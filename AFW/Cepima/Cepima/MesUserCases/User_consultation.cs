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
            string centre = "";
            //récuperer le centre en fonction du personnel chosies
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string query = "SELECT id_centre FROM personnels WHERE id_personnel = @PersonnelId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@personnel",personnelId);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    centre = Convert.ToString(result);
                }
            }

            // ============================== Appel de la méthode d'ajout de la consultation
            MesClasses.ReceptionManager.EnregistrerConsultation
                (
                    patientId,
                    centre,
                    personnelId,
                    motif,
                    description
                );
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

    }
}
