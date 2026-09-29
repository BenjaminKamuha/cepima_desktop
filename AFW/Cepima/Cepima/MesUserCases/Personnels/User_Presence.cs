using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cepima.MesUserCases.Personnels
{
    public partial class User_Presence : UserControl
    {
        private Timer timerRecherche;
        private bool initialisationTerminee = false;

        public User_Presence()
        {
            InitializeComponent();

            InitialiserRecherche();
        }

        // ============================================================
        // LOAD
        // ============================================================

        private void User_Presence_Load(object sender, EventArgs e)
        {
            try
            {
                initialisationTerminee = false;

                ChargerFiltres();

                initialisationTerminee = true;

                ChargerStatistiquesPresence();
                ChargerPresences();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'initialisation des présences.\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // INITIALISATION RECHERCHE
        // ============================================================

        private void InitialiserRecherche()
        {
            timerRecherche = new Timer();
            timerRecherche.Interval = 300;
            timerRecherche.Tick += timerRecherche_Tick;
        }

        private void timerRecherche_Tick(object sender, EventArgs e)
        {
            timerRecherche.Stop();

            if (!initialisationTerminee)
                return;

            ChargerPresences();
        }

        // ============================================================
        // STATISTIQUES
        // ============================================================

        private void ChargerStatistiquesPresence()
        {
            try
            {
                /*
                 * Une seule requête au lieu de 4 requêtes séparées.
                 * Cela réduit fortement les allers-retours avec MySQL.
                 */

                string requete = @"
                    SELECT

                        (
                            SELECT COUNT(*)
                            FROM personnels
                        ) AS total,

                        (
                            SELECT COUNT(DISTINCT id_personnel)
                            FROM presences
                            WHERE date_presence >= CURDATE()
                              AND date_presence < DATE_ADD(
                                    CURDATE(),
                                    INTERVAL 1 DAY
                              )
                              AND statut = 'Présent'
                        ) AS present,

                        (
                            SELECT COUNT(DISTINCT id_personnel)
                            FROM presences
                            WHERE date_presence >= CURDATE()
                              AND date_presence < DATE_ADD(
                                    CURDATE(),
                                    INTERVAL 1 DAY
                              )
                              AND statut = 'Retard'
                        ) AS retard,

                        (
                            SELECT COUNT(*)
                            FROM personnels p
                            WHERE p.actif = 1
                              AND NOT EXISTS
                              (
                                  SELECT 1
                                  FROM presences pr
                                  WHERE pr.id_personnel = p.id_personnel
                                    AND pr.date_presence >= CURDATE()
                                    AND pr.date_presence < DATE_ADD(
                                        CURDATE(),
                                        INTERVAL 1 DAY
                                    )
                              )
                        ) AS absent";

                using (MySqlConnection connexion =
                    MesClasses.ManagerClasse.GetConnexion())
                {
                    using (MySqlCommand commande =
                        new MySqlCommand(
                            requete,
                            connexion))
                    {
                        using (MySqlDataReader reader =
                            commande.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lbl_nb_total.Text =
                                    GetInt(reader, "total").ToString();

                                lbl_nb_present.Text =
                                    GetInt(reader, "present").ToString();

                                lbl_nb_retard.Text =
                                    GetInt(reader, "retard").ToString();

                                lbl_nb_absent.Text =
                                    GetInt(reader, "absent").ToString();
                            }
                            else
                            {
                                lbl_nb_total.Text = "0";
                                lbl_nb_present.Text = "0";
                                lbl_nb_retard.Text = "0";
                                lbl_nb_absent.Text = "0";
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Impossible de charger les statistiques des présences.\n\n" +
                    ex.Message,
                    "Erreur MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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

        // ============================================================
        // FILTRES
        // ============================================================

        private void ChargerFiltres()
        {
            cbx_statut.Items.Clear();

            cbx_statut.Items.Add("Tous");
            cbx_statut.Items.Add("Présent");
            cbx_statut.Items.Add("Retard");
            cbx_statut.Items.Add("Absent");

            cbx_statut.SelectedIndex = 0;

            cbx_periode.Items.Clear();

            cbx_periode.Items.Add("Tous");
            cbx_periode.Items.Add("Aujourd'hui");
            cbx_periode.Items.Add("Cette semaine");
            cbx_periode.Items.Add("Ce mois");

            cbx_periode.SelectedIndex = 0;
        }

        // ============================================================
        // CHARGER LES PRESENCES
        // ============================================================

        private void ChargerPresences()
        {
            string recherche =
                txt_recherche.Text.Trim();

            string statut =
                cbx_statut.Text.Trim();

            string periode =
                cbx_periode.Text.Trim();

            try
            {
                dgv_presences.SuspendLayout();

                dgv_presences.Rows.Clear();

                string requete = @"
                    SELECT
                        p.id_personnel,

                        CONCAT(
                            COALESCE(p.nom, ''),
                            ' ',
                            COALESCE(p.post_nom, ''),
                            ' ',
                            COALESCE(p.prenom, '')
                        ) AS personnel,

                        p.fonction,

                        pr.date_presence,
                        pr.heure_entree,
                        pr.heure_sortie,
                        pr.statut

                    FROM presences pr

                    INNER JOIN personnels p
                        ON p.id_personnel = pr.id_personnel

                    WHERE 1 = 1
                ";

                // ========================================================
                // RECHERCHE
                // ========================================================

                if (recherche.Length > 0)
                {
                    requete += @"
                        AND
                        (
                            p.nom LIKE @recherche
                            OR p.post_nom LIKE @recherche
                            OR p.prenom LIKE @recherche
                        )";
                }

                // ========================================================
                // PERIODE
                // ========================================================

                AjouterFiltrePeriode(
                    ref requete,
                    periode);

                // ========================================================
                // STATUT
                // ========================================================

                if (statut == "Présent")
                {
                    requete += @"
                        AND pr.statut = @statut";
                }
                else if (statut == "Retard")
                {
                    requete += @"
                        AND pr.statut = @statut";
                }
                else if (statut == "Absent")
                {
                    requete += @"
                        AND pr.statut = @statut";
                }

                // ========================================================
                // ORDRE
                // ========================================================

                requete += @"
                    ORDER BY
                        pr.date_presence DESC,
                        p.nom ASC,
                        p.post_nom ASC,
                        p.prenom ASC";

                using (MySqlConnection connexion =
                    MesClasses.ManagerClasse.GetConnexion())
                {
                    using (MySqlCommand commande =
                        new MySqlCommand(
                            requete,
                            connexion))
                    {
                        // =================================================
                        // PARAMETRE RECHERCHE
                        // =================================================

                        if (recherche.Length > 0)
                        {
                            commande.Parameters.Add(
                                "@recherche",
                                MySqlDbType.VarChar).Value =
                                "%" + recherche + "%";
                        }

                        // =================================================
                        // PARAMETRE STATUT
                        // =================================================

                        if (statut == "Présent" ||
                            statut == "Retard" ||
                            statut == "Absent")
                        {
                            commande.Parameters.Add(
                                "@statut",
                                MySqlDbType.VarChar).Value =
                                statut;
                        }

                        // =================================================
                        // EXECUTION
                        // =================================================

                        using (MySqlDataReader reader =
                            commande.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AjouterPresenceDansGrid(
                                    reader);
                            }
                        }
                    }
                }

                ApplyStyle();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Impossible de charger les présences.\n\n" +
                    ex.Message,
                    "Erreur MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
            finally
            {
                dgv_presences.ResumeLayout();
            }
        }

        // ============================================================
        // FILTRE PERIODE
        // ============================================================

        private void AjouterFiltrePeriode(
            ref string requete,
            string periode)
        {
            if (periode == "Aujourd'hui")
            {
                /*
                 * Beaucoup plus performant que :
                 *
                 * DATE(pr.date_presence) = CURDATE()
                 *
                 * car MySQL peut utiliser un index sur date_presence.
                 */

                requete += @"
                    AND pr.date_presence >= CURDATE()
                    AND pr.date_presence < DATE_ADD(
                        CURDATE(),
                        INTERVAL 1 DAY
                    )";
            }
            else if (periode == "Cette semaine")
            {
                /*
                 * Semaine commençant lundi.
                 */

                requete += @"
                    AND pr.date_presence >= DATE_SUB(
                        CURDATE(),
                        INTERVAL WEEKDAY(CURDATE()) DAY
                    )
                    AND pr.date_presence < DATE_ADD(
                        DATE_SUB(
                            CURDATE(),
                            INTERVAL WEEKDAY(CURDATE()) DAY
                        ),
                        INTERVAL 7 DAY
                    )";
            }
            else if (periode == "Ce mois")
            {
                /*
                 * Premier jour du mois jusqu'au premier jour
                 * du mois suivant.
                 */

                requete += @"
                    AND pr.date_presence >=
                        DATE_SUB(
                            CURDATE(),
                            INTERVAL DAYOFMONTH(CURDATE()) - 1 DAY
                        )
                    AND pr.date_presence < DATE_ADD(
                        DATE_SUB(
                            CURDATE(),
                            INTERVAL DAYOFMONTH(CURDATE()) - 1 DAY
                        ),
                        INTERVAL 1 MONTH
                    )";
            }
        }

        // ============================================================
        // AJOUT D'UNE PRESENCE AU DATAGRIDVIEW
        // ============================================================

        private void AjouterPresenceDansGrid(
            MySqlDataReader reader)
        {
            string idPersonnel =
                GetString(
                    reader,
                    "id_personnel");

            string personnel =
                GetString(
                    reader,
                    "personnel").Trim();

            string fonction =
                GetString(
                    reader,
                    "fonction");

            string datePresence = "";

            if (reader["date_presence"] != DBNull.Value)
            {
                DateTime date =
                    Convert.ToDateTime(
                        reader["date_presence"]);

                datePresence =
                    date.ToString(
                        "dd/MM/yyyy");
            }

            string heureEntree =
                GetString(
                    reader,
                    "heure_entree");

            string heureSortie =
                GetString(
                    reader,
                    "heure_sortie");

            string statut =
                GetString(
                    reader,
                    "statut");

            int indexLigne =
                dgv_presences.Rows.Add();

            DataGridViewRow ligne =
                dgv_presences.Rows[indexLigne];

            // ========================================================
            // ID PERSONNEL
            // ========================================================

            if (dgv_presences.Columns.Contains(
                "colIDPersonnel"))
            {
                ligne.Cells[
                    "colIDPersonnel"].Value =
                    idPersonnel;
            }

            // ========================================================
            // DONNEES VISIBLES
            // ========================================================

            ligne.Cells[
                "colPersonnel"].Value =
                personnel;

            ligne.Cells[
                "colFonction"].Value =
                fonction;

            ligne.Cells[
                "colDate"].Value =
                datePresence;

            ligne.Cells[
                "colHeureEntree"].Value =
                heureEntree;

            ligne.Cells[
                "colHeureSortie"].Value =
                heureSortie;

            ligne.Cells[
                "colStatut"].Value =
                statut;
        }

        // ============================================================
        // RECHERCHE
        // ============================================================

        private void txt_recherche_TextChanged(
            object sender,
            EventArgs e)
        {
            if (!initialisationTerminee)
                return;

            if (timerRecherche == null)
                return;

            timerRecherche.Stop();
            timerRecherche.Start();
        }

        // ============================================================
        // FILTRE STATUT
        // ============================================================

        private void cbx_statut_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (!initialisationTerminee)
                return;

            if (timerRecherche != null)
                timerRecherche.Stop();

            ChargerPresences();
        }

        // ============================================================
        // FILTRE PERIODE
        // ============================================================

        private void cbx_periode_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (!initialisationTerminee)
                return;

            if (timerRecherche != null)
                timerRecherche.Stop();

            ChargerPresences();
        }

        // ============================================================
        // STYLE
        // ============================================================

        private void ApplyStyle()
        {
            if (dgv_presences.Columns.Contains(
                "colPersonnel"))
            {
                dgv_presences.Columns[
                    "colPersonnel"].Width = 180;
            }

            if (dgv_presences.Columns.Contains(
                "colFonction"))
            {
                dgv_presences.Columns[
                    "colFonction"].Width = 120;
            }

            if (dgv_presences.Columns.Contains(
                "colDate"))
            {
                dgv_presences.Columns[
                    "colDate"].Width = 90;
            }

            if (dgv_presences.Columns.Contains(
                "colHeureEntree"))
            {
                dgv_presences.Columns[
                    "colHeureEntree"].Width = 90;
            }

            if (dgv_presences.Columns.Contains(
                "colHeureSortie"))
            {
                dgv_presences.Columns[
                    "colHeureSortie"].Width = 90;
            }

            if (dgv_presences.Columns.Contains(
                "colStatut"))
            {
                dgv_presences.Columns[
                    "colStatut"].Width = 90;
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
                return "";

            return reader[colonne].ToString();
        }

        private int GetInt(
            MySqlDataReader reader,
            string colonne)
        {
            if (reader[colonne] == DBNull.Value)
                return 0;

            return Convert.ToInt32(
                reader[colonne]);
        }
    }
}