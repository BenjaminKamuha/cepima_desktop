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
    public partial class User_personnels_display : UserControl
    {
        public User_personnels_display()
        {
            InitializeComponent();
            LoadPersonnel();
            //MesClasses.ReceptionManager.MoveLabel(label1,panel1);
        }

        public  void LoadPersonnel(params string[] args)
        {
            panel_personnel_display.Controls.Clear();
            if (args.Length != 0)
            {
                try
                {
                    string query = "SELECT id_personnel,CONCAT(nom,' ',post_nom) AS Personnel,fonction FROM personnels WHERE CONCAT(nom,' ',post_nom) LIKE @search OR nom LIKE @search OR post_nom";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@search", "%" + args[0] + "%");
                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string idPersonnel = reader["id_personnel"].ToString();
                                string patient = reader["Personnel"].ToString();
                                string fonction = reader["fonction"].ToString();
                                Panel panPatient = new Panel();
                                panPatient.Size = new Size(140, 130);
                                panPatient.BorderStyle = BorderStyle.FixedSingle;
                                MesClasses.ManagerClasse.AddControl(panel_personnel_display, panPatient, 10, 10);

                                PictureBox picture = MesClasses.ManagerClasse.AddPicture(Properties.Resources.male_user_90px, new Point(40, 2),
                                    new Size(60, 60));
                                panPatient.Controls.Add(picture);

                                Label lbNom = MesClasses.ManagerClasse.CustomLabel(patient, new Point(20, 70));
                                lbNom.AutoSize = true;
                                lbNom.Font = new System.Drawing.Font("Calibri", 9, FontStyle.Bold);
                                panPatient.Controls.Add(lbNom);

                                Label lbfonction = MesClasses.ManagerClasse.CustomLabel(fonction, new Point(40, 85));
                                lbfonction.AutoSize = true;
                                lbfonction.Font = new System.Drawing.Font("Calibri", 8, FontStyle.Bold);
                                panPatient.Controls.Add(lbfonction);

                                RoundedButton bt_details = MesClasses.ManagerClasse.Rbutton("Détails", new Point(30, 105), new Size(80, 20), Color.FromArgb(7, 51, 131), Color.White);
                                bt_details.BorderRadius = 4;
                                bt_details.BorderSize = 0;
                                bt_details.BorderColor = Color.FromArgb(44, 123, 229);
                                bt_details.HoverBackColor = Color.FromArgb(44, 123, 229);
                                bt_details.Tag = idPersonnel;
                                panPatient.Controls.Add(bt_details);
                                bt_details.Click += (s, e) =>
                                {
                                    MesUserCases.UC_detail_personnel personnel = new UC_detail_personnel(idPersonnel);
                                    personnel.Dock = DockStyle.Fill;
                                    panel_personnel_display.Controls.Clear();
                                    panel_personnel_display.Controls.Add(personnel);
                                    tb_search_personnel.Enabled = false;
                                };
                            }
                            reader.Close();
                            ProgressiveDisplay pd = new ProgressiveDisplay(panel_personnel_display, 50);
                            pd.Start();
                        }
                        else
                        {
                            panel_personnel_display.Controls.Clear();
                            lb_not_found.Text = "Aucun nom ne correspond aux terme de recherche '" + args[0] + "'";
                            panel_personnel_display.Controls.Add(lb_not_found);
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
                    string query = "SELECT id_personnel,CONCAT(nom,' ',post_nom) AS Personnel,fonction FROM personnels ORDER BY nom ASC";
                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,null,true))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string idPersonnel = reader["id_personnel"].ToString();
                                string patient = reader["Personnel"].ToString();
                                string fonction = reader["fonction"].ToString();
                                Panel panPatient = new Panel();
                                panPatient.Size = new Size(140, 130);
                                panPatient.BorderStyle = BorderStyle.FixedSingle;
                                MesClasses.ManagerClasse.AddControl(panel_personnel_display, panPatient, 10, 10);

                                PictureBox picture = MesClasses.ManagerClasse.AddPicture(Properties.Resources.male_user_90px, new Point(40, 2),
                                    new Size(60, 60));
                                panPatient.Controls.Add(picture);

                                Label lbNom = MesClasses.ManagerClasse.CustomLabel(patient, new Point(20, 70));
                                lbNom.AutoSize = true;
                                lbNom.Font = new System.Drawing.Font("Calibri", 9, FontStyle.Bold);
                                panPatient.Controls.Add(lbNom);

                                Label lbfonction = MesClasses.ManagerClasse.CustomLabel(fonction, new Point(40, 85));
                                lbfonction.AutoSize = true;
                                lbfonction.Font = new System.Drawing.Font("Calibri", 8, FontStyle.Bold);
                                panPatient.Controls.Add(lbfonction);

                                RoundedButton bt_details = MesClasses.ManagerClasse.Rbutton("Détails", new Point(30, 105), new Size(80,20), Color.FromArgb(7, 51, 131), Color.White);
                                bt_details.BorderRadius = 4;
                                bt_details.BorderSize = 0;
                                bt_details.BorderColor = Color.FromArgb(44, 123, 229);
                                bt_details.HoverBackColor = Color.FromArgb(44, 123, 229);
                                bt_details.Tag = idPersonnel;
                                panPatient.Controls.Add(bt_details);
                                bt_details.Click += (s, e) =>
                                {
                                    MesUserCases.UC_detail_personnel personnel = new UC_detail_personnel(idPersonnel);
                                    personnel.Dock = DockStyle.Fill;
                                    panel_personnel_display.Controls.Clear();
                                    panel_personnel_display.Controls.Add(personnel);
                                    tb_search_personnel.Enabled = false;
                                };
                            }
                            reader.Close();
                            ProgressiveDisplay pd = new ProgressiveDisplay(panel_personnel_display, 50);
                            pd.Start();
                        }
                        else
                        {
                            lb_not_found.Text = "Aucun personnel dans le registre";
                            lb_not_found.Visible = true;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erreur : "+ex.Message);
                }
            }
            

        }

        private void tb_search_personnel_TextChanged(object sender, EventArgs e)
        {
            panel_personnel_display.Controls.Clear();
            LoadPersonnel(tb_search_personnel.Text);
        }
    }
}
