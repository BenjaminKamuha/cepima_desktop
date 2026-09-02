using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cepima.MesForms;
using Cepima.Data;
using MySql.Data.MySqlClient;

namespace Cepima.MesUserCases.Pharmacie
{
    public partial class UC_detail_produit : UserControl
    {
        public UC_detail_produit()
        {
            InitializeComponent();
        }

        // Chargement des informationd u produit
        private void loadProdDetail()
        {
            try
            {
                Database database = new Database();

                using (MySqlConnection connection =
                       database.GetConnection())
                {
                    connection.Open();

                    string query = @"SELECT
                                    /* =====================================================
                                       INFORMATIONS DU MÉDICAMENT
                                       ===================================================== */

                                    m.id,
                                    m.nom,
                                    m.dosage,
                                    m.FORME AS forme,

                                    m.seuil_minimum,

                                    m.prix_achat,
                                    m.prix_vente,

                                    /* Catégorie */
                                    c.id AS categorie_id,
                                    c.nom AS categorie,
                                    c.couleur AS categorie_couleur,

                                    /* Unité de gestion */
                                    u.id AS unite_gestion_id,
                                    u.nom AS unite_gestion,
                                    u.abreviation AS unite_abreviation,


                                    /* =====================================================
                                       STOCK ACTUEL
                                       ===================================================== */

                                    COALESCE(
                                        (
                                            SELECT SUM(lm.quantite)
                                            FROM lot_medicament lm
                                            WHERE lm.medicament_id = m.id
                                        ),
                                        0
                                    ) AS stock_actuel,


                                    /* =====================================================
                                       QUANTITÉ DISTRIBUÉE
                                       ===================================================== */

                                    COALESCE(
                                        (
                                            SELECT SUM(dl.quantite)
                                            FROM dispensation_ligne dl
                                            WHERE dl.medicament_id = m.id
                                        ),
                                        0
                                    ) AS quantite_distribuee,


                                    /* =====================================================
                                       QUANTITÉ REÇUE
                                       ===================================================== */

                                    COALESCE(
                                        (
                                            SELECT SUM(ral.quantite)
                                            FROM reception_achat_ligne ral
                                            WHERE ral.medicament_id = m.id
                                        ),
                                        0
                                    ) AS quantite_recue,


                                    /* =====================================================
                                       TAUX DE DISTRIBUTION
       
                                       quantité distribuée / quantité reçue × 100
                                       ===================================================== */

                                    CASE
                                        WHEN COALESCE(
                                            (
                                                SELECT SUM(ral.quantite)
                                                FROM reception_achat_ligne ral
                                                WHERE ral.medicament_id = m.id
                                            ),
                                            0
                                        ) = 0
                                        THEN 0

                                        ELSE ROUND(
                                            (
                                                COALESCE(
                                                    (
                                                        SELECT SUM(dl.quantite)
                                                        FROM dispensation_ligne dl
                                                        WHERE dl.medicament_id = m.id
                                                    ),
                                                    0
                                                )
                                                /
                                                (
                                                    SELECT SUM(ral.quantite)
                                                    FROM reception_achat_ligne ral
                                                    WHERE ral.medicament_id = m.id
                                                )
                                            ) * 100,
                                            2
                                        )
                                    END AS taux_distribution,


                                    /* =====================================================
                                       FOURNISSEUR
                                       Dernier fournisseur associé à une réception
                                       ===================================================== */

                                    (
                                        SELECT f.id

                                        FROM fournisseur f

                                        INNER JOIN reception_achat ra
                                            ON ra.fournisseur_id = f.id

                                        INNER JOIN reception_achat_ligne ral
                                            ON ral.reception_id = ra.id

                                        WHERE ral.medicament_id = m.id

                                        ORDER BY ra.date_reception DESC

                                        LIMIT 1
                                    ) AS fournisseur_id,


                                    (
                                        SELECT f.nom

                                        FROM fournisseur f

                                        INNER JOIN reception_achat ra
                                            ON ra.fournisseur_id = f.id

                                        INNER JOIN reception_achat_ligne ral
                                            ON ral.reception_id = ra.id

                                        WHERE ral.medicament_id = m.id

                                        ORDER BY ra.date_reception DESC

                                        LIMIT 1
                                    ) AS fournisseur_nom,


                                    (
                                        SELECT f.telephone

                                        FROM fournisseur f

                                        INNER JOIN reception_achat ra
                                            ON ra.fournisseur_id = f.id

                                        INNER JOIN reception_achat_ligne ral
                                            ON ral.reception_id = ra.id

                                        WHERE ral.medicament_id = m.id

                                        ORDER BY ra.date_reception DESC

                                        LIMIT 1
                                    ) AS fournisseur_telephone,


                                    (
                                        SELECT f.adresse

                                        FROM fournisseur f

                                        INNER JOIN reception_achat ra
                                            ON ra.fournisseur_id = f.id

                                        INNER JOIN reception_achat_ligne ral
                                            ON ral.reception_id = ra.id

                                        WHERE ral.medicament_id = m.id

                                        ORDER BY ra.date_reception DESC

                                        LIMIT 1
                                    ) AS fournisseur_adresse


                                FROM medicament m


                                /* =====================================================
                                   CATÉGORIE
                                   ===================================================== */

                                LEFT JOIN medicament_categorie c
                                    ON c.id = m.categorie_id


                                /* =====================================================
                                   UNITÉ DE GESTION
                                   ===================================================== */

                                LEFT JOIN unite_gestion u
                                    ON u.id = m.unite_gestion_id


                                /* =====================================================
                                   MÉDICAMENT DEMANDÉ
                                   ===================================================== */

                                WHERE m.id = @medicament_id;";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                           
                    {
                        command.Parameters.AddWithValue("@medicament_id", UC_stock_pharmacie.PROD_ID);
                        using (MySqlDataReader reader =
                               command.ExecuteReader())
                        {
                            // Vider la liste

                            while (reader.Read())
                            {
                                lb_prod_name.Text += " " + reader["nom"].ToString();
                                lb_prod_form.Text += " " + reader["forme"].ToString();
                                lb_prod_dose.Text += " " + reader["dosage"].ToString();
                                lb_price.Text += " " + reader["prix_achat"].ToString();
                                lb_prod_category.Text += " " + reader["categorie"].ToString();
                                lb_provider.Text += " " + reader["fournisseur_nom"].ToString();
                                lb_provide_phone.Text += " " + reader["fournisseur_telephone"].ToString();
                                lb_taux_distribution.Text = reader["taux_distribution"].ToString();
                                lb_seuil.Text = reader["seuil_minimum"].ToString();
                                lb_stock_now.Text = reader["stock_actuel"].ToString(); 

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des informations :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UC_detail_produit_Load(object sender, EventArgs e)
        {
            UI.Position.CenterControl(lb_stock_now, c_pnl_stock_now, 40);
            UI.Position.CenterControl(lb_seuil, c_pnl_seuil_min, 40);
            UI.Position.CenterControl(lb_taux_distribution, c_pnl_taux, 40);
            lb_taux_distribution.Left += 40;
            lb_stock_now.Left += 40;
            lb_seuil.Left += 40;
            Form_detail_produit.managerColor(pnl_detail_prod);
            loadProdDetail();
        }

        private void pnl_detail_prod_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
