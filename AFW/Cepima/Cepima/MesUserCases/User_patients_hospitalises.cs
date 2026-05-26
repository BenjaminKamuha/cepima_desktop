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
        public User_patients_hospitalises()
        {
            InitializeComponent();
            ChargerPatientsHospitalises();
            ChargerInfosPatient("1");
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
                        string query = "SELECT h.id_hospitalisation,p.id_patient,CONCAT(p.nom,' ',p.post_nom) AS Patient,h.date_entree FROM hospitalisation h INNER JOIN patients p ON h.id_patient = p.id_patient WHERE CONCAT(p.nom,' ',p.post_nom) LIKE @search";
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
                                //création des panel dynamiquement
                                Panel p = new Panel();
                                p.Size = new Size(190, 70);
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
                        lb_chambre_actuelle.Text = "Chambre n°:" + reader["numero_chambre"];
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
                string query = "SELECT pr.id_prescription,DATE(pr.date_prescription) AS datePrescription,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS medecin FROM prescriptions pr INNER JOIN consultation c ON pr.id_consultation=c.id_consultation INNER JOIN personnels p ON c.id_personnel=p.id_personnel WHERE pr.id_patient =@id ORDER BY pr.id_prescription DESC LIMIT 1";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",patient_id);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                {
                    if (reader.Read())
                    {
                        lb_id_prescription.Text = "Préscription n°: " + reader["id_prescription"];
                        lb_date_prescription.Text = Convert.ToDateTime(reader["date_prescription"]).ToString("dd/MM/yyyy");
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
        private void LoadSuivi()
        {
            dgv_suivi.Rows.Clear();
            try
            {
                string query = "SELECT id_suivi,temperature,tension,rythme_cardiaque,observation,date_suivi FROM suivi_hospitalisation WHERE id_hospitalisation =@id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",hospitalisationID);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int row = dgv_suivi.Rows.Add();
                            dgv_suivi.Rows[row].Cells["Date"].Value = Convert.ToDateTime(reader["date_suivi"]).ToString("dd/MM/yyyy HH:mm");
                            dgv_suivi.Rows[row].Cells["Temp(°c)"].Value = reader["temperature"]+" °C";
                            dgv_suivi.Rows[row].Cells["Tension"].Value = reader["tension"];
                            dgv_suivi.Rows[row].Cells["Pouls"].Value = reader["rythme_cardiaque"];
                            dgv_suivi.Rows[row].Cells["Observation"].Value = reader["observation"]; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : "+ex.Message);
            }
        }

        // ============================== Charger les evenements dans le datagridview ======================================================
        private void LoadHistorique()
        {
            dgv_historique.Rows.Clear();

            try
            {
                string query ="SELECT id_historique,evenement,date_evenement FROM historique_sejour WHERE id_hospitalisation=@id ORDER BYdate_evenement DESC";
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
                            // coloration automatique

                            string evenement = reader["evenement"].ToString();

                            if (evenement.Contains("Prescription"))
                            {
                                dgv_historique.Rows[row].DefaultCellStyle.BackColor = Color.LightBlue;
                            }

                            else if (evenement.Contains("Hospitalisé"))
                            {
                                dgv_historique.Rows[row].DefaultCellStyle.BackColor = Color.LightGreen;
                            }

                            else if (evenement.Contains("Suivi"))
                            {
                                dgv_historique.Rows[row].DefaultCellStyle.BackColor = Color.LightYellow;
                            }

                            else if (evenement.Contains("sorti"))
                            {
                                dgv_historique.Rows[row].DefaultCellStyle.BackColor = Color.LightPink;
                            }
                        }
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
            DialogResult rep = MessageBox.Show("Confirmer la sortie du patient ?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (rep != DialogResult.Yes)
                return;
            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {

                    // ========= changer état hospitalisation

                    string queryHosp = @"UPDATE hospitalisation SET etat='Sorti',date_sortie=NOW() WHERE id_hospitalisation=@id";
                    MySqlCommand cmd1 = new MySqlCommand(queryHosp,con);
                    cmd1.Parameters.AddWithValue("@id",hospitalisationID);
                    cmd1.ExecuteNonQuery();

                    // ======================== récupérer chambre actuelle =============================================

                    string chambreID = "";

                    string querySelect = "SELECT id_chambre FROM affectation_chambre WHERE id_hospitalisation=@id ORDER BY id_affectation DESC LIMIT 1";
                    MySqlCommand cmd2 = new MySqlCommand(querySelect,con);

                    cmd2.Parameters.AddWithValue("@id",hospitalisationID);
                    object result = cmd2.ExecuteScalar();

                    if (result != null)
                    {
                        chambreID =result.ToString();
                    }

                    // ==================== libérer la chambre ============================================================

                    if (chambreID != "")
                    {
                        string queryChambre ="UPDATE chambre SET statut='Disponible'WHERE id_chambre=@id";

                        MySqlCommand cmd3 = new MySqlCommand(queryChambre,con);
                        cmd3.Parameters.AddWithValue("@id",chambreID);
                        cmd3.ExecuteNonQuery();
                    }

                    // ================================== mettre a jour la date fin dans affectation ========================
                    string queryAf = "UPDATE affectation_chambre SET date_fin = NOW() WHERE id_hospitalisation =@id AND date_fin IS NULL";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@id",hospitalisationID);
                    MesClasses.ManagerClasse.CRUD(queryAf,MesClasses.ManagerClasse.request_params);
                    MesClasses.Event.SaveHistorique(hospitalisationID, "Patient sorti");
                    MessageBox.Show( "Sortie enregistrée");
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
    }
   
}
