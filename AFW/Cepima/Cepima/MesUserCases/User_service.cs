using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cepima.MesUserCases
{
    public partial class User_service : UserControl
    {
        string  ancienneValeur = "0";
        int rowEndition = -1;
        public User_service()
        {
            InitializeComponent();
            MesClasses.ReceptionManager.MoveLabel(label4,panel1);
            MesClasses.ReceptionManager.ChargerServicesInDatagridview(dgv_services);
            AjouterBoutons();
            dgv_services.CellFormatting += dgv_services_CellFormatting;
            dgv_services.CellContentClick += dgv_services_CellContentClick;
            dgv_services.CellClick += dgv_services_CellClick;
            dgv_services.CellBeginEdit += dgv_services_CellBeginEdit;
        }

        void dgv_services_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgv_services.Columns[e.ColumnIndex].Name == "Service")
            {
                ancienneValeur = dgv_services.Rows[e.RowIndex].Cells["Service"].ToString();
                rowEndition = e.RowIndex;
            }
        }

        void dgv_services_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_services.Columns[e.ColumnIndex].Name == "Service")
            {
                //ancienneValeur = Convert.ToDecimal(dgv_salaire.Rows[e.RowIndex].Cells["salaire_base"].Value);
                dgv_services.ReadOnly = false;
                foreach (DataGridViewColumn col in dgv_services.Columns)
                {
                    col.ReadOnly = true;
                }
                dgv_services.Columns["Service"].ReadOnly = false;
                dgv_services.CurrentCell = dgv_services.Rows[e.RowIndex].Cells["Service"];
                dgv_services.BeginEdit(true);
            }
        }

        void dgv_services_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int id_service = Convert.ToInt32(dgv_services.Rows[e.RowIndex].Cells["id_service"].Value);

                if (dgv_services.Columns[e.ColumnIndex].Name == "Modifier" && e.RowIndex >= 0)
                {
                    dgv_services.EndEdit();
                    if (rowEndition != e.RowIndex)
                    {
                        MessageBox.Show("Veuillez d'abord modifier la cellule !");
                        return;
                    }
                    string  nouveau_service = Convert.ToString(dgv_services.Rows[e.RowIndex].Cells["Service"].Value);
                    if (ancienneValeur == nouveau_service)
                    {
                        MessageBox.Show("Aucune modification effectuée !");
                        return;
                    }
                    MesClasses.ReceptionManager.UpdateService(id_service, nouveau_service);
                    MesClasses.ReceptionManager.ChargerServicesInDatagridview(dgv_services);
                    dgv_services.ReadOnly = true;
                    rowEndition = -1;
                }
                else if (dgv_services.Columns[e.ColumnIndex].Name == "Supprimer")
                {
                    DialogResult result = MessageBox.Show(" Voulez-vous Supprimer ce service ?", "Confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        MesClasses.ReceptionManager.DeleteService(id_service);
                        MesClasses.ReceptionManager.ChargerServicesInDatagridview(dgv_services);
                    }
                }

            }
            catch (Exception)
            {
                return;
            }
        }

        void dgv_services_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_services.Columns[e.ColumnIndex].Name == "Modifier")
            {
                e.CellStyle.BackColor = Color.FromArgb(39, 174, 96);
                e.CellStyle.ForeColor = Color.White;
            }
            else if (dgv_services.Columns[e.ColumnIndex].Name == "Supprimer")
            {
                e.CellStyle.BackColor = Color.FromArgb(231, 76, 60);
                e.CellStyle.ForeColor = Color.White;
            }
        }

        private void bt_save_service_Click(object sender, EventArgs e)
        {
            string service_name = tb_name_service.Text;
            string description = rich_description.Text;
           // enregistrement d'un service
            MesClasses.ReceptionManager.ServiceCepima(MesForms.SessionUtilisateur.idCentre.ToString(),service_name,description);
            MesClasses.ReceptionManager.ChargerServicesInDatagridview(dgv_services);
            tb_name_service.Text = "";
            rich_description.Clear();
        }

        // =================================== Ajouter la colonnes pour les actions (Modifier,supprimer,ect) =======================
        private void AjouterBoutons()
        {
            // Modifier
            DataGridViewButtonColumn btnModifier = new DataGridViewButtonColumn();
            btnModifier.Name = "Modifier";
            btnModifier.Text = "Modifier";
            btnModifier.UseColumnTextForButtonValue = true;
            dgv_services.Columns.Add(btnModifier);

            // Supprimer
            DataGridViewButtonColumn btnSupprimer = new DataGridViewButtonColumn();
            btnSupprimer.Name = "Supprimer";
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseColumnTextForButtonValue = true;
            dgv_services.Columns.Add(btnSupprimer);

            //desactiver
            ((DataGridViewButtonColumn)dgv_services.Columns["Modifier"]).FlatStyle = FlatStyle.Flat;
            ((DataGridViewButtonColumn)dgv_services.Columns["Supprimer"]).FlatStyle = FlatStyle.Flat;
            dgv_services.Columns["Modifier"].HeaderText = "";
            dgv_services.Columns["Supprimer"].HeaderText = "";
            dgv_services.Columns["Modifier"].Width = 60;
            dgv_services.Columns["Supprimer"].Width = 90;
            dgv_services.Columns["Centre"].Width = 280;
            dgv_services.Columns["Service"].Width = 160;
            dgv_services.DefaultCellStyle.SelectionBackColor = Color.FromArgb(39, 174, 96);
        }
    }
}
