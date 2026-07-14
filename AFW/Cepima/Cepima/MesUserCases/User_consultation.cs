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
        string filtrePatient = "En attente";
        string type_patient = "";
        public User_consultation()
        {
            InitializeComponent();
            LoadPatient();
            LoadServices();
            rb_all.Checked = true;
        }

        // ================ Charger les patients et les personnels dans leurs comboBox respectif =============================================
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
        // récuperer l'id_hospitalisation ===========================
        private int RecupererIdHospitalisation()
        {
            int idHospitalisation = 0;

            try
            {
                string query = "SELECT id_hospitalisation FROM hospitalisation WHERE id_patient=@patient ORDER BY id_hospitalisation DESC LIMIT 1";
                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add("@patient", idPatient.ToString());
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

                MesClasses.ManagerClasse.request_params.Add("@patient", idPatient.ToString());
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

        private void LoadPatient()
        {
            fl_patient.Controls.Clear();
            lb_search.Visible = false;

            try
            {
                string query = "";

                //=================== Construction de la requête ===================

                if (filtrePatient == "En attente")
                {
                    query = "SELECT DISTINCT p.id_patient,p.nom,p.post_nom,'En attente' AS etat_patient FROM signes_vitaux s INNER JOIN patients p ON p.id_patient = s.id_patient WHERE s.is_counsel = 0";
                }

                else if (filtrePatient == "Tous")
                {
                    query = "SELECT * FROM(SELECT DISTINCT p.id_patient,p.nom,p.post_nom,'En attente' AS etat_patient FROM signes_vitaux s INNER JOIN patients p ON p.id_patient=s.id_patient WHERE s.is_counsel=0 UNION SELECT DISTINCT p.id_patient,p.nom,p.post_nom,'Hospitalisé' AS etat_patient FROM hospitalisation h INNER JOIN consultation c ON c.id_consultation=h.id_consultation INNER JOIN patients p ON p.id_patient=c.id_patient WHERE h.date_sortie IS NULL) AS listePatients";
                }
                else if(filtrePatient == "Hospitalisé")
                {
                    query = "SELECT p.id_patient,p.nom,p.post_nom,h.etat AS etat_patient FROM hospitalisation h INNER JOIN patients p ON p.id_patient=h.id_patient WHERE date_sortie IS NULL";
                }
                else if (filtrePatient == "Sorti")
                {
                    query = "SELECT p.id_patient,p.nom,p.post_nom,h.etat AS etat_patient FROM hospitalisation h INNER JOIN patients p ON p.id_patient=h.id_patient WHERE h.etat = 'Sorti'";
                }
                else // EEG terminé
                {
                    query = "SELECT DISTINCT p.id_patient,p.nom,p.post_nom,'EEG Terminé' AS etat_patient FROM examens_eeg e INNER JOIN patients p ON p.id_patient=e.id_patient WHERE e.statut='Terminé'";
                }

                //=================== Recherche ===================

                if (!string.IsNullOrWhiteSpace(tb_search.Text))
                {
                    if (filtrePatient == "Tous")
                    {
                        query += " WHERE nom LIKE @rech OR post_nom LIKE @rech";
                    }
                    else
                    {
                        query += " AND (p.nom LIKE @rech OR p.post_nom LIKE @rech)";
                    }
                }

                //=================== Tri ===================

                query += " ORDER BY nom ASC";

                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        if (!string.IsNullOrWhiteSpace(tb_search.Text))
                        {
                            cmd.Parameters.AddWithValue("@rech", "%" + tb_search.Text.Trim() + "%");
                        }

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    AjouterPanel(
                                        reader["id_patient"].ToString(),
                                        reader["nom"].ToString(),
                                        reader["post_nom"].ToString(),
                                        reader["etat_patient"].ToString());
                                }

                                reader.Close();
                            }
                            else
                            {
                          
                                if (!string.IsNullOrWhiteSpace(tb_search.Text))
                                {
                                    lb_search.Text = "Aucun patient trouvé pour \""+tb_search.Text +"\"";
                                }
                                else
                                {
                                    lb_search.Text = "Aucun patient disponible.";
                                }
                                lb_search.Visible = true;
                                fl_patient.Controls.Add(lb_search);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
        private void AjouterPanel(string id, string nom, string postNom,string etat)
        {
            Panel panelPatient = new Panel
            {
                Size = new Size(240, 60),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
            };

            PictureBox picture = new PictureBox
            {
                Location = new Point(10, 10),
                Size = new Size(35, 35),
                Image = Properties.Resources.round_user,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            panelPatient.Controls.Add(picture);

            Label labelNom = new Label
            {
                Text = nom + " " + postNom,
                Location = new Point(50, 15),
                AutoSize = true,
                Font = new Font("Calibri", 10)
            };

            panelPatient.Controls.Add(labelNom);

            CheckBox chk = new CheckBox
            {
                Tag = id,
                AutoSize = true,
                Location = new Point(220, 40)
            };

            chk.CheckedChanged += chkClient_CheckedChanged;
            Label lbStatut = MesClasses.ManagerClasse.CustomLabel("Statut : " + etat, new Point(50, 30));
            lbStatut.AutoSize = true;
            lbStatut.Font = new System.Drawing.Font("Calibri", 9);
            panelPatient.Controls.Add(chk);
            panelPatient.Controls.Add(lbStatut);

            if (etat == "Hospitalisé")
            {
                lbStatut.ForeColor = Color.Red;
            }
            else
            {
                lbStatut.ForeColor = Color.DarkOrange;
            }
            fl_patient.Controls.Add(panelPatient);
        }
        public static int idPatient;
        
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

                //===================================== si EEG terminé =========================
                if (filtrePatient == "EEG" || filtrePatient == "Tous")
                {
                    bt_continue.Visible = true;
                }
            }
            else
            {
                bt_continue.Visible = false;
                idPatient = 0;
            }
        }
  
        private void rb_ambulatoire_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_ambulatoire.Checked)
            {
                pan_test.Visible = false;
                type_patient = "Ambulatoire";
            }
        }

        private void rb_hospitalisation_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_hospitalisation.Checked)
            {
                pan_test.Visible = true;
                type_patient = "Hospitalisé";
            }
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

        private void rb_eeg_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_eeg.Checked)
            {
                MessageBox.Show("Une demande EEG sera creé après la consultation");
            }
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            LoadPatient();
        }

        private void rb_attente_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_attente.Checked)
            {
                filtrePatient = "En attente";
                LoadPatient();
                bt_continue.Visible = false;
            }
        }

        private void rb_eeg_termine_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_eeg_termine.Checked)
            {
                filtrePatient = "EEG";
                LoadPatient();
            }
        }
        //======================================= SAVE EEG =========================================
        private void SaveEEG(int idConsultation, int id_patient)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string queryInsert = "INSERT INTO examens_eeg(id_patient,id_consultation,date_examen)VALUES(@patient,@consultation,CURDATE())";
                    using (MySqlCommand cmdInsert = new MySqlCommand(queryInsert, con))
                    {
                        cmdInsert.Parameters.AddWithValue("@patient", id_patient);
                        cmdInsert.Parameters.AddWithValue("@consultation", idConsultation);
                        cmdInsert.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur d'enregistrement : " + ex.Message);
                }
            }
        }

        private void bt_continue_Click(object sender, EventArgs e)
        {
            MesUserCases.User_prescription presc = new User_prescription(idPatient,type_patient);
            presc.Dock = DockStyle.Fill;
            Form1.GlobalPanel_main.Controls.Clear();
            Form1.GlobalPanel_main.Controls.Add(presc);
        }

        private void rb_all_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_all.Checked)
            {
                filtrePatient = "Tous";
                LoadPatient();
            }
        }

        // ====================================== ENREGISTRER LA CONSULTATION  =========================================
        private void bt_save_consultation_Click(object sender, EventArgs e)
        {
            //================ Vérification =================
            if (!rb_ambulatoire.Checked && !rb_hospitalisation.Checked)
            {
                MessageBox.Show("Vous devez sélectionner le type de patient.");
                return;
            }

            string motif = tb_motif.Text.Trim();
            string description = rich_description.Text.Trim();
            string frais = tb_montant_consultation.Text;
            //================ Enregistrement consultation =================
            MesClasses.ReceptionManager.EnregistrerConsultation(
                idPatient.ToString(),
                MesForms.SessionUtilisateur.idCentre.ToString(),
                MesForms.SessionUtilisateur.idUser.ToString(),
                frais,
                motif,
                description);

            int idConsultation = RecupererIdConsultation();

            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();

                try
                {
                    int idFacture = MesClasses.ReceptionManager.CreerFactureSiInexistante(idConsultation,idPatient,type_patient,con,tr);

                    decimal montantConsultation = Convert.ToDecimal(tb_montant_consultation.Text);

                    MesClasses.ReceptionManager.MettreAJourPrestation(idFacture, "Consultation", 1, montantConsultation, montantConsultation, con, tr);

                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }

            //================ Hospitalisation =================
            if (rb_hospitalisation.Checked)
            {
                // ========================== VERIFIER SI LE PATIENT EST DEJA HOSPITALISE ==========================
                if (PatientEstHospitalise(idPatient))
                {
                    MessageBox.Show("Ce patient est déjà hospitalisé");
                    return;
                }
                SaveHospitalisation(idConsultation);
                MessageBox.Show("Hospitalisation enregistrée.");
            }

            //================ Mise à jour signes vitaux =================
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string query = "UPDATE signes_vitaux SET is_counsel = 1 WHERE id_patient=@id";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", idPatient);
                    cmd.ExecuteNonQuery();
                }
            }

            //================ Nettoyage =================
            tb_motif.Clear();
            rich_description.Clear();

            //================ EEG demandé ? =================
            if (rb_eeg.Checked)
            {
                SaveEEG(idConsultation, idPatient);

                MessageBox.Show("Demande EEG envoyée avec succès.");

                LoadPatient();

                return;
            }

            //================ Prescription =================
            User_prescription presc = new User_prescription(idPatient,type_patient);
            presc.Dock = DockStyle.Fill;
            Form1.GlobalPanel_main.Controls.Clear();
            Form1.GlobalPanel_main.Controls.Add(presc);
        }

        private void rb_patient_hospitalisé_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_patient_hospitalisé.Checked)
            {
                filtrePatient = "Hospitalisé";
                LoadPatient();
            }
        }

        private void rb_patient_sortie_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_patient_sortie.Checked)
            {
                filtrePatient = "Sorti";
                LoadPatient();
            }
        }
        // =================================== vérifier si le patient est deja hospitalisé ==================================
        private bool PatientEstHospitalise(int idPatient)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string query = "SELECT COUNT(*) FROM hospitalisation WHERE id_patient = @id AND date_sortie IS NULL";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", idPatient);

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }
    }
}
