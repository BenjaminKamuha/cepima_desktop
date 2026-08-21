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
            AfficherDernierSolde();
            cbxPeriode.SelectedIndexChanged += cbxPeriode_SelectedIndexChanged;
        }

        void cbxPeriode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLivreCaisse();
        }
       
        // ========================================== CHARGER TOUTES LES OPERATIONS (LIVRE DE CAISSE ) ======================================
        private void LoadLivreCaisse()
        {
            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    string condition = "";
                    switch (cbxPeriode.Text)
                    {
                        case "Aujourd'hui":
                            condition = "WHERE DATE(date) = CURDATE()";
                            break;
                        case "Hier":
                            condition = "WHERE DATE(date) = CURDATE() - INTERVAL 1 DAY";
                            break;
                        case "Cette semaine":
                            condition = "WHERE YEARWEEK(date,1) = YEARWEEK(CURDATE(),1)";
                            break;
                        case "Ce mois":
                            condition = "WHERE YEAR(date) = YEAR(CURDATE()) AND MONTH(date) = MONTH(CURDATE())";
                            break;
                        case "Cette année":
                            condition = "WHERE YEAR(date) = YEAR(CURDATE())";
                            break;
                        case "Toutes les opérations":
                        default:
                            condition = "";
                            break;
                    } 

                    string query = "SELECT date AS Date,recette AS Recette,depasse AS 'Depasse', solde AS Solde,provenance AS Reference,description AS Description FROM livre_caisse WHERE 1 = 1 ORDER BY date DESC";

                    DataTable dt = new DataTable();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        // Afficher les données

                        dgv_caisse.DataSource = dt;

                        //calcul des totaux
                        decimal totalEntree = 0;
                        decimal totalDepasse = 0;

                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["Recette"] != DBNull.Value)
                            {
                                totalEntree += Convert.ToDecimal(row["Recette"]);
                            }

                            if (row["Dépasse"] != DBNull.Value)
                            {
                                totalDepasse += Convert.ToDecimal(row["Dépasse"]);
                            }
                        }
                        decimal solde = totalEntree - totalDepasse;

                        //Afficher dans les panels via les labels
                        lb_total_entree.Text = totalEntree.ToString("N2") + "$";
                        lb_total_depense.Text = totalDepasse.ToString("N2") + "$";
                        lb_solde_jour.Text = solde.ToString("N2") + "$";
                        lb_nombre_operation.Text = dt.Rows.Count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " +ex.Message);
            }
        }

        private void InitCBXPeriode()
        {
            cbxPeriode.Items.Clear();
            cbxPeriode.Items.Add("Toutes les opérations");
            cbxPeriode.Items.Add("Aujourd'hui");
            cbxPeriode.Items.Add("Hier");
            cbxPeriode.Items.Add("Cette semaine");
            cbxPeriode.Items.Add("Ce mois");
            cbxPeriode.Items.Add("Cette année");

            cbxPeriode.SelectedIndex = 0;
        }

        private void AfficherDernierSolde()
        {
            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    string query = "SELECT solde FROM livre_caisse WHERE DATE(date) < CURDATE() ORDER BY date DESC LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        decimal dernierSolde = Convert.ToDecimal(result);
                        lb_dernier_solde.Text = dernierSolde.ToString("N2") + "$";
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erreur lors du calcul du dernier solde :\n"+ex.Message,"Erreur",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
