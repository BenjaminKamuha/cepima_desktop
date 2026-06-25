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
    public partial class User_patients_hospitalises : UserControl
    {
        string  hospitalisationID,ID_PATIENT;
        string STATUT;
        public User_patients_hospitalises()
        {
            InitializeComponent();
            ChargerPatientsHospitalises();
            //ChargerInfosPatient("1");
            dgv_suivi.ReadOnly = true;
            cbx_afficher.SelectedIndexChanged += cbx_afficher_SelectedIndexChanged;
            LoadFiltrer();
        }

        void cbx_afficher_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSuivi(cbx_afficher.Text);
        }
        private void LoadFiltrer()
        {
            cbx_afficher.Items.Clear();
            cbx_afficher.Items.Add("Tous");
            cbx_afficher.Items.Add("Aujourd'hui");
            cbx_afficher.Items.Add("Cette semaine");

            cbx_afficher.SelectedIndex = 0;
        }
        private void ChargerInfosPatient(string idHospitalisation)
        {
            try
            {
                string query = "SELECT p.nom,p.post_nom,p.prenom,p.sexe,p.telephone,p.adresse,p.numero_fiche,h.date_entree,h.motif,h.etat FROM patients p INNER JOIN hospitalisation h ON p.id_patient=h.id_patient WHERE h.id_hospitalisation=@id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id", idHospitalisation);

                using (MySqlDataReader reader =
                MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                {
                    if (reader.Read())
                    {
                        lb_nom.Text = reader["nom"].ToString();
                        lb_postnom.Text = reader["post_nom"].ToString();
                        lb_prenom.Text = reader["prenom"].ToString();
                        lb_genre.Text = reader["sexe"].ToString();
                        lb_phone.Text = reader["telephone"].ToString();
                        lb_adresse.Text = reader["adresse"].ToString();
                        lb_numero_fiche.Text = reader["numero_fiche"].ToString();

                        //======== Hospitalisation ========

                        lb_date_hospitalisation.Text = Convert.ToDateTime(reader["date_entree"]).ToString("dd/MM/yyyy");
                        lb_motif.Text = reader["motif"].ToString();
                        lb_statut.Text = reader["etat"].ToString();
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
        private void ChargerPatientsHospitalises(params string[] args)
        {
            flowLayoutPanel1.Controls.Clear();
            if (args.Length != 0)
            {
                try
                {
                    using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                    {
                        string query = "SELECT h.id_hospitalisation,p.id_patient,CONCAT(p.nom,' ',p.post_nom) AS Patient,h.date_entree,h.statut FROM hospitalisation h INNER JOIN patients p ON h.id_patient = p.id_patient WHERE CONCAT(p.nom,' ',p.post_nom) LIKE @search";
                        MesClasses.ManagerClasse.request_params.Clear();
                        MesClasses.ManagerClasse.request_params.Add("@search", "%" + args[0] + "%");
                        MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true);
                        if (reader.HasRows)
                        {
                            int i = 0;
                            while (reader.Read())
                            {
                                string idHospitalisation = reader["id_hospitalisation"].ToString();
                                string patientID = reader["id_patient"].ToString();
                                string patient = reader["Patient"].ToString();
                                string date = reader["date_entree"].ToString();
                                STATUT = reader["statut"].ToString();
                                //création des panel dynamiquement
                                Panel p = new Panel();
                                p.Size = new Size(180, 70);
                                p.BorderStyle = BorderStyle.FixedSingle; // 193; 318
                                p.Cursor = Cursors.Hand;

                                //avatar
                                AvatarControl avatar = new AvatarControl();
                                avatar.Size = new Size(40, 40);
                                avatar.Location = new Point(5, 5);
                                avatar.BorderColor = Color.Transparent;
                                avatar.Avatar = Properties.Resources.user_male_40px;

                                p.Controls.Add(avatar);

                                //Label nom
                                Label lb = new Label();
                                lb.Text = patient;
                                lb.AutoSize = true;
                                lb.Location = new Point(50, 20); //Calibri; 9,75pt
                                lb.Font = new System.Drawing.Font("Calibri",9);
                                p.Controls.Add(lb);

                                // label date hospitalisation
                                Label lbHospi = new Label();
                                lbHospi.AutoSize = true;
                                lbHospi.Location = new Point(30, 50);
                                lbHospi.Text = "Hospitalisé le " + date;
                                lbHospi.Font = new System.Drawing.Font("Calibri", 9);
                                p.Controls.Add(lbHospi);
                                //evenement (expression lambda)
                                p.Click += (s, e) =>
                                {
                                    ChargerInfosPatient(idHospitalisation);
                                    hospitalisationID = idHospitalisation;
                                    ID_PATIENT = patientID;
                                    LoadDernierPrescription(patientID);
                                    LoadResumeSejour();
                                    LoadSuivi();
                                    LoadHistorique();
                                };
                                flowLayoutPanel1.Controls.Add(p);
                                i++;

                                // ============================== test par raport au statut ==========================================
                                if (STATUT == "Hospitalisé")
                                {
                                    p.BackColor = Color.FromArgb(245, 246, 242);//245; 246; 242
                                    p.BackColor = Color.Red;
                                }
                                if (STATUT == "Sorti")
                                {
                                    p.BackColor = Color.LightGreen;
                                }
                            }
                            reader.Close();
                            lb_nombre_patient.Text = i.ToString() + " patient(s)";
                        }
                        else
                        {
                            flowLayoutPanel1.Controls.Clear();
                            lb_search.Text = "Pas de patient pour '" + args[0] + "'";
                            flowLayoutPanel1.Controls.Add(lb_search);
                            lb_search.Visible = true;
                            lb_nombre_patient.Text = "Aucun patient";
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                try
                {
                    using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                    {
                        string query = "SELECT h.id_hospitalisation,p.id_patient,CONCAT(p.nom,' ',p.post_nom) AS Patient,h.date_entree FROM hospitalisation h INNER JOIN patients p ON h.id_patient = p.id_patient";
                        using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                        {
                            if (reader.HasRows)
                            {
                                int i = 0;
                                while (reader.Read())
                                {
                                    string idHospitalisation = reader["id_hospitalisation"].ToString();
                                    string patientID = reader["id_patient"].ToString();
                                    string patient = reader["Patient"].ToString();
                                    string date = Convert.ToDateTime(reader["date_entree"]).ToString("dd/MM/yyyy");
                                    //création des panel dynamiquement
                                    Panel p = new Panel();
                                    p.Size = new Size(190, 70);
                                    p.BorderStyle = BorderStyle.FixedSingle; //193; 318
                                    p.Cursor = Cursors.Hand;

                                    //avatar
                                    AvatarControl avatar = new AvatarControl();
                                    avatar.Size = new Size(40, 40);
                                    avatar.Location = new Point(5, 5);
                                    avatar.BorderColor = Color.Transparent;
                                    avatar.Avatar = Properties.Resources.user_male_40px;

                                    p.Controls.Add(avatar);

                                    //Label nom
                                    Label lb = new Label();
                                    lb.Text = patient;
                                    lb.AutoSize = true;
                                    lb.Location = new Point(50, 20);
                                    lb.Font = new System.Drawing.Font("Calibri", 9);
                                    p.Controls.Add(lb);

                                    // label date hospitalisation
                                    Label lbHospi = new Label();
                                    lbHospi.AutoSize = true;
                                    lbHospi.Location = new Point(30, 50);
                                    lbHospi.Text = "Hospitalisé le " + date;
                                    lbHospi.Font = new System.Drawing.Font("Calibri", 9);
                                    p.Controls.Add(lbHospi);
                                    //evenement (expression lambda)
                                    p.Click += (s, e) =>
                                    {
                                        ChargerInfosPatient(idHospitalisation);
                                        hospitalisationID = idHospitalisation;
                                        ID_PATIENT = patientID;
                                        LoadDernierPrescription(patientID);
                                        LoadResumeSejour();
                                        LoadSuivi();
                                        LoadHistorique();
                                    };
                                    flowLayoutPanel1.Controls.Add(p);
                                    i++;

                                    // ============================== test par raport au statut ==========================================
                                    if (STATUT == "Hospitalisé")
                                    {
                                        p.BackColor = Color.FromArgb(245, 246, 242);//245; 246; 242
                                    }
                                    if (STATUT == "Sorti")
                                    {
                                        p.BackColor = Color.LightGreen;
                                    }
                                }
                                reader.Close();
                                lb_nombre_patient.Text = i.ToString() + " patient(s)";
                            }
                            else
                            {
                                lb_search.Text = "Aucun patient hospitalisé";
                                lb_search.Visible = true;
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        // ================= méthode pour charger le séjour du patient =======================
        private void LoadResumeSejour()
        {
            try
            {
                string query = "SELECT c.numero_chambre,c.type_chambre,h.date_entree,DATEDIFF(NOW(),h.date_entree) AS jours FROM hospitalisation h LEFT JOIN affectation_chambre a ON h.id_hospitalisation = a.id_hospitalisation LEFT JOIN chambre c ON a.id_chambre = c.id_chambre WHERE h.id_hospitalisation=@id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",hospitalisationID);

                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                {
                    if (reader.Read())
                    {
                        lb_chambre_actuelle.Text = "Chamb n°:" + reader["numero_chambre"];
                        lb_type_chambre.Text = reader["type_chambre"].ToString();
                        lb_date_entree.Text = Convert.ToDateTime(reader["date_entree"]).ToString("dd/MM/yyyy");
                        lb_nombre_jours.Text = reader["jours"] + "Jours";
                    }
                    else
                    {
                        lb_chambre_actuelle.Text = "Chambre :---";
                        lb_type_chambre.Text = "Type : ---";
                        lb_date_entree.Text = "Date :---";
                        lb_nombre_jours.Text = "jours :---";
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erreur : "+ex.Message);
            }
        }
        // ===================== derniere préscription ========================================
        private void LoadDernierPrescription(string patient_id)
        {
            try
            {
                string query = "SELECT pr.id_prescription,DATE(pr.date_prescription) AS datePrescription,CONCAT(p.nom,' ',p.post_nom) AS medecin FROM prescriptions pr INNER JOIN consultation c ON pr.id_consultation=c.id_consultation INNER JOIN personnels p ON c.id_personnel=p.id_personnel WHERE pr.id_patient =@id ORDER BY pr.id_prescription DESC LIMIT 1";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",patient_id);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                {
                    if (reader.Read())
                    {
                        lb_id_prescription.Text = "Préscription n°: " + reader["id_prescription"];
                        lb_date_prescription.Text = Convert.ToDateTime(reader["datePrescription"]).ToString("dd/MM/yyyy");
                        lb_nom_medecin.Text = reader["medecin"].ToString();
                    }
                    else
                    {
                        lb_id_prescription.Text = "---";
                        lb_date_prescription.Text = "---";
                        lb_nom_medecin.Text = "---";
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : "+ex.Message);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                ChargerPatientsHospitalises();
            }
            else
            {
                ChargerPatientsHospitalises(textBox1.Text);
            }
        }

        private void bt_add_suivie_Click(object sender, EventArgs e)
        {
            if (hospitalisationID == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient avant d'effectuer son suivi");
                return;
            }
            MesForms.Form_add_suivi_hospitalisation suivi = new MesForms.Form_add_suivi_hospitalisation(hospitalisationID);
            suivi.ShowDialog();
        }

        // =================================================== suivi hospitalisation ============================
        private void LoadSuivi(string filter = "Tous")
        {
            dgv_suivi.Rows.Clear();

            try
            {
                string query = "";

                // ================= FILTRES =================

                if (filter == "Tous") // tous ensemble
                {
                    query = "SELECT id_suivi,temperature,tension,rythme_cardiaque,observation,date_suivi,etat_mental FROM suivi_hospitalisation WHERE id_hospitalisation=@id ORDER BY date_suivi DESC";
                }
                    // afficher les suivis du jour
                else if (filter == "Aujourd'hui")
                {
                    query = "SELECT id_suivi,temperature,tension,rythme_cardiaque,observation,date_suivi,etat_mental FROM suivi_hospitalisation WHERE id_hospitalisation=@id AND DATE(date_suivi)=CURDATE() ORDER BY date_suivi DESC";
                }
                    // afficher les suivi de la semaine
                else if (filter == "Cette semaine")
                {
                    query = "SELECT id_suivi,temperature,tension,rythme_cardiaque,observation,date_suivi,etat_mental FROM suivi_hospitalisation WHERE id_hospitalisation=@id AND date_suivi >= DATE_SUB(NOW(),INTERVAL 7 DAY) ORDER BY date_suivi DESC";
                }

                // ================= PARAMETRES =================

                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",hospitalisationID);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                {

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int row = dgv_suivi.Rows.Add();
                            dgv_suivi.Rows[row].Tag = reader["id_suivi"];
                            dgv_suivi.Rows[row].Cells["Date"].Value = Convert.ToDateTime(reader["date_suivi"]).ToString("dd/MM/yyyy HH:mm");
                            dgv_suivi.Rows[row].Cells["Temp"].Value = reader["temperature"]+ " °C";
                            dgv_suivi.Rows[row].Cells["Tension"].Value = reader["tension"];
                            dgv_suivi.Rows[row].Cells["Pouls"].Value = reader["rythme_cardiaque"];
                            dgv_suivi.Rows[row].Cells["Obs"].Value = reader["observation"];
                            dgv_suivi.Rows[row].Cells["etat"].Value = reader["etat_mental"];

                            // ===== STYLE

                            double temp = Convert.ToDouble(reader["temperature"]);

                            if (temp >= 38)
                            {
                                dgv_suivi.Rows[row].DefaultCellStyle.BackColor = Color.MistyRose;
                            }

                            ApplyStyle();
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Erreur : " + ex.Message);
            }
        }

        private void ApplyStyle()
        {
            dgv_suivi.Columns["Date"].Width = 100;
            dgv_suivi.Columns["Temp"].Width = 60;
            dgv_suivi.Columns["Tension"].Width = 80;
            dgv_suivi.Columns["Pouls"].Width = 80;
            dgv_suivi.Columns["Obs"].Width = 120;
            dgv_suivi.Columns["etat"].Width = 70;
            dgv_suivi.Columns["colSave"].Width = 10;
            dgv_suivi.Columns["colUpdate"].Width = 10;
            dgv_suivi.Columns["colDelete"].Width = 10;
        }
        // ============================== Charger les evenements dans le datagridview ======================================================
        private void LoadHistorique()
        {
            dgv_historique.Rows.Clear();

            try
            {
                string query ="SELECT id_historique,evenement,date_evenement FROM historique_sejour WHERE id_hospitalisation=@id ORDER BY date_evenement DESC";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",hospitalisationID);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                {

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int row = dgv_historique.Rows.Add();
                            dgv_historique.Rows[row].Cells["colDate"].Value = Convert.ToDateTime(reader["date_evenement"]).ToString("dd/MM/yyyy HH:mm");
                            dgv_historique.Rows[row].Cells["colEvenement"].Value = reader["evenement"];
                            dgv_historique.Rows[row].Tag = reader["id_historique"];

                            dgv_historique.Columns["colDate"].Width = 130;
                        }
                        reader.Close();
                    }
                    else
                    {
                        dgv_historique.Rows.Add("","Aucun événement");
                    }

                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : "+ ex.Message);
            }
        }

        private void bt_sortie_patient_Click(object sender,EventArgs e)
        {
            if (STATUT == "Hospitalisé")
            {
                DialogResult rep = MessageBox.Show("Confirmer la sortie du patient ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rep != DialogResult.Yes)
                    return;
                try
                {
                    using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                    {

                        // ========= changer état hospitalisation

                        string queryHosp = "UPDATE hospitalisation SET etat='Sorti',date_sortie=NOW() WHERE id_hospitalisation=@id";
                        MySqlCommand cmd1 = new MySqlCommand(queryHosp, con);
                        cmd1.Parameters.AddWithValue("@id", hospitalisationID);
                        cmd1.ExecuteNonQuery();

                        // ======================== récupérer chambre actuelle =============================================

                        string chambreID = "";

                        string querySelect = "SELECT id_chambre FROM affectation_chambre WHERE id_hospitalisation=@id ORDER BY id_affectation DESC LIMIT 1";
                        MySqlCommand cmd2 = new MySqlCommand(querySelect, con);

                        cmd2.Parameters.AddWithValue("@id", hospitalisationID);
                        object result = cmd2.ExecuteScalar();

                        if (result != null)
                        {
                            chambreID = result.ToString();
                        }

                        // ===================================================================================================
                        // GENERER LA FACTURE POUR L'HOSPITALISATION
                        //=====================================================================================================
                        int idConsultation = RecupererIdConsultation();
                        GenererFactureHospitalisation(idConsultation);

                        // ==================== libérer la chambre ============================================================

                        if (chambreID != "")
                        {
                            string queryChambre = "UPDATE chambre SET statut='Disponible'WHERE id_chambre=@id";

                            MySqlCommand cmd3 = new MySqlCommand(queryChambre, con);
                            cmd3.Parameters.AddWithValue("@id", chambreID);
                            cmd3.ExecuteNonQuery();
                        }

                        // ================================== mettre a jour la date fin dans affectation ========================
                        string queryAf = "UPDATE affectation_chambre SET date_fin = NOW() WHERE id_hospitalisation =@id AND date_fin IS NULL";
                        MesClasses.ManagerClasse.request_params.Clear();
                        MesClasses.ManagerClasse.request_params.Add("@id", hospitalisationID);
                        MesClasses.ManagerClasse.CRUD(queryAf, MesClasses.ManagerClasse.request_params);
                        MesClasses.Event.SaveHistorique(hospitalisationID, "Patient sorti");
                        MessageBox.Show("Sortie enregistrée");
                        ChargerPatientsHospitalises();
                        LoadHistorique();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                    ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Desolé, ce patient est deja sorti ");
                return;
            }
        }

        // =============================== recuperer l'idConsultation =====================================================
        private int RecupererIdConsultation()
        {
            int idConsultation = 0;
            try
            {
                string query = "SELECT id_consultation FROM hospitalisation WHERE id_hospitalisation = @id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",hospitalisationID);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
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

                MessageBox.Show("Erreur récuperation consultation : "+ex.Message);
            }
            return idConsultation;
        }

        // ==================== GENERER LA FACTURE  D'HOSPITALISATION A TRAVERS UNE METHODE SPECIALE ======================================
        private void GenererFactureHospitalisation(int idConsultation)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                MySqlTransaction trans = con.BeginTransaction();

                try
                {
                    // =========================================
                    // calcul hospitalisation
                    // =========================================

                    decimal tarif_journalier = 0;
                    int nbJours = 1;
                    decimal montantChambre = 0;
                    string queryHosp = "SELECT h.date_entree,c.tarif_journalier FROM hospitalisation h JOIN affectation_chambre a ON h.id_hospitalisation = a.id_hospitalisation JOIN chambre c ON a.id_chambre = c.id_chambre WHERE h.id_hospitalisation=@id ORDER BY a.id_affectation DESC LIMIT 1";

                    MySqlCommand cmdHosp = new MySqlCommand(queryHosp,con,trans);
                    cmdHosp.Parameters.AddWithValue("@id",hospitalisationID);
                    using (MySqlDataReader reader = cmdHosp.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime entree = Convert.ToDateTime(reader["date_entree"]);
                            tarif_journalier = Convert.ToDecimal(reader["tarif_journalier"]);

                            nbJours = (DateTime.Now - entree).Days;

                            if (nbJours <= 0)
                                nbJours = 1;

                            montantChambre = nbJours *tarif_journalier;
                        }
                        reader.Close();
                    }

                    // =========================================
                    // calcul médicaments
                    // =========================================

                    decimal montantMedicament = 0;
                    string queryMedTotal = "SELECT SUM(p.quantite * m.prix_vente) AS total FROM prescriptions p JOIN medicament m ON p.id_medicament = m.id_medicament WHERE p.id_consultation=@id";
                    MySqlCommand cmdMedTotal = new MySqlCommand(queryMedTotal,con,trans);
                    cmdMedTotal.Parameters.AddWithValue("@id",idConsultation);
                    object result = cmdMedTotal.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        montantMedicament = Convert.ToDecimal(result);
                    }

                    // =========================================
                    // total facture
                    // =========================================

                    decimal total = montantChambre + montantMedicament;

                    // =========================================
                    // insertion facture
                    // =========================================

                    int idFacture = 0;
                    string queryFacture = "INSERT INTO facture(id_patient,id_consultation,id_centre,type_facture,date_facture,montant_total,statut)VALUES(@patient,@consultation,@centre,@type,NOW(),@total,'Non payé')";
                    MySqlCommand cmdFacture = new MySqlCommand(queryFacture,con,trans);
                    cmdFacture.Parameters.AddWithValue("@patient",ID_PATIENT);
                    cmdFacture.Parameters.AddWithValue("@consultation",idConsultation);
                    cmdFacture.Parameters.AddWithValue("@centre",MesForms.SessionUtilisateur.idCentre);
                    cmdFacture.Parameters.AddWithValue("@type","Hospitalisé");
                    cmdFacture.Parameters.AddWithValue("@total",total);
                    cmdFacture.ExecuteNonQuery();

                    idFacture = Convert.ToInt32(cmdFacture.LastInsertedId);

                    // =========================================
                    // détail hospitalisation
                    // =========================================

                    string queryDetailHosp = "INSERT INTO detail_facture(id_facture,description,quantite,prix_unitaire,montant)VALUES(@facture,@desc,@qte,@prix,@montant)";
                    MySqlCommand cmdDetailHosp = new MySqlCommand(queryDetailHosp,con,trans);
                    cmdDetailHosp.Parameters.AddWithValue("@facture",idFacture);
                    cmdDetailHosp.Parameters.AddWithValue("@desc","Hospitalisation");
                    cmdDetailHosp.Parameters.AddWithValue("@qte",nbJours);
                    cmdDetailHosp.Parameters.AddWithValue("@prix",tarif_journalier);
                    cmdDetailHosp.Parameters.AddWithValue("@montant",montantChambre);
                    cmdDetailHosp.ExecuteNonQuery();

                    // =========================================
                    // récupérer médicaments
                    // =========================================

                    List<string> noms = new List<string>();
                    List<int> quantites = new List<int>();
                    List<decimal> prixs = new List<decimal>();
                    string queryMed = "SELECT m.nom_medicament,p.quantite,m.prix_vente FROM prescriptions p JOIN medicament m ON p.id_medicament = m.id_medicament WHERE p.id_consultation=@id";
                    MySqlCommand cmdMed = new MySqlCommand(queryMed,con,trans);
                    cmdMed.Parameters.AddWithValue("@id",idConsultation);
                    using (MySqlDataReader reader = cmdMed.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            noms.Add(reader["nom_medicament"].ToString());
                            quantites.Add(Convert.ToInt32(reader["quantite"]));
                            prixs.Add(Convert.ToDecimal(reader["prix_vente"]));
                        }

                        reader.Close();
                    }

                    // =========================================
                    // insertion détail médicaments
                    // =========================================

                    for (int i = 0;i < noms.Count;i++)
                    {
                        decimal montant = quantites[i] * prixs[i];
                        string queryDetailMed = "INSERT INTO detail_facture(id_facture,description,quantite,prix_unitaire,montant)VALUES(@facture,@desc,@qte,@prix,@montant)";
                        MySqlCommand cmdDetailMed = new MySqlCommand(queryDetailMed,con,trans);
                        cmdDetailMed.Parameters.AddWithValue("@facture",idFacture);
                        cmdDetailMed.Parameters.AddWithValue("@desc",noms[i]);
                        cmdDetailMed.Parameters.AddWithValue("@qte",quantites[i]);
                        cmdDetailMed.Parameters.AddWithValue("@prix",prixs[i]);
                        cmdDetailMed.Parameters.AddWithValue("@montant",montant);
                        cmdDetailMed.ExecuteNonQuery();
                    }

                    // =========================================
                    // validation transaction
                    // =========================================

                    trans.Commit();
                    MessageBox.Show("Facture hospitalisation générée\n\nTotal : "+ total + " Fc");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Erreur : "+ ex.Message);
                }
            }
        }

        // ======================================== facture ===============================================================================
        private int CreerFacture(int patient,int consultation,decimal total)
        {
            int idFacture = 0;

            try
            {
                string query = "INSERT INTO facture(id_patient,id_consultation,id_centre,date_facture,montant_total,statut)VALUES(@patient,@consultation,@centre,CURDATE(),@total,'Non payé')";
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    MySqlCommand cmd = new MySqlCommand(query,con);
                    cmd.Parameters.AddWithValue("@patient",patient);
                    cmd.Parameters.AddWithValue("@consultation",consultation);
                    cmd.Parameters.AddWithValue("@centre",MesForms.SessionUtilisateur.idCentre);
                    cmd.Parameters.AddWithValue("@total",total);
                    cmd.ExecuteNonQuery();

                    idFacture = Convert.ToInt32(cmd.LastInsertedId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return idFacture;
        }
        // ====================== Detail facture ==========================================================
        private void AjouterDetailFacture(int idFacture,string description,int quantite,decimal prix,decimal montant)
        {
            string query = "INSERT INTO detail_facture(id_facture,description,quantite,prix_unitaire,montant)VALUES(@facture,@desc,@qte,@prix,@montant)";
            MesClasses.ManagerClasse.request_params.Clear();
            MesClasses.ManagerClasse.request_params.Add("@facture",idFacture.ToString());
            MesClasses.ManagerClasse.request_params.Add("@desc",description);
            MesClasses.ManagerClasse.request_params.Add("@qte",quantite.ToString());
            MesClasses.ManagerClasse.request_params.Add("@prix",prix.ToString());
            MesClasses.ManagerClasse.request_params.Add("@montant",montant.ToString());
            MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params);
        }
        // ================= calcul du montant total des medicaments prescrits lors de l'hosptalisation =====================================
        private decimal CalculerMontantMedicament()
        {
            decimal total = 0;

            try
            {
                string query = "SELECT SUM(m.prix_vente * p.quantite) AS total FROM prescriptions p JOIN medicament m ON p.id_medicament = m.id_medicament WHERE p.id_patient=@id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",ID_PATIENT);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                {
                    if (reader.Read() && reader["total"] != DBNull.Value)
                    {
                        total = Convert.ToDecimal(reader["total"]);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return total;
        }
        // ========================================= calcul du chambre =================================================
        private decimal CalculerMontantChambre()
        {
            decimal tarif = 0;
            int nbJours = 1;

            try
            {
                string query = "SELECT h.date_entree,c.tarif_journalier FROM hospitalisation h JOIN affectation_chambre a ON h.id_hospitalisation = a.id_hospitalisation JOIN chambre c ON a.id_chambre = c.id_chambre WHERE h.id_hospitalisation=@id ORDER BY a.id_affectation DESC LIMIT 1";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",hospitalisationID);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                {
                    if (reader.Read())
                    {
                        DateTime entree = Convert.ToDateTime(reader["date_entree"]);

                        tarif = Convert.ToDecimal(reader["tarif_journalier"]);

                        nbJours = (DateTime.Now - entree).Days;

                        if (nbJours <= 0)
                            nbJours = 1;
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return tarif * nbJours;
        }
        private void bt_display_prescription_Click(object sender, EventArgs e)
        {
            if (hospitalisationID == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient");
                return;
            }
            else
            {
                MesForms.Form_Display_prescription prescription = new MesForms.Form_Display_prescription(hospitalisationID);
                prescription.ShowDialog();
            }
        }

        private void bt_load_suivi__Click(object sender, EventArgs e)
        {
            LoadSuivi(cbx_afficher.Text);
            LoadHistorique();
        }

        private void bt_new_prescription_Click(object sender, EventArgs e)
        {
            MesForms.Form_New_prescription presc = new MesForms.Form_New_prescription(hospitalisationID,ID_PATIENT);
            presc.ShowDialog();
        }

        private void dgv_suivi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            string idSuivi = dgv_suivi.Rows[e.RowIndex].Tag.ToString();

            // si bouton supprimer clicqué
            if (dgv_suivi.Columns[e.ColumnIndex].Name == "colDelete")
            {
                var result = MessageBox.Show("Supprimer cette donnée ?","Confirmation",MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string queryDelete = "DELETE FROM suivi_hospitalisation WHERE id_suivi = @id";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@id",idSuivi);
                    MesClasses.ManagerClasse.CRUD(queryDelete,MesClasses.ManagerClasse.request_params);
                    MessageBox.Show("Donnée supprimée avec succès !!");
                    LoadSuivi();
                }
            }

            // si bouton modifier clicqué on passe au mode edition
            if (dgv_suivi.Columns[e.ColumnIndex].Name == "colUpdate")
            {
                dgv_suivi.ReadOnly = false;
                dgv_suivi.Rows[e.RowIndex].Cells["Temp"].ReadOnly = false;
                dgv_suivi.Rows[e.RowIndex].Cells["Tension"].ReadOnly = false;
                dgv_suivi.Rows[e.RowIndex].Cells["Pouls"].ReadOnly = false;
                dgv_suivi.Rows[e.RowIndex].Cells["Obs"].ReadOnly = false;

                dgv_suivi.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            }

            // si bouton save clicqué, on enregistre les modifications du tableau
            if (dgv_suivi.Columns[e.ColumnIndex].Name == "colSave")
            {
                SaveModification_suivi(e.RowIndex);
            }
        }
        // ============================================ modification des données edités dans le tableau =========================
        private void SaveModification_suivi(int rowIndex)
        {
            string idSuivi = dgv_suivi.Rows[rowIndex].Tag.ToString();
            string temp = dgv_suivi.Rows[rowIndex].Cells["Temp"].Value.ToString();
            string tension = dgv_suivi.Rows[rowIndex].Cells["Tension"].Value.ToString();
            string poul = dgv_suivi.Rows[rowIndex].Cells["Pouls"].Value.ToString();
            string observation = dgv_suivi.Rows[rowIndex].Cells["Obs"].Value.ToString();

            string queryUpdate = "UPDATE suivi_hospitalisation SET temperature=@temp,tension=@tension,rythme_cardiaque=@frequence,observation=@obs WHERE id_suivi = @id";
            MesClasses.ManagerClasse.request_params.Clear();
            MesClasses.ManagerClasse.request_params.Add("@temp",temp);
            MesClasses.ManagerClasse.request_params.Add("@tension",tension);
            MesClasses.ManagerClasse.request_params.Add("@frequence",poul);
            MesClasses.ManagerClasse.request_params.Add("@obs",observation);
            MesClasses.ManagerClasse.request_params.Add("id",idSuivi);

            MesClasses.ManagerClasse.CRUD(queryUpdate,MesClasses.ManagerClasse.request_params);
            MessageBox.Show("Données modifiée avec succès!!");
            LoadSuivi();
            //remettre la lecture seule
            dgv_suivi.Rows[rowIndex].Cells["Temp"].ReadOnly = true;
            dgv_suivi.Rows[rowIndex].Cells["Tension"].ReadOnly = true;
            dgv_suivi.Rows[rowIndex].Cells["Pouls"].ReadOnly = true;
            dgv_suivi.Rows[rowIndex].Cells["Obs"].ReadOnly = true;

            dgv_suivi.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
        }
    }
   
}
