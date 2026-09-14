namespace Cepima.MesUserCases.Hospitalisation
{
    partial class User_chambre
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
            this.flow_chambres = new System.Windows.Forms.FlowLayoutPanel();
            this.lb_not_found = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_nombres_chambres = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rb_suspendu = new System.Windows.Forms.RadioButton();
            this.rb_libre = new System.Windows.Forms.RadioButton();
            this.rb_occupe = new System.Windows.Forms.RadioButton();
            this.rb_tous = new System.Windows.Forms.RadioButton();
            this.bt_add_chambre = new RoundedButton();
            this.tb_recherche_chambre = new MyRoundedTextBox();
            this.bunifuRoundedPanel1.SuspendLayout();
            this.flow_chambres.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.DarkBlue;
            this.bunifuRoundedPanel1.BorderRadius = 8;
            this.bunifuRoundedPanel1.BorderSize = 0;
            this.bunifuRoundedPanel1.Controls.Add(this.flow_chambres);
            this.bunifuRoundedPanel1.Controls.Add(this.panel1);
            this.bunifuRoundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 10;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(1057, 573);
            this.bunifuRoundedPanel1.TabIndex = 0;
            // 
            // flow_chambres
            // 
            this.flow_chambres.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flow_chambres.AutoScroll = true;
            this.flow_chambres.Controls.Add(this.lb_not_found);
            this.flow_chambres.Location = new System.Drawing.Point(13, 79);
            this.flow_chambres.Name = "flow_chambres";
            this.flow_chambres.Size = new System.Drawing.Size(1030, 486);
            this.flow_chambres.TabIndex = 1;
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
            this.panel1.Controls.Add(this.lb_nombres_chambres);
            this.panel1.Controls.Add(this.bt_add_chambre);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.rb_suspendu);
            this.panel1.Controls.Add(this.rb_libre);
            this.panel1.Controls.Add(this.rb_occupe);
            this.panel1.Controls.Add(this.rb_tous);
            this.panel1.Controls.Add(this.tb_recherche_chambre);
            this.panel1.Location = new System.Drawing.Point(13, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 62);
            this.panel1.TabIndex = 0;
            // 
            // lb_nombres_chambres
            // 
            this.lb_nombres_chambres.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_nombres_chambres.AutoSize = true;
            this.lb_nombres_chambres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nombres_chambres.Location = new System.Drawing.Point(839, 31);
            this.lb_nombres_chambres.Name = "lb_nombres_chambres";
            this.lb_nombres_chambres.Size = new System.Drawing.Size(24, 16);
            this.lb_nombres_chambres.TabIndex = 38;
            this.lb_nombres_chambres.Text = "34";
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
            // rb_suspendu
            // 
            this.rb_suspendu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rb_suspendu.AutoSize = true;
            this.rb_suspendu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_suspendu.Location = new System.Drawing.Point(683, 29);
            this.rb_suspendu.Name = "rb_suspendu";
            this.rb_suspendu.Size = new System.Drawing.Size(112, 20);
            this.rb_suspendu.TabIndex = 12;
            this.rb_suspendu.TabStop = true;
            this.rb_suspendu.Text = "Supsendues";
            this.rb_suspendu.UseVisualStyleBackColor = true;
            this.rb_suspendu.CheckedChanged += new System.EventHandler(this.rb_suspendu_CheckedChanged);
            // 
            // rb_libre
            // 
            this.rb_libre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rb_libre.AutoSize = true;
            this.rb_libre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_libre.Location = new System.Drawing.Point(557, 29);
            this.rb_libre.Name = "rb_libre";
            this.rb_libre.Size = new System.Drawing.Size(69, 20);
            this.rb_libre.TabIndex = 12;
            this.rb_libre.TabStop = true;
            this.rb_libre.Text = "Libres";
            this.rb_libre.UseVisualStyleBackColor = true;
            this.rb_libre.CheckedChanged += new System.EventHandler(this.rb_libre_CheckedChanged);
            // 
            // rb_occupe
            // 
            this.rb_occupe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rb_occupe.AutoSize = true;
            this.rb_occupe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_occupe.Location = new System.Drawing.Point(404, 29);
            this.rb_occupe.Name = "rb_occupe";
            this.rb_occupe.Size = new System.Drawing.Size(96, 20);
            this.rb_occupe.TabIndex = 12;
            this.rb_occupe.TabStop = true;
            this.rb_occupe.Text = "Occupées";
            this.rb_occupe.UseVisualStyleBackColor = true;
            this.rb_occupe.CheckedChanged += new System.EventHandler(this.rb_occupe_CheckedChanged);
            // 
            // rb_tous
            // 
            this.rb_tous.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rb_tous.AutoSize = true;
            this.rb_tous.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_tous.Location = new System.Drawing.Point(286, 29);
            this.rb_tous.Name = "rb_tous";
            this.rb_tous.Size = new System.Drawing.Size(61, 20);
            this.rb_tous.TabIndex = 12;
            this.rb_tous.TabStop = true;
            this.rb_tous.Text = "Tous";
            this.rb_tous.UseVisualStyleBackColor = true;
            this.rb_tous.CheckedChanged += new System.EventHandler(this.rb_tous_CheckedChanged);
            // 
            // bt_add_chambre
            // 
            this.bt_add_chambre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_add_chambre.BackColor = System.Drawing.Color.Transparent;
            this.bt_add_chambre.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_add_chambre.BorderRadius = 8;
            this.bt_add_chambre.ButtonText = "Ajouter";
            this.bt_add_chambre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_add_chambre.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_add_chambre.FlatAppearance.BorderSize = 0;
            this.bt_add_chambre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_add_chambre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_add_chambre.ForeColor = System.Drawing.Color.White;
            this.bt_add_chambre.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_add_chambre.Image = global::Cepima.Properties.Resources.add_30px;
            this.bt_add_chambre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_add_chambre.Location = new System.Drawing.Point(911, 15);
            this.bt_add_chambre.Name = "bt_add_chambre";
            this.bt_add_chambre.Size = new System.Drawing.Size(109, 35);
            this.bt_add_chambre.TabIndex = 37;
            this.bt_add_chambre.Text = "Ajouter";
            this.bt_add_chambre.TextColor = System.Drawing.Color.White;
            this.bt_add_chambre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_add_chambre.UseVisualStyleBackColor = false;
            this.bt_add_chambre.Click += new System.EventHandler(this.bt_add_chambre_Click);
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
            // User_chambre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Name = "User_chambre";
            this.Size = new System.Drawing.Size(1057, 573);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.flow_chambres.ResumeLayout(false);
            this.flow_chambres.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.Panel panel1;
        private MyRoundedTextBox tb_recherche_chambre;
        private System.Windows.Forms.RadioButton rb_suspendu;
        private System.Windows.Forms.RadioButton rb_libre;
        private System.Windows.Forms.RadioButton rb_occupe;
        private System.Windows.Forms.RadioButton rb_tous;
        private RoundedButton bt_add_chambre;
        private System.Windows.Forms.FlowLayoutPanel flow_chambres;
        private System.Windows.Forms.Label lb_not_found;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb_nombres_chambres;
    }
}
