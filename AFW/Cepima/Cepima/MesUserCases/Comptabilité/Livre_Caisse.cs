using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cepima.MesUserCases.Comptabilité
{
    public partial class Livre_Caisse : UserControl
    {
        public Livre_Caisse()
        {
            InitializeComponent();
        }

        private void ChargerResumeCaisseDuJour()
        {
            try
            {
                string query = @"
            SELECT
                COALESCE(SUM(recette), 0) AS total_entree,
                COALESCE(SUM(depasse), 0) AS total_sortie
            FROM livre_caisse
            WHERE DATE(date) = CURDATE();";

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                {

                    using (MySqlCommand commande =
                        new MySqlCommand(query, connexion))
                    {
                        using (MySqlDataReader reader =
                            commande.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                decimal totalEntree =
                                    Convert.ToDecimal(reader["total_entree"]);

                                decimal totalSortie =
                                    Convert.ToDecimal(reader["total_sortie"]);

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
        private void Livre_Caisse_Load(object sender, EventArgs e)
        {
            cbx_type.Items.Clear();
            cbx_type.Items.Add("Toutes les caisses");
            cbx_type.Items.Add("Caisse EEG");
            cbx_type.Items.Add("Caisse Générale");

            cbx_type.SelectedIndex = 0;

            ChargerResumeCaisseDuJour();
            ChargerLivreCaisse();
            dgv_caisse.RowPostPaint += dgv_caisse_RowPostPaint;
        }

        void dgv_caisse_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv == null)
                return;

            // Vérifier si c'est une ligne de séparation de mois
            if (dgv.Rows[e.RowIndex].Tag == null)
                return;

            string nomMois =
                dgv.Rows[e.RowIndex].Tag.ToString();

            Graphics g = e.Graphics;

            // -----------------------------------------------------
            // Position verticale du centre de la ligne
            // -----------------------------------------------------

            int y = e.RowBounds.Top +
                    (e.RowBounds.Height / 2);

            // -----------------------------------------------------
            // Dimensions de la ligne
            // -----------------------------------------------------

            int gauche = e.RowBounds.Left + 5;
            int droite = e.RowBounds.Right - 5;

            // -----------------------------------------------------
            // Police du mois
            // -----------------------------------------------------

            using (Font police = new Font("Segoe UI",10,FontStyle.Bold))
            {
                SizeF tailleTexte =
                    g.MeasureString(nomMois, police);

                float centreX =
                    (gauche + droite) / 2f;

                float texteGauche =
                    centreX - (tailleTexte.Width / 2);

                float texteDroite =
                    centreX + (tailleTexte.Width / 2);

              
                // -------------------------------------------------
                // Texte du mois
                // -------------------------------------------------

                using (Brush pinceau =
                    new SolidBrush(Color.Black))
                {
                    g.DrawString(
                        nomMois,
                        police,
                        pinceau,
                        texteGauche,
                        e.RowBounds.Top +
                        ((e.RowBounds.Height - tailleTexte.Height) / 2));
                }
            }
        }

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

                // =========================================================
                // FILTRE PAR CAISSE
                // =========================================================

                bool toutesLesCaisses = false;

                if (cbx_type.SelectedIndex == 1)
                {
                    query += " AND provenance = 'EEG'";
                }
                else if (cbx_type.SelectedIndex == 2)
                {
                    query += " AND provenance = 'GENERALE'";
                }
                else
                {
                    toutesLesCaisses = true;
                }

                // =========================================================
                // ORDRE CHRONOLOGIQUE
                // =========================================================

                query += " ORDER BY date ASC";

                using (MySqlConnection connexion =
                    MesClasses.ManagerClasse.GetConnexion())
                {
                    using (MySqlCommand commande =
                        new MySqlCommand(query, connexion))
                    {
                        using (MySqlDataReader reader =
                            commande.ExecuteReader())
                        {
                            // =====================================================
                            // VIDER LE TABLEAU
                            // =====================================================

                            dgv_caisse.Rows.Clear();

                            int dernierMois = -1;
                            int derniereAnnee = -1;

                            // =====================================================
                            // SOLDE ACTUEL
                            // =====================================================

                            decimal soldeActuel = 0;

                            while (reader.Read())
                            {
                                // =====================================================
                                // DATE
                                // =====================================================

                                DateTime dateOperation =
                                    Convert.ToDateTime(reader["date"]);

                                int mois = dateOperation.Month;
                                int annee = dateOperation.Year;

                                // =====================================================
                                // NOUVEAU MOIS
                                // =====================================================

                                if (mois != dernierMois ||
                                    annee != derniereAnnee)
                                {
                                    int ligneMois =
                                        dgv_caisse.Rows.Add();

                                    string nomMois =
                                        dateOperation.ToString(
                                            "MMMM yyyy",
                                            new System.Globalization.CultureInfo("fr-FR")
                                        ).ToUpper();

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

                                    // Nom du mois
                                    dgv_caisse.Rows[ligneMois].Tag =
                                        nomMois;

                                    // Style
                                    dgv_caisse.Rows[ligneMois].Height = 32;

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

                                    dgv_caisse.Rows[ligneMois].ReadOnly = true;

                                    dernierMois = mois;
                                    derniereAnnee = annee;
                                }

                                // =====================================================
                                // AJOUT DE L'OPÉRATION
                                // =====================================================

                                int ligneOperation =
                                    dgv_caisse.Rows.Add();

                                // =====================================================
                                // DATE
                                // =====================================================

                                dgv_caisse.Rows[ligneOperation]
                                    .Cells["colDate"].Value =
                                    dateOperation.ToString(
                                        "dd/MM/yyyy");

                                // =====================================================
                                // DESCRIPTION
                                // =====================================================

                                dgv_caisse.Rows[ligneOperation]
                                    .Cells["colDesc"].Value =
                                    reader["description"] == DBNull.Value
                                    ? ""
                                    : reader["description"].ToString();

                                // =====================================================
                                // PROVENANCE
                                // =====================================================

                                string provenance =
                                    reader["provenance"] == DBNull.Value
                                    ? ""
                                    : reader["provenance"].ToString();

                                dgv_caisse.Rows[ligneOperation]
                                    .Cells["colProvenance"].Value =
                                    provenance;

                                // =====================================================
                                // RECETTE
                                // =====================================================

                                decimal recette = 0;

                                if (reader["recette"] != DBNull.Value)
                                {
                                    recette =
                                        Convert.ToDecimal(
                                            reader["recette"]);
                                }

                                dgv_caisse.Rows[ligneOperation]
                                    .Cells["colEntree"].Value =
                                    recette.ToString("N2") + " $";

                                // =====================================================
                                // DEPENSE
                                // =====================================================

                                decimal depense = 0;

                                if (reader["depasse"] != DBNull.Value)
                                {
                                    depense =
                                        Convert.ToDecimal(
                                            reader["depasse"]);
                                }

                                dgv_caisse.Rows[ligneOperation]
                                    .Cells["colSortie"].Value =
                                    depense.ToString("N2") + " $";

                                // =====================================================
                                // SOLDE
                                // =====================================================

                                decimal soldeOperation = 0;

                                if (toutesLesCaisses)
                                {
                                    // -------------------------------------------------
                                    // TOUTES LES CAISSES
                                    //
                                    // On calcule un solde global :
                                    //
                                    // solde = recettes - dépenses
                                    // -------------------------------------------------

                                    soldeActuel += recette - depense;

                                    soldeOperation = soldeActuel;
                                }
                                else
                                {
                                    // -------------------------------------------------
                                    // UNE SEULE CAISSE
                                    //
                                    // On utilise le solde enregistré dans la table.
                                    // -------------------------------------------------

                                    if (reader["solde"] != DBNull.Value)
                                    {
                                        soldeOperation =
                                            Convert.ToDecimal(
                                                reader["solde"]);
                                    }

                                    soldeActuel = soldeOperation;
                                }

                                dgv_caisse.Rows[ligneOperation]
                                    .Cells["colSolde"].Value =
                                    soldeOperation.ToString("N2") + " $";
                            }

                            // =========================================================
                            // TOTAL DU SOLDE
                            // =========================================================

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

                            // =========================================================
                            // STYLE TOTAL
                            // =========================================================

                            DataGridViewRow ligneTotalStyle =
                                dgv_caisse.Rows[ligneTotal];

                            ligneTotalStyle.DefaultCellStyle.Font =
                                new Font(
                                    dgv_caisse.Font,
                                    FontStyle.Bold);

                            ligneTotalStyle.DefaultCellStyle.BackColor =
                                Color.LightGray;

                            ligneTotalStyle.DefaultCellStyle.ForeColor =
                                Color.Black;

                            ligneTotalStyle.Height = 35;

                            ligneTotalStyle.ReadOnly = true;

                            // =========================================================
                            // ALIGNEMENT TITRE
                            // =========================================================

                            dgv_caisse.Rows[ligneTotal]
                                .Cells["colDate"]
                                .Style.Alignment =
                                DataGridViewContentAlignment.MiddleLeft;

                            // =========================================================
                            // ALIGNEMENT SOLDE
                            // =========================================================

                            dgv_caisse.Rows[ligneTotal]
                                .Cells["colSolde"]
                                .Style.Alignment =
                                DataGridViewContentAlignment.MiddleCenter;
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

        private void cbx_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargerLivreCaisse();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Ouverture du formulaire des toutes les factures
            MesForms.Compt.DisplayFactureCaisse dis = new MesForms.Compt.DisplayFactureCaisse();
            dis.ShowDialog();
        }

    }
}
