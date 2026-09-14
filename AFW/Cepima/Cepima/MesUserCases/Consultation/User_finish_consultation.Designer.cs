namespace Cepima.MesUserCases
{
    partial class User_finish_consultation
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
            this.bunifuRoundedPanel1 = new BunifuRoundedPanel();
            this.flow_consultation = new System.Windows.Forms.FlowLayoutPanel();
            this.lb_not_found = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.combo_statut = new MyRoundedComboBox();
            this.lb_nombres_consultation = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tb_recherche_chambre = new MyRoundedTextBox();
            this.bunifuRoundedPanel1.SuspendLayout();
            this.flow_consultation.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.DarkBlue;
            this.bunifuRoundedPanel1.BorderRadius = 8;
            this.bunifuRoundedPanel1.BorderSize = 0;
            this.bunifuRoundedPanel1.Controls.Add(this.flow_consultation);
            this.bunifuRoundedPanel1.Controls.Add(this.panel1);
            this.bunifuRoundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 10;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(1057, 573);
            this.bunifuRoundedPanel1.TabIndex = 1;
            // 
            // flow_consultation
            // 
            this.flow_consultation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flow_consultation.AutoScroll = true;
            this.flow_consultation.Controls.Add(this.lb_not_found);
            this.flow_consultation.Location = new System.Drawing.Point(13, 79);
            this.flow_consultation.Name = "flow_consultation";
            this.flow_consultation.Size = new System.Drawing.Size(1030, 486);
            this.flow_consultation.TabIndex = 1;
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.combo_statut);
            this.panel1.Controls.Add(this.lb_nombres_consultation);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.tb_recherche_chambre);
            this.panel1.Location = new System.Drawing.Point(13, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 62);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(455, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 39;
            this.label7.Text = "Période  : ";
            // 
            // combo_statut
            // 
            this.combo_statut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_statut.ArrowColor = System.Drawing.SystemColors.ActiveCaption;
            this.combo_statut.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.combo_statut.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.combo_statut.BorderColor = System.Drawing.Color.Silver;
            this.combo_statut.BorderRadius = 6;
            this.combo_statut.BorderSize = 1;
            this.combo_statut.DropDownBackColor = System.Drawing.Color.White;
            this.combo_statut.DropDownForeColor = System.Drawing.Color.Black;
            this.combo_statut.DropDownSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.combo_statut.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.combo_statut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_statut.FocusBorderColor = System.Drawing.Color.Silver;
            this.combo_statut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.combo_statut.Location = new System.Drawing.Point(556, 15);
            this.combo_statut.Name = "combo_statut";
            this.combo_statut.SelectedItem = null;
            this.combo_statut.SelectedValue = null;
            this.combo_statut.Size = new System.Drawing.Size(211, 30);
            this.combo_statut.TabIndex = 40;
            this.combo_statut.SelectedIndexChanged += new System.EventHandler(this.combo_statut_SelectedIndexChanged);
            // 
            // lb_nombres_consultation
            // 
            this.lb_nombres_consultation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_nombres_consultation.AutoSize = true;
            this.lb_nombres_consultation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nombres_consultation.Location = new System.Drawing.Point(896, 29);
            this.lb_nombres_consultation.Name = "lb_nombres_consultation";
            this.lb_nombres_consultation.Size = new System.Drawing.Size(24, 16);
            this.lb_nombres_consultation.TabIndex = 38;
            this.lb_nombres_consultation.Text = "34";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1030, 4);
            this.panel2.TabIndex = 7;
            // 
            // tb_recherche_chambre
            // 
            this.tb_recherche_chambre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_recherche_chambre.BackColor = System.Drawing.Color.White;
            this.tb_recherche_chambre.BorderColor = System.Drawing.Color.Silver;
            this.tb_recherche_chambre.BorderRadius = 8;
            this.tb_recherche_chambre.BorderSize = 1;
            this.tb_recherche_chambre.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_recherche_chambre.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.tb_recherche_chambre.ForeColor = System.Drawing.Color.Black;
            this.tb_recherche_chambre.Image = global::Cepima.Properties.Resources.search_25px;
            this.tb_recherche_chambre.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_recherche_chambre.ImagePadding = 4;
            this.tb_recherche_chambre.Location = new System.Drawing.Point(3, 15);
            this.tb_recherche_chambre.MaxLength = 32767;
            this.tb_recherche_chambre.Name = "tb_recherche_chambre";
            this.tb_recherche_chambre.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_recherche_chambre.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_recherche_chambre.PlaceholderText = "Search room";
            this.tb_recherche_chambre.Size = new System.Drawing.Size(256, 34);
            this.tb_recherche_chambre.TabIndex = 11;
            this.tb_recherche_chambre.TextChanged += new System.EventHandler(this.tb_recherche_chambre_TextChanged);
            // 
            // User_finish_consultation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Name = "User_finish_consultation";
            this.Size = new System.Drawing.Size(1057, 573);
            this.Load += new System.EventHandler(this.User_finish_consultation_Load);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.flow_consultation.ResumeLayout(false);
            this.flow_consultation.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.FlowLayoutPanel flow_consultation;
        private System.Windows.Forms.Label lb_not_found;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_nombres_consultation;
        private System.Windows.Forms.Panel panel2;
        private MyRoundedTextBox tb_recherche_chambre;
        private System.Windows.Forms.Label label7;
        private MyRoundedComboBox combo_statut;

    }
}
