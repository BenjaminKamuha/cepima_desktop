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
using System.IO;
using Cepima.Data;
using Cepima.MesUserCases;

namespace Cepima.MesForms
{
    public partial class Form_add_medoc : Form
    {
        Database db = new Database();

        public static MyRoundedComboBox CBX_CATEGORIE { get; set; }
        public static MyRoundedComboBox CBX_UNITE { get; set; }

        int PROD_ID = UC_stock_pharmacie.PROD_ID;
        string query;

        public Form_add_medoc()
        {
            InitializeComponent();

            CBX_CATEGORIE = cbx_category;
            CBX_UNITE = cbx_unity;

            ChargerCategories();
            ChargerUnites();


            if (PROD_ID != 0)
            {
                ChargerInfoProduit();
                query = @"
                UPDATE medicament
                SET nom = @nom,
                    categorie_id = @categorie_id,
                    unite_gestion_id = @categorie_id,
                    seuil_minimum = @seuil_minimum, 
                    prix_vente = @prix_vente,
                    prix_achat = @prix_vente

                    WHERE id = @id_med;";
            }
            else
            {
                query = @"
                INSERT INTO medicament
                (
                    nom,
                    categorie_id,
                    unite_gestion_id,
                    seuil_minimum,
                    prix_vente,
                    prix_achat
                )
                VALUES
                (
                    @nom,
                    @categorie_id,
                    @unite_gestion_id,
                    @seuil_minimum,
                    @prix_vente,
                    @prix_vente
                )";
            }
        }

        private void ChargerInfoProduit()
        {
            try
            {
                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();
                    string query = @"
                        SELECT
                            m.id,
                            m.nom,
                            m.unite_gestion_id,
                            m.prix_achat,
                            m.prix_vente,
                            m.categorie_id
                            
                        FROM medicament m 
                        WHERE m.id=@med_id";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@med_id", PROD_ID);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tb_medoc_name.Text = reader["nom"].ToString();
                                cbx_category.SelectedValue = Convert.ToInt32(reader["categorie_id"].ToString());
                                cbx_unity.SelectedValue = Convert.ToInt32(reader["unite_gestion_id"].ToString());
                                try
                                {
                                    ud_prix_achat.Value = Convert.ToDecimal(reader["prix_achat"].ToString());
                                    ud_prix_vente.Value = Convert.ToDecimal(reader["prix_vente"].ToString());
                                }
                                catch
                                {
                                    // Si le produit n'a pas de prix
                                }
                                
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement produit " + ex.Message);
            }
        }

