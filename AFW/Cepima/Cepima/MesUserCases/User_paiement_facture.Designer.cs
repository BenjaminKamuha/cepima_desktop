namespace Cepima.MesUserCases
{
    partial class User_paiement_facture
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.dt_final = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dt_debut = new System.Windows.Forms.DateTimePicker();
            this.cbx_type_facture = new System.Windows.Forms.ComboBox();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.tb_tarif = new MyRoundedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.dgv_paiement = new ModernDataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel_appercu_recu = new CustomRoundedPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.modernDataGridView1 = new ModernDataGridView();
            this.colRecu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFacture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMontant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReste = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.bt_cacher = new System.Windows.Forms.Button();
            this.bt_print = new System.Windows.Forms.Button();
            this.colApercu = new System.Windows.Forms.DataGridViewImageColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.customRoundedPanel1.SuspendLayout();
            this.customRoundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_paiement)).BeginInit();
            this.panel_appercu_recu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modernDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 50);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1100, 4);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "HISTORIQUE DES PAIEMENTS / RECUS";
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customRoundedPanel1.BackColor = System.Drawing.Color.White;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 6;
            this.customRoundedPanel1.BorderSize = 1;
            this.customRoundedPanel1.Controls.Add(this.dt_final);
            this.customRoundedPanel1.Controls.Add(this.label4);
            this.customRoundedPanel1.Controls.Add(this.dt_debut);
            this.customRoundedPanel1.Controls.Add(this.cbx_type_facture);
            this.customRoundedPanel1.Controls.Add(this.pictureBox1);
            this.customRoundedPanel1.Controls.Add(this.tb_search);
            this.customRoundedPanel1.Controls.Add(this.tb_tarif);
            this.customRoundedPanel1.Controls.Add(this.label6);
            this.customRoundedPanel1.Controls.Add(this.label5);
            this.customRoundedPanel1.Controls.Add(this.label3);
            this.customRoundedPanel1.Controls.Add(this.label2);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel1.Location = new System.Drawing.Point(3, 56);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Size = new System.Drawing.Size(1094, 86);
            this.customRoundedPanel1.TabIndex = 2;
            // 
            // dt_final
            // 
            this.dt_final.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_final.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_final.Location = new System.Drawing.Point(857, 55);
            this.dt_final.Name = "dt_final";
            this.dt_final.Size = new System.Drawing.Size(148, 22);
            this.dt_final.TabIndex = 18;
            this.dt_final.ValueChanged += new System.EventHandler(this.dt_final_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.label4.Location = new System.Drawing.Point(8, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "FILTRE DE RECHERCHE";
            // 
            // dt_debut
            // 
            this.dt_debut.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_debut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_debut.Location = new System.Drawing.Point(604, 55);
            this.dt_debut.Name = "dt_debut";
            this.dt_debut.Size = new System.Drawing.Size(148, 22);
            this.dt_debut.TabIndex = 18;
            this.dt_debut.ValueChanged += new System.EventHandler(this.dt_debut_ValueChanged);
            // 
            // cbx_type_facture
            // 
            this.cbx_type_facture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_type_facture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_type_facture.FormattingEnabled = true;
            this.cbx_type_facture.Location = new System.Drawing.Point(339, 54);
            this.cbx_type_facture.Name = "cbx_type_facture";
            this.cbx_type_facture.Size = new System.Drawing.Size(145, 23);
            this.cbx_type_facture.TabIndex = 17;
            this.cbx_type_facture.SelectedIndexChanged += new System.EventHandler(this.cbx_type_facture_SelectedIndexChanged);
            // 
            // tb_search
            // 
            this.tb_search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_search.Location = new System.Drawing.Point(25, 52);
            this.tb_search.Multiline = true;
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(194, 22);
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
            this.tb_tarif.Location = new System.Drawing.Point(22, 49);
            this.tb_tarif.Name = "tb_tarif";
            this.tb_tarif.PasswordChar = '\0';
            this.tb_tarif.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_tarif.PlaceholderText = "";
            this.tb_tarif.Size = new System.Drawing.Size(219, 28);
            this.tb_tarif.TabIndex = 16;
            this.tb_tarif.UseSystemPasswordChar = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(854, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Date fin : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(603, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Date début : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(346, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Type de paiement";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Rechercher (Patient) ";
            // 
            // customRoundedPanel2
            // 
            this.customRoundedPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customRoundedPanel2.BackColor = System.Drawing.Color.White;
            this.customRoundedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel2.BorderRadius = 6;
            this.customRoundedPanel2.BorderSize = 1;
            this.customRoundedPanel2.Controls.Add(this.panel_appercu_recu);
            this.customRoundedPanel2.Controls.Add(this.dgv_paiement);
            this.customRoundedPanel2.Controls.Add(this.panel5);
            this.customRoundedPanel2.Controls.Add(this.label8);
            this.customRoundedPanel2.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel2.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel2.Location = new System.Drawing.Point(3, 148);
            this.customRoundedPanel2.Name = "customRoundedPanel2";
            this.customRoundedPanel2.Size = new System.Drawing.Size(1094, 396);
            this.customRoundedPanel2.TabIndex = 3;
            // 
            // dgv_paiement
            // 
            this.dgv_paiement.AllowUserToAddRows = false;
            this.dgv_paiement.AllowUserToDeleteRows = false;
            this.dgv_paiement.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgv_paiement.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_paiement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_paiement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_paiement.BackgroundColor = System.Drawing.Color.White;
            this.dgv_paiement.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_paiement.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_paiement.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_paiement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_paiement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_paiement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRecu,
            this.colDate,
            this.colFacture,
            this.colPatient,
            this.colTotal,
            this.colMontant,
            this.colReste,
            this.colType,
            this.colApercu});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_paiement.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_paiement.EnableHeadersVisualStyles = false;
            this.dgv_paiement.GridColor = System.Drawing.Color.LightGray;
            this.dgv_paiement.Location = new System.Drawing.Point(3, 36);
            this.dgv_paiement.Name = "dgv_paiement";
            this.dgv_paiement.RowHeadersVisible = false;
            this.dgv_paiement.Size = new System.Drawing.Size(1088, 357);
            this.dgv_paiement.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel5.Location = new System.Drawing.Point(3, 26);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 4);
            this.panel5.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.label8.Location = new System.Drawing.Point(9, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "HISTORIQUE DES PAIEMENTS";
            // 
            // panel_appercu_recu
            // 
            this.panel_appercu_recu.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panel_appercu_recu.BorderColor = System.Drawing.Color.Silver;
            this.panel_appercu_recu.BorderRadius = 8;
            this.panel_appercu_recu.BorderSize = 1;
            this.panel_appercu_recu.Controls.Add(this.bt_cacher);
            this.panel_appercu_recu.Controls.Add(this.bt_print);
            this.panel_appercu_recu.Controls.Add(this.modernDataGridView1);
            this.panel_appercu_recu.Controls.Add(this.label7);
            this.panel_appercu_recu.HoverBackColor = System.Drawing.Color.Empty;
            this.panel_appercu_recu.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.panel_appercu_recu.Location = new System.Drawing.Point(700, 64);
            this.panel_appercu_recu.Name = "panel_appercu_recu";
            this.panel_appercu_recu.Size = new System.Drawing.Size(391, 329);
            this.panel_appercu_recu.TabIndex = 4;
            this.panel_appercu_recu.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(17, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Apercu reçu";
            // 
            // modernDataGridView1
            // 
            this.modernDataGridView1.AllowUserToAddRows = false;
            this.modernDataGridView1.AllowUserToDeleteRows = false;
            this.modernDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.modernDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.modernDataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.modernDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.modernDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.modernDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.modernDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.modernDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.modernDataGridView1.DefaultCellStyle = dataGridViewCellStyle9;
            this.modernDataGridView1.EnableHeadersVisualStyles = false;
            this.modernDataGridView1.GridColor = System.Drawing.Color.LightGray;
            this.modernDataGridView1.Location = new System.Drawing.Point(3, 42);
            this.modernDataGridView1.Name = "modernDataGridView1";
            this.modernDataGridView1.RowHeadersVisible = false;
            this.modernDataGridView1.Size = new System.Drawing.Size(385, 284);
            this.modernDataGridView1.TabIndex = 1;
            // 
            // colRecu
            // 
            this.colRecu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRecu.HeaderText = "N° Reçu";
            this.colRecu.MinimumWidth = 50;
            this.colRecu.Name = "colRecu";
            // 
            // colDate
            // 
            this.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDate.HeaderText = "Date";
            this.colDate.MinimumWidth = 50;
            this.colDate.Name = "colDate";
            // 
            // colFacture
            // 
            this.colFacture.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFacture.HeaderText = "N° facture";
            this.colFacture.MinimumWidth = 50;
            this.colFacture.Name = "colFacture";
            this.colFacture.Visible = false;
            // 
            // colPatient
            // 
            this.colPatient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPatient.HeaderText = "Patient";
            this.colPatient.MinimumWidth = 50;
            this.colPatient.Name = "colPatient";
            // 
            // colTotal
            // 
            this.colTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTotal.HeaderText = "Montant Total";
            this.colTotal.MinimumWidth = 50;
            this.colTotal.Name = "colTotal";
            // 
            // colMontant
            // 
            this.colMontant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMontant.HeaderText = "Montant payé";
            this.colMontant.MinimumWidth = 50;
            this.colMontant.Name = "colMontant";
            // 
            // colReste
            // 
            this.colReste.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colReste.HeaderText = "Montant restant";
            this.colReste.MinimumWidth = 50;
            this.colReste.Name = "colReste";
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colType.HeaderText = "Type paiement";
            this.colType.MinimumWidth = 50;
            this.colType.Name = "colType";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewImageColumn1.HeaderText = "Apercu reçu";
            this.dataGridViewImageColumn1.Image = global::Cepima.Properties.Resources.print_20px;
            this.dataGridViewImageColumn1.MinimumWidth = 50;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // bt_cacher
            // 
            this.bt_cacher.FlatAppearance.BorderSize = 0;
            this.bt_cacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_cacher.Image = global::Cepima.Properties.Resources.invisible_25px;
            this.bt_cacher.Location = new System.Drawing.Point(118, 8);
            this.bt_cacher.Name = "bt_cacher";
            this.bt_cacher.Size = new System.Drawing.Size(59, 28);
            this.bt_cacher.TabIndex = 5;
            this.bt_cacher.UseVisualStyleBackColor = true;
            this.bt_cacher.Click += new System.EventHandler(this.bt_cacher_Click);
            // 
            // bt_print
            // 
            this.bt_print.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_print.FlatAppearance.BorderSize = 0;
            this.bt_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_print.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_print.ForeColor = System.Drawing.Color.White;
            this.bt_print.Image = global::Cepima.Properties.Resources.print_white;
            this.bt_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_print.Location = new System.Drawing.Point(230, 8);
            this.bt_print.Name = "bt_print";
            this.bt_print.Size = new System.Drawing.Size(148, 28);
            this.bt_print.TabIndex = 5;
            this.bt_print.Text = "Imprimer recu";
            this.bt_print.UseVisualStyleBackColor = false;
            this.bt_print.Click += new System.EventHandler(this.bt_print_Click);
            // 
            // colApercu
            // 
            this.colApercu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colApercu.HeaderText = "Apercu reçu";
            this.colApercu.Image = global::Cepima.Properties.Resources.print_20px;
            this.colApercu.MinimumWidth = 50;
            this.colApercu.Name = "colApercu";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(218, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // User_paiement_facture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.customRoundedPanel2);
            this.Controls.Add(this.customRoundedPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "User_paiement_facture";
            this.Size = new System.Drawing.Size(1100, 547);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel1.PerformLayout();
            this.customRoundedPanel2.ResumeLayout(false);
            this.customRoundedPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_paiement)).EndInit();
            this.panel_appercu_recu.ResumeLayout(false);
            this.panel_appercu_recu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modernDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.DateTimePicker dt_final;
        private System.Windows.Forms.DateTimePicker dt_debut;
        private System.Windows.Forms.ComboBox cbx_type_facture;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tb_search;
        private MyRoundedTextBox tb_tarif;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private CustomRoundedPanel customRoundedPanel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private ModernDataGridView dgv_paiement;
        private CustomRoundedPanel panel_appercu_recu;
        private System.Windows.Forms.Label label7;
        private ModernDataGridView modernDataGridView1;
        private System.Windows.Forms.Button bt_print;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFacture;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReste;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewImageColumn colApercu;
        private System.Windows.Forms.Button bt_cacher;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    }
}
