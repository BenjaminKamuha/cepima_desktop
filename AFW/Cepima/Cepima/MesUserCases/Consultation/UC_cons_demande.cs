using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Cepima.Data;

namespace Cepima.MesUserCases.Consultation
{
    public partial class UC_cons_demande : UserControl
    {
        // ============================================================
        // CONSTRUCTEUR
        // ============================================================

        public UC_cons_demande()
        {
            InitializeComponent();

            InitialiserEvenements();

            rd_tout.Checked = true;

            ChargerDemandesConsultation();
        }


        // ============================================================
        // INITIALISATION DES EVENEMENTS
        // ============================================================

        private void InitialiserEvenements()
        {
            rd_tout.CheckedChanged += FiltreChanged;
            rd_statut_demande.CheckedChanged += FiltreChanged;
            rd_statut_termine.CheckedChanged += FiltreChanged;
            rd_statut_annule.CheckedChanged += FiltreChanged;

            tb_search_demande.TextChanged +=
                tb_search_demande_TextChanged;

            this.Resize +=
                UC_cons_demande_Resize;
        }


        // ============================================================
        // FILTRE STATUT
        // ============================================================

        private void FiltreChanged(
            object sender,
            EventArgs e)
        {
            RadioButton radio =
                sender as RadioButton;

            if (radio == null)
                return;

            if (!radio.Checked)
                return;

            ChargerDemandesConsultation();
        }


        // ============================================================
        // RECHERCHE
        // ============================================================

        private void tb_search_demande_TextChanged(
            object sender,
            EventArgs e)
        {
            ChargerDemandesConsultation();
        }


        // ============================================================
        // STATUT SELECTIONNE
        // ============================================================

        private string ObtenirStatutSelectionne()
        {
            if (rd_statut_demande.Checked)
                return "En attente";

            if (rd_statut_termine.Checked)
                return "Terminée";

            if (rd_statut_annule.Checked)
                return "Annulée";

            return "Tous";
        }


        // ============================================================
        // CHARGER LES DEMANDES
        // ============================================================

