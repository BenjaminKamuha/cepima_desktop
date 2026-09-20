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
using Cepima.MesForms.Pharmacie;
using Cepima.MesForms.EEG;

namespace Cepima.MesUserCases.EEG
{
    public partial class User_examens : UserControl
    {
        // =========================================================
        // CONSTRUCTEUR
        // =========================================================

        public User_examens()
        {
            InitializeComponent();

            // -----------------------------------------------------
            // RADIO BUTTON PAR DEFAUT
            // -----------------------------------------------------

            rd_tout.Checked = true;


            // -----------------------------------------------------
            // EVENEMENT RECHERCHE
            // -----------------------------------------------------

            tb_search_demande.TextChanged +=
                tb_search_demande_TextChanged;


            // -----------------------------------------------------
            // EVENEMENTS RADIO BUTTON
            // -----------------------------------------------------

            rd_tout.CheckedChanged +=
                rd_statut_CheckedChanged;

            rd_statut_demande.CheckedChanged +=
                rd_statut_CheckedChanged;

            rd_statut_termine.CheckedChanged +=
                rd_statut_CheckedChanged;

            rd_statut_annule.CheckedChanged +=
                rd_statut_CheckedChanged;


            // -----------------------------------------------------
            // CHARGEMENT INITIAL
            // -----------------------------------------------------

            ChargerDemandesEEG();
        }


        // =========================================================
        // CHARGER LES DEMANDES EEG
        // =========================================================

