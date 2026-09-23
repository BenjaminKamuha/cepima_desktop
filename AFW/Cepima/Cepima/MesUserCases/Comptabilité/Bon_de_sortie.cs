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
namespace Cepima.MesUserCases.Comptabilité
{
    public partial class Bon_de_sortie : UserControl
    {
        public static Button btRefresh;
        public Bon_de_sortie()
        {
            InitializeComponent();
            btRefresh = bt_refresh;
        }

        private void Bon_de_sortie_Load(object sender, EventArgs e)
        {
            cbx_statut.Items.Clear();
            cbx_statut.Items.Add("Tous");
            cbx_statut.Items.Add("En attente");
            cbx_statut.Items.Add("Validé");
            cbx_statut.Items.Add("Annulé");

            cbx_statut.SelectedIndex = 0;

            LoadBonSortie();
        }

        private void LoadBonSortie(params string[] args)
        {
            panel_bon_sortie.Controls.Clear();

            // =========================================================
            // CONFIGURATION DU FLOWLAYOUTPANEL
            // =========================================================

            panel_bon_sortie.FlowDirection =
                FlowDirection.LeftToRight;

            panel_bon_sortie.WrapContents = true;
            panel_bon_sortie.AutoScroll = true;

            panel_bon_sortie.Padding =
                new Padding(10, 10, 8, 10);

            lb_not_found.Visible = false;


            // =========================================================
            // FILTRE SELON LE STATUT
            // =========================================================

            string filtre = "";

            if (cbx_statut.SelectedIndex == 1)
            {
                filtre = " AND statut = 'En attente'";
            }
            else if (cbx_statut.SelectedIndex == 2)
            {
                filtre = " AND statut = 'Validé'";
            }
            else if (cbx_statut.SelectedIndex == 3)
            {
                filtre = " AND statut = 'Annulé'";
            }


            // =========================================================
            // RECHERCHE
            // =========================================================

            if (args.Length != 0 && !string.IsNullOrWhiteSpace(args[0]))
            {
                try
                {
                    string query = @"
                SELECT
                    id_bon,
                    nom_resp,
                    montant,
                    date,
                    statut
                FROM bon_sortie
                WHERE
                    (
                        nom_resp LIKE @search
                        OR CAST(id_bon AS CHAR) LIKE @search
                    )
                    " + filtre + @"
                ORDER BY date DESC,
                         id_bon DESC";

                    MesClasses.ManagerClasse.request_params.Clear();

                    MesClasses.ManagerClasse.request_params.Add(
                        "@search",
                        "%" + args[0] + "%"
                    );

                    using (MySqlDataReader reader =
                        MesClasses.ManagerClasse.CRUD(
                            query,
                            MesClasses.ManagerClasse.request_params,
                            true))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string idBon =
                                    reader["id_bon"].ToString();

                                string nomResp =
                                    reader["nom_resp"] == DBNull.Value
                                    ? ""
                                    : reader["nom_resp"].ToString();

                                string montant =
                                    reader["montant"] == DBNull.Value
                                    ? "0"
                                    : reader["montant"].ToString();

                                string dateBon =
                                    reader["date"] == DBNull.Value
                                    ? ""
                                    : reader["date"].ToString();

                                string statut =
                                    reader["statut"] == DBNull.Value
                                    ? ""
                                    : reader["statut"].ToString();


                                // =================================================
                                // CRÉATION DE LA CARTE
                                // =================================================

                                BunifuRoundedPanel panBon =
                                    CreerPanelBonSortie(
                                        idBon,
                                        nomResp,
                                        montant,
                                        dateBon,
                                        statut
                                    );


                                // Ajout au FlowLayoutPanel
                                panel_bon_sortie.Controls.Add(
                                    panBon
                                );
                            }

                            reader.Close();

                            ProgressiveDisplay pd =
                                new ProgressiveDisplay(
                                    panel_bon_sortie,
                                    100
                                );

                            pd.Start();
                        }
                        else
                        {
                            lb_not_found.Text =
                                "Aucun bon de sortie ne correspond au terme de recherche '"
                                + args[0] + "'";

                            panel_bon_sortie.Controls.Add(
                                lb_not_found
                            );

                            lb_not_found.Visible = true;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(
                        "Erreur : " + ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }


            // =========================================================
            // AFFICHAGE DE TOUS LES BONS
            // =========================================================

            else
            {
                try
                {
                    string query = @"
                SELECT
                    id_bon,
                    nom_resp,
                    montant,
                    date,
                    statut
                FROM bon_sortie
                WHERE 1 = 1
                    " + filtre + @"
                ORDER BY date DESC,
                         id_bon DESC";


                    using (MySqlDataReader reader =
                        MesClasses.ManagerClasse.CRUD(
                            query,
                            null,
                            true))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string idBon =
                                    reader["id_bon"].ToString();

                                string nomResp =
                                    reader["nom_resp"] == DBNull.Value
                                    ? ""
                                    : reader["nom_resp"].ToString();

                                string montant =
                                    reader["montant"] == DBNull.Value
                                    ? "0"
                                    : reader["montant"].ToString();

                                string dateBon =
                                    reader["date"] == DBNull.Value
                                    ? ""
                                    : reader["date"].ToString();

                                string statut =
                                    reader["statut"] == DBNull.Value
                                    ? ""
                                    : reader["statut"].ToString();


                                // =================================================
                                // CRÉATION DE LA CARTE
                                // =================================================

                                BunifuRoundedPanel panBon =
                                    CreerPanelBonSortie(
                                        idBon,
                                        nomResp,
                                        montant,
                                        dateBon,
                                        statut
                                    );


                                panel_bon_sortie.Controls.Add(
                                    panBon
                                );
                            }

                            reader.Close();

                            ProgressiveDisplay pd =
                                new ProgressiveDisplay(
                                    panel_bon_sortie,
                                    100
                                );

                            pd.Start();
                        }
                        else
                        {
                            lb_not_found.Text =
                                "Aucun bon de sortie dans le registre";

                            panel_bon_sortie.Controls.Add(
                                lb_not_found
                            );

                            lb_not_found.Visible = true;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(
                        "Erreur : " + ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private BunifuRoundedPanel CreerPanelBonSortie(
         string idBon,
         string nomResp,
         string montant,
         string dateBon,
         string statut)
        {
            // ---------------------------------------------------------
            // PANEL PRINCIPAL
            // ---------------------------------------------------------

            BunifuRoundedPanel panBon =
                new BunifuRoundedPanel();

            panBon.Size =
                new Size(290, 130);

            panBon.BorderRadius = 8;
            panBon.BorderColor = Color.Silver;
            panBon.BorderSize = 0;
            panBon.ShadowDepth = 10;
            panBon.ShadowColor = Color.Gray;

            panBon.Tag = idBon;

            panBon.Margin =
                new Padding(10);

            panBon.Padding =
                new Padding(10);


            // ---------------------------------------------------------
            // PICTUREBOX
            // ---------------------------------------------------------

            PictureBox picture =
                MesClasses.ManagerClasse.AddPicture(
                    Properties.Resources.bill,
                    new Point(15, 15),
                    new Size(55, 55)
                );

            picture.SizeMode =
                PictureBoxSizeMode.Zoom;

            panBon.Controls.Add(picture);


            // ---------------------------------------------------------
            // TITRE
            // ---------------------------------------------------------

            Label lbTitre =
                MesClasses.ManagerClasse.CustomLabel(
                    "Bon de sortie",
                    new Point(85, 18)
                );

            lbTitre.AutoSize = true;

            lbTitre.Font =
                new Font(
                    "Calibri",
                    11,
                    FontStyle.Bold
                );

            panBon.Controls.Add(lbTitre);


            // ---------------------------------------------------------
            // NUMERO DU BON
            // ---------------------------------------------------------

            Label lbNumero =
                MesClasses.ManagerClasse.CustomLabel(
                    "N° " + idBon,
                    new Point(85, 42)
                );

            lbNumero.AutoSize = true;

            lbNumero.Font =
                new Font(
                    "Calibri",
                    9,
                    FontStyle.Regular
                );

            lbNumero.ForeColor =
                Color.Gray;

            panBon.Controls.Add(lbNumero);


            // ---------------------------------------------------------
            // RESPONSABLE
            // ---------------------------------------------------------

            Label lbResponsableTitre =
                MesClasses.ManagerClasse.CustomLabel(
                    "Responsable :",
                    new Point(15, 78)
                );

            lbResponsableTitre.AutoSize = true;

            lbResponsableTitre.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold
                );

            panBon.Controls.Add(
                lbResponsableTitre
            );


            Label lbResponsable =
                MesClasses.ManagerClasse.CustomLabel(
                    nomResp,
                    new Point(110, 78)
                );

            lbResponsable.AutoSize = true;

            lbResponsable.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Regular
                );

            panBon.Controls.Add(
                lbResponsable
            );


            // ---------------------------------------------------------
            // DATE
            // ---------------------------------------------------------

            DateTime date;

            if (DateTime.TryParse(
                dateBon,
                out date))
            {
                dateBon =
                    date.ToString("dd/MM/yyyy");
            }

            Label lbDate =
                MesClasses.ManagerClasse.CustomLabel(
                    "Date : " + dateBon,
                    new Point(15, 103)
                );

            lbDate.AutoSize = true;

            lbDate.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Regular
                );

            panBon.Controls.Add(
                lbDate
            );


            // ---------------------------------------------------------
            // STATUT
            // ---------------------------------------------------------

            Label lbStatut =
                MesClasses.ManagerClasse.CustomLabel(
                    statut,
                    new Point(190, 103)
                );

            lbStatut.AutoSize = true;

            lbStatut.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold
                );


            // ---------------------------------------------------------
            // COULEUR DU STATUT
            // ---------------------------------------------------------

            if (statut == "En attente")
            {
                lbStatut.ForeColor = Color.Orange;
            }
            else if (statut == "Validé")
            {
                lbStatut.ForeColor = Color.FromArgb(0, 200, 83);
            }
            else if (statut == "Annulé")
            {
                lbStatut.ForeColor = Color.Red;
            }
            else
            {
                lbStatut.ForeColor = Color.Black;
            }

            panBon.Controls.Add(lbStatut
            );


            // ---------------------------------------------------------
            // EVENEMENT DU PANEL
            // ---------------------------------------------------------

            panBon.Cursor =
                Cursors.Hand;

            panBon.Click += (e, s) =>
            {
                MesForms.Compt.DetailBon detail = new MesForms.Compt.DetailBon(idBon);
                detail.ShowDialog();
            };


            // ---------------------------------------------------------
            // RETOUR
            // ---------------------------------------------------------

            return panBon;
        }

        private void tb_search_demande_TextChanged(object sender, EventArgs e)
        {
            LoadBonSortie(tb_search_demande.Text);
        }

        private void cbx_statut_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBonSortie();
        }

        private void bt_add_bon_Click(object sender, EventArgs e)
        {
            MesForms.Compt.Bon_de_sortie bon = new MesForms.Compt.Bon_de_sortie();
            bon.ShowDialog();
        }

        private void bt_refresh_Click(object sender, EventArgs e)
        {
            LoadBonSortie();
        }
    }
}
