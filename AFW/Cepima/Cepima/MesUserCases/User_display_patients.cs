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
            GlobalPanel_detail = fl_patient;
        }

        // LoadPatient
        private void LoadPatient()
        {
            try
            {
                string query = "SELECT id_patient,nom,post_nom FROM patients ORDER BY nom ASC";
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,null,true))
                {
                    while (reader.Read())
                    {
                        string idPatient = reader["id_patient"].ToString();
                        string patient = reader["nom"]+ " " +reader["post_nom"];
                        Panel panPatient = new Panel();
                        panPatient.Size = new Size(140,130);
                        panPatient.BorderStyle = BorderStyle.FixedSingle;
                        MesClasses.ManagerClasse.AddControl(fl_patient,panPatient,15,10);

                        PictureBox picture = MesClasses.ManagerClasse.AddPicture(Properties.Resources.male_user_90px,new Point(30,2),
                            new Size(80,80));
                        panPatient.Controls.Add(picture);

                        Label lbNom = MesClasses.ManagerClasse.CustomLabel(patient, new Point(20, 85));
                        lbNom.AutoSize = true;
                        lbNom.Font = new System.Drawing.Font("Calibri",9,FontStyle.Bold);
                        panPatient.Controls.Add(lbNom);

                        RoundedButton bt_details = MesClasses.ManagerClasse.Rbutton("Détails", new Point(30, 105), new Size(80, 20), Color.FromArgb(7, 51, 131), Color.White);
                        bt_details.BorderRadius = 4;
                        bt_details.BorderSize = 0;
                        bt_details.BorderColor = Color.FromArgb(44, 123, 229);
                        bt_details.HoverBackColor = Color.FromArgb(44,123, 229);
                        bt_details.Tag = idPatient;
                        bt_details.Click += (s, e) =>
                        {
                            User_detail_patient detailt = new User_detail_patient(idPatient);
                            detailt.Dock = DockStyle.None;
                            GlobalPanel_detail.Controls.Clear();
                            GlobalPanel_detail.Controls.Add(detailt);
                        };
                        panPatient.Controls.Add(bt_details);
                    }
                    reader.Close();
                    ProgressiveDisplay pd = new ProgressiveDisplay(fl_patient, 100);
                    pd.Start();
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Erreur : "+ex.Message);
            }
            
        }
    }
}
