using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Cepima.MesUserCases
{
    public partial class User_consultation : UserControl
    {
        public User_consultation()
        {
            InitializeComponent();
            MesClasses.ReceptionManager.MoveLabel(label1,panel1);
            LoadDataPersonnelPatient();
        }

        private void bt_save_consultation_Click(object sender, EventArgs e)
        {

            string patientId = cbx_patient.SelectedValue.ToString();
            string personnelId = cbx_personnel.SelectedValue.ToString();
            string motif = tb_motif.Text;
            string description = rich_description.Text;
            // ============================== Appel de la méthode d'ajout de la consultation
            MesClasses.ReceptionManager.EnregistrerConsultation(patientId,MesForms.SessionUtilisateur.idCentre.ToString(),personnelId,motif,description);
        }

        // ============================ Charger les patients et les personnels dans leurs comboBox respectif =============================================
        private void LoadDataPersonnelPatient()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();
                try
                {
                   // ============================================ les patients =====================================
                    string queryPatient = "SELECT id_patient,CONCAT(numero_fiche,'  ',nom,' ',post_nom,' ',prenom) AS namePatient FROM patients ORDER BY nom ASC";
                    using (MySqlCommand cmdPatient = new MySqlCommand(queryPatient,con,tr))
                    {
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmdPatient))
                        {
                            da.Fill(dt);
                            cbx_patient.DataSource = dt;
                            cbx_patient.ValueMember = "id_patient";
                            cbx_patient.DisplayMember = "namePatient";
                            cbx_patient.SelectedIndex = -1;
                        }
                    }

                    // ========================================== les personnels ==================================
                    string queryPersonnel = "SELECT id_personnel,CONCAT(nom,' ',post_nom,' ',prenom) AS nomPersonnel FROM personnels ORDER BY nom ASC";
                    using (MySqlCommand cmd = new MySqlCommand(queryPersonnel, con, tr))
                    {
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            cbx_personnel.DataSource = dt;
                            cbx_personnel.DisplayMember = "nomPersonnel";
                            cbx_personnel.ValueMember = "id_personnel";
                            cbx_personnel.SelectedIndex = -1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Erreur lors du chargement de données "+ex.Message);
                }
            }
        }

        private void bt_display_panel_hospitalisation_Click(object sender, EventArgs e)
        {
            panel_hospit.Visible = true;
        }

        private void bt_save_hospitalisation_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    //récuperons d'abord le dernier id de la consultation
                    string query = "SELECT id_consultation FROM consultation WHERE id_patient = @id ORDER BY id_consultation DESC LIMIT 1";
                    MySqlCommand cmdSelect = new MySqlCommand(query,con);
                    cmdSelect.Parameters.AddWithValue("@id",cbx_patient.SelectedValue);
                    int idConsultation = Convert.ToInt32(cmdSelect.ExecuteScalar());
                    // Enregistrement de l'hospitalisation
                    string queryInsert = "INSERT INTO hospitalisation(id_patient,id_centre,id_service,id_consultation,date_entree,motif,etat)VALUES(@patient,@centre,@service,@consultation,CURDATE(),@motif,@etat)";
                    MySqlCommand cmd = new MySqlCommand(queryInsert,con);
                    cmd.Parameters.AddWithValue("@patient",cbx_patient.SelectedValue);
                    cmd.Parameters.AddWithValue("@centre",MesForms.SessionUtilisateur.idCentre);
                    cmd.Parameters.AddWithValue("@service",cbx_service.SelectedValue);
                    cmd.Parameters.AddWithValue("@consultation",idConsultation);
                    cmd.Parameters.AddWithValue("@motif",tb_motif.Text);
                    cmd.Parameters.AddWithValue("@etat",cbx_statut.SelectedItem);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Patient hospitalisé !!");
                    cbx_statut.SelectedIndex = -1;
                    cbx_service.SelectedIndex = -1;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur : "+ex.Message);
            }
        }

    }
}
