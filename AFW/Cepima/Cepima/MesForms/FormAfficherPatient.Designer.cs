namespace Cepima.MesForms
{
    partial class FormAfficherPatient
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
            this.lb_not_found = new System.Windows.Forms.Label();
            this.tb_search_demande = new MyRoundedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_nombres = new System.Windows.Forms.Label();
            this.pan = new CustomRoundedPanel();
            this.panel_patient = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_add_patient = new RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pan.SuspendLayout();
            this.panel_patient.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_not_found
            // 
            this.lb_not_found.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_not_found.AutoSize = true;
            this.lb_not_found.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_not_found.Location = new System.Drawing.Point(3, 0);
            this.lb_not_found.Name = "lb_not_found";
            this.lb_not_found.Padding = new System.Windows.Forms.Padding(400, 250, 0, 0);
            this.lb_not_found.Size = new System.Drawing.Size(400, 270);
            this.lb_not_found.TabIndex = 4;
            // 
            // tb_search_demande
            // 
            this.tb_search_demande.BackColor = System.Drawing.Color.White;
            this.tb_search_demande.BorderColor = System.Drawing.Color.Silver;
            this.tb_search_demande.BorderRadius = 8;
            this.tb_search_demande.BorderSize = 1;
            this.tb_search_demande.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_search_demande.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.tb_search_demande.ForeColor = System.Drawing.Color.Black;
            this.tb_search_demande.Image = global::Cepima.Properties.Resources.search_25px;
            this.tb_search_demande.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_search_demande.ImagePadding = 4;
            this.tb_search_demande.Location = new System.Drawing.Point(9, 5);
            this.tb_search_demande.MaxLength = 32767;
            this.tb_search_demande.Name = "tb_search_demande";
            this.tb_search_demande.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_search_demande.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_search_demande.PlaceholderText = "";
            this.tb_search_demande.Size = new System.Drawing.Size(273, 34);
            this.tb_search_demande.TabIndex = 14;
            this.tb_search_demande.TextChanged += new System.EventHandler(this.tb_search_demande_TextChanged_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.vision;
            this.pictureBox1.Location = new System.Drawing.Point(512, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 38);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // lb_nombres
            // 
            this.lb_nombres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_nombres.AutoSize = true;
            this.lb_nombres.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nombres.Location = new System.Drawing.Point(829, 17);
            this.lb_nombres.Name = "lb_nombres";
            this.lb_nombres.Size = new System.Drawing.Size(52, 15);
            this.lb_nombres.TabIndex = 11;
            this.lb_nombres.Text = "Patients";
            // 
            // pan
            // 
            this.pan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pan.BackColor = System.Drawing.Color.White;
            this.pan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pan.BorderRadius = 10;
            this.pan.BorderSize = 2;
            this.pan.Controls.Add(this.panel_patient);
            this.pan.HoverBackColor = System.Drawing.Color.Empty;
            this.pan.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.pan.Location = new System.Drawing.Point(2, 45);
            this.pan.Name = "pan";
            this.pan.ShadowBlur = 10;
            this.pan.ShadowBorderRadius = -1;
            this.pan.ShadowColor = System.Drawing.Color.Black;
            this.pan.ShadowEnabled = false;
            this.pan.ShadowOffsetX = 0;
            this.pan.ShadowOffsetY = 4;
            this.pan.ShadowOpacity = 60;
            this.pan.ShadowSpread = 0;
            this.pan.Size = new System.Drawing.Size(1031, 533);
            this.pan.TabIndex = 10;
            // 
            // panel_patient
            // 
            this.panel_patient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_patient.Controls.Add(this.lb_not_found);
            this.panel_patient.Location = new System.Drawing.Point(17, 12);
            this.panel_patient.Name = "panel_patient";
            this.panel_patient.Size = new System.Drawing.Size(997, 518);
            this.panel_patient.TabIndex = 0;
            // 
            // btn_add_patient
            // 
            this.btn_add_patient.BackColor = System.Drawing.Color.Transparent;
            this.btn_add_patient.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_add_patient.ButtonText = "";
            this.btn_add_patient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add_patient.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_add_patient.FlatAppearance.BorderSize = 0;
            this.btn_add_patient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_patient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_patient.ForeColor = System.Drawing.Color.White;
            this.btn_add_patient.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_add_patient.Image = global::Cepima.Properties.Resources.add_25px;
            this.btn_add_patient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_add_patient.Location = new System.Drawing.Point(976, 6);
            this.btn_add_patient.Name = "btn_add_patient";
            this.btn_add_patient.Size = new System.Drawing.Size(40, 33);
            this.btn_add_patient.TabIndex = 13;
            this.btn_add_patient.TextColor = System.Drawing.Color.White;
            this.btn_add_patient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_add_patient.UseVisualStyleBackColor = false;
            this.btn_add_patient.Click += new System.EventHandler(this.btn_add_patient_Click);
            // 
            // FormAfficherPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1041, 547);
            this.Controls.Add(this.tb_search_demande);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lb_nombres);
            this.Controls.Add(this.pan);
            this.Controls.Add(this.btn_add_patient);
            this.Name = "FormAfficherPatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAfficherPatient";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pan.ResumeLayout(false);
            this.panel_patient.ResumeLayout(false);
            this.panel_patient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_not_found;
        private MyRoundedTextBox tb_search_demande;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_nombres;
        private CustomRoundedPanel pan;
        private System.Windows.Forms.FlowLayoutPanel panel_patient;
        private RoundedButton btn_add_patient;
    }
}