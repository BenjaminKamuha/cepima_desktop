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
    public partial class User_Termine_hospi : UserControl
    {
        public User_Termine_hospi()
        {
            InitializeComponent();
            LoadDemandes();
            rb_tous.Checked = true;
        }

        // charger les demandes pour les patients
        private void LoadDemandes(string recherche = "",string statut = "")
        {
            flow_demande.Controls.Clear();
            lb_not_found.Visible = false;
            try
            {
                string query = "SELECT d.id_demande,p.id_patient,p.nom,p.post_nom,p.prenom,p.sexe,p.date_naissance,d.statut FROM demande_service d INNER JOIN patients p ON d.id_patient = p.id_patient JOIN service s ON s.id_service = d.id_service WHERE 1 = 1";

                MesClasses.ManagerClasse.request_params.Clear();


                // =====================================================
                // RECHERCHE DU PATIENT
                // =====================================================

                if (!string.IsNullOrWhiteSpace(recherche))
                {
                    query += "  AND (p.nom LIKE @search OR p.post_nom LIKE @search OR p.prenom LIKE @search)";

                    MesClasses.ManagerClasse.request_params.Add("@search","%" + recherche + "%");
                }


                // =====================================================
                // FILTRE STATUT
                // =====================================================

                if (!string.IsNullOrWhiteSpace(statut))
                {
                    query += " AND d.statut = @statut";

                    MesClasses.ManagerClasse.request_params.Add("@statut",statut);
                }

                query += " AND s.nom = 'Hospitalisation'";

                query += " ORDER BY d.date_demande DESC";


                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                {
                    int i = 0;

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string idDemande = reader["id_demande"].ToString();
                            string patient = reader["id_patient"].ToString();
                            string nom = reader["nom"].ToString();
                            string postnom = reader["post_nom"].ToString();
                            string prenom = reader["prenom"].ToString();
                            string sexe = reader["sexe"].ToString();

                            DateTime dateNaissance = Convert.ToDateTime(reader["date_naissance"]);

                            int age = MesClasses.ReceptionManager.CalculerAge(dateNaissance);

                            string statutDemande = reader["statut"].ToString();


                            CreerCarteDemande(
                                idDemande,
                                patient,
                                nom,
                                postnom,
                                prenom,
                                age,
                                sexe,
                                statutDemande
                            );

                            i++;
                        }

                        lb_nombres.Text = i + " demande(s)";
                    }
                    else
                    {
                        lb_not_found.Text = "Aucune demande trouvée";
                        flow_demande.Controls.Add(lb_not_found);
                        lb_not_found.Visible = true;

                        lb_nombres.Text = "0 demande";
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur : " + ex.Message,"Erreur",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void CreerCarteDemande(string idDemande,string id_patient,string nom,string postnom,string prenom,int age,string sexe,string statut)
        {
            BunifuRoundedPanel panDemande = new BunifuRoundedPanel();
            panDemande.Size = new Size(290, 130);
            panDemande.BorderRadius = 8;
            panDemande.BorderColor = Color.Silver;
            panDemande.BorderSize = 1;
            panDemande.ShadowColor = Color.Gray;
            panDemande.ShadowDepth = 10;
            panDemande.Tag = id_patient;

            panDemande.Click += (s, e) =>
                {
                    //Afficher le fomulaire d'affectation du patient dans la chambre
                    MesForms.Hospitalisation.Hospitalisation hospi = new MesForms.Hospitalisation.Hospitalisation(id_patient);
                    hospi.ShowDialog();
                };
            // Espace entre les cartes
            panDemande.Margin = new Padding(8, 10, 12, 10);

            PictureBox picture = MesClasses.ManagerClasse.AddPicture(
                Properties.Resources.user,
                new Point(15, 15),
                new Size(60, 60)
            );

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
                "Statut :",
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
                statut,
                new Point(75, 95)
            );

            lbValeurStatut.AutoSize = true;

            lbValeurStatut.Font = new Font(
                "Calibri",
                10,
                FontStyle.Bold
            );


            // =====================================================
            // COULEUR DU STATUT
            // =====================================================

            if (statut == "Demandée")
            {
                lbValeurStatut.ForeColor =
                    Color.FromArgb(255, 150, 0);
            }
            else if (statut == "Acceptée")
            {
                lbValeurStatut.ForeColor =
                    Color.FromArgb(44, 123, 229);
            }
            else if (statut == "En cours")
            {
                lbValeurStatut.ForeColor =
                    Color.FromArgb(150, 100, 220);
            }
            else if (statut == "Terminée")
            {
                lbValeurStatut.ForeColor =
                    Color.FromArgb(0, 180, 80);
            }
            else if (statut == "Annulée")
            {
                lbValeurStatut.ForeColor =
                    Color.Red;
            }

            panDemande.Controls.Add(lbValeurStatut);


            // =====================================================
            // AJOUT AU FLOWLAYOUTPANEL
            // =====================================================

            flow_demande.Controls.Add(panDemande);
        }

        private void rb_tous_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_tous.Checked)
            {
                LoadDemandes(
                    textBox_reseach.Text,
                    ""
                );
            }
        }

        private void rb_demandees_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_demandees.Checked)
            {
                LoadDemandes(
                    textBox_reseach.Text,
                    "Demandée"
                );
            }
        }

        private void rb_terminees_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_terminees.Checked)
            {
                LoadDemandes(
                    textBox_reseach.Text,
                    "Terminée"
                );
            }
        }

        private void rb_annulees_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_annulees.Checked)
            {
                LoadDemandes(
                    textBox_reseach.Text,
                    "Annulée"
                );
            }
        }

        private void textBox_reseach_TextChanged(object sender, EventArgs e)
        {
            string statut = "";

            if (rb_demandees.Checked)
            {
                statut = "Demandée";
            }
            else if (rb_terminees.Checked)
            {
                statut = "Terminée";
            }
            else if (rb_annulees.Checked)
            {
                statut = "Annulée";
            }

            LoadDemandes(
                textBox_reseach.Text,
                statut
            );
        }
    }
}
