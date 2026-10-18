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
namespace Cepima.MesForms.Services
{
    public partial class Form_Psychiatrique : Form
    {
        string ID_PATIENT;
        int DEMANDE_ID;
        public Form_Psychiatrique(string id_patient, int demande_id)
        {
            InitializeComponent();
            this.ID_PATIENT = id_patient;
            this.DEMANDE_ID = demande_id;
        }

        private void Form_Psychiatrique_Load(object sender, EventArgs e)
        {
            ChargerPatients();
            // comboBox Apparence générale
            cmbApparenceGenerale.Items.Clear();
            cmbApparenceGenerale.Items.Add("------------------ Sélectionner une option ------------------");
            cmbApparenceGenerale.Items.Add("Bon");
            cmbApparenceGenerale.Items.Add("Mauvais");
            cmbApparenceGenerale.SelectedIndex = 0;

            // comboBox Contact
            cmbContact.Items.Clear();
            cmbContact.Items.Add("------------------ Sélectionner une option ------------------");
            cmbContact.Items.Add("Facile");
            cmbContact.Items.Add("Difficile");
            cmbContact.SelectedIndex = 0;

            // comboBox Humeur
            cmbHumeur.Items.Clear();
            cmbHumeur.Items.Add("------------------ Sélectionner une option ------------------");
            cmbHumeur.Items.Add("Normale");
            cmbHumeur.Items.Add("Dépressive");
            cmbHumeur.Items.Add("Euphorique");
            cmbHumeur.SelectedIndex = 0;

            // comboBox Idées suicidaires
            cmbIdeesSuicidaires.Items.Clear();
            cmbIdeesSuicidaires.Items.Add("------------------ Sélectionner une option ------------------");
            cmbIdeesSuicidaires.Items.Add("Oui");
            cmbIdeesSuicidaires.Items.Add("Non");
            cmbIdeesSuicidaires.SelectedIndex = 0;
        }
        private void ChargerPatients()
        {
            try
            {

                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    con.Open();

                    string query = @"
                        SELECT
                            id_patient,
                            date_naissance,
                            numero_fiche,
                            sexe,
                            CONCAT(
                                nom,
                                ' ',
                                post_nom,
                                CASE
                                    WHEN prenom IS NOT NULL
                                         AND prenom <> ''
                                    THEN CONCAT(' ', prenom)
                                    ELSE ''
                                END
                            ) AS patient
                        FROM patients
                        WHERE id_patient = @id_patient
                        LIMIT 1";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_patient",
                            ID_PATIENT);

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nomPatient =
                                    reader["patient"] == DBNull.Value
                                        ? ""
                                        : reader["patient"].ToString();

                                string sexe =
                                    reader["sexe"] == DBNull.Value
                                        ? ""
                                        : reader["sexe"].ToString();

                                string numeroFiche =
                                    reader["numero_fiche"] == DBNull.Value
                                        ? ""
                                        : reader["numero_fiche"].ToString();

                                int age = 0;

                                if (reader["date_naissance"] !=
                                    DBNull.Value)
                                {
                                    DateTime naissance =
                                        Convert.ToDateTime(
                                            reader["date_naissance"]);

                                    age =
                                        DateTime.Now.Year -
                                        naissance.Year;

                                    if (DateTime.Now.Date <
                                        naissance.AddYears(age).Date)
                                    {
                                        age--;
                                    }
                                }

                                lb_nom_patient.Text =
                                    nomPatient;

                                lb_sexe_age.Text =
                                    sexe + " - " +
                                    age.ToString() +
                                    " ans";

                                lb_num_fiche.Text =
                                    numeroFiche;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du patient :\n\n" +
                    ex.Message,
                    "SERVICE",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void EnregistrerExamenPsychiatrique(int idPatient, int idDemande)
        {
            string requete = @"INSERT INTO examen_psychiatrique
 (id_demande,id_patient,apparence_generale,contact,humeur,discours,pensee,hallucination,idees_suicidaires,jugement)VALUES(@id_demande,@id_patient,@apparence_generale,@contact,@humeur,@discours,@pensee,@hallucination,@idees_suicidaires,@jugement)";

            using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
            {
                using (MySqlCommand cmd = new MySqlCommand(requete, connexion))
                {
                    cmd.Parameters.AddWithValue("@id_demande", idDemande);
                    cmd.Parameters.AddWithValue("@id_patient", idPatient);

                    cmd.Parameters.AddWithValue("@apparence_generale", cmbApparenceGenerale.Text);

                    cmd.Parameters.AddWithValue("@contact", cmbContact.Text);

                    cmd.Parameters.AddWithValue("@humeur", cmbHumeur.Text);

                    cmd.Parameters.AddWithValue("@discours", txtDiscours.Text);

                    cmd.Parameters.AddWithValue("@pensee", txtPensee.Text);

                    cmd.Parameters.AddWithValue("@hallucination", txtHallucination.Text);

                    cmd.Parameters.AddWithValue("@idees_suicidaires", cmbIdeesSuicidaires.Text);

                    cmd.Parameters.AddWithValue("@jugement", txtJugement.Text);

                    try
                    {
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Examen psychiatrique enregistré avec succès.","Confirmation",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de l'enregistrement : " + ex.Message,"Erreur",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_save_examen_Click(object sender, EventArgs e)
        {
            EnregistrerExamenPsychiatrique(Convert.ToInt32(this.ID_PATIENT),Convert.ToInt32(this.DEMANDE_ID));
        }

    }
}
