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
    public partial class Form_Display_prescription : Form
    {
        string HOSPITALISATION_ID;
        public Form_Display_prescription(string id_hosp)
        {
            InitializeComponent();
            HOSPITALISATION_ID = id_hosp;
            LoadPrescription();
        }

        // ==================================== charger la liste de préscription du patient ================
        private void LoadPrescription()
        {
            dgv_prescription.Rows.Clear();
            try
            {
                string query = "SELECT pr.id_prescription,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS patient,CONCAT(per.nom,' ',per.post_nom) AS medecin,m.nom_medicament,pr.quantite,pr.unite,pr.statut,c.date_consultation FROM prescriptions pr JOIN consultation c ON pr.id_consultation = c.id_consultation  JOIN personnels per ON per.id_personnel = c.id_personnel JOIN medicament m ON pr.id_medicament = m.id_medicament JOIN patients p ON pr.id_patient = p.id_patient JOIN hospitalisation h ON h.id_consultation = c.id_consultation WHERE h.id_hospitalisation =@id ORDER BY pr.id_prescription DESC";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",HOSPITALISATION_ID);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                {
                    while(reader.Read())
                    {
                        groupBox1.Text = "Prescription du patient : "+reader["patient"];
                        int row = dgv_prescription.Rows.Add();
                        dgv_prescription.Rows[row].Cells["colDate"].Value = Convert.ToDateTime(reader["date_consultation"]).ToString("dd/MM/yyyy");
                        dgv_prescription.Rows[row].Cells["colMedecin"].Value = reader["medecin"];
                        dgv_prescription.Rows[row].Cells["colMedicament"].Value = reader["nom_medicament"];
                        dgv_prescription.Rows[row].Cells["colQuantite"].Value = reader["quantite"];
                        dgv_prescription.Rows[row].Cells["colUnite"].Value = reader["unite"];
                        dgv_prescription.Rows[row].Cells["colStatut"].Value = reader["statut"];
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
