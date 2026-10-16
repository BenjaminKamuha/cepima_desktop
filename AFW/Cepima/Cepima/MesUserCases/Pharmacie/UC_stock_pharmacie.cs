using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cepima.Data;
using MySql.Data.MySqlClient;
using Cepima.MesForms;

namespace Cepima.MesUserCases
{
    public partial class UC_stock_pharmacie : UserControl
    {
        public static FlowLayoutPanel FL_MEDOC { get; set; }
        public static Int32 PROD_ID;

        public UC_stock_pharmacie()
        {
            InitializeComponent();

            FL_MEDOC = fl_medoc;

            ChargerMedicaments();
            ChargerCategories();
            ChargerCatCard();
        }


        // =========================================================
        // CENTRER LES ELEMENTS DU FLOWLAYOUT
        // =========================================================

        public static void CenterFlowLayoutItems(
            FlowLayoutPanel flowLayoutPanel1)
        {
            if (flowLayoutPanel1 == null)
                return;

            int availableWidth =
                flowLayoutPanel1.ClientSize.Width;

            if (flowLayoutPanel1.VerticalScroll.Visible)
            {
                availableWidth -=
                    SystemInformation.VerticalScrollBarWidth;
            }

            foreach (Control item
                in flowLayoutPanel1.Controls)
            {
                int marginLeft =
                    Math.Max(
                        5,
                        (availableWidth - item.Width) / 2);

                int marginRight =
                    marginLeft;

                item.Margin =
                    new Padding(
                        marginLeft,
                        item.Margin.Top,
                        marginRight,
                        item.Margin.Bottom);
            }
        }


        // =========================================================
        // CHARGER LES CATEGORIES
        // =========================================================

