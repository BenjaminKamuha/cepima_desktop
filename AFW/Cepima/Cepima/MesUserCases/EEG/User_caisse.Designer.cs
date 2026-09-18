namespace Cepima.MesUserCases.EEG
{
    partial class User_caisse
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.pnl_examen = new System.Windows.Forms.Panel();
            this.rd_tout = new System.Windows.Forms.RadioButton();
            this.rd_statut_annule = new System.Windows.Forms.RadioButton();
            this.rd_statut_termine = new System.Windows.Forms.RadioButton();
            this.rd_statut_demande = new System.Windows.Forms.RadioButton();
            this.tb_search_demande = new MyRoundedTextBox();
            this.customRoundedPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.customRoundedPanel1.Controls.Add(this.pnl_examen);
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
            this.customRoundedPanel1.Size = new System.Drawing.Size(1003, 450);
            this.customRoundedPanel1.TabIndex = 43;
            // 
            // pnl_examen
            // 
            this.pnl_examen.Location = new System.Drawing.Point(3, 16);
            this.pnl_examen.Name = "pnl_examen";
            this.pnl_examen.Size = new System.Drawing.Size(997, 466);
            this.pnl_examen.TabIndex = 7;
            // 
            // rd_tout
            // 
            this.rd_tout.AutoSize = true;
            this.rd_tout.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_tout.Location = new System.Drawing.Point(320, 20);
            this.rd_tout.Name = "rd_tout";
            this.rd_tout.Size = new System.Drawing.Size(55, 22);
            this.rd_tout.TabIndex = 45;
            this.rd_tout.TabStop = true;
            this.rd_tout.Text = "Tous";
            this.rd_tout.UseVisualStyleBackColor = true;
            this.rd_tout.Visible = false;
            // 
            // rd_statut_annule
            // 
            this.rd_statut_annule.AutoSize = true;
            this.rd_statut_annule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_statut_annule.Location = new System.Drawing.Point(686, 20);
            this.rd_statut_annule.Name = "rd_statut_annule";
            this.rd_statut_annule.Size = new System.Drawing.Size(87, 21);
            this.rd_statut_annule.TabIndex = 46;
            this.rd_statut_annule.TabStop = true;
            this.rd_statut_annule.Text = "Annulé(s)";
            this.rd_statut_annule.UseVisualStyleBackColor = true;
            this.rd_statut_annule.Visible = false;
            // 
            // rd_statut_termine
            // 
            this.rd_statut_termine.AutoSize = true;
            this.rd_statut_termine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_statut_termine.Location = new System.Drawing.Point(573, 20);
            this.rd_statut_termine.Name = "rd_statut_termine";
            this.rd_statut_termine.Size = new System.Drawing.Size(95, 21);
            this.rd_statut_termine.TabIndex = 47;
            this.rd_statut_termine.TabStop = true;
            this.rd_statut_termine.Text = "Terminé(s)";
            this.rd_statut_termine.UseVisualStyleBackColor = true;
            this.rd_statut_termine.Visible = false;
            // 
            // rd_statut_demande
            // 
            this.rd_statut_demande.AutoSize = true;
            this.rd_statut_demande.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_statut_demande.Location = new System.Drawing.Point(441, 20);
            this.rd_statut_demande.Name = "rd_statut_demande";
            this.rd_statut_demande.Size = new System.Drawing.Size(104, 21);
            this.rd_statut_demande.TabIndex = 48;
            this.rd_statut_demande.TabStop = true;
            this.rd_statut_demande.Text = "Demandé(s)";
            this.rd_statut_demande.UseVisualStyleBackColor = true;
            this.rd_statut_demande.Visible = false;
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
            this.tb_search_demande.PlaceholderText = "Rechercher un examen";
            this.tb_search_demande.Size = new System.Drawing.Size(273, 34);
            this.tb_search_demande.TabIndex = 44;
            // 
            // User_caisse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.customRoundedPanel1);
            this.Controls.Add(this.rd_tout);
            this.Controls.Add(this.rd_statut_annule);
            this.Controls.Add(this.rd_statut_termine);
            this.Controls.Add(this.rd_statut_demande);
            this.Controls.Add(this.tb_search_demande);
            this.Name = "User_caisse";
            this.Size = new System.Drawing.Size(1021, 519);
            this.Load += new System.EventHandler(this.User_caisse_Load);
            this.customRoundedPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.Panel pnl_examen;
        private System.Windows.Forms.RadioButton rd_tout;
        private System.Windows.Forms.RadioButton rd_statut_annule;
        private System.Windows.Forms.RadioButton rd_statut_termine;
        private System.Windows.Forms.RadioButton rd_statut_demande;
        private MyRoundedTextBox tb_search_demande;
    }
}
