using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cepima.MesForms.Hospitalisation
{
    public partial class Detail_hospitalisation : Form
    {
        string id_patient, id_hospitalisation;

        public Detail_hospitalisation(string patient, string hospitalisation)
        {
            InitializeComponent();
            this.id_patient = patient;
            this.id_hospitalisation = hospitalisation;
        }

        private void Detail_hospitalisation_Load(object sender, EventArgs e)
        {
            LoadDataAdministratives();
            ChargerDetailsHospitalisation();
            ChargerPrescriptions();
        }

        //méthode pour charger les informations administratives du patient
        private void LoadDataAdministratives()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string query = "SELECT CONCAT(nom,' ',post_nom,' ',prenom) AS Patient,CONCAT('PAT-',YEAR(date_creation),'-',numero_fiche) AS dossier,date_naissance,sexe FROM patients  WHERE id_patient = @id ";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@id", this.id_patient);
                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                    {
                        if (reader.Read())
                        {
                            lb_nom.Text = reader["Patient"].ToString();
                            lb_dossier.Text = reader["dossier"].ToString();
                            DateTime date = Convert.ToDateTime(reader["date_naissance"]);
                            int annee = MesClasses.ReceptionManager.CalculerAge(date);
                            lb_age.Text = annee.ToString() + " ans" + " - " + reader["sexe"];
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void ChargerDetailsHospitalisation()
        {
            try
            {
                string query = @"
        SELECT

            h.date_entree,
            h.date_sortie,
            h.motif,
            h.etat,

            c.numero_chambre,c.tarif_journalier,
            ac.date_debut,
            ac.date_fin

        FROM hospitalisation h

        LEFT JOIN affectation_chambre ac
            ON ac.id_hospitalisation = h.id_hospitalisation

        LEFT JOIN chambre c
            ON c.id_chambre = ac.id_chambre

        WHERE h.id_hospitalisation = @id

        ORDER BY ac.id_affectation DESC

        LIMIT 1";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id",
                    id_hospitalisation
                );

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    if (reader.Read())
                    {
                        // ==============================
                        // DATE D'ADMISSION
                        // ==============================

                        DateTime dateEntree =
                            Convert.ToDateTime(reader["date_entree"]);

                        lb_date_admission.Text =
                            dateEntree.ToString("dd/MM/yyyy");


                        // ==============================
                        // NOMBRE DE JOURS
                        // ==============================

                        DateTime dateFin;

                        if (reader["date_sortie"] != DBNull.Value)
                        {
                            dateFin =
                                Convert.ToDateTime(reader["date_sortie"]);
                        }
                        else
                        {
                            dateFin = DateTime.Today;
                        }

                        int nombreJour =
                            (dateFin.Date - dateEntree.Date).Days + 1;

                        lb_nombreJour.Text =
                            nombreJour.ToString() + " jour(s)";


                        // ==============================
                        // MOTIF
                        // ==============================

                        lb_motif.Text =
                            reader["motif"].ToString();


                        // ==============================
                        // DIAGNOSTIC
                        // ==============================

                        lb_diagnostic.Text = "-";


                        // ==============================
                        // CHAMBRE
                        // ==============================

                        if (reader["numero_chambre"] != DBNull.Value)
                        {
                            lb_chambre.Text =
                                "Chambre N° : " +
                                reader["numero_chambre"].ToString() + " /Tarif journalier : " + reader["tarif_journalier"] + " $/jours";
                        }
                        else
                        {
                            lb_chambre.Text =
                                "Non affectée";
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "Les détails de cette hospitalisation sont introuvables.",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des détails :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ChargerPrescriptions()
        {
            try
            {
                dgv_prescription.Rows.Clear();

                string query = @"
            SELECT
                pr.id_prescription,
                pr.id_medicament,

                CONCAT(
                    m.nom,
                    IFNULL(CONCAT(' ', m.dosage), '')
                ) AS medicament,

                pr.quantite AS prescrit,

                COALESCE(SUM(ds.quantite), 0) AS delivre

            FROM prescriptions pr

            INNER JOIN hospitalisation h
                ON h.id_consultation = pr.id_consultation

            INNER JOIN medicament m
                ON m.id = pr.id_medicament

            LEFT JOIN sortie_s_pa s
                ON s.id_hospitalisation = h.id_hospitalisation

            LEFT JOIN detail_sortie_s_pa ds
                ON ds.id_sortie = s.id_sortie
                AND ds.id_medicament = pr.id_medicament

            WHERE h.id_hospitalisation = @id_hospitalisation

            GROUP BY
                pr.id_prescription,
                pr.id_medicament,
                m.nom,
                m.dosage,
                pr.quantite

            ORDER BY pr.id_prescription ASC";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_hospitalisation",
                    id_hospitalisation
                );

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    while (reader.Read())
                    {
                        int prescrit =
                            reader["prescrit"] == DBNull.Value
                            ? 0
                            : Convert.ToInt32(reader["prescrit"]);

                        int delivre =
                            Convert.ToInt32(reader["delivre"]);

                        string statut;

                        if (delivre <= 0)
                        {
                            statut = "Non délivré";
                        }
                        else if (delivre < prescrit)
                        {
                            statut = "Partiel";
                        }
                        else
                        {
                            statut = "Livré";
                        }

                        int row = dgv_prescription.Rows.Add();

                        dgv_prescription.Rows[row]
                            .Cells["colIdPrescription"].Value =
                            Convert.ToInt32(reader["id_prescription"]);

                        dgv_prescription.Rows[row]
                            .Cells["colIdMedicament"].Value =
                            Convert.ToInt32(reader["id_medicament"]);

                        dgv_prescription.Rows[row]
                            .Cells["colMedicament"].Value =
                            reader["medicament"].ToString();

                        dgv_prescription.Rows[row]
                            .Cells["colPrescrit"].Value =
                            prescrit;

                        dgv_prescription.Rows[row]
                            .Cells["colDelivre"].Value =
                            delivre;

                        dgv_prescription.Rows[row]
                            .Cells["colStatut"].Value =
                            statut;
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des prescriptions :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void bt_delivrer_Click(object sender, EventArgs e)
        {
            List<MedicamentADeLivrer> medicamentsSelectionnes = new List<MedicamentADeLivrer>();

            foreach (DataGridViewRow row in dgv_prescription.Rows)
            {
                if (row.IsNewRow)
                    continue;

                bool selectionne = false;

                if (row.Cells["colSelection"].Value != null)
                {
                    selectionne = Convert.ToBoolean(row.Cells["colSelection"].Value);
                }

                if (!selectionne)
                    continue;

                MedicamentADeLivrer medicament = row.Tag as MedicamentADeLivrer;

                if (medicament != null)
                {
                    // On ne transmet pas un médicament
                    // dont la quantité restante est déjà à 0.
                    if (medicament.QuantiteRestante > 0)
                    {
                        medicamentsSelectionnes.Add(medicament);
                    }
                }
            }

            // Aucun médicament sélectionné
            if (medicamentsSelectionnes.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner au moins un médicament à délivrer.", "Délivrance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Ouverture du formulaire de délivrance
            Delivrance_Medoc dev = new Delivrance_Medoc(this.id_patient, this.id_hospitalisation, medicamentsSelectionnes);
            dev.ShowDialog();

            if (dev.ShowDialog() == DialogResult.OK)
            {
                // La délivrance a été enregistrée
                // On peut actualiser les prescriptions
                ChargerPrescriptions();
            }
        }
    }
}
