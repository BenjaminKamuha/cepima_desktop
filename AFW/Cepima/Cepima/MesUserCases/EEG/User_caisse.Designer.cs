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
            this.rd_tout = new System.Windows.Forms.RadioButton();
            this.rd_statut_annule = new System.Windows.Forms.RadioButton();
            this.rd_statut_termine = new System.Windows.Forms.RadioButton();
            this.rd_statut_demande = new System.Windows.Forms.RadioButton();
            this.rd_prescription = new System.Windows.Forms.RadioButton();
            this.rd_EEG = new System.Windows.Forms.RadioButton();
            this.rb_recu = new System.Windows.Forms.RadioButton();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.tb_search_demande = new MyRoundedTextBox();
            this.pnl_examen = new System.Windows.Forms.FlowLayoutPanel();
            this.customRoundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rd_tout
            // 
            this.rd_tout.AutoSize = true;
            this.rd_tout.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_tout.Location = new System.Drawing.Point(897, 20);
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
            this.rd_statut_annule.Location = new System.Drawing.Point(770, 20);
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
            this.rd_statut_termine.Location = new System.Drawing.Point(947, 21);
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
            this.rd_statut_demande.Location = new System.Drawing.Point(863, 20);
            this.rd_statut_demande.Name = "rd_statut_demande";
            this.rd_statut_demande.Size = new System.Drawing.Size(104, 21);
            this.rd_statut_demande.TabIndex = 48;
            this.rd_statut_demande.TabStop = true;
            this.rd_statut_demande.Text = "Demandé(s)";
            this.rd_statut_demande.UseVisualStyleBackColor = true;
            this.rd_statut_demande.Visible = false;
            this.rd_statut_demande.CheckedChanged += new System.EventHandler(this.rd_statut_demande_CheckedChanged);
            // 
            // rd_prescription
            // 
            this.rd_prescription.AutoSize = true;
            this.rd_prescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_prescription.Location = new System.Drawing.Point(461, 20);
            this.rd_prescription.Name = "rd_prescription";
            this.rd_prescription.Size = new System.Drawing.Size(108, 21);
            this.rd_prescription.TabIndex = 49;
            this.rd_prescription.TabStop = true;
            this.rd_prescription.Text = "Prescriptions";
            this.rd_prescription.UseVisualStyleBackColor = true;
            this.rd_prescription.CheckedChanged += new System.EventHandler(this.rd_hospitalisation_CheckedChanged);
            // 
            // rd_EEG
            // 
            this.rd_EEG.AutoSize = true;
            this.rd_EEG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_EEG.Location = new System.Drawing.Point(302, 20);
            this.rd_EEG.Name = "rd_EEG";
            this.rd_EEG.Size = new System.Drawing.Size(116, 21);
            this.rd_EEG.TabIndex = 50;
            this.rd_EEG.TabStop = true;
            this.rd_EEG.Text = "Examens EEG";
            this.rd_EEG.UseVisualStyleBackColor = true;
            this.rd_EEG.CheckedChanged += new System.EventHandler(this.rd_EEG_CheckedChanged);
            // 
            // rb_recu
            // 
            this.rb_recu.AutoSize = true;
            this.rb_recu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_recu.Location = new System.Drawing.Point(624, 20);
            this.rb_recu.Name = "rb_recu";
            this.rb_recu.Size = new System.Drawing.Size(135, 21);
            this.rb_recu.TabIndex = 49;
            this.rb_recu.TabStop = true;
            this.rb_recu.Text = "Afficher les récus";
            this.rb_recu.UseVisualStyleBackColor = true;
            this.rb_recu.CheckedChanged += new System.EventHandler(this.rb_recu_CheckedChanged);
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
            // pnl_examen
            // 
            this.pnl_examen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_examen.Location = new System.Drawing.Point(3, 3);
            this.pnl_examen.Name = "pnl_examen";
            this.pnl_examen.Size = new System.Drawing.Size(997, 444);
            this.pnl_examen.TabIndex = 2;
            // 
            // User_caisse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.rb_recu);
            this.Controls.Add(this.rd_prescription);
            this.Controls.Add(this.rd_EEG);
            this.Controls.Add(this.customRoundedPanel1);
            this.Controls.Add(this.rd_tout);
            this.Controls.Add(this.rd_statut_annule);
            this.Controls.Add(this.rd_statut_termine);
            this.Controls.Add(this.rd_statut_demande);
            this.Controls.Add(this.tb_search_demande);
            this.Name = "User_caisse";
            this.Size = new System.Drawing.Size(1021, 519);
            this.customRoundedPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.RadioButton rd_tout;
        private System.Windows.Forms.RadioButton rd_statut_annule;
        private System.Windows.Forms.RadioButton rd_statut_termine;
        private System.Windows.Forms.RadioButton rd_statut_demande;
        private MyRoundedTextBox tb_search_demande;
        private System.Windows.Forms.RadioButton rd_prescription;
        private System.Windows.Forms.RadioButton rd_EEG;
        private System.Windows.Forms.RadioButton rb_recu;
        private System.Windows.Forms.FlowLayoutPanel pnl_examen;
    }
}
