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
    public partial class Form_Fiche_suivie : Form
    {
        string PatientID;
        public Form_Fiche_suivie(string id_patient)
        {
            InitializeComponent();
            PatientID = id_patient;
        }

        private void Form_Fiche_suivie_Load(object sender, EventArgs e)
        {
            LoadDataAdministratives();
        }

        // fonction de calcul de l'age
        private int CalculerAge(DateTime dateNaissence)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - dateNaissence.Year;

            if (dateNaissence.Date > now.AddYears(-age))
            {
                age--;
            }
            return age;

        }
        //méthode pour charger les informations administratives du patient
        private void LoadDataAdministratives()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : "+ex.Message);
                }
            }
        }
    }
}
