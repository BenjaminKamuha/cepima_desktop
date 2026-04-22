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
    public partial class User_horaires : UserControl
    {
        public User_horaires()
        {
            InitializeComponent();
            MesClasses.ReceptionManager.MoveLabel(label4,panel1);
            ChargerPersonnels();
            Charger_jours();
            MesClasses.RH_manager.LoadHoraireForPersonnel(dgv_horaire);
            AjouterBoutons();
            dgv_horaire.CellFormatting += dgv_horaire_CellFormatting;
            dgv_horaire.CellContentClick += dgv_horaire_CellContentClick;
        }

        void dgv_horaire_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        void dgv_horaire_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_horaire.Columns[e.ColumnIndex].Name == "Modifier")
            {
                e.CellStyle.BackColor = Color.Green;
                e.CellStyle.ForeColor = Color.White;
            }
            else if (dgv_horaire.Columns[e.ColumnIndex].Name == "Supprimer")
            {
                e.CellStyle.BackColor = Color.Orange;
                e.CellStyle.ForeColor = Color.White;
            }
        }
        private void ChargerPersonnels()
        {
            try
            {
                string query = "SELECT  id_personnel,CONCAT(nom,' ',post_nom,' ',prenom) AS nomComplet FROM personnels WHERE id_centre = 1";
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, null, true))
                {
                    while (reader.Read())
                    {
                        employer e = new employer
                        {
                            id_personnel = Convert.ToInt32(reader["id_personnel"]),
                            nom = reader["nomComplet"].ToString()
                        };
                        list_box_personnel.Items.Add(e);
                    }
                    reader.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur lors du chargement des données :" + ex.Message);
            }
        }

        // ========================= charger les jours de la semaine dans le comboBox ==========
        private void Charger_jours()
        {
            combo_day.Items.Clear();
            combo_day.Items.Add("Lundi");
            combo_day.Items.Add("Mardi");
            combo_day.Items.Add("Mercredi");
            combo_day.Items.Add("Jeudi");
            combo_day.Items.Add("Vendredi");
            combo_day.Items.Add("Samedi");
            combo_day.Items.Add("Dimanche");
        }

        private void bt_save_horaire_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    foreach (var item in list_box_personnel.CheckedItems)
                    {
                        employer em = (employer)item;
                        string query = "INSERT INTO horaire (id_personnel,heure_entree_normal,heure_sortie_normal,jour_travail)VALUES(@personnel,@entre,@sortie,@jour)";
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@personnel", em.id_personnel);
                            cmd.Parameters.AddWithValue("@entre", dt_heure_arrivee.Value.TimeOfDay);
                            cmd.Parameters.AddWithValue("@sortie", dt_heure_sortie.Value.TimeOfDay);
                            cmd.Parameters.AddWithValue("@jour",combo_day.SelectedItem);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Présence ajoutée avec succès !!");
                    MesClasses.RH_manager.LoadHoraireForPersonnel(dgv_horaire);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement des présences " + ex.Message);
            }
        }

        private void AjouterBoutons()
        {
            // Modifier
            DataGridViewButtonColumn btnModifier = new DataGridViewButtonColumn();
            btnModifier.Name = "Modifier";
            btnModifier.Text = "Modifier";
            btnModifier.UseColumnTextForButtonValue = true;
            dgv_horaire.Columns.Add(btnModifier);

            // Supprimer
            DataGridViewButtonColumn btnSupprimer = new DataGridViewButtonColumn();
            btnSupprimer.Name = "Supprimer";
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseColumnTextForButtonValue = true;
            dgv_horaire.Columns.Add(btnSupprimer);

            //desactiver
            ((DataGridViewButtonColumn)dgv_horaire.Columns["Modifier"]).FlatStyle = FlatStyle.Flat;
            ((DataGridViewButtonColumn)dgv_horaire.Columns["Supprimer"]).FlatStyle = FlatStyle.Flat;
            dgv_horaire.Columns["Modifier"].HeaderText = "";
            dgv_horaire.Columns["Supprimer"].HeaderText = "";
            dgv_horaire.Columns["Modifier"].Width = 60;
            dgv_horaire.Columns["Supprimer"].Width = 60;
        }
        
    }
    public class employer
    {
        public int id_personnel { get; set; }
        public string nom { get; set; }

        public override string ToString()
        {
            return nom;
        }
    }
 
}
