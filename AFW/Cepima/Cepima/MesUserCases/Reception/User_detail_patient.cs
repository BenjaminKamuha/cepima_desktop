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
    public partial class User_detail_patient : UserControl
    {
        private string _patientId;

        public User_detail_patient(string id_patient)
        {
            InitializeComponent();

            _patientId = id_patient;

            ChargerDetails();
        }


        // ============================================================
        // CHARGER LES DETAILS DU PATIENT
        // ============================================================

        public void ChargerDetails()
        {
            try
            {
                tb_num_fiche.Focus();

                CacherTextBox();

                string querySelect = @"
                    SELECT
                        p.id_patient,
                        p.numero_fiche,
                        p.nom,
                        p.post_nom,
                        p.prenom,
                        p.sexe,
                        p.date_naissance,
                        p.adresse,
                        p.telephone,
                        c.nom_centre

                    FROM patients p

                    INNER JOIN centres c
                        ON c.id_centre = p.id_centre

                    WHERE p.id_patient = @id

                    LIMIT 1";


                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id",
                    _patientId
                );


                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        querySelect,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    if (reader.Read())
                    {
                        // =================================================
                        // NUMERO FICHE
                        // =================================================

                        tb_num_fiche.Text =
                            GetValue(
                                reader,
                                "numero_fiche");


                        // =================================================
                        // NOM
                        // =================================================

                        string nom =
                            GetValue(
                                reader,
                                "nom");

                        lb_nom.Text = nom;
                        tb_mod_nom.Text = nom;


                        // =================================================
                        // POST-NOM
                        // =================================================

                        string postNom =
                            GetValue(
                                reader,
                                "post_nom");

                        lb_postnom.Text = postNom;
                        tb_mod_postnom.Text = postNom;


                        // =================================================
                        // PRENOM
                        // =================================================

                        string prenom =
                            GetValue(
                                reader,
                                "prenom");

                        lb_prenom.Text = prenom;
                        tb_mod_prenom.Text = prenom;


                        // =================================================
                        // SEXE
                        // =================================================

                        string sexe =
                            GetValue(
                                reader,
                                "sexe");

                        lb_genre.Text = sexe;
                        tb_mod_genre.Text = sexe;


                        // =================================================
                        // DATE DE NAISSANCE
                        // =================================================

                        if (reader["date_naissance"] !=
                            DBNull.Value)
                        {
                            DateTime dateNaissance =
                                Convert.ToDateTime(
                                    reader[
                                        "date_naissance"]);

                            lb_date.Text =
                                dateNaissance.ToString(
                                    "dd/MM/yyyy");
                        }
                        else
                        {
                            lb_date.Text = "";
                        }


                        // =================================================
                        // ADRESSE
                        // =================================================

                        string adresse =
                            GetValue(
                                reader,
                                "adresse");

                        lb_adresse.Text = adresse;
                        tb_mod_adresse.Text = adresse;


                        // =================================================
                        // TELEPHONE
                        // =================================================

                        string telephone =
                            GetValue(
                                reader,
                                "telephone");

                        lb_phone.Text = telephone;
                        tb_mod_phone.Text = telephone;


                        // =================================================
                        // CENTRE
                        // =================================================

                        lb_centre.Text =
                            GetValue(
                                reader,
                                "nom_centre");
                    }
                    else
                    {
                        MessageBox.Show(
                            "Patient introuvable.",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur du chargement des détails :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des détails :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ============================================================
        // RECUPERER UNE VALEUR SQL SANS RISQUE DE NULL
        // ============================================================

        private string GetValue(
            MySqlDataReader reader,
            string column)
        {
            if (reader[column] == DBNull.Value)
            {
                return "";
            }

            return reader[column].ToString();
        }


        // ============================================================
        // CACHER LES TEXTBOX DE MODIFICATION
        // ============================================================

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


        // ============================================================
        // RETOUR
        // ============================================================

        private void bt_return_Click(
            object sender,
            EventArgs e)
        {
            MesUserCases.User_display_patients pt =
                new User_display_patients();

            pt.Dock = DockStyle.Fill;

            Form1.GlobalPanel_main.Controls.Clear();

            Form1.GlobalPanel_main.Controls.Add(pt);
        }


        // ============================================================
        // MODIFICATION NOM
        // ============================================================

        private void bt_mod_nom_Click(
            object sender,
            EventArgs e)
        {
            AfficherModification(
                tb_mod_nom,
                lb_nom.Text);
        }


        // ============================================================
        // MODIFICATION POST-NOM
        // ============================================================

        private void bt_mod_postnom_Click(
            object sender,
            EventArgs e)
        {
            AfficherModification(
                tb_mod_postnom,
                lb_postnom.Text);
        }


        // ============================================================
        // MODIFICATION PRENOM
        // ============================================================

        private void bt_mod_prenom_Click(
            object sender,
            EventArgs e)
        {
            AfficherModification(
                tb_mod_prenom,
                lb_prenom.Text);
        }


        // ============================================================
        // MODIFICATION GENRE
        // ============================================================

        private void bt_mod_genre_Click(
            object sender,
            EventArgs e)
        {
            AfficherModification(
                tb_mod_genre,
                lb_genre.Text);
        }


        // ============================================================
        // MODIFICATION ADRESSE
        // ============================================================

        private void bt_mod_adresse_Click(
            object sender,
            EventArgs e)
        {
            AfficherModification(
                tb_mod_adresse,
                lb_adresse.Text);
        }


        // ============================================================
        // MODIFICATION TELEPHONE
        // ============================================================

        private void bt_mod_phone_Click(
            object sender,
            EventArgs e)
        {
            AfficherModification(
                tb_mod_phone,
                lb_phone.Text);
        }


        // ============================================================
        // AFFICHER UN CHAMP DE MODIFICATION
        // ============================================================

        private void AfficherModification(
            TextBox textbox,
            string valeur)
        {
            textbox.Visible = true;

            textbox.Text = valeur;

            textbox.Focus();

            textbox.SelectAll();

            bt_cancel.Visible = true;

            bt_save_update.Visible = true;
        }


        // ============================================================
        // ANNULER MODIFICATION
        // ============================================================

        private void bt_cancel_Click(
            object sender,
            EventArgs e)
        {
            CacherTextBox();
        }


        // ============================================================
        // ENREGISTRER MODIFICATION
        // ============================================================

        private void bt_save_update_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                string query_update = @"
                    UPDATE patients

                    SET
                        nom = @nom,
                        post_nom = @post_nom,
                        prenom = @prenom,
                        sexe = @sexe,
                        telephone = @phone,
                        adresse = @adresse

                    WHERE id_patient = @id";


                MesClasses.ManagerClasse.request_params.Clear();


                MesClasses.ManagerClasse.request_params.Add(
                    "@nom",
                    tb_mod_nom.Text.Trim()
                );


                MesClasses.ManagerClasse.request_params.Add(
                    "@post_nom",
                    tb_mod_postnom.Text.Trim()
                );


                MesClasses.ManagerClasse.request_params.Add(
                    "@prenom",
                    tb_mod_prenom.Text.Trim()
                );


                MesClasses.ManagerClasse.request_params.Add(
                    "@sexe",
                    tb_mod_genre.Text.Trim()
                );


                MesClasses.ManagerClasse.request_params.Add(
                    "@phone",
                    tb_mod_phone.Text.Trim()
                );


                MesClasses.ManagerClasse.request_params.Add(
                    "@adresse",
                    tb_mod_adresse.Text.Trim()
                );


                MesClasses.ManagerClasse.request_params.Add(
                    "@id",
                    _patientId
                );


                MesClasses.ManagerClasse.CRUD(
                    query_update,
                    MesClasses.ManagerClasse.request_params
                );


                MessageBox.Show(
                    "Patient modifié avec succès !!",
                    "Modification",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                CacherTextBox();

                ChargerDetails();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur de modification :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la modification :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ============================================================
        // SUPPRIMER PATIENT
        // ============================================================

        private void bt_delete_patient_Click(
            object sender,
            EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Voulez-vous supprimer le patient " +
                    lb_nom.Text +
                    " " +
                    lb_postnom.Text +
                    " ?",
                    "Suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);


            if (result != DialogResult.Yes)
            {
                return;
            }


            try
            {
                string query_delete = @"
                    DELETE FROM patients
                    WHERE id_patient = @id";


                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id",
                    _patientId
                );


                MesClasses.ManagerClasse.CRUD(
                    query_delete,
                    MesClasses.ManagerClasse.request_params
                );


                MessageBox.Show(
                    "Patient supprimé avec succès !",
                    "Suppression",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                bt_return.PerformClick();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors de la suppression :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la suppression :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}