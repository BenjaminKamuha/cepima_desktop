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

        // Empêche cbx_service_SelectedIndexChanged de travailler
        // pendant le chargement ou la modification d'une demande.
        private bool initialisationService = false;


        // =========================================================
        // CONSTRUCTEUR
        // =========================================================

        public Form_demander_service()
        {
            InitializeComponent();

            Configurer();

            ChargerPatients();
            ChargerServices();
            ChargerConsultations(Form1.PATIENT_ID);

            // -----------------------------------------------------
            // MODE MODIFICATION
            // -----------------------------------------------------

            if (Form1.DEMANDE_ID != 0)
            {
                btn_send_request.Text = "Modifier";

                ChargerDemande(Form1.DEMANDE_ID);
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

            cbx_consultation.DropDownStyle =
                ComboBoxStyle.DropDownList;

            // -----------------------------------------------------
            // IMPORTANT
            // -----------------------------------------------------
            // Si ces événements sont déjà associés dans le Designer,
            // NE PAS les associer une deuxième fois dans le Designer.
            //
            // Ici ils sont associés par le code.
            // -----------------------------------------------------

            btn_send_request.Click -= btn_send_request_Click;
            btn_send_request.Click += btn_send_request_Click;

            btn_cancel.Click -= btn_cancel_Click;
            btn_cancel.Click += btn_cancel_Click;

            cbx_service.SelectedIndexChanged -=
                cbx_service_SelectedIndexChanged;

            cbx_service.SelectedIndexChanged +=
                cbx_service_SelectedIndexChanged;

            initialisationService = true;

            try
            {
                cbx_service.SelectedIndex = -1;
                cbx_consultation.SelectedIndex = -1;
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

                                if (reader["date_naissance"] != DBNull.Value)
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

                using (MySqlConnection con = db.GetConnection())
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
                                cbx_service.DataSource = null;

                                cbx_service.DisplayMember =
                                    "nom";

                                cbx_service.ValueMember =
                                    "id_service";

                                cbx_service.DataSource = dt;

                                cbx_service.SelectedIndex = -1;
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
        // CHARGER LES CONSULTATIONS DU PATIENT
        // =========================================================

        private void ChargerConsultations(int patientId)
        {
            try
            {
                Database db = new Database();

                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"
                        SELECT
                            id,
                            DATE_FORMAT(
                                date_consultation,
                                '%d/%m/%Y %H:%i'
                            ) AS consultation
                        FROM consultation
                        WHERE patient_id = @patient_id
                        ORDER BY date_consultation DESC";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@patient_id",
                            patientId);

                        using (MySqlDataAdapter adapter =
                            new MySqlDataAdapter(cmd))
                        {
                            DataTable dt =
                                new DataTable();

                            adapter.Fill(dt);

                            initialisationService = true;

                            try
                            {
                                cbx_consultation.DataSource = null;

                                cbx_consultation.DisplayMember =
                                    "consultation";

                                cbx_consultation.ValueMember =
                                    "id";

                                cbx_consultation.DataSource = dt;

                                cbx_consultation.SelectedIndex = -1;
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
                    "Erreur lors du chargement des consultations.\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // CHARGER UNE DEMANDE EXISTANTE
        // =========================================================

        private void ChargerDemande(int idDemande)
        {
            try
            {
                Database db = new Database();

                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"
                        SELECT
                            id_service,
                            id_consultation,
                            priorite,
                            motif,
                            observation
                        FROM demande_service
                        WHERE id_demande = @id_demande
                          AND id_patient = @id_patient
                          AND statut = 'Demandée'
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

                            // -------------------------------------------------
                            // IMPORTANT :
                            // On bloque l'événement SelectedIndexChanged
                            // pendant le remplissage des contrôles.
                            // -------------------------------------------------

                            initialisationService = true;

                            try
                            {
                                // ---------------------------------------------
                                // SERVICE
                                // ---------------------------------------------

                                if (reader["id_service"] != DBNull.Value)
                                {
                                    cbx_service.SelectedValue =
                                        Convert.ToInt32(
                                            reader["id_service"]);
                                }
                                else
                                {
                                    cbx_service.SelectedIndex = -1;
                                }


                                // ---------------------------------------------
                                // CONSULTATION
                                // ---------------------------------------------

                                if (reader["id_consultation"] !=
                                    DBNull.Value)
                                {
                                    cbx_consultation.SelectedValue =
                                        Convert.ToInt32(
                                            reader["id_consultation"]);
                                }
                                else
                                {
                                    cbx_consultation.SelectedIndex = -1;
                                }


                                // ---------------------------------------------
                                // PRIORITE
                                // ---------------------------------------------

                                string priorite =
                                    reader["priorite"] == DBNull.Value
                                        ? "Normale"
                                        : reader["priorite"].ToString();

                                if (priorite == "Urgente")
                                {
                                    rd_priorite_urgente.Checked = true;
                                    rd_priorite_normal.Checked = false;
                                }
                                else
                                {
                                    rd_priorite_normal.Checked = true;
                                    rd_priorite_urgente.Checked = false;
                                }


                                // ---------------------------------------------
                                // MOTIF
                                // ---------------------------------------------

                                tb_indicateur.Text =
                                    reader["motif"] == DBNull.Value
                                        ? ""
                                        : reader["motif"].ToString();


                                // ---------------------------------------------
                                // OBSERVATION
                                // ---------------------------------------------

                                tb_observation.Text =
                                    reader["observation"] == DBNull.Value
                                        ? ""
                                        : reader["observation"].ToString();
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
                        SELECT
                            id_demande
                        FROM demande_service
                        WHERE id_patient = @id_patient
                          AND id_service = @id_service
                          AND statut = 'Demandée'
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
                    "Erreur lors de la vérification de la demande.\n\n" +
                    ex.Message,
                    "Demande de service",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return 0;
        }


        // =========================================================
        // VERIFIER SI UN SERVICE EST DEJA UTILISE PAR UNE AUTRE
        // DEMANDE
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
                        SELECT
                            id_demande
                        FROM demande_service
                        WHERE id_patient = @id_patient
                          AND id_service = @id_service
                          AND statut = 'Demandée'
                          AND id_demande <> @id_demande
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
                    "Erreur lors de la vérification du service.\n\n" +
                    ex.Message,
                    "Demande de service",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return 0;
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
        // ENREGISTRER OU MODIFIER
        // =========================================================

        private void EnregistrerDemande()
        {
            // -----------------------------------------------------
            // VERIFICATION DU SERVICE
            // -----------------------------------------------------

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


            // -----------------------------------------------------
            // VERIFICATION DU MOTIF
            // -----------------------------------------------------

            if (string.IsNullOrWhiteSpace(
                tb_indicateur.Text))
            {
                MessageBox.Show(
                    "Veuillez saisir le motif de la demande.",
                    "Demande de service",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_indicateur.Focus();

                return;
            }


            // -----------------------------------------------------
            // RECUPERATION DU SERVICE
            // -----------------------------------------------------

            int idService;

            try
            {
                idService =
                    Convert.ToInt32(
                        cbx_service.SelectedValue);
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


            // -----------------------------------------------------
            // RECUPERATION CONSULTATION
            // -----------------------------------------------------

            int? idConsultation = null;

            if (cbx_consultation.SelectedIndex >= 0 &&
                cbx_consultation.SelectedValue != null)
            {
                try
                {
                    idConsultation =
                        Convert.ToInt32(
                            cbx_consultation.SelectedValue);
                }
                catch
                {
                    idConsultation = null;
                }
            }


            // -----------------------------------------------------
            // PRIORITE
            // -----------------------------------------------------

            string priorite =
                rd_priorite_normal.Checked
                    ? "Normale"
                    : "Urgente";


            // -----------------------------------------------------
            // MOTIF
            // -----------------------------------------------------

            string motif =
                tb_indicateur.Text.Trim();


            // -----------------------------------------------------
            // OBSERVATION
            // -----------------------------------------------------

            string observation = null;

            if (!string.IsNullOrWhiteSpace(
                tb_observation.Text))
            {
                observation =
                    tb_observation.Text.Trim();
            }


            // =====================================================
            // MODE MODIFICATION
            // =====================================================

            if (Form1.DEMANDE_ID != 0)
            {
                ModifierDemande(
                    Form1.DEMANDE_ID,
                    idService,
                    idConsultation,
                    priorite,
                    motif,
                    observation);

                return;
            }


            // =====================================================
            // MODE NOUVELLE DEMANDE
            // =====================================================

            int demandeExistante =
                VerifierDemandeExistante(
                    Form1.PATIENT_ID,
                    idService);


            if (demandeExistante > 0)
            {
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
                    // On passe directement en mode modification.
                    Form1.DEMANDE_ID =
                        demandeExistante;

                    btn_send_request.Text =
                        "Modifier";

                    ChargerDemande(
                        demandeExistante);

                    return;
                }

                // -------------------------------------------------
                // L'utilisateur a choisi NON.
                //
                // On ne fait rien d'autre.
                // La demande existante reste intacte.
                // -------------------------------------------------

                return;
            }


            // =====================================================
            // INSERTION
            // =====================================================

            try
            {
                Database db = new Database();

                using (MySqlConnection con =
                    db.GetConnection())
                {
                    con.Open();

                    string query = @"
                        INSERT INTO demande_service
                        (
                            id_patient,
                            id_service,
                            id_consultation,
                            id_personnel,
                            date_demande,
                            priorite,
                            motif,
                            observation
                        )
                        VALUES
                        (
                            @id_patient,
                            @id_service,
                            @id_consultation,
                            @id_personnel,
                            NOW(),
                            @priorite,
                            @motif,
                            @observation
                        )";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_patient",
                            Form1.PATIENT_ID);

                        cmd.Parameters.AddWithValue(
                            "@id_service",
                            idService);


                        if (idConsultation.HasValue)
                        {
                            cmd.Parameters.AddWithValue(
                                "@id_consultation",
                                idConsultation.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(
                                "@id_consultation",
                                DBNull.Value);
                        }


                        // Pour le moment aucun personnel
                        // n'est associé automatiquement.
                        cmd.Parameters.AddWithValue(
                            "@id_personnel",
                            DBNull.Value);


                        cmd.Parameters.AddWithValue(
                            "@priorite",
                            priorite);


                        cmd.Parameters.AddWithValue(
                            "@motif",
                            motif);


                        if (observation == null)
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

                        if (lignes > 0)
                        {
                            MessageBox.Show(
                                "La demande de service a été " +
                                "enregistrée avec succès.",
                                "Demande de service",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            // Très important :
                            // on sort du mode modification.
                            Form1.DEMANDE_ID = 0;

                            DialogResult =
                                DialogResult.OK;

                            Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'enregistrement de la demande.\n\n" +
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
            int? idConsultation,
            string priorite,
            string motif,
            string observation)
        {
            // -----------------------------------------------------
            // VERIFIER SI LE NOUVEAU SERVICE EST DEJA UTILISE
            // PAR UNE AUTRE DEMANDE DU MEME PATIENT
            // -----------------------------------------------------

            int autreDemande =
                VerifierAutreDemandeExistante(
                    Form1.PATIENT_ID,
                    idService,
                    idDemande);


            if (autreDemande > 0)
            {
                MessageBox.Show(
                    "Ce patient possède déjà une autre demande " +
                    "en attente pour ce service.\n\n" +
                    "Vous ne pouvez pas utiliser ce service " +
                    "pour cette demande.",
                    "Service déjà demandé",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // =====================================================
            // UPDATE
            // =====================================================

            try
            {
                Database db = new Database();

                using (MySqlConnection con =
                    db.GetConnection())
                {
                    con.Open();

                    string query = @"
                        UPDATE demande_service
                        SET
                            id_service = @id_service,
                            id_consultation = @id_consultation,
                            priorite = @priorite,
                            motif = @motif,
                            observation = @observation
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

                        cmd.Parameters.AddWithValue(
                            "@id_service",
                            idService);


                        if (idConsultation.HasValue)
                        {
                            cmd.Parameters.AddWithValue(
                                "@id_consultation",
                                idConsultation.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(
                                "@id_consultation",
                                DBNull.Value);
                        }


                        cmd.Parameters.AddWithValue(
                            "@priorite",
                            priorite);


                        cmd.Parameters.AddWithValue(
                            "@motif",
                            motif);


                        if (observation == null)
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


                        if (lignes > 0)
                        {
                            MessageBox.Show(
                                "La demande a été modifiée " +
                                "avec succès.",
                                "Demande de service",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            // Très important :
                            // la demande n'est plus en mode modification.
                            Form1.DEMANDE_ID = 0;

                            DialogResult =
                                DialogResult.OK;

                            Close();
                        }
                        else
                        {
                            MessageBox.Show(
                                "La demande n'existe plus ou " +
                                "elle n'est plus modifiable.",
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
                    "Erreur lors de la modification de la demande.\n\n" +
                    ex.Message,
                    "Demande de service",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // ANNULER UNE DEMANDE
        // =========================================================

        private void AnnulerDemande(int idDemande)
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
                    "Erreur lors de l'annulation de la demande.\n\n" +
                    ex.Message,
                    "Demande de service",
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
                int idDemande =
                    Form1.DEMANDE_ID;

                AnnulerDemande(idDemande);

                return;
            }


            DialogResult =
                DialogResult.Cancel;

            Close();
        }


        // =========================================================
        // CHANGEMENT DE SERVICE
        // =========================================================

        private void cbx_service_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            // -----------------------------------------------------
            // 1. Le formulaire est en train de charger/modifier
            // -----------------------------------------------------

            if (initialisationService)
            {
                return;
            }


            // -----------------------------------------------------
            // 2. Aucun service sélectionné
            // -----------------------------------------------------

            if (cbx_service.SelectedIndex < 0)
            {
                return;
            }


            // -----------------------------------------------------
            // 3. Valeur temporaire DataRowView pendant le chargement
            // -----------------------------------------------------

            if (cbx_service.SelectedValue == null)
            {
                return;
            }

            if (cbx_service.SelectedValue is DataRowView)
            {
                return;
            }


            // -----------------------------------------------------
            // 4. Recuperer l'ID du service
            // -----------------------------------------------------

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
            // CAS 1 :
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
                    // -------------------------------------------------
                    // On passe en mode modification.
                    // -------------------------------------------------

                    Form1.DEMANDE_ID =
                        idDemande;

                    btn_send_request.Text =
                        "Modifier";

                    ChargerDemande(
                        idDemande);

                    return;
                }


                // -----------------------------------------------------
                // L'utilisateur a répondu NON.
                //
                // On désélectionne le service.
                //
                // IMPORTANT :
                // initialisationService empêche SelectedIndexChanged
                // de relancer la vérification.
                // -----------------------------------------------------

                initialisationService = true;

                try
                {
                    cbx_service.SelectedIndex = -1;
                }
                finally
                {
                    initialisationService = false;
                }

                return;
            }


            // =====================================================
            // CAS 2 :
            // MODIFICATION D'UNE DEMANDE
            // =====================================================

            int demandeActuelle =
                Form1.DEMANDE_ID;


            // -----------------------------------------------------
            // Vérifier si le nouveau service appartient déjà
            // à une autre demande du même patient.
            // -----------------------------------------------------

            int autreDemande =
                VerifierAutreDemandeExistante(
                    Form1.PATIENT_ID,
                    idService,
                    demandeActuelle);


            if (autreDemande <= 0)
            {
                // Aucun conflit.
                return;
            }


            // -----------------------------------------------------
            // Il existe déjà une autre demande pour ce service.
            // -----------------------------------------------------

            MessageBox.Show(
                "Ce patient possède déjà une autre demande " +
                "en attente pour ce service.\n\n" +
                "Vous ne pouvez pas sélectionner ce service.",
                "Service déjà demandé",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);


            // -----------------------------------------------------
            // Recharger l'ancien service de la demande actuelle.
            // -----------------------------------------------------

            ChargerServiceDemandeActuelle(
                demandeActuelle);
        }


        // =========================================================
        // RESTAURER LE SERVICE ACTUEL APRES UN CONFLIT
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
                        SELECT id_service
                        FROM demande_service
                        WHERE id_demande = @id_demande
                          AND id_patient = @id_patient
                          AND statut = 'Demandée'
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

                        object resultat =
                            cmd.ExecuteScalar();

                        if (resultat != null &&
                            resultat != DBNull.Value)
                        {
                            int ancienService =
                                Convert.ToInt32(resultat);

                            initialisationService = true;

                            try
                            {
                                cbx_service.SelectedValue =
                                    ancienService;
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
                initialisationService = false;

                MessageBox.Show(
                    "Erreur lors du rétablissement du service.\n\n" +
                    ex.Message,
                    "Demande de service",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}