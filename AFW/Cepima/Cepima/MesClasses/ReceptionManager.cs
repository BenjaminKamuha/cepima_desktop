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
namespace Cepima.MesClasses
{
    class ReceptionManager
    {
        
        // Enregistrement du patient
        public static void ServiceCepima(string centre_id, string name_centre, string description)
        {
            using (MySqlConnection con = ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();
                try
                {
                    string queryService = "INSERT INTO services(id_centre,nom_service,description)VALUES(@id,@name,@desc)";
                    ManagerClasse.request_params.Clear();
                    ManagerClasse.request_params.Add("@id", centre_id);
                    ManagerClasse.request_params.Add("@name", name_centre);
                    ManagerClasse.request_params.Add("@desc", description);
                    ManagerClasse.CRUD(queryService, ManagerClasse.request_params);
                    tr.Commit();
                    MessageBox.Show("Service ajouté avec succès !!");
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Erreur d'ajout du service " + ex.Message);
                }
            }
        }

        //===============================Enregistrement du patient ===============================
        public  static void SavePatient(string numeroFiche, string nom, string postnom, string prenom, string genre, DateTime dateNaissance, string phoneNumber, string adresse,string idCentre)
        {
            using (MySqlConnection con = ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();
                try
                {
                    string queryInsertPatient = "INSERT INTO patients(numero_fiche,nom,post_nom,prenom,sexe,date_naissance,telephone,adresse,date_creation,id_centre)VALUES(@numero,@nom,@post,@prenom,@sexe,@naissance,@phone,@adresse,CURDATE(),@centre)";
                    ManagerClasse.request_params.Clear();
                    ManagerClasse.request_params.Add("@numero", numeroFiche);
                    ManagerClasse.request_params.Add("@nom", nom);
                    ManagerClasse.request_params.Add("@post", postnom);
                    ManagerClasse.request_params.Add("@prenom", prenom);
                    ManagerClasse.request_params.Add("@sexe", genre);
                    ManagerClasse.request_params.Add("@naissance", dateNaissance.ToString("yyyy-MM-dd"));
                    ManagerClasse.request_params.Add("@phone", phoneNumber);
                    ManagerClasse.request_params.Add("@adresse", adresse);
                    ManagerClasse.request_params.Add("@centre",idCentre);
                    ManagerClasse.CRUD(queryInsertPatient, ManagerClasse.request_params);
                    tr.Commit();
                    MessageBox.Show("Patient enregistré avec succès !!", "Enregistrement du patient");
                }
                catch (MySqlException ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Erreur d'ajout du patient :" + ex.Message);
                }
            }
        }

        // ==============================Enregistrer la consultation =====================================
        public static void EnregistrerConsultation(string patient_id, string centre_id, string personnel_id, string frais_consultation,string motif, string diagnostic)
        {
            using (MySqlConnection con = ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();
                try
                {
                    string queryConsultation = "INSERT INTO consultation(id_patient,id_centre,id_personnel,date_consultation,frais_consultation,motif,diagnostic)VALUES(@patient,@centre,@personnel,CURDATE(),@frais,@motif,@diagnostic)";
                    ManagerClasse.request_params.Clear();
                    ManagerClasse.request_params.Add("@patient",patient_id);
                    ManagerClasse.request_params.Add("@centre",centre_id);
                    ManagerClasse.request_params.Add("@personnel",personnel_id);
                    ManagerClasse.request_params.Add("@frais",frais_consultation);
                    ManagerClasse.request_params.Add("@motif",motif);
                    ManagerClasse.request_params.Add("@diagnostic",diagnostic);
                    ManagerClasse.CRUD(queryConsultation,ManagerClasse.request_params);
                    tr.Commit();
                    MessageBox.Show("Consultation ajoutée avec succès !!","Consultation");
                }
                catch (MySqlException ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Erreur d'ajout de la consultation : " + ex.Message);
                }
            }
        }

