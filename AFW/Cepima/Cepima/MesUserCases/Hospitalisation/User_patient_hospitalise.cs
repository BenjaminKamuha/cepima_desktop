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

namespace Cepima.MesUserCases.Hospitalisation
{
    public partial class User_patient_hospitalise : UserControl
    {
        public User_patient_hospitalise()
        {
            InitializeComponent();

            LoadPatientsHospitalises();
        }


        // ============================================================
        // CHARGER LES PATIENTS HOSPITALISES
        // ============================================================

        private void LoadPatientsHospitalises(
            string recherche = "")
        {
            try
            {
                // =====================================================
                // SUSPENDRE LE LAYOUT
                // =====================================================

                flow_demande.SuspendLayout();

                flow_demande.Controls.Clear();

                lb_not_found.Visible = false;


                // =====================================================
                // REQUETE
                // =====================================================

                string query = @"
                    SELECT
                        h.id_hospitalisation,
                        p.id_patient,
                        p.nom,
                        p.post_nom,
                        p.prenom,
                        p.sexe,
                        p.date_naissance,
                        h.etat

                    FROM hospitalisation h

                    INNER JOIN patients p
                        ON h.id_patient = p.id_patient

                    WHERE h.etat = 'Hospitalisé'";


                // =====================================================
                // PARAMETRES
                // =====================================================

                MesClasses.ManagerClasse.request_params.Clear();


                // =====================================================
                // RECHERCHE PATIENT
                // =====================================================

                if (!string.IsNullOrWhiteSpace(recherche))
                {
                    query += @"
                        AND
                        (
                            p.nom LIKE @search
                            OR p.post_nom LIKE @search
                            OR p.prenom LIKE @search
                        )";

                    MesClasses.ManagerClasse.request_params.Add(
                        "@search",
                        "%" + recherche.Trim() + "%");
                }


                // =====================================================
                // TRI
                // =====================================================

                query += @"
                    ORDER BY h.date_entree DESC";


                // =====================================================
                // EXECUTION
                // =====================================================

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    int nombrePatients = 0;


                    // =================================================
                    // LECTURE
                    // =================================================

                    while (reader.Read())
                    {
                        // =============================================
                        // IDENTIFIANTS
                        // =============================================

                        string idHospitalisation =
                            reader[
                                "id_hospitalisation"]
                            .ToString();

                        string idPatient =
                            reader[
                                "id_patient"]
                            .ToString();


                        // =============================================
                        // IDENTITE
                        // =============================================

                        string nom =
                            reader["nom"].ToString();

                        string postnom =
                            reader["post_nom"].ToString();

                        string prenom =
                            reader["prenom"].ToString();

                        string sexe =
                            reader["sexe"].ToString();


                        // =============================================
                        // AGE
                        // =============================================

                        int age = 0;

                        if (reader["date_naissance"] !=
                            DBNull.Value)
                        {
                            DateTime dateNaissance =
                                Convert.ToDateTime(
                                    reader[
                                        "date_naissance"]);

                            age =
                                MesClasses.ReceptionManager
                                .CalculerAge(
                                    dateNaissance);
                        }


                        // =============================================
                        // STATUT
                        // =============================================

                        string statut =
                            reader["etat"].ToString();


                        // =============================================
                        // CREER LA CARTE
                        // =============================================

                        CreerCarteDemande(
                            idHospitalisation,
                            idPatient,
                            nom,
                            postnom,
                            prenom,
                            age,
                            sexe,
                            statut);


                        nombrePatients++;
                    }


                    // =================================================
                    // RESULTAT
                    // =================================================

                    if (nombrePatients == 0)
                    {
                        lb_not_found.Text =
                            "Aucun patient trouvé";

                        lb_not_found.Visible =
                            true;

                        lb_nombres.Text =
                            "0 Patient(s)";

                        flow_demande.Controls.Add(
                            lb_not_found);
                    }
                    else
                    {
                        lb_not_found.Visible =
                            false;

                        lb_nombres.Text =
                            nombrePatients +
                            " Patient(s)";
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des patients :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des patients :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                // =====================================================
                // REACTIVER LE LAYOUT
                // =====================================================

                flow_demande.ResumeLayout(true);
            }
        }


        // ============================================================
        // CREER UNE CARTE PATIENT
        // ============================================================

        private void CreerCarteDemande(
            string idDemande,
            string id_patient,
            string nom,
            string postnom,
            string prenom,
            int age,
            string sexe,
            string statut)
        {
            // ========================================================
            // PANEL
            // ========================================================

            BunifuRoundedPanel panDemande =
                new BunifuRoundedPanel();

            panDemande.Size =
                new Size(
                    290,
                    130);

            panDemande.Margin =
                new Padding(
                    8,
                    10,
                    12,
                    10);

            panDemande.BorderRadius =
                8;

            panDemande.BorderColor =
                Color.Silver;

            panDemande.BorderSize =
                1;

            panDemande.ShadowColor =
                Color.Gray;

            panDemande.ShadowDepth =
                10;


            // ========================================================
            // INFORMATIONS STOCKEES
            // ========================================================

            panDemande.Tag =
                new DemandeInfo
                {
                    IdDemande =
                        idDemande,

                    IdPatient =
                        id_patient
                };


            // ========================================================
            // CLICK
            // ========================================================

            panDemande.Click +=
                delegate(object sender, EventArgs e)
                {
                    DemandeInfo info =
                        panDemande.Tag
                        as DemandeInfo;

                    if (info == null)
                        return;


                    string patient =
                        info.IdPatient;

                    string hospi =
                        info.IdDemande;


                    // -----------------------------------------------
                    // DETAIL HOSPITALISATION
                    // -----------------------------------------------

                    MesForms.Hospitalisation
                        .Detail_hospitalisation detail =
                        new MesForms.Hospitalisation
                        .Detail_hospitalisation(
                            patient,
                            hospi);

                    detail.ShowDialog();
                };


            // ========================================================
            // IMAGE
            // ========================================================

            PictureBox picture =
                MesClasses.ManagerClasse.AddPicture(
                    Properties.Resources.user,
                    new Point(
                        15,
                        15),
                    new Size(
                        60,
                        60));

            picture.Cursor =
                Cursors.Hand;

            panDemande.Controls.Add(
                picture);


            // ========================================================
            // NOM + POST-NOM
            // ========================================================

            Label lbNom =
                MesClasses.ManagerClasse.CustomLabel(
                    (
                        nom.ToUpper() +
                        " " +
                        postnom.ToUpper()
                    ).Trim(),
                    new Point(
                        90,
                        15));

            lbNom.AutoSize =
                true;

            lbNom.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold);

            lbNom.Cursor =
                Cursors.Hand;

            panDemande.Controls.Add(
                lbNom);


            // ========================================================
            // PRENOM
            // ========================================================

            Label lbPrenom =
                MesClasses.ManagerClasse.CustomLabel(
                    prenom,
                    new Point(
                        90,
                        37));

            lbPrenom.AutoSize =
                true;

            lbPrenom.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold);

