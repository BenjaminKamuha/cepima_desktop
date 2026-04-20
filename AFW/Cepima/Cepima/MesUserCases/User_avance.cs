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
    public partial class User_avance : UserControl
    {
         decimal ancienneValeur = 0;
         int rowEndition = -1;
        public User_avance()
        {
            InitializeComponent();
            MesClasses.ReceptionManager.MoveLabel(label4,panel1);
            LoadSalaireInComboBox();
            MesClasses.RH_manager.LoadAvances_salaire(dgv_avance,"");
            AjouterBoutons();
            dgv_avance.CellFormatting += dgv_avance_CellFormatting;
            dgv_avance.CellContentClick += dgv_avance_CellContentClick;
            dgv_avance.CellClick += dgv_avance_CellClick;
            dgv_avance.CellBeginEdit += dgv_avance_CellBeginEdit;
        }

        void dgv_avance_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgv_avance.Columns[e.ColumnIndex].Name == "Montant_avance")
            {
                ancienneValeur = Convert.ToDecimal(dgv_avance.Rows[e.RowIndex].Cells["Montant_avance"].Value);
                rowEndition = e.RowIndex;
            }
        }

        void dgv_avance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_avance.Columns[e.ColumnIndex].Name == "Montant_avance")
            {
                //ancienneValeur = Convert.ToDecimal(dgv_salaire.Rows[e.RowIndex].Cells["salaire_base"].Value);
                dgv_avance.ReadOnly = false;
                foreach (DataGridViewColumn col in dgv_avance.Columns)
                {
                    col.ReadOnly = true;
                }
                dgv_avance.Columns["Montant_avance"].ReadOnly = false;
                dgv_avance.CurrentCell = dgv_avance.Rows[e.RowIndex].Cells["Montant_avance"];
                dgv_avance.BeginEdit(true);
            }
        }

        void dgv_avance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int id = Convert.ToInt32(dgv_avance.Rows[e.RowIndex].Cells["id_avance"].Value);
                int SalaireID = Convert.ToInt32(dgv_avance.Rows[e.RowIndex].Cells["id_salaire"].Value);
                if (dgv_avance.Columns[e.ColumnIndex].Name == "Modifier" && e.RowIndex >= 0)
                {
                    dgv_avance.EndEdit();
                    if (rowEndition != e.RowIndex)
                    {
                        MessageBox.Show("Veuillez d'abord modifier la cellule !");
                        return;
                    }
                    decimal montant = Convert.ToDecimal(dgv_avance.Rows[e.RowIndex].Cells["Montant_avance"].Value);
                    if (ancienneValeur == montant)
                    {
                        MessageBox.Show("Aucune modification effectuée !");
                        return;
                    }
                    // modifier les données via la méthode
                    MesClasses.RH_manager.Update_avance_salaire(id,montant);
                    // recalculer le reste avant de le mettre à jour
                    RecalculerReste(SalaireID);
                    MesClasses.RH_manager.LoadAvances_salaire(dgv_avance," ");
                    dgv_avance.ReadOnly = true;
                    rowEndition = -1;
                }
                else if (dgv_avance.Columns[e.ColumnIndex].Name == "Supprimer")
                {
                    DialogResult result = MessageBox.Show(" Voulez-vous Supprimer ce salaire ?", "Confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        MesClasses.RH_manager.Delete_avance_salaire(id);
                        MesClasses.RH_manager.LoadAvances_salaire(dgv_avance, "");
                    }
                }

            }
            catch (Exception)
            {
                return;
            }
        }

        // ========================= Recalculer le resteAvance ===========================
        private void RecalculerReste(int salaireId)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();
                try
                {
                    string queySalaire = "SELECT salaire_base FROM salaires WHERE id_salaire = @id";
                    MySqlCommand cmd1 = new MySqlCommand(queySalaire, con, tr);
                    cmd1.Parameters.AddWithValue("@id",salaireId);
                    decimal salaireBase = Convert.ToDecimal(cmd1.ExecuteScalar());

                    // total avance 
                    string queryAvance = "SELECT IFNULL(SUM(montant),0) FROM avances_salaire WHERE id_salaire = @id";
                    MySqlCommand cmd2 = new MySqlCommand(queryAvance,con,tr);
                    cmd2.Parameters.AddWithValue("@id",salaireId);
                    decimal totalAvance = Convert.ToDecimal(cmd2.ExecuteScalar());
                    decimal reste = salaireBase - totalAvance;

                    // mettre à jour toutes les lignes
                    string queryUpdate = "UPDATE avances_salaire SET reste = @reste WHERE id_salaire = @id";
                    MySqlCommand cmd3 = new MySqlCommand(queryUpdate,con,tr);
                    cmd3.Parameters.AddWithValue("@reste",reste);
                    cmd3.Parameters.AddWithValue("@id",salaireId);
                    cmd3.ExecuteNonQuery();
                    tr.Commit();
                }
                catch (MySqlException ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Erreur : "+ex.Message);
                }
            }
        }
        void dgv_avance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_avance.Columns[e.ColumnIndex].Name == "Modifier")
            {
                e.CellStyle.BackColor = Color.FromArgb(39, 174, 96);
                e.CellStyle.ForeColor = Color.White;
            }
            else if (dgv_avance.Columns[e.ColumnIndex].Name == "Supprimer")
            {
                e.CellStyle.BackColor = Color.FromArgb(231, 76, 60);
                e.CellStyle.ForeColor = Color.White;
            }
        }
        // charger les salaires dans le comboBox =================================
        private void LoadSalaireInComboBox()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string query = "SELECT s.id_salaire,s.salaire_base,CONCAT(p.nom ,' ',p.post_nom, ' ',p.prenom, '  |Base : ', s.salaire_base, '$','  |Mois:', s.mois) AS data_display FROM salaires s INNER JOIN personnels p ON p.id_personnel = s.id_personnel ORDER BY s.date_paiement DESC";
                MySqlDataAdapter da = new MySqlDataAdapter(query,con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbx_salaire.DataSource = dt;
                cbx_salaire.DisplayMember = "data_display";
                cbx_salaire.ValueMember = "id_salaire";
                cbx_salaire.SelectedIndex = -1;
            }
        }

        // ========================== méthode pour calculer le reste de l'avance du salaire ======================
        decimal salaireBases = 0;
        decimal totalAvances = 0;
        int idSalaire = 0;
        private void CalculerReste()
        {
            decimal montant;
            if (salaireBases == 0)
                return;
            if (!decimal.TryParse(tb_montant_avance.Text, out montant))
            {
                tb_reste_avance.Text = "";
                return;
            }
            decimal reste = salaireBases - (totalAvances + montant);
            // limiter automatiquement
            decimal maxMontant = salaireBases - totalAvances;
            // sécurité
            if (montant > maxMontant)
            {
                tb_montant_avance.Text = maxMontant.ToString();
                tb_montant_avance.SelectionStart = tb_montant_avance.Text.Length;
                MessageBox.Show("Montant ajusté au maximun disponible");
            }

            if (reste < 0)
            {
                tb_reste_avance.Text = "0";
            }
            else
            {
                tb_reste_avance.Text = reste.ToString("N2");
                tb_reste_avance.ForeColor = Color.Red;
            }
           
        }

        // =================================== Méthode pour récuperer les avances ==================
        private decimal GetTotalAvances(int id)
        {
            decimal total = 0;
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string query = "SELECT IFNULL(SUM(montant),0) FROM avances_salaire WHERE id_salaire = @id";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@id",id);
                total = Convert.ToDecimal(cmd.ExecuteScalar());
            }
            return total;
        }
        private void tb_reste_avance_TextChanged(object sender, EventArgs e)
        {
            
            CalculerReste();
        }

        private void cbx_salaire_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_salaire.SelectedIndex == -1)
            {
                return;
            }
            DataRowView row = (DataRowView)cbx_salaire.SelectedItem;
            salaireBases = Convert.ToDecimal(row["salaire_base"]);
            idSalaire = Convert.ToInt32(row["id_salaire"]);
            totalAvances = GetTotalAvances(idSalaire);
            CalculerReste();
        }

        private void tb_montant_avance_TextChanged(object sender, EventArgs e)
        {
            CalculerReste();
        }
        private void tb_montant_avance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void tb_search_personnel_TextChanged(object sender, EventArgs e)
        {
            MesClasses.RH_manager.LoadAvances_salaire(dgv_avance,tb_search_personnel.Text);
        }

        private void bt_add_avance_Click(object sender, EventArgs e)
        {

            if (salaireBases == 0)
            {
                MessageBox.Show("Veuillez sélectionner un salaire");
                return;
            }
            decimal montant;
            if (!decimal.TryParse(tb_montant_avance.Text, out montant))
            {
                MessageBox.Show("Montant invalide !");
                return;
            }

            if (salaireBases - (totalAvances + montant) < 0)
            {
                MessageBox.Show("L'avance dépasse le salaire !");
                return;
            }

            // ===================== enregistrement des avances ========================
            MesClasses.RH_manager.Save_Avance_salaires(Convert.ToInt32(cbx_salaire.SelectedValue),Convert.ToDecimal(tb_montant_avance.Text),Convert.ToDecimal(tb_reste_avance.Text));
            MesClasses.RH_manager.LoadAvances_salaire(dgv_avance," ");
        }

        // =================================== Ajouter la colonnes pour les actions (Modifier,supprimer,ect) =======================
        private void AjouterBoutons()
        {
            // Modifier
            DataGridViewButtonColumn btnModifier = new DataGridViewButtonColumn();
            btnModifier.Name = "Modifier";
            btnModifier.Text = "Modifier";
            btnModifier.UseColumnTextForButtonValue = true;
            dgv_avance.Columns.Add(btnModifier);

            // Supprimer
            DataGridViewButtonColumn btnSupprimer = new DataGridViewButtonColumn();
            btnSupprimer.Name = "Supprimer";
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseColumnTextForButtonValue = true;
            dgv_avance.Columns.Add(btnSupprimer);

            //desactiver
            ((DataGridViewButtonColumn)dgv_avance.Columns["Modifier"]).FlatStyle = FlatStyle.Flat;
            ((DataGridViewButtonColumn)dgv_avance.Columns["Supprimer"]).FlatStyle = FlatStyle.Flat;
            dgv_avance.Columns["Modifier"].HeaderText = "";
            dgv_avance.Columns["Supprimer"].HeaderText = "";
            dgv_avance.Columns["Modifier"].Width = 60;
            dgv_avance.Columns["Supprimer"].Width = 60;
            dgv_avance.Columns["Personnel"].Width = 150;
            dgv_avance.Columns["Fonction"].Width = 100;
            dgv_avance.DefaultCellStyle.SelectionBackColor = Color.FromArgb(39, 174, 96);
        }
    }
}
