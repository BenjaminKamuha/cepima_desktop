using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cepima.MesUserCases.Personnels
{
    public partial class User_DashBord_Personnel : UserControl
    {
        private Timer timerRecherche;

        public User_DashBord_Personnel()
        {
            InitializeComponent();

            InitialiserRecherche();

            dgv_paiement.CellMouseDown -= dgv_paiement_CellMouseDown;
            dgv_paiement.CellMouseDown += dgv_paiement_CellMouseDown;

            ChargerMois();
            ChargerAnnees();

            LoadStatistiquesPersonnel();
            LoadDerniersPersonnel();
            ChargerCarteSalaires();
        }

        // ============================================================
        // INITIALISATION DE LA RECHERCHE
        // ============================================================

        private void InitialiserRecherche()
        {
            timerRecherche = new Timer();
            timerRecherche.Interval = 300;
            timerRecherche.Tick += timerRecherche_Tick;

            txt_recherche.TextChanged -= txt_recherche_TextChanged;
            txt_recherche.TextChanged += txt_recherche_TextChanged;
        }

        private void timerRecherche_Tick(object sender, EventArgs e)
        {
            timerRecherche.Stop();
            LoadHistoriquePaiement();
        }

        // ============================================================
        // CLIC DROIT DATAGRIDVIEW
        // ============================================================

        private void dgv_paiement_CellMouseDown(
            object sender,
            DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            if (e.RowIndex < 0)
                return;

            dgv_paiement.ClearSelection();

            dgv_paiement.Rows[e.RowIndex].Selected = true;

            if (dgv_paiement.Rows[e.RowIndex].Cells.Count > 0)
            {
                dgv_paiement.CurrentCell =
                    dgv_paiement.Rows[e.RowIndex].Cells[0];
            }
        }

        // ============================================================
        // ID PERSONNEL SELECTIONNE
        // ============================================================

        private int GetIDPersonnelSelectionne()
        {
            if (dgv_paiement.CurrentRow == null)
                return 0;

            object value =
                dgv_paiement.CurrentRow.Cells["id_personnel"].Value;

            if (value == null || value == DBNull.Value)
                return 0;

            int id;

            if (int.TryParse(value.ToString(), out id))
                return id;

            return 0;
        }

        // ============================================================
        // ID SALAIRE SELECTIONNE
        // ============================================================

        private int GetIDSalaireSelectionne()
        {
            if (dgv_paiement.CurrentRow == null)
                return 0;

            object value =
                dgv_paiement.CurrentRow.Cells["ID"].Value;

            if (value == null || value == DBNull.Value)
                return 0;

            int id;

            if (int.TryParse(value.ToString(), out id))
                return id;

            return 0;
        }

        // ============================================================
        // STATISTIQUES PERSONNEL
        // ============================================================

        private void LoadStatistiquesPersonnel()
        {
            try
            {
                /*
                 * Les 4 requêtes COUNT ont été regroupées en une seule.
                 * Cela évite 4 allers-retours MySQL.
                 */

                string query = @"
                    SELECT
                        COUNT(*) AS total,
                        SUM(CASE WHEN actif = 1 THEN 1 ELSE 0 END) AS actifs,
                        SUM(CASE WHEN actif = 0 THEN 1 ELSE 0 END) AS inactifs,
                        COUNT(
                            DISTINCT
                            CASE
                                WHEN fonction IS NOT NULL
                                AND fonction <> ''
                                THEN fonction
                            END
                        ) AS fonctions
                    FROM personnels";

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        null,
                        true))
                {
                    if (reader.Read())
                    {
                        lb_total.Text =
                            GetInt(reader, "total").ToString();

                        lb_actif.Text =
                            GetInt(reader, "actifs").ToString();

                        lb_inactif.Text =
                            GetInt(reader, "inactifs").ToString();

                        lbl_total_salaire.Text =
                            GetInt(reader, "fonctions").ToString();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des statistiques :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des statistiques :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // DERNIERS PERSONNELS
        // ============================================================

        private void LoadDerniersPersonnel()
        {
            try
            {
                dgv_personnel.SuspendLayout();

                dgv_personnel.Rows.Clear();

                string query = @"
                    SELECT
                        id_personnel,
                        nom,
                        post_nom,
                        prenom,
                        date_naissance,
                        sexe,
                        adresse,
                        fonction
                    FROM personnels
                    ORDER BY id_personnel DESC
                    LIMIT 10";

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        null,
                        true))
                {
                    while (reader.Read())
                    {
                        string id =
                            GetString(reader, "id_personnel");

                        string nom =
                            GetString(reader, "nom");

                        string postNom =
                            GetString(reader, "post_nom");

                        string prenom =
                            GetString(reader, "prenom");

                        string personnel =
                            (nom + " " +
                             postNom + " " +
                             prenom).Trim();

                        int age = -1;
                        string date = "Non renseignée";

                        if (reader["date_naissance"] != DBNull.Value)
                        {
                            DateTime dateNaissance =
                                Convert.ToDateTime(
                                    reader["date_naissance"]);

                            age =
                                CalculerAge(dateNaissance);

                            date =
                                dateNaissance.ToString(
                                    "dd/MM/yyyy");
                        }

                        string sexe =
                            GetString(reader, "sexe");

                        string adresse =
                            GetString(reader, "adresse");

                        string fonction =
                            GetString(reader, "fonction");

                        string affichageAge =
                            age >= 0
                                ? age + " ans"
                                : "Non renseigné";

                        dgv_personnel.Rows.Add(
                            id,
                            personnel,
                            affichageAge,
                            sexe,
                            adresse,
                            fonction,
                            date);
                    }
                }

                ApplyStytle();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du personnel :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Une erreur est survenue lors du chargement du personnel :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                dgv_personnel.ResumeLayout();
            }
        }

        // ============================================================
        // CALCUL AGE
        // ============================================================

        private int CalculerAge(DateTime dateNaissance)
        {
            DateTime aujourdHui = DateTime.Today;

            int age =
                aujourdHui.Year -
                dateNaissance.Year;

            if (dateNaissance.Date >
                aujourdHui.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        // ============================================================
        // STYLE
        // ============================================================

        private void ApplyStytle()
        {
            if (dgv_personnel.Columns.Contains("colID"))
                dgv_personnel.Columns["colID"].Width = 80;

            if (dgv_personnel.Columns.Contains("colPersonnel"))
                dgv_personnel.Columns["colPersonnel"].Width = 300;
        }

        // ============================================================
        // MOIS
        // ============================================================

        private void ChargerMois()
        {
            cbx_mois.Items.Clear();

            cbx_mois.Items.Add("Tous");

            cbx_mois.Items.Add("Janvier");
            cbx_mois.Items.Add("Février");
            cbx_mois.Items.Add("Mars");
            cbx_mois.Items.Add("Avril");
            cbx_mois.Items.Add("Mai");
            cbx_mois.Items.Add("Juin");
            cbx_mois.Items.Add("Juillet");
            cbx_mois.Items.Add("Août");
            cbx_mois.Items.Add("Septembre");
            cbx_mois.Items.Add("Octobre");
            cbx_mois.Items.Add("Novembre");
            cbx_mois.Items.Add("Décembre");

            cbx_mois.SelectedIndex = 0;
        }

        // ============================================================
        // HISTORIQUE PAIEMENTS
        // ============================================================

        private void LoadHistoriquePaiement()
        {
            try
            {
                dgv_paiement.SuspendLayout();

                dgv_paiement.Rows.Clear();

                string recherche =
                    txt_recherche.Text.Trim();

                string moisSelectionne =
                    cbx_mois.Text.Trim();

                string anneeSelectionnee =
                    cbx_annee.Text.Trim();

                /*
                 * IMPORTANT :
                 * On conserve ici les sous-requêtes de primes,
                 * retenues et avances pour ne pas multiplier les
                 * lignes de salaire.
                 */

                string query = @"
                    SELECT
                        s.id_salaire,
                        s.id_personnel,

                        CONCAT(
                            COALESCE(p.nom, ''),
                            ' ',
                            COALESCE(p.post_nom, ''),
                            ' ',
                            COALESCE(p.prenom, '')
                        ) AS personnel,

                        p.fonction,

                        s.salaire_base AS salaire,

                        IFNULL(pr.prime, 0) AS prime,

                        IFNULL(r.retenue, 0) AS retenue,

                        IFNULL(a.avance, 0) AS avance,

                        s.statut,
                        s.mois,

                        YEAR(s.date_paiement) AS annee,

                        s.date_paiement

                    FROM salaires s

                    INNER JOIN personnels p
                        ON p.id_personnel = s.id_personnel

                    LEFT JOIN
                    (
                        SELECT
                            id_salaire,
                            SUM(montant) AS prime
                        FROM prime
                        GROUP BY id_salaire
                    ) pr
                        ON pr.id_salaire = s.id_salaire

                    LEFT JOIN
                    (
                        SELECT
                            id_salaire,
                            SUM(montant) AS retenue
                        FROM retenue
                        GROUP BY id_salaire
                    ) r
                        ON r.id_salaire = s.id_salaire

                    LEFT JOIN
                    (
                        SELECT
                            id_salaire,
                            SUM(montant) AS avance
                        FROM avances_salaire
                        GROUP BY id_salaire
                    ) a
                        ON a.id_salaire = s.id_salaire

                    WHERE 1 = 1
                ";

                // ========================================================
                // RECHERCHE
                // ========================================================

                if (recherche != "")
                {
                    query += @"
                        AND
                        (
                            p.nom LIKE @recherche
                            OR p.post_nom LIKE @recherche
                            OR p.prenom LIKE @recherche
                        )";
                }

                // ========================================================
                // MOIS
                // ========================================================

                int numeroMois =
                    ObtenirNumeroMois(
                        moisSelectionne);

                if (numeroMois > 0)
                {
                    query += @"
                        AND MONTH(s.date_paiement) = @mois";
                }

                // ========================================================
                // ANNEE
                // ========================================================

                int annee;

                bool anneeValide =
                    int.TryParse(
                        anneeSelectionnee,
                        out annee);

                if (anneeValide)
                {
                    query += @"
                        AND YEAR(s.date_paiement) = @annee";
                }

                // ========================================================
                // ORDRE
                // ========================================================

                query += @"
                    ORDER BY
                        s.date_paiement DESC,
                        s.id_salaire DESC";

                // ========================================================
                // PARAMETRES
                // ========================================================

                MesClasses.ManagerClasse.request_params.Clear();

                if (recherche != "")
                {
                    MesClasses.ManagerClasse.request_params.Add(
                        "@recherche",
                        "%" + recherche + "%");
                }

                if (numeroMois > 0)
                {
                    MesClasses.ManagerClasse.request_params.Add(
                        "@mois",
                        numeroMois.ToString());
                }

                if (anneeValide)
                {
                    MesClasses.ManagerClasse.request_params.Add(
                        "@annee",
                        annee.ToString());
                }

                // ========================================================
                // EXECUTION
                // ========================================================

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    string dernierMois = "";
                    string derniereAnnee = "";

                    while (reader.Read())
                    {
                        string mois =
                            GetString(reader, "mois");

                        string anneeTexte =
                            GetString(reader, "annee");

                        // =================================================
                        // SEPARATEUR DE GROUPE
                        // =================================================

                        if (dernierMois != "" &&
                            (
                                dernierMois != mois ||
                                derniereAnnee != anneeTexte
                            ))
                        {
                            int ligneVide =
                                dgv_paiement.Rows.Add();

                            dgv_paiement.Rows[ligneVide].Height = 20;
                            dgv_paiement.Rows[ligneVide].ReadOnly = true;
                        }

                        // =================================================
                        // AJOUT LIGNE
                        // =================================================

                        int row =
                            dgv_paiement.Rows.Add();

                        // =================================================
                        // INFORMATIONS CACHEES
                        // =================================================

                        dgv_paiement.Rows[row]
                            .Cells["id_personnel"].Value =
                            GetInt(
                                reader,
                                "id_personnel");

                        dgv_paiement.Rows[row]
                            .Cells["ID"].Value =
                            GetInt(
                                reader,
                                "id_salaire");

                        // =================================================
                        // PERSONNEL
                        // =================================================

                        dgv_paiement.Rows[row]
                            .Cells["colPerson"].Value =
                            GetString(
                                reader,
                                "personnel");

                        // =================================================
                        // FONCTION
                        // =================================================

                        dgv_paiement.Rows[row]
                            .Cells["colFunction"].Value =
                            GetString(
                                reader,
                                "fonction");

                        // =================================================
                        // SALAIRE
                        // =================================================

                        dgv_paiement.Rows[row]
                            .Cells["colsalaire"].Value =
                            GetDecimal(
                                reader,
                                "salaire")
                            .ToString("N2");

                        // =================================================
                        // PRIME
                        // =================================================

                        dgv_paiement.Rows[row]
                            .Cells["colPrime"].Value =
                            GetDecimal(
                                reader,
                                "prime")
                            .ToString("N2");

                        // =================================================
                        // RETENUE
                        // =================================================

                        dgv_paiement.Rows[row]
                            .Cells["colRetenu"].Value =
                            GetDecimal(
                                reader,
                                "retenue")
                            .ToString("N2");

                        // =================================================
                        // AVANCE
                        // =================================================

                        dgv_paiement.Rows[row]
                            .Cells["colAvance"].Value =
                            GetDecimal(
                                reader,
                                "avance")
                            .ToString("N2");

                        // =================================================
                        // STATUT
                        // =================================================

                        dgv_paiement.Rows[row]
                            .Cells["colStatut"].Value =
                            GetString(
                                reader,
                                "statut");

                        // =================================================
                        // GROUPE
                        // =================================================

                        dgv_paiement.Rows[row].Tag =
                            new GroupeSalaire
                            {
                                Mois = mois,
                                Annee = anneeTexte
                            };

                        dernierMois = mois;
                        derniereAnnee = anneeTexte;
                    }
                }

                if (dgv_paiement.Columns.Contains("colPerson"))
                {
                    dgv_paiement.Columns["colPerson"].Width = 200;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement de l'historique des paiements :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement de l'historique des paiements :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                dgv_paiement.ResumeLayout();
            }
        }

        // ============================================================
        // CARTE SALAIRES
        // ============================================================

        private void ChargerCarteSalaires()
        {
            try
            {
                string query = @"
                    SELECT
                        SUM(s.salaire_base) AS total_salaire,
                        s.mois,
                        YEAR(s.date_paiement) AS annee

                    FROM salaires s

                    INNER JOIN
                    (
                        SELECT
                            mois,
                            YEAR(date_paiement) AS annee
                        FROM salaires
                        WHERE date_paiement IS NOT NULL
                        ORDER BY
                            date_paiement DESC,
                            id_salaire DESC
                        LIMIT 1
                    ) dernier
                        ON dernier.mois = s.mois
                        AND dernier.annee =
                            YEAR(s.date_paiement)

                    GROUP BY
                        s.mois,
                        YEAR(s.date_paiement)

                    LIMIT 1";

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        null,
                        true))
                {
                    if (reader.Read())
                    {
                        decimal totalSalaire =
                            GetDecimal(
                                reader,
                                "total_salaire");

                        string mois =
                            GetString(
                                reader,
                                "mois");

                        int annee =
                            GetInt(
                                reader,
                                "annee");

                        lbl_total_salaire.Text =
                            totalSalaire.ToString("N2") +
                            " $";

                        lbl_mois_salaire.Text =
                            mois + " " + annee;
                    }
                    else
                    {
                        lbl_total_salaire.Text =
                            "0.00 $";

                        lbl_mois_salaire.Text =
                            "Aucun salaire";
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement de la carte des salaires :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement de la carte des salaires :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // RECHERCHE
        // ============================================================

        private void txt_recherche_TextChanged(
            object sender,
            EventArgs e)
        {
            if (timerRecherche == null)
                return;

            timerRecherche.Stop();
            timerRecherche.Start();
        }

        // ============================================================
        // NUMERO MOIS
        // ============================================================

        private int ObtenirNumeroMois(string mois)
        {
            switch (mois)
            {
                case "Janvier":
                    return 1;

                case "Février":
                    return 2;

                case "Mars":
                    return 3;

                case "Avril":
                    return 4;

                case "Mai":
                    return 5;

                case "Juin":
                    return 6;

                case "Juillet":
                    return 7;

                case "Août":
                    return 8;

                case "Septembre":
                    return 9;

                case "Octobre":
                    return 10;

                case "Novembre":
                    return 11;

                case "Décembre":
                    return 12;

                default:
                    return 0;
            }
        }

        // ============================================================
        // ANNEES
        // ============================================================

        private void ChargerAnnees()
        {
            try
            {
                cbx_annee.Items.Clear();

                cbx_annee.Items.Add("Toutes");

                string query = @"
                    SELECT DISTINCT
                        YEAR(date_paiement) AS annee
                    FROM salaires
                    WHERE date_paiement IS NOT NULL
                    ORDER BY annee DESC";

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        null,
                        true))
                {
                    while (reader.Read())
                    {
                        cbx_annee.Items.Add(
                            GetString(
                                reader,
                                "annee"));
                    }
                }

                cbx_annee.SelectedIndex = 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des années :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des années :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // CHANGEMENT MOIS
        // ============================================================

        private void cbx_mois_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            LoadHistoriquePaiement();
        }

        // ============================================================
        // CHANGEMENT ANNEE
        // ============================================================

        private void cbx_annee_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            LoadHistoriquePaiement();
        }

        // ============================================================
        // AJOUT PERSONNEL
        // ============================================================

        private void bt_start_Click(
            object sender,
            EventArgs e)
        {
            MesForms.Personnel.Ajout_personnel personnel =
                new MesForms.Personnel.Ajout_personnel();

            personnel.ShowDialog();
        }

        // ============================================================
        // UTILITAIRES
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

        private decimal GetDecimal(
            MySqlDataReader reader,
            string colonne)
        {
            if (reader[colonne] == DBNull.Value)
                return 0m;

            return Convert.ToDecimal(
                reader[colonne]);
        }

        // ============================================================
        // CLASSE GROUPE SALAIRE
        // ============================================================

        private class GroupeSalaire
        {
            public string Mois { get; set; }
            public string Annee { get; set; }
        }
    }
}