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
        string ID_DEMANDE;

        public Form_caisse_eeg(string patient, string demande)
        {
            InitializeComponent();

            ID_PATIENT = patient;
            ID_DEMANDE = demande;
        }

        private void bt_confirmer_Click(object sender, EventArgs e)
        {

            Database db = new Database();

            decimal montant = Convert.ToDecimal(tb_montant.Text);
            int id_facture = 0;

            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();

                MySqlTransaction tr = con.BeginTransaction();
                try
                {

                    // Création de la facture
                    id_facture = MesClasses.ReceptionManager.CreerFactureSiInexistante(ID_PATIENT, con, tr);

                    // Facture
                    MesClasses.ReceptionManager.MettreAJourPrestation(id_facture, "EEG", 1, montant, montant, con, tr);

                    // Payement EEG
                    MesClasses.ReceptionManager.PayementFacture(id_facture, dtp_date.Value.Date, montant, con, tr);

                    // Changer statut demande
                    string query_update_demande = "UPDATE demande_service SET statut='Demandée' WHERE id_demande=@id_demande AND id_patient=@id_patient";

                    using (MySqlCommand cmd = new MySqlCommand(query_update_demande, con, tr))
                    {
                        cmd.Parameters.AddWithValue("@id_demande", ID_DEMANDE);
                        cmd.Parameters.AddWithValue("@id_patient", ID_PATIENT);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Payement enregistré avec succès");

                    }
                    tr.Commit();
                    this.Close();

                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Erreur");
                }

                
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
