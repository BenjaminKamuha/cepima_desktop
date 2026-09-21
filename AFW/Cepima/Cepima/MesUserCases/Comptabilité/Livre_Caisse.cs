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

            dt_debut.Value = DateTime.Today;
            dt_fin.Value = DateTime.Today;

            ChargerResumeCaisseDuJour();
            ChargerLivreCaisse();
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
            WHERE date >= @date_debut
              AND date < DATE_ADD(@date_fin, INTERVAL 1 DAY)";

                // Filtre sur la caisse
                if (cbx_type.SelectedIndex == 1)
                {
                    query += " AND provenance = 'EEG'";
                }
                else if (cbx_type.SelectedIndex == 2)
                {
                    query += " AND provenance = 'GENERALE'";
                }

                query += " ORDER BY date DESC";

                using (MySqlConnection connexion =
                    MesClasses.ManagerClasse.GetConnexion())
                {

                    using (MySqlCommand commande =
                        new MySqlCommand(query, connexion))
                    {
                        commande.Parameters.AddWithValue(
                            "@date_debut",
                            dt_debut.Value.Date);

                        commande.Parameters.AddWithValue(
                            "@date_fin",
                            dt_fin.Value.Date);

                        using (MySqlDataReader reader =
                            commande.ExecuteReader())
                        {
                            // Vider les anciennes lignes
                            dgv_caisse.Rows.Clear();

                            while (reader.Read())
                            {
                                int ligne = dgv_caisse.Rows.Add();

                                // Date
                                dgv_caisse.Rows[ligne]
                                    .Cells["colDate"].Value =
                                    Convert.ToDateTime(reader["date"])
                                    .ToString("dd/MM/yyyy HH:mm");

                                // Description
                                dgv_caisse.Rows[ligne]
                                    .Cells["colDesc"].Value =
                                    reader["description"] == DBNull.Value
                                    ? ""
                                    : reader["description"].ToString();

                                // Provenance
                                dgv_caisse.Rows[ligne]
                                    .Cells["colProvenance"].Value =
                                    reader["provenance"] == DBNull.Value
                                    ? ""
                                    : reader["provenance"].ToString();

                                // Entrée
                                dgv_caisse.Rows[ligne]
                                    .Cells["colEntree"].Value =
                                    reader["recette"] == DBNull.Value
                                    ? "0,00 $"
                                    : Convert.ToDecimal(reader["recette"])
                                        .ToString("N2") + " $";

                                // Sortie
                                dgv_caisse.Rows[ligne]
                                    .Cells["colSortie"].Value =
                                    reader["depasse"] == DBNull.Value
                                    ? "0,00 $"
                                    : Convert.ToDecimal(reader["depasse"])
                                        .ToString("N2") + " $";

                                // Solde
                                dgv_caisse.Rows[ligne]
                                    .Cells["colSolde"].Value =
                                    reader["solde"] == DBNull.Value
                                    ? "0,00 $"
                                    : Convert.ToDecimal(reader["solde"])
                                        .ToString("N2") + " $";
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

        private void cbx_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargerLivreCaisse();
        }

        private void dt_debut_ValueChanged(object sender, EventArgs e)
        {
            ChargerLivreCaisse();
        }

        private void dt_fin_ValueChanged(object sender, EventArgs e)
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