        //================================ Save signes vitaux =======================================================
        public static void SaveSigneVitaux(string patient_id,decimal temperature,string tension,string frequence,decimal poids,decimal taille)
        {
            using (MySqlConnection con = ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();
                try
                {
                    string query = "INSERT INTO signes_vitaux(id_patient,temperature,tension,frequence_cardiaque,poids,taille,date_prise)VALUES(@patient,@temp,@tension,@frequency,@poids,@taille,CURDATE())";
                    ManagerClasse.request_params.Clear();
                    ManagerClasse.request_params.Add("@patient", patient_id);
                    ManagerClasse.request_params.Add("@temp", temperature.ToString());
                    ManagerClasse.request_params.Add("@tension", tension);
                    ManagerClasse.request_params.Add("@frequency", frequence.ToString());
                    ManagerClasse.request_params.Add("@poids", poids.ToString());
                    ManagerClasse.request_params.Add("@taille", taille.ToString());
                    ManagerClasse.CRUD(query,ManagerClasse.request_params);
                    tr.Commit();
                    MessageBox.Show("Les signes vitaux ont été ajoutés","Enregistrement");
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Erreur d'ajout des signes vitaux : "+ex.Message);
                }
               
            }
        }

        // ======================================= move the label =================================
        public static void MoveLabel(Label lbMove, Panel panelMove,int vitesse = 2)
        {
            Timer existingTimer = lbMove.Tag as Timer;
            if (existingTimer != null)
            {
                existingTimer.Stop();
            }

            Timer timer = new Timer();
            timer.Interval = 30;

            timer.Tick += (s, e) =>
            {
                lbMove.Left -= vitesse;

                if (lbMove.Right < 0)
                {
                    lbMove.Left = panelMove.Width;
                }
            };
            lbMove.Tag = timer;
            timer.Start();
        }

