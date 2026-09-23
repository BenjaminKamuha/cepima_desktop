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
namespace Cepima.MesForms.Compt
{
    public partial class DetailBon : Form
    {
        private string BON_ID;
        public DetailBon(string idBon)
        {
            InitializeComponent();
            this.BON_ID = idBon;
            ChargerDetailsBon();
        }

        private void bt_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {

                    // ---------------------------------------------------------
                    // 1. Vérifier le bon et récupérer son statut + montant
                    // ---------------------------------------------------------

                    string sqlVerif = @"
                SELECT montant, statut
                FROM bon_sortie
                WHERE id_bon = @id_bon";

                    decimal montant = 0;
                    string statut = "";

                    using (MySqlCommand cmd = new MySqlCommand(sqlVerif, con))
                    {
                        cmd.Parameters.AddWithValue("@id_bon", this.BON_ID);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "Le bon de sortie est introuvable.",
                                    "Erreur",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                                return;
                            }

                            montant = Convert.ToDecimal(reader["montant"]);
                            statut = reader["statut"].ToString();
                        }
                    }


                    // ---------------------------------------------------------
                    // 2. Vérifier le statut
                    // ---------------------------------------------------------

                    if (statut == "validé")
                    {
                        MessageBox.Show(
                            "Ce bon de sortie a déjà été validé.",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        return;
                    }

                    if (statut == "annulé")
                    {
                        MessageBox.Show(
                            "Ce bon de sortie a été annulé. Il ne peut pas être validé.",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }


                    // ---------------------------------------------------------
                    // 3. Demander confirmation
                    // ---------------------------------------------------------

                    DialogResult resultat = MessageBox.Show(
                        "Voulez-vous vraiment valider ce bon de sortie ?\n\n" +
                        "Montant : " + montant.ToString("N2") + " $",
                        "Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resultat != DialogResult.Yes)
                    {
                        return;
                    }


                    // ---------------------------------------------------------
                    // 4. Modifier le statut du bon
                    // ---------------------------------------------------------

                    string sqlUpdate = @"
                UPDATE bon_sortie
                SET statut = 'validé'
                WHERE id_bon = @id_bon
                AND statut = 'en attente'";

                    using (MySqlCommand cmd = new MySqlCommand(sqlUpdate, con))
                    {
                        cmd.Parameters.AddWithValue("@id_bon", this.BON_ID);

                        int lignesModifiees = cmd.ExecuteNonQuery();

                        if (lignesModifiees == 0)
                        {
                            MessageBox.Show(
                                "Le bon ne peut plus être validé.",
                                "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }


                    // ---------------------------------------------------------
                    // 5. Ajouter la sortie dans le livre de caisse
                    // ---------------------------------------------------------

                    MesClasses.ReceptionManager.AjouterLivreCaisse(
                        0,
                        montant,
                        "GENERALE",
                        "Bon de sortie N° " + this.BON_ID
                    );


                    // ---------------------------------------------------------
                    // 6. Message de succès
                    // ---------------------------------------------------------

                    MessageBox.Show(
                        "Le bon de sortie a été validé avec succès.\n\n" +
                        "La sortie a été enregistrée dans le livre de caisse.",
                        "Succès",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la validation du bon :\n" + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ChargerDetailsBon()
        {
            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {

                    string sql = @"
                SELECT 
                    nom_resp,
                    signature_donneur,
                    montant,
                    date,
                    statut
                FROM bon_sortie
                WHERE id_bon = @id_bon";

                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id_bon", this.BON_ID);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lb_responsable.Text =
                                    reader["nom_resp"].ToString();

                                lb_demandeur.Text =
                                    reader["signature_donneur"].ToString();

                                decimal montant =
                                    Convert.ToDecimal(reader["montant"]);

                                lb_montant.Text =
                                    montant.ToString("N2") + " $";

                                DateTime date =
                                    Convert.ToDateTime(reader["date"]);

                                lb_date.Text =
                                    date.ToString("dd/MM/yyyy");

                                lb_statut.Text =
                                    reader["statut"].ToString();

                                lb_statut.Text =
    reader["statut"].ToString();

                                // Afficher le bouton uniquement si le bon est en attente
                                if (lb_statut.Text == "En attente")
                                {
                                    bt_confirm.Visible = true;
                                }
                                else
                                {
                                    bt_confirm.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du bon :\n" + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void bt_print_Click(object sender, EventArgs e)
        {
            // imprimer le bon de recu 
            MesForms.Rapport.BonRapport bon = new Rapport.BonRapport(this.BON_ID);
            bon.ShowDialog();

            MesUserCases.Comptabilité.Bon_de_sortie.btRefresh.PerformClick();
        }
    }
}
