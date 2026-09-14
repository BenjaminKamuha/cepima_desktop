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
namespace Cepima.MesForms.Personnel
{
    public partial class Detail_salaire : Form
    {
        string idPersonnel;
        public static Button btRefresh { get; set; }
        public Detail_salaire(string personnelID)
        {
            InitializeComponent();
            this.idPersonnel = personnelID;
            bt_modifier.Visible = false;
            bt_delete.Visible = false;
            btRefresh = bt_refresh;
            bt_delete.Click += bt_delete_Click;
        }

        void bt_delete_Click(object sender, EventArgs e)
        {
            // =========================================================
            // VERIFIER LA SELECTION
            // =========================================================

            if (dgv_historique.CurrentRow == null)
            {
                MessageBox.Show(
                    "Veuillez sélectionner une opération à supprimer.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            // =========================================================
            // VERIFIER QUE CE N'EST PAS UNE LIGNE VIDE
            // =========================================================

            if (dgv_historique.CurrentRow.Tag == null)
            {
                MessageBox.Show(
                    "Veuillez sélectionner une opération valide.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            // =========================================================
            // RECUPERER LES INFORMATIONS
            // =========================================================

            dynamic info = dgv_historique.CurrentRow.Tag;

            int idOperation = info.IdOperation;
            string type = info.Type;


            // =========================================================
            // CONFIRMATION
            // =========================================================

            DialogResult confirmation = MessageBox.Show(
                "Voulez-vous vraiment supprimer cette opération ?\n\n" +
                "Type : " + type,
                "Confirmation de suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes)
                return;


            // =========================================================
            // DETERMINER LA TABLE ET LA COLONNE ID
            // =========================================================

            string query = "";

            switch (type)
            {
                case "Avance":

                    query = @"
                DELETE FROM avances_salaire
                WHERE id_avance = @id";

                    break;


                case "Prime":

                    query = @"
                DELETE FROM prime
                WHERE id_prime = @id";

                    break;


                case "Retenue":

                    query = @"
                DELETE FROM retenue
                WHERE id_retenue = @id";

                    break;


                case "Salaire":

                    query = @"
                DELETE FROM salaires
                WHERE id_salaire = @id";

                    break;


                default:

                    MessageBox.Show(
                        "Type d'opération inconnu.",
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
            }


            // =========================================================
            // EXECUTION
            // =========================================================

            try
            {
                using (MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {
                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id",
                            idOperation);

                        int lignesSupprimees =
                            cmd.ExecuteNonQuery();

                        if (lignesSupprimees == 0)
                        {
                            MessageBox.Show("Aucune opération n'a été supprimée.","Information",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }


                // =========================================================
                // MESSAGE
                // =========================================================

                MessageBox.Show("Opération supprimée avec succès.","Succès",MessageBoxButtons.OK,MessageBoxIcon.Information);


                // =========================================================
                // ACTUALISER L'HISTORIQUE
                // =========================================================

                ChargerHistoriquePaie();


                // =========================================================
                // CACHER LES BOUTONS
                // =========================================================

                bt_modifier.Visible = false;
                bt_delete.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression :\n" +ex.Message,"Erreur",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Detail_salaire_Load(object sender, EventArgs e)
        {
            ChargerInfosPersonnelles();
            ChargerHistoriquePaie();
        }

        private void ChargerInfosPersonnelles()
        {
            try
            {
                string query = "SELECT nom,post_nom,sexe,date_naissance,fonction,telephone,adresse FROM personnels WHERE id_personnel = @id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",idPersonnel);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                {
                    while (reader.Read())
                    {
                        lb_nom.Text = reader["nom"].ToString();
                        lb_post_nom.Text = reader["post_nom"].ToString();
                        DateTime date = Convert.ToDateTime(reader["date_naissance"]);
                        int age = MesClasses.ReceptionManager.CalculerAge(date);
                        lb_age.Text = age.ToString() +" - "+ reader["sexe"];
                        lb_phone.Text = reader["telephone"].ToString();
                        lb_fonction.Text = reader["fonction"].ToString();
                        lb_adresse.Text = reader["adresse"].ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erreur : "+ex.Message);
            }
        }

        private void ChargerHistoriquePaie()
        {
            try
            {
                string query = @"

    /* =========================================================
       1. SALAIRES
       ========================================================= */

    SELECT
        s.id_salaire AS id_operation,

        s.id_salaire AS groupe_salaire,

        DATE_FORMAT(
            s.date_paiement,
            '%d/%m/%Y'
        ) AS date_operation,

        s.date_paiement AS date_tri,

        CONCAT(
            s.mois,
            ' ',
            YEAR(s.date_paiement)
        ) AS mois,

        'Salaire' AS type_operation,

        'Salaire de base' AS motif,

        s.salaire_base AS montant,

        NULL AS reste,

        /* ==========================================
           CALCUL DU SALAIRE NET
           Le résultat ne peut jamais être négatif
           ========================================== */

        GREATEST(

            s.salaire_base

            + COALESCE(
                (
                    SELECT SUM(pr.montant)
                    FROM prime pr
                    WHERE pr.id_salaire = s.id_salaire
                ),
                0
            )

            - COALESCE(
                (
                    SELECT SUM(r.montant)
                    FROM retenue r
                    WHERE r.id_salaire = s.id_salaire
                ),
                0
            )

            - COALESCE(
                (
                    SELECT SUM(a.montant)
                    FROM avances_salaire a
                    WHERE a.id_salaire = s.id_salaire
                ),
                0
            ),

            0

        ) AS net_a_payer,

        s.statut AS statut,

        2 AS ordre_operation,

        s.date_paiement AS date_salaire_tri

    FROM salaires s

    WHERE s.id_personnel = @id_personnel


    UNION ALL


    /* =========================================================
       2. PRIMES
       ========================================================= */

    SELECT
        pr.id_prime AS id_operation,

        s.id_salaire AS groupe_salaire,

        DATE_FORMAT(
            pr.date_prime,
            '%d/%m/%Y'
        ) AS date_operation,

        pr.date_prime AS date_tri,

        CONCAT(
            s.mois,
            ' ',
            YEAR(s.date_paiement)
        ) AS mois,

        'Prime' AS type_operation,

        pr.motif AS motif,

        pr.montant AS montant,

        NULL AS reste,

        NULL AS net_a_payer,

        NULL AS statut,

        1 AS ordre_operation,

        s.date_paiement AS date_salaire_tri

    FROM prime pr

    INNER JOIN salaires s
        ON s.id_salaire = pr.id_salaire

    WHERE s.id_personnel = @id_personnel


    UNION ALL


    /* =========================================================
       3. RETENUES
       ========================================================= */

    SELECT
        r.id_retenue AS id_operation,

        s.id_salaire AS groupe_salaire,

        DATE_FORMAT(
            r.date_retenue,
            '%d/%m/%Y'
        ) AS date_operation,

        r.date_retenue AS date_tri,

        CONCAT(
            s.mois,
            ' ',
            YEAR(s.date_paiement)
        ) AS mois,

        'Retenue' AS type_operation,

        r.motif AS motif,

        r.montant AS montant,

        NULL AS reste,

        NULL AS net_a_payer,

        NULL AS statut,

        1 AS ordre_operation,

        s.date_paiement AS date_salaire_tri

    FROM retenue r

    INNER JOIN salaires s
        ON s.id_salaire = r.id_salaire

    WHERE s.id_personnel = @id_personnel


    UNION ALL


    /* =========================================================
       4. AVANCES
       ========================================================= */

    SELECT
        a.id_avance AS id_operation,

        s.id_salaire AS groupe_salaire,

        DATE_FORMAT(
            a.date_avance,
            '%d/%m/%Y'
        ) AS date_operation,

        a.date_avance AS date_tri,

        CONCAT(
            s.mois,
            ' ',
            YEAR(s.date_paiement)
        ) AS mois,

        'Avance' AS type_operation,

        'Avance sur salaire' AS motif,

        a.montant AS montant,

        /* ==========================================
           PROTECTION DU RESTE
           ========================================== */

        GREATEST(
            a.reste,
            0
        ) AS reste,

        NULL AS net_a_payer,

        NULL AS statut,

        1 AS ordre_operation,

        s.date_paiement AS date_salaire_tri

    FROM avances_salaire a

    INNER JOIN salaires s
        ON s.id_salaire = a.id_salaire

    WHERE s.id_personnel = @id_personnel


    /* =========================================================
       ORDRE FINAL
       ========================================================= */

    ORDER BY
        date_salaire_tri DESC,
        groupe_salaire DESC,
        ordre_operation ASC,
        date_tri DESC
";


                // =========================================================
                // PARAMÈTRE
                // =========================================================

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_personnel",
                    idPersonnel
                );


                // =========================================================
                // EXÉCUTION
                // =========================================================

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    dgv_historique.Rows.Clear();

                    int dernierGroupeSalaire = -1;

                    while (reader.Read())
                    {
                        int groupeSalaire =
                            Convert.ToInt32(
                                reader["groupe_salaire"]);


                        // =================================================
                        // SÉPARATION ENTRE LES MOIS
                        // =================================================

                        if (dernierGroupeSalaire != -1 &&
                            dernierGroupeSalaire != groupeSalaire)
                        {
                            int ligneVide = dgv_historique.Rows.Add();

                            dgv_historique.Rows[ligneVide].Height = 25;

                            dgv_historique.Rows[ligneVide].ReadOnly = true;
                        }


                        // =================================================
                        // NOUVELLE LIGNE
                        // =================================================

                        int ligne =
                            dgv_historique.Rows.Add();


                        // =================================================
                        // DATE
                        // =================================================

                        dgv_historique.Rows[ligne]
                            .Cells["date"].Value =
                            reader["date_operation"].ToString();


                        // =================================================
                        // TYPE
                        // =================================================

                        dgv_historique.Rows[ligne]
                            .Cells["type"].Value =
                            reader["type_operation"].ToString();


                        // =================================================
                        // MOIS
                        // =================================================

                        dgv_historique.Rows[ligne]
                            .Cells["mois"].Value =
                            reader["mois"].ToString();


                        // =================================================
                        // MOTIF
                        // =================================================

                        dgv_historique.Rows[ligne]
                            .Cells["motif"].Value =
                            reader["motif"].ToString();


                        // =================================================
                        // MONTANT
                        // =================================================

                        if (reader["montant"] != DBNull.Value)
                        {
                            decimal montant =
                                Convert.ToDecimal(
                                    reader["montant"]);

                            dgv_historique.Rows[ligne]
                                .Cells["montant"].Value =
                                montant.ToString("N2") + " $";
                        }
                        else
                        {
                            dgv_historique.Rows[ligne]
                                .Cells["montant"].Value =
                                "-";
                        }


                        // =================================================
                        // RESTE
                        // =================================================

                        if (reader["reste"] != DBNull.Value)
                        {
                            decimal reste =
                                Convert.ToDecimal(
                                    reader["reste"]);

                            dgv_historique.Rows[ligne]
                                .Cells["reste"].Value =
                                reste.ToString("N2") + " $";
                        }
                        else
                        {
                            dgv_historique.Rows[ligne]
                                .Cells["reste"].Value =
                                "-";
                        }


                        // =================================================
                        // SALAIRE NET
                        // =================================================

                        if (reader["net_a_payer"] != DBNull.Value)
                        {
                            decimal net =
                                Convert.ToDecimal(
                                    reader["net_a_payer"]);

                            dgv_historique.Rows[ligne]
                                .Cells["net"].Value =
                                net.ToString("N2") + " $";
                        }
                        else
                        {
                            dgv_historique.Rows[ligne]
                                .Cells["net"].Value =
                                "-";
                        }



                        // =================================================
                        // INFORMATIONS CACHÉES
                        // =================================================


                        dgv_historique.Rows[ligne].Tag =
                            new
                            {
                                IdOperation =
                                    Convert.ToInt32(
                                        reader["id_operation"]),

                                IdSalaire =
                                    Convert.ToInt32(
                                        reader["groupe_salaire"]),

                                Type =
                                    reader["type_operation"]
                                    .ToString()
                            };


                        dernierGroupeSalaire = groupeSalaire;
                    }
                }


                // =========================================================
                // AUCUNE DONNÉE
                // =========================================================

                if (dgv_historique.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Aucun historique de paie trouvé pour ce personnel.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement de l'historique de paie :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private int RecupererIdOperationSelectionnee()
        {
            if (dgv_historique.CurrentRow == null)
                return 0;

            return Convert.ToInt32(
                dgv_historique.CurrentRow.Cells["id_operation"].Value
            );
        }
        private string RecupererTypeOperationSelectionnee()
        {
            if (dgv_historique.CurrentRow == null)
                return "";

            return dgv_historique.CurrentRow.Cells["type_operation"].Value.ToString();
        }
        private int RecupererIdSalaireSelectionne()
        {
            if (dgv_historique.CurrentRow == null)
                return 0;

            return Convert.ToInt32(
                dgv_historique.CurrentRow.Cells["groupe_salaire"].Value
            );
        }
        private void bt_modifier_Click(object sender, EventArgs e)
        {
            // Vérifier qu'une ligne est sélectionnée
            if (dgv_historique.CurrentRow == null)
            {
                MessageBox.Show(
                    "Veuillez sélectionner une opération à modifier.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            // Vérifier que ce n'est pas une ligne de séparation
            if (dgv_historique.CurrentRow.Tag == null)
            {
                MessageBox.Show(
                    "Veuillez sélectionner une opération valide.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            // Récupérer les informations stockées dans Tag
            dynamic info = dgv_historique.CurrentRow.Tag;

            int idOperation = info.IdOperation;
            int idSalaire = info.IdSalaire;
            string type = info.Type;


            // =========================================================
            // SELON LE TYPE D'OPÉRATION
            // =========================================================

            switch (type)
            {
                case "Prime":

                    Ajouter_prime frmPrime =
                        new Ajouter_prime(
                            idPersonnel,
                            idOperation
                        );

                    frmPrime.ShowDialog();

                    break;


                case "Retenue":

                    // Nous ferons le formulaire de modification
                    // de la retenue ici.

                 Ajouter_retenue frmRetenue =
        new Ajouter_retenue(
            idPersonnel,
            idOperation
        );

    frmRetenue.ShowDialog();

                    break;


                case "Avance":

                    // Nous ferons le formulaire de modification
                    // de l'avance ici.

                   Ajouter_avance frmAvance =
        new Ajouter_avance(
            idPersonnel,
            idOperation
        );

    frmAvance.ShowDialog();

                    break;


                case "Salaire":

                    // Nous ferons le formulaire de modification
                    // du salaire ici.
             Add_salaire frmSalaire = new Add_salaire(idPersonnel,idOperation);
             frmSalaire.ShowDialog();

                    break;


                default:

                    MessageBox.Show(
                        "Type d'opération inconnu.",
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    break;
            }
        }

        private void RecupererOperationSelectionnee(out int idOperation,out int idSalaire,out string type)
        {
            idOperation = 0;
            idSalaire = 0;
            type = "";

            if (dgv_historique.CurrentRow == null)
                return;

            if (dgv_historique.CurrentRow.Tag == null)
                return;

            dynamic info = dgv_historique.CurrentRow.Tag;

            idOperation = info.IdOperation;
            idSalaire = info.IdSalaire;
            type = info.Type;
        }
        private void dgv_historique_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgv_historique.Rows[e.RowIndex].Tag == null)
                return;

            dynamic info =
                dgv_historique.Rows[e.RowIndex].Tag;

            int idOperation = info.IdOperation;
            int idSalaire = info.IdSalaire;
            string type = info.Type;

            MessageBox.Show("Type : " + type +"\nID opération : " + idOperation +"\nID salaire : " + idSalaire);

            bt_delete.Visible = true;
            bt_modifier.Visible = true;
        }

        private void bt_refresh_Click(object sender, EventArgs e)
        {
            ChargerHistoriquePaie();
        }
    }
}
