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

namespace Cepima.MesUserCases
{
    public partial class User_livre_caisse : UserControl
    {
        public User_livre_caisse()
        {
            InitializeComponent();

            InitCBXPeriode();

            LoadLivreCaisse();

            cbxPeriode.SelectedIndexChanged += cbxPeriode_SelectedIndexChanged;
        }


        // ============================================================
        // CHANGEMENT DE PERIODE
        // ============================================================

        private void cbxPeriode_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            LoadLivreCaisse();
        }


        // ============================================================
        // CHARGER LE LIVRE DE CAISSE
        // ============================================================

        private void LoadLivreCaisse()
        {
            try
            {
                using (MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {
                    // =================================================
                    // CONDITION DE PERIODE
                    // =================================================

                    string condition = GetConditionPeriode();


                    // =================================================
                    // CHARGEMENT DES OPERATIONS
                    // =================================================

                    string query = @"
                        SELECT
                            date AS Date,
                            recette AS Recette,
                            depasse AS Depasse,
                            solde AS Solde,
                            provenance AS Reference,
                            description AS Description

                        FROM livre_caisse

                        " + condition + @"

                        ORDER BY date DESC";


                    DataTable dt = new DataTable();


                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        using (MySqlDataAdapter da =
                            new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }


                    // =================================================
                    // AFFICHER LES DONNEES
                    // =================================================

                    dgv_caisse.DataSource = dt;


                    // =================================================
                    // CALCUL DES TOTAUX
                    // =================================================

                    decimal totalEntree = 0;
                    decimal totalDepense = 0;


                    if (dt.Rows.Count > 0)
                    {
                        object sommeEntree =
                            dt.Compute(
                                "SUM(Recette)",
                                ""
                            );

                        object sommeDepense =
                            dt.Compute(
                                "SUM(Depasse)",
                                "");


                        if (sommeEntree != null &&
                            sommeEntree != DBNull.Value)
                        {
                            totalEntree =
                                Convert.ToDecimal(
                                    sommeEntree);
                        }


                        if (sommeDepense != null &&
                            sommeDepense != DBNull.Value)
                        {
                            totalDepense =
                                Convert.ToDecimal(
                                    sommeDepense);
                        }
                    }


                    decimal solde =
                        totalEntree - totalDepense;


                    // =================================================
                    // AFFICHER LES TOTAUX
                    // =================================================

                    lb_total_entree.Text =
                        totalEntree.ToString("N2") + "$";


                    lb_total_depense.Text =
                        totalDepense.ToString("N2") + "$";


                    lb_solde_jour.Text =
                        solde.ToString("N2") + "$";


                    lb_nombre_operation.Text =
                        dt.Rows.Count.ToString();


                    // =================================================
                    // DERNIER SOLDE AVANT AUJOURD'HUI
                    // =================================================

                    AfficherDernierSolde(con);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du livre de caisse :\n\n" +
                    ex.Message,
                    "Erreur MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du livre de caisse :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // ============================================================
        // CONDITION DE PERIODE
        // ============================================================

        private string GetConditionPeriode()
        {
            switch (cbxPeriode.Text)
            {
                case "Aujourd'hui":

                    return @"
                        WHERE date >= CURDATE()
                        AND date < CURDATE() + INTERVAL 1 DAY";


                case "Hier":

                    return @"
                        WHERE date >= CURDATE() - INTERVAL 1 DAY
                        AND date < CURDATE()";


                case "Cette semaine":

                    return @"
                        WHERE date >=
                            CURDATE() -
                            INTERVAL WEEKDAY(CURDATE()) DAY

                        AND date <
                            CURDATE() +
                            INTERVAL 1 DAY";


                case "Ce mois":

                    return @"
                        WHERE date >=
                            DATE_FORMAT(
                                CURDATE(),
                                '%Y-%m-01'
                            )

                        AND date <
                            DATE_FORMAT(
                                CURDATE() + INTERVAL 1 MONTH,
                                '%Y-%m-01'
                            )";


                case "Cette année":

                    return @"
                        WHERE date >=
                            MAKEDATE(
                                YEAR(CURDATE()),
                                1
                            )

                        AND date <
                            MAKEDATE(
                                YEAR(CURDATE()) + 1,
                                1
                            )";


                case "Toutes les opérations":

                default:

                    return "";
            }
        }


        // ============================================================
        // INITIALISER COMBOBOX PERIODE
        // ============================================================

        private void InitCBXPeriode()
        {
            cbxPeriode.Items.Clear();

            cbxPeriode.Items.Add(
                "Toutes les opérations");

            cbxPeriode.Items.Add(
                "Aujourd'hui");

            cbxPeriode.Items.Add(
                "Hier");

            cbxPeriode.Items.Add(
                "Cette semaine");

            cbxPeriode.Items.Add(
                "Ce mois");

            cbxPeriode.Items.Add(
                "Cette année");


            cbxPeriode.SelectedIndex = 0;
        }


        // ============================================================
        // AFFICHER DERNIER SOLDE
        // ============================================================

        private void AfficherDernierSolde(
            MySqlConnection con)
        {
            try
            {
                string query = @"
                    SELECT solde

                    FROM livre_caisse

                    WHERE date < CURDATE()

                    ORDER BY date DESC

                    LIMIT 1";


                using (MySqlCommand cmd =
                    new MySqlCommand(query, con))
                {
                    object result =
                        cmd.ExecuteScalar();


                    if (result != null &&
                        result != DBNull.Value)
                    {
                        decimal dernierSolde =
                            Convert.ToDecimal(result);


                        lb_dernier_solde.Text =
                            dernierSolde.ToString("N2") +
                            "$";
                    }
                    else
                    {
                        lb_dernier_solde.Text =
                            "0.00$";
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors du calcul du dernier solde :\n\n" +
                    ex.Message,
                    "Erreur MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}