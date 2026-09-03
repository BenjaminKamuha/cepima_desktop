namespace Cepima.MesForms
{
    partial class Form_demander_service
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
            this.label1 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rd_priorite_normal = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_observation = new MyRoundedTextBox();
            this.tb_indicateur = new MyRoundedTextBox();
            this.bunifuRoundedPanel1 = new BunifuRoundedPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_nom_patient = new System.Windows.Forms.Label();
            this.lb_num_fiche = new System.Windows.Forms.Label();
            this.lb_sexe_age = new System.Windows.Forms.Label();
            this.cbx_consultation = new MyRoundedComboBox();
            this.cbx_service = new MyRoundedComboBox();
            this.btn_cancel = new RoundedButton();
            this.btn_send_request = new RoundedButton();
            this.bunifuRoundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Priorité :";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(170, 113);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(167, 18);
            this.title.TabIndex = 29;
            this.title.Text = "DEMANDER UN SERVICE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Services : ";
            // 
            // rd_priorite_normal
            // 
            this.rd_priorite_normal.AutoSize = true;
            this.rd_priorite_normal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_priorite_normal.Location = new System.Drawing.Point(211, 244);
            this.rd_priorite_normal.Name = "rd_priorite_normal";
            this.rd_priorite_normal.Size = new System.Drawing.Size(79, 21);
            this.rd_priorite_normal.TabIndex = 41;
            this.rd_priorite_normal.TabStop = true;
            this.rd_priorite_normal.Text = "Normale";
            this.rd_priorite_normal.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(357, 240);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 21);
            this.radioButton1.TabIndex = 41;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Urgente";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(81, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 30;
            this.label3.Text = "Indicateur/Motif :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(84, 420);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "Consultation :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(81, 497);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 17);
            this.label5.TabIndex = 30;
            this.label5.Text = "Observation :";
            // 
            // tb_observation
            // 
            this.tb_observation.BackColor = System.Drawing.Color.White;
            this.tb_observation.BorderColor = System.Drawing.Color.Silver;
            this.tb_observation.BorderRadius = 8;
            this.tb_observation.FocusBorderColor = System.Drawing.Color.Orange;
            this.tb_observation.ForeColor = System.Drawing.Color.Black;
            this.tb_observation.Image = null;
            this.tb_observation.Location = new System.Drawing.Point(211, 480);
            this.tb_observation.MaxLength = 32767;
            this.tb_observation.Multiline = true;
            this.tb_observation.Name = "tb_observation";
            this.tb_observation.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_observation.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_observation.PlaceholderText = "";
            this.tb_observation.Size = new System.Drawing.Size(238, 67);
            this.tb_observation.TabIndex = 42;
            // 
            // tb_indicateur
            // 
            this.tb_indicateur.BackColor = System.Drawing.Color.White;
            this.tb_indicateur.BorderColor = System.Drawing.Color.Silver;
            this.tb_indicateur.BorderRadius = 8;
            this.tb_indicateur.FocusBorderColor = System.Drawing.Color.Orange;
            this.tb_indicateur.ForeColor = System.Drawing.Color.Black;
            this.tb_indicateur.Image = null;
            this.tb_indicateur.Location = new System.Drawing.Point(211, 291);
            this.tb_indicateur.MaxLength = 32767;
            this.tb_indicateur.Multiline = true;
            this.tb_indicateur.Name = "tb_indicateur";
            this.tb_indicateur.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_indicateur.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_indicateur.PlaceholderText = "";
            this.tb_indicateur.Size = new System.Drawing.Size(238, 67);
            this.tb_indicateur.TabIndex = 42;
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
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(12, 11);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 10;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(519, 80);
            this.bunifuRoundedPanel1.TabIndex = 40;
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
            this.lb_num_fiche.Location = new System.Drawing.Point(396, 37);
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
            // cbx_consultation
            // 
            this.cbx_consultation.ArrowColor = System.Drawing.Color.DimGray;
            this.cbx_consultation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_consultation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_consultation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbx_consultation.BorderRadius = 8;
            this.cbx_consultation.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_consultation.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_consultation.DropDownSelectedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.cbx_consultation.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_consultation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_consultation.DropDownWidth = 250;
            this.cbx_consultation.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.cbx_consultation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_consultation.Location = new System.Drawing.Point(211, 408);
            this.cbx_consultation.MinimumSize = new System.Drawing.Size(80, 36);
            this.cbx_consultation.Name = "cbx_consultation";
            this.cbx_consultation.SelectedItem = null;
            this.cbx_consultation.SelectedValue = null;
            this.cbx_consultation.Size = new System.Drawing.Size(238, 42);
            this.cbx_consultation.TabIndex = 34;
            // 
            // cbx_service
            // 
            this.cbx_service.ArrowColor = System.Drawing.Color.DimGray;
            this.cbx_service.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_service.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_service.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbx_service.BorderRadius = 8;
            this.cbx_service.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_service.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_service.DropDownSelectedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.cbx_service.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_service.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_service.DropDownWidth = 250;
            this.cbx_service.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.cbx_service.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_service.Location = new System.Drawing.Point(211, 160);
            this.cbx_service.MinimumSize = new System.Drawing.Size(80, 36);
            this.cbx_service.Name = "cbx_service";
            this.cbx_service.SelectedItem = null;
            this.cbx_service.SelectedValue = null;
            this.cbx_service.Size = new System.Drawing.Size(238, 42);
            this.cbx_service.TabIndex = 34;
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
            this.btn_cancel.Location = new System.Drawing.Point(98, 565);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(150, 45);
            this.btn_cancel.TabIndex = 32;
            this.btn_cancel.Text = "Annuler";
            this.btn_cancel.TextColor = System.Drawing.Color.White;
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_send_request
            // 
            this.btn_send_request.BackColor = System.Drawing.Color.Transparent;
            this.btn_send_request.BorderColor = System.Drawing.Color.White;
            this.btn_send_request.BorderRadius = 10;
            this.btn_send_request.BorderSize = 0;
            this.btn_send_request.ButtonText = "Envoyer";
            this.btn_send_request.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_send_request.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_send_request.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_send_request.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send_request.ForeColor = System.Drawing.Color.White;
            this.btn_send_request.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_send_request.Image = global::Cepima.Properties.Resources.paper_plane_30px;
            this.btn_send_request.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_send_request.Location = new System.Drawing.Point(281, 565);
            this.btn_send_request.Name = "btn_send_request";
            this.btn_send_request.Size = new System.Drawing.Size(164, 45);
            this.btn_send_request.TabIndex = 31;
            this.btn_send_request.Text = "Envoyer";
            this.btn_send_request.TextColor = System.Drawing.Color.White;
            this.btn_send_request.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_send_request.UseVisualStyleBackColor = false;
            this.btn_send_request.Click += new System.EventHandler(this.btn_send_request_Click);
            // 
            // Form_demander_service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(543, 678);
            this.Controls.Add(this.tb_observation);
            this.Controls.Add(this.tb_indicateur);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.rd_priorite_normal);
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Controls.Add(this.cbx_consultation);
            this.Controls.Add(this.cbx_service);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_send_request);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.label2);
            this.Name = "Form_demander_service";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demande service";
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.bunifuRoundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyRoundedComboBox cbx_service;
        private RoundedButton btn_cancel;
        private RoundedButton btn_send_request;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label2;
        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_nom_patient;
        private System.Windows.Forms.Label lb_num_fiche;
        private System.Windows.Forms.Label lb_sexe_age;
        private System.Windows.Forms.RadioButton rd_priorite_normal;
        private System.Windows.Forms.RadioButton radioButton1;
        private MyRoundedTextBox tb_indicateur;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private MyRoundedComboBox cbx_consultation;
        private System.Windows.Forms.Label label5;
        private MyRoundedTextBox tb_observation;
    }
}