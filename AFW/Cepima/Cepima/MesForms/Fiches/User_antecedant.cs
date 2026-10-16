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
    public partial class User_antecedant : UserControl
    {
        private string Patient;
        public User_antecedant(string idPatient)
        {
            InitializeComponent();
            Patient = idPatient;
            ChargerAntecedents();
        }

        public void ChargerAntecedents()
        {
            lblAntecedentsMedicaux.Text = "Non renseigné";
            lblAntecedentsPsychiatriques.Text = "Non renseigné";
            lblAntecedentsHereditaires.Text = "Non renseigné";
            lblHabitudesToxiques.Text = "Non renseigné";
            lblFamiliaux.Text = "Non renseigné";
            lblCollateraux.Text = "Non renseigné";
            lblAllergies.Text = "Non renseigné";
            lblAllergies.Text = "Non renseigné";

            string sql = @"
                        SELECT *
                        FROM antecedents
                        WHERE id_patient = @id_patient
                        ORDER BY date_enregistrement DESC, id_antecedent DESC
                        LIMIT 1";

            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id_patient", Patient);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                                return;

                            List<string> liste = new List<string>();

                            // Antécédents médicaux
                            if (Convert.ToInt32(reader["medical_hta"]) == 1)
                                liste.Add("HTA");
                            if (Convert.ToInt32(reader["medical_diabete"]) == 1)
                                liste.Add("Diabète");
                            if (Convert.ToInt32(reader["medical_epilepsie"]) == 1)
                                liste.Add("Épilepsie");
                            if (Convert.ToInt32(reader["medical_traumatisme_cranien"]) == 1)
                                liste.Add("Traumatisme crânien");
                            if (Convert.ToInt32(reader["medical_avc"]) == 1)
                                liste.Add("AVC");
                            if (Convert.ToInt32(reader["medical_vih"]) == 1)
                                liste.Add("VIH");
                            if (Convert.ToInt32(reader["medical_tuberculose"]) == 1)
                                liste.Add("Tuberculose");

                            if (reader["medical_autre"] != DBNull.Value &&
                                reader["medical_autre"].ToString().Trim() != "")
                                liste.Add("Autres : " + reader["medical_autre"]);

                            lblAntecedentsMedicaux.Text = liste.Count > 0
                                ? string.Join(", ", liste)
                                : "Aucun antécédent sélectionné";

                            // Antécédents psychiatriques
                            liste.Clear();

                            if (Convert.ToInt32(reader["psy_depression"]) == 1)
                                liste.Add("Dépression");
                            if (Convert.ToInt32(reader["psy_tentative_suicide"]) == 1)
                                liste.Add("Tentative de suicide");
                            if (Convert.ToInt32(reader["psy_hospitalisation"]) == 1)
                                liste.Add("Hospitalisation psychiatrique");
                            if (Convert.ToInt32(reader["psy_trouble_bipolaire"]) == 1)
                                liste.Add("Trouble bipolaire");
                            if (Convert.ToInt32(reader["psy_schizophrenie"]) == 1)
                                liste.Add("Schizophrénie");

                            if (reader["psy_autre"] != DBNull.Value &&
                                reader["psy_autre"].ToString().Trim() != "")
                                liste.Add("Autres : " + reader["psy_autre"]);

                            lblAntecedentsPsychiatriques.Text = liste.Count > 0
                                ? string.Join(", ", liste)
                                : "Aucun antécédent sélectionné";

                            // Antécédents héréditaires
                            liste.Clear();

                            if (Convert.ToInt32(reader["hereditaire_hta"]) == 1)
                                liste.Add("HTA");
                            if (Convert.ToInt32(reader["hereditaire_diabete"]) == 1)
                                liste.Add("Diabète");
                            if (Convert.ToInt32(reader["hereditaire_epilepsie"]) == 1)
                                liste.Add("Épilepsie");
                            if (Convert.ToInt32(reader["hereditaire_avc"]) == 1)
                                liste.Add("AVC");
                            if (Convert.ToInt32(reader["hereditaire_tuberculose"]) == 1)
                                liste.Add("Tuberculose");
                            if (Convert.ToInt32(reader["hereditaire_vih"]) == 1)
                                liste.Add("VIH");

                            if (reader["hereditaire_autre"] != DBNull.Value &&
                                reader["hereditaire_autre"].ToString().Trim() != "")
                                liste.Add("Autres : " + reader["hereditaire_autre"]);

                            lblAntecedentsHereditaires.Text = liste.Count > 0
                                ? string.Join(", ", liste)
                                : "Aucun antécédent sélectionné";

                            // Habitudes toxiques
                            liste.Clear();

                            if (Convert.ToInt32(reader["toxique_alcool"]) == 1)
                                liste.Add("Alcool");
                            if (Convert.ToInt32(reader["toxique_tabac"]) == 1)
                                liste.Add("Tabac");
                            if (Convert.ToInt32(reader["toxique_cannabis"]) == 1)
                                liste.Add("Cannabis");
                            if (Convert.ToInt32(reader["toxique_drogues"]) == 1)
                                liste.Add("Drogues");

                            if (reader["toxique_autres"] != DBNull.Value &&
                                reader["toxique_autres"].ToString().Trim() != "")
                                liste.Add("Autres : " + reader["toxique_autres"]);

                            lblHabitudesToxiques.Text = liste.Count > 0
                                ? string.Join(", ", liste)
                                : "Aucune habitude sélectionnée";

                            // Autres catégories en texte libre
                            if (reader["familiaux"] != DBNull.Value &&
                                reader["familiaux"].ToString().Trim() != "")
                                lblFamiliaux.Text = reader["familiaux"].ToString();

                            if (reader["collateraux"] != DBNull.Value &&
                                reader["collateraux"].ToString().Trim() != "")
                                lblCollateraux.Text = reader["collateraux"].ToString();

                            if (reader["chirurgicaux"] != DBNull.Value &&
                                reader["chirurgicaux"].ToString().Trim() != "")
                                lblAllergies.Text = reader["chirurgicaux"].ToString();

                            if (reader["allergies"] != DBNull.Value &&
                                reader["allergies"].ToString().Trim() != "")
                                lblAllergies.Text = reader["allergies"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur lors du chargement des antécédents :\n" + ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
