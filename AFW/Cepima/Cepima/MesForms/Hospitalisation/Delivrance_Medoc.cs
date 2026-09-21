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
        private int idPrescription;

        private List<MedicamentADeLivrer>
            medicamentsSelectionnes;
        private List<MedicamentControle> controlesMedicaments = new List<MedicamentControle>();

        public Delivrance_Medoc(string idPatient,  int idPrescription, List<MedicamentADeLivrer> medicamentsSelectionnes)
        {
            InitializeComponent();
            this.idPatient = idPatient;
            this.idPrescription = idPrescription;
            this.medicamentsSelectionnes = medicamentsSelectionnes;
        }

        private void Delivrance_Medoc_Load(object sender, EventArgs e)
        {
            ChargerInformationsPatient();
            AfficherMedicaments();
        }

        private void ChargerInformationsPatient()
{
    using (MySqlConnection con =
        MesClasses.ManagerClasse.GetConnexion())
    {
        try
        {
            if (con.State != ConnectionState.Open)
                con.Open();

            string query = @"
                SELECT
                    nom,
                    post_nom,
                    prenom
                FROM patients
                WHERE id_patient = @idPatient
                LIMIT 1";

            using (MySqlCommand cmd =
                new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue(
                    "@idPatient",
                    idPatient);

                using (MySqlDataReader reader =
                    cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string nom =
                            reader["nom"].ToString();

                        string postNom =
                            reader["post_nom"].ToString();

                        string prenom =
                            reader["prenom"].ToString();

                        lbl_patient.Text =
                            "Patient : " +
                            nom + " " +
                            postNom + " " +
                            prenom;

                        lbl_service.Text =
                            "Prescription : #" +
                            idPrescription;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Erreur lors du chargement du patient :\n\n" +
                ex.Message,
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
            CustomRoundedPanel panel = new CustomRoundedPanel();
            // ==========================================
            // DIMENSION DU PANEL
            // ==========================================

            panel.Size = new Size(500, 110);

            panel.BackColor = Color.White;

            panel.Margin = new Padding(10);

            // Bordure visible
            panel.BorderRadius = 8;
            panel.BorderSize = 1;
            panel.BorderColor = Color.Gray;


            // ==========================================
            // NOM DU MÉDICAMENT
            // ==========================================

            Label lblNom = new Label();

            lblNom.Text = medicament.Nom;

            lblNom.Font =
                new Font("Segoe UI", 13, FontStyle.Bold);

            lblNom.ForeColor =
                Color.FromArgb(20, 35, 60);

            lblNom.Location = new Point(15, 8);

            lblNom.AutoSize = true;

            panel.Controls.Add(lblNom);


            // ==========================================
            // DOSAGE + FORME
            // ==========================================

            Label lblDetails = new Label();

            lblDetails.Text =
                medicament.Dosage +
                " - " +
                medicament.Forme;

            lblDetails.Font =
                new Font("Segoe UI", 10);

            lblDetails.ForeColor =
                Color.FromArgb(80, 95, 115);

            lblDetails.Location = new Point(15, 32);

            lblDetails.AutoSize = true;

            panel.Controls.Add(lblDetails);


            // ==========================================
            // QUANTITÉ PRESCRITE
            // ==========================================

            Label lblPrescrit = new Label();

            lblPrescrit.Text =
                "Prescrit : " +
                medicament.QuantitePrescrite;

            lblPrescrit.Font =
                new Font("Segoe UI", 10);

            lblPrescrit.Location = new Point(15, 58);

            lblPrescrit.AutoSize = true;

            panel.Controls.Add(lblPrescrit);


            // ==========================================
            // DÉJÀ DÉLIVRÉ
            // ==========================================

            Label lblDelivre = new Label();

            lblDelivre.Text =
                "Déjà délivré : " +
                medicament.QuantiteDelivree;

            lblDelivre.Font =
                new Font("Segoe UI", 10);

            lblDelivre.Location = new Point(15, 82);

            lblDelivre.AutoSize = true;

            panel.Controls.Add(lblDelivre);


            // ==========================================
            // RESTE
            // ==========================================

            Label lblReste = new Label();

            lblReste.Text =
                "Reste : " +
                medicament.QuantiteRestante;

            lblReste.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            lblReste.ForeColor =
                Color.Red;

            lblReste.Location = new Point(180, 58);

            lblReste.AutoSize = true;

            panel.Controls.Add(lblReste);


            // ==========================================
            // NUMERIC UP DOWN
            // ==========================================

            RoundedNumericUpDown nudQuantite = new RoundedNumericUpDown();
            nudQuantite.Size = new System.Drawing.Size(170, 32);
            nudQuantite.Location = new Point(320, 55);
            nudQuantite.BorderColor = Color.Gray;
            nudQuantite.FocusBorderColor = Color.Gray;
            nudQuantite.Minimum = 0;
            nudQuantite.Maximum = medicament.QuantiteRestante;
            nudQuantite.Value = medicament.QuantiteRestante;
           

            // Associer le médicament
            nudQuantite.Tag = medicament;

            panel.Controls.Add(nudQuantite);


            // ==========================================
            // STATUT
            // ==========================================

            Label lblStatut = new Label();

            if (medicament.QuantiteRestante <= 0)
            {
                lblStatut.Text =
                    "✓ Déjà entièrement délivré";

                lblStatut.ForeColor =
                    Color.Green;

                nudQuantite.Value = 0;

                nudQuantite.Enabled = false;
            }
            else
            {
                lblStatut.Text =
                    "Disponible à délivrer";

                lblStatut.ForeColor =
                    Color.Green;
            }

            lblStatut.Font =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold);
            lblStatut.Location = new Point(180, 85);

            lblStatut.AutoSize = true;

            panel.Controls.Add(lblStatut);


            // ==========================================
            // TAG DU PANEL
            // ==========================================

            panel.Tag = medicament;


            // ==========================================
            // AJOUT AU FLOWLAYOUTPANEL
            // ==========================================

            flp_medicaments.Controls.Add(panel);
        }

        private void bt_valider_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connexion =
                    MesClasses.ManagerClasse.GetConnexion())
                {


                    // ============================================================
                    // 1. RÉCUPÉRER LES MÉDICAMENTS À DÉLIVRER
                    // ============================================================

                    List<MedicamentADeLivrer> medicamentsADelivrer =
                        new List<MedicamentADeLivrer>();

                    Dictionary<int, int> quantitesADelivrer =
                        new Dictionary<int, int>();

                    foreach (Control control in flp_medicaments.Controls)
                    {
                        CustomRoundedPanel panel =
                            control as CustomRoundedPanel;

                        if (panel == null)
                            continue;

                        MedicamentADeLivrer medicament =
                            panel.Tag as MedicamentADeLivrer;

                        if (medicament == null)
                            continue;

                        RoundedNumericUpDown nud = null;

                        foreach (Control c in panel.Controls)
                        {
                            RoundedNumericUpDown controle =
                                c as RoundedNumericUpDown;

                            if (controle != null)
                            {
                                nud = controle;
                                break;
                            }
                        }

                        if (nud == null)
                            continue;

                        int quantite =
                            Convert.ToInt32(nud.Value);

                        if (quantite <= 0)
                            continue;

                        if (quantite > medicament.QuantiteRestante)
                        {
                            MessageBox.Show(
                                "La quantité délivrée pour " +
                                medicament.Nom +
                                " ne peut pas dépasser " +
                                medicament.QuantiteRestante + ".",
                                "Quantité incorrecte",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }

                        medicamentsADelivrer.Add(medicament);

                        quantitesADelivrer[
                            medicament.IdMedicament] = quantite;
                    }


                    // ============================================================
                    // 2. VÉRIFIER QU'IL Y A AU MOINS UN MÉDICAMENT
                    // ============================================================

                    if (medicamentsADelivrer.Count == 0)
                    {
                        MessageBox.Show(
                            "Veuillez saisir une quantité à délivrer.",
                            "Délivrance",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        return;
                    }


                    // ============================================================
                    // 3. VÉRIFIER LE STOCK
                    // ============================================================

                    foreach (MedicamentADeLivrer medicament
                        in medicamentsADelivrer)
                    {
                        int quantiteDemandee =
                            quantitesADelivrer[
                                medicament.IdMedicament];

                        string queryStock = @"
                    SELECT quantite
                    FROM stock_pharmacie
                    WHERE id_medicament = @id_medicament
                    LIMIT 1";

                        using (MySqlCommand cmdStock =
                            new MySqlCommand(
                                queryStock,
                                connexion))
                        {
                            cmdStock.Parameters.AddWithValue(
                                "@id_medicament",
                                medicament.IdMedicament);

                            object resultat =
                                cmdStock.ExecuteScalar();

                            if (resultat == null ||
                                resultat == DBNull.Value)
                            {
                                MessageBox.Show(
                                    "Le médicament " +
                                    medicament.Nom +
                                    " n'existe pas dans le stock.",
                                    "Stock insuffisant",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                return;
                            }

                            int stockDisponible =
                                Convert.ToInt32(resultat);

                            if (stockDisponible < quantiteDemandee)
                            {
                                MessageBox.Show(
                                    "Stock insuffisant pour : " +
                                    medicament.Nom +
                                    "\n\n" +
                                    "Demandé : " +
                                    quantiteDemandee +
                                    "\n" +
                                    "Disponible : " +
                                    stockDisponible,
                                    "Stock insuffisant",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                return;
                            }
                        }
                    }


                    // ============================================================
                    // 4. CRÉER LA DISPENSATION
                    // ============================================================

                    string queryDispensation = @"
                INSERT INTO dispensation
                (
                    prescription_id,
                    patient_id,
                    type,
                    date_dispensation,
                    agent_id,
                    observation
                )
                VALUES
                (
                    @prescription_id,
                    @patient_id,
                    @type,
                    NOW(),
                    NULL,
                    @observation
                )";

                    int idDispensation;

                    using (MySqlCommand cmd =
                        new MySqlCommand(
                            queryDispensation,
                            connexion))
                    {
                        cmd.Parameters.AddWithValue(
                            "@prescription_id",
                            idPrescription);

                        cmd.Parameters.AddWithValue(
                            "@patient_id",
                            Convert.ToInt32(idPatient));

                        cmd.Parameters.AddWithValue(
                            "@type",
                            "PHARMACIE");

                        cmd.Parameters.AddWithValue(
                            "@observation",
                            "");

                        cmd.ExecuteNonQuery();
                    }


                    // ============================================================
                    // 5. RÉCUPÉRER L'ID DE LA DISPENSATION
                    // ============================================================

                    using (MySqlCommand cmd =
                        new MySqlCommand(
                            "SELECT LAST_INSERT_ID();",
                            connexion))
                    {
                        idDispensation =
                            Convert.ToInt32(cmd.ExecuteScalar());
                    }


                    // ============================================================
                    // 6. TRAITER CHAQUE MÉDICAMENT
                    // ============================================================

                    foreach (MedicamentADeLivrer medicament
                        in medicamentsADelivrer)
                    {
                        int quantiteRestante =
                            quantitesADelivrer[
                                medicament.IdMedicament];


                        // ========================================================
                        // 6.1 RÉCUPÉRER LES LOTS
                        // ========================================================

                        string queryLots = @"
                    SELECT
                        id,
                        quantite,
                        date_expiration
                    FROM lot_medicament
                    WHERE medicament_id = @id_medicament
                      AND quantite > 0
                      AND date_expiration >= CURDATE()
                    ORDER BY date_expiration ASC";

                        List<int> idsLots =
                            new List<int>();

                        List<int> quantitesLots =
                            new List<int>();

                        using (MySqlCommand cmdLots =
                            new MySqlCommand(
                                queryLots,
                                connexion))
                        {
                            cmdLots.Parameters.AddWithValue(
                                "@id_medicament",
                                medicament.IdMedicament);

                            using (MySqlDataReader reader =
                                cmdLots.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    idsLots.Add(
                                        Convert.ToInt32(
                                            reader["id"]));

                                    quantitesLots.Add(
                                        Convert.ToInt32(
                                            reader["quantite"]));
                                }
                            }
                        }


                        // ========================================================
                        // 6.2 VÉRIFIER LA QUANTITÉ DES LOTS
                        // ========================================================

                        int totalLots = 0;

                        foreach (int qteLot in quantitesLots)
                        {
                            totalLots += qteLot;
                        }
    

                        if (totalLots < quantiteRestante)
                        {
                            MessageBox.Show(
                                "Les lots disponibles ne permettent pas " +
                                "de délivrer " +
                                quantiteRestante +
                                " unité(s) de " +
                                medicament.Nom +
                                ".",
                                "Lots insuffisants",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }


                        // ========================================================
                        // 6.3 RÉPARTIR LA QUANTITÉ SUR LES LOTS
                        // ========================================================

                        for (int i = 0;
                             i < idsLots.Count &&
                             quantiteRestante > 0;
                             i++)
                        {
                            int idLot =
                                idsLots[i];

                            int quantiteLot =
                                quantitesLots[i];

                            int quantiteAUtiliser =
                                Math.Min(
                                    quantiteRestante,
                                    quantiteLot);


                            // ====================================================
                            // INSERTION DANS dispensation_ligne
                            // ====================================================

                            string queryLigne = @"
                        INSERT INTO dispensation_ligne
                        (
                            dispensation_id,
                            medicament_id,
                            lot_id,
                            quantite
                        )
                        VALUES
                        (
                            @dispensation_id,
                            @medicament_id,
                            @lot_id,
                            @quantite
                        )";

                            using (MySqlCommand cmdLigne =
                                new MySqlCommand(
                                    queryLigne,
                                    connexion))
                            {
                                cmdLigne.Parameters.AddWithValue(
                                    "@dispensation_id",
                                    idDispensation);

                                cmdLigne.Parameters.AddWithValue(
                                    "@medicament_id",
                                    medicament.IdMedicament);

                                cmdLigne.Parameters.AddWithValue(
                                    "@lot_id",
                                    idLot);

                                cmdLigne.Parameters.AddWithValue(
                                    "@quantite",
                                    quantiteAUtiliser);

                                cmdLigne.ExecuteNonQuery();
                            }


                            // ====================================================
                            // DIMINUER LE LOT
                            // ====================================================

                            string queryUpdateLot = @"
                        UPDATE lot_medicament
                        SET quantite = quantite - @quantite
                        WHERE id = @id_lot";

                            using (MySqlCommand cmdUpdateLot =
                                new MySqlCommand(
                                    queryUpdateLot,
                                    connexion))
                            {
                                cmdUpdateLot.Parameters.AddWithValue(
                                    "@quantite",
                                    quantiteAUtiliser);

                                cmdUpdateLot.Parameters.AddWithValue(
                                    "@id_lot",
                                    idLot);

                                cmdUpdateLot.ExecuteNonQuery();
                            }


                            quantiteRestante -=
                                quantiteAUtiliser;
                        }


                        // ========================================================
                        // 6.4 DIMINUER LE STOCK PHARMACIE
                        // ========================================================

                        int quantiteDelivree =
                            quantitesADelivrer[
                                medicament.IdMedicament];

                        string queryUpdateStock = @"
                    UPDATE stock_pharmacie
                    SET quantite = quantite - @quantite
                    WHERE id_medicament = @id_medicament";

                        using (MySqlCommand cmdStock =
                            new MySqlCommand(
                                queryUpdateStock,
                                connexion))
                        {
                            cmdStock.Parameters.AddWithValue(
                                "@quantite",
                                quantiteDelivree);

                            cmdStock.Parameters.AddWithValue(
                                "@id_medicament",
                                medicament.IdMedicament);

                            cmdStock.ExecuteNonQuery();
                        }
                    }


                    // ============================================================
                    // 7. CALCULER LE STATUT DE LA PRESCRIPTION
                    // ============================================================

                    string queryStatut = @"
                SELECT
                    SUM(pl.quantite_prescrite)
                    AS total_prescrit,

                    COALESCE(
                        (
                            SELECT SUM(dl.quantite)
                            FROM dispensation_ligne dl
                            INNER JOIN dispensation d
                                ON d.id = dl.dispensation_id
                            WHERE d.prescription_id =
                                  pl.prescription_id
                              AND dl.medicament_id =
                                  pl.medicament_id
                        ),
                        0
                    ) AS total_delivre

                FROM prescription_ligne pl

                WHERE pl.prescription_id =
                      @idPrescription

                GROUP BY pl.prescription_id";

                    int totalPrescrit = 0;
                    int totalDelivre = 0;

                    using (MySqlCommand cmdStatut =
                        new MySqlCommand(
                            queryStatut,
                            connexion))
                    {
                        cmdStatut.Parameters.AddWithValue(
                            "@idPrescription",
                            idPrescription);

                        using (MySqlDataReader reader =
                            cmdStatut.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                totalPrescrit =
                                    Convert.ToInt32(
                                        reader["total_prescrit"]);

                                totalDelivre =
                                    Convert.ToInt32(
                                        reader["total_delivre"]);
                            }
                        }
                    }


                    // ============================================================
                    // 8. DÉTERMINER LE NOUVEAU STATUT
                    // ============================================================

                    string nouveauStatut;

                    if (totalDelivre >= totalPrescrit)
                    {
                        nouveauStatut = "LIVREE";
                    }
                    else if (totalDelivre > 0)
                    {
                        nouveauStatut = "PARTIELLE";
                    }
                    else
                    {
                        nouveauStatut = "ACTIVE";
                    }


                    // ============================================================
                    // 9. METTRE À JOUR LA PRESCRIPTION
                    // ============================================================

                    string queryUpdatePrescription = @"
                UPDATE prescription
                SET statut = @statut
                WHERE id = @idPrescription";

                    using (MySqlCommand cmdUpdate =
                        new MySqlCommand(
                            queryUpdatePrescription,
                            connexion))
                    {
                        cmdUpdate.Parameters.AddWithValue(
                            "@statut",
                            nouveauStatut);

                        cmdUpdate.Parameters.AddWithValue(
                            "@idPrescription",
                            idPrescription);

                        cmdUpdate.ExecuteNonQuery();
                    }


                    // ============================================================
                    // 10. TERMINER
                    // ============================================================

                    MessageBox.Show(
                        "La délivrance a été enregistrée avec succès.",
                        "Délivrance",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult =
                        DialogResult.OK;

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Une erreur est survenue lors de la délivrance :\n\n" +
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
    public class LotDisponible
{
    public int IdLot { get; set; }

    public int Quantite { get; set; }
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
