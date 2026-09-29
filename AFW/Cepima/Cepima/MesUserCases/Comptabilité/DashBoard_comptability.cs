using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            ChargerDashboard();
        }

        /// <summary>
        /// Charge toutes les informations du dashboard avec une seule connexion MySQL.
        /// </summary>
        private void ChargerDashboard()
        {
            try
            {
                string[] mois =
                {
                    "Jan", "Fév", "Mar", "Avr",
                    "Mai", "Juin", "Juil", "Aoû",
                    "Sep", "Oct", "Nov", "Déc"
                };

                decimal[] soldesEEG = new decimal[12];
                decimal[] soldesGenerale = new decimal[12];

                decimal soldeEEG = 0;
                decimal soldeGenerale = 0;
                decimal totalRecettes = 0;

                using (MySqlConnection connexion =
                    MesClasses.ManagerClasse.GetConnexion())
                {
                   
                    // =====================================================
                    // 1. SOLDE CAISSE EEG + SOLDE CAISSE GENERALE
                    // =====================================================

                    string querySoldes = @"
                        SELECT provenance, solde
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
                                        : Convert.ToDecimal(reader["solde"]);

                                // Comme le résultat est trié DESC,
                                // la première ligne de chaque caisse
                                // est son dernier solde du jour.
                                if (provenance == "EEG" && !eegTrouve)
                                {
                                    soldeEEG = solde;
                                    eegTrouve = true;
                                }
                                else if (provenance == "GENERALE" &&
                                         !generaleTrouve)
                                {
                                    soldeGenerale = solde;
                                    generaleTrouve = true;
                                }

                                if (eegTrouve && generaleTrouve)
                                    break;
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
                        object resultat = commande.ExecuteScalar();

                        if (resultat != null &&
                            resultat != DBNull.Value)
                        {
                            totalRecettes =
                                Convert.ToDecimal(resultat);
                        }
                    }

                    // =====================================================
                    // 3. GRAPHIQUE CAISSE EEG
                    // =====================================================

                    ChargerSoldesMensuels(
                        connexion,
                        "EEG",
                        soldesEEG);

                    // =====================================================
                    // 4. GRAPHIQUE CAISSE GENERALE
                    // =====================================================

                    ChargerSoldesMensuels(
                        connexion,
                        "GENERALE",
                        soldesGenerale);
                }

                // =========================================================
                // AFFICHAGE DES INDICATEURS
                // =========================================================

                lbl_solde_eeg.Text =
                    soldeEEG.ToString("N2") + " $";

                lbl_solde_generale.Text =
                    soldeGenerale.ToString("N2") + " $";

                lbl_total_recettes.Text =
                    totalRecettes.ToString("N2") + " $";

                // =========================================================
                // AFFICHAGE DES GRAPHIQUES
                // =========================================================

                AfficherGraphique(
                    monGraphiqueEEG,
                    "Caisse EEG",
                    mois,
                    soldesEEG);

                AfficherGraphique(
                    monGraphiqueCaisseGenerale,
                    "Caisse Générale",
                    mois,
                    soldesGenerale);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du tableau de bord :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Récupère le dernier solde disponible pour chaque mois.
        /// La sélection est faite côté MySQL afin de limiter les données
        /// transférées vers le poste client.
        /// </summary>
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
            GROUP BY YEAR(date), MONTH(date)
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
                    provenance);

                using (MySqlDataReader reader =
                    commande.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int mois =
                            Convert.ToInt32(reader["mois"]);

                        decimal solde =
                            reader["solde"] == DBNull.Value
                                ? 0
                                : Convert.ToDecimal(reader["solde"]);

                        if (mois >= 1 && mois <= 12)
                        {
                            soldes[mois - 1] = solde;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Configure et affiche un graphique.
        /// </summary>
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
                    Convert.ToDouble(soldes[i]));
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
                valeurs);
        }
    }
}