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
namespace Cepima.MesUserCases.EEG
{
    public partial class User_DashBoard : UserControl
    {
        public User_DashBoard()
        {
            InitializeComponent();
            ChargerCount();
        }

        //charger les resumés dans le panels en haut
        private void ChargerCount()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) AS nombre FROM examens_eeg WHERE statut = 'Terminé' AND date_examen = CURDATE()",con))
                    {
                        int nombre = Convert.ToInt32(cmd.ExecuteScalar());
                        lb_realise.Text = nombre.ToString();
                    }

                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) AS nombre FROM examens_eeg WHERE statut = 'En cours' AND date_examen = CURDATE()",con))
                    {
                        int nombre = Convert.ToInt32(cmd.ExecuteScalar());
                        lb_attente.Text = nombre.ToString();
                    }

                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) AS nombre FROM examens_eeg WHERE date_examen = CURDATE()", con))
                    {
                        int nombre = Convert.ToInt32(cmd.ExecuteScalar());
                        lb_eeg_now.Text = nombre.ToString();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erreur : "+ex.Message);
                }
            }
        }
    }
}
