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

        private bool VerifierChampsSignesVitaux()
        {
            // comboBox_patients
            if (cbx_patient_signes.SelectedIndex == -1)
            {
                User_patient.erreur.SetError(cbx_patient_signes, "Vous devez sélectionner un patient");
                return false;
            }
            else
            {
                User_patient.erreur.SetError(cbx_patient_signes, "");
            }

            // tb_temperature
            if (tb_temperature.Text.Trim() == "")
            {
                User_patient.erreur.SetError(tb_temperature, "Ce champ est obligatoire");
                tb_temperature.Focus();
                return false;
            }
            else
            {
                User_patient.erreur.SetError(tb_temperature, "");
            }

            // tb_tension
            if (tb_tension.Text.Trim() == "")
            {
                User_patient.erreur.SetError(tb_tension, "Ce champ est obligatoire");
                tb_tension.Focus();
                return false;
            }
            else
            {
                User_patient.erreur.SetError(tb_tension, "");
            }

            //  tb_fréquence
            if (tb_frequence.Text.Trim() == "")
            {
                User_patient.erreur.SetError(tb_frequence, "Ce champ est obligatoire");
                tb_frequence.Focus();
                return false;
            }
            else
            {
                User_patient.erreur.SetError(tb_frequence, "");
            }

            //  tb_ poids
            if (tb_poids.Text.Trim() == "")
            {
                User_patient.erreur.SetError(tb_poids, "Ce champ est obligatoire");
                tb_poids.Focus();
                return false;
            }
            else
            {
                User_patient.erreur.SetError(tb_poids, "");
            }

            // tb_ taille
            if (tb_taille.Text.Trim() == string.Empty)
            {
                User_patient.erreur.SetError(tb_taille, "Ce champs est obligatoire");
                return false;
            }
            else
            {
                User_patient.erreur.SetError(tb_taille, "");
            }
            return true;
        }
    }
}
