using System;
using System.Data;
using System.Windows.Forms;
using Cepima.Data;
using MySql.Data.MySqlClient;


namespace Cepima.MesForms
{
    public partial class Form_demander_service : Form
    {
        // =========================================================
        // VARIABLES
        // =========================================================

        // Empêche les événements de travailler pendant
        // l'initialisation ou le chargement d'une demande.
        private bool initialisationService = false;

        private const string STATUTS_ACTIFS = "'Demandée','En attente','Acceptée','En cours'";


        // =========================================================
        // CONSTRUCTEUR
        // =========================================================

        public Form_demander_service()
        {
            InitializeComponent();

            Configurer();

            ChargerPatients();
            ChargerServices();

            // -----------------------------------------------------
            // MODE MODIFICATION
            // -----------------------------------------------------

            if (Form1.DEMANDE_ID != 0)
            {
                btn_send_request.Text = "Modifier";

                ChargerDemande(
                    Form1.DEMANDE_ID);
            }
            else
            {
                btn_send_request.Text = "Enregistrer";
            }
        }


        // =========================================================
        // CONFIGURATION
        // =========================================================

        private void Configurer()
        {
            rd_priorite_normal.Checked = true;

            cbx_service.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cbx_prestation.DropDownStyle =
                ComboBoxStyle.DropDownList;


            // -----------------------------------------------------
            // Bouton enregistrer
            // -----------------------------------------------------

            btn_send_request.Click -=
                btn_send_request_Click;

            btn_send_request.Click +=
                btn_send_request_Click;


            // -----------------------------------------------------
            // Bouton annuler
            // -----------------------------------------------------

            btn_cancel.Click -=
                btn_cancel_Click;

            btn_cancel.Click +=
                btn_cancel_Click;


            // -----------------------------------------------------
            // Initialisation du service
            // -----------------------------------------------------

            initialisationService = true;

            try
            {
                cbx_service.SelectedIndex = -1;

                cbx_prestation.DataSource = null;
                cbx_prestation.Items.Clear();
            }
            finally
            {
                initialisationService = false;
            }
        }


        // =========================================================
        // CHARGER LES INFORMATIONS DU PATIENT
        // =========================================================

