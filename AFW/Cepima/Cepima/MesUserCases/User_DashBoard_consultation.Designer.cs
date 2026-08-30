namespace Cepima.MesUserCases
{
    partial class User_DashBoard_consultation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_patient = new ModernDataGridView();
            this.customRoundedPanel5 = new CustomRoundedPanel();
            this.lb_sorti = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.customRoundedPanel4 = new CustomRoundedPanel();
            this.lb_attente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.customRoundedPanel3 = new CustomRoundedPanel();
            this.lb_hospitalise = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.lb_patient_now = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdresse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_save_patient = new test_arrondissement2012.PerfectRoundedButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.customRoundedPanel6 = new CustomRoundedPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tb_search_patient = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_patient)).BeginInit();
            this.customRoundedPanel5.SuspendLayout();
            this.customRoundedPanel4.SuspendLayout();
            this.customRoundedPanel3.SuspendLayout();
            this.customRoundedPanel1.SuspendLayout();
            this.customRoundedPanel2.SuspendLayout();
            this.customRoundedPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_patient
            // 
            this.dgv_patient.AllowUserToAddRows = false;
            this.dgv_patient.AllowUserToDeleteRows = false;
            this.dgv_patient.AllowUserToResizeRows = false;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgv_patient.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            this.dgv_patient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_patient.BackgroundColor = System.Drawing.Color.White;
            this.dgv_patient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_patient.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_patient.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_patient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dgv_patient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_patient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colPatient,
            this.colTelephone,
            this.colAdresse,
            this.colNumero,
            this.colType,
            this.colTime,
            this.colStatut});
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_patient.DefaultCellStyle = dataGridViewCellStyle24;
            this.dgv_patient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_patient.EnableHeadersVisualStyles = false;
            this.dgv_patient.GridColor = System.Drawing.Color.LightGray;
            this.dgv_patient.Location = new System.Drawing.Point(0, 0);
            this.dgv_patient.Name = "dgv_patient";
            this.dgv_patient.RowHeadersVisible = false;
            this.dgv_patient.Size = new System.Drawing.Size(1015, 338);
            this.dgv_patient.TabIndex = 0;
            // 
            // customRoundedPanel5
            // 
            this.customRoundedPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customRoundedPanel5.BorderColor = System.Drawing.Color.Transparent;
            this.customRoundedPanel5.BorderRadius = 8;
            this.customRoundedPanel5.BorderSize = 0;
            this.customRoundedPanel5.Controls.Add(this.dgv_patient);
            this.customRoundedPanel5.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel5.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel5.Location = new System.Drawing.Point(3, 176);
            this.customRoundedPanel5.Name = "customRoundedPanel5";
            this.customRoundedPanel5.Size = new System.Drawing.Size(1015, 338);
            this.customRoundedPanel5.TabIndex = 10;
            // 
            // lb_sorti
            // 
            this.lb_sorti.AutoSize = true;
            this.lb_sorti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sorti.Location = new System.Drawing.Point(94, 49);
            this.lb_sorti.Name = "lb_sorti";
            this.lb_sorti.Size = new System.Drawing.Size(15, 16);
            this.lb_sorti.TabIndex = 0;
            this.lb_sorti.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "CONSULTATION DU JOUR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(71, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "URGENCES";
            // 
            // customRoundedPanel4
            // 
            this.customRoundedPanel4.BackColor = System.Drawing.Color.White;
            this.customRoundedPanel4.BorderColor = System.Drawing.Color.Silver;
            this.customRoundedPanel4.BorderRadius = 10;
            this.customRoundedPanel4.BorderSize = 2;
            this.customRoundedPanel4.Controls.Add(this.lb_sorti);
            this.customRoundedPanel4.Controls.Add(this.label3);
            this.customRoundedPanel4.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel4.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel4.Location = new System.Drawing.Point(785, 26);
            this.customRoundedPanel4.Name = "customRoundedPanel4";
            this.customRoundedPanel4.Size = new System.Drawing.Size(212, 100);
            this.customRoundedPanel4.TabIndex = 6;
            // 
            // lb_attente
            // 
            this.lb_attente.AutoSize = true;
            this.lb_attente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_attente.Location = new System.Drawing.Point(94, 49);
            this.lb_attente.Name = "lb_attente";
            this.lb_attente.Size = new System.Drawing.Size(15, 16);
            this.lb_attente.TabIndex = 0;
            this.lb_attente.Text = "5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(68, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "TERMINEES";
            // 
            // customRoundedPanel3
            // 
            this.customRoundedPanel3.BackColor = System.Drawing.Color.White;
            this.customRoundedPanel3.BorderColor = System.Drawing.Color.Silver;
            this.customRoundedPanel3.BorderRadius = 10;
            this.customRoundedPanel3.BorderSize = 2;
            this.customRoundedPanel3.Controls.Add(this.lb_attente);
            this.customRoundedPanel3.Controls.Add(this.label2);
            this.customRoundedPanel3.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel3.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel3.Location = new System.Drawing.Point(543, 26);
            this.customRoundedPanel3.Name = "customRoundedPanel3";
            this.customRoundedPanel3.Size = new System.Drawing.Size(212, 100);
            this.customRoundedPanel3.TabIndex = 7;
            // 
            // lb_hospitalise
            // 
            this.lb_hospitalise.AutoSize = true;
            this.lb_hospitalise.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_hospitalise.Location = new System.Drawing.Point(88, 49);
            this.lb_hospitalise.Name = "lb_hospitalise";
            this.lb_hospitalise.Size = new System.Drawing.Size(22, 16);
            this.lb_hospitalise.TabIndex = 0;
            this.lb_hospitalise.Text = "22";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(67, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "EN ATTENTE";
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.BackColor = System.Drawing.Color.White;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.Silver;
            this.customRoundedPanel1.BorderRadius = 10;
            this.customRoundedPanel1.BorderSize = 2;
            this.customRoundedPanel1.Controls.Add(this.lb_hospitalise);
            this.customRoundedPanel1.Controls.Add(this.label1);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel1.Location = new System.Drawing.Point(276, 26);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Size = new System.Drawing.Size(212, 100);
            this.customRoundedPanel1.TabIndex = 8;
            // 
            // lb_patient_now
            // 
            this.lb_patient_now.AutoSize = true;
            this.lb_patient_now.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_patient_now.Location = new System.Drawing.Point(88, 49);
            this.lb_patient_now.Name = "lb_patient_now";
            this.lb_patient_now.Size = new System.Drawing.Size(22, 16);
            this.lb_patient_now.TabIndex = 0;
            this.lb_patient_now.Text = "46";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(58, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "CONSULTATION";
            // 
            // customRoundedPanel2
            // 
            this.customRoundedPanel2.BackColor = System.Drawing.Color.White;
            this.customRoundedPanel2.BorderColor = System.Drawing.Color.Silver;
            this.customRoundedPanel2.BorderRadius = 10;
            this.customRoundedPanel2.BorderSize = 2;
            this.customRoundedPanel2.Controls.Add(this.lb_patient_now);
            this.customRoundedPanel2.Controls.Add(this.label4);
            this.customRoundedPanel2.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel2.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel2.Location = new System.Drawing.Point(24, 26);
            this.customRoundedPanel2.Name = "customRoundedPanel2";
            this.customRoundedPanel2.Size = new System.Drawing.Size(212, 100);
            this.customRoundedPanel2.TabIndex = 9;
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colID.HeaderText = "N°";
            this.colID.MinimumWidth = 50;
            this.colID.Name = "colID";
            // 
            // colPatient
            // 
            this.colPatient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPatient.HeaderText = "Patient";
            this.colPatient.MinimumWidth = 50;
            this.colPatient.Name = "colPatient";
            // 
            // colTelephone
            // 
            this.colTelephone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTelephone.HeaderText = "Téléphone";
            this.colTelephone.MinimumWidth = 50;
            this.colTelephone.Name = "colTelephone";
            // 
            // colAdresse
            // 
            this.colAdresse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAdresse.HeaderText = "Adresse";
            this.colAdresse.MinimumWidth = 50;
            this.colAdresse.Name = "colAdresse";
            // 
            // colNumero
            // 
            this.colNumero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNumero.HeaderText = "Numéro Fiche";
            this.colNumero.MinimumWidth = 50;
            this.colNumero.Name = "colNumero";
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colType.HeaderText = "Type";
            this.colType.MinimumWidth = 50;
            this.colType.Name = "colType";
            // 
            // colTime
            // 
            this.colTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTime.HeaderText = "Heure";
            this.colTime.MinimumWidth = 50;
            this.colTime.Name = "colTime";
            // 
            // colStatut
            // 
            this.colStatut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStatut.HeaderText = "Statut";
            this.colStatut.MinimumWidth = 50;
            this.colStatut.Name = "colStatut";
            // 
            // bt_save_patient
            // 
            this.bt_save_patient.BackColor = System.Drawing.Color.Transparent;
            this.bt_save_patient.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_save_patient.BorderRadius = 5;
            this.bt_save_patient.BorderSize = 0;
            this.bt_save_patient.ButtonText = "Commencer";
            this.bt_save_patient.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.bt_save_patient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save_patient.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_save_patient.Location = new System.Drawing.Point(330, 144);
            this.bt_save_patient.Name = "bt_save_patient";
            this.bt_save_patient.Size = new System.Drawing.Size(135, 29);
            this.bt_save_patient.TabIndex = 19;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(531, 150);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(168, 23);
            this.comboBox1.TabIndex = 20;
            // 
            // customRoundedPanel6
            // 
            this.customRoundedPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customRoundedPanel6.BackColor = System.Drawing.SystemColors.Window;
            this.customRoundedPanel6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel6.BorderRadius = 5;
            this.customRoundedPanel6.BorderSize = 2;
            this.customRoundedPanel6.Controls.Add(this.pictureBox2);
            this.customRoundedPanel6.Controls.Add(this.tb_search_patient);
            this.customRoundedPanel6.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel6.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel6.Location = new System.Drawing.Point(747, 145);
            this.customRoundedPanel6.Name = "customRoundedPanel6";
            this.customRoundedPanel6.Size = new System.Drawing.Size(250, 28);
            this.customRoundedPanel6.TabIndex = 21;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox2.Image = global::Cepima.Properties.Resources.search1;
            this.pictureBox2.Location = new System.Drawing.Point(216, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // tb_search_patient
            // 
            this.tb_search_patient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_search_patient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_search_patient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search_patient.Location = new System.Drawing.Point(5, 4);
            this.tb_search_patient.Multiline = true;
            this.tb_search_patient.Name = "tb_search_patient";
            this.tb_search_patient.Size = new System.Drawing.Size(205, 20);
            this.tb_search_patient.TabIndex = 0;
            // 
            // User_DashBoard_consultation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customRoundedPanel6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.bt_save_patient);
            this.Controls.Add(this.customRoundedPanel5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.customRoundedPanel4);
            this.Controls.Add(this.customRoundedPanel3);
            this.Controls.Add(this.customRoundedPanel1);
            this.Controls.Add(this.customRoundedPanel2);
            this.Name = "User_DashBoard_consultation";
            this.Size = new System.Drawing.Size(1021, 519);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_patient)).EndInit();
            this.customRoundedPanel5.ResumeLayout(false);
            this.customRoundedPanel4.ResumeLayout(false);
            this.customRoundedPanel4.PerformLayout();
            this.customRoundedPanel3.ResumeLayout(false);
            this.customRoundedPanel3.PerformLayout();
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel1.PerformLayout();
            this.customRoundedPanel2.ResumeLayout(false);
            this.customRoundedPanel2.PerformLayout();
            this.customRoundedPanel6.ResumeLayout(false);
            this.customRoundedPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ModernDataGridView dgv_patient;
        private CustomRoundedPanel customRoundedPanel5;
        private System.Windows.Forms.Label lb_sorti;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private CustomRoundedPanel customRoundedPanel4;
        private System.Windows.Forms.Label lb_attente;
        private System.Windows.Forms.Label label2;
        private CustomRoundedPanel customRoundedPanel3;
        private System.Windows.Forms.Label lb_hospitalise;
        private System.Windows.Forms.Label label1;
        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.Label lb_patient_now;
        private System.Windows.Forms.Label label4;
        private CustomRoundedPanel customRoundedPanel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdresse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatut;
        private test_arrondissement2012.PerfectRoundedButton bt_save_patient;
        private System.Windows.Forms.ComboBox comboBox1;
        private CustomRoundedPanel customRoundedPanel6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox tb_search_patient;
    }
}
