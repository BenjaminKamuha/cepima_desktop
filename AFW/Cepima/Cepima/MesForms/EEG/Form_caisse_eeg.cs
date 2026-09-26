using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Cepima.Data;

namespace Cepima.MesForms.EEG
{
    public partial class Form_caisse_eeg : Form
    {
        private string ID_PATIENT;
        private string ID_DEMANDE;
        private int ID_PRESTATION;
        private decimal PRIX_PRESTATION;

        public Form_caisse_eeg(string patient, string demande, int idPrestation)
        {
            InitializeComponent();

            ID_PATIENT = patient;
            ID_DEMANDE = demande;
            ID_PRESTATION = idPrestation;

            ChargerTarif();
        }

        private void ChargerTarif()
        {
            try
            {
                Database db = new Database();
                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"
                        SELECT prix
                        FROM tarif_prestation
                        WHERE id_prestation = @id_prestation
                          AND actif = 1
                          AND date_debut <= CURDATE()
                          AND (date_fin IS NULL OR date_fin >= CURDATE())
                        ORDER BY date_debut DESC, id_tarif DESC
                        LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_prestation", ID_PRESTATION);
                        object result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                        {
                            throw new Exception("Aucun tarif actif n'est défini pour cette prestation.");
                        }

                        PRIX_PRESTATION = Convert.ToDecimal(result);
                        tb_montant.Text = PRIX_PRESTATION.ToString("0.00");
                        tb_montant.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du tarif.\n\n" + ex.Message,
                    "Paiement EEG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                bt_confirmer.Enabled = false;
            }
        }

        private void bt_confirmer_Click(object sender, EventArgs e)
        {
            if (ID_PRESTATION <= 0)
            {
                MessageBox.Show("La prestation EEG est invalide.", "Paiement EEG",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Database db = new Database();

            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                using (MySqlTransaction tr = con.BeginTransaction())
                {
                    try
                    {
                        // 1. Facture unique du patient
                        int idFacture = MesClasses.ReceptionManager.CreerFactureSiInexistante(
                            ID_PATIENT, con, tr);

                        // 2. Vérifier si cette prestation existe déjà dans la facture
                        int idDetail = MesClasses.ReceptionManager.TrouverDetailPrestation(
                            idFacture, ID_PRESTATION, con, tr);

                        // 3. Ajouter la prestation seulement si nécessaire
                        if (idDetail == 0)
                        {
                            idDetail = MesClasses.ReceptionManager.AjouterPrestationFacture(
                                idFacture,
                                ID_PRESTATION,
                                1,
                                PRIX_PRESTATION,
                                con,
                                tr);
                        }

                        // 4. Paiement anticipé EEG.
                        // Le paiement est rattaché au détail EEG,
                        // mais ne clôture jamais la facture.
                        MesClasses.ReceptionManager.PayerEEG(
                            idFacture,
                            idDetail,
                            PRIX_PRESTATION,
                            dtp_date.Value.Date,
                            con,
                            tr);

                        // 5. La demande reste dans son flux normal.
                        string query = @"
                            UPDATE demande_service
                            SET statut = 'Demandée'
                            WHERE id_demande = @id_demande
                              AND id_patient = @id_patient";

                        using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
                        {
                            cmd.Parameters.AddWithValue("@id_demande", ID_DEMANDE);
                            cmd.Parameters.AddWithValue("@id_patient", ID_PATIENT);
                            cmd.ExecuteNonQuery();
                        }

                        MesClasses.ReceptionManager.AjouterLivreCaisse(PRIX_PRESTATION,0,"Caisse EEG","Paiement d'examen EEG");
                        tr.Commit();

                        MessageBox.Show(
                            "Paiement EEG enregistré avec succès.\n\n" +
                            "La facture reste ouverte pour les autres services.",
                            "Paiement EEG",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    catch (Exception ex)
                    {
                        try { tr.Rollback(); }
                        catch { }

                        MessageBox.Show(
                            "Erreur lors de l'enregistrement du paiement EEG :\n\n" + ex.Message,
                            "Paiement EEG",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
