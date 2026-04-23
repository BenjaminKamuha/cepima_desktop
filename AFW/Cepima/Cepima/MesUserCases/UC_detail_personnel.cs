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
    public partial class UC_detail_personnel : UserControl
    {
        string personelId;
        public UC_detail_personnel(string id_personnel)
        {
            InitializeComponent();
            personelId = id_personnel;
            LoadDetailsPersonnels();
        }

        // ====================== cacher les textBox =========================================
        private void CacherTextBox()
        {
            tb_mod_nom.Visible = false;
            tb_mod_postnom.Visible = false;
            tb_mod_prenom.Visible = false;
            tb_mod_genre.Visible = false;
            tb_mod_fonction.Visible = false;
            tb_mod_adresse.Visible = false;
            tb_mod_phone.Visible = false;
            dt_date_embauche.Visible = false;
            bt_cancel.Visible = false;
            bt_save_update.Visible = false;
        }

        // ========================================== Charger les détails du personnel ==================================
        private void LoadDetailsPersonnels()
        {
            CacherTextBox();
            try
            {
                string querySelect = "SELECT id_personnel,nom,post_nom,prenom,sexe,date_naissance,date_embauche,fonction,p.telephone,p.adresse,nom_centre FROM personnels p JOIN centres c ON c.id_centre = p.id_centre WHERE id_personnel = @id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",personelId);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(querySelect, MesClasses.ManagerClasse.request_params, true))
                {
                    while (reader.Read())
                    {
                        lb_nom.Text = reader["nom"].ToString();
                        tb_mod_nom.Text = reader["nom"].ToString();
                        lb_postnom.Text = reader["post_nom"].ToString();
                        tb_mod_postnom.Text = reader["post_nom"].ToString();
                        lb_prenom.Text = reader["prenom"].ToString();
                        tb_mod_prenom.Text = reader["prenom"].ToString();
                        lb_fonction.Text = reader["fonction"].ToString();
                        tb_mod_fonction.Text = reader["fonction"].ToString();
                        lb_genre.Text = reader["sexe"].ToString();
                        tb_mod_genre.Text = reader["sexe"].ToString();
                        lb_date_embauche.Text = Convert.ToDateTime(reader["date_embauche"]).ToString("dd/MM/yyyy");
                        dt_date_embauche.Text = Convert.ToDateTime(reader["date_embauche"]).ToString("dd/MM/yyyy");
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
                MessageBox.Show("Erreur de chargement de données : "+ex.Message);
            }
        }

        private void bt_return_Click(object sender, EventArgs e)
        {
            MesUserCases.User_personnels_display display = new User_personnels_display();
            display.Dock = DockStyle.Fill;
            Form1.GlobalPanel_main.Controls.Clear();
            Form1.GlobalPanel_main.Controls.Add(display);
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
            bt_cancel.Visible = true;
            bt_save_update.Visible = true;
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

        private void bt_mod_fonction_Click(object sender, EventArgs e)
        {
            tb_mod_fonction.Visible = true;
            tb_mod_fonction.Text = lb_fonction.Text;
            tb_mod_fonction.Focus();
            tb_mod_fonction.SelectAll();
            bt_cancel.Visible = true;
            bt_save_update.Visible = true;
        }

        private void bt_mod_date_embauche_Click(object sender, EventArgs e)
        {
            dt_date_embauche.Visible = true;
            dt_date_embauche.Text = lb_date_embauche.Text;
            dt_date_embauche.Focus();
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

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            CacherTextBox();
        }

        private void bt_save_update_Click(object sender, EventArgs e)
        {
            try
            {
                string UpdateQuery = "UPDATE personnels SET nom=@nom,post_nom=@post,prenom=@prenom,sexe=@sexe,date_embauche=@date,fonction=@fonction,adresse=@adresse,telephone=@phone WHERE id_personnel =@personnel";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@nom",tb_mod_nom.Text);
                MesClasses.ManagerClasse.request_params.Add("@post",tb_mod_postnom.Text);
                MesClasses.ManagerClasse.request_params.Add("@prenom",tb_mod_prenom.Text);
                MesClasses.ManagerClasse.request_params.Add("@sexe",tb_mod_genre.Text);
                MesClasses.ManagerClasse.request_params.Add("@date",dt_date_embauche.Value.ToString("yyyy-MM-dd"));
                MesClasses.ManagerClasse.request_params.Add("@fonction",tb_mod_fonction.Text);
                MesClasses.ManagerClasse.request_params.Add("@adresse",tb_mod_adresse.Text);
                MesClasses.ManagerClasse.request_params.Add("@phone",tb_mod_phone.Text);
                MesClasses.ManagerClasse.request_params.Add("@personnel",personelId);
                MesClasses.ManagerClasse.CRUD(UpdateQuery,MesClasses.ManagerClasse.request_params);
                MessageBox.Show("Le personnel "+tb_mod_nom.Text+ " "+tb_mod_postnom.Text+ " "+tb_mod_prenom.Text+ " a été modifié ");
                CacherTextBox();
                LoadDetailsPersonnels();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur de modification "+ex.Message);
            }
        }

        private void bt_delete_personnel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Voulez-vous supprimer "+lb_nom.Text+" "+lb_postnom.Text+ " "+lb_prenom.Text+" ?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string DeleteQuery = "DELETE FROM personnels WHERE id_personnel =@personnel";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@personnel", personelId);
                    MesClasses.ManagerClasse.CRUD(DeleteQuery, MesClasses.ManagerClasse.request_params);
                    MessageBox.Show("Suppression du personnel " + lb_nom.Text + " " + lb_postnom.Text);
                    bt_return.PerformClick();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erreur de suppression " + ex.Message);
                }
            }
        }
    }
}
