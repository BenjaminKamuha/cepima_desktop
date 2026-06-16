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
using Microsoft.Reporting.WinForms;

namespace Cepima.MesForms
{
    public partial class FormFacturePrint : Form
    {
        int factureID;
        public FormFacturePrint(int id_facture)
        {
            InitializeComponent();
            factureID = id_facture;
        }

        private void FormFacturePrint_Load(object sender, EventArgs e)
        {
            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    // ========================== DATASET PRINCICAP ====================================
                    DataSet ds = new DataSet();

                    //  ========================= DATATABLE FACTURE =========================================
                    DataTable dtFacture = new DataTable();
                    string queryFacture = "SELECT f.id_facture,DATE_FORMAT(f.date_facture,'%d/%m/%Y') AS date_facture,f.type_facture,f.montant_total,f.statut,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS patient FROM facture f JOIN patients p ON f.id_patient = p.id_patient WHERE f.id_facture = @id";
                    using (MySqlCommand cmdFacture = new MySqlCommand(queryFacture, con))
                    {
                        cmdFacture.Parameters.AddWithValue("@id",factureID);
                        MySqlDataAdapter daFacture = new MySqlDataAdapter(cmdFacture);
                        daFacture.Fill(dtFacture);
                    }

                    // =================================== DATATABLE DETAILS ===============================
                    DataTable dtDetail = new DataTable();
                    string queryDetail = "SELECT description,quantite,prix_unitaire,montant FROM detail_facture WHERE id_facture =@id";
                    using (MySqlCommand cmdDetail = new MySqlCommand(queryDetail, con))
                    {
                        cmdDetail.Parameters.AddWithValue("@id",factureID);
                        MySqlDataAdapter daDetail = new MySqlDataAdapter(cmdDetail);
                        daDetail.Fill(dtDetail);
                    }

                    // =================================== AJOUT DATASOURCE ===========================================
                    reportViewer1.LocalReport.DataSources.Clear();
                    // ========================== datasource facture ====================================
                    ReportDataSource rdsFacture = new ReportDataSource("facture_ds",dtFacture);
                    // ========================== datasource details ===================================
                    ReportDataSource rdsDetail = new ReportDataSource("ds_detail",dtDetail);

                    reportViewer1.LocalReport.DataSources.Add(rdsFacture);
                    reportViewer1.LocalReport.DataSources.Add(rdsDetail);

                    // =============================== RDLC ===========================================
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Cepima.FactureRDLC.rdlc";
                    reportViewer1.LocalReport.Refresh();
                    this.reportViewer1.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur d'impression de la facture :" + ex.Message);
                }
            }
        }
    }
}
