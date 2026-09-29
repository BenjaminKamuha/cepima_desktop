using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cepima.MesUserCases
{
    public partial class User_personnels_display : UserControl
    {
        private Timer timerRecherche;

        public User_personnels_display()
        {
            InitializeComponent();

            InitialiserRecherche();

            LoadPersonnel();
        }

        // ============================================================
        // INITIALISATION RECHERCHE
        // ============================================================

        private void InitialiserRecherche()
        {
            timerRecherche = new Timer();
            timerRecherche.Interval = 300;
            timerRecherche.Tick += timerRecherche_Tick;

            tb_search_demande.TextChanged -=
                tb_search_demande_TextChanged;

            tb_search_demande.TextChanged +=
                tb_search_demande_TextChanged;
        }

        private void timerRecherche_Tick(
            object sender,
            EventArgs e)
        {
            timerRecherche.Stop();

            LoadPersonnel(
                tb_search_demande.Text);
        }

        // ============================================================
        // CHARGEMENT PERSONNEL
        // ============================================================

        private void LoadPersonnel(params string[] args)
        {
            string recherche = "";

            if (args != null &&
                args.Length > 0 &&
                args[0] != null)
            {
                recherche = args[0].Trim();
            }

            try
            {
                // ----------------------------------------------------
                // PREPARATION AFFICHAGE
                // ----------------------------------------------------

                panel_patient.SuspendLayout();

                panel_patient.Controls.Clear();

                panel_patient.FlowDirection =
                    FlowDirection.LeftToRight;

                panel_patient.WrapContents =
                    true;

                panel_patient.AutoScroll =
                    true;

                panel_patient.Padding =
                    new Padding(10, 10, 8, 10);

                lb_not_found.Visible = false;

                // ----------------------------------------------------
                // REQUETE UNIQUE
                // ----------------------------------------------------

                string query = @"
                    SELECT
                        id_personnel,
                        nom,
                        post_nom
                    FROM personnels
                    WHERE 1 = 1
                ";

                if (recherche.Length > 0)
                {
                    query += @"
                        AND
                        (
                            nom LIKE @search
                            OR post_nom LIKE @search
                            OR prenom LIKE @search
                        )
                    ";
                }

                query += @"
                    ORDER BY
                        nom ASC,
                        post_nom ASC,
                        prenom ASC
                ";

                // ----------------------------------------------------
                // EXECUTION
                // ----------------------------------------------------

                MesClasses.ManagerClasse.request_params.Clear();

                if (recherche.Length > 0)
                {
                    MesClasses.ManagerClasse.request_params.Add(
                        "@search",
                        "%" + recherche + "%");
                }

                int nombre = 0;

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        recherche.Length > 0
                            ? MesClasses.ManagerClasse.request_params
                            : null,
                        true))
                {
                    while (reader.Read())
                    {
                        string idPersonnel =
                            GetString(
                                reader,
                                "id_personnel");

                        string nom =
                            GetString(
                                reader,
                                "nom");

                        string postnom =
                            GetString(
                                reader,
                                "post_nom");

                        CustomRoundedPanel panPersonnel =
                            CreerPanelPersonnel(
                                idPersonnel,
                                nom,
                                postnom);

                        panel_patient.Controls.Add(
                            panPersonnel);

                        nombre++;
                    }
                }

                // ----------------------------------------------------
                // RESULTAT
                // ----------------------------------------------------

                if (nombre == 0)
                {
                    if (recherche.Length > 0)
                    {
                        lb_not_found.Text =
                            "Aucun nom ne correspond au terme de recherche '" +
                            recherche +
                            "'";
                    }
                    else
                    {
                        lb_not_found.Text =
                            "Aucun personnel dans le registre";
                    }

                    panel_patient.Controls.Add(
                        lb_not_found);

                    lb_not_found.Visible = true;
                }
                else
                {
                    ProgressiveDisplay pd =
                        new ProgressiveDisplay(
                            panel_patient,
                            100);

                    pd.Start();
                }

                lb_nombres.Text =
                    nombre.ToString() +
                    (
                        nombre > 1
                            ? " Personnel(s)"
                            : " Personnel"
                    );
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur MySQL lors du chargement du personnel :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du personnel :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                panel_patient.ResumeLayout();
            }
        }

        // ============================================================
        // CREATION CARTE PERSONNEL
        // ============================================================

        private CustomRoundedPanel CreerPanelPersonnel(
            string idPersonnel,
            string nom,
            string postnom)
        {
            CustomRoundedPanel panPersonnel =
                new CustomRoundedPanel();

            panPersonnel.Size =
                new Size(160, 130);

            panPersonnel.BorderRadius =
                8;

            panPersonnel.BorderColor =
                Color.Silver;

            panPersonnel.BorderSize =
                1;

            panPersonnel.Tag =
                idPersonnel;

            panPersonnel.Margin =
                new Padding(10);

            panPersonnel.Padding =
                new Padding(
                    10,
                    10,
                    8,
                    10);

            // ========================================================
            // PHOTO
            // ========================================================

            PictureBox picture =
                MesClasses.ManagerClasse.AddPicture(
                    Properties.Resources.user,
                    new Point(2, 5),
                    new Size(70, 70));

            panPersonnel.Controls.Add(
                picture);

            // ========================================================
            // NOM
            // ========================================================

            Label lbNom =
                MesClasses.ManagerClasse.CustomLabel(
                    nom,
                    new Point(70, 20));

            lbNom.AutoSize =
                true;

            lbNom.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold);

            panPersonnel.Controls.Add(
                lbNom);

            // ========================================================
            // POST-NOM
            // ========================================================

            Label lbPost =
                MesClasses.ManagerClasse.CustomLabel(
                    postnom,
                    new Point(70, 40));

            lbPost.AutoSize =
                true;

            lbPost.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold);

            panPersonnel.Controls.Add(
                lbPost);

            // ========================================================
            // BOUTON DETAIL
            // ========================================================

            RoundedButton btnSuivi =
                MesClasses.ManagerClasse.Rbutton(
                    "Afficher détail",
                    new Point(30, 100),
                    new Size(95, 25),
                    Color.FromArgb(
                        44,
                        123,
                        229),
                    Color.White);

            btnSuivi.BorderRadius =
                4;

            btnSuivi.BorderSize =
                0;

            btnSuivi.BorderColor =
                Color.FromArgb(
                    44,
                    123,
                    229);

            btnSuivi.HoverBackColor =
                Color.FromArgb(
                    7,
                    51,
                    131);

            panPersonnel.Controls.Add(
                btnSuivi);

            // ========================================================
            // EVENEMENT
            // ========================================================

            btnSuivi.Cursor =
                Cursors.Hand;

            btnSuivi.Click +=
                delegate(object sender, EventArgs e)
                {
                    OuvrirDetailPersonnel(
                        idPersonnel);
                };

            return panPersonnel;
        }

        // ============================================================
        // DETAIL PERSONNEL
        // ============================================================

        private void OuvrirDetailPersonnel(
            string idPersonnel)
        {
            try
            {
                Form1.GlobalPanel_main.Visible =
                    false;

                using (
                    MesForms.Personnel.Detail_Test detail =
                        new MesForms.Personnel.Detail_Test(
                            idPersonnel))
                {
                    detail.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Impossible d'ouvrir le détail du personnel :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Form1.GlobalPanel_main.Visible =
                    true;
            }
        }

        // ============================================================
        // RECHERCHE
        // ============================================================

        private void tb_search_demande_TextChanged(
            object sender,
            EventArgs e)
        {
            if (timerRecherche == null)
                return;

            timerRecherche.Stop();
            timerRecherche.Start();
        }

        // ============================================================
        // LOAD DU USERCONTROL
        // ============================================================

        private void User_personnels_display_Load(
            object sender,
            EventArgs e)
        {
        }

        // ============================================================
        // LECTURE SECURISEE
        // ============================================================

        private string GetString(
            MySqlDataReader reader,
            string colonne)
        {
            if (reader[colonne] == DBNull.Value)
                return "";

            return reader[colonne].ToString();
        }
    }
}