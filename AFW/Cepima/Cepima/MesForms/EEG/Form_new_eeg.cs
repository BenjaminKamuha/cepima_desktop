using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using Cepima.Data;
using Cepima.MesUserCases.EEG;


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
                        cmd.Parameters.AddWithValue("@id_p", ObtenirIdPatient());
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
            cbx_type_eeg.Items.Clear();

            cbx_type_eeg.Items.Add("18_cannaux");
            cbx_type_eeg.Items.Add("32_cannaux");

            cbx_type_eeg.SelectedIndex = 0;
        }

        private int ObtenirIdPatient()
        {
            return UC_demandes_eeg.PATIENT_ID;
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

                lb_fichier.Text = fichier.Name;
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
            if (rd_eveil.Checked)
                return "Éveil";

            if (rd_somnolence.Checked)
                return "Somnolence";

            if (rd_sommeil.Checked)
                return "Sommeil";

            return null;
        }
    }




}
