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
    public partial class Add_chambre : Form
    {
        public Add_chambre()
        {
            InitializeComponent();
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string query = "INSERT INTO chambre(id_centre,numero_chambre,nombre_lit,tarif_journalier)VALUES(@centre,@chambre,@lit,@tarif)";
                    using (MySqlCommand cmd = new MySqlCommand(query,con))
                    {
                        cmd.Parameters.AddWithValue("@centre",SessionUtilisateur.idCentre);
                        cmd.Parameters.AddWithValue("@chambre",tb_numero_chambre.Text);
                        cmd.Parameters.AddWithValue("@lit",numeric_lit.Value);
                        cmd.Parameters.AddWithValue("@tarif",tb_tarif.Text);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Chambre ajoutée avec succès !!");
                    tb_tarif.Text = "";
                    tb_tarif.Text = "";
                    numeric_lit.Value = 0;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erreur : "+ex.Message);
                }
            }
        }
    }
}
