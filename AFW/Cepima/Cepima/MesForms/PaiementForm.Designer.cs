namespace Cepima.MesForms
{
    partial class PaiementForm
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
            this.bt_choisir_patient = new RoundedButton();
            this.panForm = new System.Windows.Forms.Panel();
            this.bt_mod = new RoundedButton();
            this.nud_montant_payer = new RoundedNumericUpDown();
            this.nud_rest = new RoundedNumericUpDown();
            this.nud_prix = new RoundedNumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_prestation = new MyRoundedComboBox();
            this.cbx_service = new MyRoundedComboBox();
            this.btn_cancel = new RoundedButton();
            this.btn_send_request = new RoundedButton();
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuRoundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panForm.SuspendLayout();
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
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(544, 91);
            this.bunifuRoundedPanel1.TabIndex = 59;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(3, 10);
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
            this.lb_nom_patient.Size = new System.Drawing.Size(0, 18);
            this.lb_nom_patient.TabIndex = 29;
            // 
            // lb_num_fiche
            // 
            this.lb_num_fiche.AutoSize = true;
            this.lb_num_fiche.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_num_fiche.Location = new System.Drawing.Point(396, 37);
            this.lb_num_fiche.Name = "lb_num_fiche";
            this.lb_num_fiche.Size = new System.Drawing.Size(0, 18);
            this.lb_num_fiche.TabIndex = 23;
            // 
            // lb_sexe_age
            // 
            this.lb_sexe_age.AutoSize = true;
            this.lb_sexe_age.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sexe_age.Location = new System.Drawing.Point(119, 49);
            this.lb_sexe_age.Name = "lb_sexe_age";
            this.lb_sexe_age.Size = new System.Drawing.Size(0, 18);
            this.lb_sexe_age.TabIndex = 23;
            // 
            // bt_choisir_patient
            // 
            this.bt_choisir_patient.BackColor = System.Drawing.Color.Transparent;
            this.bt_choisir_patient.BorderColor = System.Drawing.Color.White;
            this.bt_choisir_patient.BorderRadius = 10;
            this.bt_choisir_patient.BorderSize = 0;
            this.bt_choisir_patient.ButtonText = "Choisir patient";
            this.bt_choisir_patient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_choisir_patient.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_choisir_patient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_choisir_patient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_choisir_patient.ForeColor = System.Drawing.Color.White;
            this.bt_choisir_patient.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_choisir_patient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_choisir_patient.Location = new System.Drawing.Point(432, 57);
            this.bt_choisir_patient.Name = "bt_choisir_patient";
            this.bt_choisir_patient.Size = new System.Drawing.Size(108, 30);
            this.bt_choisir_patient.TabIndex = 55;
            this.bt_choisir_patient.Text = "Choisir patient";
            this.bt_choisir_patient.TextColor = System.Drawing.Color.White;
            this.bt_choisir_patient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_choisir_patient.UseVisualStyleBackColor = false;
            this.bt_choisir_patient.Click += new System.EventHandler(this.bt_choisir_patient_Click);
            // 
            // panForm
            // 
            this.panForm.Controls.Add(this.bt_mod);
            this.panForm.Controls.Add(this.nud_montant_payer);
            this.panForm.Controls.Add(this.nud_rest);
            this.panForm.Controls.Add(this.nud_prix);
            this.panForm.Controls.Add(this.label5);
            this.panForm.Controls.Add(this.label3);
            this.panForm.Controls.Add(this.label1);
            this.panForm.Controls.Add(this.label4);
            this.panForm.Controls.Add(this.cbx_prestation);
            this.panForm.Controls.Add(this.cbx_service);
            this.panForm.Controls.Add(this.btn_cancel);
            this.panForm.Controls.Add(this.btn_send_request);
            this.panForm.Controls.Add(this.label2);
            this.panForm.Enabled = false;
            this.panForm.Location = new System.Drawing.Point(13, 97);
            this.panForm.Name = "panForm";
            this.panForm.Size = new System.Drawing.Size(519, 474);
            this.panForm.TabIndex = 62;
            // 
            // bt_mod
            // 
            this.bt_mod.BackColor = System.Drawing.Color.Transparent;
            this.bt_mod.BorderColor = System.Drawing.Color.White;
            this.bt_mod.BorderRadius = 10;
            this.bt_mod.BorderSize = 0;
            this.bt_mod.ButtonText = "Modifier";
            this.bt_mod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_mod.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_mod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_mod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_mod.ForeColor = System.Drawing.Color.White;
            this.bt_mod.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_mod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_mod.Location = new System.Drawing.Point(355, 158);
            this.bt_mod.Name = "bt_mod";
            this.bt_mod.Size = new System.Drawing.Size(88, 30);
            this.bt_mod.TabIndex = 74;
            this.bt_mod.Text = "Modifier";
            this.bt_mod.TextColor = System.Drawing.Color.White;
            this.bt_mod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_mod.UseVisualStyleBackColor = true;
            this.bt_mod.Click += new System.EventHandler(this.bt_mod_Click);
            // 
            // nud_montant_payer
            // 
            this.nud_montant_payer.BackColor = System.Drawing.Color.White;
            this.nud_montant_payer.BorderColor = System.Drawing.Color.LightGray;
            this.nud_montant_payer.BorderSize = 2;
            this.nud_montant_payer.ButtonBackColor = System.Drawing.Color.White;
            this.nud_montant_payer.ButtonFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.nud_montant_payer.ButtonForeColor = System.Drawing.Color.DimGray;
            this.nud_montant_payer.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.nud_montant_payer.DecimalPlaces = 2;
            this.nud_montant_payer.Enabled = false;
            this.nud_montant_payer.FocusBorderColor = System.Drawing.Color.DeepSkyBlue;
            this.nud_montant_payer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nud_montant_payer.ForeColor = System.Drawing.Color.Black;
            this.nud_montant_payer.Location = new System.Drawing.Point(205, 230);
            this.nud_montant_payer.MinimumSize = new System.Drawing.Size(77, 32);
            this.nud_montant_payer.Name = "nud_montant_payer";
            this.nud_montant_payer.Size = new System.Drawing.Size(130, 38);
            this.nud_montant_payer.TabIndex = 71;
            this.nud_montant_payer.ValueChanged += new System.EventHandler(this.nud_montant_payer_ValueChanged);
            // 
            // nud_rest
            // 
            this.nud_rest.BackColor = System.Drawing.Color.White;
            this.nud_rest.BorderColor = System.Drawing.Color.LightGray;
            this.nud_rest.BorderSize = 2;
            this.nud_rest.ButtonBackColor = System.Drawing.Color.White;
            this.nud_rest.ButtonFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.nud_rest.ButtonForeColor = System.Drawing.Color.DimGray;
            this.nud_rest.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.nud_rest.DecimalPlaces = 2;
            this.nud_rest.Enabled = false;
            this.nud_rest.FocusBorderColor = System.Drawing.Color.DeepSkyBlue;
            this.nud_rest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nud_rest.ForeColor = System.Drawing.Color.Black;
            this.nud_rest.Location = new System.Drawing.Point(205, 300);
            this.nud_rest.MinimumSize = new System.Drawing.Size(77, 32);
            this.nud_rest.Name = "nud_rest";
            this.nud_rest.Size = new System.Drawing.Size(130, 38);
            this.nud_rest.TabIndex = 72;
            // 
            // nud_prix
            // 
            this.nud_prix.BackColor = System.Drawing.Color.White;
            this.nud_prix.BorderColor = System.Drawing.Color.LightGray;
            this.nud_prix.BorderSize = 2;
            this.nud_prix.ButtonBackColor = System.Drawing.Color.White;
            this.nud_prix.ButtonFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.nud_prix.ButtonForeColor = System.Drawing.Color.DimGray;
            this.nud_prix.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.nud_prix.DecimalPlaces = 2;
            this.nud_prix.Enabled = false;
            this.nud_prix.FocusBorderColor = System.Drawing.Color.DeepSkyBlue;
            this.nud_prix.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nud_prix.ForeColor = System.Drawing.Color.Black;
            this.nud_prix.Location = new System.Drawing.Point(205, 156);
            this.nud_prix.MinimumSize = new System.Drawing.Size(77, 32);
            this.nud_prix.Name = "nud_prix";
            this.nud_prix.Size = new System.Drawing.Size(130, 38);
            this.nud_prix.TabIndex = 73;
            this.nud_prix.ValueChanged += new System.EventHandler(this.nud_prix_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(75, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 17);
            this.label5.TabIndex = 67;
            this.label5.Text = "Reste à payer:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 68;
            this.label3.Text = "Montant payer:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 69;
            this.label1.Text = "Prix prestation:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(78, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 70;
            this.label4.Text = "Prestation: ";
            // 
            // cbx_prestation
            // 
            this.cbx_prestation.ArrowColor = System.Drawing.Color.DimGray;
            this.cbx_prestation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_prestation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_prestation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbx_prestation.BorderRadius = 8;
            this.cbx_prestation.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_prestation.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_prestation.DropDownSelectedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.cbx_prestation.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_prestation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_prestation.DropDownWidth = 250;
            this.cbx_prestation.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.cbx_prestation.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.cbx_prestation.Location = new System.Drawing.Point(205, 86);
            this.cbx_prestation.MinimumSize = new System.Drawing.Size(80, 36);
            this.cbx_prestation.Name = "cbx_prestation";
            this.cbx_prestation.SelectedItem = null;
            this.cbx_prestation.SelectedValue = null;
            this.cbx_prestation.Size = new System.Drawing.Size(238, 36);
            this.cbx_prestation.TabIndex = 63;
            this.cbx_prestation.SelectedIndexChanged += new System.EventHandler(this.cbx_prestation_SelectedIndexChanged_1);
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
            this.cbx_service.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.cbx_service.Location = new System.Drawing.Point(205, 16);
            this.cbx_service.MinimumSize = new System.Drawing.Size(80, 36);
            this.cbx_service.Name = "cbx_service";
            this.cbx_service.SelectedItem = null;
            this.cbx_service.SelectedValue = null;
            this.cbx_service.Size = new System.Drawing.Size(238, 36);
            this.cbx_service.TabIndex = 62;
            this.cbx_service.SelectedIndexChanged += new System.EventHandler(this.cbx_service_SelectedIndexChanged);
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
            this.btn_cancel.Location = new System.Drawing.Point(92, 409);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(150, 45);
            this.btn_cancel.TabIndex = 66;
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
            this.btn_send_request.ButtonText = "Confirmer";
            this.btn_send_request.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_send_request.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_send_request.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_send_request.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send_request.ForeColor = System.Drawing.Color.White;
            this.btn_send_request.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_send_request.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_send_request.Location = new System.Drawing.Point(275, 409);
            this.btn_send_request.Name = "btn_send_request";
            this.btn_send_request.Size = new System.Drawing.Size(164, 45);
            this.btn_send_request.TabIndex = 65;
            this.btn_send_request.Text = "Confirmer";
            this.btn_send_request.TextColor = System.Drawing.Color.White;
            this.btn_send_request.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_send_request.UseVisualStyleBackColor = false;
            this.btn_send_request.Click += new System.EventHandler(this.btn_send_request_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 64;
            this.label2.Text = "Services : ";
            // 
            // PaiementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(544, 583);
            this.Controls.Add(this.panForm);
            this.Controls.Add(this.bt_choisir_patient);
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Name = "PaiementForm";
            this.Text = "PaiementForm";
            this.Load += new System.EventHandler(this.PaiementForm_Load);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.bunifuRoundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panForm.ResumeLayout(false);
            this.panForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BunifuRoundedPanel bunifuRoundedPanel1;
        private RoundedButton bt_choisir_patient;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_nom_patient;
        private System.Windows.Forms.Label lb_num_fiche;
        private System.Windows.Forms.Label lb_sexe_age;
        private System.Windows.Forms.Panel panForm;
        private RoundedButton bt_mod;
        private RoundedNumericUpDown nud_montant_payer;
        private RoundedNumericUpDown nud_rest;
        private RoundedNumericUpDown nud_prix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private MyRoundedComboBox cbx_prestation;
        private MyRoundedComboBox cbx_service;
        private RoundedButton btn_cancel;
        private RoundedButton btn_send_request;
        private System.Windows.Forms.Label label2;
    }
}