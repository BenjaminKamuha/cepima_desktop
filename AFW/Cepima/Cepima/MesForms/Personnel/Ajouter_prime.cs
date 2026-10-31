using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cepima.MesForms.Personnel
{
    public partial class Ajouter_prime : Form
    {
        private int idPersonnel = 0;
        private int idSalaire = 0;
        private int idPrime = 0;
        private bool modeModification = false;

        public Ajouter_prime()
        {
            InitializeComponent();
        }

        // Nouveau personnel / nouvelle prime
        public Ajouter_prime(int idPersonnel) : this()
        {
            this.idPersonnel = idPersonnel;

            ChargerPersonnel();
            ChargerSalaires();
            InitialiserFormulaire();
        }

        // Modification d'une prime existante
        public Ajouter_prime(int idPersonnel, int idPrime) : this()
        {
            this.idPersonnel = idPersonnel;
            this.idPrime = idPrime;
            modeModification = true;

            ChargerPersonnel();
            ChargerSalaires();
            InitialiserFormulaire();
            ChargerPrime();
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
                            txtPersonnel.Text = reader["nom"] + " " +
                                               reader["post_nom"] + " " +
                                               reader["prenom"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement du personnel :\n" + ex.Message);
            }
        }

        private void ChargerSalaires()
        {
            try
            {
                cbSalaire.Items.Clear();

                string requete = @"SELECT id_salaire, mois, salaire_base, statut
                           FROM salaires
                           WHERE id_personnel = @idPersonnel
                           ORDER BY date_paiement DESC";

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddWithValue("@idPersonnel", idPersonnel);

                    using (MySqlDataReader reader = commande.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbSalaire.Items.Add(new SalaireItem
                            {
                                Id = Convert.ToInt32(reader["id_salaire"]),
                                Texte = reader["mois"].ToString() + " | " +
                                        Convert.ToDecimal(reader["salaire_base"]).ToString("N2") +
                                        " | " + reader["statut"].ToString()
                            });
                        }
                    }
                }

                if (cbSalaire.Items.Count > 0)
                {
                    cbSalaire.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show(
                        "Ce personnel ne possède aucun salaire enregistré.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des salaires :\n" + ex.Message);
            }
        }

        private void InitialiserFormulaire()
        {
            dtpDatePrime.Value = DateTime.Today;
            cbSalaire.DropDownStyle = ComboBoxStyle.DropDownList;
            nudMontant.Minimum = 0;
            nudMontant.Maximum = 100000000;
            nudMontant.DecimalPlaces = 2;
            nudMontant.Increment = 100;

            if (modeModification)
            {
                lbTitre.Text = "Modifier une prime";
                lbSousTitre.Text = "Modifier les informations de la prime";
                btEnregistrer.Text = "Enregistrer les modifications";
            }
            else
            {
                lbTitre.Text = "Ajouter une prime";
                lbSousTitre.Text = "Enregistrer une nouvelle prime";
                btEnregistrer.Text = "Enregistrer";
            }
        }

        private void ChargerPrime()
        {
            try
            {
                string requete = @"SELECT id_salaire, date_prime, motif, montant
                           FROM prime
                           WHERE id_prime = @idPrime";

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddWithValue("@idPrime", idPrime);

                    using (MySqlDataReader reader = commande.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idSalaire = Convert.ToInt32(reader["id_salaire"]);

                            foreach (SalaireItem item in cbSalaire.Items)
                            {
                                if (item.Id == idSalaire)
                                {
                                    cbSalaire.SelectedItem = item;
                                    break;
                                }
                            }

                            dtpDatePrime.Value = Convert.ToDateTime(reader["date_prime"]);
                            txtMotif.Text = reader["motif"].ToString();
                            nudMontant.Value = Convert.ToDecimal(reader["montant"]);
                        }
                        else
                        {
                            MessageBox.Show("Prime introuvable.");
                            DialogResult = DialogResult.Cancel;
                            Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement de la prime :\n" + ex.Message);
            }
        }

        private void EnregistrerPrime()
        {
            if (idPersonnel <= 0 || cbSalaire.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un salaire.");
                cbSalaire.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotif.Text))
            {
                MessageBox.Show("Veuillez saisir le motif de la prime.");
                txtMotif.Focus();
                return;
            }

            if (nudMontant.Value <= 0)
            {
                MessageBox.Show("Veuillez saisir un montant valide.");
                nudMontant.Focus();
                return;
            }

            try
            {
                SalaireItem salaire = (SalaireItem)cbSalaire.SelectedItem;

                string requete = @"INSERT INTO prime
                           (id_salaire, date_prime, motif, montant)
                           VALUES
                           (@idSalaire, @datePrime, @motif, @montant)";

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddWithValue("@idSalaire", salaire.Id);
                    commande.Parameters.AddWithValue("@datePrime", dtpDatePrime.Value.Date);
                    commande.Parameters.AddWithValue("@motif", txtMotif.Text.Trim());
                    commande.Parameters.AddWithValue("@montant", nudMontant.Value);

                    commande.ExecuteNonQuery();
                }

                MessageBox.Show("La prime a été enregistrée avec succès.",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement de la prime :\n" + ex.Message);
            }
        }

        private void ModifierPrime()
        {
            if (cbSalaire.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un salaire.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotif.Text))
            {
                MessageBox.Show("Veuillez saisir le motif de la prime.");
                txtMotif.Focus();
                return;
            }

            if (nudMontant.Value <= 0)
            {
                MessageBox.Show("Veuillez saisir un montant valide.");
                nudMontant.Focus();
                return;
            }

            try
            {
                SalaireItem salaire = (SalaireItem)cbSalaire.SelectedItem;

                string requete = @"UPDATE prime
                           SET id_salaire = @idSalaire,
                               date_prime = @datePrime,
                               motif = @motif,
                               montant = @montant
                           WHERE id_prime = @idPrime";

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddWithValue("@idSalaire", salaire.Id);
                    commande.Parameters.AddWithValue("@datePrime", dtpDatePrime.Value.Date);
                    commande.Parameters.AddWithValue("@motif", txtMotif.Text.Trim());
                    commande.Parameters.AddWithValue("@montant", nudMontant.Value);
                    commande.Parameters.AddWithValue("@idPrime", idPrime);

                    int resultat = commande.ExecuteNonQuery();

                    if (resultat > 0)
                    {
                        MessageBox.Show("La prime a été modifiée avec succès.",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Aucune modification effectuée.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification de la prime :\n" + ex.Message);
            }
        }

        private void btEnregistrer_Click(object sender, EventArgs e)
        {
            if (modeModification)
                ModifierPrime();
            else
                EnregistrerPrime();
        }
    }

    //public class SalaireItem
    //{
    //    public int Id { get; set; }
    //    public string Texte { get; set; }

    //    public override string ToString()
    //    {
    //        return Texte;
    //    }
    //}
}
