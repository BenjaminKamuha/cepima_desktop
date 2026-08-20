namespace Cepima.MesUserCases
{
    partial class User_Stock_hospitalisation
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_afficher = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tb_tarif = new MyRoundedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_stock = new System.Windows.Forms.Label();
            this.lb_appro = new System.Windows.Forms.Label();
            this.lb_history = new System.Windows.Forms.Label();
            this.pan_move = new System.Windows.Forms.Panel();
            this.bt_appri = new test_arrondissement2012.PerfectRoundedButton();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.pan_test = new CustomRoundedPanel();
            this.customRoundedPanel3 = new CustomRoundedPanel();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.dgv_medoc = new ModernDataGridView();
            this.colMedoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colForme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeuil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEtat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.customRoundedPanel1.SuspendLayout();
            this.customRoundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_medoc)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbx_afficher);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.tb_tarif);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 122);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 120);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1100, 2);
            this.panel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(317, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Catégorie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rechercher Médicament";
            // 
            // cbx_afficher
            // 
            this.cbx_afficher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_afficher.Font = new System.Drawing.Font("Calibri", 10F);
            this.cbx_afficher.FormattingEnabled = true;
            this.cbx_afficher.Location = new System.Drawing.Point(315, 84);
            this.cbx_afficher.Name = "cbx_afficher";
            this.cbx_afficher.Size = new System.Drawing.Size(186, 23);
            this.cbx_afficher.TabIndex = 21;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(196, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(21, 83);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(172, 22);
            this.textBox1.TabIndex = 17;
            // 
            // tb_tarif
            // 
            this.tb_tarif.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_tarif.BorderRadius = 4;
            this.tb_tarif.BorderSize = 0;
            this.tb_tarif.Enabled = false;
            this.tb_tarif.FocusBorderColor = System.Drawing.Color.Orange;
            this.tb_tarif.Location = new System.Drawing.Point(19, 80);
            this.tb_tarif.Name = "tb_tarif";
            this.tb_tarif.PasswordChar = '\0';
            this.tb_tarif.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_tarif.PlaceholderText = "";
            this.tb_tarif.Size = new System.Drawing.Size(199, 28);
            this.tb_tarif.TabIndex = 18;
            this.tb_tarif.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "GESTION DU STOCK DE SOINS";
            // 
            // lb_stock
            // 
            this.lb_stock.AutoSize = true;
            this.lb_stock.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_stock.Location = new System.Drawing.Point(38, 141);
            this.lb_stock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_stock.Name = "lb_stock";
            this.lb_stock.Size = new System.Drawing.Size(95, 18);
            this.lb_stock.TabIndex = 2;
            this.lb_stock.Text = "Stock de soins";
            this.lb_stock.Click += new System.EventHandler(this.lb_stock_Click);
            // 
            // lb_appro
            // 
            this.lb_appro.AutoSize = true;
            this.lb_appro.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_appro.Location = new System.Drawing.Point(183, 141);
            this.lb_appro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_appro.Name = "lb_appro";
            this.lb_appro.Size = new System.Drawing.Size(132, 18);
            this.lb_appro.TabIndex = 2;
            this.lb_appro.Text = "Approvisionnement";
            this.lb_appro.Click += new System.EventHandler(this.lb_appro_Click);
            // 
            // lb_history
            // 
            this.lb_history.AutoSize = true;
            this.lb_history.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_history.Location = new System.Drawing.Point(373, 141);
            this.lb_history.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_history.Name = "lb_history";
            this.lb_history.Size = new System.Drawing.Size(168, 18);
            this.lb_history.TabIndex = 2;
            this.lb_history.Text = "Historique de distribution";
            this.lb_history.Click += new System.EventHandler(this.lb_history_Click);
            // 
            // pan_move
            // 
            this.pan_move.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.pan_move.Location = new System.Drawing.Point(19, 161);
            this.pan_move.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pan_move.Name = "pan_move";
            this.pan_move.Size = new System.Drawing.Size(134, 4);
            this.pan_move.TabIndex = 0;
            // 
            // bt_appri
            // 
            this.bt_appri.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bt_appri.BackColor = System.Drawing.Color.Transparent;
            this.bt_appri.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_appri.BorderRadius = 5;
            this.bt_appri.BorderSize = 0;
            this.bt_appri.ButtonText = "Nouvelle apprivisionnement";
            this.bt_appri.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.bt_appri.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_appri.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_appri.Location = new System.Drawing.Point(916, 132);
            this.bt_appri.Name = "bt_appri";
            this.bt_appri.Size = new System.Drawing.Size(167, 32);
            this.bt_appri.TabIndex = 16;
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 10;
            this.customRoundedPanel1.BorderSize = 1;
            this.customRoundedPanel1.Controls.Add(this.pan_test);
            this.customRoundedPanel1.Controls.Add(this.customRoundedPanel3);
            this.customRoundedPanel1.Controls.Add(this.customRoundedPanel2);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(15, 169);
            this.customRoundedPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Size = new System.Drawing.Size(1083, 375);
            this.customRoundedPanel1.TabIndex = 1;
            // 
            // pan_test
            // 
            this.pan_test.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pan_test.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pan_test.BorderRadius = 10;
            this.pan_test.BorderSize = 1;
            this.pan_test.HoverBackColor = System.Drawing.Color.Empty;
            this.pan_test.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.pan_test.Location = new System.Drawing.Point(479, 238);
            this.pan_test.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pan_test.Name = "pan_test";
            this.pan_test.Size = new System.Drawing.Size(601, 137);
            this.pan_test.TabIndex = 1;
            // 
            // customRoundedPanel3
            // 
            this.customRoundedPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customRoundedPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel3.BorderRadius = 10;
            this.customRoundedPanel3.BorderSize = 1;
            this.customRoundedPanel3.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel3.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel3.Location = new System.Drawing.Point(6, 238);
            this.customRoundedPanel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customRoundedPanel3.Name = "customRoundedPanel3";
            this.customRoundedPanel3.Size = new System.Drawing.Size(469, 135);
            this.customRoundedPanel3.TabIndex = 1;
            // 
            // customRoundedPanel2
            // 
            this.customRoundedPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customRoundedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel2.BorderRadius = 10;
            this.customRoundedPanel2.BorderSize = 1;
            this.customRoundedPanel2.Controls.Add(this.dgv_medoc);
            this.customRoundedPanel2.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel2.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel2.Location = new System.Drawing.Point(6, 7);
            this.customRoundedPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customRoundedPanel2.Name = "customRoundedPanel2";
            this.customRoundedPanel2.Size = new System.Drawing.Size(1074, 227);
            this.customRoundedPanel2.TabIndex = 0;
            // 
            // dgv_medoc
            // 
            this.dgv_medoc.AllowUserToAddRows = false;
            this.dgv_medoc.AllowUserToDeleteRows = false;
            this.dgv_medoc.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgv_medoc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_medoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_medoc.BackgroundColor = System.Drawing.Color.White;
            this.dgv_medoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_medoc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_medoc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_medoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_medoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_medoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMedoc,
            this.colCat,
            this.colForme,
            this.colDosage,
            this.colStock,
            this.colSeuil,
            this.colEtat});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_medoc.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_medoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_medoc.EnableHeadersVisualStyles = false;
            this.dgv_medoc.GridColor = System.Drawing.Color.LightGray;
            this.dgv_medoc.Location = new System.Drawing.Point(0, 0);
            this.dgv_medoc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv_medoc.Name = "dgv_medoc";
            this.dgv_medoc.RowHeadersVisible = false;
            this.dgv_medoc.RowTemplate.Height = 28;
            this.dgv_medoc.Size = new System.Drawing.Size(1074, 227);
            this.dgv_medoc.TabIndex = 0;
            // 
            // colMedoc
            // 
            this.colMedoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMedoc.HeaderText = "Médicament";
            this.colMedoc.MinimumWidth = 50;
            this.colMedoc.Name = "colMedoc";
            // 
            // colCat
            // 
            this.colCat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCat.HeaderText = "Catégorie";
            this.colCat.MinimumWidth = 50;
            this.colCat.Name = "colCat";
            // 
            // colForme
            // 
            this.colForme.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colForme.HeaderText = "Forme";
            this.colForme.MinimumWidth = 50;
            this.colForme.Name = "colForme";
            // 
            // colDosage
            // 
            this.colDosage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDosage.HeaderText = "Dosage";
            this.colDosage.MinimumWidth = 50;
            this.colDosage.Name = "colDosage";
            // 
            // colStock
            // 
            this.colStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStock.HeaderText = "Stock Disponible";
            this.colStock.MinimumWidth = 50;
            this.colStock.Name = "colStock";
            // 
            // colSeuil
            // 
            this.colSeuil.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSeuil.HeaderText = "Seuil Alerte";
            this.colSeuil.MinimumWidth = 50;
            this.colSeuil.Name = "colSeuil";
            // 
            // colEtat
            // 
            this.colEtat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEtat.HeaderText = "Etat";
            this.colEtat.MinimumWidth = 50;
            this.colEtat.Name = "colEtat";
            // 
            // User_Stock_hospitalisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.bt_appri);
            this.Controls.Add(this.pan_move);
            this.Controls.Add(this.lb_history);
            this.Controls.Add(this.lb_appro);
            this.Controls.Add(this.lb_stock);
            this.Controls.Add(this.customRoundedPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "User_Stock_hospitalisation";
            this.Size = new System.Drawing.Size(1100, 547);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_medoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private MyRoundedTextBox tb_tarif;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbx_afficher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.Label lb_stock;
        private System.Windows.Forms.Label lb_appro;
        private System.Windows.Forms.Label lb_history;
        private System.Windows.Forms.Panel pan_move;
        private CustomRoundedPanel customRoundedPanel2;
        private ModernDataGridView dgv_medoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colForme;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDosage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeuil;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEtat;
        private CustomRoundedPanel pan_test;
        private CustomRoundedPanel customRoundedPanel3;
        private test_arrondissement2012.PerfectRoundedButton bt_appri;

    }
}
