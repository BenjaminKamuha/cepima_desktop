namespace Cepima.MesUserCases
{
    partial class User_facture_all
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.cbx_filter_periode = new System.Windows.Forms.ComboBox();
            this.cbx_statut_facture = new System.Windows.Forms.ComboBox();
            this.cbx_type_facture = new System.Windows.Forms.ComboBox();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.tb_tarif = new MyRoundedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.customRoundedPanel4 = new CustomRoundedPanel();
            this.bt_actualiser = new test_arrondissement2012.PerfectRoundedButton();
            this.lb_nombre_facture = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgv_facture = new ModernDataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colPatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMontant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDetail = new System.Windows.Forms.DataGridViewImageColumn();
            this.colPayement = new System.Windows.Forms.DataGridViewImageColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.customRoundedPanel1.SuspendLayout();
            this.customRoundedPanel2.SuspendLayout();
            this.customRoundedPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_facture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.label1.Location = new System.Drawing.Point(18, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "FACTURATION";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1490, 5);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1490, 54);
            this.panel1.TabIndex = 0;
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customRoundedPanel1.BackColor = System.Drawing.Color.White;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 8;
            this.customRoundedPanel1.BorderSize = 1;
            this.customRoundedPanel1.Controls.Add(this.cbx_filter_periode);
            this.customRoundedPanel1.Controls.Add(this.cbx_statut_facture);
            this.customRoundedPanel1.Controls.Add(this.cbx_type_facture);
            this.customRoundedPanel1.Controls.Add(this.pictureBox1);
            this.customRoundedPanel1.Controls.Add(this.tb_search);
            this.customRoundedPanel1.Controls.Add(this.tb_tarif);
            this.customRoundedPanel1.Controls.Add(this.label5);
            this.customRoundedPanel1.Controls.Add(this.label4);
            this.customRoundedPanel1.Controls.Add(this.label3);
            this.customRoundedPanel1.Controls.Add(this.label2);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel1.Location = new System.Drawing.Point(4, 59);
            this.customRoundedPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Size = new System.Drawing.Size(1481, 98);
            this.customRoundedPanel1.TabIndex = 1;
            // 
            // cbx_filter_periode
            // 
            this.cbx_filter_periode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_filter_periode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_filter_periode.FormattingEnabled = true;
            this.cbx_filter_periode.Location = new System.Drawing.Point(1213, 34);
            this.cbx_filter_periode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_filter_periode.Name = "cbx_filter_periode";
            this.cbx_filter_periode.Size = new System.Drawing.Size(219, 32);
            this.cbx_filter_periode.TabIndex = 17;
            this.cbx_filter_periode.SelectedIndexChanged += new System.EventHandler(this.cbx_statut_facture_SelectedIndexChanged);
            // 
            // cbx_statut_facture
            // 
            this.cbx_statut_facture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_statut_facture.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_statut_facture.FormattingEnabled = true;
            this.cbx_statut_facture.Location = new System.Drawing.Point(837, 30);
            this.cbx_statut_facture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_statut_facture.Name = "cbx_statut_facture";
            this.cbx_statut_facture.Size = new System.Drawing.Size(216, 32);
            this.cbx_statut_facture.TabIndex = 17;
            this.cbx_statut_facture.SelectedIndexChanged += new System.EventHandler(this.cbx_statut_facture_SelectedIndexChanged);
            // 
            // cbx_type_facture
            // 
            this.cbx_type_facture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_type_facture.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_type_facture.FormattingEnabled = true;
            this.cbx_type_facture.Location = new System.Drawing.Point(491, 30);
            this.cbx_type_facture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_type_facture.Name = "cbx_type_facture";
            this.cbx_type_facture.Size = new System.Drawing.Size(192, 32);
            this.cbx_type_facture.TabIndex = 17;
            this.cbx_type_facture.SelectedIndexChanged += new System.EventHandler(this.cbx_type_facture_SelectedIndexChanged);
            // 
            // tb_search
            // 
            this.tb_search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_search.Font = new System.Drawing.Font("Calibri", 12F);
            this.tb_search.Location = new System.Drawing.Point(34, 37);
            this.tb_search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_search.Multiline = true;
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(259, 27);
            this.tb_search.TabIndex = 15;
            this.tb_search.TextChanged += new System.EventHandler(this.tb_search_TextChanged);
            // 
            // tb_tarif
            // 
            this.tb_tarif.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_tarif.BorderRadius = 4;
            this.tb_tarif.BorderSize = 0;
            this.tb_tarif.Enabled = false;
            this.tb_tarif.FocusBorderColor = System.Drawing.Color.Orange;
            this.tb_tarif.Location = new System.Drawing.Point(29, 34);
            this.tb_tarif.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_tarif.Name = "tb_tarif";
            this.tb_tarif.PasswordChar = '\0';
            this.tb_tarif.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_tarif.PlaceholderText = "";
            this.tb_tarif.Size = new System.Drawing.Size(292, 34);
            this.tb_tarif.TabIndex = 16;
            this.tb_tarif.UseSystemPasswordChar = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F);
            this.label5.Location = new System.Drawing.Point(1113, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Période : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F);
            this.label4.Location = new System.Drawing.Point(749, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Statut";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F);
            this.label3.Location = new System.Drawing.Point(344, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Type de facture";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F);
            this.label2.Location = new System.Drawing.Point(43, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Rechercher ";
            // 
            // customRoundedPanel2
            // 
            this.customRoundedPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customRoundedPanel2.BackColor = System.Drawing.Color.White;
            this.customRoundedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel2.BorderRadius = 8;
            this.customRoundedPanel2.BorderSize = 1;
            this.customRoundedPanel2.Controls.Add(this.customRoundedPanel4);
            this.customRoundedPanel2.Controls.Add(this.dgv_facture);
            this.customRoundedPanel2.Controls.Add(this.label7);
            this.customRoundedPanel2.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel2.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel2.Location = new System.Drawing.Point(4, 165);
            this.customRoundedPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.customRoundedPanel2.Name = "customRoundedPanel2";
            this.customRoundedPanel2.Size = new System.Drawing.Size(1481, 505);
            this.customRoundedPanel2.TabIndex = 2;
            // 
            // customRoundedPanel4
            // 
            this.customRoundedPanel4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel4.BorderRadius = 4;
            this.customRoundedPanel4.BorderSize = 1;
            this.customRoundedPanel4.Controls.Add(this.bt_actualiser);
            this.customRoundedPanel4.Controls.Add(this.lb_nombre_facture);
            this.customRoundedPanel4.Controls.Add(this.label8);
            this.customRoundedPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.customRoundedPanel4.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel4.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel4.Location = new System.Drawing.Point(0, 462);
            this.customRoundedPanel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.customRoundedPanel4.Name = "customRoundedPanel4";
            this.customRoundedPanel4.Size = new System.Drawing.Size(1481, 43);
            this.customRoundedPanel4.TabIndex = 2;
            // 
            // bt_actualiser
            // 
            this.bt_actualiser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_actualiser.BackColor = System.Drawing.Color.Transparent;
            this.bt_actualiser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_actualiser.BorderRadius = 5;
            this.bt_actualiser.BorderSize = 0;
            this.bt_actualiser.ButtonText = "Actualiser";
            this.bt_actualiser.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.bt_actualiser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_actualiser.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_actualiser.Location = new System.Drawing.Point(1352, 9);
            this.bt_actualiser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_actualiser.Name = "bt_actualiser";
            this.bt_actualiser.Size = new System.Drawing.Size(114, 30);
            this.bt_actualiser.TabIndex = 11;
            this.bt_actualiser.Click += new System.EventHandler(this.bt_actualiser_Click);
            // 
            // lb_nombre_facture
            // 
            this.lb_nombre_facture.AutoSize = true;
            this.lb_nombre_facture.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lb_nombre_facture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.lb_nombre_facture.Location = new System.Drawing.Point(91, 11);
            this.lb_nombre_facture.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_nombre_facture.Name = "lb_nombre_facture";
            this.lb_nombre_facture.Size = new System.Drawing.Size(20, 24);
            this.lb_nombre_facture.TabIndex = 0;
            this.lb_nombre_facture.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(25, 11);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "Total : ";
            // 
            // dgv_facture
            // 
            this.dgv_facture.AllowUserToAddRows = false;
            this.dgv_facture.AllowUserToDeleteRows = false;
            this.dgv_facture.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgv_facture.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_facture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_facture.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_facture.BackgroundColor = System.Drawing.Color.White;
            this.dgv_facture.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_facture.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_facture.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_facture.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_facture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_facture.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPatient,
            this.colType,
            this.colDate,
            this.colMontant,
            this.colStatut,
            this.colPrint,
            this.colDelete,
            this.colDetail,
            this.colPayement,
            this.colID});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_facture.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_facture.EnableHeadersVisualStyles = false;
            this.dgv_facture.GridColor = System.Drawing.Color.LightGray;
            this.dgv_facture.Location = new System.Drawing.Point(4, 37);
            this.dgv_facture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_facture.Name = "dgv_facture";
            this.dgv_facture.RowHeadersVisible = false;
            this.dgv_facture.Size = new System.Drawing.Size(1474, 420);
            this.dgv_facture.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 10);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Liste des factures";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Cepima.Properties.Resources.print_20px;
            this.dataGridViewImageColumn1.MinimumWidth = 50;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::Cepima.Properties.Resources.trash_red1;
            this.dataGridViewImageColumn2.MinimumWidth = 50;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewImageColumn3.HeaderText = "";
            this.dataGridViewImageColumn3.Image = global::Cepima.Properties.Resources.more_details_20px;
            this.dataGridViewImageColumn3.MinimumWidth = 50;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            // 
            // dataGridViewImageColumn4
            // 
            this.dataGridViewImageColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewImageColumn4.HeaderText = "";
            this.dataGridViewImageColumn4.Image = global::Cepima.Properties.Resources.Us_Dollar_Circled_20px;
            this.dataGridViewImageColumn4.MinimumWidth = 50;
            this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(291, 36);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // colPatient
            // 
            this.colPatient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPatient.HeaderText = "Patient";
            this.colPatient.MinimumWidth = 50;
            this.colPatient.Name = "colPatient";
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colType.HeaderText = "Type ";
            this.colType.MinimumWidth = 50;
            this.colType.Name = "colType";
            // 
            // colDate
            // 
            this.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDate.HeaderText = "Date facture";
            this.colDate.MinimumWidth = 50;
            this.colDate.Name = "colDate";
            // 
            // colMontant
            // 
            this.colMontant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMontant.HeaderText = "Montant ";
            this.colMontant.MinimumWidth = 50;
            this.colMontant.Name = "colMontant";
            // 
            // colStatut
            // 
            this.colStatut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStatut.HeaderText = "Statut";
            this.colStatut.MinimumWidth = 50;
            this.colStatut.Name = "colStatut";
            // 
            // colPrint
            // 
            this.colPrint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPrint.HeaderText = "Imprimer";
            this.colPrint.Image = global::Cepima.Properties.Resources.print_20px;
            this.colPrint.MinimumWidth = 50;
            this.colPrint.Name = "colPrint";
            this.colPrint.ToolTipText = "Imprimer la facture";
            // 
            // colDelete
            // 
            this.colDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDelete.HeaderText = "Supprimer";
            this.colDelete.Image = global::Cepima.Properties.Resources.trash_red1;
            this.colDelete.MinimumWidth = 50;
            this.colDelete.Name = "colDelete";
            this.colDelete.ToolTipText = "Supprimer la facture";
            // 
            // colDetail
            // 
            this.colDetail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDetail.HeaderText = "Détail facture";
            this.colDetail.Image = global::Cepima.Properties.Resources.more_details_20px;
            this.colDetail.MinimumWidth = 50;
            this.colDetail.Name = "colDetail";
            this.colDetail.ToolTipText = "Afficher les détails";
            // 
            // colPayement
            // 
            this.colPayement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPayement.HeaderText = "Payer";
            this.colPayement.Image = global::Cepima.Properties.Resources.Us_Dollar_Circled_20px;
            this.colPayement.MinimumWidth = 50;
            this.colPayement.Name = "colPayement";
            this.colPayement.ToolTipText = "Effectuer un paiement";
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colID.HeaderText = "";
            this.colID.MinimumWidth = 50;
            this.colID.Name = "colID";
            this.colID.Visible = false;
            // 
            // User_facture_all
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.customRoundedPanel2);
            this.Controls.Add(this.customRoundedPanel1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "User_facture_all";
            this.Size = new System.Drawing.Size(1490, 674);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel1.PerformLayout();
            this.customRoundedPanel2.ResumeLayout(false);
            this.customRoundedPanel2.PerformLayout();
            this.customRoundedPanel4.ResumeLayout(false);
            this.customRoundedPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_facture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tb_search;
        private MyRoundedTextBox tb_tarif;
        private System.Windows.Forms.ComboBox cbx_statut_facture;
        private System.Windows.Forms.ComboBox cbx_type_facture;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private CustomRoundedPanel customRoundedPanel2;
        private CustomRoundedPanel customRoundedPanel4;
        private System.Windows.Forms.Label lb_nombre_facture;
        private System.Windows.Forms.Label label8;
        private ModernDataGridView dgv_facture;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private test_arrondissement2012.PerfectRoundedButton bt_actualiser;
        private System.Windows.Forms.ComboBox cbx_filter_periode;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatut;
        private System.Windows.Forms.DataGridViewImageColumn colPrint;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
        private System.Windows.Forms.DataGridViewImageColumn colDetail;
        private System.Windows.Forms.DataGridViewImageColumn colPayement;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;

    }
}
