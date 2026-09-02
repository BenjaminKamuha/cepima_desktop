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
            //MesClasses.ReceptionManager.MoveLabel(label1,panel1);
        }

        private void LoadPatient(params string [] args)
        {
            panel_patient.Controls.Clear();
            if (args.Length != 0)
            {
                try
                {
                    string query = "SELECT id_patient,nom,post_nom,numero_fiche FROM patients WHERE nom LIKE @search OR post_nom LIKE @search ";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@search", "%" + args[0] + "%");
                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                    {
                        int i = 0;
                        if (reader.HasRows)
                        {
                           
                            while (reader.Read())
                            {
                                string idPatient = reader["id_patient"].ToString();
                                string nom = reader["nom"].ToString();
                                string postnom = reader["post_nom"].ToString();
                                string numero = reader["numero_fiche"].ToString();

                                CustomRoundedPanel panPatient = new CustomRoundedPanel();
                                panPatient.Size = new Size(160, 130);
                                panPatient.BorderRadius = 8;
                                panPatient.BorderColor = Color.Silver;
                                panPatient.BorderSize = 1;
                                panPatient.Tag = idPatient;
                                MesClasses.ManagerClasse.AddControl(panel_patient, panPatient, 10, 8);


                                // evenement Hover du panel pour déclencher l'ouverture du Formulaire détail
                                panPatient.MouseHover += (s, e) =>
                                    {
                                        //MesForms.FormDetailPatient detail = new MesForms.FormDetailPatient(idPatient);
                                        //detail.ShowDialog();
                                    };
                                PictureBox picture = MesClasses.ManagerClasse.AddPicture(Properties.Resources.male_user_90px, new Point(2, 5),
                                    new Size(70, 70));
                                panPatient.Controls.Add(picture);

                                Label lbNom = MesClasses.ManagerClasse.CustomLabel(nom, new Point(70, 20));
                                lbNom.AutoSize = true;
                                lbNom.Font = new System.Drawing.Font("Calibri", 10, FontStyle.Bold);
                                panPatient.Controls.Add(lbNom);

                                Label lbPost = MesClasses.ManagerClasse.CustomLabel(postnom, new Point(70, 40));
                                lbPost.AutoSize = true;
                                lbPost.Font = new System.Drawing.Font("Calibri", 10, FontStyle.Bold);
                                panPatient.Controls.Add(lbPost);

                                Label lbFiche = MesClasses.ManagerClasse.CustomLabel(numero, new Point(10, 75));
                                lbFiche.AutoSize = true;
                                lbFiche.Font = new System.Drawing.Font("Calibri", 10, FontStyle.Bold);
                                panPatient.Controls.Add(lbFiche);

                                RoundedButton btnSuivi = MesClasses.ManagerClasse.Rbutton("Fiche de suivi", new Point(40, 100), new Size(95, 25), Color.FromArgb(44, 123, 229), Color.White);
                                btnSuivi.BorderRadius = 4;
                                btnSuivi.BorderSize = 0;
                                btnSuivi.BorderColor = Color.FromArgb(44, 123, 229);
                                btnSuivi.HoverBackColor = Color.FromArgb(7, 51, 131);
                                panPatient.Controls.Add(btnSuivi);

                                btnSuivi.Click += (e, s) =>
                                {
                                    //ouverture de la fiche de suivi du patient
                                    Form1.GlobalPanel_main.Visible = false;
                                    MesForms.Form_Fiche_suivie fiche = new MesForms.Form_Fiche_suivie(idPatient);
                                    fiche.ShowDialog();
                                    Form1.GlobalPanel_main.Visible = true;
                                };

                                i++;
                            }
                          
                            reader.Close();
                            lb_nombres.Text = i.ToString() + "Patient(s) trouvé(s)";
                            ProgressiveDisplay pd = new ProgressiveDisplay(panel_patient, 100);
                            pd.Start();
                            

                        }
                        else
                        {
                            panel_patient.Controls.Clear();
                            lb_not_found.Text = "Aucun nom ne correspond aux terme de recherche '" + args[0] + "'";
                            panel_patient.Controls.Add(lb_not_found);
                            lb_not_found.Visible = true;
                            lb_nombres.Text = i.ToString()+" Patient(s) trouvé(s)";
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
                    string query = "SELECT id_patient,nom,post_nom,numero_fiche FROM patients ORDER BY nom ASC";
                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, null, true))
                    {
                        if (reader.HasRows)
                        {
                            int i = 0;
                            while (reader.Read())
                            {
                                string idPatient = reader["id_patient"].ToString();
                                string nom = reader["nom"].ToString();
                                string postnom = reader["post_nom"].ToString();
                                string numero = reader["numero_fiche"].ToString();

                                CustomRoundedPanel panPatient = new CustomRoundedPanel();
                                panPatient.Size = new Size(160, 130);
                                panPatient.BorderRadius = 8;
                                panPatient.BorderColor = Color.Silver;
                                panPatient.BorderSize = 1;
                                panPatient.Tag = idPatient;
                               
                                MesClasses.ManagerClasse.AddControl(panel_patient, panPatient, 10, 8);

                                // evenement Hover du panel pour déclencher l'ouverture du Formulaire détail
                                panPatient.MouseHover += (s, e) =>
                                {
                                    //MesForms.FormDetailPatient details = new MesForms.FormDetailPatient(idPatient);
                                    //details.ShowDialog();
                                };

                                PictureBox picture = MesClasses.ManagerClasse.AddPicture(Properties.Resources.male_user_90px, new Point(2, 5),
                                    new Size(70, 70));
                                panPatient.Controls.Add(picture);

                                Label lbNom = MesClasses.ManagerClasse.CustomLabel(nom, new Point(70, 20));
                                lbNom.AutoSize = true;
                                lbNom.Font = new System.Drawing.Font("Calibri", 10, FontStyle.Bold);
                                panPatient.Controls.Add(lbNom);

                                Label lbPost = MesClasses.ManagerClasse.CustomLabel(postnom, new Point(70, 40));
                                lbPost.AutoSize = true;
                                lbPost.Font = new System.Drawing.Font("Calibri", 10, FontStyle.Bold);
                                panPatient.Controls.Add(lbPost);

                                Label lbFiche = MesClasses.ManagerClasse.CustomLabel(numero, new Point(10, 75));
                                lbFiche.AutoSize = true;
                                lbFiche.Font = new System.Drawing.Font("Calibri", 10, FontStyle.Bold);
                                panPatient.Controls.Add(lbFiche);
                        
                                RoundedButton btnSuivi = MesClasses.ManagerClasse.Rbutton("Fiche de suivi", new Point(40, 100), new Size(95, 25), Color.FromArgb(44, 123, 229), Color.White);
                                btnSuivi.BorderRadius = 4;
                                btnSuivi.BorderSize = 0;
                                btnSuivi.BorderColor = Color.FromArgb(44, 123, 229);
                                btnSuivi.HoverBackColor = Color.FromArgb(7, 51, 131);
                                panPatient.Controls.Add(btnSuivi);

                                btnSuivi.Click += (e, s) =>
                                    {
                                        //ouverture de la fiche de suivi du patient
                                        Form1.GlobalPanel_main.Visible = false;
                                        MesForms.Form_Fiche_suivie fiche = new MesForms.Form_Fiche_suivie(idPatient);
                                        fiche.ShowDialog();
                                        Form1.GlobalPanel_main.Visible = true;
                                    };
                                i++;
                            }
                          
                            reader.Close();
                            lb_nombres.Text = i.ToString() + " Patient(s)";
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
