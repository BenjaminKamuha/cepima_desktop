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
using Cepima.Data;
using Cepima.MesForms.Pharmacie;

namespace Cepima.MesUserCases.EEG
{
    public partial class User_examens : UserControl
    {
        public User_examens()
        {
            InitializeComponent();

            ChargerDemandesEEG();
        }

        private void ChargerDemandesEEG()
        {
            try
            {
                Database db = new Database();

                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"
                SELECT
                    ds.id_demande,
                    ds.id_patient,
                    ds.id_service,
                    ds.id_consultation,
                    p.nom,
                    p.post_nom,
                    p.prenom,
                    p.numero_fiche,

                    DATE_FORMAT(
                        ds.date_demande,
                        '%d/%m/%Y %H:%i'
                    ) AS date_demande,

                    ds.priorite,
                    ds.motif,
                    ds.statut

                FROM demande_service ds

                INNER JOIN patients p
                    ON p.id_patient = ds.id_patient

                INNER JOIN service s
                    ON s.id_service = ds.id_service

                WHERE s.nom = 'EEG'

                ORDER BY ds.date_demande DESC";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string idPatient = reader["id_patient"].ToString();
                                string nom = reader["nom"].ToString();
                                string postnom = reader["post_nom"].ToString();
                                string numero = reader["numero_fiche"].ToString();
                                string status = reader["statut"].ToString();

                                Create_pan_examen(idPatient, nom, postnom, status);
                            }

                            ProgressiveDisplay pd = new ProgressiveDisplay(pnl_examen, 100);
                            pd.Start();
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des demandes EEG.\n\n" +
                    ex.Message,
                    "Demandes EEG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Create_pan_examen(string idPatient, string nom, string postnom, string status )
        {
            CustomRoundedPanel panDemande = new CustomRoundedPanel();
            panDemande.Size = new Size(160, 130);
            panDemande.BorderRadius = 8;
            panDemande.BorderColor = Color.Silver;
            panDemande.BorderSize = 1;
            panDemande.Tag = idPatient;
            MesClasses.ManagerClasse.AddControl(pnl_examen, panDemande, 10, 8);

            // evenement Hover du panel pour déclencher l'ouverture du Formulaire détail
            panDemande.Click += (s, e) =>
            {
                if (status == "Terminée")
                {
                    MesForms.Form_Fiche_suivie fiche = new MesForms.Form_Fiche_suivie(idPatient);
                    fiche.ShowDialog();
                }
                else if (status == "Demandée")
                {
                    Form1.PATIENT_ID = Convert.ToInt32(idPatient);
                    Form_new_eeg frm_eeg = new Form_new_eeg();
                    frm_eeg.ShowDialog();
                }                
            };
            PictureBox picture = MesClasses.ManagerClasse.AddPicture(Properties.Resources.brain_40px, new Point(2, 5),
                new Size(70, 70));
            panDemande.Controls.Add(picture);

            Label lbNom = MesClasses.ManagerClasse.CustomLabel(nom, new Point(70, 20));
            lbNom.AutoSize = true;
            lbNom.Font = new System.Drawing.Font("Calibri", 10, FontStyle.Bold);
            panDemande.Controls.Add(lbNom);

            Label lbPost = MesClasses.ManagerClasse.CustomLabel(postnom, new Point(70, 40));
            lbPost.AutoSize = true;
            lbPost.Font = new System.Drawing.Font("Calibri", 10, FontStyle.Bold);
            panDemande.Controls.Add(lbPost);

            Label lbstatus = MesClasses.ManagerClasse.CustomLabel(status, new Point(10, 75));
            lbstatus.AutoSize = true;
            lbstatus.Font = new System.Drawing.Font("Calibri", 10, FontStyle.Bold);
            if (status == "Terminée")
            {
                lbstatus.ForeColor = Color.Green;
            }
            else if (status == "Demandée")
            {
                lbstatus.ForeColor = Color.Orange;
            }
            panDemande.Controls.Add(lbstatus);

            pnl_examen.Controls.Add(panDemande);
        }
    }
}
