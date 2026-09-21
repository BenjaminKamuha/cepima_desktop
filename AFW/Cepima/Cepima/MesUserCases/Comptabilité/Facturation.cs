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
    public partial class Facturation : UserControl
    {
        public Facturation()
        {
            InitializeComponent();
            LoadFactures();
            rb_tout.Checked = true;
        }

        private string GetFiltreFacture()
        {
            if (rb_ambulatoire.Checked)
            {
                return " AND f.type_facture = 'Ambulatoire'";
            }

            if (rb_hospitalise.Checked)
            {
                return " AND f.type_facture = 'Hospitalisé'";
            }

            if (rb_partielle.Checked)
            {
                return " AND f.statut = 'Partiellement payé'";
            }

            return "";
        }

        private void LoadFactures(params string[] args)
        {
            panel_facture.Controls.Clear();

            // =========================================================
            // CONFIGURATION DU FLOWLAYOUTPANEL
            // =========================================================

            panel_facture.FlowDirection = FlowDirection.LeftToRight;
            panel_facture.WrapContents = true;
            panel_facture.AutoScroll = true;
            panel_facture.Padding = new Padding(10, 10, 8, 10);

            lb_not_found.Visible = false;


            // =========================================================
            // FILTRE SELON LE RADIOBUTTON
            // =========================================================

            string filtre = "";

            if (rb_ambulatoire.Checked)
            {
                filtre = " AND f.type_facture = 'Ambulatoire'";
            }
            else if (rb_hospitalise.Checked)
            {
                filtre = " AND f.type_facture = 'Hospitalisé'";
            }
            else if (rb_partielle.Checked)
            {
                filtre = " AND f.statut = 'Partiellement payé'";
            }


            // =========================================================
            // RECHERCHE D'UNE FACTURE
            // =========================================================

            if (args.Length != 0)
            {
                try
                {
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
                WHERE
                    (
                        p.nom LIKE @search
                        OR p.post_nom LIKE @search
                        OR p.prenom LIKE @search
                        OR CAST(f.id_facture AS CHAR) LIKE @search
                    )
                    " + filtre + @"
                ORDER BY f.date_facture DESC,
                         f.id_facture DESC";

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
                        int i = 0;

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string idFacture =
                                    reader["id_facture"].ToString();

                                string idPatient =
                                    reader["id_patient"].ToString();

                                string nom =
                                    reader["nom"].ToString();

                                string postnom =
                                    reader["post_nom"].ToString();

                                string prenom =
                                    reader["prenom"].ToString();

                                string typeFacture =
                                    reader["type_facture"].ToString();

                                string dateFacture =
                                    reader["date_facture"].ToString();

                                string montantTotal =
                                    reader["montant_total"].ToString();

                                string montantPaye =
                                    reader["montant_paye"].ToString();

                                string reste =
                                    reader["reste"].ToString();

                                string statut =
                                    reader["statut"].ToString();


                                // Création de la carte facture
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
                                        statut
                                    );


                                // Ajout au FlowLayoutPanel
                                panel_facture.Controls.Add(panFacture);

                                i++;
                            }

                            reader.Close();

                            ProgressiveDisplay pd =
                                new ProgressiveDisplay(
                                    panel_facture,
                                    100
                                );

                            pd.Start();
                        }
                        else
                        {
                            lb_not_found.Text =
                                "Aucune facture ne correspond au terme de recherche '"
                                + args[0] + "'";

                            panel_facture.Controls.Add(lb_not_found);

                            lb_not_found.Visible = true;

                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }


            // =========================================================
            // AFFICHAGE DE TOUTES LES FACTURES
            // =========================================================

            else
            {
                try
                {
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
                    " + filtre + @"
                ORDER BY f.date_facture DESC,
                         f.id_facture DESC";


                    using (MySqlDataReader reader =
                           MesClasses.ManagerClasse.CRUD(
                               query,
                               null,
                               true))
                    {
                        if (reader.HasRows)
                        {
                            int i = 0;

                            while (reader.Read())
                            {
                                string idFacture =
                                    reader["id_facture"].ToString();

                                string idPatient =
                                    reader["id_patient"].ToString();

                                string nom =
                                    reader["nom"].ToString();

                                string postnom =
                                    reader["post_nom"].ToString();

                                string prenom =
                                    reader["prenom"].ToString();

                                string typeFacture =
                                    reader["type_facture"].ToString();

                                string dateFacture =
                                    reader["date_facture"].ToString();

                                string montantTotal =
                                    reader["montant_total"].ToString();

                                string montantPaye =
                                    reader["montant_paye"].ToString();

                                string reste =
                                    reader["reste"].ToString();

                                string statut =
                                    reader["statut"].ToString();


                                // Création de la carte facture
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
                                        statut
                                    );


                                // Ajout au FlowLayoutPanel
                                panel_facture.Controls.Add(panFacture);

                                i++;
                            }

                            reader.Close();


                            ProgressiveDisplay pd =
                                new ProgressiveDisplay(
                                    panel_facture,
                                    100
                                );

                            pd.Start();
                        }
                        else
                        {
                            lb_not_found.Text =
                                "Aucune facture dans le registre";

                            panel_facture.Controls.Add(lb_not_found);

                            lb_not_found.Visible = true;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private BunifuRoundedPanel CreerPanelFacture(string idFacture,string idPatient,string nom,string postnom,string prenom,string typeFacture,string dateFacture,string montantTotal,string montantPaye,string reste,string statut)
        {
            // ---------------------------------------------------------
            // PANEL PRINCIPAL
            // --------------------------------------------------------

            BunifuRoundedPanel panFacture = new BunifuRoundedPanel();
            panFacture.Size = new Size(290, 135);

            panFacture.BorderRadius = 8;
            panFacture.BorderColor = Color.Silver;
            panFacture.BorderSize = 0;
            panFacture.ShadowDepth = 10;
            panFacture.ShadowColor = Color.Gray;

            panFacture.Tag = idFacture;

            panFacture.Margin =
                new Padding(10);

            panFacture.Padding =
                new Padding(10);


            // ---------------------------------------------------------
            // PICTUREBOX
            // ---------------------------------------------------------

            PictureBox picture =
                MesClasses.ManagerClasse.AddPicture(
                    Properties.Resources.bill,
                    new Point(15, 15),
                    new Size(60, 60)
                );

            picture.SizeMode = PictureBoxSizeMode.Zoom;
            panFacture.Controls.Add(picture);


            // ---------------------------------------------------------
            // TEXTE "FACTURE"
            // ---------------------------------------------------------

            Label lbFacture =
                MesClasses.ManagerClasse.CustomLabel(
                    "Facture",
                    new Point(90, 18)
                );

            lbFacture.AutoSize = true;

            lbFacture.Font =
                new System.Drawing.Font(
                    "Calibri",
                    10,
                    FontStyle.Bold
                );

            panFacture.Controls.Add(lbFacture);


            // ---------------------------------------------------------
            // NUMERO DE FACTURE
            // ---------------------------------------------------------

            Label lbNumero =
                MesClasses.ManagerClasse.CustomLabel(
                    "N° " + idFacture,
                    new Point(175, 18)
                );

            lbNumero.AutoSize = true;

            lbNumero.Font =
                new System.Drawing.Font(
                    "Calibri",
                    10,
                    FontStyle.Bold
                );

            panFacture.Controls.Add(lbNumero);


            // ---------------------------------------------------------
            // NOM DU PATIENT
            // ---------------------------------------------------------

            string nomPatient =
                (nom + " " + postnom + " " + prenom).Trim();

            Label lbPatient =
                MesClasses.ManagerClasse.CustomLabel(
                    nomPatient,
                    new Point(90, 48)
                );

            lbPatient.AutoSize = true;

            lbPatient.Font =
                new System.Drawing.Font(
                    "Calibri",
                    10,
                    FontStyle.Bold
                );

            panFacture.Controls.Add(lbPatient);


            // ---------------------------------------------------------
            // STATUT
            // ---------------------------------------------------------

            Label lbStatutTitre =
                MesClasses.ManagerClasse.CustomLabel(
                    "Statut:",
                    new Point(15, 98)
                );

            lbStatutTitre.AutoSize = true;

            lbStatutTitre.Font =
                new System.Drawing.Font(
                    "Calibri",
                    10,
                    FontStyle.Bold
                );

            panFacture.Controls.Add(lbStatutTitre);


            // ---------------------------------------------------------
            // VALEUR DU STATUT
            // ---------------------------------------------------------

            Label lbStatut =
                MesClasses.ManagerClasse.CustomLabel(
                    statut,
                    new Point(75, 98)
                );

            lbStatut.AutoSize = true;

            lbStatut.Font =
                new System.Drawing.Font(
                    "Calibri",
                    10,
                    FontStyle.Bold
                );


            // Couleur selon le statut
            if (statut == "Non payé")
            {
                lbStatut.ForeColor = Color.Red;
            }
            else if (statut == "Payé")
            {
                lbStatut.ForeColor = Color.FromArgb(0, 200, 83);
            }
            else if (statut == "Partiellement payé")
            {
                lbStatut.ForeColor = Color.Orange;
            }
            else if (statut == "Clôturée")
            {
                lbStatut.ForeColor =
                    Color.FromArgb(44, 123, 229);
            }
            else
            {
                lbStatut.ForeColor = Color.Black;
            }

            panFacture.Controls.Add(lbStatut);


            // ---------------------------------------------------------
            // EVENEMENT DU PANEL
            // ---------------------------------------------------------

            panFacture.Cursor =
                Cursors.Hand;

            panFacture.Click += (e, s) =>
            {
                MessageBox.Show("Afficher la facture");
                MesForms.FormFacturePrint facture = new MesForms.FormFacturePrint(Convert.ToInt32(idFacture));
                facture.ShowDialog();
            };


            // ---------------------------------------------------------
            // RETOUR DU PANEL
            // ---------------------------------------------------------

            return panFacture;
        }

        private void tb_search_demande_TextChanged(object sender, EventArgs e)
        {
            LoadFactures(tb_search_demande.Text);
        }

        private void rb_tout_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_tout.Checked)
            {
                LoadFactures();
            }
        }

        private void rb_ambulatoire_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_ambulatoire.Checked)
            {
                LoadFactures();
            }
        }

        private void rb_hospitalise_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_hospitalise.Checked)
            {
                LoadFactures();
            }
        }

        private void rb_partielle_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_partielle.Checked)
            {
                LoadFactures();
            }
        }
    }
}
