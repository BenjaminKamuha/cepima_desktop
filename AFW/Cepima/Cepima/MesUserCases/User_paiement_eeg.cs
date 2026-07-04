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
    public partial class User_paiement_eeg : UserControl
    {
        public User_paiement_eeg()
        {
            InitializeComponent();
            FilterByType_eeg(cbx_type_eeg);
            LoadExamensEEG();
            LoadResume();
        }

        // =============================== FILTRER PAR TYPE EEG =====================================
        private void FilterByType_eeg(ComboBox cbx)
        {
            cbx.Items.Clear();
            cbx.Items.Add("Tous");
            cbx.Items.Add("18_cannaux");
            cbx.Items.Add("32_cannaux");
            cbx.SelectedIndex = 0;
        }

        // ============================= CHARGER LES EXAMENS DANS LE DATAGRIDVIEW ==============================
        private void LoadExamensEEG()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();
                try
                {
                    dgv_examens_eeg.Rows.Clear();
                    decimal montantTotal = 0;
                    int total_examens = 0;

                    string query = "SELECT e.id_examens,e.date_examen,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS patient,e.type_EEG,e.prix_examen,e.statut,CONCAT(per.nom,' ',per.post_nom,' ',per.prenom) AS medecin FROM examens_eeg e INNER JOIN patients p ON p.id_patient = e.id_patient INNER JOIN consultation c ON c.id_consultation = e.id_consultation INNER JOIN personnels per ON per.id_personnel = c.id_personnel WHERE 1=1";
                    using (MySqlCommand cmd = new MySqlCommand(query,con,tr))
                    {
                        //================================= rechercher ============================================
                        if (!string.IsNullOrWhiteSpace(tb_search_patient.Text))
                        {
                            query += " AND (p.nom LIKE @rech OR p.post_nom LIKE @rech OR p.prenom LIKE @rech )";
                            cmd.Parameters.AddWithValue("@rech", "%" + tb_search_patient.Text + "%");
                        }

                        //================================== Type EEG =============================================
                        if (cbx_type_eeg.SelectedIndex > 0)
                        {
                            query += " AND e.type_EEG=@type";
                            cmd.Parameters.AddWithValue("@type",cbx_type_eeg.Text);
                        }

                        // ================================== DATE  =============================================
                        query += " AND DATE(e.date_examen) = @date";
                        cmd.Parameters.AddWithValue("@date",dt_date.Value.ToString("yyyy-MM-dd"));
                        query += " ORDER BY e.date_examens DESC";

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int row = dgv_examens_eeg.Rows.Add();
                                dgv_examens_eeg.Tag = reader["id_examens"];
                                dgv_examens_eeg.Rows[row].Cells["colDate"].Value = Convert.ToDateTime(reader["date_examen"]).ToString("dd/MM/yyyy");
                                dgv_examens_eeg.Rows[row].Cells["colPatient"].Value = reader["patient"];
                                dgv_examens_eeg.Rows[row].Cells["colType"].Value = reader["type_EEG"];
                                dgv_examens_eeg.Rows[row].Cells["colPrix"].Value = Convert.ToDecimal(reader["prix_examen"]);
                                dgv_examens_eeg.Rows[row].Cells["colStatut"].Value = reader["statut"];
                                dgv_examens_eeg.Rows[row].Cells["colMedecin"].Value = reader["medecin"];

                                montantTotal += Convert.ToDecimal(reader["prix_examen"]);
                                total_examens++;
                            }
                            reader.Close();
                        }
                        lb_total_examens.Text = total_examens.ToString()+" examen(s)";
                        lb_total_montant.Text = montantTotal.ToString() + " $";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : "+ex.Message);
                }
            }
        }

        // ============================================ RESUMER DU JOUR  =======================================
        private void LoadResume()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string query_encaissement = "SELECT IFNULL(SUM(prix_examen),0)  AS prix_examen FROM examens_eeg WHERE DATE(date_examen) = CURDATE() AND statut = 'Terminé'";
                    using (MySqlCommand cmd = new MySqlCommand(query_encaissement, con))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            lb_encaissement_jour.Text = reader["prix_examen"].ToString()+" $";
                        }
                        reader.Close();
                    }

                    // ==========================================  ENCAISSEMENT CE MOIS ============================================
                    string queryMois = "SELECT IFNULL(SUM(prix_examen),0) AS prix_examen FROM examens_eeg WHERE MONTH(date_examen) = MONTH(CURDATE()) AND YEAR(date_examen) = YEAR(CURDATE()) AND statut = 'Terminé'";
                    using (MySqlCommand cmd = new MySqlCommand(queryMois, con))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            lb_encaissement_mois.Text = reader["prix_examen"].ToString() + " $";
                        }
                        reader.Close();
                    }

                    // ====================================== COMPTER LES EXAMEN NON PAYE ==============================================
                    string queryNonPaye = "SELECT COUNT(*)  AS data FROM examens_eeg WHERE statut = 'Demandé'";
                    using (MySqlCommand cmd = new MySqlCommand(queryNonPaye, con))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            lb_examen_non_paye.Text = reader["data"].ToString();
                        }
                        reader.Close();
                    }

                    // =================================== EXAMENS DU MOIS  ===========================================================
                    string queryMoisExamen = "SELECT COUNT(*) AS data FROM examens_eeg WHERE MONTH(date_examen)=MONTH(CURDATE()) AND YEAR(date_examen)=YEAR(CURDATE())";
                    using (MySqlCommand cmd = new MySqlCommand(queryMoisExamen, con))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            lb_examen_total.Text = reader["data"].ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur  : " + ex.Message);
                }
            }
        }
        private void tb_search_patient_TextChanged(object sender, EventArgs e)
        {
            LoadExamensEEG();
        }

        private void cbx_type_eeg_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadExamensEEG();
        }

        private void dt_date_ValueChanged(object sender, EventArgs e)
        {
            LoadExamensEEG();
        }
    }
}
