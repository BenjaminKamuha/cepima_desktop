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
using Cepima.Data;


namespace Cepima.MesForms.Pharmacie
{
    public partial class Form_new_eeg : Form
    {
        private Database db = new Database();
        public Form_new_eeg()
        {
            InitializeComponent();

            ChargerPatients();
            ChargerTypesEEG();

            dtp_eeg.Value = DateTime.Now;

            rd_eveil.Checked = true;

            //txtDuree.Text = "20";

            btn_import_file.Click += btnImporterFichier_Click;
            btn_save.Click += btn_save_Click;
        }

        void btn_save_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ChargerPatients()
        {
            try
            {
                Database db = new Database();

                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"
                SELECT 
                    id_patient,
                    YEAR(date_naissance) AS annee_naissance,
                    numero_fiche,
                    sexe,
                    CONCAT(
                        nom,
                        ' ',
                        post_nom,
                        CASE 
                            WHEN prenom IS NOT NULL AND prenom <> ''
                            THEN CONCAT(' ', prenom)
                            ELSE ''
                        END
                    ) AS patient
                FROM patients
                WHERE id_patient = @id_p";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_p", );
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            int age = DateTime.Now.Date.Year - Convert.ToInt32(reader["annee_naissance"].ToString());
                            lb_nom_patient.Text = reader["patient"].ToString();
                            lb_sexe_age.Text = reader["sexe"].ToString() + "-" + age.ToString() + " ans";
                            lb_num_fiche.Text = reader["numero_fiche"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des patients :\n" + ex.Message,
                    "EEG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ChargerTypesEEG()
        {
            cboTypeEEG.Items.Clear();

            cboTypeEEG.Items.Add("18_cannaux");
            cboTypeEEG.Items.Add("32_cannaux");

            cboTypeEEG.SelectedIndex = 0;
        }

        private int ObtenirIdPatient()
        {
            if (cboPatient.SelectedIndex == -1 ||
                cboPatient.SelectedValue == null)
            {
                return 0;
            }

            return Convert.ToInt32(cboPatient.SelectedValue);
        }

        private string fichierEEGSelectionne = "";

        private void btnImporterFichier_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Sélectionner le fichier EEG";

                dialog.Filter =
                    "Fichiers EEG (*.edf;*.edfz;*.bdf;*.set)|*.edf;*.edfz;*.bdf;*.set|" +
                    "Tous les fichiers (*.*)|*.*";

                dialog.Multiselect = false;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                fichierEEGSelectionne = dialog.FileName;

                FileInfo fichier = new FileInfo(fichierEEGSelectionne);

                txtFichierEEG.Text = fichier.Name;
            }
        }

        private string ObtenirNomFichier()
        {
            if (string.IsNullOrEmpty(fichierEEGSelectionne))
                return null;

            return Path.GetFileName(fichierEEGSelectionne);
        }

        private string ObtenirExtensionFichier()
        {
            if (string.IsNullOrEmpty(fichierEEGSelectionne))
                return null;

            return Path.GetExtension(fichierEEGSelectionne);
        }

        private long ObtenirTailleFichier()
        {
            if (string.IsNullOrEmpty(fichierEEGSelectionne))
                return 0;

            FileInfo fichier = new FileInfo(fichierEEGSelectionne);

            return fichier.Length;
        }

        private string ObtenirEtatPatient()
        {
            if (rbEveil.Checked)
                return "Éveil";

            if (rbSomnolence.Checked)
                return "Somnolence";

            if (rbSommeil.Checked)
                return "Sommeil";

            return null;
        }
    }




}
