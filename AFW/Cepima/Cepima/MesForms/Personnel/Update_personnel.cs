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
using Cepima.Services;

namespace Cepima.MesForms.Personnel
{
    public partial class Update_personnel : Form
    {
        string id_personnel;
        Database db = new Database();

        public Update_personnel(string id_)
        {
            InitializeComponent();
            this.id_personnel = id_;
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            try
            {
                string queryUpdate = "UPDATE personnels SET nom=@nom,post_nom=@post,prenom=@prenom,sexe=@sexe,situation_familliale=@sifa,date_naissance=@naissance,date_embauche=@embauche,fonction=@fonction,telephone=@phone,adresse=@adresse WHERE id_personnel = @id";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@nom",tb_mod_nom.Text);
                MesClasses.ManagerClasse.request_params.Add("@post",tb_mod_post.Text);
                MesClasses.ManagerClasse.request_params.Add("@prenom",tb_mod_prenom.Text);
                MesClasses.ManagerClasse.request_params.Add("@sexe",tb_mod_sexe.Text);
                MesClasses.ManagerClasse.request_params.Add("@sifa",tb_mod_sifa.Text);
                MesClasses.ManagerClasse.request_params.Add("@naissance",dt_naissance.Value.Date.ToString("yyyy-MM-dd"));
                MesClasses.ManagerClasse.request_params.Add("@embauche",dt_embauche.Value.Date.ToString("yyyy-MM-dd"));
                MesClasses.ManagerClasse.request_params.Add("@fonction",tb_mod_fonction.Text);
                MesClasses.ManagerClasse.request_params.Add("@phone", tb_mod_phone.Text);
                MesClasses.ManagerClasse.request_params.Add("@adresse", tb_mod_adresse.Text);
                MesClasses.ManagerClasse.request_params.Add("@id",this.id_personnel);

                MesClasses.ManagerClasse.CRUD(queryUpdate,MesClasses.ManagerClasse.request_params);
                MessageBox.Show("Modification réussie avec succès!!");
                MesForms.Personnel.Detail_Test.btRefresh.PerformClick();
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erreur : "+ex.Message);
            }
        }

        private void Update_personnel_Load(object sender, EventArgs e)
        {
            int fingerprint_id = 0;

            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string query = "SELECT nom,post_nom,prenom,sexe,date_naissance,situation_familliale,date_embauche,adresse,telephone,fonction, fingerprint_id FROM personnels WHERE id_personnel =  @id";
                    MesClasses.ManagerClasse.request_params.Clear();
                    MesClasses.ManagerClasse.request_params.Add("@id",this.id_personnel);
                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
                    {
                        while (reader.Read())
                        {
                            tb_mod_nom.Text = reader["nom"].ToString();
                            tb_mod_post.Text = reader["post_nom"].ToString();
                            tb_mod_prenom.Text = reader["prenom"].ToString();
                            tb_mod_sexe.Text = reader["sexe"].ToString();
                            tb_mod_sifa.Text = reader["situation_familliale"].ToString();
                            tb_mod_phone.Text = reader["telephone"].ToString();
                            tb_mod_adresse.Text = reader["adresse"].ToString();
                            tb_mod_fonction.Text = reader["fonction"].ToString();
                            dt_embauche.Value = Convert.ToDateTime(reader["date_embauche"]);
                            dt_naissance.Value = Convert.ToDateTime(reader["date_naissance"]);
                            //fingerprint_id = Convert.ToInt32(reader["fingerprint_id"]);

                            if (reader["fingerprint_id"] != DBNull.Value)
                            {
                                picture_fingerprint.Visible = true;
                            }
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erreur : "+ex.Message);
                }
            }
        }

        private void SetFormBusy(bool busy, string message)
        {
            this.UseWaitCursor = busy;
            this.Enabled = !busy;

            if (busy && !string.IsNullOrEmpty(message))
            {
                this.Text = "CEPIMA - " + message;
            }
            else
            {
                this.Text = "CEPIMA - Ajout du personnel";
            }

            Application.DoEvents();
        }

