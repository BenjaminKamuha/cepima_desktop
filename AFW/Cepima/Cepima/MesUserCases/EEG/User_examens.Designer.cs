namespace Cepima.MesUserCases.EEG
{
    partial class User_examens
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
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.cbx_filter_category = new MyRoundedComboBox();
            this.tb_search = new MyRoundedTextBox();
            this.pnl_examen = new System.Windows.Forms.Panel();
            this.customRoundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customRoundedPanel1.BackColor = System.Drawing.Color.White;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 10;
            this.customRoundedPanel1.BorderSize = 2;
            this.customRoundedPanel1.Controls.Add(this.pnl_examen);
            this.customRoundedPanel1.Controls.Add(this.cbx_filter_category);
            this.customRoundedPanel1.Controls.Add(this.tb_search);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(9, 17);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.ShadowBlur = 10;
            this.customRoundedPanel1.ShadowBorderRadius = -1;
            this.customRoundedPanel1.ShadowColor = System.Drawing.Color.Black;
            this.customRoundedPanel1.ShadowEnabled = false;
            this.customRoundedPanel1.ShadowOffsetX = 0;
            this.customRoundedPanel1.ShadowOffsetY = 4;
            this.customRoundedPanel1.ShadowOpacity = 60;
            this.customRoundedPanel1.ShadowSpread = 0;
            this.customRoundedPanel1.Size = new System.Drawing.Size(1003, 485);
            this.customRoundedPanel1.TabIndex = 2;
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
            this.cbx_filter_category.Location = new System.Drawing.Point(11, 17);
            this.cbx_filter_category.MinimumSize = new System.Drawing.Size(80, 30);
            this.cbx_filter_category.Name = "cbx_filter_category";
            this.cbx_filter_category.SelectedItem = null;
            this.cbx_filter_category.SelectedValue = null;
            this.cbx_filter_category.Size = new System.Drawing.Size(188, 34);
            this.cbx_filter_category.TabIndex = 5;
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
            this.tb_search.Location = new System.Drawing.Point(242, 17);
            this.tb_search.MaxLength = 32767;
            this.tb_search.Name = "tb_search";
            this.tb_search.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_search.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_search.PlaceholderText = "Rechercher un produit";
            this.tb_search.Size = new System.Drawing.Size(273, 34);
            this.tb_search.TabIndex = 6;
            // 
            // pnl_examen
            // 
            this.pnl_examen.Location = new System.Drawing.Point(3, 79);
            this.pnl_examen.Name = "pnl_examen";
            this.pnl_examen.Size = new System.Drawing.Size(997, 403);
            this.pnl_examen.TabIndex = 7;
            // 
            // User_examens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.customRoundedPanel1);
            this.Name = "User_examens";
            this.Size = new System.Drawing.Size(1021, 519);
            this.customRoundedPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel1;
        private MyRoundedComboBox cbx_filter_category;
        private MyRoundedTextBox tb_search;
        private System.Windows.Forms.Panel pnl_examen;
    }
}
