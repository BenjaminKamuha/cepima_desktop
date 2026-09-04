using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using Cepima.Data;
using Cepima.MesUserCases.EEG;

namespace Cepima.MesForms.Pharmacie
{
    public partial class Form_new_eeg : Form
    {
        private Database db = new Database();

        // Fichier EEG sélectionné sur l'ordinateur
        private string fichierEEGSelectionne = "";

        public Form_new_eeg()
        {
            InitializeComponent();

            ChargerPatients();
            ChargerTypesEEG();

            dtp_eeg.Value = DateTime.Now;

            rd_eveil.Checked = true;

            btn_import_file.Click += btnImporterFichier_Click;
            btn_save.Click += btn_save_Click;
            btn_cancel.Click += btn_cancel_Click;
        }

        // ============================================================
        // ENREGISTREMENT DE L'EEG
        // ============================================================

        private void btn_save_Click(object sender, EventArgs e)
        {
            EnregistrerEEG();
        }

        private void EnregistrerEEG()
        {
            int idPatient = Form1.PATIENT_ID;
            int idDemande = Form1.DEMANDE_ID;

            // --------------------------------------------------------
            // Vérification du patient
            // --------------------------------------------------------

            if (idPatient <= 0)
            {
                MessageBox.Show(
                    "Aucun patient n'est sélectionné.",
                    "EEG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // --------------------------------------------------------
            // Vérification de la demande
            // --------------------------------------------------------

            if (idDemande <= 0)
            {
                MessageBox.Show(
                    "Aucune demande EEG n'est associée à cet examen.",
                    "EEG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // --------------------------------------------------------
            // Vérification du type EEG
            // --------------------------------------------------------

            if (cbx_type_eeg.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Veuillez sélectionner le type d'EEG.",
                    "EEG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cbx_type_eeg.Focus();

                return;
            }


            MySqlConnection con = null;
            MySqlTransaction transaction = null;

            try
            {
                con = db.GetConnection();
                con.Open();

                transaction = con.BeginTransaction();

                // ====================================================
                // 1. Vérifier que la demande existe
                // ====================================================

                string queryDemande = @"
                    SELECT
                        ds.id_patient,
                        ds.id_service,
                        ds.statut,
                        s.nom
                    FROM demande_service ds
                    INNER JOIN service s
                        ON s.id_service = ds.id_service
                    WHERE ds.id_demande = @id_demande
                    LIMIT 1";

                int patientDemande = 0;
                int serviceDemande = 0;
                string statutDemande = "";
                string nomService = "";

                using (MySqlCommand cmd = new MySqlCommand(queryDemande, con, transaction))
                {
                    cmd.Parameters.AddWithValue("@id_demande", idDemande);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            reader.Close();

                            throw new Exception(
                                "La demande de service n'existe plus.");
                        }

                        patientDemande = Convert.ToInt32(
                            reader["id_patient"]);

                        serviceDemande = Convert.ToInt32(
                            reader["id_service"]);

                        statutDemande =
                            reader["statut"].ToString();

                        nomService =
                            reader["nom"].ToString();
                    }
                }

                // ====================================================
                // 2. Vérifier que la demande appartient au patient
                // ====================================================

                if (patientDemande != idPatient)
                {
                    throw new Exception(
                        "La demande EEG ne correspond pas au patient sélectionné.");
                }

                // ====================================================
                // 3. Vérifier que le service est bien EEG
                // ====================================================

                if (nomService != "EEG")
                {
                    throw new Exception(
                        "Cette demande n'est pas une demande EEG.");
                }

                // ====================================================
                // 4. Vérifier le statut de la demande
                // ====================================================

                if (statutDemande == "Annulée")
                {
                    throw new Exception(
                        "Cette demande EEG a été annulée.");
                }

                if (statutDemande == "Terminée")
                {
                    throw new Exception(
                        "Cette demande EEG est déjà terminée.");
                }

                // ====================================================
                // 5. Vérifier qu'il n'existe pas déjà un examen
                //    pour cette demande
                // ====================================================

                string queryExiste = @"
                    SELECT id_examens
                    FROM examens_eeg
                    WHERE id_demande = @id_demande
                    LIMIT 1";

                int idExamenExistant = 0;

                using (MySqlCommand cmd = new MySqlCommand(
                    queryExiste,
                    con,
                    transaction))
                {
                    cmd.Parameters.AddWithValue(
                        "@id_demande",
                        idDemande);

                    object resultat = cmd.ExecuteScalar();

                    if (resultat != null &&
                        resultat != DBNull.Value)
                    {
                        idExamenExistant =
                            Convert.ToInt32(resultat);
                    }
                }

                if (idExamenExistant > 0)
                {
                    throw new Exception(
                        "Un examen EEG existe déjà pour cette demande.");
                }

                // ====================================================
                // 6. Informations du fichier EEG
                // ====================================================

                string nomFichier = ObtenirNomFichier();
                string extensionFichier = ObtenirExtensionFichier();
                long tailleFichier = ObtenirTailleFichier();

                string cheminFichier = null;

                // ====================================================
                // 7. Copier le fichier EEG
                // ====================================================

                if (!string.IsNullOrEmpty(fichierEEGSelectionne))
                {
                    string dossierEEG = Path.Combine(
                        Application.StartupPath,
                        "FichiersEEG");

                    if (!Directory.Exists(dossierEEG))
                    {
                        Directory.CreateDirectory(dossierEEG);
                    }

                    string nomUnique =
                        idPatient.ToString() +
                        "_" +
                        DateTime.Now.ToString("yyyyMMddHHmmss") +
                        "_" +
                        Path.GetFileName(
                            fichierEEGSelectionne);

                    cheminFichier = Path.Combine(
                        dossierEEG,
                        nomUnique);

                    File.Copy(
                        fichierEEGSelectionne,
                        cheminFichier,
                        false);
                }

                // ====================================================
                // 8. Insérer l'examen EEG
                // ====================================================

                string queryExamen = @"
                    INSERT INTO examens_eeg
                    (
                        id_demande,
                        id_patient,
                        id_consultation,
                        date_examen,
                        type_EEG,
                        indication,
                        etat_patient,
                        privation_sommeil,
                        duree_enregistrement,
                        medicaments_avant_examen,
                        prix_examen,
                        resultat,
                        statut,
                        interpretation,
                        observations,
                        nom_fichier,
                        chemin_fichier,
                        extension_fichier,
                        taille_fichier
                    )
                    SELECT
                        @id_demande,
                        @id_patient,
                        ds.id_consultation,
                        @date_examen,
                        @type_EEG,
                        @indication,
                        @etat_patient,
                        0,
                        NULL,
                        NULL,
                        NULL,
                        NULL,
                        'En cours',
                        NULL,
                        @observations,
                        @nom_fichier,
                        @chemin_fichier,
                        @extension_fichier,
                        @taille_fichier
                    FROM demande_service ds
                    WHERE ds.id_demande = @id_demande";

                using (MySqlCommand cmd = new MySqlCommand(
                    queryExamen,
                    con,
                    transaction))
                {
                    cmd.Parameters.AddWithValue(
                        "@id_demande",
                        idDemande);

                    cmd.Parameters.AddWithValue(
                        "@id_patient",
                        idPatient);

                    cmd.Parameters.AddWithValue(
                        "@date_examen",
                        dtp_eeg.Value.Date);

                    cmd.Parameters.AddWithValue(
                        "@type_EEG",
                        cbx_type_eeg.SelectedItem.ToString());

                    cmd.Parameters.AddWithValue(
                        "@indication",
                        tb_indicateur.Text.Trim());

                    cmd.Parameters.AddWithValue(
                        "@etat_patient",
                        ObtenirEtatPatient());

                    cmd.Parameters.AddWithValue(
                        "@observations",
                        string.IsNullOrWhiteSpace(
                            tb_observation.Text)
                            ? (object)DBNull.Value
                            : tb_observation.Text.Trim());

                    cmd.Parameters.AddWithValue(
                        "@nom_fichier",
                        string.IsNullOrEmpty(nomFichier)
                            ? (object)DBNull.Value
                            : nomFichier);

                    cmd.Parameters.AddWithValue(
                        "@chemin_fichier",
                        string.IsNullOrEmpty(cheminFichier)
                            ? (object)DBNull.Value
                            : cheminFichier);

                    cmd.Parameters.AddWithValue(
                        "@extension_fichier",
                        string.IsNullOrEmpty(extensionFichier)
                            ? (object)DBNull.Value
                            : extensionFichier);

                    cmd.Parameters.AddWithValue(
                        "@taille_fichier",
                        tailleFichier > 0
                            ? (object)tailleFichier
                            : DBNull.Value);

                    int lignes = cmd.ExecuteNonQuery();

                    if (lignes <= 0)
                    {
                        throw new Exception(
                            "L'examen EEG n'a pas pu être enregistré.");
                    }
                }

                // ====================================================
                // 9. Mettre la demande à "En cours"
                // ====================================================

                string queryStatut = @"
                    UPDATE demande_service
                    SET statut = 'En cours'
                    WHERE id_demande = @id_demande
                    AND statut <> 'Terminée'
                    AND statut <> 'Annulée'";

                using (MySqlCommand cmd = new MySqlCommand(
                    queryStatut,
                    con,
                    transaction))
                {
                    cmd.Parameters.AddWithValue(
                        "@id_demande",
                        idDemande);

                    cmd.ExecuteNonQuery();
                }

                // ====================================================
                // 10. Valider toute la transaction
                // ====================================================

                transaction.Commit();

                MessageBox.Show(
                    "L'examen EEG a été enregistré avec succès.",
                    "EEG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // On réinitialise les IDs globaux
                Form1.DEMANDE_ID = 0;
                Form1.PATIENT_ID = 0;

                // Fermer le formulaire
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // ----------------------------------------------------
                // Annuler la transaction
                // ----------------------------------------------------

                try
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                }
                catch
                {
                }

                MessageBox.Show(
                    "Erreur lors de l'enregistrement de l'EEG :\n\n" +
                    ex.Message,
                    "EEG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        // ============================================================
        // CHARGER LE PATIENT
        // ============================================================

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
                            YEAR(date_naissance) AS annee_naissance,
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
                        WHERE id_patient = @id_p";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_p",
                            ObtenirIdPatient());

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int anneeNaissance =
                                    Convert.ToInt32(
                                        reader["annee_naissance"]
                                        .ToString());

                                int age =
                                    DateTime.Now.Date.Year -
                                    anneeNaissance;

                                lb_nom_patient.Text =
                                    reader["patient"].ToString();

                                lb_sexe_age.Text =
                                    reader["sexe"].ToString() +
                                    "-" +
                                    age.ToString() +
                                    " ans";

                                lb_num_fiche.Text =
                                    reader["numero_fiche"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du patient :\n" +
                    ex.Message,
                    "EEG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // CHARGER LES TYPES EEG
        // ============================================================

        private void ChargerTypesEEG()
        {
            cbx_type_eeg.Items.Clear();

            cbx_type_eeg.Items.Add("18_cannaux");
            cbx_type_eeg.Items.Add("32_cannaux");

            cbx_type_eeg.SelectedIndex = 0;
        }

        // ============================================================
        // OBTENIR L'ID PATIENT
        // ============================================================

        private int ObtenirIdPatient()
        {
            return Form1.PATIENT_ID;
        }

        // ============================================================
        // IMPORTER LE FICHIER EEG
        // ============================================================

        private void btnImporterFichier_Click(
            object sender,
            EventArgs e)
        {
            using (OpenFileDialog dialog =
                new OpenFileDialog())
            {
                dialog.Title =
                    "Sélectionner le fichier EEG";

                dialog.Filter =
                    "Fichiers EEG (*.edf;*.edfz;*.bdf;*.set)|*.edf;*.edfz;*.bdf;*.set|" +
                    "Tous les fichiers (*.*)|*.*";

                dialog.Multiselect = false;

                if (dialog.ShowDialog() !=
                    DialogResult.OK)
                {
                    return;
                }

                fichierEEGSelectionne =
                    dialog.FileName;

                FileInfo fichier =
                    new FileInfo(
                        fichierEEGSelectionne);

                lb_fichier.Text =
                    fichier.Name;
            }
        }

        // ============================================================
        // NOM DU FICHIER
        // ============================================================

        private string ObtenirNomFichier()
        {
            if (string.IsNullOrEmpty(
                fichierEEGSelectionne))
            {
                return null;
            }

            return Path.GetFileName(
                fichierEEGSelectionne);
        }

        // ============================================================
        // EXTENSION DU FICHIER
        // ============================================================

        private string ObtenirExtensionFichier()
        {
            if (string.IsNullOrEmpty(
                fichierEEGSelectionne))
            {
                return null;
            }

            return Path.GetExtension(
                fichierEEGSelectionne);
        }

        // ============================================================
        // TAILLE DU FICHIER
        // ============================================================

        private long ObtenirTailleFichier()
        {
            if (string.IsNullOrEmpty(
                fichierEEGSelectionne))
            {
                return 0;
            }

            FileInfo fichier =
                new FileInfo(
                    fichierEEGSelectionne);

            return fichier.Length;
        }

        // ============================================================
        // ETAT DU PATIENT
        // ============================================================

        private string ObtenirEtatPatient()
        {
            if (rd_eveil.Checked)
            {
                return "Éveil";
            }

            if (rd_somnolence.Checked)
            {
                return "Somnolence";
            }

            if (rd_sommeil.Checked)
            {
                return "Sommeil";
            }

            return null;
        }

        // ============================================================
        // ANNULER
        // ============================================================

        private void btn_cancel_Click(
            object sender,
            EventArgs e)
        {
            Form1.DEMANDE_ID = 0;
            Form1.PATIENT_ID = 0;

            this.DialogResult =
                DialogResult.Cancel;

            this.Close();
        }
    }
}