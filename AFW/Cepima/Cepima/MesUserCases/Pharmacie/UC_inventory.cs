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

        // ID de l'inventaire actuellement ouvert
        private int inventaireSelectionneId = 0;

        // Notre ModernDataGridView
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

            this.Load +=
                UC_inventory_Load;

            tb_search.TextChanged +=
                tb_search_TextChanged;

            cbx_filter_category.SelectedIndexChanged +=
                cbx_filter_category_SelectedIndexChanged;


            // =====================================================
            // ÉVÉNEMENTS DES BOUTONS
            // =====================================================

            btnValiderInventaire.Click +=
                btnValiderInventaire_Click;

            btnRetourInventaires.Click +=
                btnRetourInventaires_Click;


            // =====================================================
            // AU DÉPART : BOUTONS CACHÉS
            // =====================================================

            btnValiderInventaire.Visible =
                false;

            btnRetourInventaires.Visible =
                false;
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
        // CONFIGURATION MODERN DATAGRIDVIEW
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

            dgvInventaires.AutoGenerateColumns =
                false;

            dgvInventaires.AllowUserToAddRows =
                false;

            dgvInventaires.AllowUserToDeleteRows =
                false;

            dgvInventaires.ReadOnly =
                true;

            dgvInventaires.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvInventaires.MultiSelect =
                false;

            dgvInventaires.RowHeadersVisible =
                false;

            dgvInventaires.BackgroundColor =
                Color.White;

            dgvInventaires.BorderStyle =
                BorderStyle.None;

            // =====================================================
            // APPARENCE MODERNE
            // =====================================================

            dgvInventaires.HeaderBackColor =
                Color.DodgerBlue;

            dgvInventaires.HeaderForeColor =
                Color.White;

            dgvInventaires.HeaderHeight =
                45;

            dgvInventaires.RowHeight =
                42;

            dgvInventaires.BorderRadius =
                1;

            dgvInventaires.OuterBorderSize =
                1;

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
        // COLONNES LISTE DES INVENTAIRES
        // =========================================================

        private void AjouterColonnesInventaires()
        {
            dgvInventaires.Columns.Clear();


            // =====================================================
            // ID
            // =====================================================

            DataGridViewTextBoxColumn colId =
                new DataGridViewTextBoxColumn();

            colId.Name =
                "id";

            colId.DataPropertyName =
                "id";

            colId.Visible =
                false;

            dgvInventaires.Columns.Add(
                colId);


            // =====================================================
            // INVENTAIRE
            // =====================================================

            DataGridViewTextBoxColumn colInventaire =
                new DataGridViewTextBoxColumn();

            colInventaire.Name =
                "inventaire";

            colInventaire.HeaderText =
                "Inventaire";

            colInventaire.DataPropertyName =
                "inventaire";

            colInventaire.ReadOnly =
                true;

            dgvInventaires.Columns.Add(
                colInventaire);


            // =====================================================
            // DATE
            // =====================================================

            DataGridViewTextBoxColumn colDate =
                new DataGridViewTextBoxColumn();

            colDate.Name =
                "date_debut";

            colDate.HeaderText =
                "Date";

            colDate.DataPropertyName =
                "date_debut";

            colDate.ReadOnly =
                true;

            dgvInventaires.Columns.Add(
                colDate);


            // =====================================================
            // TYPE
            // =====================================================

            DataGridViewTextBoxColumn colType =
                new DataGridViewTextBoxColumn();

            colType.Name =
                "type";

            colType.HeaderText =
                "Type";

            colType.DataPropertyName =
                "type";

            colType.ReadOnly =
                true;

            dgvInventaires.Columns.Add(
                colType);


            // =====================================================
            // STATUT
            // =====================================================

            DataGridViewTextBoxColumn colStatut =
                new DataGridViewTextBoxColumn();

            colStatut.Name =
                "statut";

            colStatut.HeaderText =
                "Statut";

            colStatut.DataPropertyName =
                "statut";

            colStatut.ReadOnly =
                true;

            dgvInventaires.Columns.Add(
                colStatut);


            // =====================================================
            // LOTS
            // =====================================================

            DataGridViewTextBoxColumn colLots =
                new DataGridViewTextBoxColumn();

            colLots.Name =
                "nombre_lots";

            colLots.HeaderText =
                "Lots";

            colLots.DataPropertyName =
                "nombre_lots";

            colLots.ReadOnly =
                true;

            dgvInventaires.Columns.Add(
                colLots);


            // =====================================================
            // ÉCARTS
            // =====================================================

            DataGridViewTextBoxColumn colEcarts =
                new DataGridViewTextBoxColumn();

            colEcarts.Name =
                "avec_ecart";

            colEcarts.HeaderText =
                "Avec écart";

            colEcarts.DataPropertyName =
                "avec_ecart";

            colEcarts.ReadOnly =
                true;

            dgvInventaires.Columns.Add(
                colEcarts);
        }


        // =========================================================
        // CHARGER LES INVENTAIRES
        // =========================================================

        private void ChargerInventaires()
        {
            try
            {
                // On revient au mode liste
                inventaireSelectionneId =
                    0;

                btnValiderInventaire.Visible =
                    false;

                btnRetourInventaires.Visible =
                    false;


                // Recréer les colonnes de la liste
                dgvInventaires.DataSource =
                    null;

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
                            ON il.inventaire_id =
                               i.id

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
        // CHARGER LES CARDS
        // =========================================================

        private void ChargerCards()
        {
            fl_med_category.Controls.Clear();

            try
            {
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
                            ON il.inventaire_id =
                               i.id

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
        }


        // =========================================================
        // CRÉER UNE CARD
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

            card.Width =
                220;

            card.Height =
                95;

            card.Margin =
                new Padding(6);

            card.BackColor =
                Color.White;

            card.BorderStyle =
                BorderStyle.FixedSingle;

            card.Cursor =
                Cursors.Hand;


            // =====================================================
            // TITRE
            // =====================================================

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
                new Point(
                    12,
                    10);

            lblTitre.AutoSize =
                true;


            // =====================================================
            // DATE
            // =====================================================

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
                new Point(
                    12,
                    34);

            lblDate.AutoSize =
                true;


            // =====================================================
            // LOTS
            // =====================================================

            Label lblLots =
                new Label();

            lblLots.Text =
                "Lots : " + lots;

            lblLots.Font =
                new Font(
                    "Verdana",
                    8);

            lblLots.Location =
                new Point(
                    12,
                    56);

            lblLots.AutoSize =
                true;


            // =====================================================
            // STATUT
            // =====================================================

            Label lblStatut =
                new Label();

            lblStatut.Text =
                statut;

            lblStatut.Font =
                new Font(
                    "Verdana",
                    8,
                    FontStyle.Bold);

            lblStatut.AutoSize =
                true;

            lblStatut.Location =
                new Point(
                    125,
                    10);


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


            // =====================================================
            // CLICK CARD
            // =====================================================

            card.Click += delegate
            {
                ChargerDetailInventaire(id);
            };

            lblTitre.Click += delegate
            {
                ChargerDetailInventaire(id);
            };

            lblDate.Click += delegate
            {
                ChargerDetailInventaire(id);
            };

            lblLots.Click += delegate
            {
                ChargerDetailInventaire(id);
            };

            lblStatut.Click += delegate
            {
                ChargerDetailInventaire(id);
            };


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
                // =================================================
                // MÉMORISER L'INVENTAIRE
                // =================================================

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
                        adapter.SelectCommand.Parameters.AddWithValue(
                            "@inventaire_id",
                            inventaireId);

                        adapter.Fill(table);
                    }
                }


                // =================================================
                // RECONFIGURER LE GRID POUR LE DETAIL
                // =================================================

                dgvInventaires.DataSource =
                    null;

                dgvInventaires.Columns.Clear();

                AjouterColonnesDetail();

                dgvInventaires.DataSource =
                    table;


                // =================================================
                // AFFICHER LES BOUTONS
                // =================================================

                btnRetourInventaires.Visible =
                    true;


                string statut =
                    ObtenirStatutInventaire(
                        inventaireId);


                if (statut == "EN_COURS")
                {
                    btnValiderInventaire.Visible =
                        true;
                }
                else
                {
                    btnValiderInventaire.Visible =
                        false;
                }
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
                        command.Parameters.AddWithValue(
                            "@id",
                            inventaireId);


                        object result =
                            command.ExecuteScalar();


                        if (result == null)
                            return "";


                        return result.ToString();
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
            // =====================================================
            // MÉDICAMENT
            // =====================================================

            DataGridViewTextBoxColumn colMedicament =
                new DataGridViewTextBoxColumn();

            colMedicament.Name =
                "medicament";

            colMedicament.HeaderText =
                "Médicament";

            colMedicament.DataPropertyName =
                "medicament";

            colMedicament.ReadOnly =
                true;

            dgvInventaires.Columns.Add(
                colMedicament);


            // =====================================================
            // DOSAGE / FORME
            // =====================================================

            DataGridViewTextBoxColumn colDesignation =
                new DataGridViewTextBoxColumn();

            colDesignation.Name =
                "designation";

            colDesignation.HeaderText =
                "Dosage / Forme";

            colDesignation.DataPropertyName =
                "designation";

            colDesignation.ReadOnly =
                true;

            dgvInventaires.Columns.Add(
                colDesignation);


            // =====================================================
            // LOT
            // =====================================================

            DataGridViewTextBoxColumn colLot =
                new DataGridViewTextBoxColumn();

            colLot.Name =
                "numero_lot";

            colLot.HeaderText =
                "Lot";

            colLot.DataPropertyName =
                "numero_lot";

            colLot.ReadOnly =
                true;

            dgvInventaires.Columns.Add(
                colLot);


            // =====================================================
            // EXPIRATION
            // =====================================================

            DataGridViewTextBoxColumn colExpiration =
                new DataGridViewTextBoxColumn();

            colExpiration.Name =
                "date_expiration";

            colExpiration.HeaderText =
                "Expiration";

            colExpiration.DataPropertyName =
                "date_expiration";

            colExpiration.ReadOnly =
                true;

            dgvInventaires.Columns.Add(
                colExpiration);


            // =====================================================
            // STOCK SYSTEME
            // =====================================================

            DataGridViewTextBoxColumn colSysteme =
                new DataGridViewTextBoxColumn();

            colSysteme.Name =
                "quantite_systeme";

            colSysteme.HeaderText =
                "Stock système";

            colSysteme.DataPropertyName =
                "quantite_systeme";

            colSysteme.ReadOnly =
                true;

            dgvInventaires.Columns.Add(
                colSysteme);


            // =====================================================
            // QUANTITE COMPTEE
            // =====================================================

            DataGridViewTextBoxColumn colComptee =
                new DataGridViewTextBoxColumn();

            colComptee.Name =
                "quantite_comptee";

            colComptee.HeaderText =
                "Quantité comptée";

            colComptee.DataPropertyName =
                "quantite_comptee";

            colComptee.ReadOnly =
                true;

            dgvInventaires.Columns.Add(
                colComptee);


            // =====================================================
            // ECART
            // =====================================================

            DataGridViewTextBoxColumn colEcart =
                new DataGridViewTextBoxColumn();

            colEcart.Name =
                "ecart";

            colEcart.HeaderText =
                "Écart";

            colEcart.DataPropertyName =
                "ecart";

            colEcart.ReadOnly =
                true;

            dgvInventaires.Columns.Add(
                colEcart);
        }


        // =========================================================
        // RECHERCHE
        // =========================================================

        private void tb_search_TextChanged(
            object sender,
            EventArgs e)
        {
            if (dgvInventaires.DataSource == null)
                return;


            DataTable table =
                dgvInventaires.DataSource as DataTable;


            if (table == null)
                return;


            // La recherche fonctionne uniquement
            // lorsque le détail est affiché.

            if (!table.Columns.Contains(
                    "medicament"))
            {
                return;
            }


            string recherche =
                tb_search.Text.Trim()
                    .Replace(
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
            inventaireSelectionneId =
                0;

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


                MySqlTransaction transaction =
                    connection.BeginTransaction();


                try
                {
                    // =================================================
                    // 1. VÉRIFIER LE STATUT
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
                        command.Parameters.AddWithValue(
                            "@inventaire_id",
                            inventaireId);


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
                    // 2. EMPÊCHER DOUBLE VALIDATION
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
                        command.Parameters.AddWithValue(
                            "@inventaire_id",
                            inventaireId);


                        using (MySqlDataReader reader =
                               command.ExecuteReader())
                        {
                            lignes.Load(reader);
                        }
                    }


                    // =================================================
                    // 4. TRAITER LES LOTS
                    // =================================================

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


                        // =================================================
                        // 5. STOCK ACTUEL
                        // =================================================

                        int stockActuel;


                        using (MySqlCommand stockCommand =
                               new MySqlCommand(
                                   @"
                                   SELECT quantite
                                   FROM lot_medicament
                                   WHERE id = @lot_id
                                   FOR UPDATE",
                                   connection,
                                   transaction))
                        {
                            stockCommand.Parameters.AddWithValue(
                                "@lot_id",
                                lotId);


                            object stock =
                                stockCommand.ExecuteScalar();


                            if (stock == null)
                            {
                                throw new Exception(
                                    "Le lot #" +
                                    lotId +
                                    " n'existe plus.");
                            }


                            stockActuel =
                                Convert.ToInt32(stock);
                        }


                        // =================================================
                        // 6. VÉRIFICATION CONCURRENCE
                        // =================================================

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


                        // =================================================
                        // 7. MODIFIER LE STOCK
                        // =================================================

                        string queryUpdateStock = @"
                            UPDATE lot_medicament

                            SET quantite =
                                @quantite

                            WHERE id =
                                @lot_id";


                        using (MySqlCommand updateCommand =
                               new MySqlCommand(
                                   queryUpdateStock,
                                   connection,
                                   transaction))
                        {
                            updateCommand.Parameters.AddWithValue(
                                "@quantite",
                                quantiteComptee);


                            updateCommand.Parameters.AddWithValue(
                                "@lot_id",
                                lotId);


                            updateCommand.ExecuteNonQuery();
                        }


                        // =================================================
                        // 8. ENREGISTRER LE MOUVEMENT
                        // =================================================

                        string queryMouvement = @"
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
                            )";


                        using (MySqlCommand mouvementCommand =
                               new MySqlCommand(
                                   queryMouvement,
                                   connection,
                                   transaction))
                        {
                            mouvementCommand.Parameters.AddWithValue(
                                "@lot_id",
                                lotId);


                            mouvementCommand.Parameters.AddWithValue(
                                "@quantite",
                                ecart);


                            mouvementCommand.Parameters.AddWithValue(
                                "@reference",
                                "INVENTAIRE-" +
                                inventaireId);


                            mouvementCommand.Parameters.AddWithValue(
                                "@observation",
                                "Ajustement suite à l'inventaire #" +
                                inventaireId);


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

                        WHERE id =
                            @inventaire_id

                        AND statut =
                            'EN_COURS'";


                    using (MySqlCommand command =
                           new MySqlCommand(
                               queryTerminer,
                               connection,
                               transaction))
                    {
                        command.Parameters.AddWithValue(
                            "@inventaire_id",
                            inventaireId);


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
                    // 11. RETOUR À LA LISTE
                    // =================================================

                    inventaireSelectionneId =
                        0;


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