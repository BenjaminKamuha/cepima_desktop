using System;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Cepima.Services;
using Cepima.Data;

namespace Cepima.MesUserCases.Personnels
{
    public partial class User_fingerprint : UserControl
    {
        // =========================================================
        // CONFIGURATION ESP32
        // =========================================================

        private const string ESP32_IP =
            "192.168.239.50";

        private const int ESP32_PORT = 8080;

        private const string ESP32_BASE_URL =
            "http://192.168.239.50:8080";


        // =========================================================
        // CONSTRUCTEUR
        // =========================================================

        public User_fingerprint()
        {
            InitializeComponent();

            this.Load += User_fingerprint_Load;

            txt_recherche.TextChanged +=
                txt_recherche_TextChanged;

            cbx_filter.SelectedIndexChanged +=
                cbx_filter_SelectedIndexChanged;

            dgv_personnel.CellContentClick +=
                dgv_personnel_CellContentClick;
        }


        // =========================================================
        // LOAD
        // =========================================================

        private void User_fingerprint_Load(
            object sender,
            EventArgs e)
        {
            InitialiserFiltre();

            ConfigurerDataGridView();

            ChargerPersonnel();
        }


        // =========================================================
        // FILTRE
        // =========================================================

        private void InitialiserFiltre()
        {
            cbx_filter.Items.Clear();

            cbx_filter.Items.Add(
                "Tous");

            cbx_filter.Items.Add(
                "Avec empreinte");

            cbx_filter.Items.Add(
                "Sans empreinte");

            cbx_filter.SelectedIndex = 0;
        }


        // =========================================================
        // CONFIGURATION DATAGRID
        // =========================================================

