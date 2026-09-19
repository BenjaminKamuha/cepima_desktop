using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Cepima.Data;

namespace Cepima.MesUserCases.Services
{
    public partial class User_services : UserControl
    {
        private Database db = new Database();

        private int serviceSelectionneId = 0;

        public User_services()
        {
            InitializeComponent();

            InitialiserInterface();

            ChargerServices();
            ChargerPrestations();
        }

        // ============================================================
        // INITIALISATION
        // ============================================================

        private void InitialiserInterface()
        {
            tb_search_service.TextChanged +=
                tb_search_service_TextChanged;

            tb_search_prestation.TextChanged +=
                tb_search_prestation_TextChanged;

            dgv_services.CellClick +=
                dgv_services_CellClick;

            dgv_services.CellDoubleClick +=
                dgv_services_CellDoubleClick;

            dgv_prestation.CellDoubleClick +=
                dgv_prestation_CellDoubleClick;

            btn_add_service.Click +=
                btn_add_service_Click;

            btn_add_prestation.Click +=
                btn_add_prestation_Click;
        }

        // ============================================================
        // CHARGER SERVICES
        // ============================================================

        private void ChargerServices(string recherche = "")
        {
            try
            {
                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"
                        SELECT
                            id_service,
                            nom,
                            description,
                            actif
                        FROM service
                        WHERE
                            nom LIKE @recherche
                            OR description LIKE @recherche
                        ORDER BY nom ASC";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@recherche",
                            "%" + recherche + "%"
                        );

                        using (MySqlDataAdapter da =
                            new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();

                            da.Fill(dt);

                            dgv_services.DataSource = dt;
                        }
                    }
                }

                ConfigurerDgvServices();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des services.\n\n" +
                    ex.Message,
                    "Services",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ============================================================
        // CONFIGURATION DGV SERVICES
        // ============================================================

