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
using System.Windows.Forms.DataVisualization.Charting;

namespace Cepima.MesUserCases.Comptabilité
{
    public partial class DashBoard_comptability : UserControl
    {
        public DashBoard_comptability()
        {
            InitializeComponent();
        }

        private void DashBoard_comptability_Load(object sender, EventArgs e)
        {
            ChargerSoldeCaisseEEG();
            ChargerSoldeCaisseGenerale();
            ChargerTotalRecettes();
            ChargerGraphiqueCaisseEEG();
            ChargerGraphiqueCaisseGenerale();
        }

        private void ChargerSoldeCaisseEEG()
        {
            try
            {
                string query = @"
            SELECT solde
            FROM livre_caisse
            WHERE provenance = 'EEG'
              AND DATE(date) = CURDATE()
            ORDER BY date DESC
            LIMIT 1";

                using (MySqlConnection connexion =
                    MesClasses.ManagerClasse.GetConnexion())
                {

                    using (MySqlCommand commande =
                        new MySqlCommand(query, connexion))
                    {
                        object resultat = commande.ExecuteScalar();

                        decimal solde = 0;

                        if (resultat != null &&
                            resultat != DBNull.Value)
                        {
                            solde = Convert.ToDecimal(resultat);
                        }

                        lbl_solde_eeg.Text = solde.ToString("N2") + " $";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement de la caisse EEG du jour :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ChargerSoldeCaisseGenerale()
        {
            try
            {
                string query = @"
            SELECT solde
            FROM livre_caisse
            WHERE provenance = 'GENERALE'
              AND DATE(date) = CURDATE()
            ORDER BY date DESC
            LIMIT 1";

                using (MySqlConnection connexion =
                    MesClasses.ManagerClasse.GetConnexion())
                {

                    using (MySqlCommand commande =
                        new MySqlCommand(query, connexion))
                    {
                        object resultat = commande.ExecuteScalar();

                        decimal solde = 0;

                        if (resultat != null &&
                            resultat != DBNull.Value)
                        {
                            solde = Convert.ToDecimal(resultat);
                        }

                        lbl_solde_generale.Text =
                            solde.ToString("N2") + " $";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement de la caisse générale du jour :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ChargerTotalRecettes()
        {
            try
            {
                string query = @"
            SELECT COALESCE(SUM(recette), 0)
            FROM livre_caisse
            WHERE DATE(date) = CURDATE()";

                using (MySqlConnection connexion =
                    MesClasses.ManagerClasse.GetConnexion())
                {

                    using (MySqlCommand commande =
                        new MySqlCommand(query, connexion))
                    {
                        object resultat = commande.ExecuteScalar();

                        decimal totalRecettes = 0;

                        if (resultat != null &&
                            resultat != DBNull.Value)
                        {
                            totalRecettes = Convert.ToDecimal(resultat);
                        }

                        lbl_total_recettes.Text =
                            totalRecettes.ToString("N2") + " $";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du total des recettes du jour :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ChargerGraphiqueCaisseEEG()
        {
            try
            {
                // Nettoyer le graphique
                chart_caisse_eeg.Series.Clear();
                chart_caisse_eeg.ChartAreas.Clear();

                // Zone du graphique
                ChartArea zone = new ChartArea("ZoneEEG");
                chart_caisse_eeg.ChartAreas.Add(zone);

                // Série
                Series serie = new Series("Caisse EEG");
                serie.ChartType = SeriesChartType.Column;
                serie.IsValueShownAsLabel = true;
                serie.YValueType = ChartValueType.Double;

                // Les 7 jours de la semaine
                string[] jours =
        {
            "Lun",
            "Mar",
            "Mer",
            "Jeu",
            "Ven",
            "Sam",
            "Dim"
        };

                // Initialiser chaque jour à 0
                decimal[] soldes = new decimal[7];

                string query = @"
            SELECT 
                WEEKDAY(date) AS numero_jour,
                solde
            FROM livre_caisse
            WHERE provenance = 'EEG'
              AND DATE(date) >= DATE_SUB(CURDATE(), INTERVAL WEEKDAY(CURDATE()) DAY)
              AND DATE(date) <= CURDATE()
            ORDER BY date ASC";

                using (MySqlConnection connexion =
                    MesClasses.ManagerClasse.GetConnexion())
                {

                    using (MySqlCommand commande =
                        new MySqlCommand(query, connexion))
                    {
                        using (MySqlDataReader reader =
                            commande.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int numeroJour =
                                    Convert.ToInt32(reader["numero_jour"]);

                                decimal solde =
                                    Convert.ToDecimal(reader["solde"]);

                                // Le dernier solde enregistré
                                // pour cette journée remplace le précédent
                                soldes[numeroJour] = solde;
                            }
                        }
                    }
                }

                // Ajouter les 7 jours au graphique
                for (int i = 0; i < 7; i++)
                {
                    DataPoint point = new DataPoint();
                    point.SetValueXY(jours[i], soldes[i]);

                    // Afficher le montant sur la barre
                    point.Label = soldes[i].ToString("N0") + " $";

                    serie.Points.Add(point);
                }

                chart_caisse_eeg.Series.Add(serie);

                // Configuration de l'axe horizontal
                zone.AxisX.Title = "Jour";
                zone.AxisX.Interval = 1;
                zone.AxisX.LabelStyle.Font = new Font("Segoe UI",12);
                // Configuration de l'axe vertical
                zone.AxisY.Title = "Montant ($)";
                zone.AxisY.LabelStyle.Format = "N0";
                // Commencer l'axe à zéro
                zone.AxisY.Minimum = 0;

                // Style général
                zone.AxisX.MajorGrid.Enabled = false;
                zone.AxisY.MajorGrid.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du graphique de la caisse EEG :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ChargerGraphiqueCaisseGenerale()
        {
            try
            {
                // Nettoyer le graphique
                chart_caisse_generale.Series.Clear();
                chart_caisse_generale.ChartAreas.Clear();

                // Zone du graphique
                ChartArea zone = new ChartArea("ZoneGenerale");
                chart_caisse_generale.ChartAreas.Add(zone);

                // Série
                Series serie = new Series("Caisse Générale");
                serie.ChartType = SeriesChartType.Column;
                serie.IsValueShownAsLabel = true;
                serie.YValueType = ChartValueType.Double;

                // Les 7 jours
                string[] jours =
        {
            "Lun",
            "Mar",
            "Mer",
            "Jeu",
            "Ven",
            "Sam",
            "Dim"
        };

                // Tous les jours commencent à 0
                decimal[] soldes = new decimal[7];

                string query = @"
            SELECT 
                WEEKDAY(date) AS numero_jour,
                solde
            FROM livre_caisse
            WHERE provenance = 'GENERALE'
              AND DATE(date) >= DATE_SUB(CURDATE(), INTERVAL WEEKDAY(CURDATE()) DAY)
              AND DATE(date) <= CURDATE()
            ORDER BY date ASC";

                using (MySqlConnection connexion =
                    MesClasses.ManagerClasse.GetConnexion())
                {
                    

                    using (MySqlCommand commande =
                        new MySqlCommand(query, connexion))
                    {
                        using (MySqlDataReader reader =
                            commande.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int numeroJour =
                                    Convert.ToInt32(reader["numero_jour"]);

                                decimal solde =
                                    Convert.ToDecimal(reader["solde"]);

                                // Le dernier solde de la journée
                                // remplace celui trouvé précédemment
                                soldes[numeroJour] = solde;
                            }
                        }
                    }
                }

                // Ajouter les 7 jours
                for (int i = 0; i < 7; i++)
                {
                    DataPoint point = new DataPoint();

                    point.SetValueXY(jours[i], soldes[i]);

                    // Afficher le montant au-dessus de la barre
                    point.Label = soldes[i].ToString("N0") + " $";

                    serie.Points.Add(point);
                }

                chart_caisse_generale.Series.Add(serie);

                // Axe horizontal
                zone.AxisX.Title = "Jour";
                zone.AxisX.Interval = 1;
                zone.AxisX.LabelStyle.Font = new Font("Segoe UI", 12);
                // Axe vertical
                zone.AxisY.Title = "Montant ($)";
                zone.AxisY.LabelStyle.Format = "N0";
                zone.AxisY.Minimum = 0;

                // Grilles
                zone.AxisX.MajorGrid.Enabled = false;
                zone.AxisY.MajorGrid.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du graphique de la caisse générale :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
