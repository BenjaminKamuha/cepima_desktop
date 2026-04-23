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
    public partial class User_hospitalisation : UserControl
    {
        public User_hospitalisation()
        {
            InitializeComponent();
            LoadHospitalisations();
        }

        // =========================== Charger les hospitalisations ========================
        private void LoadHospitalisations()
        {
            try
            {
                flow_hospitalisation.Controls.Clear();

                string query = "SELECT h.id_hospitalisation,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS Patient,c.nom_centre AS Centre,h.date_entree,h.date_sortie,h.motif,h.etat FROM hospitalisation h INNER JOIN patients p ON p.id_patient = h.id_patient INNER JOIN centres c ON c.id_centre = h.id_centre ORDER BY h.date_entree DESC";
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, null, true))
                {
                    while (reader.Read())
                    {
                        Panel card = CreateHospitalisationCard(
                            reader["id_hospitalisation"].ToString(),
                            reader["Patient"].ToString(),
                            reader["Centre"].ToString(),
                            reader["date_entree"].ToString(),
                            reader["date_sortie"].ToString(),
                            reader["motif"].ToString(),
                            reader["etat"].ToString()
                        );

                        flow_hospitalisation.Controls.Add(card);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        // =============================Méthode pour créer une carte hospitalisation (Panel dynamique ) =============================
        private Panel CreateHospitalisationCard(string id,string patient,string centre,string dateEntree,string dateSortie,string motif,string etat)
        {
            Panel pan = new Panel();
            pan.Size = new Size(260, 160);
            pan.BorderStyle = BorderStyle.FixedSingle;
            pan.BackColor = Color.White;
            pan.Margin = new Padding(10);

            // Patient
            Label lbPatient = new Label();
            lbPatient.Text = "Patient : " + patient;
            lbPatient.Location = new Point(10, 10);
            lbPatient.AutoSize = true;
            pan.Controls.Add(lbPatient);

            // Centre
            Label lbCentre = new Label();
            lbCentre.Text = "Centre : " + centre;
            lbCentre.Location = new Point(10, 30);
            lbCentre.AutoSize = true;
            pan.Controls.Add(lbCentre);

            // Date entrée
            Label lbEntree = new Label();
            lbEntree.Text = "Entrée : " + dateEntree;
            lbEntree.Location = new Point(10, 50);
            pan.Controls.Add(lbEntree);

            // Date sortie
            Label lbSortie = new Label();
            lbSortie.Text = "Sortie : " + (string.IsNullOrEmpty(dateSortie) ? "-" : dateSortie);
            lbSortie.Location = new Point(10, 70);
            pan.Controls.Add(lbSortie);

            // Motif
            Label lbMotif = new Label();
            lbMotif.Text = "Motif : " + motif;
            lbMotif.Location = new Point(10, 90);
            pan.Controls.Add(lbMotif);

            // Etat
            Label lbEtat = new Label();
            lbEtat.Text = "Etat : " + etat;
            lbEtat.Location = new Point(10, 110);
            lbEtat.ForeColor = etat == "Sorti" ? Color.Green : Color.Red;
            pan.Controls.Add(lbEtat);

            // Bouton Détails
            Button btnDetail = new Button();
            btnDetail.Text = "Détails";
            btnDetail.Size = new Size(80, 25);
            btnDetail.Location = new Point(10, 130);
            btnDetail.Tag = id;

            btnDetail.Click += (s, e) =>
            {
                MessageBox.Show("Détails ID : " + id);
                User_detail_hospitalisation details = new User_detail_hospitalisation(id);
                details.Dock = DockStyle.Fill;
                panel_details.Controls.Clear();
                panel_details.Controls.Add(details);
                // ouvrir formulaire détail ici
            };

            pan.Controls.Add(btnDetail);

            // Bouton Sortie
            Button btnSortie = new Button();
            btnSortie.Text = "Sortie";
            btnSortie.Size = new Size(80, 25);
            btnSortie.Location = new Point(100, 130);
            btnSortie.BackColor = Color.Orange;
            btnSortie.ForeColor = Color.White;
            btnSortie.Tag = id;

            // désactiver si déjà sorti
            if (etat == "Sorti")
                btnSortie.Enabled = false;

            btnSortie.Click += (s, e) =>
            {
                DialogResult result = MessageBox.Show("Confirmer la sortie ?", "Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    //  UPDATE hospitalisation
                    SortirPatient(id);
                    LoadHospitalisations();
                }
            };

            pan.Controls.Add(btnSortie);

            return pan;
        }
        // =========================== Enregistrer la sortie du patient ================================================
        // cette méthode va : 
        //=> Mettre fin à l'hospitalisation
        //=>Cloturer l'affectation
        //=>Libérer la chambre
        //=>Tous faire dans une seule transaction
        public static void SortirPatient(string idHospitalisation)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                MySqlTransaction trans = con.BeginTransaction();

                try
                {
                    //  Mettre à jour hospitalisation
                    string q1 = @"UPDATE hospitalisation SET date_sortie = CURDATE(),etat = 'Sorti'WHERE id_hospitalisation = @id";
                    MySqlCommand cmd1 = new MySqlCommand(q1, con, trans);
                    cmd1.Parameters.AddWithValue("@id", idHospitalisation);
                    cmd1.ExecuteNonQuery();

                    // Récupérer la chambre actuelle
                    string qGet = "SELECT id_chambre FROM affectation_chambre WHERE id_hospitalisation = @id AND date_fin IS NULL LIMIT 1";
                    MySqlCommand cmdGet = new MySqlCommand(qGet, con, trans);
                    cmdGet.Parameters.AddWithValue("@id", idHospitalisation);

                    object result = cmdGet.ExecuteScalar();

                    if (result != null)
                    {
                        int idChambre = Convert.ToInt32(result);

                        //Clôturer affectation
                        string q2 = "UPDATE affectation_chambre SET date_fin = CURDATE() WHERE id_hospitalisation = @id AND date_fin IS NULL";
                        MySqlCommand cmd2 = new MySqlCommand(q2, con, trans);
                        cmd2.Parameters.AddWithValue("@id", idHospitalisation);
                        cmd2.ExecuteNonQuery();

                        //Libérer la chambre
                        string q3 = "UPDATE chambres SET statut = 'Libre' WHERE id_chambres = @idChambre";
                        MySqlCommand cmd3 = new MySqlCommand(q3, con, trans);
                        cmd3.Parameters.AddWithValue("@idChambre", idChambre);
                        cmd3.ExecuteNonQuery();
                    }

                    //Valider transaction
                    trans.Commit();

                    MessageBox.Show("Patient sorti avec succès ");
                }
                catch (Exception ex)
                {
                    // Annuler tout s'il y a erreur
                    trans.Rollback();
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }
    }
}
