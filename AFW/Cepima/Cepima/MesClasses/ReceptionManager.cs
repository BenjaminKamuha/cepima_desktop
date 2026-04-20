using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace Cepima.MesClasses
{
    class ReceptionManager
    {
        // Enregistrement du patient
        public static void ServiceCepima(string centre_id, string name_centre, string description)
        {
            using (MySqlConnection con = ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();
                try
                {
                    string queryService = "INSERT INTO services(id_centre,nom_centre,description)VALUES(@id,@name,@desc)";
                    ManagerClasse.request_params.Clear();
                    ManagerClasse.request_params.Add("@id", centre_id);
                    ManagerClasse.request_params.Add("@name", name_centre);
                    ManagerClasse.request_params.Add("@desc", description);
                    ManagerClasse.CRUD(queryService, ManagerClasse.request_params);
                    tr.Commit();
                    MessageBox.Show("Service ajouté avec succès !!");
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Erreur d'ajout du service " + ex.Message);
                }
            }
        }

        //===============================Enregistrement du patient ===============================
        public  static void SavePatient(string numeroFiche, string nom, string postnom, string prenom, string genre, DateTime dateNaissance, string phoneNumber, string adresse,string idCentre)
        {
            using (MySqlConnection con = ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();
                try
                {
                    string queryInsertPatient = "INSERT INTO patients(numero_fiche,nom,post_nom,prenom,sexe,date_naissance,telephone,adresse,date_creation,id_centre)VALUES(@numero,@nom,@post,@prenom,@sexe,@naissance,@phone,@adresse,CURDATE(),@centre)";
                    ManagerClasse.request_params.Clear();
                    ManagerClasse.request_params.Add("@numero", numeroFiche);
                    ManagerClasse.request_params.Add("@nom", nom);
                    ManagerClasse.request_params.Add("@post", postnom);
                    ManagerClasse.request_params.Add("@prenom", prenom);
                    ManagerClasse.request_params.Add("@sexe", genre);
                    ManagerClasse.request_params.Add("@naissance", dateNaissance.ToString("yyyy-MM-dd"));
                    ManagerClasse.request_params.Add("@phone", phoneNumber);
                    ManagerClasse.request_params.Add("@adresse", adresse);
                    ManagerClasse.request_params.Add("@centre",idCentre);
                    ManagerClasse.CRUD(queryInsertPatient, ManagerClasse.request_params);
                    tr.Commit();
                    MessageBox.Show("Patient enregistré avec succès !!", "Enregistrement du patient");
                }
                catch (MySqlException ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Erreur d'ajout du patient :" + ex.Message);
                }
            }
        }

        // ==============================Enregistrer la consultation =====================================
        public static void EnregistrerConsultation(string patient_id, string centre_id, string personnel_id, string motif, string diagnostic)
        {
            using (MySqlConnection con = ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();
                try
                {
                    string queryConsultation = "INSERT INTO consultation(id_patient,id_centre,id_personnel,date_consultation,motid,diagnostic)VALUES(@patient,@centre,@personnel,CURDATE(),@motif,@diagnostic)";
                    ManagerClasse.request_params.Clear();
                    ManagerClasse.request_params.Add("@patient",patient_id);
                    ManagerClasse.request_params.Add("@centre",centre_id);
                    ManagerClasse.request_params.Add("@personnel",personnel_id);
                    ManagerClasse.request_params.Add("@motif",motif);
                    ManagerClasse.request_params.Add("@diagnostic",diagnostic);
                    ManagerClasse.CRUD(queryConsultation,ManagerClasse.request_params);
                    tr.Commit();
                    MessageBox.Show("Consultation ajoutée avec succès !!","Consultation");
                }
                catch (MySqlException ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Erreur d'ajout de la consultation : " + ex.Message);
                }
            }
        }

        //================================ Save signes vitaux =======================================================
        public static void SaveSigneVitaux(string patient_id,decimal temperature,string tension,int frequence,decimal poids,decimal taille)
        {
            using (MySqlConnection con = ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();
                try
                {
                    string query = "INSERT INTO signes_vitaux(id_patient,temperature,tension,frequence,poids,taille,date_prise)VALUES(@patient,@temp,@tension,@frequency,@poids,@taille,CURDATE())";
                    ManagerClasse.request_params.Clear();
                    ManagerClasse.request_params.Add("@patient", patient_id);
                    ManagerClasse.request_params.Add("@temp", temperature.ToString());
                    ManagerClasse.request_params.Add("@tension", tension);
                    ManagerClasse.request_params.Add("@frequency", frequence.ToString());
                    ManagerClasse.request_params.Add("@poids", poids.ToString());
                    ManagerClasse.request_params.Add("@taille", taille.ToString());
                    tr.Commit();
                    MessageBox.Show("Les signes vitaux ont été ajoutés","Enregistrement");
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Erreur d'ajout des signes vitaux : "+ex.Message);
                }
               
            }
        }

        // ======================================= move the label =================================
        public static void MoveLabel(Label lbMove, Panel panelMove,int vitesse = 2)
        {
            Timer existingTimer = lbMove.Tag as Timer;
            if (existingTimer != null)
            {
                existingTimer.Stop();
            }

            Timer timer = new Timer();
            timer.Interval = 30;

            timer.Tick += (s, e) =>
            {
                lbMove.Left -= vitesse;

                if (lbMove.Right < 0)
                {
                    lbMove.Left = panelMove.Width;
                }
            };
            lbMove.Tag = timer;
            timer.Start();
        }

    }
}
