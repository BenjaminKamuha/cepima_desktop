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
using System.IO;

namespace Cepima.MesUserCases
{
    public partial class User_consultation : UserControl
    {
        int ID_PATIENT;
        int id_diagnostic;
        string Type_consultation = "";
        public User_consultation(int Patient_Id)
        {
            InitializeComponent();
            ID_PATIENT = Patient_Id;
            LoadDataAdministratives();
        }
      
        //Charger les informations du patient à consulter
    
        //méthode pour charger les informations administratives du patient
        private void LoadDataAdministratives()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string query = "SELECT p.nom,p.post_nom,CONCAT('PAT-',YEAR(p.date_creation),'-',p.numero_fiche) AS dossier,p.telephone,p.date_naissance,p.sexe,c.date_consultation FROM patients p LEFT JOIN consultation c ON p.id_patient = c.patient_id WHERE p.id_patient = @id ORDER BY c.date_consultation DESC LIMIT 1";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@id", ID_PATIENT.ToString());
                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                    {
                        if (reader.Read())
                        {
                            lb_nom.Text = reader["nom"].ToString();
                            lb_postnom.Text = reader["post_nom"].ToString();
                            lb_dossier.Text = reader["dossier"].ToString();
                            DateTime date = Convert.ToDateTime(reader["date_naissance"]);
                            int annee = MesClasses.ReceptionManager.CalculerAge(date);
                            lb_age.Text = annee.ToString() + " ans" + " - " + reader["sexe"];
                            lb_adresse.Text = reader["telephone"].ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void btn_save_category_Click(object sender, EventArgs e)
        {
            Save_Consultation();
        }

        //fonction pour récuperer le texte des radioButtons
        private string GetRadioSelection(Panel panel_test)
        {
            foreach (Control control in panel_test.Controls)
            {
                RadioButton rb = control as RadioButton;

                if (rb != null && rb.Checked)
                {
                    return rb.Text;
                }
            }
            return null;
        }

        private void Save_Consultation()
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {

                string risqueSuicidaire = GetRadioSelection(panelSuicidaire);
                string risqueAgression = GetRadioSelection(panelAgression);
                string risqueFugue = GetRadioSelection(panelFugue);

                using (MySqlTransaction tr = con.BeginTransaction())
                {
                    try
                    {
                        using (MySqlCommand cmd = new MySqlCommand("INSERT INTO diagnostic (libelle,description)VALUES(@lib,@desc)", con,tr))
                        {
                            cmd.Parameters.AddWithValue("@lib",tb_diagnostic_principal.Text);
                            cmd.Parameters.AddWithValue("@desc",tb_motif.Text);
                            cmd.ExecuteNonQuery();
                            id_diagnostic = Convert.ToInt32(cmd.LastInsertedId);
                        }

                        //insertion dans la table consultation
                        string queryConsultation = "INSERT INTO consultation(patient_id,type_consultation,motif,symptomes_depuis,symptome_insomnie,symptome_anxiete,symptome_agitation,symptome_tristesse,symptome_idees_delirantes,symptome_hallucinations,symptome_perte_memoire,symptome_autre,evolution_symptomes,facteurs_declenchants,risque_suicidaire,risque_agression,risque_fugue,autres_risques,diagnostic_id,prochaine_consultation,date_consultation,utilisateur_id)VALUES(@patient,@type,@motif,@depuis,@insomnie,@anxiete,@agitation,@tristesse,@delire,@hallucination,@perte,@autre,@evolution,@declencheurs,@suicidaire,@agression,@fugue,@autres_risque,@id_diagnostic,@prochaine,CURDATE(),@user)";
                        using (MySqlCommand cmd = new MySqlCommand(queryConsultation, con, tr))
                        {
                            cmd.Parameters.AddWithValue("@patient",ID_PATIENT);
                            cmd.Parameters.AddWithValue("@type", Type_consultation);
                            cmd.Parameters.AddWithValue("@motif",tb_motif.Text);
                            cmd.Parameters.AddWithValue("@depuis",dt_depuis.Value.Date);
                            cmd.Parameters.AddWithValue("@insomnie",insomnie.Checked);
                            cmd.Parameters.AddWithValue("@anxiete",anxiete.Checked);
                            cmd.Parameters.AddWithValue("@agitation",agitation.Checked);
                            cmd.Parameters.AddWithValue("@tristesse",tristesse.Checked);
                            cmd.Parameters.AddWithValue("@delire",delirante.Checked);
                            cmd.Parameters.AddWithValue("@hallucination",hallucination.Checked);
                            cmd.Parameters.AddWithValue("@perte",perte_memoire.Checked);
                            cmd.Parameters.AddWithValue("@autre",tb_autre.Text);
                            cmd.Parameters.AddWithValue("@evolution",rich_evolution.Text);
                            cmd.Parameters.AddWithValue("@declencheurs",rich_facteurs.Text);
                            cmd.Parameters.AddWithValue("@suicidaire",risqueSuicidaire);
                            cmd.Parameters.AddWithValue("@agression",risqueAgression);
                            cmd.Parameters.AddWithValue("@fugue",risqueFugue);
                            cmd.Parameters.AddWithValue("@autres_risque",tb_autre_evaluation.Text);
                            cmd.Parameters.AddWithValue("@id_diagnostic",id_diagnostic);
                            cmd.Parameters.AddWithValue("@prochaine",dt_after_.Value.Date);
                            cmd.Parameters.AddWithValue("@user", MesClasses.SessionUtilisateur.idUser);
                            cmd.ExecuteNonQuery();


                        }
                        tr.Commit();
                        MessageBox.Show("Consultation crée avec succès !!","Enregistrement");
                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        MessageBox.Show("Erreur : " + ex.Message);
                    }
                }
            }
        }

        private void rb_consultation_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_consultation.Checked)
            {
                Type_consultation = "Première consultation";
                MessageBox.Show(Type_consultation);
            }
        }

        private void rb_suivi_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_suivi.Checked)
            {
                Type_consultation = "Consultation de suivie";
            }
        }

        private void rb_control_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_control.Checked)
            {
                Type_consultation = "Consultation de contrôle";
            }
        }

        private void rb_urgence_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_urgence.Checked)
            {
                Type_consultation = "Consultation d'urgence";
            }
        } 
    }
}
