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
    public partial class User_presences : UserControl
    {
        public User_presences()
        {
            InitializeComponent();
            Filter(combo_periode);
            ChargerStatuts();
            StyleDataGridView();
            ChargerPresences();
            ChargerStatistiques();
        }
        private void Filter(ComboBox cbx)
        {
            cbx.Items.Clear();
            cbx.Items.Add("Tous");
            cbx.Items.Add("Aujourd'hui");
            cbx.Items.Add("Cette semaine");
            cbx.Items.Add("Ce mois");

            cbx.SelectedIndex = 0;
        }
        private void ChargerStatuts()
        {
            combo_statut.Items.Clear();

            combo_statut.Items.Add("Tous");
            combo_statut.Items.Add("Présent");
            combo_statut.Items.Add("Retard");
            combo_statut.Items.Add("Absent");

            combo_statut.SelectedIndex = 0;
        }

        private void StyleDataGridView()
        {
            dgvPresences.Columns["colID"].Width = 40;
            dgvPresences.Columns["colPersonnel"].Width = 180;
            dgvPresences.Columns["colFonction"].Width = 130;
            dgvPresences.Columns["colDate"].Width = 90;
            dgvPresences.Columns["colEntreeNormal"].Width = 100;
            dgvPresences.Columns["colEntree"].Width = 90;
            dgvPresences.Columns["colRetard"].Width = 80;
            dgvPresences.Columns["colSortieNormal"].Width = 100;
            dgvPresences.Columns["colSortie"].Width = 90;
            dgvPresences.Columns["colStatut"].Width = 90;
        }
        private void FiltrerStatut()
        {
            if (combo_statut.Text == "Tous")
                return;

            for (int i = dgvPresences.Rows.Count - 1; i >= 0; i--)
            {
                if (dgvPresences.Rows[i].Cells["colStatut"].Value.ToString()
                    != combo_statut.Text)
                {
                    dgvPresences.Rows.RemoveAt(i);
                }
            }
        }
        // charger les présences et les absences dans le datagridview
        private void ChargerPresences()
        {
            dgvPresences.Rows.Clear();

            try
            {
                string jour = DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("fr-FR"));
                jour = char.ToUpper(jour[0]) + jour.Substring(1);

                string query = "SELECT pe.id_personnel,CONCAT(pe.nom, ' ', pe.post_nom, ' ', pe.prenom) AS nom_complet,pe.fonction,pr.date_presence,h.heure_entree_normal,pr.heure_entree,h.heure_sortie_normal,pr.heure_sortie FROM personnels pe LEFT JOIN horaire h ON h.id_personnel = pe.id_personnel AND h.jour_travail = @jour LEFT JOIN presences pr ON pr.id_personnel = pe.id_personnel AND DATE(pr.date_presence) = CURDATE() WHERE pe.actif = 1 ";

                // Recherche
                if (textBox_research.Text.Trim() != "")
                {
                    query += "AND (pe.nom LIKE @recherche OR pe.post_nom LIKE @recherche OR pe.prenom LIKE @recherche)";
                }

                // Aujourd'hui
                if (combo_periode.Text == "Aujourd'hui")
                {
                    query += " AND DATE(pr.date_presence) = CURDATE()";
                }

                // Cette semaine
                if (combo_periode.Text == "Cette semaine")
                {
                    query += "AND YEARWEEK(pr.date_presence, 1) = YEARWEEK(CURDATE(), 1)";
                }

                // Ce mois
                if (combo_periode.Text == "Ce mois")
                {
                    query += "AND MONTH(pr.date_presence) = MONTH(CURDATE()) AND YEAR(pr.date_presence) = YEAR(CURDATE())";
                }

                query += " ORDER BY pr.date_presence DESC, pe.nom ASC";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add("@jour",jour);

                if (textBox_research.Text.Trim() != "")
                {
                    MesClasses.ManagerClasse.request_params.Add("@recherche","%" + textBox_research.Text.Trim() + "%");
                }

                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                {
                    while (reader.Read())
                    {
                        int row = dgvPresences.Rows.Add();

                        dgvPresences.Rows[row].Cells["colID"].Value = reader["id_personnel"];
                        dgvPresences.Rows[row].Cells["colPersonnel"].Value = reader["nom_complet"];
                        dgvPresences.Rows[row].Cells["colFonction"].Value = reader["fonction"];
                        dgvPresences.Rows[row].Cells["colDate"].Value = Convert.ToDateTime(reader["date_presence"]).ToString("dd/MM/yyyy");
                        dgvPresences.Rows[row].Cells["colEntreeNormal"].Value = reader["heure_entree_normal"];
                        dgvPresences.Rows[row].Cells["colEntree"].Value = reader["heure_entree"];
                        dgvPresences.Rows[row].Cells["colSortieNormal"].Value = reader["heure_sortie_normal"];

                        if (reader["heure_sortie"] != DBNull.Value)
                        {
                            dgvPresences.Rows[row].Cells["colSortie"].Value = reader["heure_sortie"];
                        }
                        else
                        {
                            dgvPresences.Rows[row].Cells["colSortie"].Value = "--";
                        }

                        // Statut
                        TimeSpan heureNormale = (TimeSpan)reader["heure_entree_normal"];

                        TimeSpan heureEntree = (TimeSpan)reader["heure_entree"];

                        if (heureEntree > heureNormale)
                        {
                            dgvPresences.Rows[row].Cells["colStatut"].Value = "Retard";
                            int retard = (int)(heureEntree - heureNormale).TotalMinutes;
                            dgvPresences.Rows[row].Cells["colRetard"].Value = retard + " min";
                        }
                        else
                        {
                            dgvPresences.Rows[row].Cells["colStatut"].Value = "Présent";
                            dgvPresences.Rows[row].Cells["colRetard"].Value = "0 min";
                        }
                    }

                    reader.Close();
                }

                FiltrerStatut();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // charger les statistiques
        private void ChargerStatistiques()
        {
            try
            {
                // Total personnel
                string queryTotal = "SELECT COUNT(*) FROM personnels WHERE actif = 1";
                MesClasses.ManagerClasse.request_params.Clear();
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(queryTotal,MesClasses.ManagerClasse.request_params,true))
                {
                    if (reader.Read())
                    {
                        lblTotalPersonnel.Text = reader[0].ToString();
                    }

                    reader.Close();
                }


                // Présences
                string queryPresence = "SELECT COUNT(*) FROM presences WHERE DATE(date_presence) = CURDATE()";
                MesClasses.ManagerClasse.request_params.Clear();
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(queryPresence,MesClasses.ManagerClasse.request_params,true))
                {
                    if (reader.Read())
                    {
                        lblPresence.Text = reader[0].ToString();
                    }

                    reader.Close();
                }


                // Retards
                string queryRetard = "SELECT COUNT(*) FROM presences pr INNER JOIN horaire h ON h.id_personnel = pr.id_personnel WHERE DATE(pr.date_presence) = CURDATE() AND pr.heure_entree > h.heure_entree_normal";

                MesClasses.ManagerClasse.request_params.Clear();
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(queryRetard,MesClasses.ManagerClasse.request_params,true))
                {
                    if (reader.Read())
                    {
                        lblRetard.Text = reader[0].ToString();
                    }

                    reader.Close();
                }


                // Absences
                string queryAbsence = "SELECT COUNT(*) FROM personnels pe LEFT JOIN presences pr ON pr.id_personnel = pe.id_personnel AND DATE(pr.date_presence) = CURDATE() WHERE pe.actif = 1 AND pr.id_presence IS NULL";

                MesClasses.ManagerClasse.request_params.Clear();
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(queryAbsence,MesClasses.ManagerClasse.request_params,true))
                {
                    if (reader.Read())
                    {
                        lblAbsence.Text = reader[0].ToString();
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void textBox_research_TextChanged(object sender, EventArgs e)
        {
            ChargerPresences();
        }

        private void combo_periode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargerPresences();
        }

        private void combo_statut_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargerPresences();
        }
    }
}
