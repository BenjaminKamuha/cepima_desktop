namespace Cepima.MesUserCases.Pharmacie
{
    partial class UC_EEG
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
            this.fl_med_card = new System.Windows.Forms.FlowLayoutPanel();
            this.pnl_table = new CustomRoundedPanel();
            this.cbx_filter_eeg = new MyRoundedComboBox();
            this.btn_new_examen = new RoundedButton();
            this.tb_search = new MyRoundedTextBox();
            this.cbx_date = new MyRoundedComboBox();
            this.modernDataGridView1 = new ModernDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modernDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fl_med_card
            // 
            this.fl_med_card.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fl_med_card.AutoScroll = true;
            this.fl_med_card.BackColor = System.Drawing.Color.White;
            this.fl_med_card.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fl_med_card.Location = new System.Drawing.Point(12, 4);
            this.fl_med_card.Name = "fl_med_card";
            this.fl_med_card.Size = new System.Drawing.Size(1003, 120);
            this.fl_med_card.TabIndex = 10;
            // 
            // pnl_table
            // 
            this.pnl_table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_table.BackColor = System.Drawing.Color.White;
            this.pnl_table.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnl_table.BorderRadius = 5;
            this.pnl_table.BorderSize = 2;
            this.pnl_table.Controls.Add(this.label1);
            this.pnl_table.Controls.Add(this.modernDataGridView1);
            this.pnl_table.HoverBackColor = System.Drawing.Color.Empty;
            this.pnl_table.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.pnl_table.Location = new System.Drawing.Point(11, 202);
            this.pnl_table.Name = "pnl_table";
            this.pnl_table.Padding = new System.Windows.Forms.Padding(10, 10, 10, 14);
            this.pnl_table.ShadowBlur = 10;
            this.pnl_table.ShadowBorderRadius = -1;
            this.pnl_table.ShadowColor = System.Drawing.Color.Black;
            this.pnl_table.ShadowEnabled = true;
            this.pnl_table.ShadowOffsetX = 0;
            this.pnl_table.ShadowOffsetY = 4;
            this.pnl_table.ShadowOpacity = 60;
            this.pnl_table.ShadowSpread = 0;
            this.pnl_table.Size = new System.Drawing.Size(1008, 311);
            this.pnl_table.TabIndex = 9;
            // 
            // cbx_filter_eeg
            // 
            this.cbx_filter_eeg.ArrowColor = System.Drawing.Color.DodgerBlue;
            this.cbx_filter_eeg.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_filter_eeg.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_filter_eeg.BorderColor = System.Drawing.Color.Silver;
            this.cbx_filter_eeg.BorderRadius = 8;
            this.cbx_filter_eeg.BorderSize = 1;
            this.cbx_filter_eeg.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_filter_eeg.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_filter_eeg.DropDownSelectedBackColor = System.Drawing.Color.Silver;
            this.cbx_filter_eeg.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_filter_eeg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_filter_eeg.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.cbx_filter_eeg.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_filter_eeg.Location = new System.Drawing.Point(13, 148);
            this.cbx_filter_eeg.MinimumSize = new System.Drawing.Size(80, 30);
            this.cbx_filter_eeg.Name = "cbx_filter_eeg";
            this.cbx_filter_eeg.SelectedItem = null;
            this.cbx_filter_eeg.SelectedValue = null;
            this.cbx_filter_eeg.Size = new System.Drawing.Size(188, 34);
            this.cbx_filter_eeg.TabIndex = 11;
            // 
            // btn_new_examen
            // 
            this.btn_new_examen.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_new_examen.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_new_examen.BorderRadius = 8;
            this.btn_new_examen.BorderSize = 0;
            this.btn_new_examen.ButtonText = "Nouvel EEG";
            this.btn_new_examen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_new_examen.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_new_examen.FlatAppearance.BorderSize = 0;
            this.btn_new_examen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_new_examen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_examen.ForeColor = System.Drawing.Color.White;
            this.btn_new_examen.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_new_examen.Image = global::Cepima.Properties.Resources.add_25px1;
            this.btn_new_examen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_new_examen.Location = new System.Drawing.Point(870, 148);
            this.btn_new_examen.Name = "btn_new_examen";
            this.btn_new_examen.Size = new System.Drawing.Size(146, 34);
            this.btn_new_examen.TabIndex = 13;
            this.btn_new_examen.Text = "Nouvel EEG";
            this.btn_new_examen.TextColor = System.Drawing.Color.White;
            this.btn_new_examen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_new_examen.UseVisualStyleBackColor = false;
            // 
            // tb_search
            // 
            this.tb_search.BackColor = System.Drawing.Color.White;
            this.tb_search.BorderColor = System.Drawing.Color.Silver;
            this.tb_search.BorderRadius = 8;
            this.tb_search.BorderSize = 1;
            this.tb_search.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_search.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search.ForeColor = System.Drawing.Color.Black;
            this.tb_search.Image = global::Cepima.Properties.Resources.search_25px;
            this.tb_search.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_search.ImagePadding = 4;
            this.tb_search.Location = new System.Drawing.Point(482, 139);
            this.tb_search.MaxLength = 32767;
            this.tb_search.Name = "tb_search";
            this.tb_search.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_search.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_search.PlaceholderText = "Rechercher un produit";
            this.tb_search.Size = new System.Drawing.Size(273, 34);
            this.tb_search.TabIndex = 12;
            // 
            // cbx_date
            // 
            this.cbx_date.ArrowColor = System.Drawing.Color.DodgerBlue;
            this.cbx_date.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_date.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_date.BorderColor = System.Drawing.Color.Silver;
            this.cbx_date.BorderRadius = 8;
            this.cbx_date.BorderSize = 1;
            this.cbx_date.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_date.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_date.DropDownSelectedBackColor = System.Drawing.Color.Silver;
            this.cbx_date.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_date.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_date.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.cbx_date.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_date.Location = new System.Drawing.Point(222, 148);
            this.cbx_date.MinimumSize = new System.Drawing.Size(80, 30);
            this.cbx_date.Name = "cbx_date";
            this.cbx_date.SelectedItem = null;
            this.cbx_date.SelectedValue = null;
            this.cbx_date.Size = new System.Drawing.Size(108, 34);
            this.cbx_date.TabIndex = 11;
            // 
            // modernDataGridView1
            // 
            this.modernDataGridView1.AllowUserToAddRows = false;
            this.modernDataGridView1.AllowUserToDeleteRows = false;
            this.modernDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.modernDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.modernDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.modernDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.modernDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.modernDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.modernDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.modernDataGridView1.ColumnHeadersHeight = 4;
            this.modernDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.modernDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.modernDataGridView1.EnableHeadersVisualStyles = false;
            this.modernDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.modernDataGridView1.HeaderBackColor = System.Drawing.Color.SteelBlue;
            this.modernDataGridView1.HeaderForeColor = System.Drawing.Color.White;
            this.modernDataGridView1.Location = new System.Drawing.Point(8, 41);
            this.modernDataGridView1.MultiSelect = false;
            this.modernDataGridView1.Name = "modernDataGridView1";
            this.modernDataGridView1.OuterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.modernDataGridView1.RowHeadersVisible = false;
            this.modernDataGridView1.RowTemplate.Height = 48;
            this.modernDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.modernDataGridView1.Size = new System.Drawing.Size(993, 264);
            this.modernDataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "EXAMENS EEG RECENTS";
            // 
            // UC_EEG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cbx_date);
            this.Controls.Add(this.cbx_filter_eeg);
            this.Controls.Add(this.btn_new_examen);
            this.Controls.Add(this.tb_search);
            this.Controls.Add(this.fl_med_card);
            this.Controls.Add(this.pnl_table);
            this.Name = "UC_EEG";
            this.Size = new System.Drawing.Size(1031, 526);
            this.pnl_table.ResumeLayout(false);
            this.pnl_table.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modernDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fl_med_card;
        private CustomRoundedPanel pnl_table;
        private MyRoundedComboBox cbx_filter_eeg;
        private RoundedButton btn_new_examen;
        private MyRoundedTextBox tb_search;
        private System.Windows.Forms.Label label1;
        private ModernDataGridView modernDataGridView1;
        private MyRoundedComboBox cbx_date;
    }
}
