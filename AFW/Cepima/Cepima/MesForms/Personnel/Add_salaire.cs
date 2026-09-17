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
    public partial class Add_salaire : Form
    {
        string PersonnelID;
        private int idSalaire;
        private bool modeModification = false;

        public Add_salaire(string id_personnel)
        {
            InitializeComponent();
            PersonnelID = id_personnel;
            modeModification = false;
            this.Text = "Ajouter une salaire du personnel";
            label1.Text = this.Text;
            bt_start.Text = "Ajouter salaire";
        }

        public Add_salaire(string id_personnel, int idSalaire)
        {
            InitializeComponent();
            PersonnelID = id_personnel;
            this.idSalaire = idSalaire;

            modeModification = true;

            this.Text = "Modification du salaire du personnel";
            label1.Text = this.Text;
            bt_start.Text = "Modifier l'avance";
        }

        private void ChargerSalaire()
        {
            try
            {
                string query = @"
            SELECT 
                mois,
                salaire_base,
                date_paiement,
                statut
            FROM salaires
            WHERE id_salaire = @id_salaire";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_salaire",
                    idSalaire.ToString()
                );

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    if (reader.Read())
                    {
                        // ==========================
                        // MOIS
                        // ==========================

                        cbx_mois.SelectedItem =
                            reader["mois"].ToString();


                        // ==========================
                        // SALAIRE
                        // ==========================

                        if (reader["salaire_base"] != DBNull.Value)
                        {
                            decimal salaire =
                                Convert.ToDecimal(
                                    reader["salaire_base"]);

                            tb_salaire.Text =
                                salaire.ToString("0.00");
                        }


                        // ==========================
                        // DATE DE PAIEMENT
                        // ==========================

                        if (reader["date_paiement"] != DBNull.Value)
                        {
                            dtp_date_paiement.Value =
                                Convert.ToDateTime(
                                    reader["date_paiement"]);
                        }


                        // ==========================
                        // STATUT
                        // ==========================

                        cbx_statut.SelectedItem =
                            reader["statut"].ToString();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Le salaire sélectionné est introuvable.",
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
                    "Erreur lors du chargement du salaire :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void Add_salaire_Load(object sender, EventArgs e)
        {
            LoadDataAdministratives();

            DataInCBX();

            if (modeModification)
            {
                ChargerSalaire();
            }
            else
            {
                ChargerSalaireBase();
            }
        }

        //méthode pour charger les informations administratives du patient
        private void LoadDataAdministratives()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string query = "SELECT nom,post_nom,sexe,date_naissance, fonction,salaire_base FROM personnels WHERE id_personnel = @id";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@id", PersonnelID.ToString());
                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                    {
                        if (reader.Read())
                        {
                            lb_nom.Text = reader["nom"].ToString();
                            lb_postnom.Text = reader["post_nom"].ToString();
                            lb_fonction.Text = reader["fonction"].ToString();
                            DateTime date = Convert.ToDateTime(reader["date_naissance"]);
                            int annee = MesClasses.ReceptionManager.CalculerAge(date);
                            lb_age.Text = annee.ToString() + " ans" + " - " + reader["sexe"];
                            decimal salaire_base = Convert.ToDecimal(reader["salaire_base"]);
                            tb_salaire.Text = salaire_base.ToString("0.00");
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void ModifierSalaire()
        {
            try
            {
                if (cbx_mois.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Veuillez sélectionner le mois.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                decimal salaire;

                if (!decimal.TryParse(
                    tb_salaire.Text,
                    out salaire))
                {
                    MessageBox.Show(
                        "Veuillez saisir un salaire valide.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                if (salaire <= 0)
                {
                    MessageBox.Show(
                        "Le salaire doit être supérieur à zéro.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                string mois =
                    cbx_mois.SelectedItem.ToString();

                string statut =
                    cbx_statut.Text;

                DateTime datePaiement =
                    dtp_date_paiement.Value.Date;


                string query = @"
            UPDATE salaires
            SET
                mois = @mois,
                salaire_base = @salaire_base,
                date_paiement = @date_paiement,
                statut = @statut
            WHERE id_salaire = @id_salaire";


                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@mois",
                    mois
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@salaire_base",
                    salaire.ToString()
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@date_paiement",
                    datePaiement.ToString("yyyy-MM-dd")
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@statut",
                    statut
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_salaire",
                    idSalaire.ToString()
                );


                MesClasses.ManagerClasse.CRUD(
                    query,
                    MesClasses.ManagerClasse.request_params,
                    false
                );


                MessageBox.Show(
                    "Le salaire a été modifié avec succès.",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );


                MesForms.Personnel.Detail_Test.btRefresh.PerformClick();

                this.DialogResult = DialogResult.OK;
                MesForms.Personnel.Detail_salaire.btRefresh.PerformClick();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la modification du salaire :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void DataInCBX()
        {
            cbx_mois.Items.Clear();

            cbx_mois.Items.Add("Janvier");
            cbx_mois.Items.Add("Février");
            cbx_mois.Items.Add("Mars");
            cbx_mois.Items.Add("Avril");
            cbx_mois.Items.Add("Mai");
            cbx_mois.Items.Add("Juin");
            cbx_mois.Items.Add("Juillet");
            cbx_mois.Items.Add("Août");
            cbx_mois.Items.Add("Septembre");
            cbx_mois.Items.Add("Octobre");
            cbx_mois.Items.Add("Novembre");
            cbx_mois.Items.Add("Décembre");

            cbx_mois.SelectedIndex = DateTime.Now.Month - 1;

            cbx_statut.Items.Clear();

            cbx_statut.Items.Add("Non payé");
            cbx_statut.Items.Add("Payé");
            cbx_statut.Items.Add("En attente");

            cbx_statut.SelectedIndex = 0;
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            if (modeModification)
            {
                ModifierSalaire();
            }
            else
            {
                AjouterSalaire();
            }
        }

        private void ChargerSalaireBase()
        {
            try
            {
                string query = @"SELECT salaire_base
                         FROM personnels
                         WHERE id_personnel = @id_personnel";

                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id_personnel", PersonnelID);

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    if (reader.Read())
                    {
                        if (reader["salaire_base"] != DBNull.Value)
                        {
                            tb_salaire.Text =
                                Convert.ToDecimal(reader["salaire_base"])
                                .ToString("0.00");
                        }
                        else
                        {
                            tb_salaire.Text = "0.00";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du salaire :\n" + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void AjouterSalaire()
        {
            try
            {
                if (cbx_mois.SelectedIndex == -1)
                {
                    MessageBox.Show("Veuillez sélectionner le mois.");
                    return;
                }

                decimal salaire;

                if (!decimal.TryParse(tb_salaire.Text, out salaire))
                {
                    MessageBox.Show("Veuillez saisir un salaire valide.");
                    return;
                }

                if (salaire <= 0)
                {
                    MessageBox.Show("Le salaire doit être supérieur à zéro.");
                    return;
                }

                DateTime datePaiement = dtp_date_paiement.Value;

                string statut = cbx_statut.Text;

                // Vérifier si un salaire existe déjà pour ce personnel et ce mois
                string verification = @"SELECT COUNT(*)
                                 FROM salaires
                                 WHERE id_personnel = @id_personnel
                                 AND mois = @mois";

                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id_personnel", PersonnelID);
                MesClasses.ManagerClasse.request_params.Add("@mois", cbx_mois.SelectedItem.ToString());

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        verification,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    if (reader.Read())
                    {
                        int nombre = Convert.ToInt32(reader[0]);

                        if (nombre > 0)
                        {
                            MessageBox.Show(
                                "Un salaire existe déjà pour ce personnel pour ce mois.",
                                "Attention",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                            return;
                        }
                    }
                }

                // Enregistrer
                string query = @"INSERT INTO salaires
                        (id_personnel, mois, salaire_base, date_paiement, statut)
                        VALUES
                        (@id_personnel, @mois, @salaire_base,
                         @date_paiement, @statut)";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_personnel",
                    PersonnelID
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@mois",
                    cbx_mois.SelectedItem.ToString()
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@salaire_base",
                    salaire.ToString()
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@date_paiement",
                    datePaiement.Date.ToString("yyyy-MM-dd")
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@statut",
                    statut
                );

                MesClasses.ManagerClasse.CRUD(
                    query,
                    MesClasses.ManagerClasse.request_params,
                    false
                );

                MessageBox.Show(
                    "Le salaire a été enregistré avec succès.",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.DialogResult = DialogResult.OK;
                MesForms.Personnel.Detail_Test.btRefresh.PerformClick();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'enregistrement du salaire :\n" + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
