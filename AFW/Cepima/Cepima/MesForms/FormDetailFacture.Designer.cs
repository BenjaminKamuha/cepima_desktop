namespace Cepima.MesForms
{
    partial class FormDetailFacture
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetailFacture));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_id = new System.Windows.Forms.Label();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_patient = new System.Windows.Forms.Label();
            this.lb_statut = new System.Windows.Forms.Label();
            this.lb_date_facture = new System.Windows.Forms.Label();
            this.lb_medecin = new System.Windows.Forms.Label();
            this.lb_type = new System.Windows.Forms.Label();
            this.lb_montant_paye = new System.Windows.Forms.Label();
            this.lb_reste = new System.Windows.Forms.Label();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.dgv_detail_facture = new ModernDataGridView();
            this.colDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.customRoundedPanel1.SuspendLayout();
            this.customRoundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detail_facture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lb_id);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 61);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(93, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Détail de la facture N° : ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.more_details_40px;
            this.pictureBox1.Location = new System.Drawing.Point(5, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lb_id
            // 
            this.lb_id.AutoSize = true;
            this.lb_id.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lb_id.ForeColor = System.Drawing.Color.White;
            this.lb_id.Location = new System.Drawing.Point(333, 20);
            this.lb_id.Name = "lb_id";
            this.lb_id.Size = new System.Drawing.Size(42, 29);
            this.lb_id.TabIndex = 0;
            this.lb_id.Text = "N° ";
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.LightGray;
            this.customRoundedPanel1.BorderRadius = 10;
            this.customRoundedPanel1.BorderSize = 1;
            this.customRoundedPanel1.Controls.Add(this.lb_reste);
            this.customRoundedPanel1.Controls.Add(this.lb_montant_paye);
            this.customRoundedPanel1.Controls.Add(this.label7);
            this.customRoundedPanel1.Controls.Add(this.lb_type);
            this.customRoundedPanel1.Controls.Add(this.label6);
            this.customRoundedPanel1.Controls.Add(this.lb_medecin);
            this.customRoundedPanel1.Controls.Add(this.label5);
            this.customRoundedPanel1.Controls.Add(this.lb_date_facture);
            this.customRoundedPanel1.Controls.Add(this.label4);
            this.customRoundedPanel1.Controls.Add(this.lb_statut);
            this.customRoundedPanel1.Controls.Add(this.label3);
            this.customRoundedPanel1.Controls.Add(this.lb_patient);
            this.customRoundedPanel1.Controls.Add(this.label2);
            this.customRoundedPanel1.Controls.Add(this.label);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(12, 82);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Size = new System.Drawing.Size(435, 416);
            this.customRoundedPanel1.TabIndex = 1;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Calibri", 12F);
            this.label.Location = new System.Drawing.Point(19, 34);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(84, 24);
            this.label.TabIndex = 0;
            this.label.Text = "Patient : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F);
            this.label2.Location = new System.Drawing.Point(19, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Statut  : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F);
            this.label3.Location = new System.Drawing.Point(19, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Date facture  : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F);
            this.label4.Location = new System.Drawing.Point(19, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Montant total  : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F);
            this.label5.Location = new System.Drawing.Point(19, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Type facture : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F);
            this.label6.Location = new System.Drawing.Point(19, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "Montant payé  : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F);
            this.label7.Location = new System.Drawing.Point(19, 358);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Montant restant  : ";
            // 
            // lb_patient
            // 
            this.lb_patient.AutoSize = true;
            this.lb_patient.Font = new System.Drawing.Font("Calibri", 12F);
            this.lb_patient.Location = new System.Drawing.Point(194, 34);
            this.lb_patient.Name = "lb_patient";
            this.lb_patient.Size = new System.Drawing.Size(123, 24);
            this.lb_patient.TabIndex = 0;
            this.lb_patient.Text = "Nom complèt";
            // 
            // lb_statut
            // 
            this.lb_statut.AutoSize = true;
            this.lb_statut.Font = new System.Drawing.Font("Calibri", 12F);
            this.lb_statut.Location = new System.Drawing.Point(194, 88);
            this.lb_statut.Name = "lb_statut";
            this.lb_statut.Size = new System.Drawing.Size(81, 24);
            this.lb_statut.TabIndex = 0;
            this.lb_statut.Text = "Statut  : ";
            // 
            // lb_date_facture
            // 
            this.lb_date_facture.AutoSize = true;
            this.lb_date_facture.Font = new System.Drawing.Font("Calibri", 12F);
            this.lb_date_facture.Location = new System.Drawing.Point(194, 142);
            this.lb_date_facture.Name = "lb_date_facture";
            this.lb_date_facture.Size = new System.Drawing.Size(133, 24);
            this.lb_date_facture.TabIndex = 0;
            this.lb_date_facture.Text = "Date facture  : ";
            // 
            // lb_medecin
            // 
            this.lb_medecin.AutoSize = true;
            this.lb_medecin.Font = new System.Drawing.Font("Calibri", 12F);
            this.lb_medecin.Location = new System.Drawing.Point(194, 196);
            this.lb_medecin.Name = "lb_medecin";
            this.lb_medecin.Size = new System.Drawing.Size(149, 24);
            this.lb_medecin.TabIndex = 0;
            this.lb_medecin.Text = "Montant total  : ";
            // 
            // lb_type
            // 
            this.lb_type.AutoSize = true;
            this.lb_type.Font = new System.Drawing.Font("Calibri", 12F);
            this.lb_type.Location = new System.Drawing.Point(194, 250);
            this.lb_type.Name = "lb_type";
            this.lb_type.Size = new System.Drawing.Size(128, 24);
            this.lb_type.TabIndex = 0;
            this.lb_type.Text = "Type facture : ";
            // 
            // lb_montant_paye
            // 
            this.lb_montant_paye.AutoSize = true;
            this.lb_montant_paye.Font = new System.Drawing.Font("Calibri", 12F);
            this.lb_montant_paye.Location = new System.Drawing.Point(194, 304);
            this.lb_montant_paye.Name = "lb_montant_paye";
            this.lb_montant_paye.Size = new System.Drawing.Size(149, 24);
            this.lb_montant_paye.TabIndex = 0;
            this.lb_montant_paye.Text = "Montant payé  : ";
            // 
            // lb_reste
            // 
            this.lb_reste.AutoSize = true;
            this.lb_reste.Font = new System.Drawing.Font("Calibri", 12F);
            this.lb_reste.Location = new System.Drawing.Point(194, 358);
            this.lb_reste.Name = "lb_reste";
            this.lb_reste.Size = new System.Drawing.Size(169, 24);
            this.lb_reste.TabIndex = 0;
            this.lb_reste.Text = "Montant restant  : ";
            // 
            // customRoundedPanel2
            // 
            this.customRoundedPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customRoundedPanel2.BorderColor = System.Drawing.Color.LightGray;
            this.customRoundedPanel2.BorderRadius = 10;
            this.customRoundedPanel2.BorderSize = 1;
            this.customRoundedPanel2.Controls.Add(this.dgv_detail_facture);
            this.customRoundedPanel2.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel2.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel2.Location = new System.Drawing.Point(453, 82);
            this.customRoundedPanel2.Name = "customRoundedPanel2";
            this.customRoundedPanel2.Size = new System.Drawing.Size(736, 416);
            this.customRoundedPanel2.TabIndex = 2;
            // 
            // dgv_detail_facture
            // 
            this.dgv_detail_facture.AllowUserToAddRows = false;
            this.dgv_detail_facture.AllowUserToDeleteRows = false;
            this.dgv_detail_facture.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgv_detail_facture.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_detail_facture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_detail_facture.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_detail_facture.BackgroundColor = System.Drawing.Color.White;
            this.dgv_detail_facture.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_detail_facture.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_detail_facture.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_detail_facture.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_detail_facture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_detail_facture.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDesc,
            this.colQuantite,
            this.colPrix,
            this.colTotal});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_detail_facture.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_detail_facture.EnableHeadersVisualStyles = false;
            this.dgv_detail_facture.GridColor = System.Drawing.Color.LightGray;
            this.dgv_detail_facture.Location = new System.Drawing.Point(3, 15);
            this.dgv_detail_facture.Name = "dgv_detail_facture";
            this.dgv_detail_facture.RowHeadersVisible = false;
            this.dgv_detail_facture.RowTemplate.Height = 24;
            this.dgv_detail_facture.Size = new System.Drawing.Size(730, 398);
            this.dgv_detail_facture.TabIndex = 0;
            // 
            // colDesc
            // 
            this.colDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDesc.HeaderText = "Description";
            this.colDesc.MinimumWidth = 50;
            this.colDesc.Name = "colDesc";
            // 
            // colQuantite
            // 
            this.colQuantite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colQuantite.HeaderText = "Quantité";
            this.colQuantite.MinimumWidth = 50;
            this.colQuantite.Name = "colQuantite";
            // 
            // colPrix
            // 
            this.colPrix.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPrix.HeaderText = "Prix";
            this.colPrix.MinimumWidth = 50;
            this.colPrix.Name = "colPrix";
            // 
            // colTotal
            // 
            this.colTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTotal.HeaderText = "Total";
            this.colTotal.MinimumWidth = 50;
            this.colTotal.Name = "colTotal";
            // 
            // FormDetailFacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1200, 517);
            this.Controls.Add(this.customRoundedPanel2);
            this.Controls.Add(this.customRoundedPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDetailFacture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel1.PerformLayout();
            this.customRoundedPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detail_facture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_id;
        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_reste;
        private System.Windows.Forms.Label lb_montant_paye;
        private System.Windows.Forms.Label lb_type;
        private System.Windows.Forms.Label lb_medecin;
        private System.Windows.Forms.Label lb_date_facture;
        private System.Windows.Forms.Label lb_statut;
        private System.Windows.Forms.Label lb_patient;
        private CustomRoundedPanel customRoundedPanel2;
        private ModernDataGridView dgv_detail_facture;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrix;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    }
}