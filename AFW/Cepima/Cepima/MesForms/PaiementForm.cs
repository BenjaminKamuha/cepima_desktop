using System;
using System.Data;
using System.Windows.Forms;
using Cepima.Data;
using MySql.Data.MySqlClient;

namespace Cepima.MesForms
{
    public partial class PaiementForm : Form
    {
        // =========================================================
        // VARIABLES GLOBALES
        // =========================================================
        Database db = new Database();

        public static int ID_PATIENT = 0;
        public static int SERVICE_ID = 0;
        public static int PRESTATION = 0;
        public static decimal PRIX = 0;

        public static Label LB_NOM_PATIENT;
        public static Label LB_SEXE;
        public static Label LB_NUM_FICHE;

        private decimal TOTAL_PRESCRIPTION = 0;

        public static int ID_PRESCRIPTION = 0;

        //public static RoundedButton BT_CHOISIR_PATIENT;

        public static Panel PAN_FORM;

        private bool initialisationService = false;
        private bool initialisationPrestation = false;


        // =========================================================
        // CONSTRUCTEUR
        // =========================================================

        public PaiementForm()
        {
            InitializeComponent();

            LB_NOM_PATIENT = lb_nom_patient;
            LB_SEXE = lb_sexe_age;
            LB_NUM_FICHE = lb_num_fiche;
            //BT_CHOISIR_PATIENT = bt_choisir_patient;
            PAN_FORM = panForm;
            

   

                Configurer();

                cbx_service.SelectedIndexChanged -=
                cbx_service_SelectedIndexChanged;
                cbx_service.SelectedIndexChanged +=
                cbx_service_SelectedIndexChanged;
                ChargerServices();
        }


        // =========================================================
        // CONFIGURATION
        // =========================================================

        private void Configurer()
        {
            cbx_service.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cbx_prestation.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cbx_service.FormattingEnabled = true;
            cbx_prestation.FormattingEnabled = true;

            initialisationService = true;
            initialisationPrestation = true;

            try
            {
                cbx_service.DataSource = null;
                cbx_service.Items.Clear();
                cbx_service.SelectedIndex = -1;

                cbx_prestation.DataSource = null;
                cbx_prestation.Items.Clear();
                cbx_prestation.SelectedIndex = -1;

                nud_prix.Value = 0;
                nud_prix.Enabled = false;
            }
            finally
            {
                initialisationPrestation = false;
                initialisationService = false;
            }

            SERVICE_ID = 0;
            PRESTATION = 0;
            PRIX = 0;
        }


        // =========================================================
        // CHARGER LES INFORMATIONS DU PATIENT
        // =========================================================

