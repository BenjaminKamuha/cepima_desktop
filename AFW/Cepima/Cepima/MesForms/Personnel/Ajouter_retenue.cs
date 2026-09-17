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
    public partial class Ajouter_retenue : Form
    {
        private string idPersonnel;

        private int idRetenue;
        private int idSalaire;

        private bool modeModification = false;

        public Ajouter_retenue(string id_personnel)
        {
            InitializeComponent();

            this.idPersonnel = id_personnel;

            modeModification = false;

            this.Text = "Ajouter une retenue ";
            label1.Text = this.Text;

            bt_start.Text = "Ajouter la retenue";
        }

        // =========================================================
        // MODE MODIFICATION
        // =========================================================

        public Ajouter_retenue(string id_personnel, int idRetenue)
        {
            InitializeComponent();

            this.idPersonnel = id_personnel;
            this.idRetenue = idRetenue;

            modeModification = true;

            this.Text = "Modification de la retenue";
            label1.Text = this.Text;

            bt_start.Text = "Modifier la retenue";
        }

        private void Ajouter_retenue_Load(object sender, EventArgs e)
        {
            ChargerSalaireConcerne();

            if (modeModification)
            {
                ChargerRetenue();
            }
        }

        // =========================================================
        // CHARGER LA RETENUE EN MODE MODIFICATION
        // =========================================================

        private void ChargerRetenue()
        {
            try
            {
                string query = @"
                    SELECT
                        date_retenue,
                        motif,
                        montant,
                        id_salaire
                    FROM retenue
                    WHERE id_retenue = @id_retenue";


                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_retenue",
                    idRetenue.ToString()
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

                        if (reader["date_retenue"] != DBNull.Value)
                        {
                            dtp_date_paiement.Value =
                                Convert.ToDateTime(
                                    reader["date_retenue"]);
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


                        // ==============================
                        // SALAIRE CONCERNE
                        // ==============================

                        if (reader["id_salaire"] != DBNull.Value)
                        {
                            idSalaire =
                                Convert.ToInt32(
                                    reader["id_salaire"]);
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "La retenue sélectionnée est introuvable.",
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
                    "Erreur lors du chargement de la retenue :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void ChargerSalaireConcerne()
        {
            try
            {
                string query = "SELECT p.nom,p.post_nom,p.prenom,p.salaire_base,s.mois FROM personnels p INNER JOIN salaires s ON p.id_personnel = s.id_personnel WHERE p.id_personnel = @id ORDER BY s.id_salaire DESC LIMIT 1";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add("@id", idPersonnel);

                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
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
                        MessageBox.Show("Le salaire concerné est introuvable.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement du salaire concerné :\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            if (modeModification)
            {
                ModifierRetenue();
            }
            else
            {
                AjouterRetenue();
            }
        }

        // =========================================================
        // AJOUTER UNE RETENUE
        // =========================================================

        private void AjouterRetenue()
        {
            try
            {
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

                    return;
                }


                if (montant <= 0)
                {
                    MessageBox.Show(
                        "Le montant doit être supérieur à zéro.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }


                if (string.IsNullOrWhiteSpace(
                    tb_motif.Text))
                {
                    MessageBox.Show(
                        "Veuillez saisir le motif de la retenue.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }


                string query = @"
                    INSERT INTO retenue
                    (
                        id_salaire,
                        date_retenue,
                        motif,
                        montant
                    )
                    VALUES
                    (
                        @id_salaire,
                        @date,
                        @motif,
                        @montant
                    )";


                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_salaire",
                    idSalaire.ToString()
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@date",
                    dtp_date_paiement.Value.Date
                        .ToString("yyyy-MM-dd")
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@motif",
                    tb_motif.Text
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@montant",
                    montant.ToString()
                );


                MesClasses.ManagerClasse.CRUD(
                    query,
                    MesClasses.ManagerClasse.request_params,
                    false
                );


                MessageBox.Show(
                    "Retenue ajoutée avec succès.",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );


                MesForms.Personnel.Detail_Test
                    .btRefresh.PerformClick();


                this.DialogResult =
                    DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'ajout de la retenue :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // =========================================================
        // MODIFIER UNE RETENUE
        // =========================================================

        private void ModifierRetenue()
        {
            try
            {
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

                    return;
                }


                if (montant <= 0)
                {
                    MessageBox.Show(
                        "Le montant doit être supérieur à zéro.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }


                if (string.IsNullOrWhiteSpace(
                    tb_motif.Text))
                {
                    MessageBox.Show(
                        "Veuillez saisir le motif de la retenue.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }


                string query = @"
                    UPDATE retenue
                    SET
                        date_retenue = @date,
                        motif = @motif,
                        montant = @montant
                    WHERE id_retenue = @id_retenue";


                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@date",
                    dtp_date_paiement.Value.Date
                        .ToString("yyyy-MM-dd")
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@motif",
                    tb_motif.Text
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@montant",
                    montant.ToString()
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_retenue",
                    idRetenue.ToString()
                );


                MesClasses.ManagerClasse.CRUD(
                    query,
                    MesClasses.ManagerClasse.request_params,
                    false
                );


                MessageBox.Show(
                    "Retenue modifiée avec succès.",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );


                MesForms.Personnel.Detail_Test
                    .btRefresh.PerformClick();


                this.DialogResult =
                    DialogResult.OK;
                MesForms.Personnel.Detail_salaire.btRefresh.PerformClick();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la modification de la retenue :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
