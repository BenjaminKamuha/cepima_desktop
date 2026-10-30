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
using System.Globalization;
namespace Cepima.MesUserCases.Personnels
{
    public partial class User_Salaire_personnel : UserControl
    {
        private string typeOperation = "Salaire";
        private Color couleurActive = Color.FromArgb(80, 180, 255);
        private Color couleurNormale = Color.White;
        private Color couleurTexteActive = Color.FromArgb(0, 80, 160);
        private Color couleurTexteNormale = Color.FromArgb(40, 40, 40);

        private int idPersonnelSelectionne = 0;
        private BunifuRoundedPanel panelPersonnelSelectionne = null;
        private Color couleurPanelNormale = Color.White;
        private Color couleurPanelSelectionne = Color.FromArgb(220, 235, 252);

        public User_Salaire_personnel()
        {
            InitializeComponent();
            LoadPersonnel();
         
            panelSalaireBase.BackColor = ColorTranslator.FromHtml("#176FC1");
            panelTotalPrimes.BackColor = ColorTranslator.FromHtml("#168653");
            panelTotalRetenues.BackColor = ColorTranslator.FromHtml("#C93636");
            panelTotalAvances.BackColor = ColorTranslator.FromHtml("#7046B8");
            panelSalaireNet.BackColor = ColorTranslator.FromHtml("#087F83");

            roundedButton1.DefaultBackColor = ColorTranslator.FromHtml("#168653");
            roundedButton1.BorderColor = ColorTranslator.FromHtml("#168653");
            roundedButton1.HoverBackColor = ColorTranslator.FromHtml("#087F83");
        }