        private void ChargerPatients()
        {
            try
            {
                Database db = new Database();

                using (MySqlConnection con =
                    db.GetConnection())
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
                            Form1.PATIENT_ID);

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

                                if (reader["date_naissance"] !=
                                    DBNull.Value)
                                {
                                    DateTime naissance =
                                        Convert.ToDateTime(
                                            reader["date_naissance"]);

                                    age =
                                        DateTime.Now.Year -
                                        naissance.Year;

                                    if (DateTime.Now.Date <
                                        naissance.AddYears(age).Date)
                                    {
                                        age--;
                                    }
                                }

                                lb_nom_patient.Text =
                                    nomPatient;

                                lb_sexe_age.Text =
                                    sexe + " - " +
                                    age.ToString() +
                                    " ans";

                                lb_num_fiche.Text =
                                    numeroFiche;
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
                    "SERVICE",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // CHARGER LES SERVICES
        // =========================================================

        private void ChargerServices()
        {
            try
            {
                Database db = new Database();

                using (MySqlConnection con =
                    db.GetConnection())
                {
                    con.Open();

                    string query = @"
                        SELECT
                            id_service,
                            nom
                        FROM service
                        WHERE actif = 1
                        ORDER BY nom";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        using (MySqlDataAdapter adapter =
                            new MySqlDataAdapter(cmd))
                        {
                            DataTable dt =
                                new DataTable();

                            adapter.Fill(dt);

                            initialisationService = true;

                            try
                            {
                                cbx_service.DataSource =
                                    null;

                                cbx_service.DisplayMember =
                                    "nom";

                                cbx_service.ValueMember =
                                    "id_service";

                                cbx_service.DataSource =
                                    dt;

                                cbx_service.SelectedIndex =
                                    -1;
                            }
                            finally
                            {
                                initialisationService = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des services.\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // CHARGER LES PRESTATIONS DU SERVICE
        // =========================================================

        private void ChargerPrestations()
        {
            cbx_prestation.DataSource = null;
            cbx_prestation.Items.Clear();

            if (cbx_service.SelectedIndex < 0 ||
                cbx_service.SelectedValue == null)
            {
                return;
            }

            if (cbx_service.SelectedValue is DataRowView)
            {
                return;
            }

            int idService;

            try
            {
                idService =
                    Convert.ToInt32(
                        cbx_service.SelectedValue);
            }
            catch
            {
                return;
            }

            try
            {
                Database db = new Database();

                using (MySqlConnection con =
                    db.GetConnection())
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
                        cmd.Parameters.AddWithValue(
                            "@id_service",
                            idService);

                        DataTable dt =
                            new DataTable();

                        using (MySqlDataAdapter adapter =
                            new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        cbx_prestation.DataSource =
                            dt;

                        cbx_prestation.DisplayMember =
                            "libelle";

                        cbx_prestation.ValueMember =
                            "id_prestation";

                        if (dt.Rows.Count > 0)
                        {
                            cbx_prestation.SelectedIndex = 0;
                        }
                        else
                        {
                            cbx_prestation.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des prestations.\n\n" +
                    ex.Message,
                    "Prestations",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // CHANGEMENT DE SERVICE
        // =========================================================

        private void cbx_service_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (initialisationService)
            {
                return;
            }

            ChargerPrestations();

            if (cbx_service.SelectedIndex < 0)
            {
                return;
            }

            if (cbx_service.SelectedValue == null)
            {
                return;
            }

            if (cbx_service.SelectedValue is DataRowView)
            {
                return;
            }

            int idService;

            try
            {
                idService =
                    Convert.ToInt32(
                        cbx_service.SelectedValue);
            }
            catch
            {
                return;
            }


            // =====================================================
            // NOUVELLE DEMANDE
            // =====================================================

            if (Form1.DEMANDE_ID == 0)
            {
                int idDemande =
                    VerifierDemandeExistante(
                        Form1.PATIENT_ID,
                        idService);

                if (idDemande <= 0)
                {
                    return;
                }

                DialogResult choix =
                    MessageBox.Show(
                        "Ce patient possède déjà une demande " +
                        "en attente pour ce service.\n\n" +
                        "Voulez-vous modifier cette demande ?",
                        "Demande existante",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                if (choix == DialogResult.Yes)
                {
                    Form1.DEMANDE_ID =
                        idDemande;

                    btn_send_request.Text =
                        "Modifier";

                    ChargerDemande(
                        idDemande);

                    return;
                }


                // -------------------------------------------------
                // NON :
                // on désélectionne le service
                // -------------------------------------------------

                initialisationService = true;

                try
                {
                    cbx_service.SelectedIndex = -1;

                    cbx_prestation.DataSource = null;
                    cbx_prestation.Items.Clear();
                }
                finally
                {
                    initialisationService = false;
                }

                return;
            }


            // =====================================================
            // MODIFICATION
            // =====================================================

            int demandeActuelle =
                Form1.DEMANDE_ID;

            int autreDemande =
                VerifierAutreDemandeExistante(
                    Form1.PATIENT_ID,
                    idService,
                    demandeActuelle);

            if (autreDemande <= 0)
            {
                return;
            }

            MessageBox.Show(
                "Ce patient possède déjà une autre demande " +
                "en attente pour ce service.\n\n" +
                "Vous ne pouvez pas sélectionner ce service.",
                "Service déjà demandé",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            ChargerServiceDemandeActuelle(
                demandeActuelle);
        }


        // =========================================================
        // CHARGER UNE DEMANDE EXISTANTE
        // =========================================================

        private void ChargerDemande(int idDemande)
        {
            try
            {
                Database db = new Database();

                using (MySqlConnection con =
                    db.GetConnection())
                {
                    con.Open();

                    string query = @"
                        SELECT
                            id_service,
                            id_prestation,
                            priorite,
                            motif,
                            observation
                        FROM demande_service
                        WHERE id_demande = @id_demande
                          AND id_patient = @id_patient
                          AND statut IN (
                              'Demandée',
                              'En attente',
                              'Acceptée',
                              'En cours'
                          )
                        LIMIT 1";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_demande",
                            idDemande);

                        cmd.Parameters.AddWithValue(
                            "@id_patient",
                            Form1.PATIENT_ID);

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "La demande n'existe pas ou " +
                                    "n'est plus en attente.",
                                    "Demande de service",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                Form1.DEMANDE_ID = 0;

                                return;
                            }

                            int idService =
                                Convert.ToInt32(
                                    reader["id_service"]);

                            int? idPrestation = null;

                            if (reader["id_prestation"] !=
                                DBNull.Value)
                            {
                                idPrestation =
                                    Convert.ToInt32(
                                        reader["id_prestation"]);
                            }

                            string priorite =
                                reader["priorite"] ==
                                DBNull.Value
                                    ? "Normale"
                                    : reader["priorite"].ToString();

                            string motif =
                                reader["motif"] ==
                                DBNull.Value
                                    ? ""
                                    : reader["motif"].ToString();

                            string observation =
                                reader["observation"] ==
                                DBNull.Value
                                    ? ""
                                    : reader["observation"].ToString();


                            // -----------------------------------------
                            // SERVICE
                            // -----------------------------------------

                            initialisationService = true;

                            try
                            {
                                cbx_service.SelectedValue =
                                    idService;
                            }
                            finally
                            {
                                initialisationService =
                                    false;
                            }


                            // -----------------------------------------
                            // PRESTATIONS
                            // -----------------------------------------

                            ChargerPrestations();


                            // -----------------------------------------
                            // PRESTATION
                            // -----------------------------------------

                            if (idPrestation.HasValue)
                            {
                                try
                                {
                                    cbx_prestation.SelectedValue =
                                        idPrestation.Value;
                                }
                                catch
                                {
                                    cbx_prestation.SelectedIndex =
                                        -1;
                                }
                            }
                            else
                            {
                                cbx_prestation.SelectedIndex =
                                    -1;
                            }


                            // -----------------------------------------
                            // PRIORITE
                            // -----------------------------------------

                            if (priorite == "Urgente")
                            {
                                rd_priorite_urgente.Checked =
                                    true;

                                rd_priorite_normal.Checked =
                                    false;
                            }
                            else
                            {
                                rd_priorite_normal.Checked =
                                    true;

                                rd_priorite_urgente.Checked =
                                    false;
                            }


                            // -----------------------------------------
                            // MOTIF
                            // -----------------------------------------

                            tb_indicateur.Text =
                                motif;


                            // -----------------------------------------
                            // OBSERVATION
                            // -----------------------------------------

                            tb_observation.Text =
                                observation;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                initialisationService = false;

                MessageBox.Show(
                    "Erreur lors du chargement de la demande.\n\n" +
                    ex.Message,
                    "Demande de service",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // VERIFIER SI UNE DEMANDE EXISTE
        // =========================================================

        private int VerifierDemandeExistante(
            int idPatient,
            int idService)
        {
            try
            {
                Database db = new Database();

                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"
                SELECT id_demande
                FROM demande_service
                WHERE id_patient = @id_patient
                  AND id_service = @id_service
                  AND statut IN (
                      'Demandée',
                      'En attente',
                      'Acceptée',
                      'En cours'
                  )
                ORDER BY date_demande DESC
                LIMIT 1";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_patient",
                            idPatient);

                        cmd.Parameters.AddWithValue(
                            "@id_service",
                            idService);

                        object result =
                            cmd.ExecuteScalar();

                        if (result != null &&
                            result != DBNull.Value)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la vérification de la demande.\n\n" +
                    ex.Message,
                    "Demande de service",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return 0;
            }

            return 0;
        }

        // =========================================================
        // VERIFIER UNE AUTRE DEMANDE
        // =========================================================

        private int VerifierAutreDemandeExistante(
            int idPatient,
            int idService,
            int idDemandeActuelle)
        {
            try
            {
                Database db = new Database();

                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"
                        SELECT id_demande
                        FROM demande_service
                        WHERE id_patient = @id_patient
                          AND id_service = @id_service
                          AND id_demande <> @id_demande
                          AND statut IN (
                              'Demandée',
                              'En attente',
                              'Acceptée',
                              'En cours'
                          )
                        ORDER BY date_demande DESC
                        LIMIT 1";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_patient",
                            idPatient);

                        cmd.Parameters.AddWithValue(
                            "@id_service",
                            idService);

                        cmd.Parameters.AddWithValue(
                            "@id_demande",
                            idDemandeActuelle);

                        object resultat =
                            cmd.ExecuteScalar();

                        if (resultat != null &&
                            resultat != DBNull.Value)
                        {
                            return Convert.ToInt32(resultat);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la vérification des demandes.\n\n" +
                    ex.Message,
                    "Demande de service",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return 0;
            }

            return 0;
        }

        // =========================================================
        // RESTAURER LE SERVICE ACTUEL
        // =========================================================

        private void ChargerServiceDemandeActuelle(
            int idDemande)
        {
            try
            {
                Database db = new Database();

                using (MySqlConnection con =
                    db.GetConnection())
                {
                    con.Open();

                    string query = @"
                        SELECT
                            id_service,
                            id_prestation
                        FROM demande_service
                        WHERE id_demande = @id_demande
                          AND id_patient = @id_patient
                          AND statut IN (
                              'Demandée',
                              'En attente',
                              'Acceptée',
                              'En cours'
                          )
                        LIMIT 1";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_demande",
                            idDemande);

                        cmd.Parameters.AddWithValue(
                            "@id_patient",
                            Form1.PATIENT_ID);

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                return;
                            }

                            int ancienService =
                                Convert.ToInt32(
                                    reader["id_service"]);

                            int? anciennePrestation =
                                null;

                            if (reader["id_prestation"] !=
                                DBNull.Value)
                            {
                                anciennePrestation =
                                    Convert.ToInt32(
                                        reader["id_prestation"]);
                            }

                            initialisationService =
                                true;

                            try
                            {
                                cbx_service.SelectedValue =
                                    ancienService;
                            }
                            finally
                            {
                                initialisationService =
                                    false;
                            }

                            reader.Close();

                            ChargerPrestations();

                            if (anciennePrestation.HasValue)
                            {
                                try
                                {
                                    cbx_prestation.SelectedValue =
                                        anciennePrestation.Value;
                                }
                                catch
                                {
                                    cbx_prestation.SelectedIndex =
                                        -1;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                initialisationService = false;

                MessageBox.Show(
                    "Erreur lors du rétablissement du service.\n\n" +
                    ex.Message,
                    "Demande de service",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // BOUTON ENREGISTRER / MODIFIER
        // =========================================================

        private void btn_send_request_Click(
            object sender,
            EventArgs e)
        {
            EnregistrerDemande();
        }


        // =========================================================
        // ENREGISTRER UNE DEMANDE
        // =========================================================

        private void EnregistrerDemande()
        {
            // ============================================================
            // VERIFICATION DU SERVICE
            // ============================================================

            if (cbx_service.SelectedIndex < 0 ||
                cbx_service.SelectedValue == null)
            {
                MessageBox.Show(
                    "Veuillez sélectionner un service.",
                    "Demande de service",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cbx_service.Focus();

                return;
            }


            // ============================================================
            // VERIFICATION DE LA PRESTATION
            // ============================================================

            if (cbx_prestation.SelectedIndex < 0 ||
                cbx_prestation.SelectedValue == null)
            {
                MessageBox.Show(
                    "Veuillez sélectionner une prestation.",
                    "Demande de service",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cbx_prestation.Focus();

                return;
            }


            // ============================================================
            // VERIFICATION DU MOTIF
            // ============================================================

            if (string.IsNullOrWhiteSpace(tb_indicateur.Text))
            {
                MessageBox.Show(
                    "Veuillez saisir le motif de la demande.",
                    "Demande de service",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_indicateur.Focus();

                return;
            }


            // ============================================================
            // RECUPERATION DU SERVICE
            // ============================================================

            int idService;

            try
            {
                idService =
                    Convert.ToInt32(cbx_service.SelectedValue);
            }
            catch
            {
                MessageBox.Show(
                    "Le service sélectionné est invalide.",
                    "Demande de service",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // ============================================================
            // RECUPERATION DE LA PRESTATION
            // ============================================================

            int idPrestation;

            try
            {
                idPrestation =
                    Convert.ToInt32(cbx_prestation.SelectedValue);
            }
            catch
            {
                MessageBox.Show(
                    "La prestation sélectionnée est invalide.",
                    "Demande de service",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // ============================================================
            // VERIFICATION DE LA COHERENCE SERVICE / PRESTATION
            // ============================================================

            try
            {
                Database dbVerification = new Database();

                using (MySqlConnection con =
                    dbVerification.GetConnection())
                {
                    con.Open();

                    string queryVerification = @"
                SELECT COUNT(*)
                FROM prestation
                WHERE id_prestation = @id_prestation
                AND id_service = @id_service
                AND actif = 1";

                    using (MySqlCommand cmd =
                        new MySqlCommand(
                            queryVerification,
                            con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_prestation",
                            idPrestation);

                        cmd.Parameters.AddWithValue(
                            "@id_service",
                            idService);

                        int existe =
                            Convert.ToInt32(
                                cmd.ExecuteScalar());

                        if (existe == 0)
                        {
                            MessageBox.Show(
                                "La prestation sélectionnée ne correspond pas au service choisi.",
                                "Demande de service",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la vérification de la prestation.\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            // ============================================================
            // PRIORITE
            // ============================================================

            string priorite =
                rd_priorite_normal.Checked
                    ? "Normale"
                    : "Urgente";


            // ============================================================
            // MOTIF
            // ============================================================

            string motif =
                tb_indicateur.Text.Trim();


            // ============================================================
            // OBSERVATION
            // ============================================================

            string observation = null;

            if (!string.IsNullOrWhiteSpace(tb_observation.Text))
            {
                observation =
                    tb_observation.Text.Trim();
            }


            // ============================================================
            // MODE MODIFICATION
            // ============================================================

            if (Form1.DEMANDE_ID != 0)
            {
                ModifierDemande(
                    Form1.DEMANDE_ID,
                    idService,
                    idPrestation,
                    priorite,
                    motif,
                    observation);

                return;
            }


            // ============================================================
            // VERIFIER SI UNE DEMANDE EXISTE DEJA
            // ============================================================

            int demandeExistante = 0;

            try
            {
                Database db = new Database();

                using (MySqlConnection con =
                    db.GetConnection())
                {
                    con.Open();

                    string query = @"
                SELECT id_demande
                FROM demande_service
                WHERE id_patient = @id_patient
                AND id_service = @id_service
                AND statut IN ('Demandée', 'En attente', 'Acceptée', 'En cours')
                ORDER BY id_demande DESC
                LIMIT 1";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_patient",
                            Form1.PATIENT_ID);

                        cmd.Parameters.AddWithValue(
                            "@id_service",
                            idService);

                        cmd.Parameters.AddWithValue(
                            "@id_prestation",
                            idPrestation);

                        object resultat =
                            cmd.ExecuteScalar();

                        if (resultat != null &&
                            resultat != DBNull.Value)
                        {
                            demandeExistante =
                                Convert.ToInt32(resultat);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la vérification de la demande existante.\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            // ============================================================
            // DEMANDE EXISTANTE
            // ============================================================

            if (demandeExistante > 0)
            {
                DialogResult choix =
                    MessageBox.Show(
                        "Ce patient possède déjà une demande " +
                        "en attente pour cette prestation.\n\n" +
                        "Voulez-vous modifier cette demande ?",
                        "Demande existante",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                if (choix == DialogResult.Yes)
                {
                    Form1.DEMANDE_ID =
                        demandeExistante;

                    btn_send_request.Text =
                        "Modifier";

                    ChargerDemande(
                        demandeExistante);

                    return;
                }

                return;
            }


            // ============================================================
            // CREATION DE LA DEMANDE
            // ============================================================
            try
            {
                Database db = new Database();

                using (MySqlConnection con =
                    db.GetConnection())
                {
                    con.Open();

                    using (MySqlTransaction tr =
                        con.BeginTransaction())
                    {
                        try
                        {
                            // ====================================================
                            // CREER LA DEMANDE
                            // ====================================================

                            string query = @"
                                INSERT INTO demande_service
                                (
                                    id_patient,
                                    id_service,
                                    id_prestation,
                                    id_personnel,
                                    date_demande,
                                    priorite,
                                    motif,
                                    observation,
                                    statut
                                )
                                VALUES
                                (
                                    @id_patient,
                                    @id_service,
                                    @id_prestation,
                                    @id_personnel,
                                    NOW(),
                                    @priorite,
                                    @motif,
                                    @observation,
                                    'En attente'
                                )";

                            int idDemande;

                            using (MySqlCommand cmd =
                                new MySqlCommand(
                                    query,
                                    con,
                                    tr))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@id_patient",
                                    Form1.PATIENT_ID);

                                cmd.Parameters.AddWithValue(
                                    "@id_service",
                                    idService);

                                cmd.Parameters.AddWithValue(
                                    "@id_prestation",
                                    idPrestation);

                                cmd.Parameters.AddWithValue(
                                    "@id_personnel",
                                    DBNull.Value);

                                cmd.Parameters.AddWithValue(
                                    "@priorite",
                                    priorite);

                                cmd.Parameters.AddWithValue(
                                    "@motif",
                                    motif);

                                cmd.Parameters.AddWithValue(
                                    "@observation",
                                    observation == null
                                        ? (object)DBNull.Value
                                        : observation);

                                cmd.ExecuteNonQuery();

                                idDemande =
                                    Convert.ToInt32(
                                        cmd.LastInsertedId);
                            }


                            // ====================================================
                            // CREER LA FACTURATION
                            // ====================================================

                            int idFacture =
                                MesClasses.ReceptionManager.CreerFactureSiInexistante(
                                    Form1.PATIENT_ID.ToString(),
                                    con,
                                    tr);

                            AjouterPrestationFacture(
                                idFacture,
                                idPrestation,
                                1,
                                DateTime.Now.Date,
                                con,
                                tr);


                            // ====================================================
                            // VALIDATION
                            // ====================================================

                            tr.Commit();


                            // ====================================================
                            // CONSERVER LES IDS
                            // ====================================================

                            Form1.DEMANDE_ID =
                                idDemande;


                            // Si tu as une variable globale pour la facture :
                            // Form1.FACTURE_ID = idFacture;


                            MessageBox.Show(
                                "La demande de service a été enregistrée.\n\n" +
                                "La facture a également été initialisée.\n\n" +
                                "N° facture : " + idFacture,
                                "Demande de service",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);


                            DialogResult =
                                DialogResult.OK;

                            Close();
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

                            MessageBox.Show(
                                "Erreur lors de l'enregistrement de la demande et de la facturation.\n\n" +
                                ex.Message,
                                "Erreur",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur de connexion à la base de données.\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        // =========================================================
        // MODIFIER UNE DEMANDE
        // =========================================================

        private void ModifierDemande(
            int idDemande,
            int idService,
            int? idPrestation,
            string priorite,
            string motif,
            string observation)
        {
            try
            {
                Database db = new Database();

                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"
                UPDATE demande_service
                SET
                    id_service = @id_service,
                    id_prestation = @id_prestation,
                    priorite = @priorite,
                    motif = @motif,
                    observation = @observation
                WHERE id_demande = @id_demande
                  AND id_patient = @id_patient
                  AND statut IN (
                      'Demandée',
                      'En attente',
                      'Acceptée',
                      'En cours'
                  )";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_demande",
                            idDemande);

                        cmd.Parameters.AddWithValue(
                            "@id_patient",
                            Form1.PATIENT_ID);

                        cmd.Parameters.AddWithValue(
                            "@id_service",
                            idService);

                        if (idPrestation.HasValue)
                        {
                            cmd.Parameters.AddWithValue(
                                "@id_prestation",
                                idPrestation.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(
                                "@id_prestation",
                                DBNull.Value);
                        }

                        cmd.Parameters.AddWithValue(
                            "@priorite",
                            priorite);

                        cmd.Parameters.AddWithValue(
                            "@motif",
                            motif);

                        if (string.IsNullOrWhiteSpace(observation))
                        {
                            cmd.Parameters.AddWithValue(
                                "@observation",
                                DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(
                                "@observation",
                                observation);
                        }

                        int lignes =
                            cmd.ExecuteNonQuery();

                        if (lignes == 0)
                        {
                            MessageBox.Show(
                                "La demande n'existe plus ou son statut ne permet plus sa modification.",
                                "Modification",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }

                        MessageBox.Show(
                            "La demande a été modifiée avec succès.",
                            "Modification",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        Form1.DEMANDE_ID = 0;

                        DialogResult =
                            DialogResult.OK;

                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la modification de la demande.\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // ANNULER UNE DEMANDE
        // =========================================================

        private void AnnulerDemande(
            int idDemande)
        {
            DialogResult choix =
                MessageBox.Show(
                    "La demande sera annulée.\n\n" +
                    "Voulez-vous vraiment annuler cette demande ?",
                    "Annuler la demande",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (choix != DialogResult.Yes)
            {
                return;
            }


            try
            {
                Database db = new Database();

                using (MySqlConnection con =
                    db.GetConnection())
                {
                    con.Open();

                    string query = @"
                        UPDATE demande_service
                        SET statut = 'Annulée'
                        WHERE id_demande = @id_demande
                          AND id_patient = @id_patient
                          AND statut = 'Demandée'";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_demande",
                            idDemande);

                        cmd.Parameters.AddWithValue(
                            "@id_patient",
                            Form1.PATIENT_ID);

                        int lignes =
                            cmd.ExecuteNonQuery();

                        if (lignes > 0)
                        {
                            MessageBox.Show(
                                "La demande a été annulée.",
                                "Demande de service",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            Form1.DEMANDE_ID = 0;

                            DialogResult =
                                DialogResult.Cancel;

                            Close();
                        }
                        else
                        {
                            MessageBox.Show(
                                "La demande n'existe pas ou " +
                                "n'est plus en attente.",
                                "Demande de service",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'annulation " +
                    "de la demande.\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // BOUTON ANNULER
        // =========================================================

        private void btn_cancel_Click(
            object sender,
            EventArgs e)
        {
            if (Form1.DEMANDE_ID != 0)
            {
                AnnulerDemande(
                    Form1.DEMANDE_ID);

                return;
            }

            DialogResult =
                DialogResult.Cancel;

            Close();
        }


        // =========================================================
        // AJOUTER UNE PRESTATION À LA FACTURE
        // =========================================================

        private void AjouterPrestationFacture(
            int idFacture,
            int idPrestation,
            int quantite,
            DateTime date,
            MySqlConnection con,
            MySqlTransaction tr)
        {
            decimal prix = 0;


            // -----------------------------------------------------
            // Récupérer le tarif actif
            // -----------------------------------------------------

            string queryPrix = @"
                SELECT prix
                FROM tarif_prestation
                WHERE id_prestation = @id_prestation
                  AND actif = 1
                  AND date_debut <= @date
                  AND (
                        date_fin IS NULL
                        OR date_fin >= @date
                      )
                ORDER BY date_debut DESC
                LIMIT 1";

            using (MySqlCommand cmd =
                new MySqlCommand(
                    queryPrix,
                    con,
                    tr))
            {
                cmd.Parameters.AddWithValue(
                    "@id_prestation",
                    idPrestation);

                cmd.Parameters.AddWithValue(
                    "@date",
                    date.Date);

                object resultat =
                    cmd.ExecuteScalar();

                if (resultat == null ||
                    resultat == DBNull.Value)
                {
                    throw new Exception(
                        "Aucun tarif actif n'est défini " +
                        "pour cette prestation.");
                }

                prix =
                    Convert.ToDecimal(resultat);
            }


            decimal montant =
                prix * quantite;


            // -----------------------------------------------------
            // Vérifier si la prestation existe déjà
            // -----------------------------------------------------

            string queryExiste = @"
                SELECT id_detail_facture
                FROM detail_facture
                WHERE id_facture = @id_facture
                  AND id_prestation = @id_prestation
                LIMIT 1";

            object idDetail;

            using (MySqlCommand cmd =
                new MySqlCommand(
                    queryExiste,
                    con,
                    tr))
            {
                cmd.Parameters.AddWithValue(
                    "@id_facture",
                    idFacture);

                cmd.Parameters.AddWithValue(
                    "@id_prestation",
                    idPrestation);

                idDetail =
                    cmd.ExecuteScalar();
            }


            // -----------------------------------------------------
            // Mise à jour
            // -----------------------------------------------------

            if (idDetail != null &&
                idDetail != DBNull.Value)
            {
                string update = @"
                    UPDATE detail_facture
                    SET
                        quantite = @quantite,
                        prix_unitaire = @prix,
                        montant = @montant
                    WHERE id_detail_facture = @id_detail";

                using (MySqlCommand cmd =
                    new MySqlCommand(
                        update,
                        con,
                        tr))
                {
                    cmd.Parameters.AddWithValue(
                        "@quantite",
                        quantite);

                    cmd.Parameters.AddWithValue(
                        "@prix",
                        prix);

                    cmd.Parameters.AddWithValue(
                        "@montant",
                        montant);

                    cmd.Parameters.AddWithValue(
                        "@id_detail",
                        Convert.ToInt32(idDetail));

                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                // -------------------------------------------------
                // Insertion
                // -------------------------------------------------

                string insert = @"
                    INSERT INTO detail_facture
                    (
                        id_facture,
                        id_prestation,
                        description,
                        quantite,
                        prix_unitaire,
                        montant
                    )
                    SELECT
                        @id_facture,
                        p.id_prestation,
                        p.libelle,
                        @quantite,
                        @prix,
                        @montant
                    FROM prestation p
                    WHERE p.id_prestation =
                          @id_prestation";

                using (MySqlCommand cmd =
                    new MySqlCommand(
                        insert,
                        con,
                        tr))
                {
                    cmd.Parameters.AddWithValue(
                        "@id_facture",
                        idFacture);

                    cmd.Parameters.AddWithValue(
                        "@id_prestation",
                        idPrestation);

                    cmd.Parameters.AddWithValue(
                        "@quantite",
                        quantite);

                    cmd.Parameters.AddWithValue(
                        "@prix",
                        prix);

                    cmd.Parameters.AddWithValue(
                        "@montant",
                        montant);

                    int lignes =
                        cmd.ExecuteNonQuery();

                    if (lignes <= 0)
                    {
                        throw new Exception(
                            "La prestation sélectionnée " +
                            "n'existe pas.");
                    }
                }
            }


            // -----------------------------------------------------
            // Recalculer la facture
            // -----------------------------------------------------

            RecalculerFacture(
                idFacture,
                con,
                tr);
        }


        // =========================================================
        // RECALCULER LE TOTAL DE LA FACTURE
        // =========================================================

        private void RecalculerFacture(
            int idFacture,
            MySqlConnection con,
            MySqlTransaction tr)
        {
            decimal total = 0;

            string query = @"
                SELECT
                    IFNULL(
                        SUM(montant),
                        0
                    )
                FROM detail_facture
                WHERE id_facture = @id";

            using (MySqlCommand cmd =
                new MySqlCommand(
                    query,
                    con,
                    tr))
            {
                cmd.Parameters.AddWithValue(
                    "@id",
                    idFacture);

                total =
                    Convert.ToDecimal(
                        cmd.ExecuteScalar());
            }


            string update = @"
                UPDATE facture
                SET
                    montant_total = @total,
                    montant_paye = COALESCE((
                        SELECT SUM(p.montant)
                        FROM paiement p
                        WHERE p.id_facture = @id
                    ), 0),
                    reste = GREATEST(
                        @total - COALESCE((
                            SELECT SUM(p2.montant)
                            FROM paiement p2
                            WHERE p2.id_facture = @id
                        ), 0),
                        0
                    ),
                    statut = CASE
                        WHEN COALESCE((SELECT SUM(p3.montant) FROM paiement p3 WHERE p3.id_facture = @id), 0) <= 0
                            THEN 'Non payé'
                        WHEN COALESCE((SELECT SUM(p4.montant) FROM paiement p4 WHERE p4.id_facture = @id), 0) < @total
                            THEN 'Partiellement payé'
                        ELSE 'Payé'
                    END
                WHERE id_facture = @id";

            using (MySqlCommand cmd =
                new MySqlCommand(
                    update,
                    con,
                    tr))
            {
                cmd.Parameters.AddWithValue(
                    "@total",
                    total);

                cmd.Parameters.AddWithValue(
                    "@id",
                    idFacture);

                cmd.ExecuteNonQuery();
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
            // -----------------------------------------------------
            // Chercher une facture ouverte
            // -----------------------------------------------------

            string query = @"
                SELECT
                    id_facture
                FROM facture
                WHERE id_patient = @idPatient
                  AND (statut IS NULL OR statut <> 'Clôturée')
                ORDER BY id_facture DESC
                LIMIT 1";

            using (MySqlCommand cmd =
                new MySqlCommand(
                    query,
                    con,
                    tr))
            {
                cmd.Parameters.AddWithValue(
                    "@idPatient",
                    idPatient);

                object result =
                    cmd.ExecuteScalar();

                if (result != null &&
                    result != DBNull.Value)
                {
                    return Convert.ToInt32(
                        result);
                }
            }


            // -----------------------------------------------------
            // Créer une nouvelle facture
            // -----------------------------------------------------

            int idFacture = 0;

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
                new MySqlCommand(
                    insert,
                    con,
                    tr))
            {
                cmd.Parameters.AddWithValue(
                    "@patient",
                    idPatient);

                cmd.Parameters.AddWithValue(
                    "@centre",
                    MesForms.SessionUtilisateur.idCentre);

                cmd.ExecuteNonQuery();

                idFacture =
                    Convert.ToInt32(
                        cmd.LastInsertedId);
            }

            return idFacture;
        }
    }
}