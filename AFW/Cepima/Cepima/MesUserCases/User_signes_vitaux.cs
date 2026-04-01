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
    public partial class User_signes_vitaux : UserControl
    {
        public User_signes_vitaux()
        {
            InitializeComponent();
            LoadPatientInCbx(cbx_patient_signes);
            MesClasses.ReceptionManager.MoveLabel(label1,panel1,2);
        }

        private void bt_save_signes_Click(object sender, EventArgs e)
        {
            //récuperation des différentes données
            string id_patient = cbx_patient_signes.SelectedValue.ToString();
            decimal temperature = Convert.ToDecimal(tb_temperature.Text);
            string tensionArterielle = tb_tension.Text;
            int frequence_cardiaque = Convert.ToInt32(tb_frequence.Text);
            decimal poids = Convert.ToDecimal(tb_poids.Text);
            decimal taille = Convert.ToDecimal(tb_taille.Text);
            MesClasses.ReceptionManager.SaveSigneVitaux(id_patient,temperature,tensionArterielle,frequence_cardiaque,poids,taille);
        }

        // ======================= Charger les patients dans le comboBox ====================================
        private void LoadPatientInCbx(ComboBox cbx)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                MySqlTransaction tr = con.BeginTransaction();
                try
                {
                    string querySelectPatients = "SELECT id_patient, CONCAT(numero_fiche,'   ',nom,' ',post_nom,' ',prenom)AS nomCompletPatient FROM patients ORDER BY nom DESC ";
                    using (MySqlCommand cmdPatients = new MySqlCommand(querySelectPatients,con,tr))
                    {
                        DataTable dt = new DataTable();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmdPatients);
                        da.Fill(dt);
                        cbx.DataSource = dt;
                        cbx.DisplayMember = "nomCompletPatient";
                        cbx.ValueMember = "id_patient";
                        cbx.SelectedIndex = -1;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erreur lors du chargement des patients : "+ex.Message);
                }
            }
        }
    }
}