        // ======================================================
        // Remplacer l'empreint
        // ======================================================
        private async Task<bool> RemplacerEmpreinteAsync(
            int fingerprintId)
        {
            if (fingerprintId <= 0)
            {
                MessageBox.Show(
                    "Fingerprint ID invalide.",
                    "CEPIMA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            try
            {
                // 1. Demander l'enrôlement avec l'ID existant
                SetFormBusy(
                    true,
                    "Préparation du remplacement de l'empreinte...");

                bool demarre =
                    await FingerprintApi.StartFingerprintEnrollment(
                        fingerprintId);

                if (!demarre)
                {
                    MessageBox.Show(
                        "Impossible de lancer le remplacement de l'empreinte.",
                        "CEPIMA - R307",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return false;
                }

                // 2. Attendre le résultat de l'enrôlement
                SetFormBusy(
                    true,
                    "Placez votre doigt sur le capteur...");

                string resultat =
                    await FingerprintApi.WaitEnrollmentResult(
                        fingerprintId);

                if (resultat != "success")
                {
                    MessageBox.Show(
                        "Le remplacement de l'empreinte a échoué.\n\n"
                        + "Résultat : "
                        + resultat,
                        "CEPIMA - R307",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return false;
                }

                Save_fingerprint_id(Convert.ToInt32(id_personnel), fingerprintId);

                MessageBox.Show(
                    "L'empreinte a été remplacée avec succès.\n\n"
                    + "Fingerprint ID : "
                    + fingerprintId,
                    "CEPIMA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du remplacement de l'empreinte :\n\n"
                    + ex.Message,
                    "CEPIMA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                SetFormBusy(false, "");
            }
        }

        private void Save_fingerprint_id(int personnel_id, int fingerprint_id)
        {

            string query = "UPDATE personnels SET fingerprint_id = @fingerprint_id WHERE id_personnel = @personnel_id";

            try
            {

                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@fingerprint_id", fingerprint_id);
                        cmd.Parameters.AddWithValue("@personnel_id", personnel_id);

                        cmd.ExecuteNonQuery();

                        con.Close();
                    }
                }
            }

            catch (Exception e)
            {
                MessageBox.Show("Erreur lors de l'enregistrement de l'mpreint\n" + e.Message);
            }
        }

        private int ObtenirFingerprintId(int idPersonnel)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();

                // 1. Vérifier si le personnel possède déjà un numéro.

                string sqlExistant = @"
            SELECT fingerprint_id
            FROM personnels
            WHERE id_personnel = @id_personnel
            LIMIT 1";

                using (MySqlCommand cmd =
                    new MySqlCommand(sqlExistant, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@id_personnel",
                        idPersonnel);

                    object resultat = cmd.ExecuteScalar();

                    if (resultat == null)
                    {
                        throw new Exception(
                            "Ce personnel n'existe pas dans la base de données.");
                    }

                    if (resultat != DBNull.Value)
                    {
                        int fingerprintId =
                            Convert.ToInt32(resultat);

                        if (fingerprintId > 0)
                            return fingerprintId;
                    }
                }

                // 2. Aucun numéro : calculer le prochain numéro.

                string sqlSuivant = @"
                    SELECT COALESCE(MAX(fingerprint_id), 0) + 1
                    FROM personnels";

                using (MySqlCommand cmd =
                    new MySqlCommand(sqlSuivant, con))
                {
                    return Convert.ToInt32(
                        cmd.ExecuteScalar());
                }
            }
        }

        // Bouton
        private async void btn_remplacer_empreinte_Click(
            object sender,
            EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show(
                "Voulez-vous remplacer l'empreinte de ce personnel ?",
                "CEPIMA - Remplacement",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes)
                return;

            int _fingerprintId = ObtenirFingerprintId(Convert.ToInt32(id_personnel));

            await RemplacerEmpreinteAsync(_fingerprintId);
        }
    }
}
