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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.tb_search_med = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.fl_recent_cons = new System.Windows.Forms.FlowLayoutPanel();
            this.pnl_info = new System.Windows.Forms.Panel();
            this.no_result_found = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_nb_queu = new System.Windows.Forms.Label();
            this.pnl_radio_mode = new System.Windows.Forms.Panel();
            this.rd_type_soritie_H = new System.Windows.Forms.RadioButton();
            this.rd_type_sortie_A = new System.Windows.Forms.RadioButton();
            this.pnl_responsable = new System.Windows.Forms.Panel();
            this.bt_validate_presc = new test_arrondissement2012.PerfectRoundedButton();
            this.data_grid_med = new ModernDataGridView();
            this.id_medicament = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.med_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.med_qty = new DataGridViewNumericUpDownColumn();
            this.med_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.med_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb_file_number = new System.Windows.Forms.Label();
            this.lb_name = new System.Windows.Forms.Label();
            this.avt = new AvatarControl();
            this.fl_queue = new System.Windows.Forms.FlowLayoutPanel();
            this.customRoundedPanel3 = new CustomRoundedPanel();
            this.customRoundedPanel1.SuspendLayout();
            this.customRoundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.pnl_info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_radio_mode.SuspendLayout();
            this.pnl_responsable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_med)).BeginInit();
            this.panel3.SuspendLayout();
            this.customRoundedPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customRoundedPanel1.BackColor = System.Drawing.Color.White;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 10;
            this.customRoundedPanel1.BorderSize = 2;
            this.customRoundedPanel1.Controls.Add(this.label3);
            this.customRoundedPanel1.Controls.Add(this.lb_nb_queu);
            this.customRoundedPanel1.Controls.Add(this.pnl_radio_mode);
            this.customRoundedPanel1.Controls.Add(this.pnl_responsable);
            this.customRoundedPanel1.Controls.Add(this.fl_queue);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Arrow;
            this.customRoundedPanel1.Location = new System.Drawing.Point(22, 46);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Size = new System.Drawing.Size(774, 543);
            this.customRoundedPanel1.TabIndex = 7;
            // 
            // tb_search_med
            // 
            this.tb_search_med.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_search_med.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_search_med.Location = new System.Drawing.Point(7, 4);
            this.tb_search_med.Multiline = true;
            this.tb_search_med.Name = "tb_search_med";
            this.tb_search_med.Size = new System.Drawing.Size(153, 17);
            this.tb_search_med.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Presc Passés";
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
            this.customRoundedPanel2.Location = new System.Drawing.Point(21, 80);
            this.customRoundedPanel2.Name = "customRoundedPanel2";
            this.customRoundedPanel2.Size = new System.Drawing.Size(163, 25);
            this.customRoundedPanel2.TabIndex = 12;
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
            // fl_recent_cons
            // 
            this.fl_recent_cons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fl_recent_cons.AutoScroll = true;
            this.fl_recent_cons.Location = new System.Drawing.Point(18, 118);
            this.fl_recent_cons.Name = "fl_recent_cons";
            this.fl_recent_cons.Size = new System.Drawing.Size(157, 463);
            this.fl_recent_cons.TabIndex = 11;
            // 
            // pnl_info
            // 
            this.pnl_info.Controls.Add(this.no_result_found);
            this.pnl_info.Controls.Add(this.pictureBox1);
            this.pnl_info.Location = new System.Drawing.Point(315, 13);
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
            this.no_result_found.Size = new System.Drawing.Size(0, 17);
            this.no_result_found.TabIndex = 0;
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Numero";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Nom produit";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Unité";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Prix Unitaire";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Type sortie";
            // 
            // lb_nb_queu
            // 
            this.lb_nb_queu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_nb_queu.AutoSize = true;
            this.lb_nb_queu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nb_queu.Location = new System.Drawing.Point(214, 12);
            this.lb_nb_queu.Name = "lb_nb_queu";
            this.lb_nb_queu.Size = new System.Drawing.Size(175, 17);
            this.lb_nb_queu.TabIndex = 13;
            this.lb_nb_queu.Text = "Prescription en Attente";
            // 
            // pnl_radio_mode
            // 
            this.pnl_radio_mode.Controls.Add(this.rd_type_soritie_H);
            this.pnl_radio_mode.Controls.Add(this.rd_type_sortie_A);
            this.pnl_radio_mode.Location = new System.Drawing.Point(64, 68);
            this.pnl_radio_mode.Name = "pnl_radio_mode";
            this.pnl_radio_mode.Size = new System.Drawing.Size(136, 56);
            this.pnl_radio_mode.TabIndex = 11;
            // 
            // rd_type_soritie_H
            // 
            this.rd_type_soritie_H.AutoSize = true;
            this.rd_type_soritie_H.Dock = System.Windows.Forms.DockStyle.Right;
            this.rd_type_soritie_H.Location = new System.Drawing.Point(85, 0);
            this.rd_type_soritie_H.Name = "rd_type_soritie_H";
            this.rd_type_soritie_H.Size = new System.Drawing.Size(51, 56);
            this.rd_type_soritie_H.TabIndex = 3;
            this.rd_type_soritie_H.Text = "Soins";
            this.rd_type_soritie_H.UseVisualStyleBackColor = true;
            // 
            // rd_type_sortie_A
            // 
            this.rd_type_sortie_A.AutoSize = true;
            this.rd_type_sortie_A.Checked = true;
            this.rd_type_sortie_A.Dock = System.Windows.Forms.DockStyle.Left;
            this.rd_type_sortie_A.Location = new System.Drawing.Point(0, 0);
            this.rd_type_sortie_A.Name = "rd_type_sortie_A";
            this.rd_type_sortie_A.Size = new System.Drawing.Size(80, 56);
            this.rd_type_sortie_A.TabIndex = 2;
            this.rd_type_sortie_A.TabStop = true;
            this.rd_type_sortie_A.Text = "Ambulatoire";
            this.rd_type_sortie_A.UseVisualStyleBackColor = true;
            // 
            // pnl_responsable
            // 
            this.pnl_responsable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_responsable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_responsable.Controls.Add(this.bt_validate_presc);
            this.pnl_responsable.Controls.Add(this.data_grid_med);
            this.pnl_responsable.Controls.Add(this.panel3);
            this.pnl_responsable.Location = new System.Drawing.Point(13, 131);
            this.pnl_responsable.Name = "pnl_responsable";
            this.pnl_responsable.Size = new System.Drawing.Size(737, 366);
            this.pnl_responsable.TabIndex = 12;
            // 
            // bt_validate_presc
            // 
            this.bt_validate_presc.BackColor = System.Drawing.Color.Transparent;
            this.bt_validate_presc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_validate_presc.BorderRadius = 5;
            this.bt_validate_presc.BorderSize = 0;
            this.bt_validate_presc.ButtonText = "Valider la prescription";
            this.bt_validate_presc.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.bt_validate_presc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_validate_presc.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_validate_presc.Location = new System.Drawing.Point(182, 322);
            this.bt_validate_presc.Name = "bt_validate_presc";
            this.bt_validate_presc.Size = new System.Drawing.Size(395, 30);
            this.bt_validate_presc.TabIndex = 6;
            this.bt_validate_presc.Visible = false;
            this.bt_validate_presc.Click += new System.EventHandler(this.bt_validate_presc_Click);
            // 
            // data_grid_med
            // 
            this.data_grid_med.AllowUserToAddRows = false;
            this.data_grid_med.AllowUserToDeleteRows = false;
            this.data_grid_med.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.data_grid_med.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.data_grid_med.BackgroundColor = System.Drawing.Color.White;
            this.data_grid_med.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.data_grid_med.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.data_grid_med.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_grid_med.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.data_grid_med.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid_med.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_medicament,
            this.med_name,
            this.med_qty,
            this.med_unit,
            this.med_price});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data_grid_med.DefaultCellStyle = dataGridViewCellStyle15;
            this.data_grid_med.EnableHeadersVisualStyles = false;
            this.data_grid_med.GridColor = System.Drawing.Color.LightGray;
            this.data_grid_med.Location = new System.Drawing.Point(-1, 102);
            this.data_grid_med.Name = "data_grid_med";
            this.data_grid_med.RowHeadersVisible = false;
            this.data_grid_med.Size = new System.Drawing.Size(737, 184);
            this.data_grid_med.TabIndex = 5;
            // 
            // id_medicament
            // 
            this.id_medicament.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id_medicament.HeaderText = "Numero";
            this.id_medicament.MinimumWidth = 50;
            this.id_medicament.Name = "id_medicament";
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
            // med_unit
            // 
            this.med_unit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.med_unit.HeaderText = "Unité";
            this.med_unit.MinimumWidth = 50;
            this.med_unit.Name = "med_unit";
            this.med_unit.ReadOnly = true;
            // 
            // med_price
            // 
            this.med_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.med_price.HeaderText = "Prix Unitaire";
            this.med_price.MinimumWidth = 50;
            this.med_price.Name = "med_price";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lb_file_number);
            this.panel3.Controls.Add(this.lb_name);
            this.panel3.Controls.Add(this.avt);
            this.panel3.Location = new System.Drawing.Point(3, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(729, 79);
            this.panel3.TabIndex = 1;
            // 
            // lb_file_number
            // 
            this.lb_file_number.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_file_number.AutoSize = true;
            this.lb_file_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_file_number.Location = new System.Drawing.Point(608, 18);
            this.lb_file_number.Name = "lb_file_number";
            this.lb_file_number.Size = new System.Drawing.Size(100, 17);
            this.lb_file_number.TabIndex = 4;
            this.lb_file_number.Text = "Numéro fiche: ";
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_name.Location = new System.Drawing.Point(105, 18);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(46, 17);
            this.lb_name.TabIndex = 2;
            this.lb_name.Text = "label1";
            // 
            // avt
            // 
            this.avt.Avatar = null;
            this.avt.BackColor = System.Drawing.Color.Transparent;
            this.avt.BorderColor = System.Drawing.Color.White;
            this.avt.BorderSize = 2;
            this.avt.Location = new System.Drawing.Point(2, 3);
            this.avt.Name = "avt";
            this.avt.Size = new System.Drawing.Size(87, 76);
            this.avt.TabIndex = 1;
            // 
            // fl_queue
            // 
            this.fl_queue.AutoScroll = true;
            this.fl_queue.Location = new System.Drawing.Point(217, 68);
            this.fl_queue.Name = "fl_queue";
            this.fl_queue.Size = new System.Drawing.Size(533, 58);
            this.fl_queue.TabIndex = 14;
            // 
            // customRoundedPanel3
            // 
            this.customRoundedPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customRoundedPanel3.BackColor = System.Drawing.Color.White;
            this.customRoundedPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel3.BorderRadius = 10;
            this.customRoundedPanel3.BorderSize = 2;
            this.customRoundedPanel3.Controls.Add(this.label4);
            this.customRoundedPanel3.Controls.Add(this.customRoundedPanel2);
            this.customRoundedPanel3.Controls.Add(this.fl_recent_cons);
            this.customRoundedPanel3.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel3.HoverCursor = System.Windows.Forms.Cursors.Arrow;
            this.customRoundedPanel3.Location = new System.Drawing.Point(812, 46);
            this.customRoundedPanel3.Name = "customRoundedPanel3";
            this.customRoundedPanel3.Size = new System.Drawing.Size(197, 543);
            this.customRoundedPanel3.TabIndex = 16;
            // 
            // User_sortie_pharmacie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_info);
            this.Controls.Add(this.customRoundedPanel3);
            this.Controls.Add(this.customRoundedPanel1);
            this.Name = "User_sortie_pharmacie";
            this.Size = new System.Drawing.Size(1025, 623);
            this.Load += new System.EventHandler(this.User_sortie_pharmacie_Load);
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel1.PerformLayout();
            this.customRoundedPanel2.ResumeLayout(false);
            this.customRoundedPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.pnl_info.ResumeLayout(false);
            this.pnl_info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_radio_mode.ResumeLayout(false);
            this.pnl_radio_mode.PerformLayout();
            this.pnl_responsable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_med)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.customRoundedPanel3.ResumeLayout(false);
            this.customRoundedPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.Label label4;
        private CustomRoundedPanel customRoundedPanel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox tb_search_med;
        private System.Windows.Forms.FlowLayoutPanel fl_recent_cons;
        private System.Windows.Forms.Panel pnl_info;
        private System.Windows.Forms.Label no_result_found;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_nb_queu;
        private System.Windows.Forms.Panel pnl_radio_mode;
        private System.Windows.Forms.RadioButton rd_type_soritie_H;
        private System.Windows.Forms.RadioButton rd_type_sortie_A;
        private System.Windows.Forms.Panel pnl_responsable;
        private test_arrondissement2012.PerfectRoundedButton bt_validate_presc;
        private ModernDataGridView data_grid_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_medicament;
        private System.Windows.Forms.DataGridViewTextBoxColumn med_name;
        private DataGridViewNumericUpDownColumn med_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn med_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn med_price;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lb_file_number;
        private System.Windows.Forms.Label lb_name;
        private AvatarControl avt;
        private System.Windows.Forms.FlowLayoutPanel fl_queue;
        private CustomRoundedPanel customRoundedPanel3;
    }
}
