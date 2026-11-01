using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Cepima.Data;

namespace Cepima.MesForms
{
    public partial class Paiement : Form
    {
        public Paiement()
        {
            InitializeComponent();

        }

        private void bt_confirmer_Click(object sender, EventArgs e)
        {
            Database db = new Database();

            using (MySqlConnection con = db.GetConnection())
                {
                    int id_paiement = 0;

                    con.Open();
                    MySqlTransaction tr = con.BeginTransaction();

                    try
                    {
                
                        // Enregistrement du paiement
                       string query = @"
                            INSERT INTO paiement
                            (
                                id_facture,
                                id_detail_facture,
                                date_paiement,
                                montant,
                                reste,
                                type_paiement
                            )
                            VALUES
                            (
                                @id_facture,
                                @id_detail,
                                @date_paiement,
                                @montant,
                                @reste,
                                @type_paiement
                            )";
                    using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
                    {
                        cmd.Parameters.AddWithValue("@id_facture", DBNull.Value);
                        cmd.Parameters.AddWithValue("@id_detail", DBNull.Value);
                        cmd.Parameters.AddWithValue("@date_paiement", Convert.ToDateTime(dtpPaiement.Value));
                        cmd.Parameters.AddWithValue("@montant", nud_montant.Value);
                        cmd.Parameters.AddWithValue("@reste", nud_reste.Value );
                        cmd.Parameters.AddWithValue("@type_paiement", nud_reste.Value > 0 ? "Partiel" : "Complet") ;

                        cmd.ExecuteNonQuery();

                        id_paiement = Convert.ToInt32(cmd.LastInsertedId);

                        // Enregistrement dans le livre de caisse
                        Cepima.MesClasses.ReceptionManager.AjouterLivreCaisse(nud_montant.Value, 0, "AUTRE", tb_description.Text, con, tr);


                        
                    }

                    tr.Commit();
                    // Impression de du reçu
                    this.Close();
                    FormRecu recu = new FormRecu(id_paiement, false);
                    recu.ShowDialog();
                    con.Close();

                }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur " + ex.Message);
                        tr.Rollback();
                    }
            }
                
        }
    }
}
