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

namespace Cepima.MesForms.Rapport
{
    public partial class BonRapport : Form
    {
        private string ID_BON;
        public BonRapport(string bonId)
        {
            InitializeComponent();
            this.ID_BON = bonId;
            LoadBonSortie();
        }

        private void BonRapport_Load(object sender, EventArgs e)
        {
            //TesterRessourceRDLC();
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
        private void TesterRessourceRDLC()
        {
            string[] ressources =
                System.Reflection.Assembly
                .GetExecutingAssembly()
                .GetManifestResourceNames();

            string resultat = "";

            foreach (string ressource in ressources)
            {
                resultat += ressource + Environment.NewLine;
            }

            MessageBox.Show(
                resultat,
                "Ressources incorporées");
        }
        private void LoadBonSortie()
        {
            try
            {
                using (MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {
                    string query = @"
                SELECT
                    id_bon AS Numero,
                    nom_resp AS Demandeur,
                    signature_donneur AS Signature_responsable,
                    montant AS Montant,
                    DATE_FORMAT(date, '%d/%m/%Y') AS Date,
                    statut
                FROM bon_sortie
                WHERE id_bon = @id_bon";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_bon",
                            this.ID_BON);

                        using (MySqlDataAdapter da =
                            new MySqlDataAdapter(cmd))
                        {
                            DataTable dt =
                                new DataTable();

                            da.Fill(dt);

                            // ======================================================
                            // VÉRIFIER QUE LE BON EXISTE
                            // ======================================================

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show(
                                    "Aucun bon de sortie trouvé pour cet identifiant.",
                                    "Bon de sortie",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                return;
                            }

                            // ======================================================
                            // ALIMENTER LE REPORTVIEWER
                            // ======================================================

                            ReportDataSource rds =
                                new ReportDataSource(
                                    "Ds_Bon",
                                    dt);

                            reportViewer1.LocalReport
                                .DataSources.Clear();

                            reportViewer1.LocalReport
                                .DataSources.Add(rds);

                            reportViewer1.LocalReport.ReportEmbeddedResource =
    "Cepima.MesForms.Rapport.Bon.rdlc";

                            reportViewer1.LocalReport.Refresh();

                            reportViewer1.RefreshReport();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement du bon de sortie :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
