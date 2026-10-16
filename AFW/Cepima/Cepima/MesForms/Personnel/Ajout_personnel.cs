using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Cepima.Services;
using Cepima.Data;

namespace Cepima.MesForms.Personnel
{
    public partial class Ajout_personnel : Form
    {
        // ========================================================
        // FINGERPRINT ID
        // ========================================================
        Database db = new Database();

        public int FingerprintId
        {
            get;
            set;
        }


        // ========================================================
        // CONSTRUCTEUR
        // ========================================================

        public Ajout_personnel()
        {
            InitializeComponent();
        }


        // ========================================================
        // LOAD
        // ========================================================

        private void Ajout_personnel_Load(
            object sender,
            EventArgs e)
        {
            cbx_sifa.Items.Clear();

            cbx_sifa.Items.Add(
                "-----Sélectionner le statut-----");

            cbx_sifa.Items.Add(
                "Marié");

            cbx_sifa.Items.Add(
                "Célibataire");

            cbx_sifa.Items.Add(
                "Divorce");

            cbx_sifa.SelectedIndex = 0;


            // ----------------------------------------------------
            // Afficher l'ID reçu du système R307
            // ----------------------------------------------------

            Console.WriteLine(
                "Fingerprint ID reçu : " +
                FingerprintId);
        }


        // ========================================================
        // ENREGISTREMENT
        // ========================================================

