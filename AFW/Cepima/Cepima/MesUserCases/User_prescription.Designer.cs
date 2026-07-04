namespace Cepima.MesUserCases
{
    partial class User_prescription
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rb_hospitalise = new System.Windows.Forms.RadioButton();
            this.rb_ambulatoire = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.customRoundedPanel3 = new CustomRoundedPanel();
            this.dgv_medoc = new ModernDataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedicament = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMontant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_valider_prescription = new test_arrondissement2012.PerfectRoundedButton();
            this.label3 = new System.Windows.Forms.Label();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.panel_medicament = new System.Windows.Forms.Panel();
            this.lb_not_found = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tb_search_medoc = new System.Windows.Forms.TextBox();
            this.tb_tarif = new MyRoundedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.customRoundedPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_medoc)).BeginInit();
            this.customRoundedPanel2.SuspendLayout();
            this.panel_medicament.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Location = new System.Drawing.Point(38, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 4);
            this.panel1.TabIndex = 1;
            // 
            // rb_hospitalise
            // 
            this.rb_hospitalise.AutoSize = true;
            this.rb_hospitalise.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_hospitalise.Location = new System.Drawing.Point(679, 14);
            this.rb_hospitalise.Name = "rb_hospitalise";
            this.rb_hospitalise.Size = new System.Drawing.Size(126, 19);
            this.rb_hospitalise.TabIndex = 1;
            this.rb_hospitalise.TabStop = true;
            this.rb_hospitalise.Text = "Patient hospitalisé";
            this.rb_hospitalise.UseVisualStyleBackColor = true;
            // 
            // rb_ambulatoire
            // 
            this.rb_ambulatoire.AutoSize = true;
            this.rb_ambulatoire.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_ambulatoire.Location = new System.Drawing.Point(366, 14);
            this.rb_ambulatoire.Name = "rb_ambulatoire";
            this.rb_ambulatoire.Size = new System.Drawing.Size(135, 19);
            this.rb_ambulatoire.TabIndex = 1;
            this.rb_ambulatoire.TabStop = true;
            this.rb_ambulatoire.Text = "Patient ambulatoire";
            this.rb_ambulatoire.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(53, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Préscription de médicaments";
            // 
            // customRoundedPanel3
            // 
            this.customRoundedPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel3.BorderRadius = 10;
            this.customRoundedPanel3.BorderSize = 1;
            this.customRoundedPanel3.Controls.Add(this.dgv_medoc);
            this.customRoundedPanel3.Controls.Add(this.bt_valider_prescription);
            this.customRoundedPanel3.Controls.Add(this.label3);
            this.customRoundedPanel3.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel3.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel3.Location = new System.Drawing.Point(423, 53);
            this.customRoundedPanel3.Name = "customRoundedPanel3";
            this.customRoundedPanel3.Size = new System.Drawing.Size(482, 376);
            this.customRoundedPanel3.TabIndex = 5;
            // 
            // dgv_medoc
            // 
            this.dgv_medoc.AllowUserToAddRows = false;
            this.dgv_medoc.AllowUserToDeleteRows = false;
            this.dgv_medoc.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgv_medoc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_medoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_medoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_medoc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.dgv_medoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_medoc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_medoc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_medoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_medoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_medoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colMedicament,
            this.colQuantite,
            this.colUnite,
            this.colPrix,
            this.colMontant});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_medoc.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_medoc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_medoc.EnableHeadersVisualStyles = false;
            this.dgv_medoc.GridColor = System.Drawing.Color.LightGray;
            this.dgv_medoc.Location = new System.Drawing.Point(3, 28);
            this.dgv_medoc.Name = "dgv_medoc";
            this.dgv_medoc.RowHeadersVisible = false;
            this.dgv_medoc.Size = new System.Drawing.Size(476, 305);
            this.dgv_medoc.TabIndex = 10;
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 50;
            this.colID.Name = "colID";
            // 
            // colMedicament
            // 
            this.colMedicament.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMedicament.HeaderText = "Medicament";
            this.colMedicament.MinimumWidth = 50;
            this.colMedicament.Name = "colMedicament";
            // 
            // colQuantite
            // 
            this.colQuantite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colQuantite.HeaderText = "Quantite";
            this.colQuantite.MinimumWidth = 50;
            this.colQuantite.Name = "colQuantite";
            // 
            // colUnite
            // 
            this.colUnite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUnite.HeaderText = "Unite";
            this.colUnite.MinimumWidth = 50;
            this.colUnite.Name = "colUnite";
            // 
            // colPrix
            // 
            this.colPrix.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPrix.HeaderText = "Prix";
            this.colPrix.MinimumWidth = 50;
            this.colPrix.Name = "colPrix";
            // 
            // colMontant
            // 
            this.colMontant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMontant.HeaderText = "Monant";
            this.colMontant.MinimumWidth = 50;
            this.colMontant.Name = "colMontant";
            // 
            // bt_valider_prescription
            // 
            this.bt_valider_prescription.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bt_valider_prescription.BackColor = System.Drawing.Color.Transparent;
            this.bt_valider_prescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_valider_prescription.BorderRadius = 5;
            this.bt_valider_prescription.BorderSize = 0;
            this.bt_valider_prescription.ButtonText = "Valider prescription";
            this.bt_valider_prescription.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.bt_valider_prescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_valider_prescription.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_valider_prescription.Location = new System.Drawing.Point(176, 346);
            this.bt_valider_prescription.Name = "bt_valider_prescription";
            this.bt_valider_prescription.Size = new System.Drawing.Size(129, 26);
            this.bt_valider_prescription.TabIndex = 9;
            this.bt_valider_prescription.Click += new System.EventHandler(this.bt_valider_prescription_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "MEDICAMENTS PRESCRITS";
            // 
            // customRoundedPanel2
            // 
            this.customRoundedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel2.BorderRadius = 10;
            this.customRoundedPanel2.BorderSize = 1;
            this.customRoundedPanel2.Controls.Add(this.panel_medicament);
            this.customRoundedPanel2.Controls.Add(this.pictureBox1);
            this.customRoundedPanel2.Controls.Add(this.tb_search_medoc);
            this.customRoundedPanel2.Controls.Add(this.tb_tarif);
            this.customRoundedPanel2.Controls.Add(this.label2);
            this.customRoundedPanel2.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel2.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel2.Location = new System.Drawing.Point(29, 53);
            this.customRoundedPanel2.Name = "customRoundedPanel2";
            this.customRoundedPanel2.Size = new System.Drawing.Size(371, 376);
            this.customRoundedPanel2.TabIndex = 4;
            // 
            // panel_medicament
            // 
            this.panel_medicament.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_medicament.AutoScroll = true;
            this.panel_medicament.Controls.Add(this.lb_not_found);
            this.panel_medicament.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel_medicament.Location = new System.Drawing.Point(3, 41);
            this.panel_medicament.Name = "panel_medicament";
            this.panel_medicament.Size = new System.Drawing.Size(364, 318);
            this.panel_medicament.TabIndex = 17;
            // 
            // lb_not_found
            // 
            this.lb_not_found.AutoSize = true;
            this.lb_not_found.Font = new System.Drawing.Font("Calibri Light", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_not_found.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_not_found.Location = new System.Drawing.Point(88, 96);
            this.lb_not_found.Name = "lb_not_found";
            this.lb_not_found.Size = new System.Drawing.Size(0, 14);
            this.lb_not_found.TabIndex = 0;
            this.lb_not_found.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(334, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // tb_search_medoc
            // 
            this.tb_search_medoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_search_medoc.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search_medoc.Location = new System.Drawing.Point(170, 10);
            this.tb_search_medoc.Multiline = true;
            this.tb_search_medoc.Name = "tb_search_medoc";
            this.tb_search_medoc.Size = new System.Drawing.Size(164, 22);
            this.tb_search_medoc.TabIndex = 15;
            this.tb_search_medoc.TextChanged += new System.EventHandler(this.tb_search_medoc_TextChanged_1);
            // 
            // tb_tarif
            // 
            this.tb_tarif.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_tarif.BorderRadius = 4;
            this.tb_tarif.BorderSize = 0;
            this.tb_tarif.Enabled = false;
            this.tb_tarif.FocusBorderColor = System.Drawing.Color.Orange;
            this.tb_tarif.Location = new System.Drawing.Point(167, 7);
            this.tb_tarif.Name = "tb_tarif";
            this.tb_tarif.PasswordChar = '\0';
            this.tb_tarif.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_tarif.PlaceholderText = "";
            this.tb_tarif.Size = new System.Drawing.Size(190, 28);
            this.tb_tarif.TabIndex = 16;
            this.tb_tarif.UseSystemPasswordChar = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "STOCK MEDICAMENT";
            // 
            // User_prescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customRoundedPanel3);
            this.Controls.Add(this.customRoundedPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rb_ambulatoire);
            this.Controls.Add(this.rb_hospitalise);
            this.Name = "User_prescription";
            this.Size = new System.Drawing.Size(944, 462);
            this.customRoundedPanel3.ResumeLayout(false);
            this.customRoundedPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_medoc)).EndInit();
            this.customRoundedPanel2.ResumeLayout(false);
            this.customRoundedPanel2.PerformLayout();
            this.panel_medicament.ResumeLayout(false);
            this.panel_medicament.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb_hospitalise;
        private System.Windows.Forms.RadioButton rb_ambulatoire;
        private System.Windows.Forms.Panel panel1;
        private CustomRoundedPanel customRoundedPanel3;
        private ModernDataGridView dgv_medoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedicament;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrix;
        private test_arrondissement2012.PerfectRoundedButton bt_valider_prescription;
        private System.Windows.Forms.Label label3;
        private CustomRoundedPanel customRoundedPanel2;
        private System.Windows.Forms.Panel panel_medicament;
        private System.Windows.Forms.Label lb_not_found;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tb_search_medoc;
        private MyRoundedTextBox tb_tarif;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontant;
    }
}
