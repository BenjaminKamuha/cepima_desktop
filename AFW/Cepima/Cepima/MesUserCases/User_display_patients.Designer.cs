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
            this.panel = new CustomRoundedPanel();
            this.fl_patient = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.tb_search_patient = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.customRoundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel.BorderRadius = 15;
            this.panel.BorderSize = 2;
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.customRoundedPanel1);
            this.panel.Controls.Add(this.fl_patient);
            this.panel.Controls.Add(this.label1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.HoverBackColor = System.Drawing.Color.Empty;
            this.panel.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(786, 424);
            this.panel.TabIndex = 0;
            // 
            // fl_patient
            // 
            this.fl_patient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fl_patient.AutoScroll = true;
            this.fl_patient.Location = new System.Drawing.Point(3, 41);
            this.fl_patient.Name = "fl_patient";
            this.fl_patient.Size = new System.Drawing.Size(780, 369);
            this.fl_patient.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 23);
            this.label1.TabIndex = 0;
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.DarkGray;
            this.customRoundedPanel1.BorderRadius = 5;
            this.customRoundedPanel1.BorderSize = 1;
            this.customRoundedPanel1.Controls.Add(this.pictureBox1);
            this.customRoundedPanel1.Controls.Add(this.tb_search_patient);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(549, 5);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Size = new System.Drawing.Size(227, 29);
            this.customRoundedPanel1.TabIndex = 0;
            // 
            // tb_search_patient
            // 
            this.tb_search_patient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.tb_search_patient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_search_patient.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search_patient.Location = new System.Drawing.Point(3, 3);
            this.tb_search_patient.Multiline = true;
            this.tb_search_patient.Name = "tb_search_patient";
            this.tb_search_patient.Size = new System.Drawing.Size(188, 24);
            this.tb_search_patient.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.search1;
            this.pictureBox1.Location = new System.Drawing.Point(192, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(414, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Rechercher un patient";
            // 
            // User_display_patients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.panel);
            this.Name = "User_display_patients";
            this.Size = new System.Drawing.Size(786, 424);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomRoundedPanel panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel fl_patient;
        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tb_search_patient;
        private System.Windows.Forms.Label label2;
    }
}
