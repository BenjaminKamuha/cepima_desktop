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
        RichTextBox diag_summary = new RichTextBox();
        string ID_PATIENT = null;
        string ID_SERVICE = null;

        public User_sortie_pharmacie()
        {
            InitializeComponent();
            controlPosition();
            loadRecent();
            loadQues();
        }

        Dictionary<int, int> id_queue = new Dictionary<int, int>(); 

        private void loadQues()
        {
            string presc_status = "Non livrée";
            string query = "SELECT p.id_patient, p.nom, p.post_nom, p.prenom, p.numero_fiche, c.id_consultation, c.diagnostic FROM consultation c JOIN patients p ON c.id_patient = p.id_patient WHERE c.statut_presc=@status;";
            MesClasses.ManagerClasse.request_params.Clear();
            MesClasses.ManagerClasse.request_params.Add("status", presc_status);

            MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true);

            if (reader.HasRows)
            {
                int i = 0;
                while (reader.Read())
                {
                    Image img_avt = ImageHelper.LoadImageFromDatabase(int.Parse(reader["id_patient"].ToString()), "id_patient", "patients", "photo");
                    if (i == 0)
                    {
                        // Chargement du patient
                        load_prescription(reader["id_consultation"].ToString(), reader["id_patient"].ToString());
                    }

                    id_queue.Add(int.Parse(reader["id_patient"].ToString()), int.Parse(reader["id_consultation"].ToString()));

                    // Ajout du panel description patient
                    Panel pnl_patient_queue = new Panel();
                    fl_queue.Controls.Add(pnl_patient_queue);
                    pnl_patient_queue.Size = new Size(150, pnl_patient_queue.Parent.Height - 15);
                    pnl_patient_queue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    pnl_patient_queue.Tag = reader["id_consultation"].ToString() + "." + reader["id_patient"].ToString();
                    pnl_patient_queue.Click += pnl_patient_queue_Click;

                    // Evenement lors du clique sur un panl

                    // Avatar du patient
                    AvatarControl avt_queue = new AvatarControl();
                    avt_queue.Size = new Size(40, 40);
                    avt_queue.Avatar = img_avt;
                    avt_queue.Enabled = false;

                    // Label nom patient
                    Label lb_name_queue = new Label();
                    lb_name_queue.Text = reader["nom"].ToString() + "\n" + reader["post_nom"].ToString();
                    lb_name_queue.TextAlign = ContentAlignment.TopCenter;
                    lb_name_queue.Height = 50;
                    lb_name_queue.Location = new Point(avt_queue.Size.Width, 10);
                    lb_name_queue.FlatStyle = FlatStyle.Flat;
                    lb_name_queue.Enabled = false;

                    Label lb_p_name_queue = new Label();


                    // Ajout du control avatar
                    pnl_patient_queue.Controls.Add(lb_name_queue);
                    pnl_patient_queue.Controls.Add(avt_queue);
                    

                    i++;
                }

                lb_nb_queu.Text += "(" + i.ToString() + ")";
            }
            else
            {
                pnl_responsable.Controls.Clear();
                Label lb_info = new Label();
                lb_info.Text = "Pas des patients en attente";
                lb_info.Font = new Font("Arial", 12, FontStyle.Bold);
                lb_info.Size = new Size(210, 15);
                pnl_responsable.Controls.Add(lb_info);

                lb_info.Left = (lb_info.Parent.ClientSize.Width - lb_info.Width) / 2;
                lb_info.Top = (lb_info.Parent.ClientSize.Height - lb_info.Height) / 2;

                bt_validate_presc.Visible = false;
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
            ID_PATIENT = patient_id;

            // Chargemeent du paitent
            string query_patient = "SELECT p.id_patient, p.nom, p.post_nom, p.prenom, p.numero_fiche, c.id_consultation, c.diagnostic FROM consultation c JOIN patients p ON c.id_patient = p.id_patient WHERE p.id_patient=@id_p;";

            MesClasses.ManagerClasse.request_params.Clear();
            MesClasses.ManagerClasse.request_params.Add("id_p", patient_id);

            MySqlDataReader reader_patient = MesClasses.ManagerClasse.CRUD(query_patient, MesClasses.ManagerClasse.request_params, true);

            if (reader_patient.HasRows)
            {
                
                while (reader_patient.Read())
                {
                    Image img_avt = ImageHelper.LoadImageFromDatabase(int.Parse(reader_patient["id_patient"].ToString()), "id_patient", "patients", "photo");
                    avt.Avatar = img_avt;
                    lb_name.Text = reader_patient["nom"].ToString() + "\n" + reader_patient["post_nom"].ToString();
                    lb_name.TextAlign = ContentAlignment.TopCenter;
                    lb_name.Height = 50;
                    lb_file_number.Text = reader_patient["numero_fiche"].ToString();
                    //lb_title.Text = "Prescription";

                    avt.Avatar = img_avt;

                    // Rich TextBox pour le résumé du diagnosic
                    lb_title_summary.Text = " Resumé diagnostique de " + reader_patient["nom"].ToString() + " " + reader_patient["post_nom"].ToString();
                    lb_title_summary.Left = (lb_title_summary.Parent.ClientSize.Width - lb_title_summary.Width) / 2;

                    //diag_summary.Clear();
                    diag_summary.Text = reader_patient["diagnostic"].ToString();
                    diag_summary.Size = new Size(250, 100);
                    diag_summary.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    diag_summary_pnl.Margin = new System.Windows.Forms.Padding(10);
                    diag_summary_pnl.TabIndex = 10;
                    diag_summary_pnl.Font = new Font("Arial", 10, FontStyle.Regular);

                    diag_summary_pnl.Controls.Add(diag_summary);
                    diag_summary.Left = (diag_summary.Parent.ClientSize.Width - diag_summary.Width) / 2;
                    diag_summary.Top = ((diag_summary.Parent.ClientSize.Height + 20) - diag_summary.Height) / 2;

                    diag_summary_pnl.Left = (diag_summary_pnl.Parent.ClientSize.Width - diag_summary_pnl.Width) / 2;

                }
            }

            else
            {
                pnl_responsable.Controls.Clear();
                Label lb_info = new Label();
                lb_info.Text = "La fils d'attente est vide";
                lb_info.Font = new Font("Arial", 12, FontStyle.Bold);
                pnl_responsable.Controls.Add(lb_info);

                lb_info.Left = (lb_info.Parent.ClientSize.Width - lb_info.Width) / 2;
                lb_info.Top = (lb_info.Parent.ClientSize.Height - lb_info.Height) / 2;
            }

        }

        private void load_prescription(string id_cons, string id_patient)
        {
            
            load_patient(id_patient);
            data_grid_med.Rows.Clear();
            // Chargement prescription
            string query_presc = "SELECT pr.id_prescription, pr.quantite, pr.unite, m.id_medicament, m.nom_medicament, m.prix_vente, m.photo FROM prescriptions pr JOIN medicament m ON m.id_medicament=pr.id_medicament WHERE id_consultation=@id_cons;";

            MesClasses.ManagerClasse.request_params.Clear();
            MesClasses.ManagerClasse.request_params.Add("id_cons", id_cons);

            MySqlDataReader reader_presc = MesClasses.ManagerClasse.CRUD(query_presc, MesClasses.ManagerClasse.request_params, true);

            if (reader_presc.HasRows)
            {
                while (reader_presc.Read())
                {
                    data_grid_med.Rows.Add(reader_presc["id_medicament"], reader_presc["nom_medicament"].ToString(), int.Parse(reader_presc["quantite"].ToString()), reader_presc["unite"].ToString(), reader_presc["prix_vente"].ToString());
                }

                bt_validate_presc.Visible = true;
            }

            else
            {
                bt_validate_presc.Visible = false;
            }


        }

        private void controlPosition()
        {
            //lb_title.Left = (lb_title.Parent.ClientSize.Width - lb_title.Width) / 2;
            //pnl_radio_mode.Left = (pnl_radio_mode.Parent.ClientSize.Width - lb_title.Width) / 2;
            pnl_responsable.Left = (pnl_responsable.Parent.ClientSize.Width - pnl_responsable.Width) / 2;
        }

        private Panel Pan_rec_cons(int id, string name)
        {
            // Chargement de l'image
            Image img_patient = ImageHelper.LoadImageFromDatabase(id, "id_patient", "patients", "photo");

            Panel pan_rec_cons = new Panel();
            pan_rec_cons.Width = 150;
            pan_rec_cons.Height = 140;
            pan_rec_cons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            AvatarControl avatar = new AvatarControl();
            avatar.BorderSize = 2;
            avatar.BorderColor = Color.SkyBlue;

            avatar.Top = 5;
            avatar.Left = 10;
            avatar.Enabled = false;
            avatar.Avatar = img_patient;
            pan_rec_cons.Controls.Add(avatar);
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

            pan_rec_cons.Controls.Add(panel_action);
            panel_action.Left = (panel_action.Parent.ClientSize.Width - panel_action.Width) / 2;

            Label lbl = new Label();
            lbl.Text = name;
            lbl.Top = 85;
            lbl.Left = 10;
            lbl.Width = 80;
            lbl.Tag = id;
            pan_rec_cons.Controls.Add(lbl);
            lbl.Left = (lbl.Parent.ClientSize.Width - lbl.Width) / 2;

            return pan_rec_cons;

        }

        private void loadRecent(params string[] args)
        {
            if (args.Length != 0)
            {
                //try
                //{
                string presc_status = "Livrée";
                string query = "SELECT p.id_patient, p.nom, p.post_nom, p.prenom, p.numero_fiche, c.id_consultation, c.diagnostic FROM consultation c JOIN patients p ON c.id_patient = p.id_patient WHERE c.statut_presc=@status AND p.nom LIKE @searchText OR p.post_nom LIKE @searchText or p.prenom LIKE @searchText;";

                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("status", presc_status);
                MesClasses.ManagerClasse.request_params.Add("searchText", args[0]);

                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                {
                    if (reader.HasRows)
                    {
                        fl_recent_cons.Controls.Clear();

                        while (reader.Read())
                        {
                            string cons_id = reader["id_consultation"].ToString();
                            string patient_name = reader["nom"].ToString();
                            //Panel pan_med = new Panel();
                            //pan_med.Size = new Size(140, 130);
                            //pan_med.BorderStyle = BorderStyle.FixedSingle;

                            Panel pan_cons = Pan_rec_cons(int.Parse(cons_id), patient_name);
                            pan_cons.Tag = cons_id;
                            //pan_med.BackColor = Color.Tomato;


                            MesClasses.ManagerClasse.AddControl(fl_recent_cons, pan_cons, 15, 10);

                            //PictureBox picture = MesClasses.ManagerClasse.AddPicture(Properties.Resources.capsules_100px, new Point(30, 2),
                            //new Size(80, 80));
                            //pan_med.Controls.Add(picture);

                            //Label lbNom = MesClasses.ManagerClasse.CustomLabel(med_name, new Point(20, 85));
                            //lbNom.AutoSize = true;
                            //lbNom.Font = new System.Drawing.Font("Calibri", 9, FontStyle.Bold);
                            //pan_med.Controls.Add(lbNom);
                        }
                        reader.Close();
                        ProgressiveDisplay pd = new ProgressiveDisplay(fl_recent_cons, 100);
                        pd.Start();
                    }
                    else
                    {
                        fl_recent_cons.Controls.Clear();
                        fl_recent_cons.Controls.Add(pnl_info);
                        fl_recent_cons.Left = (pnl_info.Parent.ClientSize.Width - pnl_info.Width) / 2;
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

                    string presc_status = "Livrée";
                    string query = "SELECT p.id_patient, p.nom, p.post_nom, p.prenom, p.numero_fiche, c.id_consultation, c.diagnostic FROM consultation c JOIN patients p ON c.id_patient = p.id_patient WHERE c.statut_presc=@status;";

                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("status", presc_status);
                    
                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                    {
                    

                        if (reader.HasRows)
                        {
                            fl_recent_cons.Controls.Clear();
                            while (reader.Read())
                            {
                                string cons_id = reader["id_consultation"].ToString();
                                string patient_name = reader["nom"].ToString();
                                //Panel pan_med = new Panel();
                                //pan_med.Size = new Size(140, 130);
                                //pan_med.BorderStyle = BorderStyle.FixedSingle;

                                Panel pan_med = Pan_rec_cons(int.Parse(cons_id), patient_name);
                                pan_med.Tag = cons_id;
                                //pan_med.BackColor = Color.Tomato;


                                MesClasses.ManagerClasse.AddControl(fl_recent_cons, pan_med, 15, 10);

                                //PictureBox picture = MesClasses.ManagerClasse.AddPicture(Properties.Resources.capsules_100px, new Point(30, 2),
                                //new Size(80, 80));
                                //pan_med.Controls.Add(picture);

                                //Label lbNom = MesClasses.ManagerClasse.CustomLabel(med_name, new Point(20, 85));
                                //lbNom.AutoSize = true;
                                //lbNom.Font = new System.Drawing.Font("Calibri", 9, FontStyle.Bold);
                                //pan_med.Controls.Add(lbNom);
                            }
                            reader.Close();
                            ProgressiveDisplay pd = new ProgressiveDisplay(fl_recent_cons, 100);
                            pd.Start();
                        }

                        else
                        {
                            fl_recent_cons.Controls.Clear();

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
            //loadMed(tb_search_med.Text);
        }

        private void bt_validate_presc_Click(object sender, EventArgs e)
        {
            string type_sortie = "";

            long id_sortie = 0;

            if (rd_type_soritie_H.Checked)
            {
                type_sortie = "Hospitalisation";
            }

            else if (rd_type_sortie_A.Checked)
            {
                type_sortie = "Ambulatoire";
            }

       
            string id_patient = ID_PATIENT;
            string status = "Livrée";

            if (type_sortie != string.Empty)
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                 {
                     MySqlTransaction tr = con.BeginTransaction();
                     // Les trois requêtes à executer
                     string query_update_cons ="UPDATE consultation SET statut_presc = @status WHERE id_patient = @id_patient";
                     string query_create_sortie = "INSERT INTO sorties_stock(id_centre, type_sortie, id_patient, id_service, date_sortie) VALUES(@id_centre, @type_sortie, @id_patient, @id_service, @date)";
                     string query_create_detail = "INSERT INTO detail_sortie_stock(id_sortie, id_medicament, quantite, prix_unitaire) VALUES(@id_sortie_stock, @id_medicament, @quantite, @prix_unitaire)";

                     //try
                     //{
                         using (MySqlCommand cmdUpdate = new MySqlCommand(query_update_cons, con, tr))
                         {
                             cmdUpdate.Parameters.AddWithValue("id_patient", id_patient);
                             cmdUpdate.Parameters.AddWithValue("status", status); 
                             cmdUpdate.ExecuteNonQuery();
                         }

                         using (MySqlCommand cmdCreate_sortie = new MySqlCommand(query_create_sortie, con, tr))
                         {
                             cmdCreate_sortie.Parameters.AddWithValue("id_centre", MesForms.SessionUtilisateur.idCentre);
                             if (rd_type_sortie_A.Checked)
                             {
                                 cmdCreate_sortie.Parameters.AddWithValue("type_sortie", type_sortie);
                                 cmdCreate_sortie.Parameters.AddWithValue("id_patient", ID_PATIENT);
                                 cmdCreate_sortie.Parameters.AddWithValue("id_service", null);
                                 cmdCreate_sortie.Parameters.AddWithValue("date", DateTime.Now.Date);

                             }

                             else
                             {
                                 cmdCreate_sortie.Parameters.AddWithValue("type_sortie", type_sortie);
                                 cmdCreate_sortie.Parameters.AddWithValue("id_patient", ID_SERVICE);
                                 cmdCreate_sortie.Parameters.AddWithValue("id_service", null);
                                 cmdCreate_sortie.Parameters.AddWithValue("date", DateTime.Now.Date);

                             }

                             cmdCreate_sortie.ExecuteNonQuery();

                             id_sortie = cmdCreate_sortie.LastInsertedId;

                         }


                        

                         using (MySqlCommand cmdCreate_detail = new MySqlCommand(query_create_detail, con, tr))
                         {
                             foreach (DataGridViewRow row in data_grid_med.Rows)
                             {
                                 // Ingorer la ligne vide
                                 if (row.IsNewRow)
                                     continue;

                                 cmdCreate_detail.Parameters.Clear();

                                 cmdCreate_detail.Parameters.AddWithValue("id_sortie_stock", id_sortie);

                                 cmdCreate_detail.Parameters.AddWithValue("id_medicament", Convert.ToString(row.Cells["id_medicament"].Value));

                                 cmdCreate_detail.Parameters.AddWithValue("quantite", Convert.ToString(row.Cells["med_qty"].Value));


                                 cmdCreate_detail.Parameters.AddWithValue("prix_unitaire" ,Convert.ToString(row.Cells["med_price"].Value));
                             }

                             cmdCreate_detail.ExecuteNonQuery();
                         }



                         tr.Commit();
                         MessageBox.Show("Prescription enregistré!!");
                     }

                     //catch (Exception ex)
                     //{
                     //    tr.Rollback();
                     //    MessageBox.Show("Erreur : " + ex.Message);
                     //}
                 //}
            }

            else
            {
                MessageBox.Show("Erreur! Sélélectionner le type de sortie avant confirmation");
            }
        }


    }
}
