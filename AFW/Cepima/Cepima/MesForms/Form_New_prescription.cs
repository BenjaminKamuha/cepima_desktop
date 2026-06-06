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
using System.IO;
namespace Cepima.MesForms
{
    public partial class Form_New_prescription : Form
    {
        private string id_hospitalisation,idPatient;
        private string idConsultation;
        public Form_New_prescription(string idHosp,string patient)
        {
            InitializeComponent();
            id_hospitalisation = idHosp;
            idPatient = patient;
            LoadMedicament();
            LoadInfosPatientInPanel();
        }
        // ================================== charger la liste de medicaments dans le panel =============================================
        private void LoadMedicament(params string[] args)
        {
            panel_medicament.Controls.Clear();

            try
            {
                string query = "";
                if (args.Length != 0)
                {
                    query = "SELECT id_medicament,nom_medicament,photo,categorie,unite,prix_vente FROM medicament WHERE nom_medicament LIKE @search";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@search", "%" + args[0] + "%");
                }
                else
                {
                    query = "SELECT id_medicament,nom_medicament,photo,categorie,unite,prix_vente FROM medicament ORDER BY nom_medicament ASC";
                }

                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, args.Length != 0 ? MesClasses.ManagerClasse.request_params : null, true))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string idMed = reader["id_medicament"].ToString();
                            string nom = reader["nom_medicament"].ToString();
                            string unite = reader["unite"].ToString();
                            string prix = reader["prix_vente"].ToString();

                            CustomRoundedPanel pan = new CustomRoundedPanel();
                            pan.Size = new Size(100, 120);
                            pan.BorderRadius = 10;
                            pan.BorderSize = 1;
                            pan.BorderColor = Color.FromArgb(224, 224, 224);
                            pan.HoverCursor = Cursors.Default;
                            MesClasses.ManagerClasse.AddControl(panel_medicament, pan, 5, 5);

                            //====== Avatar ======
                            AvatarControl avatar = new AvatarControl();
                            avatar.Location = new Point(25, 5);
                            avatar.Size = new Size(45, 45);
                            avatar.BorderSize = 2;
                            avatar.BorderColor = Color.FromArgb(44, 123, 229);

