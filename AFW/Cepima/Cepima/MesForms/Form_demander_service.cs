using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cepima.Data;
using MySql.Data.MySqlClient;

namespace Cepima.MesForms
{
    public partial class Form_demander_service : Form
    {
        public Form_demander_service()
        {
            InitializeComponent();

            ChargerPatients();
            ChargerServices();
            ChargerConsultations(Form1.PATIENT_ID);
        }

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
                            WHEN prenom IS NOT NULL AND prenom <> ''
                            THEN CONCAT(' ', prenom)
                            ELSE ''
                        END
                    ) AS patient
                FROM patients
                WHERE id_patient = @id_p";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_p", Form1.PATIENT_ID);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int age = DateTime.Now.Date.Year - Convert.ToInt32(reader["annee_naissance"].ToString());
                                lb_nom_patient.Text = reader["patient"].ToString();
                                lb_sexe_age.Text = reader["sexe"].ToString() + "-" + age.ToString() + " ans";
                                lb_num_fiche.Text = reader["numero_fiche"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des patients :\n" + ex.Message,
                    "SERVICE",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Configurer()
        {
            rd_priorite_normal.Checked = true;
            cbx_service.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx_consultation.DropDownStyle = ComboBoxStyle.DropDownList;

            btn_send_request.Click += btn_send_request_Click;
            btn_cancel.Click += btn_cancel_Click;

            cbx_service.SelectedIndex = -1;
            cbx_service.SelectedIndex = -1;
            cbx_service.SelectedIndex = -1;

            //lblPatientInfo.Text = "";
        }

        // =========================================================
        // SERVICES
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
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            cbx_service.DataSource = dt;
                            cbx_service.DisplayMember = "nom";
                            cbx_service.ValueMember = "id_service";
                            cbx_service.SelectedIndex = -1;
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
        // CONSULTATIONS DU PATIENT
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
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            cbx_consultation.DataSource = dt;
                            cbx_consultation.DisplayMember =
                                "consultation";

                            cbx_consultation.ValueMember = "id";

                            cbx_consultation.SelectedIndex = -1;
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

        void btn_send_request_Click(object sender, EventArgs e)
        {
            EnregistrerDemande();
        }

        private void EnregistrerDemande()
        {
            // -----------------------------------------------------
            // VALIDATIONS
            // -----------------------------------------------------

            if (cbx_service.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Veuillez sélectionner un service.",
                    "Demande de service",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cbx_service.Focus();
                return;
            }

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

            // -----------------------------------------------------
            // RECUPERATION DES VALEURS
            // -----------------------------------------------------

            int idService =
                Convert.ToInt32(cbx_service.SelectedValue);

            int? idConsultation = null;

            if (cbx_consultation.SelectedIndex >= 0 &&
                cbx_consultation.SelectedValue != null)
            {
                idConsultation =
                    Convert.ToInt32(cbx_consultation.SelectedValue);
            }

            string priorite =
                rd_priorite_normal.Checked
                    ? "Urgente"
                    : "Normale";

            string motif =
                tb_indicateur.Text.Trim();

            string observation = null;

            if (!string.IsNullOrWhiteSpace(tb_observation.Text))
            {
                observation =
                    tb_observation.Text.Trim();
            }

            // -----------------------------------------------------
            // INSERTION
            // -----------------------------------------------------

            try
            {
                Database db = new Database();

                using (MySqlConnection con = db.GetConnection())
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
                            statut,
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
                            'Demandée',
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

                        // Pour le moment aucun personnel n'est
                        // associé automatiquement à la demande.
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

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "La demande de service a été enregistrée.",
                    "Demande de service",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
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


        void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
