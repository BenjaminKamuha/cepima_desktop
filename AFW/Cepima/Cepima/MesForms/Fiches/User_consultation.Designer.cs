namespace Cepima.MesForms.Fiches
{
    partial class User_consultation
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
            this.bunifuRoundedPanel1 = new BunifuRoundedPanel();
            this.btn_new_consualor = new RoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuRoundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.DarkBlue;
            this.bunifuRoundedPanel1.BorderRadius = 6;
            this.bunifuRoundedPanel1.BorderSize = 0;
            this.bunifuRoundedPanel1.Controls.Add(this.btn_new_consualor);
            this.bunifuRoundedPanel1.Controls.Add(this.label1);
            this.bunifuRoundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 10;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(796, 170);
            this.bunifuRoundedPanel1.TabIndex = 0;
            // 
            // btn_new_consualor
            // 
            this.btn_new_consualor.BackColor = System.Drawing.Color.Transparent;
            this.btn_new_consualor.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_new_consualor.BorderRadius = 10;
            this.btn_new_consualor.ButtonText = "Nouvelle consultation";
            this.btn_new_consualor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_new_consualor.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_new_consualor.FlatAppearance.BorderSize = 0;
            this.btn_new_consualor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_new_consualor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_consualor.ForeColor = System.Drawing.Color.White;
            this.btn_new_consualor.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_new_consualor.Image = global::Cepima.Properties.Resources.counselor_40px;
            this.btn_new_consualor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_new_consualor.Location = new System.Drawing.Point(282, 106);
            this.btn_new_consualor.Name = "btn_new_consualor";
            this.btn_new_consualor.Size = new System.Drawing.Size(241, 38);
            this.btn_new_consualor.TabIndex = 8;
            this.btn_new_consualor.Text = "Nouvelle consultation";
            this.btn_new_consualor.TextColor = System.Drawing.Color.White;
            this.btn_new_consualor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_new_consualor.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(248, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Aucune consultation trouvée pour ce patient";
            // 
            // User_consultation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Name = "User_consultation";
            this.Size = new System.Drawing.Size(796, 170);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.bunifuRoundedPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BunifuRoundedPanel bunifuRoundedPanel1;
        private RoundedButton btn_new_consualor;
        private System.Windows.Forms.Label label1;

    }
}
