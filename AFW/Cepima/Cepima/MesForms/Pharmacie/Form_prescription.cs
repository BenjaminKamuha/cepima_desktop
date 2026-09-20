using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Cepima.Data;

namespace Cepima.MesForms.Pharmacie
{
    public partial class Form_prescription : Form
    {
        // =========================================================
        // VARIABLES
        // =========================================================

        private int ID_PRESCRIPTION = 0;


        // =========================================================
        // CONSTRUCTEUR
        // =========================================================

        public Form_prescription(int idPrescription)
        {
            InitializeComponent();

            ID_PRESCRIPTION = idPrescription;

            ConfigurerFormulaire();

            ChargerPrescription();
        }

        // =========================================================
        // CONFIGURATION DU FORMULAIRE
        // =========================================================

        private void ConfigurerFormulaire()
        {
            // -----------------------------------------------------
            // Configuration du DataGridView
            // -----------------------------------------------------

            dgv_presc.AutoGenerateColumns = false;

            dgv_presc.AllowUserToAddRows = false;
            dgv_presc.AllowUserToDeleteRows = false;
            dgv_presc.AllowUserToResizeRows = false;

            dgv_presc.ReadOnly = true;

            dgv_presc.MultiSelect = false;

            dgv_presc.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgv_presc.RowHeadersVisible = false;

            dgv_presc.Columns.Clear();


            // =====================================================
            // PRODUIT
            // =====================================================

            DataGridViewTextBoxColumn colProduit =
                new DataGridViewTextBoxColumn();

            colProduit.Name = "Produit";
            colProduit.HeaderText = "Produit";
            colProduit.ReadOnly = true;

            colProduit.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            colProduit.FillWeight = 45;

            dgv_presc.Columns.Add(colProduit);


            // =====================================================
            // QUANTITE PRESCRITE
            // =====================================================

            DataGridViewTextBoxColumn colQtePrescrite =
                new DataGridViewTextBoxColumn();

            colQtePrescrite.Name = "QtePrescrit";
            colQtePrescrite.HeaderText = "Qté prescrit";
            colQtePrescrite.ReadOnly = true;

            colQtePrescrite.Width = 100;

            colQtePrescrite.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgv_presc.Columns.Add(colQtePrescrite);


            // =====================================================
            // QUANTITE DELIVREE
            // =====================================================

            DataGridViewTextBoxColumn colQteDelivree =
                new DataGridViewTextBoxColumn();

            colQteDelivree.Name = "QteDelivre";
            colQteDelivree.HeaderText = "Qté délivré";
            colQteDelivree.ReadOnly = true;

            colQteDelivree.Width = 100;

            colQteDelivree.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgv_presc.Columns.Add(colQteDelivree);


            // =====================================================
            // STATUT
            // =====================================================

            DataGridViewTextBoxColumn colStatut =
                new DataGridViewTextBoxColumn();

            colStatut.Name = "Statut";
            colStatut.HeaderText = "Statut";
            colStatut.ReadOnly = true;

            colStatut.Width = 110;

            colStatut.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgv_presc.Columns.Add(colStatut);


            // =====================================================
            // EVENEMENT BOUTON DELIVRER
            // =====================================================

            btn_delivrer.Click -= btn_delivrer_Click;
            btn_delivrer.Click += btn_delivrer_Click;
        }


        // =========================================================
        // CHARGER LA PRESCRIPTION
        // =========================================================

