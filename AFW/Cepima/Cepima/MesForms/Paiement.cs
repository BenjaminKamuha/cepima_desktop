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
using Cepima.Data;

namespace Cepima.MesForms
{
    public partial class Paiement : Form
    {
        Patient
        public Paiement()
        {
            InitializeComponent();
            ChargerRecus();
        }
        l
        private void Create_pan_recu(string idPaiement, string idPatient, string patient, string age, string datePaiement, string statut, string montant)
        {
            BunifuRoundedPanel panRecu = new BunifuRoundedPanel();
            panRecu.Size = new Size(290, 155);
            panRecu.BorderRadius = 8;
            panRecu.ShadowDepth = 10;
            panRecu.BorderColor = Color.Silver;
            panRecu.BorderSize = 1;
            panRecu.Margin = new System.Windows.Forms.Padding(10);
            panRecu.BackColor = Color.White;

            Label lbPatient = MesClasses.ManagerClasse.CustomLabel(patient, new Point(12, 12));
            lbPatient.AutoSize = true;
            lbPatient.Font = new Font("Calibri", 11, FontStyle.Bold);
            panRecu.Controls.Add(lbPatient);

            Label lbAge = MesClasses.ManagerClasse.CustomLabel("Âge : " + age + " ans", new Point(12, 40));
            lbAge.AutoSize = true;
            panRecu.Controls.Add(lbAge);

            Label lbDate = MesClasses.ManagerClasse.CustomLabel("Paiement : " + datePaiement, new Point(12, 63));
            lbDate.AutoSize = true;
            panRecu.Controls.Add(lbDate);

            Label lbStatut = MesClasses.ManagerClasse.CustomLabel("Statut : " + statut, new Point(12, 86));
            lbStatut.AutoSize = true;
            lbStatut.Font = new Font("Calibri", 9, FontStyle.Bold);
            lbStatut.ForeColor = statut == "Payé" ? Color.Green : Color.DarkOrange;
            panRecu.Controls.Add(lbStatut);

            Label lbMontant = MesClasses.ManagerClasse.CustomLabel("Montant : " + montant + " $", new Point(12, 108));
            lbMontant.AutoSize = true;
            lbMontant.Font = new Font("Calibri", 9, FontStyle.Bold);
            panRecu.Controls.Add(lbMontant);

            Button btnImprimer = new Button();
            btnImprimer.Text = "Imprimer";
            btnImprimer.Size = new Size(85, 28);
            btnImprimer.Location = new Point(160, 115);
            btnImprimer.Cursor = Cursors.Hand;

            btnImprimer.Click += delegate(object sender, EventArgs e)
            {
                try
                {
                    int paiementId = Convert.ToInt32(idPaiement);
                    MesForms.FormRecu frm = new MesForms.FormRecu(paiementId);
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'ouverture du reçu :\n" + ex.Message, "Reçu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            panRecu.Controls.Add(btnImprimer);
            pnl_ambulatoire.Controls.Add(panRecu);
            //MesClasses.ManagerClasse.AddControl(pnl_examen, panRecu, 10, 10);
        }

        // charger les reçus de paiements
        private void ChargerRecus()
        {
            try
            {
                pnl_ambulatoire.SuspendLayout();
                pnl_ambulatoire.Controls.Clear();
                pnl_ambulatoire.FlowDirection =
                  FlowDirection.LeftToRight;

                pnl_ambulatoire.WrapContents = true;
                pnl_ambulatoire.AutoScroll = true;
                pnl_ambulatoire.Padding = new Padding(10, 10, 8, 10);

                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {

                    string recherche = tb_search_demande.Text.Trim();

                    string query = @"
                                SELECT pa.id_paiement, pa.id_facture, pa.date_paiement, pa.montant, pa.type_paiement,
                                       f.statut, p.id_patient, p.nom, p.post_nom, p.prenom,
                                       TIMESTAMPDIFF(YEAR, p.date_naissance, CURDATE()) AS age
                                FROM paiement pa
                                INNER JOIN facture f ON pa.id_facture = f.id_facture
                                INNER JOIN patients p ON f.id_patient = p.id_patient
                                WHERE (@recherche = ''
                                    OR p.nom LIKE @mot
                                    OR p.post_nom LIKE @mot
                                    OR p.prenom LIKE @mot)
                                ORDER BY pa.date_paiement DESC, pa.id_paiement DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@recherche", recherche);
                        cmd.Parameters.AddWithValue("@mot", "%" + recherche + "%");

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Create_pan_recu(
                                    reader["id_paiement"].ToString(),
                                    reader["id_patient"].ToString(),
                                    (reader["nom"] + " " + reader["post_nom"] + " " + reader["prenom"]).ToString().Trim(),
                                    reader["age"] == DBNull.Value ? "" : reader["age"].ToString(),
                                    Convert.ToDateTime(reader["date_paiement"]).ToString("dd/MM/yyyy"),
                                    reader["statut"].ToString(),
                                    reader["montant"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des reçus :\n" + ex.Message, "Reçus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pnl_ambulatoire.ResumeLayout(true);
            }
        }


//        private void bt_confirmer_Click(object sender, EventArgs e)
//        {
//            Database db = new Database();

//            using (MySqlConnection con = db.GetConnection())
//                {
//                    int id_paiement = 0;

//                    con.Open();
//                    MySqlTransaction tr = con.BeginTransaction();

//                    try
//                    {
                
//                        // Enregistrement du paiement
//                       string query = @"
//                            INSERT INTO paiement
//                            (
//                                id_facture,
//                                id_detail_facture,
//                                date_paiement,
//                                montant,
//                                reste,
//                                type_paiement
//                            )
//                            VALUES
//                            (
//                                @id_facture,
//                                @id_detail,
//                                @date_paiement,
//                                @montant,
//                                @reste,
//                                @type_paiement
//                            )";
//                    using (MySqlCommand cmd = new MySqlCommand(query, con, tr))
//                    {
//                        cmd.Parameters.AddWithValue("@id_facture", DBNull.Value);
//                        cmd.Parameters.AddWithValue("@id_detail", DBNull.Value);
//                        cmd.Parameters.AddWithValue("@date_paiement", Convert.ToDateTime(dtpPaiement.Value));
//                        cmd.Parameters.AddWithValue("@montant", nud_montant.Value);
//                        cmd.Parameters.AddWithValue("@reste", nud_reste.Value );
//                        cmd.Parameters.AddWithValue("@type_paiement", nud_reste.Value > 0 ? "Partiel" : "Complet") ;

//                        cmd.ExecuteNonQuery();

//                        id_paiement = Convert.ToInt32(cmd.LastInsertedId);

//                        // Enregistrement dans le livre de caisse
//                        Cepima.MesClasses.ReceptionManager.AjouterLivreCaisse(nud_montant.Value, 0, "AUTRE", tb_description.Text, con, tr);

//                    }

//                    tr.Commit();
//                    // Impression de du reçu
//                    this.Close();
//                    FormRecu recu = new FormRecu(id_paiement, false);
//                    recu.ShowDialog();
//                    con.Close();
//                }
//                    catch (Exception ex)
//                    {
//                        MessageBox.Show("Erreur " + ex.Message);
//                        tr.Rollback();
//                    }
//            }
                
//        }
    }
}
