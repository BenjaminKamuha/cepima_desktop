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
    public partial class FormDetailPatient : Form
    {
        string IDPATIENT;
        public FormDetailPatient(string idPatient)
        {
            InitializeComponent();
            IDPATIENT = idPatient;
        }

        private void FormDetailPatient_Load(object sender, EventArgs e)
        {
            ChargerDetails();
        }

        // ============================= Charger les détails du patients sur le control ===================
        public void ChargerDetails()
        {

            try
            {
                string querySelect = "SELECT id_patient,nom,post_nom,prenom,sexe,patients.numero_fiche,date_naissance,patients.adresse,patients.telephone,nom_centre FROM patients JOIN centres  ON centres.id_centre = patients.id_centre WHERE id_patient = @id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id", IDPATIENT);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(querySelect, MesClasses.ManagerClasse.request_params, true))
                {
                    CacherTextBox();
                    while (reader.Read())
                    {
                        lb_numero.Text = reader["numero_fiche"].ToString();
                        lb_nom.Text = reader["nom"].ToString();
                        tb_mod_nom.Text = reader["nom"].ToString();
                        lb_postnom.Text = reader["post_nom"].ToString();
                        tb_mod_postnom.Text = reader["post_nom"].ToString();
                        lb_prenom.Text = reader["prenom"].ToString();
                        tb_mod_prenom.Text = reader["prenom"].ToString();
                        lb_genre.Text = reader["sexe"].ToString();
                        tb_mod_genre.Text = reader["sexe"].ToString();
                        lb_date.Text = Convert.ToDateTime(reader["date_naissance"]).ToString("dd/MM/yyyy");
                        lb_adresse.Text = reader["adresse"].ToString();
                        tb_mod_adresse.Text = reader["adresse"].ToString();
                        lb_phone.Text = reader["telephone"].ToString();
                        tb_mod_phone.Text = reader["telephone"].ToString();
                        lb_centre.Text = reader["nom_centre"].ToString();
                    }
                    reader.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur du chargement de détails " + ex.Message);
            }
        }

        // cacher les textBox lors du chargement des données
        private void CacherTextBox()
        {
            tb_mod_adresse.Visible = false;
            tb_mod_nom.Visible = false;
            tb_mod_prenom.Visible = false;
            tb_mod_postnom.Visible = false;
            tb_mod_genre.Visible = false;
            tb_mod_phone.Visible = false;
            bt_cancel.Visible = false;
            bt_save_update.Visible = false;
        }

        private void bt_mod_nom_Click(object sender, EventArgs e)
        {
            tb_mod_nom.Visible = true;
            tb_mod_nom.Text = lb_nom.Text;
            tb_mod_nom.Focus();
            tb_mod_nom.SelectAll();
            bt_cancel.Visible = true;
            bt_save_update.Visible = true;
        }

        private void bt_mod_postnom_Click(object sender, EventArgs e)
        {
            tb_mod_postnom.Visible = true;
            tb_mod_postnom.Text = lb_postnom.Text;
            tb_mod_postnom.Focus();
            tb_mod_postnom.SelectAll();
            bt_save_update.Visible = true;
            bt_cancel.Visible = true;
        }

        private void bt_mod_prenom_Click(object sender, EventArgs e)
        {
            tb_mod_prenom.Visible = true;
            tb_mod_prenom.Text = lb_prenom.Text;
            tb_mod_prenom.Focus();
            tb_mod_prenom.SelectAll();
            bt_cancel.Visible = true;
            bt_save_update.Visible = true;
        }

        private void bt_mod_genre_Click(object sender, EventArgs e)
        {
            tb_mod_genre.Visible = true;
            tb_mod_genre.Text = lb_genre.Text;
            tb_mod_genre.Focus();
            tb_mod_genre.SelectAll();
            bt_cancel.Visible = true;
            bt_save_update.Visible = true;
        }

        private void bt_mod_phone_Click(object sender, EventArgs e)
        {
            tb_mod_phone.Visible = true;
            tb_mod_phone.Text = lb_phone.Text;
            tb_mod_phone.Focus();
            tb_mod_phone.SelectAll();
            bt_cancel.Visible = true;
            bt_save_update.Visible = true;
        }

        private void bt_mod_adresse_Click(object sender, EventArgs e)
        {
            tb_mod_adresse.Visible = true;
            tb_mod_adresse.Text = lb_adresse.Text;
            tb_mod_adresse.Focus();
            tb_mod_adresse.SelectAll();
            bt_cancel.Visible = true;
            bt_save_update.Visible = true;
        }

        private void bt_delete_patient_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Voulez-vous supprimer le patient " + lb_nom.Text + " " + lb_postnom.Text + "?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string query_delete = "DELETE FROM patients WHERE id_patient = @id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id", IDPATIENT);
                MesClasses.ManagerClasse.CRUD(query_delete, MesClasses.ManagerClasse.request_params);
                MessageBox.Show("Patient supprimé avec succès !");
            }
        }

        private void bt_save_update_Click(object sender, EventArgs e)
        {
            try
            {
                string query_update = "UPDATE patients SET nom = @nom,post_nom =@post_nom,prenom =@prenom,sexe=@sexe,telephone =@phone,adresse =@adresse WHERE id_patient = @id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@nom", tb_mod_nom.Text);
                MesClasses.ManagerClasse.request_params.Add("@post_nom", tb_mod_postnom.Text);
                MesClasses.ManagerClasse.request_params.Add("@prenom", tb_mod_prenom.Text);
                MesClasses.ManagerClasse.request_params.Add("@sexe", tb_mod_genre.Text);
                MesClasses.ManagerClasse.request_params.Add("@phone", tb_mod_phone.Text);
                MesClasses.ManagerClasse.request_params.Add("@adresse", tb_mod_adresse.Text);
                MesClasses.ManagerClasse.request_params.Add("@id", IDPATIENT);
                MesClasses.ManagerClasse.CRUD(query_update, MesClasses.ManagerClasse.request_params);
                MessageBox.Show("Patient modifié avec succès !!", "Modification");
                CacherTextBox();
                ChargerDetails();
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Erreur de modification : " + ex.Message);
            }
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            CacherTextBox();
        }
    }
}
