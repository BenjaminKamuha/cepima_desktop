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
    public partial class FormRecu : Form
    {
        int paiementID;
        public FormRecu(int id_paiement)
        {
            InitializeComponent();
            paiementID = id_paiement;
            LoadRecu();
        }

         // =========================== charger le reçu dans le repprtView =============
        private void LoadRecu()
        {
            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    DataTable dt = new DataTable();
                    string query = "SELECT pa.numero_recu,DATE_FORMAT(pa.date_paiement,'%d/%m/%Y') AS date_paiement,pa.montant,pa.type_paiement,pa.reste,f.id_facture,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS patient FROM paiement pa JOIN facture f ON pa.id_facture = f.id_facture JOIN patients p ON f.id_patient = p.id_patient WHERE pa.id_paiement=@id";
                    MySqlCommand cmd = new MySqlCommand(query,con);
                    cmd.Parameters.AddWithValue("@id", paiementID);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    ReportDataSource rds = new ReportDataSource("ds_Recu", dt);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    //reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"F:\Projet_2026\cepima_desktop\AFW\Cepima\Cepima\bin\Debug\RecuRDLC.rdlc";
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Cepima.RecuRDLC.rdlc";
                    reportViewer1.LocalReport.Refresh();
                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : "+ ex.Message);
            }
        }
    }
}
