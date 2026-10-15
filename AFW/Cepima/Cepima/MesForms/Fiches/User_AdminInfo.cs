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
            try
            {
                string query = "SELECT CONCAT(nom,' ',post_nom,' ',prenom) AS patient,sexe,date_naissance,telephone,adresse,profession,nom_pere,nom_mere,profession_pere,profession_mere,confession_religieuse,niveau_etude,personne_accompagnante,telephone_accompagnant,adresse_accompagnant,autres_membres_famille,engagement_tuteur,etat_civil FROM patients WHERE id_patient = @id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",ID_PATIENT);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                {
                    while (reader.Read())
                    {
                        lb_nom.Text = reader["patient"].ToString();
                        lb_date.Text = Convert.ToDateTime(reader["date_naissance"]).ToString("dd/MM/yyyy");
                        DateTime dt = Convert.ToDateTime(reader["date_naissance"]);
                        int age = CalculerAge(dt);
                        lb_age.Text = age.ToString() + "ans";
                        lb_sexe.Text = reader["sexe"].ToString();
                        lb_adresse.Text = reader["adresse"].ToString();
                        lb_phone.Text = reader["telephone"].ToString();
                        lb_profession.Text = reader["profession"].ToString();
                        lb_nom_mere.Text = reader["nom_mere"].ToString();
                        lb_nom_pere.Text = reader["nom_pere"].ToString();
                        lb_profession_mere.Text = reader["profession_mere"].ToString();
                        lb_profession_pere.Text = reader["profession_pere"].ToString();
                        lb_confession.Text = reader["confession_religieuse"].ToString();
                        lb_etat_civile.Text = reader["etat_civil"].ToString();
                        lb_niveau_etude.Text = reader["niveau_etude"].ToString();
                        lb_personne_accompagner.Text = reader["personne_accompagnante"].ToString();
                        lb_contact.Text = reader["telephone_accompagnant"].ToString();
                        lb_adresse_personnel.Text = reader["adresse_accompagnant"].ToString();
                        lb_nom_autre.Text = reader["autres_membres_famille"].ToString();
                        lb_engagement.Text = reader["engagement_tuteur"].ToString();
                    }
                    reader.Close();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erreur de chargement de données : "+ex.Message);
            }
        }

        private void bunifuRoundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
