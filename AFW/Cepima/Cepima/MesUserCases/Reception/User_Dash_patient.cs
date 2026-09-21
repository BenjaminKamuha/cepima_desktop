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
    public partial class User_Dash_patient : UserControl
    {
        int ID_PATIENT = 0;
        public User_Dash_patient()
        {
            InitializeComponent();
            LoadPatient();
            dgv_patient.CellContentClick += dgv_patient_CellContentClick;
            LoadResume();
        }

        // charger les patients recentes
        private void LoadPatient()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT id_patient,nom,post_nom,prenom,numero_fiche,telephone FROM patients ORDER BY date_creation DESC LIMIT 11 ",con))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                 int row = dgv_patient.Rows.Add();
                                 dgv_patient.Rows[row].Tag = reader["id_patient"];
                                 dgv_patient.Rows[row].Cells["colID"].Value = Convert.ToInt32(reader["id_patient"]);
                                 dgv_patient.Rows[row].Cells["colNom"].Value = reader["nom"].ToString();
                                 dgv_patient.Rows[row].Cells["colPostnom"].Value = reader["post_nom"].ToString();
                                 dgv_patient.Rows[row].Cells["colPrenom"].Value = reader["prenom"].ToString();
                                 dgv_patient.Rows[row].Cells["colNumero"].Value = reader["numero_fiche"].ToString();
                                 dgv_patient.Rows[row].Cells["colPhone"].Value = reader["telephone"].ToString();
                            }
                            reader.Close();

                            ApplyStyle();

                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erreur : "+ex.Message);
                }
            }

        }

        private void ApplyStyle()
        {
            dgv_patient.Columns["colSignes"].Width = 100;
            dgv_patient.Columns["action"].Width = 100;
            dgv_patient.Columns["colID"].Width = 30;
        }
        void dgv_patient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgv_patient.Columns[e.ColumnIndex].Name == "colSignes")
            {
                Form1.GlobalPanel_main.Visible = false;
                ID_PATIENT = Convert.ToInt32(dgv_patient.Rows[e.RowIndex].Tag);
                //ouverture du formulaire de prise des signes vitaux
                MesForms.Form_signes_vitaux signes = new MesForms.Form_signes_vitaux(ID_PATIENT);
                signes.ShowDialog();
                Form1.GlobalPanel_main.Visible = true;
            }

            if (dgv_patient.Columns[e.ColumnIndex].Name == "action")
            {
                Form1.GlobalPanel_main.Visible = false;
                 ID_PATIENT = Convert.ToInt32(dgv_patient.Rows[e.RowIndex].Tag);
                 MesForms.Form_Fiche_suivie fiche = new MesForms.Form_Fiche_suivie(ID_PATIENT.ToString());
                 fiche.ShowDialog();
                 Form1.GlobalPanel_main.Visible = true;
            }

            else if (dgv_patient.Columns[e.ColumnIndex].Name == "colService")
            {
                Form1.GlobalPanel_main.Visible = false;
                ID_PATIENT = Convert.ToInt32(dgv_patient.Rows[e.RowIndex].Tag);
                Form1.PATIENT_ID = ID_PATIENT;
                MesForms.Form_demander_service service = new MesForms.Form_demander_service(ID_PATIENT.ToString(), 0);
                service.ShowDialog();
                Form1.GlobalPanel_main.Visible = true;
            }
        }

        //méthode pour charger le résume
        private void LoadResume()
        {
            try
            {
                //charger les patients aujourd'hui
                string queryNow = "SELECT COUNT(*) AS Nombre FROM patients WHERE date_creation = CURDATE()";
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(queryNow,null,true))
                {
                    if (reader.Read())
                    {
                        lb_patient_now.Text = reader["Nombre"].ToString();
                    }
                    reader.Close();
                }

                // charger les patients hospitalisés
                string queryHospi = "SELECT COUNT(*) AS Nombre FROM hospitalisation WHERE date_sortie IS NULL";
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(queryHospi, null, true))
                {
                    if (reader.Read())
                    {
                        lb_hospitalise.Text = reader["Nombre"].ToString();
                    }
                    reader.Close();
                }
                
                // patients en attente
                string queryAttente = "SELECT COUNT(*) AS Nombre FROM signes_vitaux WHERE is_counsel = 0";
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(queryAttente,null,true))
                {
                    if (reader.Read())
                    {
                        lb_attente.Text = reader["Nombre"].ToString();
                    }
                    reader.Close();
                }

                // patients sortie
                string querySortie = "SELECT COUNT(*) AS Nombre FROM hospitalisation WHERE date_sortie IS NOT NULL";
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(querySortie, null, true))
                {
                    if (reader.Read())
                    {
                        lb_sorti.Text = reader["Nombre"].ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        private void bt_add_patient_Click(object sender, EventArgs e)
        {
            MesForms.Form_add_patient add = new MesForms.Form_add_patient();
            add.ShowDialog();
        }
    }
}
