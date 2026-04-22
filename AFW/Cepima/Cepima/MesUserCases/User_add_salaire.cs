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
    public partial class User_add_salaire : UserControl
    {
        decimal ancienneValeur = 0;
        int rowEndition = -1;
        public User_add_salaire()
        {
            InitializeComponent();
            MesClasses.ReceptionManager.MoveLabel(label4,panel1);
            LoadStatutForPresence(combo_statut);
            ChargerMois();
            LoadPersonnels();
            MesClasses.RH_manager.LoadSalaryInDgv(dgv_salaire);
            AjouterBoutons();
            dgv_salaire.CellFormatting += dgv_salaire_CellFormatting;
            dgv_salaire.CellContentClick += dgv_salaire_CellContentClick;
            dgv_salaire.CellClick += dgv_salaire_CellClick;
            dgv_salaire.CellBeginEdit += dgv_salaire_CellBeginEdit;
        }

        void dgv_salaire_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgv_salaire.Columns[e.ColumnIndex].Name == "salaire_base")
            {
                ancienneValeur = Convert.ToDecimal(dgv_salaire.Rows[e.RowIndex].Cells["salaire_base"].Value);
                rowEndition = e.RowIndex;
            }
        }
        void dgv_salaire_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_salaire.Columns[e.ColumnIndex].Name == "salaire_base")
            {
                //ancienneValeur = Convert.ToDecimal(dgv_salaire.Rows[e.RowIndex].Cells["salaire_base"].Value);
                dgv_salaire.ReadOnly = false;
                foreach (DataGridViewColumn col in dgv_salaire.Columns)
                {
                    col.ReadOnly = true;
                }
                dgv_salaire.Columns["salaire_base"].ReadOnly = false;
                dgv_salaire.CurrentCell = dgv_salaire.Rows[e.RowIndex].Cells["salaire_base"];
                dgv_salaire.BeginEdit(true);
            }
        }
        void dgv_salaire_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               
                int id = Convert.ToInt32(dgv_salaire.Rows[e.RowIndex].Cells["ID"].Value);
               
                if (dgv_salaire.Columns[e.ColumnIndex].Name == "Modifier" && e.RowIndex >= 0)
                {
                    dgv_salaire.EndEdit();
                    if (rowEndition != e.RowIndex)
                    {
                        MessageBox.Show("Veuillez d'abord modifier la cellule !");
                        return;
                    }
                    decimal montant = Convert.ToDecimal(dgv_salaire.Rows[e.RowIndex].Cells["salaire_base"].Value);
                    if (ancienneValeur == montant)
                    {
                        MessageBox.Show("Aucune modification effectuée !");
                        return;
                    }
                    MesClasses.RH_manager.UpdateSalary(id,montant);
                    MesClasses.RH_manager.LoadSalaryInDgv(dgv_salaire);
                    dgv_salaire.ReadOnly = true;
                    rowEndition = -1;
                }
                else if (dgv_salaire.Columns[e.ColumnIndex].Name == "Supprimer")
                {
                    DialogResult result = MessageBox.Show(" Voulez-vous Supprimer ce salaire ?", "Confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        MesClasses.RH_manager.DeleteSalary(id);
                        MesClasses.RH_manager.LoadSalaryInDgv(dgv_salaire);
                    }
                }
               
            }
            catch (Exception)
            {
                return;
            }
           
        }

        void dgv_salaire_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_salaire.Columns[e.ColumnIndex].Name == "Modifier")
            {
                e.CellStyle.BackColor = Color.FromArgb(39, 174, 96);
                e.CellStyle.ForeColor = Color.White;
            }
            else if (dgv_salaire.Columns[e.ColumnIndex].Name == "Supprimer")
            {
                e.CellStyle.BackColor = Color.FromArgb(231, 76, 60);
                e.CellStyle.ForeColor = Color.White;
            }
        }

        private void User_add_salaire_Load(object sender, EventArgs e)
        {

        }
        private static void LoadStatutForPresence(ComboBox cbx)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string query_presence = "SHOW COLUMNS FROM salaires LIKE 'statut'";
                using (MySqlCommand cmd = new MySqlCommand(query_presence, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string enumValues = reader["Type"].ToString();
                            //extraire les valeurs entre les quotes
                            var value = enumValues
                                .Replace("enum(", "").Replace(")", "").Replace("'", "").Split(',');

                            foreach (var val in value)
                            {
                                cbx.Items.Add(val);
                            }
                        }
                    }
                }
            }

        }

        // ========================== charger les mois dans le comboBox =======================
        private void ChargerMois()
        {
            combo_mois.Items.Clear();
            combo_mois.Items.Add("Janvier");
            combo_mois.Items.Add("Fevrier");
            combo_mois.Items.Add("Mars");
            combo_mois.Items.Add("Avril");
            combo_mois.Items.Add("Mai");
            combo_mois.Items.Add("Juin");
            combo_mois.Items.Add("Juillet");
            combo_mois.Items.Add("Aout");
            combo_mois.Items.Add("Septembre");
            combo_mois.Items.Add("Octobre");
            combo_mois.Items.Add("Novembre");
            combo_mois.Items.Add("Décembre");
        }
        // ================================= charger la liste du personnel dans la liseBox
        private void LoadPersonnels()
        {
            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    string query = "SELECT id_personnel,CONCAT(nom,' ',post_nom,' ',prenom) AS Nom FROM personnels ORDER BY id_personnel ASC";
                    using (MySqlCommand cmd = new MySqlCommand(query,con))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Data_employer data = new Data_employer
                            {
                                personnel_id = Convert.ToInt32(reader["id_personnel"]),
                                Name = reader["Nom"].ToString()
                            };
                            list_box_personnel.Items.Add(data);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement de données "+ex.Message);
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
            dgv_salaire.Columns.Add(btnModifier);

            // Supprimer
            DataGridViewButtonColumn btnSupprimer = new DataGridViewButtonColumn();
            btnSupprimer.Name = "Supprimer";
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseColumnTextForButtonValue = true;
            dgv_salaire.Columns.Add(btnSupprimer);

            //desactiver
            ((DataGridViewButtonColumn)dgv_salaire.Columns["Modifier"]).FlatStyle = FlatStyle.Flat;
            ((DataGridViewButtonColumn)dgv_salaire.Columns["Supprimer"]).FlatStyle = FlatStyle.Flat;
            dgv_salaire.Columns["Modifier"].HeaderText = "";
            dgv_salaire.Columns["Supprimer"].HeaderText = "";
            dgv_salaire.Columns["Modifier"].Width = 60;
            dgv_salaire.Columns["Supprimer"].Width = 60;
            dgv_salaire.Columns["Personnel"].Width = 150;
            dgv_salaire.Columns["Fonction"].Width = 100;
            dgv_salaire.DefaultCellStyle.SelectionBackColor = Color.FromArgb(39, 174, 96);
        }

        private void bt_save_salaire_Click(object sender, EventArgs e)
        {
            if (VerifierChamps() == true)
            {
                string periode = combo_mois.SelectedItem.ToString();
                string statut = combo_statut.SelectedItem.ToString();
                decimal salaire = Convert.ToDecimal(tb_salaire_base.Text);
                // ========================== Appel de la méthode  d'enregistrement de salaire =============================================
                foreach (var item in list_box_personnel.CheckedItems)
                {
                    Data_employer dt = (Data_employer)item;
                    MesClasses.RH_manager.EnregistrerSalaire(dt.personnel_id.ToString(), periode, salaire, statut);
                }
                MessageBox.Show("Salaire enregistré avec succès !!");
                MesClasses.RH_manager.LoadSalaryInDgv(dgv_salaire);
                tb_salaire_base.Clear();
                combo_mois.SelectedIndex = -1;
                combo_statut.SelectedIndex = -1;

                for (int i = 0; i < list_box_personnel.Items.Count; i++)
                {
                    list_box_personnel.SetItemChecked(i, false);
                }
            }
            else
            {
                return;
            }
        }

        //  ==================== méthode pour vérifier les champs vides =============
        public static ErrorProvider erreur = new ErrorProvider();
        private bool VerifierChamps()
        {
            if (list_box_personnel.CheckedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner au moins un personnel");
                return false;
            }
            if (combo_mois.SelectedIndex == -1)
            {
                erreur.SetError(combo_mois,"Vous devez choisir un mois");
                return false;
            }
            else
            {
                erreur.SetError(combo_mois, "");
            }

            // tb_salaire_base
            if (tb_salaire_base.Text.Trim() == string.Empty)
            {
                erreur.SetError(tb_salaire_base, "Ce champs est obligatoire");
                tb_salaire_base.Focus();
                return false;
            }
            else
            {
                erreur.SetError(tb_salaire_base, " ");
            }

            // Pour le comboBox statut
            if (combo_statut.SelectedIndex == -1)
            {
                erreur.SetError(combo_statut, "Vous devez sélectionner une élement");
                return false;
            }
            else
            {
                erreur.SetError(combo_statut, " ");
            }

            return true;
        }
    }
    public class Data_employer
    {
        public int personnel_id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