        private void ConfigurerDataGridView()
        {
            dgv_personnel.Columns.Clear();

            dgv_personnel.AutoGenerateColumns = false;

            // -----------------------------------------------------
            // ID
            // -----------------------------------------------------

            DataGridViewTextBoxColumn colId =
                new DataGridViewTextBoxColumn();

            colId.Name = "id_personnel";
            colId.HeaderText = "ID";
            colId.DataPropertyName = "id_personnel";
            colId.Visible = false;

            dgv_personnel.Columns.Add(colId);


            // -----------------------------------------------------
            // NOM
            // -----------------------------------------------------

            DataGridViewTextBoxColumn colNom =
                new DataGridViewTextBoxColumn();

            colNom.Name = "nom";
            colNom.HeaderText = "Nom";
            colNom.DataPropertyName = "nom";

            dgv_personnel.Columns.Add(colNom);


            // -----------------------------------------------------
            // POST NOM
            // -----------------------------------------------------

            DataGridViewTextBoxColumn colPostNom =
                new DataGridViewTextBoxColumn();

            colPostNom.Name = "post_nom";
            colPostNom.HeaderText = "Post-nom";
            colPostNom.DataPropertyName = "post_nom";

            dgv_personnel.Columns.Add(colPostNom);


            // -----------------------------------------------------
            // PRENOM
            // -----------------------------------------------------

            DataGridViewTextBoxColumn colPrenom =
                new DataGridViewTextBoxColumn();

            colPrenom.Name = "prenom";
            colPrenom.HeaderText = "Prénom";
            colPrenom.DataPropertyName = "prenom";

            dgv_personnel.Columns.Add(colPrenom);


            // -----------------------------------------------------
            // FONCTION
            // -----------------------------------------------------

            DataGridViewTextBoxColumn colFonction =
                new DataGridViewTextBoxColumn();

            colFonction.Name = "fonction";
            colFonction.HeaderText = "Fonction";
            colFonction.DataPropertyName = "fonction";

            dgv_personnel.Columns.Add(colFonction);


            // -----------------------------------------------------
            // FINGERPRINT
            // -----------------------------------------------------

            DataGridViewTextBoxColumn colFingerprint =
                new DataGridViewTextBoxColumn();

            colFingerprint.Name =
                "fingerprint_id";

            colFingerprint.HeaderText =
                "Empreinte";

            colFingerprint.DataPropertyName =
                "fingerprint_id";

            dgv_personnel.Columns.Add(
                colFingerprint);


            // -----------------------------------------------------
            // STATUT
            // -----------------------------------------------------

            DataGridViewTextBoxColumn colStatut =
                new DataGridViewTextBoxColumn();

            colStatut.Name =
                "statut_fingerprint";

            colStatut.HeaderText =
                "Statut";

            dgv_personnel.Columns.Add(
                colStatut);


            // -----------------------------------------------------
            // ACTION ENROLER
            // -----------------------------------------------------

            DataGridViewButtonColumn colEnroll =
                new DataGridViewButtonColumn();

            colEnroll.Name =
                "btn_enroler";

            colEnroll.HeaderText =
                "Action";

            colEnroll.Text =
                "Enrôler";

            colEnroll.UseColumnTextForButtonValue =
                false;

            dgv_personnel.Columns.Add(
                colEnroll);


            // -----------------------------------------------------
            // REMPLACER
            // -----------------------------------------------------

            DataGridViewButtonColumn colReplace =
                new DataGridViewButtonColumn();

            colReplace.Name =
                "btn_remplacer";

            colReplace.HeaderText =
                "";

            colReplace.Text =
                "Remplacer";

            colReplace.UseColumnTextForButtonValue =
                false;

            dgv_personnel.Columns.Add(
                colReplace);


            // -----------------------------------------------------
            // SUPPRIMER
            // -----------------------------------------------------

            DataGridViewButtonColumn colDelete =
                new DataGridViewButtonColumn();

            colDelete.Name =
                "btn_supprimer";

            colDelete.HeaderText =
                "";

            colDelete.Text =
                "Supprimer";

            colDelete.UseColumnTextForButtonValue =
                false;

            dgv_personnel.Columns.Add(
                colDelete);


            // -----------------------------------------------------
            // STYLE BOUTONS
            // -----------------------------------------------------

            dgv_personnel.Columns[
                "btn_enroler"
            ].DefaultCellStyle.BackColor =
                Color.SeaGreen;

            dgv_personnel.Columns[
                "btn_enroler"
            ].DefaultCellStyle.ForeColor =
                Color.White;


            dgv_personnel.Columns[
                "btn_remplacer"
            ].DefaultCellStyle.BackColor =
                Color.DarkOrange;

            dgv_personnel.Columns[
                "btn_remplacer"
            ].DefaultCellStyle.ForeColor =
                Color.White;


            dgv_personnel.Columns[
                "btn_supprimer"
            ].DefaultCellStyle.BackColor =
                Color.Firebrick;

            dgv_personnel.Columns[
                "btn_supprimer"
            ].DefaultCellStyle.ForeColor =
                Color.White;
        }


        // =========================================================
        // CHARGER PERSONNEL
        // =========================================================