        // Charger les services dans le datagaridview
        public static void ChargerServicesInDatagridview(DataGridView dgv)
        { 
            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    string query = "SELECT s.id_service,s.nom_service AS Service,c.nom_centre AS Centre FROM services s JOIN centres c ON s.id_centre = c.id_centre";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                    dgv.Columns["id_service"].Visible = false;
                    //Ajuster les cellules par rapport aux données
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 123, 229);  //7, 51, 131
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(247, 252, 250);
                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Bold);
                    dgv.DefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur de chargement de données : "+ex.Message);
            }
        }

        // ======================= modifier un service =========================================
        public static void UpdateService(int id_service, string service)
        {
            string queryUpdate = "UPDATE services SET nom_service =@name WHERE id_service =@id";
            MesClasses.ManagerClasse.request_params.Clear();
            MesClasses.ManagerClasse.request_params.Add("@name",service);
            MesClasses.ManagerClasse.request_params.Add("@id",id_service.ToString());
            MesClasses.ManagerClasse.CRUD(queryUpdate,MesClasses.ManagerClasse.request_params);
            MessageBox.Show("Modification réussie !!");

        }

        // ======================== supprimer un service =========================================
        public static void DeleteService(int id_service)
        {
            string queryDelete = "DELETE FROM services WHERE id_service =@id";
            MesClasses.ManagerClasse.request_params.Clear();
            MesClasses.ManagerClasse.request_params.Add("@id",id_service.ToString());
            MesClasses.ManagerClasse.CRUD(queryDelete,MesClasses.ManagerClasse.request_params);
            MessageBox.Show("Service supprimé avc succès !!");
        }

        // ============================================= Ajouter une consultation =======================
        public static void SaveConsultation(int id_patient, int id_centre, int id_personnel, string motif, string diagnostic)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string queryInsert = "INSERT INTO consultation(id_patient,id_centre,id_personnel,date_consultation,motif,diagnostic)VALUES(@patient,@centre,@personnel,CURDATE(),@motif,@diagnostic)";
                using (MySqlCommand cmd = new MySqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@patient",id_patient);
                    cmd.Parameters.AddWithValue("@centre",id_centre);
                    cmd.Parameters.AddWithValue("@personnel",id_personnel);
                    cmd.Parameters.AddWithValue("@motif",motif);
                    cmd.Parameters.AddWithValue("@diagnostic",diagnostic);
                }
                MessageBox.Show("Consultation crée avec succès !!");
            }
        }

        private static void InitialiserDetailFacture(int idFacture,MySqlConnection con, MySqlTransaction tr)
        {
            string[] prestations = 
            {"Consultation","Médicaments","EEG","Laboratoire","Hospitalisation","Nursing","Séance psychosociale","Imprimés","Autres"};

            foreach (string p in prestations)
            {
                string query = "INSERT INTO detail_facture(id_facture,description,quantite,prix_unitaire,montant)VALUES(@facture,@description,@qte,@prix,@montant)";

                using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
                {
                    cmd.Parameters.AddWithValue("@facture", idFacture);
                    cmd.Parameters.AddWithValue("@description", p);
                    cmd.Parameters.AddWithValue("@qte",DBNull.Value);
                    cmd.Parameters.AddWithValue("@prix",DBNull.Value);
                    cmd.Parameters.AddWithValue("@montant",DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // ================================== mettre en jour la prestation (consultationn,EEG,Laboratoire,Hospitalisation ============
        public static void MettreAJourPrestation(int idFacture, string description, int? quantite, decimal? prixUnitaire, decimal? montant, MySqlConnection con, MySqlTransaction tr)
        {

            string query = @"UPDATE detail_facture SET quantite = @qte,prix_unitaire = @prix,montant = @montant WHERE id_facture = @facture AND description = @description";
            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@facture", idFacture);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@qte", quantite.HasValue ? (object)quantite.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@prix", prixUnitaire.HasValue ? (object)prixUnitaire.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@montant", montant.HasValue ? (object)montant.Value : DBNull.Value);
                cmd.ExecuteNonQuery();

                RecalculerFacture(idFacture, con, tr);
            }
        }

        // ==================================== recalculer le montant ========================================================
        private  static void RecalculerFacture(int idFacture,MySqlConnection con,MySqlTransaction tr)
        {
            decimal total = 0;

            string query = @"SELECT IFNULL(SUM(montant),0) FROM detail_facture WHERE id_facture=@id";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@id", idFacture);

                total = Convert.ToDecimal(cmd.ExecuteScalar());
            }

            query = "UPDATE facture SET montant_total=@total WHERE id_facture=@id";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@id", idFacture);

                cmd.ExecuteNonQuery();
            }
        }
        // ================================== creer une facture s'il n'existe pas =============================================
        public static int CreerFactureSiInexistante(int idConsultation,int idPatient,string typeFacture,MySqlConnection con,MySqlTransaction tr)
        {
            // Vérifier si la facture existe déjà
            string query = "SELECT id_facture FROM facture WHERE id_consultation=@id";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@id", idConsultation);

                object result = cmd.ExecuteScalar();

                if (result != null)
                    return Convert.ToInt32(result);
            }

            //================ Création =================

            int idFacture = 0;

            string insert = "INSERT INTO facture(id_patient,id_consultation,id_centre,type_facture,date_facture,montant_total,statut)VALUES(@patient,@consultation,@centre,@type,CURDATE(),0,'Non payé')";
            using (MySqlCommand cmd = new MySqlCommand(insert, con, tr))
            {
                cmd.Parameters.AddWithValue("@patient", idPatient);
                cmd.Parameters.AddWithValue("@consultation", idConsultation);
                cmd.Parameters.AddWithValue("@centre", MesForms.SessionUtilisateur.idCentre);
                cmd.Parameters.AddWithValue("@type", typeFacture);

                cmd.ExecuteNonQuery();

                idFacture = Convert.ToInt32(cmd.LastInsertedId);
            }

            InitialiserDetailFacture(idFacture, con, tr);

            return idFacture;
        }

    }
    class Event
    {
        public static void SaveHistorique(string idHospitalisation, string evenement)
        {
            string query = "INSERT INTO historique_sejour(id_hospitalisation,evenement,date_evenement)VALUES(@id,@ev,NOW())";
            MesClasses.ManagerClasse.request_params.Clear();
            MesClasses.ManagerClasse.request_params.Add("@id", idHospitalisation);
            MesClasses.ManagerClasse.request_params.Add("@ev", evenement);
            MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params);
        }
    }
}
