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
    public partial class Payement_Facture : Form
    {
        private string idFacture;
        private string idPatient;
        public Payement_Facture(string idFacture, string idPatient)
        {
            InitializeComponent();
            this.idFacture = idFacture;
            this.idPatient = idPatient;
        }

        private void Payement_Facture_Load(object sender, EventArgs e)
        {
            ChargerInformationsPatient();
            ChargerMontantRestant();
        }
        private void ChargerInformationsPatient()
        {
            try
            {
                string query = @"
            SELECT
                nom,
                post_nom,
                prenom,
                sexe,
                date_naissance
               
            FROM patients
            WHERE id_patient = @id_patient";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_patient",
                    idPatient
                );

                using (MySqlDataReader reader =
                       MesClasses.ManagerClasse.CRUD(
                           query,
                           MesClasses.ManagerClasse.request_params,
                           true))
                {
                    if (reader.Read())
                    {
                        // =====================================================
                        // INFORMATIONS PATIENT
                        // =====================================================

                        string nom =
                            reader["nom"].ToString();

                        string postNom =
                            reader["post_nom"].ToString();

                        string prenom =
                            reader["prenom"].ToString();

                        string sexe =
                            reader["sexe"].ToString();


                        // =====================================================
                        // CALCUL DE L'AGE
                        // =====================================================

                        int age = 0;

                        if (reader["date_naissance"] != DBNull.Value)
                        {
                            DateTime dateNaissance =
                                Convert.ToDateTime(
                                    reader["date_naissance"]
                                );

                            age =
                                DateTime.Today.Year -
                                dateNaissance.Year;

                            if (dateNaissance.Date >
                                DateTime.Today.AddYears(-age))
                            {
                                age--;
                            }
                        }


                        // =====================================================
                        // AFFICHAGE
                        // =====================================================


                        lb_nom.Text = nom + " " + postNom + " " + prenom;
                        lb_age.Text = age.ToString() + " ans" + " - " + age;
                    }
                    else
                    {
                        MessageBox.Show(
                            "Patient introuvable.",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }

                    reader.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du patient :\n\n"
                    + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ChargerMontantRestant()
        {
            try
            {
                string query = @"
            SELECT reste
            FROM facture
            WHERE id_facture = @id_facture";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_facture",
                    idFacture
                );

                using (MySqlDataReader reader =
                       MesClasses.ManagerClasse.CRUD(
                           query,
                           MesClasses.ManagerClasse.request_params,
                           true))
                {
                    if (reader.Read())
                    {
                        decimal reste = 0;

                        if (reader["reste"] != DBNull.Value)
                        {
                            reste = Convert.ToDecimal(reader["reste"]);
                        }

                        tb_montant.Text = reste.ToString("N2");
                        tb_montant.Focus();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Facture introuvable.",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }

                    reader.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du montant restant :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void EnregistrerPaiement()
        {
            try
            {
                // =========================================================
                // 1. Vérifier le montant saisi
                // =========================================================

                decimal montant;

                if (!decimal.TryParse(tb_montant.Text.Trim(), out montant))
                {
                    MessageBox.Show(
                        "Veuillez saisir un montant valide.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    tb_montant.Focus();
                    return;
                }

                if (montant <= 0)
                {
                    MessageBox.Show(
                        "Le montant doit être supérieur à zéro.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    tb_montant.Focus();
           
                    return;
                }


                // =========================================================
                // 2. Récupérer le reste actuel depuis FACTURE
                // =========================================================

                string query = @"
            SELECT
                montant_total,
                montant_paye,
                reste
            FROM facture
            WHERE id_facture = @id_facture";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_facture",
                    idFacture
                );

                decimal montantTotal = 0;
                decimal montantPayeActuel = 0;
                decimal resteActuel = 0;

                using (MySqlDataReader reader =
                       MesClasses.ManagerClasse.CRUD(
                           query,
                           MesClasses.ManagerClasse.request_params,
                           true))
                {
                    if (!reader.Read())
                    {
                        MessageBox.Show(
                            "Facture introuvable.",
                            "Erreur",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                        return;
                    }

                    if (reader["montant_total"] != DBNull.Value)
                        montantTotal = Convert.ToDecimal(
                            reader["montant_total"]
                        );

                    if (reader["montant_paye"] != DBNull.Value)
                        montantPayeActuel = Convert.ToDecimal(
                            reader["montant_paye"]
                        );

                    if (reader["reste"] != DBNull.Value)
                        resteActuel = Convert.ToDecimal(
                            reader["reste"]
                        );

                    reader.Close();
                }


                // =========================================================
                // 3. Vérifier que le paiement ne dépasse pas le reste
                // =========================================================

                if (montant > resteActuel)
                {
                    MessageBox.Show(
                        "Le montant saisi (" +
                        montant.ToString("N2") +
                        " FC) dépasse le montant restant (" +
                        resteActuel.ToString("N2") +
                        " FC).",
                        "Montant invalide",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    tb_montant.Focus();

                    return;
                }


                // =========================================================
                // 4. Calculer le nouveau montant payé
                // =========================================================

                decimal nouveauMontantPaye =
                    montantPayeActuel + montant;


                // =========================================================
                // 5. Calculer le nouveau reste
                //
                // IMPORTANT :
                // Le reste vient uniquement de la table FACTURE.
                // =========================================================

                decimal nouveauReste =
                    resteActuel - montant;


                // Éviter une éventuelle petite valeur négative
                if (nouveauReste < 0)
                    nouveauReste = 0;


                // =========================================================
                // 6. Déterminer le type du paiement
                // =========================================================

                string typePaiement;

                if (nouveauReste == 0)
                {
                    typePaiement = "Complet";
                }
                else
                {
                    typePaiement = "Partiel";
                }


                // =========================================================
                // 7. Déterminer le nouveau statut de la facture
                // =========================================================

                string statut;

                if (nouveauReste == 0)
                {
                    statut = "Payé";
                }
                else
                {
                    statut = "Partiellement payé";
                }


                // =========================================================
                // 8. Enregistrer le paiement
                //
                // Le champ paiement.reste reste dans la table,
                // mais il n'est PAS utilisé pour les calculs.
                // =========================================================

                string insertPaiement = @"
            INSERT INTO paiement
            (
                id_facture,
                date_paiement,
                montant,
                type_paiement
            )
            VALUES
            (
                @id_facture,
                @date_paiement,
                @montant,
                @type_paiement
            )";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_facture",
                    idFacture
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@date_paiement",
                    DateTime.Today.ToString("yyyy-MM-dd")
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@montant",
                    montant.ToString()
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@type_paiement",
                    typePaiement
                );

                MesClasses.ManagerClasse.CRUD(
                    insertPaiement,
                    MesClasses.ManagerClasse.request_params,
                    false
                );


                // =========================================================
                // 9. Mettre à jour la facture
                // =========================================================

                string updateFacture = @"
            UPDATE facture
            SET
                montant_paye = @montant_paye,
                reste = @reste,
                statut = @statut
            WHERE id_facture = @id_facture";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@montant_paye",
                    nouveauMontantPaye.ToString()
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@reste",
                    nouveauReste.ToString()
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@statut",
                    statut
                );

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_facture",
                    idFacture
                );

                MesClasses.ManagerClasse.CRUD(
                    updateFacture,
                    MesClasses.ManagerClasse.request_params,
                    false
                );



                // =========================================================
                // 10. Ajouter le paiement dans le livre de caisse
                // =========================================================

                MesClasses.ReceptionManager.AjouterLivreCaisse(
                    montant,
                    0,
                    "GENERALE",
                    "Paiement facture N° " + idFacture
                );

                var result = MessageBox.Show("Imprimer le facture");
                MesForms.FormRecu recu = new FormRecu(Convert.ToInt32(idFacture));
                recu.ShowDialog();
                // =========================================================
                // 10. Message de confirmation
                // =========================================================

                MessageBox.Show(
                    "Paiement enregistré avec succès.",
                    "Paiement",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );


                // Retourner OK au formulaire qui a ouvert Payement
                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'enregistrement du paiement :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void bt_valider_Click(object sender, EventArgs e)
        {
            EnregistrerPaiement();
        }
    }
}
