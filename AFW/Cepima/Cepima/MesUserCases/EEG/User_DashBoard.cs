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

namespace Cepima.MesUserCases.EEG
{
    public partial class User_DashBoard : UserControl
    {
        public User_DashBoard()
        {
            InitializeComponent();

            ChargerCount();
        }

        // ============================================================
        // CHARGER LES RESUMES
        // ============================================================

        private void ChargerCount()
        {
            using (MySqlConnection con =
                MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    // =================================================
                    // UNE SEULE REQUETE POUR LES 3 COMPTEURS
                    // =================================================

                    string query = @"
                        SELECT
                            SUM(
                                CASE
                                    WHEN statut = 'Terminé'
                                    THEN 1
                                    ELSE 0
                                END
                            ) AS nombre_realise,

                            SUM(
                                CASE
                                    WHEN statut = 'En cours'
                                    THEN 1
                                    ELSE 0
                                END
                            ) AS nombre_attente,

                            COUNT(*) AS nombre_eeg

                        FROM examens_eeg

                        WHERE date_examen = CURDATE()";


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
                                // EEG REALISES
                                // =====================================

                                int nombreRealise =
                                    reader["nombre_realise"] == DBNull.Value
                                        ? 0
                                        : Convert.ToInt32(
                                            reader["nombre_realise"]);

                                lb_realise.Text =
                                    nombreRealise.ToString();


                                // =====================================
                                // EEG EN COURS
                                // =====================================

                                int nombreAttente =
                                    reader["nombre_attente"] == DBNull.Value
                                        ? 0
                                        : Convert.ToInt32(
                                            reader["nombre_attente"]);

                                lb_attente.Text =
                                    nombreAttente.ToString();


                                // =====================================
                                // TOTAL EEG DU JOUR
                                // =====================================

                                int nombreEeg =
                                    reader["nombre_eeg"] == DBNull.Value
                                        ? 0
                                        : Convert.ToInt32(
                                            reader["nombre_eeg"]);

                                lb_eeg_now.Text =
                                    nombreEeg.ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur lors du chargement " +
                        "des statistiques EEG :\n\n" +
                        ex.Message,
                        "Tableau de bord EEG",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}