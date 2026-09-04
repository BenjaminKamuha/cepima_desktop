namespace Cepima.MesForms.EEG
{
    partial class Form_realisation_eeg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bunifuRoundedPanel1 = new BunifuRoundedPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_nom_patient = new System.Windows.Forms.Label();
            this.lb_num_fiche = new System.Windows.Forms.Label();
            this.lb_sexe_age = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_type_examen = new System.Windows.Forms.Label();
            this.lb_date_examen = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.pnl_type_examen = new CustomRoundedPanel();
            this.pnl_date_examen = new CustomRoundedPanel();
            this.bunifuRoundedPanel2 = new BunifuRoundedPanel();
            this.btn_open_file = new RoundedButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lb_status_file = new System.Windows.Forms.Label();
            this.lb_file_format = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_taille = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_file_name = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_observation = new MyRoundedTextBox();
            this.tb_indicateur = new MyRoundedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_save = new RoundedButton();
            this.bunifuRoundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_type_examen.SuspendLayout();
            this.pnl_date_examen.SuspendLayout();
            this.bunifuRoundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.DarkBlue;
            this.bunifuRoundedPanel1.BorderRadius = 2;
            this.bunifuRoundedPanel1.BorderSize = 0;
            this.bunifuRoundedPanel1.Controls.Add(this.pictureBox1);
            this.bunifuRoundedPanel1.Controls.Add(this.lb_nom_patient);
            this.bunifuRoundedPanel1.Controls.Add(this.lb_num_fiche);
            this.bunifuRoundedPanel1.Controls.Add(this.lb_sexe_age);
            this.bunifuRoundedPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 5;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(764, 80);
            this.bunifuRoundedPanel1.TabIndex = 39;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // lb_nom_patient
            // 
            this.lb_nom_patient.AutoSize = true;
            this.lb_nom_patient.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nom_patient.Location = new System.Drawing.Point(119, 17);
            this.lb_nom_patient.Name = "lb_nom_patient";
            this.lb_nom_patient.Size = new System.Drawing.Size(105, 18);
            this.lb_nom_patient.TabIndex = 29;
            this.lb_nom_patient.Text = "Kambale Jean ";
            // 
            // lb_num_fiche
            // 
            this.lb_num_fiche.AutoSize = true;
            this.lb_num_fiche.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_num_fiche.Location = new System.Drawing.Point(686, 27);
            this.lb_num_fiche.Name = "lb_num_fiche";
            this.lb_num_fiche.Size = new System.Drawing.Size(70, 18);
            this.lb_num_fiche.TabIndex = 23;
            this.lb_num_fiche.Text = "CEP-0023";
            // 
            // lb_sexe_age
            // 
            this.lb_sexe_age.AutoSize = true;
            this.lb_sexe_age.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sexe_age.Location = new System.Drawing.Point(119, 49);
            this.lb_sexe_age.Name = "lb_sexe_age";
            this.lb_sexe_age.Size = new System.Drawing.Size(117, 18);
            this.lb_sexe_age.TabIndex = 23;
            this.lb_sexe_age.Text = "HOMME - 32 ans";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 29;
            this.label1.Text = "EXAMEN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 18);
            this.label2.TabIndex = 23;
            this.label2.Text = "Type";
            // 
            // lb_type_examen
            // 
            this.lb_type_examen.AutoSize = true;
            this.lb_type_examen.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_type_examen.Location = new System.Drawing.Point(19, 47);
            this.lb_type_examen.Name = "lb_type_examen";
            this.lb_type_examen.Size = new System.Drawing.Size(38, 18);
            this.lb_type_examen.TabIndex = 29;
            this.lb_type_examen.Text = "type";
            // 
            // lb_date_examen
            // 
            this.lb_date_examen.AutoSize = true;
            this.lb_date_examen.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_date_examen.Location = new System.Drawing.Point(19, 47);
            this.lb_date_examen.Name = "lb_date_examen";
            this.lb_date_examen.Size = new System.Drawing.Size(38, 18);
            this.lb_date_examen.TabIndex = 29;
            this.lb_date_examen.Text = "date";
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date.Location = new System.Drawing.Point(19, 10);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(37, 18);
            this.Date.TabIndex = 23;
            this.Date.Text = "Date";
            // 
            // pnl_type_examen
            // 
            this.pnl_type_examen.BackColor = System.Drawing.Color.MediumAquamarine;
            this.pnl_type_examen.BorderColor = System.Drawing.Color.Transparent;
            this.pnl_type_examen.BorderRadius = 8;
            this.pnl_type_examen.BorderSize = 0;
            this.pnl_type_examen.Controls.Add(this.lb_type_examen);
            this.pnl_type_examen.Controls.Add(this.label2);
            this.pnl_type_examen.HoverBackColor = System.Drawing.Color.Empty;
            this.pnl_type_examen.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.pnl_type_examen.Location = new System.Drawing.Point(88, 138);
            this.pnl_type_examen.Name = "pnl_type_examen";
            this.pnl_type_examen.ShadowBlur = 10;
            this.pnl_type_examen.ShadowBorderRadius = -1;
            this.pnl_type_examen.ShadowColor = System.Drawing.Color.Black;
            this.pnl_type_examen.ShadowEnabled = false;
            this.pnl_type_examen.ShadowOffsetX = 0;
            this.pnl_type_examen.ShadowOffsetY = 4;
            this.pnl_type_examen.ShadowOpacity = 60;
            this.pnl_type_examen.ShadowSpread = 0;
            this.pnl_type_examen.Size = new System.Drawing.Size(213, 77);
            this.pnl_type_examen.TabIndex = 40;
            // 
            // pnl_date_examen
            // 
            this.pnl_date_examen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_date_examen.BorderColor = System.Drawing.Color.Transparent;
            this.pnl_date_examen.BorderRadius = 8;
            this.pnl_date_examen.BorderSize = 0;
            this.pnl_date_examen.Controls.Add(this.lb_date_examen);
            this.pnl_date_examen.Controls.Add(this.Date);
            this.pnl_date_examen.HoverBackColor = System.Drawing.Color.Empty;
            this.pnl_date_examen.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.pnl_date_examen.Location = new System.Drawing.Point(462, 138);
            this.pnl_date_examen.Name = "pnl_date_examen";
            this.pnl_date_examen.ShadowBlur = 10;
            this.pnl_date_examen.ShadowBorderRadius = -1;
            this.pnl_date_examen.ShadowColor = System.Drawing.Color.Black;
            this.pnl_date_examen.ShadowEnabled = false;
            this.pnl_date_examen.ShadowOffsetX = 0;
            this.pnl_date_examen.ShadowOffsetY = 0;
            this.pnl_date_examen.ShadowOpacity = 50;
            this.pnl_date_examen.ShadowSpread = 20;
            this.pnl_date_examen.Size = new System.Drawing.Size(213, 77);
            this.pnl_date_examen.TabIndex = 40;
            // 
            // bunifuRoundedPanel2
            // 
            this.bunifuRoundedPanel2.BorderColor = System.Drawing.Color.DarkBlue;
            this.bunifuRoundedPanel2.BorderRadius = 10;
            this.bunifuRoundedPanel2.BorderSize = 0;
            this.bunifuRoundedPanel2.Controls.Add(this.btn_open_file);
            this.bunifuRoundedPanel2.Controls.Add(this.pictureBox2);
            this.bunifuRoundedPanel2.Controls.Add(this.lb_status_file);
            this.bunifuRoundedPanel2.Controls.Add(this.lb_file_format);
            this.bunifuRoundedPanel2.Controls.Add(this.label6);
            this.bunifuRoundedPanel2.Controls.Add(this.lb_taille);
            this.bunifuRoundedPanel2.Controls.Add(this.label5);
            this.bunifuRoundedPanel2.Controls.Add(this.label4);
            this.bunifuRoundedPanel2.Controls.Add(this.lb_file_name);
            this.bunifuRoundedPanel2.Location = new System.Drawing.Point(88, 274);
            this.bunifuRoundedPanel2.Name = "bunifuRoundedPanel2";
            this.bunifuRoundedPanel2.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel2.ShadowDepth = 5;
            this.bunifuRoundedPanel2.Size = new System.Drawing.Size(592, 100);
            this.bunifuRoundedPanel2.TabIndex = 41;
            // 
            // btn_open_file
            // 
            this.btn_open_file.BackColor = System.Drawing.Color.Transparent;
            this.btn_open_file.BorderColor = System.Drawing.Color.White;
            this.btn_open_file.BorderRadius = 10;
            this.btn_open_file.BorderSize = 0;
            this.btn_open_file.ButtonText = "Ouvrir";
            this.btn_open_file.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_open_file.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_open_file.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_open_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_open_file.ForeColor = System.Drawing.Color.White;
            this.btn_open_file.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_open_file.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_open_file.Location = new System.Drawing.Point(504, 5);
            this.btn_open_file.Name = "btn_open_file";
            this.btn_open_file.Size = new System.Drawing.Size(83, 28);
            this.btn_open_file.TabIndex = 38;
            this.btn_open_file.Text = "Ouvrir";
            this.btn_open_file.TextColor = System.Drawing.Color.White;
            this.btn_open_file.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_open_file.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Cepima.Properties.Resources.file_invoice_50px;
            this.pictureBox2.Location = new System.Drawing.Point(11, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 37;
            this.pictureBox2.TabStop = false;
            // 
            // lb_status_file
            // 
            this.lb_status_file.AutoSize = true;
            this.lb_status_file.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_status_file.Location = new System.Drawing.Point(518, 71);
            this.lb_status_file.Name = "lb_status_file";
            this.lb_status_file.Size = new System.Drawing.Size(44, 18);
            this.lb_status_file.TabIndex = 23;
            this.lb_status_file.Text = "statut";
            // 
            // lb_file_format
            // 
            this.lb_file_format.AutoSize = true;
            this.lb_file_format.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_file_format.Location = new System.Drawing.Point(291, 71);
            this.lb_file_format.Name = "lb_file_format";
            this.lb_file_format.Size = new System.Drawing.Size(49, 18);
            this.lb_file_format.TabIndex = 23;
            this.lb_file_format.Text = "format";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(460, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 18);
            this.label6.TabIndex = 23;
            this.label6.Text = "Statut";
            // 
            // lb_taille
            // 
            this.lb_taille.AutoSize = true;
            this.lb_taille.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_taille.Location = new System.Drawing.Point(92, 71);
            this.lb_taille.Name = "lb_taille";
            this.lb_taille.Size = new System.Drawing.Size(36, 18);
            this.lb_taille.TabIndex = 23;
            this.lb_taille.Text = "taille";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(233, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 18);
            this.label5.TabIndex = 23;
            this.label5.Text = "Format:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 18);
            this.label4.TabIndex = 23;
            this.label4.Text = "Taille: ";
            // 
            // lb_file_name
            // 
            this.lb_file_name.AutoSize = true;
            this.lb_file_name.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_file_name.Location = new System.Drawing.Point(48, 13);
            this.lb_file_name.Name = "lb_file_name";
            this.lb_file_name.Size = new System.Drawing.Size(37, 18);
            this.lb_file_name.TabIndex = 23;
            this.lb_file_name.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 29;
            this.label3.Text = "FICHIER";
            // 
            // tb_observation
            // 
            this.tb_observation.BackColor = System.Drawing.Color.White;
            this.tb_observation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_observation.BorderRadius = 8;
            this.tb_observation.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_observation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_observation.ForeColor = System.Drawing.Color.Black;
            this.tb_observation.Image = null;
            this.tb_observation.Location = new System.Drawing.Point(88, 524);
            this.tb_observation.MaxLength = 32767;
            this.tb_observation.Multiline = true;
            this.tb_observation.Name = "tb_observation";
            this.tb_observation.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_observation.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_observation.PlaceholderText = "";
            this.tb_observation.Size = new System.Drawing.Size(592, 64);
            this.tb_observation.TabIndex = 44;
            // 
            // tb_indicateur
            // 
            this.tb_indicateur.BackColor = System.Drawing.Color.White;
            this.tb_indicateur.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_indicateur.BorderRadius = 8;
            this.tb_indicateur.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_indicateur.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_indicateur.ForeColor = System.Drawing.Color.Black;
            this.tb_indicateur.Image = null;
            this.tb_indicateur.Location = new System.Drawing.Point(88, 427);
            this.tb_indicateur.MaxLength = 32767;
            this.tb_indicateur.Name = "tb_indicateur";
            this.tb_indicateur.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_indicateur.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_indicateur.PlaceholderText = "";
            this.tb_indicateur.Size = new System.Drawing.Size(587, 46);
            this.tb_indicateur.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(85, 496);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 18);
            this.label7.TabIndex = 29;
            this.label7.Text = "OBSERVATION";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(85, 398);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 18);
            this.label8.TabIndex = 29;
            this.label8.Text = "OBSERVATION";
            this.label8.Click += new System.EventHandler(this.label7_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Transparent;
            this.btn_save.BorderColor = System.Drawing.Color.White;
            this.btn_save.BorderRadius = 10;
            this.btn_save.BorderSize = 0;
            this.btn_save.ButtonText = "Enregistrer";
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_save.Image = global::Cepima.Properties.Resources.save_30px;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.Location = new System.Drawing.Point(516, 610);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(164, 45);
            this.btn_save.TabIndex = 46;
            this.btn_save.Text = "Enregistrer";
            this.btn_save.TextColor = System.Drawing.Color.White;
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = false;
            // 
            // Form_realisation_eeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(764, 670);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.tb_observation);
            this.Controls.Add(this.tb_indicateur);
            this.Controls.Add(this.bunifuRoundedPanel2);
            this.Controls.Add(this.pnl_date_examen);
            this.Controls.Add(this.pnl_type_examen);
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form_realisation_eeg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_realisation_eeg";
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.bunifuRoundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_type_examen.ResumeLayout(false);
            this.pnl_type_examen.PerformLayout();
            this.pnl_date_examen.ResumeLayout(false);
            this.pnl_date_examen.PerformLayout();
            this.bunifuRoundedPanel2.ResumeLayout(false);
            this.bunifuRoundedPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_nom_patient;
        private System.Windows.Forms.Label lb_num_fiche;
        private System.Windows.Forms.Label lb_sexe_age;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_type_examen;
        private System.Windows.Forms.Label lb_date_examen;
        private System.Windows.Forms.Label Date;
        private CustomRoundedPanel pnl_type_examen;
        private CustomRoundedPanel pnl_date_examen;
        private BunifuRoundedPanel bunifuRoundedPanel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lb_file_name;
        private System.Windows.Forms.Label label3;
        private RoundedButton btn_open_file;
        private System.Windows.Forms.Label lb_status_file;
        private System.Windows.Forms.Label lb_file_format;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_taille;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private MyRoundedTextBox tb_observation;
        private MyRoundedTextBox tb_indicateur;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private RoundedButton btn_save;

    }
}