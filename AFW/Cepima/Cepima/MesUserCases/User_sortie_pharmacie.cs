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
using Cepima.MesClasses;

namespace Cepima.MesUserCases
{
    public partial class User_sortie_pharmacie : UserControl
    {
        public User_sortie_pharmacie()
        {
            InitializeComponent();
            loadMed();


            data_grid_med.Rows.Add(); // crée une ligne vide

            int rowIndex = data_grid_med.Rows.Count - 1;

            // colonne par index
            data_grid_med.Rows[rowIndex].Cells[0].Value = "Paracétamol";
            data_grid_med.Rows[rowIndex].Cells[1].Value = 25;
            data_grid_med.Rows[rowIndex].Cells[2].Value = true;

        }


        private Panel Pan_med(int id, string name)
        {

            // Chargement de l'image
            Image img_med = ImageHelper.LoadImageFromDatabase(id, "id_medicament", "medicament", "photo");

            Panel pan_med = new Panel();
            pan_med.Width = 150;
            pan_med.Height = 140;
            pan_med.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

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
            btn_distribuer.ButtonText = "Ajouter";
            btn_distribuer.BorderColor = Color.Transparent;
            btn_distribuer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            btn_distribuer.BorderRadius = 5;
            btn_distribuer.Size = new Size(72, 24);
            btn_distribuer.Location = new Point(2, 2);
            btn_distribuer.Tag = id;


            Panel panel_action = new Panel();
            panel_action.Size = new Size(311, 60);
            panel_action.Location = new Point(0, 110);
            panel_action.Controls.Add(btn_distribuer);
            btn_distribuer.Left = (btn_distribuer.Parent.ClientSize.Width - btn_distribuer.Width) / 2; 

            pan_med.Controls.Add(panel_action);
            panel_action.Left = (panel_action.Parent.ClientSize.Width - panel_action.Width) / 2;

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

        private void loadMed(params string[] args)
        {
            if (args.Length != 0)
            {
                //try
                //{
                string query = "SELECT id_medicament, nom_medicament, categorie, unite FROM medicament WHERE nom_medicament LIKE @searchText ORDER BY nom_medicament ASC";
                Dictionary<string, string> request_params = MesClasses.ManagerClasse.request_params;
                request_params.Clear();
                request_params.Add("searchText", "%" + args[0] + "%");
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, request_params, true))
                {
                    if (reader.HasRows)
                    {
                        fl_stock_med.Controls.Clear();

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


                            MesClasses.ManagerClasse.AddControl(fl_stock_med, pan_med, 15, 10);

                            //PictureBox picture = MesClasses.ManagerClasse.AddPicture(Properties.Resources.capsules_100px, new Point(30, 2),
                            //new Size(80, 80));
                            //pan_med.Controls.Add(picture);

                            //Label lbNom = MesClasses.ManagerClasse.CustomLabel(med_name, new Point(20, 85));
                            //lbNom.AutoSize = true;
                            //lbNom.Font = new System.Drawing.Font("Calibri", 9, FontStyle.Bold);
                            //pan_med.Controls.Add(lbNom);
                        }
                        reader.Close();
                        ProgressiveDisplay pd = new ProgressiveDisplay(fl_stock_med, 100);
                        pd.Start();
                    }
                    else
                    {
                        fl_stock_med.Controls.Clear();
                        fl_stock_med.Controls.Add(pnl_info);
                        fl_stock_med.Left = (pnl_info.Parent.ClientSize.Width - pnl_info.Width) / 2;
                        pnl_info.Top = (pnl_info.Parent.ClientSize.Height - pnl_info.Height) / 2;
                        pnl_info.Visible = true;


                    }
                }
                //}
                //catch (MySqlException ex)
                //{
                //    MessageBox.Show("Erreur : " + ex.Message);
                //}
            }

            else
            {
                try
                {
                    string query = "SELECT id_medicament, nom_medicament, categorie, unite FROM medicament ORDER BY nom_medicament ASC";
                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, null, true))
                    {
                        if (reader.HasRows)
                        {
                            fl_stock_med.Controls.Clear();
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


                                MesClasses.ManagerClasse.AddControl(fl_stock_med, pan_med, 15, 10);

                                //PictureBox picture = MesClasses.ManagerClasse.AddPicture(Properties.Resources.capsules_100px, new Point(30, 2),
                                //new Size(80, 80));
                                //pan_med.Controls.Add(picture);

                                //Label lbNom = MesClasses.ManagerClasse.CustomLabel(med_name, new Point(20, 85));
                                //lbNom.AutoSize = true;
                                //lbNom.Font = new System.Drawing.Font("Calibri", 9, FontStyle.Bold);
                                //pan_med.Controls.Add(lbNom);
                            }
                            reader.Close();
                            ProgressiveDisplay pd = new ProgressiveDisplay(fl_stock_med, 100);
                            pd.Start();
                        }

                        else
                        {
                            fl_stock_med.Controls.Clear();
                            fl_stock_med.Controls.Add(pnl_no_entry);
                            pnl_no_entry.Left = (pnl_no_entry.Parent.ClientSize.Width - pnl_no_entry.Width) / 2;
                            pnl_no_entry.Top = (pnl_no_entry.Parent.ClientSize.Height - pnl_no_entry.Height) / 2;
                            pnl_no_entry.Visible = true;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }

        }

        private void User_sortie_pharmacie_Load(object sender, EventArgs e)
        {

        }

        private void tb_search_med_TextChanged(object sender, EventArgs e)
        {
            loadMed(tb_search_med.Text);
        }

        private void customRoundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void modernDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void data_grid_med_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