        private void ChargerStatistiquesSalaire()
        {
            // Aucun personnel sélectionné : remettre les panneaux à zéro.
            if (idPersonnelSelectionne <= 0)
            {
                lbMontantSalaireBase.Text = "0,00";
                lbMontantTotalPrimes.Text = "0,00";
                lbMontantTotalRetenues.Text = "0,00";
                lbMontantTotalAvances.Text = "0,00";
                lbMontantSalaireNet.Text = "0,00";
                return;
            }

            try
            {
                string requete = @"
            SELECT
                COALESCE(SUM(s.salaire_base), 0) AS total_base,

                COALESCE((
                    SELECT SUM(p.montant)
                    FROM prime p
                    INNER JOIN salaires sp ON sp.id_salaire = p.id_salaire
                    WHERE sp.id_personnel = @idPersonnel
                    AND (@toutesPeriodes = 1 OR sp.mois = @mois)
                ), 0) AS total_primes,

                COALESCE((
                    SELECT SUM(r.montant)
                    FROM retenue r
                    INNER JOIN salaires sr ON sr.id_salaire = r.id_salaire
                    WHERE sr.id_personnel = @idPersonnel
                    AND (@toutesPeriodes = 1 OR sr.mois = @mois)
                ), 0) AS total_retenues,

                COALESCE((
                    SELECT SUM(a.montant)
                    FROM avances_salaire a
                    INNER JOIN salaires sa ON sa.id_salaire = a.id_salaire
                    WHERE sa.id_personnel = @idPersonnel
                    AND (@toutesPeriodes = 1 OR sa.mois = @mois)
                ), 0) AS total_avances

            FROM salaires s
            WHERE s.id_personnel = @idPersonnel
            AND (@toutesPeriodes = 1 OR s.mois = @mois)";

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddWithValue("@idPersonnel", idPersonnelSelectionne);
                    commande.Parameters.AddWithValue("@toutesPeriodes",
                        cbPeriode.SelectedIndex == 0 ? 1 : 0);
                    commande.Parameters.AddWithValue("@mois",
                        cbPeriode.SelectedIndex == 0 ? "" : cbPeriode.Text);

                    using (MySqlDataReader reader = commande.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal salaireBase = Convert.ToDecimal(reader["total_base"]);
                            decimal totalPrimes = Convert.ToDecimal(reader["total_primes"]);
                            decimal totalRetenues = Convert.ToDecimal(reader["total_retenues"]);
                            decimal totalAvances = Convert.ToDecimal(reader["total_avances"]);

                            decimal salaireNet = salaireBase + totalPrimes
                                                 - totalRetenues - totalAvances;

                            lbMontantSalaireBase.Text = salaireBase.ToString("N2") + "$";
                            lbMontantTotalPrimes.Text = totalPrimes.ToString("N2") + "$";
                            lbMontantTotalRetenues.Text = totalRetenues.ToString("N2") + "$";
                            lbMontantTotalAvances.Text = totalAvances.ToString("N2") + "$";
                            lbMontantSalaireNet.Text = salaireNet.ToString("N2") + "$";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du calcul des statistiques salariales :\n" + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void SelectionnerOnglet(Label onglet, string texteBouton)
        {
            Label[] onglets = { lb_salaire, lb_primes, lb_retenues, lb_avances };

            foreach (Label lbl in onglets)
            {
                lbl.ForeColor = Color.FromArgb(40, 40, 40);
                lbl.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            }

            onglet.ForeColor = Color.FromArgb(0, 120, 215);
            onglet.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            panel_moove.Width = onglet.Width;
            panel_moove.Height = 4;
            panel_moove.Left = onglet.Left;
            panel_moove.Top = onglet.Bottom + 2;
            panel_moove.BackColor = Color.FromArgb(0, 160, 255);
            panel_moove.BringToFront();

            bt_operation.Text = texteBouton;
        }
        private void LoadPersonnel(params string[] args)
        {
            string recherche = (args != null && args.Length > 0 && args[0] != null) ? args[0].Trim() : "";
            BunifuRoundedPanel premierPersonnel = null;
            try
            {
                flowEleves.Controls.Clear();
            
                lb_not_found.Visible = false;

                string query = @"SELECT id_personnel, nom, post_nom, prenom,fonction FROM personnels e WHERE 1 = 1";

                if (recherche.Length > 0)
                    query += @" AND (nom LIKE @search OR post_nom LIKE @search OR prenom LIKE @search)";

                query += " ORDER BY nom ASC, post_nom ASC, prenom ASC";

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                using (MySqlCommand commande = new MySqlCommand(query, connexion))
                {
                    if (recherche.Length > 0)
                        commande.Parameters.AddWithValue("@search", "%" + recherche + "%");

                    using (MySqlDataReader reader = commande.ExecuteReader())
                    {
                        bool trouve = false;

                        while (reader.Read())
                        {
                            trouve = true;
                            string idEleve = reader.GetString("id_personnel");
                            string nom = reader.GetString("nom");
                            string postnom = reader.GetString("post_nom");
                            string prenom = reader.GetString("prenom");
                            string fonction = reader.GetString("fonction");
                            BunifuRoundedPanel panEleve = CreerPanelEleve(idEleve, nom, postnom, prenom, fonction);

                            flowEleves.Controls.Add(panEleve);

                            // Mémoriser la première carte
                            if (premierPersonnel == null)
                                premierPersonnel = panEleve;
                        }

                        if (!trouve)
                        {
                            lb_not_found.Text = recherche.Length > 0
                                ? "Aucun élève ne correspond au terme '" + recherche + "'."
                                : "Aucun élève enregistré.";

                            flowEleves.Controls.Add(lb_not_found);
                            lb_not_found.Visible = true;
                        }
                    }
                    // Sélection automatique du premier personnel
                    if (premierPersonnel != null)
                    {
                        int id = Convert.ToInt32(premierPersonnel.Tag);
                        SelectionnerPersonnel(id, premierPersonnel);
                    }
                    else
                    {
                        idPersonnelSelectionne = 0;
                        panelPersonnelSelectionne = null;

                        lbMontantSalaireBase.Text = "0,00 $";
                        lbMontantTotalPrimes.Text = "0,00 $";
                        lbMontantTotalRetenues.Text = "0,00 $";
                        lbMontantTotalAvances.Text = "0,00 $";
                        lbMontantSalaireNet.Text = "0,00 $";

                        dgv_operations.Rows.Clear();
                    }
                }

                //if (flowEleves.Controls.Count > 0 && !lb_not_found.Visible)
                //{
                //    MesClasses.ProgressiveDisplay pd = new MesClasses.ProgressiveDisplay(flowEleves, 100);
                //    pd.Start();

                //}
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur MySQL :\n\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des élèves :\n\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                flowEleves.ResumeLayout();
            }
        }

        //Creér les cartes automatiquement grace à la méthode
        private BunifuRoundedPanel CreerPanelEleve(string idEleve, string nom, string postnom, string prenom, string fonction)
        {
            BunifuRoundedPanel panEleve = new BunifuRoundedPanel();

            panEleve.Size = new Size(240, 90);
            panEleve.BorderRadius = 8;
            panEleve.BorderColor = Color.Silver;
            panEleve.BorderSize = 0;
            panEleve.ShadowDepth = 6;
            panEleve.ShadowColor = Color.Gray;
            panEleve.Tag = idEleve;
            panEleve.Padding = new Padding(15);
            panEleve.BackColor = couleurPanelNormale;

            string nomComplet = (postnom + " " + prenom).Trim();

            PictureBox picture = MesClasses.ManagerClasse.AddPicture(
                Properties.Resources.user,
                new Point(15, 15),
                new Size(60, 60));

            picture.SizeMode = PictureBoxSizeMode.Zoom;
            panEleve.Controls.Add(picture);

            Label lbTitre = MesClasses.ManagerClasse.CustomLabel(nom, new Point(90, 18));
            lbTitre.AutoSize = true;
            lbTitre.Font = new Font("Calibri", 10, FontStyle.Bold);
            lbTitre.ForeColor = Color.FromArgb(23, 43, 77);
            panEleve.Controls.Add(lbTitre);

            Label lbNom = MesClasses.ManagerClasse.CustomLabel(nomComplet, new Point(90, 40));
            lbNom.AutoSize = true;
            lbNom.Font = new Font("Calibri", 10, FontStyle.Bold);
            lbNom.ForeColor = Color.FromArgb(23, 43, 77);
            panEleve.Controls.Add(lbNom);

            Label lbtext = MesClasses.ManagerClasse.CustomLabel(fonction, new Point(90, 65));
            lbtext.AutoSize = true;
            lbtext.Font = new Font("Calibri", 10, FontStyle.Bold);
            lbtext.ForeColor = Color.FromArgb(23, 43, 77);
            panEleve.Controls.Add(lbtext);

            // Sélection du personnel
            EventHandler ouvrirEleve = delegate(object sender, EventArgs e)
            {
               
                try
                {
                    int id = Convert.ToInt32(panEleve.Tag);

                    SelectionnerPersonnel(id, panEleve);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Impossible de sélectionner le personnel :\n\n" + ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            };

            // Le clic sur la carte, la photo ou les textes sélectionne le personnel
            panEleve.Click += ouvrirEleve;
            picture.Click += ouvrirEleve;
            lbTitre.Click += ouvrirEleve;
            lbNom.Click += ouvrirEleve;
            lbtext.Click += ouvrirEleve;

            return panEleve;
        }

        private void tb_num_fiche_TextChanged(object sender, EventArgs e)
        {
            flowEleves.Controls.Clear();
            LoadPersonnel(tb_num_fiche.Text);
        }
        // evolution du salaiure net

        private void ChargerEvolutionSalaireNet()
        {
            if (idPersonnelSelectionne <= 0 || cbPeriode.SelectedIndex < 0)
                return;

            try
            {
                CultureInfo culture = new CultureInfo("fr-FR");

                List<string> periodes = new List<string>();

                if (ToutesLesPeriodes)
                {
                    string requetePeriodes = @"
                SELECT mois, MIN(date_paiement) AS ordre
                FROM salaires
                WHERE id_personnel = @idPersonnel
                GROUP BY mois
                ORDER BY ordre";

                    using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                    using (MySqlCommand commande = new MySqlCommand(requetePeriodes, connexion))
                    {
                        commande.Parameters.AddWithValue("@idPersonnel", idPersonnelSelectionne);

                        using (MySqlDataReader reader = commande.ExecuteReader())
                        {
                            while (reader.Read())
                                periodes.Add(reader["mois"].ToString());
                        }
                    }
                }
                else
                {
                    DateTime periode = DateTime.ParseExact(
                        cbPeriode.Text,
                        "MMMM yyyy",
                        culture
                    );

                    for (int i = 5; i >= 0; i--)
                        periodes.Add(periode.AddMonths(-i).ToString("MMMM yyyy", culture));
                }

                List<string> mois = new List<string>();
                List<double> montants = new List<double>();

                if (periodes.Count > 0)
                {
                    string[] parametres = new string[periodes.Count];

                    for (int i = 0; i < periodes.Count; i++)
                        parametres[i] = "@mois" + i;

                    string requete = @"
                SELECT
                    s.mois,
                    MIN(s.date_paiement) AS ordre,
                    SUM(
                        s.salaire_base
                        + COALESCE((
                            SELECT SUM(p.montant)
                            FROM prime p
                            WHERE p.id_salaire = s.id_salaire
                        ), 0)
                        - COALESCE((
                            SELECT SUM(r.montant)
                            FROM retenue r
                            WHERE r.id_salaire = s.id_salaire
                        ), 0)
                        - COALESCE((
                            SELECT SUM(a.montant)
                            FROM avances_salaire a
                            WHERE a.id_salaire = s.id_salaire
                        ), 0)
                    ) AS salaire_net
                FROM salaires s
                WHERE s.id_personnel = @idPersonnel
                AND s.mois IN (" + string.Join(",", parametres) + @")
                GROUP BY s.mois
                ORDER BY ordre";

                    Dictionary<string, double> donnees =
                        new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);

                    using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                    using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                    {
                        commande.Parameters.AddWithValue("@idPersonnel", idPersonnelSelectionne);

                        for (int i = 0; i < periodes.Count; i++)
                            commande.Parameters.AddWithValue("@mois" + i, periodes[i]);

                        using (MySqlDataReader reader = commande.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                donnees[reader["mois"].ToString()] =
                                    Convert.ToDouble(reader["salaire_net"]);
                            }
                        }
                    }

                    foreach (string periode in periodes)
                    {
                        mois.Add(periode);

                        montants.Add(
                            donnees.ContainsKey(periode) ? donnees[periode] : 0
                        );
                    }
                }

                monGraphiqueClasses.Titre = "Évolution du salaire net";
                monGraphiqueClasses.CouleurFond = Color.White;
                monGraphiqueClasses.AfficherLegende = false;

                monGraphiqueClasses.AjouterHistogramme(
                    "Salaire net",
                    mois,
                    montants
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur graphique évolution :\n" + ex.Message);
            }
        }

        private void ChargerRepartitionSalaire()
        {
            if (idPersonnelSelectionne <= 0 || cbPeriode.SelectedIndex < 0)
                return;

            try
            {
                decimal salaireBase = 0;
                decimal primes = 0;
                decimal retenues = 0;
                decimal avances = 0;

                string requete = @"
            SELECT
                COALESCE((
                    SELECT SUM(s.salaire_base)
                    FROM salaires s
                    WHERE s.id_personnel = @idPersonnel
                    AND (@toutesPeriodes = 1 OR s.mois = @mois)
                ), 0) AS total_base,

                COALESCE((
                    SELECT SUM(p.montant)
                    FROM prime p
                    INNER JOIN salaires s ON s.id_salaire = p.id_salaire
                    WHERE s.id_personnel = @idPersonnel
                    AND (@toutesPeriodes = 1 OR s.mois = @mois)
                ), 0) AS total_primes,

                COALESCE((
                    SELECT SUM(r.montant)
                    FROM retenue r
                    INNER JOIN salaires s ON s.id_salaire = r.id_salaire
                    WHERE s.id_personnel = @idPersonnel
                    AND (@toutesPeriodes = 1 OR s.mois = @mois)
                ), 0) AS total_retenues,

                COALESCE((
                    SELECT SUM(a.montant)
                    FROM avances_salaire a
                    INNER JOIN salaires s ON s.id_salaire = a.id_salaire
                    WHERE s.id_personnel = @idPersonnel
                    AND (@toutesPeriodes = 1 OR s.mois = @mois)
                ), 0) AS total_avances";

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddWithValue("@idPersonnel", idPersonnelSelectionne);
                    commande.Parameters.AddWithValue("@toutesPeriodes", ToutesLesPeriodes ? 1 : 0);
                    commande.Parameters.AddWithValue("@mois", ToutesLesPeriodes ? "" : cbPeriode.Text);

                    using (MySqlDataReader reader = commande.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            salaireBase = Convert.ToDecimal(reader["total_base"]);
                            primes = Convert.ToDecimal(reader["total_primes"]);
                            retenues = Convert.ToDecimal(reader["total_retenues"]);
                            avances = Convert.ToDecimal(reader["total_avances"]);
                        }
                    }
                }

                monGraphique.Titre = "Répartition des montants du salaire";
                monGraphique.AfficherLegende = true;

                monGraphique.AjouterGraphiqueCirculaire(
                    "Salaire de base", Convert.ToDouble(salaireBase),
                    "Primes", Convert.ToDouble(primes),
                    "Retenues", Convert.ToDouble(retenues),
                    "Avances", Convert.ToDouble(avances),
                    "Autres", 0
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur graphique répartition :\n" + ex.Message);
            }
        }

        private void ChargerGraphiques()
        {
            ChargerEvolutionSalaireNet();
            ChargerRepartitionSalaire();
        }
        private void SelectionnerPersonnel(int id, BunifuRoundedPanel panel)
        {
            if (panelPersonnelSelectionne != null)
                panelPersonnelSelectionne.BackColor = couleurPanelNormale;

            idPersonnelSelectionne = id;
            panelPersonnelSelectionne = panel;
            panelPersonnelSelectionne.BackColor = couleurPanelSelectionne;

            ChargerPeriodes();

            cbPeriode.SelectedIndex = 0;

            ChargerStatistiquesSalaire();
            RechargerOngletActif();
            ChargerGraphiques();
        }
        private void User_Salaire_personnel_Load(object sender, EventArgs e)
        {
            
            SelectionnerOnglet(lb_salaire, "Ajouter un salaire");
            lb_salaire.Click += delegate
            {
                typeOperation = "Salaire";
                SelectionnerOnglet(lb_salaire, "Ajouter un salaire");
                ChargerSalaires();
            };

            lb_primes.Click += delegate
            {
                typeOperation = "Prime";
                SelectionnerOnglet(lb_primes, "Ajouter une prime");
                ChargerPrimes();
            };

            lb_retenues.Click += delegate
            {
                typeOperation = "Retenue";
                SelectionnerOnglet(lb_retenues, "Ajouter une retenue");
                ChargerRetenues();
            };

            lb_avances.Click += delegate
            {
                typeOperation = "Avance";
                SelectionnerOnglet(lb_avances, "Ajouter une avance");
                ChargerAvances();
            };
        }

        private void bt_operation_Click(object sender, EventArgs e)
        {

            if (idPersonnelSelectionne <= 0)
            {
                MessageBox.Show(
                    "Veuillez d'abord sélectionner un personnel.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            switch (typeOperation)
            {
                case "Salaire":
                    using (MesForms.Personnel.Ajouter_salaire formulaire = new MesForms.Personnel.Ajouter_salaire(idPersonnelSelectionne))
                    {
                        if (formulaire.ShowDialog() == DialogResult.OK)
                        {
                            ChargerSalaires();
                            // Actualiser les cinq panneaux récapitulatifs
                        }
                    }
                    break;

                case "Prime":
                    using (MesForms.Personnel.Ajouter_prime formulaire = new MesForms.Personnel.Ajouter_prime(idPersonnelSelectionne))
                    {
                        if (formulaire.ShowDialog() == DialogResult.OK)
                        {
                            ChargerPrimes();
                            // Actualiser les cinq panneaux récapitulatifs
                        }
                    }
                    break;

                case "Avance":
                    using (MesForms.Personnel.Ajouter_Avance formulaire = new MesForms.Personnel.Ajouter_Avance(idPersonnelSelectionne))
                    {
                        if (formulaire.ShowDialog() == DialogResult.OK)
                        {
                            ChargerAvances();
                        }
                    }
                    break;

                case "Retenue":
                    MessageBox.Show("Ouverture du formulaire d'ajout d'une retenue.",
                        "Avance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void ChargerSalaires()
        {
            try
            {
                dgv_operations.Rows.Clear();
                dgv_operations.Columns.Clear();

                dgv_operations.Columns.Add("colID", "ID");
                dgv_operations.Columns.Add("colMois", "Mois");
                dgv_operations.Columns.Add("colDate", "Date de paiement");
                dgv_operations.Columns.Add("colMontant", "Salaire de base");
                dgv_operations.Columns.Add("colStatut", "Statut");

                if (idPersonnelSelectionne > 0)
                {
                    string requete = "SELECT id_salaire, mois, date_paiement, salaire_base, statut FROM salaires WHERE id_personnel = @idPersonnel AND (@toutesPeriodes = 1 OR mois = @mois)";

                    using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                    using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                    {
                        commande.Parameters.AddWithValue("@idPersonnel", idPersonnelSelectionne);
                        commande.Parameters.AddWithValue("@toutesPeriodes", ToutesLesPeriodes ? 1 : 0);
                        commande.Parameters.AddWithValue("@mois", ToutesLesPeriodes ? "" : cbPeriode.Text);
                        using (MySqlDataReader reader = commande.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgv_operations.Rows.Add(
                                    reader["id_salaire"],
                                    reader["mois"],
                                    Convert.ToDateTime(reader["date_paiement"]).ToString("dd/MM/yyyy"),
                                    Convert.ToDecimal(reader["salaire_base"]).ToString("N2"),
                                    reader["statut"]
                                );
                            }
                        }
                    }
                }

                // Ajouter les icônes après le chargement des lignes
                AjouterBoutonsActions();

                // Appliquer le style et les largeurs
                ConfigurerGrille();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des salaires :\n" + ex.Message);
            }
        }
        private void ChargerPrimes()
        {
            try
            {
                dgv_operations.Rows.Clear();
                dgv_operations.Columns.Clear();

                dgv_operations.Columns.Add("colID", "ID");
                dgv_operations.Columns.Add("colDate", "Date");
                dgv_operations.Columns.Add("colMotif", "Motif");
                dgv_operations.Columns.Add("colMontant", "Montant");

                if (idPersonnelSelectionne <= 0)
                    return;

                string requete = @"SELECT pr.id_prime, pr.date_prime, pr.motif, pr.montant
                           FROM prime pr
                           INNER JOIN salaires s ON s.id_salaire = pr.id_salaire
                           WHERE s.id_personnel = @idPersonnel
                            AND (@toutesPeriodes = 1 OR s.mois = @mois)";

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddWithValue("@idPersonnel", idPersonnelSelectionne);
                    commande.Parameters.AddWithValue("@toutesPeriodes", ToutesLesPeriodes ? 1 : 0);
                    commande.Parameters.AddWithValue("@mois", ToutesLesPeriodes ? "" : cbPeriode.Text);

                    using (MySqlDataReader reader = commande.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgv_operations.Rows.Add(
                                reader["id_prime"],
                                reader["date_prime"] == DBNull.Value ? "" : Convert.ToDateTime(reader["date_prime"]).ToString("dd/MM/yyyy"),
                                reader["motif"],
                                reader["montant"] == DBNull.Value ? "0,00" : Convert.ToDecimal(reader["montant"]).ToString("N2")
                            );
                        }
                        // Ajouter les icônes après le chargement des lignes
                        AjouterBoutonsActions();

                        // Appliquer le style et les largeurs
                        ConfigurerGrille();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des primes :\n" + ex.Message);
            }
        }

        private void ChargerRetenues()
        {
            try
            {
                dgv_operations.Rows.Clear();
                dgv_operations.Columns.Clear();

                dgv_operations.Columns.Add("colID", "ID");
                dgv_operations.Columns.Add("colDate", "Date");
                dgv_operations.Columns.Add("colMotif", "Motif");
                dgv_operations.Columns.Add("colMontant", "Montant");
                dgv_operations.Columns.Add("colPresence", "ID présence");

                if (idPersonnelSelectionne <= 0)
                    return;

                string requete = @"SELECT r.id_retenue, r.date_retenue, r.motif, r.montant, r.id_presence
                           FROM retenue r
                           INNER JOIN salaires s ON s.id_salaire = r.id_salaire
                           WHERE s.id_personnel = @idPersonnel
                            AND (@toutesPeriodes = 1 OR s.mois = @mois)";

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddWithValue("@idPersonnel", idPersonnelSelectionne);
                    commande.Parameters.AddWithValue("@toutesPeriodes", ToutesLesPeriodes ? 1 : 0);
                    commande.Parameters.AddWithValue("@mois", ToutesLesPeriodes ? "" : cbPeriode.Text);

                    using (MySqlDataReader reader = commande.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgv_operations.Rows.Add(
                                reader["id_retenue"],
                                reader["date_retenue"] == DBNull.Value ? "" : Convert.ToDateTime(reader["date_retenue"]).ToString("dd/MM/yyyy"),
                                reader["motif"],
                                reader["montant"] == DBNull.Value ? "0,00" : Convert.ToDecimal(reader["montant"]).ToString("N2"),
                                reader["id_presence"] == DBNull.Value ? "" : reader["id_presence"].ToString()
                            );
                        }
                        // Ajouter les icônes après le chargement des lignes
                        AjouterBoutonsActions();

                        // Appliquer le style et les largeurs
                        ConfigurerGrille();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des retenues :\n" + ex.Message);
            }
        }

        private void ChargerAvances()
        {
            try
            {
                dgv_operations.Rows.Clear();
                dgv_operations.Columns.Clear();

                dgv_operations.Columns.Add("colID", "ID");
                dgv_operations.Columns.Add("colDate", "Date");
                dgv_operations.Columns.Add("colMontant", "Montant");
                dgv_operations.Columns.Add("colReste", "Reste");

                if (idPersonnelSelectionne <= 0)
                    return;

                string requete = @"SELECT a.id_avance, a.date_avance, a.montant, a.reste
                           FROM avances_salaire a
                           INNER JOIN salaires s ON s.id_salaire = a.id_salaire
                           WHERE s.id_personnel = @idPersonnel
                            AND (@toutesPeriodes = 1 OR s.mois = @mois)";

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddWithValue("@idPersonnel", idPersonnelSelectionne);
                    commande.Parameters.AddWithValue("@toutesPeriodes", ToutesLesPeriodes ? 1 : 0);
                    commande.Parameters.AddWithValue("@mois", ToutesLesPeriodes ? "" : cbPeriode.Text);
                    using (MySqlDataReader reader = commande.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgv_operations.Rows.Add(
                                reader["id_avance"],
                                reader["date_avance"] == DBNull.Value ? "" : Convert.ToDateTime(reader["date_avance"]).ToString("dd/MM/yyyy"),
                                reader["montant"] == DBNull.Value ? "0,00" : Convert.ToDecimal(reader["montant"]).ToString("N2"),
                                reader["reste"] == DBNull.Value ? "0,00" : Convert.ToDecimal(reader["reste"]).ToString("N2")
                            );
                        }
                        // Ajouter les icônes après le chargement des lignes
                        AjouterBoutonsActions();

                        // Appliquer le style et les largeurs
                        ConfigurerGrille();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des avances :\n" + ex.Message);
            }
        }

        private void ConfigurerGrille()
        {
            dgv_operations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv_operations.AllowUserToAddRows = false;
            dgv_operations.ReadOnly = false;
            dgv_operations.RowTemplate.Height = 30;
            dgv_operations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_operations.MultiSelect = false;
            dgv_operations.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgv_operations.ColumnHeadersHeight = 40;
            dgv_operations.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv_operations.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgv_operations.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 252);
            dgv_operations.DefaultCellStyle.SelectionForeColor = Color.FromArgb(23, 43, 77);

            // Ajuster les largeurs selon les noms réels des colonnes
            if (dgv_operations.Columns.Contains("colID"))
                dgv_operations.Columns["colID"].Width = 40;

            if (dgv_operations.Columns.Contains("colMois"))
                dgv_operations.Columns["colMois"].Width = 120;

            if (dgv_operations.Columns.Contains("colDate"))
                dgv_operations.Columns["colDate"].Width = 160;

            if (dgv_operations.Columns.Contains("colMontant"))
                dgv_operations.Columns["colMontant"].Width = 160;

            if (dgv_operations.Columns.Contains("colStatut"))
                dgv_operations.Columns["colStatut"].Width = 95;

            if (dgv_operations.Columns.Contains("colModifier"))
                dgv_operations.Columns["colModifier"].Width = 40;

            if (dgv_operations.Columns.Contains("colSupprimer"))
                dgv_operations.Columns["colSupprimer"].Width = 40;
         
        }

        private void AjouterBoutonsActions()
        {
            if (!dgv_operations.Columns.Contains("colModifier"))
            {
                DataGridViewImageColumn modifier = new DataGridViewImageColumn();
                modifier.Name = "colModifier";
                modifier.HeaderText = "";
                modifier.Image = Properties.Resources.time_machine_30px;
                modifier.ImageLayout = DataGridViewImageCellLayout.Zoom;
                modifier.Width = 20;
                modifier.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                modifier.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                modifier.ToolTipText = "Modifier";
                dgv_operations.Columns.Add(modifier);
            }

            if (!dgv_operations.Columns.Contains("colSupprimer"))
            {
                DataGridViewImageColumn supprimer = new DataGridViewImageColumn();
                supprimer.Name = "colSupprimer";
                supprimer.HeaderText = "";
                supprimer.Image = Properties.Resources.trash_red;
                supprimer.ImageLayout = DataGridViewImageCellLayout.Zoom;
                supprimer.Width = 20;
                supprimer.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                supprimer.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                supprimer.ToolTipText = "Supprimer";
                dgv_operations.Columns.Add(supprimer);
            }
        }

        private void dgv_operations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string colonne = dgv_operations.Columns[e.ColumnIndex].Name;

            if (colonne != "colModifier" && colonne != "colSupprimer")
                return;

            if (dgv_operations.Rows[e.RowIndex].Cells["colID"].Value == null)
                return;

            int idOperation = Convert.ToInt32(
                dgv_operations.Rows[e.RowIndex].Cells["colID"].Value);

            if (colonne == "colModifier")
            {
                switch (typeOperation)
                {
                    case "Salaire":
                        ModifierSalaire(idOperation);
                        break;
                    case "Prime":
                        ModifierPrime(idOperation);
                        break;
                    case "Retenue":
                        //ModifierRetenue(idOperation);
                        break;
                    case "Avance":
                        ModifierAvance(idOperation);
                        break;
                }
            }
            else
            {
                switch (typeOperation)
                {
                    case "Salaire":
                        SupprimerSalaire(idOperation);
                        break;
                    case "Prime":
                        SupprimerPrime(idOperation);
                        break;
                    case "Retenue":
                        SupprimerRetenue(idOperation);
                        break;
                    case "Avance":
                        SupprimerAvance(idOperation);
                        break;
                }
            }
        }

        private void ModifierSalaire(int idSalaire)
        {
            using (MesForms.Personnel.Ajouter_salaire formulaire = new MesForms.Personnel.Ajouter_salaire(idPersonnelSelectionne, idSalaire))
            {
                if (formulaire.ShowDialog() == DialogResult.OK)
                {
                    ChargerSalaires();

                    // Nous ajouterons ici l'actualisation des 5 panneaux.
                }
            }
        }

        private void ModifierPrime(int idPrime)
        {
            using (MesForms.Personnel.Ajouter_prime formulaire = new MesForms.Personnel.Ajouter_prime(idPersonnelSelectionne))
            {
                if (formulaire.ShowDialog() == DialogResult.OK)
                {
                    ChargerPrimes();
                }
            }
        }

        private void ModifierAvance(int idAvance)
        {
            using (MesForms.Personnel.Ajouter_Avance formulaire = new MesForms.Personnel.Ajouter_Avance(idPersonnelSelectionne, idAvance))
            {
                if (formulaire.ShowDialog() == DialogResult.OK)
                {
                    ChargerAvances();
                }
            }
        }
        private void SupprimerSalaire(int idSalaire)
        {
            SupprimerOperation("Salaire", idSalaire);
        }

        private void SupprimerPrime(int idPrime)
        {
            SupprimerOperation("Prime", idPrime);
        }

        private void SupprimerRetenue(int idRetenue)
        {
            SupprimerOperation("Retenue", idRetenue);
        }

        private void SupprimerAvance(int idAvance)
        {
            SupprimerOperation("Avance", idAvance);
        }

        private void SupprimerOperation(string type, int idOperation)
        {
            string message = type == "Salaire"
                ? "Voulez-vous supprimer ce salaire ainsi que ses primes, retenues et avances associées ?"
                : "Voulez-vous vraiment supprimer cette opération ?";

            DialogResult resultat = MessageBox.Show(
                message,
                "Confirmation de suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resultat != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                using (MySqlTransaction transaction = connexion.BeginTransaction())
                {
                    try
                    {
                        if (type == "Salaire")
                        {
                            // Supprimer les opérations liées au salaire
                            ExecuterSuppression(connexion, transaction,
                                "DELETE FROM prime WHERE id_salaire = @id", idOperation);

                            ExecuterSuppression(connexion, transaction,
                                "DELETE FROM retenue WHERE id_salaire = @id", idOperation);

                            ExecuterSuppression(connexion, transaction,
                                "DELETE FROM avances_salaire WHERE id_salaire = @id", idOperation);

                            ExecuterSuppression(connexion, transaction,
                                "DELETE FROM salaires WHERE id_salaire = @id", idOperation);
                        }
                        else if (type == "Prime")
                        {
                            ExecuterSuppression(connexion, transaction,
                                "DELETE FROM prime WHERE id_prime = @id", idOperation);
                        }
                        else if (type == "Retenue")
                        {
                            ExecuterSuppression(connexion, transaction,
                                "DELETE FROM retenue WHERE id_retenue = @id", idOperation);
                        }
                        else if (type == "Avance")
                        {
                            ExecuterSuppression(connexion, transaction,
                                "DELETE FROM avances_salaire WHERE id_avance = @id", idOperation);
                        }

                        transaction.Commit();

                        MessageBox.Show(
                            "Suppression effectuée avec succès.",
                            "Succès",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

                // Actualiser l'onglet actuellement affiché
                RechargerOngletActif();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la suppression :\n" + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ExecuterSuppression(MySqlConnection connexion,MySqlTransaction transaction,string requete,int id)
        {
            using (MySqlCommand commande = new MySqlCommand(requete, connexion, transaction))
            {
                commande.Parameters.AddWithValue("@id", id);
                commande.ExecuteNonQuery();
            }
        }
        // Recharger encore les données
        private void RechargerOngletActif()
        {
            switch (typeOperation)
            {
                case "Salaire":
                    ChargerSalaires();
                    break;

                case "Prime":
                    ChargerPrimes();
                    break;

                case "Retenue":
                    ChargerRetenues();
                    break;

                case "Avance":
                    ChargerAvances();
                    break;
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            if (idPersonnelSelectionne <= 0)
            {
                MessageBox.Show("Veuillez sélectionner un personnel.");
                return;
            }

            ChargerStatistiquesSalaire();
            RechargerOngletActif();
            ChargerGraphiques();
            MessageBox.Show(
                "Les informations salariales ont été actualisées.",
                "Actualisation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ChargerPeriodes()
        {
            try
            {
                cbPeriode.Items.Clear();

                cbPeriode.Items.Add("Toutes les périodes");

                string requete = @"
            SELECT DISTINCT mois,
                   MIN(date_paiement) AS ordre
            FROM salaires
            WHERE id_personnel = @idPersonnel
            GROUP BY mois
            ORDER BY ordre DESC";

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddWithValue("@idPersonnel", idPersonnelSelectionne);

                    using (MySqlDataReader reader = commande.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbPeriode.Items.Add(reader["mois"].ToString());
                        }
                    }
                }

                cbPeriode.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des périodes :\n" + ex.Message);
            }
        }

        private bool ToutesLesPeriodes
        {
            get
            {
                return cbPeriode.SelectedIndex <= 0;
            }
        }

        private string ObtenirPeriodeSelectionnee()
        {
            if (ToutesLesPeriodes)
                return null;

            return cbPeriode.Text;
        }

        private void cbPeriode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (idPersonnelSelectionne <= 0 || cbPeriode.SelectedIndex < 0)
                return;

            ChargerStatistiquesSalaire();
            RechargerOngletActif();
            ChargerGraphiques();
        }
    }
}
