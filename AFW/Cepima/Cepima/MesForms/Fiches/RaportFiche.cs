using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;

namespace Cepima.MesForms.Fiches
{
    public partial class RaportFiche : Form
    {
        private string PATIENT;
        private int ID_FICHE;
        public RaportFiche(string id, int idFiche)
        {
            InitializeComponent();
            this.PATIENT = id;
            ID_FICHE = idFiche;
        }

        private void RaportFiche_Load(object sender, EventArgs e)
        {
            ChargerFicheMedicale();
            
        }

        private void ChargerFicheMedicale()
        {
            int idPatient;

            if (!int.TryParse(PATIENT, out idPatient))
            {
                MessageBox.Show(
                    "L'identifiant du patient est invalide.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (ID_FICHE <= 0)
            {
                MessageBox.Show(
                    "Ce patient n'a pas de fiche médicale,prenez ses signes vitaux pour qu'il sois en possession de la fiche",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
            }

            string numeroFiche = "";
            string date_entree = "";

            Ds_Fiche ds = new Ds_Fiche();
            ds.EnforceConstraints = false;
            //ds.EnforceConstraints = true;
            try
            {
                using (MySqlConnection connexion = MesClasses.ManagerClasse.GetConnexion())
                {
                   

                    string sqlFiche = "SELECT numero_fiche, date_entree FROM fiches_medicales WHERE id_fiche = @id_fiche AND id_patient = @id_patient LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(sqlFiche, connexion))
                    {
                        cmd.Parameters.AddWithValue("@id_fiche", ID_FICHE);
                        cmd.Parameters.AddWithValue("@id_patient", idPatient);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                numeroFiche = reader["numero_fiche"].ToString();

                                date_entree = Convert.ToDateTime(reader["date_entree"]).ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                MessageBox.Show("Cette fiche médicale est introuvable pour ce patient.","Fiche médicale",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    string sqlPatient = "SELECT id_patient,CONCAT(nom,' ',post_nom,' ',prenom) AS nom,sexe, date_naissance,telephone,adresse,profession,etat_civil,nom_pere,nom_mere,profession_pere,profession_mere,confession_religieuse,niveau_etude,personne_accompagnante,telephone_accompagnant,autres_membres_famille,engagement_tuteur FROM patients WHERE id_patient = @id_patient";

                    using (MySqlCommand cmd = new MySqlCommand(sqlPatient, connexion))
                    {
                        cmd.Parameters.AddWithValue("@id_patient", idPatient);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(ds.dtPatient);
                        }
                    }

                    if (ds.dtPatient.Rows.Count == 0)
                    {
                        MessageBox.Show(
                            "Aucun patient trouvé.",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }

                    // =====================================
                    // 2. ANTÉCÉDENTS
                    // =====================================

                    string sqlAntecedents = @"
                        SELECT *
                        FROM antecedents
                        WHERE id_patient = @id_patient
                        ORDER BY date_enregistrement DESC,
                                 id_antecedent DESC
                        LIMIT 1;";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sqlAntecedents, connexion))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_patient", idPatient);

                        using (MySqlDataAdapter da =
                            new MySqlDataAdapter(cmd))
                        {
                            da.Fill(ds.dtAntecedents);
                        }
                    }

                    // =====================================
                    // 3. PRÉPARER LES ANTÉCÉDENTS POUR LE RDLC
                    // =====================================

                    if (ds.dtAntecedents.Rows.Count > 0)
                    {
                        DataRow ligne = ds.dtAntecedents.Rows[0];

                        StringBuilder medicaux = new StringBuilder();
                        StringBuilder psychiatriques = new StringBuilder();
                        StringBuilder hereditaires = new StringBuilder();
                        StringBuilder toxiques = new StringBuilder();

                        // Antécédents médicaux
                        AjouterSiVrai(ligne, "medical_hta","Hypertension artérielle", medicaux);
                        AjouterSiVrai(ligne, "medical_diabete","Diabète", medicaux);
                        AjouterSiVrai(ligne, "medical_epilepsie","Épilepsie", medicaux);
                        AjouterSiVrai(ligne, "medical_traumatisme_cranien","Traumatisme crânien", medicaux);
                        AjouterSiVrai(ligne, "medical_avc","AVC", medicaux);
                        AjouterSiVrai(ligne, "medical_vih","VIH", medicaux);
                        AjouterSiVrai(ligne, "medical_tuberculose","Tuberculose", medicaux);
                        AjouterTexte(ligne, "medical_autre", medicaux);

                        // Antécédents psychiatriques
                        AjouterSiVrai(ligne, "psy_depression",
                            "Dépression", psychiatriques);
                        AjouterSiVrai(ligne, "psy_tentative_suicide",
                            "Tentative de suicide", psychiatriques);
                        AjouterSiVrai(ligne, "psy_hospitalisation",
                            "Hospitalisation psychiatrique", psychiatriques);
                        AjouterSiVrai(ligne, "psy_trouble_bipolaire",
                            "Trouble bipolaire", psychiatriques);
                        AjouterSiVrai(ligne, "psy_schizophrenie",
                            "Schizophrénie", psychiatriques);

                        AjouterTexte(ligne, "psy_autre", psychiatriques);

                        // Antécédents héréditaires
                        AjouterSiVrai(ligne, "hereditaire_hta",
                            "Hypertension artérielle", hereditaires);
                        AjouterSiVrai(ligne, "hereditaire_diabete",
                            "Diabète", hereditaires);
                        AjouterSiVrai(ligne, "hereditaire_epilepsie",
                            "Épilepsie", hereditaires);
                        AjouterSiVrai(ligne, "hereditaire_avc",
                            "AVC", hereditaires);
                        AjouterSiVrai(ligne, "hereditaire_tuberculose",
                            "Tuberculose", hereditaires);
                        AjouterSiVrai(ligne, "hereditaire_vih",
                            "VIH", hereditaires);

                        AjouterTexte(ligne, "hereditaire_autre",
                            hereditaires);

                        // Habitudes toxiques
                        AjouterSiVrai(ligne, "toxique_alcool",
                            "Alcool", toxiques);
                        AjouterSiVrai(ligne, "toxique_tabac",
                            "Tabac", toxiques);
                        AjouterSiVrai(ligne, "toxique_cannabis",
                            "Cannabis", toxiques);
                        AjouterSiVrai(ligne, "toxique_drogues",
                            "Drogues", toxiques);

                        AjouterTexte(ligne, "toxique_autres", toxiques);

                        // Affecter les colonnes calculées
                        ligne["medicaux_texte"] =
                            TexteOuNonRenseigne(medicaux);

                        ligne["psychiatriques_texte"] =
                            TexteOuNonRenseigne(psychiatriques);

                        ligne["hereditaires_texte"] =
                            TexteOuNonRenseigne(hereditaires);

                        ligne["toxiques_texte"] =
                            TexteOuNonRenseigne(toxiques);
                    }

                    // Les autres sections seront ajoutées ici :
                    // signes vitaux, consultation, examens,
                    // EEG et traitements.

                    // =====================================
                    // 3. SIGNES VITAUX
                    // =====================================

                    string sqlSignes = @"
                            SELECT
                                id_signe,
                                temperature,
                                tension,
                                frequence_cardiaque,
                                poids,
                                taille,
                                etat,
                                date_prise
                            FROM signes_vitaux
                            WHERE id_patient = @id_patient
                            ORDER BY date_prise DESC, id_signe DESC
                            LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(sqlSignes, connexion))
                    {
                        cmd.Parameters.AddWithValue("@id_patient", idPatient);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(ds.dtSignesVitaux);
                        }
                    }

                    // =====================================
                    // 4. EXAMEN NEUROLOGIQUE
                    // =====================================

                    string sqlNeuro = @"
                            SELECT
                                id_examen_neurologique,
                                conscience,
                                orientation_temporo_spatiale,
                                langage,
                                memoire,
                                nerfs_craniens,
                                force_musculaire,
                                tonus,
                                reflexes,
                                sensibilite,
                                coordination,
                                marche
                            FROM examen_neurologique
                            WHERE id_patient = @id_patient
                            ORDER BY date_enregistrement DESC,
                                     id_examen_neurologique DESC
                            LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(sqlNeuro, connexion))
                    {
                        cmd.Parameters.AddWithValue("@id_patient", idPatient);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(ds.dtExamenNeuro);
                        }
                    }

                    // =====================================
                    // 5. CONSULTATION
                    // =====================================

                    string sqlConsultation = @"
                            SELECT
                                id,
                                motif,
                                historique_maladie,
                                diagnostic_id
                            FROM consultation
                            WHERE patient_id = @id_patient
                            ORDER BY date_consultation DESC, id DESC
                            LIMIT 1;";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sqlConsultation, connexion))
                    {
                        cmd.Parameters.AddWithValue("@id_patient", idPatient);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(ds.dtConsultation);
                        }
                    }

                    // =====================================
                    // 6. EXAMEN PSYCHIATRIQUE
                    // =====================================

                    string sqlPsy = @"
                            SELECT
                                id_examen_psychiatrique,
                                apparence_generale,
                                contact,
                                humeur,
                                discours,
                                pensee,
                                hallucination,
                                idees_suicidaires,
                                jugement
                            FROM examen_psychiatrique
                            WHERE id_patient = @id_patient
                            ORDER BY date_enregistrement DESC,
                                     id_examen_psychiatrique DESC
                            LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(sqlPsy, connexion))
                    {
                        cmd.Parameters.AddWithValue("@id_patient", idPatient);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(ds.dtExamenPsy);
                        }
                    }

