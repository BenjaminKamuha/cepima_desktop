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

namespace Cepima.MesForms
{
    public partial class Form_add_patient : Form
    {
        public static ErrorProvider erreur = new ErrorProvider();
        public Form_add_patient()
        {
            InitializeComponent();
            cbx_genre.Items.Clear();
            cbx_genre.Items.Add("Masculin");
            cbx_genre.Items.Add("Feminin");

            cbx_etat.Items.Clear();
            cbx_etat.Items.Add("---Selectionner l'état civil---");
            cbx_etat.Items.Add("Marié");
            cbx_etat.Items.Add("Celibataire");
            cbx_etat.Items.Add("Divorcé");
            cbx_etat.Items.Add("Veuf");
            cbx_etat.Items.Add("Veuve");

            cbx_etat.SelectedIndex = 0;
        }

        // ============================== Méthode pour génerer le numéro de la fiche ===========================
        private string GenererNumeroFiche()
        {
            int dernierNumero = 0;
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string queryPatient = "SELECT MAX(id_patient) FROM patients";
                MySqlCommand cmd = new MySqlCommand(queryPatient, con);
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                    dernierNumero = Convert.ToInt32(result);
            }

            int nouveauNumero = dernierNumero + 1;
            return "CEP-" + nouveauNumero.ToString("D3");
        }

        // déclaration de la variable qui va contenir l'id du patient enregistré
        int idPatient = 0;

        private void Form_add_patient_Load(object sender, EventArgs e)
        {
            tb_num_fiche.Text = GenererNumeroFiche();
        }

        // vérifier les champs vides
        //private bool VerifierChamps()
        //{
        //    // tb_name_patient
        //    if (tb_name_patient.Text.Trim() == "")
        //    {
        //        erreur.SetError(tb_name_patient, "Ce champ est obligatoire");
        //        tb_name_patient.Focus();
        //        return false;
        //    }
        //    else
        //    {
        //        erreur.SetError(tb_name_patient, "");
        //    }

        //    // tb_post_nom
        //    if (tb_post_nom.Text.Trim() == "")
        //    {
        //        erreur.SetError(tb_post_nom, "Ce champ est obligatoire");
        //        tb_post_nom.Focus();
        //        return false;
        //    }
        //    else
        //    {
        //        erreur.SetError(tb_post_nom, "");
        //    }

        //    // tb_prenom
        //    if (tb_prenom.Text.Trim() == "")
        //    {
        //        erreur.SetError(tb_prenom, "Ce champ est obligatoire");
        //        tb_prenom.Focus();
        //        return false;
        //    }
        //    else
        //    {
        //        erreur.SetError(tb_prenom, "");
        //    }

        //    // combo genre
        //    if (cbx_genre.SelectedIndex == -1)
        //    {
        //        erreur.SetError(cbx_genre, "Sélection obligatoire");
        //        cbx_genre.Focus();
        //        return false;
        //    }
        //    else
        //    {
        //        erreur.SetError(cbx_genre, "");
        //    }

        //    // téléphone
        //    if (tb_phone_number.Text.Trim() == "")
        //    {
        //        erreur.SetError(tb_phone_number, "Ce champ est obligatoire");
        //        tb_phone_number.Focus();
        //        return false;
        //    }
        //    else
        //    {
        //        erreur.SetError(tb_phone_number, "");
        //    }

        //    // adresse
        //    if (tb_adresse.Text.Trim() == "")
        //    {
        //        erreur.SetError(tb_adresse, "Ce champ est obligatoire");
        //        tb_adresse.Focus();
        //        return false;
        //    }
        //    else
        //    {
        //        erreur.SetError(tb_adresse, "");
        //    }

        //    return true;
        //}

        private void bt_save_patient_Load(object sender, EventArgs e)
        {

        }