        private void ChargerPersonnel()
        {
            try
            {
                using (
                    MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {

                    string sql =
                        "SELECT " +
                        "id_personnel, " +
                        "nom, " +
                        "post_nom, " +
                        "prenom, " +
                        "fonction, " +
                        "fingerprint_id " +
                        "FROM personnels ";

                    string recherche =
                        txt_recherche.Text.Trim();

                    if (recherche.Length > 0)
                    {
                        sql +=
                            "WHERE " +
                            "(nom LIKE @recherche " +
                            "OR post_nom LIKE @recherche " +
                            "OR prenom LIKE @recherche) ";
                    }

                    if (cbx_filter.SelectedIndex == 1)
                    {
                        if (recherche.Length > 0)
                            sql += "AND ";

                        else
                            sql += "WHERE ";

                        sql +=
                            "fingerprint_id IS NOT NULL ";
                    }

                    else if (
                        cbx_filter.SelectedIndex == 2)
                    {
                        if (recherche.Length > 0)
                            sql += "AND ";

                        else
                            sql += "WHERE ";

                        sql +=
                            "fingerprint_id IS NULL ";
                    }

                    sql +=
                        "ORDER BY nom, post_nom, prenom";


                    using (
                        MySqlCommand cmd =
                        new MySqlCommand(
                            sql,
                            con))
                    {
                        if (recherche.Length > 0)
                        {
                            cmd.Parameters.AddWithValue(
                                "@recherche",
                                "%" +
                                recherche +
                                "%");
                        }

                        using (
                            MySqlDataAdapter adapter =
                            new MySqlDataAdapter(cmd))
                        {
                            DataTable table =
                                new DataTable();

                            adapter.Fill(table);

                            AjouterStatut(
                                table);

                            dgv_personnel.DataSource =
                                table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur de chargement :\n\n" +
                    ex.Message,
                    "CEPIMA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // AJOUTER STATUT
        // =========================================================

        private void AjouterStatut(
            DataTable table)
        {
            if (
                !table.Columns.Contains(
                    "statut_fingerprint"))
            {
                table.Columns.Add(
                    "statut_fingerprint",
                    typeof(string));
            }

            foreach (
                DataRow row in table.Rows)
            {
                if (
                    row["fingerprint_id"] ==
                    DBNull.Value)
                {
                    row["statut_fingerprint"] =
                        "Aucune empreinte";
                }
                else
                {
                    row["statut_fingerprint"] =
                        "Enregistrée";
                }
            }
        }


        // =========================================================
        // RECHERCHE
        // =========================================================

        private void txt_recherche_TextChanged(
            object sender,
            EventArgs e)
        {
            ChargerPersonnel();
        }


        // =========================================================
        // FILTRE
        // =========================================================

        private void cbx_filter_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            ChargerPersonnel();
        }


        // =========================================================
        // CLICK DATAGRID
        // =========================================================

        private async void dgv_personnel_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex < 0)
                return;


            DataGridViewRow row =
                dgv_personnel.Rows[
                    e.RowIndex];


            int idPersonnel =
                Convert.ToInt32(
                    row.Cells[
                        "id_personnel"].Value);


            string nom =
                Convert.ToString(
                    row.Cells["nom"].Value);

            string postNom =
                Convert.ToString(
                    row.Cells["post_nom"].Value);

            string prenom =
                Convert.ToString(
                    row.Cells["prenom"].Value);


            string colonne =
                dgv_personnel.Columns[
                    e.ColumnIndex].Name;


            // =====================================================
            // ENROLER
            // =====================================================

            if (colonne ==
                "btn_enroler")
            {
                await EnrolerPersonnel(
                    idPersonnel,
                    nom,
                    postNom,
                    prenom);

                return;
            }


            // =====================================================
            // REMPLACER
            // =====================================================

            if (colonne ==
                "btn_remplacer")
            {
                object value =
                    row.Cells[
                        "fingerprint_id"].Value;

                if (
                    value == null ||
                    value == DBNull.Value)
                {
                    return;
                }

                int fingerprintId =
                    Convert.ToInt32(value);

                await RemplacerEmpreinte(
                    idPersonnel,
                    fingerprintId,
                    nom,
                    postNom,
                    prenom);

                return;
            }


            // =====================================================
            // SUPPRIMER
            // =====================================================

            if (colonne ==
                "btn_supprimer")
            {
                object value =
                    row.Cells[
                        "fingerprint_id"].Value;

                if (
                    value == null ||
                    value == DBNull.Value)
                {
                    return;
                }

                int fingerprintId =
                    Convert.ToInt32(value);

                await SupprimerEmpreinte(
                    idPersonnel,
                    fingerprintId,
                    nom,
                    postNom,
                    prenom);

                return;
            }
        }


        // =========================================================
        // ENROLER PERSONNEL
        // =========================================================

        private async Task EnrolerPersonnel(
            int idPersonnel,
            string nom,
            string postNom,
            string prenom)
        {
            int fingerprintId =
                GetNextFingerprintId();


            DialogResult confirmation =
                MessageBox.Show(
                    "Agent : " +
                    nom + " " +
                    postNom + " " +
                    prenom +
                    "\n\n" +
                    "ID empreinte proposé : " +
                    fingerprintId +
                    "\n\n" +
                    "Le R307 va passer en mode enrôlement.\n" +
                    "Posez votre doigt lorsque le capteur vous le demande.",
                    "Enrôlement",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);

            if (
                confirmation !=
                DialogResult.OK)
            {
                return;
            }


            bool started =
                await FingerprintApi
                .StartFingerprintEnrollment(
                    fingerprintId);


            if (!started)
            {
                MessageBox.Show(
                    "Impossible de démarrer l'enrôlement sur le R307.",
                    "R307",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            MessageBox.Show(
                "Le R307 est prêt.\n\n" +
                "Posez votre doigt lorsque le capteur le demande.",
                "R307",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);


            string result =
                await FingerprintApi
                .WaitEnrollmentResult(
                    fingerprintId);


            if (result == "success")
            {
                if (
                    UpdateFingerprintId(
                        idPersonnel,
                        fingerprintId))
                {
                    MessageBox.Show(
                        "Empreinte enregistrée avec succès.\n\n" +
                        "ID : " +
                        fingerprintId,
                        "CEPIMA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ChargerPersonnel();
                }

                return;
            }


            if (result == "error")
            {
                MessageBox.Show(
                    "L'enrôlement de l'empreinte a échoué.",
                    "R307",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            MessageBox.Show(
                "Le R307 n'a pas terminé l'enrôlement.",
                "R307",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }


        // =========================================================
        // REMPLACER
        // =========================================================

        private async Task RemplacerEmpreinte(
            int idPersonnel,
            int fingerprintId,
            string nom,
            string postNom,
            string prenom)
        {
            DialogResult result =
                MessageBox.Show(
                    "Agent : " +
                    nom + " " +
                    postNom + " " +
                    prenom +
                    "\n\n" +
                    "Empreinte actuelle : ID " +
                    fingerprintId +
                    "\n\n" +
                    "L'ancienne empreinte sera supprimée " +
                    "du R307 puis remplacée par une nouvelle.\n\n" +
                    "Continuer ?",
                    "Remplacer l'empreinte",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (
                result !=
                DialogResult.Yes)
            {
                return;
            }


            // -----------------------------------------------------
            // SUPPRESSION R307
            // -----------------------------------------------------

            bool deleted =
                await DeleteFingerprintFromEsp32(
                    fingerprintId);


            if (!deleted)
            {
                MessageBox.Show(
                    "Impossible de supprimer l'ancienne empreinte du R307.\n\n" +
                    "Aucune modification n'a été faite dans CEPIMA.",
                    "R307",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            // -----------------------------------------------------
            // ENRÔLEMENT MEME ID
            // -----------------------------------------------------

            bool started =
                await FingerprintApi
                .StartFingerprintEnrollment(
                    fingerprintId);


            if (!started)
            {
                MessageBox.Show(
                    "L'ancienne empreinte a été supprimée,\n" +
                    "mais le nouvel enrôlement n'a pas pu démarrer.",
                    "R307",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            MessageBox.Show(
                "Le R307 est prêt.\n\n" +
                "Posez votre doigt.",
                "Nouvelle empreinte",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);


            string enrollmentResult =
                await FingerprintApi
                .WaitEnrollmentResult(
                    fingerprintId);


            if (
                enrollmentResult ==
                "success")
            {
                MessageBox.Show(
                    "Empreinte remplacée avec succès.\n\n" +
                    "ID : " +
                    fingerprintId,
                    "CEPIMA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ChargerPersonnel();

                return;
            }


            MessageBox.Show(
                "Le remplacement de l'empreinte a échoué.",
                "R307",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }


        // =========================================================
        // SUPPRIMER EMPREINTE
        // =========================================================

        private async Task SupprimerEmpreinte(
            int idPersonnel,
            int fingerprintId,
            string nom,
            string postNom,
            string prenom)
        {
            DialogResult result =
                MessageBox.Show(
                    "Voulez-vous vraiment supprimer l'empreinte de :\n\n" +
                    nom + " " +
                    postNom + " " +
                    prenom +
                    "\n\n" +
                    "ID empreinte : " +
                    fingerprintId,
                    "Suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (
                result !=
                DialogResult.Yes)
            {
                return;
            }


            bool deleted =
                await DeleteFingerprintFromEsp32(
                    fingerprintId);


            if (!deleted)
            {
                MessageBox.Show(
                    "Impossible de supprimer l'empreinte du R307.\n\n" +
                    "L'association dans CEPIMA n'a pas été supprimée.",
                    "R307",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            if (
                RemoveFingerprintFromDatabase(
                    idPersonnel))
            {
                MessageBox.Show(
                    "Empreinte supprimée avec succès.",
                    "CEPIMA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ChargerPersonnel();
            }
        }


        // =========================================================
        // PROCHAIN ID
        // =========================================================

        private int GetNextFingerprintId()
        {
            using (
                MySqlConnection con =
                MesClasses.ManagerClasse.GetConnexion())
            {

                string sql =
                    "SELECT COALESCE(" +
                    "MAX(fingerprint_id), 0) + 1 " +
                    "FROM personnels";

                using (
                    MySqlCommand cmd =
                    new MySqlCommand(
                        sql,
                        con))
                {
                    return Convert.ToInt32(
                        cmd.ExecuteScalar());
                }
            }
        }


        // =========================================================
        // METTRE A JOUR FINGERPRINT_ID
        // =========================================================

        private bool UpdateFingerprintId(
            int idPersonnel,
            int fingerprintId)
        {
            try
            {
                using (
                    MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {

                    string sql =
                        "UPDATE personnels " +
                        "SET fingerprint_id = @fingerprint_id " +
                        "WHERE id_personnel = @id_personnel";

                    using (
                        MySqlCommand cmd =
                        new MySqlCommand(
                            sql,
                            con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@fingerprint_id",
                            fingerprintId);

                        cmd.Parameters.AddWithValue(
                            "@id_personnel",
                            idPersonnel);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur mise à jour empreinte :\n\n" +
                    ex.Message,
                    "MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }


        // =========================================================
        // SUPPRIMER ASSOCIATION MYSQL
        // =========================================================

        private bool RemoveFingerprintFromDatabase(
            int idPersonnel)
        {
            try
            {
                using (
                    MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {

                    string sql =
                        "UPDATE personnels " +
                        "SET fingerprint_id = NULL " +
                        "WHERE id_personnel = @id_personnel";

                    using (
                        MySqlCommand cmd =
                        new MySqlCommand(
                            sql,
                            con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_personnel",
                            idPersonnel);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur suppression empreinte :\n\n" +
                    ex.Message,
                    "MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }


        // =========================================================
        // DELETE R307
        // =========================================================

        private async Task<bool>
            DeleteFingerprintFromEsp32(
                int fingerprintId)
        {
            try
            {
                string url =
                    ESP32_BASE_URL +
                    "/api/fingerprint/delete";

                string json =
                    "{\"fingerprint_id\":" +
                    fingerprintId +
                    "}";

                HttpWebRequest request =
                    (HttpWebRequest)
                    WebRequest.Create(url);

                request.Method =
                    "POST";

                request.ContentType =
                    "application/json";

                request.Timeout =
                    5000;

                byte[] data =
                    Encoding.UTF8.GetBytes(
                        json);

                request.ContentLength =
                    data.Length;

                using (
                    var stream =
                    await request
                    .GetRequestStreamAsync())
                {
                    await stream.WriteAsync(
                        data,
                        0,
                        data.Length);
                }

                using (
                    HttpWebResponse response =
                    (HttpWebResponse)
                    await request
                    .GetResponseAsync())
                {
                    string body = "";

                    using (
                        var stream =
                        response.GetResponseStream())
                    {
                        if (stream != null)
                        {
                            using (
                                var reader =
                                new System.IO.StreamReader(
                                    stream))
                            {
                                body =
                                    await reader
                                    .ReadToEndAsync();
                            }
                        }
                    }

                    Console.WriteLine(
                        "DELETE R307 : " +
                        body);

                    return
                        response.StatusCode ==
                        HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Erreur DELETE R307 : " +
                    ex.Message);

                return false;
            }
        }
    }
}