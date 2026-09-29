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

namespace Cepima.MesUserCases
{
    public partial class User_display_patients : UserControl
    {
        public static Panel GlobalPanel_detail { get; set; }

        // Timer pour éviter une requête MySQL à chaque frappe
        private Timer searchTimer;

        public User_display_patients()
        {
            InitializeComponent();

            ConfigurerRecherche();
        }


        // ============================================================
        // CONFIGURATION RECHERCHE
        // ============================================================

        private void ConfigurerRecherche()
        {
            searchTimer = new Timer();

            // Attendre 300 ms après la dernière frappe
            searchTimer.Interval = 300;

            searchTimer.Tick += SearchTimer_Tick;
        }


        private void SearchTimer_Tick(
            object sender,
            EventArgs e)
        {
            searchTimer.Stop();

            LoadPatient(
                tb_search_demande.Text.Trim()
            );
        }


        // ============================================================
        // CHARGER LES PATIENTS
        // ============================================================

        private void LoadPatient(params string[] args)
        {
            // --------------------------------------------------------
            // Nettoyage de l'affichage précédent
            // --------------------------------------------------------

            panel_patient.SuspendLayout();

            try
            {
                panel_patient.Controls.Clear();

                // ----------------------------------------------------
                // Configuration du FlowLayoutPanel
                // ----------------------------------------------------

                panel_patient.FlowDirection =
                    FlowDirection.LeftToRight;

                panel_patient.WrapContents = true;

                panel_patient.AutoScroll = true;

                panel_patient.Padding =
                    new Padding(10, 10, 8, 10);

                lb_not_found.Visible = false;


                // ----------------------------------------------------
                // Recherche
                // ----------------------------------------------------

                string recherche = "";

                if (args != null &&
                    args.Length > 0 &&
                    !string.IsNullOrWhiteSpace(args[0]))
                {
                    recherche = args[0].Trim();
                }


                // ----------------------------------------------------
                // REQUETE
                // ----------------------------------------------------

                string query;

                bool isSearch =
                    !string.IsNullOrWhiteSpace(recherche);


                if (isSearch)
                {
                    query = @"
                        SELECT
                            id_patient,
                            nom,
                            post_nom,
                            numero_fiche

                        FROM patients

                        WHERE
                            nom LIKE @search
                            OR post_nom LIKE @search

                        ORDER BY nom ASC

                        LIMIT 100";
                }
                else
                {
                    query = @"
                        SELECT
                            id_patient,
                            nom,
                            post_nom,
                            numero_fiche

                        FROM patients

                        ORDER BY nom ASC

                        LIMIT 100";
                }


                // ----------------------------------------------------
                // PARAMETRES
                // ----------------------------------------------------

                MesClasses.ManagerClasse.request_params.Clear();

                if (isSearch)
                {
                    MesClasses.ManagerClasse.request_params.Add(
                        "@search",
                        "%" + recherche + "%"
                    );
                }


                // ----------------------------------------------------
                // EXECUTION
                // ----------------------------------------------------

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        isSearch
                            ? MesClasses.ManagerClasse.request_params
                            : null,
                        true))
                {
                    int nombrePatients = 0;


                    while (reader.Read())
                    {
                        string idPatient =
                            reader["id_patient"].ToString();

                        string nom =
                            reader["nom"].ToString();

                        string postnom =
                            reader["post_nom"].ToString();

                        string numero =
                            reader["numero_fiche"].ToString();


                        // --------------------------------------------
                        // CREATION CARTE
                        // --------------------------------------------

                        CustomRoundedPanel panPatient =
                            CreerPanelPatient(
                                idPatient,
                                nom,
                                postnom,
                                numero
                            );


                        panel_patient.Controls.Add(
                            panPatient
                        );


                        nombrePatients++;
                    }


                    // ------------------------------------------------
                    // RESULTAT
                    // ------------------------------------------------

                    if (nombrePatients > 0)
                    {
                        if (isSearch)
                        {
                            lb_nombres.Text =
                                nombrePatients +
                                " Patient(s) trouvé(s)";
                        }
                        else
                        {
                            lb_nombres.Text =
                                nombrePatients +
                                " Patient(s)";
                        }


                        // ------------------------------------------------
                        // AFFICHAGE PROGRESSIF
                        // ------------------------------------------------

                        ProgressiveDisplay pd =
                            new ProgressiveDisplay(
                                panel_patient,
                                100
                            );

                        pd.Start();
                    }
                    else
                    {
                        if (isSearch)
                        {
                            lb_not_found.Text =
                                "Aucun nom ne correspond " +
                                "au terme de recherche '" +
                                recherche +
                                "'";
                        }
                        else
                        {
                            lb_not_found.Text =
                                "Aucun patient dans le registre";
                        }


                        panel_patient.Controls.Add(
                            lb_not_found
                        );

                        lb_not_found.Visible = true;

                        lb_nombres.Text =
                            "0 Patient";
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des patients :\n\n" +
                    ex.Message,
                    "Erreur MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des patients :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                panel_patient.ResumeLayout();
            }
        }


