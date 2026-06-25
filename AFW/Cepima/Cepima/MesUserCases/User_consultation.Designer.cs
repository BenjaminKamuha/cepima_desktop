namespace Cepima.MesUserCases
{
    partial class User_consultation
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
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.rb_eeg = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rb_hospitalisation = new System.Windows.Forms.RadioButton();
            this.rb_ambulatoire = new System.Windows.Forms.RadioButton();
            this.pan_test = new System.Windows.Forms.Panel();
            this.tb_motif_hospitalisation = new System.Windows.Forms.TextBox();
            this.myRoundedTextBox1 = new MyRoundedTextBox();
            this.cbx_service = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.rich_description = new System.Windows.Forms.RichTextBox();
            this.fl_patient = new System.Windows.Forms.FlowLayoutPanel();
            this.tb_motif = new System.Windows.Forms.TextBox();
            this.myRoundedTextBox4 = new MyRoundedTextBox();
            this.bt_save_consultation = new test_arrondissement2012.PerfectRoundedButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbx_personnel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.customRoundedPanel3 = new CustomRoundedPanel();
            this.rb_attente = new System.Windows.Forms.RadioButton();
            this.rb_eeg_termine = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.tb_tarif = new MyRoundedTextBox();
            this.bt_continue = new test_arrondissement2012.PerfectRoundedButton();
            this.customRoundedPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pan_test.SuspendLayout();
            this.customRoundedPanel2.SuspendLayout();
            this.customRoundedPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 10;
            this.customRoundedPanel1.BorderSize = 2;
            this.customRoundedPanel1.Controls.Add(this.rb_eeg);
            this.customRoundedPanel1.Controls.Add(this.panel2);
            this.customRoundedPanel1.Controls.Add(this.pan_test);
            this.customRoundedPanel1.Controls.Add(this.customRoundedPanel2);
            this.customRoundedPanel1.Controls.Add(this.tb_motif);
            this.customRoundedPanel1.Controls.Add(this.myRoundedTextBox4);
            this.customRoundedPanel1.Controls.Add(this.bt_continue);
            this.customRoundedPanel1.Controls.Add(this.bt_save_consultation);
            this.customRoundedPanel1.Controls.Add(this.label3);
            this.customRoundedPanel1.Controls.Add(this.label6);
            this.customRoundedPanel1.Controls.Add(this.cbx_personnel);
            this.customRoundedPanel1.Controls.Add(this.label2);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Arrow;
            this.customRoundedPanel1.Location = new System.Drawing.Point(342, 11);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Size = new System.Drawing.Size(623, 492);
            this.customRoundedPanel1.TabIndex = 3;
            // 
            // rb_eeg
            // 
            this.rb_eeg.AutoSize = true;
            this.rb_eeg.Font = new System.Drawing.Font("Calibri", 9.4F, System.Drawing.FontStyle.Bold);
            this.rb_eeg.Location = new System.Drawing.Point(28, 35);
            this.rb_eeg.Name = "rb_eeg";
            this.rb_eeg.Size = new System.Drawing.Size(153, 19);
            this.rb_eeg.TabIndex = 6;
            this.rb_eeg.TabStop = true;
            this.rb_eeg.Text = "Demander examen EEG";
            this.rb_eeg.UseVisualStyleBackColor = true;
            this.rb_eeg.CheckedChanged += new System.EventHandler(this.rb_eeg_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(6, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Patients à consulter";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rb_hospitalisation);
            this.panel2.Controls.Add(this.rb_ambulatoire);
            this.panel2.Location = new System.Drawing.Point(264, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(337, 26);
            this.panel2.TabIndex = 4;
            // 
            // rb_hospitalisation
            // 
            this.rb_hospitalisation.AutoSize = true;
            this.rb_hospitalisation.Font = new System.Drawing.Font("Calibri", 9.4F, System.Drawing.FontStyle.Bold);
            this.rb_hospitalisation.Location = new System.Drawing.Point(7, 3);
            this.rb_hospitalisation.Name = "rb_hospitalisation";
            this.rb_hospitalisation.Size = new System.Drawing.Size(121, 19);
            this.rb_hospitalisation.TabIndex = 6;
            this.rb_hospitalisation.TabStop = true;
            this.rb_hospitalisation.Text = "Patient hospitalié";
            this.rb_hospitalisation.UseVisualStyleBackColor = true;
            this.rb_hospitalisation.CheckedChanged += new System.EventHandler(this.rb_hospitalisation_CheckedChanged);
            // 
            // rb_ambulatoire
            // 
            this.rb_ambulatoire.AutoSize = true;
            this.rb_ambulatoire.Font = new System.Drawing.Font("Calibri", 9.4F, System.Drawing.FontStyle.Bold);
            this.rb_ambulatoire.Location = new System.Drawing.Point(159, 4);
            this.rb_ambulatoire.Name = "rb_ambulatoire";
            this.rb_ambulatoire.Size = new System.Drawing.Size(135, 19);
            this.rb_ambulatoire.TabIndex = 6;
            this.rb_ambulatoire.TabStop = true;
            this.rb_ambulatoire.Text = "Patient ambulatoire";
            this.rb_ambulatoire.UseVisualStyleBackColor = true;
            this.rb_ambulatoire.CheckedChanged += new System.EventHandler(this.rb_ambulatoire_CheckedChanged);
            // 
            // pan_test
            // 
            this.pan_test.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.pan_test.Controls.Add(this.tb_motif_hospitalisation);
            this.pan_test.Controls.Add(this.myRoundedTextBox1);
            this.pan_test.Controls.Add(this.cbx_service);
            this.pan_test.Controls.Add(this.label9);
            this.pan_test.Controls.Add(this.label8);
            this.pan_test.Location = new System.Drawing.Point(65, 329);
            this.pan_test.Name = "pan_test";
            this.pan_test.Size = new System.Drawing.Size(537, 76);
            this.pan_test.TabIndex = 19;
            this.pan_test.Visible = false;
            // 
            // tb_motif_hospitalisation
            // 
            this.tb_motif_hospitalisation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.tb_motif_hospitalisation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_motif_hospitalisation.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_motif_hospitalisation.Location = new System.Drawing.Point(289, 35);
            this.tb_motif_hospitalisation.Multiline = true;
            this.tb_motif_hospitalisation.Name = "tb_motif_hospitalisation";
            this.tb_motif_hospitalisation.Size = new System.Drawing.Size(233, 23);
            this.tb_motif_hospitalisation.TabIndex = 23;
            // 
            // myRoundedTextBox1
            // 
            this.myRoundedTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myRoundedTextBox1.BorderRadius = 4;
            this.myRoundedTextBox1.BorderSize = 1;
            this.myRoundedTextBox1.Enabled = false;
            this.myRoundedTextBox1.FocusBorderColor = System.Drawing.Color.Orange;
            this.myRoundedTextBox1.Location = new System.Drawing.Point(286, 33);
            this.myRoundedTextBox1.Name = "myRoundedTextBox1";
            this.myRoundedTextBox1.PasswordChar = '\0';
            this.myRoundedTextBox1.PlaceholderColor = System.Drawing.Color.Beige;
            this.myRoundedTextBox1.PlaceholderText = "";
            this.myRoundedTextBox1.Size = new System.Drawing.Size(242, 27);
            this.myRoundedTextBox1.TabIndex = 22;
            this.myRoundedTextBox1.UseSystemPasswordChar = false;
            // 
            // cbx_service
            // 
            this.cbx_service.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_service.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_service.FormattingEnabled = true;
            this.cbx_service.Location = new System.Drawing.Point(8, 35);
            this.cbx_service.Name = "cbx_service";
            this.cbx_service.Size = new System.Drawing.Size(169, 23);
            this.cbx_service.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.4F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(286, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "Motif d\'hospitalisation";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.4F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(14, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Services";
            // 
            // customRoundedPanel2
            // 
            this.customRoundedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel2.BorderRadius = 4;
            this.customRoundedPanel2.BorderSize = 2;
            this.customRoundedPanel2.Controls.Add(this.rich_description);
            this.customRoundedPanel2.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel2.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel2.Location = new System.Drawing.Point(228, 231);
            this.customRoundedPanel2.Name = "customRoundedPanel2";
            this.customRoundedPanel2.Size = new System.Drawing.Size(296, 67);
            this.customRoundedPanel2.TabIndex = 7;
            // 
            // rich_description
            // 
            this.rich_description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rich_description.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.rich_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rich_description.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rich_description.Location = new System.Drawing.Point(4, 3);
            this.rich_description.Name = "rich_description";
            this.rich_description.Size = new System.Drawing.Size(287, 61);
            this.rich_description.TabIndex = 8;
            this.rich_description.Text = "";
            // 
            // fl_patient
            // 
            this.fl_patient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fl_patient.AutoScroll = true;
            this.fl_patient.Location = new System.Drawing.Point(11, 115);
            this.fl_patient.Name = "fl_patient";
            this.fl_patient.Size = new System.Drawing.Size(257, 374);
            this.fl_patient.TabIndex = 5;
            // 
            // tb_motif
            // 
            this.tb_motif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.tb_motif.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_motif.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_motif.Location = new System.Drawing.Point(231, 172);
            this.tb_motif.Multiline = true;
            this.tb_motif.Name = "tb_motif";
            this.tb_motif.Size = new System.Drawing.Size(290, 23);
            this.tb_motif.TabIndex = 6;
            // 
            // myRoundedTextBox4
            // 
            this.myRoundedTextBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myRoundedTextBox4.BorderRadius = 4;
            this.myRoundedTextBox4.BorderSize = 1;
            this.myRoundedTextBox4.Enabled = false;
            this.myRoundedTextBox4.FocusBorderColor = System.Drawing.Color.Orange;
            this.myRoundedTextBox4.Location = new System.Drawing.Point(228, 170);
            this.myRoundedTextBox4.Name = "myRoundedTextBox4";
            this.myRoundedTextBox4.PasswordChar = '\0';
            this.myRoundedTextBox4.PlaceholderColor = System.Drawing.Color.Beige;
            this.myRoundedTextBox4.PlaceholderText = "";
            this.myRoundedTextBox4.Size = new System.Drawing.Size(299, 27);
            this.myRoundedTextBox4.TabIndex = 5;
            this.myRoundedTextBox4.UseSystemPasswordChar = false;
            // 
            // bt_save_consultation
            // 
            this.bt_save_consultation.BackColor = System.Drawing.Color.Transparent;
            this.bt_save_consultation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_save_consultation.BorderRadius = 5;
            this.bt_save_consultation.BorderSize = 0;
            this.bt_save_consultation.ButtonText = "Enregistrer";
            this.bt_save_consultation.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.bt_save_consultation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save_consultation.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_save_consultation.Location = new System.Drawing.Point(82, 447);
            this.bt_save_consultation.Name = "bt_save_consultation";
            this.bt_save_consultation.Size = new System.Drawing.Size(148, 32);
            this.bt_save_consultation.TabIndex = 2;
            this.bt_save_consultation.Click += new System.EventHandler(this.bt_save_consultation_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.4F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(62, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Motif de consultation : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.4F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(62, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Diagnostic : ";
            // 
            // cbx_personnel
            // 
            this.cbx_personnel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_personnel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_personnel.FormattingEnabled = true;
            this.cbx_personnel.Location = new System.Drawing.Point(230, 122);
            this.cbx_personnel.Name = "cbx_personnel";
            this.cbx_personnel.Size = new System.Drawing.Size(297, 23);
            this.cbx_personnel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.4F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(62, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Personnels  : ";
            // 
            // customRoundedPanel3
            // 
            this.customRoundedPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customRoundedPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel3.BorderRadius = 10;
            this.customRoundedPanel3.BorderSize = 1;
            this.customRoundedPanel3.Controls.Add(this.pictureBox1);
            this.customRoundedPanel3.Controls.Add(this.tb_search);
            this.customRoundedPanel3.Controls.Add(this.tb_tarif);
            this.customRoundedPanel3.Controls.Add(this.rb_eeg_termine);
            this.customRoundedPanel3.Controls.Add(this.rb_attente);
            this.customRoundedPanel3.Controls.Add(this.fl_patient);
            this.customRoundedPanel3.Controls.Add(this.label5);
            this.customRoundedPanel3.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel3.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel3.Location = new System.Drawing.Point(3, 11);
            this.customRoundedPanel3.Name = "customRoundedPanel3";
            this.customRoundedPanel3.Size = new System.Drawing.Size(283, 492);
            this.customRoundedPanel3.TabIndex = 4;
            // 
            // rb_attente
            // 
            this.rb_attente.AutoSize = true;
            this.rb_attente.Font = new System.Drawing.Font("Calibri", 9.4F, System.Drawing.FontStyle.Bold);
            this.rb_attente.Location = new System.Drawing.Point(10, 46);
            this.rb_attente.Name = "rb_attente";
            this.rb_attente.Size = new System.Drawing.Size(82, 19);
            this.rb_attente.TabIndex = 1;
            this.rb_attente.TabStop = true;
            this.rb_attente.Text = "En attente";
            this.rb_attente.UseVisualStyleBackColor = true;
            this.rb_attente.CheckedChanged += new System.EventHandler(this.rb_attente_CheckedChanged);
            // 
            // rb_eeg_termine
            // 
            this.rb_eeg_termine.AutoSize = true;
            this.rb_eeg_termine.Font = new System.Drawing.Font("Calibri", 9.4F, System.Drawing.FontStyle.Bold);
            this.rb_eeg_termine.Location = new System.Drawing.Point(177, 46);
            this.rb_eeg_termine.Name = "rb_eeg_termine";
            this.rb_eeg_termine.Size = new System.Drawing.Size(93, 19);
            this.rb_eeg_termine.TabIndex = 1;
            this.rb_eeg_termine.TabStop = true;
            this.rb_eeg_termine.Text = "EEG terminé";
            this.rb_eeg_termine.UseVisualStyleBackColor = true;
            this.rb_eeg_termine.CheckedChanged += new System.EventHandler(this.rb_eeg_termine_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(247, 84);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // tb_search
            // 
            this.tb_search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_search.Location = new System.Drawing.Point(12, 84);
            this.tb_search.Multiline = true;
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(234, 22);
            this.tb_search.TabIndex = 18;
            this.tb_search.TextChanged += new System.EventHandler(this.tb_search_TextChanged);
            // 
            // tb_tarif
            // 
            this.tb_tarif.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_tarif.BorderRadius = 4;
            this.tb_tarif.BorderSize = 0;
            this.tb_tarif.Enabled = false;
            this.tb_tarif.FocusBorderColor = System.Drawing.Color.Orange;
            this.tb_tarif.Location = new System.Drawing.Point(10, 81);
            this.tb_tarif.Name = "tb_tarif";
            this.tb_tarif.PasswordChar = '\0';
            this.tb_tarif.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_tarif.PlaceholderText = "";
            this.tb_tarif.Size = new System.Drawing.Size(260, 28);
            this.tb_tarif.TabIndex = 19;
            this.tb_tarif.UseSystemPasswordChar = false;
            // 
            // bt_continue
            // 
            this.bt_continue.BackColor = System.Drawing.Color.Transparent;
            this.bt_continue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_continue.BorderRadius = 5;
            this.bt_continue.BorderSize = 0;
            this.bt_continue.ButtonText = "Continuer la préscription";
            this.bt_continue.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.bt_continue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_continue.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_continue.Location = new System.Drawing.Point(450, 447);
            this.bt_continue.Name = "bt_continue";
            this.bt_continue.Size = new System.Drawing.Size(148, 32);
            this.bt_continue.TabIndex = 2;
            this.bt_continue.Visible = false;
            this.bt_continue.Click += new System.EventHandler(this.bt_continue_Click);
            // 
            // User_consultation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.customRoundedPanel3);
            this.Controls.Add(this.customRoundedPanel1);
            this.Name = "User_consultation";
            this.Size = new System.Drawing.Size(999, 506);
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pan_test.ResumeLayout(false);
            this.pan_test.PerformLayout();
            this.customRoundedPanel2.ResumeLayout(false);
            this.customRoundedPanel3.ResumeLayout(false);
            this.customRoundedPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.TextBox tb_motif;
        private MyRoundedTextBox myRoundedTextBox4;
        private test_arrondissement2012.PerfectRoundedButton bt_save_consultation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbx_personnel;
        private System.Windows.Forms.Label label2;
        private CustomRoundedPanel customRoundedPanel2;
        private System.Windows.Forms.RichTextBox rich_description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel fl_patient;
        private System.Windows.Forms.RadioButton rb_hospitalisation;
        private System.Windows.Forms.RadioButton rb_ambulatoire;
        private System.Windows.Forms.Panel pan_test;
        private System.Windows.Forms.TextBox tb_motif_hospitalisation;
        private MyRoundedTextBox myRoundedTextBox1;
        private System.Windows.Forms.ComboBox cbx_service;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rb_eeg;
        private System.Windows.Forms.Label label5;
        private CustomRoundedPanel customRoundedPanel3;
        private System.Windows.Forms.RadioButton rb_eeg_termine;
        private System.Windows.Forms.RadioButton rb_attente;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tb_search;
        private MyRoundedTextBox tb_tarif;
        private test_arrondissement2012.PerfectRoundedButton bt_continue;
    }
}
