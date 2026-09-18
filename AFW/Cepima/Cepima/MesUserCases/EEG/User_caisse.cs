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
            Database db = new Database();

            ChargerDemandesEEG();

        }

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
                    // REQUETE
                    // =================================================

                    string query = @"
                        SELECT
                            ds.id_demande,
                            ds.id_patient,
                            ds.id_service,
                            ds.id_consultation,

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

                        WHERE s.nom = 'EEG' AND statut IS NULL


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
                            Form1.PATIENT_ID = Convert.ToInt32(idPatient);
                            Form1.DEMANDE_ID = Convert.ToInt32(idDemande);

                            Form_caisse_eeg form = new Form_caisse_eeg(idPatient, idDemande);
                            form.ShowDialog();
                            ChargerDemandesEEG();

                       
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


        private void User_caisse_Load(object sender, EventArgs e)
        {

        }


    }
}
