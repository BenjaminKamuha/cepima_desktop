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

namespace Cepima.MesUserCases.Hospitalisation
{
    public partial class User_DashBoard_Hospi : UserControl
    {
        public User_DashBoard_Hospi()
        {
            InitializeComponent();

            LoadResume();
        }


        // ============================================================
        // CHARGER LES RESUMES
        // ============================================================

        private void LoadResume()
        {
            using (MySqlConnection con =
                MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    // =================================================
                    // UNE SEULE REQUETE POUR LES 4 COMPTEURS
                    // =================================================

                    string query = @"
                        SELECT

                            (
                                SELECT COUNT(*)
                                FROM hospitalisation
                                WHERE etat = 'Hospitalisé'
                            ) AS total_hospitalises,

                            (
                                SELECT COUNT(*)
                                FROM chambre
                            ) AS total_chambres,

                            (
                                SELECT COUNT(*)
                                FROM chambre
                                WHERE statut = 'Occupée'
                            ) AS chambres_occupees,

                            (
                                SELECT COUNT(*)
                                FROM hospitalisation
                                WHERE date_sortie IS NOT NULL
                            ) AS total_sorties";


                    using (MySqlCommand cmd =
                        new MySqlCommand(
                            query,
                            con))
                    {
                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // =====================================
                                // PATIENTS HOSPITALISES
                                // =====================================

                                lb_total.Text =
                                    Convert.ToInt32(
                                        reader["total_hospitalises"])
                                    .ToString();


                                // =====================================
                                // CHAMBRES
                                // =====================================

                                lb_chambre.Text =
                                    Convert.ToInt32(
                                        reader["total_chambres"])
                                    .ToString();


                                // =====================================
                                // CHAMBRES OCCUPEES
                                // =====================================

                                lb_libre.Text =
                                    Convert.ToInt32(
                                        reader["chambres_occupees"])
                                    .ToString();


                                // =====================================
                                // SORTIES
                                // =====================================

                                lb_sorties.Text =
                                    Convert.ToInt32(
                                        reader["total_sorties"])
                                    .ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur lors du chargement des statistiques :\n\n" +
                        ex.Message,
                        "Tableau de bord",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }


        // ============================================================
        // LOAD DU USER CONTROL
        // ============================================================

        private void User_DashBoard_Hospi_Load(
            object sender,
            EventArgs e)
        {
            combo_statut.Items.Clear();

            combo_statut.Items.Add("Tous");
            combo_statut.Items.Add("Hospitalisé");
            combo_statut.Items.Add("En observation");
            combo_statut.Items.Add("Stable");
            combo_statut.Items.Add("Sorti");

            combo_statut.SelectedIndex = 0;

            LoadHospitalisations();
        }


        // ============================================================
        // CHANGEMENT DE STATUT
        // ============================================================

        private void combo_statut_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            string statut = "";

            if (combo_statut.SelectedItem != null)
            {
                statut =
                    combo_statut.SelectedItem.ToString();
            }

            LoadHospitalisations(
                txt_recherche.Text,
                statut);
        }


        // ============================================================
        // RECHERCHE
        // ============================================================

        private void txt_recherche_TextChanged(
            object sender,
            EventArgs e)
        {
            string statut = "";

            if (combo_statut.SelectedItem != null)
            {
                statut =
                    combo_statut.SelectedItem.ToString();
            }

            LoadHospitalisations(
                txt_recherche.Text,
                statut);
        }


        // ============================================================
        // CHARGER LES HOSPITALISATIONS
        // ============================================================

        private void LoadHospitalisations(
            string recherche = "",
            string statut = "")
        {
            try
            {
                // =====================================================
                // SUSPENDRE LE LAYOUT
                // =====================================================

                dgv_hospitalisation.SuspendLayout();

                dgv_hospitalisation.Rows.Clear();


                // =====================================================
                // REQUETE
                // =====================================================

                string query = @"
                    SELECT
                        h.id_hospitalisation,
                        h.date_entree,
                        h.date_sortie,
                        h.etat,

                        p.nom,
                        p.post_nom,
                        p.prenom,
                        p.date_naissance,
                        p.adresse,

                        c.numero_chambre,
                        c.tarif_journalier

                    FROM hospitalisation h

                    INNER JOIN patients p
                        ON h.id_patient = p.id_patient

                    INNER JOIN affectation_chambre a
                        ON a.id_hospitalisation =
                           h.id_hospitalisation

                    INNER JOIN chambre c
                        ON a.id_chambre =
                           c.id_chambre

                    WHERE 1 = 1";


                // =====================================================
                // PARAMETRES
                // =====================================================

                MesClasses.ManagerClasse.request_params.Clear();


                // =====================================================
                // RECHERCHE PATIENT
                // =====================================================

                if (!string.IsNullOrWhiteSpace(recherche))
                {
                    query += @"
                        AND
                        (
                            p.nom LIKE @search
                            OR p.post_nom LIKE @search
                            OR p.prenom LIKE @search
                        )";

                    MesClasses.ManagerClasse.request_params.Add(
                        "@search",
                        "%" + recherche.Trim() + "%");
                }


                // =====================================================
                // FILTRE STATUT
                // =====================================================

                if (!string.IsNullOrWhiteSpace(statut) &&
                    statut != "Tous")
                {
                    query += @"
                        AND h.etat = @statut";

                    MesClasses.ManagerClasse.request_params.Add(
                        "@statut",
                        statut);
                }


                // =====================================================
                // TRI + LIMITE
                // =====================================================

                query += @"
                    ORDER BY h.date_entree DESC
                    LIMIT 15";


                // =====================================================
                // EXECUTION
                // =====================================================

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    int nombreLignes = 0;


                    // =================================================
                    // LECTURE
                    // =================================================

                    while (reader.Read())
                    {
                        // =============================================
                        // PATIENT
                        // =============================================

                        string nom =
                            reader["nom"].ToString();

                        string postnom =
                            reader["post_nom"].ToString();

                        string prenom =
                            reader["prenom"].ToString();

                        string patient =
                            (nom + " " +
                             postnom + " " +
                             prenom).Trim();


                        // =============================================
                        // CHAMBRE
                        // =============================================

                        string chambre =
                            reader["numero_chambre"].ToString();


                        // =============================================
                        // TARIF
                        // =============================================

                        string tarif = "0";

                        if (reader["tarif_journalier"] !=
                            DBNull.Value)
                        {
                            decimal tarifDecimal =
                                Convert.ToDecimal(
                                    reader[
                                        "tarif_journalier"]);

                            tarif =
                                tarifDecimal.ToString("N0");
                        }


                        // =============================================
                        // AGE
                        // =============================================

                        int age = 0;

                        if (reader["date_naissance"] !=
                            DBNull.Value)
                        {
                            age =
                                MesClasses.ReceptionManager
                                .CalculerAge(
                                    Convert.ToDateTime(
                                        reader[
                                            "date_naissance"]));
                        }


                        // =============================================
                        // ADRESSE
                        // =============================================

                        string adresse =
                            reader["adresse"].ToString();


                        // =============================================
                        // DATE ENTREE
                        // =============================================

                        string dateEntree = "";

                        if (reader["date_entree"] !=
                            DBNull.Value)
                        {
                            dateEntree =
                                Convert.ToDateTime(
                                    reader[
                                        "date_entree"])
                                .ToString(
                                    "dd/MM/yyyy");
                        }


                        // =============================================
                        // ETAT
                        // =============================================

                        string etat =
                            reader["etat"].ToString();


                        // =============================================
                        // AJOUT DATAGRIDVIEW
                        // =============================================

                        dgv_hospitalisation.Rows.Add(
                            patient,
                            age + " ans",
                            adresse,
                            "Chambre N° : " + chambre,
                            tarif + "$",
                            dateEntree,
                            etat);


                        nombreLignes++;
                    }


                    // =================================================
                    // LARGEUR COLONNE
                    // =================================================

                    if (dgv_hospitalisation.Columns.Contains(
                        "colPatient"))
                    {
                        dgv_hospitalisation
                            .Columns["colPatient"]
                            .Width = 200;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des hospitalisations :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des hospitalisations :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                // =====================================================
                // REACTIVER LE LAYOUT
                // =====================================================

                dgv_hospitalisation.ResumeLayout(true);
            }
        }
    }
}