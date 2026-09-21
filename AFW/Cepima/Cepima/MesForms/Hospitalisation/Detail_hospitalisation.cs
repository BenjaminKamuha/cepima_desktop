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
                p.id AS id_prescription,
                pl.id AS id_ligne,
                pl.medicament_id,

                CONCAT(
                    m.nom,
                    IFNULL(CONCAT(' ', m.dosage), '')
                ) AS medicament,

                pl.quantite_prescrite AS prescrit,

                COALESCE(
                    (
                        SELECT SUM(dl.quantite)
                        FROM dispensation_ligne dl

                        INNER JOIN dispensation d
                            ON d.id = dl.dispensation_id

                        WHERE d.prescription_id = p.id
                          AND dl.medicament_id = pl.medicament_id
                    ),
                    0
                ) AS delivre

            FROM prescription p

            INNER JOIN prescription_ligne pl
                ON pl.prescription_id = p.id

            INNER JOIN medicament m
                ON m.id = pl.medicament_id

            WHERE p.patient_id = @id_patient

            ORDER BY
                p.date_prescription DESC,
                pl.id ASC";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_patient",
                    id_patient
                );

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    while (reader.Read())
                    {
                        int idPrescription =
                            Convert.ToInt32(
                                reader["id_prescription"]);

                        int idMedicament =
                            Convert.ToInt32(
                                reader["medicament_id"]);

                        int prescrit =
                            reader["prescrit"] == DBNull.Value
                            ? 0
                            : Convert.ToInt32(
                                reader["prescrit"]);

                        int delivre =
                            reader["delivre"] == DBNull.Value
                            ? 0
                            : Convert.ToInt32(
                                reader["delivre"]);

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

                        int row =
                            dgv_prescription.Rows.Add();

                        dgv_prescription.Rows[row]
                            .Cells["colIdPrescription"].Value =
                            idPrescription;

                        dgv_prescription.Rows[row]
                            .Cells["colIdMedicament"].Value =
                            idMedicament;

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

        private List<MedicamentADeLivrer> ChargerMedicamentsPrescription(
    int idPrescription)
        {
            List<MedicamentADeLivrer> liste =
                new List<MedicamentADeLivrer>();

            try
            {
                string query = @"
            SELECT
                pl.prescription_id,
                pl.medicament_id,

                m.nom AS produit,
                m.dosage,
                m.FORME,

                pl.dose,
                pl.frequence,
                pl.duree,

                pl.quantite_prescrite,

                COALESCE(
                    (
                        SELECT SUM(dl.quantite)
                        FROM dispensation_ligne dl

                        INNER JOIN dispensation d
                            ON d.id = dl.dispensation_id

                        WHERE d.prescription_id =
                              pl.prescription_id

                          AND dl.medicament_id =
                              pl.medicament_id
                    ),
                    0
                ) AS quantite_delivree

            FROM prescription_ligne pl

            INNER JOIN medicament m
                ON m.id = pl.medicament_id

            WHERE pl.prescription_id =
                  @idPrescription

            ORDER BY pl.id";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@idPrescription",
                    idPrescription.ToString()
                );

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    while (reader.Read())
                    {
                        MedicamentADeLivrer medicament =
                            new MedicamentADeLivrer();

                        medicament.IdPrescription =
                            Convert.ToInt32(
                                reader["prescription_id"]);

                        medicament.IdMedicament =
                            Convert.ToInt32(
                                reader["medicament_id"]);

                        medicament.Nom =
                            reader["produit"].ToString();

                        medicament.Dosage =
                            reader["dosage"] == DBNull.Value
                                ? ""
                                : reader["dosage"].ToString();

                        medicament.Forme =
                            reader["FORME"] == DBNull.Value
                                ? ""
                                : reader["FORME"].ToString();

                        medicament.Dose =
                            reader["dose"] == DBNull.Value
                                ? ""
                                : reader["dose"].ToString();

                        medicament.Frequence =
                            reader["frequence"] == DBNull.Value
                                ? ""
                                : reader["frequence"].ToString();

                        medicament.Duree =
                            reader["duree"] == DBNull.Value
                                ? ""
                                : reader["duree"].ToString();

                        medicament.QuantitePrescrite =
                            Convert.ToInt32(
                                reader["quantite_prescrite"]);

                        medicament.QuantiteDelivree =
                            Convert.ToInt32(
                                reader["quantite_delivree"]);

                        // Ajouter uniquement les médicaments
                        // qui ont encore quelque chose à délivrer
                        if (medicament.QuantiteRestante > 0)
                        {
                            liste.Add(medicament);
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des médicaments de la prescription :\n\n" +
                    ex.Message,
                    "Délivrance",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return liste;
        }
        private void bt_delivrer_Click(object sender, EventArgs e)
        {
            // =====================================================
            // 1. RÉCUPÉRER TOUTES LES PRESCRIPTIONS DU DATAGRIDVIEW
            // =====================================================

            List<int> prescriptions =
                new List<int>();

            foreach (DataGridViewRow row
                in dgv_prescription.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (row.Cells["colIdPrescription"].Value == null)
                    continue;

                int idPrescription =
                    Convert.ToInt32(
                        row.Cells["colIdPrescription"].Value);

                // Éviter les doublons
                if (!prescriptions.Contains(idPrescription))
                {
                    prescriptions.Add(idPrescription);
                }
            }


            // =====================================================
            // 2. VÉRIFIER QU'IL EXISTE DES PRESCRIPTIONS
            // =====================================================

            if (prescriptions.Count == 0)
            {
                MessageBox.Show(
                    "Aucune prescription n'est disponible pour ce patient.",
                    "Délivrance",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }


            // =====================================================
            // 3. TRAITER CHAQUE PRESCRIPTION
            // =====================================================

            foreach (int idPrescription
                in prescriptions)
            {
                List<MedicamentADeLivrer> medicaments =
                    ChargerMedicamentsPrescription(
                        idPrescription);


                // -------------------------------------------------
                // Cette prescription est déjà entièrement délivrée
                // -------------------------------------------------

                if (medicaments.Count == 0)
                {
                    continue;
                }


                // =================================================
                // 4. OUVRIR LE FORMULAIRE DE DÉLIVRANCE
                // =================================================

                using (Delivrance_Medoc formulaire =
                    new Delivrance_Medoc(
                        id_patient,
                        idPrescription,
                        medicaments))
                {
                    DialogResult resultat =
                        formulaire.ShowDialog();

                    if (resultat == DialogResult.OK)
                    {
                        // Actualiser les données
                        ChargerPrescriptions();
                    }
                }
            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
