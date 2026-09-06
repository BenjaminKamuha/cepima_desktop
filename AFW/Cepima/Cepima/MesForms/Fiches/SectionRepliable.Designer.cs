namespace Cepima.MesForms.Fiches
{
    partial class SectionRepliable
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
            this.panelSection = new BunifuRoundedPanel();
            this.panelContent = new BunifuRoundedPanel();
            this.panelHeader = new BunifuRoundedPanel();
            this.btnToggle = new System.Windows.Forms.Button();
            this.lblTitre = new System.Windows.Forms.Label();
            this.panelSection.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSection
            // 
            this.panelSection.BorderColor = System.Drawing.Color.DarkBlue;
            this.panelSection.BorderRadius = 4;
            this.panelSection.BorderSize = 0;
            this.panelSection.Controls.Add(this.panelContent);
            this.panelSection.Controls.Add(this.panelHeader);
            this.panelSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSection.Location = new System.Drawing.Point(0, 0);
            this.panelSection.Margin = new System.Windows.Forms.Padding(5);
            this.panelSection.Name = "panelSection";
            this.panelSection.ShadowColor = System.Drawing.Color.Gray;
            this.panelSection.ShadowDepth = 5;
            this.panelSection.Size = new System.Drawing.Size(796, 300);
            this.panelSection.TabIndex = 2;
            // 
            // panelContent
            // 
            this.panelContent.BorderColor = System.Drawing.Color.DarkBlue;
            this.panelContent.BorderRadius = 6;
            this.panelContent.BorderSize = 0;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 45);
            this.panelContent.Name = "panelContent";
            this.panelContent.ShadowColor = System.Drawing.Color.Gray;
            this.panelContent.ShadowDepth = 10;
            this.panelContent.Size = new System.Drawing.Size(796, 255);
            this.panelContent.TabIndex = 1;
            // 
            // panelHeader
            // 
            this.panelHeader.BorderColor = System.Drawing.Color.DarkBlue;
            this.panelHeader.BorderRadius = 6;
            this.panelHeader.BorderSize = 0;
            this.panelHeader.Controls.Add(this.btnToggle);
            this.panelHeader.Controls.Add(this.lblTitre);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.ShadowColor = System.Drawing.Color.Gray;
            this.panelHeader.ShadowDepth = 10;
            this.panelHeader.Size = new System.Drawing.Size(796, 45);
            this.panelHeader.TabIndex = 1;
            // 
            // btnToggle
            // 
            this.btnToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToggle.FlatAppearance.BorderSize = 0;
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggle.Location = new System.Drawing.Point(757, 7);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(26, 33);
            this.btnToggle.TabIndex = 1;
            this.btnToggle.Text = "-";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitre.Location = new System.Drawing.Point(13, 15);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(235, 20);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Informations administratives";
            // 
            // SectionRepliable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelSection);
            this.Name = "SectionRepliable";
            this.Size = new System.Drawing.Size(796, 300);
            this.panelSection.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BunifuRoundedPanel panelSection;
        private BunifuRoundedPanel panelContent;
        private BunifuRoundedPanel panelHeader;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Label lblTitre;


    }
}
