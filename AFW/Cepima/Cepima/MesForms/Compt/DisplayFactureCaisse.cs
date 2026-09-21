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

namespace Cepima.MesForms.Compt
{
    public partial class DisplayFactureCaisse : Form
    {
        public DisplayFactureCaisse()
        {
            InitializeComponent();
        }

        private void DisplayFactureCaisse_Load(object sender, EventArgs e)
        {
            LoadFactures();
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

                                string dateFacture = "";

                                if (reader["date_facture"] != DBNull.Value)
                                {
                                    DateTime date =
                                        Convert.ToDateTime(reader["date_facture"]);

                                    dateFacture =
                                        date.ToString("dd/MM/yyyy");
                                }

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

                                string dateFacture = "";

                                if (reader["date_facture"] != DBNull.Value)
                                {
                                    DateTime date =
                                        Convert.ToDateTime(reader["date_facture"]);

                                    dateFacture =
                                        date.ToString("dd/MM/yyyy");
                                }

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
                new Size(300, 235);

            panFacture.BorderRadius = 8;
            panFacture.BorderColor = Color.Silver;
            panFacture.BorderSize = 0;

            panFacture.ShadowDepth = 10;
            panFacture.ShadowColor = Color.Gray;

            // On conserve les deux identifiants
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
                    new Size(55, 55)
                );

            picture.SizeMode =
                PictureBoxSizeMode.Zoom;

            panFacture.Controls.Add(picture);


            // ---------------------------------------------------------
            // TEXTE "FACTURE"
            // ---------------------------------------------------------

            Label lbFacture =
                MesClasses.ManagerClasse.CustomLabel(
                    "Facture",
                    new Point(80, 15)
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
                    new Point(170, 15)
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
                    new Point(80, 40)
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
            // TYPE DE FACTURE
            // ---------------------------------------------------------

            Label lbType =
                MesClasses.ManagerClasse.CustomLabel(
                    "Type : " + typeFacture,
                    new Point(15, 78)
                );

            lbType.AutoSize = true;

            lbType.Font =
                new System.Drawing.Font(
                    "Calibri",
                    10,
                    FontStyle.Regular
                );

            panFacture.Controls.Add(lbType);


            // ---------------------------------------------------------
            // DATE DE FACTURE
            // ---------------------------------------------------------

            Label lbDate =
                MesClasses.ManagerClasse.CustomLabel(
                    "Date : " + dateFacture,
                    new Point(155, 78)
                );

            lbDate.AutoSize = true;

            lbDate.Font =
                new System.Drawing.Font(
                    "Calibri",
                    10,
                    FontStyle.Regular
                );

            panFacture.Controls.Add(lbDate);


            // ---------------------------------------------------------
            // MONTANT TOTAL
            // ---------------------------------------------------------

            Label lbTotal =
                MesClasses.ManagerClasse.CustomLabel(
                    "Total : " + montantTotal + " $",
                    new Point(15, 105)
                );

            lbTotal.AutoSize = true;

            lbTotal.Font =
                new System.Drawing.Font(
                    "Calibri",
                    10,
                    FontStyle.Bold
                );

            panFacture.Controls.Add(lbTotal);


            // ---------------------------------------------------------
            // MONTANT PAYE
            // ---------------------------------------------------------

            Label lbPaye =
                MesClasses.ManagerClasse.CustomLabel(
                    "Payé : " + montantPaye + " $",
                    new Point(15, 128)
                );

            lbPaye.AutoSize = true;

            lbPaye.Font =
                new System.Drawing.Font(
                    "Calibri",
                    10,
                    FontStyle.Regular
                );

            panFacture.Controls.Add(lbPaye);


            // ---------------------------------------------------------
            // RESTE A PAYER
            // ---------------------------------------------------------

            Label lbReste =
                MesClasses.ManagerClasse.CustomLabel(
                    "Reste : " + reste + " $",
                    new Point(155, 128)
                );

            lbReste.AutoSize = true;

            lbReste.Font =
                new System.Drawing.Font(
                    "Calibri",
                    10,
                    FontStyle.Bold
                );

            panFacture.Controls.Add(lbReste);


            // ---------------------------------------------------------
            // STATUT
            // ---------------------------------------------------------

            Label lbStatutTitre =
                MesClasses.ManagerClasse.CustomLabel(
                    "Statut :",
                    new Point(15, 153)
                );

            lbStatutTitre.AutoSize = true;

            lbStatutTitre.Font =
                new System.Drawing.Font(
                    "Calibri",
                    9,
                    FontStyle.Bold
                );

            panFacture.Controls.Add(lbStatutTitre);


            // ---------------------------------------------------------
            // VALEUR DU STATUT
            // ---------------------------------------------------------

            Label lbStatut =
                MesClasses.ManagerClasse.CustomLabel(
                    statut,
                    new Point(70, 153)
                );

            lbStatut.AutoSize = true;

            lbStatut.Font =
                new System.Drawing.Font(
                    "Calibri",
                    10,
                    FontStyle.Bold
                );


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
                    Color.FromArgb(0, 200, 83);
            }
            else if (statut == "Partiellement payé")
            {
                lbStatut.ForeColor =
                    Color.Orange;
            }
            else if (statut == "Clôturée")
            {
                lbStatut.ForeColor =
                    Color.FromArgb(44, 123, 229);
            }
            else
            {
                lbStatut.ForeColor =
                    Color.Black;
            }

            panFacture.Controls.Add(lbStatut);


            // ---------------------------------------------------------
            // BOUTON PAYER
            // ---------------------------------------------------------

            RoundedButton btnPayer =
                MesClasses.ManagerClasse.Rbutton(
                    "Payer",
                    new Point(105, 190),
                    new Size(90, 28),
                    Color.FromArgb(0, 180, 80),
                    Color.White
                );

            btnPayer.BorderRadius = 4;
            btnPayer.BorderSize = 0;

            btnPayer.BorderColor =
                Color.FromArgb(0, 180, 80);

            btnPayer.HoverBackColor =
                Color.FromArgb(0, 120, 55);

            panFacture.Controls.Add(btnPayer);


            // ---------------------------------------------------------
            // EVENEMENT DU BOUTON PAYER
            // ---------------------------------------------------------

            btnPayer.Click += (e, s) =>
            {
                MesForms.Compt.Payement_Facture pay = new Payement_Facture(idFacture,idPatient);
                pay.ShowDialog();
            };


            // ---------------------------------------------------------
            // EVENEMENT DU PANEL
            // ---------------------------------------------------------

            panFacture.Cursor =
                Cursors.Default ;

            panFacture.Click += (e, s) =>
            {
                // Nous utiliserons idFacture ici
                // pour ouvrir le détail de la facture.
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
    }
}
