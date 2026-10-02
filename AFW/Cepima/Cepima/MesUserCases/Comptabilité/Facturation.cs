using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cepima.MesUserCases.Comptabilité
{
    public partial class Facturation : UserControl
    {
        // ============================================================
        // TIMER DE RECHERCHE
        // ============================================================

        private Timer timerRecherche;

        // ============================================================
        // CONSTRUCTEUR
        // ============================================================

        public Facturation()
        {
            InitializeComponent();

            InitialiserRecherche();

            // Définir le filtre AVANT le premier chargement
            rb_tout.Checked = true;

            LoadFactures();
        }

        // ============================================================
        // INITIALISATION DE LA RECHERCHE
        // ============================================================

        private void InitialiserRecherche()
        {
            timerRecherche = new Timer();

            // 300 ms après la dernière frappe
            timerRecherche.Interval = 300;

            timerRecherche.Tick += timerRecherche_Tick;

            // On évite de dépendre uniquement du designer
            tb_search_demande.TextChanged -=
                tb_search_demande_TextChanged;

            tb_search_demande.TextChanged +=
                tb_search_demande_TextChanged;
        }

        // ============================================================
        // TIMER
        // ============================================================

        private void timerRecherche_Tick(
            object sender,
            EventArgs e)
        {
            timerRecherche.Stop();

            LoadFactures(tb_search_demande.Text);
        }

        // ============================================================
        // FILTRE FACTURE
        // ============================================================

        private string GetFiltreFacture()
        {
            if (rb_ambulatoire.Checked)
            {
                return " AND f.type_facture = @typeFacture ";
            }

            if (rb_hospitalise.Checked)
            {
                return " AND f.type_facture = @typeFacture ";
            }

            if (rb_partielle.Checked)
            {
                return " AND f.statut = @statutFacture ";
            }

            return "";
        }

        // ============================================================
        // PARAMETRES DU FILTRE
        // ============================================================

        private void AjouterParametresFiltre(
            MySqlCommand commande)
        {
            if (rb_ambulatoire.Checked)
            {
                commande.Parameters.AddWithValue(
                    "@typeFacture",
                    "Ambulatoire");
            }
            else if (rb_hospitalise.Checked)
            {
                commande.Parameters.AddWithValue(
                    "@typeFacture",
                    "Hospitalisé");
            }
            else if (rb_partielle.Checked)
            {
                commande.Parameters.AddWithValue(
                    "@statutFacture",
                    "Partiellement payé");
            }
        }

        // ============================================================
        // CHARGEMENT DES FACTURES
        // ============================================================

        private void LoadFactures(params string[] args)
        {
            string recherche = "";

            if (args != null &&
                args.Length > 0 &&
                args[0] != null)
            {
                recherche = args[0].Trim();
            }

            try
            {
                // ----------------------------------------------------
                // Préparation de l'interface
                // ----------------------------------------------------

                panel_facture.SuspendLayout();

                panel_facture.Controls.Clear();

                panel_facture.FlowDirection =
                    FlowDirection.LeftToRight;

                panel_facture.WrapContents = true;
                panel_facture.AutoScroll = true;

                panel_facture.Padding =
                    new Padding(10, 10, 8, 10);

                lb_not_found.Visible = false;

                // ----------------------------------------------------
                // REQUETE UNIQUE
                // ----------------------------------------------------

                string query = @"
                    SELECT
                        f.id_facture,
                        f.id_patient,
                        f.type_facture,
                        f.date_facture,
                        f.montant_total,
                        f.montant_paye,
                        f.reste,
                        f.statut,

                        p.nom,
                        p.post_nom,
                        p.prenom

                    FROM facture f

                    LEFT JOIN patients p
                        ON p.id_patient = f.id_patient

                    WHERE 1 = 1
                ";

                // ----------------------------------------------------
                // RECHERCHE
                // ----------------------------------------------------

                if (recherche.Length > 0)
                {
                    query += @"
                        AND
                        (
                            p.nom LIKE @search
                            OR p.post_nom LIKE @search
                            OR p.prenom LIKE @search
                            OR CAST(f.id_facture AS CHAR) LIKE @search
                        )
                    ";
                }

                // ----------------------------------------------------
                // FILTRE
                // ----------------------------------------------------

                query += GetFiltreFacture();

                // ----------------------------------------------------
                // TRI
                // ----------------------------------------------------

                query += @"
                    ORDER BY
                        f.date_facture DESC,
                        f.id_facture DESC";

                // ----------------------------------------------------
                // CONNEXION
                // ----------------------------------------------------

                using (MySqlConnection connexion =
                    MesClasses.ManagerClasse.GetConnexion())
                {
                    using (MySqlCommand commande =
                        new MySqlCommand(query, connexion))
                    {
                        // Recherche
                        if (recherche.Length > 0)
                        {
                            commande.Parameters.AddWithValue(
                                "@search",
                                "%" + recherche + "%");
                        }

                        // Filtres
                        AjouterParametresFiltre(
                            commande);

                        using (MySqlDataReader reader =
                            commande.ExecuteReader())
                        {
                            bool trouve = false;

                            while (reader.Read())
                            {
                                trouve = true;

                                // ------------------------------------
                                // ID FACTURE
                                // ------------------------------------

                                string idFacture =
                                    GetString(reader, "id_facture");

                                // ------------------------------------
                                // ID PATIENT
                                // ------------------------------------

                                string idPatient =
                                    GetString(reader, "id_patient");

                                // ------------------------------------
                                // PATIENT
                                // ------------------------------------

                                string nom =
                                    GetString(reader, "nom");

                                string postnom =
                                    GetString(reader, "post_nom");

                                string prenom =
                                    GetString(reader, "prenom");

                                // ------------------------------------
                                // FACTURE
                                // ------------------------------------

                                string typeFacture =
                                    GetString(
                                        reader,
                                        "type_facture");

                                string dateFacture =
                                    GetString(
                                        reader,
                                        "date_facture");

                                string montantTotal =
                                    GetString(
                                        reader,
                                        "montant_total");

                                string montantPaye =
                                    GetString(
                                        reader,
                                        "montant_paye");

                                string reste =
                                    GetString(
                                        reader,
                                        "reste");

                                string statut =
                                    GetString(
                                        reader,
                                        "statut");

                                // ------------------------------------
                                // CREATION CARTE
                                // ------------------------------------

                                BunifuRoundedPanel panFacture =
                                    CreerPanelFacture(
                                        idFacture,
                                        idPatient,
                                        nom,
                                        postnom,
                                        prenom,
                                        typeFacture,
                                        dateFacture,
                                        montantTotal,
                                        montantPaye,
                                        reste,
                                        statut);

                                panel_facture.Controls.Add(
                                    panFacture);
                            }

                            // ----------------------------------------
                            // AUCUN RESULTAT
                            // ----------------------------------------

                            if (!trouve)
                            {
                                if (recherche.Length > 0)
                                {
                                    lb_not_found.Text =
                                        "Aucune facture ne correspond " +
                                        "au terme de recherche '" +
                                        recherche +
                                        "'";
                                }
                                else
                                {
                                    lb_not_found.Text =
                                        "Aucune facture dans le registre";
                                }

                                panel_facture.Controls.Add(
                                    lb_not_found);

                                lb_not_found.Visible = true;
                            }
                        }
                    }
                }

                // ----------------------------------------------------
                // AFFICHAGE PROGRESSIF
                // ----------------------------------------------------

                if (panel_facture.Controls.Count > 0 &&
                    lb_not_found.Visible == false)
                {
                    ProgressiveDisplay pd =
                        new ProgressiveDisplay(
                            panel_facture,
                            100);

                    pd.Start();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur MySQL :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des factures :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                panel_facture.ResumeLayout();
            }
        }

        // ============================================================
        // LECTURE SECURISEE D'UNE VALEUR
        // ============================================================

        private string GetString(
            MySqlDataReader reader,
            string colonne)
        {
            if (reader[colonne] == DBNull.Value)
            {
                return "";
            }

            return reader[colonne].ToString();
        }

        // ============================================================
        // CREATION D'UNE CARTE FACTURE
        // ============================================================

        private BunifuRoundedPanel CreerPanelFacture(
            string idFacture,
            string idPatient,
            string nom,
            string postnom,
            string prenom,
            string typeFacture,
            string dateFacture,
            string montantTotal,
            string montantPaye,
            string reste,
            string statut)
        {
            // ---------------------------------------------------------
            // PANEL PRINCIPAL
            // ---------------------------------------------------------

            BunifuRoundedPanel panFacture =
                new BunifuRoundedPanel();

            panFacture.Size =
                new Size(290, 135);

            panFacture.BorderRadius = 8;

            panFacture.BorderColor =
                Color.Silver;

            panFacture.BorderSize = 0;

            panFacture.ShadowDepth = 10;

            panFacture.ShadowColor =
                Color.Gray;

            panFacture.Tag =
                idFacture;

            panFacture.Margin =
                new Padding(10);

            panFacture.Padding =
                new Padding(10);

            // ---------------------------------------------------------
            // IMAGE
            // ---------------------------------------------------------

            PictureBox picture =
                MesClasses.ManagerClasse.AddPicture(
                    Properties.Resources.bill,
                    new Point(15, 15),
                    new Size(60, 60));

            picture.SizeMode =
                PictureBoxSizeMode.Zoom;

            panFacture.Controls.Add(
                picture);

            RoundedButton btn = new RoundedButton();
            btn.ButtonText = "Clôturer";
            btn.Size = new Size(90, 25);
            btn.BorderRadius = 8;
            btn.Location = new Point(170, 98);


            btn.Click += (e, ev) =>
            {
                string query = "UPDATE facture SET statut = 'Clôturée' WHERE id_facture = @id_facture";
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_facture", idFacture);
                        cmd.ExecuteNonQuery();
                        LoadFactures();
                    }
                }
            };

            if (statut != "Clôturée")
            {
                panFacture.Controls.Add(btn);
            }

            // ---------------------------------------------------------
            // TITRE FACTURE
            // ---------------------------------------------------------

            Label lbFacture =
                MesClasses.ManagerClasse.CustomLabel(
                    "Facture",
                    new Point(90, 18));

            lbFacture.AutoSize = true;

            lbFacture.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold);

            panFacture.Controls.Add(
                lbFacture);

            // ---------------------------------------------------------
            // NUMERO
            // ---------------------------------------------------------

            Label lbNumero =
                MesClasses.ManagerClasse.CustomLabel(
                    "N° " + idFacture,
                    new Point(175, 18));

            lbNumero.AutoSize = true;

            lbNumero.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold);

            panFacture.Controls.Add(
                lbNumero);

            // ---------------------------------------------------------
            // PATIENT
            // ---------------------------------------------------------

            string nomPatient =
                (nom + " " +
                 postnom + " " +
                 prenom).Trim();

            Label lbPatient =
                MesClasses.ManagerClasse.CustomLabel(
                    nomPatient,
                    new Point(90, 48));

            lbPatient.AutoSize = true;

            lbPatient.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold);

            panFacture.Controls.Add(
                lbPatient);

            // ---------------------------------------------------------
            // STATUT - TITRE
            // ---------------------------------------------------------

            Label lbStatutTitre =
                MesClasses.ManagerClasse.CustomLabel(
                    "Statut:",
                    new Point(15, 98));

            lbStatutTitre.AutoSize = true;

            lbStatutTitre.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold);

            panFacture.Controls.Add(
                lbStatutTitre);

            // ---------------------------------------------------------
            // STATUT
            // ---------------------------------------------------------

            Label lbStatut =
                MesClasses.ManagerClasse.CustomLabel(
                    statut,
                    new Point(75, 98));

            lbStatut.AutoSize = true;

            lbStatut.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold);

            // ---------------------------------------------------------
            // COULEUR DU STATUT
            // ---------------------------------------------------------

            if (statut == "Non payé")
            {
                lbStatut.ForeColor =
                    Color.Red;
            }
            else if (statut == "Payé")
            {
                lbStatut.ForeColor =
                    Color.FromArgb(
                        0,
                        200,
                        83);
            }
            else if (statut ==
                     "Partiellement payé")
            {
                lbStatut.ForeColor =
                    Color.Orange;
            }
            else if (statut ==
                     "Clôturée")
            {
                lbStatut.ForeColor =
                    Color.FromArgb(
                        44,
                        123,
                        229);
            }
            else
            {
                lbStatut.ForeColor =
                    Color.Black;
            }

            panFacture.Controls.Add(
                lbStatut);

            // ---------------------------------------------------------
            // EVENEMENT
            // ---------------------------------------------------------

            panFacture.Cursor =
                Cursors.Hand;

            panFacture.Click +=
                delegate(object sender, EventArgs e)
                {
                    try
                    {
                        int id =
                            Convert.ToInt32(
                                idFacture);

                        MesForms.FormFacturePrint facture =
                            new MesForms.FormFacturePrint(id);

                        facture.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Impossible d'ouvrir la facture :\n\n" +
                            ex.Message,
                            "Erreur",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                };

            // ---------------------------------------------------------
            // Permettre également le clic sur les contrôles enfants
            // ---------------------------------------------------------

            picture.Click +=
                delegate(object sender, EventArgs e)
                {
                    OuvrirFacture(idFacture);
                };

            lbFacture.Click +=
                delegate(object sender, EventArgs e)
                {
                    OuvrirFacture(idFacture);
                };

            lbNumero.Click +=
                delegate(object sender, EventArgs e)
                {
                    OuvrirFacture(idFacture);
                };

            lbPatient.Click +=
                delegate(object sender, EventArgs e)
                {
                    OuvrirFacture(idFacture);
                };

            lbStatutTitre.Click +=
                delegate(object sender, EventArgs e)
                {
                    OuvrirFacture(idFacture);
                };

            lbStatut.Click +=
                delegate(object sender, EventArgs e)
                {
                    OuvrirFacture(idFacture);
                };

            return panFacture;
        }

        // ============================================================
        // OUVRIR FACTURE
        // ============================================================

        private void OuvrirFacture(
            string idFacture)
        {
            try
            {
                int id =
                    Convert.ToInt32(
                        idFacture);

                MesForms.FormFacturePrint facture =
                    new MesForms.FormFacturePrint(id);

                facture.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Impossible d'ouvrir la facture :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // RECHERCHE
        // ============================================================

        private void tb_search_demande_TextChanged(
            object sender,
            EventArgs e)
        {
            if (timerRecherche == null)
            {
                return;
            }

            timerRecherche.Stop();

            timerRecherche.Start();
        }

        // ============================================================
        // RADIO : TOUS
        // ============================================================

        private void rb_tout_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (!rb_tout.Checked)
            {
                return;
            }

            timerRecherche.Stop();

            LoadFactures(
                tb_search_demande.Text);
        }

        // ============================================================
        // RADIO : AMBULATOIRE
        // ============================================================

        private void rb_ambulatoire_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (!rb_ambulatoire.Checked)
            {
                return;
            }

            timerRecherche.Stop();

            LoadFactures(
                tb_search_demande.Text);
        }

        // ============================================================
        // RADIO : HOSPITALISE
        // ============================================================

        private void rb_hospitalise_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (!rb_hospitalise.Checked)
            {
                return;
            }

            timerRecherche.Stop();

            LoadFactures(
                tb_search_demande.Text);
        }

        // ============================================================
        // RADIO : PARTIELLEMENT PAYE
        // ============================================================

        private void rb_partielle_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (!rb_partielle.Checked)
            {
                return;
            }

            timerRecherche.Stop();

            LoadFactures(
                tb_search_demande.Text);
        }
    }
}