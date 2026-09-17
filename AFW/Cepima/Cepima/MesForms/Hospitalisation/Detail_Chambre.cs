using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Cepima.MesForms.Hospitalisation
{
    public partial class Detail_Chambre : Form
    {
        private string id_chambre;
        public Detail_Chambre(string chambre)
        {
            InitializeComponent();
            id_chambre = chambre;
            chargerData();
        }
        private void chargerData()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string query = "SELECT numero_chambre,nombre_lit,tarif_journalier,statut FROM chambre WHERE id_chambre = @id";
                using (MySqlCommand cmd = new MySqlCommand(query,con))
                {
                    cmd.Parameters.AddWithValue("@id",id_chambre);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lb_chambre.Text = "Chambre N° : "+reader["numero_chambre"].ToString();
                        lb_nombre_lit.Text = "Nombre de lits : " + reader["nombre_lit"].ToString();
                        lb_statut.Text = reader["statut"].ToString();
                        lb_tafif.Text = reader["tarif_journalier"].ToString() + "$/jours";
                    }
                }
            }
        }

        private void bt_update_Click(object sender, EventArgs e)
        {
            MesForms.Hospitalisation.update up = new update(id_chambre);
            up.ShowDialog();
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Supprimer cette chambre??", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    string query = "DELETE FROM chambre WHERE id_chambre = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id_chambre);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Chambre supprimée");
                }
            }
        }
        
    }
}
