namespace Cepima.MesUserCases
{
    partial class User_chambres
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
            this.cbx_service = new System.Windows.Forms.ComboBox();
            this.cbx_type_chambre = new System.Windows.Forms.ComboBox();
            this.tb_tarif = new MyRoundedTextBox();
            this.numeric_chambre = new System.Windows.Forms.NumericUpDown();
            this.bt_save_chambre = new test_arrondissement2012.PerfectRoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgv_chambres = new ModernDataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTarif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdate = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.colSave = new System.Windows.Forms.DataGridViewImageColumn();
            this.customRoundedPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_chambre)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chambres)).BeginInit();
            this.SuspendLayout();
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 10;
            this.customRoundedPanel1.BorderSize = 2;
            this.customRoundedPanel1.Controls.Add(this.dgv_chambres);
            this.customRoundedPanel1.Controls.Add(this.panel2);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(196, 23);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Size = new System.Drawing.Size(809, 474);
            this.customRoundedPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbx_service);
            this.panel2.Controls.Add(this.cbx_type_chambre);
            this.panel2.Controls.Add(this.tb_tarif);
            this.panel2.Controls.Add(this.numeric_chambre);
            this.panel2.Controls.Add(this.bt_save_chambre);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(107, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(498, 271);
            this.panel2.TabIndex = 10;
            // 
            // cbx_service
            // 
            this.cbx_service.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_service.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.cbx_service.FormattingEnabled = true;
            this.cbx_service.Location = new System.Drawing.Point(197, 129);
            this.cbx_service.Name = "cbx_service";
            this.cbx_service.Size = new System.Drawing.Size(189, 23);
            this.cbx_service.TabIndex = 13;
            // 
            // cbx_type_chambre
            // 
            this.cbx_type_chambre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_type_chambre.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.cbx_type_chambre.FormattingEnabled = true;
            this.cbx_type_chambre.Location = new System.Drawing.Point(197, 77);
            this.cbx_type_chambre.Name = "cbx_type_chambre";
            this.cbx_type_chambre.Size = new System.Drawing.Size(189, 23);
            this.cbx_type_chambre.TabIndex = 13;
            // 
            // tb_tarif
            // 
            this.tb_tarif.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_tarif.BorderRadius = 4;
            this.tb_tarif.BorderSize = 0;
            this.tb_tarif.FocusBorderColor = System.Drawing.Color.Orange;
            this.tb_tarif.Location = new System.Drawing.Point(197, 174);
            this.tb_tarif.Name = "tb_tarif";
            this.tb_tarif.PasswordChar = '\0';
            this.tb_tarif.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_tarif.PlaceholderText = "";
            this.tb_tarif.Size = new System.Drawing.Size(189, 28);
            this.tb_tarif.TabIndex = 12;
            this.tb_tarif.UseSystemPasswordChar = false;
            // 
            // numeric_chambre
            // 
            this.numeric_chambre.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeric_chambre.Location = new System.Drawing.Point(197, 22);
            this.numeric_chambre.Name = "numeric_chambre";
            this.numeric_chambre.Size = new System.Drawing.Size(189, 23);
            this.numeric_chambre.TabIndex = 11;
            // 
            // bt_save_chambre
            // 
            this.bt_save_chambre.BackColor = System.Drawing.Color.Transparent;
            this.bt_save_chambre.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_save_chambre.BorderRadius = 5;
            this.bt_save_chambre.BorderSize = 0;
            this.bt_save_chambre.ButtonText = "Enregistrer";
            this.bt_save_chambre.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.bt_save_chambre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save_chambre.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_save_chambre.Location = new System.Drawing.Point(201, 228);
            this.bt_save_chambre.Name = "bt_save_chambre";
            this.bt_save_chambre.Size = new System.Drawing.Size(132, 30);
            this.bt_save_chambre.TabIndex = 10;
            this.bt_save_chambre.Click += new System.EventHandler(this.bt_save_chambre_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Numero chambre : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Service  : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tarif journalier  : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(57, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "Type chambre  : ";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(14, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 215);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-10, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ajouter une chambre";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.room_90px;
            this.pictureBox1.Location = new System.Drawing.Point(22, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dgv_chambres
            // 
            this.dgv_chambres.AllowUserToAddRows = false;
            this.dgv_chambres.AllowUserToDeleteRows = false;
            this.dgv_chambres.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgv_chambres.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_chambres.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_chambres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_chambres.BackgroundColor = System.Drawing.Color.White;
            this.dgv_chambres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_chambres.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_chambres.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_chambres.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_chambres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_chambres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colService,
            this.colNumero,
            this.colType,
            this.colTarif,
            this.colStatut,
            this.colUpdate,
            this.colDelete,
            this.colSave});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_chambres.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_chambres.EnableHeadersVisualStyles = false;
            this.dgv_chambres.GridColor = System.Drawing.Color.LightGray;
            this.dgv_chambres.Location = new System.Drawing.Point(3, 291);
            this.dgv_chambres.Name = "dgv_chambres";
            this.dgv_chambres.RowHeadersVisible = false;
            this.dgv_chambres.Size = new System.Drawing.Size(803, 178);
            this.dgv_chambres.TabIndex = 11;
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 50;
            this.colID.Name = "colID";
            this.colID.Visible = false;
            // 
            // colService
            // 
            this.colService.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colService.HeaderText = "Service";
            this.colService.MinimumWidth = 50;
            this.colService.Name = "colService";
            // 
            // colNumero
            // 
            this.colNumero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNumero.HeaderText = "N°chambre";
            this.colNumero.MinimumWidth = 50;
            this.colNumero.Name = "colNumero";
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colType.HeaderText = "Type chambre";
            this.colType.MinimumWidth = 50;
            this.colType.Name = "colType";
            // 
            // colTarif
            // 
            this.colTarif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTarif.HeaderText = "Tarif journalier";
            this.colTarif.MinimumWidth = 50;
            this.colTarif.Name = "colTarif";
            // 
            // colStatut
            // 
            this.colStatut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStatut.HeaderText = "Statut";
            this.colStatut.MinimumWidth = 50;
            this.colStatut.Name = "colStatut";
            // 
            // colUpdate
            // 
            this.colUpdate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUpdate.HeaderText = "";
            this.colUpdate.Image = global::Cepima.Properties.Resources.edit_green;
            this.colUpdate.MinimumWidth = 50;
            this.colUpdate.Name = "colUpdate";
            // 
            // colDelete
            // 
            this.colDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDelete.HeaderText = "";
            this.colDelete.Image = global::Cepima.Properties.Resources.trash_red;
            this.colDelete.MinimumWidth = 50;
            this.colDelete.Name = "colDelete";
            // 
            // colSave
            // 
            this.colSave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSave.HeaderText = "";
            this.colSave.Image = global::Cepima.Properties.Resources.ok_20px;
            this.colSave.MinimumWidth = 50;
            this.colSave.Name = "colSave";
            // 
            // User_chambres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.customRoundedPanel1);
            this.Name = "User_chambres";
            this.Size = new System.Drawing.Size(1008, 530);
            this.Load += new System.EventHandler(this.User_chambres_Load);
            this.customRoundedPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_chambre)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chambres)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private test_arrondissement2012.PerfectRoundedButton bt_save_chambre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numeric_chambre;
        private System.Windows.Forms.Label label3;
        private MyRoundedTextBox tb_tarif;
        private System.Windows.Forms.ComboBox cbx_type_chambre;
        private System.Windows.Forms.ComboBox cbx_service;
        private System.Windows.Forms.Label label2;
        private ModernDataGridView dgv_chambres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colService;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTarif;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatut;
        private System.Windows.Forms.DataGridViewImageColumn colUpdate;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
        private System.Windows.Forms.DataGridViewImageColumn colSave;
    }
}
