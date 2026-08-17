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
            FiltragePeriode(cbx_filter_periode);
            cbx_filter_periode.SelectedIndexChanged += cbx_filter_periode_SelectedIndexChanged;
        }

        void cbx_filter_periode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFacture();
        }

        private decimal RecupererMontantRestant(int factureID)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string query = "SELECT reste FROM paiement WHERE id_facture = @id ORDER BY id_paiement DESC LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(query,con))
                {
                    cmd.Parameters.AddWithValue("@id",factureID);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        return Convert.ToDecimal(result);
                    }
                }
                return Convert.ToDecimal(dgv_facture.CurrentRow.Cells["colMontant"].Value);
            }
        }
        // ======================== FILTRAGE PAR periode ===============================
        private void FiltragePeriode(ComboBox cbx)
        {
            cbx.Items.Clear();
            cbx.Items.Add("Tous");
            cbx.Items.Add("Aujourd'hui");
            cbx.Items.Add("Cette semaine");
            cbx.Items.Add("Ce mois");

            cbx.SelectedIndex = 0;
        }
        void dgv_facture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idFacture = Convert.ToInt32(dgv_facture.Rows[e.RowIndex].Cells["colID"].Value);
                MONTANT = RecupererMontantRestant(idFacture);
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

                // Afficher les détails de la facture sélectionnée
                if (dgv_facture.Columns[e.ColumnIndex].Name == "colDetail")
                {
                    MesForms.FormDetailFacture detail = new MesForms.FormDetailFacture(idFacture);
                    detail.Show();
                }

                // Afficher le formulaire de paiement de la facture
                if (dgv_facture.Columns[e.ColumnIndex].Name == "colPayement")
                {
                    MesForms.FormPaiement pay = new MesForms.FormPaiement(MONTANT,idFacture);
                    pay.Show();
                }
            }
        }
        // ================================ supprimer la facture =================================================
        private void DeletFacture(int factureID) //357; 227 (panel_add_paiement)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();
                try
                {
                    string queryDelete = "DELETE FROM facture WHERE id_facture =@id";
                    using (MySqlCommand cmdDelete = new MySqlCommand(queryDelete,con,tr))
                    {
                    cmdDelete.Parameters.AddWithValue("@id", factureID);
                    cmdDelete.ExecuteNonQuery();
                    }

                    // ================================= SUPPRIMER LES DETAILS AUSSI DE LA FACTURE ==============================
                    string queryDetail = "DELETE FROM detail_facture WHERE id_facture = @id";
                    using (MySqlCommand cmdDetail = new MySqlCommand(queryDetail, con, tr))
                    {
                        cmdDetail.Parameters.AddWithValue("@id",factureID);
                        cmdDetail.ExecuteNonQuery();
                    }

                    tr.Commit();
                    MessageBox.Show("Facture supprimée avec succès !!");
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Erreur de suppression de la facture " + ex.Message);
                }
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

        // ===================================================== LoadFacture ================================================
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
                    // filtrage par periode
                    switch (cbx_filter_periode.Text)
                    {
                        case "Aujourd'hui":
                            query += " AND DATE(f.date_facture)=CURDATE()";
                            break;
                        case "Cette semaine":
                            query += " AND YEARWEEK(f.date_facture,1)=YEARWEEK(CURDATE(),1)";
                            break;
                        case "Ce mois":
                            query += " AND MONTH(f.date_facture)=MONTH(CURDATE()) AND YEAR(f.date_facture)=YEAR(CURDATE())";
                            break;
                    }

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
            dgv_facture.Columns["colPatient"].Width = 180;
            dgv_facture.Columns["colType"].Width = 100;
            dgv_facture.Columns["colMontant"].Width = 100;
            dgv_facture.Columns["colDate"].Width = 110;
            dgv_facture.Columns["colStatut"].Width = 90;
            dgv_facture.Columns["colPrint"].Width = 90;
            dgv_facture.Columns["colDelete"].Width = 90;
            dgv_facture.Columns["colDetail"].Width = 100;
            dgv_facture.Columns["colPayement"].Width = 50;
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

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            LoadFacture();
        }

        private void bt_add_paiement_Click(object sender, EventArgs e)
        {
            //MesUserCases.User_add_paiement paiement = new User_add_paiement(MONTANT,idFacture);
            //paiement.Dock = DockStyle.Fill;
            //panel_add_paiement.Controls.Clear();
            //panel_add_paiement.Controls.Add(paiement);
        }

        private void bt_actualiser_Click(object sender, EventArgs e)
        {
            LoadFacture();
        }
    }
}
