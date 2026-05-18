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
            controlPosition();
            loadMed();
            loadQues();
        }

        Dictionary<int, int> id_queue = new Dictionary<int, int>(); 

        private void loadQues()
        {
            string query = "SELECT p.id_patient, p.nom, p.post_nom, p.prenom, p.numero_fiche, c.id_consultation, c.diagnostic FROM consultation c JOIN patients p ON c.id_patient = p.id_patient;";

            MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, null, true);

            if (reader.HasRows)
            {
                int i = 0;
                while (reader.Read())
                {
                    Image img_avt = ImageHelper.LoadImageFromDatabase(int.Parse(reader["id_patient"].ToString()), "id_patient", "patients", "photo");
                    if (i == 0)
                    {
                        // Chargement de la prescription
                        //load_prescription(reader["id_consultation"].ToString(), reader["id_patient"].ToString());
                    }

                    id_queue.Add(int.Parse(reader["id_patient"].ToString()), int.Parse(reader["id_consultation"].ToString()));

                    // Ajout du panel description patient
                    Panel pnl_patient_queue = new Panel();
                    fl_queue.Controls.Add(pnl_patient_queue);
                    pnl_patient_queue.Size = new Size(150, pnl_patient_queue.Parent.Height - 5);
                    pnl_patient_queue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    pnl_patient_queue.Tag = reader["id_consultation"].ToString() + "." + reader["id_patient"].ToString();
                    pnl_patient_queue.Click += pnl_patient_queue_Click;

                    // Evenement lors du clique sur un panl

                    // Avatar du patient
                    AvatarControl avt_queue = new AvatarControl();
                    avt_queue.Size = new Size(50, 50);
                    avt_queue.Avatar = img_avt;
                    avt_queue.Enabled = false;

                    // Label nom patient
                    Label lb_name_queue = new Label();
                    lb_name_queue.Text = reader["nom"].ToString() + " " + reader["post_nom"].ToString();
                    lb_name_queue.Location = new Point(avt_queue.Size.Width, avt_queue.Size.Height / 2);
                    lb_name_queue.Enabled = false;

                    // Ajout du control avatar
                    pnl_patient_queue.Controls.Add(lb_name);
                    pnl_patient_queue.Controls.Add(avt_queue);
                    

                    i++;
                }

                lb_nb_queu.Text += "(" + i.ToString() + ")";
            }
        }

        void pnl_patient_queue_Click(object sender, EventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl.Tag != null)
            {
                string consultation_id = pnl.Tag.ToString().Split('.')[0];
                string patient_id = pnl.Tag.ToString().Split('.')[1];

                // Chargement de la prescription
                load_prescription(consultation_id, patient_id);
                
            }
        }

        private void load_patient(string patient_id)
        {

        }

        private void load_prescription(string id_cons, string id_patient)
        {
            data_grid_med.Rows.Clear();

            // Chargemeent du paitent
            string query_patient = "SELECT p.id_patient, p.nom, p.post_nom, p.prenom, p.numero_fiche, c.id_consultation, c.diagnostic FROM consultation c JOIN patients p ON c.id_patient = p.id_patient WHERE p.id_patient=@id_p;";

            MesClasses.ManagerClasse.request_params.Clear();
            MesClasses.ManagerClasse.request_params.Add("id_p", id_patient);
            MySqlDataReader reader_patient = MesClasses.ManagerClasse.CRUD(query_patient, MesClasses.ManagerClasse.request_params, true);

            if (reader_patient.HasRows)
            {
                while (reader_patient.Read())
                {
                    Image img_avt = ImageHelper.LoadImageFromDatabase(int.Parse(reader_patient["id_patient"].ToString()), "id_patient", "patients", "photo");
                    avt.Avatar = img_avt;
                    lb_name.Text = reader_patient["nom"].ToString();
                    lb_last_name.Text = reader_patient["post_nom"].ToString();
                    lb_file_number.Text = reader_patient["numero_fiche"].ToString();
                    lb_title.Text = "Prescription";

                    avt.Avatar = img_avt;
                }
            }


            // Chargement prescription
            string query_presc = "SELECT pr.id_prescription, pr.quantite, pr.unite, m.id_medicament, m.nom_medicament, m.photo FROM prescriptions pr JOIN medicament m ON m.id_medicament=pr.id_medicament WHERE id_consultation=@id_cons;";

            MesClasses.ManagerClasse.request_params.Clear();
            MesClasses.ManagerClasse.request_params.Add("id_cons", id_cons);

            MySqlDataReader reader_cons = MesClasses.ManagerClasse.CRUD(query_presc, MesClasses.ManagerClasse.request_params, true);

            if (reader_cons.HasRows)
            {
                while (reader_cons.Read())
                {
                    data_grid_med.Rows.Add(reader_cons["nom_medicament"].ToString(), int.Parse(reader_cons["quantite"].ToString()), reader_cons["unite"].ToString());
                }
            }
        }

        private void controlPosition()
        {
            lb_title.Left = (lb_title.Parent.ClientSize.Width - lb_title.Width) / 2;
            //pnl_radio_mode.Left = (pnl_radio_mode.Parent.ClientSize.Width - lb_title.Width) / 2;
            pnl_responsable.Left = (pnl_responsable.Parent.ClientSize.Width - pnl_responsable.Width) / 2;
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fl_stock_med_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
