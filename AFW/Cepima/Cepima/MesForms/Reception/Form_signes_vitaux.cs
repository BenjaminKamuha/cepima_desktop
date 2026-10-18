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
            cbx_etat.Items.Clear();
            cbx_etat.Items.Add("Bon");
            cbx_etat.Items.Add("Moyen");
            cbx_etat.Items.Add("Altéré");
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
            try
            {
                decimal poids = Convert.ToDecimal(tb_poids.Text);
                decimal taille = Convert.ToDecimal(tb_taille.Text);
                decimal temperature = Convert.ToDecimal(tb_temperature.Text);

                string tension = tb_tension.Text;
                string frequence = tb_frequence.Text;
                string etat = cbx_etat.Text;

                bool enregistre = MesClasses.ReceptionManager.SaveSigneVitaux(
                    PatientID.ToString(),
                    temperature,
                    tension,
                    frequence,
                    poids,
                    taille,
                    etat);

                if (enregistre)
                {
                    ViderChamps();
                    this.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Vérifiez la température, le poids et la taille.",
                    "Informations invalides",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Une erreur est survenue : " + ex.Message,
                    "Enregistrement",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
