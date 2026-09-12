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
    public partial class Detail_Personnel : Form
    {
        string personnelID;
        public Detail_Personnel(string id_personnel)
        {
            InitializeComponent();
            personnelID = id_personnel;
            LoadDetailsPersonnels();
          
        }
        private void LoadDetailsPersonnels()
        {
            try
            {
                string querySelect = "SELECT id_personnel,CONCAT('PER',' - ','CEP',' - ',YEAR(p.date_embauche)) AS dossier,nom,post_nom,prenom,sexe,date_naissance,date_embauche,fonction,p.telephone,p.adresse,nom_centre FROM personnels p JOIN centres c ON c.id_centre = p.id_centre WHERE id_personnel = @id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id", personnelID);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(querySelect, MesClasses.ManagerClasse.request_params, true))
                {
                    while (reader.Read())
                    {
                        lb_nom.Text = reader["nom"].ToString();
                        lb_postnom.Text = reader["post_nom"].ToString();
                        lb_prenom.Text = reader["prenom"].ToString();
                        lb_fonction.Text = reader["fonction"].ToString();
                        lb_genre.Text = reader["sexe"].ToString();
                        lb_dossier.Text = reader["dossier"].ToString();
                        lb_date_embauche.Text = Convert.ToDateTime(reader["date_embauche"]).ToString("dd/MM/yyyy");
                        lb_date.Text = Convert.ToDateTime(reader["date_naissance"]).ToString("dd/MM/yyyy");
                        lb_adresse.Text = reader["adresse"].ToString();
                        lb_phone.Text = reader["telephone"].ToString();
                        lb_centre.Text = reader["nom_centre"].ToString();
                    }
                    reader.Close();
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur de chargement de données : " + ex.Message);
            }
        }

        private void bunifuRoundedPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bt_add_salaire_Click(object sender, EventArgs e)
        {
            MesForms.Personnel.Add_salaire salaire = new Add_salaire(personnelID);
            salaire.ShowDialog();
        }
    }
}
