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

namespace Cepima.MesUserCases.Hospitalisation
{
    public partial class User_DashBoard_Hospi : UserControl
    {
        public User_DashBoard_Hospi()
        {
            InitializeComponent();
            LoadResume();
        }

        private void LoadResume()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    // aficher le nombre des patients hospitalisés
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*)  FROM hospitalisation WHERE etat = 'Hospitalisé'", con))
                    {
                        lb_total.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString();
                    }

                    // afficher le nombre de chambre
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM chambre ",con))
                    {
                        lb_chambre.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString();
                    }

                    // afficher le nombre de chambre occupée
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM chambre WHERE statut = 'Occupée'",con))
                    {
                        lb_libre.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString();
                    }

                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM hospitalisation WHERE date_sortie IS NOT NULL",con))
                    {
                        lb_sorties.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erreur : "+ex.Message);
                }
            }
        }

        private void User_DashBoard_Hospi_Load(object sender, EventArgs e)
        {
            combo_statut.Items.Clear();

            combo_statut.Items.Add("Tous");
            combo_statut.Items.Add("Hospitalisé");
            combo_statut.Items.Add("En observation");
            combo_statut.Items.Add("Stable");
            combo_statut.Items.Add("Sorti");

            combo_statut.SelectedIndex = 0;

            LoadHospitalisations();
        }

        private void combo_statut_SelectedIndexChanged(object sender, EventArgs e)
        {
            string statut = "";

            if (combo_statut.SelectedItem != null)
            {
                statut = combo_statut.SelectedItem.ToString();
            }

            LoadHospitalisations(txt_recherche.Text,statut);
        }

        private void txt_recherche_TextChanged(object sender, EventArgs e)
        {
            string statut = "";

            if (combo_statut.SelectedItem != null)
            {
                statut = combo_statut.SelectedItem.ToString();
            }

            LoadHospitalisations(txt_recherche.Text,statut);
        }

        private void LoadHospitalisations(string recherche = "",string statut = "")
        {
            dgv_hospitalisation.Rows.Clear();

            try
            {
                string query = "SELECT h.id_hospitalisation, h.date_entree,h.date_sortie,h.etat,p.nom,p.post_nom,p.prenom,p.date_naissance, p.adresse,c.numero_chambre,c.tarif_journalier FROM hospitalisation h INNER JOIN patients p ON h.id_patient = p.id_patient INNER JOIN affectation_chambre a ON a.id_hospitalisation = h.id_hospitalisation JOIN chambre c ON a.id_chambre = c.id_chambre WHERE 1 = 1";

                MesClasses.ManagerClasse.request_params.Clear();

                if (!string.IsNullOrWhiteSpace(recherche))
                {
                    query += " AND ( p.nom LIKE @search OR p.post_nom LIKE @search OR p.prenom LIKE @search)";

                    MesClasses.ManagerClasse.request_params.Add( "@search", "%" + recherche + "%");
                }

                if (!string.IsNullOrWhiteSpace(statut) &&
                    statut != "Tous")
                {
                    query += " AND h.etat = @statut";

                    MesClasses.ManagerClasse.request_params.Add(
                        "@statut",
                        statut
                    );
                }

                query += " ORDER BY h.date_entree DESC LIMIT 15";
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string nom = reader["nom"].ToString();
                            string postnom = reader["post_nom"].ToString();
                            string prenom = reader["prenom"].ToString();
                            string patient = nom + " " + postnom + " " + prenom;
                            string chambre = reader["numero_chambre"].ToString();
                            string tarif = reader["tarif_journalier"].ToString();
                            int age = MesClasses.ReceptionManager.CalculerAge(Convert.ToDateTime(reader["date_naissance"]));
                            string adresse = reader["adresse"].ToString();
                            string dateEntree = Convert.ToDateTime(reader["date_entree"]).ToString("dd/MM/yyyy");
                            string etat = reader["etat"].ToString();

                            // ====================================
                            // AJOUT DANS LE DATAGRIDVIEW
                            // ====================================

                            dgv_hospitalisation.Rows.Add(
                                patient,
                                age + " ans",
                                adresse,
                                "Chambre N° :"+chambre,      
                                tarif+"$",         
                                dateEntree,
                                etat
                            );

                            dgv_hospitalisation.Columns["colPatient"].Width = 200;

                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
