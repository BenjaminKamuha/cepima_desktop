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
using System.IO;

namespace Cepima.MesUserCases
{
    public partial class User_consultation : UserControl
    {
        int ID_PATIENT;
        public User_consultation(int Patient_Id)
        {
            InitializeComponent();
            ID_PATIENT = Patient_Id;
            LoadDataAdministratives();
        }
      
        //Charger les informations du patient à consulter
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
                    string query = "SELECT p.nom,p.post_nom,CONCAT('PAT-',YEAR(p.date_creation),'-',p.numero_fiche) AS dossier,p.telephone,p.date_naissance,p.sexe,c.date_consultation FROM patients p LEFT JOIN consultation c ON p.id_patient = c.patient_id WHERE p.id_patient = @id ORDER BY c.date_consultation DESC LIMIT 1";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@id", ID_PATIENT.ToString());
                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                    {
                        if (reader.Read())
                        {
                            lb_nom.Text = reader["nom"].ToString();
                            lb_postnom.Text = reader["post_nom"].ToString();
                            lb_dossier.Text = reader["dossier"].ToString();
                            DateTime date = Convert.ToDateTime(reader["date_naissance"]);
                            int annee = CalculerAge(date);
                            lb_age.Text = annee.ToString() + " ans" + " - " + reader["sexe"];
                            lb_adresse.Text = reader["telephone"].ToString();
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

        private void btn_save_category_Click(object sender, EventArgs e)
        {
            Save_Consultation();
        }

        private void Save_Consultation()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                using (MySqlTransaction tr = con.BeginTransaction())
                {
                    try
                    {
                        string query = "INSERT INTO diagnostic ()VALUES()";
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Erreur : " + ex.Message);
                    }
                }
            }
        }
    }
}
