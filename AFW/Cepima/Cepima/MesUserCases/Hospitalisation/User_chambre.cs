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
    public partial class User_chambre : UserControl
    {
        public User_chambre()
        {
            InitializeComponent();

            rb_tous.Checked = true;

            LoadChambres();
        }


        // ============================================================
        // CHARGER LES CHAMBRES
        // ============================================================

        private void LoadChambres(
            string recherche = "",
            string statut = "")
        {
            try
            {
                // =====================================================
                // SUSPENDRE LE LAYOUT
                // =====================================================

                flow_chambres.SuspendLayout();

                flow_chambres.Controls.Clear();

                lb_not_found.Visible = false;


                // =====================================================
                // REQUETE DE BASE
                // =====================================================

                string query = @"
                    SELECT
                        id_chambre,
                        numero_chambre,
                        nombre_lit,
                        tarif_journalier,
                        statut

                    FROM chambre

                    WHERE 1 = 1";


                // =====================================================
                // PARAMETRES
                // =====================================================

                MesClasses.ManagerClasse.request_params.Clear();


                // =====================================================
                // RECHERCHE
                // =====================================================

                if (!string.IsNullOrWhiteSpace(recherche))
                {
                    query += @"
                        AND numero_chambre LIKE @recherche";

                    MesClasses.ManagerClasse.request_params.Add(
                        "@recherche",
                        "%" + recherche.Trim() + "%");
                }


                // =====================================================
                // FILTRE STATUT
                // =====================================================

                if (!string.IsNullOrWhiteSpace(statut))
                {
                    switch (statut)
                    {
                        case "Disponible":

                            query += @"
                                AND statut = 'Disponible'";

                            break;


                        case "Occupée":

                            query += @"
                                AND statut = 'Occupée'";

                            break;


                        case "Suspendue":

                            query += @"
                                AND statut IN
                                (
                                    'Maintenance',
                                    'Hos service'
                                )";

                            break;
                    }
                }


                // =====================================================
                // TRI
                // =====================================================

                query += @"
                    ORDER BY numero_chambre ASC";


                // =====================================================
                // EXECUTION
                // =====================================================

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    int nombreChambres = 0;


                    // =================================================
                    // LECTURE
                    // =================================================

                    while (reader.Read())
                    {
                        // =============================================
                        // ID
                        // =============================================

                        string idChambre =
                            reader["id_chambre"].ToString();


                        // =============================================
                        // NUMERO
                        // =============================================

                        string numero =
                            reader["numero_chambre"].ToString();


                        // =============================================
                        // NOMBRE DE LITS
                        // =============================================

                        string nombre =
                            reader["nombre_lit"].ToString();


                        // =============================================
                        // TARIF
                        // =============================================

                        string tarif = "0";

                        if (reader["tarif_journalier"] !=
                            DBNull.Value)
                        {
                            decimal valeurTarif =
                                Convert.ToDecimal(
                                    reader[
                                        "tarif_journalier"]);

                            tarif =
                                valeurTarif.ToString("N0");
                        }


                        // =============================================
                        // STATUT
                        // =============================================

                        string statutChambre =
                            reader["statut"].ToString();


                        // =============================================
                        // CREATION DE LA CARTE
                        // =============================================

                        CreerCarteChambre(
                            idChambre,
                            numero,
                            nombre,
                            tarif,
                            statutChambre);


                        nombreChambres++;
                    }


                    // =================================================
                    // RESULTAT
                    // =================================================

                    if (nombreChambres == 0)
                    {
                        lb_not_found.Text =
                            "Aucune chambre trouvée";

                        lb_not_found.Visible =
                            true;

                        lb_nombres_chambres.Text =
                            "0 chambre";

                        flow_chambres.Controls.Add(
                            lb_not_found);
                    }
                    else
                    {
                        lb_not_found.Visible =
                            false;

                        lb_nombres_chambres.Text =
                            nombreChambres == 1
                                ? "1 chambre"
                                : nombreChambres +
                                  " chambre(s)";
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des chambres :\n\n" +
                    ex.Message,
                    "Chambres",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des chambres :\n\n" +
                    ex.Message,
                    "Chambres",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                // =====================================================
                // REACTIVER LE LAYOUT
                // =====================================================

                flow_chambres.ResumeLayout(true);
            }
        }


        // ============================================================
        // CREER UNE CARTE CHAMBRE
        // ============================================================

        private void CreerCarteChambre(
            string idChambre,
            string numero,
            string nombre,
            string tarif,
            string statut)
        {
            BunifuRoundedPanel panChambre =
                new BunifuRoundedPanel();


            // ========================================================
            // PROPRIETES DU PANEL
            // ========================================================

            panChambre.Size =
                new Size(
                    290,
                    130);

            panChambre.Margin =
                new Padding(
                    10,
                    10,
                    20,
                    10);

            panChambre.BorderRadius =
                8;

            panChambre.BorderColor =
                Color.Silver;

            panChambre.BorderSize =
                1;

            panChambre.ShadowColor =
                Color.Gray;

            panChambre.ShadowDepth =
                10;

            panChambre.Tag =
                idChambre;


            // ========================================================
            // CLICK SUR LA CARTE
            // ========================================================

            panChambre.Click +=
                delegate(object sender, EventArgs e)
                {
                    MesForms.Hospitalisation.Detail_Chambre
                        detail =
                        new MesForms.Hospitalisation.Detail_Chambre(
                            idChambre);

                    detail.ShowDialog();
                };


            // ========================================================
            // ICONE
            // ========================================================

            PictureBox picture =
                MesClasses.ManagerClasse.AddPicture(
                    Properties.Resources.icone_chambre,
                    new Point(
                        15,
                        15),
                    new Size(
                        60,
                        60));

            picture.Cursor =
                Cursors.Hand;

            panChambre.Controls.Add(
                picture);


            // ========================================================
            // NUMERO CHAMBRE
            // ========================================================

            Label lbNumero =
                MesClasses.ManagerClasse.CustomLabel(
                    "Chambre N° " + numero,
                    new Point(
                        90,
                        15));

            lbNumero.AutoSize =
                true;

            lbNumero.Font =
                new Font(
                    "Calibri",
                    11,
                    FontStyle.Bold);

            lbNumero.Cursor =
                Cursors.Hand;

            panChambre.Controls.Add(
                lbNumero);


            // ========================================================
            // NOMBRE DE LITS
            // ========================================================

            Label lbType =
                MesClasses.ManagerClasse.CustomLabel(
                    "Lit(s) : " + nombre,
                    new Point(
                        90,
                        40));

            lbType.AutoSize =
                true;

            lbType.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Regular);

            lbType.Cursor =
                Cursors.Hand;

            panChambre.Controls.Add(
                lbType);


            // ========================================================
            // TARIF
            // ========================================================

            Label lbTarif =
                MesClasses.ManagerClasse.CustomLabel(
                    "Tarif : " + tarif + "$/Jours",
                    new Point(
                        90,
                        65));

            lbTarif.AutoSize =
                true;

            lbTarif.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Regular);

            lbTarif.Cursor =
                Cursors.Hand;

            panChambre.Controls.Add(
                lbTarif);


            // ========================================================
            // LABEL STATUT
            // ========================================================

            Label lbStatut =
                MesClasses.ManagerClasse.CustomLabel(
                    "Statut :",
                    new Point(
                        15,
                        95));

            lbStatut.AutoSize =
                true;

            lbStatut.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold);

            panChambre.Controls.Add(
                lbStatut);


            // ========================================================
            // VALEUR STATUT
            // ========================================================

            Label lbValeurStatut =
                MesClasses.ManagerClasse.CustomLabel(
                    statut,
                    new Point(
                        75,
                        95));

            lbValeurStatut.AutoSize =
                true;

            lbValeurStatut.Font =
                new Font(
                    "Calibri",
                    10,
                    FontStyle.Bold);


            // ========================================================
            // COULEUR STATUT
            // ========================================================

            if (statut == "Disponible")
            {
                lbValeurStatut.ForeColor =
                    Color.FromArgb(
                        0,
                        180,
                        80);
            }
            else if (statut == "Occupée")
            {
                lbValeurStatut.ForeColor =
                    Color.Red;
            }
            else if (statut == "Reservée")
            {
                lbValeurStatut.ForeColor =
                    Color.Orange;
            }
            else
            {
                lbValeurStatut.ForeColor =
                    Color.Gray;
            }


            lbValeurStatut.Cursor =
                Cursors.Hand;

            panChambre.Controls.Add(
                lbValeurStatut);


            // ========================================================
            // AJOUT DE LA CARTE
            // ========================================================

            flow_chambres.Controls.Add(
                panChambre);
        }


        // ============================================================
        // TOUTES LES CHAMBRES
        // ============================================================

        private void rb_tous_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (!rb_tous.Checked)
                return;

            LoadChambres(
                tb_recherche_chambre.Text,
                "");
        }


        // ============================================================
        // CHAMBRES OCCUPEES
        // ============================================================

        private void rb_occupe_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (!rb_occupe.Checked)
                return;

            LoadChambres(
                tb_recherche_chambre.Text,
                "Occupée");
        }


        // ============================================================
        // CHAMBRES DISPONIBLES
        // ============================================================

        private void rb_libre_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (!rb_libre.Checked)
                return;

            LoadChambres(
                tb_recherche_chambre.Text,
                "Disponible");
        }


        // ============================================================
        // CHAMBRES SUSPENDUES
        // ============================================================

        private void rb_suspendu_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (!rb_suspendu.Checked)
                return;

            LoadChambres(
                tb_recherche_chambre.Text,
                "Suspendue");
        }


        // ============================================================
        // RECHERCHE
        // ============================================================

        private void tb_recherche_chambre_TextChanged(
            object sender,
            EventArgs e)
        {
            string statut = "";


            if (rb_occupe.Checked)
            {
                statut =
                    "Occupée";
            }
            else if (rb_libre.Checked)
            {
                statut =
                    "Disponible";
            }
            else if (rb_suspendu.Checked)
            {
                statut =
                    "Suspendue";
            }


            LoadChambres(
                tb_recherche_chambre.Text,
                statut);
        }


        // ============================================================
        // AJOUTER UNE CHAMBRE
        // ============================================================

        private void bt_add_chambre_Click(
            object sender,
            EventArgs e)
        {
            MesForms.Hospitalisation.Add_chambre chambre =
                new MesForms.Hospitalisation.Add_chambre();

            chambre.ShowDialog();

            // --------------------------------------------------------
            // Recharger après ajout
            // --------------------------------------------------------

            string statut = "";

            if (rb_occupe.Checked)
            {
                statut = "Occupée";
            }
            else if (rb_libre.Checked)
            {
                statut = "Disponible";
            }
            else if (rb_suspendu.Checked)
            {
                statut = "Suspendue";
            }

            LoadChambres(
                tb_recherche_chambre.Text,
                statut);
        }
    }
}