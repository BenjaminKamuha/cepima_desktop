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
    public partial class update : Form
    {
        private string id_chambre;
        public update(string chambre)
        {
            InitializeComponent();
            id_chambre = chambre;
        }

        private void update_Load(object sender, EventArgs e)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string query = "SELECT numero_chambre,nombre_lit,tarif_journalier FROM chambre WHERE id_chambre = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id",id_chambre);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tb_mod_chambre.Text = reader["numero_chambre"].ToString();
                            tb_mod_tarif.Text = reader["tarif_journalier"].ToString();

                            if (reader["nombre_lit"] != DBNull.Value)
                            {
                                numeric_mod.Value = Convert.ToInt32(reader["nombre_lit"]);
                            }
                            else
                            {
                                numeric_mod.Value = 0;
                            }
                        }
                        reader.Close();
                        
                    }
                }
            }
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string query = "UPDATE chambre SET numero_chambre =@chambre,nombre_lit =@lit,tarif_journalier = @tarif WHERE id_chambre = @id";
                using (MySqlCommand cmd = new MySqlCommand(query,con))
                {
                    cmd.Parameters.AddWithValue("@chambre",tb_mod_chambre.Text);
                    cmd.Parameters.AddWithValue("@lit",numeric_mod.Value);
                    cmd.Parameters.AddWithValue("@tarif",tb_mod_tarif.Text);
                    cmd.Parameters.AddWithValue("@id",id_chambre);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Chambre modifié avec succès !!");
                this.Close();
            }
        }

    }
}
