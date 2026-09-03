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
    public partial class User_AdminInfo : UserControl
    {
        string ID_PATIENT;
        public User_AdminInfo(string id_patient)
        {
            InitializeComponent();
            ID_PATIENT = id_patient;
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
                    string query = "SELECT CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS Patient,CONCAT('PAT-',YEAR(p.date_creation),'-',p.numero_fiche) AS dossier,p.nom_garde,p.telephone_garde,p.date_naissance,p.sexe,c.date_consultation,d.libelle AS diagnostic FROM patients p LEFT JOIN consultation c ON p.id_patient = c.patient_id LEFT JOIN diagnostic d ON c.diagnostic_id = d.id WHERE p.id_patient = @id ORDER BY c.date_consultation DESC LIMIT 1";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@id",ID_PATIENT);
                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                    {
                        if (reader.Read())
                        {
                            lb_nom.Text = reader["Patient"].ToString();
                            lb_dossier.Text = reader["dossier"].ToString();
                            DateTime date = Convert.ToDateTime(reader["date_naissance"]);
                            int annee = CalculerAge(date);
                            lb_age.Text = annee.ToString() + " ans" + " - " + reader["sexe"];
                            lb_adresse.Text = reader["telephone_garde"].ToString();
                            lb_date.Text = date.ToString();
                            lb_diagnostic.Text = reader["diagnostic"].ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }
    }
}