        private void ChargerCategories()
        {
            try
            {
                Database database =
                    new Database();

                using (MySqlConnection connection =
                    database.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            id,
                            nom,
                            couleur
                        FROM medicament_categorie
                        WHERE actif = 1
                        ORDER BY nom ASC";

                    using (MySqlCommand command =
                        new MySqlCommand(
                            query,
                            connection))
                    {
                        using (MySqlDataAdapter adapter =
                            new MySqlDataAdapter(command))
                        {
                            DataTable table =
                                new DataTable();

                            adapter.Fill(table);


                            // =========================================
                            // TOUTES LES CATEGORIES
                            // =========================================

                            DataRow ligneToutes =
                                table.NewRow();

                            ligneToutes["id"] =
                                0;

                            ligneToutes["nom"] =
                                "Toutes les catégories";

                            ligneToutes["couleur"] =
                                DBNull.Value;

                            table.Rows.InsertAt(
                                ligneToutes,
                                0);


                            // =========================================
                            // COMBOBOX
                            // =========================================

                            cbx_filter_category.DataSource =
                                table;

                            cbx_filter_category.DisplayMember =
                                "nom";

                            cbx_filter_category.ValueMember =
                                "id";

                            cbx_filter_category.SelectedIndex =
                                0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des catégories :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // CHARGER TOUS LES MEDICAMENTS
        // =========================================================

        public static void ChargerMedicaments()
        {
            try
            {
                if (FL_MEDOC == null)
                    return;

                Database database =
                    new Database();

                using (MySqlConnection connection =
                    database.GetConnection())
                {
                    // Gardé volontairement
                    connection.Open();

                    string query = @"
                        SELECT
                            m.id,
                            m.nom,
                            m.unite_gestion,
                            c.nom AS categorie,
                            c.couleur
                        FROM medicament m
                        INNER JOIN medicament_categorie c
                            ON m.categorie_id = c.id
                        WHERE m.actif = 1
                        ORDER BY m.nom ASC";

                    using (MySqlCommand command =
                        new MySqlCommand(
                            query,
                            connection))
                    {
                        using (MySqlDataReader reader =
                            command.ExecuteReader())
                        {
                            FL_MEDOC.SuspendLayout();

                            try
                            {
                                FL_MEDOC.Controls.Clear();

                                while (reader.Read())
                                {
                                    AjouterMedicamentDansListe(
                                        reader);
                                }
                            }
                            finally
                            {
                                FL_MEDOC.ResumeLayout(
                                    true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des médicaments :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // CHARGER LES CARTES DES CATEGORIES
        // =========================================================

        private void ChargerCatCard()
        {
            fl_med_category.SuspendLayout();

            try
            {
                fl_med_category.Controls.Clear();

                Database database =
                    new Database();

                using (MySqlConnection connection =
                    database.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            c.id,
                            c.nom,
                            c.couleur,
                            COUNT(m.id) AS nombre_medicaments
                        FROM medicament_categorie c
                        LEFT JOIN medicament m
                            ON m.categorie_id = c.id
                        GROUP BY
                            c.id,
                            c.nom,
                            c.couleur
                        ORDER BY
                            c.nom ASC";

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
                                Color color =
                                    ConvertirCouleur(
                                        reader["couleur"]
                                            .ToString());


                                // =====================================
                                // TITRE
                                // =====================================

                                Label lb_title =
                                    new Label();

                                lb_title.Text =
                                    reader["nom"]
                                        .ToString();

                                lb_title.Font =
                                    new Font(
                                        "verdana",
                                        10,
                                        FontStyle.Regular);

                                lb_title.TextAlign =
                                    ContentAlignment.MiddleCenter;


                                // =====================================
                                // NOMBRE
                                // =====================================

                                Label lb_value =
                                    new Label();

                                lb_value.Text =
                                    reader[
                                        "nombre_medicaments"]
                                        .ToString();

                                lb_value.TextAlign =
                                    ContentAlignment.MiddleCenter;

                                lb_value.Font =
                                    new Font(
                                        "verdana",
                                        14,
                                        FontStyle.Bold);


                                // =====================================
                                // PANEL
                                // =====================================

                                CustomRoundedPanel c_pnl =
                                    new CustomRoundedPanel();

                                c_pnl.Size =
                                    new Size(
                                        180,
                                        80);

                                c_pnl.BorderRadius =
                                    15;

                                c_pnl.BorderSize =
                                    0;

                                c_pnl.BackColor =
                                    color;

                                c_pnl.ForeColor =
                                    Color.White;

                                c_pnl.Margin =
                                    new Padding(15);


                                // =====================================
                                // AJOUT DES ELEMENTS
                                // =====================================

                                c_pnl.Controls.Add(
                                    lb_title);

                                c_pnl.Controls.Add(
                                    lb_value);


                                // =====================================
                                // CENTRAGE
                                // =====================================

                                UI.Position.CenterControl(
                                    lb_title,
                                    c_pnl,
                                    5);

                                UI.Position.CenterControl(
                                    lb_value,
                                    c_pnl,
                                    35);


                                fl_med_category.Controls.Add(
                                    c_pnl);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des catégories :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                fl_med_category.ResumeLayout(
                    true);
            }
        }


        // =========================================================
        // CLICK SUR UN MEDICAMENT
        // =========================================================

        static void item_Click(
            object sender,
            EventArgs e)
        {
            ModernListItem item =
                sender as ModernListItem;

            if (item == null)
                return;

            if (item.Tag == null)
                return;

            PROD_ID =
                Convert.ToInt32(
                    item.Tag);

            Form_detail_produit frm_detail =
                new Form_detail_produit();

            frm_detail.ShowDialog();
        }


        // =========================================================
        // CONVERTIR COULEUR HEXADECIMALE
        // =========================================================

        public static Color ConvertirCouleur(
            string hex)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(hex))
                {
                    return Color.Gray;
                }

                hex =
                    hex.Trim();

                if (hex.StartsWith("#"))
                {
                    hex =
                        hex.Substring(1);
                }

                if (hex.Length != 6)
                {
                    return Color.Gray;
                }

                int r =
                    int.Parse(
                        hex.Substring(0, 2),
                        System.Globalization
                            .NumberStyles.HexNumber);

                int g =
                    int.Parse(
                        hex.Substring(2, 2),
                        System.Globalization
                            .NumberStyles.HexNumber);

                int b =
                    int.Parse(
                        hex.Substring(4, 2),
                        System.Globalization
                            .NumberStyles.HexNumber);

                return Color.FromArgb(
                    r,
                    g,
                    b);
            }
            catch
            {
                return Color.Gray;
            }
        }


        // =========================================================
        // RECHERCHER UN MEDICAMENT
        // =========================================================

        private void RechercherMedicaments(
            string recherche)
        {
            try
            {
                Database database =
                    new Database();

                using (MySqlConnection connection =
                    database.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            m.id,
                            m.nom,
                            m.unite_gestion,
                            c.nom AS categorie,
                            c.couleur
                        FROM medicament m
                        INNER JOIN medicament_categorie c
                            ON m.categorie_id = c.id
                        WHERE m.nom LIKE @recherche
                        ORDER BY m.nom ASC";

                    using (MySqlCommand command =
                        new MySqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.Add(
                            "@recherche",
                            MySqlDbType.VarChar)
                            .Value =
                                "%" +
                                (recherche ?? "")
                                    .Trim() +
                                "%";


                        using (MySqlDataReader reader =
                            command.ExecuteReader())
                        {
                            fl_medoc.SuspendLayout();

                            try
                            {
                                fl_medoc.Controls.Clear();

                                while (reader.Read())
                                {
                                    AjouterMedicamentDansListe(
                                        reader);
                                }
                            }
                            finally
                            {
                                fl_medoc.ResumeLayout(
                                    true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la recherche :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // FILTRER PAR CATEGORIE
        // =========================================================

        private void FiltrerMedicamentsParCategorie(
            int categorieId)
        {
            try
            {
                Database database =
                    new Database();

                using (MySqlConnection connection =
                    database.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            m.id,
                            m.nom,
                            m.unite_gestion,
                            c.nom AS categorie,
                            c.couleur
                        FROM medicament m
                        INNER JOIN medicament_categorie c
                            ON m.categorie_id = c.id
                        WHERE m.categorie_id = @categorie_id
                        ORDER BY m.nom ASC";

                    using (MySqlCommand command =
                        new MySqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.Add(
                            "@categorie_id",
                            MySqlDbType.Int32)
                            .Value =
                                categorieId;


                        using (MySqlDataReader reader =
                            command.ExecuteReader())
                        {
                            fl_medoc.SuspendLayout();

                            try
                            {
                                fl_medoc.Controls.Clear();

                                while (reader.Read())
                                {
                                    AjouterMedicamentDansListe(
                                        reader);
                                }
                            }
                            finally
                            {
                                fl_medoc.ResumeLayout(
                                    true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du filtrage :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // AJOUTER UN MEDICAMENT DANS LA LISTE
        // =========================================================
        //
        // IMPORTANT :
        // Cette méthode est STATIC car elle est appelée depuis
        // ChargerMedicaments(), qui est également STATIC.
        //
        // On utilise FL_MEDOC, déjà défini comme propriété STATIC.
        // =========================================================

        private static void AjouterMedicamentDansListe(
            MySqlDataReader reader)
        {
            if (reader == null)
                return;

            if (FL_MEDOC == null)
                return;


            ModernListItem item =
                new ModernListItem();


            item.Title =
                reader["nom"]
                    .ToString();


            item.Subtitle =
                reader["categorie"]
                    .ToString()
                + " • "
                + reader["unite_gestion"]
                    .ToString();


            item.IndicatorColor =
                ConvertirCouleur(
                    reader["couleur"]
                        .ToString());


            item.Tag =
                Convert.ToInt32(
                    reader["id"]);


            // Conservation du comportement
            // et du style existant.

            item.TitleFont =
                UI.Theme.FontMedium;


            item.SubtitleFont =
                UI.Theme.FontNormal;


            item.IndicatorSize =
                40;


            item.Width =
                145;


            item.Height =
                80;


            item.Margin =
                new Padding(10);


            item.Click +=
                item_Click;


            FL_MEDOC.Controls.Add(
                item);
        }


        // =========================================================
        // RECHERCHE
        // =========================================================

        private void tb_search_TextChanged(
            object sender,
            EventArgs e)
        {
            RechercherMedicaments(
                tb_search.Text);
        }


        // =========================================================
        // FILTRE CATEGORIE
        // =========================================================

        private void cbx_filter_category_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (cbx_filter_category.SelectedIndex < 0)
            {
                ChargerMedicaments();
                return;
            }

            if (cbx_filter_category.SelectedValue == null)
            {
                return;
            }

            try
            {
                int categorieId =
                    Convert.ToInt32(
                        cbx_filter_category.SelectedValue);


                // =============================================
                // TOUTES LES CATEGORIES
                // =============================================

                if (categorieId == 0)
                {
                    ChargerMedicaments();
                    return;
                }


                // =============================================
                // CATEGORIE SELECTIONNEE
                // =============================================

                FiltrerMedicamentsParCategorie(
                    categorieId);
            }
            catch
            {
                // Evite l'erreur pendant
                // le chargement initial.
            }
        }


        // =========================================================
        // AJOUT MEDICAMENT
        // =========================================================

        private void btn_add_med_Click(
            object sender,
            EventArgs e)
        {
            UC_stock_pharmacie.PROD_ID =
                0;

            Form_add_medoc frm_medoc =
                new Form_add_medoc();

            frm_medoc.ShowDialog();
        }


        // =========================================================
        // EVENEMENT EXISTANT
        // =========================================================

        private void customRoundedPanel1_Paint(
            object sender,
            PaintEventArgs e)
        {
        }
    }
}