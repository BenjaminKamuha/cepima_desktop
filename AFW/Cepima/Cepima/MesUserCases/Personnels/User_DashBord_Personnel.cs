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
            LoadFilter();
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
                        lb_fonctions.Text = reader[0].ToString();
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

        private void LoadFilter()
        {
            cbx_filtrer.Items.Clear();
            cbx_filtrer.Items.Add("Tous");
            cbx_filtrer.Items.Add("Salaire");
            cbx_filtrer.Items.Add("Prime");
            cbx_filtrer.Items.Add("Retenue");
            cbx_filtrer.Items.Add("Avance");

            cbx_filtrer.SelectedIndex = 0;
            LoadHistoriquePaiement();
        }


        private void LoadHistoriquePaiement()
        {
            try
            {
                dgv_paiement.Rows.Clear();

                string recherche = txt_recherche.Text.Trim();
                string type = cbx_filtrer.Text;

                string query = "SELECT s.id_salaire,s.id_personnel,CONCAT(p.nom, ' ',p.post_nom, ' ',p.prenom) AS personnel,p.fonction,s.salaire_base AS salaire,IFNULL(r.retenue, 0) AS retenue,IFNULL(pr.prime, 0) AS prime,IFNULL(a.avance, 0) AS avance,s.statut FROM salaires s INNER JOIN personnels p ON p.id_personnel = s.id_personnel LEFT JOIN (SELECT id_salaire,SUM(montant) AS prime FROM prime GROUP BY id_salaire ) pr ON pr.id_salaire = s.id_salaire LEFT JOIN (SELECT id_salaire,SUM(montant) AS retenue FROM retenue GROUP BY id_salaire) r ON r.id_salaire = s.id_salaire LEFT JOIN (SELECT id_salaire,SUM(montant) AS avance FROM avances_salaire GROUP BY id_salaire) a ON a.id_salaire = s.id_salaire WHERE(p.nom LIKE @recherche OR p.post_nom LIKE @recherche OR p.prenom LIKE @recherche)";

                // =====================================================
                // FILTRE PAR TYPE DE SALAIRE
                // =====================================================

                if (type == "Salaire")
                {
                    query += " AND s.salaire_base > 0 ";
                }
                else if (type == "Prime")
                {
                    query += " AND IFNULL(pr.prime, 0) > 0 ";
                }
                else if (type == "Retenue")
                {
                    query += " AND IFNULL(r.retenue, 0) > 0 ";
                }
                else if (type == "Avance")
                {
                    query += " AND IFNULL(a.avance, 0) > 0 ";
                }

                query += " ORDER BY s.id_salaire DESC";


                // =====================================================
                // PARAMETRE DE RECHERCHE
                // =====================================================

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@recherche",
                    "%" + recherche + "%"
                );


                // =====================================================
                // EXECUTION
                // =====================================================

                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                {
                    while (reader.Read())
                    {
                        int row = dgv_paiement.Rows.Add();
                        dgv_paiement.Rows[row].Cells["id_personnel"].Value = Convert.ToInt32(reader["id_personnel"]);
                        dgv_paiement.Rows[row].Cells["ID"].Value = Convert.ToInt32(reader["id_salaire"]);
                        dgv_paiement.Rows[row].Cells["colPerson"].Value = reader["personnel"].ToString();
                        dgv_paiement.Rows[row].Cells["colFunction"].Value = reader["fonction"].ToString();
                        dgv_paiement.Rows[row].Cells["colsalaire"].Value = Convert.ToDecimal(reader["salaire"]);
                        dgv_paiement.Rows[row].Cells["colPrime"].Value = Convert.ToDecimal(reader["prime"]);
                        dgv_paiement.Rows[row].Cells["colRetenu"].Value = Convert.ToDecimal(reader["retenue"]);
                        dgv_paiement.Rows[row].Cells["colAvance"].Value = Convert.ToDecimal(reader["avance"]);
                        dgv_paiement.Rows[row].Cells["colStatut"].Value = reader["statut"].ToString();
                    }
                    reader.Close();
                    dgv_paiement.Columns["colPerson"].Width = 200;

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement de l'historique des paiements : "
                    + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void cbx_filtrer_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHistoriquePaiement();
        }

        private void txt_recherche_TextChanged(object sender, EventArgs e)
        {
            LoadHistoriquePaiement();
        }

    }
}
