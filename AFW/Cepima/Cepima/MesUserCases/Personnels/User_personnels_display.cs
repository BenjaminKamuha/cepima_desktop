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
    public partial class User_personnels_display : UserControl
    {
        public User_personnels_display()
        {
            InitializeComponent();
            LoadPersonnel();
            //MesClasses.ReceptionManager.MoveLabel(label1,panel1);
        }

        private void LoadPersonnel(params string[] args)
        {
            panel_patient.Controls.Clear();

            // Configuration du FlowLayoutPanel
            panel_patient.FlowDirection = FlowDirection.LeftToRight;
            panel_patient.WrapContents = true;
            panel_patient.AutoScroll = true;
            panel_patient.Padding = new Padding(10, 10, 8, 10);

            lb_not_found.Visible = false;

            // =========================================================
            // RECHERCHE D'UN PATIENT
            // =========================================================

            if (args.Length != 0)
            {
                try
                {
                    string query = "SELECT id_personnel, nom, post_nom FROM personnels WHERE nom LIKE @search OR post_nom LIKE @search";

                    MesClasses.ManagerClasse.request_params.Clear();

                    MesClasses.ManagerClasse.request_params.Add("@search","%" + args[0] + "%");

                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                    {
                        int i = 0;

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string idPatient = reader["id_personnel"].ToString();
                                string nom = reader["nom"].ToString();
                                string postnom = reader["post_nom"].ToString();

                                // Création de la carte patient
                                CustomRoundedPanel panPatient =
                                    CreerPanelPatient(
                                        idPatient,
                                        nom,
                                        postnom
                                    );

                                // Ajout au FlowLayoutPanel
                                panel_patient.Controls.Add(panPatient);

                                i++;
                            }

                            reader.Close();

                            lb_nombres.Text =
                                i.ToString() + " Personnel(s) trouvé(s)";

                            ProgressiveDisplay pd =
                                new ProgressiveDisplay(panel_patient, 100);

                            pd.Start();
                        }
                        else
                        {
                            lb_not_found.Text =
                                "Aucun nom ne correspond aux terme de recherche '"
                                + args[0] + "'";

                            panel_patient.Controls.Add(lb_not_found);

                            lb_not_found.Visible = true;

                            lb_nombres.Text =
                                i.ToString() + " Personnel(s) trouvé(s)";
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }

            // =========================================================
            // AFFICHAGE DE TOUS LES PATIENTS
            // =========================================================

            else
            {
                try
                {
                    string query =
                        "SELECT id_personnel, nom, post_nom " +
                        "FROM personnels ORDER BY nom ASC";

                    using (MySqlDataReader reader =
                           MesClasses.ManagerClasse.CRUD(
                               query,
                               null,
                               true))
                    {
                        if (reader.HasRows)
                        {
                            int i = 0;

                            while (reader.Read())
                            {
                                string idPatient =
                                    reader["id_personnel"].ToString();

                                string nom =
                                    reader["nom"].ToString();

                                string postnom =
                                    reader["post_nom"].ToString();

                                // Création de la carte patient
                                CustomRoundedPanel panPatient =
                                    CreerPanelPatient(
                                        idPatient,
                                        nom,
                                        postnom
                                    );

                                // Ajout au FlowLayoutPanel
                                panel_patient.Controls.Add(panPatient);

                                i++;
                            }

                            reader.Close();

                            lb_nombres.Text =
                                i.ToString() + " Personnel(s)";

                            ProgressiveDisplay pd =
                                new ProgressiveDisplay(panel_patient, 100);

                            pd.Start();
                        }
                        else
                        {
                            lb_not_found.Text =
                                "Aucun personnel dans le registre";

                            lb_not_found.Visible = true;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private CustomRoundedPanel CreerPanelPatient(string idPatient, string nom, string postnom)
        {
            // ---------------------------------------------------------
            // PANEL PRINCIPAL
            // ---------------------------------------------------------

            CustomRoundedPanel panPatient = new CustomRoundedPanel();

            panPatient.Size = new Size(160, 130);

            panPatient.BorderRadius = 8;
            panPatient.BorderColor = Color.Silver;
            panPatient.BorderSize = 1;

            panPatient.Tag = idPatient;

            // Marge entre les cartes
            panPatient.Margin = new Padding(10);
            panPatient.Padding = new Padding(10, 10, 8, 10);

            // ---------------------------------------------------------
            // PHOTO
            // ---------------------------------------------------------

            PictureBox picture = MesClasses.ManagerClasse.AddPicture(Properties.Resources.user, new Point(2, 5), new Size(70, 70));

            panPatient.Controls.Add(picture);


            // ---------------------------------------------------------
            // NOM
            // ---------------------------------------------------------

            Label lbNom =
                MesClasses.ManagerClasse.CustomLabel(
                    nom,
                    new Point(70, 20)
                );

            lbNom.AutoSize = true;

            lbNom.Font =
                new System.Drawing.Font(
                    "Calibri",
                    10,
                    FontStyle.Bold
                );

            panPatient.Controls.Add(lbNom);


            // ---------------------------------------------------------
            // POST-NOM
            // ---------------------------------------------------------

            Label lbPost =
                MesClasses.ManagerClasse.CustomLabel(
                    postnom,
                    new Point(70, 40)
                );

            lbPost.AutoSize = true;

            lbPost.Font =
                new System.Drawing.Font(
                    "Calibri",
                    10,
                    FontStyle.Bold
                );

            panPatient.Controls.Add(lbPost);

            // ---------------------------------------------------------
            // BOUTON FICHE DE SUIVI
            // ---------------------------------------------------------

            RoundedButton btnSuivi =
                MesClasses.ManagerClasse.Rbutton(
                    "Afficher détail",
                    new Point(30, 100),
                    new Size(95, 25),
                    Color.FromArgb(44, 123, 229),
                    Color.White
                );

            btnSuivi.BorderRadius = 4;
            btnSuivi.BorderSize = 0;
            btnSuivi.BorderColor =
                Color.FromArgb(44, 123, 229);

            btnSuivi.HoverBackColor =
                Color.FromArgb(7, 51, 131);

            panPatient.Controls.Add(btnSuivi);


            // ---------------------------------------------------------
            // EVENEMENT DU BOUTON
            // ---------------------------------------------------------

            btnSuivi.Click += (e, s) =>
            {
                // Ouverture du formulaire de détail du personnel sélectionné

                Form1.GlobalPanel_main.Visible = false;
                MesForms.Personnel.Detail_Test detail = new MesForms.Personnel.Detail_Test(idPatient);
                detail.ShowDialog();
                Form1.GlobalPanel_main.Visible = true;
            };


            // ---------------------------------------------------------
            // RETOUR DU PANEL
            // ---------------------------------------------------------

            return panPatient;
        }

        private void User_personnels_display_Load(object sender, EventArgs e)
        {

        }

        private void tb_search_demande_TextChanged(object sender, EventArgs e)
        {
            LoadPersonnel(tb_search_demande.Text);
        }
    }
}
