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
    public partial class Form_add_suivi_hospitalisation : Form
    {
        private string id_hospitalisation;
        public Form_add_suivi_hospitalisation(string idHosp)
        {
            InitializeComponent();
            id_hospitalisation = idHosp;
            LoadEnumCombo();
        }

        private void bt_close_window_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // =========================== save suivi hospitalisation =============================
        private void Save_suiv_hospitalisation()
        {
            string query = "INSERT INTO suivi_hospitalisation(id_hospitalisation,temperature,tension,rythme_cardiaque,observation,date_suivi,etat_mental)VALUES(@id,@temp,@tension,@rythme,@observation,NOW(),@etat)";
            MesClasses.ManagerClasse.request_params.Clear();
            MesClasses.ManagerClasse.request_params.Add("@id",id_hospitalisation);
            MesClasses.ManagerClasse.request_params.Add("@temp",tb_temperature.Text);
            MesClasses.ManagerClasse.request_params.Add("@tension",tb_tension.Text);
            MesClasses.ManagerClasse.request_params.Add("@rythme",tb_rythme.Text);
            MesClasses.ManagerClasse.request_params.Add("@observation",rich_text.Text);
            MesClasses.ManagerClasse.request_params.Add("@etat",cbx_etat_mental.SelectedItem.ToString());
            MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params);
            MessageBox.Show("Le suivi de l'hospitalisation "+id_hospitalisation+" a été effectué avec succès");

            // save l'historique du séjour
            MesClasses.Event.SaveHistorique(id_hospitalisation,"Suivi : Temp "+tb_temperature.Text+"°C, patient "+cbx_etat_mental.Text);
            CacherText();
        }
        private void CacherText()
        {
            tb_rythme.Text = "";
            tb_tension.Text = "";
            tb_temperature.Text = "";
            rich_text.Clear();
            cbx_etat_mental.SelectedIndex = -1;
        }

        private void bt_save_suivi_Click(object sender, EventArgs e)
        {
            Save_suiv_hospitalisation();
        }
        private void LoadEnumCombo()
        {
            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    string query = "SHOW COLUMNS FROM suivi_hospitalisation LIKE 'etat_mental'";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string enumValue = reader["Type"].ToString();

                        // enum('Simple','VIP','Urgence')

                        enumValue = enumValue.Replace("enum(", "").Replace(")", "").Replace("'", "");
                        string[] items = enumValue.Split(',');
                        cbx_etat_mental.Items.Clear();
                        cbx_etat_mental.Items.AddRange(items);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
