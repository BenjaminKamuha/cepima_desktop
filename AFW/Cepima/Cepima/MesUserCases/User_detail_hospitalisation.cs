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
                        
                    }
                    reader.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur du chargement de données : "+ex.Message);
            }
        }
    }
}
