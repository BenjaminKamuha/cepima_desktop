namespace Cepima.MesUserCases.Personnels
{
    partial class User_fingerprint
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
            this.label9 = new System.Windows.Forms.Label();
            this.cbx_filter = new MyRoundedComboBox();
            this.dgv_personnel = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuRoundedPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_personnel)).BeginInit();
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
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(3, 81);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 10;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(1089, 463);
            this.bunifuRoundedPanel1.TabIndex = 7;
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1073, 439);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_recherche);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cbx_filter);
            this.panel1.Controls.Add(this.dgv_personnel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 433);
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
            this.txt_recherche.Location = new System.Drawing.Point(4, 13);
            this.txt_recherche.MaxLength = 32767;
            this.txt_recherche.Name = "txt_recherche";
            this.txt_recherche.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txt_recherche.PlaceholderColor = System.Drawing.Color.Gray;
            this.txt_recherche.PlaceholderText = "Search personn";
            this.txt_recherche.Size = new System.Drawing.Size(257, 30);
            this.txt_recherche.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(299, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "Tous";
            // 
            // cbx_filter
            // 
            this.cbx_filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_filter.ArrowColor = System.Drawing.SystemColors.ActiveCaption;
            this.cbx_filter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_filter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_filter.BorderColor = System.Drawing.Color.Silver;
            this.cbx_filter.BorderRadius = 6;
            this.cbx_filter.BorderSize = 1;
            this.cbx_filter.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_filter.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_filter.DropDownSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.cbx_filter.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_filter.FocusBorderColor = System.Drawing.Color.Silver;
            this.cbx_filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbx_filter.Location = new System.Drawing.Point(363, 15);
            this.cbx_filter.Name = "cbx_filter";
            this.cbx_filter.SelectedItem = null;
            this.cbx_filter.SelectedValue = null;
            this.cbx_filter.Size = new System.Drawing.Size(153, 28);
            this.cbx_filter.TabIndex = 7;
            // 
            // dgv_personnel
            // 
            this.dgv_personnel.AllowUserToAddRows = false;
            this.dgv_personnel.AllowUserToDeleteRows = false;
            this.dgv_personnel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_personnel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_personnel.BackgroundColor = System.Drawing.Color.White;
            this.dgv_personnel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_personnel.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_personnel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_personnel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_personnel.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_personnel.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_personnel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_personnel.EnableHeadersVisualStyles = false;
            this.dgv_personnel.Location = new System.Drawing.Point(0, 54);
            this.dgv_personnel.Name = "dgv_personnel";
            this.dgv_personnel.ReadOnly = true;
            this.dgv_personnel.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_personnel.RowHeadersVisible = false;
            this.dgv_personnel.RowTemplate.Height = 30;
            this.dgv_personnel.Size = new System.Drawing.Size(1061, 382);
            this.dgv_personnel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "GESTION DES EMPREINTES";
            // 
            // User_fingerprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Controls.Add(this.label1);
            this.Name = "User_fingerprint";
            this.Size = new System.Drawing.Size(1095, 547);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_personnel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private MyRoundedTextBox txt_recherche;
        private System.Windows.Forms.Label label9;
        private MyRoundedComboBox cbx_filter;
        private System.Windows.Forms.DataGridView dgv_personnel;
        private System.Windows.Forms.Label label1;
    }
}
