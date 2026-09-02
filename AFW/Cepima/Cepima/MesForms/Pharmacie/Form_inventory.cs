using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Cepima.Data;

namespace Cepima.MesForms.Pharmacie
{
    public partial class Form_inventory : Form
    {
        private Database db;

        public Form_inventory()
        {
            InitializeComponent();

            db = new Database();

            ConfigurerInventaire();
        }

        // =========================================================
        // CONFIGURATION
        // =========================================================

        private void ConfigurerInventaire()
        {
            ConfigurerGrid();

            dgvInventaire.ColumnHeadersDefaultCellStyle.BackColor =
                Color.DodgerBlue;

            dgvInventaire.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvInventaire.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Verdana",
                    12,
                    FontStyle.Bold);

            dgvInventaire.CellValueChanged +=
                dgvInventaire_CellValueChanged;

            dgvInventaire.CurrentCellDirtyStateChanged +=
                dgvInventaire_CurrentCellDirtyStateChanged;

            btnEnregistrer.Click +=
                btnEnregistrer_Click;

            dgvInventaire.EditingControlShowing +=
                dgvInventaire_EditingControlShowing;

            dgvInventaire.DataError +=
                dgvInventaire_DataError;

            this.Load +=
                Form_inventory_Load;
        }

        // =========================================================
        // CONFIGURATION DU GRID
        // =========================================================

        private void ConfigurerGrid()
        {
            dgvInventaire.AutoGenerateColumns = false;

            dgvInventaire.AllowUserToAddRows = false;
            dgvInventaire.AllowUserToDeleteRows = false;
            dgvInventaire.AllowUserToResizeRows = false;

            dgvInventaire.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvInventaire.MultiSelect = false;

            dgvInventaire.RowHeadersVisible = false;

            dgvInventaire.BorderStyle =
                BorderStyle.None;

            dgvInventaire.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvInventaire.GridColor =
                Color.White;

            dgvInventaire.BackgroundColor =
                Color.White;

            dgvInventaire.EnableHeadersVisualStyles =
                false;

            // =========================================================
            // DESIGN MODERN DATAGRIDVIEW
            // =========================================================

            dgvInventaire.HeaderBackColor =
                Color.DodgerBlue;

            dgvInventaire.HeaderForeColor =
                Color.White;

            dgvInventaire.HeaderHeight =
                45;

            dgvInventaire.RowHeight =
                42;

            dgvInventaire.BorderRadius =
                1;

            dgvInventaire.OuterBorderSize =
                1;

            dgvInventaire.OuterBorderColor =
                Color.LightGray;

            // =========================================================
            // STYLE EN-TÊTE
            // =========================================================

            dgvInventaire.ColumnHeadersDefaultCellStyle =
                new DataGridViewCellStyle
                {
                    Alignment =
                        DataGridViewContentAlignment.MiddleLeft,

                    BackColor =
                        Color.DodgerBlue,

                    ForeColor =
                        Color.White,

                    Font =
                        new Font(
                            "Segoe UI",
                            10F,
                            FontStyle.Bold),

                    SelectionBackColor =
                        Color.DodgerBlue,

                    SelectionForeColor =
                        Color.White,

                    WrapMode =
                        DataGridViewTriState.False
                };

            // =========================================================
            // STYLE DES CELLULES
            // =========================================================

            dgvInventaire.DefaultCellStyle =
                new DataGridViewCellStyle
                {
                    Alignment =
                        DataGridViewContentAlignment.MiddleLeft,

                    BackColor =
                        Color.White,

                    ForeColor =
                        Color.Black,

                    Font =
                        new Font(
                            "Segoe UI",
                            10F),

                    SelectionBackColor =
                        Color.LightBlue,

                    SelectionForeColor =
                        Color.Black,

                    WrapMode =
                        DataGridViewTriState.False
                };

            // =========================================================
            // PAS D'ALTERNANCE DE COULEUR
            // =========================================================

            dgvInventaire.AlternatingRowsDefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor =
                        Color.White,

                    ForeColor =
                        Color.Black,

                    SelectionBackColor =
                        Color.LightBlue,

                    SelectionForeColor =
                        Color.Black
                };

            // =========================================================
            // HAUTEUR DES LIGNES
            // =========================================================

            dgvInventaire.RowTemplate.Height =
                42;

            // =========================================================
            // COLONNES
            // =========================================================

            dgvInventaire.Columns.Clear();


            // =========================================================
            // ID DU LOT
            // =========================================================

