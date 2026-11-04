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

namespace Cepima.MesForms
{
    public partial class FormAfficherPatient : Form
    {
        public static Panel GlobalPanel_detail { get; set; }

        // Timer pour éviter une requête MySQL à chaque frappe
        private Timer searchTimer;
        string context;

        public FormAfficherPatient()
        {
            InitializeComponent();

            ConfigurerRecherche();
            LoadPatient();
        }

        private void ConfigurerRecherche()
        {
            searchTimer = new Timer();

            // Attendre 300 ms après la dernière frappe
            searchTimer.Interval = 300;

            searchTimer.Tick += SearchTimer_Tick;
        }


        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();

            LoadPatient(
                tb_search_demande.Text.Trim()
            );
        }

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

                        BunifuRoundedPanel panPatient =
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


        private BunifuRoundedPanel CreerPanelPatient(string idPatient, string nom, string postnom, string numero)
        {
            // --------------------------------------------------------
            // PANEL PRINCIPAL
            // --------------------------------------------------------


            BunifuRoundedPanel panPatient = new BunifuRoundedPanel();

            panPatient.Size = new Size(300, 155);

            panPatient.BorderRadius = 8;
            panPatient.BorderSize = 0;
            panPatient.ShadowDepth = 10;
            panPatient.BorderColor = Color.Silver;
            panPatient.BorderSize = 1;
            panPatient.Tag = idPatient;

            panPatient.Margin = new Padding(10);

            panPatient.Padding = new Padding(10);

            // --------------------------------------------------------
            // PHOTO
            // --------------------------------------------------------

            PictureBox picture =
                MesClasses.ManagerClasse.AddPicture(
                    Properties.Resources.user,
                    new Point(10, 10),
                    new Size(65, 65)
                );

            panPatient.Controls.Add(picture);

            // --------------------------------------------------------
            // NOM
            // --------------------------------------------------------

            Label lbNom =
MesClasses.ManagerClasse.CustomLabel(
                    nom,
                    new Point(80, 10)
                );

            lbNom.AutoSize = true;

            lbNom.Font = new Font(
                "Calibri",
                10,
                FontStyle.Bold
            );

            panPatient.Controls.Add(lbNom);

            // --------------------------------------------------------
            // POST-NOM
            // --------------------------------------------------------

            Label lbPost =
                MesClasses.ManagerClasse.CustomLabel(
                    postnom,
                    new Point(80, 32)
                );

            lbPost.AutoSize = true;

            lbPost.Font = new Font(
                "Calibri",
                10,
                FontStyle.Bold
            );

            panPatient.Controls.Add(lbPost);

            // --------------------------------------------------------
            // NUMERO DU PATIENT
            // --------------------------------------------------------

            Label lbFiche =
                MesClasses.ManagerClasse.CustomLabel(
                    numero,
                    new Point(80, 54)
                );

            lbFiche.AutoSize = true;

            lbFiche.Font = new Font(
                "Calibri",
                9,
                FontStyle.Regular
            );

            panPatient.Controls.Add(lbFiche);

            // --------------------------------------------------------
            // BOUTON AFFECTATION
            // --------------------------------------------------------


            RoundedButton bt_select =
                MesClasses.ManagerClasse.Rbutton(
                    "Séléctionner",
                    new Point(20, 105),
                    new Size(110, 30),
                    Color.FromArgb(44, 123, 229),
                    Color.White
                );

            bt_select.BorderRadius = 4;
            bt_select.BorderSize = 0;

            bt_select.BorderColor =
                Color.FromArgb(44, 123, 229);

            bt_select.HoverBackColor =
                Color.FromArgb(7, 51, 131);

            bt_select.Tag = idPatient;

            bt_select.Click += delegate
            {
                PaiementForm.ID_PATIENT = Convert.ToInt32(idPatient);
                PaiementForm.ChargerPatients();
                this.Close();
            };


            panPatient.Controls.Add(bt_select);

            panPatient.Size = new Size(150, 150);
           

            return panPatient;
        }


        private void tb_search_demande_TextChanged(object sender, EventArgs e)
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

        private void User_display_patients_Load(object sender, EventArgs e)
        {
            LoadPatient();
        }

        private void btn_add_patient_Click(object sender, EventArgs e)
        {
            MesForms.Form_add_patient add = new MesForms.Form_add_patient();
            add.ShowDialog();
        }

