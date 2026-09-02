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

        public static void CenterFlowLayoutItems(FlowLayoutPanel flowLayoutPanel1)
        {
            int availableWidth =
                flowLayoutPanel1.ClientSize.Width;

            if (flowLayoutPanel1.VerticalScroll.Visible)
            {
                availableWidth -=
                    SystemInformation.VerticalScrollBarWidth;
            }

            foreach (Control item in flowLayoutPanel1.Controls)
            {
                int marginLeft =
                    Math.Max(
                        5,
                        (availableWidth -
                         item.Width) / 2);

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

        private void ChargerCategories()
        {
            try
            {
                Database database = new Database();

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
                           new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter =
                               new MySqlDataAdapter(command))
                        {
                            DataTable table =
                                new DataTable();

                            adapter.Fill(table);


                            // =============================================
                            // AJOUTER "TOUTES LES CATÉGORIES"
                            // =============================================

                            DataRow ligneToutes =
                                table.NewRow();

                            ligneToutes["id"] = 0;
                            ligneToutes["nom"] =
                                "Toutes les catégories";
                            ligneToutes["couleur"] =
                                DBNull.Value;

                            table.Rows.InsertAt(
                                ligneToutes,
                                0);


                            // =============================================
                            // CONFIGURER LE COMBOBOX
                            // =============================================

                            cbx_filter_category.DataSource =
                                table;

                            cbx_filter_category.DisplayMember =
                                "nom";

                            cbx_filter_category.ValueMember =
                                "id";


                            // Sélectionner "Toutes les catégories"
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

        public static void ChargerMedicaments()
        {
            try
            {
                Database database = new Database();

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
                ORDER BY m.nom ASC";

                    using (MySqlCommand command =
                           new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader =
                               command.ExecuteReader())
                        {
                            // Vider la liste
                            FL_MEDOC.Controls.Clear();

                            while (reader.Read())
                            {
                                ModernListItem item =
                                    new ModernListItem();

                                item.Title =
                                    reader["nom"].ToString();

                                item.Subtitle = reader["categorie"].ToString() + " • " + reader["unite_gestion"].ToString();

                                string couleur = reader["couleur"].ToString();

                                Color couleurIndicateur = ConvertirCouleur(couleur);

                                item.IndicatorColor = couleurIndicateur;

                                item.Tag = Convert.ToInt32(reader["id"]);

                                item.TitleFont = UI.Theme.FontMedium;

                                item.SubtitleFont = UI.Theme.FontNormal;

                                item.IndicatorSize = 40;

                                item.Width = 145;
                                item.Height = 80;

                                item.Margin = new Padding(10);

                                item.Click += item_Click;

                                FL_MEDOC.Controls.Add(item);

                                
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

        private void ChargerCatCard()
        {
            // Réunitialisation du panel 
            fl_med_category.Controls.Clear();

            Database database = new Database();

            try
            {
                using (MySqlConnection connection = database.GetConnection())
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
                           new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Color color = UC_stock_pharmacie.ConvertirCouleur(reader["couleur"].ToString());

                                Label lb_title = new Label();
                                lb_title.Text = reader["nom"].ToString();
                                lb_title.Font = new Font("verdana", 10, FontStyle.Regular);
                                lb_title.TextAlign = ContentAlignment.MiddleCenter;

                                Label lb_value = new Label();
                                lb_value.Text = reader["nombre_medicaments"].ToString();
                                lb_value.TextAlign = ContentAlignment.MiddleCenter;
                                lb_value.Font = new Font("verdana", 14, FontStyle.Bold);
                                // Création des cards
                                CustomRoundedPanel c_pnl = new CustomRoundedPanel();
                                c_pnl.Size = new Size(180, 80);
                                c_pnl.BorderRadius = 15;
                                c_pnl.BorderSize = 0;
                                c_pnl.BackColor = color;
                                c_pnl.ForeColor = Color.White;
                                c_pnl.Margin = new Padding(15);
                                
                                // Ajout des panels
                                c_pnl.Controls.Add(lb_title);
                                c_pnl.Controls.Add(lb_value);
                                
                                // Centrage des elements sur le panel
                                UI.Position.CenterControl(lb_title, c_pnl, 5);
                                UI.Position.CenterControl(lb_value, c_pnl, 35);

                                fl_med_category.Controls.Add(c_pnl);

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
        }

        static void item_Click(object sender, EventArgs e)
        {

            ModernListItem item = sender as ModernListItem;

            PROD_ID = Convert.ToInt32(item.Tag);

            Form_detail_produit frm_detail = new Form_detail_produit();
            frm_detail.ShowDialog();
        }

        public static Color ConvertirCouleur(string hex)
        {
            try
            {
                if (string.IsNullOrEmpty(hex))
                {
                    return Color.Gray;
                }

                hex = hex.Trim();

                if (hex.StartsWith("#"))
                {
                    hex = hex.Substring(1);
                }

                if (hex.Length == 6)
                {
                    int r =
                        int.Parse(
                            hex.Substring(0, 2),
                            System.Globalization.NumberStyles.HexNumber);

                    int g =
                        int.Parse(
                            hex.Substring(2, 2),
                            System.Globalization.NumberStyles.HexNumber);

                    int b =
                        int.Parse(
                            hex.Substring(4, 2),
                            System.Globalization.NumberStyles.HexNumber);

                    return Color.FromArgb(r, g, b);
                }

                return Color.Gray;
            }
            catch
            {
                return Color.Gray;
            }
        }

        private void RechercherMedicaments(string recherche)
        {
            try
            {
                Database database = new Database();

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
                           new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@recherche",
                            "%" + recherche.Trim() + "%");

                        using (MySqlDataReader reader =
                               command.ExecuteReader())
                        {
                            fl_medoc.Controls.Clear();

                            while (reader.Read())
                            {
                                AjouterMedicamentDansListe(
                                    reader);
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

        private void FiltrerMedicamentsParCategorie(int categorieId)
        {
            try
            {
                Database database = new Database();

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
                           new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@categorie_id",
                            categorieId);

                        using (MySqlDataReader reader =
                               command.ExecuteReader())
                        {
                            fl_medoc.Controls.Clear();

                            while (reader.Read())
                            {
                                AjouterMedicamentDansListe(
                                    reader);
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

        private void AjouterMedicamentDansListe(MySqlDataReader reader)
        {
            ModernListItem item =
                new ModernListItem();

            item.Title =
                reader["nom"].ToString();

            item.Subtitle = reader["categorie"].ToString() + " • " + reader["unite_gestion"].ToString();

            item.IndicatorColor = ConvertirCouleur(reader["couleur"].ToString());

            item.Tag = Convert.ToInt32(reader["id"]);

            item.Click += item_Click;

            fl_medoc.Controls.Add(
                item);
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            RechercherMedicaments(tb_search.Text);
        }

        private void cbx_filter_category_SelectedIndexChanged(object sender, EventArgs e)
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
                int categorieId = Convert.ToInt32(cbx_filter_category.SelectedValue);

                if (categorieId == 0)
                {
                    ChargerMedicaments();
                    return;
                }

                FiltrerMedicamentsParCategorie(categorieId);
            }
            catch
            {
                // Évite l'erreur pendant le chargement initial
            }
        }

        private void btn_add_med_Click(object sender, EventArgs e)
        {
            UC_stock_pharmacie.PROD_ID = 0;
            Form_add_medoc frm_medoc = new Form_add_medoc();
            frm_medoc.ShowDialog();
        }

        private void customRoundedPanel1_Paint(object sender, PaintEventArgs e)
        {

















































































































































































        }

    }
}
