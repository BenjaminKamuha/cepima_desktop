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
                string query = "INSERT INTO chambre(id_centre,numero_chambre,type_chambre,tarif_journalier)VALUES(@centre,@numero,@type,@tarif)";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@centre",MesForms.SessionUtilisateur.idCentre);
                    cmd.Parameters.AddWithValue("@numero",numeric_chambre.Value);
                    cmd.Parameters.AddWithValue("@type",cbx_type_chambre.SelectedItem);
                    cmd.Parameters.AddWithValue("@tarif",tb_tarif.Text);
                    cmd.ExecuteNonQuery();
                    cbx_type_chambre.SelectedIndex = -1;
                    tb_tarif.Text = "";
                    numeric_chambre.Value = 0;
                }
            }
        }
    }
}