                    // =====================================
                    // 7. EXAMENS EEG
                    // =====================================

                    string sqlEEG = @"
                        SELECT
                            id_patient,
                            type_EEG,
                            resultat,
                            interpretation,
                            observations 
                        FROM examens_eeg
                        WHERE id_patient = @id_patient
                        ORDER BY date_examen DESC
                        LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(sqlEEG, connexion))
                    {
                        cmd.Parameters.AddWithValue("@id_patient", idPatient);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(ds.dtEEG);
                        }
                    }

                    // =====================================
                    // 8. TRAITEMENTS PRESCRITS
                    // =====================================

                    string sqlTraitement = "SELECT m.nom,m.dosage,m.FORME,p.quantite,p.unite,p.statut,p.date_prescription FROM prescriptions p INNER JOIN medicament m ON p.id_medicament = m.id WHERE p.id_patient = @id_patient ORDER BY p.date_prescription DESC, p.id_prescription DESC";

                    using (MySqlCommand cmd = new MySqlCommand(sqlTraitement, connexion))
                    {
                        cmd.Parameters.AddWithValue("@id_patient", idPatient);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(ds.dtTraitement);
                        }
                    }
                }
                // =====================================
                // 4. ENVOYER LES DONNÉES AU REPORTVIEWER
                // =====================================

                reportViewer1.LocalReport.DataSources.Clear();

                // =====================================
                // ASSOCIER TOUS LES DATATABLES AU RAPPORT RDLC
                // =====================================

                reportViewer1.LocalReport.DataSources.Clear();

                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("dsPatient",
                        (System.Data.DataTable)ds.dtPatient));

                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("dsAntecedents",
                        (System.Data.DataTable)ds.dtAntecedents));

                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("dsSignes",
                        (System.Data.DataTable)ds.dtSignesVitaux));

                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("dsExamen_neurologique",
                        (System.Data.DataTable)ds.dtExamenNeuro));

                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("dsConsultation",
                        (System.Data.DataTable)ds.dtConsultation));

                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("dsPsychiatrique",
                        (System.Data.DataTable)ds.dtExamenPsy));

                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("dsEEG",
                        (System.Data.DataTable)ds.dtEEG));

                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("dsTraitement",
                        (System.Data.DataTable)ds.dtTraitement));

                // =====================================
                // PARAMÈTRES DU RAPPORT
                // =====================================

                string age = "Non renseigné";
               
                // Récupérer la date de naissance du patient
                if (ds.dtPatient.Rows.Count > 0)
                {
                    DataRow patient = ds.dtPatient.Rows[0];

                    if (patient["date_naissance"] != DBNull.Value)
                    {
                        DateTime dateNaissance = Convert.ToDateTime(patient["date_naissance"]);
                        DateTime aujourdHui = DateTime.Today;
                        int agePatient = aujourdHui.Year - dateNaissance.Year;

                        if (dateNaissance.Date > aujourdHui.AddYears(-agePatient))
                        {
                            agePatient--;
                        }

                        age = agePatient.ToString() + " ans";
                    }
                }

           
                // Créer les paramètres RDLC
                // =====================================
                // PARAMÈTRES DU RAPPORT RDLC
                // =====================================

                ReportParameter[] parametres = new ReportParameter[]
                {
                    new ReportParameter("age", age),
                    new ReportParameter("numeroFiche", numeroFiche),
                    new ReportParameter("date", date_entree)
                };

                reportViewer1.LocalReport.SetParameters(parametres);

                reportViewer1.RefreshReport();
                reportViewer1.LocalReport.SetParameters(parametres);

                // Actualiser le rapport
                reportViewer1.RefreshReport();
                // Actualiser le rapport
                reportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement de la fiche : "+ ex.Message,"Erreur",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================
        // MÉTHODES UTILITAIRES POUR LES ANTÉCÉDENTS
        // =====================================

        private void AjouterSiVrai(DataRow ligne,string colonne,string libelle,StringBuilder resultat)
        {
            if (ligne.Table.Columns.Contains(colonne) && ligne[colonne] != DBNull.Value && Convert.ToInt32(ligne[colonne]) == 1)
            {
                if (resultat.Length > 0)
                    resultat.Append(", ");

                resultat.Append(libelle);
            }
        }

        private void AjouterTexte(DataRow ligne,string colonne,StringBuilder resultat)
        {
            if (ligne.Table.Columns.Contains(colonne) &&
                ligne[colonne] != DBNull.Value)
            {
                string valeur = ligne[colonne].ToString().Trim();

                if (valeur != "")
                {
                    if (resultat.Length > 0)
                        resultat.Append(", ");

                    resultat.Append(valeur);
                }
            }
        }

        private string TexteOuNonRenseigne(StringBuilder texte)
        {
            if (texte.Length == 0)
                return "Non renseigné";

            return texte.ToString();
        }
    }
}