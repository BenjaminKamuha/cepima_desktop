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
    public partial class User_consultation : UserControl
    {
        public User_consultation()
        {
            InitializeComponent();
            //MesClasses.ReceptionManager.MoveLabel(label1,panel1);
            LoadDataPersonnelPatient();
            LoadPatient();
        }

        // ============================ Charger les patients et les personnels dans leurs comboBox respectif =============================================
        private void LoadDataPersonnelPatient()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();
                try
                {
                    // ========================================== les personnels ==================================
                    string queryPersonnel = "SELECT id_personnel,CONCAT(nom,' ',post_nom,' ',prenom) AS nomPersonnel FROM personnels ORDER BY nom ASC";
                    using (MySqlCommand cmd = new MySqlCommand(queryPersonnel, con, tr))
                    {
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            cbx_personnel.DataSource = dt;
                            cbx_personnel.DisplayMember = "nomPersonnel";
                            cbx_personnel.ValueMember = "id_personnel";
                            cbx_personnel.SelectedIndex = -1;
                        }
                    }
                  
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Erreur lors du chargement de données "+ex.Message);
                }
            }
        }

        private void SaveHospitalisation()
        {
             try
             {
                 int idConsultation = RecupererIdConsultation();
                 using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                 {
                     // Enregistrement de l'hospitalisation
                     string queryInsert = "INSERT INTO hospitalisation(id_patient,id_centre,id_service,id_consultation,date_entree,motif,etat)VALUES(@patient,@centre,@service,@consultation,CURDATE(),@motif,@etat)";
                     MySqlCommand cmd = new MySqlCommand(queryInsert, con);
                     cmd.Parameters.AddWithValue("@patient", idPatient);
                     cmd.Parameters.AddWithValue("@centre", MesForms.SessionUtilisateur.idCentre);
                     cmd.Parameters.AddWithValue("@service", cbx_service.SelectedValue);
                     cmd.Parameters.AddWithValue("@consultation", idConsultation);
                     cmd.Parameters.AddWithValue("@motif", tb_motif.Text);
                     cmd.Parameters.AddWithValue("@etat", "Hospitalisé");
                     cmd.ExecuteNonQuery();
                     cbx_service.SelectedIndex = -1;
                     tb_motif_hospitalisation.Clear();
                 }
             }
             catch (MySqlException ex)
             {
                 MessageBox.Show("Erreur : " + ex.Message);
             }
        }
        private void bt_save_consultation_Click_1(object sender, EventArgs e)
        {
            string personnelId = cbx_personnel.SelectedValue.ToString();
            string motif = tb_motif.Text;
            string description = rich_description.Text;

            // ================= cas du patient ambulatoire (qui arrive juste pour faire la consultation et repartir chez lui ===========
            if (rb_ambulatoire.Checked)
            {
                // ============================== Appel de la méthode d'ajout de la consultation
                MesClasses.ReceptionManager.EnregistrerConsultation(idPatient.ToString(), MesForms.SessionUtilisateur.idCentre.ToString(), personnelId, motif, description);

                // =========================== mettre en jour le champs booleen de la table signes vitaux =================
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    string query = "UPDATE  signes_vitaux SET is_counsel = 1 WHERE id_patient = @id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", idPatient);
                    cmd.ExecuteNonQuery();
                }
                tb_motif.Clear();
                cbx_personnel.SelectedIndex = -1;
                rich_description.Clear();
            }

            // ======================== cas du patient qui sera hospitalisé =================================================
            else if (rb_hospitalisation.Checked)
            {
                // ============================== Appel de la méthode d'ajout de la consultation
                MesClasses.ReceptionManager.EnregistrerConsultation(idPatient.ToString(), MesForms.SessionUtilisateur.idCentre.ToString(), personnelId, motif, description);

                // =================== save hospitalisation =================================
                SaveHospitalisation();
                // =========================== mettre en jour le champs booleen de la table signes vitaux =================
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    string query = "UPDATE  signes_vitaux SET is_counsel = 1 WHERE id_patient = @id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", idPatient);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Hospitalisaton crée avec succès !!");
            }
           
            LoadPatient();
        }

        private void LoadPatient()
        {
            fl_patient.Controls.Clear();

            try
            {
                string query = "SELECT p.id_patient,p.nom,p.post_nom FROM signes_vitaux s JOIN patients p ON p.id_patient = s.id_patient WHERE is_counsel = 0";

                MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, null, true);

                while (reader.Read())
                {
                    AjouterPanel(
                        reader["id_patient"].ToString(),
                        reader["nom"].ToString(),
                        reader["post_nom"].ToString()
                    );
                }

                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur patient " + ex.Message);
            }
        }
        private void AjouterPanel(string id, string nom, string postNom)
        {
            Panel panelPatient = new Panel
            {
                Size = new Size(180, 60),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
            };

            PictureBox picture = new PictureBox
            {
                Location = new Point(10, 5),
                Size = new Size(35, 35),
                Image = Properties.Resources.round_user,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            panelPatient.Controls.Add(picture);

            Label labelNom = new Label
            {
                Text = nom + " " + postNom,
                Location = new Point(50, 20),
                AutoSize = true,
                Font = new Font("Consolas", 8, FontStyle.Bold)
            };

            panelPatient.Controls.Add(labelNom);

            CheckBox chk = new CheckBox
            {
                Tag = id,
                AutoSize = true,
                Location = new Point(160, 40)
            };

            chk.CheckedChanged += chkClient_CheckedChanged;

            panelPatient.Controls.Add(chk);

            fl_patient.Controls.Add(panelPatient);
        }
        int idPatient;
        
        void chkClient_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;

            if (chk.Checked)
            {
                foreach (Panel p in fl_patient.Controls.OfType<Panel>())
                {
                    foreach (CheckBox c in p.Controls.OfType<CheckBox>())
                    {
                        if (c != chk)
                        {
                            c.Checked = false;
                        }
                    }
                }

                idPatient = Convert.ToInt32(chk.Tag);
            }
            else
            {
                idPatient = 0;
            }
        }

        // ===================================  partie prescription =====================================
        private void LoadMedicament(params string[] args)
        {
            panel_medicament.Controls.Clear();

            try
            {
                string query = "";
                if (args.Length != 0)
                {
                    query = "SELECT id_medicament,nom_medicament,photos,categorie,unite,prix_vente FROM medicament WHERE nom_medicament LIKE @search";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@search", "%" + args[0] + "%");
                }
                else
                {
                    query = "SELECT id_medicament,nom_medicament,photos,categorie,unite,prix_vente FROM medicament ORDER BY nom_medicament ASC";
                }

                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, args.Length != 0 ? MesClasses.ManagerClasse.request_params : null, true))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string idMed = reader["id_medicament"].ToString();
                            string nom = reader["nom_medicament"].ToString();
                            string photo = reader["photos"].ToString();
                            string unite = reader["unite"].ToString();
                            string prix = reader["prix_vente"].ToString();

                            Panel pan = new Panel();
                            pan.Size = new Size(150, 170);
                            pan.BorderStyle =
                            BorderStyle.FixedSingle;
                            pan.Cursor = Cursors.Hand;
                            pan.Tag = idMed;
                            MesClasses.ManagerClasse.AddControl(panel_medicament,pan,15,10);

                            //====== Avatar ======
                            AvatarControl avatar = new AvatarControl();
                            avatar.Location = new Point(30, 5);
                            avatar.Size = new Size(80, 80);
                            avatar.BorderSize = 2;
                            avatar.BorderColor = Color.FromArgb(44, 123, 229);

                            if (!string.IsNullOrEmpty(photo))
                            {
                                try
                                {
                                    avatar.Avatar = Image.FromFile(photo);
                                }
                                catch
                                {
                                    //avatar.Avatar = Properties.Resources;
                                }
                            }
                            else
                            {
                                //avatar.Avatar = Properties.Resources.medicine;
                            }

                            pan.Controls.Add(avatar);

                            Label lbNom = MesClasses.ManagerClasse.CustomLabel(nom,new Point(10, 90));
                            lbNom.AutoSize = true;
                            lbNom.Font = new Font("Calibri",9,FontStyle.Bold);
                            pan.Controls.Add(lbNom);
                            Label lbPrix =MesClasses.ManagerClasse.CustomLabel(prix + " FC",new Point(40, 115));
                            pan.Controls.Add(lbPrix);

                            RoundedButton btSelect = MesClasses.ManagerClasse.Rbutton("Choisir",new Point(30, 140),new Size(80, 20),Color.FromArgb(7, 51, 131),Color.White);
                            btSelect.BorderRadius = 4;
                            btSelect.BorderSize = 0;
                            btSelect.Tag = idMed;
                            btSelect.Click += (s, e) =>
                            {
                                AjouterAuDataGrid(
                                    idMed,
                                    nom,
                                    unite,
                                    prix
                                );
                            };

                            pan.Controls.Add(btSelect);
                        }
                        reader.Close();
                        ProgressiveDisplay pd = new ProgressiveDisplay(panel_medicament,100);
                        pd.Start();
                    }
                    else
                    {
                        panel_medicament.Controls.Clear();
                        lb_not_found.Visible = true;
                        lb_not_found.Text = "Aucun médicament trouvé";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
        // ====================== méthode pour ajouter au datagridview ================================
        private void AjouterAuDataGrid(string id,string nom,string unite,string prix)
        {
            foreach (DataGridViewRow row in dgv_medoc.Rows)
            {
                if (row.Cells["colID"].Value != null && row.Cells["colID"].Value.ToString() == id)
                {
                    int qte = Convert.ToInt32(row.Cells["colQuantite"].Value);
                    row.Cells["colQuantite"].Value = qte + 1;
                    return;
                }
            }
            dgv_medoc.Rows.Add(id,nom,1,unite,prix,"Non Livré");
        }
        // enregistrement dans la table prescriptions  et récuperation de l'id consultation ==========================
        private int RecupererIdConsultation()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string query = "SELECT MAX(id_consultation) FROM consultation";
                MySqlCommand cmd = new MySqlCommand(query,con);
                object result = cmd.ExecuteScalar();

                return Convert.ToInt32(result);
            }
        }
        private void bt_valider_prescription_Click(object sender, EventArgs e)
        {
            try
            {
                int idConsultation = RecupererIdConsultation();
                foreach (DataGridViewRow row in dgv_medoc.Rows)
                {
                    if (row.IsNewRow)
                        continue;
                    string query = "INSERT INTO prescription(id_consultation,id_patient,id_medicament,quantite,unite,statut)VALUES(@id_consultation,@id_patient,@id_medicament,@quantite,@unite,@statut)";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@id_consultation",idConsultation.ToString());
                    MesClasses.ManagerClasse.request_params.Add("@id_patient", idPatient.ToString());
                    MesClasses.ManagerClasse.request_params.Add("@id_medicament",row.Cells["colID"].Value.ToString());
                    MesClasses.ManagerClasse.request_params.Add("@quantite",row.Cells["colQuantite"].Value.ToString());
                    MesClasses.ManagerClasse.request_params.Add("@unite",row.Cells["colUnite"].Value.ToString());
                    MesClasses.ManagerClasse.request_params.Add("@statut","Non Livré"
                    );
                    MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params);
                }

                MessageBox.Show("Prescription enregistrée avec succès");

                dgv_medoc.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void tb_search_med_TextChanged(object sender, EventArgs e)
        {
            panel_medicament.Controls.Clear();
            LoadMedicament(tb_search_med.Text);
        }

        private void rb_ambulatoire_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_ambulatoire.Checked)
                pan_test.Visible = false;
        }

        private void rb_hospitalisation_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_hospitalisation.Checked)
                pan_test.Visible = true;
        }
    }
}
