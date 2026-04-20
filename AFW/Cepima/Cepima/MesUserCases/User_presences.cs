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
    public partial class User_presences : UserControl
    {
        public User_presences()
        {
            InitializeComponent();
            MesClasses.ReceptionManager.MoveLabel(label4,panel1);
            LoadStatutForPresence(combo_statut);
            ChargerPersonnels();
            MesClasses.RH_manager.LoadPresencesForPersonnel(dgv_presence);
            AjouterBoutons();
            dgv_presence.CellFormatting += dgv_presence_CellFormatting;
            dgv_presence.CellContentClick += dgv_presence_CellContentClick;
        }

        void dgv_presence_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgv_presence.Rows[e.RowIndex].Cells["ID"].Value);
                if (dgv_presence.Columns[e.ColumnIndex].Name == "Modifier")
                {
                    MessageBox.Show("Modifier salaire ID "+ id);
                }
                else if (dgv_presence.Columns[e.ColumnIndex].Name == "Supprimer")
                {
                    DialogResult result = MessageBox.Show("Supprimer ce salaire ?", "Confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        //SupprimerSalaire(id);
                        MessageBox.Show(" supprimer une donnée de l'id "+ id);
                        MesClasses.RH_manager.LoadPresencesForPersonnel(dgv_presence);
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        void dgv_presence_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_presence.Columns[e.ColumnIndex].Name == "Modifier")
            {
                e.CellStyle.BackColor = Color.Green;
                e.CellStyle.ForeColor = Color.White;
            }
            else if (dgv_presence.Columns[e.ColumnIndex].Name == "Supprimer")
            {
                e.CellStyle.BackColor = Color.Orange;
                e.CellStyle.ForeColor = Color.White;
            }
        }

        private static void LoadStatutForPresence(ComboBox cbx)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string query_presence = "SHOW COLUMNS FROM presences LIKE 'statut'";
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

        private void ChargerPersonnels()
        {
            try
            {
                string query = "SELECT  id_personnel,CONCAT(nom,' ',post_nom,' ',prenom) AS nomComplet FROM personnels WHERE id_centre = 1";
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,null,true))
                {
                    while (reader.Read())
                    {
                        Personnel p = new Personnel
                        {
                            Id = Convert.ToInt32(reader["id_personnel"]),
                            NomComplet = reader["nomComplet"].ToString()
                        };
                        list_box_personnel.Items.Add(p);
                    }
                    reader.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur lors du chargement des données :"+ex.Message);
            }
        }

        private void bt_save_presence_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    foreach (var item in list_box_personnel.CheckedItems)
                    {
                        Personnel p = (Personnel)item;
                        string query = "INSERT INTO presences (id_personnel,date_presence,heure_entree,heure_sortie,statut)VALUES(@personnel,CURDATE(),@entre,@sortie,@statut)";
                        using (MySqlCommand cmd = new MySqlCommand(query,con))
                        {
                            cmd.Parameters.AddWithValue("@personnel",p.Id);
                            cmd.Parameters.AddWithValue("@entre",dt_heure_arrivee.Value.TimeOfDay);
                            cmd.Parameters.AddWithValue("@sortie",dt_heure_sortie.Value.TimeOfDay);
                            cmd.Parameters.AddWithValue("@statut",combo_statut.SelectedItem);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Présence ajoutée avec succès !!");
                    MesClasses.RH_manager.LoadPresencesForPersonnel(dgv_presence);

                    for (int i = 0; i < list_box_personnel.Items.Count; i++)
                    {
                        list_box_personnel.SetItemChecked(i, false);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement des présences "+ex.Message);
            }
        }
        
        private void AjouterBoutons()
        {
            // Modifier
            DataGridViewButtonColumn btnModifier = new DataGridViewButtonColumn();
            btnModifier.Name = "Modifier";
            btnModifier.Text = "Modifier";
            btnModifier.UseColumnTextForButtonValue = true;
            dgv_presence.Columns.Add(btnModifier);

            // Supprimer
            DataGridViewButtonColumn btnSupprimer = new DataGridViewButtonColumn();
            btnSupprimer.Name = "Supprimer";
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseColumnTextForButtonValue = true;
            dgv_presence.Columns.Add(btnSupprimer);

           //desactiver
            ((DataGridViewButtonColumn)dgv_presence.Columns["Modifier"]).FlatStyle = FlatStyle.Flat;
            ((DataGridViewButtonColumn)dgv_presence.Columns["Supprimer"]).FlatStyle = FlatStyle.Flat;
            dgv_presence.Columns["Modifier"].HeaderText = "";
            dgv_presence.Columns["Supprimer"].HeaderText = "";
            dgv_presence.Columns["Modifier"].Width = 60;
            dgv_presence.Columns["Supprimer"].Width = 60;
        }
    }

    public class Personnel
    {
        public int Id { get; set; }
        public string NomComplet { get; set; }

        public override string ToString()
        {
            return NomComplet;
        }
    }
}
