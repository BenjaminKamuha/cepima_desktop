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

namespace Cepima.MesForms
{
    public partial class Form_add_category_med : Form
    {
        public Form_add_category_med()
        {
            InitializeComponent();
        }

        private void btn_save_category_Click(object sender, EventArgs e)
        {

            try
            {

                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    string query = "INSERT INTO medicament_categorie (nom, couleur) VALUES (@nom, @couleur);";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("nom", tb_cat_name.Text);
                        cmd.Parameters.AddWithValue("couleur", tb_cat_color.HexColor);

                        cmd.ExecuteNonQuery();
                        Form_add_medoc.ChargerCategories();
                        this.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur enregistrement catégorie" + ex.Message);
            }
            
        }
    }
}
