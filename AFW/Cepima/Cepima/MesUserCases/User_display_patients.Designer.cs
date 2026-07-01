namespace Cepima.MesUserCases
{
    partial class User_display_patients
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
            this.panel_patient = new System.Windows.Forms.Panel();
            this.lb_not_found = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tb_search_patient = new System.Windows.Forms.TextBox();
            this.customRoundedPanel1.SuspendLayout();
            this.panel_patient.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.customRoundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customRoundedPanel1.BackColor = System.Drawing.Color.White;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 10;
            this.customRoundedPanel1.BorderSize = 2;
            this.customRoundedPanel1.Controls.Add(this.panel_patient);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(235, 38);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Size = new System.Drawing.Size(771, 462);
            this.customRoundedPanel1.TabIndex = 1;
            // 
            // panel_patient
            // 
            this.panel_patient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_patient.AutoScroll = true;
            this.panel_patient.Controls.Add(this.lb_not_found);
            this.panel_patient.Location = new System.Drawing.Point(15, 17);
            this.panel_patient.Name = "panel_patient";
            this.panel_patient.Size = new System.Drawing.Size(743, 430);
            this.panel_patient.TabIndex = 0;
            // 
            // lb_not_found
            // 
            this.lb_not_found.AutoSize = true;
            this.lb_not_found.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_not_found.Location = new System.Drawing.Point(198, 230);
            this.lb_not_found.Name = "lb_not_found";
            this.lb_not_found.Size = new System.Drawing.Size(0, 16);
            this.lb_not_found.TabIndex = 0;
            this.lb_not_found.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(15, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 229);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(58, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Patients";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.being_sick_100px;
            this.pictureBox1.Location = new System.Drawing.Point(34, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // customRoundedPanel2
            // 
            this.customRoundedPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customRoundedPanel2.BackColor = System.Drawing.SystemColors.Window;
            this.customRoundedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel2.BorderRadius = 5;
            this.customRoundedPanel2.BorderSize = 2;
            this.customRoundedPanel2.Controls.Add(this.pictureBox2);
            this.customRoundedPanel2.Controls.Add(this.tb_search_patient);
            this.customRoundedPanel2.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel2.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel2.Location = new System.Drawing.Point(679, 4);
            this.customRoundedPanel2.Name = "customRoundedPanel2";
            this.customRoundedPanel2.Size = new System.Drawing.Size(296, 28);
            this.customRoundedPanel2.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox2.Image = global::Cepima.Properties.Resources.search1;
            this.pictureBox2.Location = new System.Drawing.Point(262, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // tb_search_patient
            // 
            this.tb_search_patient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_search_patient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_search_patient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search_patient.Location = new System.Drawing.Point(10, 4);
            this.tb_search_patient.Multiline = true;
            this.tb_search_patient.Name = "tb_search_patient";
            this.tb_search_patient.Size = new System.Drawing.Size(247, 20);
            this.tb_search_patient.TabIndex = 0;
            this.tb_search_patient.TextChanged += new System.EventHandler(this.tb_search_patient_TextChanged);
            // 
            // User_display_patients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.customRoundedPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.customRoundedPanel1);
            this.Name = "User_display_patients";
            this.Size = new System.Drawing.Size(1031, 526);
            this.customRoundedPanel1.ResumeLayout(false);
            this.panel_patient.ResumeLayout(false);
            this.panel_patient.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.customRoundedPanel2.ResumeLayout(false);
            this.customRoundedPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.Panel panel_patient;
        private System.Windows.Forms.Label lb_not_found;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomRoundedPanel customRoundedPanel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox tb_search_patient;

    }
}