        private void AjouterBoutonRetour()
        {
            // Éviter d'ajouter plusieurs boutons Retour
            Control ancien = panel_patient.Controls
                .Cast<Control>()
                .FirstOrDefault(c => c.Name == "btnRetourFiches");

            if (ancien != null)
                panel_patient.Controls.Remove(ancien);

            RoundedButton btnRetour = MesClasses.ManagerClasse.Rbutton(
                " Retour aux patients",
                new Point(150, 10),
                new Size(200, 35),
                Color.FromArgb(18, 98, 168),
                Color.White);

            btnRetour.Name = "btnRetourFiches";
            btnRetour.Margin = new Padding(10);
            btnRetour.BorderRadius = 6;
            btnRetour.BorderSize = 0;
            btnRetour.BorderColor = Color.FromArgb(7, 51, 131);
            btnRetour.HoverBackColor = Color.FromArgb(44, 123, 229);
            btnRetour.Image = Properties.Resources.arrow_white;
            btnRetour.Click += delegate
            {
                LoadPatient();
                tb_search_demande.Visible = true;
                lb_nombres.Visible = true;
            };

            // Le bouton apparaît au début du FlowLayoutPanel
            panel_patient.Controls.Add(btnRetour);
            panel_patient.Controls.SetChildIndex(btnRetour, 0);

        }


        private BunifuRoundedPanel CreerCarteFiche(int idFiche, string idPatient, string numero, string nom, string postnom, string prenom, string dateEntree, string sexe, int age)
        {
            BunifuRoundedPanel carte = new BunifuRoundedPanel();

            int largeurCarte = panel_patient.ClientSize.Width
                    - panel_patient.Padding.Horizontal
                    - 30;

            if (panel_patient.VerticalScroll.Visible)
                largeurCarte -= SystemInformation.VerticalScrollBarWidth;

            carte.Size = new Size(largeurCarte, 210);
            carte.Margin = new Padding(5, 8, 5, 8);

            carte.BorderRadius = 10;
            carte.BorderSize = 1;
            carte.BorderColor = Color.Silver;
            carte.BackColor = Color.White;
            carte.Tag = idFiche;

            // Image du patient
            PictureBox picture = new PictureBox();
            picture.Location = new Point(20, 15);
            picture.Size = new Size(120, 120);
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.Image = Properties.Resources.user;
            picture.BackColor = Color.White;
            carte.Controls.Add(picture);

            // Numéro de fiche
            Label lbNumero = new Label();
            lbNumero.Text = numero;
            lbNumero.Location = new Point(165, 20);
            lbNumero.Size = new Size(600, 25);
            lbNumero.Font = new Font("Calibri", 14, FontStyle.Bold);
            lbNumero.ForeColor = Color.FromArgb(44, 123, 229);
            carte.Controls.Add(lbNumero);

            // Nom du patient
            Label lbPatient = new Label();
            lbPatient.Text = "Patient : " + nom + " " + postnom + " " + prenom;
            lbPatient.Location = new Point(165, 55);
            lbPatient.Size = new Size(650, 25);
            lbPatient.Font = new Font("Calibri", 12, FontStyle.Bold);
            lbPatient.AutoEllipsis = true;
            carte.Controls.Add(lbPatient);

            // Date d'entrée
            Label lbDate = new Label();
            lbDate.Text = "Date d'entrée : " + dateEntree;
            lbDate.Location = new Point(165, 90);
            lbDate.Size = new Size(500, 23);
            lbDate.Font = new Font("Calibri", 12, FontStyle.Bold);
            carte.Controls.Add(lbDate);

            // Statut
            Label lbStatut = new Label();
            lbStatut.Text = "Sexe : " + sexe + "  Age  : " + age + "ans";
            lbStatut.Location = new Point(165, 120);
            lbStatut.Size = new Size(300, 23);
            lbStatut.Font = new Font("Calibri", 12, FontStyle.Bold);

            carte.Controls.Add(lbStatut);

            // Bouton en bas à droite
            int margeDroite = 20;
            int largeurBouton = 195;
            int hauteurBouton = 35;

            RoundedButton btnAfficher = MesClasses.ManagerClasse.Rbutton(
                "Afficher ma fiche",
                new Point(
                    carte.ClientSize.Width - largeurBouton - margeDroite,
                    carte.ClientSize.Height - hauteurBouton - 15
                ),
                new Size(largeurBouton, hauteurBouton),
                Color.FromArgb(44, 123, 229),
                Color.White);

            btnAfficher.BorderRadius = 6;
            btnAfficher.BorderSize = 0;
            btnAfficher.BorderColor = Color.FromArgb(44, 123, 229);
            btnAfficher.HoverBackColor = Color.FromArgb(18, 98, 168);
            btnAfficher.Image = Properties.Resources.arrow_white;

            carte.Controls.Add(btnAfficher);

            btnAfficher.Click += delegate
            {
                MesForms.Fiches.RaportFiche rapport =
                    new MesForms.Fiches.RaportFiche(idPatient, idFiche);

                rapport.ShowDialog();
            };

            return carte;
        }

    }
}
