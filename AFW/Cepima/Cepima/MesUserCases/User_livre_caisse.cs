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
        string typeOperation = "Tous";
        public User_livre_caisse()
        {
            InitializeComponent();
            Selectionner(lbl_tous);
            LoadResumeLivreCaisse();
            LoadLivreCaisse();
         
        }
        // ================================ METTRE EN MOUVEMENT LE PANEL ========================================
        private void MoveBar(Label lbl)
        {
            panelSelection.Width = lbl.Width;
            panelSelection.Left = lbl.Left;
            panelSelection.Top = lbl.Bottom + 17;
        }

        private void Selectionner(Label actif)
        {
            lbl_tous.ForeColor = Color.Black;
            lbl_depenses.ForeColor = Color.Black;
            lbl_entrees.ForeColor = Color.Black;
            actif.ForeColor = Color.FromArgb(33,99,219);
            MoveBar(actif);
        }

        private void lbl_tous_Click(object sender, EventArgs e)
        {
            typeOperation = "Tous";
            Selectionner(lbl_tous);
            LoadResumeLivreCaisse();
            LoadLivreCaisse();
        }

        private void lbl_entrees_Click(object sender, EventArgs e)
        {
            typeOperation = "Entrée";
            Selectionner(lbl_entrees);
            LoadResumeLivreCaisse();
            LoadLivreCaisse();
        }

        private void lbl_depenses_Click(object sender, EventArgs e)
        {
            typeOperation = "Sortie";
            Selectionner(lbl_depenses);
            LoadResumeLivreCaisse();
            LoadLivreCaisse();
        }

        // ========================================== CHARGER TOUTES LES OPERATIONS (LIVRE DE CAISSE ) ======================================
        private void LoadLivreCaisse()
        {
            dgv_livre.Rows.Clear();
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string query = "";

                    // ============================= TOUTES LES OPERATIONS ==============================
                    if (typeOperation == "Tous")
                    {
                        query = "SELECT pa.date_paiement AS date_operation,'Entrée' AS type_operation,pa.numero_recu AS reference,CONCAT('Paiement facture N°',f.id_facture) AS designation,pa.mode_paiement,pa.montant,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS responsable FROM paiement pa JOIN facture f ON pa.id_facture = f.id_facture JOIN patients p ON f.id_patient=p.id_patient UNION ALL SELECT d.date_depense,'Sortie',d.id_depense,d.motif,'-',d.montant,d.responsable FROM depenses d ORDER BY date_operation DESC";
                    }

                    // ================================================ ENTREES =====================================
                    else if (typeOperation == "Entrée")
                    {
                        query = "SELECT pa.date_paiement AS date_operation,'Entrée' AS type_operation,pa.numero_recu AS reference,CONCAT('Paiement facture N° ',f.id_facture) AS designation,pa.mode_paiement,pa.montant,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS responsable FROM paiement pa JOIN facture f ON pa.id_facture = f.id_facture JOIN patients p ON p.id_patient = f.id_patient ORDER BY date_operation DESC";
                    }
                    // =========================================== DEPENSES ======================================
                    else
                    {
                        query = "SELECT d.date_depense AS date_operation,'Sortie' AS type_operation,d.id_depense AS reference,d.motif AS designation,'-' AS mode_paiement,d.montant,d.responsable FROM depenses d ORDER BY date_operation";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int row = dgv_livre.Rows.Add();
                                dgv_livre.Rows[row].Cells["colDate"].Value = Convert.ToDateTime(reader["date_operation"]).ToString("dd/MM/yyyy");
                                dgv_livre.Rows[row].Cells["colType"].Value = reader["type_operation"];
                                dgv_livre.Rows[row].Cells["colReference"].Value = reader["reference"];
                                dgv_livre.Rows[row].Cells["colDesignation"].Value = reader["designation"];
                                dgv_livre.Rows[row].Cells["colMode"].Value = reader["mode_paiement"];
                                dgv_livre.Rows[row].Cells["colMontant"].Value = Convert.ToDecimal(reader["montant"]);
                                dgv_livre.Rows[row].Cells["colResponsable"].Value = reader["responsable"];
                            }
                            reader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }
        // ==================================================== CHARGER LE RESUME DU LIVRE DE CAISSE =========================
        private void LoadResumeLivreCaisse()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    MySqlTransaction tr = con.BeginTransaction();

                    decimal encaisse = 0;
                    decimal depense = 0;
                    decimal operation = 0;

                    // ================================= TOTAL PAIEMENTS ================================
                    string queryPaiement = "SELECT COUNT(*) nb, IFNULL(SUM(montant),0) total FROM paiement WHERE DATE (date_paiement) BETWEEN @debut AND @fin";
                    using (MySqlCommand cmd = new MySqlCommand(queryPaiement, con, tr))
                    {
                        cmd.Parameters.AddWithValue("@debut",dt_debut.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@fin",dt_fin.Value.ToString("yyyy-MM-dd"));

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                encaisse = Convert.ToDecimal(reader["total"]);
                                operation = Convert.ToInt32(reader["nb"]);
                            }
                            reader.Close();
                        }
                    }

                    // ===================================== DEPENSES =============================================
                    string queryDepense = "SELECT COUNT(*) nb, IFNULL(SUM(montant),0) total FROM depenses WHERE DATE(date_depense) BETWEEN @debut AND @fin";
                    using (MySqlCommand cmd = new MySqlCommand(queryDepense, con, tr))
                    {
                        cmd.Parameters.AddWithValue("@debut",dt_debut.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@fin",dt_fin.Value.ToString("yyyy-MM-dd"));

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                depense = Convert.ToDecimal(reader["total"]);
                                operation += Convert.ToInt32(reader["nb"]);
                            }
                            reader.Close();
                        }
                    }

                    // =================================== CALCUL DU SOLDE  ==========================================
                    decimal solde = encaisse - depense;
                    lb_solde_jour.Text = solde.ToString() + " $";
                    lb_total_depense.Text = depense.ToString()+" $";
                    lb_total_entree.Text = encaisse.ToString() + " $";
                    lb_nombre_operation.Text = operation.ToString();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erreur : "+ex.Message);
                }
            }
        }

        private void dt_debut_ValueChanged(object sender, EventArgs e)
        {
            LoadResumeLivreCaisse();
        }

        private void dt_fin_ValueChanged(object sender, EventArgs e)
        {
            LoadResumeLivreCaisse();
        }
      
    }
}
