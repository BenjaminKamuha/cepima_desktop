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
            LoadServices();
            LoadMedicament();
        }

        // ================ Charger les patients et les personnels dans leurs comboBox respectif =============================================
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
        // =========================== hospitalisation =======================================================================================
        private void SaveHospitalisation(int idConsultation)
        {
            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {

                    string queryInsert = "INSERT INTO hospitalisation(id_patient,id_centre,id_service,id_consultation,date_entree,motif,etat)VALUES(@patient,@centre,@service,@consultation,CURDATE(),@motif,@etat)";
                    MySqlCommand cmd = new MySqlCommand(queryInsert,con);
                    cmd.Parameters.AddWithValue("@patient",idPatient);
                    cmd.Parameters.AddWithValue("@centre",MesForms.SessionUtilisateur.idCentre);
                    cmd.Parameters.AddWithValue("@service",cbx_service.SelectedValue);
                    cmd.Parameters.AddWithValue("@consultation",idConsultation);
                    cmd.Parameters.AddWithValue("@motif",tb_motif.Text);
                    cmd.Parameters.AddWithValue("@etat","Hospitalisé");
                    cmd.ExecuteNonQuery();

                    int idHospitalisation = Convert.ToInt32(cmd.LastInsertedId);
                    
                    string nomPatient = "";
                    string queryNom = "SELECT CONCAT(nom,' ',post_nom,' ',prenom)FROM patients WHERE id_patient=@id";
                    using (MySqlCommand cmdNom = new MySqlCommand(queryNom,con))
                    {
                        cmdNom.Parameters.AddWithValue("@id",idPatient);

                        object result = cmdNom.ExecuteScalar();

                        if (result != null)
                        {
                            nomPatient = result.ToString();
                        }
                    }

                    MesClasses.Event.SaveHistorique(idHospitalisation.ToString(),"Patient : "+ nomPatient +" hospitalisé");
                    cbx_service.SelectedIndex = -1;
                    tb_motif_hospitalisation.Clear();

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur : "+ ex.Message);
            }
        }
        private void bt_save_consultation_Click_1(object sender, EventArgs e)
        {
            if (cbx_personnel.SelectedValue == null)
            {
                MessageBox.Show("Sélectionnez un personnel");
                return;
            }
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

            //    // =================== save hospitalisation =================================
                int consultationID = RecupererIdConsultation();
                SaveHospitalisation(consultationID);
                int hospitalisationID = RecupererIdHospitalisation();
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
            else
            {
                MessageBox.Show("Sélectionnez un type de patient");
            }
           
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
        // ===================================  partie prescription ==================================================
        private void LoadMedicament(params string[] args)
        {
            panel_medicament.Controls.Clear();

            try
            {
                string query = "";
                if (args.Length != 0)
                {
                    query = "SELECT id_medicament,nom_medicament,photo,categorie,unite,prix_vente FROM medicament WHERE nom_medicament LIKE @search";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@search", "%" + args[0] + "%");
                }
                else
                {
                    query = "SELECT id_medicament,nom_medicament,photo,categorie,unite,prix_vente FROM medicament ORDER BY nom_medicament ASC";
                }

                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, args.Length != 0 ? MesClasses.ManagerClasse.request_params : null, true))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string idMed = reader["id_medicament"].ToString();
                            string nom = reader["nom_medicament"].ToString();
                            string unite = reader["unite"].ToString();
                            string prix = reader["prix_vente"].ToString();

                            CustomRoundedPanel pan = new CustomRoundedPanel();
                            pan.Size = new Size(100,120);
                            pan.BorderRadius = 10;
                            pan.BorderSize = 1;
                            pan.BorderColor = Color.FromArgb(224, 224, 224);
                            pan.HoverCursor = Cursors.Default;
                            MesClasses.ManagerClasse.AddControl(panel_medicament,pan,5,5);

                            //====== Avatar ======
                            AvatarControl avatar = new AvatarControl();
                            avatar.Location = new Point(25, 5);
                            avatar.Size = new Size(45,45);
                            avatar.BorderSize = 2;
                            avatar.BorderColor = Color.FromArgb(44, 123, 229);

                            try
                            {
                                if (reader["photo"] != DBNull.Value)
                                {
                                    byte[] imageData = (byte[])reader["photo"];
                                    using (MemoryStream ms = new MemoryStream(imageData))
                                    {
                                        avatar.Avatar = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    avatar.Avatar = Properties.Resources.capsules_100px;
                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("Erreur image : "+ex.Message);
                                avatar.Avatar = Properties.Resources.capsules_100px;
                            }

                            pan.Controls.Add(avatar);

                            Label lbNom = MesClasses.ManagerClasse.CustomLabel(nom,new Point(5,55));
                            lbNom.AutoSize = true;
                            lbNom.Font = new Font("Calibri",9);
                            pan.Controls.Add(lbNom);

                            Label lbPrix = MesClasses.ManagerClasse.CustomLabel("Prix : "+prix + "$",new Point(20,70));
                            lbPrix.AutoSize = true;
                            lbPrix.Font = new System.Drawing.Font("Calibri",9);
                            pan.Controls.Add(lbPrix);

                            RoundedButton btSelect = MesClasses.ManagerClasse.Rbutton("Choisir",new Point(10, 95),new Size(80, 20),Color.FromArgb(7, 51, 131),Color.White);
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
        // ====================== méthode pour ajouter au datagridview ===============================================
        private void AjouterAuDataGrid(string id,string nom,string unite,string prix)
        {
            decimal prixUnit = Convert.ToDecimal(prix);

            foreach (DataGridViewRow row in dgv_medoc.Rows)
            {
                if (row.IsNewRow)
                    continue;
                if (row.Cells["colID"].Value != null && row.Cells["colID"].Value.ToString() == id)
                {
                    int qte = Convert.ToInt32(row.Cells["colQuantite"].Value);
                    qte++;
                    row.Cells["colQuantite"].Value = qte;
                    row.Cells["colMontant"].Value = qte * prixUnit;
                    return;
                }
            }
            int quantite = 1;
            decimal montant = quantite * prixUnit;
            dgv_medoc.Rows.Add(id,nom,quantite,unite,prixUnit,montant,"Non Livré");
        }

        private decimal CalculTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgv_medoc.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }
                total += Convert.ToDecimal(row.Cells["colMontant"].Value);
            }
            return total;
        }
        // ================================ méthode pour generer la facture =============================================
        private int GenererFacture(int consultationID,int patientID,string type)
        {
            int idFacture = 0;

            try
            {
                decimal total = CalculTotal();
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    string queryInsert = "INSERT INTO facture(id_patient,id_consultation,id_centre,type_facture,date_facture,montant_total,statut)VALUES(@patient,@consultation,@centre,@type,CURDATE(),@total,'Non payé')";
                    MySqlCommand cmd = new MySqlCommand(queryInsert,con);
                    cmd.Parameters.AddWithValue("@patient",patientID);
                    cmd.Parameters.AddWithValue("@consultation",consultationID);
                    cmd.Parameters.AddWithValue("@centre",MesForms.SessionUtilisateur.idCentre);
                    cmd.Parameters.AddWithValue("@type",type);
                    cmd.Parameters.AddWithValue("@total",total);
                    cmd.ExecuteNonQuery();

                    idFacture = Convert.ToInt32(cmd.LastInsertedId);
                }

                GenererDetailFacture(idFacture);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur facture : "+ ex.Message);
            }
            return idFacture;
        }
        // ============================= recuperer l'idfacture ====================================
        private int GetFactureByConsultation(int consultation)
        {
            string query = "SELECT id_facture FROM facture WHERE id_consultation = @id ORDER BY id_facture DESC LIMIT 1";
            MesClasses.ManagerClasse.request_params.Clear();
            MesClasses.ManagerClasse.request_params.Add("@id",consultation.ToString());
            using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
            {
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["id_facture"]);
                }
            }
            return 0;
        }
        // ============================== détails facture =================================================================
        private void GenererDetailFacture(int idFacture)
        {
            try
            {
                foreach (DataGridViewRow row in dgv_medoc.Rows)
                {
                    if (row.IsNewRow) continue;

                    string query = "INSERT INTO detail_facture(id_facture, description, quantite, prix_unitaire, montant)VALUES(@id_facture, @desc, @qte, @prix, @montant)";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@id_facture", idFacture.ToString());
                    MesClasses.ManagerClasse.request_params.Add("@desc", row.Cells["colMedicament"].Value.ToString());
                    MesClasses.ManagerClasse.request_params.Add("@qte", row.Cells["colQuantite"].Value.ToString());
                    MesClasses.ManagerClasse.request_params.Add("@prix", row.Cells["colPrix"].Value.ToString());
                    MesClasses.ManagerClasse.request_params.Add("@montant", row.Cells["colMontant"].Value.ToString());
                    MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erreur détail facture : "+ex.Message);
            }
            
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
        // récuperer l'id_hospitalisation ===========================
        private int RecupererIdHospitalisation()
        {
            int idHospitalisation = 0;

            try
            {
                string query = @"SELECT id_hospitalisation FROM hospitalisation WHERE id_patient=@patient ORDER BY id_hospitalisation DESC LIMIT 1";
                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add("@patient",idPatient.ToString());
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                {
                    if (reader.Read())
                    {
                        idHospitalisation = Convert.ToInt32(reader["id_hospitalisation"]);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }

            return idHospitalisation;
        }
        private void bt_valider_prescription_Click(object sender, EventArgs e)
        {
            try
            {
                int idConsultation = RecupererIdConsultation();
                // ================================ INSERERTION PRESCRIPTIONS ==================================
                foreach (DataGridViewRow row in dgv_medoc.Rows)
                {
                    if (row.IsNewRow)
                        continue;
                    string query = "INSERT INTO prescriptions(id_consultation,id_patient,id_medicament,quantite,unite,statut,date_prescription)VALUES(@id_consultation,@id_patient,@id_medicament,@quantite,@unite,@statut,CURDATE())";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@id_consultation",idConsultation.ToString());
                    MesClasses.ManagerClasse.request_params.Add("@id_patient", idPatient.ToString());
                    MesClasses.ManagerClasse.request_params.Add("@id_medicament",row.Cells["colID"].Value.ToString());
                    MesClasses.ManagerClasse.request_params.Add("@quantite",row.Cells["colQuantite"].Value.ToString());
                    MesClasses.ManagerClasse.request_params.Add("@unite",row.Cells["colUnite"].Value.ToString());
                    MesClasses.ManagerClasse.request_params.Add("@statut","Non Livré");
                    MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params);
                }
              
                // ===================================== PATIENT AMBULATOIRE ========================================
                if (rb_ambulatoire.Checked)
                {
                    int idFacture = GenererFacture(idConsultation,idPatient,"Ambulatoire");
                    MessageBox.Show("Prescription et facture enregistrées");
                }
                    // ================================ PATIENT HOSPITALISE ========================================
                else
                {
                    // 
                    int idHospitalisationID = RecupererIdHospitalisation();
                    // récuperer aussi le nom du docteur qui a préscrit les medocs
                    string nomMedecin = "";
                    string query = "SELECT CONCAT(p.nom,' ',p.post_nom) AS medecin FROM consultation c JOIN personnels p ON c.id_personnel = p.id_personnel WHERE c.id_consultation = @id";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@id",idConsultation.ToString());
                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                    {
                        if (reader.Read())
                        {
                            nomMedecin = reader["medecin"].ToString();
                        }
                        reader.Close();
                    }
                    // ======================= construction de la liste de medocs préscrit par le medecin ===================
                    List<string> medos = new List<string>();
                    foreach (DataGridViewRow row in dgv_medoc.Rows)
                    {
                        if (row.IsNewRow)
                            continue;
                        medos.Add(row.Cells["colMedicament"].Value.ToString());
                    }
                    string medicaments = string.Join(", ", medos);

                    // =============================== HISTORIQUE =======================================
                    MesClasses.Event.SaveHistorique(idHospitalisationID.ToString(),"Prescription ajoutée par Dr : "+nomMedecin+" : "+medicaments);
                    // ================================ ACTUALISATION DE DONNEES =======================
                    LoadPatient();
                    dgv_medoc.Rows.Clear();
                    
                     // ================================= AFFECTATION CHAMBRE ========================
                    MesUserCases.User_affectation affectation = new User_affectation();
                    affectation.Dock = DockStyle.Fill;
                    Form1.GlobalPanel_main.Controls.Clear();
                    Form1.GlobalPanel_main.Controls.Add(affectation);
                }
                MessageBox.Show("Prescription enregistrée avec succès !!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void tb_search_med_TextChanged(object sender, EventArgs e)
        {
            //panel_medicament.Controls.Clear();
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

        // =============== charger les services dans le comboBox =====================
        private void LoadServices()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string query = "SELECT id_service,nom_service FROM services ORDER BY id_service ASC";
                using (MySqlDataAdapter ad = new MySqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    ad.Fill(dt);

                    cbx_service.DataSource = dt;
                    cbx_service.DisplayMember = "nom_service";
                    cbx_service.ValueMember = "id_service";
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MesForms.Form_add_medoc medoc = new MesForms.Form_add_medoc();
            medoc.ShowDialog();
        }
    }
}
