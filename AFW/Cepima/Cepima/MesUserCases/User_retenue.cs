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
    public partial class User_retenue : UserControl
    {
        public User_retenue()
        {
            InitializeComponent();
            MesClasses.ReceptionManager.MoveLabel(label4,panel1);
            MesClasses.RH_manager.ChargerRetenues(dgv_retenue);
            AjouterBoutons();
            LoadSalaireInComboBox();
            tb_montant.KeyPress += tb_montant_KeyPress;
            dgv_retenue.CellFormatting += dgv_retenue_CellFormatting;
            dgv_retenue.CellContentClick += dgv_retenue_CellContentClick;
            dgv_retenue.CellClick += dgv_retenue_CellClick;
            dgv_retenue.CellBeginEdit += dgv_retenue_CellBeginEdit;
            tb_search.TextChanged += tb_search_TextChanged;
        }
        decimal ancienneValeur = 0;
        int rowEndition = -1;
        void dgv_retenue_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgv_retenue.Columns[e.ColumnIndex].Name == "Montant_retenu")
            {
                ancienneValeur = Convert.ToDecimal(dgv_retenue.Rows[e.RowIndex].Cells["Montant_retenu"].Value);
                rowEndition = e.RowIndex;
            }
        }

        void dgv_retenue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_retenue.Columns[e.ColumnIndex].Name == "Montant_retenu")
            {
                //ancienneValeur = Convert.ToDecimal(dgv_salaire.Rows[e.RowIndex].Cells["salaire_base"].Value);
                dgv_retenue.ReadOnly = false;
                foreach (DataGridViewColumn col in dgv_retenue.Columns)
                {
                    col.ReadOnly = true;
                }
                dgv_retenue.Columns["Montant_retenu"].ReadOnly = false;
                dgv_retenue.CurrentCell = dgv_retenue.Rows[e.RowIndex].Cells["Montant_retenu"];
                dgv_retenue.BeginEdit(true);
            }
        }

        void dgv_retenue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int id = Convert.ToInt32(dgv_retenue.Rows[e.RowIndex].Cells["id_retenue"].Value);

                if (dgv_retenue.Columns[e.ColumnIndex].Name == "Modifier" && e.RowIndex >= 0)
                {
                    dgv_retenue.EndEdit();
                    if (rowEndition != e.RowIndex)
                    {
                        MessageBox.Show("Veuillez d'abord modifier la cellule !");
                        return;
                    }
                    decimal montant = Convert.ToDecimal(dgv_retenue.Rows[e.RowIndex].Cells["Montant_retenu"].Value);
                    if (ancienneValeur == montant)
                    {
                        MessageBox.Show("Aucune modification effectuée !");
                        return;
                    }
                    //update primes
                    MesClasses.RH_manager.Update_retenue(id, montant, ancienneValeur);
                    MesClasses.RH_manager.ChargerRetenues(dgv_retenue);
                    dgv_retenue.ReadOnly = true;
                    rowEndition = -1;
                }
                else if (dgv_retenue.Columns[e.ColumnIndex].Name == "Supprimer")
                {
                    DialogResult result = MessageBox.Show(" Voulez-vous Supprimer ce salaire ?", "Confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        // delete primes
                        MesClasses.RH_manager.Delete_retenue(id);
                        MesClasses.RH_manager.ChargerRetenues(dgv_retenue);
                    }
                }

            }
            catch (Exception)
            {
                return;
            }
        }

        void dgv_retenue_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_retenue.Columns[e.ColumnIndex].Name == "Modifier")
            {
                e.CellStyle.BackColor = Color.FromArgb(39, 174, 96);
                e.CellStyle.ForeColor = Color.White;
            }
            else if (dgv_retenue.Columns[e.ColumnIndex].Name == "Supprimer")
            {
                e.CellStyle.BackColor = Color.FromArgb(231, 76, 60);
                e.CellStyle.ForeColor = Color.White;
            }
        }

        void tb_montant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        // =================================== Ajouter la colonnes pour les actions (Modifier,supprimer,ect) =======================
        private void AjouterBoutons()
        {
            // Modifier
            DataGridViewButtonColumn btnModifier = new DataGridViewButtonColumn();
            btnModifier.Name = "Modifier";
            btnModifier.Text = "Modifier";
            btnModifier.UseColumnTextForButtonValue = true;
            dgv_retenue.Columns.Add(btnModifier);

            // Supprimer
            DataGridViewButtonColumn btnSupprimer = new DataGridViewButtonColumn();
            btnSupprimer.Name = "Supprimer";
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseColumnTextForButtonValue = true;
            dgv_retenue.Columns.Add(btnSupprimer);

            //desactiver
            ((DataGridViewButtonColumn)dgv_retenue.Columns["Modifier"]).FlatStyle = FlatStyle.Flat;
            ((DataGridViewButtonColumn)dgv_retenue.Columns["Supprimer"]).FlatStyle = FlatStyle.Flat;
            dgv_retenue.Columns["Modifier"].HeaderText = "";
            dgv_retenue.Columns["Supprimer"].HeaderText = "";
            dgv_retenue.Columns["Modifier"].Width = 60;
            dgv_retenue.Columns["Supprimer"].Width = 60;
            dgv_retenue.Columns["Personnel"].Width = 150;
            dgv_retenue.Columns["Fonction"].Width = 100;
            dgv_retenue.DefaultCellStyle.SelectionBackColor = Color.FromArgb(39, 174, 96);
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            MesClasses.RH_manager.ChargerRetenues(dgv_retenue,tb_search.Text);
        }

        private void bt_annuler_consultation_Click(object sender, EventArgs e)
        {
            try
            {
                int idSalaire = Convert.ToInt32(combo_mois.SelectedValue);
                decimal montant_retenue = Convert.ToDecimal(tb_montant.Text);
                string motif_prime = rich_description.Text;

               // ===================================== Save retenues ============================================================
                MesClasses.RH_manager.Save_retenues(idSalaire,motif_prime,montant_retenue);
                MesClasses.RH_manager.ChargerRetenues(dgv_retenue);
                combo_mois.SelectedIndex = -1;
                tb_montant.Clear();
                rich_description.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : "+ex.Message);
            }
        }

        private void LoadSalaireInComboBox()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string query = "SELECT s.id_salaire,s.salaire_base,CONCAT(p.nom ,' ',p.post_nom, ' ',p.prenom, '  |Base : ', s.salaire_base, '$','  |Mois:', s.mois) AS data_display FROM salaires s INNER JOIN personnels p ON p.id_personnel = s.id_personnel ORDER BY s.date_paiement DESC";
                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                combo_mois.DataSource = dt;
                combo_mois.DisplayMember = "data_display";
                combo_mois.ValueMember = "id_salaire";
                combo_mois.SelectedIndex = -1;
            }
        }
    }
}
