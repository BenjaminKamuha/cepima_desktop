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
    public partial class User_affectation : UserControl
    {
        string idChambre, hospitalisationID,numeroChambre;
        public User_affectation()
        {
            InitializeComponent();
            ChargerPatientsHospitalises();
            LoadTypeChambre();
            LoadChambres();
            //ChargerInfosPatient();
        }

        // =========================== charger les patients hospitalisés ===============================================
        private void ChargerPatientsHospitalises(params string[] args)
        {
            flowLayoutPanel1.Controls.Clear();
            if (args.Length != 0)
            {
                try
                {
                    using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                    {
                        string query = "SELECT h.id_hospitalisation,p.id_patient,CONCAT(p.nom,' ',p.post_nom) AS Patient,h.date_entree FROM hospitalisation h INNER JOIN patients p ON h.id_patient = p.id_patient WHERE CONCAT(p.nom,' ',p.post_nom) LIKE @search AND h.date_sortie IS NULL";
                        MesClasses.ManagerClasse.request_params.Clear();
                        MesClasses.ManagerClasse.request_params.Add("@search", "%" + args[0] + "%");
                        MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true);
                        if (reader.HasRows)
                        {
                            int i = 0;
                            while (reader.Read())
                            {
                                string idHospitalisation = reader["id_hospitalisation"].ToString();
                                string patient = reader["Patient"].ToString();
                                string date = reader["date_entree"].ToString();
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
                        string query = "SELECT h.id_hospitalisation,p.id_patient,CONCAT(p.nom,' ',p.post_nom) AS Patient,h.date_entree FROM hospitalisation h INNER JOIN patients p ON h.id_patient = p.id_patient WHERE h.date_sortie IS NULL";
                        using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                        {
                            if (reader.HasRows)
                            {
                                int i = 0;
                                while (reader.Read())
                                {
                                    string idHospitalisation = reader["id_hospitalisation"].ToString();
                                    string patient = reader["Patient"].ToString();
                                    string date = Convert.ToDateTime(reader["date_entree"]).ToString("dd/MM/yyyy");
                                    //création des panel dynamiquement
                                    Panel p = new Panel();
                                    p.Size = new Size(180, 70);
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
                                    lb.Location = new Point(50,20);
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
        // ============================ Charger les informations personnels du patient===================================
        private void ChargerInfosPatient(string idHospitalisation)
        {
            try
            {
                string query = "SELECT p.nom,p.post_nom,p.prenom,p.sexe,p.telephone,p.adresse,p.numero_fiche,h.date_entree,h.motif,h.etat FROM patients p INNER JOIN hospitalisation h ON p.id_patient=h.id_patient WHERE h.id_hospitalisation=@id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",idHospitalisation);

                using (MySqlDataReader reader =
                MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
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
                MessageBox.Show("Erreur : "+ ex.Message);
            }
        }
        // =================== charger d'abord les type de chambre disponible ===========================================
        private void LoadTypeChambre()
        {
            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    string query = "SHOW COLUMNS FROM chambre LIKE 'type_chambre'";

                    MySqlCommand cmd = new MySqlCommand(query, con);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string typeEnum = reader["Type"].ToString();

                        // enlève enum(...)
                        typeEnum = typeEnum.Replace("enum(", "");

                        typeEnum = typeEnum.Replace(")", "");

                        typeEnum = typeEnum.Replace("'", "");

                        string[] types = typeEnum.Split(',');

                        cbx_type_chambre.Items.Clear();

                        cbx_type_chambre.Items.Add("Tous");

                        cbx_type_chambre.Items.AddRange(types);

                        cbx_type_chambre.SelectedIndex = 0;
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ============================ charger les chambres avec leurs informations ===================================
        private void LoadChambres(params string[] args)
        {
            panel_display_chambre.Controls.Clear();

            try
            {
                string query = "";

                MesClasses.ManagerClasse.request_params.Clear();

                // Si un type est sélectionné
                if (args.Length > 0)
                {
                    query = "SELECT c.id_chambre,c.numero_chambre,c.type_chambre,c.tarif_journalier,c.statut,s.nom_service FROM chambre c JOIN services s ON c.id_service=s.id_service WHERE c.type_chambre=@type ORDER BY c.numero_chambre ASC";
                    MesClasses.ManagerClasse.request_params.Add("@type", args[0]);
                }
                else
                {
                    query = "SELECT c.id_chambre,c.numero_chambre,c.type_chambre,c.tarif_journalier,c.statut,s.nom_service FROM chambre c JOIN services s ON c.id_service=s.id_service ORDER BY c.numero_chambre ASC";
                }

                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                {
                    if (reader.HasRows)
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            string id_chambre = reader["id_chambre"].ToString();
                            string numero_chambre = reader["numero_chambre"].ToString();
                            //numeroChambre = reader["numero_chambre"].ToString();
                            string type_chambre = reader["type_chambre"].ToString();
                            string tarif = reader["tarif_journalier"].ToString();
                            string statut = reader["statut"].ToString();
                            string service = reader["nom_service"].ToString();
                            CustomRoundedPanel panPatient = new CustomRoundedPanel();
                            panPatient.Size = new Size(188, 190);
                            panPatient.BorderRadius = 10;
                            panPatient.BorderSize = 1;
                            panPatient.BorderColor = Color.FromArgb(224,224,224);
                            panPatient.HoverCursor = Cursors.Default;

                            RoundedButton bt_details = MesClasses.ManagerClasse.Rbutton("Choisir chambre", new Point(30, 165), new Size(120, 20), Color.FromArgb(39, 174, 96), Color.White);
                            bt_details.BorderRadius = 4;
                            bt_details.BorderSize = 0;
                            bt_details.BorderColor = Color.FromArgb(39, 174, 96);
                            bt_details.Tag = id_chambre;

                            bt_details.Click += (s, e) =>
                            {
                                idChambre = id_chambre;
                                tb_type_chambre.Text = "Chambre n° : " + numero_chambre;
                                tb_type_chambre.Tag = id_chambre;
                            };

                            panPatient.Controls.Add(bt_details);
                            AvatarControl avatar = new AvatarControl();
                            avatar.Location = new Point(10, 10);
                            avatar.Size = new Size(40, 40);
                            avatar.BorderSize = 1;
                            avatar.BorderColor = Color.FromArgb(39, 174, 96);
                            avatar.Avatar = Properties.Resources.hospital_bed_green;

                            if (statut == "Occupée")
                            {
                                panPatient.BackColor = Color.FromArgb(255, 230, 230);
                                panPatient.BorderColor = Color.Red;
                                bt_details.Enabled = false;
                                avatar.BorderColor = Color.Red;
                            }
                            else if (statut == "Disponible")
                            {
                                panPatient.BackColor = Color.FromArgb(245, 246, 242);
                                bt_details.Enabled = true;
                                avatar.BorderColor = Color.FromArgb(39, 174, 96);
                            }
                            
                            MesClasses.ManagerClasse.AddControl(panel_display_chambre,panPatient,8,8);

                            panPatient.Controls.Add(avatar);

                            Label lbNom = MesClasses.ManagerClasse.CustomLabel("Chambre N°: "+ numero_chambre,new Point(60, 25));

                            lbNom.AutoSize = true;
                            lbNom.Font = new Font("Calibri",10,FontStyle.Bold);
                            panPatient.Controls.Add(lbNom);

                            Label lbType = MesClasses.ManagerClasse.CustomLabel("Type : "+ type_chambre,new Point(10, 60));
                            lbType.Font = new System.Drawing.Font("Calibri",9);
                            panPatient.Controls.Add(lbType);

                            Label lbTarif = MesClasses.ManagerClasse.CustomLabel("Tarif : "+ tarif + " $/jour",new Point(10, 90));
                            lbTarif.Font = new System.Drawing.Font("Calibri", 9);
                            panPatient.Controls.Add(lbTarif);

                            Label lbStatut = MesClasses.ManagerClasse.CustomLabel("Statut : "+ statut,new Point(10, 120));
                            lbStatut.Font = new System.Drawing.Font("Calibri", 9);
                            panPatient.Controls.Add(lbStatut);

                            Label lbService = MesClasses.ManagerClasse.CustomLabel("Service : "+service,new Point(10,145));
                            lbService.Font = new System.Drawing.Font("Calibri",9);
                            lbService.AutoSize = true;
                            panPatient.Controls.Add(lbService);
                            i++;

                        }

                        reader.Close();
                        if (i > 1)
                            lb_nombre_chambre.Text = i.ToString() + " Chambres";
                        else
                            lb_nombre_chambre.Text = i.ToString() + " Chambre";
                        ProgressiveDisplay pd = new ProgressiveDisplay(panel_display_chambre,100);
                        pd.Start();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur : "+ ex.Message);
            }
        }

        private void cbx_type_chambre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_type_chambre.Text == "Tous")
            {
                LoadChambres();
            }
            else
            {
                LoadChambres(cbx_type_chambre.Text);
            }
        }

        private void bt_add_affectation_Click(object sender, EventArgs e)
        {
           SaveAffectation_chambre();
        }

        // ======================= enregistrer l'affectation de la chambre ===============================================
        private void SaveAffectation_chambre()
        {
            try
            {
                if (string.IsNullOrEmpty(hospitalisationID))
                {
                    MessageBox.Show("Sélectionner un patient");
                    return;
                }
                if (string.IsNullOrEmpty(idChambre))
                {
                    MessageBox.Show("Choisissez une chambre");
                    return;
                }
                string queryInsert = "INSERT INTO affectation_chambre(id_hospitalisation,id_chambre,date_debut)VALUES(@hospitalisation,@chambre,CURDATE())";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@hospitalisation", hospitalisationID);
                MesClasses.ManagerClasse.request_params.Add("@chambre", idChambre);
                //MesClasses.ManagerClasse.request_params.Add("@debut",dt_date_debut.Value.ToString());
                MesClasses.ManagerClasse.CRUD(queryInsert, MesClasses.ManagerClasse.request_params);

                // ================== la chambre devient occupé maintenant ==========================
                string queryUpdate = "UPDATE chambre SET statut = 'Occupée' WHERE id_chambre = @id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id", idChambre);
                MesClasses.ManagerClasse.CRUD(queryUpdate, MesClasses.ManagerClasse.request_params);

                // enregistrer l'historique mais avant tous récuperons le numero de la chambre du patient
                string querySelect_chambre = "SELECT h.id_hospitalisation,c.numero_chambre FROM hospitalisation h JOIN affectation_chambre ac ON h.id_hospitalisation = ac.id_hospitalisation JOIN chambre c ON ac.id_chambre = c.id_chambre WHERE h.id_hospitalisation =@id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",hospitalisationID);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(querySelect_chambre, MesClasses.ManagerClasse.request_params, true))
                {
                    if (reader.Read())
                    {
                        numeroChambre = reader["numero_chambre"].ToString();
                    }
                    reader.Close();
                }
                MesClasses.Event.SaveHistorique(hospitalisationID,"Patient affecté à la chambre "+numeroChambre);
                MessageBox.Show("Chambre affectée avec succès");
                idChambre = "";
                hospitalisationID = "";
                ChargerPatientsHospitalises();
                LoadChambres();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : "+ex.Message);
            }
           
        }
    }
}
