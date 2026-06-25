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
        public User_consultation()
        {
            InitializeComponent();
            LoadDataPersonnelPatient();
            LoadPatient();
            LoadServices();
            rb_attente.Checked = true;
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

            //=========================================== save hospitalisation ===========================
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
                
                MessageBox.Show("Hospitalisaton enregistré.\nChoisissez la suite");
            }

            else
            {
                MessageBox.Show("Sélectionnez un type de patient");
            }

            if (rb_eeg.Checked)
            {
                int idConsultation = RecupererIdConsultation();
                SaveEEG(idConsultation, idPatient);
                MessageBox.Show("Demande EEG envoyée avec succès");
                LoadPatient();
                return;
            }
            else
            {
                //======================= PASSER DIRECTEMENT A LA PRESCRIPTION DES MEDICAMENTS ========================
                User_prescription presc = new User_prescription(idPatient);
                presc.Dock = DockStyle.Fill;
                Form1.GlobalPanel_main.Controls.Clear();
                Form1.GlobalPanel_main.Controls.Add(presc);
            }
        }

        private void LoadPatient()
        {
            fl_patient.Controls.Clear();

            try
            {
                string query = "";

                // ================= PATIENTS EN ATTENTE =================
                if (filtrePatient == "En attente")
                {
                    query ="SELECT DISTINCT p.id_patient,p.nom,p.post_nom FROM signes_vitaux s JOIN patients p ON p.id_patient=s.id_patient WHERE s.is_counsel=0";
                }

                // ================= EEG TERMINE =================
                else
                {
                    query = "SELECT DISTINCT p.id_patient,p.nom,p.post_nom FROM examens_eeg e JOIN patients p ON p.id_patient=e.id_patient WHERE e.statut='Terminé'";
                }

                // ================= RECHERCHE =================

                if (!string.IsNullOrWhiteSpace(tb_search.Text))
                {
                    query +=" AND(p.nom LIKE @rech OR p.post_nom LIKE @rech)";
                }

                query += " ORDER BY p.nom ASC";

                MySqlCommand cmd = new MySqlCommand(query,MesClasses.ManagerClasse.GetConnexion());

                if (!string.IsNullOrWhiteSpace(tb_search.Text))
                {
                    cmd.Parameters.AddWithValue("@rech","%" +tb_search.Text +"%");
                }

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AjouterPanel(

                        reader["id_patient"].ToString(),
                        reader["nom"].ToString(),
                        reader["post_nom"].ToString(),
                        filtrePatient
                        );
                    }

                    reader.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AjouterPanel(string id, string nom, string postNom,string statut)
        {
            Panel panelPatient = new Panel
            {
                Size = new Size(240, 60),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
            };

            PictureBox picture = new PictureBox
            {
                Location = new Point(10, 2),
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

            Label lbStatut = MesClasses.ManagerClasse.CustomLabel("Statut : "+statut,new Point(50,40));
            lbStatut.AutoSize = true;
            lbStatut.Font = new System.Drawing.Font("Calibri",9);
            panelPatient.Controls.Add(chk);
            panelPatient.Controls.Add(lbStatut);
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
                if (filtrePatient == "EEG")
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

                    MessageBox.Show("Examen EEG ajouté !!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur d'enregistrement : " + ex.Message);
                }
            }
        }

        private void bt_continue_Click(object sender, EventArgs e)
        {
            MesUserCases.User_prescription presc = new User_prescription(idPatient);
            presc.Dock = DockStyle.Fill;
            Form1.GlobalPanel_main.Controls.Clear();
            Form1.GlobalPanel_main.Controls.Add(presc);
        }

        //
    }
}
