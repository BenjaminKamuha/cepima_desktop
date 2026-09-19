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
    public partial class User_patient_hospitalise : UserControl
    {
        public User_patient_hospitalise()
        {
            InitializeComponent();
            LoadPatientsHospitalises();
        }

        private void LoadPatientsHospitalises(string recherche = "")
        {
            flow_demande.Controls.Clear();
            lb_not_found.Visible = false;
            try
            {
                string query = "SELECT h.id_hospitalisation,p.id_patient,p.nom,p.post_nom,p.prenom,p.sexe,p.date_naissance,h.etat FROM hospitalisation h INNER JOIN patients p ON h.id_patient = p.id_patient  WHERE 1 = 1";

                MesClasses.ManagerClasse.request_params.Clear();


                // =====================================================
                // RECHERCHE DU PATIENT
                // =====================================================

                if (!string.IsNullOrWhiteSpace(recherche))
                {
                    query += "  AND (p.nom LIKE @search OR p.post_nom LIKE @search OR p.prenom LIKE @search)";

                    MesClasses.ManagerClasse.request_params.Add("@search", "%" + recherche + "%");
                }

                query += " AND h.etat = 'Hospitalisé'";

                query += " ORDER BY h.date_entree DESC";


                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                {
                    int i = 0;

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string idHospitalisation = reader["id_hospitalisation"].ToString();
                            string patient = reader["id_patient"].ToString();
                            string nom = reader["nom"].ToString();
                            string postnom = reader["post_nom"].ToString();
                            string prenom = reader["prenom"].ToString();
                            string sexe = reader["sexe"].ToString();

                            DateTime dateNaissance = Convert.ToDateTime(reader["date_naissance"]);

                            int age = MesClasses.ReceptionManager.CalculerAge(dateNaissance);

                            string statutDemande = reader["etat"].ToString();


                            CreerCarteDemande(
                                idHospitalisation,
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

                        lb_nombres.Text = i + " Patient(s)";
                    }
                    else
                    {
                        lb_not_found.Text = "Aucun patient trouvé";
                        flow_demande.Controls.Add(lb_not_found);
                        lb_not_found.Visible = true;

                        lb_nombres.Text = "0 Patient(s)";
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreerCarteDemande(string idDemande, string id_patient, string nom, string postnom, string prenom, int age, string sexe, string statut)
        {
            BunifuRoundedPanel panDemande = new BunifuRoundedPanel();
            panDemande.Size = new Size(290, 130);
            panDemande.BorderRadius = 8;
            panDemande.BorderColor = Color.Silver;
            panDemande.BorderSize = 1;
            panDemande.ShadowColor = Color.Gray;
            panDemande.ShadowDepth = 10;
            panDemande.Tag = new DemandeInfo
            {
                IdDemande = idDemande,
                IdPatient = id_patient
            };

            panDemande.Click += (s, e) =>
            {
                //récuperer les informations stockées
                DemandeInfo info = (DemandeInfo)panDemande.Tag;
                string patient = info.IdPatient;
                string Hospi = info.IdDemande;
                //Afficher le fomulaire de détail de l'hospitalisation
                MesForms.Hospitalisation.Detail_hospitalisation hospi = new MesForms.Hospitalisation.Detail_hospitalisation(patient,Hospi);
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

            if (statut == "Hospitalisé")
            {
                lbValeurStatut.ForeColor =
                    Color.FromArgb(255, 150, 0);
            }
        
            else if (statut == "Sorti")
            {
                lbValeurStatut.ForeColor =
                    Color.FromArgb(0, 180, 80);
            }
          

            panDemande.Controls.Add(lbValeurStatut);


            // =====================================================
            // AJOUT AU FLOWLAYOUTPANEL
            // =====================================================

            flow_demande.Controls.Add(panDemande);
        }

        private void textBox_reseach_TextChanged(object sender, EventArgs e)
        {
            LoadPatientsHospitalises(textBox_reseach.Text);
        }
    }

    public class DemandeInfo
    {
        public string IdDemande { get; set; }
        public string IdPatient { get; set; }
    }
}
