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
        public FormRecu(int id)
        {
            InitializeComponent();
            paiementID = id;
            LoadRecu();
        }

        private void FormRecu_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        // =========================== charger le reçu dans le ReportViewer ===========================
        private void LoadRecu()
        {
            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    string query = "SELECT DATE_FORMAT(pa.date_paiement, '%d/%m/%Y') AS date_paiement,f.id_facture,CONCAT(p.nom, ' ',p.post_nom, ' ',p.prenom) AS patient,pa.montant AS montant_paye,pa.type_paiement,f.reste,df.description,df.quantite,df.prix_unitaire,f.montant_total AS total_facture,df.montant  AS montant_prestation FROM paiement pa INNER JOIN facture f ON pa.id_facture = f.id_facture INNER JOIN patients p ON f.id_patient = p.id_patient LEFT JOIN detail_facture df ON f.id_facture = df.id_facture WHERE pa.id_paiement = @id ORDER BY FIELD(df.description,'Consultation','Médicaments','EEG','Laboratoire','Hospitalisation','Nursing','Séance psychosociale','Imprimés','Autres')";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", paiementID);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // Vérifier que le paiement existe
                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("Aucun paiement trouvé pour cet identifiant.","Reçu",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                return;
                            }

                             // ======================================================//
                            // Alimenter le ReportViewer                             //
                           // ======================================================//
                            ReportDataSource rds = new ReportDataSource("ds_Recu", dt);
                            reportViewer1.LocalReport.DataSources.Clear();
                            reportViewer1.LocalReport.DataSources.Add(rds);
                            reportViewer1.LocalReport.ReportEmbeddedResource = "Cepima.RecuRDLC.rdlc";
                            reportViewer1.LocalReport.Refresh();
                            reportViewer1.RefreshReport();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement du reçu :\n" + ex.Message,"Erreur",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