        private void ChargerPrescription()
        {
            if (ID_PRESCRIPTION <= 0)
            {
                MessageBox.Show(
                    "La prescription est invalide.",
                    "Prescription",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            try
            {
                Database db = new Database();

                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();


                    // =================================================
                    // 1. INFORMATIONS DE LA PRESCRIPTION ET DU PATIENT
                    // =================================================

                    string queryPrescription = @"
                        SELECT
                            p.id,
                            p.patient_id,
                            p.medecin_id,
                            p.date_prescription,
                            p.statut,
                            p.observation,

                            pat.nom,
                            pat.post_nom,
                            pat.prenom

                        FROM prescription p

                        INNER JOIN patients pat
                            ON pat.id_patient = p.patient_id

                        WHERE p.id = @id_prescription
                        LIMIT 1";


                    using (MySqlCommand cmd =
                        new MySqlCommand(queryPrescription, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_prescription",
                            ID_PRESCRIPTION);


                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "La prescription n'existe pas.",
                                    "Prescription",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                return;
                            }


                            // -------------------------------------------------
                            // NOM DU PATIENT
                            // -------------------------------------------------

                            string nom =
                                reader["nom"] == DBNull.Value
                                    ? ""
                                    : reader["nom"].ToString();

                            string postNom =
                                reader["post_nom"] == DBNull.Value
                                    ? ""
                                    : reader["post_nom"].ToString();

                            string prenom =
                                reader["prenom"] == DBNull.Value
                                    ? ""
                                    : reader["prenom"].ToString();


                            string patient =
                                (nom + " " + postNom + " " + prenom)
                                .Trim();

                            lb_nom_patient.Text =
                                patient;


                            // -------------------------------------------------
                            // INFORMATIONS PRESCRIPTION
                            // -------------------------------------------------

                            DateTime datePrescription =
                                Convert.ToDateTime(
                                    reader["date_prescription"]);


                            lb_prescription.Text =
                                "Prescription #" +
                                ID_PRESCRIPTION.ToString() +
                                " - " +
                                datePrescription.ToString("dd/MM/yyyy");


                            // -------------------------------------------------
                            // STATUT DE LA PRESCRIPTION
                            // -------------------------------------------------

                            string statutPrescription =
                                reader["statut"] == DBNull.Value
                                    ? ""
                                    : reader["statut"].ToString();


                            if (!string.IsNullOrEmpty(statutPrescription))
                            {
                                lb_prescription.Text +=
                                    " (" + statutPrescription + ")";
                            }
                        }
                    }


                    // =================================================
                    // 2. CHARGER LES MEDICAMENTS
                    // =================================================

                    ChargerLignesPrescription(con);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement de la prescription.\n\n" +
                    ex.Message,
                    "Prescription",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // CHARGER LES LIGNES DE LA PRESCRIPTION
        // =========================================================

        private void ChargerLignesPrescription(
            MySqlConnection con)
        {
            dgv_presc.Rows.Clear();


            string query = @"
                SELECT
                    pl.id AS id_ligne,
                    pl.medicament_id,
                    m.nom AS produit,
                    pl.quantite_prescrite,

                    COALESCE(
                        (
                            SELECT SUM(dl.quantite)

                            FROM dispensation_ligne dl

                            INNER JOIN dispensation d
                                ON d.id = dl.dispensation_id

                            WHERE d.prescription_id = pl.prescription_id
                              AND dl.medicament_id = pl.medicament_id
                        ),
                        0
                    ) AS quantite_delivree

                FROM prescription_ligne pl

                INNER JOIN medicament m
                    ON m.id = pl.medicament_id

                WHERE pl.prescription_id = @id_prescription

                ORDER BY pl.id";


            using (MySqlCommand cmd =
                new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue(
                    "@id_prescription",
                    ID_PRESCRIPTION);


                using (MySqlDataReader reader =
                    cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idLigne =
                            Convert.ToInt32(
                                reader["id_ligne"]);


                        int medicamentId =
                            Convert.ToInt32(
                                reader["medicament_id"]);


                        string produit =
                            reader["produit"].ToString();


                        int quantitePrescrite =
                            Convert.ToInt32(
                                reader["quantite_prescrite"]);


                        int quantiteDelivree =
                            Convert.ToInt32(
                                reader["quantite_delivree"]);


                        string statut =
                            DeterminerStatut(
                                quantitePrescrite,
                                quantiteDelivree);


                        int index =
                            dgv_presc.Rows.Add(
                                produit,
                                quantitePrescrite,
                                quantiteDelivree,
                                statut);


                        // -------------------------------------------------
                        // Stocker les IDs dans la ligne
                        // -------------------------------------------------

                        dgv_presc.Rows[index]
                            .Tag = idLigne;


                        dgv_presc.Rows[index]
                            .Cells["Produit"]
                            .Tag = medicamentId;


                        // -------------------------------------------------
                        // Couleur du statut
                        // -------------------------------------------------

                        AppliquerStyleStatut(
                            dgv_presc.Rows[index]
                                .Cells["Statut"],
                            statut);
                    }
                }
            }


            // =====================================================
            // AUCUN MEDICAMENT
            // =====================================================

            if (dgv_presc.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Cette prescription ne contient aucun médicament.",
                    "Prescription",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }


            // =====================================================
            // ACTIVER / DESACTIVER LE BOUTON
            // =====================================================

            ActualiserBoutonDelivrer();
        }


        // =========================================================
        // DETERMINER LE STATUT D'UN MEDICAMENT
        // =========================================================

        private string DeterminerStatut(
            int quantitePrescrite,
            int quantiteDelivree)
        {
            if (quantiteDelivree <= 0)
            {
                return "En attente";
            }


            if (quantiteDelivree < quantitePrescrite)
            {
                return "Partiel";
            }


            return "Délivré";
        }


        // =========================================================
        // STYLE DU STATUT
        // =========================================================

        private void AppliquerStyleStatut(
            DataGridViewCell cell,
            string statut)
        {
            if (statut == "En attente")
            {
                cell.Style.ForeColor =
                    Color.DarkOrange;

                cell.Style.Font =
                    new Font(
                        dgv_presc.Font,
                        FontStyle.Bold);
            }
            else if (statut == "Partiel")
            {
                cell.Style.ForeColor =
                    Color.DarkBlue;

                cell.Style.Font =
                    new Font(
                        dgv_presc.Font,
                        FontStyle.Bold);
            }
            else if (statut == "Délivré")
            {
                cell.Style.ForeColor =
                    Color.Green;

                cell.Style.Font =
                    new Font(
                        dgv_presc.Font,
                        FontStyle.Bold);
            }
        }


        // =========================================================
        // ACTUALISER LE BOUTON DELIVRER
        // =========================================================

        private void ActualiserBoutonDelivrer()
        {
            btn_delivrer.Enabled = false;


            foreach (DataGridViewRow row
                in dgv_presc.Rows)
            {
                if (row.IsNewRow)
                    continue;


                string statut =
                    row.Cells["Statut"]
                       .Value == null
                        ? ""
                        : row.Cells["Statut"]
                            .Value.ToString();


                if (statut == "En attente" ||
                    statut == "Partiel")
                {
                    btn_delivrer.Enabled = true;

                    return;
                }
            }
        }


        // =========================================================
        // CLIC SUR DELIVRER
        // =========================================================

        private void btn_delivrer_Click(
            object sender,
            EventArgs e)
        {
            if (dgv_presc.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Aucun médicament à délivrer.",
                    "Dispensation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }


            // -----------------------------------------------------
            // Vérifier s'il reste quelque chose à délivrer
            // -----------------------------------------------------

            bool resteQuelqueChose = false;


            foreach (DataGridViewRow row
                in dgv_presc.Rows)
            {
                if (row.IsNewRow)
                    continue;


                string statut =
                    row.Cells["Statut"]
                       .Value == null
                        ? ""
                        : row.Cells["Statut"]
                            .Value.ToString();


                if (statut == "En attente" ||
                    statut == "Partiel")
                {
                    resteQuelqueChose = true;

                    break;
                }
            }


            if (!resteQuelqueChose)
            {
                MessageBox.Show(
                    "Tous les médicaments de cette prescription ont déjà été délivrés.",
                    "Dispensation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }


            // -----------------------------------------------------
            // Pour l'instant :
            // le bouton est prêt pour le formulaire de dispensation.
            // -----------------------------------------------------

            MessageBox.Show(
                "La prescription est prête pour la dispensation.",
                "Dispensation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);


            /*
             * PROCHAINE ETAPE
             * ----------------
             *
             * Ici nous ouvrirons le formulaire de dispensation.
             *
             * Ce formulaire devra :
             *
             * 1. Recevoir ID_PRESCRIPTION
             *
             * 2. Charger les médicaments restant à délivrer.
             *
             * 3. Calculer :
             *
             *    quantité restante =
             *    quantité prescrite - quantité déjà délivrée
             *
             * 4. Chercher les lots du médicament
             *    par ordre FIFO.
             *
             * 5. Prendre d'abord le premier lot.
             *
             * 6. Si le lot est insuffisant :
             *       passer au lot suivant.
             *
             * 7. Insérer les lignes dans :
             *
             *       dispensation
             *       dispensation_ligne
             *
             * 8. Décrémenter :
             *
             *       lot_medicament.quantite
             *
             * 9. Recharger cette fenêtre.
             */
        }


        // =========================================================
        // DOUBLE CLIC SUR UNE LIGNE
        // =========================================================

        private void dgv_presc_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            DataGridViewRow row =
                dgv_presc.Rows[e.RowIndex];


            string produit =
                row.Cells["Produit"]
                   .Value == null
                    ? ""
                    : row.Cells["Produit"]
                        .Value.ToString();


            string quantitePrescrite =
                row.Cells["QtePrescrit"]
                   .Value == null
                    ? "0"
                    : row.Cells["QtePrescrit"]
                        .Value.ToString();


            string quantiteDelivree =
                row.Cells["QteDelivre"]
                   .Value == null
                    ? "0"
                    : row.Cells["QteDelivre"]
                        .Value.ToString();


            string statut =
                row.Cells["Statut"]
                   .Value == null
                    ? ""
                    : row.Cells["Statut"]
                        .Value.ToString();


            MessageBox.Show(
                "Produit : " + produit +
                "\nQté prescrite : " + quantitePrescrite +
                "\nQté délivrée : " + quantiteDelivree +
                "\nStatut : " + statut,
                "Détail",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}