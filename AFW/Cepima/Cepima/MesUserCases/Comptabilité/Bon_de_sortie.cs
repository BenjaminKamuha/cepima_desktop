using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cepima.MesUserCases.Comptabilité
{
    public partial class Bon_de_sortie : UserControl
    {
        public static Button btRefresh;

        // Timer pour éviter une requête à chaque caractère tapé
        private Timer timerRecherche;

        public Bon_de_sortie()
        {
            InitializeComponent();

            btRefresh = bt_refresh;

            InitialiserRecherche();
        }

        // ============================================================
        // INITIALISATION
        // ============================================================

        private void InitialiserRecherche()
        {
            timerRecherche = new Timer();
            timerRecherche.Interval = 300;
            timerRecherche.Tick += timerRecherche_Tick;
        }

        // ============================================================
        // LOAD
        // ============================================================

        private void Bon_de_sortie_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                cbx_statut.Items.Clear();

                cbx_statut.Items.Add("Tous");
                cbx_statut.Items.Add("En attente");
                cbx_statut.Items.Add("Validé");
                cbx_statut.Items.Add("Annulé");

                cbx_statut.SelectedIndex = 0;

                LoadBonSortie();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des bons de sortie :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // TIMER RECHERCHE
        // ============================================================

        private void timerRecherche_Tick(
            object sender,
            EventArgs e)
        {
            timerRecherche.Stop();

            LoadBonSortie(
                tb_search_demande.Text);
        }

        // ============================================================
        // CHARGER LES BONS DE SORTIE
        // ============================================================

        private void LoadBonSortie(
            params string[] args)
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
                // PREPARATION DU PANEL
                // ----------------------------------------------------

                panel_bon_sortie.SuspendLayout();

                panel_bon_sortie.Controls.Clear();

                panel_bon_sortie.FlowDirection =
                    FlowDirection.LeftToRight;

                panel_bon_sortie.WrapContents =
                    true;

                panel_bon_sortie.AutoScroll =
                    true;

                panel_bon_sortie.Padding =
                    new Padding(
                        10,
                        10,
                        8,
                        10);

                lb_not_found.Visible = false;

                // ----------------------------------------------------
                // REQUETE UNIQUE
                // ----------------------------------------------------

                string query = @"
                    SELECT
                        id_bon,
                        nom_resp,
                        montant,
                        date,
                        statut
                    FROM bon_sortie
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
                            nom_resp LIKE @search
                            OR CAST(id_bon AS CHAR) LIKE @search
                        )
                    ";
                }

                // ----------------------------------------------------
                // FILTRE STATUT
                // ----------------------------------------------------

                if (cbx_statut.SelectedIndex == 1)
                {
                    query +=
                        " AND statut = @statut ";
                }
                else if (cbx_statut.SelectedIndex == 2)
                {
                    query +=
                        " AND statut = @statut ";
                }
                else if (cbx_statut.SelectedIndex == 3)
                {
                    query +=
                        " AND statut = @statut ";
                }

                // ----------------------------------------------------
                // TRI
                // ----------------------------------------------------

                query += @"
                    ORDER BY
                        date DESC,
                        id_bon DESC";

                // ----------------------------------------------------
                // CONNEXION
                // ----------------------------------------------------

                using (MySqlConnection connexion =
                    MesClasses.ManagerClasse.GetConnexion())
                {
                    using (MySqlCommand commande =
                        new MySqlCommand(
                            query,
                            connexion))
                    {
                        // ------------------------------------------------
                        // PARAMETRE RECHERCHE
                        // ------------------------------------------------

                        if (recherche.Length > 0)
                        {
                            commande.Parameters.AddWithValue(
                                "@search",
                                "%" + recherche + "%");
                        }

                        // ------------------------------------------------
                        // PARAMETRE STATUT
                        // ------------------------------------------------

                        if (cbx_statut.SelectedIndex == 1)
                        {
                            commande.Parameters.AddWithValue(
                                "@statut",
                                "En attente");
                        }
                        else if (cbx_statut.SelectedIndex == 2)
                        {
                            commande.Parameters.AddWithValue(
                                "@statut",
                                "Validé");
                        }
                        else if (cbx_statut.SelectedIndex == 3)
                        {
                            commande.Parameters.AddWithValue(
                                "@statut",
                                "Annulé");
                        }

                        // ------------------------------------------------
                        // EXECUTION
                        // ------------------------------------------------

                        using (MySqlDataReader reader =
                            commande.ExecuteReader())
                        {
                            bool trouve = false;

                            while (reader.Read())
                            {
                                trouve = true;

                                string idBon =
                                    GetString(
                                        reader,
                                        "id_bon");

                                string nomResp =
                                    GetString(
                                        reader,
                                        "nom_resp");

                                string montant =
                                    GetString(
                                        reader,
                                        "montant");

                                string dateBon =
                                    GetString(
                                        reader,
                                        "date");

                                string statut =
                                    GetString(
                                        reader,
                                        "statut");

                                BunifuRoundedPanel panBon =
                                    CreerPanelBonSortie(
                                        idBon,
                                        nomResp,
                                        montant,
                                        dateBon,
                                        statut);

                                panel_bon_sortie.Controls.Add(
                                    panBon);
                            }

                            // ------------------------------------------------
                            // AUCUN RESULTAT
                            // ------------------------------------------------

                            if (!trouve)
                            {
                                if (recherche.Length > 0)
                                {
                                    lb_not_found.Text =
                                        "Aucun bon de sortie ne correspond " +
                                        "au terme de recherche '" +
                                        recherche +
                                        "'";
                                }
                                else
                                {
                                    lb_not_found.Text =
                                        "Aucun bon de sortie dans le registre";
                                }

                                panel_bon_sortie.Controls.Add(
                                    lb_not_found);

                                lb_not_found.Visible = true;
                            }
                            else
                            {
                                // --------------------------------------------
                                // AFFICHAGE PROGRESSIF
                                // --------------------------------------------

                                ProgressiveDisplay pd =
                                    new ProgressiveDisplay(
                                        panel_bon_sortie,
                                        100);

                                pd.Start();
                            }
                        }
                    }
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
                    "Erreur lors du chargement des bons de sortie :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                panel_bon_sortie.ResumeLayout();
            }
        }

        // ============================================================
        // LECTURE SECURISEE
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
        // CREATION DE LA CARTE
        // ============================================================

        private BunifuRoundedPanel CreerPanelBonSortie(
            string idBon,
            string nomResp,
            string montant,
            string dateBon,
            string statut)
        {
            BunifuRoundedPanel panBon =
                new BunifuRoundedPanel();

            panBon.Size =
                new Size(
                    290,
                    130);

            panBon.BorderRadius =
                8;

            panBon.BorderColor =
                Color.Silver;

            panBon.BorderSize =
                0;

            panBon.ShadowDepth =
                10;

            panBon.ShadowColor =
                Color.Gray;

            panBon.Tag =
                idBon;

            panBon.Margin =
                new Padding(10);

            panBon.Padding =
                new Padding(10);

            // ========================================================
            // IMAGE
            // ========================================================

            PictureBox picture =
                MesClasses.ManagerClasse.AddPicture(
                    Properties.Resources.bill,
                    new Point(15, 15),
                    new Size(55, 55));

            picture.SizeMode =
                PictureBoxSizeMode.Zoom;

            panBon.Controls.Add(
                picture);

            // ========================================================
            // TITRE
            // ========================================================

            Label lbTitre =
                MesClasses.ManagerClasse.CustomLabel(
                    "Bon de sortie",
                    new Point(85, 18));

            lbTitre.AutoSize =
                true;

            lbTitre.Font =
                new Font(
                    "Calibri",
                    11,
                    FontStyle.Bold);

            panBon.Controls.Add(
                lbTitre);

            // ========================================================
            // NUMERO
            // ========================================================

            Label lbNumero =
                MesClasses.ManagerClasse.CustomLabel(
                    "N° " + idBon,
                    new Point(85, 42));

            lbNumero.AutoSize =
                true;

            lbNumero.Font =
                new Font(
                    "Calibri",
                    9,
                    FontStyle.Regular);

            lbNumero.ForeColor =
                Color.Gray;

            panBon.Controls.Add(
                lbNumero);

            // ========================================================
            // RESPONSABLE
            // ========================================================

            Label lbResponsableTitre =
                MesClasses.ManagerClasse.CustomLabel(
                    "Responsable :",
                    new Point(15, 78));

            lbResponsableTitre.AutoSize =
                true;

            lbResponsableTitre.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold);

            panBon.Controls.Add(
                lbResponsableTitre);

            Label lbResponsable =
                MesClasses.ManagerClasse.CustomLabel(
                    nomResp,
                    new Point(110, 78));

            lbResponsable.AutoSize =
                true;

            lbResponsable.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Regular);

            panBon.Controls.Add(
                lbResponsable);

            // ========================================================
            // DATE
            // ========================================================

            DateTime date;

            if (DateTime.TryParse(
                dateBon,
                out date))
            {
                dateBon =
                    date.ToString(
                        "dd/MM/yyyy");
            }

            Label lbDate =
                MesClasses.ManagerClasse.CustomLabel(
                    "Date : " + dateBon,
                    new Point(15, 103));

            lbDate.AutoSize =
                true;

            lbDate.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Regular);

            panBon.Controls.Add(
                lbDate);

            // ========================================================
            // STATUT
            // ========================================================

            Label lbStatut =
                MesClasses.ManagerClasse.CustomLabel(
                    statut,
                    new Point(190, 103));

            lbStatut.AutoSize =
                true;

            lbStatut.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold);

            // ========================================================
            // COULEUR STATUT
            // ========================================================

            if (statut == "En attente")
            {
                lbStatut.ForeColor =
                    Color.Orange;
            }
            else if (statut == "Validé")
            {
                lbStatut.ForeColor =
                    Color.FromArgb(
                        0,
                        200,
                        83);
            }
            else if (statut == "Annulé")
            {
                lbStatut.ForeColor =
                    Color.Red;
            }
            else
            {
                lbStatut.ForeColor =
                    Color.Black;
            }

            panBon.Controls.Add(
                lbStatut);

            // ========================================================
            // EVENEMENT DU PANEL
            // ========================================================

            panBon.Cursor =
                Cursors.Hand;

            panBon.Click +=
                delegate(object sender, EventArgs e)
                {
                    OuvrirDetailBon(idBon);
                };

            // ========================================================
            // EVENEMENTS DES CONTROLES ENFANTS
            // ========================================================

            picture.Cursor =
                Cursors.Hand;

            picture.Click +=
                delegate(object sender, EventArgs e)
                {
                    OuvrirDetailBon(idBon);
                };

            lbTitre.Cursor =
                Cursors.Hand;

            lbTitre.Click +=
                delegate(object sender, EventArgs e)
                {
                    OuvrirDetailBon(idBon);
                };

            lbNumero.Cursor =
                Cursors.Hand;

            lbNumero.Click +=
                delegate(object sender, EventArgs e)
                {
                    OuvrirDetailBon(idBon);
                };

            lbResponsableTitre.Cursor =
                Cursors.Hand;

            lbResponsableTitre.Click +=
                delegate(object sender, EventArgs e)
                {
                    OuvrirDetailBon(idBon);
                };

            lbResponsable.Cursor =
                Cursors.Hand;

            lbResponsable.Click +=
                delegate(object sender, EventArgs e)
                {
                    OuvrirDetailBon(idBon);
                };

            lbDate.Cursor =
                Cursors.Hand;

            lbDate.Click +=
                delegate(object sender, EventArgs e)
                {
                    OuvrirDetailBon(idBon);
                };

            lbStatut.Cursor =
                Cursors.Hand;

            lbStatut.Click +=
                delegate(object sender, EventArgs e)
                {
                    OuvrirDetailBon(idBon);
                };

            return panBon;
        }

        // ============================================================
        // OUVRIR DETAIL
        // ============================================================

        private void OuvrirDetailBon(
            string idBon)
        {
            try
            {
                MesForms.Compt.DetailBon detail =
                    new MesForms.Compt.DetailBon(
                        idBon);

                detail.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Impossible d'ouvrir le bon de sortie :\n\n" +
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
        // CHANGEMENT DE STATUT
        // ============================================================

        private void cbx_statut_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (timerRecherche != null)
            {
                timerRecherche.Stop();
            }

            LoadBonSortie(
                tb_search_demande.Text);
        }

        // ============================================================
        // AJOUTER UN BON
        // ============================================================

        private void bt_add_bon_Click(
            object sender,
            EventArgs e)
        {
            MesForms.Compt.Bon_de_sortie bon =
                new MesForms.Compt.Bon_de_sortie();

            bon.ShowDialog();
        }

        // ============================================================
        // RAFRAICHIR
        // ============================================================

        private void bt_refresh_Click(
            object sender,
            EventArgs e)
        {
            if (timerRecherche != null)
            {
                timerRecherche.Stop();
            }

            LoadBonSortie(
                tb_search_demande.Text);
        }
    }
}