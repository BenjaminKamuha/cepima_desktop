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

namespace Cepima.MesUserCases
{
    public partial class User_DashBoard_consultation : UserControl
    {
        private int idPatient = 0;

        public User_DashBoard_consultation()
        {
            InitializeComponent();

            LoadFilter();
            LoadInforDay();
            LoadConsultations();
        }

        // ============================================================
        // DEMARRER UNE CONSULTATION
        // ============================================================
        private void bt_start_Click(object sender, EventArgs e)
        {
            if (idPatient <= 0)
            {
                MessageBox.Show(
                    "Veuillez sélectionner un patient.",
                    "Consultation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            User_consultation cons =
                new User_consultation(idPatient);

            cons.Dock = DockStyle.Fill;

            Form1.GlobalPanel_main.Controls.Clear();
            Form1.GlobalPanel_main.Controls.Add(cons);
        }

        // ============================================================
        // FILTRES
        // ============================================================
        private void LoadFilter()
        {
            cbx_filtrer.Items.Clear();

            cbx_filtrer.Items.Add(
                "Toutes les consultations");

            cbx_filtrer.Items.Add(
                "Première consultation");

            cbx_filtrer.Items.Add(
                "Consultation de contrôle");

            cbx_filtrer.Items.Add(
                "Consultation d'urgence");

            cbx_filtrer.SelectedIndex = 0;
        }

        // ============================================================
        // INFORMATIONS DU JOUR
        // ============================================================
        private void LoadInforDay()
        {
            using (MySqlConnection con =
                MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    // =================================================
                    // 1. NOMBRE DE CONSULTATIONS DU JOUR
                    // =================================================
                    string queryConsultations = @"
                        SELECT COUNT(*)
                        FROM consultation c
                        INNER JOIN service s
                            ON s.nom = 'Consultation'
                           AND s.actif = 1
                        WHERE c.date_consultation >= CURDATE()
                          AND c.date_consultation <
                              DATE_ADD(CURDATE(), INTERVAL 1 DAY)";

                    using (MySqlCommand cmd =
                        new MySqlCommand(
                            queryConsultations,
                            con))
                    {
                        int nombre =
                            Convert.ToInt32(
                                cmd.ExecuteScalar());

                        lb_consultation.Text =
                            nombre.ToString();
                    }


                    // =================================================
                    // 2. DEMANDES DE CONSULTATION EN ATTENTE
                    // =================================================
                    //
                    // On ne met PAS id_service = 5.
                    //
                    // On fait la liaison :
                    //
                    // demande_service
                    //       ↓
                    //      service
                    //
                    // et on identifie le service par son nom.
                    //
                    // =================================================

                    string queryEnAttente = @"
                        SELECT COUNT(*)
                        FROM demande_service ds

                        INNER JOIN service s
                            ON s.id_service = ds.id_service

                        WHERE s.nom = 'Consultation'
                          AND s.actif = 1
                          AND ds.statut = 'En attente'

                          AND ds.date_demande >= CURDATE()
                          AND ds.date_demande <
                              DATE_ADD(
                                  CURDATE(),
                                  INTERVAL 1 DAY
                              )";

                    using (MySqlCommand cmd =
                        new MySqlCommand(
                            queryEnAttente,
                            con))
                    {
                        int nombre =
                            Convert.ToInt32(
                                cmd.ExecuteScalar());

                        lb_attente.Text =
                            nombre.ToString();
                    }


                    // =================================================
                    // 3. DEMANDES DE CONSULTATION DEMANDEES
                    // =================================================

                    string queryDemandee = @"
                        SELECT COUNT(*)
                        FROM demande_service ds

                        INNER JOIN service s
                            ON s.id_service = ds.id_service

                        WHERE s.nom = 'Consultation'
                          AND s.actif = 1
                          AND ds.statut = 'Demandée'

                          AND ds.date_demande >= CURDATE()
                          AND ds.date_demande <
                              DATE_ADD(
                                  CURDATE(),
                                  INTERVAL 1 DAY
                              )";

                    using (MySqlCommand cmd =
                        new MySqlCommand(
                            queryDemandee,
                            con))
                    {
                        int nombre =
                            Convert.ToInt32(
                                cmd.ExecuteScalar());

                        lb_termine.Text =
                            nombre.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur de chargement des données :\n\n" +
                        ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        // ============================================================
        // CHARGER LES CONSULTATIONS
        // ============================================================
        private void LoadConsultations()
        {
            try
            {
                string recherche =
                    txt_recherche.Text.Trim();

                string typeFiltre = "";

                // =================================================
                // FILTRE
                // =================================================
                if (cbx_filtrer.SelectedIndex == 1)
                {
                    typeFiltre =
                        "Première consultation";
                }
                else if (cbx_filtrer.SelectedIndex == 2)
                {
                    typeFiltre =
                        "Consultation de contrôle";
                }
                else if (cbx_filtrer.SelectedIndex == 3)
                {
                    typeFiltre =
                        "Consultation d'urgence";
                }


                // =================================================
                // REQUETE
                // =================================================
                //
                // consultation
                //       ↓ patient_id
                // patients
                //
                // demande_service est reliée au service
                // "Consultation".
                //
                // Il n'y a PAS de id_consultation dans
                // demande_service, donc on ne l'utilise pas.
                //
                // =================================================

                string query = @"
                    SELECT
                        c.id,
                        p.id_patient,
                        p.nom,
                        p.post_nom,
                        p.prenom,
                        p.sexe,
                        p.date_naissance,
                        p.adresse,
                        c.type_consultation,
                        c.motif,
                        c.date_consultation

                    FROM consultation c

                    INNER JOIN patients p
                        ON p.id_patient = c.patient_id

                    WHERE
                    (
                        p.nom LIKE @recherche
                        OR p.post_nom LIKE @recherche
                        OR p.prenom LIKE @recherche
                    )";


                // =================================================
                // FILTRE TYPE CONSULTATION
                // =================================================

                if (typeFiltre != "")
                {
                    query += @"
                        AND c.type_consultation =
                            @type_consultation";
                }


                // =================================================
                // TRI
                // =================================================

                query += @"
                    ORDER BY
                        c.date_consultation DESC";


                // =================================================
                // PARAMETRES
                // =================================================

                MesClasses.ManagerClasse
                    .request_params.Clear();

                MesClasses.ManagerClasse
                    .request_params.Add(
                        "@recherche",
                        "%" + recherche + "%");


                if (typeFiltre != "")
                {
                    MesClasses.ManagerClasse
                        .request_params.Add(
                            "@type_consultation",
                            typeFiltre);
                }


                // =================================================
                // EXECUTION
                // =================================================

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    dgv_consultations.Rows.Clear();

                    while (reader.Read())
                    {
                        // =========================================
                        // ID CONSULTATION
                        // =========================================

                        int numero =
                            Convert.ToInt32(
                                reader["id"]);


                        // =========================================
                        // ID PATIENT
                        // =========================================

                        int PATIENT_ID =
                            Convert.ToInt32(
                                reader["id_patient"]);


                        // =========================================
                        // PATIENT
                        // =========================================

                        string patient =
                            reader["nom"].ToString()
                            + " "
                            + reader["post_nom"].ToString()
                            + " "
                            + reader["prenom"].ToString();


                        // =========================================
                        // SEXE
                        // =========================================

                        string sexe =
                            reader["sexe"].ToString();


                        // =========================================
                        // AGE
                        // =========================================

                        int age = 0;

                        if (reader["date_naissance"] !=
                            DBNull.Value)
                        {
                            DateTime dateNaissance =
                                Convert.ToDateTime(
                                    reader["date_naissance"]);

                            age =
                                CalculerAge(
                                    dateNaissance);
                        }


                        // =========================================
                        // TYPE CONSULTATION
                        // =========================================

                        string typeConsultation =
                            reader["type_consultation"]
                                .ToString();


                        // =========================================
                        // ADRESSE
                        // =========================================

                        string adresse =
                            reader["adresse"].ToString();


                        // =========================================
                        // MOTIF
                        // =========================================

                        string motif =
                            reader["motif"].ToString();


                        // =========================================
                        // STATUT
                        // =========================================
                        //
                        // La table consultation ne possède pas
                        // directement le statut de la demande.
                        //
                        // Pour l'instant, une consultation affichée
                        // dans ce tableau est considérée "En cours".
                        //
                        // Le statut réel d'une DEMANDE se trouve
                        // dans demande_service.
                        //
                        // =========================================

                        string statut = "En cours";


                        // =========================================
                        // AJOUT AU DATAGRIDVIEW
                        // =========================================

                        dgv_consultations.Rows.Add(
                            numero,
                            patient,
                            sexe,
                            age + " ans",
                            typeConsultation,
                            motif,
                            statut,
                            PATIENT_ID
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des consultations :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // CALCULER L'AGE
        // ============================================================
        private int CalculerAge(
            DateTime dateNaissance)
        {
            DateTime aujourdHui =
                DateTime.Today;

            int age =
                aujourdHui.Year -
                dateNaissance.Year;

            if (dateNaissance.Date >
                aujourdHui.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        // ============================================================
        // CHANGEMENT DE FILTRE
        // ============================================================
        private void cbx_filtrer_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            LoadConsultations();
        }

        // ============================================================
        // RECHERCHE
        // ============================================================
        private void txt_recherche_TextChanged(
            object sender,
            EventArgs e)
        {
            LoadConsultations();
        }

        // ============================================================
        // SELECTION D'UNE CONSULTATION
        // ============================================================
        private void dgv_consultations_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // --------------------------------------------------------
            // Clic sur l'en-tête
            // --------------------------------------------------------

            if (e.RowIndex < 0)
            {
                return;
            }


            // --------------------------------------------------------
            // Vérifier que la colonne existe
            // --------------------------------------------------------

            if (!dgv_consultations.Columns.Contains(
                "ID_Patient"))
            {
                idPatient = 0;

                bt_start.Visible = false;

                return;
            }


            // --------------------------------------------------------
            // Récupérer la valeur
            // --------------------------------------------------------

            object valeur =
                dgv_consultations
                    .Rows[e.RowIndex]
                    .Cells["ID_Patient"]
                    .Value;


            if (valeur == null ||
                valeur == DBNull.Value)
            {
                idPatient = 0;

                bt_start.Visible = false;

                return;
            }


            // --------------------------------------------------------
            // Convertir
            // --------------------------------------------------------

            int patientId;

            if (int.TryParse(
                valeur.ToString(),
                out patientId))
            {
                idPatient =
                    patientId;

                bt_start.Visible =
                    idPatient > 0;
            }
            else
            {
                idPatient = 0;

                bt_start.Visible = false;
            }
        }
    }
}