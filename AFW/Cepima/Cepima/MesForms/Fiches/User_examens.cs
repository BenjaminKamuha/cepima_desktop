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
    public partial class User_examens : UserControl
    {
        private string patientID;
        public User_examens(string id)
        {
            InitializeComponent();
            patientID = id;
            ChargerExamenNeurologique();
            ChargerExamenPsychiatrique();
            ChargerSignesVitaux();
           
        }
        public void ChargerSignesVitaux()
        {
            lblTemperature.Text = "Non renseigné";
            lblTension.Text = "Non renseigné";
            lblFrequenceCardiaque.Text = "Non renseigné";
            lblPoids.Text = "Non renseigné";
            lblEtat.Text = "Non renseigné";

            string sql = @"
                    SELECT temperature, tension, frequence_cardiaque,
                           poids, taille, etat, date_prise
                    FROM signes_vitaux
                    WHERE id_patient = @id_patient
                    ORDER BY date_prise DESC, id_signe DESC
                    LIMIT 1";

            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id_patient",this.patientID);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblTemperature.Text =
                                    reader["temperature"] == DBNull.Value
                                    ? "Non renseigné"
                                    : reader["temperature"].ToString() + " °C";

                                lblTension.Text =
                                    reader["tension"] == DBNull.Value
                                    ? "Non renseigné"
                                    : reader["tension"].ToString() + " mmHg";

                                lblFrequenceCardiaque.Text =
                                    reader["frequence_cardiaque"] == DBNull.Value
                                    ? "Non renseigné"
                                    : reader["frequence_cardiaque"].ToString();

                                lblPoids.Text =
                                    reader["poids"] == DBNull.Value
                                    ? "Non renseigné"
                                    : reader["poids"].ToString() + " kg";

                                lblEtat.Text =
                                    reader["etat"] == DBNull.Value
                                    ? "Non renseigné"
                                    : reader["etat"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur lors du chargement des signes vitaux :\n"
                        + ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        public void ChargerExamenNeurologique()
        {
            lblConscience.Text = "Non renseigné";
            lblOrientation.Text = "Non renseigné";
            lblLangage.Text = "Non renseigné";
            lblMemoire.Text = "Non renseigné";
            lblNerfsCraniens.Text = "Non renseigné";
            lblForceMusculaire.Text = "Non renseigné";
            lblTonus.Text = "Non renseigné";
            lblReflexes.Text = "Non renseigné";
            lblSensibilite.Text = "Non renseigné";
            lblCoordination.Text = "Non renseigné";
            lblMarche.Text = "Non renseigné";

            string sql = @"
                    SELECT *
                    FROM examen_neurologique
                    WHERE id_patient = @id_patient
                    ORDER BY date_enregistrement DESC,
                             id_examen_neurologique DESC
                    LIMIT 1";

            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                   
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id_patient", this.patientID);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblConscience.Text = reader["conscience"] == DBNull.Value
                                    ? "Non renseigné" : reader["conscience"].ToString();

                                lblOrientation.Text = reader["orientation_temporo_spatiale"] == DBNull.Value
                                    ? "Non renseigné" : reader["orientation_temporo_spatiale"].ToString();

                                lblLangage.Text = reader["langage"] == DBNull.Value
                                    ? "Non renseigné" : reader["langage"].ToString();

                                lblMemoire.Text = reader["memoire"] == DBNull.Value
                                    ? "Non renseigné" : reader["memoire"].ToString();

                                lblNerfsCraniens.Text = reader["nerfs_craniens"] == DBNull.Value
                                    ? "Non renseigné" : reader["nerfs_craniens"].ToString();

                                lblForceMusculaire.Text = reader["force_musculaire"] == DBNull.Value
                                    ? "Non renseigné" : reader["force_musculaire"].ToString();

                                lblTonus.Text = reader["tonus"] == DBNull.Value
                                    ? "Non renseigné" : reader["tonus"].ToString();

                                lblReflexes.Text = reader["reflexes"] == DBNull.Value
                                    ? "Non renseigné" : reader["reflexes"].ToString();

                                lblSensibilite.Text = reader["sensibilite"] == DBNull.Value
                                    ? "Non renseigné" : reader["sensibilite"].ToString();

                                lblCoordination.Text = reader["coordination"] == DBNull.Value
                                    ? "Non renseigné" : reader["coordination"].ToString();

                                lblMarche.Text = reader["marche"] == DBNull.Value
                                    ? "Non renseigné" : reader["marche"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur lors du chargement de l'examen neurologique :\n"
                        + ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        public void ChargerExamenPsychiatrique()
        {
            lblApparenceGenerale.Text = "Non renseigné";
            lblContact.Text = "Non renseigné";
            lblHumeur.Text = "Non renseigné";
            lblDiscours.Text = "Non renseigné";
            lblPensee.Text = "Non renseigné";
            lblHallucination.Text = "Non renseigné";
            lblIdeesSuicidaires.Text = "Non renseigné";
            lblJugement.Text = "Non renseigné";

            string sql = @"
                        SELECT *
                        FROM examen_psychiatrique
                        WHERE id_patient = @id_patient
                        ORDER BY date_enregistrement DESC,
                                 id_examen_psychiatrique DESC
                        LIMIT 1";

            using (MySqlConnection con =
                MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id_patient", this.patientID);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblApparenceGenerale.Text =
                                    reader["apparence_generale"] == DBNull.Value
                                    ? "Non renseigné"
                                    : reader["apparence_generale"].ToString();

                                lblContact.Text =
                                    reader["contact"] == DBNull.Value
                                    ? "Non renseigné"
                                    : reader["contact"].ToString();

                                lblHumeur.Text =
                                    reader["humeur"] == DBNull.Value
                                    ? "Non renseigné"
                                    : reader["humeur"].ToString();

                                lblDiscours.Text =
                                    reader["discours"] == DBNull.Value
                                    ? "Non renseigné"
                                    : reader["discours"].ToString();

                                lblPensee.Text =
                                    reader["pensee"] == DBNull.Value
                                    ? "Non renseigné"
                                    : reader["pensee"].ToString();

                                lblHallucination.Text =
                                    reader["hallucination"] == DBNull.Value
                                    ? "Non renseigné"
                                    : reader["hallucination"].ToString();

                                lblIdeesSuicidaires.Text =
                                    reader["idees_suicidaires"] == DBNull.Value
                                    ? "Non renseigné"
                                    : reader["idees_suicidaires"].ToString();

                                lblJugement.Text =
                                    reader["jugement"] == DBNull.Value
                                    ? "Non renseigné"
                                    : reader["jugement"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur lors du chargement de l'examen psychiatrique :\n"
                        + ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