        private void ChargerDemandesEEG()
        {
            try
            {
                // -------------------------------------------------
                // SUPPRIMER LES ANCIENS PANELS
                // -------------------------------------------------

                pnl_examen.Controls.Clear();


                Database db = new Database();


                using (MySqlConnection con =
                    db.GetConnection())
                {
                    con.Open();


                    // =================================================
                    // TEXTE DE RECHERCHE
                    // =================================================

                    string recherche =
                        tb_search_demande.Text.Trim();


                    // =================================================
                    // STATUT SELECTIONNE
                    // =================================================

                    string statut =
                        ObtenirStatutSelectionne();


                    // =================================================
                    // REQUETE
                    // =================================================

                    string query = @"
                        SELECT
                            ds.id_demande,
                            ds.id_patient,
                            ds.id_service,

                            p.nom,
                            p.post_nom,
                            p.prenom,
                            p.numero_fiche,

                            DATE_FORMAT(
                                ds.date_demande,
                                '%d/%m/%Y %H:%i'
                            ) AS date_demande,

                            ds.priorite,
                            ds.motif,
                            ds.statut

                        FROM demande_service ds

                        INNER JOIN patients p
                            ON p.id_patient = ds.id_patient

                        INNER JOIN service s
                            ON s.id_service = ds.id_service

                        WHERE s.nom = 'EEG' AND statut NOT IN ('En attente', 'Annulé')

                        AND
                        (
                            @statut = 'Tous'
                            OR ds.statut = @statut
                        )

                        AND
                        (
                            p.nom LIKE @recherche
                            OR p.post_nom LIKE @recherche
                            OR p.prenom LIKE @recherche
                            OR p.numero_fiche LIKE @recherche
                            OR ds.motif LIKE @recherche
                        )

                        ORDER BY ds.date_demande DESC";


                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        // -------------------------------------------------
                        // PARAMETRES
                        // -------------------------------------------------

                        cmd.Parameters.AddWithValue(
                            "@statut",
                            statut);


                        cmd.Parameters.AddWithValue(
                            "@recherche",
                            "%" + recherche + "%");


                        // -------------------------------------------------
                        // LECTURE
                        // -------------------------------------------------

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string idDemande =
                                    reader["id_demande"].ToString();


                                string idPatient =
                                    reader["id_patient"].ToString();


                                string nom =
                                    reader["nom"] == DBNull.Value
                                        ? ""
                                        : reader["nom"].ToString();


                                string postnom =
                                    reader["post_nom"] == DBNull.Value
                                        ? ""
                                        : reader["post_nom"].ToString();


                                string prenom =
                                    reader["prenom"] == DBNull.Value
                                        ? ""
                                        : reader["prenom"].ToString();


                                string numero =
                                    reader["numero_fiche"] == DBNull.Value
                                        ? ""
                                        : reader["numero_fiche"].ToString();


                                string status =
                                    reader["statut"] == DBNull.Value
                                        ? ""
                                        : reader["statut"].ToString();


                                string dateDemande =
                                    reader["date_demande"] == DBNull.Value
                                        ? ""
                                        : reader["date_demande"].ToString();


                                string priorite =
                                    reader["priorite"] == DBNull.Value
                                        ? ""
                                        : reader["priorite"].ToString();


                                string motif =
                                    reader["motif"] == DBNull.Value
                                        ? ""
                                        : reader["motif"].ToString();


                                // -------------------------------------------------
                                // CREATION DU PANEL
                                // -------------------------------------------------

                                Create_pan_examen(
                                    idDemande,
                                    idPatient,
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


                // =================================================
                // ANIMATION
                // =================================================

                if (pnl_examen.Controls.Count > 0)
                {
                    ProgressiveDisplay pd =
                        new ProgressiveDisplay(
                            pnl_examen,
                            100);

                    pd.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des demandes EEG.\n\n" +
                    ex.Message,
                    "Demandes EEG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // OBTENIR LE STATUT SELECTIONNE
        // =========================================================

        private string ObtenirStatutSelectionne()
        {
            // -----------------------------------------------------
            // TOUT
            // -----------------------------------------------------

            if (rd_tout.Checked)
            {
                return "Tous";
            }


            // -----------------------------------------------------
            // DEMANDE
            // -----------------------------------------------------

            if (rd_statut_demande.Checked)
            {
                return "Demandée";
            }


            // -----------------------------------------------------
            // TERMINE
            // -----------------------------------------------------

            if (rd_statut_termine.Checked)
            {
                return "Terminée";
            }

            // -----------------------------------------------------
            // ANNULE
            // -----------------------------------------------------

            if (rd_statut_annule.Checked)
            {
                return "Annulée";
            }


            // -----------------------------------------------------
            // PAR DEFAUT
            // -----------------------------------------------------

            return "Tous";
        }


        // =========================================================
        // EVENEMENT RECHERCHE
        // =========================================================

        private void tb_search_demande_TextChanged(
            object sender,
            EventArgs e)
        {
            ChargerDemandesEEG();
        }


        // =========================================================
        // EVENEMENT RADIO BUTTON
        // =========================================================

        private void rd_statut_CheckedChanged(
            object sender,
            EventArgs e)
        {
            RadioButton radio =
                sender as RadioButton;


            // On recharge uniquement le RadioButton
            // qui vient d'être sélectionné.

            if (radio != null &&
                radio.Checked)
            {
                ChargerDemandesEEG();
            }
        }


        // =========================================================
        // CREER LE PANEL D'UNE DEMANDE
        // =========================================================

        private void Create_pan_examen(
            string idDemande,
            string idPatient,
            string nom,
            string postnom,
            string prenom,
            string numero,
            string status,
            string dateDemande,
            string priorite,
            string motif)
        {
            // =====================================================
            // CREATION DU PANEL
            // =====================================================

            CustomRoundedPanel panDemande =
                new CustomRoundedPanel();


            panDemande.Size =
                new Size(160, 145);


            panDemande.BorderRadius =
                8;


            panDemande.BorderColor =
                Color.Silver;


            panDemande.BorderSize =
                1;


            // ID de la demande
            panDemande.Tag =
                idDemande;


            // =====================================================
            // HOVER
            // =====================================================

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


            // =====================================================
            // AJOUT AU PANEL PRINCIPAL
            // =====================================================

            MesClasses.ManagerClasse.AddControl(
                pnl_examen,
                panDemande,
                10,
                8);


            // =====================================================
            // EVENEMENT CLICK
            // =====================================================

            EventHandler clickDemande =
                delegate(object sender, EventArgs e)
                {
                    try
                    {
                        // ---------------------------------------------
                        // DEMANDE EEG
                        // ---------------------------------------------

                        if (status == "Demandée")
                        {
                            Form1.PATIENT_ID = Convert.ToInt32(idPatient);
                            Form1.DEMANDE_ID = Convert.ToInt32(idDemande);

                            Form_new_eeg form = new Form_new_eeg();
                            form.ShowDialog();

                            ChargerDemandesEEG();
                        }
                        else if (status == "En cours")
                        {
                            Form1.PATIENT_ID = Convert.ToInt32(idPatient);
                            Form1.DEMANDE_ID = Convert.ToInt32(idDemande);

                            Form_realisation_eeg form = new Form_realisation_eeg();

                            form.ShowDialog();

                            ChargerDemandesEEG();
                        }
                        else if (status == "Terminée")
                        {
                            MesForms.Form_Fiche_suivie form =
                                new MesForms.Form_Fiche_suivie(idPatient);

                            form.ShowDialog();

                            ChargerDemandesEEG();
                        }
                        else if (status == "Annulée")
                        {
                            MessageBox.Show(
                                "Cette demande EEG a été annulée.",
                                "EEG",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Erreur lors de l'ouverture de la demande.\n\n" +
                            ex.Message,
                            "Demande EEG",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                };


            // =====================================================
            // CLICK SUR LE PANEL
            // =====================================================

            panDemande.Click +=
                clickDemande;


            // =====================================================
            // IMAGE EEG
            // =====================================================

            PictureBox picture =
                MesClasses.ManagerClasse.AddPicture(
                    Properties.Resources.brain_40px,
                    new Point(2, 5),
                    new Size(60, 60));


            picture.Cursor =
                Cursors.Hand;


            panDemande.Controls.Add(
                picture);


            // =====================================================
            // NOM
            // =====================================================

            Label lbNom =
                MesClasses.ManagerClasse.CustomLabel(
                    nom,
                    new Point(65, 15));


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


            // =====================================================
            // POST-NOM
            // =====================================================

            Label lbPost =
                MesClasses.ManagerClasse.CustomLabel(
                    postnom,
                    new Point(65, 35));


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


            panDemande.Controls.Add(
                lbNumero);


            // =====================================================
            // STATUT
            // =====================================================

            Label lbStatus =
                MesClasses.ManagerClasse.CustomLabel(
                    status,
                    new Point(10, 88));


            lbStatus.AutoSize =
                true;


            lbStatus.Font =
                new Font(
                    "Calibri",
                    9,
                    FontStyle.Bold);


            lbStatus.Cursor =
                Cursors.Hand;


            // -----------------------------------------------------
            // COULEUR DU STATUT
            // -----------------------------------------------------

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


            // =====================================================
            // DATE
            // =====================================================

            Label lbDate =
                MesClasses.ManagerClasse.CustomLabel(
                    dateDemande,
                    new Point(10, 110));


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


            // =====================================================
            // CLICK SUR TOUS LES CONTROLES ENFANTS
            // =====================================================

            AjouterClickAuxEnfants(
                panDemande,
                clickDemande);


            // =====================================================
            // HOVER SUR TOUS LES CONTROLES ENFANTS
            // =====================================================

            AjouterHoverAuxEnfants(
                panDemande,
                couleurHover,
                couleurNormale);
        }


        // =========================================================
        // AJOUTER LE CLICK AUX CONTROLES ENFANTS
        // =========================================================

        private void AjouterClickAuxEnfants(
            Control parent,
            EventHandler clickHandler)
        {
            foreach (Control control in parent.Controls)
            {
                // -------------------------------------------------
                // CLICK
                // -------------------------------------------------

                control.Click +=
                    clickHandler;


                // -------------------------------------------------
                // CURSEUR
                // -------------------------------------------------

                control.Cursor =
                    Cursors.Hand;


                // -------------------------------------------------
                // CONTROLES ENFANTS
                // -------------------------------------------------

                if (control.Controls.Count > 0)
                {
                    AjouterClickAuxEnfants(
                        control,
                        clickHandler);
                }
            }
        }


        // =========================================================
        // AJOUTER LE HOVER AUX CONTROLES ENFANTS
        // =========================================================

        private void AjouterHoverAuxEnfants(
            Control parent,
            Color couleurHover,
            Color couleurNormale)
        {
            foreach (Control control in parent.Controls)
            {
                // -------------------------------------------------
                // MOUSE ENTER
                // -------------------------------------------------

                control.MouseEnter +=
                    delegate(object sender, EventArgs e)
                    {
                        parent.BackColor =
                            couleurHover;
                    };


                // -------------------------------------------------
                // MOUSE LEAVE
                // -------------------------------------------------

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


                // -------------------------------------------------
                // CONTROLES ENFANTS
                // -------------------------------------------------

                if (control.Controls.Count > 0)
                {
                    AjouterHoverAuxEnfants(
                        control,
                        couleurHover,
                        couleurNormale);
                }
            }
        }
    }
}