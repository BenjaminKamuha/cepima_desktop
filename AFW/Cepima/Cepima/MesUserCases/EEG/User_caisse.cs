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

            ChargerDemandesEEG();
        }

        // ============================================================
        // CHARGER LES DEMANDES EEG
        // ============================================================
        private void ChargerPrescriptions()
        {
            //try
            //{
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
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(
            //        "Erreur lors du chargement des prescriptions.\n\n" +
            //        ex.Message,
            //        "Prescriptions",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    pnl_examen.ResumeLayout(true);
            //}
        }



        private void Create_pan_prescription(
        string idPrescription,
        string idPatient,
        string nom,
        string postnom,
        string prenom,
        string numero,
        string statut,
        string datePrescription,
        string type,
        string observation)
        {
            // =====================================================
            // PANEL
            // =====================================================

            CustomRoundedPanel panPrescription =
                new CustomRoundedPanel();

            panPrescription.Size =
                new Size(160, 145);

            panPrescription.BorderRadius =
                8;

            panPrescription.BorderColor =
                Color.Silver;

            panPrescription.BorderSize =
                1;

            panPrescription.Tag =
                idPrescription;


            // =====================================================
            // COULEURS
            // =====================================================

            Color couleurNormale =
                Color.White;

            Color couleurHover =
                Color.FromArgb(
                    245,
                    248,
                    255);

            panPrescription.BackColor =
                couleurNormale;

            panPrescription.HoverBackColor =
                couleurHover;

            panPrescription.HoverCursor =
                Cursors.Hand;


            // =====================================================
            // IMAGE PRESCRIPTION
            // =====================================================

            PictureBox picture =
                MesClasses.ManagerClasse.AddPicture(
                    Properties.Resources.capsules_100px,
                    new Point(2, 5),
                    new Size(60, 60));

            picture.Cursor =
                Cursors.Hand;

            panPrescription.Controls.Add(
                picture);


            // =====================================================
            // CLICK
            // =====================================================

            EventHandler clickPrescription =
                delegate(object sender, EventArgs e)
                {
                    try
                    {
                        int prescriptionId =
                            Convert.ToInt32(
                                idPrescription);

                        int patientId =
                            Convert.ToInt32(
                                idPatient);


                        // -------------------------------------------------
                        // STOCKER L'ID PATIENT
                        // -------------------------------------------------

                        Form1.PATIENT_ID =
                            patientId;


                        // -------------------------------------------------
                        // OUVRIR LA PRESCRIPTION
                        // -------------------------------------------------

                        MesForms.Pharmacie.Form_prescription frm =
                            new MesForms.Pharmacie.Form_prescription(
                                prescriptionId);

                        frm.ShowDialog();


                        // -------------------------------------------------
                        // RECHARGER APRES RETOUR
                        // -------------------------------------------------

                        ChargerPrescriptions();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Erreur lors de l'ouverture de la prescription.\n\n" +
                            ex.Message,
                            "Prescription",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                };


            // =====================================================
            // CLICK SUR LE PANEL
            // =====================================================

            panPrescription.Click +=
                clickPrescription;


            // =====================================================
            // PATIENT
            // =====================================================

            string patient =
                (nom + " " + postnom + " " + prenom)
                .Trim();

            Label lbPatient =
                MesClasses.ManagerClasse.CustomLabel(
                    patient,
                    new Point(65, 15));

            lbPatient.AutoSize =
                true;

            lbPatient.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold);

            lbPatient.Cursor =
                Cursors.Hand;

            panPrescription.Controls.Add(
                lbPatient);


            // =====================================================
            // NUMERO FICHE
            // =====================================================

            Label lbNumero =
                MesClasses.ManagerClasse.CustomLabel(
                    numero,
                    new Point(10, 67));

            lbNumero.AutoSize =
                true;

            lbNumero.Font =
                new Font(
                    "Calibri",
                    9,
                    FontStyle.Regular);

            lbNumero.Cursor =
                Cursors.Hand;

            panPrescription.Controls.Add(
                lbNumero);


            // =====================================================
            // TYPE
            // =====================================================

            Label lbType =
                MesClasses.ManagerClasse.CustomLabel(
                    type,
                    new Point(10, 88));

            lbType.AutoSize =
                true;

            lbType.Font =
                new Font(
                    "Calibri",
                    9,
                    FontStyle.Bold);

            lbType.Cursor =
                Cursors.Hand;


            if (type == "Hospitalisation")
            {
                lbType.ForeColor =
                    Color.Blue;
            }
            else
            {
                lbType.ForeColor =
                    Color.DarkGreen;
            }

            panPrescription.Controls.Add(
                lbType);


            // =====================================================
            // STATUT
            // =====================================================

            Label lbStatut =
                MesClasses.ManagerClasse.CustomLabel(
                    statut,
                    new Point(10, 106));

            lbStatut.AutoSize =
                true;

            lbStatut.Font =
                new Font(
                    "Calibri",
                    9,
                    FontStyle.Bold);

            lbStatut.Cursor =
                Cursors.Hand;


            if (string.Equals(
                statut,
                "ACTIVE",
                StringComparison.OrdinalIgnoreCase))
            {
                lbStatut.ForeColor =
                    Color.Orange;
            }
            else if (string.Equals(
                statut,
                "DELIVREE",
                StringComparison.OrdinalIgnoreCase))
            {
                lbStatut.ForeColor =
                    Color.Green;
            }
            else
            {
                lbStatut.ForeColor =
                    Color.Gray;
            }

            panPrescription.Controls.Add(
                lbStatut);


            // =====================================================
            // DATE
            // =====================================================

            Label lbDate =
                MesClasses.ManagerClasse.CustomLabel(
                    datePrescription,
                    new Point(10, 125));

            lbDate.AutoSize =
                true;

            lbDate.Font =
                new Font(
                    "Calibri",
                    8,
                    FontStyle.Regular);

            lbDate.ForeColor =
                Color.Gray;

            lbDate.Cursor =
                Cursors.Hand;

            panPrescription.Controls.Add(
                lbDate);


            // =====================================================
            // OBSERVATION
            // =====================================================

            if (!string.IsNullOrWhiteSpace(
                observation))
            {
                // Conservation du comportement original.
                // Aucun changement de fonctionnalité.
            }


            // =====================================================
            // CLICK SUR TOUS LES CONTROLES ENFANTS
            // =====================================================

            AjouterClickAuxEnfants(
                panPrescription,
                clickPrescription);


            // =====================================================
            // HOVER SUR TOUS LES CONTROLES ENFANTS
            // =====================================================

            AjouterHoverAuxEnfants(
                panPrescription,
                couleurHover,
                couleurNormale);


            // =====================================================
            // AJOUT AU FLOWLAYOUTPANEL
            // =====================================================

            pnl_examen.Controls.Add(
                panPrescription);
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

        private void Create_pan_examen(
            string idDemande,
            string idPatient,
            int idPrestation,
            string nom,
            string postnom,
            string prenom,
            string numero,
            string status,
            string dateDemande,
            string priorite,
            string motif)
        {
            // ============================================================
            // CREATION DU PANEL
            // ============================================================

            CustomRoundedPanel panDemande =
                new CustomRoundedPanel();

            panDemande.Size =
                new Size(
                    160,
                    145);

            panDemande.BorderRadius =
                8;

            panDemande.BorderColor =
                Color.Silver;

            panDemande.BorderSize =
                1;

            // ============================================================
            // ID DEMANDE
            // ============================================================

            panDemande.Tag =
                idDemande;

            // ============================================================
            // HOVER
            // ============================================================

            Color couleurNormale =
                Color.White;

            Color couleurHover =
                Color.FromArgb(
                    245,
                    248,
                    255);

            panDemande.BackColor =
                couleurNormale;

            panDemande.HoverBackColor =
                couleurHover;

            panDemande.HoverCursor =
                Cursors.Hand;

            // ============================================================
            // AJOUT AU PANEL PRINCIPAL
            // ============================================================

            MesClasses.ManagerClasse.AddControl(
                pnl_examen,
                panDemande,
                10,
                8);

            // ============================================================
            // EVENEMENT CLICK
            // ============================================================

            EventHandler clickDemande =
                delegate(object sender, EventArgs e)
                {
                    try
                    {
                        // ---------------------------------------------
                        // PATIENT
                        // ---------------------------------------------

                        Form1.PATIENT_ID =
                            Convert.ToInt32(
                                idPatient);

                        // ---------------------------------------------
                        // DEMANDE
                        // ---------------------------------------------

                        Form1.DEMANDE_ID =
                            Convert.ToInt32(
                                idDemande);

                        // ---------------------------------------------
                        // OUVRIR CAISSE EEG
                        // ---------------------------------------------

                        Form_caisse_eeg form =
                            new Form_caisse_eeg(
                                idPatient,
                                idDemande,
                                idPrestation);

                        form.ShowDialog();

                        // ---------------------------------------------
                        // RECHARGER LA LISTE
                        // ---------------------------------------------

                        ChargerDemandesEEG();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Erreur lors de l'ouverture de la demande EEG.\n\n" +
                            ex.Message,
                            "Demande EEG",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                };

            // ============================================================
            // CLICK SUR LE PANEL
            // ============================================================

            panDemande.Click +=
                clickDemande;

            // ============================================================
            // IMAGE EEG
            // ============================================================

            PictureBox picture =
                MesClasses.ManagerClasse.AddPicture(
                    Properties.Resources.brain_40px,
                    new Point(2, 5),
                    new Size(60, 60));

            picture.Cursor =
                Cursors.Hand;

            panDemande.Controls.Add(
                picture);

            // ============================================================
            // NOM
            // ============================================================

            Label lbNom =
                MesClasses.ManagerClasse.CustomLabel(
                    nom,
                    new Point(
                        65,
                        15));

            lbNom.AutoSize =
                true;

            lbNom.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold);

            lbNom.Cursor =
                Cursors.Hand;

            panDemande.Controls.Add(
                lbNom);

            // ============================================================
            // POST-NOM
            // ============================================================

            Label lbPost =
                MesClasses.ManagerClasse.CustomLabel(
                    postnom,
                    new Point(
                        65,
                        35));

            lbPost.AutoSize =
                true;

            lbPost.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold);

            lbPost.Cursor =
                Cursors.Hand;

            panDemande.Controls.Add(
                lbPost);

            // ============================================================
            // NUMERO FICHE
            // ============================================================

            Label lbNumero =
                MesClasses.ManagerClasse.CustomLabel(
                    numero,
                    new Point(
                        10,
                        67));

            lbNumero.AutoSize =
                true;

            lbNumero.Font =
                new Font(
                    "Calibri",
                    9,
                    FontStyle.Regular);

            lbNumero.Cursor =
                Cursors.Hand;

            panDemande.Controls.Add(
                lbNumero);

            // ============================================================
            // STATUT
            // ============================================================

            Label lbStatus =
                MesClasses.ManagerClasse.CustomLabel(
                    status,
                    new Point(
                        10,
                        88));

            lbStatus.AutoSize =
                true;

            lbStatus.Font =
                new Font(
                    "Calibri",
                    9,
                    FontStyle.Bold);

            lbStatus.Cursor =
                Cursors.Hand;

            // ------------------------------------------------------------
            // COULEUR DU STATUT
            // ------------------------------------------------------------

            if (status == "Terminée")
            {
                lbStatus.ForeColor =
                    Color.Green;
            }
            else if (status == "Demandée")
            {
                lbStatus.ForeColor =
                    Color.Orange;
            }
            else if (status == "Annulée")
            {
                lbStatus.ForeColor =
                    Color.Red;
            }

            panDemande.Controls.Add(
                lbStatus);

            // ============================================================
            // DATE
            // ============================================================

            Label lbDate =
                MesClasses.ManagerClasse.CustomLabel(
                    dateDemande,
                    new Point(
                        10,
                        110));

            lbDate.AutoSize =
                true;

            lbDate.Font =
                new Font(
                    "Calibri",
                    8,
                    FontStyle.Regular);

            lbDate.ForeColor =
                Color.Gray;

            lbDate.Cursor =
                Cursors.Hand;

            panDemande.Controls.Add(
                lbDate);

            // ============================================================
            // CLICK SUR TOUS LES CONTROLES ENFANTS
            // ============================================================

            AjouterClickAuxEnfants(
                panDemande,
                clickDemande);

            // ============================================================
            // HOVER SUR TOUS LES CONTROLES ENFANTS
            // ============================================================

            AjouterHoverAuxEnfants(
                panDemande,
                couleurHover,
                couleurNormale);
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
    }
}