        public static void ChargerCategories()
        {
            try
            {
                Database database = new Database();
                using (MySqlConnection connection = database.GetConnection())
                {
                    connection.Open();

                    string query = @"SELECT id, nom, couleur FROM medicament_categorie ORDER BY nom ASC";

                    using (MySqlCommand command =
                           new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter =
                               new MySqlDataAdapter(command))
                        {
                            DataTable table =
                                new DataTable();

                            adapter.Fill(table);

                            CBX_CATEGORIE.DataSource = table;

                            CBX_CATEGORIE.DisplayMember = "nom";
                            CBX_CATEGORIE.ValueMember = "id";

                            CBX_CATEGORIE.SelectedIndex = -1;
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

        public static void ChargerUnites()
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
                    abreviation
                FROM unite_gestion
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

                            // Charger les données
                            CBX_UNITE.DataSource =
                                table;

                            // Texte affiché
                            CBX_UNITE.DisplayMember =
                                "nom";

                            // Valeur récupérée
                            CBX_UNITE.ValueMember =
                                "id";

                            // Aucun élément sélectionné au départ
                            CBX_UNITE.SelectedIndex =
                                -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des unités :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void EnregistrerMedicament()
        {
            string nom = tb_medoc_name.Text.Trim();

            // Vérification du nom
            if (string.IsNullOrEmpty(nom))
            {
                MessageBox.Show(
                    "Veuillez saisir le nom du médicament.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_medoc_name.Focus();
                return;
            }

            // Vérification de la catégorie
            if (cbx_category.SelectedIndex < 0 ||
                cbx_category.SelectedValue == null)
            {
                MessageBox.Show(
                    "Veuillez sélectionner une catégorie.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cbx_category.Focus();
                return;
            }

            // Vérification de l'unité
            if (cbx_unity.SelectedIndex < 0 ||
                cbx_unity.SelectedValue == null)
            {
                MessageBox.Show(
                    "Veuillez sélectionner une unité de gestion.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cbx_unity.Focus();
                return;
            }

            try
            {
                Database database = new Database();

                using (MySqlConnection connection =
                       database.GetConnection())
                {
                    connection.Open();

                    // =================================================
                    // RÉCUPÉRER LES IDS
                    // =================================================

                    int categorieId =
                        Convert.ToInt32(
                            cbx_category.SelectedValue);

                    int uniteId =
                        Convert.ToInt32(
                            cbx_category.SelectedValue);

                    int seuil = 
                        Convert.ToInt32(
                            ud_seuil.Value);

                    decimal prix_achat =
                        Convert.ToDecimal(
                            ud_prix_achat.Value);

                    decimal prix_vente =
                        Convert.ToDecimal(
                            ud_prix_vente.Value);


                    // =================================================
                    // VÉRIFIER SI LE MÉDICAMENT EXISTE
                    // =================================================

                    if (PROD_ID == 0)
                    {
                        string checkQuery = @"
    SELECT id, actif
    FROM medicament
    WHERE nom = @nom
      AND categorie_id = @categorie_id
    LIMIT 1";

                        using (MySqlCommand checkCommand =
                               new MySqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@nom", nom);
                            checkCommand.Parameters.AddWithValue("@categorie_id", categorieId);

                            using (MySqlDataReader reader = checkCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int medicamentId = Convert.ToInt32(reader["id"]);
                                    int actif = Convert.ToInt32(reader["actif"]);

                                    reader.Close();

                                    if (actif == 1)
                                    {
                                        MessageBox.Show(
                                            "Ce médicament existe déjà dans cette catégorie.",
                                            "Doublon",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);

                                        tb_medoc_name.Focus();

                                        return;
                                    }
                                    else
                                    {
                                        // Le médicament existe mais est désactivé
                                        string activateQuery = @"
                    UPDATE medicament
                    SET actif = 1
                    WHERE id = @id";

                                        using (MySqlCommand activateCommand =
                                               new MySqlCommand(activateQuery, connection))
                                        {
                                            activateCommand.Parameters.AddWithValue(
                                                "@id",
                                                medicamentId);

                                            activateCommand.ExecuteNonQuery();
                                        }

                                        MessageBox.Show(
                                            "Ce médicament existait déjà et a été réactivé.",
                                            "Médicament réactivé",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);

                                        return;
                                    }
                                }
                            }
                        }
                    }
                    


                    // =================================================
                    // INSERTION
                    // =================================================

                    using (MySqlCommand command =
                           new MySqlCommand(
                               query,
                               connection))
                    {
                        command.Parameters.AddWithValue(
                            "@nom",
                            nom);

                        command.Parameters.AddWithValue(
                            "@categorie_id",
                            categorieId);

                        command.Parameters.AddWithValue(
                            "@unite_gestion_id",
                            uniteId);

                        command.Parameters.AddWithValue(
                            "@seuil_minimum", seuil);

                        command.Parameters.AddWithValue(
                            "@prix_achat", prix_achat);
                        command.Parameters.AddWithValue(
                            "@prix_vente", prix_vente);

                        if (PROD_ID != 0) 
                        {
                            command.Parameters.AddWithValue("@id_med", PROD_ID);
                        }
                        command.ExecuteNonQuery();
                    }
                }


                // =====================================================
                // SUCCÈS
                // =====================================================

                if (PROD_ID != 0)
                {
                    MessageBox.Show("Produit modifié avec succès", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {

                    DialogResult result = MessageBox.Show(
                        "Le médicament a été enregistré avec succès. Enregistrer un autre ?",
                        "Enregistrement",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Réinitialiser le formulaire
                        ViderFormulaireMedicament();

                        // Garder le formulaire ouvert
                        tb_medoc_name.Focus();
                    }

                    else
                    {
                        // Fermer le formulaire
                        this.Close();
                    }
                }


                // =====================================================
                // VIDER LE FORMULAIRE
                // =====================================================

                ViderFormulaireMedicament();

                tb_medoc_name.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'enregistrement du médicament :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ViderFormulaireMedicament()
        {
            tb_medoc_name.Text = "";

            cbx_category.SelectedIndex = -1;

            cbx_unity.SelectedIndex = -1;

            ud_prix_achat.Value = 0;

            ud_prix_vente.Value = 0;
        }

        private void btn_add_category_Click(object sender, EventArgs e)
        {
            Form_add_category_med frm_cat = new Form_add_category_med();
            frm_cat.ShowDialog();


        }

        private void btn_add_unity_Click(object sender, EventArgs e)
        {
            Form_add_unity frm_unity = new Form_add_unity();
            frm_unity.ShowDialog();
        }

        private void bt_save_medoc_Click(object sender, EventArgs e)
        {
            EnregistrerMedicament();
            UC_stock_pharmacie.ChargerMedicaments();          
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
