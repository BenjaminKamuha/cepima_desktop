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
    public partial class User_add_paiement : UserControl
    {
        decimal Montant;
        int FactureID;
        public User_add_paiement(decimal montant,int Idfacture)
        {
            InitializeComponent();
            Montant = montant;
            FactureID = Idfacture;
            lb_total_facture.Text = Montant.ToString() + " $";
           
        }

        private void ValiderPaiement()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();
                try
                {
                    // ======================== récuperer les valeures ============================
                    decimal totalFacture = Convert.ToDecimal(lb_total_facture.Text);
                    decimal montantPaye = Convert.ToDecimal(tb_montant_paye.Text);
                    decimal reste = Convert.ToDecimal(tb_reste.Text);
                    string numero = tb_numero_fiche.Text;
                    //variable poour la mise en jour de la facture ainsi que le paiement
                    string typePaiement = "";
                    string statutFacture = "";

                    // ======================================= verifier si le montant payé n'est pas superieur au totalFacture =============
                    if (montantPaye > totalFacture)
                    {
                        MessageBox.Show("Montant supérieur au total");
                        return;
                    }
                    // ===================================== type de paiement ==========================
                    if (reste > 0)
                    {
                        typePaiement = "Partiel";
                        statutFacture = "Partiellement payé";
                    }
                    else
                    {
                        typePaiement = "Complet";
                        statutFacture = "Payé";
                    }

                    // ================================== INSERT PAIEMENT ===================================
                    string queryInsertPaiement = "INSERT INTO paiement(id_facture,numero_recu,date_paiement,montant,reste,mode_paiement,type_paiement)VALUES(@facture,@recu,CURDATE(),@montant,@reste,@mode,@type)";
                    using (MySqlCommand cmd = new MySqlCommand(queryInsertPaiement, con, tr))
                    {
                        cmd.Parameters.AddWithValue("@facture",FactureID);
                        cmd.Parameters.AddWithValue("@recu",numero);
                        cmd.Parameters.AddWithValue("@montant",montantPaye);
                        cmd.Parameters.AddWithValue("@reste",reste);
                        cmd.Parameters.AddWithValue("@mode",tb_mode_paiement.Text);
                        cmd.Parameters.AddWithValue("@type",typePaiement);
                        cmd.ExecuteNonQuery();
                    }

                    // =============================== UPDATE FACTURE ==============================
                    string updateQuery = "UPDATE facture SET statut=@statut WHERE id_facture =@id";
                    using (MySqlCommand cmdUpdate = new MySqlCommand(updateQuery, con, tr))
                    {
                        cmdUpdate.Parameters.AddWithValue("@statut",statutFacture);
                        cmdUpdate.Parameters.AddWithValue("@id",FactureID);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    tr.Commit();
                    MessageBox.Show("Paiement enregistré");
                    tb_mode_paiement.Clear();
                    tb_montant_paye.Clear();
                    tb_numero_fiche.Clear();
                    tb_reste.Clear();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void bt_add_paiement_Click(object sender, EventArgs e)
        {
            ValiderPaiement();
        }

        private void tb_montant_paye_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Je suis dedans monsier");
             try
             {
                 decimal total = Convert.ToDecimal(lb_total_facture.Text.Replace("$","").Trim());
                 decimal montant_ = 0;

                 if (!string.IsNullOrWhiteSpace(tb_montant_paye.Text))
                 {
                     montant_ = Convert.ToDecimal(tb_montant_paye.Text);

                     if (montant_ > total)
                     {
                         MessageBox.Show("Le montant payé ne peut pas dépasser le montant de la facture");
                         tb_montant_paye.Text = total.ToString();
                         tb_montant_paye.SelectionStart = tb_montant_paye.Text.Length;
                         return;
                     }
                 }

                 decimal reste = total - montant_;
                 tb_reste.Text = reste.ToString("N2");
                
             }
             catch (Exception)
             {
                 tb_reste.Clear();
             }
        }
    }
}
