namespace Cepima.MesUserCases
{
    partial class User_personnels_display
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
            this.panel_personnel_display = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel_personnel_display
            // 
            this.panel_personnel_display.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_personnel_display.AutoScroll = true;
            this.panel_personnel_display.BackColor = System.Drawing.Color.Coral;
            this.panel_personnel_display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_personnel_display.Location = new System.Drawing.Point(0, 0);
            this.panel_personnel_display.Name = "panel_personnel_display";
            this.panel_personnel_display.Size = new System.Drawing.Size(894, 458);
            this.panel_personnel_display.TabIndex = 4;
            // 
            // User_personnels_display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_personnel_display);
            this.Name = "User_personnels_display";
            this.Size = new System.Drawing.Size(894, 458);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_personnel_display;
    }
}
