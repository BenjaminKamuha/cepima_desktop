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

                    DataTable dtFacture = new DataTable();
                    string query = "SELECT f.id_facture,DATE_FORMAT(f.date_facture,'%d/%m/%Y') AS date_facture,f.type_facture,f.montant_total,f.statut,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS patient,df.description,df.quantite,df.prix_unitaire,df.montant FROM facture f INNER JOIN patients p ON p.id_patient = f.id_patient INNER JOIN detail_facture df ON df.id_facture = f.id_facture WHERE f.id_facture=@id";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", factureID);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dtFacture);

                    }
                    // ================= DATASOURCE ===================
                    reportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rds = new ReportDataSource("facture_ds",dtFacture);
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    // ================= RDLC ========================

                    reportViewer1.LocalReport.ReportEmbeddedResource = "Cepima.FactureRDLC.rdlc";
                    reportViewer1.LocalReport.Refresh();
                    reportViewer1.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur impression facture : "+ ex.Message);
                }

            }
        }
    }
}
