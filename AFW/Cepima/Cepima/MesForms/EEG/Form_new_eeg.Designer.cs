namespace Cepima.MesForms.Pharmacie
{
    partial class Form_new_eeg
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
            this.title = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_eeg = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rd_eveil = new System.Windows.Forms.RadioButton();
            this.rd_somnolence = new System.Windows.Forms.RadioButton();
            this.rd_sommeil = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_fichier = new System.Windows.Forms.Label();
            this.bunifuRoundedPanel1 = new BunifuRoundedPanel();
            this.lb_nom_patient = new System.Windows.Forms.Label();
            this.lb_num_fiche = new System.Windows.Forms.Label();
            this.lb_sexe_age = new System.Windows.Forms.Label();
            this.cbx_type_eeg = new MyRoundedComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_cancel = new RoundedButton();
            this.btn_import_file = new RoundedButton();
            this.btn_save = new RoundedButton();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_observation = new MyRoundedTextBox();
            this.label = new System.Windows.Forms.Label();
            this.tb_indicateur = new MyRoundedTextBox();
            this.bunifuRoundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(263, 104);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(152, 18);
            this.title.TabIndex = 29;
            this.title.Text = "NOUVEL EXAMEN EEG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(148, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 27;
            this.label2.Text = "Type d\'EEG :";
            // 
            // dtp_eeg
            // 
            this.dtp_eeg.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_eeg.Location = new System.Drawing.Point(266, 242);
            this.dtp_eeg.Name = "dtp_eeg";
            this.dtp_eeg.Size = new System.Drawing.Size(264, 24);
            this.dtp_eeg.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(148, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 27;
            this.label1.Text = "Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(150, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Condition :";
            // 
            // rd_eveil
            // 
            this.rd_eveil.AutoSize = true;
            this.rd_eveil.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.rd_eveil.Location = new System.Drawing.Point(266, 307);
            this.rd_eveil.Name = "rd_eveil";
            this.rd_eveil.Size = new System.Drawing.Size(53, 22);
            this.rd_eveil.TabIndex = 40;
            this.rd_eveil.TabStop = true;
            this.rd_eveil.Text = "Eveil";
            this.rd_eveil.UseVisualStyleBackColor = true;
            // 
            // rd_somnolence
            // 
            this.rd_somnolence.AutoSize = true;
            this.rd_somnolence.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.rd_somnolence.Location = new System.Drawing.Point(335, 307);
            this.rd_somnolence.Name = "rd_somnolence";
            this.rd_somnolence.Size = new System.Drawing.Size(100, 22);
            this.rd_somnolence.TabIndex = 40;
            this.rd_somnolence.TabStop = true;
            this.rd_somnolence.Text = "Somnolence";
            this.rd_somnolence.UseVisualStyleBackColor = true;
            // 
            // rd_sommeil
            // 
            this.rd_sommeil.AutoSize = true;
            this.rd_sommeil.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.rd_sommeil.Location = new System.Drawing.Point(451, 307);
            this.rd_sommeil.Name = "rd_sommeil";
            this.rd_sommeil.Size = new System.Drawing.Size(78, 22);
            this.rd_sommeil.TabIndex = 40;
            this.rd_sommeil.TabStop = true;
            this.rd_sommeil.Text = "Sommeil";
            this.rd_sommeil.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(148, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "Fichier :";
            // 
            // lb_fichier
            // 
            this.lb_fichier.AutoSize = true;
            this.lb_fichier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fichier.Location = new System.Drawing.Point(263, 368);
            this.lb_fichier.Name = "lb_fichier";
            this.lb_fichier.Size = new System.Drawing.Size(0, 17);
            this.lb_fichier.TabIndex = 23;
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
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(673, 80);
            this.bunifuRoundedPanel1.TabIndex = 38;
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
            this.lb_num_fiche.Location = new System.Drawing.Point(501, 49);
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
            // cbx_type_eeg
            // 
            this.cbx_type_eeg.ArrowColor = System.Drawing.Color.DimGray;
            this.cbx_type_eeg.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_type_eeg.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_type_eeg.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbx_type_eeg.BorderRadius = 8;
            this.cbx_type_eeg.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_type_eeg.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_type_eeg.DropDownSelectedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.cbx_type_eeg.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_type_eeg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_type_eeg.DropDownWidth = 250;
            this.cbx_type_eeg.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.cbx_type_eeg.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.cbx_type_eeg.Location = new System.Drawing.Point(266, 166);
            this.cbx_type_eeg.MinimumSize = new System.Drawing.Size(80, 36);
            this.cbx_type_eeg.Name = "cbx_type_eeg";
            this.cbx_type_eeg.SelectedItem = null;
            this.cbx_type_eeg.SelectedValue = null;
            this.cbx_type_eeg.Size = new System.Drawing.Size(264, 42);
            this.cbx_type_eeg.TabIndex = 34;
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
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancel.BorderColor = System.Drawing.Color.White;
            this.btn_cancel.BorderRadius = 10;
            this.btn_cancel.BorderSize = 0;
            this.btn_cancel.ButtonText = "Annuler";
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel.DefaultBackColor = System.Drawing.Color.Crimson;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_cancel.Image = global::Cepima.Properties.Resources.cancel_30px;
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancel.Location = new System.Drawing.Point(163, 516);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(150, 45);
            this.btn_cancel.TabIndex = 32;
            this.btn_cancel.Text = "Annuler";
            this.btn_cancel.TextColor = System.Drawing.Color.White;
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = false;
            // 
            // btn_import_file
            // 
            this.btn_import_file.BackColor = System.Drawing.Color.Transparent;
            this.btn_import_file.BorderColor = System.Drawing.Color.White;
            this.btn_import_file.BorderRadius = 10;
            this.btn_import_file.BorderSize = 0;
            this.btn_import_file.ButtonText = "Importer";
            this.btn_import_file.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_import_file.DefaultBackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_import_file.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_import_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_import_file.ForeColor = System.Drawing.Color.White;
            this.btn_import_file.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_import_file.Image = global::Cepima.Properties.Resources.folder_30px;
            this.btn_import_file.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_import_file.Location = new System.Drawing.Point(151, 396);
            this.btn_import_file.Name = "btn_import_file";
            this.btn_import_file.Size = new System.Drawing.Size(122, 31);
            this.btn_import_file.TabIndex = 31;
            this.btn_import_file.Text = "Importer";
            this.btn_import_file.TextColor = System.Drawing.Color.White;
            this.btn_import_file.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_import_file.UseVisualStyleBackColor = false;
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
            this.btn_save.Location = new System.Drawing.Point(346, 516);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(164, 45);
            this.btn_save.TabIndex = 31;
            this.btn_save.Text = "Enregistrer";
            this.btn_save.TextColor = System.Drawing.Color.White;
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(137, 528);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Observation :";
            this.label5.Visible = false;
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
            this.tb_observation.Location = new System.Drawing.Point(255, 515);
            this.tb_observation.MaxLength = 32767;
            this.tb_observation.Multiline = true;
            this.tb_observation.Name = "tb_observation";
            this.tb_observation.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_observation.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_observation.PlaceholderText = "";
            this.tb_observation.Size = new System.Drawing.Size(264, 90);
            this.tb_observation.TabIndex = 28;
            this.tb_observation.Visible = false;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(139, 625);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(68, 17);
            this.label.TabIndex = 23;
            this.label.Text = "Indication";
            this.label.Visible = false;
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
            this.tb_indicateur.Location = new System.Drawing.Point(255, 615);
            this.tb_indicateur.MaxLength = 32767;
            this.tb_indicateur.Name = "tb_indicateur";
            this.tb_indicateur.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_indicateur.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_indicateur.PlaceholderText = "";
            this.tb_indicateur.Size = new System.Drawing.Size(264, 37);
            this.tb_indicateur.TabIndex = 28;
            this.tb_indicateur.Visible = false;
            // 
            // Form_new_eeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(673, 702);
            this.Controls.Add(this.rd_sommeil);
            this.Controls.Add(this.rd_somnolence);
            this.Controls.Add(this.rd_eveil);
            this.Controls.Add(this.dtp_eeg);
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Controls.Add(this.cbx_type_eeg);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_import_file);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.title);
            this.Controls.Add(this.tb_observation);
            this.Controls.Add(this.tb_indicateur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_fichier);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label);
            this.Name = "Form_new_eeg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_new_eeg";
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.bunifuRoundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyRoundedComboBox cbx_type_eeg;
        private RoundedButton btn_cancel;
        private RoundedButton btn_save;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.Label lb_nom_patient;
        private System.Windows.Forms.Label lb_num_fiche;
        private System.Windows.Forms.Label lb_sexe_age;
        private System.Windows.Forms.DateTimePicker dtp_eeg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rd_eveil;
        private System.Windows.Forms.RadioButton rd_somnolence;
        private System.Windows.Forms.RadioButton rd_sommeil;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_fichier;
        private RoundedButton btn_import_file;
        private System.Windows.Forms.Label label5;
        private MyRoundedTextBox tb_observation;
        private System.Windows.Forms.Label label;
        private MyRoundedTextBox tb_indicateur;
    }
}