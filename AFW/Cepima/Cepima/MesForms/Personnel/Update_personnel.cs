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
    public partial class Update_personnel : Form
    {
        string id_personnel;
        public Update_personnel(string id_)
        {
            InitializeComponent();
            this.id_personnel = id_;
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            try
            {
                string queryUpdate = "UPDATE personnels SET nom=@nom,post_nom=@post,prenom=@prenom,sexe=@sexe,situation_familliale=@sifa,date_naissance=@naissance,date_embauche=@embauche,fonction=@fonction,telephone=@phone,adresse=@adresse WHERE id_personnel = @id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@nom",tb_mod_nom.Text);
                MesClasses.ManagerClasse.request_params.Add("@post",tb_mod_post.Text);
                MesClasses.ManagerClasse.request_params.Add("@prenom",tb_mod_prenom.Text);
                MesClasses.ManagerClasse.request_params.Add("@sexe",tb_mod_sexe.Text);
                MesClasses.ManagerClasse.request_params.Add("@sifa",tb_mod_sifa.Text);
                MesClasses.ManagerClasse.request_params.Add("@naissance",dt_naissance.Value.Date.ToString("yyyy-MM-dd"));
                MesClasses.ManagerClasse.request_params.Add("@embauche",dt_embauche.Value.Date.ToString("yyyy-MM-dd"));
                MesClasses.ManagerClasse.request_params.Add("@fonction",tb_mod_fonction.Text);
                MesClasses.ManagerClasse.request_params.Add("@phone", tb_mod_phone.Text);
                MesClasses.ManagerClasse.request_params.Add("@adresse", tb_mod_adresse.Text);
                MesClasses.ManagerClasse.request_params.Add("@id",this.id_personnel);

                MesClasses.ManagerClasse.CRUD(queryUpdate,MesClasses.ManagerClasse.request_params);
                MessageBox.Show("Modification réussie avec succès!!");
                MesForms.Personnel.Detail_Test.btRefresh.PerformClick();
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erreur : "+ex.Message);
            }
        }

        private void Update_personnel_Load(object sender, EventArgs e)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string query = "SELECT nom,post_nom,prenom,sexe,date_naissance,situation_familliale,date_embauche,adresse,telephone,fonction FROM personnels WHERE id_personnel =  @id";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@id",this.id_personnel);
                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                    {
                        while (reader.Read())
                        {
                            tb_mod_nom.Text = reader["nom"].ToString();
                            tb_mod_post.Text = reader["post_nom"].ToString();
                            tb_mod_prenom.Text = reader["prenom"].ToString();
                            tb_mod_sexe.Text = reader["sexe"].ToString();
                            tb_mod_sifa.Text = reader["situation_familliale"].ToString();
                            tb_mod_phone.Text = reader["telephone"].ToString();
                            tb_mod_adresse.Text = reader["adresse"].ToString();
                            tb_mod_fonction.Text = reader["fonction"].ToString();
                            dt_embauche.Value = Convert.ToDateTime(reader["date_embauche"]);
                            dt_naissance.Value = Convert.ToDateTime(reader["date_naissance"]);
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erreur : "+ex.Message);
                }
            }
        }
    }
}