        private void ChargerDemandesConsultation()
        {
            try
            {
                // =====================================================
                // SUSPENDRE LE LAYOUT
                // =====================================================

                pnl_cons.SuspendLayout();

                pnl_cons.Controls.Clear();


                // =====================================================
                // VALEURS DE RECHERCHE
                // =====================================================

                string recherche =
                    tb_search_demande.Text.Trim();

                string statut =
                    ObtenirStatutSelectionne();


                // =====================================================
                // CONNEXION
                // =====================================================

                Database db =
                    new Database();

                using (MySqlConnection con =
                    db.GetConnection())
                {
                    // IMPORTANT :
                    // GetConnection() retourne ici une connexion
                    // qui doit être ouverte explicitement.

                    con.Open();


                    // =================================================
                    // REQUETE
                    // =================================================

                    string query = @"
                        SELECT
                            ds.id_demande,
                            ds.id_patient,
                            ds.id_prestation,

                            COALESCE(p.nom, '') AS nom,
                            COALESCE(p.post_nom, '') AS post_nom,
                            COALESCE(p.prenom, '') AS prenom,
                            COALESCE(p.numero_fiche, '') AS numero_fiche,

                            COALESCE(
                                pr.libelle,
                                ''
                            ) AS prestation,

                            ds.date_demande,

                            ds.priorite,
                            ds.motif,
                            ds.statut

                        FROM demande_service ds

                        INNER JOIN service s
                            ON s.id_service =
                               ds.id_service

                        LEFT JOIN patients p
                            ON p.id_patient =
                               ds.id_patient

                        LEFT JOIN prestation pr
                            ON pr.id_prestation =
                               ds.id_prestation

                        WHERE
                            s.nom = 'Consultation'

                        AND
                        (
                            @statut = 'Tous'
                            OR ds.statut = @statut
                        )

                        AND
                        (
                            @recherche = ''
                            OR p.nom LIKE @recherche
                            OR p.post_nom LIKE @recherche
                            OR p.prenom LIKE @recherche
                            OR p.numero_fiche LIKE @recherche
                            OR pr.libelle LIKE @recherche
                            OR ds.motif LIKE @recherche
                        )

                        ORDER BY
                            ds.date_demande DESC";


                    // =================================================
                    // COMMANDE
                    // =================================================

                    using (MySqlCommand cmd =
                        new MySqlCommand(
                            query,
                            con))
                    {
                        // =================================================
                        // PARAMETRE STATUT
                        // =================================================

                        cmd.Parameters.Add(
                            "@statut",
                            MySqlDbType.VarChar,
                            30).Value =
                            statut;


                        // =================================================
                        // PARAMETRE RECHERCHE
                        // =================================================

                        cmd.Parameters.Add(
                            "@recherche",
                            MySqlDbType.VarChar,
                            255).Value =
                            string.IsNullOrEmpty(recherche)
                                ? ""
                                : "%" + recherche + "%";


                        // =================================================
                        // EXECUTION
                        // =================================================

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            int positionX = 10;
                            int positionY = 10;

                            int largeurPanel = 950;
                            int hauteurPanel = 125;


                            // =================================================
                            // LECTURE
                            // =================================================

                            while (reader.Read())
                            {
                                // =============================================
                                // ID DEMANDE
                                // =============================================

                                string idDemande =
                                    reader[
                                        "id_demande"
                                    ].ToString();


                                // =============================================
                                // ID PATIENT
                                // =============================================

                                string idPatient =
                                    reader[
                                        "id_patient"
                                    ].ToString();


                                // =============================================
                                // NOM
                                // =============================================

                                string nom =
                                    reader[
                                        "nom"
                                    ].ToString();


                                // =============================================
                                // POST-NOM
                                // =============================================

                                string postNom =
                                    reader[
                                        "post_nom"
                                    ].ToString();


                                // =============================================
                                // PRENOM
                                // =============================================

                                string prenom =
                                    reader[
                                        "prenom"
                                    ].ToString();


                                // =============================================
                                // NUMERO FICHE
                                // =============================================

                                string numeroFiche =
                                    reader[
                                        "numero_fiche"
                                    ].ToString();


                                // =============================================
                                // PRESTATION
                                // =============================================

                                string prestation =
                                    reader[
                                        "prestation"
                                    ].ToString();


                                // =============================================
                                // DATE
                                // =============================================

                                string dateDemande = "";

                                if (reader["date_demande"] !=
                                    DBNull.Value)
                                {
                                    DateTime date =
                                        Convert.ToDateTime(
                                            reader[
                                                "date_demande"
                                            ]);

                                    dateDemande =
                                        date.ToString(
                                            "dd/MM/yyyy HH:mm");
                                }


                                // =============================================
                                // PRIORITE
                                // =============================================

                                string priorite =
                                    reader[
                                        "priorite"
                                    ].ToString();


                                // =============================================
                                // MOTIF
                                // =============================================

                                string motif = "";

                                if (reader["motif"] !=
                                    DBNull.Value)
                                {
                                    motif =
                                        reader[
                                            "motif"
                                        ].ToString();
                                }


                                // =============================================
                                // STATUT
                                // =============================================

                                string statutDemande =
                                    reader[
                                        "statut"
                                    ].ToString();


                                // =============================================
                                // CREATION DU PANEL
                                // =============================================

                                CustomRoundedPanel panel =
                                    CreerPanelConsultation(
                                        idDemande,
                                        idPatient,
                                        nom,
                                        postNom,
                                        prenom,
                                        numeroFiche,
                                        prestation,
                                        dateDemande,
                                        priorite,
                                        motif,
                                        statutDemande);


                                // =============================================
                                // DIMENSIONS
                                // =============================================

                                panel.Width =
                                    Math.Max(
                                        largeurPanel,
                                        pnl_cons.ClientSize.Width - 20);

                                panel.Height =
                                    hauteurPanel;


                                // =============================================
                                // POSITION
                                // =============================================

                                panel.Location =
                                    new Point(
                                        positionX,
                                        positionY);


                                // =============================================
                                // AJOUT
                                // =============================================

                                pnl_cons.Controls.Add(
                                    panel);


                                // =============================================
                                // POSITION SUIVANTE
                                // =============================================

                                positionY +=
                                    panel.Height + 10;
                            }
                        }
                    }
                }


                // =====================================================
                // FIN DU LAYOUT
                // =====================================================

                pnl_cons.ResumeLayout();

                pnl_cons.AutoScroll = true;

                pnl_cons.Refresh();
            }
            catch (Exception ex)
            {
                pnl_cons.ResumeLayout();

                MessageBox.Show(
                    "Erreur lors du chargement des demandes " +
                    "de consultation.\n\n" +
                    ex.Message,
                    "Consultation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ============================================================
        // CREER UNE CARTE DE DEMANDE
        // ============================================================

        private CustomRoundedPanel
            CreerPanelConsultation(
                string idDemande,
                string idPatient,
                string nom,
                string postNom,
                string prenom,
                string numeroFiche,
                string prestation,
                string dateDemande,
                string priorite,
                string motif,
                string statut)
        {
            CustomRoundedPanel panel =
                new CustomRoundedPanel();


            panel.BackColor =
                Color.White;

            panel.BorderColor =
                Color.FromArgb(
                    225,
                    225,
                    225);

            panel.BorderRadius = 10;
            panel.BorderSize = 1;

            panel.ShadowEnabled = false;

            panel.Cursor =
                Cursors.Hand;


            // ========================================================
            // NOM DU PATIENT
            // ========================================================

            Label lblPatient =
                new Label();

            lblPatient.AutoSize = true;

            lblPatient.Font =
                new Font(
                    "Microsoft Tai Le",
                    11F,
                    FontStyle.Bold);

            lblPatient.ForeColor =
                Color.FromArgb(
                    40,
                    40,
                    40);

            lblPatient.Text =
                (nom + " " +
                 postNom + " " +
                 prenom).Trim();

            lblPatient.Location =
                new Point(
                    20,
                    15);

            panel.Controls.Add(
                lblPatient);


            // ========================================================
            // NUMERO PATIENT
            // ========================================================

            Label lblNumero =
                new Label();

            lblNumero.AutoSize = true;

            lblNumero.Font =
                new Font(
                    "Microsoft Tai Le",
                    9F);

            lblNumero.ForeColor =
                Color.Gray;

            lblNumero.Text =
                "N° patient : " +
                numeroFiche;

            lblNumero.Location =
                new Point(
                    20,
                    42);

            panel.Controls.Add(
                lblNumero);


            // ========================================================
            // PRESTATION
            // ========================================================

            Label lblPrestation =
                new Label();

            lblPrestation.AutoSize = true;

            lblPrestation.Font =
                new Font(
                    "Microsoft Tai Le",
                    10F,
                    FontStyle.Bold);

            lblPrestation.ForeColor =
                Color.FromArgb(
                    30,
                    100,
                    180);

            lblPrestation.Text =
                "Prestation : " +
                (string.IsNullOrWhiteSpace(
                    prestation)
                    ? "Consultation"
                    : prestation);

            lblPrestation.Location =
                new Point(
                    250,
                    15);

            panel.Controls.Add(
                lblPrestation);


            // ========================================================
            // DATE
            // ========================================================

            Label lblDate =
                new Label();

            lblDate.AutoSize = true;

            lblDate.Font =
                new Font(
                    "Microsoft Tai Le",
                    9F);

            lblDate.ForeColor =
                Color.Gray;

            lblDate.Text =
                "Date : " +
                dateDemande;

            lblDate.Location =
                new Point(
                    250,
                    42);

            panel.Controls.Add(
                lblDate);


            // ========================================================
            // PRIORITE
            // ========================================================

            Label lblPriorite =
                new Label();

            lblPriorite.AutoSize = true;

            lblPriorite.Font =
                new Font(
                    "Microsoft Tai Le",
                    9F,
                    FontStyle.Bold);

            lblPriorite.Text =
                "Priorité : " +
                priorite;

            lblPriorite.Location =
                new Point(
                    500,
                    15);


            if (priorite == "Urgente")
            {
                lblPriorite.ForeColor =
                    Color.Red;
            }
            else
            {
                lblPriorite.ForeColor =
                    Color.DarkOrange;
            }

            panel.Controls.Add(
                lblPriorite);


            // ========================================================
            // STATUT
            // ========================================================

            Label lblStatut =
                new Label();

            lblStatut.AutoSize = true;

            lblStatut.Font =
                new Font(
                    "Microsoft Tai Le",
                    9F,
                    FontStyle.Bold);

            lblStatut.Text =
                "Statut : " +
                statut;

            lblStatut.Location =
                new Point(
                    500,
                    42);


            if (statut == "Demandée")
            {
                lblStatut.ForeColor =
                    Color.DarkOrange;
            }
            else if (statut == "Terminée")
            {
                lblStatut.ForeColor =
                    Color.Green;
            }
            else if (statut == "Annulée")
            {
                lblStatut.ForeColor =
                    Color.Red;
            }
            else
            {
                lblStatut.ForeColor =
                    Color.DodgerBlue;
            }

            panel.Controls.Add(
                lblStatut);


            // ========================================================
            // MOTIF
            // ========================================================

            Label lblMotif =
                new Label();

            lblMotif.AutoSize = false;

            lblMotif.Font =
                new Font(
                    "Microsoft Tai Le",
                    9F);

            lblMotif.ForeColor =
                Color.FromArgb(
                    70,
                    70,
                    70);

            lblMotif.Text =
                "Motif : " +
                (string.IsNullOrWhiteSpace(
                    motif)
                    ? "-"
                    : motif);

            lblMotif.Location =
                new Point(
                    20,
                    72);

            lblMotif.Width =
                700;

            lblMotif.Height =
                35;

            panel.Controls.Add(
                lblMotif);


            // ========================================================
            // BOUTONS D'ACTION
            // ========================================================

            if (statut == "Terminée")
            {
                // ====================================================
                // DEMANDE SERVICE
                // ====================================================

                Button btnRecommander =
                    new Button();

                btnRecommander.Text =
                    "Demande service";

                btnRecommander.Width =
                    150;

                btnRecommander.Height =
                    32;

                btnRecommander.FlatStyle =
                    FlatStyle.Flat;

                btnRecommander.FlatAppearance.BorderSize =
                    0;

                btnRecommander.BackColor =
                    Color.FromArgb(
                        30,
                        120,
                        210);

                btnRecommander.ForeColor =
                    Color.White;

                btnRecommander.Font =
                    new Font(
                        "Microsoft Tai Le",
                        9F,
                        FontStyle.Bold);

                btnRecommander.Location =
                    new Point(
                        650,
                        20);

                btnRecommander.Tag =
                    idDemande;

                btnRecommander.Click +=
                    delegate(object sender, EventArgs e)
                    {
                        RecommanderService(
                            idDemande,
                            idPatient);
                    };

                panel.Controls.Add(
                    btnRecommander);


                // ====================================================
                // PRESCRIPTION
                // ====================================================

                Button btnPrescription =
                    new Button();

                btnPrescription.Text =
                    "Prescription";

                btnPrescription.Width =
                    110;

                btnPrescription.Height =
                    32;

                btnPrescription.FlatStyle =
                    FlatStyle.Flat;

                btnPrescription.FlatAppearance.BorderSize =
                    0;

                btnPrescription.BackColor =
                    Color.FromArgb(
                        60,
                        160,
                        90);

                btnPrescription.ForeColor =
                    Color.White;

                btnPrescription.Font =
                    new Font(
                        "Microsoft Tai Le",
                        9F,
                        FontStyle.Bold);

                btnPrescription.Location =
                    new Point(
                        815,
                        20);

                btnPrescription.Tag =
                    idDemande;

                btnPrescription.Click +=
                    delegate(object sender, EventArgs e)
                    {
                        OuvrirPrescription(
                            idDemande,
                            idPatient);
                    };

                panel.Controls.Add(
                    btnPrescription);
            }
            else
            {
                // ====================================================
                // COMMENCER
                // ====================================================

                Button btnOuvrir =
                    new Button();

                btnOuvrir.Text =
                    "Commencer";

                btnOuvrir.Width =
                    90;

                btnOuvrir.Height =
                    32;

                btnOuvrir.FlatStyle =
                    FlatStyle.Flat;

                btnOuvrir.FlatAppearance.BorderSize =
                    0;

                btnOuvrir.BackColor =
                    Color.FromArgb(
                        30,
                        120,
                        210);

                btnOuvrir.ForeColor =
                    Color.White;

                btnOuvrir.Font =
                    new Font(
                        "Microsoft Tai Le",
                        9F,
                        FontStyle.Bold);

                btnOuvrir.Location =
                    new Point(
                        820,
                        45);

                btnOuvrir.Tag =
                    idDemande;

                btnOuvrir.Click +=
                    delegate(object sender, EventArgs e)
                    {
                        OuvrirDemande(
                            idDemande,
                            idPatient);
                    };

                panel.Controls.Add(
                    btnOuvrir);
            }


            // ========================================================
            // CLICK SUR LE PANEL
            // ========================================================

            panel.Tag =
                idDemande;

            if (statut == "En attente")
            {
                panel.Click +=
                    delegate(object sender, EventArgs e)
                    {
                        OuvrirDemande(
                            idDemande,
                            idPatient);
                    };
            }


            return panel;
        }


        // ============================================================
        // OUVRIR UNE DEMANDE
        // ============================================================

        private void OuvrirDemande(
            string idDemande,
            string idPatient)
        {
            try
            {
                User_consultation uc =
                    new User_consultation(
                        Convert.ToInt32(idPatient),
                        Convert.ToInt32(idDemande));

                Form1.GlobalPanel_main.Controls.Clear();

                uc.Dock =
                    DockStyle.Fill;

                Form1.GlobalPanel_main.Controls.Add(
                    uc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ============================================================
        // RECOMMANDER UN SERVICE
        // ============================================================

        private void RecommanderService(
            string idDemande,
            string idPatient)
        {
            MesForms.Form_demander_service frm =
                new MesForms.Form_demander_service(
                    idPatient,
                    0);

            frm.ShowDialog();
        }


        // ============================================================
        // PRESCRIPTION
        // ============================================================

        private void OuvrirPrescription(
            string idDemande,
            string idPatient)
        {
            MesForms.Prescription.Form_prescription_mdc
                form_presc =
                new MesForms.Prescription.Form_prescription_mdc(
                    Convert.ToInt32(idPatient));

            form_presc.ShowDialog();
        }


        // ============================================================
        // REDIMENSIONNEMENT
        // ============================================================

        private void UC_cons_demande_Resize(
            object sender,
            EventArgs e)
        {
            foreach (Control control
                in pnl_cons.Controls)
            {
                if (control is CustomRoundedPanel)
                {
                    control.Width =
                        Math.Max(
                            900,
                            pnl_cons.ClientSize.Width - 20);
                }
            }
        }
    }
}