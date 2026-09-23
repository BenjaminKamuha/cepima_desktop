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
                string[] mois =
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

                decimal[] soldes = new decimal[12];

                string query = @"
            SELECT 
                MONTH(date) AS numero_mois,
                solde
            FROM livre_caisse
            WHERE provenance = 'EEG'
              AND YEAR(date) = YEAR(CURDATE())
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
                                int numeroMois =
                                    Convert.ToInt32(reader["numero_mois"]);

                                decimal solde =
                                    Convert.ToDecimal(reader["solde"]);

                                // Le dernier solde du mois
                                // remplace le précédent
                                soldes[numeroMois - 1] = solde;
                            }
                        }
                    }
                }

                List<string> etiquettes =
                    new List<string>(mois);

                List<double> valeurs =
                    new List<double>();

                for (int i = 0; i < 12; i++)
                {
                    valeurs.Add(
                        Convert.ToDouble(soldes[i])
                    );
                }

                monGraphiqueEEG.Vider();

                monGraphiqueEEG.CouleurFond =
                    Color.White;

                monGraphiqueEEG.AfficherLegende =
                    false;

                monGraphiqueEEG.AfficherGrille =
                    true;

                monGraphiqueEEG.AnimationActive =
                    true;

                monGraphiqueEEG.AjouterHistogramme(
                    "Caisse EEG",
                    etiquettes,
                    valeurs
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du graphique mensuel de la caisse EEG :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ChargerGraphiqueCaisseGenerale()
        {
            try
            {
                string[] mois =
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

                decimal[] soldes = new decimal[12];

                string query = @"
            SELECT 
                MONTH(date) AS numero_mois,
                solde
            FROM livre_caisse
            WHERE provenance = 'GENERALE'
              AND YEAR(date) = YEAR(CURDATE())
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
                                int numeroMois =
                                    Convert.ToInt32(reader["numero_mois"]);

                                decimal solde =
                                    Convert.ToDecimal(reader["solde"]);

                                // Le dernier solde du mois
                                // remplace le précédent
                                soldes[numeroMois - 1] = solde;
                            }
                        }
                    }
                }

                List<string> etiquettes =
                    new List<string>(mois);

                List<double> valeurs =
                    new List<double>();

                for (int i = 0; i < 12; i++)
                {
                    valeurs.Add(
                        Convert.ToDouble(soldes[i])
                    );
                }

                monGraphiqueCaisseGenerale.Vider();

                monGraphiqueCaisseGenerale.CouleurFond =
                    Color.White;

                monGraphiqueCaisseGenerale.AfficherLegende =
                    false;

                monGraphiqueCaisseGenerale.AfficherGrille =
                    true;

                monGraphiqueCaisseGenerale.AnimationActive =
                    true;

                monGraphiqueCaisseGenerale.AjouterHistogramme(
                    "Caisse Générale",
                    etiquettes,
                    valeurs
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du graphique mensuel de la caisse générale :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
