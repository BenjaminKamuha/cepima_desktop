namespace Cepima.MesUserCases.Pharmacie
{
    partial class UC_prescription
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
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.fl_prescription = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_add_med = new RoundedButton();
            this.tb_search = new MyRoundedTextBox();
            this.rd_ambulatoire = new System.Windows.Forms.RadioButton();
            this.rd_delivree = new System.Windows.Forms.RadioButton();
            this.rd_en_attente = new System.Windows.Forms.RadioButton();
            this.rd_hospitalisation = new System.Windows.Forms.RadioButton();
            this.rd_tout = new System.Windows.Forms.RadioButton();
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
            this.customRoundedPanel1.BorderRadius = 5;
            this.customRoundedPanel1.BorderSize = 2;
            this.customRoundedPanel1.Controls.Add(this.fl_prescription);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(11, 70);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 14);
            this.customRoundedPanel1.ShadowBlur = 10;
            this.customRoundedPanel1.ShadowBorderRadius = -1;
            this.customRoundedPanel1.ShadowColor = System.Drawing.Color.Black;
            this.customRoundedPanel1.ShadowEnabled = true;
            this.customRoundedPanel1.ShadowOffsetX = 0;
            this.customRoundedPanel1.ShadowOffsetY = 4;
            this.customRoundedPanel1.ShadowOpacity = 60;
            this.customRoundedPanel1.ShadowSpread = 0;
            this.customRoundedPanel1.Size = new System.Drawing.Size(1008, 443);
            this.customRoundedPanel1.TabIndex = 9;
            // 
            // fl_prescription
            // 
            this.fl_prescription.AutoScroll = true;
            this.fl_prescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fl_prescription.Location = new System.Drawing.Point(10, 10);
            this.fl_prescription.Name = "fl_prescription";
            this.fl_prescription.Size = new System.Drawing.Size(988, 419);
            this.fl_prescription.TabIndex = 3;
            // 
            // btn_add_med
            // 
            this.btn_add_med.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_add_med.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_add_med.BorderRadius = 8;
            this.btn_add_med.BorderSize = 0;
            this.btn_add_med.ButtonText = "Ajouter";
            this.btn_add_med.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add_med.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_add_med.FlatAppearance.BorderSize = 0;
            this.btn_add_med.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_med.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_med.ForeColor = System.Drawing.Color.White;
            this.btn_add_med.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_add_med.Image = global::Cepima.Properties.Resources.add_25px1;
            this.btn_add_med.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_add_med.Location = new System.Drawing.Point(895, 13);
            this.btn_add_med.Name = "btn_add_med";
            this.btn_add_med.Size = new System.Drawing.Size(120, 34);
            this.btn_add_med.TabIndex = 8;
            this.btn_add_med.Text = "Ajouter";
            this.btn_add_med.TextColor = System.Drawing.Color.White;
            this.btn_add_med.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_add_med.UseVisualStyleBackColor = false;
            // 
            // tb_search
            // 
            this.tb_search.BackColor = System.Drawing.Color.White;
            this.tb_search.BorderColor = System.Drawing.Color.Silver;
            this.tb_search.BorderRadius = 8;
            this.tb_search.BorderSize = 1;
            this.tb_search.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_search.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search.ForeColor = System.Drawing.Color.Black;
            this.tb_search.Image = global::Cepima.Properties.Resources.search_25px;
            this.tb_search.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_search.ImagePadding = 4;
            this.tb_search.Location = new System.Drawing.Point(11, 13);
            this.tb_search.MaxLength = 32767;
            this.tb_search.Name = "tb_search";
            this.tb_search.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_search.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_search.PlaceholderText = "Rechercher";
            this.tb_search.Size = new System.Drawing.Size(273, 34);
            this.tb_search.TabIndex = 7;
            // 
            // rd_ambulatoire
            // 
            this.rd_ambulatoire.AutoSize = true;
            this.rd_ambulatoire.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_ambulatoire.Location = new System.Drawing.Point(618, 27);
            this.rd_ambulatoire.Name = "rd_ambulatoire";
            this.rd_ambulatoire.Size = new System.Drawing.Size(101, 21);
            this.rd_ambulatoire.TabIndex = 44;
            this.rd_ambulatoire.TabStop = true;
            this.rd_ambulatoire.Text = "Ambulatoire";
            this.rd_ambulatoire.UseVisualStyleBackColor = true;
            // 
            // rd_delivree
            // 
            this.rd_delivree.AutoSize = true;
            this.rd_delivree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_delivree.Location = new System.Drawing.Point(510, 27);
            this.rd_delivree.Name = "rd_delivree";
            this.rd_delivree.Size = new System.Drawing.Size(95, 21);
            this.rd_delivree.TabIndex = 45;
            this.rd_delivree.TabStop = true;
            this.rd_delivree.Text = "Delivrée(s)";
            this.rd_delivree.UseVisualStyleBackColor = true;
            // 
            // rd_en_attente
            // 
            this.rd_en_attente.AutoSize = true;
            this.rd_en_attente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_en_attente.Location = new System.Drawing.Point(389, 27);
            this.rd_en_attente.Name = "rd_en_attente";
            this.rd_en_attente.Size = new System.Drawing.Size(108, 21);
            this.rd_en_attente.TabIndex = 46;
            this.rd_en_attente.TabStop = true;
            this.rd_en_attente.Text = "En attente(s)";
            this.rd_en_attente.UseVisualStyleBackColor = true;
            // 
            // rd_hospitalisation
            // 
            this.rd_hospitalisation.AutoSize = true;
            this.rd_hospitalisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_hospitalisation.Location = new System.Drawing.Point(732, 27);
            this.rd_hospitalisation.Name = "rd_hospitalisation";
            this.rd_hospitalisation.Size = new System.Drawing.Size(118, 21);
            this.rd_hospitalisation.TabIndex = 44;
            this.rd_hospitalisation.TabStop = true;
            this.rd_hospitalisation.Text = "Hospitalisation";
            this.rd_hospitalisation.UseVisualStyleBackColor = true;
            // 
            // rd_tout
            // 
            this.rd_tout.AutoSize = true;
            this.rd_tout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_tout.Location = new System.Drawing.Point(318, 27);
            this.rd_tout.Name = "rd_tout";
            this.rd_tout.Size = new System.Drawing.Size(58, 21);
            this.rd_tout.TabIndex = 46;
            this.rd_tout.TabStop = true;
            this.rd_tout.Text = "Tous";
            this.rd_tout.UseVisualStyleBackColor = true;
            // 
            // UC_prescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.rd_hospitalisation);
            this.Controls.Add(this.rd_ambulatoire);
            this.Controls.Add(this.rd_delivree);
            this.Controls.Add(this.rd_tout);
            this.Controls.Add(this.rd_en_attente);
            this.Controls.Add(this.customRoundedPanel1);
            this.Controls.Add(this.btn_add_med);
            this.Controls.Add(this.tb_search);
            this.Name = "UC_prescription";
            this.Size = new System.Drawing.Size(1031, 526);
            this.customRoundedPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.FlowLayoutPanel fl_prescription;
        private RoundedButton btn_add_med;
        private MyRoundedTextBox tb_search;
        private System.Windows.Forms.RadioButton rd_ambulatoire;
        private System.Windows.Forms.RadioButton rd_delivree;
        private System.Windows.Forms.RadioButton rd_en_attente;
        private System.Windows.Forms.RadioButton rd_hospitalisation;
        private System.Windows.Forms.RadioButton rd_tout;
    }
}
