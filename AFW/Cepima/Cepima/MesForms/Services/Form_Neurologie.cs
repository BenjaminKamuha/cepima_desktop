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
    public partial class Form_Neurologie : Form
    {
        string ID_PATIENT;
        int DEMANDE_ID;
        public Form_Neurologie(string id_patient, int demande_id)
        {
            InitializeComponent();
            this.ID_PATIENT = id_patient;
            this.DEMANDE_ID = demande_id;
        }

        private void Form_Neurologie_Load(object sender, EventArgs e)
        {
            ChargerPatients();
            // comboBox Conscience
            cbx_conscience.Items.Clear();
            cbx_conscience.Items.Add("------------------ Sélectioner une option ------------------");
            cbx_conscience.Items.Add("Lucide");
            cbx_conscience.Items.Add("Obnubilé");
            cbx_conscience.Items.Add("Coma");
            cbx_conscience.SelectedIndex = 0;

            //comboBox orientation
            cbx_orientation.Items.Clear();
            cbx_orientation.Items.Add("------------------ Sélectioner une option ------------------");
            cbx_orientation.Items.Add("Oui");
            cbx_orientation.Items.Add("Non");
            cbx_orientation.SelectedIndex = 0;

            //comboBox langage
            cbx_langage.Items.Clear();
            cbx_langage.Items.Add("------------------ Sélectioner une option ------------------");
            cbx_langage.Items.Add("Cohérent");
            cbx_langage.Items.Add("Non cohérent");
            cbx_conscience.SelectedIndex = 0;

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

        private void btn_save_examen_Click(object sender, EventArgs e)
        {
            EnregistrerExamenNeurologique(Convert.ToInt32(this.ID_PATIENT), Convert.ToInt32(this.DEMANDE_ID));
        }
        private void EnregistrerExamenNeurologique(int idPatient, int? idDemande)
        {
            string requete = "INSERT INTO examen_neurologique(id_demande,id_patient,conscience,orientation_temporo_spatiale,langage,memoire,nerfs_craniens,force_musculaire,tonus,reflexes,sensibilite,coordination,marche)VALUES(@id_demande,@id_patient,@conscience,@orientation,@langage,@memoire,@nerfs_craniens,@force_musculaire,@tonus,@reflexes,@sensibilite,@coordination,@marche)";

            using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
            {
                using (MySqlCommand cmd = new MySqlCommand(requete, connexion))
                {
                    cmd.Parameters.AddWithValue("@id_demande", idDemande.HasValue ? (object)idDemande.Value : DBNull.Value);

                    cmd.Parameters.AddWithValue("@id_patient", idPatient);

                    // Remplacer ces noms par ceux des contrôles réels.
                    cmd.Parameters.AddWithValue(
                        "@conscience", cbx_conscience.Text);

                    cmd.Parameters.AddWithValue(
                        "@orientation", cbx_orientation.Text);

                    cmd.Parameters.AddWithValue(
                        "@langage", cbx_langage.Text);

                    cmd.Parameters.AddWithValue(
                        "@memoire", tb_memoire.Text);

                    cmd.Parameters.AddWithValue(
                        "@nerfs_craniens", tb_nerf.Text);

                    cmd.Parameters.AddWithValue(
                        "@force_musculaire", tb_force.Text);

                    cmd.Parameters.AddWithValue(
                        "@tonus", tb_tonus.Text);

                    cmd.Parameters.AddWithValue(
                        "@reflexes", tb_reflexe.Text);

                    cmd.Parameters.AddWithValue(
                        "@sensibilite", tb_sensibilite.Text);

                    cmd.Parameters.AddWithValue(
                        "@coordination", tb_coordination.Text);

                    cmd.Parameters.AddWithValue(
                        "@marche", tb_marche.Text);

                    try
                    {
                        cmd.ExecuteNonQuery();

                        MessageBox.Show(
                            "Examen neurologique enregistré avec succès.",
                            "Confirmation",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Erreur lors de l'enregistrement : " + ex.Message,
                            "Erreur",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
