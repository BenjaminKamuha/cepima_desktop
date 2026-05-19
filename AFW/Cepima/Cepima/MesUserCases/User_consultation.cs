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
            //MesClasses.ReceptionManager.MoveLabel(label1,panel1);
            LoadDataPersonnelPatient();
            LoadPatient();
        }

        // ============================ Charger les patients et les personnels dans leurs comboBox respectif =============================================
        private void LoadDataPersonnelPatient()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();
                try
                {
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

        //private void bt_save_hospitalisation_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
        //        {
        //            //récuperons d'abord le dernier id de la consultation
        //            string query = "SELECT id_consultation FROM consultation WHERE id_patient = @id ORDER BY id_consultation DESC LIMIT 1";
        //            MySqlCommand cmdSelect = new MySqlCommand(query,con);
        //            cmdSelect.Parameters.AddWithValue("@id",cbx_patient.SelectedValue);
        //            int idConsultation = Convert.ToInt32(cmdSelect.ExecuteScalar());
        //            // Enregistrement de l'hospitalisation
        //            string queryInsert = "INSERT INTO hospitalisation(id_patient,id_centre,id_service,id_consultation,date_entree,motif,etat)VALUES(@patient,@centre,@service,@consultation,CURDATE(),@motif,@etat)";
        //            MySqlCommand cmd = new MySqlCommand(queryInsert,con);
        //            cmd.Parameters.AddWithValue("@patient",cbx_patient.SelectedValue);
        //            cmd.Parameters.AddWithValue("@centre",MesForms.SessionUtilisateur.idCentre);
        //            cmd.Parameters.AddWithValue("@service",cbx_service.SelectedValue);
        //            cmd.Parameters.AddWithValue("@consultation",idConsultation);
        //            cmd.Parameters.AddWithValue("@motif",tb_motif.Text);
        //            cmd.Parameters.AddWithValue("@etat",cbx_statut.SelectedItem);
        //            cmd.ExecuteNonQuery();

        //            MessageBox.Show("Patient hospitalisé !!");
        //            cbx_statut.SelectedIndex = -1;
        //            cbx_service.SelectedIndex = -1;
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("Erreur : "+ex.Message);
        //    }
        //}

        private void bt_save_consultation_Click_1(object sender, EventArgs e)
        {
            string personnelId = cbx_personnel.SelectedValue.ToString();
            string motif = tb_motif.Text;
            string description = rich_description.Text;
            // ============================== Appel de la méthode d'ajout de la consultation
            MesClasses.ReceptionManager.EnregistrerConsultation(idPatient.ToString(), MesForms.SessionUtilisateur.idCentre.ToString(), personnelId, motif, description);

            // =========================== mettre en jour le champs booleen de la table signes vitaux =================
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string query = "UPDATE  signes_vitaux SET is_counsel = 1 WHERE id_patient = @id";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@id",idPatient);
                cmd.ExecuteNonQuery();
            }
            LoadPatient();
        }

        private void LoadPatient()
        {
            fl_patient.Controls.Clear();

            try
            {
                string query = "SELECT p.id_patient,p.nom,p.post_nom FROM signes_vitaux s JOIN patients p ON p.id_patient = s.id_patient WHERE is_counsel = 0";

                MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, null, true);

                while (reader.Read())
                {
                    AjouterPanel(
                        reader["id_patient"].ToString(),
                        reader["nom"].ToString(),
                        reader["post_nom"].ToString()
                    );
                }

                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur patient " + ex.Message);
            }
        }
        private void AjouterPanel(string id, string nom, string postNom)
        {
            Panel panelPatient = new Panel
            {
                Size = new Size(180, 60),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
            };

            PictureBox picture = new PictureBox
            {
                Location = new Point(10, 5),
                Size = new Size(35, 35),
                Image = Properties.Resources.round_user,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            panelPatient.Controls.Add(picture);

            Label labelNom = new Label
            {
                Text = nom + " " + postNom,
                Location = new Point(50, 20),
                AutoSize = true,
                Font = new Font("Consolas", 8, FontStyle.Bold)
            };

            panelPatient.Controls.Add(labelNom);

            CheckBox chk = new CheckBox
            {
                Tag = id,
                AutoSize = true,
                Location = new Point(160, 40)
            };

            chk.CheckedChanged += chkClient_CheckedChanged;

            panelPatient.Controls.Add(chk);

            fl_patient.Controls.Add(panelPatient);
        }
        int idPatient;
        void chkClient_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;

            if (chk.Checked)
            {
                foreach (Panel p in fl_patient.Controls.OfType<Panel>())
                {
                    foreach (CheckBox c in p.Controls.OfType<CheckBox>())
                    {
                        if (c != chk)
                        {
                            c.Checked = false;
                        }
                    }
                }

                idPatient = Convert.ToInt32(chk.Tag);
            }
            else
            {
                idPatient = 0;
            }
        }

        // ===================================  partie prescription =====================================
        private void ChargerMedicament(params string[] args)
        {
            if (args.Length != 0)
            {
                try
                {

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erreur lors du chargement de données :"+ex.Message);
                }
            }
            else
            {
                try
                {

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erreur de chargement de données :"+ex.Message);
                }
            }
        }
    }
}
