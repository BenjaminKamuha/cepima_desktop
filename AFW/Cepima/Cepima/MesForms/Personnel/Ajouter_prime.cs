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
    public partial class Ajouter_prime : Form
    {
        string idPersonnel;
        private int idPrime;

        private bool modeModification = false;

        //constructeur pour Ajout de la prime
        public Ajouter_prime(string personnel)
        {
            InitializeComponent();

            this.idPersonnel = personnel;
            modeModification = false;

            // Apparence du formulaire en mode ajout
            this.Text = "Ajouter une prime";
            label1.Text = "Ajouter une prime";

            bt_start.Text = "Enregistrer la prime";
            ChargerSalaireConcerne();
        }


        //constructeur pour modification
        // =========================================================
        // CONSTRUCTEUR : MODIFICATION
        // =========================================================

        public Ajouter_prime(string personnel, int idPrime)
        {
            InitializeComponent();

            this.idPersonnel = personnel;
            this.idPrime = idPrime;

            modeModification = true;

            ChargerSalaireConcerne();

            // Charger les informations de la prime
            ChargerPrime();

            // Apparence du formulaire en mode modification
            this.Text = "Modifier une prime";
            label1.Text = "Modifier une prime";

            bt_start.Text = "Modifier la prime";
        }


        private void ChargerPrime()
        {
            try
            {
                string query = @"
                    SELECT
                        date_prime,
                        motif,
                        montant
                    FROM prime
                    WHERE id_prime = @id_prime";


                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_prime",
                    idPrime.ToString()
                );


                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    if (reader.Read())
                    {
                        // ==============================
                        // DATE
                        // ==============================

                        if (reader["date_prime"] != DBNull.Value)
                        {
                            dtp_date_paiement.Value =
                                Convert.ToDateTime(
                                    reader["date_prime"]);
                        }


                        // ==============================
                        // MOTIF
                        // ==============================

                        tb_motif.Text =
                            reader["motif"].ToString();


                        // ==============================
                        // MONTANT
                        // ==============================

                        if (reader["montant"] != DBNull.Value)
                        {
                            decimal montant =
                                Convert.ToDecimal(
                                    reader["montant"]);

                            tb_montant.Text =
                                montant.ToString("0.00");
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "La prime sélectionnée est introuvable.",
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
                    "Erreur lors du chargement de la prime :\n"
                    + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void Ajouter_prime_Load(object sender, EventArgs e)
        {

        }

        private void ChargerSalaireConcerne()
        {
            try
            {
                string query = "SELECT p.nom,p.post_nom,p.prenom,p.salaire_base,s.mois FROM personnels p INNER JOIN salaires s ON p.id_personnel = s.id_personnel WHERE p.id_personnel = @id ORDER BY s.id_salaire DESC LIMIT 1";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add("@id",idPersonnel);

                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params, true))
                {
                    if (reader.Read())
                    {
                        // ==============================
                        // NOM DU PERSONNEL
                        // ==============================

                        string nom = reader["nom"].ToString();
                        string postNom = reader["post_nom"].ToString();
                        string prenom = reader["prenom"].ToString();

                        lblPersonnel.Text = nom + " " + postNom + " " + prenom;

                        decimal salaire = Convert.ToDecimal(reader["salaire_base"]);

                        lblSalaire.Text = salaire.ToString("N2") + " $";
                        string moisTexte = reader["mois"].ToString(); lblMois.Text = moisTexte;
                    }
                    else
                    {
                        MessageBox.Show("Le salaire concerné est introuvable.","Information",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement du salaire concerné :\n" +ex.Message,"Erreur",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public static int  RecupererIDSalaire(int id)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string query = "SELECT id_salaire FROM salaires WHERE id_personnel = @id  ORDER BY id_salaire DESC LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(query,con))
                {
                    cmd.Parameters.AddWithValue("@id",id);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
           
// =====================================================
            // VERIFICATION DU MOTIF
            // =====================================================

            if (string.IsNullOrWhiteSpace(tb_motif.Text))
            {
                MessageBox.Show(
                    "Veuillez saisir le motif de la prime.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tb_motif.Focus();

                return;
            }


            // =====================================================
            // VERIFICATION DU MONTANT
            // =====================================================

            decimal montant;

            if (!decimal.TryParse(
                tb_montant.Text,
                out montant))
            {
                MessageBox.Show(
                    "Veuillez saisir un montant valide.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tb_montant.Focus();

                return;
            }


            if (montant <= 0)
            {
                MessageBox.Show(
                    "Le montant de la prime doit être supérieur à zéro.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tb_montant.Focus();

                return;
            }


            // =====================================================
            // MODIFICATION
            // =====================================================

            if (modeModification)
            {
                ModifierPrime(montant);
                MesForms.Personnel.Detail_salaire.btRefresh.PerformClick();
            }

            // =====================================================
            // AJOUT
            // =====================================================

            else
            {
                AjouterPrime(montant);
            }
        }

        // =========================================================
        // AJOUTER UNE PRIME
        // =========================================================

        private void AjouterPrime(decimal montant)
        {
            using (MySqlConnection con =
                MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    int idSalaire =
                        RecupererIDSalaire(
                            Convert.ToInt32(idPersonnel));


                    if (idSalaire == 0)
                    {
                        MessageBox.Show(
                            "Aucun salaire n'a été trouvé pour ce personnel.",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }


                    string query = @"
                        INSERT INTO prime
                        (
                            id_salaire,
                            date_prime,
                            motif,
                            montant
                        )
                        VALUES
                        (
                            @salaire,
                            @date,
                            @motif,
                            @montant
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
                            "@motif",
                            tb_motif.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@montant",
                            montant);


                        cmd.ExecuteNonQuery();
                    }


                    MessageBox.Show(
                        "Prime ajoutée avec succès !",
                        "Succès",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );


                    MesForms.Personnel.Detail_Test
                        .btRefresh
                        .PerformClick();


                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur lors de l'ajout de la prime :\n"
                        + ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        // =========================================================
        // MODIFIER UNE PRIME
        // =========================================================

        private void ModifierPrime(decimal montant)
        {
            using (MySqlConnection con =
                MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string query = @"
                        UPDATE prime
                        SET
                            date_prime = @date,
                            motif = @motif,
                            montant = @montant
                        WHERE id_prime = @id_prime";


                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@date",
                            dtp_date_paiement.Value.Date);

                        cmd.Parameters.AddWithValue(
                            "@motif",
                            tb_motif.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@montant",
                            montant);

                        cmd.Parameters.AddWithValue(
                            "@id_prime",
                            idPrime);


                        int lignesModifiees =
                            cmd.ExecuteNonQuery();


                        if (lignesModifiees == 0)
                        {
                            MessageBox.Show(
                                "Aucune modification n'a été effectuée.",
                                "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                            return;
                        }
                    }


                    MessageBox.Show(
                        "Prime modifiée avec succès !",
                        "Succès",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );


                    // Actualiser le formulaire détail
                    MesForms.Personnel.Detail_Test
                        .btRefresh
                        .PerformClick();


                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur lors de la modification de la prime :\n"
                        + ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }
    }
}
   

