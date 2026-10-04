using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cepima.MesForms.Personnel
{
    public partial class Liste_presence : Form
    {
        private DataTable donneesPresences;

        public Liste_presence(DataTable donnees)
        {
            InitializeComponent();
            donneesPresences = donnees;
        }

        private void Liste_presence_Load(object sender, EventArgs e)
        {
            try
            {
                // Vider les anciennes données
                reportViewer1.LocalReport.DataSources.Clear();

                // Ajouter Ds_Liste
                Microsoft.Reporting.WinForms.ReportDataSource source =
                    new Microsoft.Reporting.WinForms.ReportDataSource(
                        "Ds_Liste",
                        donneesPresences);

                reportViewer1.LocalReport.DataSources.Add(source);

                // Rapport RDLC
                reportViewer1.LocalReport.ReportEmbeddedResource =
                    "Cepima.MesForms.Personnel.Liste_presence.rdlc";

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du rapport :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
