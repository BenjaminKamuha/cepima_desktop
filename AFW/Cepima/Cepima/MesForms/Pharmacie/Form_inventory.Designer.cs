namespace Cepima.MesForms.Pharmacie
{
    partial class Form_inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_inventory));
            this.bunifuRoundedPanel1 = new BunifuRoundedPanel();
            this.btnEnregistrer = new RoundedButton();
            this.dgvInventaire = new ModernDataGridView();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.txtObservation = new MyRoundedTextBox();
            this.lb_respo_value = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuRoundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventaire)).BeginInit();
            this.pnl_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.DarkBlue;
            this.bunifuRoundedPanel1.BorderRadius = 8;
            this.bunifuRoundedPanel1.BorderSize = 0;
            this.bunifuRoundedPanel1.Controls.Add(this.btnEnregistrer);
            this.bunifuRoundedPanel1.Controls.Add(this.dgvInventaire);
            this.bunifuRoundedPanel1.Controls.Add(this.pnl_header);
            this.bunifuRoundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 10;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(1197, 558);
            this.bunifuRoundedPanel1.TabIndex = 1;
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnregistrer.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEnregistrer.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnEnregistrer.BorderRadius = 8;
            this.btnEnregistrer.BorderSize = 0;
            this.btnEnregistrer.ButtonText = "Enregistrer";
            this.btnEnregistrer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnregistrer.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btnEnregistrer.FlatAppearance.BorderSize = 0;
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.ForeColor = System.Drawing.Color.White;
            this.btnEnregistrer.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btnEnregistrer.Image = global::Cepima.Properties.Resources.save_30px;
            this.btnEnregistrer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnregistrer.Location = new System.Drawing.Point(519, 497);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(158, 40);
            this.btnEnregistrer.TabIndex = 4;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.TextColor = System.Drawing.Color.White;
            this.btnEnregistrer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            // 
            // dgvInventaire
            // 
            this.dgvInventaire.AllowUserToAddRows = false;
            this.dgvInventaire.AllowUserToDeleteRows = false;
            this.dgvInventaire.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvInventaire.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInventaire.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInventaire.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventaire.BorderRadius = 1;
            this.dgvInventaire.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventaire.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvInventaire.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventaire.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInventaire.ColumnHeadersHeight = 20;
            this.dgvInventaire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInventaire.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInventaire.EnableHeadersVisualStyles = false;
            this.dgvInventaire.GridColor = System.Drawing.Color.White;
            this.dgvInventaire.HeaderBackColor = System.Drawing.Color.SteelBlue;
            this.dgvInventaire.HeaderForeColor = System.Drawing.Color.White;
            this.dgvInventaire.HeaderHeight = 45;
            this.dgvInventaire.ColumnHeadersHeight = 45;
            this.dgvInventaire.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            this.dgvInventaire.RowHeight = 42;
            this.dgvInventaire.RowTemplate.Height = 42;

            this.dgvInventaire.BorderRadius = 8;
            this.dgvInventaire.OuterBorderSize = 1;
            this.dgvInventaire.OuterBorderColor =
                System.Drawing.Color.LightGray;

            this.dgvInventaire.HeaderBackColor =
                System.Drawing.Color.DodgerBlue;

            this.dgvInventaire.HeaderForeColor =
                System.Drawing.Color.White;
            this.dgvInventaire.Location = new System.Drawing.Point(47, 129);
            this.dgvInventaire.MultiSelect = false;
            this.dgvInventaire.Name = "dgvInventaire";
            this.dgvInventaire.OuterBorderColor = System.Drawing.Color.White;
            this.dgvInventaire.RowHeadersVisible = false;
            this.dgvInventaire.RowHeight = 40;
            this.dgvInventaire.RowTemplate.Height = 40;
            this.dgvInventaire.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventaire.Size = new System.Drawing.Size(1102, 353);
            this.dgvInventaire.TabIndex = 0;
            // 
            // pnl_header
            // 
            this.pnl_header.Controls.Add(this.txtObservation);
            this.pnl_header.Controls.Add(this.lb_respo_value);
            this.pnl_header.Controls.Add(this.label3);
            this.pnl_header.Controls.Add(this.label2);
            this.pnl_header.Controls.Add(this.label1);
            this.pnl_header.Controls.Add(this.pictureBox1);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(1197, 106);
            this.pnl_header.TabIndex = 0;
            // 
            // txtObservation
            // 
            this.txtObservation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservation.BackColor = System.Drawing.Color.White;
            this.txtObservation.BorderColor = System.Drawing.Color.LightGray;
            this.txtObservation.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.txtObservation.ForeColor = System.Drawing.Color.Black;
            this.txtObservation.Image = null;
            this.txtObservation.Location = new System.Drawing.Point(781, 48);
            this.txtObservation.MaxLength = 32767;
            this.txtObservation.Multiline = true;
            this.txtObservation.Name = "txtObservation";
            this.txtObservation.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtObservation.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtObservation.PlaceholderText = "Enter text...";
            this.txtObservation.Size = new System.Drawing.Size(368, 55);
            this.txtObservation.TabIndex = 14;
            // 
            // lb_respo_value
            // 
            this.lb_respo_value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_respo_value.AutoSize = true;
            this.lb_respo_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_respo_value.Location = new System.Drawing.Point(778, 17);
            this.lb_respo_value.Name = "lb_respo_value";
            this.lb_respo_value.Size = new System.Drawing.Size(46, 17);
            this.lb_respo_value.TabIndex = 13;
            this.lb_respo_value.Text = "label4";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(649, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Observation :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(649, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Responsable :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "INVENTAIRE";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.adjust_30px;
            this.pictureBox1.Location = new System.Drawing.Point(3, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Form_inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1197, 558);
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_inventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventaire";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_inventory_Load);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventaire)).EndInit();
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label lb_respo_value;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ModernDataGridView dgvInventaire;
        private MyRoundedTextBox txtObservation;
        private RoundedButton btnEnregistrer;
    }
}