        private async void btn_save_personnel_Click(
            object sender,
            EventArgs e)
        {
            // ----------------------------------------------------
            // Validation
            // ----------------------------------------------------

            if (string.IsNullOrWhiteSpace(
                tb_nom.Text))
            {
                MessageBox.Show(
                    "Veuillez saisir le nom.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_nom.Focus();

                return;
            }


            if (string.IsNullOrWhiteSpace(
                tb_post_nom.Text))
            {
                MessageBox.Show(
                    "Veuillez saisir le post-nom.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_post_nom.Focus();

                return;
            }


            if (string.IsNullOrWhiteSpace(
                tb_prenom.Text))
            {
                MessageBox.Show(
                    "Veuillez saisir le prénom.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_prenom.Focus();

                return;
            }


            if (string.IsNullOrWhiteSpace(
                tb_fonction.Text))
            {
                MessageBox.Show(
                    "Veuillez saisir la fonction.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_fonction.Focus();

                return;
            }


            if (cbx_sifa.SelectedIndex <= 0)
            {
                MessageBox.Show(
                    "Veuillez sélectionner la situation familiale.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cbx_sifa.Focus();

                return;
            }


            // ----------------------------------------------------
            // Vérification Fingerprint ID
            // ----------------------------------------------------

            if (FingerprintId <= 0)
            {
                MessageBox.Show(
                    "Fingerprint ID invalide.",
                    "R307",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            // ----------------------------------------------------
            // Désactiver bouton
            // ----------------------------------------------------

            btn_save_personnel.Enabled = false;


            try
            {
                int personnelId;


                // =================================================
                // 1. ENREGISTRER LE PERSONNEL
                // =================================================

                using (
                    MySqlConnection con = db.GetConnection())
                {
                    con.Open();


                    string queryInsert =
                        "INSERT INTO personnels " +
                        "(" +
                        "nom," +
                        "post_nom," +
                        "prenom," +
                        "sexe," +
                        "date_naissance," +
                        "date_embauche," +
                        "fonction," +
                        "telephone," +
                        "adresse," +
                        "situation_familliale," +
                        "fingerprint_id," +
                        "actif" +
                        ")" +
                        "VALUES" +
                        "(" +
                        "@nom," +
                        "@post," +
                        "@prenom," +
                        "@sexe," +
                        "@naissance," +
                        "@embauche," +
                        "@fonction," +
                        "@phone," +
                        "@adresse," +
                        "@sifa," +
                        "@fingerprint_id," +
                        "@actif" +
                        ")";


                    using (
                        MySqlCommand cmd =
                        new MySqlCommand(
                            queryInsert,
                            con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@nom",
                            tb_nom.Text.Trim());


                        cmd.Parameters.AddWithValue(
                            "@post",
                            tb_post_nom.Text.Trim());


                        cmd.Parameters.AddWithValue(
                            "@prenom",
                            tb_prenom.Text.Trim());


                        cmd.Parameters.AddWithValue(
                            "@sexe",
                            tb_sexe.Text.Trim());


                        cmd.Parameters.AddWithValue(
                            "@naissance",
                            dt_naisance.Value.Date);


                        cmd.Parameters.AddWithValue(
                            "@embauche",
                            dt_embauche.Value.Date);


                        cmd.Parameters.AddWithValue(
                            "@fonction",
                            tb_fonction.Text.Trim());


                        cmd.Parameters.AddWithValue(
                            "@phone",
                            tb_phone.Text.Trim());


                        cmd.Parameters.AddWithValue(
                            "@adresse",
                            tb_adresse.Text.Trim());


                        cmd.Parameters.AddWithValue(
                            "@sifa",
                            cbx_sifa.Text);


                        cmd.Parameters.AddWithValue(
                            "@fingerprint_id",
                            FingerprintId);


                        cmd.Parameters.AddWithValue(
                            "@actif",
                            1);


                        cmd.ExecuteNonQuery();


                        personnelId =
                            Convert.ToInt32(
                                cmd.LastInsertedId);
                    }
                }


                // =================================================
                // 2. PERSONNEL ENREGISTRE
                // =================================================

                MessageBox.Show(
                    "Personnel enregistré.\n\n" +
                    "ID personnel : " +
                    personnelId +
                    "\n" +
                    "Fingerprint ID : " +
                    FingerprintId +
                    "\n\n" +
                    "L'enrôlement de l'empreinte va commencer.",
                    "CEPIMA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                // =================================================
                // 3. ENVOYER L'ID A L'ESP32
                //
                // IMPORTANT :
                // await ne bloque pas l'interface.
                // =================================================

                bool requestAccepted =
                    await FingerprintApi
                    .StartFingerprintEnrollment(
                        FingerprintId);


                if (!requestAccepted)
                {
                    MessageBox.Show(
                        "Impossible de démarrer " +
                        "l'enrôlement sur le R307.\n\n" +
                        "Vérifiez que l'ESP32 est connecté " +
                        "au Wi-Fi et accessible.",
                        "CEPIMA - R307",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    btn_save_personnel.Enabled =
                        true;

                    return;
                }


                // =================================================
                // 4. L'ESP32 A ACCEPTÉ
                // =================================================

                MessageBox.Show(
                    "Le R307 est prêt.\n\n" +
                    "Posez votre doigt lorsque le capteur " +
                    "vous le demande.",
                    "CEPIMA - R307",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                // =================================================
                // 5. ATTENDRE LE RESULTAT
                //
                // Cette attente est asynchrone.
                // WinForms reste disponible.
                // =================================================

                string result =
                    await FingerprintApi
                    .WaitEnrollmentResult(
                        FingerprintId);


                // =================================================
                // 6. RESULTAT
                // =================================================

                if (result == "success")
                {
                    MessageBox.Show(
                        "Empreinte enregistrée avec succès !\n\n" +
                        "Fingerprint ID : " +
                        FingerprintId +
                        "\n\n" +
                        "Le R307 est revenu en mode scan.",
                        "CEPIMA - R307",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);


                    ClearTextFill();


                    this.DialogResult =
                        DialogResult.OK;

                    this.Close();

                    return;
                }


                if (result == "error")
                {
                    MessageBox.Show(
                        "L'enrôlement de l'empreinte a échoué.\n\n" +
                        "Le personnel est enregistré dans CEPIMA,\n" +
                        "mais son empreinte n'a pas été enregistrée " +
                        "dans le R307.\n\n" +
                        "Fingerprint ID : " +
                        FingerprintId,
                        "CEPIMA - R307",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    btn_save_personnel.Enabled =
                        true;

                    return;
                }


                // =================================================
                // TIMEOUT
                // =================================================

                MessageBox.Show(
                    "Le délai d'attente de l'enrôlement " +
                    "est dépassé.\n\n" +
                    "Le personnel a été enregistré, " +
                    "mais vérifiez l'état du R307.",
                    "CEPIMA - R307",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                btn_save_personnel.Enabled =
                    true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur MySQL :\n\n" +
                    ex.Message,
                    "Erreur d'enregistrement",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                btn_save_personnel.Enabled =
                    true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur :\n\n" +
                    ex.Message,
                    "CEPIMA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                btn_save_personnel.Enabled =
                    true;
            }
        }


        // ========================================================
        // NETTOYER FORMULAIRE
        // ========================================================

        private void ClearTextFill()
        {
            tb_nom.Text = "";
            tb_post_nom.Text = "";
            tb_prenom.Text = "";

            tb_sexe.Text = "";

            tb_fonction.Text = "";

            tb_phone.Text = "";

            tb_adresse.Text = "";

            cbx_sifa.SelectedIndex = 0;
        }
    }
}