        private void ConfigurerDgvServices()
        {
            if (dgv_services.Columns.Contains("id_service"))
                dgv_services.Columns["id_service"].Visible = false;

            if (dgv_services.Columns.Contains("nom"))
                dgv_services.Columns["nom"].HeaderText =
                    "Service";

            if (dgv_services.Columns.Contains("description"))
                dgv_services.Columns["description"].HeaderText =
                    "Description";

            if (dgv_services.Columns.Contains("actif"))
            {
                dgv_services.Columns["actif"].HeaderText =
                    "État";

                dgv_services.Columns["actif"]
                    .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // ============================================================
        // SELECTION SERVICE
        // ============================================================

        private void dgv_services_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow ligne =
                dgv_services.Rows[e.RowIndex];

            object valeur =
                ligne.Cells["id_service"].Value;

            if (valeur == null ||
                valeur == DBNull.Value)
                return;

            serviceSelectionneId =
                Convert.ToInt32(valeur);

            ChargerPrestations();
        }

        // ============================================================
        // DOUBLE CLIC SERVICE
        // Modifier / Activer / Désactiver
        // ============================================================

        private void dgv_services_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow ligne =
                dgv_services.Rows[e.RowIndex];

            int idService =
                Convert.ToInt32(
                    ligne.Cells["id_service"].Value
                );

            string nom =
                ligne.Cells["nom"].Value.ToString();

            string description =
                ligne.Cells["description"].Value == DBNull.Value
                    ? ""
                    : ligne.Cells["description"].Value.ToString();

            bool actif =
                Convert.ToBoolean(
                    ligne.Cells["actif"].Value
                );

            DialogResult resultat =
                MessageBox.Show(
                    "Que voulez-vous faire avec le service :\n\n" +
                    nom +
                    "\n\nOui = Modifier\n" +
                    "Non = " +
                    (actif ? "Désactiver" : "Activer") +
                    "\nAnnuler = Fermer",
                    "Gestion du service",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

            if (resultat == DialogResult.Yes)
            {
                ModifierService(
                    idService,
                    nom,
                    description
                );
            }
            else if (resultat == DialogResult.No)
            {
                ChangerEtatService(
                    idService,
                    !actif
                );

                ChargerServices();
            }
        }

        // ============================================================
        // MODIFIER SERVICE
        // ============================================================

        private void ModifierService(
            int idService,
            string ancienNom,
            string ancienneDescription)
        {
            using (Form form = new Form())
            {
                form.Text = "Modifier le service";
                form.Size = new Size(450, 260);
                form.StartPosition =
                    FormStartPosition.CenterParent;
                form.FormBorderStyle =
                    FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                Label lbNom = new Label();
                lbNom.Text = "Nom du service";
                lbNom.Location = new Point(25, 25);
                lbNom.AutoSize = true;

                TextBox tbNom = new TextBox();
                tbNom.Text = ancienNom;
                tbNom.Location = new Point(25, 50);
                tbNom.Width = 380;

                Label lbDescription = new Label();
                lbDescription.Text = "Description";
                lbDescription.Location =
                    new Point(25, 85);
                lbDescription.AutoSize = true;

                TextBox tbDescription = new TextBox();
                tbDescription.Text =
                    ancienneDescription;
                tbDescription.Location =
                    new Point(25, 110);
                tbDescription.Width = 380;

                Button btnOk = new Button();
                btnOk.Text = "Enregistrer";
                btnOk.Location =
                    new Point(215, 160);
                btnOk.Width = 90;
                btnOk.DialogResult =
                    DialogResult.OK;

                Button btnAnnuler = new Button();
                btnAnnuler.Text = "Annuler";
                btnAnnuler.Location =
                    new Point(315, 160);
                btnAnnuler.Width = 90;
                btnAnnuler.DialogResult =
                    DialogResult.Cancel;

                form.Controls.Add(lbNom);
                form.Controls.Add(tbNom);
                form.Controls.Add(lbDescription);
                form.Controls.Add(tbDescription);
                form.Controls.Add(btnOk);
                form.Controls.Add(btnAnnuler);

                form.AcceptButton = btnOk;
                form.CancelButton = btnAnnuler;

                if (form.ShowDialog() != DialogResult.OK)
                    return;

                if (string.IsNullOrWhiteSpace(tbNom.Text))
                {
                    MessageBox.Show(
                        "Le nom du service est obligatoire.",
                        "Service",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                try
                {
                    using (MySqlConnection con =
                        db.GetConnection())
                    {
                        con.Open();

                        string query = @"
                            UPDATE service
                            SET
                                nom = @nom,
                                description = @description
                            WHERE id_service = @id";

                        using (MySqlCommand cmd =
                            new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue(
                                "@nom",
                                tbNom.Text.Trim()
                            );

                            cmd.Parameters.AddWithValue(
                                "@description",
                                string.IsNullOrWhiteSpace(
                                    tbDescription.Text)
                                    ? (object)DBNull.Value
                                    : tbDescription.Text.Trim()
                            );

                            cmd.Parameters.AddWithValue(
                                "@id",
                                idService
                            );

                            cmd.ExecuteNonQuery();
                        }
                    }

                    ChargerServices();
                    ChargerPrestations();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur lors de la modification.\n\n" +
                        ex.Message,
                        "Service",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        // ============================================================
        // AJOUTER SERVICE
        // ============================================================

        private void btn_add_service_Click(
            object sender,
            EventArgs e)
        {
            using (Form form = new Form())
            {
                form.Text = "Nouveau service";
                form.Size = new Size(450, 260);
                form.StartPosition =
                    FormStartPosition.CenterParent;
                form.FormBorderStyle =
                    FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                Label lbNom = new Label();
                lbNom.Text = "Nom du service";
                lbNom.Location = new Point(25, 25);
                lbNom.AutoSize = true;

                TextBox tbNom = new TextBox();
                tbNom.Location = new Point(25, 50);
                tbNom.Width = 380;

                Label lbDescription = new Label();
                lbDescription.Text = "Description";
                lbDescription.Location =
                    new Point(25, 85);
                lbDescription.AutoSize = true;

                TextBox tbDescription = new TextBox();
                tbDescription.Location =
                    new Point(25, 110);
                tbDescription.Width = 380;

                Button btnOk = new Button();
                btnOk.Text = "Enregistrer";
                btnOk.Location =
                    new Point(215, 160);
                btnOk.Width = 90;
                btnOk.DialogResult =
                    DialogResult.OK;

                Button btnAnnuler = new Button();
                btnAnnuler.Text = "Annuler";
                btnAnnuler.Location =
                    new Point(315, 160);
                btnAnnuler.Width = 90;
                btnAnnuler.DialogResult =
                    DialogResult.Cancel;

                form.Controls.Add(lbNom);
                form.Controls.Add(tbNom);
                form.Controls.Add(lbDescription);
                form.Controls.Add(tbDescription);
                form.Controls.Add(btnOk);
                form.Controls.Add(btnAnnuler);

                form.AcceptButton = btnOk;
                form.CancelButton = btnAnnuler;

                if (form.ShowDialog() != DialogResult.OK)
                    return;

                if (string.IsNullOrWhiteSpace(tbNom.Text))
                {
                    MessageBox.Show(
                        "Le nom du service est obligatoire.",
                        "Service",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                try
                {
                    using (MySqlConnection con =
                        db.GetConnection())
                    {
                        con.Open();

                        string query = @"
                            INSERT INTO service
                            (
                                nom,
                                description,
                                actif
                            )
                            VALUES
                            (
                                @nom,
                                @description,
                                1
                            )";

                        using (MySqlCommand cmd =
                            new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue(
                                "@nom",
                                tbNom.Text.Trim()
                            );

                            cmd.Parameters.AddWithValue(
                                "@description",
                                string.IsNullOrWhiteSpace(
                                    tbDescription.Text)
                                    ? (object)DBNull.Value
                                    : tbDescription.Text.Trim()
                            );

                            cmd.ExecuteNonQuery();
                        }
                    }

                    ChargerServices();

                    MessageBox.Show(
                        "Service ajouté avec succès.",
                        "Service",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(
                        "Impossible d'ajouter le service.\n\n" +
                        ex.Message,
                        "Service",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        // ============================================================
        // CHARGER PRESTATIONS
        // ============================================================

        private void ChargerPrestations(
            string recherche = "")
        {
            try
            {
                using (MySqlConnection con =
                    db.GetConnection())
                {
                    con.Open();

                    string query = @"
                        SELECT
                            p.id_prestation,
                            p.id_service,
                            p.libelle,
                            p.description,
                            p.unite,
                            p.actif,

                            tp.id_tarif,
                            tp.prix,
                            tp.date_debut,
                            tp.date_fin

                        FROM prestation p

                        LEFT JOIN tarif_prestation tp
                            ON tp.id_prestation =
                               p.id_prestation

                            AND tp.actif = 1

                            AND tp.date_debut <= CURDATE()

                            AND (
                                tp.date_fin IS NULL
                                OR tp.date_fin >= CURDATE()
                            )

                        WHERE
                            (
                                @id_service = 0
                                OR p.id_service = @id_service
                            )

                            AND
                            (
                                p.libelle LIKE @recherche
                                OR p.description LIKE @recherche
                            )

                        ORDER BY p.libelle ASC";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_service",
                            serviceSelectionneId
                        );

                        cmd.Parameters.AddWithValue(
                            "@recherche",
                            "%" + recherche + "%"
                        );

                        using (MySqlDataAdapter da =
                            new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();

                            da.Fill(dt);

                            dgv_prestation.DataSource = dt;
                        }
                    }
                }

                ConfigurerDgvPrestations();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des prestations.\n\n" +
                    ex.Message,
                    "Prestations",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ============================================================
        // CONFIGURATION DGV PRESTATIONS
        // ============================================================

        private void ConfigurerDgvPrestations()
        {
            if (dgv_prestation.Columns.Contains(
                "id_prestation"))
                dgv_prestation.Columns[
                    "id_prestation"].Visible = false;

            if (dgv_prestation.Columns.Contains(
                "id_service"))
                dgv_prestation.Columns[
                    "id_service"].Visible = false;

            if (dgv_prestation.Columns.Contains(
                "id_tarif"))
                dgv_prestation.Columns[
                    "id_tarif"].Visible = false;

            if (dgv_prestation.Columns.Contains(
                "libelle"))
                dgv_prestation.Columns[
                    "libelle"].HeaderText =
                    "Prestation";

            if (dgv_prestation.Columns.Contains(
                "description"))
                dgv_prestation.Columns[
                    "description"].HeaderText =
                    "Description";

            if (dgv_prestation.Columns.Contains(
                "unite"))
                dgv_prestation.Columns[
                    "unite"].HeaderText =
                    "Unité";

            if (dgv_prestation.Columns.Contains(
                "prix"))
            {
                dgv_prestation.Columns[
                    "prix"].HeaderText =
                    "Tarif";

                dgv_prestation.Columns[
                    "prix"].DefaultCellStyle.Format =
                    "N2";
            }

            if (dgv_prestation.Columns.Contains(
                "date_debut"))
                dgv_prestation.Columns[
                    "date_debut"].HeaderText =
                    "Début";

            if (dgv_prestation.Columns.Contains(
                "date_fin"))
                dgv_prestation.Columns[
                    "date_fin"].HeaderText =
                    "Fin";

            if (dgv_prestation.Columns.Contains(
                "actif"))
                dgv_prestation.Columns[
                    "actif"].HeaderText =
                    "Actif";
        }

        // ============================================================
        // DOUBLE CLIC PRESTATION
        // ============================================================

        private void dgv_prestation_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow ligne =
                dgv_prestation.Rows[e.RowIndex];

            int idPrestation =
                Convert.ToInt32(
                    ligne.Cells[
                        "id_prestation"].Value
                );

            string libelle =
                ligne.Cells["libelle"]
                    .Value.ToString();

            string description =
                ligne.Cells["description"]
                    .Value == DBNull.Value
                    ? ""
                    : ligne.Cells["description"]
                        .Value.ToString();

            string unite =
                ligne.Cells["unite"]
                    .Value == DBNull.Value
                    ? ""
                    : ligne.Cells["unite"]
                        .Value.ToString();

            bool actif =
                Convert.ToBoolean(
                    ligne.Cells["actif"].Value
                );

            object prixObjet =
                ligne.Cells["prix"].Value;

            decimal? prix = null;

            if (prixObjet != null &&
                prixObjet != DBNull.Value)
            {
                prix =
                    Convert.ToDecimal(prixObjet);
            }

            DialogResult resultat =
                MessageBox.Show(
                    "Que voulez-vous faire avec :\n\n" +
                    libelle +
                    "\n\nOui = Modifier\n" +
                    "Non = " +
                    (actif ? "Désactiver" : "Activer") +
                    "\nAnnuler = Fermer",
                    "Gestion de la prestation",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

            if (resultat == DialogResult.Yes)
            {
                ModifierPrestation(
                    idPrestation,
                    libelle,
                    description,
                    unite,
                    prix
                );
            }
            else if (resultat == DialogResult.No)
            {
                ChangerEtatPrestation(
                    idPrestation,
                    !actif
                );

                ChargerPrestations();
            }
        }

        // ============================================================
        // MODIFIER PRESTATION
        // ============================================================

        private void ModifierPrestation(
            int idPrestation,
            string ancienLibelle,
            string ancienneDescription,
            string ancienneUnite,
            decimal? ancienPrix)
        {
            using (Form form = new Form())
            {
                form.Text = "Modifier la prestation";
                form.Size = new Size(470, 360);
                form.StartPosition =
                    FormStartPosition.CenterParent;
                form.FormBorderStyle =
                    FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                Label lbLibelle = new Label();
                lbLibelle.Text = "Libellé";
                lbLibelle.Location =
                    new Point(25, 20);
                lbLibelle.AutoSize = true;

                TextBox tbLibelle = new TextBox();
                tbLibelle.Text = ancienLibelle;
                tbLibelle.Location =
                    new Point(25, 45);
                tbLibelle.Width = 400;

                Label lbDescription = new Label();
                lbDescription.Text = "Description";
                lbDescription.Location =
                    new Point(25, 80);
                lbDescription.AutoSize = true;

                TextBox tbDescription = new TextBox();
                tbDescription.Text =
                    ancienneDescription;
                tbDescription.Location =
                    new Point(25, 105);
                tbDescription.Width = 400;

                Label lbUnite = new Label();
                lbUnite.Text = "Unité";
                lbUnite.Location =
                    new Point(25, 140);
                lbUnite.AutoSize = true;

                TextBox tbUnite = new TextBox();
                tbUnite.Text = ancienneUnite;
                tbUnite.Location =
                    new Point(25, 165);
                tbUnite.Width = 180;

                Label lbPrix = new Label();
                lbPrix.Text = "Nouveau tarif";
                lbPrix.Location =
                    new Point(225, 140);
                lbPrix.AutoSize = true;

                NumericUpDown nudPrix =
                    new NumericUpDown();

                nudPrix.Location =
                    new Point(225, 165);

                nudPrix.Width = 200;

                nudPrix.Maximum =
                    1000000000;

                nudPrix.DecimalPlaces = 2;

                nudPrix.ThousandsSeparator = true;

                if (ancienPrix.HasValue)
                    nudPrix.Value =
                        ancienPrix.Value;

                Label lbInfo = new Label();

                lbInfo.Text =
                    "Si le prix change, un nouveau tarif sera créé.";

                lbInfo.Location =
                    new Point(25, 205);

                lbInfo.AutoSize = true;

                Button btnOk = new Button();

                btnOk.Text =
                    "Enregistrer";

                btnOk.Location =
                    new Point(235, 250);

                btnOk.Width = 90;

                btnOk.DialogResult =
                    DialogResult.OK;

                Button btnAnnuler =
                    new Button();

                btnAnnuler.Text =
                    "Annuler";

                btnAnnuler.Location =
                    new Point(335, 250);

                btnAnnuler.Width = 90;

                btnAnnuler.DialogResult =
                    DialogResult.Cancel;

                form.Controls.Add(lbLibelle);
                form.Controls.Add(tbLibelle);

                form.Controls.Add(lbDescription);
                form.Controls.Add(tbDescription);

                form.Controls.Add(lbUnite);
                form.Controls.Add(tbUnite);

                form.Controls.Add(lbPrix);
                form.Controls.Add(nudPrix);

                form.Controls.Add(lbInfo);

                form.Controls.Add(btnOk);
                form.Controls.Add(btnAnnuler);

                form.AcceptButton = btnOk;
                form.CancelButton = btnAnnuler;

                if (form.ShowDialog() !=
                    DialogResult.OK)
                    return;

                if (string.IsNullOrWhiteSpace(
                    tbLibelle.Text))
                {
                    MessageBox.Show(
                        "Le libellé est obligatoire.",
                        "Prestation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                try
                {
                    using (MySqlConnection con =
                        db.GetConnection())
                    {
                        con.Open();

                        MySqlTransaction tr =
                            con.BeginTransaction();

                        try
                        {
                            // ----------------------------------------
                            // Modifier prestation
                            // ----------------------------------------

                            string query = @"
                                UPDATE prestation
                                SET
                                    libelle = @libelle,
                                    description = @description,
                                    unite = @unite
                                WHERE
                                    id_prestation =
                                    @id_prestation";

                            using (MySqlCommand cmd =
                                new MySqlCommand(
                                    query,
                                    con,
                                    tr))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@libelle",
                                    tbLibelle.Text.Trim()
                                );

                                cmd.Parameters.AddWithValue(
                                    "@description",
                                    string.IsNullOrWhiteSpace(
                                        tbDescription.Text)
                                        ? (object)DBNull.Value
                                        : tbDescription.Text.Trim()
                                );

                                cmd.Parameters.AddWithValue(
                                    "@unite",
                                    string.IsNullOrWhiteSpace(
                                        tbUnite.Text)
                                        ? (object)DBNull.Value
                                        : tbUnite.Text.Trim()
                                );

                                cmd.Parameters.AddWithValue(
                                    "@id_prestation",
                                    idPrestation
                                );

                                cmd.ExecuteNonQuery();
                            }

                            // ----------------------------------------
                            // Gestion du tarif
                            // ----------------------------------------

                            decimal nouveauPrix =
                                nudPrix.Value;

                            bool prixChange = false;

                            if (!ancienPrix.HasValue)
                            {
                                prixChange = true;
                            }
                            else if (ancienPrix.Value !=
                                     nouveauPrix)
                            {
                                prixChange = true;
                            }

                            if (prixChange)
                            {
                                FermerAncienTarif(
                                    idPrestation,
                                    DateTime.Now.Date,
                                    con,
                                    tr
                                );

                                CreerTarif(
                                    idPrestation,
                                    nouveauPrix,
                                    DateTime.Now.Date,
                                    con,
                                    tr
                                );
                            }

                            tr.Commit();
                        }
                        catch
                        {
                            try
                            {
                                tr.Rollback();
                            }
                            catch
                            {
                            }

                            throw;
                        }
                    }

                    ChargerPrestations();

                    MessageBox.Show(
                        "Prestation modifiée avec succès.",
                        "Prestation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur lors de la modification.\n\n" +
                        ex.Message,
                        "Prestation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        // ============================================================
        // AJOUTER PRESTATION
        // ============================================================

        private void btn_add_prestation_Click(
            object sender,
            EventArgs e)
        {
            if (serviceSelectionneId <= 0)
            {
                MessageBox.Show(
                    "Veuillez d'abord sélectionner un service.",
                    "Prestation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            using (Form form = new Form())
            {
                form.Text =
                    "Nouvelle prestation";

                form.Size =
                    new Size(470, 360);

                form.StartPosition =
                    FormStartPosition.CenterParent;

                form.FormBorderStyle =
                    FormBorderStyle.FixedDialog;

                form.MaximizeBox = false;
                form.MinimizeBox = false;

                Label lbLibelle = new Label();

                lbLibelle.Text =
                    "Libellé";

                lbLibelle.Location =
                    new Point(25, 20);

                lbLibelle.AutoSize = true;

                TextBox tbLibelle =
                    new TextBox();

                tbLibelle.Location =
                    new Point(25, 45);

                tbLibelle.Width = 400;

                Label lbDescription =
                    new Label();

                lbDescription.Text =
                    "Description";

                lbDescription.Location =
                    new Point(25, 80);

                lbDescription.AutoSize = true;

                TextBox tbDescription =
                    new TextBox();

                tbDescription.Location =
                    new Point(25, 105);

                tbDescription.Width = 400;

                Label lbUnite =
                    new Label();

                lbUnite.Text =
                    "Unité";

                lbUnite.Location =
                    new Point(25, 140);

                lbUnite.AutoSize = true;

                TextBox tbUnite =
                    new TextBox();

                tbUnite.Location =
                    new Point(25, 165);

                tbUnite.Width = 180;

                Label lbPrix =
                    new Label();

                lbPrix.Text =
                    "Tarif initial";

                lbPrix.Location =
                    new Point(225, 140);

                lbPrix.AutoSize = true;

                NumericUpDown nudPrix =
                    new NumericUpDown();

                nudPrix.Location =
                    new Point(225, 165);

                nudPrix.Width = 200;

                nudPrix.Maximum =
                    1000000000;

                nudPrix.DecimalPlaces =
                    2;

                nudPrix.ThousandsSeparator =
                    true;

                Button btnOk =
                    new Button();

                btnOk.Text =
                    "Enregistrer";

                btnOk.Location =
                    new Point(235, 230);

                btnOk.Width = 90;

                btnOk.DialogResult =
                    DialogResult.OK;

                Button btnAnnuler =
                    new Button();

                btnAnnuler.Text =
                    "Annuler";

                btnAnnuler.Location =
                    new Point(335, 230);

                btnAnnuler.Width = 90;

                btnAnnuler.DialogResult =
                    DialogResult.Cancel;

                form.Controls.Add(lbLibelle);
                form.Controls.Add(tbLibelle);

                form.Controls.Add(lbDescription);
                form.Controls.Add(tbDescription);

                form.Controls.Add(lbUnite);
                form.Controls.Add(tbUnite);

                form.Controls.Add(lbPrix);
                form.Controls.Add(nudPrix);

                form.Controls.Add(btnOk);
                form.Controls.Add(btnAnnuler);

                form.AcceptButton = btnOk;
                form.CancelButton = btnAnnuler;

                if (form.ShowDialog() !=
                    DialogResult.OK)
                    return;

                if (string.IsNullOrWhiteSpace(
                    tbLibelle.Text))
                {
                    MessageBox.Show(
                        "Le libellé est obligatoire.",
                        "Prestation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                try
                {
                    using (MySqlConnection con =
                        db.GetConnection())
                    {
                        con.Open();

                        MySqlTransaction tr =
                            con.BeginTransaction();

                        try
                        {
                            int idPrestation;

                            // ----------------------------------------
                            // Créer prestation
                            // ----------------------------------------

                            string query = @"
                                INSERT INTO prestation
                                (
                                    id_service,
                                    libelle,
                                    description,
                                    unite,
                                    actif
                                )
                                VALUES
                                (
                                    @id_service,
                                    @libelle,
                                    @description,
                                    @unite,
                                    1
                                )";

                            using (MySqlCommand cmd =
                                new MySqlCommand(
                                    query,
                                    con,
                                    tr))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@id_service",
                                    serviceSelectionneId
                                );

                                cmd.Parameters.AddWithValue(
                                    "@libelle",
                                    tbLibelle.Text.Trim()
                                );

                                cmd.Parameters.AddWithValue(
                                    "@description",
                                    string.IsNullOrWhiteSpace(
                                        tbDescription.Text)
                                        ? (object)DBNull.Value
                                        : tbDescription.Text.Trim()
                                );

                                cmd.Parameters.AddWithValue(
                                    "@unite",
                                    string.IsNullOrWhiteSpace(
                                        tbUnite.Text)
                                        ? (object)DBNull.Value
                                        : tbUnite.Text.Trim()
                                );

                                cmd.ExecuteNonQuery();

                                idPrestation =
                                    Convert.ToInt32(
                                        cmd.LastInsertedId
                                    );
                            }

                            // ----------------------------------------
                            // Créer tarif initial
                            // ----------------------------------------

                            CreerTarif(
                                idPrestation,
                                nudPrix.Value,
                                DateTime.Now.Date,
                                con,
                                tr
                            );

                            tr.Commit();
                        }
                        catch
                        {
                            try
                            {
                                tr.Rollback();
                            }
                            catch
                            {
                            }

                            throw;
                        }
                    }

                    ChargerPrestations();

                    MessageBox.Show(
                        "Prestation ajoutée avec succès.",
                        "Prestation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur lors de l'ajout.\n\n" +
                        ex.Message,
                        "Prestation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        // ============================================================
        // CREER TARIF
        // ============================================================

        private void CreerTarif(
            int idPrestation,
            decimal prix,
            DateTime dateDebut,
            MySqlConnection con,
            MySqlTransaction tr)
        {
            // ============================================================
            // 1. Désactiver l'ancien tarif actif
            // ============================================================

            string updateQuery = @"
        UPDATE tarif_prestation
        SET
            actif = 0,
            date_fin = @date_fin
        WHERE
            id_prestation = @id_prestation
            AND actif = 1";

            using (MySqlCommand cmd =
                new MySqlCommand(updateQuery, con, tr))
            {
                cmd.Parameters.AddWithValue(
                    "@id_prestation",
                    idPrestation
                );

                // L'ancien tarif reste valable jusqu'à la veille
                // du début du nouveau tarif.
                cmd.Parameters.AddWithValue(
                    "@date_fin",
                    dateDebut.Date.AddDays(-1)
                );

                cmd.ExecuteNonQuery();
            }


            // ============================================================
            // 2. Créer le nouveau tarif
            // ============================================================

            string insertQuery = @"
        INSERT INTO tarif_prestation
        (
            id_prestation,
            prix,
            date_debut,
            date_fin,
            actif
        )
        VALUES
        (
            @id_prestation,
            @prix,
            @date_debut,
            NULL,
            1
        )";

            using (MySqlCommand cmd =
                new MySqlCommand(insertQuery, con, tr))
            {
                cmd.Parameters.AddWithValue(
                    "@id_prestation",
                    idPrestation
                );

                cmd.Parameters.AddWithValue(
                    "@prix",
                    prix
                );

                cmd.Parameters.AddWithValue(
                    "@date_debut",
                    dateDebut.Date
                );

                cmd.ExecuteNonQuery();
            }
        }
        // ============================================================
        // FERMER ANCIEN TARIF
        // ============================================================

        private void FermerAncienTarif(
            int idPrestation,
            DateTime dateNouveauTarif,
            MySqlConnection con,
            MySqlTransaction tr)
        {
            string query = @"
                UPDATE tarif_prestation
                SET
                    actif = 0,
                    date_fin =
                        DATE_SUB(
                            @date,
                            INTERVAL 1 DAY
                        )
                WHERE
                    id_prestation = @id
                    AND actif = 1
                    AND date_debut < @date";

            using (MySqlCommand cmd =
                new MySqlCommand(
                    query,
                    con,
                    tr))
            {
                cmd.Parameters.AddWithValue(
                    "@id",
                    idPrestation
                );

                cmd.Parameters.AddWithValue(
                    "@date",
                    dateNouveauTarif
                );

                cmd.ExecuteNonQuery();
            }
        }

        // ============================================================
        // ACTIVER / DESACTIVER SERVICE
        // ============================================================

        private void ChangerEtatService(
            int idService,
            bool actif)
        {
            try
            {
                using (MySqlConnection con =
                    db.GetConnection())
                {
                    con.Open();

                    string query = @"
                        UPDATE service
                        SET actif = @actif
                        WHERE id_service = @id";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@actif",
                            actif ? 1 : 0
                        );

                        cmd.Parameters.AddWithValue(
                            "@id",
                            idService
                        );

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du changement d'état.\n\n" +
                    ex.Message,
                    "Service",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ============================================================
        // ACTIVER / DESACTIVER PRESTATION
        // ============================================================

        private void ChangerEtatPrestation(
            int idPrestation,
            bool actif)
        {
            try
            {
                using (MySqlConnection con =
                    db.GetConnection())
                {
                    con.Open();

                    string query = @"
                        UPDATE prestation
                        SET actif = @actif
                        WHERE id_prestation = @id";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@actif",
                            actif ? 1 : 0
                        );

                        cmd.Parameters.AddWithValue(
                            "@id",
                            idPrestation
                        );

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du changement d'état.\n\n" +
                    ex.Message,
                    "Prestation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ============================================================
        // RECHERCHE SERVICE
        // ============================================================

        private void tb_search_service_TextChanged(
            object sender,
            EventArgs e)
        {
            ChargerServices(
                tb_search_service.Text.Trim()
            );
        }

        // ============================================================
        // RECHERCHE PRESTATION
        // ============================================================

        private void tb_search_prestation_TextChanged(
            object sender,
            EventArgs e)
        {
            ChargerPrestations(
                tb_search_prestation.Text.Trim()
            );
        }

        // ============================================================
        // ACTUALISER
        // ============================================================

        public void Actualiser()
        {
            ChargerServices();

            ChargerPrestations();
        }
    }
}