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


        // ============================================================
        // CHARGEMENT DES INFORMATIONS DU PRODUIT
        // ============================================================

        private void loadProdDetail()
        {
            try
            {
                Database database = new Database();

                using (MySqlConnection connection =
                    database.GetConnection())
                {
                    // CONSERVE COMME DANS TON CODE
                    connection.Open();


                    // =================================================
                    // REQUETE
                    // =================================================

                    string query = @"
                        SELECT

                            /* =================================================
                               MEDICAMENT
                               ================================================= */

                            m.id,
                            m.nom,
                            m.dosage,
                            m.FORME AS forme,
                            m.seuil_minimum,
                            m.prix_achat,
                            m.prix_vente,


                            /* =================================================
                               CATEGORIE
                               ================================================= */

                            c.id AS categorie_id,
                            c.nom AS categorie,
                            c.couleur AS categorie_couleur,


                            /* =================================================
                               UNITE DE GESTION
                               ================================================= */

                            u.id AS unite_gestion_id,
                            u.nom AS unite_gestion,
                            u.abreviation AS unite_abreviation,


                            /* =================================================
                               STOCK ACTUEL
                               ================================================= */

                            COALESCE(
                                stock.stock_actuel,
                                0
                            ) AS stock_actuel,


                            /* =================================================
                               QUANTITE DISTRIBUEE
                               ================================================= */

                            COALESCE(
                                distribution.quantite_distribuee,
                                0
                            ) AS quantite_distribuee,


                            /* =================================================
                               QUANTITE RECUE
                               ================================================= */

                            COALESCE(
                                reception.quantite_recue,
                                0
                            ) AS quantite_recue,


                            /* =================================================
                               TAUX DE DISTRIBUTION
                               ================================================= */

                            CASE

                                WHEN COALESCE(
                                    reception.quantite_recue,
                                    0
                                ) = 0

                                THEN 0

                                ELSE ROUND(
                                    (
                                        COALESCE(
                                            distribution.quantite_distribuee,
                                            0
                                        )
                                        /
                                        reception.quantite_recue
                                    ) * 100,
                                    2
                                )

                            END AS taux_distribution,


                            /* =================================================
                               FOURNISSEUR
                               ================================================= */

                            fournisseur.fournisseur_id,
                            fournisseur.fournisseur_nom,
                            fournisseur.fournisseur_telephone,
                            fournisseur.fournisseur_adresse


                        FROM medicament m


                        /* =====================================================
                           CATEGORIE
                           ===================================================== */

                        LEFT JOIN medicament_categorie c
                            ON c.id = m.categorie_id


                        /* =====================================================
                           UNITE DE GESTION
                           ===================================================== */

                        LEFT JOIN unite_gestion u
                            ON u.id = m.unite_gestion_id


                        /* =====================================================
                           STOCK
                           ===================================================== */

                        LEFT JOIN
                        (
                            SELECT
                                lm.medicament_id,
                                SUM(lm.quantite) AS stock_actuel

                            FROM lot_medicament lm

                            WHERE lm.medicament_id =
                                @medicament_id

                            GROUP BY
                                lm.medicament_id

                        ) stock

                            ON stock.medicament_id = m.id


                        /* =====================================================
                           DISTRIBUTION
                           ===================================================== */

                        LEFT JOIN
                        (
                            SELECT
                                dl.medicament_id,
                                SUM(dl.quantite)
                                    AS quantite_distribuee

                            FROM dispensation_ligne dl

                            WHERE dl.medicament_id =
                                @medicament_id

                            GROUP BY
                                dl.medicament_id

                        ) distribution

                            ON distribution.medicament_id = m.id


                        /* =====================================================
                           RECEPTION
                           ===================================================== */

                        LEFT JOIN
                        (
                            SELECT
                                ral.medicament_id,
                                SUM(ral.quantite)
                                    AS quantite_recue

                            FROM reception_achat_ligne ral

                            WHERE ral.medicament_id =
                                @medicament_id

                            GROUP BY
                                ral.medicament_id

                        ) reception

                            ON reception.medicament_id = m.id


                        /* =====================================================
                           DERNIER FOURNISSEUR

                           On récupère directement la dernière réception
                           du médicament demandé.

                           Cette méthode évite le gros GROUP BY + MAX()
                           de l'ancienne requête.
                           ===================================================== */

                        LEFT JOIN
                        (
                            SELECT
                                ral.medicament_id,

                                f.id AS fournisseur_id,
                                f.nom AS fournisseur_nom,
                                f.telephone AS fournisseur_telephone,
                                f.adresse AS fournisseur_adresse

                            FROM reception_achat_ligne ral

                            INNER JOIN reception_achat ra
                                ON ra.id = ral.reception_id

                            INNER JOIN fournisseur f
                                ON f.id = ra.fournisseur_id

                            WHERE ral.medicament_id =
                                @medicament_id

                            ORDER BY
                                ra.date_reception DESC,
                                ra.id DESC

                            LIMIT 1

                        ) fournisseur

                            ON fournisseur.medicament_id = m.id


                        /* =====================================================
                           MEDICAMENT DEMANDE
                           ===================================================== */

                        WHERE m.id = @medicament_id

                        LIMIT 1;
                    ";


                    // =================================================
                    // COMMANDE
                    // =================================================

                    using (MySqlCommand command =
                        new MySqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.Add(
                            "@medicament_id",
                            MySqlDbType.Int32
                        ).Value =
                            UC_stock_pharmacie.PROD_ID;


                        // =================================================
                        // LECTURE
                        // =================================================

                        using (MySqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "Le médicament demandé est introuvable.",
                                    "Information",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                return;
                            }


                            // =============================================
                            // INFORMATIONS PRODUIT
                            // =============================================

                            lb_prod_name.Text =
                                GetString(
                                    reader,
                                    "nom");

                            lb_prod_form.Text =
                                GetString(
                                    reader,
                                    "forme");

                            lb_prod_dose.Text =
                                GetString(
                                    reader,
                                    "dosage");

                            lb_price.Text =
                                GetString(
                                    reader,
                                    "prix_achat");

                            lb_prod_category.Text =
                                GetString(
                                    reader,
                                    "categorie");

                            lb_provider.Text =
                                GetString(
                                    reader,
                                    "fournisseur_nom");

                            lb_provide_phone.Text =
                                GetString(
                                    reader,
                                    "fournisseur_telephone");


                            // =============================================
                            // TAUX DISTRIBUTION
                            // =============================================

                            lb_taux_distribution.Text =
                                GetString(
                                    reader,
                                    "taux_distribution");


                            // =============================================
                            // SEUIL
                            // =============================================

                            lb_seuil.Text =
                                GetString(
                                    reader,
                                    "seuil_minimum");


                            // =============================================
                            // STOCK
                            // =============================================

                            lb_stock_now.Text =
                                GetString(
                                    reader,
                                    "stock_actuel");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur MySQL lors du chargement des informations :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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


        // ============================================================
        // LECTURE SECURISEE DES VALEURS
        // ============================================================

        private string GetString(
            MySqlDataReader reader,
            string column)
        {
            if (reader[column] == DBNull.Value)
            {
                return "";
            }

            return reader[column].ToString();
        }


        // ============================================================
        // LOAD USER CONTROL
        // ============================================================

        private void UC_detail_produit_Load(
            object sender,
            EventArgs e)
        {
            // =========================================================
            // POSITIONNEMENT
            // =========================================================

            UI.Position.CenterControl(
                lb_stock_now,
                c_pnl_stock_now,
                40);

            UI.Position.CenterControl(
                lb_seuil,
                c_pnl_seuil_min,
                40);

            UI.Position.CenterControl(
                lb_taux_distribution,
                c_pnl_taux,
                40);


            lb_taux_distribution.Left += 40;
            lb_stock_now.Left += 40;
            lb_seuil.Left += 40;


            // =========================================================
            // COULEURS
            // =========================================================

            Form_detail_produit.managerColor(
                pnl_detail_prod);


            // =========================================================
            // CHARGEMENT
            // =========================================================

            loadProdDetail();
        }


        private void pnl_detail_prod_Paint(
            object sender,
            PaintEventArgs e)
        {
        }
    }
}