            lbPrenom.Cursor =
                Cursors.Hand;

            panDemande.Controls.Add(
                lbPrenom);


            // ========================================================
            // AGE + SEXE
            // ========================================================

            Label lbInfos =
                MesClasses.ManagerClasse.CustomLabel(
                    age + " ans - " + sexe,
                    new Point(
                        90,
                        62));

            lbInfos.AutoSize =
                true;

            lbInfos.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold);

            lbInfos.Cursor =
                Cursors.Hand;

            panDemande.Controls.Add(
                lbInfos);


            // ========================================================
            // STATUT
            // ========================================================

            Label lbStatut =
                MesClasses.ManagerClasse.CustomLabel(
                    "Statut :",
                    new Point(
                        15,
                        95));

            lbStatut.AutoSize =
                true;

            lbStatut.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold);

            panDemande.Controls.Add(
                lbStatut);


            // ========================================================
            // VALEUR STATUT
            // ========================================================

            Label lbValeurStatut =
                MesClasses.ManagerClasse.CustomLabel(
                    statut,
                    new Point(
                        75,
                        95));

            lbValeurStatut.AutoSize =
                true;

            lbValeurStatut.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold);


            // ========================================================
            // COULEUR STATUT
            // ========================================================

            if (statut == "Hospitalisé")
            {
                lbValeurStatut.ForeColor =
                    Color.FromArgb(
                        255,
                        150,
                        0);
            }
            else if (statut == "Sorti")
            {
                lbValeurStatut.ForeColor =
                    Color.FromArgb(
                        0,
                        180,
                        80);
            }
            else
            {
                lbValeurStatut.ForeColor =
                    Color.Gray;
            }

            lbValeurStatut.Cursor =
                Cursors.Hand;

            panDemande.Controls.Add(
                lbValeurStatut);


            // ========================================================
            // AJOUT AU FLOWLAYOUTPANEL
            // ========================================================

            flow_demande.Controls.Add(
                panDemande);
        }


        // ============================================================
        // RECHERCHE
        // ============================================================

        private void textBox_reseach_TextChanged(
            object sender,
            EventArgs e)
        {
            LoadPatientsHospitalises(
                textBox_reseach.Text);
        }
    }


    // ================================================================
    // INFORMATIONS DE LA CARTE
    // ================================================================

    public class DemandeInfo
    {
        public string IdDemande
        {
            get;
            set;
        }

        public string IdPatient
        {
            get;
            set;
        }
    }
}