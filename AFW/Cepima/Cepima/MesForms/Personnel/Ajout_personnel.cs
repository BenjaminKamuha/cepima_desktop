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
    public partial class Ajout_personnel : Form
    {
        public Ajout_personnel()
        {
            InitializeComponent();
        }

        private void Ajout_personnel_Load(object sender, EventArgs e)
        {
            cbx_sifa.Items.Clear();
            cbx_sifa.Items.Add("-----Sélectionner le statut-----");
            cbx_sifa.Items.Add("Marié");
            cbx_sifa.Items.Add("Célibataire");
            cbx_sifa.Items.Add("Divorce");

            cbx_sifa.SelectedIndex = 0;
        }

        private void btn_save_personnel_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string queryInsert = "INSERT INTO personnels(nom,post_nom,prenom,sexe,date_naissance,date_embauche,fonction,telephone,adresse,situation_familliale)VALUES(@nom,@post,@prenom,@sexe,@naissance,@embauche,@fonction,@phone,@adresse,@sifa)";
                    using (MySqlCommand cmd = new MySqlCommand(queryInsert,con))
                    {
                        cmd.Parameters.AddWithValue("@nom",tb_nom.Text);
                        cmd.Parameters.AddWithValue("@post", tb_post_nom.Text);
                        cmd.Parameters.AddWithValue("@prenom", tb_prenom.Text);
                        cmd.Parameters.AddWithValue("@sexe", tb_sexe.Text);
                        cmd.Parameters.AddWithValue("@naissance",  dt_naisance.Value.Date);
                        cmd.Parameters.AddWithValue("@embauche", dt_embauche.Value.Date);
                        cmd.Parameters.AddWithValue("@fonction", tb_fonction.Text);
                        cmd.Parameters.AddWithValue("@phone", tb_phone.Text);
                        cmd.Parameters.AddWithValue("@adresse", tb_adresse.Text);
                        cmd.Parameters.AddWithValue("@sifa", cbx_sifa.Text);
                        cmd.ExecuteNonQuery();

                        ClearTextFill();
                    }

                    var result = MessageBox.Show("Voulez-vous continuer l'enregistrement du personnel??","Enregistrement",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erreur d'enregistrement : "+ex.Message);
                }
            }

        }

        private void ClearTextFill()
        {
            tb_nom.Text = "";
            tb_post_nom.Text = "";
            tb_prenom.Text = "";
            cbx_sifa.SelectedIndex = -1;
            tb_sexe.Text = "";
            tb_fonction.Text = "";
            tb_phone.Text = "";
            tb_adresse.Text = "";
        }
    }
}
