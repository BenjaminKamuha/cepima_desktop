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

        private void bt_save_patient_Click(object sender, EventArgs e)
        {
            if (VerifierChamps() == true)
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    try
                    {
                        using (MySqlCommand cmd = new MySqlCommand("INSERT INTO patients(numero_fiche,nom,post_nom,prenom,sexe,date_naissance,telephone,adresse,date_creation,id_centre,nom_garde,telephone_garde)VALUES(@numero,@nom,@post,@prenom,@sexe,@naissance,@phone,@adresse,CURDATE(),@centre,@garde,@contact)", con))
                        {
                            cmd.Parameters.AddWithValue("@numero", tb_num_fiche.Text);
                            cmd.Parameters.AddWithValue("@nom", tb_name_patient.Text);
                            cmd.Parameters.AddWithValue("@post", tb_post_nom.Text);
                            cmd.Parameters.AddWithValue("@prenom", tb_prenom.Text);
                            cmd.Parameters.AddWithValue("@sexe", cbx_genre.Text);
                            cmd.Parameters.AddWithValue("@naissance", dt_naissance.Value.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@phone", tb_phone_number.Text);
                            cmd.Parameters.AddWithValue("@adresse", tb_adresse.Text);
                            cmd.Parameters.AddWithValue("@centre", SessionUtilisateur.idCentre);
                            cmd.Parameters.AddWithValue("@garde", tb_garde_name.Text);
                            cmd.Parameters.AddWithValue("@contact", tb_contact_garde.Text);
                            cmd.ExecuteNonQuery();
                         
                            // récuperons l'id inseré imediatement
                            idPatient = Convert.ToInt32(cmd.LastInsertedId);
                            this.Close();
                            // appel du formulaire de prise de signes vitaux
                            MesForms.Form_signes_vitaux signes = new Form_signes_vitaux(idPatient);
                            signes.ShowDialog();
                            Form1.GlobalPanel_main.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur : " + ex.Message);
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void Form_add_patient_Load(object sender, EventArgs e)
        {
            tb_num_fiche.Text = GenererNumeroFiche();
        }

        // vérifier les champs vides
        private bool VerifierChamps()
        {
            // tb_name_patient
            if (tb_name_patient.Text.Trim() == "")
            {
                erreur.SetError(tb_name_patient, "Ce champ est obligatoire");
                tb_name_patient.Focus();
                return false;
            }
            else
            {
                erreur.SetError(tb_name_patient, "");
            }

            // tb_post_nom
            if (tb_post_nom.Text.Trim() == "")
            {
                erreur.SetError(tb_post_nom, "Ce champ est obligatoire");
                tb_post_nom.Focus();
                return false;
            }
            else
            {
                erreur.SetError(tb_post_nom, "");
            }

            // tb_prenom
            if (tb_prenom.Text.Trim() == "")
            {
                erreur.SetError(tb_prenom, "Ce champ est obligatoire");
                tb_prenom.Focus();
                return false;
            }
            else
            {
                erreur.SetError(tb_prenom, "");
            }

            // combo genre
            if (cbx_genre.SelectedIndex == -1)
            {
                erreur.SetError(cbx_genre, "Sélection obligatoire");
                cbx_genre.Focus();
                return false;
            }
            else
            {
                erreur.SetError(cbx_genre, "");
            }

            // téléphone
            if (tb_phone_number.Text.Trim() == "")
            {
                erreur.SetError(tb_phone_number, "Ce champ est obligatoire");
                tb_phone_number.Focus();
                return false;
            }
            else
            {
                erreur.SetError(tb_phone_number, "");
            }

            // adresse
            if (tb_adresse.Text.Trim() == "")
            {
                erreur.SetError(tb_adresse, "Ce champ est obligatoire");
                tb_adresse.Focus();
                return false;
            }
            else
            {
                erreur.SetError(tb_adresse, "");
            }

            return true;
        }

        private void bt_save_patient_Load(object sender, EventArgs e)
        {

        }
    }
}
