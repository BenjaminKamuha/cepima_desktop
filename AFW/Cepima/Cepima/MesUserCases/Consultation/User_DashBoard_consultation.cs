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
    public partial class User_DashBoard_consultation : UserControl
    {
        int idPatient = 0;
        public User_DashBoard_consultation()
        {
            InitializeComponent();
            LoadFilter();
            LoadInforDay();
            LoadConsultations();
        }

        private void dgv_consult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_consultations.CurrentRow != null)
            {
               bt_start.Visible = true;
               idPatient = Convert.ToInt32(dgv_consultations.CurrentRow.Cells["ID_Patient"].Value);
            }
            else
            {
                bt_start.Visible = false;
                return;
            }
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            // appel du User_consultation
            MesUserCases.User_consultation cons = new User_consultation(idPatient);
            cons.Dock = DockStyle.Fill;
            Form1.GlobalPanel_main.Controls.Clear();
            Form1.GlobalPanel_main.Controls.Add(cons);
        }

        private void LoadFilter()
        {
            cbx_filtrer.Items.Clear();
            cbx_filtrer.Items.Add("Toutes les consultations");
            cbx_filtrer.Items.Add("Première consultation");
            cbx_filtrer.Items.Add("Consultation de contrôle");
            cbx_filtrer.Items.Add("Consultation d'urgence");

            cbx_filtrer.SelectedIndex = 0;
        }

        //chager les informations du jour de la consultation
        private void LoadInforDay()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string queryOne = "SELECT COUNT(*) AS Nombre FROM consultation WHERE date_consultation = CURDATE()";
                    using (MySqlCommand cmd = new MySqlCommand(queryOne, con))
                    {
                        int nombre = Convert.ToInt32(cmd.ExecuteScalar());
                        lb_consultation.Text = nombre.ToString();
                    }

                    //consultation en attente
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(DISTINCT id_consultation) AS nombre FROM demande_service WHERE statut = 'Terminée'AND id_consultation IS NOT NULL AND date_demande = CURDATE()", con))
                    {
                        int nombre = Convert.ToInt32(cmd.ExecuteScalar());
                        lb_termine.Text = nombre.ToString();
                    }

                    //consultation terminées
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(DISTINCT id_consultation) AS nombre FROM demande_service WHERE statut = 'Demandée' AND id_consultation IS NOT NULL AND date_demande = CURDATE()",con))
                    {
                        int nombre = Convert.ToInt32(cmd.ExecuteScalar());
                        lb_attente.Text = nombre.ToString();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erreur de chargement de données : " + ex.Message);
                }
            }
        }

        //charger les consultations dans le datagridview
        private void LoadConsultations()
        {
            try
            {
                string recherche = txt_recherche.Text.Trim();

                string typeFiltre = "";

                // Déterminer le filtre sélectionné
                if (cbx_filtrer.SelectedIndex == 1)
                {
                    typeFiltre = "Première consultation";
                }
                else if (cbx_filtrer.SelectedIndex == 2)
                {
                    typeFiltre = "Consultation de contrôle";
                }
                else if (cbx_filtrer.SelectedIndex == 3)
                {
                    typeFiltre = "Consultation d'urgence";
                }

                string query = "SELECT c.id,p.id_patient,p.nom,p.post_nom,p.prenom,p.sexe,p.date_naissance,c.type_consultation,c.motif,c.date_consultation FROM patients p INNER JOIN consultation c ON p.id_patient = c.patient_id WHERE (p.nom LIKE @recherche OR p.post_nom LIKE @recherche OR p.prenom LIKE @recherche OR p.numero_fiche LIKE @recherche )";

                // Ajouter le filtre du type de consultation
                if (typeFiltre != "")
                {
                    query += " AND c.type_consultation = @type_consultation ";
                }

                query += " ORDER BY c.date_consultation DESC";

                // Paramètre recherche
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@recherche", "%" + recherche + "%");

                // Paramètre du filtre
                if (typeFiltre != "")
                {
                    MesClasses.ManagerClasse.request_params.Add("@type_consultation",typeFiltre);
                }

                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                {
                    dgv_consultations.Rows.Clear();

                    while (reader.Read())
                    {
                        int numero = Convert.ToInt32(reader["id"]);
                        string patient = reader["nom"].ToString() + " " +reader["post_nom"].ToString() + " " +reader["prenom"].ToString();

                        string sexe = reader["sexe"].ToString();

                        int age = 0;

                        if (reader["date_naissance"] != DBNull.Value)
                        {
                            DateTime dateNaissance = Convert.ToDateTime(reader["date_naissance"]);
                            age = CalculerAge(dateNaissance);
                        }

                        string typeConsultation = reader["type_consultation"].ToString();

                        string adresse = reader["adresse"].ToString();

                        string motif = reader["motif"].ToString();

                        string statut = "En cours";

                        dgv_consultations.Rows.Add(
                            numero,
                            patient,
                            sexe,
                            age,
                            typeConsultation,
                            adresse,
                            motif,
                            statut
                        );

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des consultations :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        //calculer l'age du patient 
        private int CalculerAge(DateTime dateNaissance)
        {
            DateTime aujourdHui = DateTime.Today;

            int age = aujourdHui.Year - dateNaissance.Year;

            if (dateNaissance.Date > aujourdHui.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        private void cbx_filtrer_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadConsultations();
        }

        private void txt_recherche_TextChanged(object sender, EventArgs e)
        {
            LoadConsultations();
        }
    }
}
