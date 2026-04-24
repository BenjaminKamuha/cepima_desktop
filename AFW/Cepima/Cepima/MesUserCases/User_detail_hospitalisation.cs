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
    public partial class User_detail_hospitalisation : UserControl
    {
        private string hospitalisationID;
        public User_detail_hospitalisation(string id)
        {
            InitializeComponent();
            hospitalisationID = id;
            ChargerDetailsHospitalisation();
        }

        // ============================= méthode pour charger tous les détails ======================
        private void ChargerDetailsHospitalisation()
        {
            try
            {
                string querySelect = "SELECT h.id_hospitalisation,h.date_entree,h.date_sortie,h.motif,h.etat,p.nom,p.post_nom,p.prenom,p.telephone,c.nom_centre,s.nom_service,ch.numero_chambre,ch.type_chambre,ch.tarif_journalier,a.date_debut,a.date_fin,cons.date_consultation,cons.diagnostic FROM hospitalisation h INNER JOIN patients p ON p.id_patient = h.id_patient INNER JOIN centres c ON c.id_centre = h.id_centre INNER JOIN service s ON s.id_service = h.id_service LEFT JOIN affectation_chambre a ON a.id_hospitalisation = h.id_hospitalisation LEFT JOIN chambres ch ON ch.id_chambres = a.id_chambre LEFT JOIN consultation cons ON cons.id_consultation = h.id_consultation WHERE h.id_hospitalisation = @id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",hospitalisationID);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(querySelect,MesClasses.ManagerClasse.request_params,true))
                {
                    while (reader.Read())
                    {
                        //Patient
                        lb_nom.Text = reader["nom"].ToString();
                        lb_postnom.Text = reader["post_nom"].ToString();
                        lb_prenom.Text = reader["prenom"].ToString();
                        lb_sexe.Text = reader["telephone"].ToString();

                        //hospitalisation
                        lb_date_entree.Text = Convert.ToDateTime(reader["date_entree"]).ToString("dd/MM/yyyy");
                        lb_date_sortie.Text = Convert.ToDateTime(reader["date_sortie"]).ToString("dd/MM/yyyy");
                        lb_etat.Text = reader["etat"].ToString();
                        lb_motif.Text = reader["motif"].ToString();

                        //Centre/service
                        lb_centre.Text = reader["nom_centre"].ToString();
                        lb_service.Text = reader["nom_service"].ToString();
                        lb_numero_chambre.Text = reader["numero_chambre"].ToString();
                        lb_type.Text = reader["type_chambre"].ToString();
                        lb_tarif.Text = reader["tarif"].ToString();

                        //Consultation
                        lb_date_consultation.Text = Convert.ToDateTime(reader["date_consultation"]).ToString("dd/MM/yyyy");
                        lb_diagnostic.Text = reader["diagnostic"].ToString();
                    }
                    reader.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur du chargement de données : "+ex.Message);
            }
        }

        private void bt_update_Click(object sender, EventArgs e)
        {

        }

        private void bt_report_Click(object sender, EventArgs e)
        {

        }
    }
}
