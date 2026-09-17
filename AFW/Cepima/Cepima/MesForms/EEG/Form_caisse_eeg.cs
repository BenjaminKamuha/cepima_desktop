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
using Cepima.Data;

namespace Cepima.MesForms.EEG
{
    public partial class Form_caisse_eeg : Form
    {
        string ID_PATIENT;

        public Form_caisse_eeg(string patient)
        {
            InitializeComponent();

            ID_PATIENT = patient;
        }

        private void bt_confirmer_Click(object sender, EventArgs e)
        {

            Database db = new Database();

            decimal montant = Convert.ToDecimal(tb_montant.Text);
            int id_facture = 0;
            using (MySqlConnection con = db.GetConnection())
            {
                MySqlTransaction tr = con.BeginTransaction();

                string query = "SELECT id_facture FROM facture WHERE id_patient = @idPatient AND (statut='Non payé' OR statut='Partiellement payé') ";

                using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
                {
                    cmd.Parameters.AddWithValue("@idPatient", ID_PATIENT);

                    id_facture = Convert.ToInt32(cmd.ExecuteScalar());

                }

                // Facture
                MesClasses.ReceptionManager.MettreAJourPrestation(id_facture, "EEG", 1, montant, montant, con, tr);

                // Payement EEG
                
            }

        }
    }
}
