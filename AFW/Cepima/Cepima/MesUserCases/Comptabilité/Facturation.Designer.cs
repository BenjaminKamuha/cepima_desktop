namespace Cepima.MesUserCases.Comptabilité
{
    partial class Facturation
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
            this.rb_tout = new System.Windows.Forms.RadioButton();
            this.rb_hospitalise = new System.Windows.Forms.RadioButton();
            this.rb_ambulatoire = new System.Windows.Forms.RadioButton();
            this.rb_partielle = new System.Windows.Forms.RadioButton();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.panel_facture = new System.Windows.Forms.FlowLayoutPanel();
            this.lb_not_found = new System.Windows.Forms.Label();
            this.tb_search_demande = new MyRoundedTextBox();
            this.customRoundedPanel1.SuspendLayout();
            this.panel_facture.SuspendLayout();
            this.SuspendLayout();
            // 
            // rb_tout
            // 
            this.rb_tout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_tout.AutoSize = true;
            this.rb_tout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_tout.Location = new System.Drawing.Point(360, 20);
            this.rb_tout.Name = "rb_tout";
            this.rb_tout.Size = new System.Drawing.Size(61, 20);
            this.rb_tout.TabIndex = 45;
            this.rb_tout.TabStop = true;
            this.rb_tout.Text = "Tous";
            this.rb_tout.UseVisualStyleBackColor = true;
            this.rb_tout.CheckedChanged += new System.EventHandler(this.rb_tout_CheckedChanged);
            // 
            // rb_hospitalise
            // 
            this.rb_hospitalise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_hospitalise.AutoSize = true;
            this.rb_hospitalise.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_hospitalise.Location = new System.Drawing.Point(630, 20);
            this.rb_hospitalise.Name = "rb_hospitalise";
            this.rb_hospitalise.Size = new System.Drawing.Size(105, 20);
            this.rb_hospitalise.TabIndex = 47;
            this.rb_hospitalise.TabStop = true;
            this.rb_hospitalise.Text = "Hospitalisé";
            this.rb_hospitalise.UseVisualStyleBackColor = true;
            this.rb_hospitalise.CheckedChanged += new System.EventHandler(this.rb_hospitalise_CheckedChanged);
            // 
            // rb_ambulatoire
            // 
            this.rb_ambulatoire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_ambulatoire.AutoSize = true;
            this.rb_ambulatoire.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_ambulatoire.Location = new System.Drawing.Point(471, 20);
            this.rb_ambulatoire.Name = "rb_ambulatoire";
            this.rb_ambulatoire.Size = new System.Drawing.Size(109, 20);
            this.rb_ambulatoire.TabIndex = 48;
            this.rb_ambulatoire.TabStop = true;
            this.rb_ambulatoire.Text = "Ambulatoire";
            this.rb_ambulatoire.UseVisualStyleBackColor = true;
            this.rb_ambulatoire.CheckedChanged += new System.EventHandler(this.rb_ambulatoire_CheckedChanged);
            // 
            // rb_partielle
            // 
            this.rb_partielle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_partielle.AutoSize = true;
            this.rb_partielle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_partielle.Location = new System.Drawing.Point(785, 20);
            this.rb_partielle.Name = "rb_partielle";
            this.rb_partielle.Size = new System.Drawing.Size(160, 20);
            this.rb_partielle.TabIndex = 46;
            this.rb_partielle.TabStop = true;
            this.rb_partielle.Text = "Partiellement  payé";
            this.rb_partielle.UseVisualStyleBackColor = true;
            this.rb_partielle.CheckedChanged += new System.EventHandler(this.rb_partielle_CheckedChanged);
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customRoundedPanel1.BackColor = System.Drawing.Color.White;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 10;
            this.customRoundedPanel1.BorderSize = 2;
            this.customRoundedPanel1.Controls.Add(this.panel_facture);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(9, 54);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.ShadowBlur = 10;
            this.customRoundedPanel1.ShadowBorderRadius = -1;
            this.customRoundedPanel1.ShadowColor = System.Drawing.Color.Black;
            this.customRoundedPanel1.ShadowEnabled = false;
            this.customRoundedPanel1.ShadowOffsetX = 0;
            this.customRoundedPanel1.ShadowOffsetY = 4;
            this.customRoundedPanel1.ShadowOpacity = 60;
            this.customRoundedPanel1.ShadowSpread = 0;
            this.customRoundedPanel1.Size = new System.Drawing.Size(1003, 462);
            this.customRoundedPanel1.TabIndex = 43;
            // 
            // panel_facture
            // 
            this.panel_facture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_facture.Controls.Add(this.lb_not_found);
            this.panel_facture.Location = new System.Drawing.Point(3, 10);
            this.panel_facture.Name = "panel_facture";
            this.panel_facture.Size = new System.Drawing.Size(997, 444);
            this.panel_facture.TabIndex = 1;
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
            this.lb_not_found.TabIndex = 5;
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
            this.tb_search_demande.Location = new System.Drawing.Point(12, 14);
            this.tb_search_demande.MaxLength = 32767;
            this.tb_search_demande.Name = "tb_search_demande";
            this.tb_search_demande.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_search_demande.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_search_demande.PlaceholderText = "Rechercher un patient";
            this.tb_search_demande.Size = new System.Drawing.Size(273, 34);
            this.tb_search_demande.TabIndex = 44;
            this.tb_search_demande.TextChanged += new System.EventHandler(this.tb_search_demande_TextChanged);
            // 
            // Facturation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.customRoundedPanel1);
            this.Controls.Add(this.rb_tout);
            this.Controls.Add(this.rb_partielle);
            this.Controls.Add(this.rb_hospitalise);
            this.Controls.Add(this.rb_ambulatoire);
            this.Controls.Add(this.tb_search_demande);
            this.Name = "Facturation";
            this.Size = new System.Drawing.Size(1021, 519);
            this.customRoundedPanel1.ResumeLayout(false);
            this.panel_facture.ResumeLayout(false);
            this.panel_facture.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.RadioButton rb_tout;
        private System.Windows.Forms.RadioButton rb_hospitalise;
        private System.Windows.Forms.RadioButton rb_ambulatoire;
        private MyRoundedTextBox tb_search_demande;
        private System.Windows.Forms.RadioButton rb_partielle;
        private System.Windows.Forms.FlowLayoutPanel panel_facture;
        private System.Windows.Forms.Label lb_not_found;
    }
}
