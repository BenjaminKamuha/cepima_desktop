namespace Cepima.MesUserCases
{
    partial class User_prescription
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rb_hospitalise = new System.Windows.Forms.RadioButton();
            this.rb_ambulatoire = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.customRoundedPanel3 = new CustomRoundedPanel();
            this.dgv_medoc = new ModernDataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedicament = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMontant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_valider_prescription = new test_arrondissement2012.PerfectRoundedButton();
            this.label3 = new System.Windows.Forms.Label();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.panel_medicament = new System.Windows.Forms.Panel();
            this.lb_not_found = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tb_search_medoc = new System.Windows.Forms.TextBox();
            this.tb_tarif = new MyRoundedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.avatarControl1 = new AvatarControl();
            this.lb_nom = new System.Windows.Forms.Label();
            this.lb_sexe = new System.Windows.Forms.Label();
            this.lb_age = new System.Windows.Forms.Label();
            this.lb_type_patient = new System.Windows.Forms.Label();
            this.lb_date = new System.Windows.Forms.Label();
            this.lb_medecin = new System.Windows.Forms.Label();
            this.perfectRoundedButton1 = new test_arrondissement2012.PerfectRoundedButton();
            this.dgvHistorique = new ModernDataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_date_examen = new System.Windows.Forms.Label();
            this.lb_type = new System.Windows.Forms.Label();
            this.lb_resultat = new System.Windows.Forms.Label();
            this.lb_interpretation = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedecin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblStatut = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.customRoundedPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_medoc)).BeginInit();
            this.customRoundedPanel2.SuspendLayout();
            this.panel_medicament.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.customRoundedPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorique)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Location = new System.Drawing.Point(38, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 4);
            this.panel1.TabIndex = 1;
            // 
            // rb_hospitalise
            // 
            this.rb_hospitalise.AutoSize = true;
            this.rb_hospitalise.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_hospitalise.Location = new System.Drawing.Point(679, 14);
            this.rb_hospitalise.Name = "rb_hospitalise";
            this.rb_hospitalise.Size = new System.Drawing.Size(126, 19);
            this.rb_hospitalise.TabIndex = 1;
            this.rb_hospitalise.TabStop = true;
            this.rb_hospitalise.Text = "Patient hospitalisé";
            this.rb_hospitalise.UseVisualStyleBackColor = true;
            // 
            // rb_ambulatoire
            // 
            this.rb_ambulatoire.AutoSize = true;
            this.rb_ambulatoire.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_ambulatoire.Location = new System.Drawing.Point(366, 14);
            this.rb_ambulatoire.Name = "rb_ambulatoire";
            this.rb_ambulatoire.Size = new System.Drawing.Size(135, 19);
            this.rb_ambulatoire.TabIndex = 1;
            this.rb_ambulatoire.TabStop = true;
            this.rb_ambulatoire.Text = "Patient ambulatoire";
            this.rb_ambulatoire.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(53, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Préscription de médicaments";
            // 
            // customRoundedPanel3
            // 
            this.customRoundedPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customRoundedPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel3.BorderRadius = 10;
            this.customRoundedPanel3.BorderSize = 1;
            this.customRoundedPanel3.Controls.Add(this.dgv_medoc);
            this.customRoundedPanel3.Controls.Add(this.perfectRoundedButton1);
            this.customRoundedPanel3.Controls.Add(this.bt_valider_prescription);
            this.customRoundedPanel3.Controls.Add(this.label3);
            this.customRoundedPanel3.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel3.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel3.Location = new System.Drawing.Point(392, 53);
            this.customRoundedPanel3.Name = "customRoundedPanel3";
            this.customRoundedPanel3.Size = new System.Drawing.Size(569, 259);
            this.customRoundedPanel3.TabIndex = 5;
            // 
            // dgv_medoc
            // 
            this.dgv_medoc.AllowUserToAddRows = false;
            this.dgv_medoc.AllowUserToDeleteRows = false;
            this.dgv_medoc.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgv_medoc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_medoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_medoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_medoc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.dgv_medoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_medoc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_medoc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_medoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_medoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_medoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colMedicament,
            this.colQuantite,
            this.colUnite,
            this.colPrix,
            this.colMontant});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_medoc.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_medoc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_medoc.EnableHeadersVisualStyles = false;
            this.dgv_medoc.GridColor = System.Drawing.Color.LightGray;
            this.dgv_medoc.Location = new System.Drawing.Point(3, 45);
            this.dgv_medoc.Name = "dgv_medoc";
            this.dgv_medoc.RowHeadersVisible = false;
            this.dgv_medoc.Size = new System.Drawing.Size(563, 206);
            this.dgv_medoc.TabIndex = 10;
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 50;
            this.colID.Name = "colID";
            // 
            // colMedicament
            // 
            this.colMedicament.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMedicament.HeaderText = "Medicament";
            this.colMedicament.MinimumWidth = 50;
            this.colMedicament.Name = "colMedicament";
            // 
            // colQuantite
            // 
            this.colQuantite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colQuantite.HeaderText = "Quantite";
            this.colQuantite.MinimumWidth = 50;
            this.colQuantite.Name = "colQuantite";
            // 
            // colUnite
            // 
            this.colUnite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUnite.HeaderText = "Unite";
            this.colUnite.MinimumWidth = 50;
            this.colUnite.Name = "colUnite";
            // 
            // colPrix
            // 
            this.colPrix.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPrix.HeaderText = "Prix";
            this.colPrix.MinimumWidth = 50;
            this.colPrix.Name = "colPrix";
            // 
            // colMontant
            // 
            this.colMontant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMontant.HeaderText = "Monant";
            this.colMontant.MinimumWidth = 50;
            this.colMontant.Name = "colMontant";
            // 
            // bt_valider_prescription
            // 
            this.bt_valider_prescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_valider_prescription.BackColor = System.Drawing.Color.Transparent;
            this.bt_valider_prescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_valider_prescription.BorderRadius = 5;
            this.bt_valider_prescription.BorderSize = 0;
            this.bt_valider_prescription.ButtonText = "Valider prescription";
            this.bt_valider_prescription.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.bt_valider_prescription.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_valider_prescription.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_valider_prescription.Location = new System.Drawing.Point(424, 7);
            this.bt_valider_prescription.Name = "bt_valider_prescription";
            this.bt_valider_prescription.Size = new System.Drawing.Size(129, 26);
            this.bt_valider_prescription.TabIndex = 9;
            this.bt_valider_prescription.Click += new System.EventHandler(this.bt_valider_prescription_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "MEDICAMENTS PRESCRITS";
            // 
            // customRoundedPanel2
            // 
            this.customRoundedPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.customRoundedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel2.BorderRadius = 10;
            this.customRoundedPanel2.BorderSize = 1;
            this.customRoundedPanel2.Controls.Add(this.panel4);
            this.customRoundedPanel2.Controls.Add(this.panel2);
            this.customRoundedPanel2.Controls.Add(this.panel_medicament);
            this.customRoundedPanel2.Controls.Add(this.pictureBox1);
            this.customRoundedPanel2.Controls.Add(this.tb_search_medoc);
            this.customRoundedPanel2.Controls.Add(this.tb_tarif);
            this.customRoundedPanel2.Controls.Add(this.label2);
            this.customRoundedPanel2.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel2.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel2.Location = new System.Drawing.Point(15, 53);
            this.customRoundedPanel2.Name = "customRoundedPanel2";
            this.customRoundedPanel2.Size = new System.Drawing.Size(373, 458);
            this.customRoundedPanel2.TabIndex = 4;
            // 
            // panel_medicament
            // 
            this.panel_medicament.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_medicament.AutoScroll = true;
            this.panel_medicament.Controls.Add(this.lb_not_found);
            this.panel_medicament.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel_medicament.Location = new System.Drawing.Point(3, 45);
            this.panel_medicament.Name = "panel_medicament";
            this.panel_medicament.Size = new System.Drawing.Size(366, 241);
            this.panel_medicament.TabIndex = 17;
            // 
            // lb_not_found
            // 
            this.lb_not_found.AutoSize = true;
            this.lb_not_found.Font = new System.Drawing.Font("Calibri Light", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_not_found.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_not_found.Location = new System.Drawing.Point(88, 96);
            this.lb_not_found.Name = "lb_not_found";
            this.lb_not_found.Size = new System.Drawing.Size(0, 14);
            this.lb_not_found.TabIndex = 0;
            this.lb_not_found.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(334, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // tb_search_medoc
            // 
            this.tb_search_medoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_search_medoc.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search_medoc.Location = new System.Drawing.Point(170, 10);
            this.tb_search_medoc.Multiline = true;
            this.tb_search_medoc.Name = "tb_search_medoc";
            this.tb_search_medoc.Size = new System.Drawing.Size(164, 22);
            this.tb_search_medoc.TabIndex = 15;
            this.tb_search_medoc.TextChanged += new System.EventHandler(this.tb_search_medoc_TextChanged_1);
            // 
            // tb_tarif
            // 
            this.tb_tarif.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_tarif.BorderRadius = 4;
            this.tb_tarif.BorderSize = 0;
            this.tb_tarif.Enabled = false;
            this.tb_tarif.FocusBorderColor = System.Drawing.Color.Orange;
            this.tb_tarif.Location = new System.Drawing.Point(167, 7);
            this.tb_tarif.Name = "tb_tarif";
            this.tb_tarif.PasswordChar = '\0';
            this.tb_tarif.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_tarif.PlaceholderText = "";
            this.tb_tarif.Size = new System.Drawing.Size(190, 28);
            this.tb_tarif.TabIndex = 16;
            this.tb_tarif.UseSystemPasswordChar = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "STOCK MEDICAMENT";
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 10;
            this.customRoundedPanel1.BorderSize = 1;
            this.customRoundedPanel1.Controls.Add(this.dgvHistorique);
            this.customRoundedPanel1.Controls.Add(this.label5);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(392, 318);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Size = new System.Drawing.Size(369, 193);
            this.customRoundedPanel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lb_type_patient);
            this.panel2.Controls.Add(this.lb_medecin);
            this.panel2.Controls.Add(this.lb_age);
            this.panel2.Controls.Add(this.lb_date);
            this.panel2.Controls.Add(this.lb_sexe);
            this.panel2.Controls.Add(this.lb_nom);
            this.panel2.Controls.Add(this.avatarControl1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(3, 300);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(366, 155);
            this.panel2.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(234, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "PATIENT CONCERNE PAR LA PRESCRIPTION";
            // 
            // avatarControl1
            // 
            this.avatarControl1.Avatar = global::Cepima.Properties.Resources.male_user_100px;
            this.avatarControl1.BackColor = System.Drawing.Color.Transparent;
            this.avatarControl1.BorderColor = System.Drawing.Color.Empty;
            this.avatarControl1.BorderSize = 0;
            this.avatarControl1.Location = new System.Drawing.Point(8, 39);
            this.avatarControl1.Name = "avatarControl1";
            this.avatarControl1.Size = new System.Drawing.Size(80, 72);
            this.avatarControl1.TabIndex = 0;
            // 
            // lb_nom
            // 
            this.lb_nom.AutoSize = true;
            this.lb_nom.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nom.Location = new System.Drawing.Point(108, 38);
            this.lb_nom.Name = "lb_nom";
            this.lb_nom.Size = new System.Drawing.Size(32, 15);
            this.lb_nom.TabIndex = 1;
            this.lb_nom.Text = "Nom";
            // 
            // lb_sexe
            // 
            this.lb_sexe.AutoSize = true;
            this.lb_sexe.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sexe.Location = new System.Drawing.Point(108, 65);
            this.lb_sexe.Name = "lb_sexe";
            this.lb_sexe.Size = new System.Drawing.Size(39, 15);
            this.lb_sexe.TabIndex = 1;
            this.lb_sexe.Text = "Genre";
            // 
            // lb_age
            // 
            this.lb_age.AutoSize = true;
            this.lb_age.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_age.Location = new System.Drawing.Point(108, 92);
            this.lb_age.Name = "lb_age";
            this.lb_age.Size = new System.Drawing.Size(26, 15);
            this.lb_age.TabIndex = 1;
            this.lb_age.Text = "Age";
            // 
            // lb_type_patient
            // 
            this.lb_type_patient.AutoSize = true;
            this.lb_type_patient.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_type_patient.Location = new System.Drawing.Point(108, 119);
            this.lb_type_patient.Name = "lb_type_patient";
            this.lb_type_patient.Size = new System.Drawing.Size(50, 15);
            this.lb_type_patient.TabIndex = 1;
            this.lb_type_patient.Text = "type_pa";
            // 
            // lb_date
            // 
            this.lb_date.AutoSize = true;
            this.lb_date.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_date.Location = new System.Drawing.Point(234, 38);
            this.lb_date.Name = "lb_date";
            this.lb_date.Size = new System.Drawing.Size(31, 15);
            this.lb_date.TabIndex = 1;
            this.lb_date.Text = "date";
            // 
            // lb_medecin
            // 
            this.lb_medecin.AutoSize = true;
            this.lb_medecin.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_medecin.Location = new System.Drawing.Point(234, 65);
            this.lb_medecin.Name = "lb_medecin";
            this.lb_medecin.Size = new System.Drawing.Size(53, 15);
            this.lb_medecin.TabIndex = 1;
            this.lb_medecin.Text = "medecin";
            // 
            // perfectRoundedButton1
            // 
            this.perfectRoundedButton1.BackColor = System.Drawing.Color.Transparent;
            this.perfectRoundedButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.perfectRoundedButton1.BorderRadius = 5;
            this.perfectRoundedButton1.BorderSize = 0;
            this.perfectRoundedButton1.ButtonText = "Annuler prescription";
            this.perfectRoundedButton1.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.perfectRoundedButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perfectRoundedButton1.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.perfectRoundedButton1.Location = new System.Drawing.Point(240, 7);
            this.perfectRoundedButton1.Name = "perfectRoundedButton1";
            this.perfectRoundedButton1.Size = new System.Drawing.Size(129, 26);
            this.perfectRoundedButton1.TabIndex = 9;
            this.perfectRoundedButton1.Click += new System.EventHandler(this.bt_valider_prescription_Click);
            // 
            // dgvHistorique
            // 
            this.dgvHistorique.AllowUserToAddRows = false;
            this.dgvHistorique.AllowUserToDeleteRows = false;
            this.dgvHistorique.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvHistorique.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHistorique.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorique.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorique.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorique.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorique.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHistorique.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorique.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHistorique.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorique.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colMedecin,
            this.colMedoc});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistorique.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvHistorique.EnableHeadersVisualStyles = false;
            this.dgvHistorique.GridColor = System.Drawing.Color.LightGray;
            this.dgvHistorique.Location = new System.Drawing.Point(3, 28);
            this.dgvHistorique.Name = "dgvHistorique";
            this.dgvHistorique.RowHeadersVisible = false;
            this.dgvHistorique.Size = new System.Drawing.Size(363, 162);
            this.dgvHistorique.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "HISTORIQUE DE PRESCRIPTION";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.lblStatut);
            this.panel3.Controls.Add(this.lb_interpretation);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.lb_date_examen);
            this.panel3.Controls.Add(this.lb_resultat);
            this.panel3.Controls.Add(this.lb_type);
            this.panel3.Location = new System.Drawing.Point(767, 315);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(191, 193);
            this.panel3.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "INFORMATIONS EXAMEN RECENT";
            // 
            // lb_date_examen
            // 
            this.lb_date_examen.AutoSize = true;
            this.lb_date_examen.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_date_examen.Location = new System.Drawing.Point(86, 41);
            this.lb_date_examen.Name = "lb_date_examen";
            this.lb_date_examen.Size = new System.Drawing.Size(31, 15);
            this.lb_date_examen.TabIndex = 1;
            this.lb_date_examen.Text = "date";
            // 
            // lb_type
            // 
            this.lb_type.AutoSize = true;
            this.lb_type.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_type.Location = new System.Drawing.Point(86, 70);
            this.lb_type.Name = "lb_type";
            this.lb_type.Size = new System.Drawing.Size(30, 15);
            this.lb_type.TabIndex = 1;
            this.lb_type.Text = "type";
            // 
            // lb_resultat
            // 
            this.lb_resultat.AutoSize = true;
            this.lb_resultat.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_resultat.Location = new System.Drawing.Point(13, 134);
            this.lb_resultat.Name = "lb_resultat";
            this.lb_resultat.Size = new System.Drawing.Size(39, 15);
            this.lb_resultat.TabIndex = 1;
            this.lb_resultat.Text = "result";
            // 
            // lb_interpretation
            // 
            this.lb_interpretation.AutoSize = true;
            this.lb_interpretation.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_interpretation.Location = new System.Drawing.Point(14, 169);
            this.lb_interpretation.Name = "lb_interpretation";
            this.lb_interpretation.Size = new System.Drawing.Size(83, 15);
            this.lb_interpretation.TabIndex = 1;
            this.lb_interpretation.Text = "interpretation";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Cepima.Properties.Resources.total_examen;
            this.pictureBox2.Location = new System.Drawing.Point(5, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(65, 61);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // colDate
            // 
            this.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDate.HeaderText = "Date";
            this.colDate.MinimumWidth = 50;
            this.colDate.Name = "colDate";
            // 
            // colMedecin
            // 
            this.colMedecin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMedecin.HeaderText = "Medecin";
            this.colMedecin.MinimumWidth = 50;
            this.colMedecin.Name = "colMedecin";
            // 
            // colMedoc
            // 
            this.colMedoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMedoc.HeaderText = "Medicament";
            this.colMedoc.MinimumWidth = 50;
            this.colMedoc.Name = "colMedoc";
            // 
            // lblStatut
            // 
            this.lblStatut.AutoSize = true;
            this.lblStatut.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatut.Location = new System.Drawing.Point(86, 109);
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(39, 15);
            this.lblStatut.TabIndex = 1;
            this.lblStatut.Text = "statut";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.Location = new System.Drawing.Point(6, 290);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(363, 4);
            this.panel4.TabIndex = 11;
            // 
            // User_prescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.customRoundedPanel1);
            this.Controls.Add(this.customRoundedPanel3);
            this.Controls.Add(this.customRoundedPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rb_ambulatoire);
            this.Controls.Add(this.rb_hospitalise);
            this.Name = "User_prescription";
            this.Size = new System.Drawing.Size(964, 514);
            this.customRoundedPanel3.ResumeLayout(false);
            this.customRoundedPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_medoc)).EndInit();
            this.customRoundedPanel2.ResumeLayout(false);
            this.customRoundedPanel2.PerformLayout();
            this.panel_medicament.ResumeLayout(false);
            this.panel_medicament.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorique)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb_hospitalise;
        private System.Windows.Forms.RadioButton rb_ambulatoire;
        private System.Windows.Forms.Panel panel1;
        private CustomRoundedPanel customRoundedPanel3;
        private ModernDataGridView dgv_medoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedicament;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrix;
        private test_arrondissement2012.PerfectRoundedButton bt_valider_prescription;
        private System.Windows.Forms.Label label3;
        private CustomRoundedPanel customRoundedPanel2;
        private System.Windows.Forms.Panel panel_medicament;
        private System.Windows.Forms.Label lb_not_found;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tb_search_medoc;
        private MyRoundedTextBox tb_tarif;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontant;
        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.Panel panel2;
        private AvatarControl avatarControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_type_patient;
        private System.Windows.Forms.Label lb_medecin;
        private System.Windows.Forms.Label lb_age;
        private System.Windows.Forms.Label lb_date;
        private System.Windows.Forms.Label lb_sexe;
        private System.Windows.Forms.Label lb_nom;
        private test_arrondissement2012.PerfectRoundedButton perfectRoundedButton1;
        private System.Windows.Forms.Panel panel3;
        private ModernDataGridView dgvHistorique;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_interpretation;
        private System.Windows.Forms.Label lb_date_examen;
        private System.Windows.Forms.Label lb_resultat;
        private System.Windows.Forms.Label lb_type;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedecin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedoc;
        private System.Windows.Forms.Label lblStatut;
        private System.Windows.Forms.Panel panel4;
    }
}
