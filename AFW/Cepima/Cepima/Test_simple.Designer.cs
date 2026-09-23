namespace Cepima
{
    partial class Test_simple
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
            this.monGraphique1 = new Cepima.Controls.MonGraphique();
            this.SuspendLayout();
            // 
            // monGraphique1
            // 
            this.monGraphique1.AfficherGrille = true;
            this.monGraphique1.AfficherLegende = true;
            this.monGraphique1.AnimationActive = true;
            this.monGraphique1.BackColor = System.Drawing.Color.White;
            this.monGraphique1.CouleurFond = System.Drawing.Color.White;
            this.monGraphique1.CouleurPrincipale = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.monGraphique1.CouleurTitre = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.monGraphique1.Location = new System.Drawing.Point(31, 31);
            this.monGraphique1.Name = "monGraphique1";
            this.monGraphique1.Size = new System.Drawing.Size(911, 525);
            this.monGraphique1.TabIndex = 0;
            this.monGraphique1.Titre = "Mon graphique";
            // 
            // Test_simple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 585);
            this.Controls.Add(this.monGraphique1);
            this.Name = "Test_simple";
            this.Text = "Test_simple";
            this.Load += new System.EventHandler(this.Test_simple_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.MonGraphique monGraphique1;

    }
}