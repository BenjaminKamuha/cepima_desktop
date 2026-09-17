namespace Cepima.MesUserCases.Hospitalisation
{
    partial class User_DashBoard_Hospi
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
            this.bunifuRoundedPanel1 = new BunifuRoundedPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.combo_statut = new MyRoundedComboBox();
            this.txt_recherche = new MyRoundedTextBox();
            this.dgv_hospitalisation = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuRoundedPanel2 = new BunifuRoundedPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.lb_total = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.lb_libre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.customRoundedPanel4 = new CustomRoundedPanel();
            this.lb_sorties = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.customRoundedPanel3 = new CustomRoundedPanel();
            this.lb_chambre = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colPatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adresse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChambre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTarif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuRoundedPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hospitalisation)).BeginInit();
            this.bunifuRoundedPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.customRoundedPanel2.SuspendLayout();
            this.customRoundedPanel1.SuspendLayout();
            this.customRoundedPanel4.SuspendLayout();
            this.customRoundedPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.DarkBlue;
            this.bunifuRoundedPanel1.BorderRadius = 8;
            this.bunifuRoundedPanel1.BorderSize = 0;
            this.bunifuRoundedPanel1.Controls.Add(this.tableLayoutPanel2);
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(3, 160);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 10;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(1089, 384);
            this.bunifuRoundedPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 15);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.11111F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1073, 360);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.combo_statut);
            this.panel1.Controls.Add(this.txt_recherche);
            this.panel1.Controls.Add(this.dgv_hospitalisation);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 354);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(790, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Statut : ";
            // 
            // combo_statut
            // 
            this.combo_statut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_statut.ArrowColor = System.Drawing.SystemColors.ActiveCaption;
            this.combo_statut.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.combo_statut.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.combo_statut.BorderColor = System.Drawing.Color.Silver;
            this.combo_statut.BorderRadius = 6;
            this.combo_statut.BorderSize = 1;
            this.combo_statut.DropDownBackColor = System.Drawing.Color.White;
            this.combo_statut.DropDownForeColor = System.Drawing.Color.Black;
            this.combo_statut.DropDownSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.combo_statut.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.combo_statut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_statut.FocusBorderColor = System.Drawing.Color.Silver;
            this.combo_statut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.combo_statut.Location = new System.Drawing.Point(872, 12);
            this.combo_statut.Name = "combo_statut";
            this.combo_statut.SelectedItem = null;
            this.combo_statut.SelectedValue = null;
            this.combo_statut.Size = new System.Drawing.Size(192, 28);
            this.combo_statut.TabIndex = 6;
            this.combo_statut.SelectedIndexChanged += new System.EventHandler(this.combo_statut_SelectedIndexChanged);
            // 
            // txt_recherche
            // 
            this.txt_recherche.BackColor = System.Drawing.Color.White;
            this.txt_recherche.BorderColor = System.Drawing.Color.Silver;
            this.txt_recherche.BorderRadius = 6;
            this.txt_recherche.BorderSize = 1;
            this.txt_recherche.FocusBorderColor = System.Drawing.Color.Silver;
            this.txt_recherche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_recherche.ForeColor = System.Drawing.Color.Black;
            this.txt_recherche.Image = global::Cepima.Properties.Resources.search;
            this.txt_recherche.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txt_recherche.ImagePadding = 2;
            this.txt_recherche.Location = new System.Drawing.Point(420, 12);
            this.txt_recherche.MaxLength = 32767;
            this.txt_recherche.Name = "txt_recherche";
            this.txt_recherche.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txt_recherche.PlaceholderColor = System.Drawing.Color.Gray;
            this.txt_recherche.PlaceholderText = "Search personn";
            this.txt_recherche.Size = new System.Drawing.Size(257, 30);
            this.txt_recherche.TabIndex = 4;
            this.txt_recherche.TextChanged += new System.EventHandler(this.txt_recherche_TextChanged);
            // 
            // dgv_hospitalisation
            // 
            this.dgv_hospitalisation.AllowUserToAddRows = false;
            this.dgv_hospitalisation.AllowUserToDeleteRows = false;
            this.dgv_hospitalisation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_hospitalisation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_hospitalisation.BackgroundColor = System.Drawing.Color.White;
            this.dgv_hospitalisation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_hospitalisation.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_hospitalisation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_hospitalisation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_hospitalisation.ColumnHeadersHeight = 30;
            this.dgv_hospitalisation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPatient,
            this.colAge,
            this.adresse,
            this.colChambre,
            this.colTarif,
            this.colDate,
            this.colStatut});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_hospitalisation.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_hospitalisation.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_hospitalisation.EnableHeadersVisualStyles = false;
            this.dgv_hospitalisation.Location = new System.Drawing.Point(3, 48);
            this.dgv_hospitalisation.Name = "dgv_hospitalisation";
            this.dgv_hospitalisation.ReadOnly = true;
            this.dgv_hospitalisation.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_hospitalisation.RowHeadersVisible = false;
            this.dgv_hospitalisation.RowTemplate.Height = 30;
            this.dgv_hospitalisation.Size = new System.Drawing.Size(1061, 303);
            this.dgv_hospitalisation.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "HISTORIQUE D\'HOSPITALISATION";
            // 
            // bunifuRoundedPanel2
            // 
            this.bunifuRoundedPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuRoundedPanel2.BorderColor = System.Drawing.Color.DarkBlue;
            this.bunifuRoundedPanel2.BorderRadius = 6;
            this.bunifuRoundedPanel2.BorderSize = 0;
            this.bunifuRoundedPanel2.Controls.Add(this.tableLayoutPanel1);
            this.bunifuRoundedPanel2.Location = new System.Drawing.Point(3, 3);
            this.bunifuRoundedPanel2.Name = "bunifuRoundedPanel2";
            this.bunifuRoundedPanel2.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel2.ShadowDepth = 10;
            this.bunifuRoundedPanel2.Size = new System.Drawing.Size(1089, 151);
            this.bunifuRoundedPanel2.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.customRoundedPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.customRoundedPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.customRoundedPanel4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.customRoundedPanel3, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 11);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1068, 124);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // customRoundedPanel2
            // 
            this.customRoundedPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(225)))), ((int)(((byte)(218)))));
            this.customRoundedPanel2.BorderColor = System.Drawing.Color.Silver;
            this.customRoundedPanel2.BorderRadius = 10;
            this.customRoundedPanel2.BorderSize = 2;
            this.customRoundedPanel2.Controls.Add(this.lb_total);
            this.customRoundedPanel2.Controls.Add(this.label4);
            this.customRoundedPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customRoundedPanel2.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel2.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel2.Location = new System.Drawing.Point(3, 3);
            this.customRoundedPanel2.Name = "customRoundedPanel2";
            this.customRoundedPanel2.ShadowBlur = 10;
            this.customRoundedPanel2.ShadowBorderRadius = -1;
            this.customRoundedPanel2.ShadowColor = System.Drawing.Color.Black;
            this.customRoundedPanel2.ShadowEnabled = false;
            this.customRoundedPanel2.ShadowOffsetX = 0;
            this.customRoundedPanel2.ShadowOffsetY = 4;
            this.customRoundedPanel2.ShadowOpacity = 60;
            this.customRoundedPanel2.ShadowSpread = 0;
            this.customRoundedPanel2.Size = new System.Drawing.Size(261, 118);
            this.customRoundedPanel2.TabIndex = 30;
            // 
            // lb_total
            // 
            this.lb_total.AutoSize = true;
            this.lb_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_total.Location = new System.Drawing.Point(114, 59);
            this.lb_total.Name = "lb_total";
            this.lb_total.Size = new System.Drawing.Size(32, 24);
            this.lb_total.TabIndex = 0;
            this.lb_total.Text = "46";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(61, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "HOSPITALISES";
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.Silver;
            this.customRoundedPanel1.BorderRadius = 10;
            this.customRoundedPanel1.BorderSize = 2;
            this.customRoundedPanel1.Controls.Add(this.lb_libre);
            this.customRoundedPanel1.Controls.Add(this.label2);
            this.customRoundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel1.Location = new System.Drawing.Point(270, 3);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.ShadowBlur = 10;
            this.customRoundedPanel1.ShadowBorderRadius = -1;
            this.customRoundedPanel1.ShadowColor = System.Drawing.Color.Black;
            this.customRoundedPanel1.ShadowEnabled = false;
            this.customRoundedPanel1.ShadowOffsetX = 0;
            this.customRoundedPanel1.ShadowOffsetY = 4;
            this.customRoundedPanel1.ShadowOpacity = 60;
            this.customRoundedPanel1.ShadowSpread = 0;
            this.customRoundedPanel1.Size = new System.Drawing.Size(261, 118);
            this.customRoundedPanel1.TabIndex = 29;
            // 
            // lb_libre
            // 
            this.lb_libre.AutoSize = true;
            this.lb_libre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_libre.Location = new System.Drawing.Point(99, 59);
            this.lb_libre.Name = "lb_libre";
            this.lb_libre.Size = new System.Drawing.Size(32, 24);
            this.lb_libre.TabIndex = 0;
            this.lb_libre.Text = "46";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(43, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "CHAMBRE OCCUPEE";
            // 
            // customRoundedPanel4
            // 
            this.customRoundedPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(181)))), ((int)(((byte)(193)))));
            this.customRoundedPanel4.BorderColor = System.Drawing.Color.Silver;
            this.customRoundedPanel4.BorderRadius = 10;
            this.customRoundedPanel4.BorderSize = 2;
            this.customRoundedPanel4.Controls.Add(this.lb_sorties);
            this.customRoundedPanel4.Controls.Add(this.label5);
            this.customRoundedPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customRoundedPanel4.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel4.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel4.Location = new System.Drawing.Point(804, 3);
            this.customRoundedPanel4.Name = "customRoundedPanel4";
            this.customRoundedPanel4.ShadowBlur = 10;
            this.customRoundedPanel4.ShadowBorderRadius = -1;
            this.customRoundedPanel4.ShadowColor = System.Drawing.Color.Black;
            this.customRoundedPanel4.ShadowEnabled = false;
            this.customRoundedPanel4.ShadowOffsetX = 0;
            this.customRoundedPanel4.ShadowOffsetY = 4;
            this.customRoundedPanel4.ShadowOpacity = 60;
            this.customRoundedPanel4.ShadowSpread = 0;
            this.customRoundedPanel4.Size = new System.Drawing.Size(261, 118);
            this.customRoundedPanel4.TabIndex = 27;
            // 
            // lb_sorties
            // 
            this.lb_sorties.AutoSize = true;
            this.lb_sorties.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sorties.Location = new System.Drawing.Point(120, 59);
            this.lb_sorties.Name = "lb_sorties";
            this.lb_sorties.Size = new System.Drawing.Size(21, 24);
            this.lb_sorties.TabIndex = 0;
            this.lb_sorties.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(93, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "SORTIS";
            // 
            // customRoundedPanel3
            // 
            this.customRoundedPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(211)))), ((int)(((byte)(204)))));
            this.customRoundedPanel3.BorderColor = System.Drawing.Color.Silver;
            this.customRoundedPanel3.BorderRadius = 10;
            this.customRoundedPanel3.BorderSize = 2;
            this.customRoundedPanel3.Controls.Add(this.lb_chambre);
            this.customRoundedPanel3.Controls.Add(this.label3);
            this.customRoundedPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customRoundedPanel3.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel3.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel3.Location = new System.Drawing.Point(537, 3);
            this.customRoundedPanel3.Name = "customRoundedPanel3";
            this.customRoundedPanel3.ShadowBlur = 10;
            this.customRoundedPanel3.ShadowBorderRadius = -1;
            this.customRoundedPanel3.ShadowColor = System.Drawing.Color.Black;
            this.customRoundedPanel3.ShadowEnabled = false;
            this.customRoundedPanel3.ShadowOffsetX = 0;
            this.customRoundedPanel3.ShadowOffsetY = 4;
            this.customRoundedPanel3.ShadowOpacity = 60;
            this.customRoundedPanel3.ShadowSpread = 0;
            this.customRoundedPanel3.Size = new System.Drawing.Size(261, 118);
            this.customRoundedPanel3.TabIndex = 28;
            // 
            // lb_chambre
            // 
            this.lb_chambre.AutoSize = true;
            this.lb_chambre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_chambre.Location = new System.Drawing.Point(120, 59);
            this.lb_chambre.Name = "lb_chambre";
            this.lb_chambre.Size = new System.Drawing.Size(21, 24);
            this.lb_chambre.TabIndex = 0;
            this.lb_chambre.Text = "5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(76, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "CHAMBRES";
            // 
            // colPatient
            // 
            this.colPatient.HeaderText = "Patient";
            this.colPatient.Name = "colPatient";
            this.colPatient.ReadOnly = true;
            // 
            // colAge
            // 
            this.colAge.HeaderText = "Age";
            this.colAge.Name = "colAge";
            this.colAge.ReadOnly = true;
            // 
            // adresse
            // 
            this.adresse.HeaderText = "Adresse";
            this.adresse.Name = "adresse";
            this.adresse.ReadOnly = true;
            // 
            // colChambre
            // 
            this.colChambre.HeaderText = "Chambre";
            this.colChambre.Name = "colChambre";
            this.colChambre.ReadOnly = true;
            // 
            // colTarif
            // 
            this.colTarif.HeaderText = "Tarif/Jours";
            this.colTarif.Name = "colTarif";
            this.colTarif.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Admission";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colStatut
            // 
            this.colStatut.HeaderText = "Statut";
            this.colStatut.Name = "colStatut";
            this.colStatut.ReadOnly = true;
            // 
            // User_DashBoard_Hospi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Controls.Add(this.bunifuRoundedPanel2);
            this.Name = "User_DashBoard_Hospi";
            this.Size = new System.Drawing.Size(1095, 547);
            this.Load += new System.EventHandler(this.User_DashBoard_Hospi_Load);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hospitalisation)).EndInit();
            this.bunifuRoundedPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.customRoundedPanel2.ResumeLayout(false);
            this.customRoundedPanel2.PerformLayout();
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel1.PerformLayout();
            this.customRoundedPanel4.ResumeLayout(false);
            this.customRoundedPanel4.PerformLayout();
            this.customRoundedPanel3.ResumeLayout(false);
            this.customRoundedPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BunifuRoundedPanel bunifuRoundedPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomRoundedPanel customRoundedPanel2;
        private System.Windows.Forms.Label lb_total;
        private System.Windows.Forms.Label label4;
        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.Label lb_libre;
        private System.Windows.Forms.Label label2;
        private CustomRoundedPanel customRoundedPanel4;
        private System.Windows.Forms.Label lb_sorties;
        private System.Windows.Forms.Label label5;
        private CustomRoundedPanel customRoundedPanel3;
        private System.Windows.Forms.Label lb_chambre;
        private System.Windows.Forms.Label label3;
        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_hospitalisation;
        private System.Windows.Forms.Label label1;
        private MyRoundedTextBox txt_recherche;
        private System.Windows.Forms.Label label7;
        private MyRoundedComboBox combo_statut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn adresse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChambre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTarif;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatut;
    }
}
