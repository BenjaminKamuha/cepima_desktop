namespace Cepima.MesForms.Pharmacie
{
    partial class Form_prescription
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuRoundedPanel1 = new BunifuRoundedPanel();
            this.lb_nom_patient = new System.Windows.Forms.Label();
            this.lb_prescription = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgv_presc = new ModernDataGridView();
            this.btn_delivrer = new RoundedButton();
            this.bunifuRoundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_presc)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuRoundedPanel1.BackColor = System.Drawing.Color.White;
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.DarkBlue;
            this.bunifuRoundedPanel1.BorderRadius = 8;
            this.bunifuRoundedPanel1.BorderSize = 0;
            this.bunifuRoundedPanel1.Controls.Add(this.lb_nom_patient);
            this.bunifuRoundedPanel1.Controls.Add(this.lb_prescription);
            this.bunifuRoundedPanel1.Controls.Add(this.pictureBox1);
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(12, 12);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 8;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(541, 88);
            this.bunifuRoundedPanel1.TabIndex = 48;
            // 
            // lb_nom_patient
            // 
            this.lb_nom_patient.AutoSize = true;
            this.lb_nom_patient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lb_nom_patient.Location = new System.Drawing.Point(130, 49);
            this.lb_nom_patient.Name = "lb_nom_patient";
            this.lb_nom_patient.Size = new System.Drawing.Size(36, 17);
            this.lb_nom_patient.TabIndex = 4;
            this.lb_nom_patient.Text = "Paul";
            // 
            // lb_prescription
            // 
            this.lb_prescription.AutoSize = true;
            this.lb_prescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lb_prescription.Location = new System.Drawing.Point(130, 22);
            this.lb_prescription.Name = "lb_prescription";
            this.lb_prescription.Size = new System.Drawing.Size(82, 17);
            this.lb_prescription.TabIndex = 6;
            this.lb_prescription.Text = "prescription";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.capsules_100px;
            this.pictureBox1.Location = new System.Drawing.Point(13, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dgv_presc
            // 
            this.dgv_presc.AllowUserToAddRows = false;
            this.dgv_presc.AllowUserToDeleteRows = false;
            this.dgv_presc.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgv_presc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_presc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_presc.BackgroundColor = System.Drawing.Color.White;
            this.dgv_presc.BorderRadius = 8;
            this.dgv_presc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_presc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_presc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_presc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_presc.ColumnHeadersHeight = 45;
            this.dgv_presc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_presc.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_presc.EnableHeadersVisualStyles = false;
            this.dgv_presc.GridColor = System.Drawing.Color.White;
            this.dgv_presc.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dgv_presc.HeaderForeColor = System.Drawing.Color.White;
            this.dgv_presc.HeaderHeight = 45;
            this.dgv_presc.Location = new System.Drawing.Point(12, 127);
            this.dgv_presc.MultiSelect = false;
            this.dgv_presc.Name = "dgv_presc";
            this.dgv_presc.OuterBorderColor = System.Drawing.Color.White;
            this.dgv_presc.RowHeadersVisible = false;
            this.dgv_presc.RowHeight = 40;
            this.dgv_presc.RowTemplate.Height = 40;
            this.dgv_presc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_presc.Size = new System.Drawing.Size(541, 161);
            this.dgv_presc.TabIndex = 49;
            // 
            // btn_delivrer
            // 
            this.btn_delivrer.BackColor = System.Drawing.Color.Transparent;
            this.btn_delivrer.BorderColor = System.Drawing.Color.White;
            this.btn_delivrer.BorderRadius = 10;
            this.btn_delivrer.BorderSize = 0;
            this.btn_delivrer.ButtonText = "Délivrer";
            this.btn_delivrer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delivrer.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_delivrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delivrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delivrer.ForeColor = System.Drawing.Color.White;
            this.btn_delivrer.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_delivrer.Image = global::Cepima.Properties.Resources.hand_with_a_pill_30px;
            this.btn_delivrer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_delivrer.Location = new System.Drawing.Point(197, 325);
            this.btn_delivrer.Name = "btn_delivrer";
            this.btn_delivrer.Size = new System.Drawing.Size(131, 37);
            this.btn_delivrer.TabIndex = 50;
            this.btn_delivrer.Text = "Délivrer";
            this.btn_delivrer.TextColor = System.Drawing.Color.White;
            this.btn_delivrer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_delivrer.UseVisualStyleBackColor = false;
            // 
            // Form_prescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(565, 374);
            this.Controls.Add(this.btn_delivrer);
            this.Controls.Add(this.dgv_presc);
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Name = "Form_prescription";
            this.Text = "Form_prescription";
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.bunifuRoundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_presc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.Label lb_nom_patient;
        private System.Windows.Forms.Label lb_prescription;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ModernDataGridView dgv_presc;
        private RoundedButton btn_delivrer;
    }
}