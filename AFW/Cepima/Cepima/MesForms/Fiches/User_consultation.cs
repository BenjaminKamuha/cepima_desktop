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
namespace Cepima.MesForms.Fiches
{
    public partial class User_consultation : UserControl
    {
        string  PatientID;
        public User_consultation(string Patient)
        {
            InitializeComponent();
            PatientID = Patient;
            ChargerData();
        }

        private void bunifuRoundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChargerData()
        {
            try
            {
                string query = "SELECT motif,historique_maladie FROM consultation   WHERE patient_id = @id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",PatientID);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                {
                    if (reader.Read())
                    {
                        lblMotif.Text = reader["motif"].ToString();
                        lblHistoire.Text = reader["historique_maladie"].ToString();
                    }
                    else
                    {
                        lblHistoire.Text = "Aucune historique de sa maladie ,veillez demander encore plus aux familliers"; lblMotif.Text = "Pas de motid de consultation,revenez plutard";
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erreur : "+ex.Message);
            }
        }
    }
}
