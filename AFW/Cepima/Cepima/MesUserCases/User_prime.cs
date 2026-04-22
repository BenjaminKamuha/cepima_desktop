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
    public partial class User_prime : UserControl
    {
        decimal ancienneValeur = 0;
        int rowEndition = -1;
        public User_prime()
        {
            InitializeComponent();
            MesClasses.ReceptionManager.MoveLabel(label4,panel1);
            LoadSalaireInComboBox();
            MesClasses.RH_manager.ChargerPrimes(dgv_primes);
            AjouterBoutons();
            dgv_primes.CellFormatting += dgv_primes_CellFormatting;
            dgv_primes.CellContentClick += dgv_primes_CellContentClick;
            dgv_primes.CellClick += dgv_primes_CellClick;
            dgv_primes.CellBeginEdit += dgv_primes_CellBeginEdit;
            tb_montant.KeyPress += tb_montant_KeyPress;
        }

        void tb_montant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        void dgv_primes_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgv_primes.Columns[e.ColumnIndex].Name == "Prime")
            {
                ancienneValeur = Convert.ToDecimal(dgv_primes.Rows[e.RowIndex].Cells["Prime"].Value);
                rowEndition = e.RowIndex;
            }
        }

        void dgv_primes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_primes.Columns[e.ColumnIndex].Name == "Prime")
            {
                //ancienneValeur = Convert.ToDecimal(dgv_salaire.Rows[e.RowIndex].Cells["salaire_base"].Value);
                dgv_primes.ReadOnly = false;
                foreach (DataGridViewColumn col in dgv_primes.Columns)
                {
                    col.ReadOnly = true;
                }
                dgv_primes.Columns["Prime"].ReadOnly = false;
                dgv_primes.CurrentCell = dgv_primes.Rows[e.RowIndex].Cells["Prime"];
                dgv_primes.BeginEdit(true);
            }
        }

        void dgv_primes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int id = Convert.ToInt32(dgv_primes.Rows[e.RowIndex].Cells["id_prime"].Value);

                if (dgv_primes.Columns[e.ColumnIndex].Name == "Modifier" && e.RowIndex >= 0)
                {
                    dgv_primes.EndEdit();
                    if (rowEndition != e.RowIndex)
                    {
                        MessageBox.Show("Veuillez d'abord modifier la cellule !");
                        return;
                    }
                    decimal montant = Convert.ToDecimal(dgv_primes.Rows[e.RowIndex].Cells["Prime"].Value);
                    if (ancienneValeur == montant)
                    {
                        MessageBox.Show("Aucune modification effectuée !");
                        return;
                    }
                    //update primes
                    MesClasses.RH_manager.Update_prime(id,montant,ancienneValeur);
                    MesClasses.RH_manager.ChargerPrimes(dgv_primes);
                    dgv_primes.ReadOnly = true;
                    rowEndition = -1;
                }
                else if (dgv_primes.Columns[e.ColumnIndex].Name == "Supprimer")
                {
                    DialogResult result = MessageBox.Show(" Voulez-vous Supprimer ce salaire ?", "Confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                       // delete primes
                        MesClasses.RH_manager.Delete_prime(id);
                        MesClasses.RH_manager.ChargerPrimes(dgv_primes);
                    }
                }

            }
            catch (Exception)
            {
                return;
            }
        }

        void dgv_primes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_primes.Columns[e.ColumnIndex].Name == "Modifier")
            {
                e.CellStyle.BackColor = Color.FromArgb(39, 174, 96);
                e.CellStyle.ForeColor = Color.White;
            }
            else if (dgv_primes.Columns[e.ColumnIndex].Name == "Supprimer")
            {
                e.CellStyle.BackColor = Color.FromArgb(231, 76, 60);
                e.CellStyle.ForeColor = Color.White;
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
                cbx_salaire_primes.DataSource = dt;
                cbx_salaire_primes.DisplayMember = "data_display";
                cbx_salaire_primes.ValueMember = "id_salaire";
                cbx_salaire_primes.SelectedIndex = -1;
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
            dgv_primes.Columns.Add(btnModifier);

            // Supprimer
            DataGridViewButtonColumn btnSupprimer = new DataGridViewButtonColumn();
            btnSupprimer.Name = "Supprimer";
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseColumnTextForButtonValue = true;
            dgv_primes.Columns.Add(btnSupprimer);

            //desactiver
            ((DataGridViewButtonColumn)dgv_primes.Columns["Modifier"]).FlatStyle = FlatStyle.Flat;
            ((DataGridViewButtonColumn)dgv_primes.Columns["Supprimer"]).FlatStyle = FlatStyle.Flat;
            dgv_primes.Columns["Modifier"].HeaderText = "";
            dgv_primes.Columns["Supprimer"].HeaderText = "";
            dgv_primes.Columns["Modifier"].Width = 60;
            dgv_primes.Columns["Supprimer"].Width = 60;
            dgv_primes.Columns["Personnel"].Width = 150;
            dgv_primes.Columns["Fonction"].Width = 100;
            dgv_primes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(39, 174, 96);
        }

        private void bt_save_prime_Click(object sender, EventArgs e)
        {
            try
            {
                int idSalaire = Convert.ToInt32(cbx_salaire_primes.SelectedValue);
                decimal montant_prime = Convert.ToDecimal(tb_montant.Text);
                string motif_prime = rich_description.Text;

                // Enregistrement d'une prime à travers sa méthode
                MesClasses.RH_manager.Save_primes(idSalaire,motif_prime,montant_prime);
                MesClasses.RH_manager.ChargerPrimes(dgv_primes);
                cbx_salaire_primes.SelectedIndex = -1;
                tb_montant.Clear();
                rich_description.Clear();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur : "+ex.Message);
            }
        }
    }
}
