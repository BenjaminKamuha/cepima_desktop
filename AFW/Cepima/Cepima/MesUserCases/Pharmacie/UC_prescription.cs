using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Cepima.Data;

namespace Cepima.MesUserCases.Pharmacie
{
    public partial class UC_prescription : UserControl
    {
        // =========================================================
        // CONSTRUCTEUR
        // =========================================================

        public UC_prescription()
        {
            InitializeComponent();

            // -----------------------------------------------------
            // FILTRE PAR DEFAUT
            // -----------------------------------------------------

            rd_tout.Checked = true;

            // -----------------------------------------------------
            // RECHERCHE
            // -----------------------------------------------------

            tb_search.TextChanged -= tb_search_TextChanged;
            tb_search.TextChanged += tb_search_TextChanged;

            // -----------------------------------------------------
            // RADIO BUTTONS
            // -----------------------------------------------------

            rd_tout.CheckedChanged -= rd_filtre_CheckedChanged;
            rd_tout.CheckedChanged += rd_filtre_CheckedChanged;

            rd_en_attente.CheckedChanged -= rd_filtre_CheckedChanged;
            rd_en_attente.CheckedChanged += rd_filtre_CheckedChanged;

            rd_delivree.CheckedChanged -= rd_filtre_CheckedChanged;
            rd_delivree.CheckedChanged += rd_filtre_CheckedChanged;

            rd_ambulatoire.CheckedChanged -= rd_filtre_CheckedChanged;
            rd_ambulatoire.CheckedChanged += rd_filtre_CheckedChanged;

            rd_hospitalisation.CheckedChanged -= rd_filtre_CheckedChanged;
            rd_hospitalisation.CheckedChanged += rd_filtre_CheckedChanged;

            // -----------------------------------------------------
            // CHARGEMENT INITIAL
            // -----------------------------------------------------

            ChargerPrescriptions();
        }


        // =========================================================
        // CHARGER LES PRESCRIPTIONS
        // =========================================================

        private void ChargerPrescriptions()
        {
            try
            {
                // -------------------------------------------------
                // SUSPENDRE LE RAFRAICHISSEMENT VISUEL
                // -------------------------------------------------

                fl_prescription.SuspendLayout();

                fl_prescription.Controls.Clear();

                Database db = new Database();

                using (MySqlConnection con = db.GetConnection())
                {
                    // Conservation de con.Open()
                    con.Open();

                    // =================================================
                    // RECHERCHE
                    // =================================================

                    string recherche =
                        tb_search.Text.Trim();

                    // =================================================
                    // FILTRE
                    // =================================================

                    string filtre =
                        ObtenirFiltreSelectionne();

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

                        AND

                            (
                                @filtre = 'Tous'

                                OR
                                (
                                    @filtre = 'En attente'
                                    AND pr.statut = 'ACTIVE'
                                )

                                OR
                                (
                                    @filtre = 'Délivrée'
                                    AND pr.statut = 'DELIVREE'
                                )

                                OR
                                (
                                    @filtre = 'Ambulatoire'
                                    AND h.patient_id IS NULL
                                )

                                OR
                                (
                                    @filtre = 'Hospitalisation'
                                    AND h.patient_id IS NOT NULL
                                )
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

                        cmd.Parameters.Add(
                            "@filtre",
                            MySqlDbType.VarChar)
                            .Value =
                                filtre;


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
                fl_prescription.ResumeLayout(true);
            }
        }


        // =========================================================
        // LECTURE SECURISEE D'UNE CHAINE
        // =========================================================

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


        // =========================================================
        // LECTURE DATE
        // =========================================================

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


        // =========================================================
        // FILTRE SELECTIONNE
        // =========================================================

        private string ObtenirFiltreSelectionne()
        {
            if (rd_en_attente.Checked)
            {
                return "En attente";
            }

            if (rd_delivree.Checked)
            {
                return "Délivrée";
            }

            if (rd_ambulatoire.Checked)
            {
                return "Ambulatoire";
            }

            if (rd_hospitalisation.Checked)
            {
                return "Hospitalisation";
            }

            return "Tous";
        }


        // =========================================================
        // CREER UNE CARTE DE PRESCRIPTION
        // =========================================================

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

            fl_prescription.Controls.Add(
                panPrescription);
        }


        // =========================================================
        // CLICK SUR LES CONTROLES ENFANTS
        // =========================================================

        private void AjouterClickAuxEnfants(
            Control parent,
            EventHandler clickHandler)
        {
            foreach (Control control
                in parent.Controls)
            {
                control.Click +=
                    clickHandler;

                control.Cursor =
                    Cursors.Hand;

                if (control.Controls.Count > 0)
                {
                    AjouterClickAuxEnfants(
                        control,
                        clickHandler);
                }
            }
        }


        // =========================================================
        // HOVER
        // =========================================================

        private void AjouterHoverAuxEnfants(
            Control parent,
            Color couleurHover,
            Color couleurNormale)
        {
            foreach (Control control
                in parent.Controls)
            {
                control.MouseEnter +=
                    delegate(object sender, EventArgs e)
                    {
                        parent.BackColor =
                            couleurHover;
                    };

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


                if (control.Controls.Count > 0)
                {
                    AjouterHoverAuxEnfants(
                        control,
                        couleurHover,
                        couleurNormale);
                }
            }
        }


        // =========================================================
        // RECHERCHE
        // =========================================================

        private void tb_search_TextChanged(
            object sender,
            EventArgs e)
        {
            ChargerPrescriptions();
        }


        // =========================================================
        // FILTRES
        // =========================================================

        private void rd_filtre_CheckedChanged(
            object sender,
            EventArgs e)
        {
            RadioButton radio =
                sender as RadioButton;

            if (radio != null &&
                radio.Checked)
            {
                ChargerPrescriptions();
            }
        }


        // =========================================================
        // AJOUT MEDICAMENT
        // =========================================================

        private void btn_add_med_Click(
            object sender,
            EventArgs e)
        {
            // Conservation de la fonctionnalité
            // telle qu'elle existe actuellement.
        }


        // =========================================================
        // EVENEMENT EXISTANT
        // =========================================================

        private void btn_add_med_Click_1(
            object sender,
            EventArgs e)
        {
        }
    }
}