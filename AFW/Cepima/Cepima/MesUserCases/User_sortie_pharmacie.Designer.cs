namespace Cepima.MesUserCases
{
    partial class User_sortie_pharmacie
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
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.data_grid_med = new ModernDataGridView();
            this.prod_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.stock_level = new DataGridViewProgressBarColumn();
            this.fl_stock_med = new System.Windows.Forms.FlowLayoutPanel();
            this.pnl_info = new System.Windows.Forms.Panel();
            this.no_result_found = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnl_no_entry = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tb_search_med = new System.Windows.Forms.TextBox();
            this.Column2 = new DataGridViewControlColumn();
            this.Column3 = new DataGridViewControlColumn();
            this.customRoundedPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_med)).BeginInit();
            this.fl_stock_med.SuspendLayout();
            this.pnl_info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_no_entry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.customRoundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customRoundedPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 10;
            this.customRoundedPanel1.BorderSize = 2;
            this.customRoundedPanel1.Controls.Add(this.panel1);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Arrow;
            this.customRoundedPanel1.Location = new System.Drawing.Point(176, 64);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Size = new System.Drawing.Size(845, 543);
            this.customRoundedPanel1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.data_grid_med);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 318);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 225);
            this.panel1.TabIndex = 1;
            // 
            // data_grid_med
            // 
            this.data_grid_med.AllowUserToAddRows = false;
            this.data_grid_med.AllowUserToDeleteRows = false;
            this.data_grid_med.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.data_grid_med.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.data_grid_med.BackgroundColor = System.Drawing.Color.White;
            this.data_grid_med.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.data_grid_med.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.data_grid_med.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_grid_med.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.data_grid_med.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid_med.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prod_name,
            this.Column1,
            this.stock_level,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data_grid_med.DefaultCellStyle = dataGridViewCellStyle3;
            this.data_grid_med.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_grid_med.EnableHeadersVisualStyles = false;
            this.data_grid_med.GridColor = System.Drawing.Color.LightGray;
            this.data_grid_med.Location = new System.Drawing.Point(0, 0);
            this.data_grid_med.Name = "data_grid_med";
            this.data_grid_med.RowHeadersVisible = false;
            this.data_grid_med.Size = new System.Drawing.Size(845, 225);
            this.data_grid_med.TabIndex = 0;
            this.data_grid_med.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_grid_med_CellContentClick);
            // 
            // prod_name
            // 
            this.prod_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prod_name.HeaderText = "Nom produit";
            this.prod_name.MinimumWidth = 50;
            this.prod_name.Name = "prod_name";
            this.prod_name.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Quantité";
            this.Column1.MinimumWidth = 50;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // stock_level
            // 
            this.stock_level.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stock_level.HeaderText = "Stock";
            this.stock_level.MinimumWidth = 50;
            this.stock_level.Name = "stock_level";
            // 
            // fl_stock_med
            // 
            this.fl_stock_med.AutoScroll = true;
            this.fl_stock_med.Controls.Add(this.pnl_info);
            this.fl_stock_med.Controls.Add(this.pnl_no_entry);
            this.fl_stock_med.Location = new System.Drawing.Point(17, 110);
            this.fl_stock_med.Name = "fl_stock_med";
            this.fl_stock_med.Size = new System.Drawing.Size(157, 497);
            this.fl_stock_med.TabIndex = 8;
            // 
            // pnl_info
            // 
            this.pnl_info.Controls.Add(this.no_result_found);
            this.pnl_info.Controls.Add(this.pictureBox1);
            this.pnl_info.Location = new System.Drawing.Point(3, 3);
            this.pnl_info.Name = "pnl_info";
            this.pnl_info.Size = new System.Drawing.Size(145, 107);
            this.pnl_info.TabIndex = 1;
            this.pnl_info.Visible = false;
            // 
            // no_result_found
            // 
            this.no_result_found.AutoSize = true;
            this.no_result_found.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no_result_found.Location = new System.Drawing.Point(12, 84);
            this.no_result_found.Name = "no_result_found";
            this.no_result_found.Size = new System.Drawing.Size(127, 17);
            this.no_result_found.TabIndex = 0;
            this.no_result_found.Text = "Produit introuvable";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.no_100px;
            this.pictureBox1.Location = new System.Drawing.Point(20, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnl_no_entry
            // 
            this.pnl_no_entry.Controls.Add(this.label2);
            this.pnl_no_entry.Controls.Add(this.pictureBox2);
            this.pnl_no_entry.Location = new System.Drawing.Point(3, 116);
            this.pnl_no_entry.Name = "pnl_no_entry";
            this.pnl_no_entry.Size = new System.Drawing.Size(145, 107);
            this.pnl_no_entry.TabIndex = 2;
            this.pnl_no_entry.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Le stok est vide";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Cepima.Properties.Resources.no_entry_100px1;
            this.pictureBox2.Location = new System.Drawing.Point(19, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(109, 44);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // customRoundedPanel2
            // 
            this.customRoundedPanel2.BackColor = System.Drawing.SystemColors.Window;
            this.customRoundedPanel2.BorderColor = System.Drawing.Color.DarkGray;
            this.customRoundedPanel2.BorderRadius = 5;
            this.customRoundedPanel2.BorderSize = 1;
            this.customRoundedPanel2.Controls.Add(this.pictureBox3);
            this.customRoundedPanel2.Controls.Add(this.tb_search_med);
            this.customRoundedPanel2.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel2.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel2.Location = new System.Drawing.Point(3, 79);
            this.customRoundedPanel2.Name = "customRoundedPanel2";
            this.customRoundedPanel2.Size = new System.Drawing.Size(190, 25);
            this.customRoundedPanel2.TabIndex = 9;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Cepima.Properties.Resources.search1;
            this.pictureBox3.Location = new System.Drawing.Point(163, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(17, 19);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // tb_search_med
            // 
            this.tb_search_med.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_search_med.Location = new System.Drawing.Point(7, 4);
            this.tb_search_med.Multiline = true;
            this.tb_search_med.Name = "tb_search_med";
            this.tb_search_med.Size = new System.Drawing.Size(153, 17);
            this.tb_search_med.TabIndex = 1;
            this.tb_search_med.TextChanged += new System.EventHandler(this.tb_search_med_TextChanged);
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Column2";
            this.Column2.MinimumWidth = 50;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Column3";
            this.Column3.MinimumWidth = 50;
            this.Column3.Name = "Column3";
            // 
            // User_sortie_pharmacie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customRoundedPanel2);
            this.Controls.Add(this.fl_stock_med);
            this.Controls.Add(this.customRoundedPanel1);
            this.Name = "User_sortie_pharmacie";
            this.Size = new System.Drawing.Size(1025, 623);
            this.Load += new System.EventHandler(this.User_sortie_pharmacie_Load);
            this.customRoundedPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_med)).EndInit();
            this.fl_stock_med.ResumeLayout(false);
            this.pnl_info.ResumeLayout(false);
            this.pnl_info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_no_entry.ResumeLayout(false);
            this.pnl_no_entry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.customRoundedPanel2.ResumeLayout(false);
            this.customRoundedPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.FlowLayoutPanel fl_stock_med;
        private System.Windows.Forms.Panel pnl_info;
        private System.Windows.Forms.Label no_result_found;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnl_no_entry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private CustomRoundedPanel customRoundedPanel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox tb_search_med;
        private ModernDataGridView data_grid_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_name;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.Panel panel1;
        private DataGridViewProgressBarColumn stock_level;
        private DataGridViewControlColumn Column2;
        private DataGridViewControlColumn Column3;
    }
}
