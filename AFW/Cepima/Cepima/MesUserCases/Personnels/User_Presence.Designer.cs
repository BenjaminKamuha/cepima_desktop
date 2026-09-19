namespace Cepima.MesUserCases.Personnels
{
    partial class User_Presence
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
            this.txt_recherche = new MyRoundedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbx_periode = new MyRoundedComboBox();
            this.cbx_statut = new MyRoundedComboBox();
            this.dgv_presences = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuRoundedPanel2 = new BunifuRoundedPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_nb_present = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_nb_absent = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.customRoundedPanel4 = new CustomRoundedPanel();
            this.lbl_nb_total = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.customRoundedPanel3 = new CustomRoundedPanel();
            this.lbl_mois_salaire = new System.Windows.Forms.Label();
            this.lbl_nb_retard = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colPersonnel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFonction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeureEntree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeureSortie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHorairePrevu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRetard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIDhoraire = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIDPersonnel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuRoundedPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_presences)).BeginInit();
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
            this.panel1.Controls.Add(this.txt_recherche);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cbx_periode);
            this.panel1.Controls.Add(this.cbx_statut);
            this.panel1.Controls.Add(this.dgv_presences);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 354);
            this.panel1.TabIndex = 0;
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
            this.txt_recherche.Location = new System.Drawing.Point(234, 12);
            this.txt_recherche.MaxLength = 32767;
            this.txt_recherche.Name = "txt_recherche";
            this.txt_recherche.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txt_recherche.PlaceholderColor = System.Drawing.Color.Gray;
            this.txt_recherche.PlaceholderText = "Search personn";
            this.txt_recherche.Size = new System.Drawing.Size(257, 30);
            this.txt_recherche.TabIndex = 8;
            this.txt_recherche.TextChanged += new System.EventHandler(this.txt_recherche_TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(807, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Période : ";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(529, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "Statut : ";
            // 
            // cbx_periode
            // 
            this.cbx_periode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_periode.ArrowColor = System.Drawing.SystemColors.ActiveCaption;
            this.cbx_periode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_periode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_periode.BorderColor = System.Drawing.Color.Silver;
            this.cbx_periode.BorderRadius = 6;
            this.cbx_periode.BorderSize = 1;
            this.cbx_periode.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_periode.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_periode.DropDownSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.cbx_periode.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_periode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_periode.FocusBorderColor = System.Drawing.Color.Silver;
            this.cbx_periode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbx_periode.Location = new System.Drawing.Point(887, 12);
            this.cbx_periode.Name = "cbx_periode";
            this.cbx_periode.SelectedItem = null;
            this.cbx_periode.SelectedValue = null;
            this.cbx_periode.Size = new System.Drawing.Size(153, 28);
            this.cbx_periode.TabIndex = 6;
            this.cbx_periode.SelectedIndexChanged += new System.EventHandler(this.cbx_periode_SelectedIndexChanged);
            // 
            // cbx_statut
            // 
            this.cbx_statut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_statut.ArrowColor = System.Drawing.SystemColors.ActiveCaption;
            this.cbx_statut.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_statut.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_statut.BorderColor = System.Drawing.Color.Silver;
            this.cbx_statut.BorderRadius = 6;
            this.cbx_statut.BorderSize = 1;
            this.cbx_statut.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_statut.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_statut.DropDownSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.cbx_statut.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_statut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_statut.FocusBorderColor = System.Drawing.Color.Silver;
            this.cbx_statut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbx_statut.Location = new System.Drawing.Point(621, 13);
            this.cbx_statut.Name = "cbx_statut";
            this.cbx_statut.SelectedItem = null;
            this.cbx_statut.SelectedValue = null;
            this.cbx_statut.Size = new System.Drawing.Size(153, 28);
            this.cbx_statut.TabIndex = 7;
            this.cbx_statut.SelectedIndexChanged += new System.EventHandler(this.cbx_statut_SelectedIndexChanged);
            // 
            // dgv_presences
            // 
            this.dgv_presences.AllowUserToAddRows = false;
            this.dgv_presences.AllowUserToDeleteRows = false;
            this.dgv_presences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_presences.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_presences.BackgroundColor = System.Drawing.Color.White;
            this.dgv_presences.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_presences.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_presences.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_presences.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_presences.ColumnHeadersHeight = 30;
            this.dgv_presences.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPersonnel,
            this.colFonction,
            this.colDate,
            this.colHeureEntree,
            this.colHeureSortie,
            this.colHorairePrevu,
            this.colRetard,
            this.colStatut,
            this.colIDhoraire,
            this.colIDPersonnel});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_presences.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_presences.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_presences.EnableHeadersVisualStyles = false;
            this.dgv_presences.Location = new System.Drawing.Point(3, 48);
            this.dgv_presences.Name = "dgv_presences";
            this.dgv_presences.ReadOnly = true;
            this.dgv_presences.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_presences.RowHeadersVisible = false;
            this.dgv_presences.RowTemplate.Height = 30;
            this.dgv_presences.Size = new System.Drawing.Size(1061, 303);
            this.dgv_presences.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "LISTE DE PRESENCES";
            // 
            // bunifuRoundedPanel2
            // 
            this.bunifuRoundedPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuRoundedPanel2.BorderColor = System.Drawing.Color.DarkBlue;
            this.bunifuRoundedPanel2.BorderRadius = 6;
            this.bunifuRoundedPanel2.BorderSize = 0;
            this.bunifuRoundedPanel2.Controls.Add(this.tableLayoutPanel1);
            this.bunifuRoundedPanel2.Location = new System.Drawing.Point(0, 3);
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
            this.customRoundedPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(178)))));
            this.customRoundedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(178)))));
            this.customRoundedPanel2.BorderRadius = 10;
            this.customRoundedPanel2.BorderSize = 2;
            this.customRoundedPanel2.Controls.Add(this.label7);
            this.customRoundedPanel2.Controls.Add(this.lbl_nb_present);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.label7.Location = new System.Drawing.Point(80, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Aujourd\'hui";
            // 
            // lbl_nb_present
            // 
            this.lbl_nb_present.AutoSize = true;
            this.lbl_nb_present.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nb_present.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lbl_nb_present.Location = new System.Drawing.Point(108, 49);
            this.lbl_nb_present.Name = "lbl_nb_present";
            this.lbl_nb_present.Size = new System.Drawing.Size(32, 24);
            this.lbl_nb_present.TabIndex = 0;
            this.lbl_nb_present.Text = "46";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(79, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "PRESENTS";
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
            this.customRoundedPanel1.BorderRadius = 10;
            this.customRoundedPanel1.BorderSize = 2;
            this.customRoundedPanel1.Controls.Add(this.label6);
            this.customRoundedPanel1.Controls.Add(this.lbl_nb_absent);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label6.Location = new System.Drawing.Point(88, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Aujourd\'hui";
            // 
            // lbl_nb_absent
            // 
            this.lbl_nb_absent.AutoSize = true;
            this.lbl_nb_absent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nb_absent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lbl_nb_absent.Location = new System.Drawing.Point(111, 49);
            this.lbl_nb_absent.Name = "lbl_nb_absent";
            this.lbl_nb_absent.Size = new System.Drawing.Size(32, 24);
            this.lbl_nb_absent.TabIndex = 0;
            this.lbl_nb_absent.Text = "46";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label2.Location = new System.Drawing.Point(85, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "ABSENTS";
            // 
            // customRoundedPanel4
            // 
            this.customRoundedPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.customRoundedPanel4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.customRoundedPanel4.BorderRadius = 10;
            this.customRoundedPanel4.BorderSize = 2;
            this.customRoundedPanel4.Controls.Add(this.lbl_nb_total);
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
            // lbl_nb_total
            // 
            this.lbl_nb_total.AutoSize = true;
            this.lbl_nb_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nb_total.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(90)))), ((int)(((byte)(150)))));
            this.lbl_nb_total.Location = new System.Drawing.Point(120, 49);
            this.lbl_nb_total.Name = "lbl_nb_total";
            this.lbl_nb_total.Size = new System.Drawing.Size(21, 24);
            this.lbl_nb_total.TabIndex = 0;
            this.lbl_nb_total.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(90)))), ((int)(((byte)(150)))));
            this.label5.Location = new System.Drawing.Point(42, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "TOTAL PERSONNEL";
            // 
            // customRoundedPanel3
            // 
            this.customRoundedPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(178)))));
            this.customRoundedPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(178)))));
            this.customRoundedPanel3.BorderRadius = 10;
            this.customRoundedPanel3.BorderSize = 2;
            this.customRoundedPanel3.Controls.Add(this.lbl_mois_salaire);
            this.customRoundedPanel3.Controls.Add(this.lbl_nb_retard);
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
            // lbl_mois_salaire
            // 
            this.lbl_mois_salaire.AutoSize = true;
            this.lbl_mois_salaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mois_salaire.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lbl_mois_salaire.Location = new System.Drawing.Point(88, 83);
            this.lbl_mois_salaire.Name = "lbl_mois_salaire";
            this.lbl_mois_salaire.Size = new System.Drawing.Size(85, 16);
            this.lbl_mois_salaire.TabIndex = 0;
            this.lbl_mois_salaire.Text = "Aujourd\'hui";
            // 
            // lbl_nb_retard
            // 
            this.lbl_nb_retard.AutoSize = true;
            this.lbl_nb_retard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nb_retard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lbl_nb_retard.Location = new System.Drawing.Point(117, 49);
            this.lbl_nb_retard.Name = "lbl_nb_retard";
            this.lbl_nb_retard.Size = new System.Drawing.Size(21, 24);
            this.lbl_nb_retard.TabIndex = 0;
            this.lbl_nb_retard.Text = "5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.label3.Location = new System.Drawing.Point(87, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "RETARD";
            // 
            // colPersonnel
            // 
            this.colPersonnel.HeaderText = "Personnel";
            this.colPersonnel.Name = "colPersonnel";
            this.colPersonnel.ReadOnly = true;
            // 
            // colFonction
            // 
            this.colFonction.HeaderText = "Fonction";
            this.colFonction.Name = "colFonction";
            this.colFonction.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colHeureEntree
            // 
            this.colHeureEntree.HeaderText = "Entrée";
            this.colHeureEntree.Name = "colHeureEntree";
            this.colHeureEntree.ReadOnly = true;
            // 
            // colHeureSortie
            // 
            this.colHeureSortie.HeaderText = "Sortie ";
            this.colHeureSortie.Name = "colHeureSortie";
            this.colHeureSortie.ReadOnly = true;
            // 
            // colHorairePrevu
            // 
            this.colHorairePrevu.HeaderText = "Entré Normale";
            this.colHorairePrevu.Name = "colHorairePrevu";
            this.colHorairePrevu.ReadOnly = true;
            // 
            // colRetard
            // 
            this.colRetard.HeaderText = "Retard";
            this.colRetard.Name = "colRetard";
            this.colRetard.ReadOnly = true;
            // 
            // colStatut
            // 
            this.colStatut.HeaderText = "Statut";
            this.colStatut.Name = "colStatut";
            this.colStatut.ReadOnly = true;
            // 
            // colIDhoraire
            // 
            this.colIDhoraire.HeaderText = "";
            this.colIDhoraire.Name = "colIDhoraire";
            this.colIDhoraire.ReadOnly = true;
            this.colIDhoraire.Visible = false;
            // 
            // colIDPersonnel
            // 
            this.colIDPersonnel.HeaderText = "";
            this.colIDPersonnel.Name = "colIDPersonnel";
            this.colIDPersonnel.ReadOnly = true;
            this.colIDPersonnel.Visible = false;
            // 
            // User_Presence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Controls.Add(this.bunifuRoundedPanel2);
            this.Name = "User_Presence";
            this.Size = new System.Drawing.Size(1095, 547);
            this.Load += new System.EventHandler(this.User_Presence_Load);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_presences)).EndInit();
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
        private System.Windows.Forms.Label lbl_nb_present;
        private System.Windows.Forms.Label label4;
        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.Label lbl_nb_absent;
        private System.Windows.Forms.Label label2;
        private CustomRoundedPanel customRoundedPanel4;
        private System.Windows.Forms.Label lbl_mois_salaire;
        private System.Windows.Forms.Label lbl_nb_total;
        private System.Windows.Forms.Label label5;
        private CustomRoundedPanel customRoundedPanel3;
        private System.Windows.Forms.Label lbl_nb_retard;
        private System.Windows.Forms.Label label3;
        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_presences;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private MyRoundedTextBox txt_recherche;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private MyRoundedComboBox cbx_periode;
        private MyRoundedComboBox cbx_statut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersonnel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFonction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeureEntree;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeureSortie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHorairePrevu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRetard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIDhoraire;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIDPersonnel;
    }
}
