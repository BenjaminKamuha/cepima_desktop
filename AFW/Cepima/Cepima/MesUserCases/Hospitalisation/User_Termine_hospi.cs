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
    public partial class User_Termine_hospi : UserControl
    {
        public User_Termine_hospi()
        {
            InitializeComponent();

            LoadDemandes();

            rb_tous.Checked = true;
        }


        // ============================================================
        // CHARGER LES DEMANDES
        // ============================================================

        private void LoadDemandes(
            string recherche = "",
            string statut = "")
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
                        d.id_demande,
                        p.id_patient,
                        p.nom,
                        p.post_nom,
                        p.prenom,
                        p.sexe,
                        p.date_naissance,
                        d.statut

                    FROM demande_service d

                    INNER JOIN patients p
                        ON d.id_patient = p.id_patient

                    INNER JOIN service s
                        ON s.id_service = d.id_service

                    WHERE s.nom = 'Hospitalisation'";


                // =====================================================
                // PARAMETRES
                // =====================================================

                MesClasses.ManagerClasse.request_params.Clear();


                // =====================================================
                // RECHERCHE DU PATIENT
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
                // FILTRE STATUT
                // =====================================================

                if (!string.IsNullOrWhiteSpace(statut))
                {
                    query += @"
                        AND d.statut = @statut";

                    MesClasses.ManagerClasse.request_params.Add(
                        "@statut",
                        statut);
                }


                // =====================================================
                // TRI
                // =====================================================

                query += @"
                    ORDER BY d.date_demande DESC";


                // =====================================================
                // EXECUTION
                // =====================================================

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    int nombreDemandes = 0;


                    // =================================================
                    // LECTURE
                    // =================================================

                    while (reader.Read())
                    {
                        // =============================================
                        // IDENTIFIANTS
                        // =============================================

                        string idDemande =
                            reader[
                                "id_demande"]
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

                        string statutDemande =
                            reader["statut"].ToString();


                        // =============================================
                        // CREATION DE LA CARTE
                        // =============================================

                        CreerCarteDemande(
                            idDemande,
                            idPatient,
                            nom,
                            postnom,
                            prenom,
                            age,
                            sexe,
                            statutDemande);


                        nombreDemandes++;
                    }


                    // =================================================
                    // RESULTAT
                    // =================================================

                    if (nombreDemandes == 0)
                    {
                        lb_not_found.Text =
                            "Aucune demande trouvée";

                        lb_not_found.Visible =
                            true;

                        lb_nombres.Text =
                            "0 demande";

                        flow_demande.Controls.Add(
                            lb_not_found);
                    }
                    else
                    {
                        lb_not_found.Visible =
                            false;

                        lb_nombres.Text =
                            nombreDemandes +
                            " demande(s)";
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des demandes :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des demandes :\n\n" +
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
        // CREER UNE CARTE DEMANDE
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

            panDemande.Tag =
                id_patient;


            // ========================================================
            // CLICK SUR LA CARTE
            // ========================================================

            panDemande.Click +=
                delegate(object sender, EventArgs e)
                {
                    string patient =
                        panDemande.Tag as string;

                    if (string.IsNullOrEmpty(patient))
                        return;


                    // =================================================
                    // FORMULAIRE D'AFFECTATION
                    // =================================================

                    MesForms.Hospitalisation.Hospitalisation hospi =
                        new MesForms.Hospitalisation.Hospitalisation(
                            patient);

                    hospi.ShowDialog();
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
            // VALEUR DU STATUT
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
            // COULEUR DU STATUT
            // ========================================================

            if (statut == "Demandée")
            {
                lbValeurStatut.ForeColor =
                    Color.FromArgb(
                        255,
                        150,
                        0);
            }
            else if (statut == "Acceptée")
            {
                lbValeurStatut.ForeColor =
                    Color.FromArgb(
                        44,
                        123,
                        229);
            }
            else if (statut == "En cours")
            {
                lbValeurStatut.ForeColor =
                    Color.FromArgb(
                        150,
                        100,
                        220);
            }
            else if (statut == "Terminée")
            {
                lbValeurStatut.ForeColor =
                    Color.FromArgb(
                        0,
                        180,
                        80);
            }
            else if (statut == "Annulée")
            {
                lbValeurStatut.ForeColor =
                    Color.Red;
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
        // FILTRE : TOUS
        // ============================================================

        private void rb_tous_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (!rb_tous.Checked)
                return;

            LoadDemandes(
                textBox_reseach.Text,
                "");
        }


        // ============================================================
        // FILTRE : DEMANDEES
        // ============================================================

        private void rb_demandees_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (!rb_demandees.Checked)
                return;

            LoadDemandes(
                textBox_reseach.Text,
                "Demandée");
        }


        // ============================================================
        // FILTRE : TERMINEES
        // ============================================================

        private void rb_terminees_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (!rb_terminees.Checked)
                return;

            LoadDemandes(
                textBox_reseach.Text,
                "Terminée");
        }


        // ============================================================
        // FILTRE : ANNULEES
        // ============================================================

        private void rb_annulees_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (!rb_annulees.Checked)
                return;

            LoadDemandes(
                textBox_reseach.Text,
                "Annulée");
        }


        // ============================================================
        // RECHERCHE
        // ============================================================

        private void textBox_reseach_TextChanged(
            object sender,
            EventArgs e)
        {
            string statut = "";


            if (rb_demandees.Checked)
            {
                statut =
                    "Demandée";
            }
            else if (rb_terminees.Checked)
            {
                statut =
                    "Terminée";
            }
            else if (rb_annulees.Checked)
            {
                statut =
                    "Annulée";
            }


            LoadDemandes(
                textBox_reseach.Text,
                statut);
        }
    }
}