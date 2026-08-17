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
    public partial class User_Examen_EEG : UserControl
    {
        string filtreStatut = "Tous";
        int idExamenSelectionne = 0;
        int idConsultation = 0;
        int ID_PATIENT = 0;
        public User_Examen_EEG()
        {
            InitializeComponent();
            Selectionner(lbl_tous);
            LoadExamensEEG();
            LoadTypeEEG(cbx_type, "examens_eeg");
            tb_search.TextChanged += tb_search_TextChanged;
        }

        void tb_search_TextChanged(object sender, EventArgs e)
        {
            LoadExamensEEG();
        }

        // ================================ METTRE EN MOUVEMENT LE PANEL ========================================
        private void MoveBar(Label lbl)
        {
            panelSelection.Width = lbl.Width;
            panelSelection.Left = lbl.Left;
            panelSelection.Top = lbl.Bottom + 8;
        }

        private void Selectionner(Label actif)
        {
            lbl_tous.ForeColor = Color.Black;
            lbl_atente.ForeColor = Color.Black;
            lbl_en_cours.ForeColor = Color.Black;
            lbl_termine.ForeColor = Color.Black;
            actif.ForeColor = Color.FromArgb(33, 99, 219);
            MoveBar(actif);
        }

        private void lbl_tous_Click(object sender, EventArgs e)
        {
            filtreStatut = "Tous";
            Selectionner(lbl_tous);
            LoadExamensEEG();
        }

        private void lbl_atente_Click(object sender, EventArgs e)
        {
            filtreStatut = "Demande";
            Selectionner(lbl_atente);
            LoadExamensEEG();
        }

        private void lbl_en_cours_Click(object sender, EventArgs e)
        {
            filtreStatut = "En cours";
            Selectionner(lbl_en_cours);
            LoadExamensEEG();
        }

        private void lbl_termine_Click(object sender, EventArgs e)
        {
            filtreStatut = "Terminé";
            Selectionner(lbl_termine);
            LoadExamensEEG();
        }
        private void LoadTypeEEG(ComboBox cbx, string table)
        {
            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    string query = "SHOW COLUMNS FROM " + table + " LIKE 'type_EEG'";

                    MySqlCommand cmd = new MySqlCommand(query, con);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string typeEnum = reader["Type"].ToString();

                        // enlève enum(...)
                        typeEnum = typeEnum.Replace("enum(", "");

                        typeEnum = typeEnum.Replace(")", "");

                        typeEnum = typeEnum.Replace("'", "");

                        string[] types = typeEnum.Split(',');

                        cbx.Items.Clear();

                        cbx.Items.AddRange(types);

                        cbx.SelectedIndex = 0;
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ============================== CHARGER LES EXAMENS EEG ====================================
        private void LoadExamensEEG()
        {
            dgv_examen_eeg.Rows.Clear();
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string query = "SELECT e.id_examens,p.id_patient,e.date_examen,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS patient,e.type_EEG,e.statut,IFNULL(e.resultat,'-')resultat FROM examens_eeg e JOIN patients p ON p.id_patient = e.id_patient WHERE 1=1";

                    //=========================================== FILTRE STATUT ==================================================
                    if (filtreStatut != "Tous")
                    {
                        query += " AND e.statut=@statut";
                    }

                    //================================ RECHERCHER ================================================================
                    if (!string.IsNullOrWhiteSpace(tb_search.Text))
                    {
                        query += " AND(p.nom LIKE @search OR p.post_nom LIKE @search OR p.prenom LIKE @search)";
                    }

                    query += " ORDER BY e.id_examens DESC ";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        if (filtreStatut != "Tous")
                        {
                            cmd.Parameters.AddWithValue("@statut",filtreStatut);
                        }

                        if (!string.IsNullOrWhiteSpace(tb_search.Text))
                        {
                            cmd.Parameters.AddWithValue("@search", "%" + tb_search.Text + "%");
                        }

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            int i = 0;
                            while (reader.Read())
                            {
                                int row = dgv_examen_eeg.Rows.Add();
                                dgv_examen_eeg.Rows[row].Tag = reader["id_examens"];
                                dgv_examen_eeg.Rows[row].Cells["colDate"].Value = Convert.ToDateTime(reader["date_examen"]).ToString("dd/MM/yyyy");
                                dgv_examen_eeg.Rows[row].Cells["colPatient"].Value = reader["patient"];
                                dgv_examen_eeg.Rows[row].Cells["colType"].Value = reader["type_EEG"];
                                dgv_examen_eeg.Rows[row].Cells["colStatut"].Value = reader["statut"];
                            }
                            if (i != 0)
                                lb_total_demande.Text = i.ToString() + " Demande(s)";
                            else
                                lb_total_demande.Text = "Aucune demande";
                            
                            
                            reader.Close();
                            dgv_examen_eeg.Columns["colDate"].Width = 80;
                            dgv_examen_eeg.Columns["colPatient"].Width = 150;
                            dgv_examen_eeg.Columns["colType"].Width = 110;
                            dgv_examen_eeg.Columns["colStatut"].Width = 80;
                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erreur : "+ex.Message);
                }
            }
        }

        private void dgv_examen_eeg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            idExamenSelectionne = Convert.ToInt32(dgv_examen_eeg.Rows[e.RowIndex].Tag);
            ID_PATIENT = Convert.ToInt32(dgv_examen_eeg.Rows[e.RowIndex].Tag);
            LoadDetailsEEG(idExamenSelectionne);
        }

        //============================================ DETAILS EXAMENS EEG ======================================
        private void LoadDetailsEEG(int idExamen)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string querySelect = "SELECT e.*,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS patient,p.date_naissance,p.adresse,p.telephone,p.sexe,CONCAT(pe.nom,' ',pe.post_nom,' ',pe.prenom) AS demandeur FROM examens_eeg e JOIN patients p ON p.id_patient = e.id_patient  JOIN consultation c ON c.id_consultation = e.id_consultation JOIN personnels pe ON pe.id_personnel = c.id_personnel WHERE e.id_examens =@id";
                    using (MySqlCommand cmd = new MySqlCommand(querySelect, con))
                    {
                        cmd.Parameters.AddWithValue("@id",idExamen);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                //============== resonnels informations =====================
                                lb_nom.Text = reader["patient"].ToString();
                                idConsultation = Convert.ToInt32(reader["id_consultation"]);
                                lb_adresse.Text = reader["adresse"].ToString();
                                lb_sexe.Text = reader["sexe"].ToString();
                                lb_phone.Text = reader["telephone"].ToString();
                                lb_date_naissance.Text = Convert.ToDateTime(reader["date_naissance"]).ToString("dd/MM/yyyy");

                                //examens eeg informations
                                lb_date_demande.Text = reader["date_examen"] ==DBNull.Value ? "-" : Convert.ToDateTime(reader["date_examen"]).ToString("dd/MM/yyyy");
                                lb_statut.Text = reader["statut"].ToString();
                                richResult.Text = reader["resultat"].ToString();
                                richInter.Text = reader["interpretation"].ToString();
                                lb_medecin.Text = reader["demandeur"].ToString();
                            }
                            reader.Close();

                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void bt_save_eeg_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();
                try
                {
                    // ================================ recuperer la consultation =======================================
                    string queryConsultation = "SELECT id_consultation FROM examens_eeg WHERE id_examens = @id";
                    using (MySqlCommand cmd = new MySqlCommand(queryConsultation, con, tr))
                    {
                        cmd.Parameters.AddWithValue("@id", idExamenSelectionne);
                        idConsultation = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    string queryUpdate = "UPDATE examens_eeg SET type_EEG=@type,prix_examen =@prix,resultat=@result,interpretation=@inter,statut='Terminé' WHERE id_examens=@id AND id_consultation=@idConsultation";
                    using (MySqlCommand cmd = new MySqlCommand(queryUpdate, con, tr))
                    {
                        cmd.Parameters.AddWithValue("@type", cbx_type.SelectedItem);
                        cmd.Parameters.AddWithValue("@prix", tb_prix_examen.Text);
                        cmd.Parameters.AddWithValue("@result", richResultat.Text);
                        cmd.Parameters.AddWithValue("@inter", rich_interpretation.Text);
                        cmd.Parameters.AddWithValue("@id", idExamenSelectionne);
                        cmd.Parameters.AddWithValue("@idConsultation", idConsultation);
                        cmd.ExecuteNonQuery();
                    }
                    decimal prixEEG = Convert.ToDecimal(tb_prix_examen.Text);
                    int idFacture = MesClasses.ReceptionManager.CreerFactureSiInexistante(idConsultation, ID_PATIENT, "Ambulatoire", con, tr);

                    MesClasses.ReceptionManager.MettreAJourPrestation(idFacture, "EEG",1, prixEEG,prixEEG, con, tr);

                    tr.Commit();
                    MessageBox.Show("EEG ajouté avec succès !!");
                    LoadExamensEEG();
                    cbx_type.SelectedIndex = -1;
                    richResultat.Clear();
                    rich_interpretation.Clear();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
