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

        private void User_DashBord_pharmacie_Load(
            object sender,
            EventArgs e)
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
            // ID
            // --------------------------------------------------------

            DataGridViewTextBoxColumn colId =
                new DataGridViewTextBoxColumn();

            colId.Name = "ID";
            colId.HeaderText = "ID";
            colId.Visible = false;

            dgv_disp.Columns.Add(colId);


            // --------------------------------------------------------
            // PATIENT
            // --------------------------------------------------------

            DataGridViewTextBoxColumn colPatient =
                new DataGridViewTextBoxColumn();

            colPatient.Name = "Patient";
            colPatient.HeaderText = "PATIENT";
            colPatient.FillWeight = 25;

            dgv_disp.Columns.Add(colPatient);


            // --------------------------------------------------------
            // PRESCRIPTION
            // --------------------------------------------------------

            DataGridViewTextBoxColumn colPrescription =
                new DataGridViewTextBoxColumn();

            colPrescription.Name = "Prescription";
            colPrescription.HeaderText = "ORDONNANCE";
            colPrescription.FillWeight = 15;

            dgv_disp.Columns.Add(colPrescription);


            // --------------------------------------------------------
            // DATE
            // --------------------------------------------------------

            DataGridViewTextBoxColumn colDate =
                new DataGridViewTextBoxColumn();

            colDate.Name = "Date";
            colDate.HeaderText = "DATE";
            colDate.FillWeight = 15;

            dgv_disp.Columns.Add(colDate);


            // --------------------------------------------------------
            // AGENT
            // --------------------------------------------------------

            DataGridViewTextBoxColumn colAgent =
                new DataGridViewTextBoxColumn();

            colAgent.Name = "Agent";
            colAgent.HeaderText = "AGENT";
            colAgent.FillWeight = 20;

            dgv_disp.Columns.Add(colAgent);


            // --------------------------------------------------------
            // OBSERVATION
            // --------------------------------------------------------

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
                    // IMPORTANT :
                    // GetConnexion() retourne déjà une connexion ouverte.
                    // NE PAS faire con.Open() ici.

                    // ========================================================
                    // UNE SEULE REQUETE POUR LES 4 STATISTIQUES
                    // ========================================================

                    string query = @"
                        SELECT

                            /* ---------------------------------------------
                               1. QUANTITE DELIVREE AUJOURD'HUI
                               --------------------------------------------- */

                            (
                                SELECT COALESCE(
                                    SUM(ms.quantite),
                                    0
                                )
                                FROM mouvement_stock ms
                                WHERE ms.type = 'SORTIE'
                                  AND ms.date_mouvement >= CURDATE()
                                  AND ms.date_mouvement < CURDATE() + INTERVAL 1 DAY
                            ) AS quantite_delivree,


                            /* ---------------------------------------------
                               2. ORDONNANCES EN ATTENTE
                               --------------------------------------------- */

                            (
                                SELECT COUNT(*)
                                FROM prescription pr
                                WHERE pr.statut = 'ACTIVE'
                            ) AS ordonnances_attente,


                            /* ---------------------------------------------
                               3. STOCK FAIBLE
                               --------------------------------------------- */

                            (
                                SELECT COUNT(*)
                                FROM
                                (
                                    SELECT
                                        m.id,
                                        m.seuil_minimum,
                                        COALESCE(
                                            SUM(l.quantite),
                                            0
                                        ) AS stock_total

                                    FROM medicament m

                                    LEFT JOIN lot_medicament l
                                        ON l.medicament_id = m.id

                                    WHERE m.actif = 1

                                    GROUP BY
                                        m.id,
                                        m.seuil_minimum

                                    HAVING stock_total <= m.seuil_minimum

                                ) AS stocks_faibles
                            ) AS stock_faible,


                            /* ---------------------------------------------
                               4. LOTS EXPIRES
                               --------------------------------------------- */

                            (
                                SELECT COUNT(*)
                                FROM lot_medicament l

                                INNER JOIN medicament m
                                    ON m.id = l.medicament_id

                                WHERE m.actif = 1
                                  AND l.date_expiration < CURDATE()
                            ) AS expiration";


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
                                // QUANTITE DELIVREE
                                // -----------------------------------------

                                int quantiteDelivree =
                                    Convert.ToInt32(
                                        reader[
                                            "quantite_delivree"]);

                                lb_quantite_delivre.Text =
                                    quantiteDelivree.ToString();


                                // -----------------------------------------
                                // ORDONNANCES
                                // -----------------------------------------

                                int ordonnances =
                                    Convert.ToInt32(
                                        reader[
                                            "ordonnances_attente"]);

                                lb_nb_ordonance_en_attente.Text =
                                    ordonnances.ToString();


                                // -----------------------------------------
                                // STOCK FAIBLE
                                // -----------------------------------------

                                int stockFaible =
                                    Convert.ToInt32(
                                        reader[
                                            "stock_faible"]);

                                lb_nombre_stock_faible.Text =
                                    stockFaible.ToString();


                                // -----------------------------------------
                                // EXPIRATION
                                // -----------------------------------------

                                int expiration =
                                    Convert.ToInt32(
                                        reader[
                                            "expiration"]);

                                lb_nombre_expiration.Text =
                                    expiration.ToString();
                            }
                        }
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
                dgv_disp.SuspendLayout();

                dgv_disp.Rows.Clear();

                using (MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {
                    // GetConnexion() retourne déjà une connexion ouverte.
                    // NE PAS faire con.Open().

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

                        WHERE d.type = 'HOSPITALISATION'

                        ORDER BY
                            d.date_dispensation DESC";


                    using (MySqlCommand cmd =
                        new MySqlCommand(
                            query,
                            con))
                    {
                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // -----------------------------------------
                                // ID
                                // -----------------------------------------

                                int id =
                                    Convert.ToInt32(
                                        reader["id"]);


                                // -----------------------------------------
                                // PRESCRIPTION
                                // -----------------------------------------

                                int idPrescription =
                                    Convert.ToInt32(
                                        reader[
                                            "prescription_id"]);


                                // -----------------------------------------
                                // PATIENT
                                // -----------------------------------------

                                string patient =
                                    reader["nom"].ToString();


                                if (reader["post_nom"] !=
                                    DBNull.Value)
                                {
                                    string postNom =
                                        reader[
                                            "post_nom"]
                                        .ToString();

                                    if (!string.IsNullOrWhiteSpace(
                                        postNom))
                                    {
                                        patient +=
                                            " " +
                                            postNom;
                                    }
                                }


                                if (reader["prenom"] !=
                                    DBNull.Value)
                                {
                                    string prenom =
                                        reader[
                                            "prenom"]
                                        .ToString();

                                    if (!string.IsNullOrWhiteSpace(
                                        prenom))
                                    {
                                        patient +=
                                            " " +
                                            prenom;
                                    }
                                }


                                // -----------------------------------------
                                // DATE
                                // -----------------------------------------

                                DateTime date =
                                    Convert.ToDateTime(
                                        reader[
                                            "date_dispensation"]);


                                // -----------------------------------------
                                // AGENT
                                // -----------------------------------------

                                string agent = "";

                                if (reader["agent_id"] !=
                                    DBNull.Value)
                                {
                                    agent =
                                        reader[
                                            "agent_id"]
                                        .ToString();
                                }


                                // -----------------------------------------
                                // OBSERVATION
                                // -----------------------------------------

                                string observation = "";

                                if (reader["observation"] !=
                                    DBNull.Value)
                                {
                                    observation =
                                        reader[
                                            "observation"]
                                        .ToString();
                                }


                                // -----------------------------------------
                                // AJOUT
                                // -----------------------------------------

                                dgv_disp.Rows.Add(
                                    id,
                                    patient.Trim(),
                                    "#" +
                                    idPrescription,
                                    date.ToString(
                                        "dd/MM/yyyy HH:mm"),
                                    agent,
                                    observation);
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
            finally
            {
                dgv_disp.ResumeLayout();
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

        private void label6_Click(
            object sender,
            EventArgs e)
        {
            // Aucun traitement pour le moment.
        }
    }
}