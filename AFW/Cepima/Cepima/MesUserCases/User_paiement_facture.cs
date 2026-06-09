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
    public partial class User_paiement_facture : UserControl
    {
        int paiementID = 0;
        public User_paiement_facture()
        {
            InitializeComponent();
            FilterType(cbx_type_facture);
            dgv_paiement.CellClick += dgv_paiement_CellClick;
            ChargerPaiement();
        }

        void dgv_paiement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                paiementID = Convert.ToInt32(dgv_paiement.Rows[e.RowIndex].Cells["colRecu"].Value);
                ChargerApercuRecu(paiementID);
            }
        }

        private void FilterType(ComboBox cbx)
        {
            cbx.Items.Clear();
            cbx.Items.Add("Tous");
            cbx.Items.Add("Partiel");
            cbx.Items.Add("Complet");
            cbx.SelectedIndex = 0;
        }

        private void ChargerPaiement()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                dgv_paiement.Rows.Clear();
                try
                {
                    string query = "SELECT pa.id_paiement,pa.numero_recu,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS patient,pa.montant,pa.reste,pa.type_paiement FROM paiement pa JOIN facture f ON pa.id_facture = f.id_facture JOIN patients p ON f.id_patient = p.id_patient WHERE 1=1";

                    // ================================= filtrage par patient ===============================
                    if (tb_search.Text.Trim() != "")
                    {
                        query += " AND(p.nom LIKE @search OR p.post_nom LIKE @search OR p.prenom LIKE @search)";
                    }

                    //=================================================== filtre par type de paiement ===========================
                    if (cbx_type_facture.Text != "" && cbx_type_facture.Text != "Tous")
                    {
                        query += " AND pa.type_paiement=@type";
                    }

                    //============================= filtre par date ========================================================
                    query += " AND DATE(pa.date_paiement) BETWEEN @debut AND @fin";

                    // ========================================= order ============================================
                    query += " ORDER BY pa.date_paiement DESC";

                    MySqlCommand cmd = new MySqlCommand(query, con);

                    // ==================== parametre recherche ============================
                    if (tb_search.Text.Trim() != "")
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + tb_search.Text.Trim() + "%");
                    }

                    // =============================== paramètre par type ===============================================
                    if (cbx_type_facture.Text != "" && cbx_type_facture.Text != "Tous")
                    {
                        cmd.Parameters.AddWithValue("@type",cbx_type_facture.Text);
                    }

                    // ================================ paramètre par date ==============================================
                    cmd.Parameters.AddWithValue("@debut",dt_debut.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@fin",dt_final.Value.ToString("yyyy-MM-dd"));

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int row = dgv_paiement.Rows.Add();
                            dgv_paiement.Rows[row].Cells["colRecu"].Value = reader["id_paiement"];
                            dgv_paiement.Rows[row].Cells["colDate"].Value = Convert.ToDateTime(reader["date_paiement"]).ToString("dd/MM/yyyy");
                            dgv_paiement.Rows[row].Cells["colFacture"].Value = reader["id_facture"];
                            dgv_paiement.Rows[row].Cells["colPatient"].Value = reader["patient"];
                            dgv_paiement.Rows[row].Cells["colMontant"].Value = reader["montant"];
                            dgv_paiement.Rows[row].Cells["colReste"].Value = reader["reste"];
                            dgv_paiement.Rows[row].Cells["colType"].Value = reader["type_paiement"];
                        }
                        reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : "+ex.Message);
                }
            }
        }

        //======================================= charger l'apercu du reçu ========================================================
        private void ChargerApercuRecu(int id_paiement)
        {
            try
            {
                string query = "SELECT pa.id_paiement,pa.numero_recu,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS patient,pa.montant,pa.reste,pa.type_paiement FROM paiement pa JOIN facture f ON pa.id_facture = f.id_facture JOIN patients p ON f.id_patient = p.id_patient WHERE p.id_paiement = @id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",id_paiement.ToString());
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                {
                    while (reader.Read())
                    {
                        lb_numero_recu.Text = reader["id_paiement"].ToString();
                        lb_date.Text = Convert.ToDecimal(reader["date_paiement"]).ToString("dd/MM/yyyy");
                        lb_numero_facture.Text = reader["id_facture"].ToString();
                        lb_patient.Text = reader["patient"].ToString();
                        lb_montant.Text = reader["montant"].ToString();
                        lb_type.Text = reader["type_paiement"].ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : "+ex.Message);
            }
        }
        private void cbx_type_facture_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargerPaiement();
        }

        private void dt_debut_ValueChanged(object sender, EventArgs e)
        {
            ChargerPaiement();
        }

        private void dt_final_ValueChanged(object sender, EventArgs e)
        {
            ChargerPaiement();
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            ChargerPaiement();
        }

        private void bt_print_recu_Click(object sender, EventArgs e)
        {
            // ====================== lancer l'impression de la facture ===========================
            if (paiementID == 0)
            {
                MessageBox.Show(" ID_PAIEMENT vide " +paiementID.ToString());
                return;
            }
            else
            {
                MesForms.FormRecu recu = new MesForms.FormRecu(paiementID);
                recu.ShowDialog();
            }
        }
    }
}
