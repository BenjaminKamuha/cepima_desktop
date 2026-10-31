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
    public partial class Ajouter_salaire : Form
    {
        private int idPersonnel = 0;
        private int idSalaire = 0;
        private bool modeModification = false;

        public Ajouter_salaire()
        {
            InitializeComponent();
        }

        public Ajouter_salaire(int idPersonnel) : this()
        {
            this.idPersonnel = idPersonnel;

            ChargerPersonnel();
            InitialiserFormulaire();
        }
        public Ajouter_salaire(int idPersonnel,int idSalaire) : this()
        {
            this.idPersonnel = idPersonnel;
            this.idSalaire = idSalaire;
            modeModification = true;

            ChargerPersonnel();
            InitialiserFormulaire();
            ChargerSalaire();
        }

        private void ChargerSalaire()
        {
            try
            {
                string requete = @"SELECT mois, date_paiement, salaire_base
                          FROM salaires
                          WHERE id_salaire = @idSalaire
                          AND id_personnel = @idPersonnel";

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddWithValue("@idSalaire", idSalaire);
                    commande.Parameters.AddWithValue("@idPersonnel", idPersonnel);

                    using (MySqlDataReader reader = commande.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cbMois.Text = reader["mois"].ToString();
                            dtpDatePaiement.Value = Convert.ToDateTime(reader["date_paiement"]);
                            nudSalaireBase.Value = Convert.ToDecimal(reader["salaire_base"]);
                        }
                        else
                        {
                            MessageBox.Show("Salaire introuvable.");
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement du salaire :\n" + ex.Message);
            }
        }
        private void Ajouter_salaire_Load(object sender, EventArgs e)
        {

        }

        private void ChargerPersonnel()
        {
            try
            {
                string requete = @"SELECT nom, post_nom, prenom
                           FROM personnels
                           WHERE id_personnel = @idPersonnel";

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddWithValue("@idPersonnel", idPersonnel);

                    using (MySqlDataReader reader = commande.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtPersonnel.Text = (
                                reader["nom"].ToString() + " " +
                                reader["post_nom"].ToString() + " " +
                                reader["prenom"].ToString()
                            ).Trim();
                        }
                        else
                        {
                            MessageBox.Show("Personnel introuvable.");
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement du personnel :\n" + ex.Message);
            }
        }

        private void InitialiserFormulaire()
        {
            cbMois.Items.Clear();

            System.Globalization.CultureInfo culture =
                new System.Globalization.CultureInfo("fr-FR");

            DateTime debut = new DateTime(DateTime.Today.Year, 1, 1);

            for (int i = 0; i < 24; i++)
            {
                DateTime date = debut.AddMonths(i);
                cbMois.Items.Add(date.ToString("MMMM yyyy", culture));
            }

            cbMois.SelectedItem = DateTime.Today.ToString("MMMM yyyy", culture);

            dtpDatePaiement.Value = DateTime.Today;
            nudSalaireBase.Minimum = 0;
            nudSalaireBase.Maximum = 100000000;
            nudSalaireBase.DecimalPlaces = 2;
            nudSalaireBase.Increment = 100;

            if (modeModification)
            {
                lbTitre.Text = "Modifier le salaire";
                lbSousTitre.Text = "Modifiez les informations du salaire sélectionné";
                btEnregistrer.Text = "Enregistrer les modifications";
            }
            else
            {
                lbTitre.Text = "Nouveau salaire";
                lbSousTitre.Text = "Enregistrer le salaire du personnel";
                btEnregistrer.Text = "Enregistrer";
            }
        }

        private void EnregistrerSalaire()
        {
            if (idPersonnel <= 0)
            {
                MessageBox.Show("Aucun personnel sélectionné.");
                return;
            }

            if (cbMois.SelectedIndex < 0)
            {
                MessageBox.Show("Veuillez sélectionner le mois.");
                cbMois.Focus();
                return;
            }

            if (nudSalaireBase.Value <= 0)
            {
                MessageBox.Show("Veuillez saisir un salaire de base valide.");
                nudSalaireBase.Focus();
                return;
            }

            try
            {
                string requete = @"INSERT INTO salaires
                           (id_personnel, mois, salaire_base, date_paiement, statut)
                           VALUES
                           (@idPersonnel, @mois, @salaireBase, @datePaiement, @statut)";

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddWithValue("@idPersonnel", idPersonnel);
                    commande.Parameters.AddWithValue("@mois", cbMois.Text);
                    commande.Parameters.AddWithValue("@salaireBase", nudSalaireBase.Value);
                    commande.Parameters.AddWithValue("@datePaiement", dtpDatePaiement.Value.Date);
                    commande.Parameters.AddWithValue("@statut", "En attente");

                    commande.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "Le salaire a été enregistré avec succès.",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'enregistrement du salaire :\n" + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btEnregistrer_Click(object sender, EventArgs e)
        {
            if (modeModification)
                ModifierSalaire();
            else
                EnregistrerSalaire();
        }

        private void ModifierSalaire()
        {
            if (idSalaire <= 0)
            {
                MessageBox.Show("Aucun salaire sélectionné.");
                return;
            }

            if (cbMois.SelectedIndex < 0)
            {
                MessageBox.Show("Veuillez sélectionner le mois.");
                cbMois.Focus();
                return;
            }

            if (nudSalaireBase.Value <= 0)
            {
                MessageBox.Show("Veuillez saisir un salaire de base valide.");
                nudSalaireBase.Focus();
                return;
            }

            try
            {
                string requete = @"UPDATE salaires
                           SET mois = @mois,
                               salaire_base = @salaireBase,
                               date_paiement = @datePaiement
                           WHERE id_salaire = @idSalaire
                           AND id_personnel = @idPersonnel";

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddWithValue("@mois", cbMois.Text);
                    commande.Parameters.AddWithValue("@salaireBase", nudSalaireBase.Value);
                    commande.Parameters.AddWithValue("@datePaiement", dtpDatePaiement.Value.Date);
                    commande.Parameters.AddWithValue("@idSalaire", idSalaire);
                    commande.Parameters.AddWithValue("@idPersonnel", idPersonnel);

                    int resultat = commande.ExecuteNonQuery();

                    if (resultat > 0)
                    {
                        MessageBox.Show(
                            "Le salaire a été modifié avec succès.",
                            "Succès",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Aucune modification effectuée.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la modification du salaire :\n" + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