        public static void ChargerPatients()
        {
            try
            {
                Database db = new Database();

                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"
                        SELECT
                            id_patient,
                            date_naissance,
                            numero_fiche,
                            sexe,
                            CONCAT(
                                nom,
                                ' ',
                                post_nom,
                                CASE
                                    WHEN prenom IS NOT NULL
                                         AND prenom <> ''
                                    THEN CONCAT(' ', prenom)
                                    ELSE ''
                                END
                            ) AS patient
                        FROM patients
                        WHERE id_patient = @id_patient
                        LIMIT 1";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_patient",
                            ID_PATIENT);

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nomPatient =
                                    reader["patient"] == DBNull.Value
                                    ? ""
                                    : reader["patient"].ToString();

                                string sexe =
                                    reader["sexe"] == DBNull.Value
                                    ? ""
                                    : reader["sexe"].ToString();

                                string numeroFiche =
                                    reader["numero_fiche"] == DBNull.Value
                                    ? ""
                                    : reader["numero_fiche"].ToString();

                                int age = 0;

                                if (reader["date_naissance"] != DBNull.Value)
                                {
                                    DateTime naissance =
                                        Convert.ToDateTime(
                                            reader["date_naissance"]);

                                    age = DateTime.Now.Year -
                                          naissance.Year;

                                    if (DateTime.Now.Date <
                                        naissance.AddYears(age).Date)
                                    {
                                        age--;
                                    }
                                }

                                
                                 LB_NOM_PATIENT.Text = nomPatient;

                                LB_SEXE.Text =
                                    sexe + " - " + age + " ans";

                                LB_NUM_FICHE.Text = numeroFiche;

                                PAN_FORM.Enabled = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du patient :\n\n" +
                    ex.Message,
                    "Patient",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // CHARGER LES SERVICES
        // =========================================================

        private void ChargerServices()
        {
            //if (ID_PATIENT > 0)
            //{
                PAN_FORM.Enabled = true;

                initialisationService = true;

                try
                {
                    Database db = new Database();

                    using (MySqlConnection con = db.GetConnection())
                    {
                        con.Open();

                        string query = @"
                        SELECT id_service, nom
                        FROM service
                        WHERE actif = 1
                        ORDER BY nom";

                        using (MySqlCommand cmd =
                            new MySqlCommand(query, con))
                        using (MySqlDataAdapter adapter =
                            new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();

                            adapter.Fill(dt);

                            cbx_service.DataSource = null;

                            cbx_service.DisplayMember = "nom";
                            cbx_service.ValueMember = "id_service";
                            cbx_service.DataSource = dt;

                            cbx_service.SelectedIndex = -1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur lors du chargement des services.\n\n" +
                        ex.Message,
                        "Services",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    initialisationService = false;
                }
            //}
            
        }


        // =========================================================
        // CHARGER LES PRESTATIONS DU SERVICE
        // =========================================================

        private void ChargerPrestations()
        {
            initialisationPrestation = true;

            try
            {
                cbx_prestation.DataSource = null;
                cbx_prestation.Items.Clear();

                PRESTATION = 0;
                PRIX = 0;

                nud_prix.Value = 0;
                nud_prix.Enabled = false;

                if (cbx_service.SelectedIndex < 0)
                    return;

                object valeur = cbx_service.SelectedValue;

                if (valeur == null ||
                    valeur == DBNull.Value ||
                    valeur is DataRowView)
                {
                    return;
                }

                int idService;

                if (!int.TryParse(
                    Convert.ToString(valeur),
                    out idService))
                {
                    return;
                }


                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"
                        SELECT
                            id_prestation,
                            libelle
                        FROM prestation
                        WHERE id_service = @id_service
                          AND actif = 1
                        ORDER BY libelle";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.Add(
                            "@id_service",
                            MySqlDbType.Int32).Value = idService;

                        DataTable dt = new DataTable();

                        using (MySqlDataAdapter adapter =
                            new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        cbx_prestation.DisplayMember = "libelle";
                        cbx_prestation.ValueMember = "id_prestation";
                        cbx_prestation.DataSource = dt;

                        cbx_prestation.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des prestations :\n\n" +
                    ex.ToString(),
                    "Prestations",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                initialisationPrestation = false;
            }
        }


        // =========================================================
        // CHANGEMENT DE SERVICE
        // =========================================================

        private void cbx_service_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (initialisationService ||
                initialisationPrestation)
            {
                return;
            }

            if (cbx_service.SelectedIndex < 0 ||
                cbx_service.SelectedValue == null ||
                cbx_service.SelectedValue is DataRowView)
            {
                SERVICE_ID = 0;

                initialisationPrestation = true;

                try
                {
                    cbx_prestation.DataSource = null;
                    cbx_prestation.Items.Clear();

                    PRESTATION = 0;
                    PRIX = 0;

                    nud_prix.Value = 0;
                    nud_prix.Enabled = false;
                }
                finally
                {
                    initialisationPrestation = false;
                }

                return;
            }

            int idService;

            if (!int.TryParse(
                Convert.ToString(cbx_service.SelectedValue),
                out idService))
            {
                return;
            }

            SERVICE_ID = idService;

            // Charger les prestations du service choisi.
            ChargerPrestations();
        }

        private string RecupererTypePrestation(int idPrestation)
        {
            string typePrestation = null;

            try
            {
                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"
                SELECT type_prestation
                FROM prestation
                WHERE id_prestation = @id_prestation
                LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_prestation", idPrestation);

                        object resultat = cmd.ExecuteScalar();

                        if (resultat != null && resultat != DBNull.Value)
                            typePrestation = resultat.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la récupération du type de prestation : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return typePrestation;
        }


        // =========================================================
        // RECUPERER L'ID DE LA PRESTATION
        // =========================================================

        private int RecupererIdPrestation()
        {
            if (cbx_prestation.SelectedIndex < 0 ||
                cbx_prestation.SelectedValue == null ||
                cbx_prestation.SelectedValue == DBNull.Value ||
                cbx_prestation.SelectedValue is DataRowView)
            {
                return 0;
            }

            int id;

            if (!int.TryParse(
                Convert.ToString(cbx_prestation.SelectedValue),
                out id))
            {
                return 0;
            }

            return id;
        }


        // =========================================================
        // CHARGER LE PRIX D'UNE PRESTATION
        // =========================================================

        private decimal ChargerPrix(int id_prestation)
        {
            decimal prix = 0;

            try
            {
                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string queryPrix = @"
                SELECT prix
                FROM tarif_prestation
                WHERE id_prestation = @id_prestation
                  AND actif = 1
                ORDER BY date_debut DESC, id_tarif DESC
                LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(queryPrix, con))
                    {
                        cmd.Parameters.AddWithValue("@id_prestation", id_prestation);

                        object resultat = cmd.ExecuteScalar();

                        if (resultat != null && resultat != DBNull.Value)
                            prix = Convert.ToDecimal(resultat);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la récupération du tarif : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return prix;
        }
        // =========================================================
        // CHANGEMENT DE PRESTATION
        // =========================================================

        private void cbx_prestation_SelectedIndexChanged_1(
            object sender,
            EventArgs e)
        {
            if (initialisationPrestation)
                return;

            int idPrestation = RecupererIdPrestation();

            if (idPrestation <= 0)
            {
                PRESTATION = 0;
                PRIX = 0;

                nud_prix.Value = 0;
                nud_prix.Enabled = false;

                return;
            }

            try
            {
                PRESTATION = idPrestation;

                if (RecupererTypePrestation(PRESTATION) != "MEDICALE")
                {

                    decimal prix = ChargerPrix(idPrestation);

                    PRIX = prix;

                    nud_prix.Enabled = true;

                    // Vérifier les limites du NumericUpDown.
                    if (prix > nud_prix.Maximum)
                    {
                        nud_prix.Value = nud_prix.Maximum;
                    }
                    else if (prix < nud_prix.Minimum)
                    {
                        nud_prix.Value = nud_prix.Minimum;
                    }
                    else
                    {
                        nud_prix.Value = prix;
                    }
                }
                //else
                //{
                //    // Precription
                //    Form1.CONTEXT = "CAISSE";

                //    MesForms.Prescription.Form_prescription_mdc
                //    form_presc = new MesForms.Prescription.Form_prescription_mdc(
                //        Convert.ToInt32(ID_PATIENT));

                //    form_presc.ShowDialog();
                //}
            }
            catch (Exception ex)
            {
                PRESTATION = 0;
                PRIX = 0;

                nud_prix.Value = 0;
                nud_prix.Enabled = false;

                MessageBox.Show(
                    "Impossible de charger le tarif :\n\n" +
                    ex.Message,
                    "Tarif de prestation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        // =========================================================
        // CREER / RECUPERER UNE FACTURE
        // =========================================================

        private int CreerFactureSiInexistante(
            string idPatient,
            MySqlConnection con,
            MySqlTransaction tr)
        {
            // Chercher une facture ouverte.

            string query = @"
                SELECT id_facture
                FROM facture
                WHERE id_patient = @idPatient
                  AND (statut IS NULL OR statut <> 'Clôturée')
                ORDER BY id_facture DESC
                LIMIT 1";

            using (MySqlCommand cmd =
                new MySqlCommand(query, con, tr))
            {
                cmd.Parameters.AddWithValue(
                    "@idPatient", idPatient);

                object result = cmd.ExecuteScalar();

                if (result != null &&
                    result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
            }


            // Créer une nouvelle facture.

            string insert = @"
                INSERT INTO facture
                (
                    id_patient,
                    id_centre,
                    type_facture,
                    date_facture,
                    montant_total,
                    montant_paye,
                    reste,
                    statut
                )
                VALUES
                (
                    @patient,
                    @centre,
                    'Ambulatoire',
                    CURDATE(),
                    0,
                    0,
                    0,
                    'Non payé'
                )";

            using (MySqlCommand cmd =
                new MySqlCommand(insert, con, tr))
            {
                cmd.Parameters.AddWithValue(
                    "@patient", idPatient);

                cmd.Parameters.AddWithValue(
                    "@centre",
                    MesForms.SessionUtilisateur.idCentre);

                cmd.ExecuteNonQuery();

                return Convert.ToInt32(cmd.LastInsertedId);
            }
        }


        private int CreerFactureSiInexistante(
            string idPatient)
        {
            // Chercher une facture ouverte.

            string query = @"
                SELECT id_facture
                FROM facture
                WHERE id_patient = @idPatient
                  AND (statut IS NULL OR statut <> 'Clôturée')
                ORDER BY id_facture DESC
                LIMIT 1";

            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();

                using (MySqlCommand cmd =
                    new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@idPatient", idPatient);

                    object result = cmd.ExecuteScalar();

                    if (result != null &&
                        result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }

            // Créer une nouvelle facture.

            string insert = @"
                INSERT INTO facture
                (
                    id_patient,
                    id_centre,
                    type_facture,
                    date_facture,
                    montant_total,
                    montant_paye,
                    reste,
                    statut
                )
                VALUES
                (
                    @patient,
                    @centre,
                    'Ambulatoire',
                    CURDATE(),
                    0,
                    0,
                    0,
                    'Non payé'
                )";

            using (MySqlConnection con = db.GetConnection())
            {
                
            using (MySqlCommand cmd =
                new MySqlCommand(insert, con))
            {
                cmd.Parameters.AddWithValue(
                    "@patient", idPatient);

                cmd.Parameters.AddWithValue(
                    "@centre",
                    MesForms.SessionUtilisateur.idCentre);

                cmd.ExecuteNonQuery();

                return Convert.ToInt32(cmd.LastInsertedId);
            }
            }
        }


        private bool MettreAJourTarifPrestation(int idPrestation, decimal nouveauPrix)
        {
            if (idPrestation <= 0)
                return false;

            if (nouveauPrix < 0)
            {
                MessageBox.Show("Le tarif ne peut pas être négatif.");
                return false;
            }

            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();

                using (MySqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Désactiver l'ancien tarif
                        string sqlDesactivation = @"
                    UPDATE tarif_prestation
                    SET actif = 0,
                        date_fin = DATE_SUB(CURDATE(), INTERVAL 1 DAY)
                    WHERE id_prestation = @id_prestation
                      AND actif = 1";

                        using (MySqlCommand cmd = new MySqlCommand(sqlDesactivation, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id_prestation", idPrestation);
                            cmd.ExecuteNonQuery();
                        }

                        // Insérer le nouveau tarif
                        string sqlInsertion = @"
                    INSERT INTO tarif_prestation
                    (id_prestation, prix, date_debut, actif)
                    VALUES
                    (@id_prestation, @prix, CURDATE(), 1)";

                        using (MySqlCommand cmd = new MySqlCommand(sqlInsertion, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id_prestation", idPrestation);
                            cmd.Parameters.AddWithValue("@prix", nouveauPrix);

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        MessageBox.Show(
                            "Erreur lors de la mise à jour du tarif : " + ex.Message,
                            "Erreur",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return false;
                    }
                }
            }
        }

        private void nud_prix_ValueChanged(object sender, EventArgs e)
        {

            nud_montant_payer.Value = nud_prix.Value;
            nud_rest.Value = nud_prix.Value - nud_montant_payer.Value;

            if (nud_prix.Value != PRIX)
            {
                nud_montant_payer.Enabled = false;
                nud_rest.Enabled = false;
                bt_mod.Visible = true;
            }

            else
            {
                nud_montant_payer.Enabled = true;
                nud_rest.Enabled = false;
                bt_mod.Visible = false;
            }
        }

        private void bt_mod_Click(object sender, EventArgs e)
        {
            MettreAJourTarifPrestation(PRESTATION, nud_prix.Value);

            nud_montant_payer.Value = nud_prix.Value;
            nud_rest.Value = nud_prix.Value - nud_montant_payer.Value;

            nud_montant_payer.Enabled = true;
            nud_rest.Enabled = false;
            bt_mod.Visible = false;
        }

        private void nud_montant_payer_ValueChanged(object sender, EventArgs e)
        {
            nud_rest.Value = Math.Abs(nud_prix.Value - nud_montant_payer.Value);
        }

        private void bt_choisir_patient_Click(object sender, EventArgs e)
        {
            FormAfficherPatient show_patient = new FormAfficherPatient();
            show_patient.ShowDialog();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            ID_PATIENT = 0;
            this.Close();
        }

        private void btn_send_request_Click(object sender, EventArgs e)
        {

            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {

                MySqlTransaction tr = con.BeginTransaction();
                // Initialisation/Recuperation facture

                try
                {
                    // Création de la facture si elle n'existes pas
                    int id_facture = MesClasses.ReceptionManager.CreerFactureSiInexistante(ID_PATIENT.ToString(), con, tr);

                    // Ajout de la prestation dans le detail de la facture
                    int id_detail = MesClasses.ReceptionManager.AjouterPrestationFacture(id_facture, PRESTATION, 1, nud_prix.Value, con, tr);

                    // Paymenet de prestation
                    int id_paiement = MesClasses.ReceptionManager.PayerPrestation(id_facture, id_detail, nud_montant_payer.Value, DateTime.Now.Date, con);
                 
                    // Recalculer la facture après ajout paimenet de la prestation
                    MesClasses.ReceptionManager.RecalculerFacture(id_facture, con);

                    // Enregistrement de l'opération dans le livre de caisse
                    MesClasses.ReceptionManager.AjouterLivreCaisse(nud_montant_payer.Value, 0,"EEG", cbx_prestation.Text, con, tr);

                    tr.Commit();

                    // ImprimerReçus
                    MesForms.FormRecu recu = new MesForms.FormRecu(id_paiement);
                    this.Close();
                    ID_PATIENT = 0;
                    recu.ShowDialog();
                   
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lor du paiement" + ex.Message);
                    tr.Rollback();
                }
                
            }

        }

        private void PaiementForm_Load(object sender, EventArgs e)
        {
            if (ID_PATIENT == 0)
            {
                
                //.Enabled = false;
                PAN_FORM.Enabled = false; 
            }
        }
    }
}