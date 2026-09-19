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

        // fonction de calcul de l'age
        public static int CalculerAge(DateTime dateNaissence)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - dateNaissence.Year;

            if (dateNaissence.Date > now.AddYears(-age))
            {
                age--;
            }
            return age;

        }
        //===============================Enregistrement du patient ===============================
        public static void SavePatient(string numeroFiche, string nom, string postnom, string prenom, string genre, DateTime dateNaissance, string phoneNumber, string adresse, string idCentre)
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
                    ManagerClasse.request_params.Add("@centre", idCentre);
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
        public static void EnregistrerConsultation(string patient_id, string centre_id, string personnel_id, string frais_consultation, string motif, string diagnostic)
        {
            using (MySqlConnection con = ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();
                try
                {
                    string queryConsultation = "INSERT INTO consultation(id_patient,id_centre,id_personnel,date_consultation,frais_consultation,motif,diagnostic)VALUES(@patient,@centre,@personnel,CURDATE(),@frais,@motif,@diagnostic)";
                    ManagerClasse.request_params.Clear();
                    ManagerClasse.request_params.Add("@patient", patient_id);
                    ManagerClasse.request_params.Add("@centre", centre_id);
                    ManagerClasse.request_params.Add("@personnel", personnel_id);
                    ManagerClasse.request_params.Add("@frais", frais_consultation);
                    ManagerClasse.request_params.Add("@motif", motif);
                    ManagerClasse.request_params.Add("@diagnostic", diagnostic);
                    ManagerClasse.CRUD(queryConsultation, ManagerClasse.request_params);
                    tr.Commit();
                    MessageBox.Show("Consultation ajoutée avec succès !!", "Consultation");
                }
                catch (MySqlException ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Erreur d'ajout de la consultation : " + ex.Message);
                }
            }
        }

        //================================ Save signes vitaux =======================================================
        public static void SaveSigneVitaux(string patient_id, decimal temperature, string tension, string frequence, decimal poids, decimal taille)
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
                    ManagerClasse.CRUD(query, ManagerClasse.request_params);

                    // Initialisation facture
                    CreerFactureSiInexistante(patient_id, con, tr);

                    tr.Commit();

                    DialogResult result = MessageBox.Show(
                       "Les signes vitaux ont été ajoutés; Voulez-vous recommander un service à ce patient ?", "Enregistrement.",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        Form1.PATIENT_ID = Convert.ToInt32(patient_id);
                        MesForms.Form_demander_service frm_service = new MesForms.Form_demander_service();
                        frm_service.ShowDialog();
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Erreur d'ajout des signes vitaux : " + ex.Message);
                }

            }
        }

        // ======================================= move the label =================================
        public static void MoveLabel(Label lbMove, Panel panelMove, int vitesse = 2)
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
                MessageBox.Show("Erreur de chargement de données : " + ex.Message);
            }
        }

        // ======================= modifier un service =========================================
        public static void UpdateService(int id_service, string service)
        {
            string queryUpdate = "UPDATE services SET nom_service =@name WHERE id_service =@id";
            MesClasses.ManagerClasse.request_params.Clear();
            MesClasses.ManagerClasse.request_params.Add("@name", service);
            MesClasses.ManagerClasse.request_params.Add("@id", id_service.ToString());
            MesClasses.ManagerClasse.CRUD(queryUpdate, MesClasses.ManagerClasse.request_params);
            MessageBox.Show("Modification réussie !!");

        }

        // ======================== supprimer un service =========================================
        public static void DeleteService(int id_service)
        {
            string queryDelete = "DELETE FROM services WHERE id_service =@id";
            MesClasses.ManagerClasse.request_params.Clear();
            MesClasses.ManagerClasse.request_params.Add("@id", id_service.ToString());
            MesClasses.ManagerClasse.CRUD(queryDelete, MesClasses.ManagerClasse.request_params);
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
                    cmd.Parameters.AddWithValue("@patient", id_patient);
                    cmd.Parameters.AddWithValue("@centre", id_centre);
                    cmd.Parameters.AddWithValue("@personnel", id_personnel);
                    cmd.Parameters.AddWithValue("@motif", motif);
                    cmd.Parameters.AddWithValue("@diagnostic", diagnostic);
                }

                MessageBox.Show("Consultation crée avec succès !!");
            }
        }

        // ============================================================
        // RECUPERER LE TARIF ACTIF D'UNE PRESTATION
        // ============================================================
        public static decimal ObtenirTarifActif(
            int idPrestation,
            DateTime date,
            MySqlConnection con,
            MySqlTransaction tr)
        {
            string query = @"
                SELECT prix
                FROM tarif_prestation
                WHERE id_prestation = @id_prestation
                  AND actif = 1
                  AND date_debut <= @date
                  AND (date_fin IS NULL OR date_fin >= @date)
                ORDER BY date_debut DESC, id_tarif DESC
                LIMIT 1";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@id_prestation", idPrestation);
                cmd.Parameters.AddWithValue("@date", date.Date);

                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    throw new Exception("Aucun tarif actif n'est défini pour cette prestation.");

                return Convert.ToDecimal(result);
            }
        }

        // ============================================================
        // AJOUTER UNE PRESTATION A LA FACTURE
        // ============================================================
        public static int AjouterPrestationFacture(
            int idFacture,
            int idPrestation,
            int quantite,
            decimal prixUnitaire,
            MySqlConnection con,
            MySqlTransaction tr)
        {
            if (idFacture <= 0)
                throw new Exception("Facture invalide.");
            if (idPrestation <= 0)
                throw new Exception("Prestation invalide.");
            if (quantite <= 0)
                throw new Exception("La quantité doit être supérieure à zéro.");
            if (prixUnitaire <= 0)
                throw new Exception("Le prix de la prestation est invalide.");

            string query = @"
                SELECT libelle
                FROM prestation
                WHERE id_prestation = @id_prestation
                  AND actif = 1
                LIMIT 1";

            string libelle;
            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@id_prestation", idPrestation);
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    throw new Exception("La prestation n'existe pas ou est inactive.");
                libelle = result.ToString();
            }

            int existant = TrouverDetailPrestation(idFacture, idPrestation, con, tr);
            if (existant > 0)
                return existant;

            decimal montant = quantite * prixUnitaire;

            query = @"
                INSERT INTO detail_facture
                (
                    id_facture,
                    id_prestation,
                    description,
                    quantite,
                    prix_unitaire,
                    montant
                )
                VALUES
                (
                    @id_facture,
                    @id_prestation,
                    @description,
                    @quantite,
                    @prix_unitaire,
                    @montant
                )";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@id_facture", idFacture);
                cmd.Parameters.AddWithValue("@id_prestation", idPrestation);
                cmd.Parameters.AddWithValue("@description", libelle);
                cmd.Parameters.AddWithValue("@quantite", quantite);
                cmd.Parameters.AddWithValue("@prix_unitaire", prixUnitaire);
                cmd.Parameters.AddWithValue("@montant", montant);
                cmd.ExecuteNonQuery();
                int idDetail = Convert.ToInt32(cmd.LastInsertedId);
                RecalculerFacture(idFacture, con, tr);
                return idDetail;
            }
        }

        // ============================================================
        // TROUVER UNE PRESTATION DANS UNE FACTURE
        // ============================================================
        public static int TrouverDetailPrestation(
            int idFacture,
            int idPrestation,
            MySqlConnection con,
            MySqlTransaction tr)
        {
            string query = @"
                SELECT id_detail_facture
                FROM detail_facture
                WHERE id_facture = @id_facture
                  AND id_prestation = @id_prestation
                ORDER BY id_detail_facture DESC
                LIMIT 1";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@id_facture", idFacture);
                cmd.Parameters.AddWithValue("@id_prestation", idPrestation);
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    return 0;
                return Convert.ToInt32(result);
            }
        }

        // ============================================================
        // RECUPERER LE TARIF ACTUEL
        // ============================================================
        public static decimal ObtenirTarifPrestation(
            int idPrestation,
            DateTime date,
            MySqlConnection con,
            MySqlTransaction tr)
        {
            string query = @"
                SELECT prix
                FROM tarif_prestation
                WHERE id_prestation = @id_prestation
                  AND actif = 1
                  AND date_debut <= @date
                  AND (date_fin IS NULL OR date_fin >= @date)
                ORDER BY date_debut DESC, id_tarif DESC
                LIMIT 1";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@id_prestation", idPrestation);
                cmd.Parameters.AddWithValue("@date", date.Date);
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    throw new Exception("Aucun tarif actif n'est défini pour cette prestation.");
                return Convert.ToDecimal(result);
            }
        }

        // ============================================================
        // PAIEMENT EEG
        // ============================================================
        public static void PayerEEG(
            int idFacture,
            int idDetailFacture,
            decimal montantPaiement,
            DateTime datePaiement,
            MySqlConnection con,
            MySqlTransaction tr)
        {
            if (montantPaiement <= 0)
                throw new Exception("Le montant du paiement EEG doit être supérieur à zéro.");

            int idPrestation;
            decimal montantEEG;

            string query = @"
                SELECT id_prestation, COALESCE(montant, 0)
                FROM detail_facture
                WHERE id_detail_facture = @id_detail
                  AND id_facture = @id_facture
                LIMIT 1
                FOR UPDATE";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@id_detail", idDetailFacture);
                cmd.Parameters.AddWithValue("@id_facture", idFacture);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        throw new Exception("Le détail EEG est introuvable dans la facture.");

                    idPrestation = Convert.ToInt32(reader.GetValue(0));
                    montantEEG = Convert.ToDecimal(reader.GetValue(1));
                }
            }

            query = @"
                SELECT COUNT(*)
                FROM prestation p
                INNER JOIN service s ON s.id_service = p.id_service
                WHERE p.id_prestation = @id_prestation
                  AND s.nom = 'EEG'
                  AND p.actif = 1
                  AND s.actif = 1";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@id_prestation", idPrestation);
                if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    throw new Exception("Cette prestation n'appartient pas au service EEG.");
            }

            decimal dejaPayeEEG;
            query = @"
                SELECT COALESCE(SUM(montant), 0)
                FROM paiement
                WHERE id_facture = @id_facture
                  AND id_detail_facture = @id_detail";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@id_facture", idFacture);
                cmd.Parameters.AddWithValue("@id_detail", idDetailFacture);
                dejaPayeEEG = Convert.ToDecimal(cmd.ExecuteScalar());
            }

            decimal resteEEG = montantEEG - dejaPayeEEG;

            if (resteEEG <= 0)
                throw new Exception("Cette prestation EEG est déjà entièrement payée.");

            if (montantPaiement > resteEEG)
                throw new Exception("Le paiement EEG dépasse le montant restant de l'EEG.");

            // Le champ reste de paiement = reste GLOBAL de la facture.
            decimal totalFacture;
            decimal dejaPayeFacture;

            query = @"
                SELECT COALESCE(montant_total, 0)
                FROM facture
                WHERE id_facture = @id_facture
                  AND statut <> 'Clôturée'
                FOR UPDATE";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@id_facture", idFacture);
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    throw new Exception("Facture introuvable ou déjà clôturée.");
                totalFacture = Convert.ToDecimal(result);
            }

            query = @"
                SELECT COALESCE(SUM(montant), 0)
                FROM paiement
                WHERE id_facture = @id_facture";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@id_facture", idFacture);
                dejaPayeFacture = Convert.ToDecimal(cmd.ExecuteScalar());
            }

            decimal nouveauResteFacture = totalFacture - dejaPayeFacture - montantPaiement;

            if (nouveauResteFacture < 0)
                throw new Exception("Le paiement EEG dépasse le reste global de la facture.");

            string typePaiement = nouveauResteFacture == 0 ? "Complet" : "Partiel";

            query = @"
                INSERT INTO paiement
                (
                    id_facture,
                    id_detail_facture,
                    date_paiement,
                    montant,
                    reste,
                    type_paiement
                )
                VALUES
                (
                    @id_facture,
                    @id_detail,
                    @date_paiement,
                    @montant,
                    @reste,
                    @type_paiement
                )";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@id_facture", idFacture);
                cmd.Parameters.AddWithValue("@id_detail", idDetailFacture);
                cmd.Parameters.AddWithValue("@date_paiement", datePaiement.Date);
                cmd.Parameters.AddWithValue("@montant", montantPaiement);
                cmd.Parameters.AddWithValue("@reste", nouveauResteFacture);
                cmd.Parameters.AddWithValue("@type_paiement", typePaiement);
                cmd.ExecuteNonQuery();
            }

            RecalculerFacture(idFacture, con, tr);
        }

        // ============================================================
        // RECALCULER LES INFORMATIONS DE LA FACTURE
        // ============================================================
        public static void RecalculerFacture(
            int idFacture,
            MySqlConnection con,
            MySqlTransaction tr)
        {
            decimal total;
            decimal paye;

            string query = @"
                SELECT COALESCE(SUM(montant), 0)
                FROM detail_facture
                WHERE id_facture = @id_facture";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@id_facture", idFacture);
                total = Convert.ToDecimal(cmd.ExecuteScalar());
            }

            query = @"
                SELECT COALESCE(SUM(montant), 0)
                FROM paiement
                WHERE id_facture = @id_facture";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@id_facture", idFacture);
                paye = Convert.ToDecimal(cmd.ExecuteScalar());
            }

            decimal reste = total - paye;
            if (reste < 0) reste = 0;

            string statut;
            if (paye <= 0)
                statut = "Non payé";
            else if (reste > 0)
                statut = "Partiellement payé";
            else
                statut = "Payé";

            query = @"
                UPDATE facture
                SET montant_total = @total,
                    montant_paye = @paye,
                    reste = @reste,
                    statut = CASE
                        WHEN statut = 'Clôturée' THEN 'Clôturée'
                        ELSE @statut
                    END
                WHERE id_facture = @id_facture";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@paye", paye);
                cmd.Parameters.AddWithValue("@reste", reste);
                cmd.Parameters.AddWithValue("@statut", statut);
                cmd.Parameters.AddWithValue("@id_facture", idFacture);
                cmd.ExecuteNonQuery();
            }
        }

        // ============================================================
        // CREER OU RECUPERER LA FACTURE OUVERTE DU PATIENT
        // ============================================================
        public static int CreerFactureSiInexistante(
            string idPatient,
            MySqlConnection con,
            MySqlTransaction tr)
        {
            string query = @"
                SELECT id_facture
                FROM facture
                WHERE id_patient = @id_patient
                  AND statut <> 'Clôturée'
                ORDER BY id_facture DESC
                LIMIT 1";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@id_patient", idPatient);

                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                    return Convert.ToInt32(result);
            }

            query = @"
                INSERT INTO facture
                (
                    id_patient,
                    id_centre,
                    date_facture,
                    montant_total,
                    montant_paye,
                    reste,
                    statut
                )
                VALUES
                (
                    @id_patient,
                    @id_centre,
                    CURDATE(),
                    0,
                    0,
                    0,
                    'Non payé'
                )";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@id_patient", idPatient);
                cmd.Parameters.AddWithValue("@id_centre", MesForms.SessionUtilisateur.idCentre);

                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.LastInsertedId);
            }
        }



        public static void PayerFactureGenerale(
            int idFacture,
            decimal montantPaiement,
            DateTime datePaiement,
            MySqlConnection con,
            MySqlTransaction tr)
        {
            if (montantPaiement <= 0)
            {
                throw new Exception(
                    "Le montant du paiement doit être supérieur à zéro.");
            }

            // ============================================================
            // 1. Récupérer le montant total de la facture
            // ============================================================

            decimal montantTotal = 0;

            string query = @"
        SELECT COALESCE(montant_total, 0)
        FROM facture
        WHERE id_facture = @id_facture
        LIMIT 1";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@id_facture", idFacture);

                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {
                    throw new Exception("La facture est introuvable.");
                }

                montantTotal = Convert.ToDecimal(result);
            }


            // ============================================================
            // 2. Calculer tout ce qui a déjà été payé sur la facture
            // ============================================================

            decimal montantDejaPaye = 0;

            query = @"
        SELECT COALESCE(SUM(montant), 0)
        FROM paiement
        WHERE id_facture = @id_facture";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue("@id_facture", idFacture);

                montantDejaPaye = Convert.ToDecimal(cmd.ExecuteScalar());
            }


            // ============================================================
            // 3. Calculer le reste avant le nouveau paiement
            // ============================================================

            decimal resteAvantPaiement =
                montantTotal - montantDejaPaye;

            if (resteAvantPaiement <= 0)
            {
                throw new Exception(
                    "Cette facture est déjà entièrement payée.");
            }


            // ============================================================
            // 4. Vérifier que le paiement ne dépasse pas le reste
            // ============================================================

            if (montantPaiement > resteAvantPaiement)
            {
                throw new Exception(
                    "Le montant du paiement (" +
                    montantPaiement.ToString("0.00") +
                    ") dépasse le reste à payer (" +
                    resteAvantPaiement.ToString("0.00") +
                    ").");
            }


            // ============================================================
            // 5. Calculer le nouveau reste
            // ============================================================

            decimal nouveauReste =
                resteAvantPaiement - montantPaiement;


            // ============================================================
            // 6. Type de paiement
            // ============================================================

            string typePaiement =
                nouveauReste == 0
                    ? "Complet"
                    : "Partiel";


            // ============================================================
            // 7. Enregistrer le paiement GENERAL
            //
            // IMPORTANT :
            // id_detail_facture = NULL
            //
            // Car la caisse générale paie le RESTE GLOBAL
            // de la facture et non une prestation particulière.
            // ============================================================

            query = @"
        INSERT INTO paiement
        (
            id_facture,
            id_detail_facture,
            date_paiement,
            montant,
            reste,
            type_paiement
        )
        VALUES
        (
            @id_facture,
            NULL,
            @date_paiement,
            @montant,
            @reste,
            @type_paiement
        )";

            using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue(
                    "@id_facture",
                    idFacture);

                cmd.Parameters.AddWithValue(
                    "@date_paiement",
                    datePaiement.Date);

                cmd.Parameters.AddWithValue(
                    "@montant",
                    montantPaiement);

                cmd.Parameters.AddWithValue(
                    "@reste",
                    nouveauReste);

                cmd.Parameters.AddWithValue(
                    "@type_paiement",
                    typePaiement);

                cmd.ExecuteNonQuery();
            }


            // ============================================================
            // 8. Recalculer la facture
            //
            // Cela met à jour :
            // montant_total
            // montant_paye
            // reste
            // statut
            // ============================================================

            RecalculerFacture(
                idFacture,
                con,
                tr);
        }
    }
}