            DataGridViewTextBoxColumn colLotId =
                new DataGridViewTextBoxColumn();

            colLotId.Name = "lot_id";
            colLotId.HeaderText = "ID";
            colLotId.DataPropertyName = "lot_id";
            colLotId.Visible = false;

            dgvInventaire.Columns.Add(colLotId);


            // =========================================================
            // MÉDICAMENT
            // =========================================================

            DataGridViewTextBoxColumn colMedicament =
                new DataGridViewTextBoxColumn();

            colMedicament.Name = "medicament";
            colMedicament.HeaderText = "Médicament";
            colMedicament.DataPropertyName = "medicament";
            colMedicament.ReadOnly = true;

            dgvInventaire.Columns.Add(colMedicament);


            // =========================================================
            // LOT
            // =========================================================

            DataGridViewTextBoxColumn colLot =
                new DataGridViewTextBoxColumn();

            colLot.Name = "numero_lot";
            colLot.HeaderText = "N° Lot";
            colLot.DataPropertyName = "numero_lot";
            colLot.ReadOnly = true;

            dgvInventaire.Columns.Add(colLot);


            // =========================================================
            // EXPIRATION
            // =========================================================

            DataGridViewTextBoxColumn colExpiration =
                new DataGridViewTextBoxColumn();

            colExpiration.Name = "date_expiration";
            colExpiration.HeaderText = "Expiration";
            colExpiration.DataPropertyName = "date_expiration";
            colExpiration.ReadOnly = true;

            dgvInventaire.Columns.Add(colExpiration);


            // =========================================================
            // STOCK SYSTÈME
            // =========================================================

            DataGridViewTextBoxColumn colSysteme =
                new DataGridViewTextBoxColumn();

            colSysteme.Name = "quantite_systeme";
            colSysteme.HeaderText = "Stock système";
            colSysteme.DataPropertyName = "quantite_systeme";
            colSysteme.ReadOnly = true;

            dgvInventaire.Columns.Add(colSysteme);


            // =========================================================
            // QUANTITÉ COMPTÉE
            // =========================================================

            DataGridViewTextBoxColumn colComptee =
                new DataGridViewTextBoxColumn();

            colComptee.Name = "quantite_comptee";
            colComptee.HeaderText = "Quantité comptée";
            colComptee.DataPropertyName = "quantite_comptee";
            colComptee.ReadOnly = false;

            dgvInventaire.Columns.Add(colComptee);


            // =========================================================
            // ÉCART
            // =========================================================

            DataGridViewTextBoxColumn colEcart =
                new DataGridViewTextBoxColumn();

            colEcart.Name = "ecart";
            colEcart.HeaderText = "Écart";
            colEcart.DataPropertyName = "ecart";
            colEcart.ReadOnly = true;

            dgvInventaire.Columns.Add(colEcart);


            // =========================================================
            // LARGEUR DES COLONNES
            // =========================================================

            dgvInventaire.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvInventaire.Columns["medicament"]
                .FillWeight = 200;

            dgvInventaire.Columns["numero_lot"]
                .FillWeight = 100;

            dgvInventaire.Columns["date_expiration"]
                .FillWeight = 110;

            dgvInventaire.Columns["quantite_systeme"]
                .FillWeight = 100;

            dgvInventaire.Columns["quantite_comptee"]
                .FillWeight = 120;

