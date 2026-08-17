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
namespace Cepima.MesForms
{
    public partial class FormDetailFacture : Form
    {
        int FACTURE;
        public FormDetailFacture(int factureID)
        {
            InitializeComponent();
            FACTURE = factureID;
            LoadDetailFacture();
            Charger_detail_de_la_facture();
        }
        // ================================== charger les details de la facture ===================================
        private void LoadDetailFacture()
        {
            try
            {
                string query = "SELECT  CONCAT(pa.nom,' ',pa.post_nom,' ',pa.prenom) AS patient,f.type_facture,f.date_facture,f.montant_total,f.statut,p.montant,p.reste FROM facture f   LEFT JOIN paiement p ON p.id_facture =f.id_facture LEFT JOIN patients pa ON f.id_patient = pa.id_patient WHERE f.id_facture =@id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id", FACTURE.ToString());
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                {
                    while (reader.Read())
                    {
                        lb_id.Text = FACTURE.ToString();
                        lb_patient.Text = reader["patient"].ToString();
                        lb_statut.Text = reader["statut"].ToString();
                        lb_date_facture.Text = Convert.ToDateTime(reader["date_facture"]).ToString("dd/MM/yyyy");
                        lb_medecin.Text = reader["montant_total"].ToString() + "$";
                        lb_type.Text = reader["type_facture"].ToString();
                        lb_montant_paye.Text = reader["montant"].ToString() + "$";
                        lb_reste.Text = reader["reste"].ToString() +"$";
                    }
                    reader.Close();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void Charger_detail_de_la_facture()
        {
            try
            {
                // ========================================== Détails de la facture ========================================================
                dgv_detail_facture.Rows.Clear();
                string query_two = "SELECT description,quantite,prix_unitaire,montant FROM detail_facture WHERE id_facture =@id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id", FACTURE.ToString());
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

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
