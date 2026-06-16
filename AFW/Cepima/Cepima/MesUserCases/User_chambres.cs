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
    public partial class User_chambres : UserControl
    {
        public User_chambres()
        {
            InitializeComponent();
            MesClasses.ReceptionManager.MoveLabel(label4,panel1);
            LoadService();
            LoadChambreInDataGridView();
            dgv_chambres.CellClick += dgv_chambres_CellClick;
        }

        void dgv_chambres_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            string idChambre = dgv_chambres.Rows[e.RowIndex].Tag.ToString();

            if (dgv_chambres.Columns[e.ColumnIndex].Name == "colUpdate")
            {
                // Tout verrouiller
                foreach (DataGridViewColumn col in dgv_chambres.Columns)
                {
                    col.ReadOnly = true;
                }

                // Déverrouiller seulement
                dgv_chambres.Rows[e.RowIndex].Cells["colNumero"].ReadOnly = false;
                dgv_chambres.Rows[e.RowIndex].Cells["colTarif"].ReadOnly = false;
                dgv_chambres.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            }

                // ===================== si bouton save ==============================
                if (dgv_chambres.Columns[e.ColumnIndex].Name == "colSave")
                {
                    saveModification(e.RowIndex);
                }

                // =========================== si bouton supprimer ==================
                if (dgv_chambres.Columns[e.ColumnIndex].Name == "colDelete")
                {
                    string query = "DELETE FROM chambre WHERE id_chambre =@id";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@id", idChambre.ToString());
                    MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params);
                    MessageBox.Show("Données supprimée avec succès !!");
                    LoadChambreInDataGridView();
                }
        }

        private void saveModification(int rowIndex)
        {
            string idchambre = dgv_chambres.Rows[rowIndex].Tag.ToString();
            string numero = dgv_chambres.Rows[rowIndex].Cells["colNumero"].Value.ToString();
            string tarif = dgv_chambres.Rows[rowIndex].Cells["colTarif"].Value.ToString();

            string queryUpdate = "UPDATE chambre SET numero_chambre =@numero,tarif_journalier =@tarif WHERE id_chambre =@id";
            MesClasses.ManagerClasse.request_params.Clear();
            MesClasses.ManagerClasse.request_params.Add("@numero", numero);
            MesClasses.ManagerClasse.request_params.Add("@tarif", tarif);
            MesClasses.ManagerClasse.request_params.Add("id",idchambre);

            MesClasses.ManagerClasse.CRUD(queryUpdate, MesClasses.ManagerClasse.request_params);
            MessageBox.Show("Données modifiée avec succès!!");
            LoadChambreInDataGridView();
            //remettre la lecture seule
            dgv_chambres.Rows[rowIndex].Cells["colNumero"].ReadOnly = true;
            dgv_chambres.Rows[rowIndex].Cells["colTarif"].ReadOnly = true;
            dgv_chambres.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
        }
        private void User_chambres_Load(object sender, EventArgs e)
        {
            LoadTypeChambre();
        }
        private void LoadTypeChambre()
        {
            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    string query = "SHOW COLUMNS FROM chambre LIKE 'type_chambre'";

                    MySqlCommand cmd = new MySqlCommand(query,con);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string typeEnum = reader["Type"].ToString();

                        // enlève enum(...)
                        typeEnum = typeEnum.Replace("enum(", "");

                        typeEnum = typeEnum.Replace(")", "");

                        typeEnum = typeEnum.Replace("'", "");

                        string[] types = typeEnum.Split(',');

                        cbx_type_chambre.Items.Clear();

                        cbx_type_chambre.Items.Add("Tous");

                        cbx_type_chambre.Items.AddRange(types);

                        cbx_type_chambre.SelectedIndex = 0;
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_save_chambre_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string query = "INSERT INTO chambre(id_centre,id_service,numero_chambre,type_chambre,tarif_journalier)VALUES(@centre,@service,@numero,@type,@tarif)";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@centre",MesForms.SessionUtilisateur.idCentre);
                    cmd.Parameters.AddWithValue("@service",cbx_service.SelectedValue);
                    cmd.Parameters.AddWithValue("@numero",numeric_chambre.Value);
                    cmd.Parameters.AddWithValue("@type",cbx_type_chambre.SelectedItem);
                    cmd.Parameters.AddWithValue("@tarif",tb_tarif.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Chambre ajoutée avec succès!!");
                    cbx_type_chambre.SelectedIndex = -1;
                    cbx_service.SelectedIndex = -1;
                    tb_tarif.Text = "";
                    numeric_chambre.Value = 0;
                }
            }
        }

        private void LoadService()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string query = "SELECT id_service,nom_service FROM services ORDER BY id_service ASC";
                using (MySqlDataAdapter ad = new MySqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    ad.Fill(dt);

                    cbx_service.DataSource = dt;
                    cbx_service.DisplayMember = "nom_service";
                    cbx_service.ValueMember = "id_service";
                }
            }
        }

        // ========================== charger les chambres dans le datagridview ===========================
        private void LoadChambreInDataGridView()
        {
            dgv_chambres.Rows.Clear();
            try
            {
                string query = "SELECT c.id_chambre,s.nom_service,c.numero_chambre,c.type_chambre,c.tarif_journalier,c.statut FROM chambre c JOIN services s ON c.id_service =s.id_service ORDER BY s.nom_service ASC";
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,null,true))
                {
                    while (reader.Read())
                    {
                        int row = dgv_chambres.Rows.Add();
                        dgv_chambres.Rows[row].Cells["colID"].Value = reader["id_chambre"];
                        dgv_chambres.Rows[row].Cells["colService"].Value = reader["nom_service"];
                        dgv_chambres.Rows[row].Cells["colNumero"].Value = reader["numero_chambre"];
                        dgv_chambres.Rows[row].Cells["colType"].Value = reader["type_chambre"];
                        dgv_chambres.Rows[row].Cells["colTarif"].Value = reader["tarif_journalier"];
                        dgv_chambres.Rows[row].Cells["colStatut"].Value = reader["statut"];
                        dgv_chambres.Rows[row].Tag = reader["id_chambre"];
                        ApplyStyle();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erreur : "+ex.Message);
            }
        }

        // ============================= style ==============================================================================================
        private void ApplyStyle()
        {
            dgv_chambres.Columns["colID"].Width = 70;
            dgv_chambres.Columns["colService"].Width = 80;
            dgv_chambres.Columns["colNumero"].Width = 80;
            dgv_chambres.Columns["colType"].Width = 150;
            dgv_chambres.Columns["colTarif"].Width = 80;
            dgv_chambres.Columns["colStatut"].Width = 90;
            dgv_chambres.Columns["colUpdate"].Width = 10;
            dgv_chambres.Columns["colDelete"].Width = 10;
            dgv_chambres.Columns["colSave"].Width = 10;
        }

    }
}