            dgvInventaire.Columns["ecart"]
                .FillWeight = 80;
        }

        // =========================================================
        // LOAD
        // =========================================================

        private void Form_inventory_Load(
            object sender,
            EventArgs e)
        {
            lb_respo_value.Text =
                MesClasses.SessionUtilisateur.Nom;

            dgvInventaire.HeaderHeight = 45;
            dgvInventaire.RowHeight = 42;

            ChargerLots();
        }

        // =========================================================
        // CHARGER LES LOTS
        // =========================================================

        private void ChargerLots()
        {
            try
            {
                using (MySqlConnection connection =
                       db.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            lm.id AS lot_id,

                            CONCAT(
                                m.nom,

                                CASE
                                    WHEN m.dosage IS NOT NULL
                                         AND m.dosage <> ''
                                    THEN CONCAT(
                                        ' - ',
                                        m.dosage
                                    )
                                    ELSE ''
                                END,

                                CASE
                                    WHEN m.FORME IS NOT NULL
                                         AND m.FORME <> ''
                                    THEN CONCAT(
                                        ' - ',
                                        m.FORME
                                    )
                                    ELSE ''
                                END

                            ) AS medicament,

                            lm.numero_lot,

                            lm.date_expiration,

                            lm.quantite AS quantite_systeme

                        FROM lot_medicament lm

                        INNER JOIN medicament m
                            ON m.id = lm.medicament_id

                        WHERE m.actif = 1

                        ORDER BY
                            m.nom ASC,
                            lm.date_expiration ASC";

                    using (MySqlDataAdapter adapter =
                           new MySqlDataAdapter(
                               query,
                               connection))
                    {
                        DataTable table =
                            new DataTable();

                        adapter.Fill(table);


                        // =================================================
                        // Colonnes propres à l'inventaire
                        // =================================================

                        table.Columns.Add(
                            "quantite_comptee",
                            typeof(int));

                        table.Columns.Add(
                            "ecart",
                            typeof(int));


                        dgvInventaire.DataSource =
                            table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement :\n\n" +
                    ex.Message,
                    "Inventaire",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // CALCUL AUTOMATIQUE DE L'ÉCART
        // =========================================================

        private void dgvInventaire_CellValueChanged(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex < 0)
                return;

            if (dgvInventaire.Columns[
                    e.ColumnIndex].Name !=
                "quantite_comptee")
            {
                return;
            }


            DataGridViewRow row =
                dgvInventaire.Rows[
                    e.RowIndex];


            int quantiteSysteme = 0;

            int quantiteComptee = 0;


            int.TryParse(
                Convert.ToString(
                    row.Cells[
                        "quantite_systeme"].Value),
                out quantiteSysteme);


            string valeur =
                Convert.ToString(
                    row.Cells[
                        "quantite_comptee"].Value);


            // ---------------------------------------------------------
            // Quantité vide
            // ---------------------------------------------------------

            if (string.IsNullOrWhiteSpace(valeur))
            {
                row.Cells[
                    "ecart"].Value = "";

                row.Cells[
                    "ecart"].Style.ForeColor =
                    Color.Gray;

                return;
            }


            if (!int.TryParse(
                    valeur,
                    out quantiteComptee))
            {
                row.Cells[
                    "ecart"].Value = "";

                return;
            }


            // ---------------------------------------------------------
            // Calcul
            // ---------------------------------------------------------

            int ecart =
                quantiteComptee -
                quantiteSysteme;


            row.Cells[
                "ecart"].Value =
                ecart;


            if (ecart < 0)
            {
                row.Cells[
                    "ecart"].Style.ForeColor =
                    Color.Red;
            }
            else if (ecart > 0)
            {
                row.Cells[
                    "ecart"].Style.ForeColor =
                    Color.Green;
            }
            else
            {
                row.Cells[
                    "ecart"].Style.ForeColor =
                    Color.Gray;
            }
        }

        // =========================================================
        // COMMIT CELLULE
        // =========================================================

        private void dgvInventaire_CurrentCellDirtyStateChanged(
            object sender,
            EventArgs e)
        {
            if (dgvInventaire.IsCurrentCellDirty)
            {
                dgvInventaire.CommitEdit(
                    DataGridViewDataErrorContexts.Commit);
            }
        }

        // =========================================================
        // CONTRÔLE DE SAISIE
        // =========================================================

        private void dgvInventaire_EditingControlShowing(
            object sender,
            DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt =
                e.Control as TextBox;

            if (txt == null)
                return;


            txt.KeyPress -=
                Quantite_KeyPress;


            if (dgvInventaire.CurrentCell != null &&
                dgvInventaire.CurrentCell
                    .OwningColumn.Name ==
                "quantite_comptee")
            {
                txt.KeyPress +=
                    Quantite_KeyPress;
            }
        }

        // =========================================================
        // ERREUR DATAGRIDVIEW
        // =========================================================

        private void dgvInventaire_DataError(
            object sender,
            DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex >= 0 &&
                dgvInventaire.Columns[
                    e.ColumnIndex].Name ==
                "quantite_comptee")
            {
                MessageBox.Show(
                    "La quantité comptée doit être " +
                    "un nombre entier.",
                    "Quantité incorrecte",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                e.ThrowException =
                    false;

                e.Cancel =
                    false;
            }
        }

        // =========================================================
        // AUTORISER UNIQUEMENT LES CHIFFRES
        // =========================================================

        private void Quantite_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled =
                    true;
            }
        }

        // =========================================================
        // BOUTON ENREGISTRER
        // =========================================================

        private void btnEnregistrer_Click(
            object sender,
            EventArgs e)
        {
            if (dgvInventaire.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Aucun lot à inventorier.",
                    "Inventaire",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // =====================================================
            // Vérifier les quantités
            // =====================================================

            foreach (DataGridViewRow row
                     in dgvInventaire.Rows)
            {
                if (row.IsNewRow)
                    continue;


                object valeur =
                    row.Cells[
                        "quantite_comptee"].Value;


                int quantite;


                if (valeur == null ||
                    !int.TryParse(
                        valeur.ToString(),
                        out quantite) ||
                    quantite < 0)
                {
                    MessageBox.Show(
                        "Veuillez saisir une quantité " +
                        "valide pour tous les lots.",
                        "Inventaire",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }


            // =====================================================
            // Confirmation
            // =====================================================

            DialogResult resultat =
                MessageBox.Show(
                    "Voulez-vous enregistrer cet inventaire ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);


            if (resultat != DialogResult.Yes)
                return;


            EnregistrerInventaire();
        }

        // =========================================================
        // ENREGISTRER L'INVENTAIRE
        // =========================================================

        private void EnregistrerInventaire()
        {
            using (MySqlConnection connection =
                   db.GetConnection())
            {
                connection.Open();


                MySqlTransaction transaction =
                    connection.BeginTransaction();


                try
                {
                    // =================================================
                    // CRÉATION DE L'INVENTAIRE
                    // =================================================

                    string queryInventaire = @"
                        INSERT INTO inventaire
                        (
                            responsable_id,
                            type,
                            statut,
                            observation
                        )
                        VALUES
                        (
                            @responsable_id,
                            'COMPLET',
                            'EN_COURS',
                            @observation
                        )";


                    int inventaireId;


                    using (MySqlCommand command =
                           new MySqlCommand(
                               queryInventaire,
                               connection,
                               transaction))
                    {
                        // TEMPORAIRE
                        // Nous remplacerons ceci par
                        // l'ID de l'utilisateur connecté.

                        int responsableId =
                            1;


                        command.Parameters.AddWithValue(
                            "@responsable_id",
                            responsableId);


                        command.Parameters.AddWithValue(
                            "@observation",
                            txtObservation.Text.Trim());


                        command.ExecuteNonQuery();


                        inventaireId =
                            Convert.ToInt32(
                                command.LastInsertedId);
                    }


                    // =================================================
                    // CRÉATION DES LIGNES
                    // =================================================

                    string queryLigne = @"
                        INSERT INTO inventaire_ligne
                        (
                            inventaire_id,
                            lot_id,
                            quantite_systeme,
                            quantite_comptee,
                            ecart
                        )
                        VALUES
                        (
                            @inventaire_id,
                            @lot_id,
                            @quantite_systeme,
                            @quantite_comptee,
                            @ecart
                        )";


                    foreach (DataGridViewRow row
                             in dgvInventaire.Rows)
                    {
                        if (row.IsNewRow)
                            continue;


                        int lotId =
                            Convert.ToInt32(
                                row.Cells[
                                    "lot_id"].Value);


                        int quantiteSysteme =
                            Convert.ToInt32(
                                row.Cells[
                                    "quantite_systeme"].Value);


                        int quantiteComptee =
                            Convert.ToInt32(
                                row.Cells[
                                    "quantite_comptee"].Value);


                        int ecart =
                            quantiteComptee -
                            quantiteSysteme;


                        using (MySqlCommand command =
                               new MySqlCommand(
                                   queryLigne,
                                   connection,
                                   transaction))
                        {
                            command.Parameters.AddWithValue(
                                "@inventaire_id",
                                inventaireId);


                            command.Parameters.AddWithValue(
                                "@lot_id",
                                lotId);


                            command.Parameters.AddWithValue(
                                "@quantite_systeme",
                                quantiteSysteme);


                            command.Parameters.AddWithValue(
                                "@quantite_comptee",
                                quantiteComptee);


                            command.Parameters.AddWithValue(
                                "@ecart",
                                ecart);


                            command.ExecuteNonQuery();
                        }
                    }


                    // =================================================
                    // COMMIT
                    // =================================================

                    transaction.Commit();


                    MessageBox.Show(
                        "Inventaire enregistré avec succès.\n\n" +
                        "N° inventaire : " +
                        inventaireId,
                        "Inventaire",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);


                    // Permet à UC_inventory de savoir
                    // que la création s'est terminée correctement.

                    this.DialogResult =
                        DialogResult.OK;


                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();


                    MessageBox.Show(
                        "Erreur lors de l'enregistrement :\n\n" +
                        ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}