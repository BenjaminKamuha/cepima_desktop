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
    public partial class User_prescription : UserControl
    {
        public static int id_patient;
        string type_patient = "";
        public User_prescription(int PatientID)
        {
            InitializeComponent();
            LoadMedicament();
            id_patient = PatientID;
            rb_ambulatoire.CheckedChanged += rb_ambulatoire_CheckedChanged;
            rb_hospitalise.CheckedChanged += rb_hospitalise_CheckedChanged;
            LoadInfosPatient();
            LoadHistoriquePrescription();
            LoadDernierEEG();
        }

        void rb_hospitalise_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_hospitalise.Checked)
            {
                type_patient = "hospitalisation";
                return;
            }
        }

        void rb_ambulatoire_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_ambulatoire.Checked)
            {
                type_patient = "ambulatoire";
                return;
            }
        }

        private void LoadMedicament(params string[] args)
        {
            panel_medicament.Controls.Clear();

            try
            {
                string query = "";
                if (args.Length != 0)
                {
                    query = "SELECT m.id_medicament,m.nom_medicament,m.photo,m.categorie,ph.unite,m.prix_vente FROM stock_pharmacie ph  JOIN medicament m ON ph.id_medicament = m.id_medicament  WHERE m.nom_medicament LIKE @search"; 
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@search", "%" + args[0] + "%");
                }
                else
                {
                    query = "SELECT m.id_medicament,m.nom_medicament,m.photo,m.categorie,ph.unite,m.prix_vente FROM stock_pharmacie ph  JOIN medicament m ON ph.id_medicament = m.id_medicament  ORDER BY m.nom_medicament ASC";
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
                            pan.Size = new Size(100, 120);
                            pan.BorderRadius = 10;
                            pan.BorderSize = 1;
                            pan.BorderColor = Color.FromArgb(224, 224, 224);
                            pan.HoverCursor = Cursors.Default;
                            MesClasses.ManagerClasse.AddControl(panel_medicament, pan, 5, 5);

                            //====== Avatar ======
                            AvatarControl avatar = new AvatarControl();
                            avatar.Location = new Point(25, 5);
                            avatar.Size = new Size(45, 45);
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

                                MessageBox.Show("Erreur image : " + ex.Message);
                                avatar.Avatar = Properties.Resources.capsules_100px;
                            }

                            pan.Controls.Add(avatar);

                            Label lbNom = MesClasses.ManagerClasse.CustomLabel(nom, new Point(5, 55));
                            lbNom.AutoSize = true;
                            lbNom.Font = new Font("Calibri", 9);
                            pan.Controls.Add(lbNom);

                            Label lbPrix = MesClasses.ManagerClasse.CustomLabel("Prix : " + prix + "$", new Point(20, 70));
                            lbPrix.AutoSize = true;
                            lbPrix.Font = new System.Drawing.Font("Calibri", 9);
                            pan.Controls.Add(lbPrix);

                            RoundedButton btSelect = MesClasses.ManagerClasse.Rbutton("Choisir", new Point(10, 95), new Size(80, 20), Color.FromArgb(7, 51, 131), Color.White);
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
                        ProgressiveDisplay pd = new ProgressiveDisplay(panel_medicament, 100);
                        pd.Start();
                    }
                    else
                    {
                        //panel_medicament.Controls.Clear();
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
        private void AjouterAuDataGrid(string id, string nom, string unite, string prix)
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
            dgv_medoc.Rows.Add(id, nom, quantite, unite, prixUnit, montant);
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

        private void tb_search_medoc_TextChanged(object sender, EventArgs e)
        {
            LoadMedicament(tb_search_medoc.Text);
        }
        // ================================ méthode pour generer la facture =============================================
        private int GenererFacture(int consultationID, int patientID, string type)
        {
            int idFacture = 0;

            try
            {
                decimal total = CalculTotal();
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    string queryInsert = "INSERT INTO facture(id_patient,id_consultation,id_centre,type_facture,date_facture,montant_total,statut)VALUES(@patient,@consultation,@centre,@type,CURDATE(),@total,'Non payé')";
                    MySqlCommand cmd = new MySqlCommand(queryInsert, con);
                    cmd.Parameters.AddWithValue("@patient", patientID);
                    cmd.Parameters.AddWithValue("@consultation", consultationID);
                    cmd.Parameters.AddWithValue("@centre", MesForms.SessionUtilisateur.idCentre);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.ExecuteNonQuery();

                    idFacture = Convert.ToInt32(cmd.LastInsertedId);
                }

                GenererDetailFacture(idFacture);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur facture : " + ex.Message);
            }
            return idFacture;
        }
        // ============================= recuperer l'idfacture ====================================
        private int GetFactureByConsultation(int consultation)
        {
            string query = "SELECT id_facture FROM facture WHERE id_consultation = @id ORDER BY id_facture DESC LIMIT 1";
            MesClasses.ManagerClasse.request_params.Clear();
            MesClasses.ManagerClasse.request_params.Add("@id", consultation.ToString());
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

                MessageBox.Show("Erreur détail facture : " + ex.Message);
            }

        }
        // enregistrement dans la table prescriptions  et récuperation de l'id consultation ===============================

        // récuperer l'id_hospitalisation ===========================
        private int RecupererIdHospitalisation()
        {
            int idHospitalisation = 0;

            try
            {
                string query = "SELECT id_hospitalisation FROM hospitalisation WHERE id_patient=@patient ORDER BY id_hospitalisation DESC LIMIT 1";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@patient", id_patient.ToString());
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
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

        private int RecupererIdConsultation()
        {
            int idConsultation = 0;
            try
            {
                string query = "SELECT id_consultation FROM consultation WHERE id_patient=@patient ORDER BY id_consultation DESC LIMIT 1";
                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add("@patient", id_patient.ToString());
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                {
                    if (reader.Read())
                    {
                        idConsultation = Convert.ToInt32(reader["id_consultation"]);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }

            return idConsultation;
        }
        // ========================== METHODE POUR LA MISE EN JOUR DE LA CONSULTATION (STATUT 'LIVRE') ===============================
        private void UpdateConsultation(int idConsultation)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string queryUpdate = "UPDATE consultation SET statut_presc='Livrée' WHERE id_consultation = @id";
                    using (MySqlCommand cmd = new MySqlCommand(queryUpdate, con))
                    {
                        cmd.Parameters.AddWithValue("@id",idConsultation);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void tb_search_medoc_TextChanged_1(object sender, EventArgs e)
        {
            LoadMedicament(tb_search_medoc.Text);
        }

        private void bt_valider_prescription_Click(object sender, EventArgs e)
        {
            if (!rb_ambulatoire.Checked && rb_hospitalise.Checked)
            {
                MessageBox.Show("Vous devez sélectiionner le type de patient");
                return;
            }
            else
            {
                ValiderPrescriptions();
            }
         
        }

        // ===================================== VALIDER PRESCRIPTIONS ==========================================
        private void ValiderPrescriptions()
        {
          
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();

                try
                {
                    int idSortie = 0;

                    //==================== SORTIE STOCK ====================
                    string queryInsertSortie = "INSERT INTO sorties_stock(id_centre,type_sortie,id_patient,date_sortie)VALUES(@centre,@type,@patient,CURDATE())";

                    using (MySqlCommand cmd = new MySqlCommand(queryInsertSortie, con, tr))
                    {
                        cmd.Parameters.AddWithValue("@centre", MesForms.SessionUtilisateur.idCentre);
                        cmd.Parameters.AddWithValue("@type", type_patient);
                        cmd.Parameters.AddWithValue("@patient", id_patient);

                        cmd.ExecuteNonQuery();

                        idSortie = Convert.ToInt32(cmd.LastInsertedId);
                    }

                    //==================== CONSULTATION ====================
                    int idconsultation = RecupererIdConsultation();

                    //==================== PRESCRIPTIONS ====================
                    foreach (DataGridViewRow row in dgv_medoc.Rows)
                    {
                        if (row.IsNewRow)
                            continue;

                        string queryInsertPresc = "INSERT INTO prescriptions(id_sortie,id_patient,id_medicament,id_consultation,quantite,unite,date_prescription)VALUES(@sortie,@patient,@medoc,@consultation,@qte,@unite,CURDATE())";
                        using (MySqlCommand cmd = new MySqlCommand(queryInsertPresc, con, tr))
                        {
                            cmd.Parameters.AddWithValue("@sortie", idSortie);
                            cmd.Parameters.AddWithValue("@patient", id_patient);
                            cmd.Parameters.AddWithValue("@medoc", row.Cells["colID"].Value);
                            cmd.Parameters.AddWithValue("@consultation", idconsultation);
                            cmd.Parameters.AddWithValue("@qte", row.Cells["colQuantite"].Value);
                            cmd.Parameters.AddWithValue("@unite", row.Cells["colUnite"].Value);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    //==================== TRAITEMENT FINAL ====================
                    if (type_patient == "ambulatoire")
                    {
                        GenererFacture(idconsultation, id_patient, "Ambulatoire");
                        UpdateConsultation(idconsultation);
                    }
                    else
                    {
                        // Ouvrir l'affectation de chambre
                        MesUserCases.User_affectation affectation = new User_affectation();
                        affectation.Dock = DockStyle.Fill;

                        Form1.GlobalPanel_main.Controls.Clear();
                        Form1.GlobalPanel_main.Controls.Add(affectation);
                    }

                    //==================== VALIDATION ====================
                    tr.Commit();

                    dgv_medoc.Rows.Clear();

                    MessageBox.Show("Prescription ajoutée avec succès.");
                }
                catch (Exception ex)
                {
                    try
                    {
                        tr.Rollback();
                    }
                    catch
                    {

                    }

                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        // ======================================= CHARGER LES INFORMATIONS DU PATIENT =================================
        private void LoadInfosPatient()
        {
            int idConsultation = RecupererIdConsultation();
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string query = "SELECT p.nom,p.post_nom,p.sexe,TIMESTAMPDIFF(YEAR,p.date_naissance,CURDATE()) AS age,CONCAT(pe.nom,' ',pe.post_nom,' ',pe.prenom) AS medecin,c.date_consultation FROM consultation c INNER JOIN patients p ON c.id_patient=p.id_patient INNER JOIN personnels pe ON pe.id_personnel=c.id_personnel WHERE c.id_consultation=@consultation LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@consultation",idConsultation);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lb_nom.Text = reader["nom"] + " " + reader["post_nom"];
                                lb_sexe.Text = reader["sexe"].ToString();
                                lb_age.Text = reader["age"] + " ans";
                                lb_type_patient.Text = "Patient : " +type_patient.ToString();
                                lb_date.Text = Convert.ToDateTime(reader["date_consultation"]).ToString("dd/MM/yyyy");
                                lb_medecin.Text = "Medecin: "+reader["medecin"].ToString();
                            }
                            reader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // ====================================== CHARGER L'HISTORIQUE DE PRESCRIPTION =====================================
        private void LoadHistoriquePrescription()
        {
            dgvHistorique.Rows.Clear();

            try
            {
                string query = "SELECT pr.date_prescription,CONCAT(pe.nom,' ',pe.post_nom) AS medecin,m.nom_medicament FROM prescriptions pr INNER JOIN consultation c ON c.id_consultation=pr.id_consultation INNER JOIN personnels pe ON pe.id_personnel=c.id_personnel INNER JOIN medicament m ON m.id_medicament=pr.id_medicament WHERE pr.id_patient=@patient ORDER BY pr.date_prescription DESC";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@patient", id_patient.ToString());

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(query,
                    MesClasses.ManagerClasse.request_params,
                    true))
                {
                    while (reader.Read())
                    {
                        int row = dgvHistorique.Rows.Add();
                        dgvHistorique.Rows[row].Cells["colDate"].Value = Convert.ToDateTime(reader["date_prescription"]).ToString("dd/MM/yyyy");
                        dgvHistorique.Rows[row].Cells["colMedecin"].Value = reader["medecin"];
                        dgvHistorique.Rows[row].Cells["colMedoc"].Value = reader["nom_medicament"];
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ======================================= CHARGER LE DERNIER EXAMEN EEG  =============================================
        private void LoadDernierEEG()
        {
            try
            {
                string query = "SELECT * FROM examens_eeg WHERE id_patient=@patient ORDER BY date_examen DESC LIMIT 1";

                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@patient", id_patient.ToString());

                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                {
                    if (reader.Read())
                    {
                        lb_date_examen.Text = Convert.ToDateTime(reader["date_examen"]).ToString("dd/MM/yyyy");
                        lb_type.Text = reader["type_EEG"].ToString();
                        lb_resultat.Text = reader["resultat"].ToString();
                        lb_interpretation.Text = reader["interpretation"].ToString();
                        lblStatut.Text = reader["statut"].ToString();
                    }
                    else
                    {
                        lb_date_examen.Text = "-";
                        lb_type.Text = "-";
                        lb_resultat.Text = "Aucun examen";
                        lb_interpretation.Text = "-";
                        lblStatut.Text = "-";
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
