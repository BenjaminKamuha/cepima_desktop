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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnl_responsable = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.data_grid_med = new ModernDataGridView();
            this.med_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.med_qty = new DataGridViewNumericUpDownColumn();
            this.unite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.action = new DataGridViewControlColumn();
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
            this.pnl_title = new System.Windows.Forms.Panel();
            this.Ambilatoire = new System.Windows.Forms.RadioButton();
            this.Soins = new System.Windows.Forms.RadioButton();
            this.pnl_radio_mode = new System.Windows.Forms.Panel();
            this.lb_title = new System.Windows.Forms.Label();
            this.avt = new AvatarControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb_name = new System.Windows.Forms.Label();
            this.lb_last_name = new System.Windows.Forms.Label();
            this.lb_file_number = new System.Windows.Forms.Label();
            this.pnl_resume_diag = new System.Windows.Forms.Panel();
            this.lb_title_summary = new System.Windows.Forms.Label();
            this.customRoundedPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnl_responsable.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_med)).BeginInit();
            this.fl_stock_med.SuspendLayout();
            this.pnl_info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_no_entry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.customRoundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.pnl_title.SuspendLayout();
            this.pnl_radio_mode.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnl_resume_diag.SuspendLayout();
            this.SuspendLayout();
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customRoundedPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 10;
            this.customRoundedPanel1.BorderSize = 2;
            this.customRoundedPanel1.Controls.Add(this.pnl_title);
            this.customRoundedPanel1.Controls.Add(this.panel2);
            this.customRoundedPanel1.Controls.Add(this.panel1);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Arrow;
            this.customRoundedPanel1.Location = new System.Drawing.Point(176, 36);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Size = new System.Drawing.Size(845, 543);
            this.customRoundedPanel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pnl_radio_mode);
            this.panel2.Controls.Add(this.pnl_responsable);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(845, 245);
            this.panel2.TabIndex = 2;
            // 
            // pnl_responsable
            // 
            this.pnl_responsable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_responsable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_responsable.Controls.Add(this.pnl_resume_diag);
            this.pnl_responsable.Controls.Add(this.panel3);
            this.pnl_responsable.Location = new System.Drawing.Point(38, 47);
            this.pnl_responsable.Name = "pnl_responsable";
            this.pnl_responsable.Size = new System.Drawing.Size(751, 184);
            this.pnl_responsable.TabIndex = 1;
            this.pnl_responsable.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.data_grid_med);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 246);
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
            this.med_name,
            this.med_qty,
            this.unite,
            this.action});
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
            this.data_grid_med.Size = new System.Drawing.Size(845, 246);
            this.data_grid_med.TabIndex = 0;
            this.data_grid_med.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_grid_med_CellContentClick);
            // 
            // med_name
            // 
            this.med_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.med_name.HeaderText = "Nom produit";
            this.med_name.MinimumWidth = 50;
            this.med_name.Name = "med_name";
            this.med_name.ReadOnly = true;
            // 
            // med_qty
            // 
            this.med_qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.med_qty.HeaderText = "Quantité";
            this.med_qty.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.med_qty.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.med_qty.MinimumWidth = 50;
            this.med_qty.Name = "med_qty";
            // 
            // unite
            // 
            this.unite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.unite.HeaderText = "Unité";
            this.unite.MinimumWidth = 50;
            this.unite.Name = "unite";
            this.unite.ReadOnly = true;
            // 
            // action
            // 
            this.action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.action.HeaderText = "Action";
            this.action.MinimumWidth = 50;
            this.action.Name = "action";
            // 
            // fl_stock_med
            // 
            this.fl_stock_med.AutoScroll = true;
            this.fl_stock_med.Controls.Add(this.pnl_info);
            this.fl_stock_med.Controls.Add(this.pnl_no_entry);
            this.fl_stock_med.Location = new System.Drawing.Point(17, 80);
            this.fl_stock_med.Name = "fl_stock_med";
            this.fl_stock_med.Size = new System.Drawing.Size(157, 497);
            this.fl_stock_med.TabIndex = 8;
            this.fl_stock_med.Paint += new System.Windows.Forms.PaintEventHandler(this.fl_stock_med_Paint);
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
            this.customRoundedPanel2.Location = new System.Drawing.Point(3, 45);
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
            // pnl_title
            // 
            this.pnl_title.Controls.Add(this.lb_title);
            this.pnl_title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_title.Location = new System.Drawing.Point(0, 245);
            this.pnl_title.Name = "pnl_title";
            this.pnl_title.Size = new System.Drawing.Size(845, 52);
            this.pnl_title.TabIndex = 1;
            // 
            // Ambilatoire
            // 
            this.Ambilatoire.AutoSize = true;
            this.Ambilatoire.Dock = System.Windows.Forms.DockStyle.Left;
            this.Ambilatoire.Location = new System.Drawing.Point(0, 0);
            this.Ambilatoire.Name = "Ambilatoire";
            this.Ambilatoire.Size = new System.Drawing.Size(80, 30);
            this.Ambilatoire.TabIndex = 2;
            this.Ambilatoire.TabStop = true;
            this.Ambilatoire.Text = "Ambulatoire";
            this.Ambilatoire.UseVisualStyleBackColor = true;
            // 
            // Soins
            // 
            this.Soins.AutoSize = true;
            this.Soins.Dock = System.Windows.Forms.DockStyle.Right;
            this.Soins.Location = new System.Drawing.Point(143, 0);
            this.Soins.Name = "Soins";
            this.Soins.Size = new System.Drawing.Size(51, 30);
            this.Soins.TabIndex = 3;
            this.Soins.TabStop = true;
            this.Soins.Text = "Soins";
            this.Soins.UseVisualStyleBackColor = true;
            // 
            // pnl_radio_mode
            // 
            this.pnl_radio_mode.Controls.Add(this.Soins);
            this.pnl_radio_mode.Controls.Add(this.Ambilatoire);
            this.pnl_radio_mode.Location = new System.Drawing.Point(267, 8);
            this.pnl_radio_mode.Name = "pnl_radio_mode";
            this.pnl_radio_mode.Size = new System.Drawing.Size(194, 30);
            this.pnl_radio_mode.TabIndex = 1;
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_title.Location = new System.Drawing.Point(376, 18);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(51, 20);
            this.lb_title.TabIndex = 0;
            this.lb_title.Text = "label1";
            // 
            // avt
            // 
            this.avt.Avatar = null;
            this.avt.BackColor = System.Drawing.Color.Transparent;
            this.avt.BorderColor = System.Drawing.Color.White;
            this.avt.BorderSize = 2;
            this.avt.Location = new System.Drawing.Point(2, 3);
            this.avt.Name = "avt";
            this.avt.Size = new System.Drawing.Size(108, 113);
            this.avt.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lb_file_number);
            this.panel3.Controls.Add(this.lb_last_name);
            this.panel3.Controls.Add(this.lb_name);
            this.panel3.Controls.Add(this.avt);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(293, 182);
            this.panel3.TabIndex = 1;
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_name.Location = new System.Drawing.Point(116, 25);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(46, 17);
            this.lb_name.TabIndex = 2;
            this.lb_name.Text = "label1";
            // 
            // lb_last_name
            // 
            this.lb_last_name.AutoSize = true;
            this.lb_last_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_last_name.Location = new System.Drawing.Point(116, 50);
            this.lb_last_name.Name = "lb_last_name";
            this.lb_last_name.Size = new System.Drawing.Size(46, 17);
            this.lb_last_name.TabIndex = 3;
            this.lb_last_name.Text = "label1";
            // 
            // lb_file_number
            // 
            this.lb_file_number.AutoSize = true;
            this.lb_file_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_file_number.Location = new System.Drawing.Point(10, 136);
            this.lb_file_number.Name = "lb_file_number";
            this.lb_file_number.Size = new System.Drawing.Size(100, 17);
            this.lb_file_number.TabIndex = 4;
            this.lb_file_number.Text = "Numéro fiche: ";
            // 
            // pnl_resume_diag
            // 
            this.pnl_resume_diag.Controls.Add(this.lb_title_summary);
            this.pnl_resume_diag.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_resume_diag.Location = new System.Drawing.Point(299, 0);
            this.pnl_resume_diag.Name = "pnl_resume_diag";
            this.pnl_resume_diag.Size = new System.Drawing.Size(450, 182);
            this.pnl_resume_diag.TabIndex = 1;
            // 
            // lb_title_summary
            // 
            this.lb_title_summary.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_title_summary.AutoSize = true;
            this.lb_title_summary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_title_summary.Location = new System.Drawing.Point(146, 3);
            this.lb_title_summary.Name = "lb_title_summary";
            this.lb_title_summary.Size = new System.Drawing.Size(166, 17);
            this.lb_title_summary.TabIndex = 5;
            this.lb_title_summary.Text = "Resumé Diagnostique";
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
            this.panel2.ResumeLayout(false);
            this.pnl_responsable.ResumeLayout(false);
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
            this.pnl_title.ResumeLayout(false);
            this.pnl_title.PerformLayout();
            this.pnl_radio_mode.ResumeLayout(false);
            this.pnl_radio_mode.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnl_resume_diag.ResumeLayout(false);
            this.pnl_resume_diag.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnl_responsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn med_name;
        private DataGridViewNumericUpDownColumn med_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn unite;
        private DataGridViewControlColumn action;
        private System.Windows.Forms.Panel pnl_title;
        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.Panel pnl_radio_mode;
        private System.Windows.Forms.RadioButton Soins;
        private System.Windows.Forms.RadioButton Ambilatoire;
        private System.Windows.Forms.Panel pnl_resume_diag;
        private System.Windows.Forms.Label lb_title_summary;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lb_file_number;
        private System.Windows.Forms.Label lb_last_name;
        private System.Windows.Forms.Label lb_name;
        private AvatarControl avt;
    }
}
