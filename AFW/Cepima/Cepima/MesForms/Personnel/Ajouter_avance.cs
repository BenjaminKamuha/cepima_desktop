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
    public partial class Ajouter_avance : Form
    {
        string idPersonnel;
        private decimal salaireBase;
        private decimal avancesDejaRecues;
        private decimal resteDisponible;
        private int idAvance;
        private bool modeModification = false;

        public Ajouter_avance(string id_personnel)
        {
            InitializeComponent();
            this.idPersonnel = id_personnel;
            ChargerSalaireConcerne();
            chargementTermine = true;
            this.Text = "Ajouter une avance";
            label1.Text = this.Text;
            bt_start.Text = this.Text;
        }

        public Ajouter_avance(string id_personnel, int id_avance)
        {
            InitializeComponent();

            this.idPersonnel = id_personnel;
            this.idAvance = id_avance;

            modeModification = true;
            modeModification = true;
            this.Text = "Modifier une avance";
            label1.Text = this.Text;
            bt_start.Text = this.Text;
        }
        private int idSalaire;

        private void ChargerSalaireConcerne()
        {
            try
            {
                string query = @"
            SELECT 
                s.id_salaire,
                s.mois,
                s.salaire_base,
                p.nom,
                p.post_nom,
                p.prenom
            FROM salaires s
            INNER JOIN personnels p 
                ON p.id_personnel = s.id_personnel
            WHERE p.id_personnel = @id
            ORDER BY s.id_salaire DESC
            LIMIT 1";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id",
                    idPersonnel
                );

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    if (reader.Read())
                    {
                        // ==========================================
                        // ID DU SALAIRE
                        // ==========================================

                        idSalaire =
                            Convert.ToInt32(reader["id_salaire"]);


                        // ==========================================
                        // PERSONNEL
                        // ==========================================

                        string nom =
                            reader["nom"].ToString();

                        string postNom =
                            reader["post_nom"].ToString();

                        string prenom =
                            reader["prenom"].ToString();

                        lblPersonnel.Text =
                            nom + " " + postNom + " " + prenom;


                        // ==========================================
                        // SALAIRE DE BASE
                        // ==========================================

                        salaireBase =
                            Convert.ToDecimal(reader["salaire_base"]);

                        lblSalaire.Text =
                            salaireBase.ToString("N2") + " $";


                        // ==========================================
                        // MOIS
                        // ==========================================

                        lblMois.Text =
                            reader["mois"].ToString();


                        // ==========================================
                        // CALCUL DES AVANCES
                        // ==========================================

                        CalculerAvancesDejaRecues();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Aucun salaire enregistré pour ce personnel.",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du salaire concerné :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void ChargerCalculsAvance()
        {
            try
            {
                int idSalaire = MesForms.Personnel.Ajouter_prime.RecupererIDSalaire(Convert.ToInt32(idPersonnel));
                string query = "SELECT s.salaire_base,COALESCE((SELECT SUM(a.montant) FROM avances_salaire a WHERE a.id_salaire = s.id_salaire), 0) AS total_avances FROM salaires s WHERE s.id_salaire = @id_salaire";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add("@id_salaire", idSalaire.ToString());

                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                {
                    if (reader.Read())
                    {
                        salaireBase = Convert.ToDecimal(reader["salaire_base"]);

                        avancesDejaRecues =
                            Convert.ToDecimal(reader["total_avances"]);

                        // Afficher les avances déjà reçues
                        tb_avancesDejaRecues.Text =
                            avancesDejaRecues.ToString("N2");

                        // Calculer le reste disponible
                        resteDisponible =
                            salaireBase - avancesDejaRecues;

                        tb_reste.Text =
                            resteDisponible.ToString("N2");
                    }
                    else
                    {
                        MessageBox.Show(
                            "Le salaire concerné est introuvable.",
                            "Erreur",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        Close();
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du calcul des avances :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void bt_start_Click(object sender, EventArgs e)
        {
            if (modeModification)
            {
                ModifierAvance();
                MesForms.Personnel.Detail_salaire.btRefresh.PerformClick();
            }
            else
            {
                AjouterAvance();
                MesForms.Personnel.Detail_salaire.btRefresh.PerformClick();
            }
        }

        private void tb_montantAvance_TextChanged(object sender, EventArgs e)
        {
            if (!chargementTermine)
                return;

            decimal montantAvance;

            if (decimal.TryParse(
                tb_montantAvance.Text,
                out montantAvance))
            {
                decimal nouveauReste =
                    resteDisponible - montantAvance;

                if (nouveauReste >= 0)
                {
                    tb_reste.Text =
                        nouveauReste.ToString("N2");
                }
                else
                {
                    tb_reste.Text = "0.00";
                }
            }
            else
            {
                tb_reste.Text =
                    resteDisponible.ToString("N2");
            }
        }

        private void CalculerAvancesDejaRecues()
        {
            try
            {
                string query;

                if (modeModification)
                {
                    query = @"
                SELECT COALESCE(SUM(montant), 0)
                FROM avances_salaire
                WHERE id_salaire = @id_salaire
                AND id_avance <> @id_avance";
                }
                else
                {
                    query = @"
                SELECT COALESCE(SUM(montant), 0)
                FROM avances_salaire
                WHERE id_salaire = @id_salaire";
                }

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_salaire",
                    idSalaire.ToString()
                );

                if (modeModification)
                {
                    MesClasses.ManagerClasse.request_params.Add(
                        "@id_avance",
                        idAvance.ToString()
                    );
                }

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    if (reader.Read())
                    {
                        avancesDejaRecues =
                            Convert.ToDecimal(reader[0]);
                    }
                    else
                    {
                        avancesDejaRecues = 0;
                    }
                }

                tb_avancesDejaRecues.Text =
                    avancesDejaRecues.ToString("N2");

                resteDisponible =
                    salaireBase - avancesDejaRecues;

                if (resteDisponible < 0)
                    resteDisponible = 0;

                // En modification, le montant actuel
                // doit pouvoir être conservé.
                if (modeModification)
                {
                    decimal montantActuel = 0;

                    decimal.TryParse(
                        tb_montantAvance.Text,
                        out montantActuel
                    );

                    tb_reste.Text =
                        (resteDisponible - montantActuel >= 0
                            ? resteDisponible - montantActuel
                            : 0
                        ).ToString("N2");
                }
                else
                {
                    tb_reste.Text =
                        resteDisponible.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du calcul des avances :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void Ajouter_avance_Load(object sender, EventArgs e)
        {
            if (modeModification)
            {
                ChargerAvance();
            }
        }
        private bool chargementTermine = false;
        private void ChargerAvance()
        {
            try
            {
                string query = @"
            SELECT
                a.id_avance,
                a.id_salaire,
                a.date_avance,
                a.montant,
                s.mois,
                s.salaire_base,
                p.nom,
                p.post_nom,
                p.prenom
            FROM avances_salaire a
            INNER JOIN salaires s
                ON s.id_salaire = a.id_salaire
            INNER JOIN personnels p
                ON p.id_personnel = s.id_personnel
            WHERE a.id_avance = @id_avance";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_avance",
                    idAvance.ToString()
                );

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    if (reader.Read())
                    {
                        idSalaire = Convert.ToInt32(reader["id_salaire"]);

                        salaireBase =
                            Convert.ToDecimal(reader["salaire_base"]);

                        lblPersonnel.Text =
                            reader["nom"].ToString() + " " +
                            reader["post_nom"].ToString() + " " +
                            reader["prenom"].ToString();

                        lblSalaire.Text =
                            salaireBase.ToString("N2") + " $";

                        lblMois.Text =
                            reader["mois"].ToString();

                        dtp_date_paiement.Value =
                            Convert.ToDateTime(reader["date_avance"]);

                        tb_montantAvance.Text =
                            Convert.ToDecimal(reader["montant"])
                            .ToString("0.00");

                        // Calculer les autres avances
                        CalculerAvancesDejaRecues();
                    }
                    else
                    {
                        MessageBox.Show(
                            "L'avance est introuvable.",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement de l'avance :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ModifierAvance()
        {
            decimal montant;

            // ==========================================
            // VERIFIER LE MONTANT
            // ==========================================

            if (!decimal.TryParse(
                tb_montantAvance.Text,
                out montant))
            {
                MessageBox.Show(
                    "Veuillez saisir un montant d'avance valide.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (montant <= 0)
            {
                MessageBox.Show(
                    "Le montant doit être supérieur à zéro.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // ==========================================
            // CALCUL DU NOUVEAU RESTE
            // ==========================================

            decimal nouveauReste =
                resteDisponible - montant;

            if (nouveauReste < 0)
            {
                MessageBox.Show(
                    "Le montant est supérieur au reste disponible.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using (MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {
                    string query = @"
                UPDATE avances_salaire
                SET
                    date_avance = @date_avance,
                    montant = @montant,
                    reste = @reste
                WHERE id_avance = @id_avance";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@date_avance",
                            dtp_date_paiement.Value.Date);

                        cmd.Parameters.AddWithValue(
                            "@montant",
                            montant);

                        cmd.Parameters.AddWithValue(
                            "@reste",
                            nouveauReste);

                        cmd.Parameters.AddWithValue(
                            "@id_avance",
                            idAvance);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Avance modifiée avec succès.",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Actualiser l'historique
                if (MesForms.Personnel.Detail_salaire.btRefresh != null)
                {
                    MesForms.Personnel.Detail_salaire.btRefresh.PerformClick();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la modification de l'avance :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AjouterAvance()
        {

            decimal montantAvance;

            if (!decimal.TryParse(
                tb_montantAvance.Text,
                out montantAvance))
            {
                MessageBox.Show(
                    "Veuillez saisir un montant d'avance valide.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (montantAvance <= 0)
            {
                MessageBox.Show(
                    "Le montant de l'avance doit être supérieur à zéro.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (montantAvance > resteDisponible)
            {
                MessageBox.Show(
                    "Le montant de l'avance est supérieur au reste disponible.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            decimal nouveauReste =
                resteDisponible - montantAvance;

            using (MySqlConnection con =
                MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string query = @"
                INSERT INTO avances_salaire
                (
                    id_salaire,
                    date_avance,
                    montant,
                    reste
                )
                VALUES
                (
                    @salaire,
                    @date,
                    @montant,
                    @reste
                )";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@salaire",
                            idSalaire);

                        cmd.Parameters.AddWithValue(
                            "@date",
                            dtp_date_paiement.Value.Date);

                        cmd.Parameters.AddWithValue(
                            "@montant",
                            montantAvance);

                        cmd.Parameters.AddWithValue(
                            "@reste",
                            nouveauReste);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show(
                        "Avance enregistrée avec succès.",
                        "Succès",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    MesForms.Personnel.Detail_Test.btRefresh.PerformClick();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur : " + ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }
    }
}
