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
    public partial class User_finish_consultation : UserControl
    {
        public User_finish_consultation()
        {
            InitializeComponent();
            LoadConsultations();
        }
        private void LoadConsultations(string recherche = "", string statut = "")
        {
            flow_consultation.Controls.Clear();
            lb_not_found.Visible = false;
            try
            {
                string query = "SELECT d.id_demande,p.id_patient,p.nom,p.post_nom,p.prenom,p.sexe,p.date_naissance,d.statut,d.date_demande FROM demande_service d INNER JOIN patients p ON d.id_patient = p.id_patient JOIN service s ON s.id_service = d.id_service WHERE 1 = 1";

                MesClasses.ManagerClasse.request_params.Clear();


                // =====================================================
                // RECHERCHE DU PATIENT
                // =====================================================

                if (!string.IsNullOrWhiteSpace(recherche))
                {
                    query += "  AND (p.nom LIKE @search OR p.post_nom LIKE @search OR p.prenom LIKE @search)";

                    MesClasses.ManagerClasse.request_params.Add("@search", "%" + recherche + "%");
                }


                // =====================================================
                // FILTRE PAR RERIODE
                // =====================================================
                if (combo_statut.SelectedItem != null) 
                {
                    string periode = combo_statut.SelectedItem.ToString();

                    if (periode == "Aujourd'hui")
                    { 
                        query += " AND DATE(d.date_demande) = CURDATE()"; 
                    } 
                    else if (periode == "Cette semaine")
                    {
                        query += " AND YEARWEEK(d.date_demande, 1) = YEARWEEK(CURDATE(), 1)";
                    } 
                    else if (periode == "Ce mois")
                    {
                        query += " AND YEAR(d.date_demande) = YEAR(CURDATE()) " + "AND MONTH(d.date_demande) = MONTH(CURDATE())";
                    } 

                    // "Tous" => aucune condition supplémentaire 
                }

                query += " AND s.nom = 'Consultation'";

                query += " ORDER BY d.date_demande DESC";


                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                {
                    int i = 0;

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string idDemande = reader["id_patient"].ToString();

                            string nom = reader["nom"].ToString();

                            string postnom = reader["post_nom"].ToString();

                            string prenom = reader["prenom"].ToString();

                            string sexe = reader["sexe"].ToString();

                            DateTime dateNaissance = Convert.ToDateTime(reader["date_naissance"]);

                            int age = MesClasses.ReceptionManager.CalculerAge(dateNaissance);

                            string statutDemande = Convert.ToDateTime(reader["date_demande"]).ToString("dd/MM/yyyy");


                            CreerCarteDemande(
                                idDemande,
                                nom,
                                postnom,
                                prenom,
                                age,
                                sexe,
                                statutDemande
                            );

                            i++;
                        }

                        lb_nombres_consultation.Text = i + " consultation(s)";
                    }
                    else
                    {
                        lb_not_found.Text = "Aucune consultation trouvée";
                        flow_consultation.Controls.Add(lb_not_found);
                        lb_not_found.Visible = true;

                        lb_nombres_consultation.Text = "0 consultation";
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreerCarteDemande(string idDemande, string nom, string postnom, string prenom, int age, string sexe, string date)
        {
            BunifuRoundedPanel panDemande = new BunifuRoundedPanel();
            panDemande.Size = new Size(290, 130);
            panDemande.BorderRadius = 8;
            panDemande.BorderColor = Color.Silver;
            panDemande.BorderSize = 1;
            panDemande.ShadowColor = Color.Gray;
            panDemande.ShadowDepth = 10;
            panDemande.Tag = idDemande;

            // Espace entre les cartes
            panDemande.Margin = new Padding(8, 10, 12, 10);

            PictureBox picture = MesClasses.ManagerClasse.AddPicture(
                Properties.Resources.user,
                new Point(15, 15),
                new Size(60, 60)
            );

            panDemande.Click += (s, e) =>
                {
                    MesUserCases.User_consultation cons = new User_consultation(Convert.ToInt32(idDemande));
                    cons.Dock = DockStyle.Fill;
                    Form1.GlobalPanel_main.Controls.Clear();
                    Form1.GlobalPanel_main.Controls.Add(cons);
                };

            panDemande.Controls.Add(picture);


            Label lbNom = MesClasses.ManagerClasse.CustomLabel(
                nom.ToUpper() + " " + postnom.ToUpper(),
                new Point(90, 15)
            );

            lbNom.AutoSize = true;

            lbNom.Font = new Font(
                "Calibri",
                10,
                FontStyle.Bold
            );

            panDemande.Controls.Add(lbNom);


            Label lbPrenom = MesClasses.ManagerClasse.CustomLabel(
                prenom,
                new Point(90, 37)
            );

            lbPrenom.AutoSize = true;

            lbPrenom.Font = new Font(
                "Calibri",
                10,
                FontStyle.Bold
            );

            panDemande.Controls.Add(lbPrenom);


            // =====================================================
            // AGE + SEXE
            // =====================================================

            Label lbInfos = MesClasses.ManagerClasse.CustomLabel(
                age + " ans - " + sexe,
                new Point(90, 62)
            );

            lbInfos.AutoSize = true;

            lbInfos.Font = new Font(
                "Calibri",
                10,
                FontStyle.Bold
            );

            panDemande.Controls.Add(lbInfos);


            // =====================================================
            // STATUT
            // =====================================================

            Label lbStatut = MesClasses.ManagerClasse.CustomLabel(
                "Date consultation :",
                new Point(15, 95)
            );

            lbStatut.AutoSize = true;

            lbStatut.Font = new Font(
                "Calibri",
                10,
                FontStyle.Bold
            );

            panDemande.Controls.Add(lbStatut);


            Label lbValeurStatut = MesClasses.ManagerClasse.CustomLabel(
                date,
                new Point(140, 95)
            );

            lbValeurStatut.AutoSize = true;

            lbValeurStatut.Font = new Font(
                "Calibri",
                10,
                FontStyle.Bold
            );

            panDemande.Controls.Add(lbValeurStatut);
            flow_consultation.Controls.Add(panDemande);
        }

        private void combo_statut_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadConsultations(tb_recherche_chambre.Text);
        }

        private void tb_recherche_chambre_TextChanged(object sender, EventArgs e)
        {
            LoadConsultations(tb_recherche_chambre.Text);
        }

        private void User_finish_consultation_Load(object sender, EventArgs e)
        {
            combo_statut.Items.Clear();
            combo_statut.Items.Add("Tous");
            combo_statut.Items.Add("Aujourd'hui");
            combo_statut.Items.Add("Cette semaine");
            combo_statut.Items.Add("Ce mois");

            combo_statut.SelectedIndex = 0;
        }
    }
}
