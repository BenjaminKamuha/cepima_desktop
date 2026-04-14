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
            pan_med.Width = 150;
            pan_med.Height = 140;

            AvatarControl avatar = new AvatarControl();
            avatar.BorderSize = 2;
            avatar.BorderColor = Color.SkyBlue;

            avatar.Top = 5;
            avatar.Left = 10;
            avatar.Enabled = false;
            avatar.Avatar = img_med;
            pan_med.Controls.Add(avatar);
            avatar.Left = (avatar.Parent.ClientSize.Width - avatar.Width) / 2;
           
            // Panel pour les actions 
            


            // Boutons Actions
            RoundedButton btn_distribuer = new RoundedButton();
            btn_distribuer.ButtonText = "Distribuer";
            btn_distribuer.BorderColor = Color.Transparent;
            btn_distribuer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            btn_distribuer.BorderRadius = 5;
            btn_distribuer.Size = new Size(72, 24);
            btn_distribuer.Location = new Point(2, 2);


            RoundedButton btn_update = new RoundedButton();
            btn_update.ButtonText = "Mettre à jour";
            btn_update.BorderColor = Color.Transparent;
            btn_update.BorderStyle = System.Windows.Forms.BorderStyle.None;
 
            btn_update.BorderRadius = 5;
            btn_update.Size = new Size(72, 24);
            btn_update.Location = new Point(75, 2);

            Panel panel_action = new Panel();
            panel_action.Size = new Size(311, 60);
            panel_action.Location = new Point(0, 110);

            panel_action.Controls.Add(btn_distribuer);
            panel_action.Controls.Add(btn_update);
            pan_med.Controls.Add(panel_action);

            Label lbl = new Label();
            lbl.Text = name;
            lbl.Top = 85;
            lbl.Left = 10;
            lbl.Width = 80;
            lbl.Tag = id;
            pan_med.Controls.Add(lbl);            
            lbl.Left = (lbl.Parent.ClientSize.Width - lbl.Width) / 2;

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
                            pan_med.Tag = med_id;
                            //pan_med.BackColor = Color.Tomato;
                            

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

        void pan_med_MouseLeave(object sender, EventArgs e)
        {
            Panel pnl = sender as Panel;
            try
            {
                if (pnl.Tag != null)
                {
                    foreach (Control control in pnl.Controls)
                    {
                        if (control is Panel)
                        {
                            control.Visible = false;
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                Label lbl = sender as Label;
                if (lbl.Tag != null)
                {
                    foreach (Control control in lbl.Parent.Controls)
                    {
                        if (control is Panel)
                        {
                            control.Visible = false;
                        }
                    }
                }
            }
        }

        void pan_med_MouseHover(object sender, EventArgs e)
        {
            Panel pnl = sender as Panel;
            try
            {
                if (pnl.Tag != null)
                {
                    foreach (Control control in pnl.Controls)
                    {
                        if (control is Panel)
                        {
                            control.Visible = true;

                            foreach (Control btn in control.Controls)
                            {
                                btn.Tag += (string)pnl.Tag;
                                if (btn.Tag.ToString().Split('_')[0] == "D")
                                {
                                    btn.Click += distribuer_med;
                                }

                                else
                                {
                                    btn.Click += update_med;
                                }
                            }
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                Label lbl = sender as Label;
                if (lbl.Tag != null)
                {
                    foreach (Control control in lbl.Parent.Controls)
                    {
                        if (control is Panel)
                        {
                            control.Visible = true;

                            foreach (Control btn in control.Controls)
                            {
                                btn.Tag += (string)lbl.Tag;
                                if (btn.Tag.ToString().Split('_')[0] == "D")
                                {
                                    btn.Click += distribuer_med;
                                }

                                else
                                {
                                    btn.Click += update_med;
                                }
                            }
                        }
                    }
                }
            }
        }


        void distribuer_med(object sender, EventArgs e)
        {
            //
        }


        void update_med(object sender, EventArgs e)
        {
            //
        }

    }
}