                            try
                            {
                                if (reader["photo"] != DBNull.Value)
                                {
                                    byte[] imageData = (byte[])reader["photo"];
                                    using (MemoryStream ms = new MemoryStream(imageData))
                                    {
                                        avatar.Avatar = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    avatar.Avatar = Properties.Resources.capsules_100px;
                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("Erreur image : " + ex.Message);
                                avatar.Avatar = Properties.Resources.capsules_100px;
                            }

                            pan.Controls.Add(avatar);

                            Label lbNom = MesClasses.ManagerClasse.CustomLabel(nom, new Point(5, 55));
                            lbNom.AutoSize = true;
                            lbNom.Font = new Font("Calibri", 9);
                            pan.Controls.Add(lbNom);

                            Label lbPrix = MesClasses.ManagerClasse.CustomLabel("Prix : " + prix + "$", new Point(20, 70));
                            lbPrix.AutoSize = true;
                            lbPrix.Font = new System.Drawing.Font("Calibri", 9);
                            pan.Controls.Add(lbPrix);

                            RoundedButton btSelect = MesClasses.ManagerClasse.Rbutton("Choisir", new Point(10, 95), new Size(80, 20), Color.FromArgb(7, 51, 131), Color.White);
                            btSelect.BorderRadius = 4;
                            btSelect.BorderSize = 0;
                            btSelect.Tag = idMed;
                            btSelect.Click += (s, e) =>
                            {
                                AjouterAuDataGrid(
                                    idMed,
                                    nom,
                                    unite,
                                    prix
                                );
                            };

                            pan.Controls.Add(btSelect);
                        }
                        reader.Close();
                        ProgressiveDisplay pd = new ProgressiveDisplay(panel_medicament, 100);
                        pd.Start();
                    }
                    else
                    {
                        panel_medicament.Controls.Clear();
                        lb_not_found.Visible = true;
                        lb_not_found.Text = "Aucun médicament trouvé";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
        // =======================================Méthode d'ajout au datagridview =======================================================
        private void AjouterAuDataGrid(string id, string nom, string unite, string prix)
        {
            foreach (DataGridViewRow row in dgv_medoc.Rows)
            {
                if (row.Cells["colID"].Value != null && row.Cells["colID"].Value.ToString() == id)
                {
                    int qte = Convert.ToInt32(row.Cells["colQuantite"].Value);
                    row.Cells["colQuantite"].Value = qte + 1;
                    return;
                }
            }
            dgv_medoc.Rows.Add(id, nom, 1, unite, prix, "Non Livré");
        }
        //========================= charger les informations personels du patient en haut ===============================================
        private void LoadInfosPatientInPanel()
        {
            try
            {
                string query = "SELECT h.id_consultation,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS patient,c.numero_chambre,s.nom_service FROM hospitalisation h JOIN patients p ON h.id_patient = p.id_patient JOIN affectation_chambre ac ON h.id_hospitalisation = ac.id_hospitalisation JOIN chambre c ON ac.id_chambre = c.id_chambre JOIN services s ON c.id_service = s.id_service WHERE h.id_hospitalisation =@id ORDER BY ac.id_affectation DESC LIMIT 1";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",id_hospitalisation);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                {
                    if (reader.Read())
                    {
                        idConsultation = reader["id_consultation"].ToString();
                        lb_nom_patient.Text = reader["patient"].ToString();
                        lb_chambre.Text = "Chambre N° : "+reader["numero_chambre"];
                        lb_service.Text = "Service : " + reader["nom_service"];
                    }
                    reader.Close();
                }

            }
            catch ( MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =================================== récuperer le nom du medecin en charge de la prescription ================================
        private string GetMedecin()
        {
            string medecin = "";
            try
            {
                string query = "SELECT CONCAT(nom,' ',post_nom) AS medecin FROM personnels  WHERE (SELECT id_personnel FROM consultation WHERE id_consultation =@id)";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@id",idConsultation);
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                {
                    if (reader.Read())
                    {
                        medecin = reader["medecin"].ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return medecin;
        }
        private void tb_search_medoc_TextChanged(object sender, EventArgs e)
        {
            LoadMedicament(tb_search_medoc.Text);
        }
        // ====================================== valider la prescription =====================================================
        private void bt_valider_prescription_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgv_medoc.Rows)
                {
                    if (row.IsNewRow)
                        continue;
                    string query = "INSERT INTO prescriptions(id_consultation,id_patient,id_medicament,quantite,unite,statut,date_prescription)VALUES(@id_consultation,@id_patient,@id_medicament,@quantite,@unite,@statut,CURDATE())";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@id_consultation",idConsultation.ToString());
                    MesClasses.ManagerClasse.request_params.Add("@id_patient", idPatient.ToString());
                    MesClasses.ManagerClasse.request_params.Add("@id_medicament",row.Cells["colID"].Value.ToString());
                    MesClasses.ManagerClasse.request_params.Add("@quantite",row.Cells["colQuantite"].Value.ToString());
                    MesClasses.ManagerClasse.request_params.Add("@unite",row.Cells["colUnite"].Value.ToString());
                    MesClasses.ManagerClasse.request_params.Add("@statut","Non Livré");
                    MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params);
                }

                // ======================= construction de la liste de medocs préscrit par le medecin ===================
                string medicament = "";
                string medecin = GetMedecin();
                foreach (DataGridViewRow row in dgv_medoc.Rows)
                {
                    if (row.IsNewRow)
                        continue;
                    medicament += row.Cells["colMedicament"].Value.ToString() + ", ";
                }
                MesClasses.Event.SaveHistorique(id_hospitalisation.ToString(), "Nouvelle Prescription ajoutée par Dr : " + medecin + " : " + medicament);
                MessageBox.Show("Nouvelle prescription ajoutée par le docteur "+medecin);
                dgv_medoc.Rows.Clear();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
