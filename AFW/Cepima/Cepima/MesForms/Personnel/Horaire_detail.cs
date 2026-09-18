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
    public partial class Horaire_detail : Form
    {
        string idPersonnel;
        public Horaire_detail(string personnelID)
        {
            InitializeComponent();
            this.idPersonnel = personnelID;
        }

        private void Horaire_detail_Load(object sender, EventArgs e)
        {
            ChargerHoraires();
        }

        private void ChargerHoraires()
        {
            try
            {
                using (MySqlConnection connexion =
                    MesClasses.ManagerClasse.GetConnexion())
                {

                    string requete = @"
                SELECT
                    id_horaire,
                    jour_travail,
                    heure_entree_normal,
                    heure_sortie_normal
                FROM horaire
                WHERE id_personnel = @idPersonnel
                ORDER BY
                    CASE jour_travail
                        WHEN 'Lundi' THEN 1
                        WHEN 'Mardi' THEN 2
                        WHEN 'Mercredi' THEN 3
                        WHEN 'Jeudi' THEN 4
                        WHEN 'Vendredi' THEN 5
                        WHEN 'Samedi' THEN 6
                        WHEN 'Dimanche' THEN 7
                    END";

                    using (MySqlCommand commande =
                        new MySqlCommand(requete, connexion))
                    {
                        commande.Parameters.AddWithValue(
                            "@idPersonnel",
                            idPersonnel);

                        using (MySqlDataReader reader =
                            commande.ExecuteReader())
                        {
                            dgv_horaires.Rows.Clear();

                            while (reader.Read())
                            {
                                string idHoraire = "";

                                if (reader["id_horaire"] != DBNull.Value)
                                {
                                    idHoraire =
                                        reader["id_horaire"].ToString();
                                }

                                string jour = "";

                                if (reader["jour_travail"] != DBNull.Value)
                                {
                                    jour =
                                        reader["jour_travail"].ToString();
                                }

                                string heureEntree = "";

                                if (reader["heure_entree_normal"] != DBNull.Value)
                                {
                                    heureEntree =
                                        reader["heure_entree_normal"].ToString();
                                }

                                string heureSortie = "";

                                if (reader["heure_sortie_normal"] != DBNull.Value)
                                {
                                    heureSortie =
                                        reader["heure_sortie_normal"].ToString();
                                }

                                // Ajouter une ligne
                                int indexLigne =
                                    dgv_horaires.Rows.Add();

                                DataGridViewRow ligne =
                                    dgv_horaires.Rows[indexLigne];

                                // ID caché
                                ligne.Cells["colIDHoraire"].Value =
                                    idHoraire;

                                // Données affichées
                                ligne.Cells["colJour"].Value =
                                    jour;

                                ligne.Cells["colHeureEntree"].Value =
                                    heureEntree;

                                ligne.Cells["colHeureSortie"].Value =
                                    heureSortie;
                            }

                            AppliquerStyleHoraires();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Impossible de charger les horaires.\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AppliquerStyleHoraires()
        {
            dgv_horaires.Columns["colIDHoraire"].Visible = false;

            dgv_horaires.Columns["colJour"].Width = 120;
            dgv_horaires.Columns["colHeureEntree"].Width = 120;
            dgv_horaires.Columns["colHeureSortie"].Width = 120;
            dgv_horaires.Columns["colModifier"].Width = 90;
            dgv_horaires.Columns["colSupprimer"].Width = 90;

            // Bouton Modifier
            DataGridViewButtonColumn boutonModifier =
                (DataGridViewButtonColumn)dgv_horaires.Columns["colModifier"];

            boutonModifier.FlatStyle = FlatStyle.Flat;

            boutonModifier.DefaultCellStyle.BackColor =
                Color.FromArgb(33, 150, 243);

            boutonModifier.DefaultCellStyle.ForeColor =
                Color.White;

            // Bouton Supprimer
            DataGridViewButtonColumn boutonSupprimer =
                (DataGridViewButtonColumn)dgv_horaires.Columns["colSupprimer"];

            boutonSupprimer.FlatStyle = FlatStyle.Flat;

            boutonSupprimer.DefaultCellStyle.BackColor =
                Color.FromArgb(244, 67, 54);

            boutonSupprimer.DefaultCellStyle.ForeColor =
                Color.White;
        }

        private void dgv_horaires_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ne rien faire si on clique sur l'en-tête
                if (e.RowIndex < 0)
                    return;

                // Vérifier la ligne sélectionnée
                DataGridViewRow ligne =
                    dgv_horaires.Rows[e.RowIndex];

                // Récupérer l'id de l'horaire
                string idHoraire = "";

                if (ligne.Cells["colIDHoraire"].Value != null)
                {
                    idHoraire =
                        ligne.Cells["colIDHoraire"].Value.ToString();
                }

                // Vérifier que l'ID existe
                if (string.IsNullOrWhiteSpace(idHoraire))
                {
                    MessageBox.Show(
                        "Impossible de déterminer l'horaire.",
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                // ============================================================
                // MODIFIER
                // ============================================================

                if (dgv_horaires.Columns[e.ColumnIndex].Name ==
                    "colModifier")
                {
                    using (Horaire formulaire =
                        new Horaire(idPersonnel, idHoraire))
                    {
                        if (formulaire.ShowDialog() == DialogResult.OK)
                        {
                            ChargerHoraires();
                        }
                    }
                }

                // ============================================================
                // SUPPRIMER
                // ============================================================

                else if (dgv_horaires.Columns[e.ColumnIndex].Name ==
                         "colSupprimer")
                {
                    DialogResult resultat =
                        MessageBox.Show(
                            "Voulez-vous vraiment supprimer cet horaire ?",
                            "Confirmation",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                    if (resultat != DialogResult.Yes)
                        return;

                    using (MySqlConnection connexion =
                        MesClasses.ManagerClasse.GetConnexion())
                    {

                        string requete = @"
                    DELETE FROM horaire
                    WHERE id_horaire = @idHoraire
                      AND id_personnel = @idPersonnel";

                        using (MySqlCommand commande =
                            new MySqlCommand(requete, connexion))
                        {
                            commande.Parameters.AddWithValue(
                                "@idHoraire",
                                idHoraire);

                            commande.Parameters.AddWithValue(
                                "@idPersonnel",
                                idPersonnel);

                            int resultatSuppression =
                                commande.ExecuteNonQuery();

                            if (resultatSuppression > 0)
                            {
                                MessageBox.Show(
                                    "Horaire supprimé avec succès.",
                                    "Suppression",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                ChargerHoraires();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "L'horaire n'existe plus.",
                                    "Information",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Une erreur est survenue.\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
