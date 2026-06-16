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
    public partial class User_service : UserControl
    {
        string SERVICE_ID;
        public User_service()
        {
            InitializeComponent();
            LoadService();
        }
        private void bt_save_service_Click(object sender, EventArgs e)
        {
            string service_name = textbox.Text;
            string description = rich_description.Text;
           // enregistrement d'un service
            MesClasses.ReceptionManager.ServiceCepima(MesForms.SessionUtilisateur.idCentre.ToString(),service_name,description);
            LoadService();
            textbox.Text = "";
            rich_description.Clear();
        }

        // ======================== charger les services sur le panel ========================================================
        private void LoadService()
        {
            try
            {
                string querySelectService = "SELECT s.id_service,s.nom_service,c.nom_centre FROM services s JOIN centres c ON s.id_centre = s.id_centre ORDER BY s.nom_service ASC";
                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(querySelectService, null, true))
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        string id_service = reader["id_service"].ToString();
                        string nomService = reader["nom_service"].ToString();
                        //string centre = reader["nom_centre"].ToString();
                        AjouterPanelService(id_service,nomService);
                        i++;
                    }
                    reader.Close();
                    lb_nombre.Text = i.ToString()+" Service(s)";
                    lb_nombre.Font = new Font("Calibri",9,FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : "+ex.Message);
            }
        }

        // =================== ajouter panel ===================================
        private void AjouterPanelService(string service_id, string name_service)
        {
            CustomRoundedPanel panService = new CustomRoundedPanel();
            panService.Size = new Size(200, 160);
            panService.BorderRadius = 10;
            panService.BorderSize = 1;
            panService.BorderColor = Color.FromArgb(224, 224, 224);
            panService.HoverCursor = Cursors.Default;
            MesClasses.ManagerClasse.AddControl(pan_display_service, panService, 8, 8);

            AvatarControl avatar = new AvatarControl();
            avatar.Location = new Point(10, 10);
            avatar.Size = new Size(40, 40);
            avatar.BorderSize = 1;
            avatar.BorderColor = Color.Transparent;
            avatar.Avatar = Properties.Resources.unit_25px;
            panService.Controls.Add(avatar);

            RoundedButton bt_update = MesClasses.ManagerClasse.Rbutton("modifier", new Point(10, 125), new Size(80, 20), Color.FromArgb(39, 174, 96), Color.White);
            bt_update.BorderRadius = 4;
            bt_update.BorderSize = 0;
            bt_update.BorderColor = Color.FromArgb(39, 174, 96);
            bt_update.Tag = service_id;
            panService.Controls.Add(bt_update);

            bt_update.Click += (e, s) =>
            {
                SERVICE_ID = service_id;
                pan_update_service.Visible = true;
                ChargerNomService(service_id);
            };

            RoundedButton bt_delete = MesClasses.ManagerClasse.Rbutton("Supprimer",new Point(115,125),new Size(80,20),Color.FromArgb(231,76,60),Color.White);
            bt_delete.BorderRadius = 4;
            bt_delete.BorderSize = 0;
            bt_delete.BorderColor = Color.FromArgb(231, 76, 60);//231; 76; 60
            bt_delete.Tag = service_id;
            panService.Controls.Add(bt_delete);

            bt_delete.Click += (e, s) =>
                {
                    var result = MessageBox.Show("Supprimer ce service ?","Confirmation",MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        SERVICE_ID = service_id;
                        DeleteService(service_id);
                    }
                    else
                        return;
                };

            Label lbNom = MesClasses.ManagerClasse.CustomLabel(name_service, new Point(60, 25));
            lbNom.AutoSize = true;
            lbNom.Font = new Font("Calibri", 10);
            panService.Controls.Add(lbNom);

            ProgressiveDisplay pd = new ProgressiveDisplay(pan_display_service, 100);
            pd.Start();
        }
        // =================================== charger le nom du service dans le textBox ===========================
        private void ChargerNomService(string id)
        {
            string query = "SELECT nom_service FROM services WHERE id_service =@id";
            MesClasses.ManagerClasse.request_params.Clear();
            MesClasses.ManagerClasse.request_params.Add("@id",id);
            using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
            {
                while (reader.Read())
                {
                    tb_mod_name_service.Text = reader["nom_service"].ToString();
                    tb_mod_name_service.SelectAll();
                    tb_mod_name_service.Focus();
                }
                reader.Close();
            }
        }

        private void bt_update_service_Click(object sender, EventArgs e)
        {
            string query = "UPDATE services SET nom_service=@name WHERE id_service =@id";
            MesClasses.ManagerClasse.request_params.Clear();
            MesClasses.ManagerClasse.request_params.Add("@name",tb_mod_name_service.Text);
            MesClasses.ManagerClasse.request_params.Add("@id",SERVICE_ID);
            MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params);
            MessageBox.Show("Service mis en jour !!");
            LoadService();
            pan_update_service.Visible = false;
        }

        private void DeleteService(string id)
        {
            string queryDelete = "DELETE FROM services WHERE id_service =@id";
            MesClasses.ManagerClasse.request_params.Clear();
            MesClasses.ManagerClasse.request_params.Add("@id",id);
            MesClasses.ManagerClasse.CRUD(queryDelete,MesClasses.ManagerClasse.request_params);
            MessageBox.Show("Service supprimé avec succès !!");
        }
    }
}
