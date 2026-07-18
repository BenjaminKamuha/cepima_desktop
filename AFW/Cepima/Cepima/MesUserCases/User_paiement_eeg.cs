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
        int idExamen = 0;
        public User_paiement_eeg()
        {
            InitializeComponent();
            FilterByType_eeg(cbx_type_eeg,cbx_filtrer);
            //LoadExamensEEG();
            LoadResume();
            LoadHistoriquePaiementEEG();
            dgv_examens_eeg.CellContentClick += dgv_examens_eeg_CellContentClick;
            LoadEnum(cbx_mode_paiement, "paiement_eeg", "mode_paiement");
        }

        void dgv_examens_eeg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex  < 0)
            {
                return;
            }

            if (dgv_examens_eeg.Columns[e.ColumnIndex].Name =="colEncaisser")
            {
                idExamen = Convert.ToInt32(dgv_examens_eeg.Rows[e.RowIndex].Tag);
                pan_add_encaissement.Visible = true;
                LoadInfosPaiement(idExamen);
            }
        }

        // ============================================= REMPLIR LES INFORMATIONS DU PAIEMENT ==========================
        private void LoadInfosPaiement(int examen_id)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string querySelect = "SELECT prix_examen FROM examens_eeg WHERE id_examens = @id";
                using (MySqlCommand cmd = new MySqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@id",examen_id);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tb_montant_a_payer.Text = reader["prix_examen"].ToString();
                    }
                    reader.Close();
                }
            }
        }

        // =============================== CHARGER LES ENUM (mode de paiement) =======================
        private void LoadEnum(ComboBox cbx, string table, string colonne)
        {
            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    string query = "SHOW COLUMNS FROM " + table + " LIKE @colonne";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@colonne", colonne);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string typeEnum = reader["Type"].ToString();

                        typeEnum = typeEnum.Replace("enum(", "");
                        typeEnum = typeEnum.Replace(")", "");
                        typeEnum = typeEnum.Replace("'", "");

                        string[] valeurs = typeEnum.Split(',');

                        cbx.Items.Clear();
                        cbx.Items.AddRange(valeurs);

                        if (cbx.Items.Count > 0)
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

        // ============================== SAVE PAIEMENT EEG =======================================
        private void SavePaiementEEG()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                MySqlTransaction trans = con.BeginTransaction();

                try
                {
                    //================= INSERTION DU PAIEMENT =================

                    string query = "INSERT INTO paiement_eeg(id_examen,date_paiement,montant_eeg,mode_paiement)VALUES(@exam,NOW(),@montant,@mode)";
                    MySqlCommand cmd = new MySqlCommand(query, con, trans);
                    cmd.Parameters.AddWithValue("@exam", idExamen);
                    cmd.Parameters.AddWithValue("@montant", Convert.ToDecimal(tb_montant_recu.Text));
                    cmd.Parameters.AddWithValue("@mode", cbx_mode_paiement.Text);
                    //cmd.Parameters.AddWithValue("@user", MesForms.SessionUtilisateur.idUser);

                    cmd.ExecuteNonQuery();

                    //================= MISE A JOUR DE L'EXAMEN =================

                    query = "UPDATE examens_eeg SET etat_paiement='Payé' WHERE id_examens=@id";
                    cmd = new MySqlCommand(query, con, trans);
                    cmd.Parameters.AddWithValue("@id", idExamen);
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Paiement enregistré avec succès.");
                    pan_add_encaissement.Visible = false;
                    LoadHistoriquePaiementEEG();
                    LoadResume();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
        }
        // =============================== FILTRER PAR TYPE EEG =====================================
        private void FilterByType_eeg(ComboBox cbx, ComboBox cbx1)
        {
            cbx.Items.Clear();
            cbx.Items.Add("Tous");
            cbx.Items.Add("18_cannaux");
            cbx.Items.Add("32_cannaux");
            cbx.SelectedIndex = 0;

            // ====================================================
            cbx1.Items.Clear();
            cbx1.Items.Add("Tous");
            cbx1.Items.Add("Ajourd'hui");
            cbx1.Items.Add("Cette semaine");
            cbx1.Items.Add("Ce mois");
            cbx1.SelectedIndex = 0;
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

                       // ============================================== type ==================
                        switch (cbx_filtrer.Text)
                        {
                            case "Ajourd'hui":
                                query += " AND DATE(e.date_examen)=CURDATE()";
                                break;
                            case "Cette semaine":
                                query += " AND YEARWEEK(e.date_examen,1)=YEARWEEK(CURDATE(),1)";
                                break;
                            case "Ce mois":
                                query += " AND MONTH(e.date_examen)=MONTH(CURDATE()) AND YEAR(e.date_examen)=YEAR(CURDATE())";
                                break;
                        }

                        cmd.CommandText = query;
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
                                dgv_examens_eeg.Rows[row].Cells["colStatut_examen"].Value = reader["statut"];
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

        // ====================================== HISTORIQUE DE PAIEMENT EEG ==================================
        private void LoadHistoriquePaiementEEG()
        {
            dgv_historique_paiement.Rows.Clear();

            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string query = "SELECT pe.id_paiement_eeg,pe.date_paiement,pe.montant_eeg,pe.mode_paiement,e.type_EEG,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) patient FROM paiement_eeg pe INNER JOIN examens_eeg e ON pe.id_examen=e.id_examens INNER JOIN patients p ON e.id_patient=p.id_patient  WHERE 1=1 ";
                    MesClasses.ManagerClasse.request_params.Clear();

                    //===================== Recherche ==========================
                    if (!string.IsNullOrWhiteSpace(tb_search_patient.Text))
                    {
                        query += " AND(p.nom LIKE @rech OR p.post_nom LIKE @rech OR p.prenom LIKE @rech )";

                        MesClasses.ManagerClasse.request_params.Add("@rech", "%" + tb_search_patient.Text + "%");
                    }

                    // ============================================== type ==================
                    switch (cbx_filtrer.Text)
                    {
                        case "Ajourd'hui":
                            query += " AND DATE(pe.date_paiement)=CURDATE()";
                            break;
                        case "Cette semaine":
                            query += " AND YEARWEEK(pe.date_paiement,1)=YEARWEEK(CURDATE(),1)";
                            break;
                        case "Ce mois":
                            query += " AND MONTH(pe.date_paiement)=MONTH(CURDATE()) AND YEAR(pe.date_paiement)=YEAR(CURDATE())";
                            break;
                    }
                 

                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                    {
                        while (reader.Read())
                        {
                            int row = dgv_historique_paiement.Rows.Add();

                            dgv_historique_paiement.Rows[row].Tag = reader["id_paiement_eeg"];

                            dgv_historique_paiement.Rows[row].Cells["date"].Value = Convert.ToDateTime(reader["date_paiement"]).ToString("dd/MM/yyyy HH:mm");

                            dgv_historique_paiement.Rows[row].Cells["patient"].Value = reader["patient"];
                            dgv_historique_paiement.Rows[row].Cells["type"].Value = reader["type_EEG"];
                            dgv_historique_paiement.Rows[row].Cells["colMontant"].Value = Convert.ToDecimal(reader["montant_eeg"]);
                            dgv_historique_paiement.Rows[row].Cells["mode"].Value = reader["mode_paiement"];

                        }

                        reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void tb_search_patient_TextChanged(object sender, EventArgs e)
        {
            LoadExamensEEG();
            LoadHistoriquePaiementEEG();
        }

        private void cbx_type_eeg_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadExamensEEG();
        }

        private void cbx_filtrer_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadExamensEEG();
            LoadHistoriquePaiementEEG();
        }

        private void bt_valider_Click(object sender, EventArgs e)
        {
            SavePaiementEEG();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
