using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Cepima.MesUserCases
{
    public partial class User_patient : UserControl
    {
         public static ErrorProvider erreur = new ErrorProvider();
        public User_patient()
        {
            InitializeComponent();
            MesClasses.ReceptionManager.MoveLabel(label1, panel1, 2);
        }

        // ============================== Méthode pour génerer le numéro de la fiche ===========================
        private string  GenererNumeroFiche()
        {
            int dernierNumero = 0;
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                string queryPatient = "SELECT MAX(id_patient) FROM patients";
                MySqlCommand cmd = new MySqlCommand(queryPatient,con);
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                    dernierNumero = Convert.ToInt32(result);
            }
            
            int nouveauNumero = dernierNumero + 1;
            return "CEP-" + nouveauNumero.ToString("D3");
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            tb_name_patient.Clear();
            tb_post_nom.Clear();
            tb_prenom.Clear();
            cbx_genre.SelectedIndex = -1;
            tb_phone_number.Clear();
            tb_adresse.Clear();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (VerifierChamps() == true)
            {
                string nomPatient = tb_name_patient.Text;
                string postnomPatient = tb_post_nom.Text;
                string prename = tb_prenom.Text;
                string Sexe = cbx_genre.SelectedItem.ToString();
                DateTime dateNaissance = dt_naissance.Value;
                string numeroPhone = tb_phone_number.Text;
                string adressePatient = tb_adresse.Text;
                //=====================Appel de la méthode dans sa class respective =====================
                MesClasses.ReceptionManager.SavePatient(tb_num_fiche.Text,nomPatient,postnomPatient,prename,Sexe,dateNaissance,numeroPhone,adressePatient,MesForms.SessionUtilisateur.idCentre.ToString()
                    );
            }
            else
            {
                return;
            }
           
        }
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

        private void tb_adresse_TextChanged(object sender, EventArgs e)
        {
            erreur.SetError(tb_adresse,"");
        }

        private void bt_save_continuous_Click(object sender, EventArgs e)
        {

            if (VerifierChamps() == true)
            {
                string numeroFiche = GenererNumeroFiche();
                string nomPatient = tb_name_patient.Text;
                string postnomPatient = tb_post_nom.Text;
                string prename = tb_prenom.Text;
                string Sexe = cbx_genre.SelectedItem.ToString();
                DateTime dateNaissance = dt_naissance.Value;
                string numeroPhone = tb_phone_number.Text;
                string adressePatient = tb_adresse.Text;
                //=====================Appel de la méthode dans sa class respective =====================
                MesClasses.ReceptionManager.SavePatient(numeroFiche, nomPatient, postnomPatient, prename, Sexe, dateNaissance, numeroPhone, adressePatient, MesForms.SessionUtilisateur.idCentre.ToString()
                    );
                MessageBox.Show("Patient ajouté avec succès, prenez directement les signes vitaux du patient");
                //Ajouter le fomulaire de consultation
                MesUserCases.User_signes_vitaux consultation = new User_signes_vitaux();
                consultation.Dock = DockStyle.Fill;
                Form1.GlobalPanel_main.Controls.Clear();
                Form1.GlobalPanel_main.Controls.Add(consultation);
            }
            else
            {
                return;
            }
        }

        private void User_patient_Load(object sender, EventArgs e)
        {
            tb_num_fiche.Text = GenererNumeroFiche();
        }
    }
}