        // ============================================================
        // CREER CARTE PATIENT
        // ============================================================

        private CustomRoundedPanel CreerPanelPatient(
            string idPatient,
            string nom,
            string postnom,
            string numero)
        {
            // --------------------------------------------------------
            // PANEL PRINCIPAL
            // --------------------------------------------------------

            CustomRoundedPanel panPatient =
                new CustomRoundedPanel();

            panPatient.Size =
                new Size(160, 130);

            panPatient.BorderRadius = 8;

            panPatient.BorderColor =
                Color.Silver;

            panPatient.BorderSize = 1;

            panPatient.Tag =
                idPatient;

            panPatient.Margin =
                new Padding(10);

            panPatient.Padding =
                new Padding(
                    10,
                    10,
                    8,
                    10
                );


            // --------------------------------------------------------
            // PHOTO
            // --------------------------------------------------------

            PictureBox picture =
                MesClasses.ManagerClasse.AddPicture(
                    Properties.Resources.user,
                    new Point(2, 5),
                    new Size(70, 70)
                );

            panPatient.Controls.Add(
                picture
            );


            // --------------------------------------------------------
            // NOM
            // --------------------------------------------------------

            Label lbNom =
                MesClasses.ManagerClasse.CustomLabel(
                    nom,
                    new Point(70, 20)
                );

            lbNom.AutoSize = true;

            lbNom.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold
                );

            panPatient.Controls.Add(
                lbNom
            );


            // --------------------------------------------------------
            // POST-NOM
            // --------------------------------------------------------

            Label lbPost =
                MesClasses.ManagerClasse.CustomLabel(
                    postnom,
                    new Point(70, 40)
                );

            lbPost.AutoSize = true;

            lbPost.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold
                );

            panPatient.Controls.Add(
                lbPost
            );


            // --------------------------------------------------------
            // NUMERO FICHE
            // --------------------------------------------------------

            Label lbFiche =
                MesClasses.ManagerClasse.CustomLabel(
                    numero,
                    new Point(10, 75)
                );

            lbFiche.AutoSize = true;

            lbFiche.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold
                );

            panPatient.Controls.Add(
                lbFiche
            );


            // --------------------------------------------------------
            // BOUTON FICHE DE SUIVI
            // --------------------------------------------------------

            RoundedButton btnSuivi =
                MesClasses.ManagerClasse.Rbutton(
                    "Affectation",
                    new Point(30, 100),
                    new Size(95, 25),
                    Color.FromArgb(44, 123, 229),
                    Color.White
                );

            btnSuivi.BorderRadius = 4;

            btnSuivi.BorderSize = 0;

            btnSuivi.BorderColor =
                Color.FromArgb(
                    44,
                    123,
                    229
                );

            btnSuivi.HoverBackColor =
                Color.FromArgb(
                    7,
                    51,
                    131
                );


            panPatient.Controls.Add(
                btnSuivi
            );


            // --------------------------------------------------------
            // EVENEMENT
            // --------------------------------------------------------

            btnSuivi.Click +=
                delegate
                {
                    Form1.GlobalPanel_main.Visible =
                        false;

                    try
                    {

                        MesForms.Form_demander_service service =
                            new MesForms.Form_demander_service(
                                idPatient,
                                0);

                        service.ShowDialog();
                    }
                    finally
                    {
                        Form1.GlobalPanel_main.Visible =
                            true;
                    }
                };


            return panPatient;
        }


        // ============================================================
        // RECHERCHE
        // ============================================================

        private void tb_search_demande_TextChanged(
            object sender,
            EventArgs e)
        {
            // --------------------------------------------------------
            // Annuler le timer précédent
            // --------------------------------------------------------

            searchTimer.Stop();


            // --------------------------------------------------------
            // Attendre que l'utilisateur arrête de taper
            // --------------------------------------------------------

            searchTimer.Start();
        }


        // ============================================================
        // CHARGEMENT DU USERCONTROL
        // ============================================================

        private void User_display_patients_Load(
            object sender,
            EventArgs e)
        {
            LoadPatient();
        }


        // ============================================================
        // NETTOYAGE
        // ============================================================

        private void NettoyerTimer()
        {
            if (searchTimer != null)
            {
                searchTimer.Stop();
                searchTimer.Dispose();
                searchTimer = null;
            }
        }
    }
}