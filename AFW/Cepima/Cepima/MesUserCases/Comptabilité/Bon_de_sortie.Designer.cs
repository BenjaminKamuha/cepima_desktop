namespace Cepima.MesUserCases.Comptabilité
{
    partial class Bon_de_sortie
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
            this.label1 = new System.Windows.Forms.Label();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.panel_bon_sortie = new System.Windows.Forms.FlowLayoutPanel();
            this.lb_not_found = new System.Windows.Forms.Label();
            this.cbx_statut = new MyRoundedComboBox();
            this.tb_search_demande = new MyRoundedTextBox();
            this.bt_add_bon = new RoundedButton();
            this.bt_refresh = new System.Windows.Forms.Button();
            this.customRoundedPanel1.SuspendLayout();
            this.panel_bon_sortie.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(370, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 51;
            this.label1.Text = "Statut : ";
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customRoundedPanel1.BackColor = System.Drawing.Color.White;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 10;
            this.customRoundedPanel1.BorderSize = 2;
            this.customRoundedPanel1.Controls.Add(this.panel_bon_sortie);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(15, 54);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.ShadowBlur = 10;
            this.customRoundedPanel1.ShadowBorderRadius = -1;
            this.customRoundedPanel1.ShadowColor = System.Drawing.Color.Black;
            this.customRoundedPanel1.ShadowEnabled = false;
            this.customRoundedPanel1.ShadowOffsetX = 0;
            this.customRoundedPanel1.ShadowOffsetY = 4;
            this.customRoundedPanel1.ShadowOpacity = 60;
            this.customRoundedPanel1.ShadowSpread = 0;
            this.customRoundedPanel1.Size = new System.Drawing.Size(1003, 462);
            this.customRoundedPanel1.TabIndex = 53;
            // 
            // panel_bon_sortie
            // 
            this.panel_bon_sortie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_bon_sortie.Controls.Add(this.lb_not_found);
            this.panel_bon_sortie.Location = new System.Drawing.Point(3, 10);
            this.panel_bon_sortie.Name = "panel_bon_sortie";
            this.panel_bon_sortie.Size = new System.Drawing.Size(997, 444);
            this.panel_bon_sortie.TabIndex = 1;
            // 
            // lb_not_found
            // 
            this.lb_not_found.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_not_found.AutoSize = true;
            this.lb_not_found.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_not_found.Location = new System.Drawing.Point(3, 0);
            this.lb_not_found.Name = "lb_not_found";
            this.lb_not_found.Padding = new System.Windows.Forms.Padding(400, 250, 0, 0);
            this.lb_not_found.Size = new System.Drawing.Size(400, 270);
            this.lb_not_found.TabIndex = 6;
            // 
            // cbx_statut
            // 
            this.cbx_statut.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbx_statut.ArrowColor = System.Drawing.Color.Silver;
            this.cbx_statut.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_statut.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_statut.BorderColor = System.Drawing.Color.Silver;
            this.cbx_statut.BorderRadius = 8;
            this.cbx_statut.BorderSize = 1;
            this.cbx_statut.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_statut.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_statut.DropDownSelectedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.cbx_statut.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_statut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_statut.FocusBorderColor = System.Drawing.Color.Silver;
            this.cbx_statut.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_statut.Location = new System.Drawing.Point(454, 18);
            this.cbx_statut.Name = "cbx_statut";
            this.cbx_statut.SelectedItem = null;
            this.cbx_statut.SelectedValue = null;
            this.cbx_statut.Size = new System.Drawing.Size(205, 30);
            this.cbx_statut.TabIndex = 50;
            this.cbx_statut.SelectedIndexChanged += new System.EventHandler(this.cbx_statut_SelectedIndexChanged);
            // 
            // tb_search_demande
            // 
            this.tb_search_demande.BackColor = System.Drawing.Color.White;
            this.tb_search_demande.BorderColor = System.Drawing.Color.Silver;
            this.tb_search_demande.BorderRadius = 8;
            this.tb_search_demande.BorderSize = 1;
            this.tb_search_demande.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_search_demande.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.tb_search_demande.ForeColor = System.Drawing.Color.Black;
            this.tb_search_demande.Image = global::Cepima.Properties.Resources.search_25px;
            this.tb_search_demande.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_search_demande.ImagePadding = 4;
            this.tb_search_demande.Location = new System.Drawing.Point(18, 14);
            this.tb_search_demande.MaxLength = 32767;
            this.tb_search_demande.Name = "tb_search_demande";
            this.tb_search_demande.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_search_demande.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_search_demande.PlaceholderText = "Rechercher un responsable";
            this.tb_search_demande.Size = new System.Drawing.Size(273, 34);
            this.tb_search_demande.TabIndex = 54;
            this.tb_search_demande.TextChanged += new System.EventHandler(this.tb_search_demande_TextChanged);
            // 
            // bt_add_bon
            // 
            this.bt_add_bon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_add_bon.BackColor = System.Drawing.Color.Transparent;
            this.bt_add_bon.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_add_bon.BorderRadius = 10;
            this.bt_add_bon.ButtonText = "Nouveau Bon de sorti";
            this.bt_add_bon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_add_bon.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_add_bon.FlatAppearance.BorderSize = 0;
            this.bt_add_bon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_add_bon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_add_bon.ForeColor = System.Drawing.Color.White;
            this.bt_add_bon.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_add_bon.Image = global::Cepima.Properties.Resources.add_25px1;
            this.bt_add_bon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_add_bon.Location = new System.Drawing.Point(777, 10);
            this.bt_add_bon.Name = "bt_add_bon";
            this.bt_add_bon.Size = new System.Drawing.Size(232, 38);
            this.bt_add_bon.TabIndex = 52;
            this.bt_add_bon.Text = "Nouveau Bon de sorti";
            this.bt_add_bon.TextColor = System.Drawing.Color.White;
            this.bt_add_bon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_add_bon.UseVisualStyleBackColor = false;
            this.bt_add_bon.Click += new System.EventHandler(this.bt_add_bon_Click);
            // 
            // bt_refresh
            // 
            this.bt_refresh.FlatAppearance.BorderSize = 0;
            this.bt_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_refresh.Location = new System.Drawing.Point(699, 25);
            this.bt_refresh.Name = "bt_refresh";
            this.bt_refresh.Size = new System.Drawing.Size(10, 23);
            this.bt_refresh.TabIndex = 7;
            this.bt_refresh.UseVisualStyleBackColor = true;
            this.bt_refresh.Click += new System.EventHandler(this.bt_refresh_Click);
            // 
            // Bon_de_sortie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tb_search_demande);
            this.Controls.Add(this.bt_refresh);
            this.Controls.Add(this.customRoundedPanel1);
            this.Controls.Add(this.bt_add_bon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbx_statut);
            this.Name = "Bon_de_sortie";
            this.Size = new System.Drawing.Size(1021, 519);
            this.Load += new System.EventHandler(this.Bon_de_sortie_Load);
            this.customRoundedPanel1.ResumeLayout(false);
            this.panel_bon_sortie.ResumeLayout(false);
            this.panel_bon_sortie.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyRoundedComboBox cbx_statut;
        private System.Windows.Forms.Label label1;
        private RoundedButton bt_add_bon;
        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.FlowLayoutPanel panel_bon_sortie;
        private MyRoundedTextBox tb_search_demande;
        private System.Windows.Forms.Label lb_not_found;
        private System.Windows.Forms.Button bt_refresh;

    }
}
