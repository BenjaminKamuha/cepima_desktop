using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cepima.MesUserCases
{
    public partial class User_DashBord_pharmacie : UserControl
    {
        public User_DashBord_pharmacie()
        {
            InitializeComponent();

            InitialiserDashboard();
        }

        // ============================================================
        // INITIALISATION
        // ============================================================

        private void InitialiserDashboard()
        {
            try
            {
                ConfigurerDataGridView();

                LoadStatistiques();

                LoadDispensationsHospitalisation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'initialisation du tableau de bord :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ============================================================
        // LOAD
        // ============================================================

        private void User_DashBord_pharmacie_Load(object sender, EventArgs e)
        {
            InitialiserDashboard();
        }


        // ============================================================
        // CONFIGURATION DATAGRIDVIEW
        // ============================================================

        private void ConfigurerDataGridView()
        {
            dgv_disp.Rows.Clear();
            dgv_disp.Columns.Clear();

            dgv_disp.AutoGenerateColumns = false;

            // --------------------------------------------------------
            // Colonnes
            // --------------------------------------------------------

            DataGridViewTextBoxColumn colId =
                new DataGridViewTextBoxColumn();

            colId.Name = "ID";
            colId.HeaderText = "ID";
            colId.Visible = false;

            dgv_disp.Columns.Add(colId);


            DataGridViewTextBoxColumn colPatient =
                new DataGridViewTextBoxColumn();

            colPatient.Name = "Patient";
            colPatient.HeaderText = "PATIENT";
            colPatient.FillWeight = 25;

            dgv_disp.Columns.Add(colPatient);


            DataGridViewTextBoxColumn colPrescription =
                new DataGridViewTextBoxColumn();

            colPrescription.Name = "Prescription";
            colPrescription.HeaderText = "ORDONNANCE";
            colPrescription.FillWeight = 15;

            dgv_disp.Columns.Add(colPrescription);


            DataGridViewTextBoxColumn colDate =
                new DataGridViewTextBoxColumn();

            colDate.Name = "Date";
            colDate.HeaderText = "DATE";
            colDate.FillWeight = 15;

            dgv_disp.Columns.Add(colDate);


            DataGridViewTextBoxColumn colAgent =
                new DataGridViewTextBoxColumn();

            colAgent.Name = "Agent";
            colAgent.HeaderText = "AGENT";
            colAgent.FillWeight = 20;

            dgv_disp.Columns.Add(colAgent);


            DataGridViewTextBoxColumn colObservation =
                new DataGridViewTextBoxColumn();

            colObservation.Name = "Observation";
            colObservation.HeaderText = "OBSERVATION";
            colObservation.FillWeight = 25;

            dgv_disp.Columns.Add(colObservation);
        }


        // ============================================================
        // STATISTIQUES
        // ============================================================

        private void LoadStatistiques()
        {
            using (MySqlConnection con =
                MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    // NE PAS faire con.Open()
                    // GetConnexion() retourne déjà une connexion ouverte.

                    // ========================================================
                    // 1. QUANTITE DELIVREE AUJOURD'HUI
                    // ========================================================

                    string queryDelivre = @"
                SELECT COALESCE(SUM(quantite), 0)
                FROM mouvement_stock
                WHERE UPPER(type) = 'SORTIE'
                  AND DATE(date_mouvement) = CURDATE()";

                    using (MySqlCommand cmd =
                        new MySqlCommand(queryDelivre, con))
                    {
                        object result = cmd.ExecuteScalar();

                        int quantite = 0;

                        if (result != null && result != DBNull.Value)
                        {
                            quantite = Convert.ToInt32(result);
                        }

                        lb_quantite_delivre.Text = quantite.ToString();
                    }


                    // ========================================================
                    // 2. ORDONNANCES EN ATTENTE
                    // ========================================================

                    string queryAttente = @"
                SELECT COUNT(*)
                FROM prescription
                WHERE UPPER(statut) = 'ACTIVE'";

                    using (MySqlCommand cmd =
                        new MySqlCommand(queryAttente, con))
                    {
                        object result = cmd.ExecuteScalar();

                        int nombre = 0;

                        if (result != null && result != DBNull.Value)
                        {
                            nombre = Convert.ToInt32(result);
                        }

                        lb_nb_ordonance_en_attente.Text = nombre.ToString();
                    }


                    // ========================================================
                    // 3. STOCK FAIBLE
                    // ========================================================

                    string queryStockFaible = @"
                SELECT COUNT(*)
                FROM
                (
                    SELECT
                        m.id,
                        m.seuil_minimum,
                        COALESCE(SUM(l.quantite), 0) AS stock_total

                    FROM medicament m

                    LEFT JOIN lot_medicament l
                        ON l.medicament_id = m.id

                    WHERE m.actif = 1

                    GROUP BY
                        m.id,
                        m.seuil_minimum

                    HAVING
                        stock_total <= m.seuil_minimum
                ) AS stocks_faibles";

                    using (MySqlCommand cmd =
                        new MySqlCommand(queryStockFaible, con))
                    {
                        object result = cmd.ExecuteScalar();

                        int nombre = 0;

                        if (result != null && result != DBNull.Value)
                        {
                            nombre = Convert.ToInt32(result);
                        }

                        lb_nombre_stock_faible.Text = nombre.ToString();
                    }


                    // ========================================================
                    // 4. LOTS EXPIRES
                    // ========================================================

                    string queryExpiration = @"
                SELECT COUNT(*)
                FROM lot_medicament l

                INNER JOIN medicament m
                    ON m.id = l.medicament_id

                WHERE m.actif = 1
                  AND l.date_expiration < CURDATE()";

                    using (MySqlCommand cmd =
                        new MySqlCommand(queryExpiration, con))
                    {
                        object result = cmd.ExecuteScalar();

                        int nombre = 0;

                        if (result != null && result != DBNull.Value)
                        {
                            nombre = Convert.ToInt32(result);
                        }

                        lb_nombre_expiration.Text = nombre.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur lors du chargement des statistiques :\n\n" +
                        ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
        // ============================================================
        // DISPENSATIONS HOSPITALISATION
        // ============================================================

        private void LoadDispensationsHospitalisation()
        {
            try
            {
                dgv_disp.Rows.Clear();

                using (MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {

                    /*
                     * La table dispensation contient :
                     *
                     * id
                     * prescription_id
                     * patient_id
                     * type
                     * date_dispensation
                     * agent_id
                     * observation
                     *
                     * On récupère donc les dispensations dont le type
                     * correspond à HOSPITALISATION.
                     *
                     * Pour le patient, nous utilisons la table
                     * patients.
                     *
                     * Pour l'ordonnance, nous utilisons prescription.
                     */

                    string query = @"
                        SELECT
                            d.id,
                            d.prescription_id,
                            d.patient_id,
                            d.date_dispensation,
                            d.agent_id,
                            d.observation,

                            p.nom,
                            p.post_nom,
                            p.prenom

                        FROM dispensation d

                        INNER JOIN patients p
                            ON p.id_patient = d.patient_id

                        WHERE UPPER(d.type) = 'HOSPITALISATION'

                        ORDER BY d.date_dispensation DESC";


                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id =
                                    Convert.ToInt32(
                                        reader["id"]);

                                int idPrescription =
                                    Convert.ToInt32(
                                        reader["prescription_id"]);

                                string patient =
                                    reader["nom"].ToString();

                                if (reader["post_nom"] != DBNull.Value)
                                {
                                    patient += " " +
                                        reader["post_nom"].ToString();
                                }

                                if (reader["prenom"] != DBNull.Value)
                                {
                                    patient += " " +
                                        reader["prenom"].ToString();
                                }

                                DateTime date =
                                    Convert.ToDateTime(
                                        reader["date_dispensation"]);

                                string agent = "";

                                if (reader["agent_id"] != DBNull.Value)
                                {
                                    agent =
                                        reader["agent_id"].ToString();
                                }

                                string observation = "";

                                if (reader["observation"] != DBNull.Value)
                                {
                                    observation =
                                        reader["observation"].ToString();
                                }

                                dgv_disp.Rows.Add(
                                    id,
                                    patient.Trim(),
                                    "#" + idPrescription,
                                    date.ToString("dd/MM/yyyy HH:mm"),
                                    agent,
                                    observation
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des dispensations " +
                    "d'hospitalisation :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ============================================================
        // RAFRAICHISSEMENT
        // ============================================================

        public void ActualiserDashboard()
        {
            LoadStatistiques();

            LoadDispensationsHospitalisation();
        }


        // ============================================================
        // CLICK LABEL
        // ============================================================

        private void label6_Click(object sender, EventArgs e)
        {
            // Aucun traitement pour le moment.
        }
    }
}