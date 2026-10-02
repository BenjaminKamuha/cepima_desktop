using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cepima.MesUserCases.Comptabilité
{
    public partial class DashBoard_comptability : UserControl, MesClasses.IAsyncLoadable
    {
        public DashBoard_comptability()
        {
            InitializeComponent();
        }

        // =========================================================
        // CHARGEMENT ASYNCHRONE
        // =========================================================
        public async Task ChargerAsync()
        {
            try
            {
                // Les opérations MySQL sont exécutées hors du thread UI.
                DashboardData data = await Task.Run(
                    () => ChargerDonneesDashboard()
                );

                // Après await, on revient sur le thread UI.
                AfficherDonneesDashboard(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du tableau de bord :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // LOAD DU USERCONTROL
        // =========================================================
        private void DashBoard_comptability_Load(
            object sender,
            EventArgs e)
        {
            // Le chargement est maintenant effectué par ChargerAsync().
        }

        // =========================================================
        // CHARGEMENT DES DONNEES
        // =========================================================
        private DashboardData ChargerDonneesDashboard()
        {
            DashboardData data = new DashboardData();

            data.Mois = new string[]
            {
                "Jan",
                "Fév",
                "Mar",
                "Avr",
                "Mai",
                "Juin",
                "Juil",
                "Aoû",
                "Sep",
                "Oct",
                "Nov",
                "Déc"
            };

            data.SoldesEEGMensuels = new decimal[12];
            data.SoldesGeneraleMensuels = new decimal[12];

            using (MySqlConnection connexion =
                MesClasses.ManagerClasse.GetConnexion())
            {
                // =====================================================
                // 1. SOLDE EEG + SOLDE GENERALE
                // =====================================================

                string querySoldes = @"
                    SELECT 
                        provenance,
                        solde
                    FROM livre_caisse
                    WHERE provenance IN ('EEG', 'GENERALE')
                      AND date >= CURDATE()
                      AND date < CURDATE() + INTERVAL 1 DAY
                    ORDER BY date DESC";

                using (MySqlCommand commande =
                    new MySqlCommand(querySoldes, connexion))
                {
                    using (MySqlDataReader reader =
                        commande.ExecuteReader())
                    {
                        bool eegTrouve = false;
                        bool generaleTrouve = false;

                        while (reader.Read())
                        {
                            string provenance =
                                reader["provenance"].ToString();

                            decimal solde =
                                reader["solde"] == DBNull.Value
                                    ? 0
                                    : Convert.ToDecimal(
                                        reader["solde"]);

                            if (provenance == "EEG" &&
                                !eegTrouve)
                            {
                                data.SoldeEEG = solde;
                                eegTrouve = true;
                            }
                            else if (provenance == "GENERALE" &&
                                     !generaleTrouve)
                            {
                                data.SoldeGenerale = solde;
                                generaleTrouve = true;
                            }

                            if (eegTrouve && generaleTrouve)
                            {
                                break;
                            }
                        }
                    }
                }

                // =====================================================
                // 2. TOTAL DES RECETTES DU JOUR
                // =====================================================

                string queryRecettes = @"
                    SELECT COALESCE(SUM(recette), 0)
                    FROM livre_caisse
                    WHERE date >= CURDATE()
                      AND date < CURDATE() + INTERVAL 1 DAY";

                using (MySqlCommand commande =
                    new MySqlCommand(queryRecettes, connexion))
                {
                    object resultat =
                        commande.ExecuteScalar();

                    if (resultat != null &&
                        resultat != DBNull.Value)
                    {
                        data.TotalRecettes =
                            Convert.ToDecimal(resultat);
                    }
                }

                // =====================================================
                // 3. SOLDE MENSUEL EEG
                // =====================================================

                ChargerSoldesMensuels(
                    connexion,
                    "EEG",
                    data.SoldesEEGMensuels
                );

                // =====================================================
                // 4. SOLDE MENSUEL CAISSE GENERALE
                // =====================================================

                ChargerSoldesMensuels(
                    connexion,
                    "GENERALE",
                    data.SoldesGeneraleMensuels
                );
            }

            return data;
        }

        // =========================================================
        // AFFICHAGE DES DONNEES SUR LE THREAD UI
        // =========================================================
        private void AfficherDonneesDashboard(
            DashboardData data)
        {
            // =====================================================
            // INDICATEURS
            // =====================================================

            lbl_solde_eeg.Text =
                data.SoldeEEG.ToString("N2") + " $";

            lbl_solde_generale.Text =
                data.SoldeGenerale.ToString("N2") + " $";

            lbl_total_recettes.Text =
                data.TotalRecettes.ToString("N2") + " $";

            // =====================================================
            // GRAPHIQUE EEG
            // =====================================================

            AfficherGraphique(
                monGraphiqueEEG,
                "Caisse EEG",
                data.Mois,
                data.SoldesEEGMensuels
            );

            // =====================================================
            // GRAPHIQUE CAISSE GENERALE
            // =====================================================

            AfficherGraphique(
                monGraphiqueCaisseGenerale,
                "Caisse Générale",
                data.Mois,
                data.SoldesGeneraleMensuels
            );
        }

        // =========================================================
        // CHARGER LES SOLDES MENSUELS
        // =========================================================
        private void ChargerSoldesMensuels(
            MySqlConnection connexion,
            string provenance,
            decimal[] soldes)
        {
            string query = @"
                SELECT 
                    MONTH(l.date) AS mois,
                    l.solde
                FROM livre_caisse l
                INNER JOIN
                (
                    SELECT 
                        YEAR(date) AS annee,
                        MONTH(date) AS mois,
                        MAX(date) AS derniere_date
                    FROM livre_caisse
                    WHERE provenance = @provenance
                      AND date >= MAKEDATE(YEAR(CURDATE()), 1)
                      AND date < MAKEDATE(YEAR(CURDATE()) + 1, 1)
                    GROUP BY 
                        YEAR(date),
                        MONTH(date)
                ) dernier
                    ON YEAR(l.date) = dernier.annee
                    AND MONTH(l.date) = dernier.mois
                    AND l.date = dernier.derniere_date
                WHERE l.provenance = @provenance
                ORDER BY MONTH(l.date)";

            using (MySqlCommand commande =
                new MySqlCommand(query, connexion))
            {
                commande.Parameters.AddWithValue(
                    "@provenance",
                    provenance
                );

                using (MySqlDataReader reader =
                    commande.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int mois =
                            Convert.ToInt32(
                                reader["mois"]
                            );

                        decimal solde =
                            reader["solde"] == DBNull.Value
                                ? 0
                                : Convert.ToDecimal(
                                    reader["solde"]
                                );

                        if (mois >= 1 && mois <= 12)
                        {
                            soldes[mois - 1] = solde;
                        }
                    }
                }
            }
        }

        // =========================================================
        // AFFICHER GRAPHIQUE
        // =========================================================
        private void AfficherGraphique(
            dynamic graphique,
            string titre,
            string[] mois,
            decimal[] soldes)
        {
            List<string> etiquettes =
                new List<string>(mois);

            List<double> valeurs =
                new List<double>();

            for (int i = 0; i < 12; i++)
            {
                valeurs.Add(
                    Convert.ToDouble(
                        soldes[i]
                    )
                );
            }

            graphique.Vider();

            graphique.CouleurFond =
                Color.White;

            graphique.AfficherLegende =
                false;

            graphique.AfficherGrille =
                true;

            graphique.AnimationActive =
                true;

            graphique.AjouterHistogramme(
                titre,
                etiquettes,
                valeurs
            );
        }
    }

    // =============================================================
    // CLASSE POUR STOCKER LES DONNEES DU DASHBOARD
    // =============================================================
    internal class DashboardData
    {
        public string[] Mois { get; set; }

        public decimal SoldeEEG { get; set; }

        public decimal SoldeGenerale { get; set; }

        public decimal TotalRecettes { get; set; }

        public decimal[] SoldesEEGMensuels { get; set; }

        public decimal[] SoldesGeneraleMensuels { get; set; }
    }
}