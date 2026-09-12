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
            this.lb_nombres = new System.Windows.Forms.Label();
            this.tb_search_demande = new MyRoundedTextBox();
            this.pan = new CustomRoundedPanel();
            this.panel_patient = new System.Windows.Forms.FlowLayoutPanel();
            this.lb_not_found = new System.Windows.Forms.Label();
            this.pan.SuspendLayout();
            this.panel_patient.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_nombres
            // 
            this.lb_nombres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_nombres.AutoSize = true;
            this.lb_nombres.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nombres.Location = new System.Drawing.Point(837, 29);
            this.lb_nombres.Name = "lb_nombres";
            this.lb_nombres.Size = new System.Drawing.Size(52, 15);
            this.lb_nombres.TabIndex = 4;
            this.lb_nombres.Text = "Patients";
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
            this.tb_search_demande.Location = new System.Drawing.Point(3, 10);
            this.tb_search_demande.MaxLength = 32767;
            this.tb_search_demande.Name = "tb_search_demande";
            this.tb_search_demande.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_search_demande.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_search_demande.PlaceholderText = "";
            this.tb_search_demande.Size = new System.Drawing.Size(273, 34);
            this.tb_search_demande.TabIndex = 9;
            this.tb_search_demande.TextChanged += new System.EventHandler(this.tb_search_demande_TextChanged);
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
            this.pan.Location = new System.Drawing.Point(3, 50);
            this.pan.Name = "pan";
            this.pan.ShadowBlur = 10;
            this.pan.ShadowBorderRadius = -1;
            this.pan.ShadowColor = System.Drawing.Color.Black;
            this.pan.ShadowEnabled = false;
            this.pan.ShadowOffsetX = 0;
            this.pan.ShadowOffsetY = 4;
            this.pan.ShadowOpacity = 60;
            this.pan.ShadowSpread = 0;
            this.pan.Size = new System.Drawing.Size(1051, 533);
            this.pan.TabIndex = 1;
            // 
            // panel_patient
            // 
            this.panel_patient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_patient.Controls.Add(this.lb_not_found);
            this.panel_patient.Location = new System.Drawing.Point(3, 12);
            this.panel_patient.Name = "panel_patient";
            this.panel_patient.Size = new System.Drawing.Size(1045, 518);
            this.panel_patient.TabIndex = 0;
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
            // User_display_patients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tb_search_demande);
            this.Controls.Add(this.lb_nombres);
            this.Controls.Add(this.pan);
            this.Name = "User_display_patients";
            this.Size = new System.Drawing.Size(1057, 586);
            this.Load += new System.EventHandler(this.User_display_patients_Load);
            this.pan.ResumeLayout(false);
            this.panel_patient.ResumeLayout(false);
            this.panel_patient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomRoundedPanel pan;
        private System.Windows.Forms.Label lb_nombres;
        private MyRoundedTextBox tb_search_demande;
        private System.Windows.Forms.FlowLayoutPanel panel_patient;
        private System.Windows.Forms.Label lb_not_found;

    }
}
