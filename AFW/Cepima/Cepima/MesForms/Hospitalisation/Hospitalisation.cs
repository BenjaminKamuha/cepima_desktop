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
    public partial class Hospitalisation : Form
    {
        string PatientID;
        public Hospitalisation(string id_patient)
        {
            InitializeComponent();
            this.PatientID = id_patient;
        }

        private void Hospitalisation_Load(object sender, EventArgs e)
        {
            LoadDataAdministratives();
            ChargerServicesEtChambres();
        }

        //méthode pour charger les informations administratives du patient
        private void LoadDataAdministratives()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string query = "SELECT nom,post_nom,sexe,date_naissance FROM patients WHERE id_patient = @id";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@id", PatientID);
                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                    {
                        if (reader.Read())
                        {
                            lb_nom.Text = reader["nom"].ToString();
                            lb_postnom.Text = reader["post_nom"].ToString();
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

        private void bt_add_hospitalisation_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();
                int  idHospitalisation;
                int? id_consultation = null;

                using (MySqlCommand cmd = new MySqlCommand(
     "SELECT id FROM consultation WHERE patient_id = @id ORDER BY id DESC LIMIT 1",
     con, tr))
                {
                    cmd.Parameters.AddWithValue("@id", PatientID);

                    object resultat = cmd.ExecuteScalar();

                    if (resultat != null && resultat != DBNull.Value)
                    {
                        id_consultation = Convert.ToInt32(resultat);
                    }
                }
                try
                {
                    string queryHospi = "INSERT INTO hospitalisation(id_patient,id_centre,id_service,id_consultation,date_entree,motif,etat)VALUES(@id_patient,@id_centre,@id_service,@id_consultation,CURDATE(),@motif,'Hospitalisé')";
                    using (MySqlCommand cmd = new MySqlCommand(queryHospi, con, tr))
                    {
                        cmd.Parameters.AddWithValue("@id_patient",PatientID);
                        cmd.Parameters.AddWithValue("@id_centre",SessionUtilisateur.idCentre);
                        cmd.Parameters.AddWithValue("@id_service",cbx_service.SelectedValue);
                        cmd.Parameters.AddWithValue("@id_consultation",id_consultation.HasValue ? (object)id_consultation.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@motif",tb_motif.Text);
                        cmd.ExecuteNonQuery();
                        idHospitalisation = Convert.ToInt32(cmd.LastInsertedId);
                    }

                    // Affectation de la chambre
                    string queryAffectation = "INSERT INTO affectation_chambre(id_hospitalisation,id_chambre,date_debut)VALUES(@id_hospitalisation,@id_chambre,CURDATE())";
                    using (MySqlCommand cmd = new MySqlCommand(queryAffectation,con,tr))
                    {
                        cmd.Parameters.AddWithValue("@id_hospitalisation",idHospitalisation);
                        cmd.Parameters.AddWithValue("@id_chambre",cbx_chambre.SelectedValue);
                        cmd.ExecuteNonQuery();
                    }

                    // Changer le statut de la chambre affecté (Passer de disponible à Occupée)
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE chambre SET statut ='Occupée' WHERE id_chambre = @id",con,tr))
                    {
                        cmd.Parameters.AddWithValue("@id",cbx_chambre.SelectedValue);
                        cmd.ExecuteNonQuery();
                    }
                    tr.Commit();
                    MessageBox.Show("Hospitalisation et affectation chambre réussies avec succès !!");
                    
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Erreur : "+ex.Message);
                }
            }
        }

        private void ChargerServicesEtChambres()
        {
            try
            {
                // =====================================================
                // CHARGER LES SERVICES
                // =====================================================

                string queryService = "SELECT id_service, nom FROM service WHERE actif = 1 ORDER BY nom ASC";

                MesClasses.ManagerClasse.request_params.Clear();

                DataTable dtService = new DataTable();

                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(
                    queryService,
                    MesClasses.ManagerClasse.request_params,
                    true))
                {
                    dtService.Load(reader);
                }

                cbx_service.DataSource = dtService;
                cbx_service.DisplayMember = "nom";
                cbx_service.ValueMember = "id_service";

                if (cbx_service.Items.Count > 0)
                    cbx_service.SelectedIndex = 0;


                // =====================================================
                // CHARGER LES CHAMBRES
                // =====================================================

                string queryChambre = "SELECT id_chambre, numero_chambre, tarif_journalier FROM chambre ORDER BY numero_chambre ASC";

                MesClasses.ManagerClasse.request_params.Clear();

                DataTable dtChambre = new DataTable();

                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(
                    queryChambre,
                    MesClasses.ManagerClasse.request_params,
                    true))
                {
                    dtChambre.Load(reader);
                }

                // Ajouter une colonne pour l'affichage personnalisé
                dtChambre.Columns.Add("affichage", typeof(string));

                foreach (DataRow row in dtChambre.Rows)
                {
                    string numero = row["numero_chambre"].ToString();

                    string tarif = "0";

                    if (row["tarif_journalier"] != DBNull.Value)
                    {
                        tarif = Convert.ToDecimal(row["tarif_journalier"]).ToString("N2") + "$/Jour";
                    }

                    row["affichage"] = "Chambre N° : " + numero + " - " + tarif;
                }

                cbx_chambre.DataSource = dtChambre;
                cbx_chambre.DisplayMember = "affichage";
                cbx_chambre.ValueMember = "id_chambre";

                if (cbx_chambre.Items.Count > 0)
                    cbx_chambre.SelectedIndex = 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des services et chambres :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

    }
    
}
