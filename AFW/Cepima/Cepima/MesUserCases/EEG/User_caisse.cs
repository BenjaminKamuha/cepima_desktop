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
using Cepima.Data;
using Cepima.MesForms.EEG;

namespace Cepima.MesUserCases.EEG
{
    public partial class User_caisse : UserControl
    {
        public User_caisse()
        {
            InitializeComponent();

            //ChargerDemandesEEG();

            rd_EEG.Checked = true;
        }

        // ============================================================
        // CHARGER LES DEMANDES EEG
        // ============================================================
        private void ChargerPrescriptions()
        {
            try
            {
                // -------------------------------------------------
                // SUSPENDRE LE RAFRAICHISSEMENT VISUEL
                // -------------------------------------------------

                pnl_examen.SuspendLayout();

                pnl_examen.Controls.Clear();

                Database db = new Database();

                using (MySqlConnection con = db.GetConnection())
                {
                    // Conservation de con.Open()
                    con.Open();

                    // =================================================
                    // RECHERCHE
                    // =================================================

                    string recherche =
                        tb_search_demande.Text.Trim();

                    // =================================================
                    // FILTRE
                    // =================================================


                    // =================================================
                    // REQUETE OPTIMISEE
                    // =================================================
                    //
                    // AVANT :
                    // Plusieurs EXISTS sur hospitalisation
                    // pour une même prescription.
                    //
                    // MAINTENANT :
                    // Une seule jointure vers les patients
                    // actuellement hospitalisés.
                    //
                    // =================================================

                    string query = @"
                        SELECT
                            pr.id,
                            pr.patient_id,
                            pr.medecin_id,
                            pr.date_prescription,
                            pr.statut,
                            pr.observation,

                            p.nom,
                            p.post_nom,
                            p.prenom,
                            p.numero_fiche,

                            CASE
                                WHEN h.patient_id IS NOT NULL
                                THEN 'Hospitalisation'
                                ELSE 'Ambulatoire'
                            END AS type_patient

                        FROM prescription pr 

                        INNER JOIN patients p
                            ON p.id_patient = pr.patient_id

                        LEFT JOIN
                        (
                            SELECT DISTINCT
                                id_patient AS patient_id

                            FROM hospitalisation

                            WHERE etat IN
                            (
                                'En cours',
                                'Hospitalisé',
                                'Active'
                            )

                        ) h
                            ON h.patient_id =
                               pr.patient_id

                        WHERE

                            (
                                @recherche = ''

                                OR p.nom LIKE @recherche_like
                                OR p.post_nom LIKE @recherche_like
                                OR p.prenom LIKE @recherche_like
                                OR p.numero_fiche LIKE @recherche_like
                                OR pr.observation LIKE @recherche_like
                            )

                        AND pr.statut = 'INNACTIVE'

                       

                        ORDER BY
                            pr.date_prescription DESC";


                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        // =================================================
                        // PARAMETRES TYPÉS
                        // =================================================

                        cmd.Parameters.Add(
                            "@recherche",
                            MySqlDbType.VarChar)
                            .Value =
                                recherche;

                        cmd.Parameters.Add(
                            "@recherche_like",
                            MySqlDbType.VarChar)
                            .Value =
                                "%" + recherche + "%";



                        // =================================================
                        // LECTURE
                        // =================================================

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // ---------------------------------
                                // ID PRESCRIPTION
                                // ---------------------------------

                                string idPrescription =
                                    reader["id"].ToString();


                                // ---------------------------------
                                // ID PATIENT
                                // ---------------------------------

                                string idPatient =
                                    reader["patient_id"].ToString();


                                // ---------------------------------
                                // PATIENT
                                // ---------------------------------

                                string nom =
                                    GetString(
                                        reader,
                                        "nom");

                                string postnom =
                                    GetString(
                                        reader,
                                        "post_nom");

                                string prenom =
                                    GetString(
                                        reader,
                                        "prenom");


                                // ---------------------------------
                                // NUMERO FICHE
                                // ---------------------------------

                                string numero =
                                    GetString(
                                        reader,
                                        "numero_fiche");


                                // ---------------------------------
                                // DATE
                                // ---------------------------------

                                string datePrescription =
                                    GetDateString(
                                        reader,
                                        "date_prescription");


                                // ---------------------------------
                                // STATUT
                                // ---------------------------------

                                string statut =
                                    GetString(
                                        reader,
                                        "statut");


                                // ---------------------------------
                                // OBSERVATION
                                // ---------------------------------

                                string observation =
                                    GetString(
                                        reader,
                                        "observation");


                                // ---------------------------------
                                // TYPE
                                // ---------------------------------

                                string type =
                                    GetString(
                                        reader,
                                        "type_patient");

                                if (string.IsNullOrWhiteSpace(type))
                                {
                                    type =
                                        "Ambulatoire";
                                }


                                // ---------------------------------
                                // CREER LA CARTE
                                // ---------------------------------

                                Create_pan_prescription(
                                    idPrescription,
                                    idPatient,
                                    nom,
                                    postnom,
                                    prenom,
                                    numero,
                                    statut,
                                    datePrescription,
                                    type,
                                    observation);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des prescriptions.\n\n" +
                    ex.Message,
                    "Prescriptions",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                pnl_examen.ResumeLayout(true);
            }
        }

        private void Create_pan_prescription(string idPrescription, string idPatient, string nom, string postnom, string prenom, string numero, string statut, string datePrescription, string type, string observation)
        {
            // PANEL
            BunifuRoundedPanel panPrescription = new BunifuRoundedPanel();
            panPrescription.Size = new Size(290, 145);
            panPrescription.BorderRadius = 8;
            panPrescription.ShadowDepth = 10;
            panPrescription.BorderColor = Color.Silver;
            panPrescription.BorderSize = 1;
            panPrescription.Margin = new System.Windows.Forms.Padding(10);
            panPrescription.Tag = idPrescription;

            // COULEURS
            Color couleurNormale = Color.White;
            Color couleurHover = Color.FromArgb(245, 248, 255);
            panPrescription.BackColor = couleurNormale;

            // IMAGE PRESCRIPTION
            PictureBox picture = MesClasses.ManagerClasse.AddPicture(Properties.Resources.capsules_100px, new Point(10, 10), new Size(60, 60));
            picture.Cursor = Cursors.Hand;
            panPrescription.Controls.Add(picture);

            // CLICK
            EventHandler clickPrescription = delegate(object sender, EventArgs e)
            {
                try
                {
                    int prescriptionId = Convert.ToInt32(idPrescription);
                    int patientId = Convert.ToInt32(idPatient);
                    Form1.PATIENT_ID = patientId;

                    MesForms.Pharmacie.Form_prescription frm = new MesForms.Pharmacie.Form_prescription(prescriptionId);
                    frm.ShowDialog();

                    ChargerPrescriptions();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'ouverture de la prescription.\n\n" + ex.Message, "Prescription", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // CLICK SUR LE PANEL
            panPrescription.Click += clickPrescription;

            // NOM DU PATIENT
            string patient = (nom + " " + postnom + " " + prenom).Trim();
            Label lbPatient = MesClasses.ManagerClasse.CustomLabel(patient, new Point(75, 15));
            lbPatient.AutoSize = true;
            lbPatient.Font = new Font("Calibri", 10, FontStyle.Bold);
            lbPatient.Cursor = Cursors.Hand;
            panPrescription.Controls.Add(lbPatient);

            // NUMERO FICHE
            Label lbNumero = MesClasses.ManagerClasse.CustomLabel(numero, new Point(75, 40));
            lbNumero.AutoSize = true;
            lbNumero.Font = new Font("Calibri", 9, FontStyle.Regular);
            lbNumero.Cursor = Cursors.Hand;
            panPrescription.Controls.Add(lbNumero);

            // TYPE
            Label lbType = MesClasses.ManagerClasse.CustomLabel(type, new Point(75, 63));
            lbType.AutoSize = true;
            lbType.Font = new Font("Calibri", 9, FontStyle.Bold);
            lbType.Cursor = Cursors.Hand;
            lbType.ForeColor = type == "Hospitalisation" ? Color.Blue : Color.DarkGreen;
            panPrescription.Controls.Add(lbType);

            // STATUT
            Label lbStatut = MesClasses.ManagerClasse.CustomLabel(statut, new Point(75, 86));
            lbStatut.AutoSize = true;
            lbStatut.Font = new Font("Calibri", 9, FontStyle.Bold);
            lbStatut.Cursor = Cursors.Hand;

            if (string.Equals(statut, "ACTIVE", StringComparison.OrdinalIgnoreCase))
                lbStatut.ForeColor = Color.Orange;
            else if (string.Equals(statut, "DELIVREE", StringComparison.OrdinalIgnoreCase))
                lbStatut.ForeColor = Color.Green;
            else
                lbStatut.ForeColor = Color.Gray;

            panPrescription.Controls.Add(lbStatut);

            // DATE
            Label lbDate = MesClasses.ManagerClasse.CustomLabel(datePrescription, new Point(75, 109));
            lbDate.AutoSize = true;
            lbDate.Font = new Font("Calibri", 8, FontStyle.Regular);
            lbDate.ForeColor = Color.Gray;
            lbDate.Cursor = Cursors.Hand;
            panPrescription.Controls.Add(lbDate);

            // OBSERVATION
            if (!string.IsNullOrWhiteSpace(observation))
            {
                // Conservation du comportement original.
            }

            // CLICK SUR TOUS LES CONTROLES ENFANTS
            AjouterClickAuxEnfants(panPrescription, clickPrescription);

            // HOVER SUR TOUS LES CONTROLES ENFANTS
            AjouterHoverAuxEnfants(panPrescription, couleurHover, couleurNormale);

            // AJOUT AU FLOWLAYOUTPANEL
            pnl_examen.Controls.Add(panPrescription);
            //MesClasses.ManagerClasse.AddControl(pnl_examen, panPrescription, 20, 10);

            //if (pnl_examen.Controls.Count > 0)
            //{
            //    ProgressiveDisplay pd = new ProgressiveDisplay(pnl_examen, 100);
            //    pd.Start();
            //}
        }


        private string GetDateString(
            MySqlDataReader reader,
            string column)
        {
            if (reader[column] == DBNull.Value)
            {
                return "";
            }

            DateTime date =
                Convert.ToDateTime(
                    reader[column]);

            return date.ToString(
                "dd/MM/yyyy HH:mm");
        }

        private string GetString(
        MySqlDataReader reader,
        string column)
        {
            if (reader[column] == DBNull.Value)
            {
                return "";
            }

            return reader[column].ToString();
        }

        private void ChargerDemandesEEG()
        {
            try
            {
                // ----------------------------------------------------
                // SUSPENDRE LE LAYOUT PENDANT LE CHARGEMENT
                // ----------------------------------------------------

                pnl_examen.SuspendLayout();

                // ----------------------------------------------------
                // SUPPRIMER LES ANCIENS PANELS
                // ----------------------------------------------------

                pnl_examen.Controls.Clear();

                // ----------------------------------------------------
                // TEXTE DE RECHERCHE
                // ----------------------------------------------------

                string recherche =
                    tb_search_demande.Text.Trim();

                // ----------------------------------------------------
                // CONNEXION
                // ----------------------------------------------------

                Database db =
                    new Database();

                using (MySqlConnection con =
                    db.GetConnection())
                {
                    // IMPORTANT :
                    // GetConnection() retourne une connexion
                    // qui doit être ouverte explicitement.

                    con.Open();

                    // =================================================
                    // REQUETE
                    // =================================================
                    //
                    // DATE_FORMAT() est retiré.
                    // On récupère directement DATETIME et on effectue
                    // le formatage côté C#.
                    //
                    // Cela évite de faire effectuer le formatage
                    // à MySQL pour chaque ligne.
                    // =================================================

                    string query = @"
                        SELECT
                            ds.id_demande,
                            ds.id_patient,
                            ds.id_service,
                            ds.id_prestation,

                            p.nom,
                            p.post_nom,
                            p.prenom,
                            p.numero_fiche,

                            ds.date_demande,
                            ds.priorite,
                            ds.motif,
                            ds.statut

                        FROM demande_service ds

                        INNER JOIN patients p
                            ON p.id_patient =
                               ds.id_patient

                        INNER JOIN service s
                            ON s.id_service =
                               ds.id_service

                   

                            AND ds.statut = 'En attente'

                            AND
                            (
                                @recherche = ''
                                OR p.nom LIKE @recherche
                                OR p.post_nom LIKE @recherche
                                OR p.prenom LIKE @recherche
                                OR p.numero_fiche LIKE @recherche
                                OR ds.motif LIKE @recherche
                            )

                        ORDER BY
                            ds.date_demande DESC";

                    using (MySqlCommand cmd =
                        new MySqlCommand(
                            query,
                            con))
                    {
                        // ------------------------------------------------
                        // PARAMETRE RECHERCHE
                        // ------------------------------------------------

                        cmd.Parameters.Add(
                            "@recherche",
                            MySqlDbType.VarChar,
                            255).Value =
                            string.IsNullOrEmpty(recherche)
                                ? ""
                                : "%" + recherche + "%";

                        // ------------------------------------------------
                        // LECTURE
                        // ------------------------------------------------

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // ========================================
                                // ID DEMANDE
                                // ========================================

                                int idDemande =
                                    Convert.ToInt32(
                                        reader["id_demande"]);


                                // ========================================
                                // ID PATIENT
                                // ========================================

                                int idPatient =
                                    Convert.ToInt32(
                                        reader["id_patient"]);


                                // ========================================
                                // ID PRESTATION
                                // ========================================

                                int idPrestation = 0;

                                if (reader["id_prestation"] !=
                                    DBNull.Value)
                                {
                                    idPrestation =
                                        Convert.ToInt32(
                                            reader["id_prestation"]);
                                }


                                // ========================================
                                // NOM
                                // ========================================

                                string nom =
                                    reader["nom"] == DBNull.Value
                                        ? ""
                                        : reader["nom"].ToString();


                                // ========================================
                                // POST-NOM
                                // ========================================

                                string postnom =
                                    reader["post_nom"] == DBNull.Value
                                        ? ""
                                        : reader["post_nom"].ToString();


                                // ========================================
                                // PRENOM
                                // ========================================

                                string prenom =
                                    reader["prenom"] == DBNull.Value
                                        ? ""
                                        : reader["prenom"].ToString();


                                // ========================================
                                // NUMERO FICHE
                                // ========================================

                                string numero =
                                    reader["numero_fiche"] == DBNull.Value
                                        ? ""
                                        : reader["numero_fiche"].ToString();


                                // ========================================
                                // STATUT
                                // ========================================

                                string status =
                                    reader["statut"] == DBNull.Value
                                        ? ""
                                        : reader["statut"].ToString();


                                // ========================================
                                // DATE
                                // ========================================

                                string dateDemande = "";

                                if (reader["date_demande"] !=
                                    DBNull.Value)
                                {
                                    DateTime date =
                                        Convert.ToDateTime(
                                            reader["date_demande"]);

                                    dateDemande =
                                        date.ToString(
                                            "dd/MM/yyyy HH:mm");
                                }


                                // ========================================
                                // PRIORITE
                                // ========================================

                                string priorite =
                                    reader["priorite"] == DBNull.Value
                                        ? ""
                                        : reader["priorite"].ToString();


                                // ========================================
                                // MOTIF
                                // ========================================

                                string motif =
                                    reader["motif"] == DBNull.Value
                                        ? ""
                                        : reader["motif"].ToString();


                                // ========================================
                                // CREATION DU PANEL
                                // ========================================

                                Create_pan_examen(
                                    idDemande.ToString(),
                                    idPatient.ToString(),
                                    idPrestation,
                                    nom,
                                    postnom,
                                    prenom,
                                    numero,
                                    status,
                                    dateDemande,
                                    priorite,
                                    motif);
                            }
                        }
                    }
                }

                // =====================================================
                // ANIMATION
                // =====================================================

                if (pnl_examen.Controls.Count > 0)
                {
                    ProgressiveDisplay pd =
                        new ProgressiveDisplay(
                            pnl_examen,
                            100);

                    pd.Start();
                }

                // =====================================================
                // FIN DU LAYOUT
                // =====================================================

                pnl_examen.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                try
                {
                    pnl_examen.ResumeLayout(true);
                }
                catch
                {
                }

                MessageBox.Show(
                    "Erreur lors du chargement des demandes EEG.\n\n" +
                    ex.Message,
                    "Demandes EEG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ============================================================
        // CREER LE PANEL D'UNE DEMANDE
        // ============================================================

        private void Create_pan_examen(string idDemande, string idPatient, int idPrestation, string nom, string postnom, string prenom, string numero, string status, string dateDemande, string priorite, string motif)
        {
            // CREATION DU PANEL
            BunifuRoundedPanel panDemande = new BunifuRoundedPanel();
            panDemande.Size = new Size(290, 145);
            panDemande.BorderRadius = 8;
            panDemande.BorderColor = Color.Silver;
            panDemande.BorderSize = 1;
            panDemande.Margin = new System.Windows.Forms.Padding(10);
            panDemande.Tag = idDemande;

            // HOVER
            Color couleurNormale = Color.White;
            Color couleurHover = Color.FromArgb(245, 248, 255);
            panDemande.BackColor = couleurNormale;

            // AJOUT AU PANEL PRINCIPAL

            // EVENEMENT CLICK
            EventHandler clickDemande = delegate(object sender, EventArgs e)
            {
                try
                {
                    Form1.PATIENT_ID = Convert.ToInt32(idPatient);
                    Form1.DEMANDE_ID = Convert.ToInt32(idDemande);

                    Form_caisse_eeg form = new Form_caisse_eeg(idPatient, idDemande, idPrestation);
                    form.ShowDialog();

                    ChargerDemandesEEG();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'ouverture de la demande EEG.\n\n" + ex.Message, "Demande EEG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // CLICK SUR LE PANEL
            panDemande.Click += clickDemande;

            // IMAGE EEG
            PictureBox picture = MesClasses.ManagerClasse.AddPicture(Properties.Resources.brain_90px, new Point(10, 10), new Size(60, 60));
            picture.Cursor = Cursors.Hand;
            panDemande.Controls.Add(picture);

            // NOM
            Label lbNom = MesClasses.ManagerClasse.CustomLabel(nom, new Point(75, 15));
            lbNom.AutoSize = true;
            lbNom.Font = new Font("Calibri", 10, FontStyle.Bold);
            lbNom.Cursor = Cursors.Hand;
            panDemande.Controls.Add(lbNom);

            // POST-NOM
            Label lbPost = MesClasses.ManagerClasse.CustomLabel(postnom, new Point(75, 35));
            lbPost.AutoSize = true;
            lbPost.Font = new Font("Calibri", 10, FontStyle.Bold);
            lbPost.Cursor = Cursors.Hand;
            panDemande.Controls.Add(lbPost);

            // NUMERO FICHE
            Label lbNumero = MesClasses.ManagerClasse.CustomLabel(numero, new Point(10, 67));
            lbNumero.AutoSize = true;
            lbNumero.Font = new Font("Calibri", 9, FontStyle.Regular);
            lbNumero.Cursor = Cursors.Hand;
            panDemande.Controls.Add(lbNumero);

            // STATUT
            Label lbStatus = MesClasses.ManagerClasse.CustomLabel(status, new Point(10, 88));
            lbStatus.AutoSize = true;
            lbStatus.Font = new Font("Calibri", 9, FontStyle.Bold);
            lbStatus.Cursor = Cursors.Hand;

            if (status == "Terminée")
                lbStatus.ForeColor = Color.Green;
            else if (status == "Demandée")
                lbStatus.ForeColor = Color.Orange;
            else if (status == "Annulée")
                lbStatus.ForeColor = Color.Red;

            panDemande.Controls.Add(lbStatus);

            // DATE
            Label lbDate = MesClasses.ManagerClasse.CustomLabel(dateDemande, new Point(10, 110));
            lbDate.AutoSize = true;
            lbDate.Font = new Font("Calibri", 8, FontStyle.Regular);
            lbDate.ForeColor = Color.Gray;
            lbDate.Cursor = Cursors.Hand;
            panDemande.Controls.Add(lbDate);

            // CLICK SUR TOUS LES CONTROLES ENFANTS
            AjouterClickAuxEnfants(panDemande, clickDemande);

            // HOVER SUR TOUS LES CONTROLES ENFANTS
            AjouterHoverAuxEnfants(panDemande, couleurHover, couleurNormale);
            pnl_examen.Controls.Add(panDemande);
        }


        // ============================================================
        // HOVER DES CONTROLES ENFANTS
        // ============================================================

        private void AjouterHoverAuxEnfants(
            Control parent,
            Color couleurHover,
            Color couleurNormale)
        {
            foreach (Control control in
                parent.Controls)
            {
                // -----------------------------------------------------
                // MOUSE ENTER
                // -----------------------------------------------------

                control.MouseEnter +=
                    delegate(object sender, EventArgs e)
                    {
                        parent.BackColor =
                            couleurHover;
                    };

                // -----------------------------------------------------
                // MOUSE LEAVE
                // -----------------------------------------------------

                control.MouseLeave +=
                    delegate(object sender, EventArgs e)
                    {
                        Point position =
                            parent.PointToClient(
                                Cursor.Position);

                        if (!parent.ClientRectangle.Contains(
                            position))
                        {
                            parent.BackColor =
                                couleurNormale;
                        }
                    };

                // -----------------------------------------------------
                // CONTROLES ENFANTS
                // -----------------------------------------------------

                if (control.Controls.Count > 0)
                {
                    AjouterHoverAuxEnfants(
                        control,
                        couleurHover,
                        couleurNormale);
                }
            }
        }

        
        // ============================================================
        // CLICK DES CONTROLES ENFANTS
        // ============================================================

        private void AjouterClickAuxEnfants(
            Control parent,
            EventHandler clickHandler)
        {
            foreach (Control control in
                parent.Controls)
            {
                // -----------------------------------------------------
                // CLICK
                // -----------------------------------------------------

                control.Click +=
                    clickHandler;

                // -----------------------------------------------------
                // CURSEUR
                // -----------------------------------------------------

                control.Cursor =
                    Cursors.Hand;

                // -----------------------------------------------------
                // CONTROLES ENFANTS
                // -----------------------------------------------------

                if (control.Controls.Count > 0)
                {
                    AjouterClickAuxEnfants(
                        control,
                        clickHandler);
                }
            }
        }


        // ============================================================
        // LOAD
        // ============================================================

        private void User_caisse_Load(
            object sender,
            EventArgs e)
        {
        }

        private void rd_statut_demande_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rd_hospitalisation_CheckedChanged(object sender, EventArgs e)
        {
            ChargerPrescriptions();
            Form1.CONTEXT = "PRESCRIPTION";
        }

        private void rd_EEG_CheckedChanged(object sender, EventArgs e)
        {
            ChargerDemandesEEG();
        }

        private void rb_recu_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_recu.Checked == true)
            {
                ChargerRecus();
            }
            
        }
        // charger les reçus de paiements
        private void ChargerRecus()
        {
            try
            {
                pnl_examen.SuspendLayout();
                pnl_examen.Controls.Clear();
                pnl_examen.FlowDirection =
                  FlowDirection.LeftToRight;

                pnl_examen.WrapContents = true;
                pnl_examen.AutoScroll = true;
                pnl_examen.Padding = new Padding(10, 10, 8, 10);

                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {

                    string recherche = tb_search_demande.Text.Trim();

                    string query = @"
                                SELECT pa.id_paiement, pa.id_facture, pa.date_paiement, pa.montant, pa.type_paiement,
                                       f.statut, p.id_patient, p.nom, p.post_nom, p.prenom,
                                       TIMESTAMPDIFF(YEAR, p.date_naissance, CURDATE()) AS age
                                FROM paiement pa
                                INNER JOIN facture f ON pa.id_facture = f.id_facture
                                INNER JOIN patients p ON f.id_patient = p.id_patient
                                WHERE (@recherche = ''
                                    OR p.nom LIKE @mot
                                    OR p.post_nom LIKE @mot
                                    OR p.prenom LIKE @mot)
                                ORDER BY pa.date_paiement DESC, pa.id_paiement DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@recherche", recherche);
                        cmd.Parameters.AddWithValue("@mot", "%" + recherche + "%");

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Create_pan_recu(
                                    reader["id_paiement"].ToString(),
                                    reader["id_patient"].ToString(),
                                    (reader["nom"] + " " + reader["post_nom"] + " " + reader["prenom"]).ToString().Trim(),
                                    reader["age"] == DBNull.Value ? "" : reader["age"].ToString(),
                                    Convert.ToDateTime(reader["date_paiement"]).ToString("dd/MM/yyyy"),
                                    reader["statut"].ToString(),
                                    reader["montant"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des reçus :\n" + ex.Message, "Reçus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pnl_examen.ResumeLayout(true);
            }
        }

        private void Create_pan_recu(string idPaiement, string idPatient, string patient, string age, string datePaiement, string statut, string montant)
        {
            BunifuRoundedPanel panRecu = new BunifuRoundedPanel();
            panRecu.Size = new Size(290, 155);
            panRecu.BorderRadius = 8;
            panRecu.ShadowDepth = 10;
            panRecu.BorderColor = Color.Silver;
            panRecu.BorderSize = 1;
            panRecu.Margin = new System.Windows.Forms.Padding(10);
            panRecu.BackColor = Color.White;

            Label lbPatient = MesClasses.ManagerClasse.CustomLabel(patient, new Point(12, 12));
            lbPatient.AutoSize = true;
            lbPatient.Font = new Font("Calibri", 11, FontStyle.Bold);
            panRecu.Controls.Add(lbPatient);

            Label lbAge = MesClasses.ManagerClasse.CustomLabel("Âge : " + age + " ans", new Point(12, 40));
            lbAge.AutoSize = true;
            panRecu.Controls.Add(lbAge);

            Label lbDate = MesClasses.ManagerClasse.CustomLabel("Paiement : " + datePaiement, new Point(12, 63));
            lbDate.AutoSize = true;
            panRecu.Controls.Add(lbDate);

            Label lbStatut = MesClasses.ManagerClasse.CustomLabel("Statut : " + statut, new Point(12, 86));
            lbStatut.AutoSize = true;
            lbStatut.Font = new Font("Calibri", 9, FontStyle.Bold);
            lbStatut.ForeColor = statut == "Payé" ? Color.Green : Color.DarkOrange;
            panRecu.Controls.Add(lbStatut);

            Label lbMontant = MesClasses.ManagerClasse.CustomLabel("Montant : " + montant + " $", new Point(12, 108));
            lbMontant.AutoSize = true;
            lbMontant.Font = new Font("Calibri", 9, FontStyle.Bold);
            panRecu.Controls.Add(lbMontant);

            Button btnImprimer = new Button();
            btnImprimer.Text = "Imprimer";
            btnImprimer.Size = new Size(85, 28);
            btnImprimer.Location = new Point(160, 115);
            btnImprimer.Cursor = Cursors.Hand;

            btnImprimer.Click += delegate(object sender, EventArgs e)
            {
                try
                {
                    int paiementId = Convert.ToInt32(idPaiement);
                    MesForms.FormRecu frm = new MesForms.FormRecu(paiementId);
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'ouverture du reçu :\n" + ex.Message, "Reçu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            panRecu.Controls.Add(btnImprimer);
            pnl_examen.Controls.Add(panRecu);
            //MesClasses.ManagerClasse.AddControl(pnl_examen, panRecu, 10, 10);
        }
    }
}