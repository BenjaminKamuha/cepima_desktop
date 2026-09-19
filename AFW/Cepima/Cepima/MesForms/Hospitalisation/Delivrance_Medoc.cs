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
namespace Cepima.MesForms.Hospitalisation
{
    public partial class Delivrance_Medoc : Form
    {
        private string idPatient;
        private string idHospi;
        private List<MedicamentADeLivrer> medicamentsSelectionnes;
        private List<MedicamentControle> controlesMedicaments = new List<MedicamentControle>();

        public Delivrance_Medoc(string idPatient, string hospi, List<MedicamentADeLivrer> medicamentsSelectionnes)
        {
            InitializeComponent();
            this.idPatient = idPatient;
            this.idHospi = hospi;
            this.medicamentsSelectionnes = medicamentsSelectionnes;
        }

        private void Delivrance_Medoc_Load(object sender, EventArgs e)
        {
            ChargerInformationsPatient();
            AfficherMedicaments();
        }

        private void ChargerInformationsPatient()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string query = @"
                SELECT 
                    p.nom,
                    p.post_nom,
                    p.prenom,
                    s.nom AS nom_service
                FROM patients p
                LEFT JOIN demande_service d
                    ON d.id_patient = p.id_patient
                LEFT JOIN service s
                    ON s.id_service = d.id_service
                WHERE p.id_patient = @idPatient
                ORDER BY d.date_demande DESC
                LIMIT 1";

                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@idPatient", idPatient);

