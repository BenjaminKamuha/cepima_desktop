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
namespace Cepima.MesForms.Personnel
{
    public partial class Detail_presence : Form
    {
        private string idPersonnel;
        public Detail_presence(string id_personnel)
        {
            InitializeComponent();
            this.idPersonnel = id_personnel;
        }

        private void Detail_presence_Load(object sender, EventArgs e)
        {
            ChargerNomPersonnel();
            ChargerHistoriquePresences();
        }
        private void ChargerNomPersonnel()
        {
            try
            {
                string query = @"
            SELECT
                nom,
                post_nom,
                prenom,sexe,date_naissance
            FROM personnels
            WHERE id_personnel = @id_personnel";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_personnel",
                    idPersonnel
                );

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    if (reader.Read())
                    {
                        lb_nom.Text = reader["nom"].ToString();
                        lb_post_nom.Text = reader["post_nom"].ToString();
                        DateTime date = Convert.ToDateTime(reader["date_naissance"]);
                        int age = MesClasses.ReceptionManager.CalculerAge(date);
                        lb_age.Text = age.ToString() + " - " + reader["sexe"];
                           
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du personnel :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ChargerHistoriquePresences()
        {
            try
            {
                dgv_presences.Rows.Clear();

                string query = @"
            SELECT
                id_presence,
                date_presence,
                heure_entree,
                heure_sortie,
                statut
            FROM presences
            WHERE id_personnel = @id_personnel
            ORDER BY date_presence DESC";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_personnel",
                    idPersonnel
                );

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    while (reader.Read())
                    {
                        int ligne =
                            dgv_presences.Rows.Add();

                        // ==============================
                        // DATE
                        // ==============================

                        if (reader["date_presence"] != DBNull.Value)
                        {
                            DateTime date =
                                Convert.ToDateTime(
                                    reader["date_presence"]);

                            dgv_presences.Rows[ligne]
                                .Cells["colDate"]
                                .Value =
                                date.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            dgv_presences.Rows[ligne]
                                .Cells["colDate"]
                                .Value = "-";
                        }


                        // ==============================
                        // HEURE D'ENTRÉE
                        // ==============================

                        if (reader["heure_entree"] != DBNull.Value)
                        {
                            TimeSpan heureEntree =
                                (TimeSpan)reader["heure_entree"];

                            dgv_presences.Rows[ligne]
                                .Cells["colEntree"]
                                .Value =
                                heureEntree.ToString(@"hh\:mm");
                        }
                        else
                        {
                            dgv_presences.Rows[ligne]
                                .Cells["colEntree"]
                                .Value = "--";
                        }


                        // ==============================
                        // HEURE DE SORTIE
                        // ==============================

                        if (reader["heure_sortie"] != DBNull.Value)
                        {
                            TimeSpan heureSortie =
                                (TimeSpan)reader["heure_sortie"];

                            dgv_presences.Rows[ligne]
                                .Cells["colSortie"]
                                .Value =
                                heureSortie.ToString(@"hh\:mm");
                        }
                        else
                        {
                            dgv_presences.Rows[ligne]
                                .Cells["colSortie"]
                                .Value = "--";
                        }


                        // ==============================
                        // STATUT
                        // ==============================

                        if (reader["statut"] != DBNull.Value)
                        {
                            dgv_presences.Rows[ligne]
                                .Cells["colStatut"]
                                .Value =
                                reader["statut"].ToString();
                        }
                        else
                        {
                            dgv_presences.Rows[ligne]
                                .Cells["colStatut"]
                                .Value = "-";
                        }


                        // ==============================
                        // ID CACHÉ
                        // ==============================

                        dgv_presences.Rows[ligne].Tag =
                            Convert.ToInt32(
                                reader["id_presence"]);
                    }
                }


                // ==============================
                // SI AUCUNE PRÉSENCE
                // ==============================

                if (dgv_presences.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Aucune présence enregistrée pour ce personnel.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement de l'historique des présences :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
