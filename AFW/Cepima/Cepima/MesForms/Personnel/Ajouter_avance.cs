using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cepima.MesForms.Personnel
{
    public partial class Ajouter_Avance : Form
    {
        private int idPersonnel = 0;
        private int idSalaire = 0;
        private int idAvance = 0;
        private bool modeModification = false;

        public Ajouter_Avance()
        {
            InitializeComponent();
        }

        // Ajout d'une nouvelle avance
        public Ajouter_Avance(int idPersonnel)
            : this()
        {
            this.idPersonnel = idPersonnel;

            ChargerPersonnel();
            ChargerSalaires();
            InitialiserFormulaire();
        }

        // Modification d'une avance existante
        public Ajouter_Avance(int idPersonnel, int idAvance): this()
        {
            this.idPersonnel = idPersonnel;
            this.idAvance = idAvance;
            modeModification = true;

            ChargerPersonnel();
            ChargerSalaires();
            InitialiserFormulaire();
            ChargerAvance();
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
                                Texte = reader["mois"] + " | " +
                                        Convert.ToDecimal(reader["salaire_base"]).ToString("N2") +
                                        " | " + reader["statut"]
                            });
                        }
                    }
                }

                if (cbSalaire.Items.Count > 0)
                    cbSalaire.SelectedIndex = 0;
                else
                    MessageBox.Show("Aucun salaire enregistré pour ce personnel.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des salaires :\n" + ex.Message);
            }
        }

        private void InitialiserFormulaire()
        {
            dtpDateAvance.Value = DateTime.Today;

            cbSalaire.DropDownStyle = ComboBoxStyle.DropDownList;

            nudMontant.Minimum = 0;
            nudMontant.Maximum = 100000000;
            nudMontant.DecimalPlaces = 2;
            nudMontant.Increment = 100;

            txtReste.ReadOnly = true;

            if (modeModification)
            {
                lbTitre.Text = "Modifier une avance";
                lbSousTitre.Text = "Modifier les informations de l'avance";
                btEnregistrer.Text = "Enregistrer les modifications";
            }
            else
            {
                lbTitre.Text = "Nouvelle avance";
                lbSousTitre.Text = "Enregistrer une avance sur salaire";
                btEnregistrer.Text = "Enregistrer";
            }
        }

        private decimal CalculerReste(int idSalaire)
        {
            string requete = @"SELECT
                       s.salaire_base
                       + COALESCE((SELECT SUM(p.montant)
                                   FROM prime p
                                   WHERE p.id_salaire = s.id_salaire), 0)
                       - COALESCE((SELECT SUM(r.montant)
                                   FROM retenue r
                                   WHERE r.id_salaire = s.id_salaire), 0)
                       - COALESCE((SELECT SUM(a.montant)
                                   FROM avances_salaire a
                                   WHERE a.id_salaire = s.id_salaire
                                   AND a.id_avance <> @idAvance), 0)
                       AS disponible
                       FROM salaires s
                       WHERE s.id_salaire = @idSalaire
                       AND s.id_personnel = @idPersonnel";

            using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
            using (MySqlCommand commande = new MySqlCommand(requete, connexion))
            {
                commande.Parameters.AddWithValue("@idSalaire", idSalaire);
                commande.Parameters.AddWithValue("@idPersonnel", idPersonnel);
                commande.Parameters.AddWithValue("@idAvance", idAvance);

                object resultat = commande.ExecuteScalar();

                return resultat == null || resultat == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(resultat);
            }
        }

        private void ActualiserReste()
        {
            if (cbSalaire.SelectedItem == null)
            {
                txtReste.Text = "0,00";
                return;
            }

            SalaireItem salaire = (SalaireItem)cbSalaire.SelectedItem;

            decimal disponible = CalculerReste(salaire.Id);
            decimal reste = disponible - nudMontant.Value;

            txtReste.Text = reste.ToString("N2");
        }

        private void cbSalaire_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualiserReste();
        }

        private void nudMontant_ValueChanged(object sender, EventArgs e)
        {
            ActualiserReste();
        }

        private void EnregistrerAvance()
        {
            if (idPersonnel <= 0 || cbSalaire.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un salaire.");
                cbSalaire.Focus();
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

                decimal disponible = CalculerReste(salaire.Id);

                if (nudMontant.Value > disponible)
                {
                    MessageBox.Show("Le montant de l'avance dépasse le montant disponible : " +
                                    disponible.ToString("N2"));
                    nudMontant.Focus();
                    return;
                }

                string requete = @"INSERT INTO avances_salaire
                           (id_salaire, date_avance, montant, reste)
                           VALUES
                           (@idSalaire, @dateAvance, @montant, @reste)";

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddWithValue("@idSalaire", salaire.Id);
                    commande.Parameters.AddWithValue("@dateAvance", dtpDateAvance.Value.Date);
                    commande.Parameters.AddWithValue("@montant", nudMontant.Value);
                    commande.Parameters.AddWithValue("@reste", disponible - nudMontant.Value);

                    commande.ExecuteNonQuery();
                }

                MessageBox.Show("L'avance a été enregistrée avec succès.",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement de l'avance :\n" + ex.Message);
            }
        }

        private void ChargerAvance()
        {
            try
            {
                string requete = @"SELECT a.id_salaire, a.date_avance, a.montant
                           FROM avances_salaire a
                           INNER JOIN salaires s ON s.id_salaire = a.id_salaire
                           WHERE a.id_avance = @idAvance
                           AND s.id_personnel = @idPersonnel";

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddWithValue("@idAvance", idAvance);
                    commande.Parameters.AddWithValue("@idPersonnel", idPersonnel);

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

                            dtpDateAvance.Value = Convert.ToDateTime(reader["date_avance"]);
                            nudMontant.Value = Convert.ToDecimal(reader["montant"]);
                        }
                        else
                        {
                            MessageBox.Show("Avance introuvable pour ce personnel.");
                            DialogResult = DialogResult.Cancel;
                            Close();
                            return;
                        }
                    }
                }

                ActualiserReste();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement de l'avance :\n" + ex.Message);
            }
        }

        private void ModifierAvance()
        {
            if (idAvance <= 0 || cbSalaire.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un salaire.");
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

                decimal disponible = CalculerReste(salaire.Id);

                if (nudMontant.Value > disponible)
                {
                    MessageBox.Show("Le montant de l'avance dépasse le montant disponible : " +
                                    disponible.ToString("N2"));
                    nudMontant.Focus();
                    return;
                }

                string requete = @"UPDATE avances_salaire
                           SET id_salaire = @idSalaire,
                               date_avance = @dateAvance,
                               montant = @montant,
                               reste = @reste
                           WHERE id_avance = @idAvance
                           AND EXISTS (
                               SELECT 1 FROM salaires
                               WHERE id_salaire = avances_salaire.id_salaire
                               AND id_personnel = @idPersonnel
                           )";

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddWithValue("@idSalaire", salaire.Id);
                    commande.Parameters.AddWithValue("@dateAvance", dtpDateAvance.Value.Date);
                    commande.Parameters.AddWithValue("@montant", nudMontant.Value);
                    commande.Parameters.AddWithValue("@reste", disponible - nudMontant.Value);
                    commande.Parameters.AddWithValue("@idAvance", idAvance);
                    commande.Parameters.AddWithValue("@idPersonnel", idPersonnel);

                    int resultat = commande.ExecuteNonQuery();

                    if (resultat > 0)
                    {
                        MessageBox.Show("L'avance a été modifiée avec succès.",
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
                MessageBox.Show("Erreur lors de la modification de l'avance :\n" + ex.Message);
            }
        }

        private void btEnregistrer_Click(object sender, EventArgs e)
        {
            if (modeModification)
                ModifierAvance();
            else
                EnregistrerAvance();
        }
    }

    //public class SalaireItem
    //{
    //    public int ID { get; set; }
    //    public string Text { get; set; }

    //    public override string ToString()
    //    {
    //        return Texte;
    //    }
    //}
}
