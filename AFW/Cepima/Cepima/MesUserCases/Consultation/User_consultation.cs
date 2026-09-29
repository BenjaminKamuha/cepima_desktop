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
        int ID_DEMANDE;
        int id_diagnostic;
        string Type_consultation = "";

        public User_consultation(int Patient_Id, int Demande_Id)
        {
            InitializeComponent();

            ID_PATIENT = Patient_Id;
            ID_DEMANDE = Demande_Id;

            LoadDataAdministratives();
        }

        // ============================================================
        // Charger les informations administratives du patient
        // ============================================================

        private void LoadDataAdministratives()
        {
            using (MySqlConnection con =
                MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    // =================================================
                    // OPTIMISATION :
                    // La consultation n'est pas utilisée dans
                    // l'affichage des informations administratives.
                    // Le LEFT JOIN + ORDER BY + LIMIT a donc été retiré.
                    // =================================================

                    string query = @"
                        SELECT
                            p.nom,
                            p.post_nom,
                            CONCAT(
                                'PAT-',
                                YEAR(p.date_creation),
                                '-',
                                p.numero_fiche
                            ) AS dossier,
                            p.telephone,
                            p.date_naissance,
                            p.sexe
                        FROM patients p
                        WHERE p.id_patient = @id
                        LIMIT 1";

                    MesClasses.ManagerClasse.request_params.Clear();

                    MesClasses.ManagerClasse.request_params.Add(
                        "@id",
                        ID_PATIENT.ToString());

                    using (MySqlDataReader reader =
                        MesClasses.ManagerClasse.CRUD(
                            query,
                            MesClasses.ManagerClasse.request_params,
                            true))
                    {
                        if (reader.Read())
                        {
                            lb_nom.Text =
                                reader["nom"].ToString();

                            lb_postnom.Text =
                                reader["post_nom"].ToString();

                            lb_dossier.Text =
                                reader["dossier"].ToString();

                            if (reader["date_naissance"] !=
                                DBNull.Value)
                            {
                                DateTime date =
                                    Convert.ToDateTime(
                                        reader["date_naissance"]);

                                int annee =
                                    MesClasses.ReceptionManager
                                        .CalculerAge(date);

                                lb_age.Text =
                                    annee.ToString()
                                    + " ans"
                                    + " - "
                                    + reader["sexe"].ToString();
                            }
                            else
                            {
                                lb_age.Text =
                                    "-";
                            }

                            lb_adresse.Text =
                                reader["telephone"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur : " + ex.Message);
                }
            }
        }

        // ============================================================
        // ENREGISTRER
        // ============================================================

        private void btn_save_category_Click(
            object sender,
            EventArgs e)
        {
            Save_Consultation();
        }

        // ============================================================
        // RECUPERER LE RADIOBUTTON SELECTIONNE
        // ============================================================

        private string GetRadioSelection(
            Panel panel_test)
        {
            foreach (Control control in
                panel_test.Controls)
            {
                RadioButton rb =
                    control as RadioButton;

                if (rb != null &&
                    rb.Checked)
                {
                    return rb.Text;
                }
            }

            return null;
        }

        // ============================================================
        // ENREGISTRER LA CONSULTATION
        // ============================================================

        private void Save_Consultation()
        {
            using (MySqlConnection con =
                MesClasses.ManagerClasse.GetConnexion())
            {
                string risqueSuicidaire =
                    GetRadioSelection(
                        panelSuicidaire);

                string risqueAgression =
                    GetRadioSelection(
                        panelAgression);

                string risqueFugue =
                    GetRadioSelection(
                        panelFugue);

                using (MySqlTransaction tr =
                    con.BeginTransaction())
                {
                    try
                    {
                        // =================================================
                        // 1. CREATION DU DIAGNOSTIC
                        // =================================================

                        using (MySqlCommand cmd =
                            new MySqlCommand(
                                @"
                                INSERT INTO diagnostic
                                (
                                    libelle,
                                    description
                                )
                                VALUES
                                (
                                    @lib,
                                    @desc
                                )",
                                con,
                                tr))
                        {
                            cmd.Parameters.Add(
                                "@lib",
                                MySqlDbType.VarChar).Value =
                                tb_diagnostic_principal.Text;

                            cmd.Parameters.Add(
                                "@desc",
                                MySqlDbType.Text).Value =
                                tb_motif.Text;

                            cmd.ExecuteNonQuery();

                            id_diagnostic =
                                Convert.ToInt32(
                                    cmd.LastInsertedId);
                        }

                        // =================================================
                        // 2. CREATION DE LA CONSULTATION
                        // =================================================

                        string queryConsultation = @"
                            INSERT INTO consultation
                            (
                                patient_id,
                                id_demande,
                                type_consultation,
                                motif,
                                symptomes_depuis,
                                symptome_insomnie,
                                symptome_anxiete,
                                symptome_agitation,
                                symptome_tristesse,
                                symptome_idees_delirantes,
                                symptome_hallucinations,
                                symptome_perte_memoire,
                                symptome_autre,
                                evolution_symptomes,
                                facteurs_declenchants,
                                risque_suicidaire,
                                risque_agression,
                                risque_fugue,
                                autres_risques,
                                diagnostic_id,
                                prochaine_consultation,
                                date_consultation,
                                utilisateur_id
                            )
                            VALUES
                            (
                                @patient,
                                @id_demande,
                                @type,
                                @motif,
                                @depuis,
                                @insomnie,
                                @anxiete,
                                @agitation,
                                @tristesse,
                                @delire,
                                @hallucination,
                                @perte,
                                @autre,
                                @evolution,
                                @declencheurs,
                                @suicidaire,
                                @agression,
                                @fugue,
                                @autres_risque,
                                @id_diagnostic,
                                @prochaine,
                                NOW(),
                                @user
                            )";

                        using (MySqlCommand cmd =
                            new MySqlCommand(
                                queryConsultation,
                                con,
                                tr))
                        {
                            // =============================================
                            // PATIENT
                            // =============================================

                            cmd.Parameters.Add(
                                "@patient",
                                MySqlDbType.Int32).Value =
                                ID_PATIENT;

                            // =============================================
                            // DEMANDE
                            // =============================================

                            cmd.Parameters.Add(
                                "@id_demande",
                                MySqlDbType.Int32).Value =
                                ID_DEMANDE;

                            // =============================================
                            // TYPE
                            // =============================================

                            cmd.Parameters.Add(
                                "@type",
                                MySqlDbType.VarChar).Value =
                                Type_consultation;

                            // =============================================
                            // MOTIF
                            // =============================================

                            cmd.Parameters.Add(
                                "@motif",
                                MySqlDbType.Text).Value =
                                tb_motif.Text;

                            // =============================================
                            // SYMPTOMES DEPUIS
                            // =============================================

                            cmd.Parameters.Add(
                                "@depuis",
                                MySqlDbType.Date).Value =
                                dt_depuis.Value.Date;

                            // =============================================
                            // SYMPTOMES
                            // =============================================

                            cmd.Parameters.Add(
                                "@insomnie",
                                MySqlDbType.Bit).Value =
                                insomnie.Checked;

                            cmd.Parameters.Add(
                                "@anxiete",
                                MySqlDbType.Bit).Value =
                                anxiete.Checked;

                            cmd.Parameters.Add(
                                "@agitation",
                                MySqlDbType.Bit).Value =
                                agitation.Checked;

                            cmd.Parameters.Add(
                                "@tristesse",
                                MySqlDbType.Bit).Value =
                                tristesse.Checked;

                            cmd.Parameters.Add(
                                "@delire",
                                MySqlDbType.Bit).Value =
                                delirante.Checked;

                            cmd.Parameters.Add(
                                "@hallucination",
                                MySqlDbType.Bit).Value =
                                hallucination.Checked;

                            cmd.Parameters.Add(
                                "@perte",
                                MySqlDbType.Bit).Value =
                                perte_memoire.Checked;

                            cmd.Parameters.Add(
                                "@autre",
                                MySqlDbType.Text).Value =
                                tb_autre.Text;

                            // =============================================
                            // EVOLUTION
                            // =============================================

                            cmd.Parameters.Add(
                                "@evolution",
                                MySqlDbType.Text).Value =
                                rich_evolution.Text;

                            // =============================================
                            // FACTEURS DECLENCHANTS
                            // =============================================

                            cmd.Parameters.Add(
                                "@declencheurs",
                                MySqlDbType.Text).Value =
                                rich_facteurs.Text;

                            // =============================================
                            // RISQUES
                            // =============================================

                            cmd.Parameters.Add(
                                "@suicidaire",
                                MySqlDbType.VarChar).Value =
                                (object)risqueSuicidaire ??
                                DBNull.Value;

                            cmd.Parameters.Add(
                                "@agression",
                                MySqlDbType.VarChar).Value =
                                (object)risqueAgression ??
                                DBNull.Value;

                            cmd.Parameters.Add(
                                "@fugue",
                                MySqlDbType.VarChar).Value =
                                (object)risqueFugue ??
                                DBNull.Value;

                            cmd.Parameters.Add(
                                "@autres_risque",
                                MySqlDbType.Text).Value =
                                tb_autre_evaluation.Text;

                            // =============================================
                            // DIAGNOSTIC
                            // =============================================

                            cmd.Parameters.Add(
                                "@id_diagnostic",
                                MySqlDbType.Int32).Value =
                                id_diagnostic;

                            // =============================================
                            // PROCHAINE CONSULTATION
                            // =============================================

                            cmd.Parameters.Add(
                                "@prochaine",
                                MySqlDbType.Date).Value =
                                dt_after_.Value.Date;

                            // =============================================
                            // UTILISATEUR
                            // =============================================

                            cmd.Parameters.Add(
                                "@user",
                                MySqlDbType.Int32).Value =
                                MesClasses.SessionUtilisateur.idUser;

                            // =============================================
                            // EXECUTION
                            // =============================================

                            cmd.ExecuteNonQuery();


                            // =============================================

                            long idConsultation =
                                cmd.LastInsertedId;
                        }

                        // =================================================
                        // 3. METTRE A JOUR LA DEMANDE
                        // =================================================

                        string queryDemande = @"
                            UPDATE demande_service
                            SET statut = 'Terminée'
                            WHERE id_demande = @id_demande
                              AND id_patient = @id_patient";

                        using (MySqlCommand cmd =
                            new MySqlCommand(
                                queryDemande,
                                con,
                                tr))
                        {
                            cmd.Parameters.Add(
                                "@id_demande",
                                MySqlDbType.Int32).Value =
                                ID_DEMANDE;

                            cmd.Parameters.Add(
                                "@id_patient",
                                MySqlDbType.Int32).Value =
                                ID_PATIENT;

                            int lignes =
                                cmd.ExecuteNonQuery();

                            if (lignes == 0)
                            {
                                throw new Exception(
                                    "La demande de service n'existe pas " +
                                    "ou ne correspond pas au patient.");
                            }
                        }

                        // =================================================
                        // 4. VALIDATION
                        // =================================================

                        tr.Commit();

                        MessageBox.Show(
                            "Consultation créée avec succès !",
                            "Enregistrement",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            tr.Rollback();
                        }
                        catch
                        {
                        }

                        MessageBox.Show(
                            "Erreur lors de l'enregistrement " +
                            "de la consultation :\n\n"
                            + ex.Message,
                            "Erreur",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ============================================================
        // TYPE DE CONSULTATION
        // ============================================================

        private void rb_consultation_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (rb_consultation.Checked)
            {
                Type_consultation =
                    "Première consultation";
            }
        }

        private void rb_suivi_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (rb_suivi.Checked)
            {
                Type_consultation =
                    "Consultation de suivie";
            }
        }

        private void rb_control_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (rb_control.Checked)
            {
                Type_consultation =
                    "Consultation de contrôle";
            }
        }

        private void rb_urgence_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (rb_urgence.Checked)
            {
                Type_consultation =
                    "Consultation d'urgence";
            }
        }
    }
}