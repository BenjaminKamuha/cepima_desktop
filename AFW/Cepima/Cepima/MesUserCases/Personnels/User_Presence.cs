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

namespace Cepima.MesUserCases.Personnels
{
    public partial class User_Presence : UserControl
    {
        public User_Presence()
        {
            InitializeComponent();
        }

        private void User_Presence_Load(object sender, EventArgs e)
        {
            ChargerStatistiquesPresence();
            ChargerFiltres();
            ChargerPresences();
        }

        private void ChargerStatistiquesPresence()
        {
            try
            {
               

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                {

                    // ==========================================
                    // 1. TOTAL DU PERSONNEL ACTIF
                    // ==========================================

                    string requeteTotal = @"
                SELECT COUNT(*)
                FROM personnels
                ";

                    using (MySqlCommand commande = new MySqlCommand(
                        requeteTotal, connexion))
                    {
                        int total = Convert.ToInt32(
                            commande.ExecuteScalar());

                        lbl_nb_total.Text = total.ToString();
                    }


                    // ==========================================
                    // 2. PERSONNEL PRÉSENT AUJOURD'HUI
                    // ==========================================

                    string requetePresent = @"
                SELECT COUNT(DISTINCT id_personnel)
                FROM presences
                WHERE date_presence = CURDATE()
                AND statut = 'Présent'";

                    using (MySqlCommand commande = new MySqlCommand(
                        requetePresent, connexion))
                    {
                        int present = Convert.ToInt32(
                            commande.ExecuteScalar());

                        lbl_nb_present.Text = present.ToString();
                    }


                    // ==========================================
                    // 3. PERSONNEL EN RETARD AUJOURD'HUI
                    // ==========================================

                    string requeteRetard = @"
                SELECT COUNT(DISTINCT id_personnel)
                FROM presences
                WHERE date_presence = CURDATE()
                AND statut = 'Retard'";

                    using (MySqlCommand commande = new MySqlCommand(
                        requeteRetard, connexion))
                    {
                        int retard = Convert.ToInt32(
                            commande.ExecuteScalar());

                        lbl_nb_retard.Text = retard.ToString();
                    }


                    // ==========================================
                    // 4. PERSONNEL ABSENT AUJOURD'HUI
                    // ==========================================

                    string requeteAbsent = @"
                SELECT COUNT(*)
                FROM personnels p
                WHERE p.actif = 1
                AND NOT EXISTS
                (
                    SELECT 1
                    FROM presences pr
                    WHERE pr.id_personnel = p.id_personnel
                    AND pr.date_presence = CURDATE()
                )";

                    using (MySqlCommand commande = new MySqlCommand(
                        requeteAbsent, connexion))
                    {
                        int absent = Convert.ToInt32(
                            commande.ExecuteScalar());

                        lbl_nb_absent.Text = absent.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Impossible de charger les statistiques des présences.\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ChargerFiltres()
        {
            // ============================
            // FILTRE STATUT
            // ============================

            cbx_statut.Items.Clear();

            cbx_statut.Items.Add("Tous");
            cbx_statut.Items.Add("Présent");
            cbx_statut.Items.Add("Retard");
            cbx_statut.Items.Add("Absent");

            cbx_statut.SelectedIndex = 0;


            // ============================
            // FILTRE PÉRIODE
            // ============================

            cbx_periode.Items.Clear();
            cbx_periode.Items.Add("Tous");
            cbx_periode.Items.Add("Aujourd'hui");
            cbx_periode.Items.Add("Cette semaine");
            cbx_periode.Items.Add("Ce mois");

            cbx_periode.SelectedIndex = 0;
        }

        private void ChargerPresences()
        {
            try
            {
                using (MySqlConnection connexion =
                    MesClasses.ManagerClasse.GetConnexion())
                {
                    string requete = @"
                SELECT
                    p.id_personnel,

                    CONCAT(
                        p.nom, ' ',
                        IFNULL(p.post_nom, ''), ' ',
                        IFNULL(p.prenom, '')
                    ) AS personnel,

                    p.fonction,

                    pr.date_presence,
                    pr.heure_entree,
                    pr.heure_sortie,
                    pr.statut

                FROM presences pr

                INNER JOIN personnels p
                    ON p.id_personnel = pr.id_personnel
            ";

                    // ============================================================
                    // RECHERCHE PAR NOM, POST-NOM OU PRÉNOM
                    // ============================================================

                    if (!string.IsNullOrWhiteSpace(txt_recherche.Text))
                    {
                        requete += @"
                    AND
                    (
                        p.nom LIKE @recherche
                        OR p.post_nom LIKE @recherche
                        OR p.prenom LIKE @recherche
                    )";
                    }

                    // ============================================================
                    // FILTRE PAR PÉRIODE
                    // ============================================================

                    if (cbx_periode.Text == "Aujourd'hui")
                    {
                        requete += @"
                    AND DATE(pr.date_presence) = CURDATE()";
                    }
                    else if (cbx_periode.Text == "Cette semaine")
                    {
                        requete += @"
                    AND YEARWEEK(pr.date_presence, 1)
                        = YEARWEEK(CURDATE(), 1)";
                    }
                    else if (cbx_periode.Text == "Ce mois")
                    {
                        requete += @"
                    AND YEAR(pr.date_presence) = YEAR(CURDATE())
                    AND MONTH(pr.date_presence) = MONTH(CURDATE())";
                    }

                    // ============================================================
                    // FILTRE PAR STATUT
                    // ============================================================

                    if (cbx_statut.Text == "Présent")
                    {
                        requete += @"
                    AND pr.statut = 'Présent'";
                    }
//                    else if (cbx_statut.Text == "Retard")
//                    {
//                        requete += @"
//                    AND pr.statut = 'Retard'";
//                    }
//                    else if (cbx_statut.Text == "Absent")
//                    {
//                        requete += @"
//                    AND pr.statut = 'Absent'";
//                    }

                    // ============================================================
                    // ORDRE
                    // ============================================================

                    requete += @"
                ORDER BY
                    pr.date_presence DESC,
                    p.nom ASC,
                    p.post_nom ASC,
                    p.prenom ASC";

                    using (MySqlCommand commande =
                        new MySqlCommand(requete, connexion))
                    {
                        // ========================================================
                        // PARAMÈTRE RECHERCHE
                        // ========================================================

                        if (!string.IsNullOrWhiteSpace(txt_recherche.Text))
                        {
                            commande.Parameters.AddWithValue(
                                "@recherche",
                                "%" + txt_recherche.Text.Trim() + "%");
                        }

                        using (MySqlDataReader reader =
                            commande.ExecuteReader())
                        {
                            // ====================================================
                            // VIDER LE DATAGRIDVIEW
                            // ====================================================

                            dgv_presences.Rows.Clear();

                            // ====================================================
                            // LECTURE DES DONNÉES
                            // ====================================================

                            while (reader.Read())
                            {
                                // ------------------------------------------------
                                // ID PERSONNEL
                                // ------------------------------------------------

                                string idPersonnel =
                                    reader["id_personnel"] == DBNull.Value
                                    ? ""
                                    : reader["id_personnel"].ToString();

                                // ------------------------------------------------
                                // PERSONNEL
                                // ------------------------------------------------

                                string personnel =
                                    reader["personnel"] == DBNull.Value
                                    ? ""
                                    : reader["personnel"].ToString().Trim();

                                // ------------------------------------------------
                                // FONCTION
                                // ------------------------------------------------

                                string fonction =
                                    reader["fonction"] == DBNull.Value
                                    ? ""
                                    : reader["fonction"].ToString();

                                // ------------------------------------------------
                                // DATE
                                // ------------------------------------------------

                                string datePresence = "";

                                if (reader["date_presence"] != DBNull.Value)
                                {
                                    datePresence =
                                        Convert.ToDateTime(
                                            reader["date_presence"])
                                        .ToString("dd/MM/yyyy");
                                }

                                // ------------------------------------------------
                                // HEURE D'ENTRÉE
                                // ------------------------------------------------

                                string heureEntree =
                                    reader["heure_entree"] == DBNull.Value
                                    ? ""
                                    : reader["heure_entree"].ToString();

                                // ------------------------------------------------
                                // HEURE DE SORTIE
                                // ------------------------------------------------

                                string heureSortie =
                                    reader["heure_sortie"] == DBNull.Value
                                    ? ""
                                    : reader["heure_sortie"].ToString();

                                // ------------------------------------------------
                                // STATUT
                                // ------------------------------------------------

                                string statut =
                                    reader["statut"] == DBNull.Value
                                    ? ""
                                    : reader["statut"].ToString();

                                // =================================================
                                // AJOUT DE LA LIGNE
                                // =================================================

                                int indexLigne =
                                    dgv_presences.Rows.Add();

                                DataGridViewRow ligne =
                                    dgv_presences.Rows[indexLigne];

                                // ------------------------------------------------
                                // ID CACHÉ
                                // ------------------------------------------------

                                //ligne.Cells["colIDPersonnel"].Value =
                                //    idPersonnel;

                                // ------------------------------------------------
                                // COLONNES VISIBLES
                                // ------------------------------------------------

                                ligne.Cells["colPersonnel"].Value =
                                    personnel;

                                ligne.Cells["colFonction"].Value =
                                    fonction;

                                ligne.Cells["colDate"].Value =
                                    datePresence;

                                ligne.Cells["colHeureEntree"].Value =
                                    heureEntree;

                                ligne.Cells["colHeureSortie"].Value =
                                    heureSortie;

                                ligne.Cells["colStatut"].Value =
                                    statut;
                            }
                        }
                    }
                }

                // ================================================================
                // STYLE
                // ================================================================

                ApplyStyle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Impossible de charger les présences.\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
//        private void ChargerPresences()
//        {
//            try
//            {
//                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
//                {
                    
//                    string requete = @"
//                SELECT
//                    p.id_personnel,
//
//                    CONCAT(
//                        p.nom, ' ',
//                        IFNULL(p.post_nom, ''), ' ',
//                        IFNULL(p.prenom, '')
//                    ) AS personnel,
//
//                    p.fonction,
//
//                    pr.date_presence,
//                    pr.heure_entree,
//                    pr.heure_sortie,
//
//                    h.id_horaire,
//                    h.heure_entree_normal AS horaire_prevu,
//
//                    CASE
//                        WHEN pr.heure_entree IS NULL THEN NULL
//
//                        WHEN h.heure_entree_normal IS NULL THEN NULL
//
//                        WHEN pr.heure_entree > h.heure_entree_normal
//                        THEN TIMESTAMPDIFF(
//                            MINUTE,
//                            h.heure_entree_normal,
//                            pr.heure_entree
//                        )
//
//                        ELSE 0
//                    END AS retard,
//
//                    pr.statut
//
//                FROM presences pr
//
//                INNER JOIN personnels p
//                    ON p.id_personnel = pr.id_personnel
//
//                LEFT JOIN horaire h
//                    ON h.id_personnel = p.id_personnel
//
//                    AND h.jour_travail =
//                        CASE DAYOFWEEK(pr.date_presence)
//                            WHEN 1 THEN 'Dimanche'
//                            WHEN 2 THEN 'Lundi'
//                            WHEN 3 THEN 'Mardi'
//                            WHEN 4 THEN 'Mercredi'
//                            WHEN 5 THEN 'Jeudi'
//                            WHEN 6 THEN 'Vendredi'
//                            WHEN 7 THEN 'Samedi'
//                        END
//
//                WHERE p.actif = 'Actif'
//            ";

//                    // ============================================================
//                    // RECHERCHE PAR NOM, POST-NOM OU PRÉNOM
//                    // ============================================================

//                    if (!string.IsNullOrWhiteSpace(txt_recherche.Text))
//                    {
//                        requete += @"
//                    AND
//                    (
//                        p.nom LIKE @recherche
//                        OR p.post_nom LIKE @recherche
//                        OR p.prenom LIKE @recherche
//                    )";
//                    }

//                    // ============================================================
//                    // FILTRE PAR PÉRIODE
//                    // ============================================================

//                    if (cbx_periode.Text == "Aujourd'hui")
//                    {
//                        requete += @"
//                    AND pr.date_presence = CURDATE()";
//                    }
//                    else if (cbx_periode.Text == "Cette semaine")
//                    {
//                        requete += @"
//                    AND YEARWEEK(pr.date_presence, 1)
//                        = YEARWEEK(CURDATE(), 1)";
//                    }
//                    else if (cbx_periode.Text == "Ce mois")
//                    {
//                        requete += @"
//                    AND YEAR(pr.date_presence) = YEAR(CURDATE())
//                    AND MONTH(pr.date_presence) = MONTH(CURDATE())";
//                    }
//                    else if (cbx_periode.Text == "Tous")
//                    {
//                        // Aucun filtre de date
//                    }

//                    // ============================================================
//                    // FILTRE PAR STATUT
//                    // ============================================================

//                    if (cbx_statut.Text == "Présent")
//                    {
//                        requete += @"
//                    AND pr.statut = 'Présent'";
//                    }
//                    else if (cbx_statut.Text == "Retard")
//                    {
//                        requete += @"
//                    AND pr.statut = 'Retard'";
//                    }
//                    else if (cbx_statut.Text == "Absent")
//                    {
//                        requete += @"
//                    AND pr.statut = 'Absent'";
//                    }

//                    // ============================================================
//                    // ORDRE D'AFFICHAGE
//                    // ============================================================

//                    requete += @"
//                ORDER BY
//                    pr.date_presence DESC,
//                    p.nom ASC,
//                    p.post_nom ASC,
//                    p.prenom ASC";

//                    using (MySqlCommand commande =
//                        new MySqlCommand(requete, connexion))
//                    {
//                        // ========================================================
//                        // PARAMÈTRE DE RECHERCHE
//                        // ========================================================

//                        if (!string.IsNullOrWhiteSpace(txt_recherche.Text))
//                        {
//                            commande.Parameters.AddWithValue(
//                                "@recherche",
//                                "%" + txt_recherche.Text.Trim() + "%");
//                        }

//                        using (MySqlDataReader reader =
//                            commande.ExecuteReader())
//                        {
//                            // ====================================================
//                            // VIDER LE DATAGRIDVIEW
//                            // ====================================================

//                            dgv_presences.Rows.Clear();

//                            // ====================================================
//                            // LECTURE DES DONNÉES
//                            // ====================================================

//                            while (reader.Read())
//                            {
//                                // ------------------------------------------------
//                                // ID PERSONNEL
//                                // ------------------------------------------------

//                                string idPersonnel = "";

//                                if (reader["id_personnel"] != DBNull.Value)
//                                {
//                                    idPersonnel =
//                                        reader["id_personnel"].ToString();
//                                }

//                                // ------------------------------------------------
//                                // PERSONNEL
//                                // ------------------------------------------------

//                                string personnel = "";

//                                if (reader["personnel"] != DBNull.Value)
//                                {
//                                    personnel =
//                                        reader["personnel"].ToString().Trim();
//                                }

//                                // ------------------------------------------------
//                                // FONCTION
//                                // ------------------------------------------------

//                                string fonction = "";

//                                if (reader["fonction"] != DBNull.Value)
//                                {
//                                    fonction =
//                                        reader["fonction"].ToString();
//                                }

//                                // ------------------------------------------------
//                                // ID HORAIRE
//                                // ------------------------------------------------

//                                string idHoraire = "";

//                                if (reader["id_horaire"] != DBNull.Value)
//                                {
//                                    idHoraire =
//                                        reader["id_horaire"].ToString();
//                                }

//                                // ------------------------------------------------
//                                // DATE DE PRÉSENCE
//                                // ------------------------------------------------

//                                string datePresence = "";

//                                if (reader["date_presence"] != DBNull.Value)
//                                {
//                                    datePresence =
//                                        Convert.ToDateTime(
//                                            reader["date_presence"]
//                                        ).ToString("dd/MM/yyyy");
//                                }

//                                // ------------------------------------------------
//                                // HEURE D'ENTRÉE
//                                // ------------------------------------------------

//                                string heureEntree = "";

//                                if (reader["heure_entree"] != DBNull.Value)
//                                {
//                                    heureEntree =
//                                        reader["heure_entree"].ToString();
//                                }

//                                // ------------------------------------------------
//                                // HEURE DE SORTIE
//                                // ------------------------------------------------

//                                string heureSortie = "";

//                                if (reader["heure_sortie"] != DBNull.Value)
//                                {
//                                    heureSortie =
//                                        reader["heure_sortie"].ToString();
//                                }

//                                // ------------------------------------------------
//                                // HORAIRE PRÉVU
//                                // ------------------------------------------------

//                                string horairePrevu = "";

//                                if (reader["horaire_prevu"] != DBNull.Value)
//                                {
//                                    horairePrevu =
//                                        reader["horaire_prevu"].ToString();
//                                }

//                                // ------------------------------------------------
//                                // RETARD
//                                // ------------------------------------------------

//                                string retard = "";

//                                if (reader["retard"] != DBNull.Value)
//                                {
//                                    int minutes =
//                                        Convert.ToInt32(reader["retard"]);

//                                    if (minutes > 0)
//                                    {
//                                        retard = minutes + " min";
//                                    }
//                                    else
//                                    {
//                                        retard = "0 min";
//                                    }
//                                }

//                                // ------------------------------------------------
//                                // STATUT
//                                // ------------------------------------------------

//                                string statut = "";

//                                if (reader["statut"] != DBNull.Value)
//                                {
//                                    statut =
//                                        reader["statut"].ToString();
//                                }

//                                // =================================================
//                                // AJOUT DE LA LIGNE
//                                // =================================================

//                                int indexLigne =
//                                    dgv_presences.Rows.Add();

//                                DataGridViewRow ligne =
//                                    dgv_presences.Rows[indexLigne];

//                                // =================================================
//                                // COLONNES CACHÉES
//                                // =================================================

//                                ligne.Cells["colIDPersonnel"].Value =
//                                    idPersonnel;

//                                ligne.Cells["colIDhoraire"].Value =
//                                    idHoraire;

//                                // =================================================
//                                // COLONNES VISIBLES
//                                // =================================================

//                                ligne.Cells["colPersonnel"].Value =
//                                    personnel;

//                                ligne.Cells["colFonction"].Value =
//                                    fonction;

//                                ligne.Cells["colDate"].Value =
//                                    datePresence;

//                                ligne.Cells["colHeureEntree"].Value =
//                                    heureEntree;

//                                ligne.Cells["colHeureSortie"].Value =
//                                    heureSortie;

//                                ligne.Cells["colHorairePrevu"].Value =
//                                    horairePrevu;

//                                ligne.Cells["colRetard"].Value =
//                                    retard;

//                                ligne.Cells["colStatut"].Value =
//                                    statut;
//                            }
//                        }
//                    }
//                }

//                // ================================================================
//                // APPLIQUER LE STYLE APRÈS LE CHARGEMENT
//                // ================================================================

//                ApplyStyle();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(
//                    "Impossible de charger les présences.\n\n" +
//                    ex.Message,
//                    "Erreur",
//                    MessageBoxButtons.OK,
//                    MessageBoxIcon.Error);
//            }
//        }

        private void txt_recherche_TextChanged(object sender, EventArgs e)
        {
            ChargerPresences();
        }

        private void cbx_statut_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargerPresences();
        }

        private void cbx_periode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargerPresences();
        }

        private void ApplyStyle()
        {
            // ============================================================
            // LARGEUR DES COLONNES
            // ============================================================

            dgv_presences.Columns["colPersonnel"].Width = 180;
            dgv_presences.Columns["colFonction"].Width = 120;
            dgv_presences.Columns["colDate"].Width = 90;
            dgv_presences.Columns["colHeureEntree"].Width = 90;
            dgv_presences.Columns["colHeureSortie"].Width = 90;
            dgv_presences.Columns["colStatut"].Width = 90;
        }

    }
}
