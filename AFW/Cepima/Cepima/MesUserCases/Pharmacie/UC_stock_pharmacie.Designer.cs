namespace Cepima.MesUserCases
{
    partial class UC_stock_pharmacie
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
            this.fl_med_category = new System.Windows.Forms.FlowLayoutPanel();
            this.cbx_filter_category = new MyRoundedComboBox();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.fl_medoc = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_add_med = new RoundedButton();
            this.tb_search = new MyRoundedTextBox();
            this.customRoundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fl_med_category
            // 
            this.fl_med_category.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fl_med_category.AutoScroll = true;
            this.fl_med_category.BackColor = System.Drawing.Color.White;
            this.fl_med_category.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fl_med_category.Location = new System.Drawing.Point(13, 65);
            this.fl_med_category.Name = "fl_med_category";
            this.fl_med_category.Size = new System.Drawing.Size(1003, 126);
            this.fl_med_category.TabIndex = 5;
            // 
            // cbx_filter_category
            // 
            this.cbx_filter_category.ArrowColor = System.Drawing.Color.DodgerBlue;
            this.cbx_filter_category.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_filter_category.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_filter_category.BorderColor = System.Drawing.Color.Silver;
            this.cbx_filter_category.BorderRadius = 8;
            this.cbx_filter_category.BorderSize = 1;
            this.cbx_filter_category.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_filter_category.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_filter_category.DropDownSelectedBackColor = System.Drawing.Color.Silver;
            this.cbx_filter_category.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_filter_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_filter_category.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.cbx_filter_category.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_filter_category.Location = new System.Drawing.Point(13, 16);
            this.cbx_filter_category.MinimumSize = new System.Drawing.Size(80, 30);
            this.cbx_filter_category.Name = "cbx_filter_category";
            this.cbx_filter_category.SelectedItem = null;
            this.cbx_filter_category.SelectedValue = null;
            this.cbx_filter_category.Size = new System.Drawing.Size(188, 34);
            this.cbx_filter_category.TabIndex = 0;
            this.cbx_filter_category.SelectedIndexChanged += new System.EventHandler(this.cbx_filter_category_SelectedIndexChanged);
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customRoundedPanel1.BackColor = System.Drawing.Color.White;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 5;
            this.customRoundedPanel1.BorderSize = 2;
            this.customRoundedPanel1.Controls.Add(this.fl_medoc);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(12, 205);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 14);
            this.customRoundedPanel1.ShadowBlur = 10;
            this.customRoundedPanel1.ShadowBorderRadius = -1;
            this.customRoundedPanel1.ShadowColor = System.Drawing.Color.Black;
            this.customRoundedPanel1.ShadowEnabled = true;
            this.customRoundedPanel1.ShadowOffsetX = 0;
            this.customRoundedPanel1.ShadowOffsetY = 4;
            this.customRoundedPanel1.ShadowOpacity = 60;
            this.customRoundedPanel1.ShadowSpread = 0;
            this.customRoundedPanel1.Size = new System.Drawing.Size(1008, 311);
            this.customRoundedPanel1.TabIndex = 4;
            this.customRoundedPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.customRoundedPanel1_Paint);
            // 
            // fl_medoc
            // 
            this.fl_medoc.AutoScroll = true;
            this.fl_medoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fl_medoc.Location = new System.Drawing.Point(10, 10);
            this.fl_medoc.Name = "fl_medoc";
            this.fl_medoc.Size = new System.Drawing.Size(988, 287);
            this.fl_medoc.TabIndex = 3;
            // 
            // btn_add_med
            // 
            this.btn_add_med.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_add_med.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_add_med.BorderRadius = 8;
            this.btn_add_med.BorderSize = 0;
            this.btn_add_med.ButtonText = "Ajouter";
            this.btn_add_med.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add_med.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_add_med.FlatAppearance.BorderSize = 0;
            this.btn_add_med.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_med.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_med.ForeColor = System.Drawing.Color.White;
            this.btn_add_med.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_add_med.Image = global::Cepima.Properties.Resources.add_25px1;
            this.btn_add_med.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_add_med.Location = new System.Drawing.Point(896, 16);
            this.btn_add_med.Name = "btn_add_med";
            this.btn_add_med.Size = new System.Drawing.Size(120, 34);
            this.btn_add_med.TabIndex = 2;
            this.btn_add_med.Text = "Ajouter";
            this.btn_add_med.TextColor = System.Drawing.Color.White;
            this.btn_add_med.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_add_med.UseVisualStyleBackColor = false;
            this.btn_add_med.Click += new System.EventHandler(this.btn_add_med_Click);
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
            this.tb_search.Location = new System.Drawing.Point(207, 16);
            this.tb_search.MaxLength = 32767;
            this.tb_search.Name = "tb_search";
            this.tb_search.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_search.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_search.PlaceholderText = "Rechercher un produit";
            this.tb_search.Size = new System.Drawing.Size(273, 34);
            this.tb_search.TabIndex = 1;
            this.tb_search.TextChanged += new System.EventHandler(this.tb_search_TextChanged);
            // 
            // UC_stock_pharmacie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.fl_med_category);
            this.Controls.Add(this.cbx_filter_category);
            this.Controls.Add(this.customRoundedPanel1);
            this.Controls.Add(this.btn_add_med);
            this.Controls.Add(this.tb_search);
            this.Name = "UC_stock_pharmacie";
            this.Size = new System.Drawing.Size(1031, 526);
            this.customRoundedPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel1;
        private MyRoundedTextBox tb_search;
        private RoundedButton btn_add_med;
        private System.Windows.Forms.FlowLayoutPanel fl_medoc;
        private MyRoundedComboBox cbx_filter_category;
        private System.Windows.Forms.FlowLayoutPanel fl_med_category;

    }
}
