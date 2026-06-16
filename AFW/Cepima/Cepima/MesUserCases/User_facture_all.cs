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
    public partial class User_facture_all : UserControl
    {
        decimal MONTANT;
        int idFacture ;
        public User_facture_all()
        {
            InitializeComponent();
            LoadFilter(cbx_type_facture,cbx_statut_facture);
            LoadFacture();
            dgv_facture.CellClick += dgv_facture_CellClick;
        }

        void dgv_facture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idFacture = Convert.ToInt32(dgv_facture.Rows[e.RowIndex].Cells["colID"].Value);
                LoadDetailFacture(idFacture);
                Charger_detail_de_la_facture(idFacture);
                lb_ID_facture.Text = idFacture.ToString();
                bt_add_paiement.Visible = true;
                MONTANT = Convert.ToDecimal(dgv_facture.Rows[e.RowIndex].Cells["colMontant"].Value);
                // ======================= si le bouton delete est clicqué, on supprime la facture ==========
                if (dgv_facture.Columns[e.ColumnIndex].Name == "colDelete")
                {
                     var result = MessageBox.Show("Supprimer cette facture ?","Confirmation",MessageBoxButtons.YesNo);
                     if (result == DialogResult.Yes)
                     {
                         DeletFacture(idFacture);
                     }
                }

                // ========================== Imprimer la facture ===============================================
                if (dgv_facture.Columns[e.ColumnIndex].Name == "colPrint")
                {
                    // lancer l'impression de la facture après avoir clicqué 
                    MesForms.FormFacturePrint facture = new MesForms.FormFacturePrint(idFacture);
                    facture.Show();

                }
            }
        }
        // ================================ supprimer la facture =================================================
        private void DeletFacture(int factureID) //357; 227 (panel_add_paiement)
        {
            try
            {
                string queryDelete = "DELETE FROM facture WHERE id_facture =@id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",factureID.ToString());
                MesClasses.ManagerClasse.CRUD(queryDelete,MesClasses.ManagerClasse.request_params);
                MessageBox.Show("Facture supprimée ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de suppression de la facture "+ex.Message);
            }
        }
        // ================================== charger les details de la facture ===================================
        private void LoadDetailFacture(int factureID)
        {
            try
            {
                string query = "SELECT  CONCAT(pa.nom,' ',pa.post_nom,' ',pa.prenom) AS patient,f.type_facture,f.date_facture,f.montant_total,f.statut,p.montant,p.reste FROM facture f  JOIN paiement p ON p.id_facture =f.id_facture JOIN patients pa ON f.id_patient = pa.id_patient WHERE f.id_facture =@id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",factureID.ToString());
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                {
                    while (reader.Read())
                    {
                        lb_patient.Text = reader["patient"].ToString();
                        lb_statut.Text = reader["statut"].ToString();
                        lb_date_facture.Text = Convert.ToDateTime(reader["date_facture"]).ToString("dd/MM/yyyy");
                        lb_medecin.Text = reader["montant_total"].ToString() + "$";
                        lb_type.Text = reader["type_facture"].ToString();
                        lb_montant_paye.Text = reader["montant"].ToString();
                        lb_reste.Text = reader["reste"].ToString();
                    }
                    reader.Close();
                }

               
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erreur : "+ex.Message);
            }
        }
        private void Charger_detail_de_la_facture(int facture)
        {
            try
            {
                // ========================================== Détails de la facture ========================================================
                dgv_detail_facture.Rows.Clear();
                string query_two = "SELECT description,quantite,prix_unitaire,montant FROM detail_facture WHERE id_facture =@id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id", facture.ToString());
                using (MySqlDataReader reader_two = MesClasses.ManagerClasse.CRUD(query_two, MesClasses.ManagerClasse.request_params, true))
                {
                    while (reader_two.Read())
                    {
                        int row = dgv_detail_facture.Rows.Add();
                        dgv_detail_facture.Rows[row].Cells["colDesc"].Value = reader_two["description"];
                        dgv_detail_facture.Rows[row].Cells["colQuantite"].Value = reader_two["quantite"];
                        dgv_detail_facture.Rows[row].Cells["colPrix"].Value = reader_two["prix_unitaire"];
                        dgv_detail_facture.Rows[row].Cells["colTotal"].Value = reader_two["montant"];
                    }
                    reader_two.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        // ================================ charger les filtres dans les comboBox ===================================
        private void LoadFilter(ComboBox cbx1, ComboBox cbx2)
        {
            cbx1.Items.Clear();
            cbx1.Items.Add("Tous");
            cbx1.Items.Add("Ambulatoire");
            cbx1.Items.Add("Hospitalisé");
            cbx1.SelectedIndex = 0;

            cbx2.Items.Clear();
            cbx2.Items.Add("Tous");
            cbx2.Items.Add("Non payé");
            cbx2.Items.Add("Payé");
            cbx2.SelectedIndex = 0;
        }

        // =============================== LoadFacture ======================================
        private void LoadFacture()
        {
            
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                dgv_facture.Rows.Clear();
                try
                {
                    string query = "SELECT f.id_facture,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS patient,f.type_facture,f.montant_total,f.statut,f.date_facture FROM facture f JOIN patients p ON f.id_patient = p.id_patient WHERE  1=1";

                    // filtrage par textBox (search)
                    if (tb_search.Text.Trim() != "")
                    {
                        query += " AND(p.nom LIKE @search OR p.post_nom LIKE @search OR p.prenom LIKE @search)";
                    }
                    // filtrage par type facture
                    if (cbx_type_facture.Text != "Tous")
                    {
                        query += " AND f.type_facture=@type";
                    }
                    // filtrage par statut
                    if (cbx_statut_facture.Text != "Tous")
                    {
                        query += " AND f.statut=@statut";
                    }
                    // filtrage par date
                    query += " AND DATE(f.date_facture) BETWEEN @debut AND @fin";

                    query += " ORDER BY f.date_facture DESC";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        // =============== paramètre searchText =============
                        if (tb_search.Text.Trim() != "")
                        {
                            cmd.Parameters.AddWithValue("@search","%" + tb_search.Text.Trim() + "%");
                        }
                        // paramètre type
                        if (cbx_type_facture.Text != "Tous")
                        {
                            cmd.Parameters.AddWithValue("@type",cbx_type_facture.Text);
                        }
                        // ========== paramètre statut
                        if (cbx_statut_facture.Text != "Tous")
                        {
                            cmd.Parameters.AddWithValue("@statut",cbx_statut_facture.Text);
                        }
                        // ============= paramètre date ==========
                        cmd.Parameters.AddWithValue("@debut",dt_debut.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@fin",dt_final.Value.ToString("yyyy-MM-dd"));

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            int i = 0;
                            while (reader.Read())
                            {
                                int row = dgv_facture.Rows.Add();
                                dgv_facture.Rows[row].Cells["colID"].Value = reader["id_facture"];
                                dgv_facture.Rows[row].Cells["colPatient"].Value = reader["patient"];
                                dgv_facture.Rows[row].Cells["colType"].Value = reader["type_facture"];
                                dgv_facture.Rows[row].Cells["colMontant"].Value = reader["montant_total"];
                                dgv_facture.Rows[row].Cells["colStatut"].Value = reader["statut"];
                                dgv_facture.Rows[row].Cells["colDate"].Value = Convert.ToDateTime(reader["date_facture"]).ToString("dd/MM/yyyy");

                                // ================= Apply the visual effects ===============
                                if (reader["statut"].ToString() == "Payé")
                                {
                                    dgv_facture.Rows[row].Cells["colStatut"].Style.ForeColor = Color.Green;
                                }
                                else
                                {
                                    dgv_facture.Rows[row].Cells["colStatut"].Style.ForeColor = Color.Red;
                                }
                                ApplyStyle();
                                i++;
                            }
                            reader.Close();
                            lb_nombre_facture.Text = i.ToString() + " facture(s)";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : "+ex.Message);
                }
            }
        }
        // ============================= style ==============================================================================================
        private void ApplyStyle()
        {
            dgv_facture.Columns["colID"].Width = 70;
            dgv_facture.Columns["colPatient"].Width = 150;
            dgv_facture.Columns["colType"].Width = 90;
            dgv_facture.Columns["colMontant"].Width = 80;
            dgv_facture.Columns["colDate"].Width = 100;
            dgv_facture.Columns["colStatut"].Width = 70;
            dgv_facture.Columns["colPrint"].Width = 10;
            dgv_facture.Columns["colDelete"].Width = 10;
        }

        // ====================================================================================================================================
        private void cbx_type_facture_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFacture();
        }

        private void cbx_statut_facture_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFacture();
        }

        private void dt_debut_ValueChanged(object sender, EventArgs e)
        {
            LoadFacture();
        }

        private void dt_final_ValueChanged(object sender, EventArgs e)
        {
            LoadFacture();
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            LoadFacture();
        }

        private void bt_add_paiement_Click(object sender, EventArgs e)
        {
            MesUserCases.User_add_paiement paiement = new User_add_paiement(MONTANT,idFacture);
            paiement.Dock = DockStyle.Fill;
            panel_add_paiement.Controls.Clear();
            panel_add_paiement.Controls.Add(paiement);
        }

        private void bt_actualiser_Click(object sender, EventArgs e)
        {
            LoadFacture();
        }
    }
}