        private void bt_save_patient_Click_1(object sender, EventArgs e)
        {

            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string query = @"
                INSERT INTO patients
                (
                    numero_fiche,
                    nom,
                    post_nom,
                    prenom,
                    sexe,
                    date_naissance,
                    telephone,
                    adresse,
                    profession,etat_civil,
                    nom_pere,
                    nom_mere,
                    profession_pere,
                    profession_mere,
                    confession_religieuse,
                    niveau_etude,
                    personne_accompagnante,
                    telephone_accompagnant,
                    adresse_accompagnant,
                    autres_membres_famille,
                    engagement_tuteur,
                    date_creation,
                    id_centre,
                    nom_garde,
                    telephone_garde
                )
                VALUES
                (
                    @numero,
                    @nom,
                    @post,
                    @prenom,
                    @sexe,
                    @naissance,
                    @phone,
                    @adresse,
                    @profession,@etat,
                    @nom_pere,
                    @nom_mere,
                    @profession_pere,
                    @profession_mere,
                    @confession,
                    @niveau,
                    @accompagnant,
                    @telephone_accompagnant,
                    @adresse_accompagnant,
                    @autres_membres,
                    @engagement,
                    CURDATE(),
                    @centre,
                    @garde,
                    @contact
                );";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@numero",
                            tb_num_fiche.Text.Trim());

                        cmd.Parameters.AddWithValue("@nom",
                            tb_name_patient.Text.Trim());

                        cmd.Parameters.AddWithValue("@post",
                            tb_post_nom.Text.Trim());

                        cmd.Parameters.AddWithValue("@prenom",
                            tb_prenom.Text.Trim());

                        cmd.Parameters.AddWithValue("@sexe",
                            cbx_genre.Text);

                        cmd.Parameters.AddWithValue("@naissance",
                            dt_naissance.Value.Date);

                        cmd.Parameters.AddWithValue("@phone",
                            tb_phone_number.Text.Trim());

                        cmd.Parameters.AddWithValue("@adresse",
                            tb_adresse.Text.Trim());

                        cmd.Parameters.AddWithValue("@profession",tb_profession.Text.Trim());

                        cmd.Parameters.AddWithValue("@etat",cbx_etat.Text.Trim());
                        cmd.Parameters.AddWithValue("@nom_pere",tb_nom_pere.Text.Trim());

                        cmd.Parameters.AddWithValue("@nom_mere",tb_nom_mere.Text.Trim());

                        cmd.Parameters.AddWithValue("@profession_pere",tb_profession_pere.Text.Trim());

                        cmd.Parameters.AddWithValue("@profession_mere",tb_profession_mere.Text.Trim());

                        cmd.Parameters.AddWithValue("@confession",tb_confession.Text);

                        cmd.Parameters.AddWithValue("@niveau",tb_niveau.Text);

                        cmd.Parameters.AddWithValue("@accompagnant",tb_personne_accompagnante.Text.Trim());

                        cmd.Parameters.AddWithValue("@telephone_accompagnant",tb_telephone_accompagnant.Text.Trim());

                        cmd.Parameters.AddWithValue("@adresse_accompagnant",tb_adresse_accompagnant.Text.Trim());

                        cmd.Parameters.AddWithValue("@autres_membres",string.IsNullOrWhiteSpace(tb_autres_membres_famille.Text)? (object)DBNull.Value: tb_autres_membres_famille.Text.Trim());

                        cmd.Parameters.AddWithValue("@engagement",string.IsNullOrWhiteSpace(tb_engagement_tuteur.Text)
                                ? (object)DBNull.Value: tb_engagement_tuteur.Text.Trim());

                        cmd.Parameters.AddWithValue("@centre",SessionUtilisateur.idCentre);

                        cmd.Parameters.AddWithValue("@garde",tb_garde_name.Text.Trim());

                        cmd.Parameters.AddWithValue("@contact",tb_contact_garde.Text.Trim());

                        cmd.ExecuteNonQuery();

                        // Récupérer immédiatement l'identifiant créé.
                        idPatient = Convert.ToInt32(cmd.LastInsertedId);
                    }

                    // Fermer la connexion avant d'ouvrir le formulaire suivant.
                    Form_signes_vitaux signes =
                        new Form_signes_vitaux(idPatient);

                    this.Hide();

                    signes.ShowDialog();

                    this.Close();

                    Form1.GlobalPanel_main.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur lors de l'enregistrement du patient : "
                        + ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
