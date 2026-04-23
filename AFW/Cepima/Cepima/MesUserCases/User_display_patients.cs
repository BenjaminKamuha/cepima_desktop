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
    public partial class User_display_patients : UserControl
    {
        public static Panel GlobalPanel_detail { get; set; }
        public User_display_patients()
        {
            InitializeComponent();
            LoadPatient();
            MesClasses.ReceptionManager.MoveLabel(label1,panel1);
        }

        private void LoadPatient(params string [] args)
        {
            panel_patient.Controls.Clear();
            if (args.Length != 0)
            {
                try
                {
                    string query = "SELECT id_patient,CONCAT(nom,' ',post_nom) AS Patient FROM patients WHERE CONCAT(nom,' ',post_nom) LIKE @search OR nom LIKE @search OR post_nom";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@search", "%" + args[0] + "%");
                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string idPatient = reader["id_patient"].ToString();
                                string patient = reader["Patient"].ToString();
                                Panel panPatient = new Panel();
                                panPatient.Size = new Size(140, 130);
                                panPatient.BorderStyle = BorderStyle.FixedSingle;
                                MesClasses.ManagerClasse.AddControl(panel_patient, panPatient, 15, 10);

                                PictureBox picture = MesClasses.ManagerClasse.AddPicture(Properties.Resources.male_user_90px, new Point(30, 2),
                                    new Size(80, 80));
                                panPatient.Controls.Add(picture);

                                Label lbNom = MesClasses.ManagerClasse.CustomLabel(patient, new Point(20, 85));
                                lbNom.AutoSize = true;
                                lbNom.Font = new System.Drawing.Font("Calibri", 9, FontStyle.Bold);
                                panPatient.Controls.Add(lbNom);

                                RoundedButton bt_details = MesClasses.ManagerClasse.Rbutton("Détails", new Point(30, 105), new Size(80, 20), Color.FromArgb(7, 51, 131), Color.White);
                                bt_details.BorderRadius = 4;
                                bt_details.BorderSize = 0;
                                bt_details.BorderColor = Color.FromArgb(44, 123, 229);
                                bt_details.HoverBackColor = Color.FromArgb(44, 123, 229);
                                bt_details.Tag = idPatient;
                                bt_details.Click += (s, e) =>
                                {
                                    User_detail_patient details = new User_detail_patient(idPatient);
                                    details.Dock = DockStyle.None;
                                    panel_patient.Controls.Clear();
                                    panel_patient.Controls.Add(details);
                                    tb_search_patient.Enabled = false;
                                };
                                panPatient.Controls.Add(bt_details);
                            }
                            reader.Close();
                            ProgressiveDisplay pd = new ProgressiveDisplay(panel_patient, 100);
                            pd.Start();
                        }
                        else
                        {
                            panel_patient.Controls.Clear();
                            lb_not_found.Text = "Aucun nom ne correspond aux terme de recherche '" + args[0] + "'";
                            panel_patient.Controls.Add(lb_not_found);
                            lb_not_found.Visible = true;
                        }
                     
                    }
                }
                catch (MySqlException ex)
                {

                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
            else
            {
                try
                {
                    string query = "SELECT id_patient,CONCAT(nom,' ',post_nom) AS Patient FROM patients ORDER BY nom ASC";
                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, null, true))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string idPatient = reader["id_patient"].ToString();
                                string patient = reader["Patient"].ToString();
                                Panel panPatient = new Panel();
                                panPatient.Size = new Size(140, 130);
                                panPatient.BorderStyle = BorderStyle.FixedSingle;
                                MesClasses.ManagerClasse.AddControl(panel_patient, panPatient, 15, 10);

                                PictureBox picture = MesClasses.ManagerClasse.AddPicture(Properties.Resources.male_user_90px, new Point(30, 2),
                                    new Size(80, 80));
                                panPatient.Controls.Add(picture);

                                Label lbNom = MesClasses.ManagerClasse.CustomLabel(patient, new Point(20, 85));
                                lbNom.AutoSize = true;
                                lbNom.Font = new System.Drawing.Font("Calibri", 9, FontStyle.Bold);
                                panPatient.Controls.Add(lbNom);

                                RoundedButton bt_details = MesClasses.ManagerClasse.Rbutton("Détails", new Point(30, 105), new Size(80, 20), Color.FromArgb(7, 51, 131), Color.White);
                                bt_details.BorderRadius = 4;
                                bt_details.BorderSize = 0;
                                bt_details.BorderColor = Color.FromArgb(44, 123, 229);
                                bt_details.HoverBackColor = Color.FromArgb(44, 123, 229);
                                bt_details.Tag = idPatient;
                                bt_details.Click += (s, e) =>
                                {
                                    User_detail_patient details = new User_detail_patient(idPatient);
                                    details.Dock = DockStyle.None;
                                    panel_patient.Controls.Clear();
                                    panel_patient.Controls.Add(details);
                                    tb_search_patient.Enabled = false;
                                };
                                panPatient.Controls.Add(bt_details);
                            }
                            reader.Close();
                            ProgressiveDisplay pd = new ProgressiveDisplay(panel_patient, 100);
                            pd.Start();
                        }
                        else
                        {
                            lb_not_found.Text = "Aucun patient dans le registre";
                            lb_not_found.Visible = true;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erreur  : "+ex.Message);
                }
            }
         
        }

        private void tb_search_patient_TextChanged(object sender, EventArgs e)
        {
            panel_patient.Controls.Clear();
            LoadPatient(tb_search_patient.Text);
        }
    }
}
