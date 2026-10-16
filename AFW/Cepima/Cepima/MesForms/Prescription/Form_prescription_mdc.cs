using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cepima.Data;
using MySql.Data.MySqlClient;
using Cepima.MesClasses;

namespace Cepima.MesForms.Prescription
{
    public partial class Form_prescription_mdc : Form
    {
        public static FlowLayoutPanel FL_MEDOC { get; set; }



        private static FlowLayoutPanel FL_PRESCRIPTION { get; set; }
        private static RoundedButton BT_SAVE_PRESC { get; set; }
        public static Int32 PROD_ID;
        private static int PATIENT_ID;



        private static List<PrescriptionLigneData> lignes = new List<PrescriptionLigneData>();

        public Form_prescription_mdc(int patient_id)
        {
            InitializeComponent();

            PATIENT_ID = patient_id;

            FL_PRESCRIPTION = fl_prescription_ligne;

            BT_SAVE_PRESC = btn_save_prescription;

            FL_MEDOC = fl_medoc;
            ChargerMedicaments();
            ChargerCategories();
            ChargerPrescription();
            ChargerPatients();

            
        }

        private void ChargerPatients()
        {
            try
            {
                Database db = new Database();

                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"
                        SELECT 
                            id_patient,
                            YEAR(date_naissance) AS annee_naissance,
                            numero_fiche,
                            sexe,
                            CONCAT(
                                nom,
                                ' ',
                                post_nom,
                                CASE 
                                    WHEN prenom IS NOT NULL
                                         AND prenom <> ''
                                    THEN CONCAT(' ', prenom)
                                    ELSE ''
                                END
                            ) AS patient
                        FROM patients
                        WHERE id_patient = @id_p";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_p", PATIENT_ID);

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int anneeNaissance =
                                    Convert.ToInt32(
                                        reader["annee_naissance"]
                                        .ToString());

                                int age =
                                    DateTime.Now.Date.Year -
                                    anneeNaissance;

                                lb_nom_patient.Text =
                                    reader["patient"].ToString();

                                lb_sexe_age.Text =
                                    reader["sexe"].ToString() +
                                    "-" +
                                    age.ToString() +
                                    " ans";

                                lb_num_fiche.Text =
                                    reader["numero_fiche"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du patient :\n" +
                    ex.Message,
                    "EEG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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
                    WHERE m.actif = 1 AND m.prix_vente IS NOT NULL
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

        static void ChargerPrescription()
        {
            Database db = new Database();
            // Réunitialisation du panel 
            FL_PRESCRIPTION.Controls.Clear();

            try
            {
                string query = "SELECT m.nom, c.couleur FROM medicament m JOIN medicament_categorie c ON m.categorie_id = c.id WHERE m.id = @id";

                if (lignes.Count() != 0)
                {
                    foreach (PrescriptionLigneData ligne in lignes)
                    {
                        Label lb_title = new Label();
                        lb_title.Font = new Font("verdana", 10, FontStyle.Regular);
                        lb_title.TextAlign = ContentAlignment.MiddleCenter;


                        Color color = Color.SkyBlue;

                        using (MySqlConnection con = db.GetConnection())
                        {
                            con.Open();
                            using (MySqlCommand cmd = new MySqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@id", ligne.MedicamentId);

                                MySqlDataReader reader = cmd.ExecuteReader();

                                reader.Read();

                                if (reader.HasRows)
                                {
                                    lb_title.Text = reader["nom"].ToString();
                                    color = ConvertirCouleur(reader["couleur"].ToString());
                                }
                            }
                        }



                        Label lb_quantite = new Label();
                        lb_quantite.Text = ligne.Quantite.ToString();
                        lb_quantite.TextAlign = ContentAlignment.MiddleLeft;
                        lb_quantite.Font = new Font("verdana", 12, FontStyle.Bold);


                        Label lb_frequence = new Label();
                        lb_quantite.Text = ligne.Frequence;
                        lb_quantite.TextAlign = ContentAlignment.BottomLeft;
                        lb_quantite.Font = new Font("verdana", 10, FontStyle.Bold);
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
                        c_pnl.Controls.Add(lb_quantite);
                        c_pnl.Controls.Add(lb_frequence);

                        // Centrage des elements sur le panel
                        UI.Position.CenterControl(lb_title, c_pnl, 5);
                        UI.Position.CenterControl(lb_quantite, c_pnl, 35);

                        FL_PRESCRIPTION.Controls.Add(c_pnl);

                    }

                    BT_SAVE_PRESC.Enabled = true;
                }

                else
                {
                    Label lb_info = new Label();
                    lb_info.Text = "Selectionner un produit pour ajouter";
                    lb_info.Size = new Size(500, 50);
                    lb_info.TextAlign = ContentAlignment.BottomLeft;
                    lb_info.Font = new Font("verdana", 9, FontStyle.Regular);
                    FL_PRESCRIPTION.Controls.Add(lb_info);
                    BT_SAVE_PRESC.Enabled = false;
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

            Form_add_ligne new_ligne = new Form_add_ligne(PROD_ID, PATIENT_ID, lignes);
            new_ligne.ShowDialog();
            ChargerPrescription();
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

        private void tb_search_TextChanged_1(object sender, EventArgs e)
        {
            RechercherMedicaments(tb_search.Text);
        }

        private void btn_save_prescription_Click(object sender, EventArgs e)
        {
            try
            {
                int idPrescription = PrescriptionManager.EnregistrerPrescription(
                Convert.ToInt32(PATIENT_ID),
                MesClasses.SessionUtilisateur.idUser,
                "",
                lignes);
                MessageBox.Show("Prescription enregistrée", "Prinscription", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lignes.Clear();
                this.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(
                "Erreur lors de l'enregistrement :\n\n" +
                ex.Message,
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            finally
            {
                lignes.Clear();
                ChargerPrescription();
            }
        }
    }
}
