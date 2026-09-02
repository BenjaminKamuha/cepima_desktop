namespace Cepima.MesUserCases.Pharmacie
{
    partial class UC_inventory
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
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.btn_new_inventory = new RoundedButton();
            this.tb_search = new MyRoundedTextBox();
            this.cbx_filter_category = new MyRoundedComboBox();
            this.btnRetourInventaires = new RoundedButton();
            this.btnValiderInventaire = new RoundedButton();
            this.SuspendLayout();
            // 
            // fl_med_category
            // 
            this.fl_med_category.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fl_med_category.AutoScroll = true;
            this.fl_med_category.BackColor = System.Drawing.Color.White;
            this.fl_med_category.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fl_med_category.Location = new System.Drawing.Point(12, 62);
            this.fl_med_category.Name = "fl_med_category";
            this.fl_med_category.Size = new System.Drawing.Size(1003, 121);
            this.fl_med_category.TabIndex = 10;
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
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(11, 202);
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
            this.customRoundedPanel1.Size = new System.Drawing.Size(1008, 235);
            this.customRoundedPanel1.TabIndex = 9;
            // 
            // btn_new_inventory
            // 
            this.btn_new_inventory.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_new_inventory.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_new_inventory.BorderRadius = 8;
            this.btn_new_inventory.BorderSize = 0;
            this.btn_new_inventory.ButtonText = "Nouvelle inventaire";
            this.btn_new_inventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_new_inventory.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_new_inventory.FlatAppearance.BorderSize = 0;
            this.btn_new_inventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_new_inventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_inventory.ForeColor = System.Drawing.Color.White;
            this.btn_new_inventory.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_new_inventory.Image = global::Cepima.Properties.Resources.add_25px1;
            this.btn_new_inventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_new_inventory.Location = new System.Drawing.Point(777, 11);
            this.btn_new_inventory.Name = "btn_new_inventory";
            this.btn_new_inventory.Size = new System.Drawing.Size(233, 43);
            this.btn_new_inventory.TabIndex = 8;
            this.btn_new_inventory.Text = "Nouvelle inventaire";
            this.btn_new_inventory.TextColor = System.Drawing.Color.White;
            this.btn_new_inventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_new_inventory.UseVisualStyleBackColor = false;
            this.btn_new_inventory.Click += new System.EventHandler(this.btn_new_inventory_Click);
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
            this.tb_search.Location = new System.Drawing.Point(206, 13);
            this.tb_search.MaxLength = 32767;
            this.tb_search.Name = "tb_search";
            this.tb_search.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_search.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_search.PlaceholderText = "Rechercher un produit";
            this.tb_search.Size = new System.Drawing.Size(273, 31);
            this.tb_search.TabIndex = 7;
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
            this.cbx_filter_category.Location = new System.Drawing.Point(12, 13);
            this.cbx_filter_category.MinimumSize = new System.Drawing.Size(80, 30);
            this.cbx_filter_category.Name = "cbx_filter_category";
            this.cbx_filter_category.SelectedItem = null;
            this.cbx_filter_category.SelectedValue = null;
            this.cbx_filter_category.Size = new System.Drawing.Size(188, 31);
            this.cbx_filter_category.TabIndex = 6;
            // 
            // btnRetourInventaires
            // 
            this.btnRetourInventaires.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetourInventaires.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRetourInventaires.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRetourInventaires.BorderRadius = 8;
            this.btnRetourInventaires.BorderSize = 0;
            this.btnRetourInventaires.ButtonText = "Retour";
            this.btnRetourInventaires.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetourInventaires.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btnRetourInventaires.FlatAppearance.BorderSize = 0;
            this.btnRetourInventaires.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetourInventaires.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetourInventaires.ForeColor = System.Drawing.Color.White;
            this.btnRetourInventaires.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btnRetourInventaires.Image = global::Cepima.Properties.Resources.return_30px;
            this.btnRetourInventaires.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRetourInventaires.Location = new System.Drawing.Point(12, 467);
            this.btnRetourInventaires.Name = "btnRetourInventaires";
            this.btnRetourInventaires.Size = new System.Drawing.Size(233, 43);
            this.btnRetourInventaires.TabIndex = 11;
            this.btnRetourInventaires.Text = "Retour";
            this.btnRetourInventaires.TextColor = System.Drawing.Color.White;
            this.btnRetourInventaires.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRetourInventaires.UseVisualStyleBackColor = false;
            this.btnRetourInventaires.Click += new System.EventHandler(this.btnRetourInventaires_Click);
            // 
            // btnValiderInventaire
            // 
            this.btnValiderInventaire.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValiderInventaire.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnValiderInventaire.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnValiderInventaire.BorderRadius = 8;
            this.btnValiderInventaire.BorderSize = 0;
            this.btnValiderInventaire.ButtonText = "Valider l\'inventaire";
            this.btnValiderInventaire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnValiderInventaire.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btnValiderInventaire.FlatAppearance.BorderSize = 0;
            this.btnValiderInventaire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValiderInventaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValiderInventaire.ForeColor = System.Drawing.Color.White;
            this.btnValiderInventaire.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btnValiderInventaire.Image = global::Cepima.Properties.Resources.ok_30px1;
            this.btnValiderInventaire.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnValiderInventaire.Location = new System.Drawing.Point(798, 467);
            this.btnValiderInventaire.Name = "btnValiderInventaire";
            this.btnValiderInventaire.Size = new System.Drawing.Size(233, 43);
            this.btnValiderInventaire.TabIndex = 12;
            this.btnValiderInventaire.Text = "Valider l\'inventaire";
            this.btnValiderInventaire.TextColor = System.Drawing.Color.White;
            this.btnValiderInventaire.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnValiderInventaire.UseVisualStyleBackColor = false;
            this.btnValiderInventaire.Click += new System.EventHandler(this.btnValiderInventaire_Click);
            // 
            // UC_inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnValiderInventaire);
            this.Controls.Add(this.btnRetourInventaires);
            this.Controls.Add(this.fl_med_category);
            this.Controls.Add(this.cbx_filter_category);
            this.Controls.Add(this.customRoundedPanel1);
            this.Controls.Add(this.btn_new_inventory);
            this.Controls.Add(this.tb_search);
            this.Name = "UC_inventory";
            this.Size = new System.Drawing.Size(1031, 526);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fl_med_category;
        private CustomRoundedPanel customRoundedPanel1;
        private RoundedButton btn_new_inventory;
        private MyRoundedTextBox tb_search;
        private MyRoundedComboBox cbx_filter_category;
        private RoundedButton btnRetourInventaires;
        private RoundedButton btnValiderInventaire;
    }
}