                    using (MySqlDataReader reader =
                        MesClasses.ManagerClasse.CRUD(
                            query,
                            MesClasses.ManagerClasse.request_params,
                            true))
                    {
                        if (reader.Read())
                        {
                            string nom = reader["nom"].ToString();
                            string postNom = reader["post_nom"].ToString();
                            string prenom = reader["prenom"].ToString();

                            lbl_patient.Text =
                                "Patient : " + nom + " " + postNom + " " + prenom;

                            string service = reader["nom_service"].ToString();

                            if (string.IsNullOrWhiteSpace(service))
                                service = "-";

                            lbl_service.Text = "Service : " + service;
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur lors du chargement des informations du patient : "
                        + ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void AfficherMedicaments()
        {
            flp_medicaments.Controls.Clear();

            foreach (MedicamentADeLivrer medicament in medicamentsSelectionnes)
            {
                AjouterPanelMedicament(medicament);
            }
        }

        private void AjouterPanelMedicament(MedicamentADeLivrer medicament)
        {
            Panel panel = new Panel();

            panel.Width = flp_medicaments.ClientSize.Width - 25;
            panel.Height = 150;

            panel.BackColor = Color.White;
            panel.Margin = new Padding(0, 0, 0, 10);

            // ==============================
            // NOM DU MÉDICAMENT
            // ==============================

            Label lblNom = new Label();

            lblNom.Text = medicament.Nom;
            lblNom.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            lblNom.ForeColor = Color.FromArgb(20, 35, 60);

            lblNom.Location = new Point(25, 20);
            lblNom.AutoSize = true;

            panel.Controls.Add(lblNom);


            // ==============================
            // DOSAGE + FORME
            // ==============================

            Label lblDetails = new Label();

            lblDetails.Text =
                medicament.Dosage + " - " + medicament.Forme;

            lblDetails.Font = new Font("Segoe UI", 10);
            lblDetails.ForeColor = Color.FromArgb(80, 95, 115);

            lblDetails.Location = new Point(25, 50);
            lblDetails.AutoSize = true;

            panel.Controls.Add(lblDetails);


            // ==============================
            // QUANTITÉ PRESCRITE
            // ==============================

            Label lblPrescrit = new Label();

            lblPrescrit.Text =
                "Prescrit : " + medicament.QuantitePrescrite;

            lblPrescrit.Font = new Font("Segoe UI", 10);
            lblPrescrit.Location = new Point(350, 20);
            lblPrescrit.AutoSize = true;

            panel.Controls.Add(lblPrescrit);


            // ==============================
            // DÉJÀ DÉLIVRÉ
            // ==============================

            Label lblDelivre = new Label();

            lblDelivre.Text =
                "Déjà délivré : " + medicament.QuantiteDelivree;

            lblDelivre.Font = new Font("Segoe UI", 10);
            lblDelivre.Location = new Point(350, 50);
            lblDelivre.AutoSize = true;

            panel.Controls.Add(lblDelivre);


            // ==============================
            // RESTE
            // ==============================

            Label lblReste = new Label();

            lblReste.Text =
                "Reste : " + medicament.QuantiteRestante;

            lblReste.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            lblReste.ForeColor = Color.Red;

            lblReste.Location = new Point(350, 80);
            lblReste.AutoSize = true;

            panel.Controls.Add(lblReste);


            // ==============================
            // NUMERIC UP DOWN
            // ==============================

            NumericUpDown nudQuantite = new NumericUpDown();

            nudQuantite.Minimum = 0;
            nudQuantite.Maximum = medicament.QuantiteRestante;

            nudQuantite.Value = medicament.QuantiteRestante;

            nudQuantite.Width = 100;
            nudQuantite.Height = 35;

            nudQuantite.Location = new Point(600, 50);
            // On associe le médicament au NumericUpDown
            nudQuantite.Tag = medicament;
            panel.Controls.Add(nudQuantite);


            // ==============================
            // STATUT
            // ==============================

            Label lblStatut = new Label();

            if (medicament.QuantiteRestante <= 0)
            {
                lblStatut.Text = "✓ Déjà entièrement délivré";
                lblStatut.ForeColor = Color.Green;

                nudQuantite.Value = 0;
                nudQuantite.Enabled = false;
            }
            else
            {
                lblStatut.Text = "Disponible à délivrer";
                lblStatut.ForeColor = Color.Green;
            }

            lblStatut.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            lblStatut.Location = new Point(600, 20);
            lblStatut.AutoSize = true;

            panel.Controls.Add(lblStatut);


            // ==============================
            // TAG DU PANEL
            // ==============================

            panel.Tag = medicament;

            flp_medicaments.Controls.Add(panel);
        }

        private void bt_valider_Click(object sender, EventArgs e)
        {
            try
            {
                // =========================================================
                // 1. RÉCUPÉRER LES MÉDICAMENTS ET LES QUANTITÉS
                // =========================================================

                List<MedicamentADeLivrer> medicamentsADelivrer =
                    new List<MedicamentADeLivrer>();

                foreach (Control control in flp_medicaments.Controls)
                {
                    if (!(control is Panel))
                        continue;

                    Panel panel = (Panel)control;

                    MedicamentADeLivrer medicament =
                        panel.Tag as MedicamentADeLivrer;

                    if (medicament == null)
                        continue;

                    // Rechercher le NumericUpDown du panel
                    NumericUpDown nud = null;

                    foreach (Control c in panel.Controls)
                    {
                        if (c is NumericUpDown)
                        {
                            nud = (NumericUpDown)c;
                            break;
                        }
                    }

                    if (nud == null)
                        continue;

                    int quantite = Convert.ToInt32(nud.Value);

                    // Rien à délivrer pour ce médicament
                    if (quantite <= 0)
                        continue;

                    // =====================================================
                    // 2. VÉRIFIER LA QUANTITÉ RESTANTE DE LA PRESCRIPTION
                    // =====================================================

                    if (quantite > medicament.QuantiteRestante)
                    {
                        MessageBox.Show(
                            "La quantité demandée pour " +
                            medicament.Nom +
                            " dépasse la quantité restante de la prescription.",
                            "Quantité invalide",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    medicamentsADelivrer.Add(medicament);
                }


                // =========================================================
                // 3. VÉRIFIER QU'IL Y A AU MOINS UN MÉDICAMENT
                // =========================================================

                if (medicamentsADelivrer.Count == 0)
                {
                    MessageBox.Show(
                        "Veuillez saisir une quantité à délivrer pour au moins un médicament.",
                        "Délivrance",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }


                // =========================================================
                // 4. CONFIRMATION
                // =========================================================

                DialogResult confirmation = MessageBox.Show(
                    "Voulez-vous réellement valider cette délivrance ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmation != DialogResult.Yes)
                    return;


                // =========================================================
                // 5. OUVRIR LA CONNEXION
                // =========================================================

                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                {
                    if (connexion.State != ConnectionState.Open)
                        connexion.Open();

                    MySqlTransaction transaction = connexion.BeginTransaction();

                    try
                    {
                        // =====================================================
                        // 6. RÉCUPÉRER LE SERVICE DE L'HOSPITALISATION
                        // =====================================================

                        int idService;

                        using (MySqlCommand cmdService = new MySqlCommand(
                            @"SELECT id_service
                      FROM hospitalisation
                      WHERE id_hospitalisation = @idHospitalisation
                      LIMIT 1",
                            connexion,
                            transaction))
                        {
                            cmdService.Parameters.AddWithValue(
                                "@idHospitalisation",
                                this.idHospi);

                            object resultat = cmdService.ExecuteScalar();

                            if (resultat == null)
                            {
                                throw new Exception(
                                    "Impossible de retrouver le service de cette hospitalisation.");
                            }

                            idService = Convert.ToInt32(resultat);
                        }


                        // =====================================================
                        // 7. CRÉER LA SORTIE
                        // =====================================================

                        int idSortie;

                        using (MySqlCommand cmdSortie = new MySqlCommand(
                            @"INSERT INTO sortie_s_pa
                      (
                          id_hospitalisation,
                          id_service,
                          date_sortie
                      )
                      VALUES
                      (
                          @idHospitalisation,
                          @idService,
                          NOW()
                      )",
                            connexion,
                            transaction))
                        {
                            cmdSortie.Parameters.AddWithValue(
                                "@idHospitalisation",
                                this.idHospi);

                            cmdSortie.Parameters.AddWithValue(
                                "@idService",
                                idService);

                            cmdSortie.ExecuteNonQuery();

                            idSortie = Convert.ToInt32(cmdSortie.LastInsertedId);
                        }


                        // =====================================================
                        // 8. TRAITER CHAQUE MÉDICAMENT
                        // =====================================================

                        foreach (MedicamentADeLivrer medicament in medicamentsADelivrer)
                        {
                            int quantiteDemandee = 0;

                            // -------------------------------------------------
                            // Récupérer à nouveau le NumericUpDown
                            // -------------------------------------------------

                            foreach (Control control in flp_medicaments.Controls)
                            {
                                if (!(control is Panel))
                                    continue;

                                Panel panel = (Panel)control;

                                MedicamentADeLivrer medPanel =
                                    panel.Tag as MedicamentADeLivrer;

                                if (medPanel == null)
                                    continue;

                                if (medPanel.IdMedicament != medicament.IdMedicament)
                                    continue;

                                foreach (Control c in panel.Controls)
                                {
                                    if (c is NumericUpDown)
                                    {
                                        NumericUpDown nud =
                                            (NumericUpDown)c;

                                        quantiteDemandee =
                                            Convert.ToInt32(nud.Value);

                                        break;
                                    }
                                }

                                break;
                            }


                            if (quantiteDemandee <= 0)
                                continue;


                            // =================================================
                            // 9. VÉRIFIER LE STOCK
                            // =================================================

                            int stockDisponible;

                            using (MySqlCommand cmdStock = new MySqlCommand(
                                @"SELECT quantite
                          FROM stock_pharmacie
                          WHERE id_medicament = @idMedicament
                          FOR UPDATE",
                                connexion,
                                transaction))
                            {
                                cmdStock.Parameters.AddWithValue(
                                    "@idMedicament",
                                    medicament.IdMedicament);

                                object resultatStock =
                                    cmdStock.ExecuteScalar();

                                if (resultatStock == null)
                                {
                                    throw new Exception(
                                        "Le médicament " +
                                        medicament.Nom +
                                        " n'existe pas dans le stock de la pharmacie.");
                                }

                                stockDisponible =
                                    Convert.ToInt32(resultatStock);
                            }


                            // =================================================
                            // 10. COMPARER AVEC LE STOCK
                            // =================================================

                            if (stockDisponible < quantiteDemandee)
                            {
                                throw new Exception(
                                    "Stock insuffisant pour le médicament : " +
                                    medicament.Nom +
                                    "\n\n" +
                                    "Stock disponible : " +
                                    stockDisponible +
                                    "\n" +
                                    "Quantité demandée : " +
                                    quantiteDemandee);
                            }


                            // =================================================
                            // 11. ENREGISTRER LE DÉTAIL DE LA SORTIE
                            // =================================================

                            using (MySqlCommand cmdDetail = new MySqlCommand(
                                @"INSERT INTO detail_sortie_s_pa
                          (
                              id_sortie,
                              id_medicament,
                              quantite,
                              prix_unitaire
                          )
                          SELECT
                              @idSortie,
                              @idMedicament,
                              @quantite,
                              prix_vente
                          FROM medicament
                          WHERE id = @idMedicament",
                                connexion,
                                transaction))
                            {
                                cmdDetail.Parameters.AddWithValue(
                                    "@idSortie",
                                    idSortie);

                                cmdDetail.Parameters.AddWithValue(
                                    "@idMedicament",
                                    medicament.IdMedicament);

                                cmdDetail.Parameters.AddWithValue(
                                    "@quantite",
                                    quantiteDemandee);

                                cmdDetail.ExecuteNonQuery();
                            }


                            // =================================================
                            // 12. DIMINUER LE STOCK
                            // =================================================

                            using (MySqlCommand cmdUpdateStock = new MySqlCommand(
                                @"UPDATE stock_pharmacie
                          SET quantite = quantite - @quantite
                          WHERE id_medicament = @idMedicament",
                                connexion,
                                transaction))
                            {
                                cmdUpdateStock.Parameters.AddWithValue(
                                    "@quantite",
                                    quantiteDemandee);

                                cmdUpdateStock.Parameters.AddWithValue(
                                    "@idMedicament",
                                    medicament.IdMedicament);

                                cmdUpdateStock.ExecuteNonQuery();
                            }


                            // =================================================
                            // 13. METTRE À JOUR LA PRESCRIPTION
                            // =================================================

                            int nouvelleQuantiteDelivree =
                                medicament.QuantiteDelivree +
                                quantiteDemandee;

                            string nouveauStatut;

                            if (nouvelleQuantiteDelivree >=
                                medicament.QuantitePrescrite)
                            {
                                nouveauStatut = "Livrée";
                            }
                            else
                            {
                                nouveauStatut = "Non livrée";
                            }


                            using (MySqlCommand cmdPrescription =
                                new MySqlCommand(
                                    @"UPDATE prescriptions
                              SET statut = @statut
                              WHERE id_prescription = @idPrescription",
                                    connexion,
                                    transaction))
                            {
                                cmdPrescription.Parameters.AddWithValue(
                                    "@statut",
                                    nouveauStatut);

                                cmdPrescription.Parameters.AddWithValue(
                                    "@idPrescription",
                                    medicament.IdPrescription);

                                cmdPrescription.ExecuteNonQuery();
                            }
                        }


                        // =====================================================
                        // 14. TOUT S'EST BIEN PASSÉ
                        // =====================================================

                        transaction.Commit();


                        MessageBox.Show(
                            "La délivrance des médicaments a été enregistrée avec succès.",
                            "Délivrance réussie",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);


                        // Fermer le formulaire
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch
                    {
                        // =====================================================
                        // ANNULER TOUTES LES OPÉRATIONS
                        // =====================================================

                        transaction.Rollback();

                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "La délivrance n'a pas pu être enregistrée.\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            DialogResult resultat = MessageBox.Show(
        "Voulez-vous annuler cette délivrance ?",
        "Annuler la délivrance",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (resultat == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }

    public class MedicamentADeLivrer
    {
        public int IdPrescription { get; set; }
        public int IdMedicament { get; set; }

        public string Nom { get; set; }
        public string Dosage { get; set; }
        public string Forme { get; set; }

        public string Dose { get; set; }
        public string Frequence { get; set; }
        public string Duree { get; set; }

        public int QuantitePrescrite { get; set; }
        public int QuantiteDelivree { get; set; }

        public int QuantiteRestante
        {
            get
            {
                return QuantitePrescrite - QuantiteDelivree;
            }
        }
    }

    public class MedicamentControle
    {
        public MedicamentADeLivrer Medicament { get; set; }
        public NumericUpDown Quantite { get; set; }
    }
}
