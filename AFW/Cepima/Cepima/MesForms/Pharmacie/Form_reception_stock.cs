using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Cepima.Data;
using Cepima.MesUserCases;

namespace Cepima.MesForms.Pharmacie
{
    public partial class Form_reception_stock : Form
    {
        Database database = new Database();

        public Int32 ID_PRODUIT;

        public Form_reception_stock()
        {
            InitializeComponent();
            ID_PRODUIT = UC_stock_pharmacie.PROD_ID;

        }


        private void ChargerMedicaments()
        {
            try
            {
                using (MySqlConnection connection = database.GetConnection())
                {
                    connection.Open();

                    string query = @"
                SELECT
                    id,
                    CONCAT(
                        nom,
                        CASE
                            WHEN dosage IS NOT NULL
                            AND dosage <> ''
                            THEN CONCAT(' - ', dosage)
                            ELSE ''
                        END,
                        CASE
                            WHEN FORME IS NOT NULL
                            AND FORME <> ''
                            THEN CONCAT(' - ', FORME)
                            ELSE ''
                        END
                    ) AS designation
                FROM medicament
                WHERE actif = 1
                ORDER BY nom ASC";

                    using (MySqlCommand command =
                           new MySqlCommand(query, connection))
                    {
                        DataTable table = new DataTable();

                        using (MySqlDataAdapter adapter =
                               new MySqlDataAdapter(command))
                        {
                            adapter.Fill(table);
                        }

                        cbx_medicament.DataSource = table;
                        cbx_medicament.DisplayMember = "designation";
                        cbx_medicament.ValueMember = "id";
                        cbx_medicament.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Impossible de charger les médicaments.\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void bt_save_stock_Click(object sender, EventArgs e)
        {
            // =====================================================
            // VALIDATION
            // =====================================================

            if (cbx_medicament.SelectedIndex < 0 ||
                cbx_medicament.SelectedValue == null)
            {
                MessageBox.Show(
                    "Veuillez sélectionner un médicament.",
                    "Réception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cbx_medicament.Focus();

                return;
            }


            if (ud_quantite.Value <= 0)
            {
                MessageBox.Show(
                    "La quantité doit être supérieure à zéro.",
                    "Réception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                ud_quantite.Focus();

                return;
            }


            string numeroLot =
                tb_numero_lot.Text.Trim();


            if (string.IsNullOrWhiteSpace(numeroLot))
            {
                MessageBox.Show(
                    "Veuillez entrer le numéro de lot.",
                    "Réception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_numero_lot.Focus();

                return;
            }


            if (dtp_expiration_date.Value.Date <= DateTime.Today)
            {
                MessageBox.Show(
                    "La date d'expiration doit être ultérieure à aujourd'hui.",
                    "Réception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                dtp_expiration_date.Focus();

                return;
            }


            int medicamentId =
                Convert.ToInt32(
                    cbx_medicament.SelectedValue);

            int quantite =
                Convert.ToInt32(
                    ud_quantite.Value);

            DateTime expiration =
                dtp_expiration_date.Value.Date;


            // =====================================================
            // TRANSACTION
            // =====================================================

            MySqlConnection connection = null;
            MySqlTransaction transaction = null;

            try
            {
                connection =
                    database.GetConnection();

                connection.Open();

                transaction =
                    connection.BeginTransaction();


                // =================================================
                // 1. VÉRIFIER SI LE LOT EXISTE DÉJÀ
                // =================================================

                string checkLotQuery = @"
            SELECT id
            FROM lot_medicament
            WHERE medicament_id = @medicament_id
              AND numero_lot = @numero_lot
            LIMIT 1";


                int lotId = 0;


                using (MySqlCommand command =
                       new MySqlCommand(
                           checkLotQuery,
                           connection,
                           transaction))
                {
                    command.Parameters.AddWithValue(
                        "@medicament_id",
                        medicamentId);

                    command.Parameters.AddWithValue(
                        "@numero_lot",
                        numeroLot);


                    object result =
                        command.ExecuteScalar();


                    if (result != null)
                    {
                        lotId =
                            Convert.ToInt32(result);
                    }
                }


                // =================================================
                // 2. CRÉER OU METTRE À JOUR LE LOT
                // =================================================

                if (lotId == 0)
                {
                    string insertLotQuery = @"
                INSERT INTO lot_medicament
                (
                    medicament_id,
                    numero_lot,
                    date_expiration,
                    quantite
                )
                VALUES
                (
                    @medicament_id,
                    @numero_lot,
                    @date_expiration,
                    @quantite
                )";


                    using (MySqlCommand command =
                           new MySqlCommand(
                               insertLotQuery,
                               connection,
                               transaction))
                    {
                        command.Parameters.AddWithValue(
                            "@medicament_id",
                            medicamentId);

                        command.Parameters.AddWithValue(
                            "@numero_lot",
                            numeroLot);

                        command.Parameters.AddWithValue(
                            "@date_expiration",
                            expiration);

                        command.Parameters.AddWithValue(
                            "@quantite",
                            quantite);


                        command.ExecuteNonQuery();


                        lotId =
                            Convert.ToInt32(
                                command.LastInsertedId);
                    }
                }
                else
                {
                    string updateLotQuery = @"
                UPDATE lot_medicament
                SET
                    quantite = quantite + @quantite,
                    date_expiration = @date_expiration
                WHERE id = @lot_id";


                    using (MySqlCommand command =
                           new MySqlCommand(
                               updateLotQuery,
                               connection,
                               transaction))
                    {
                        command.Parameters.AddWithValue(
                            "@quantite",
                            quantite);

                        command.Parameters.AddWithValue(
                            "@date_expiration",
                            expiration);

                        command.Parameters.AddWithValue(
                            "@lot_id",
                            lotId);


                        command.ExecuteNonQuery();
                    }
                }


                // =================================================
                // 3. CRÉER LE MOUVEMENT DE STOCK
                // =================================================

                string insertMovementQuery = @"
            INSERT INTO mouvement_stock
            (
                lot_id,
                type,
                quantite,
                date_mouvement,
                reference,
                observation
            )
            VALUES
            (
                @lot_id,
                'ENTREE',
                @quantite,
                NOW(),
                @reference,
                @observation
            )";


                using (MySqlCommand command =
                       new MySqlCommand(
                           insertMovementQuery,
                           connection,
                           transaction))
                {
                    command.Parameters.AddWithValue(
                        "@lot_id",
                        lotId);

                    command.Parameters.AddWithValue(
                        "@quantite",
                        quantite);

                    command.Parameters.AddWithValue(
                        "@reference",
                        numeroLot);

                    command.Parameters.AddWithValue(
                        "@observation",
                        "Réception de stock");


                    command.ExecuteNonQuery();
                }


                // =================================================
                // 4. VALIDATION
                // =================================================

                transaction.Commit();


                MessageBox.Show(
                    "La réception a été enregistrée avec succès.",
                    "Réception de stock",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();

                Form_detail_produit.BT_REFRESH.PerformClick();

                // Nettoyage du formulaire
                cbx_medicament.SelectedIndex = -1;

                ud_quantite.Value = 1;

                tb_numero_lot.Text = "";

                dtp_expiration_date.Value =
                    DateTime.Today.AddYears(1);

                cbx_medicament.Focus();

            }
            catch (Exception ex)
            {
                // =================================================
                // ANNULATION
                // =================================================

                if (transaction != null)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {
                    }
                }


                MessageBox.Show(
                    "La réception n'a pas pu être enregistrée.\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        private void Form_reception_stock_Load(object sender, EventArgs e)
        {
            ChargerMedicaments();

            cbx_medicament.SelectedValue = ID_PRODUIT;
            ud_quantite.Minimum = 1;
            ud_quantite.Value = 1;
            dtp_expiration_date.MinDate = DateTime.Today;
            dtp_expiration_date.Value = DateTime.Today.AddYears(1);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
