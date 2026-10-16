using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Cepima.Data;
using Cepima.MesForms;
using Cepima.MesUserCases;

namespace Cepima.MesUserCases.Pharmacie
{
    public partial class UC_inventory : UserControl
    {
        private Database db;

        private int inventaireSelectionneId = 0;

        private ModernDataGridView dgvInventaires;


        // =========================================================
        // CONSTRUCTEUR
        // =========================================================

        public UC_inventory()
        {
            InitializeComponent();

            db = new Database();

            Configurer();
        }


        // =========================================================
        // CONFIGURATION
        // =========================================================

        private void Configurer()
        {
            ConfigurerDataGridView();

            this.Load += UC_inventory_Load;

            tb_search.TextChanged +=
                tb_search_TextChanged;

            cbx_filter_category.SelectedIndexChanged +=
                cbx_filter_category_SelectedIndexChanged;

            btnValiderInventaire.Click +=
                btnValiderInventaire_Click;

            btnRetourInventaires.Click +=
                btnRetourInventaires_Click;

            btnValiderInventaire.Visible = false;
            btnRetourInventaires.Visible = false;
        }


        // =========================================================
        // LOAD
        // =========================================================

        private void UC_inventory_Load(
            object sender,
            EventArgs e)
        {
            ChargerInventaires();
        }


        // =========================================================
        // CONFIGURATION DATAGRIDVIEW
        // =========================================================

        private void ConfigurerDataGridView()
        {
            dgvInventaires =
                new ModernDataGridView();

            dgvInventaires.Name =
                "dgvInventaires";

            dgvInventaires.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            dgvInventaires.Location =
                new Point(0, 0);

            dgvInventaires.Size =
                new Size(
                    customRoundedPanel1.Width,
                    customRoundedPanel1.Height - 60);

            dgvInventaires.AutoGenerateColumns = false;
            dgvInventaires.AllowUserToAddRows = false;
            dgvInventaires.AllowUserToDeleteRows = false;
            dgvInventaires.ReadOnly = true;

            dgvInventaires.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvInventaires.MultiSelect = false;
            dgvInventaires.RowHeadersVisible = false;

            dgvInventaires.BackgroundColor =
                Color.White;

            dgvInventaires.BorderStyle =
                BorderStyle.None;

            dgvInventaires.HeaderBackColor =
                Color.DodgerBlue;

            dgvInventaires.HeaderForeColor =
                Color.White;

            dgvInventaires.HeaderHeight = 45;
            dgvInventaires.RowHeight = 42;

            dgvInventaires.BorderRadius = 1;

            dgvInventaires.OuterBorderSize = 1;

            dgvInventaires.OuterBorderColor =
                Color.LightGray;

            dgvInventaires.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvInventaires.EnableHeadersVisualStyles =
                false;

            AjouterColonnesInventaires();

            customRoundedPanel1.Controls.Add(
                dgvInventaires);
        }


        // =========================================================
        // COLONNES INVENTAIRES
        // =========================================================

        private void AjouterColonnesInventaires()
        {
            dgvInventaires.Columns.Clear();

            AjouterColonne(
                "id",
                "id",
                "",
                false);

            AjouterColonne(
                "inventaire",
                "inventaire",
                "Inventaire",
                true);

            AjouterColonne(
                "date_debut",
                "date_debut",
                "Date",
                true);

            AjouterColonne(
                "type",
                "type",
                "Type",
                true);

            AjouterColonne(
                "statut",
                "statut",
                "Statut",
                true);

            AjouterColonne(
                "nombre_lots",
                "nombre_lots",
                "Lots",
                true);

            AjouterColonne(
                "avec_ecart",
                "avec_ecart",
                "Avec écart",
                true);
        }


        private void AjouterColonne(
            string name,
            string dataPropertyName,
            string headerText,
            bool visible)
        {
            DataGridViewTextBoxColumn colonne =
                new DataGridViewTextBoxColumn();

            colonne.Name = name;
            colonne.DataPropertyName =
                dataPropertyName;

            colonne.HeaderText =
                headerText;

            colonne.Visible = visible;
            colonne.ReadOnly = true;

            dgvInventaires.Columns.Add(
                colonne);
        }


