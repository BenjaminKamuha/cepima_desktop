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
           
        }

        private void LoadPersonnel()
        {
            try
            {
                string query = "SELECT id_personnel,nom,post_nom,fonction FROM personnels ORDER BY nom ASC";
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, null, true))
                {
                    while (reader.Read())
                    {
                        string idPatient = reader["id_personnel"].ToString();
                        string patient = reader["nom"] + " " + reader["post_nom"];
                        string fonction = reader["fonction"].ToString();
                        Panel panPatient = new Panel();
                        panPatient.Size = new Size(140, 130);
                        panPatient.BorderStyle = BorderStyle.FixedSingle;
                        MesClasses.ManagerClasse.AddControl(panel_personnel_display, panPatient,30,30);

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
                            //User_detail_patient detailt = new User_detail_patient(idPatient);
                            //detailt.Dock = DockStyle.None;
                            //GlobalPanel_detail.Controls.Clear();
                            //GlobalPanel_detail.Controls.Add(detailt);
                        };

                        Label lbfonction = MesClasses.ManagerClasse.CustomLabel(fonction, new Point(30, 105));
                        lbfonction.AutoSize = true;
                        lbfonction.Font = new System.Drawing.Font("Calibri", 9, FontStyle.Bold);
                        panPatient.Controls.Add(lbfonction);
                        //panPatient.Controls.Add(bt_details);
                    }
                    reader.Close();
                    ProgressiveDisplay pd = new ProgressiveDisplay(panel_personnel_display, 100);
                    pd.Start();
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Erreur : " + ex.Message);
            }

        }
    }
}
