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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_consult = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSexe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdresse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_start = new RoundedButton();
            this.tb_search_ = new MyRoundedTextBox();
            this.cbx_filtrer = new MyRoundedComboBox();
            this.customRoundedPanel4 = new CustomRoundedPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.customRoundedPanel3 = new CustomRoundedPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_consult)).BeginInit();
            this.customRoundedPanel4.SuspendLayout();
            this.customRoundedPanel3.SuspendLayout();
            this.customRoundedPanel2.SuspendLayout();
            this.customRoundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgv_consult);
            this.panel1.Location = new System.Drawing.Point(11, 202);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(997, 314);
            this.panel1.TabIndex = 2;
            // 
            // dgv_consult
            // 
            this.dgv_consult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_consult.BackgroundColor = System.Drawing.Color.White;
            this.dgv_consult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_consult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_consult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_consult.ColumnHeadersHeight = 30;
            this.dgv_consult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colPatient,
            this.colSexe,
            this.colAdresse,
            this.colType,
            this.colHeure,
            this.colStatut,
            this.ID_Patient});
            this.dgv_consult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_consult.EnableHeadersVisualStyles = false;
            this.dgv_consult.Location = new System.Drawing.Point(0, 0);
            this.dgv_consult.Name = "dgv_consult";
            this.dgv_consult.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_consult.RowHeadersVisible = false;
            this.dgv_consult.RowTemplate.Height = 30;
            this.dgv_consult.Size = new System.Drawing.Size(995, 312);
            this.dgv_consult.TabIndex = 0;
            this.dgv_consult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_consult_CellClick);
            // 
            // colID
            // 
            this.colID.HeaderText = "N°";
            this.colID.Name = "colID";
            // 
            // colPatient
            // 
            this.colPatient.HeaderText = "Patient";
            this.colPatient.Name = "colPatient";
            // 
            // colSexe
            // 
            this.colSexe.HeaderText = "Sexe";
            this.colSexe.Name = "colSexe";
            // 
            // colAdresse
            // 
            this.colAdresse.HeaderText = "Adresse";
            this.colAdresse.Name = "colAdresse";
            // 
            // colType
            // 
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            // 
            // colHeure
            // 
            this.colHeure.HeaderText = "Heure";
            this.colHeure.Name = "colHeure";
            // 
            // colStatut
            // 
            this.colStatut.HeaderText = "Statut";
            this.colStatut.Name = "colStatut";
            // 
            // ID_Patient
            // 
            this.ID_Patient.HeaderText = "";
            this.ID_Patient.Name = "ID_Patient";
            this.ID_Patient.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(240, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "CONSULTATIONS DU JOUR";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "N°";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 124;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Patient";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Sexe";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 124;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Adresse";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 124;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Age";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 124;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Type";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Heure";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 124;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Statut";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 124;
            // 
            // bt_start
            // 
            this.bt_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_start.BackColor = System.Drawing.Color.Transparent;
            this.bt_start.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_start.BorderRadius = 8;
            this.bt_start.ButtonText = "Commencer";
            this.bt_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_start.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_start.FlatAppearance.BorderSize = 0;
            this.bt_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_start.ForeColor = System.Drawing.Color.White;
            this.bt_start.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_start.Image = global::Cepima.Properties.Resources.play_30px;
            this.bt_start.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_start.Location = new System.Drawing.Point(850, 164);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(157, 35);
            this.bt_start.TabIndex = 35;
            this.bt_start.Text = "Commencer";
            this.bt_start.TextColor = System.Drawing.Color.White;
            this.bt_start.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_start.UseVisualStyleBackColor = false;
            this.bt_start.Visible = false;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // tb_search_
            // 
            this.tb_search_.BackColor = System.Drawing.Color.White;
            this.tb_search_.BorderColor = System.Drawing.Color.Silver;
            this.tb_search_.BorderRadius = 6;
            this.tb_search_.BorderSize = 1;
            this.tb_search_.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_search_.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search_.ForeColor = System.Drawing.Color.Black;
            this.tb_search_.Image = global::Cepima.Properties.Resources.search;
            this.tb_search_.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_search_.Location = new System.Drawing.Point(585, 169);
            this.tb_search_.MaxLength = 32767;
            this.tb_search_.Name = "tb_search_";
            this.tb_search_.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_search_.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_search_.PlaceholderText = "";
            this.tb_search_.Size = new System.Drawing.Size(243, 30);
            this.tb_search_.TabIndex = 1;
            this.tb_search_.Text = "Search";
            // 
            // cbx_filtrer
            // 
            this.cbx_filtrer.ArrowColor = System.Drawing.Color.Silver;
            this.cbx_filtrer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_filtrer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_filtrer.BorderColor = System.Drawing.Color.Silver;
            this.cbx_filtrer.BorderRadius = 6;
            this.cbx_filtrer.BorderSize = 1;
            this.cbx_filtrer.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_filtrer.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_filtrer.DropDownSelectedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.cbx_filtrer.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_filtrer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_filtrer.FocusBorderColor = System.Drawing.Color.Silver;
            this.cbx_filtrer.Location = new System.Drawing.Point(306, 170);
            this.cbx_filtrer.Name = "cbx_filtrer";
            this.cbx_filtrer.SelectedItem = null;
            this.cbx_filtrer.SelectedValue = null;
            this.cbx_filtrer.Size = new System.Drawing.Size(192, 28);
            this.cbx_filtrer.TabIndex = 1;
            // 
            // customRoundedPanel4
            // 
            this.customRoundedPanel4.BorderColor = System.Drawing.Color.Silver;
            this.customRoundedPanel4.BorderRadius = 10;
            this.customRoundedPanel4.BorderSize = 2;
            this.customRoundedPanel4.Controls.Add(this.label8);
            this.customRoundedPanel4.Controls.Add(this.label4);
            this.customRoundedPanel4.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel4.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel4.Location = new System.Drawing.Point(776, 44);
            this.customRoundedPanel4.Name = "customRoundedPanel4";
            this.customRoundedPanel4.ShadowBlur = 10;
            this.customRoundedPanel4.ShadowBorderRadius = -1;
            this.customRoundedPanel4.ShadowColor = System.Drawing.Color.Black;
            this.customRoundedPanel4.ShadowEnabled = false;
            this.customRoundedPanel4.ShadowOffsetX = 0;
            this.customRoundedPanel4.ShadowOffsetY = 4;
            this.customRoundedPanel4.ShadowOpacity = 60;
            this.customRoundedPanel4.ShadowSpread = 0;
            this.customRoundedPanel4.Size = new System.Drawing.Size(232, 100);
            this.customRoundedPanel4.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(104, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(72, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "URGENCES";
            // 
            // customRoundedPanel3
            // 
            this.customRoundedPanel3.BorderColor = System.Drawing.Color.Silver;
            this.customRoundedPanel3.BorderRadius = 10;
            this.customRoundedPanel3.BorderSize = 2;
            this.customRoundedPanel3.Controls.Add(this.label7);
            this.customRoundedPanel3.Controls.Add(this.label3);
            this.customRoundedPanel3.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel3.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel3.Location = new System.Drawing.Point(521, 44);
            this.customRoundedPanel3.Name = "customRoundedPanel3";
            this.customRoundedPanel3.ShadowBlur = 10;
            this.customRoundedPanel3.ShadowBorderRadius = -1;
            this.customRoundedPanel3.ShadowColor = System.Drawing.Color.Black;
            this.customRoundedPanel3.ShadowEnabled = false;
            this.customRoundedPanel3.ShadowOffsetX = 0;
            this.customRoundedPanel3.ShadowOffsetY = 4;
            this.customRoundedPanel3.ShadowOpacity = 60;
            this.customRoundedPanel3.ShadowSpread = 0;
            this.customRoundedPanel3.Size = new System.Drawing.Size(232, 100);
            this.customRoundedPanel3.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(97, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(70, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "TERMINEES";
            // 
            // customRoundedPanel2
            // 
            this.customRoundedPanel2.BorderColor = System.Drawing.Color.Silver;
            this.customRoundedPanel2.BorderRadius = 10;
            this.customRoundedPanel2.BorderSize = 2;
            this.customRoundedPanel2.Controls.Add(this.label6);
            this.customRoundedPanel2.Controls.Add(this.label2);
            this.customRoundedPanel2.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel2.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel2.Location = new System.Drawing.Point(266, 44);
            this.customRoundedPanel2.Name = "customRoundedPanel2";
            this.customRoundedPanel2.ShadowBlur = 10;
            this.customRoundedPanel2.ShadowBorderRadius = -1;
            this.customRoundedPanel2.ShadowColor = System.Drawing.Color.Black;
            this.customRoundedPanel2.ShadowEnabled = false;
            this.customRoundedPanel2.ShadowOffsetX = 0;
            this.customRoundedPanel2.ShadowOffsetY = 4;
            this.customRoundedPanel2.ShadowOpacity = 60;
            this.customRoundedPanel2.ShadowSpread = 0;
            this.customRoundedPanel2.Size = new System.Drawing.Size(232, 100);
            this.customRoundedPanel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(97, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "11";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(68, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "EN ATTENTE";
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.Silver;
            this.customRoundedPanel1.BorderRadius = 10;
            this.customRoundedPanel1.BorderSize = 2;
            this.customRoundedPanel1.Controls.Add(this.label5);
            this.customRoundedPanel1.Controls.Add(this.label1);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel1.Location = new System.Drawing.Point(11, 44);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.ShadowBlur = 10;
            this.customRoundedPanel1.ShadowBorderRadius = -1;
            this.customRoundedPanel1.ShadowColor = System.Drawing.Color.Black;
            this.customRoundedPanel1.ShadowEnabled = false;
            this.customRoundedPanel1.ShadowOffsetX = 0;
            this.customRoundedPanel1.ShadowOffsetY = 4;
            this.customRoundedPanel1.ShadowOpacity = 60;
            this.customRoundedPanel1.ShadowSpread = 0;
            this.customRoundedPanel1.Size = new System.Drawing.Size(232, 100);
            this.customRoundedPanel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(97, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "14";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(54, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "CONSULTATION";
            // 
            // User_DashBoard_consultation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bt_start);
            this.Controls.Add(this.tb_search_);
            this.Controls.Add(this.cbx_filtrer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.customRoundedPanel4);
            this.Controls.Add(this.customRoundedPanel3);
            this.Controls.Add(this.customRoundedPanel2);
            this.Controls.Add(this.customRoundedPanel1);
            this.Name = "User_DashBoard_consultation";
            this.Size = new System.Drawing.Size(1021, 519);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_consult)).EndInit();
            this.customRoundedPanel4.ResumeLayout(false);
            this.customRoundedPanel4.PerformLayout();
            this.customRoundedPanel3.ResumeLayout(false);
            this.customRoundedPanel3.PerformLayout();
            this.customRoundedPanel2.ResumeLayout(false);
            this.customRoundedPanel2.PerformLayout();
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel1;
        private CustomRoundedPanel customRoundedPanel2;
        private CustomRoundedPanel customRoundedPanel3;
        private CustomRoundedPanel customRoundedPanel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgv_consult;
        private MyRoundedComboBox cbx_filtrer;
        private MyRoundedTextBox tb_search_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSexe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdresse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeure;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatut;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private RoundedButton bt_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Patient;

    }
}
