using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Cepima.Data;

namespace Cepima.MesForms.EEG
{
    public partial class Form_realisation_eeg : Form
    {
        private Database db = new Database();

        private int idDemande = 0;
        private int idExamen = 0;

        private string cheminFichier = "";

        public Form_realisation_eeg()
        {
            InitializeComponent();

            idDemande = Form1.DEMANDE_ID;

            btn_save.Click += btn_save_Click;
            btn_open_file.Click += btn_open_file_Click;

            ChargerExamen();
        }

        // ============================================================
        // CHARGER L'EXAMEN EEG
        // ============================================================

        private void ChargerExamen()
        {
            if (idDemande <= 0)
            {
                MessageBox.Show(
                    "Aucune demande EEG sélectionnée.",
                    "EEG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();
                return;
            }

            try
            {
                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"
                        SELECT
                            e.id_examens,
                            e.id_patient,
                            e.id_demande,
                            e.date_examen,
                            e.type_EEG,
                            e.indication,
                            e.statut,
                            e.observations,
                            e.nom_fichier,
                            e.chemin_fichier,
                            e.extension_fichier,
                            e.taille_fichier,
                            p.nom,
                            p.post_nom,
                            p.prenom,
                            p.numero_fiche,
                            p.sexe,
                            p.date_naissance
                        FROM examens_eeg e
                        INNER JOIN patients p
                            ON p.id_patient = e.id_patient
                        WHERE e.id_demande = @id_demande
                        LIMIT 1";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_demande",
                            idDemande);

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "Aucun examen EEG trouvé pour cette demande.",
                                    "EEG",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                Close();
                                return;
                            }

                            idExamen =
                                Convert.ToInt32(
                                    reader["id_examens"]);

                            // ----------------------------------------
                            // Patient
                            // ----------------------------------------

                            string nom =
                                reader["nom"].ToString();

                            string postNom =
                                reader["post_nom"].ToString();

                            string prenom =
                                reader["prenom"].ToString();

                            string patient =
                                nom + " " + postNom;

                            if (!string.IsNullOrWhiteSpace(prenom))
                            {
                                patient += " " + prenom;
                            }

                            lb_nom_patient.Text = patient;

                            lb_num_fiche.Text =
                                reader["numero_fiche"].ToString();

                            // ----------------------------------------
                            // Sexe + âge
                            // ----------------------------------------

                            string sexe =
                                reader["sexe"].ToString();

                            int age = CalculerAge(
                                Convert.ToDateTime(
                                    reader["date_naissance"]));

                            lb_sexe_age.Text =
                                sexe + " - " +
                                age.ToString() +
                                " ans";

                            // ----------------------------------------
                            // Type EEG
                            // ----------------------------------------

                            lb_type_examen.Text =
                                reader["type_EEG"].ToString();

                            // ----------------------------------------
                            // Date
                            // ----------------------------------------

                            DateTime dateExamen =
                                Convert.ToDateTime(
                                    reader["date_examen"]);

                            lb_date_examen.Text =
                                dateExamen.ToString("dd/MM/yyyy");

                            // ----------------------------------------
                            // Indication
                            // ----------------------------------------

                            tb_indicateur.Text =
                                reader["indication"] == DBNull.Value
                                ? ""
                                : reader["indication"].ToString();

                            // ----------------------------------------
                            // Observation
                            // ----------------------------------------

                            tb_observation.Text =
                                reader["observations"] == DBNull.Value
                                ? ""
                                : reader["observations"].ToString();

                            // ----------------------------------------
                            // Fichier EEG
                            // ----------------------------------------

                            if (reader["nom_fichier"] != DBNull.Value)
                            {
                                lb_file_name.Text =
                                    reader["nom_fichier"].ToString();
                            }
                            else
                            {
                                lb_file_name.Text =
                                    "Aucun fichier";
                            }

                            if (reader["extension_fichier"] !=
                                DBNull.Value)
                            {
                                lb_file_format.Text =
                                    reader["extension_fichier"]
                                    .ToString();
                            }
                            else
                            {
                                lb_file_format.Text = "-";
                            }

                            if (reader["taille_fichier"] !=
                                DBNull.Value)
                            {
                                long taille =
                                    Convert.ToInt64(
                                        reader["taille_fichier"]);

                                lb_taille.Text =
                                    FormaterTaille(taille);
                            }
                            else
                            {
                                lb_taille.Text = "-";
                            }

                            if (reader["chemin_fichier"] !=
                                DBNull.Value)
                            {
                                cheminFichier =
                                    reader["chemin_fichier"]
                                    .ToString();

                                if (File.Exists(cheminFichier))
                                {
                                    lb_status_file.Text =
                                        "Disponible";
                                }
                                else
                                {
                                    lb_status_file.Text =
                                        "Introuvable";
                                }
                            }
                            else
                            {
                                cheminFichier = "";

                                lb_status_file.Text =
                                    "Aucun fichier";
                            }

                            // ----------------------------------------
                            // Vérifier le statut
                            // ----------------------------------------

                            string statut =
                                reader["statut"].ToString();

                            if (statut != "En cours")
                            {
                                btn_save.Enabled = false;

                                MessageBox.Show(
                                    "Cet examen EEG n'est plus en cours.",
                                    "EEG",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement de l'examen EEG :\n\n" +
                    ex.Message,
                    "EEG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // OUVRIR LE FICHIER EEG
        // ============================================================

        private void btn_open_file_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrEmpty(cheminFichier))
            {
                MessageBox.Show(
                    "Aucun fichier EEG n'est associé à cet examen.",
                    "EEG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (!File.Exists(cheminFichier))
            {
                MessageBox.Show(
                    "Le fichier EEG est introuvable :\n\n" +
                    cheminFichier,
                    "EEG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                Process.Start(cheminFichier);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Impossible d'ouvrir le fichier :\n\n" +
                    ex.Message,
                    "EEG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // TERMINER L'EEG
        // ============================================================

        private void btn_save_Click(
            object sender,
            EventArgs e)
        {
            if (idExamen <= 0)
            {
                MessageBox.Show(
                    "Aucun examen EEG sélectionné.",
                    "EEG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult confirmation =
                MessageBox.Show(
                    "Voulez-vous terminer cet examen EEG ?\n\n" +
                    "Après validation, la demande sera marquée comme terminée.",
                    "Terminer l'EEG",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes)
            {
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
                // 1. Enregistrer les observations
                // ====================================================

                string queryExamen = @"
                    UPDATE examens_eeg
                    SET
                        observations = @observations,
                        statut = 'Terminé'
                    WHERE id_examens = @id_examens
                    AND statut = 'En cours'";

                using (MySqlCommand cmd =
                    new MySqlCommand(
                        queryExamen,
                        con,
                        transaction))
                {
                    cmd.Parameters.AddWithValue(
                        "@id_examens",
                        idExamen);

                    cmd.Parameters.AddWithValue(
                        "@observations",
                        string.IsNullOrWhiteSpace(
                            tb_observation.Text)
                            ? (object)DBNull.Value
                            : tb_observation.Text.Trim());

                    int lignes =
                        cmd.ExecuteNonQuery();

                    if (lignes <= 0)
                    {
                        throw new Exception(
                            "L'examen EEG n'est plus en cours " +
                            "ou n'existe pas.");
                    }
                }

                // ====================================================
                // 2. Terminer la demande de service
                // ====================================================

                string queryDemande = @"
                    UPDATE demande_service
                    SET statut = 'Terminée'
                    WHERE id_demande = @id_demande
                    AND statut = 'En cours'";

                using (MySqlCommand cmd =
                    new MySqlCommand(
                        queryDemande,
                        con,
                        transaction))
                {
                    cmd.Parameters.AddWithValue(
                        "@id_demande",
                        idDemande);

                    int lignes =
                        cmd.ExecuteNonQuery();

                    if (lignes <= 0)
                    {
                        throw new Exception(
                            "La demande EEG n'est plus en cours.");
                    }
                }

                // ====================================================
                // 3. Valider
                // ====================================================

                transaction.Commit();

                MessageBox.Show(
                    "L'examen EEG a été terminé avec succès.",
                    "EEG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Form1.DEMANDE_ID = 0;
                Form1.PATIENT_ID = 0;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
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
                    "Erreur lors de la finalisation de l'EEG :\n\n" +
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
        // CALCUL AGE
        // ============================================================

        private int CalculerAge(DateTime dateNaissance)
        {
            DateTime aujourdHui = DateTime.Today;

            int age =
                aujourdHui.Year -
                dateNaissance.Year;

            if (dateNaissance.Date >
                aujourdHui.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        // ============================================================
        // FORMATER TAILLE FICHIER
        // ============================================================

        private string FormaterTaille(long taille)
        {
            if (taille < 1024)
            {
                return taille.ToString() + " octets";
            }

            if (taille < 1024 * 1024)
            {
                return (taille / 1024.0)
                    .ToString("0.##") + " Ko";
            }

            if (taille < 1024 * 1024 * 1024)
            {
                return (taille / (1024.0 * 1024.0))
                    .ToString("0.##") + " Mo";
            }

            return (taille / (1024.0 * 1024.0 * 1024.0))
                .ToString("0.##") + " Go";
        }

        // ============================================================
        // ÉVÉNEMENT EXISTANT DU DESIGNER
        // ============================================================

        private void label7_Click(
            object sender,
            EventArgs e)
        {
        }
    }
}