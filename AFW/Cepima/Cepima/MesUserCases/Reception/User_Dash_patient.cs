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
    public partial class User_Dash_patient : UserControl
    {
        int ID_PATIENT = 0;

        public User_Dash_patient()
        {
            InitializeComponent();

            LoadPatient();

            dgv_patient.CellContentClick += dgv_patient_CellContentClick;

            LoadResume();
        }


        // ============================================================
        // CHARGER LES PATIENTS RECENTS
        // ============================================================

        private void LoadPatient()
        {
            using (MySqlConnection con =
                MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string query = @"
                        SELECT
                            id_patient,
                            nom,
                            post_nom,
                            prenom,
                            numero_fiche,
                            telephone
                        FROM patients
                        ORDER BY date_creation DESC
                        LIMIT 11";


                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int row =
                                    dgv_patient.Rows.Add();

                                int patientId =
                                    Convert.ToInt32(
                                        reader["id_patient"]);


                                // ------------------------------------------------
                                // ID
                                // ------------------------------------------------

                                dgv_patient.Rows[row].Tag =
                                    patientId;

                                dgv_patient.Rows[row]
                                    .Cells["colID"]
                                    .Value =
                                    patientId;


                                // ------------------------------------------------
                                // NOM
                                // ------------------------------------------------

                                dgv_patient.Rows[row]
                                    .Cells["colNom"]
                                    .Value =
                                    reader["nom"].ToString();


                                // ------------------------------------------------
                                // POST-NOM
                                // ------------------------------------------------

                                dgv_patient.Rows[row]
                                    .Cells["colPostnom"]
                                    .Value =
                                    reader["post_nom"].ToString();


                                // ------------------------------------------------
                                // PRENOM
                                // ------------------------------------------------

                                dgv_patient.Rows[row]
                                    .Cells["colPrenom"]
                                    .Value =
                                    reader["prenom"].ToString();


                                // ------------------------------------------------
                                // NUMERO FICHE
                                // ------------------------------------------------

                                dgv_patient.Rows[row]
                                    .Cells["colNumero"]
                                    .Value =
                                    reader["numero_fiche"].ToString();


                                // ------------------------------------------------
                                // TELEPHONE
                                // ------------------------------------------------

                                dgv_patient.Rows[row]
                                    .Cells["colPhone"]
                                    .Value =
                                    reader["telephone"].ToString();
                            }
                        }
                    }

                    ApplyStyle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur : " + ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }


        // ============================================================
        // STYLE DATAGRIDVIEW
        // ============================================================

        private void ApplyStyle()
        {
            dgv_patient.Columns["colSignes"].Width = 100;

            dgv_patient.Columns["action"].Width = 100;

            dgv_patient.Columns["colID"].Width = 30;
        }


        // ============================================================
        // CLICK DATAGRIDVIEW
        // ============================================================

        private void dgv_patient_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0)
            {
                return;
            }


            string columnName =
                dgv_patient.Columns[
                    e.ColumnIndex].Name;


            // ========================================================
            // RECUPERER ID PATIENT
            // ========================================================

            if (dgv_patient.Rows[e.RowIndex].Tag == null)
            {
                return;
            }

            ID_PATIENT =
                Convert.ToInt32(
                    dgv_patient.Rows[e.RowIndex].Tag);


            // ========================================================
            // SIGNES VITAUX
            // ========================================================

            if (columnName == "colSignes")
            {
                Form1.GlobalPanel_main.Visible = false;

                try
                {
                    MesForms.Form_signes_vitaux signes =
                        new MesForms.Form_signes_vitaux(
                            ID_PATIENT);

                    signes.ShowDialog();
                }
                finally
                {
                    Form1.GlobalPanel_main.Visible = true;
                }

                return;
            }


            // ========================================================
            // FICHE DE SUIVI
            // ========================================================

            if (columnName == "action")
            {
                Form1.GlobalPanel_main.Visible = false;

                try
                {
                    MesForms.Form_Fiche_suivie fiche =
                        new MesForms.Form_Fiche_suivie(
                            ID_PATIENT.ToString());

                    fiche.ShowDialog();
                }
                finally
                {
                    Form1.GlobalPanel_main.Visible = true;
                }

                return;
            }


            // ========================================================
            // DEMANDE DE SERVICE
            // ========================================================

            if (columnName == "colService")
            {
                Form1.GlobalPanel_main.Visible = false;

                try
                {
                    Form1.PATIENT_ID = ID_PATIENT;

                    MesForms.Form_demander_service service =
                        new MesForms.Form_demander_service(
                            ID_PATIENT.ToString(),
                            0);

                    service.ShowDialog();
                }
                finally
                {
                    Form1.GlobalPanel_main.Visible = true;
                }

                return;
            }
        }


        // ============================================================
        // RESUME DU DASHBOARD
        // ============================================================

        private void LoadResume()
        {
            using (MySqlConnection con =
                MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    // =================================================
                    // UNE SEULE REQUETE POUR LES 4 COMPTEURS
                    // =================================================

                    string query = @"
                        SELECT

                            /* ==========================================
                               PATIENTS CREES AUJOURD'HUI
                               ========================================== */

                            (
                                SELECT COUNT(*)
                                FROM patients
                                WHERE date_creation >= CURDATE()
                                  AND date_creation < CURDATE() + INTERVAL 1 DAY
                            ) AS patients_now,


                            /* ==========================================
                               PATIENTS HOSPITALISES
                               ========================================== */

                            (
                                SELECT COUNT(*)
                                FROM hospitalisation
                                WHERE date_sortie IS NULL
                            ) AS hospitalises,


                            /* ==========================================
                               PATIENTS EN ATTENTE
                               ========================================== */

                            (
                                SELECT COUNT(*)
                                FROM signes_vitaux
                                WHERE is_counsel = 0
                            ) AS attente,


                            /* ==========================================
                               PATIENTS SORTIS
                               ========================================== */

                            (
                                SELECT COUNT(*)
                                FROM hospitalisation
                                WHERE date_sortie IS NOT NULL
                            ) AS sortis;
                    ";


                    using (MySqlCommand cmd =
                        new MySqlCommand(
                            query,
                            con))
                    {
                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // -----------------------------------------
                                // PATIENTS AUJOURD'HUI
                                // -----------------------------------------

                                lb_patient_now.Text =
                                    reader[
                                        "patients_now"]
                                    .ToString();


                                // -----------------------------------------
                                // HOSPITALISES
                                // -----------------------------------------

                                lb_hospitalise.Text =
                                    reader[
                                        "hospitalises"]
                                    .ToString();


                                // -----------------------------------------
                                // EN ATTENTE
                                // -----------------------------------------

                                lb_attente.Text =
                                    reader[
                                        "attente"]
                                    .ToString();


                                // -----------------------------------------
                                // SORTIS
                                // -----------------------------------------

                                lb_sorti.Text =
                                    reader[
                                        "sortis"]
                                    .ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur lors du chargement du résumé :\n\n" +
                        ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }


        // ============================================================
        // AJOUT PATIENT
        // ============================================================

        private void bt_add_patient_Click(
            object sender,
            EventArgs e)
        {
            MesForms.Form_add_patient add =
                new MesForms.Form_add_patient();

            add.ShowDialog();
        }
    }
}