        // =========================================================
        // CHARGER LES INVENTAIRES
        // =========================================================

        private void ChargerInventaires()
        {
            try
            {
                inventaireSelectionneId = 0;

                btnValiderInventaire.Visible = false;
                btnRetourInventaires.Visible = false;

                dgvInventaires.DataSource = null;

                AjouterColonnesInventaires();

                using (MySqlConnection connection =
                    db.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            i.id,

                            CONCAT(
                                'Inventaire #',
                                i.id
                            ) AS inventaire,

                            DATE_FORMAT(
                                i.date_debut,
                                '%d/%m/%Y %H:%i'
                            ) AS date_debut,

                            i.type,
                            i.statut,

                            COUNT(il.id)
                                AS nombre_lots,

                            SUM(
                                CASE
                                    WHEN il.ecart <> 0
                                    THEN 1
                                    ELSE 0
                                END
                            ) AS avec_ecart

                        FROM inventaire i

                        LEFT JOIN inventaire_ligne il
                            ON il.inventaire_id = i.id

                        GROUP BY
                            i.id,
                            i.date_debut,
                            i.type,
                            i.statut

                        ORDER BY
                            i.id DESC";


                    using (MySqlDataAdapter adapter =
                        new MySqlDataAdapter(
                            query,
                            connection))
                    {
                        DataTable table =
                            new DataTable();

                        adapter.Fill(table);

                        dgvInventaires.DataSource =
                            table;
                    }
                }

                ChargerCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des inventaires :\n\n" +
                    ex.Message,
                    "Inventaire",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // CHARGER LES CARTES
        // =========================================================

        private void ChargerCards()
        {
            fl_med_category.SuspendLayout();

            try
            {
                fl_med_category.Controls.Clear();

                using (MySqlConnection connection =
                    db.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            i.id,
                            i.date_debut,
                            i.type,
                            i.statut,

                            COUNT(il.id)
                                AS nombre_lots

                        FROM inventaire i

                        LEFT JOIN inventaire_ligne il
                            ON il.inventaire_id = i.id

                        GROUP BY
                            i.id,
                            i.date_debut,
                            i.type,
                            i.statut

                        ORDER BY
                            i.id DESC

                        LIMIT 5";


                    using (MySqlCommand command =
                        new MySqlCommand(
                            query,
                            connection))
                    {
                        using (MySqlDataReader reader =
                            command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id =
                                    Convert.ToInt32(
                                        reader["id"]);

                                DateTime date =
                                    Convert.ToDateTime(
                                        reader["date_debut"]);

                                string type =
                                    Convert.ToString(
                                        reader["type"]);

                                string statut =
                                    Convert.ToString(
                                        reader["statut"]);

                                int lots =
                                    Convert.ToInt32(
                                        reader["nombre_lots"]);

                                AjouterCard(
                                    id,
                                    date,
                                    type,
                                    statut,
                                    lots);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des cartes :\n\n" +
                    ex.Message,
                    "Inventaire",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                fl_med_category.ResumeLayout(true);
            }
        }


        // =========================================================
        // CREER UNE CARD
        // =========================================================

        private void AjouterCard(
            int id,
            DateTime date,
            string type,
            string statut,
            int lots)
        {
            Panel card =
                new Panel();

            card.Width = 220;
            card.Height = 95;

            card.Margin =
                new Padding(6);

            card.BackColor =
                Color.White;

            card.BorderStyle =
                BorderStyle.FixedSingle;

            card.Cursor =
                Cursors.Hand;


            Label lblTitre =
                new Label();

            lblTitre.Text =
                "Inventaire #" + id;

            lblTitre.Font =
                new Font(
                    "Verdana",
                    10,
                    FontStyle.Bold);

            lblTitre.Location =
                new Point(12, 10);

            lblTitre.AutoSize = true;


            Label lblDate =
                new Label();

            lblDate.Text =
                date.ToString(
                    "dd/MM/yyyy HH:mm");

            lblDate.Font =
                new Font(
                    "Verdana",
                    8);

            lblDate.ForeColor =
                Color.Gray;

            lblDate.Location =
                new Point(12, 34);

            lblDate.AutoSize = true;


            Label lblLots =
                new Label();

            lblLots.Text =
                "Lots : " + lots;

            lblLots.Font =
                new Font(
                    "Verdana",
                    8);

            lblLots.Location =
                new Point(12, 56);

            lblLots.AutoSize = true;


            Label lblStatut =
                new Label();

            lblStatut.Text =
                statut;

            lblStatut.Font =
                new Font(
                    "Verdana",
                    8,
                    FontStyle.Bold);

            lblStatut.AutoSize = true;

            lblStatut.Location =
                new Point(125, 10);


            if (statut == "EN_COURS")
            {
                lblStatut.ForeColor =
                    Color.DarkOrange;
            }
            else
            {
                lblStatut.ForeColor =
                    Color.Green;
            }


            EventHandler ouvrir =
                delegate
                {
                    ChargerDetailInventaire(id);
                };


            card.Click += ouvrir;
            lblTitre.Click += ouvrir;
            lblDate.Click += ouvrir;
            lblLots.Click += ouvrir;
            lblStatut.Click += ouvrir;


            card.Controls.Add(
                lblTitre);

            card.Controls.Add(
                lblDate);

            card.Controls.Add(
                lblLots);

            card.Controls.Add(
                lblStatut);

            fl_med_category.Controls.Add(
                card);
        }


        // =========================================================
        // CHARGER DETAIL INVENTAIRE
        // =========================================================

        private void ChargerDetailInventaire(
            int inventaireId)
        {
            try
            {
                inventaireSelectionneId =
                    inventaireId;

                DataTable table =
                    new DataTable();

                string query = @"
                    SELECT

                        m.nom AS medicament,

                        CONCAT(

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

                        ) AS designation,

                        lm.numero_lot,
                        lm.date_expiration,

                        il.quantite_systeme,
                        il.quantite_comptee,
                        il.ecart

                    FROM inventaire_ligne il

                    INNER JOIN lot_medicament lm
                        ON lm.id = il.lot_id

                    INNER JOIN medicament m
                        ON m.id = lm.medicament_id

                    WHERE il.inventaire_id =
                          @inventaire_id

                    ORDER BY
                        m.nom ASC,
                        lm.date_expiration ASC";


                using (MySqlConnection connection =
                    db.GetConnection())
                {
                    connection.Open();

                    using (MySqlDataAdapter adapter =
                        new MySqlDataAdapter(
                            query,
                            connection))
                    {
                        adapter.SelectCommand
                            .Parameters.Add(
                                "@inventaire_id",
                                MySqlDbType.Int32)
                            .Value =
                                inventaireId;

                        adapter.Fill(table);
                    }
                }


                dgvInventaires.DataSource =
                    null;

                dgvInventaires.Columns.Clear();

                AjouterColonnesDetail();

                dgvInventaires.DataSource =
                    table;


                btnRetourInventaires.Visible =
                    true;


                string statut =
                    ObtenirStatutInventaire(
                        inventaireId);


                btnValiderInventaire.Visible =
                    statut == "EN_COURS";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du détail :\n\n" +
                    ex.Message,
                    "Inventaire",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // OBTENIR LE STATUT
        // =========================================================

        private string ObtenirStatutInventaire(
            int inventaireId)
        {
            try
            {
                using (MySqlConnection connection =
                    db.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT statut
                        FROM inventaire
                        WHERE id = @id";


                    using (MySqlCommand command =
                        new MySqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.Add(
                            "@id",
                            MySqlDbType.Int32)
                            .Value =
                                inventaireId;

                        object result =
                            command.ExecuteScalar();

                        return result == null
                            ? ""
                            : result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la récupération du statut :\n\n" +
                    ex.Message,
                    "Inventaire",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return "";
            }
        }


        // =========================================================
        // COLONNES DETAIL
        // =========================================================

        private void AjouterColonnesDetail()
        {
            AjouterColonne(
                "medicament",
                "medicament",
                "Médicament",
                true);

            AjouterColonne(
                "designation",
                "designation",
                "Dosage / Forme",
                true);

            AjouterColonne(
                "numero_lot",
                "numero_lot",
                "Lot",
                true);

            AjouterColonne(
                "date_expiration",
                "date_expiration",
                "Expiration",
                true);

            AjouterColonne(
                "quantite_systeme",
                "quantite_systeme",
                "Stock système",
                true);

            AjouterColonne(
                "quantite_comptee",
                "quantite_comptee",
                "Quantité comptée",
                true);

            AjouterColonne(
                "ecart",
                "ecart",
                "Écart",
                true);
        }


        // =========================================================
        // RECHERCHE
        // =========================================================

        private void tb_search_TextChanged(
            object sender,
            EventArgs e)
        {
            DataTable table =
                dgvInventaires.DataSource
                as DataTable;

            if (table == null)
                return;

            if (!table.Columns.Contains(
                "medicament"))
            {
                return;
            }


            string recherche =
                tb_search.Text.Trim();


            if (string.IsNullOrEmpty(recherche))
            {
                table.DefaultView.RowFilter = "";
                return;
            }


            recherche =
                recherche.Replace(
                    "'",
                    "''");


            table.DefaultView.RowFilter =
                "medicament LIKE '%" +
                recherche +
                "%'";
        }


        // =========================================================
        // FILTRE CATEGORIE
        // =========================================================

        private void cbx_filter_category_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            // À développer plus tard.
        }


        // =========================================================
        // NOUVEL INVENTAIRE
        // =========================================================

        private void btn_new_inventory_Click(
            object sender,
            EventArgs e)
        {
            MesForms.Pharmacie.Form_inventory form =
                new MesForms.Pharmacie.Form_inventory();


            if (form.ShowDialog() ==
                DialogResult.OK)
            {
                ChargerInventaires();
            }
        }


        // =========================================================
        // VALIDER L'INVENTAIRE
        // =========================================================

        private void btnValiderInventaire_Click(
            object sender,
            EventArgs e)
        {
            if (inventaireSelectionneId <= 0)
            {
                MessageBox.Show(
                    "Veuillez sélectionner un inventaire.",
                    "Inventaire",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            ValiderInventaire(
                inventaireSelectionneId);
        }


        // =========================================================
        // RETOUR À LA LISTE
        // =========================================================

        private void btnRetourInventaires_Click(
            object sender,
            EventArgs e)
        {
            AfficherListeInventaires();
        }


        private void AfficherListeInventaires()
        {
            inventaireSelectionneId = 0;

            btnValiderInventaire.Visible =
                false;

            btnRetourInventaires.Visible =
                false;

            ChargerInventaires();
        }


        // =========================================================
        // VALIDATION DE L'INVENTAIRE
        // =========================================================

        private void ValiderInventaire(
            int inventaireId)
        {
            DialogResult confirmation =
                MessageBox.Show(
                    "Voulez-vous vraiment valider cet inventaire ?\n\n" +
                    "Cette opération va ajuster les stocks selon les " +
                    "quantités comptées.",
                    "Validation de l'inventaire",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);


            if (confirmation !=
                DialogResult.Yes)
            {
                return;
            }


            using (MySqlConnection connection =
                db.GetConnection())
            {
                connection.Open();

                using (MySqlTransaction transaction =
                    connection.BeginTransaction())
                {
                    try
                    {
                        // =================================================
                        // 1. VERIFIER LE STATUT
                        // =================================================

                        string queryInventaire = @"
                            SELECT statut
                            FROM inventaire
                            WHERE id = @inventaire_id
                            FOR UPDATE";


                        string statut = "";


                        using (MySqlCommand command =
                            new MySqlCommand(
                                queryInventaire,
                                connection,
                                transaction))
                        {
                            command.Parameters.Add(
                                "@inventaire_id",
                                MySqlDbType.Int32)
                                .Value =
                                    inventaireId;

                            object result =
                                command.ExecuteScalar();


                            if (result == null)
                            {
                                throw new Exception(
                                    "Inventaire introuvable.");
                            }


                            statut =
                                result.ToString();
                        }


                        // =================================================
                        // 2. EMPECHER DOUBLE VALIDATION
                        // =================================================

                        if (statut != "EN_COURS")
                        {
                            throw new Exception(
                                "Cet inventaire a déjà été validé " +
                                "ou n'est plus disponible pour validation.");
                        }


                        // =================================================
                        // 3. CHARGER LES LIGNES
                        // =================================================

                        string queryLignes = @"
                            SELECT
                                il.id,
                                il.lot_id,
                                il.quantite_systeme,
                                il.quantite_comptee,
                                il.ecart

                            FROM inventaire_ligne il

                            WHERE il.inventaire_id =
                                  @inventaire_id

                            ORDER BY il.id ASC";


                        DataTable lignes =
                            new DataTable();


                        using (MySqlCommand command =
                            new MySqlCommand(
                                queryLignes,
                                connection,
                                transaction))
                        {
                            command.Parameters.Add(
                                "@inventaire_id",
                                MySqlDbType.Int32)
                                .Value =
                                    inventaireId;


                            using (MySqlDataReader reader =
                                command.ExecuteReader())
                            {
                                lignes.Load(reader);
                            }
                        }


                        // =================================================
                        // COMMANDES PREPAREES
                        // =================================================

                        using (MySqlCommand stockCommand =
                            new MySqlCommand(
                                @"
                                SELECT quantite
                                FROM lot_medicament
                                WHERE id = @lot_id
                                FOR UPDATE",
                                connection,
                                transaction))

                        using (MySqlCommand updateCommand =
                            new MySqlCommand(
                                @"
                                UPDATE lot_medicament
                                SET quantite = @quantite
                                WHERE id = @lot_id",
                                connection,
                                transaction))

                        using (MySqlCommand mouvementCommand =
                            new MySqlCommand(
                                @"
                                INSERT INTO mouvement_stock
                                (
                                    lot_id,
                                    type,
                                    quantite,
                                    reference,
                                    observation
                                )
                                VALUES
                                (
                                    @lot_id,
                                    'AJUSTEMENT',
                                    @quantite,
                                    @reference,
                                    @observation
                                )",
                                connection,
                                transaction))
                        {
                            // =============================================
                            // PARAMETRES STOCK
                            // =============================================

                            stockCommand.Parameters.Add(
                                "@lot_id",
                                MySqlDbType.Int32);


                            // =============================================
                            // PARAMETRES UPDATE
                            // =============================================

                            updateCommand.Parameters.Add(
                                "@quantite",
                                MySqlDbType.Int32);

                            updateCommand.Parameters.Add(
                                "@lot_id",
                                MySqlDbType.Int32);


                            // =============================================
                            // PARAMETRES MOUVEMENT
                            // =============================================

                            mouvementCommand.Parameters.Add(
                                "@lot_id",
                                MySqlDbType.Int32);

                            mouvementCommand.Parameters.Add(
                                "@quantite",
                                MySqlDbType.Int32);

                            mouvementCommand.Parameters.Add(
                                "@reference",
                                MySqlDbType.VarChar);

                            mouvementCommand.Parameters.Add(
                                "@observation",
                                MySqlDbType.VarChar);


                            // =============================================
                            // 4. TRAITER LES LOTS
                            // =============================================

                            foreach (DataRow ligne
                                in lignes.Rows)
                            {
                                int lotId =
                                    Convert.ToInt32(
                                        ligne["lot_id"]);

                                int quantiteSysteme =
                                    Convert.ToInt32(
                                        ligne["quantite_systeme"]);

                                int quantiteComptee =
                                    Convert.ToInt32(
                                        ligne["quantite_comptee"]);

                                int ecart =
                                    quantiteComptee -
                                    quantiteSysteme;


                                // Aucun écart
                                if (ecart == 0)
                                    continue;


                                // =========================================
                                // 5. VERIFIER STOCK ACTUEL
                                // =========================================

                                stockCommand.Parameters[
                                    "@lot_id"].Value =
                                        lotId;

                                object stock =
                                    stockCommand.ExecuteScalar();


                                if (stock == null)
                                {
                                    throw new Exception(
                                        "Le lot #" +
                                        lotId +
                                        " n'existe plus.");
                                }


                                int stockActuel =
                                    Convert.ToInt32(
                                        stock);


                                // =========================================
                                // 6. VERIFICATION CONCURRENCE
                                // =========================================

                                if (stockActuel !=
                                    quantiteSysteme)
                                {
                                    throw new Exception(
                                        "Le stock du lot #" +
                                        lotId +
                                        " a changé depuis le début " +
                                        "de l'inventaire.\n\n" +

                                        "Stock lors du comptage : " +
                                        quantiteSysteme +

                                        "\nStock actuel : " +
                                        stockActuel +

                                        "\n\nL'inventaire ne peut pas être " +
                                        "validé automatiquement.");
                                }


                                // =========================================
                                // 7. MODIFIER STOCK
                                // =========================================

                                updateCommand.Parameters[
                                    "@quantite"].Value =
                                        quantiteComptee;

                                updateCommand.Parameters[
                                    "@lot_id"].Value =
                                        lotId;

                                updateCommand.ExecuteNonQuery();


                                // =========================================
                                // 8. ENREGISTRER MOUVEMENT
                                // =========================================

                                mouvementCommand.Parameters[
                                    "@lot_id"].Value =
                                        lotId;

                                mouvementCommand.Parameters[
                                    "@quantite"].Value =
                                        ecart;

                                mouvementCommand.Parameters[
                                    "@reference"].Value =
                                        "INVENTAIRE-" +
                                        inventaireId;

                                mouvementCommand.Parameters[
                                    "@observation"].Value =
                                        "Ajustement suite à " +
                                        "l'inventaire #" +
                                        inventaireId;

                                mouvementCommand.ExecuteNonQuery();
                            }
                        }


                        // =================================================
                        // 9. TERMINER L'INVENTAIRE
                        // =================================================

                        string queryTerminer = @"
                            UPDATE inventaire

                            SET
                                statut = 'TERMINE',
                                date_fin = NOW()

                            WHERE id = @inventaire_id

                            AND statut = 'EN_COURS'";


                        using (MySqlCommand command =
                            new MySqlCommand(
                                queryTerminer,
                                connection,
                                transaction))
                        {
                            command.Parameters.Add(
                                "@inventaire_id",
                                MySqlDbType.Int32)
                                .Value =
                                    inventaireId;


                            int lignesModifiees =
                                command.ExecuteNonQuery();


                            if (lignesModifiees != 1)
                            {
                                throw new Exception(
                                    "Impossible de terminer l'inventaire.");
                            }
                        }


                        // =================================================
                        // 10. COMMIT
                        // =================================================

                        transaction.Commit();


                        MessageBox.Show(
                            "Inventaire #" +
                            inventaireId +
                            " validé avec succès.\n\n" +
                            "Les stocks ont été ajustés.",
                            "Inventaire",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);


                        // =================================================
                        // 11. RETOUR LISTE
                        // =================================================

                        inventaireSelectionneId = 0;

                        btnValiderInventaire.Visible =
                            false;

                        btnRetourInventaires.Visible =
                            false;

                        ChargerInventaires();
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch
                        {
                        }


                        MessageBox.Show(
                            "La validation a échoué.\n\n" +
                            ex.Message,
                            "Erreur",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}