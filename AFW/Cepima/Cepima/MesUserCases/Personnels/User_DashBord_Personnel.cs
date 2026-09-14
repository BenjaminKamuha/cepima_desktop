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
    public partial class User_DashBord_Personnel : UserControl
    {
        public User_DashBord_Personnel()
        {
            InitializeComponent();
            LoadStatistiquesPersonnel();
            LoadDerniersPersonnel();
            ChargerMois();
            ChargerAnnees();
            ChargerCarteSalaires();
            dgv_paiement.CellMouseDown += dgv_paiement_CellMouseDown;
        }

        void dgv_paiement_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgv_paiement.ClearSelection();

                dgv_paiement.Rows[e.RowIndex].Selected = true;

                dgv_paiement.CurrentCell = dgv_paiement.Rows[e.RowIndex].Cells[0];
            }
        }

        private int GetIDPersonnelSelectionne()
        {
            if (dgv_paiement.CurrentRow == null)
                return 0;

            return Convert.ToInt32(dgv_paiement.CurrentRow.Cells["id_personnel"].Value);
        }

        private int GetIDSalaireSelectionne()
        {
            if (dgv_paiement.CurrentRow == null)
                return 0;

            return Convert.ToInt32(dgv_paiement.CurrentRow.Cells["ID"].Value);
        }

        private void LoadStatistiquesPersonnel()
        {
            try
            {
                // =====================================================
                // 1. NOMBRE TOTAL DE PERSONNELS
                // =====================================================

                string queryTotal =
                    "SELECT COUNT(*) FROM personnels";

                using (MySqlDataReader reader =
                       MesClasses.ManagerClasse.CRUD(queryTotal, null, true))
                {
                    if (reader.Read())
                    {
                        lb_total.Text = reader[0].ToString();
                    }
                }


                // =====================================================
                // 2. NOMBRE DE PERSONNELS ACTIFS
                // =====================================================

                string queryActif =
                    "SELECT COUNT(*) FROM personnels WHERE actif = 1";

                using (MySqlDataReader reader =
                       MesClasses.ManagerClasse.CRUD(queryActif, null, true))
                {
                    if (reader.Read())
                    {
                        lb_actif.Text = reader[0].ToString();
                    }
                }


                // =====================================================
                // 3. NOMBRE DE PERSONNELS INACTIFS
                // =====================================================

                string queryInactif =
                    "SELECT COUNT(*) FROM personnels WHERE actif = 0";

                using (MySqlDataReader reader =
                       MesClasses.ManagerClasse.CRUD(queryInactif, null, true))
                {
                    if (reader.Read())
                    {
                        lb_inactif.Text = reader[0].ToString();
                    }
                }


                // =====================================================
                // 4. NOMBRE DE FONCTIONS
                // =====================================================

                string queryFonctions = "SELECT COUNT(DISTINCT fonction) FROM personnels WHERE fonction IS NOT NULL AND fonction <> ''";

                using (MySqlDataReader reader =
                       MesClasses.ManagerClasse.CRUD(queryFonctions, null, true))
                {
                    if (reader.Read())
                    {
                        lbl_total_salaire.Text = reader[0].ToString();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des statistiques : "
                    + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadDerniersPersonnel()
        {
            try
            {
                dgv_personnel.Rows.Clear();

                string query = "SELECT id_personnel,nom,post_nom,prenom,date_naissance,sexe,adresse,fonction,date_naissance FROM personnels ORDER BY id_personnel ASC LIMIT 10";

                using (MySqlDataReader reader =
                       MesClasses.ManagerClasse.CRUD(query, null, true))
                {
                    while (reader.Read())
                    {
                        string id = reader["id_personnel"].ToString();

                        string personnel =
                            reader["nom"].ToString() + " " +
                            reader["post_nom"].ToString() + " " +
                            reader["prenom"].ToString();

                        int age = CalculerAge(Convert.ToDateTime(reader["date_naissance"]));

                        string sexe = reader["sexe"].ToString();
                        string adresse = reader["adresse"].ToString();
                        string fonction = reader["fonction"].ToString();
                        string date = Convert.ToDateTime(reader["date_naissance"]).ToString("dd/MM/yyyy");
                        dgv_personnel.Rows.Add(
                            id,
                            personnel,
                            age +" ans",
                            sexe,
                            adresse,
                            fonction,
                            date
                        );
                        ApplyStytle();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du personnel : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private int CalculerAge(DateTime dateNaissance)
        {
            int age = DateTime.Now.Year - dateNaissance.Year;

            if (DateTime.Now < dateNaissance.AddYears(age))
            {
                age--;
            }

            return age;
        }

        private void ApplyStytle()
        {
            dgv_personnel.Columns["colID"].Width = 80;
            dgv_personnel.Columns["colPersonnel"].Width = 300;
        }

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

        private void LoadHistoriquePaiement()
        {
            try
            {
                dgv_paiement.Rows.Clear();

                // =========================================================
                // RÉCUPÉRER LES FILTRES
                // =========================================================

                string recherche = txt_recherche.Text.Trim();
                string moisSelectionne = cbx_mois.Text.Trim();
                string anneeSelectionnee = cbx_annee.Text.Trim();


                // =========================================================
                // REQUÊTE PRINCIPALE
                // =========================================================

                string query = @"
            SELECT

                s.id_salaire,

                s.id_personnel,

                CONCAT(
                    p.nom,
                    ' ',
                    p.post_nom,
                    ' ',
                    p.prenom
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


            /* =====================================================
               PRIMES
               ===================================================== */

            LEFT JOIN
            (
                SELECT
                    id_salaire,
                    SUM(montant) AS prime

                FROM prime

                GROUP BY id_salaire

            ) pr
                ON pr.id_salaire = s.id_salaire


            /* =====================================================
               RETENUES
               ===================================================== */

            LEFT JOIN
            (
                SELECT
                    id_salaire,
                    SUM(montant) AS retenue

                FROM retenue

                GROUP BY id_salaire

            ) r
                ON r.id_salaire = s.id_salaire


            /* =====================================================
               AVANCES
               ===================================================== */

            LEFT JOIN
            (
                SELECT
                    id_salaire,
                    SUM(montant) AS avance

                FROM avances_salaire

                GROUP BY id_salaire

            ) a
                ON a.id_salaire = s.id_salaire


            WHERE
            (
                p.nom LIKE @recherche
                OR p.post_nom LIKE @recherche
                OR p.prenom LIKE @recherche
            )
        ";


                // =========================================================
                // FILTRE PAR MOIS
                // =========================================================

                if (moisSelectionne != "Tous" &&
                    moisSelectionne != "")
                {
                    query += @"
                AND MONTH(s.date_paiement) = @mois
            ";
                }


                // =========================================================
                // FILTRE PAR ANNÉE
                // =========================================================

                if (anneeSelectionnee != "Toutes" &&
                    anneeSelectionnee != "")
                {
                    query += @"
                AND YEAR(s.date_paiement) = @annee
            ";
                }


                // =========================================================
                // ORDRE
                // =========================================================

                query += @"

            ORDER BY
                s.date_paiement DESC,
                s.id_salaire DESC
        ";


                // =========================================================
                // PARAMÈTRE RECHERCHE
                // =========================================================

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@recherche",
                    "%" + recherche + "%"
                );


                // =========================================================
                // PARAMÈTRE MOIS
                // =========================================================

                if (moisSelectionne != "Tous" &&
                    moisSelectionne != "")
                {
                    int numeroMois = ObtenirNumeroMois(moisSelectionne);

                    MesClasses.ManagerClasse.request_params.Add(
                        "@mois",
                        numeroMois.ToString()
                    );
                }


                // =========================================================
                // PARAMÈTRE ANNÉE
                // =========================================================

                if (anneeSelectionnee != "Toutes" &&
                    anneeSelectionnee != "")
                {
                    MesClasses.ManagerClasse.request_params.Add(
                        "@annee",
                        anneeSelectionnee
                    );
                }


                // =========================================================
                // EXÉCUTION
                // =========================================================

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
                        string mois = reader["mois"].ToString();

                        string annee =
                            reader["annee"].ToString();


                        // =====================================================
                        // CHANGEMENT DE MOIS
                        // =====================================================

                        if (dernierMois != "" &&
                            (
                                dernierMois != mois ||
                                derniereAnnee != annee
                            ))
                        {
                            int ligneVide =
                                dgv_paiement.Rows.Add();

                            dgv_paiement.Rows[ligneVide].Height = 20;

                            dgv_paiement.Rows[ligneVide].ReadOnly = true;
                        }


                        // =====================================================
                        // AJOUT DE LA LIGNE
                        // =====================================================

                        int row =
                            dgv_paiement.Rows.Add();


                        // =====================================================
                        // INFORMATIONS CACHÉES
                        // =====================================================

                        dgv_paiement.Rows[row]
                            .Cells["id_personnel"].Value =
                            Convert.ToInt32(
                                reader["id_personnel"]);


                        dgv_paiement.Rows[row]
                            .Cells["ID"].Value =
                            Convert.ToInt32(
                                reader["id_salaire"]);


                        // =====================================================
                        // PERSONNEL
                        // =====================================================

                        dgv_paiement.Rows[row]
                            .Cells["colPerson"].Value =
                            reader["personnel"].ToString();


                        // =====================================================
                        // FONCTION
                        // =====================================================

                        dgv_paiement.Rows[row]
                            .Cells["colFunction"].Value =
                            reader["fonction"].ToString();


                        // =====================================================
                        // SALAIRE
                        // =====================================================

                        dgv_paiement.Rows[row]
                            .Cells["colsalaire"].Value =
                            Convert.ToDecimal(
                                reader["salaire"])
                                .ToString("N2");


                        // =====================================================
                        // PRIME
                        // =====================================================

                        dgv_paiement.Rows[row]
                            .Cells["colPrime"].Value =
                            Convert.ToDecimal(
                                reader["prime"])
                                .ToString("N2");


                        // =====================================================
                        // RETENUE
                        // =====================================================

                        dgv_paiement.Rows[row]
                            .Cells["colRetenu"].Value =
                            Convert.ToDecimal(
                                reader["retenue"])
                                .ToString("N2");


                        // =====================================================
                        // AVANCE
                        // =====================================================

                        dgv_paiement.Rows[row]
                            .Cells["colAvance"].Value =
                            Convert.ToDecimal(
                                reader["avance"])
                                .ToString("N2");


                        // =====================================================
                        // STATUT
                        // =====================================================

                        dgv_paiement.Rows[row]
                            .Cells["colStatut"].Value =
                            reader["statut"].ToString();


                        // =====================================================
                        // INFORMATIONS DU MOIS
                        // =====================================================

                        dgv_paiement.Rows[row].Tag =
                            new
                            {
                                Mois = mois,
                                Annee = annee
                            };


                        // =====================================================
                        // MÉMORISER LE GROUPE
                        // =====================================================

                        dernierMois = mois;
                        derniereAnnee = annee;
                    }
                }


                // =========================================================
                // LARGEUR PERSONNEL
                // =========================================================

                if (dgv_paiement.Columns.Contains("colPerson"))
                {
                    dgv_paiement.Columns["colPerson"].Width = 200;
                }


                // =========================================================
                // AUCUN RÉSULTAT
                // =========================================================

                if (dgv_paiement.Rows.Count == 0)
                {
                    //MessageBox.Show(
                    //    "Aucun paiement ne correspond aux critères sélectionnés.",
                    //    "Information",
                    //    MessageBoxButtons.OK,
                    //    MessageBoxIcon.Information
                    //);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement de l'historique des paiements :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

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
                ORDER BY date_paiement DESC, id_salaire DESC
                LIMIT 1
            ) dernier
                ON dernier.mois = s.mois
                AND dernier.annee = YEAR(s.date_paiement)

            GROUP BY
                s.mois,
                YEAR(s.date_paiement)

            LIMIT 1";

                MesClasses.ManagerClasse.request_params.Clear();

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    if (reader.Read())
                    {
                        decimal totalSalaire =
                            reader["total_salaire"] != DBNull.Value
                            ? Convert.ToDecimal(reader["total_salaire"])
                            : 0;

                        string mois =
                            reader["mois"].ToString();

                        int annee =
                            Convert.ToInt32(reader["annee"]);

                        // ==============================
                        // TOTAL
                        // ==============================

                        lbl_total_salaire.Text =
                            totalSalaire.ToString("N2") + " $";


                        // ==============================
                        // MOIS + ANNÉE
                        // ==============================

                        lbl_mois_salaire.Text =
                            mois + " " + annee;
                    }
                    else
                    {
                        lbl_total_salaire.Text = "0.00 $";
                        lbl_mois_salaire.Text = "Aucun salaire";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement de la carte des salaires :\n"
                    + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void txt_recherche_TextChanged(object sender, EventArgs e)
        {
            LoadHistoriquePaiement();
        }

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

            ORDER BY annee DESC
        ";

                MesClasses.ManagerClasse.request_params.Clear();

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    while (reader.Read())
                    {
                        cbx_annee.Items.Add(
                            reader["annee"].ToString()
                        );
                    }
                }

                cbx_annee.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des années :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void cbx_mois_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHistoriquePaiement();
        }

        private void cbx_annee_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHistoriquePaiement();
        }
    }
}
