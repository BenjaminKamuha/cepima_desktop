using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cepima.MesUserCases.Comptabilité
{
    public partial class Livre_Caisse : UserControl
    {
        private readonly CultureInfo cultureFr =
            new CultureInfo("fr-FR");

        public Livre_Caisse()
        {
            InitializeComponent();
        }

        // ============================================================
        // CHARGEMENT DU FORMULAIRE
        // ============================================================

        private void Livre_Caisse_Load(object sender, EventArgs e)
        {
            try
            {
                // Eviter d'ajouter plusieurs fois les éléments
                cbx_type.Items.Clear();

                cbx_type.Items.Add("Toutes les caisses");
                cbx_type.Items.Add("Caisse EEG");
                cbx_type.Items.Add("Caisse Générale");

                cbx_type.SelectedIndex = 0;

                // Eviter de brancher plusieurs fois l'événement
                dgv_caisse.RowPostPaint -= dgv_caisse_RowPostPaint;
                dgv_caisse.RowPostPaint += dgv_caisse_RowPostPaint;

                ChargerResumeCaisseDuJour();
                ChargerLivreCaisse();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement de la caisse :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // RESUME DE LA CAISSE DU JOUR
        // ============================================================

        private void ChargerResumeCaisseDuJour()
        {
            try
            {
                string query = @"
                    SELECT
                        COALESCE(SUM(recette), 0) AS total_entree,
                        COALESCE(SUM(depasse), 0) AS total_sortie
                    FROM livre_caisse
                    WHERE date >= CURDATE()
                      AND date < CURDATE() + INTERVAL 1 DAY;";

                using (MySqlConnection connexion =
                    MesClasses.ManagerClasse.GetConnexion())
                {
                    using (MySqlCommand commande =
                        new MySqlCommand(query, connexion))
                    {
                        using (MySqlDataReader reader =
                            commande.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                decimal totalEntree = 0;
                                decimal totalSortie = 0;

                                if (reader["total_entree"] != DBNull.Value)
                                {
                                    totalEntree =
                                        Convert.ToDecimal(
                                            reader["total_entree"]);
                                }

                                if (reader["total_sortie"] != DBNull.Value)
                                {
                                    totalSortie =
                                        Convert.ToDecimal(
                                            reader["total_sortie"]);
                                }

                                decimal solde =
                                    totalEntree - totalSortie;

                                lb_total_entree.Text =
                                    totalEntree.ToString("N2") + " $";

                                lb_total_sortie.Text =
                                    totalSortie.ToString("N2") + " $";

                                lb_solde.Text =
                                    solde.ToString("N2") + " $";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du résumé de la caisse du jour :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // SEPARATEUR DE MOIS
        // ============================================================

        private void dgv_caisse_RowPostPaint(
            object sender,
            DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv == null)
                return;

            if (e.RowIndex < 0 ||
                e.RowIndex >= dgv.Rows.Count)
                return;

            if (dgv.Rows[e.RowIndex].Tag == null)
                return;

            string nomMois =
                dgv.Rows[e.RowIndex].Tag.ToString();

            Graphics g = e.Graphics;

            int y = e.RowBounds.Top +
                    (e.RowBounds.Height / 2);

            int gauche = e.RowBounds.Left + 5;
            int droite = e.RowBounds.Right - 5;

            using (Font police =
                new Font("Segoe UI", 10, FontStyle.Bold))
            {
                SizeF tailleTexte =
                    g.MeasureString(nomMois, police);

                float centreX =
                    (gauche + droite) / 2f;

                float texteGauche =
                    centreX - (tailleTexte.Width / 2);

                using (Brush pinceau =
                    new SolidBrush(Color.Black))
                {
                    g.DrawString(
                        nomMois,
                        police,
                        pinceau,
                        texteGauche,
                        e.RowBounds.Top +
                        ((e.RowBounds.Height -
                          tailleTexte.Height) / 2));
                }
            }
        }

        // ============================================================
        // CHARGEMENT DU LIVRE DE CAISSE
        // ============================================================

        private void ChargerLivreCaisse()
        {
            try
            {
                string query = @"
                    SELECT
                        date,
                        description,
                        provenance,
                        recette,
                        depasse,
                        solde
                    FROM livre_caisse
                    WHERE 1 = 1";

                bool toutesLesCaisses = false;

                // ====================================================
                // FILTRE CAISSE
                // ====================================================

                if (cbx_type.SelectedIndex == 1)
                {
                    query += @"
                        AND provenance = @provenance";

                }
                else if (cbx_type.SelectedIndex == 2)
                {
                    query += @"
                        AND provenance = @provenance";
                }
                else
                {
                    toutesLesCaisses = true;
                }

                // ====================================================
                // ORDRE
                // ====================================================

                query += @"
                    ORDER BY date ASC";

                using (MySqlConnection connexion =
                    MesClasses.ManagerClasse.GetConnexion())
                {
                    using (MySqlCommand commande =
                        new MySqlCommand(query, connexion))
                    {
                        if (!toutesLesCaisses)
                        {
                            string provenance =
                                cbx_type.SelectedIndex == 1
                                    ? "EEG"
                                    : "GENERALE";

                            commande.Parameters.AddWithValue(
                                "@provenance",
                                provenance);
                        }

                        using (MySqlDataReader reader =
                            commande.ExecuteReader())
                        {
                            // =================================================
                            // DESACTIVER TEMPORAIREMENT LE RAFRAICHISSEMENT
                            // =================================================

                            dgv_caisse.SuspendLayout();

                            try
                            {
                                dgv_caisse.Rows.Clear();

                                int dernierMois = -1;
                                int derniereAnnee = -1;

                                decimal soldeActuel = 0;

                                while (reader.Read())
                                {
                                    // =============================================
                                    // DATE
                                    // =============================================

                                    DateTime dateOperation;

                                    if (reader["date"] == DBNull.Value)
                                    {
                                        continue;
                                    }

                                    dateOperation =
                                        Convert.ToDateTime(
                                            reader["date"]);

                                    int mois =
                                        dateOperation.Month;

                                    int annee =
                                        dateOperation.Year;

                                    // =============================================
                                    // SEPARATEUR DE MOIS
                                    // =============================================

                                    if (mois != dernierMois ||
                                        annee != derniereAnnee)
                                    {
                                        AjouterLigneMois(
                                            dateOperation);

                                        dernierMois = mois;
                                        derniereAnnee = annee;
                                    }

                                    // =============================================
                                    // VALEURS
                                    // =============================================

                                    string description =
                                        reader["description"] ==
                                        DBNull.Value
                                            ? ""
                                            : reader["description"].ToString();

                                    string provenance =
                                        reader["provenance"] ==
                                        DBNull.Value
                                            ? ""
                                            : reader["provenance"].ToString();

                                    decimal recette = 0;

                                    if (reader["recette"] !=
                                        DBNull.Value)
                                    {
                                        recette =
                                            Convert.ToDecimal(
                                                reader["recette"]);
                                    }

                                    decimal depense = 0;

                                    if (reader["depasse"] !=
                                        DBNull.Value)
                                    {
                                        depense =
                                            Convert.ToDecimal(
                                                reader["depasse"]);
                                    }

                                    // =============================================
                                    // SOLDE
                                    // =============================================

                                    decimal soldeOperation;

                                    if (toutesLesCaisses)
                                    {
                                        soldeActuel +=
                                            recette - depense;

                                        soldeOperation =
                                            soldeActuel;
                                    }
                                    else
                                    {
                                        if (reader["solde"] !=
                                            DBNull.Value)
                                        {
                                            soldeOperation =
                                                Convert.ToDecimal(
                                                    reader["solde"]);

                                            soldeActuel =
                                                soldeOperation;
                                        }
                                        else
                                        {
                                            soldeOperation =
                                                soldeActuel;
                                        }
                                    }

                                    // =============================================
                                    // AJOUT DE LA LIGNE
                                    // =============================================

                                    AjouterLigneOperation(
                                        dateOperation,
                                        description,
                                        provenance,
                                        recette,
                                        depense,
                                        soldeOperation);
                                }

                                // =============================================
                                // TOTAL
                                // =============================================

                                AjouterLigneTotal(
                                    soldeActuel);
                            }
                            finally
                            {
                                dgv_caisse.ResumeLayout();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du livre de caisse :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // AJOUTER UNE LIGNE MOIS
        // ============================================================

        private void AjouterLigneMois(
            DateTime dateOperation)
        {
            int ligneMois =
                dgv_caisse.Rows.Add();

            string nomMois =
                dateOperation.ToString(
                    "MMMM yyyy",
                    cultureFr).ToUpper();

            dgv_caisse.Rows[ligneMois]
                .Cells["colDate"].Value = "";

            dgv_caisse.Rows[ligneMois]
                .Cells["colDesc"].Value = "";

            dgv_caisse.Rows[ligneMois]
                .Cells["colProvenance"].Value = "";

            dgv_caisse.Rows[ligneMois]
                .Cells["colEntree"].Value = "";

            dgv_caisse.Rows[ligneMois]
                .Cells["colSortie"].Value = "";

            dgv_caisse.Rows[ligneMois]
                .Cells["colSolde"].Value = "";

            dgv_caisse.Rows[ligneMois].Tag =
                nomMois;

            dgv_caisse.Rows[ligneMois].Height =
                32;

            dgv_caisse.Rows[ligneMois]
                .DefaultCellStyle.BackColor =
                Color.White;

            dgv_caisse.Rows[ligneMois]
                .DefaultCellStyle.ForeColor =
                Color.Black;

            dgv_caisse.Rows[ligneMois]
                .DefaultCellStyle.SelectionBackColor =
                Color.White;

            dgv_caisse.Rows[ligneMois]
                .DefaultCellStyle.SelectionForeColor =
                Color.Black;

            dgv_caisse.Rows[ligneMois].ReadOnly =
                true;
        }

        // ============================================================
        // AJOUTER UNE OPERATION
        // ============================================================

        private void AjouterLigneOperation(
            DateTime dateOperation,
            string description,
            string provenance,
            decimal recette,
            decimal depense,
            decimal solde)
        {
            int ligne =
                dgv_caisse.Rows.Add();

            dgv_caisse.Rows[ligne]
                .Cells["colDate"].Value =
                dateOperation.ToString("dd/MM/yyyy");

            dgv_caisse.Rows[ligne]
                .Cells["colDesc"].Value =
                description;

            dgv_caisse.Rows[ligne]
                .Cells["colProvenance"].Value =
                provenance;

            dgv_caisse.Rows[ligne]
                .Cells["colEntree"].Value =
                recette.ToString("N2") + " $";

            dgv_caisse.Rows[ligne]
                .Cells["colSortie"].Value =
                depense.ToString("N2") + " $";

            dgv_caisse.Rows[ligne]
                .Cells["colSolde"].Value =
                solde.ToString("N2") + " $";
        }

        // ============================================================
        // AJOUTER TOTAL
        // ============================================================

        private void AjouterLigneTotal(
            decimal soldeActuel)
        {
            int ligneTotal =
                dgv_caisse.Rows.Add();

            dgv_caisse.Rows[ligneTotal]
                .Cells["colDate"].Value =
                "TOTAL DU SOLDE";

            dgv_caisse.Rows[ligneTotal]
                .Cells["colDesc"].Value = "";

            dgv_caisse.Rows[ligneTotal]
                .Cells["colProvenance"].Value = "";

            dgv_caisse.Rows[ligneTotal]
                .Cells["colEntree"].Value = "";

            dgv_caisse.Rows[ligneTotal]
                .Cells["colSortie"].Value = "";

            dgv_caisse.Rows[ligneTotal]
                .Cells["colSolde"].Value =
                soldeActuel.ToString("N2") + " $";

            DataGridViewRow ligne =
                dgv_caisse.Rows[ligneTotal];

            ligne.DefaultCellStyle.Font =
                new Font(
                    dgv_caisse.Font,
                    FontStyle.Bold);

            ligne.DefaultCellStyle.BackColor =
                Color.LightGray;

            ligne.DefaultCellStyle.ForeColor =
                Color.Black;

            ligne.Height = 35;

            ligne.ReadOnly = true;

            ligne.Cells["colDate"]
                .Style.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            ligne.Cells["colSolde"]
                .Style.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }

        // ============================================================
        // CHANGEMENT DE CAISSE
        // ============================================================

        private void cbx_type_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            ChargerLivreCaisse();
        }

        // ============================================================
        // AFFICHER LES FACTURES
        // ============================================================

        private void linkLabel1_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            MesForms.Compt.DisplayFactureCaisse dis =
                new MesForms.Compt.DisplayFactureCaisse();

            dis.ShowDialog();
        }
    }
}