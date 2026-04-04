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
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel.BorderRadius = 15;
            this.panel.BorderSize = 2;
            this.panel.Controls.Add(this.fl_patient);
            this.panel.Controls.Add(this.label1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.HoverBackColor = System.Drawing.Color.Empty;
            this.panel.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(961, 424);
            this.panel.TabIndex = 0;
            // 
            // fl_patient
            // 
            this.fl_patient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fl_patient.AutoScroll = true;
            this.fl_patient.Location = new System.Drawing.Point(3, 18);
            this.fl_patient.Name = "fl_patient";
            this.fl_patient.Size = new System.Drawing.Size(955, 392);
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
            // User_display_patients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.panel);
            this.Name = "User_display_patients";
            this.Size = new System.Drawing.Size(961, 424);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomRoundedPanel panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel fl_patient;
    }
}
