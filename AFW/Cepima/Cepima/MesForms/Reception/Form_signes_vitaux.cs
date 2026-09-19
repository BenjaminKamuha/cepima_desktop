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
    public partial class Form_signes_vitaux : Form
    {
        int PatientID;
        public Form_signes_vitaux(int idPatient)
        {
            InitializeComponent();
            PatientID = idPatient;
        }

        private void Form_signes_vitaux_Load(object sender, EventArgs e)
        {
            LoadInfosPatient();
        }

        // charger les informations personnels du patient
        private void LoadInfosPatient()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT nom,post_nom,prenom,numero_fiche FROM patients WHERE id_patient = @id", con))
                    {
                        cmd.Parameters.AddWithValue("@id",PatientID);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            lb_nom.Text = reader["nom"].ToString();
                            lb_postnom.Text = reader["post_nom"].ToString();
                            lb_prenom.Text = reader["prenom"].ToString();
                            lb_fiche.Text = reader["numero_fiche"].ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void bt_save_signe_Click(object sender, EventArgs e)
        {
            string tension = tb_tension.Text;
            try
            {
                decimal poid = Convert.ToDecimal(tb_poids.Text);
                decimal taille = Convert.ToDecimal(tb_taille.Text);

                string frequence = tb_frequence.Text;
                decimal temp = Convert.ToDecimal(tb_temperature.Text);
                MesClasses.ReceptionManager.SaveSigneVitaux(PatientID.ToString(), temp, tension, frequence, poid, taille);
                ViderChamps();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur d'enreigstrement. Vérifier vos inforamtions", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        //vider les champs
        private void ViderChamps()
        {
            PatientID = 0;
            tb_taille.Clear();
            tb_poids.Clear();
            tb_temperature.Clear();
            tb_tension.Clear();
            tb_frequence.Clear();
        }

        private void bt_save_signe_Load(object sender, EventArgs e)
        {

        }
    }
}
