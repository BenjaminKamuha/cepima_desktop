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
    public partial class Detail_Test : Form
    {
        string personnelID;
        public static Button btRefresh { get; set; }
        public Detail_Test(string id_personnel)
        {
            InitializeComponent();
            this.personnelID = id_personnel;
            btRefresh = bt_refresh;
            bt_refresh.Click += bt_refresh_Click;
            LoadDetailsPersonnels();
        }

        void bt_refresh_Click(object sender, EventArgs e)
        {
            LoadDetailsPersonnels();
            ChargerSituationSalariale();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadDetailsPersonnels()
        {
            try
            {
                string querySelect = "SELECT id_personnel,CONCAT('PER',' - ','CEP','/',YEAR(p.date_embauche)) AS dossier,nom,post_nom,prenom,sexe,date_naissance,date_embauche,fonction,p.telephone,p.adresse,p.situation_familliale,p.actif AS statut,nom_centre FROM personnels p JOIN centres c ON c.id_centre = p.id_centre WHERE id_personnel = @id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id", personnelID);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(querySelect, MesClasses.ManagerClasse.request_params, true))
                {
                    while (reader.Read())
                    {
                        lb_nom.Text = reader["nom"].ToString();
                        lb_postnom.Text = reader["post_nom"].ToString();
                        lb_prenom.Text = reader["prenom"].ToString();
                        lb_fonction.Text = reader["fonction"].ToString();
                        lb_genre.Text = reader["sexe"].ToString();
                        lb_dossier.Text = reader["dossier"].ToString();
                        lb_date_embauche.Text = Convert.ToDateTime(reader["date_embauche"]).ToString("dd/MM/yyyy");
                        lb_date.Text = Convert.ToDateTime(reader["date_naissance"]).ToString("dd/MM/yyyy");
                        lb_adresse.Text = reader["adresse"].ToString();
                        lb_phone.Text = reader["telephone"].ToString();
                        lb_centre.Text = reader["nom_centre"].ToString();
                        lb_sifa.Text = reader["situation_familliale"].ToString();
                        DateTime dt = Convert.ToDateTime(reader["date_naissance"]);
                        int age = MesClasses.ReceptionManager.CalculerAge(dt);
                        //int  statut = Convert.ToInt32(reader["statut"]);
                        lb_age.Text = age.ToString() + " ans";

                        if (reader["statut"] != DBNull.Value && Convert.ToBoolean(reader["statut"]) == true)
                        {
                            lb_statut.Text = "Actif";
                            pn_statut.BackColor = Color.FromArgb(27, 94, 32);
                            lb_statut.ForeColor = Color.White;
                        }
                        else
                        {
                            lb_statut.Text = "Non ";
                            pn_statut.BackColor = Color.Gray;
                            lb_statut.ForeColor = Color.White;
                        }
                    }
                    reader.Close();
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur de chargement de données : " + ex.Message);
            }
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            MesForms.Personnel.Update_personnel update = new Update_personnel(personnelID);
            update.ShowDialog();
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    var resul = MessageBox.Show("Supprimer le personnel", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resul == DialogResult.Yes)
                    {
                        string query = "DELETE FROM personnel WHERE id = @id";
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", personnelID);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Suppression réussie !!");
                        this.Close();
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erreur de suppression : " + ex.Message);
                }
            }
        }

        private void bt_salaire_Click(object sender, EventArgs e)
        {
            MesForms.Personnel.Add_salaire salaire = new Add_salaire(personnelID);
            salaire.ShowDialog();
        }

        private void Detail_Test_Load(object sender, EventArgs e)
        {
            ChargerSituationSalariale();
            ChargerPresence();
        }

        private void bt_ad_prime_Click(object sender, EventArgs e)
        {
            MesForms.Personnel.Ajouter_prime prime = new Ajouter_prime(personnelID);
            prime.ShowDialog();
        }

        private void bt_add_retenue_Click(object sender, EventArgs e)
        {
            MesForms.Personnel.Ajouter_retenue retenue = new Ajouter_retenue(personnelID);
            retenue.ShowDialog();
        }

        private void roundedButton4_Click(object sender, EventArgs e)
        {
            MesForms.Personnel.Ajouter_avance avance = new Ajouter_avance(personnelID);
            avance.ShowDialog();
        }

        private void ChargerSituationSalariale()
        {
            try
            {
                string query = @"
            SELECT
                s.id_salaire,
                s.mois,
                s.salaire_base,
                s.date_paiement,
                s.statut,

                COALESCE(
                    (SELECT SUM(pr.montant)
                     FROM prime pr
                     WHERE pr.id_salaire = s.id_salaire),
                    0
                ) AS total_primes,

                COALESCE(
                    (SELECT SUM(r.montant)
                     FROM retenue r
                     WHERE r.id_salaire = s.id_salaire),
                    0
                ) AS total_retenues,

                COALESCE(
                    (SELECT SUM(a.montant)
                     FROM avances_salaire a
                     WHERE a.id_salaire = s.id_salaire),
                    0
                ) AS total_avances

            FROM salaires s

            WHERE s.id_personnel = @id_personnel

            ORDER BY s.id_salaire DESC

            LIMIT 1";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_personnel",
                    personnelID
                );

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    if (reader.Read())
                    {
                        decimal salaireBase =
                            Convert.ToDecimal(reader["salaire_base"]);

                        decimal totalPrimes =
                            Convert.ToDecimal(reader["total_primes"]);

                        decimal totalRetenues =
                            Convert.ToDecimal(reader["total_retenues"]);

                        decimal totalAvances =
                            Convert.ToDecimal(reader["total_avances"]);

                        // ==============================
                        // AFFICHAGE
                        // ==============================

                        lblSalaireBase.Text =
                            salaireBase.ToString("N2") + " $";

                        lblTotalPrimes.Text =
                            totalPrimes.ToString("N2") + " $";

                        lblTotalRetenues.Text =
                            totalRetenues.ToString("N2") + " $";

                        lblTotalAvances.Text =
                            totalAvances.ToString("N2") + " $";

                        // ==============================
                        // SALAIRE NET
                        // ==============================

                        decimal salaireNet =
                            salaireBase
                            + totalPrimes
                            - totalRetenues
                            - totalAvances;

                        lblSalaireNet.Text =
                            salaireNet.ToString("N2") + " $";

                        // ==============================
                        // INFORMATIONS SUPPLEMENTAIRES
                        // ==============================

                        //lblMoisSalaire.Text =
                        //    reader["mois"].ToString();

                        //lblStatutSalaire.Text =
                        //    reader["statut"].ToString();
                    }
                    else
                    {
                        // Aucun salaire enregistré
                        lblSalaireBase.Text = "0.00 $";
                        lblTotalPrimes.Text = "0.00 $";
                        lblTotalRetenues.Text = "0.00 $";
                        lblTotalAvances.Text = "0.00 $";
                        lblSalaireNet.Text = "0.00 $";

                        //lblMoisSalaire.Text = "Aucun salaire";
                        //lblStatutSalaire.Text = "-";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement de la situation salariale :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ChargerPresence()
        {
            try
            {
                // =========================================================
                // 1. RECHERCHER LA PRÉSENCE D'AUJOURD'HUI
                // =========================================================

                string queryAujourdHui = @"
            SELECT 
                heure_entree,
                heure_sortie,
                statut
            FROM presences
            WHERE id_personnel = @id_personnel
              AND date_presence = CURDATE()
            ORDER BY id_presence DESC
            LIMIT 1";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_personnel",
                    personnelID
                );

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        queryAujourdHui,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    if (reader.Read())
                    {
                        // ==============================
                        // STATUT
                        // ==============================

                        string statut = reader["statut"].ToString();

                        lblStatutPresence.Text =
                            statut + " aujourd'hui";


                        // ==============================
                        // HEURE D'ENTRÉE
                        // ==============================

                        if (reader["heure_entree"] != DBNull.Value)
                        {
                            TimeSpan heureEntree =
                                (TimeSpan)reader["heure_entree"];

                            lblHeureEntree.Text =
                                heureEntree.ToString(@"hh\:mm");
                        }
                        else
                        {
                            lblHeureEntree.Text = "--";
                        }


                        // ==============================
                        // HEURE DE SORTIE
                        // ==============================

                        if (reader["heure_sortie"] != DBNull.Value)
                        {
                            TimeSpan heureSortie =
                                (TimeSpan)reader["heure_sortie"];

                            lblHeureSortie.Text =
                                heureSortie.ToString(@"hh\:mm");
                        }
                        else
                        {
                            lblHeureSortie.Text = "--";
                        }
                    }
                    else
                    {
                        // Aucun enregistrement aujourd'hui

                        lblStatutPresence.Text =
                            "Absent aujourd'hui";

                        lblHeureEntree.Text = "--";
                        lblHeureSortie.Text = "--";
                    }
                }


                // =========================================================
                // 2. RECHERCHER LA DERNIÈRE PRÉSENCE
                // =========================================================

                string queryDernierePresence = @"
            SELECT date_presence
            FROM presences
            WHERE id_personnel = @id_personnel
            ORDER BY date_presence DESC, id_presence DESC
            LIMIT 1";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_personnel",
                    personnelID
                );

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        queryDernierePresence,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    if (reader.Read())
                    {
                        if (reader["date_presence"] != DBNull.Value)
                        {
                            DateTime datePresence =
                                Convert.ToDateTime(reader["date_presence"]);

                            lblDernierePresence.Text =
                                datePresence.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            lblDernierePresence.Text = "--";
                        }
                    }
                    else
                    {
                        lblDernierePresence.Text = "--";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des présences :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void bt_add_salaire_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"
            SELECT COUNT(*)
            FROM salaires
            WHERE id_personnel = @id_personnel";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_personnel",
                    personnelID
                );

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    if (reader.Read())
                    {
                        int nombreSalaires =
                            Convert.ToInt32(reader[0]);

                        // =========================================
                        // AUCUN SALAIRE
                        // =========================================

                        if (nombreSalaires == 0)
                        {
                            MessageBox.Show(
                                "Aucun salaire n'est enregistré pour ce personnel.",
                                "Historique des salaires",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                            return;
                        }
                    }
                }

                // =========================================
                // SALAIRE(S) EXISTANT(S)
                // =========================================

                MesForms.Personnel.Detail_salaire detail =
                    new MesForms.Personnel.Detail_salaire(personnelID);

                detail.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la vérification des salaires :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void customRoundedPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"
            SELECT COUNT(*)
            FROM presences
            WHERE id_personnel = @id_personnel";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@id_personnel",
                    personnelID
                );

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    if (reader.Read())
                    {
                        int nombrePresences =
                            Convert.ToInt32(reader[0]);

                        // =========================================
                        // AUCUNE PRÉSENCE
                        // =========================================

                        if (nombrePresences == 0)
                        {
                            MessageBox.Show(
                                "Aucune présence n'est enregistrée pour ce personnel.",
                                "Historique des présences",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                            return;
                        }
                    }
                }

                // =========================================
                // IL EXISTE DES PRÉSENCES
                // =========================================

                MesForms.Personnel.Detail_presence presence =
                    new MesForms.Personnel.Detail_presence(personnelID);

                presence.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la vérification des présences :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
