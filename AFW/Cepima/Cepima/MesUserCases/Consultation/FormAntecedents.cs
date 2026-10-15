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
namespace Cepima.MesUserCases.Consultation
{
    public partial class FormAntecedents : Form
    {
        int idPatient;
        int idConsultation;
        public FormAntecedents(int patientId,int consultation)
        {
            InitializeComponent();
            this.idPatient = patientId;
            this.idConsultation = consultation;
        }

        private void btn_save__Click(object sender, EventArgs e)
        {
           
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                MySqlTransaction transaction = null;

                try
                {

                    transaction = con.BeginTransaction();

                    string sql = @"
                INSERT INTO antecedents
                (
                    id_patient,
                    id_consultation,

                    medical_hta,
                    medical_diabete,
                    medical_epilepsie,
                    medical_traumatisme_cranien,
                    medical_avc,
                    medical_vih,
                    medical_tuberculose,
                    medical_autre,

                    psy_depression,
                    psy_tentative_suicide,
                    psy_hospitalisation,
                    psy_trouble_bipolaire,
                    psy_schizophrenie,
                    psy_autre,

                    hereditaire_hta,
                    hereditaire_diabete,
                    hereditaire_epilepsie,
                    hereditaire_avc,
                    hereditaire_tuberculose,
                    hereditaire_vih,
                    hereditaire_autre,

                    familiaux,
                    collateraux,
                    chirurgicaux,
                    allergies,

                    toxique_alcool,
                    toxique_tabac,
                    toxique_cannabis,
                    toxique_drogues,
                    toxique_autres
                )
                VALUES
                (
                    @id_patient,
                    @id_consultation,

                    @medical_hta,
                    @medical_diabete,
                    @medical_epilepsie,
                    @medical_traumatisme_cranien,
                    @medical_avc,
                    @medical_vih,
                    @medical_tuberculose,
                    @medical_autre,

                    @psy_depression,
                    @psy_tentative_suicide,
                    @psy_hospitalisation,
                    @psy_trouble_bipolaire,
                    @psy_schizophrenie,
                    @psy_autre,

                    @hereditaire_hta,
                    @hereditaire_diabete,
                    @hereditaire_epilepsie,
                    @hereditaire_avc,
                    @hereditaire_tuberculose,
                    @hereditaire_vih,
                    @hereditaire_autre,

                    @familiaux,
                    @collateraux,
                    @chirurgicaux,
                    @allergies,

                    @toxique_alcool,
                    @toxique_tabac,
                    @toxique_cannabis,
                    @toxique_drogues,
                    @toxique_autres
                )";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, con, transaction))
                    {
                        // Identifiants
                        cmd.Parameters.AddWithValue(
                            "@id_patient", idPatient);

                        // Si les antécédents ne sont pas liés
                        // à une consultation précise
                        cmd.Parameters.AddWithValue(
                            "@id_consultation", DBNull.Value);

                        // A. Antécédents médicaux
                        cmd.Parameters.AddWithValue(
                            "@medical_hta", chkMedicalHTA.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@medical_diabete",
                            chkMedicalDiabete.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@medical_epilepsie",
                            chkMedicalEpilepsie.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@medical_traumatisme_cranien",
                            chkMedicalTraumatismeCranien.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@medical_avc", chkMedicalAVC.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@medical_vih", chkMedicalVIH.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@medical_tuberculose",
                            chkMedicalTuberculose.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@medical_autre",
                            rich_medicaux_autres.Text);

                        // B. Antécédents psychiatriques
                        cmd.Parameters.AddWithValue(
                            "@psy_depression",
                            chkPsyDepression.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@psy_tentative_suicide",
                            chkPsyTentativeSuicide.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@psy_hospitalisation",
                            chkPsyHospitalisation.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@psy_trouble_bipolaire",
                            chkPsyTroubleBipolaire.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@psy_schizophrenie",
                            chkPsySchizophrenie.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@psy_autre",
                            rich_pys_autres.Text);

                        // C. Antécédents héréditaires
                        cmd.Parameters.AddWithValue(
                            "@hereditaire_hta",
                            chkHereditaireHTA.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@hereditaire_diabete",
                            chkHereditaireDiabete.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@hereditaire_epilepsie",
                            chkHereditaireEpilepsie.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@hereditaire_avc",
                            chkHereditaireAVC.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@hereditaire_tuberculose",
                            chkHereditaireTuberculose.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@hereditaire_vih",
                            chkHereditaireVIH.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@hereditaire_autre",rich_here_autres.Text);

                        // D. Autres catégories
                        cmd.Parameters.AddWithValue(
                            "@familiaux", txtFamiliaux.Text);

                        cmd.Parameters.AddWithValue(
                            "@collateraux", txtCollateraux.Text);

                        cmd.Parameters.AddWithValue(
                            "@chirurgicaux", txtChirurgicaux.Text);

                        cmd.Parameters.AddWithValue(
                            "@allergies", txtAllergies.Text);

                        // E. Habitudes toxiques
                        cmd.Parameters.AddWithValue(
                            "@toxique_alcool",
                            chkToxiqueAlcool.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@toxique_tabac",
                            chkToxiqueTabac.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@toxique_cannabis",
                            chkToxiqueCannabis.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@toxique_drogues",
                            chkToxiqueDrogues.Checked ? 1 : 0);

                        cmd.Parameters.AddWithValue(
                            "@toxique_autres",rich_habitude_autres.Text);

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    MessageBox.Show(
                        "Les antécédents ont été enregistrés avec succès.",
                        "Enregistrement réussi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.Close();
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch
                        {
                        }
                    }

                    MessageBox.Show(
                        "Erreur lors de l'enregistrement :\n"
                        + ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
