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
using System.IO;
using Cepima.MesClasses;

namespace Cepima.MesUserCases
{
    public partial class User_medicament : UserControl
    {
        public User_medicament()
        {
            InitializeComponent();
            loadMed();
        }

        private void customRoundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private Panel Pan_med(int id, string name)
        {

            // Chargement de l'image
            Image img_med = ImageHelper.LoadImageFromDatabase(id, "id_medicament", "medicament", "photo");


            Panel pan_med = new Panel();

            pan_med.Width = 100;
            pan_med.Height = 140;

            AvatarControl avatar = new AvatarControl();
            avatar.BorderSize = 2;
            avatar.BorderColor = Color.SkyBlue;

            avatar.Top = 5;
            avatar.Left = 10;

            avatar.Avatar = img_med;

            Label lbl = new Label();

            lbl.Text = name;
            lbl.Top = 85;
            lbl.Left = 10;
            lbl.Width = 80;

            Button btn = new Button();

            btn.Text = "Photo";
            btn.Width = 80;
            btn.Top = 105;
            btn.Left = 10;

            btn.Tag = id;

            btn.Click += Btn_Click;

            pan_med.Controls.Add(avatar);
            pan_med.Controls.Add(lbl);
            pan_med.Controls.Add(btn);

            return pan_med;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            int id = Convert.ToInt32(btn.Tag);

            ImageHelper.ChoisirImage(id, btn);
        }


        

        private void loadMed()
        {
            try
            {
                string query = "SELECT id_medicament, nom_medicament, categorie, unite FROM medicament ORDER BY nom_medicament ASC";
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, null, true))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string med_id = reader["id_medicament"].ToString();
                            string med_name = reader["nom_medicament"].ToString();
                            //Panel pan_med = new Panel();
                            //pan_med.Size = new Size(140, 130);
                            //pan_med.BorderStyle = BorderStyle.FixedSingle;

                            Panel pan_med = Pan_med(int.Parse(med_id), med_name);

                            MesClasses.ManagerClasse.AddControl(fl_med, pan_med, 15, 10);

                            //PictureBox picture = MesClasses.ManagerClasse.AddPicture(Properties.Resources.capsules_100px, new Point(30, 2),
                            //new Size(80, 80));
                            //pan_med.Controls.Add(picture);

                            //Label lbNom = MesClasses.ManagerClasse.CustomLabel(med_name, new Point(20, 85));
                            //lbNom.AutoSize = true;
                            //lbNom.Font = new System.Drawing.Font("Calibri", 9, FontStyle.Bold);
                            //pan_med.Controls.Add(lbNom);
                        }
                        reader.Close();
                        ProgressiveDisplay pd = new ProgressiveDisplay(fl_med, 100);
                        pd.Start();
                    }

                    else
                    {
                        Label lb_no_med = new Label();
                        lb_no_med.Text = "Aucun produit en stock";
                        lb_no_med.Anchor = AnchorStyles.None;

                        fl_med.Controls.Add(lb_no_med);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }

        }


    }
}


