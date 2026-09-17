namespace Cepima.MesForms.Personnel
{
    partial class Add_salaire
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtp_date_paiement = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_salaire = new MyRoundedTextBox();
            this.cbx_statut = new MyRoundedComboBox();
            this.cbx_mois = new MyRoundedComboBox();
            this.bunifuRoundedPanel1 = new BunifuRoundedPanel();
            this.lb_age = new System.Windows.Forms.Label();
            this.lb_postnom = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_fonction = new System.Windows.Forms.Label();
            this.lb_nom = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bt_start = new RoundedButton();
            this.bunifuRoundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(142, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ajouter un salaire du personnel";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(15, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Mois  : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(12, 312);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Salaire de base  : ";
            // 
            // dtp_date_paiement
            // 
            this.dtp_date_paiement.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_date_paiement.Location = new System.Drawing.Point(159, 376);
            this.dtp_date_paiement.Name = "dtp_date_paiement";
            this.dtp_date_paiement.Size = new System.Drawing.Size(285, 27);
            this.dtp_date_paiement.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(15, 384);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Date paiement  : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(15, 452);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Statut  : ";
            // 
            // tb_salaire
            // 
            this.tb_salaire.BackColor = System.Drawing.Color.White;
            this.tb_salaire.BorderColor = System.Drawing.Color.Silver;
            this.tb_salaire.BorderRadius = 6;
            this.tb_salaire.BorderSize = 1;
            this.tb_salaire.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_salaire.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_salaire.ForeColor = System.Drawing.Color.Black;
            this.tb_salaire.Image = null;
            this.tb_salaire.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_salaire.ImagePadding = 2;
            this.tb_salaire.Location = new System.Drawing.Point(159, 299);
            this.tb_salaire.MaxLength = 32767;
            this.tb_salaire.Name = "tb_salaire";
            this.tb_salaire.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_salaire.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_salaire.PlaceholderText = "20 par exemple";
            this.tb_salaire.Size = new System.Drawing.Size(285, 30);
            this.tb_salaire.TabIndex = 9;
            // 
            // cbx_statut
            // 
            this.cbx_statut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_statut.ArrowColor = System.Drawing.SystemColors.ActiveCaption;
            this.cbx_statut.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_statut.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_statut.BorderColor = System.Drawing.Color.Silver;
            this.cbx_statut.BorderRadius = 6;
            this.cbx_statut.BorderSize = 1;
            this.cbx_statut.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_statut.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_statut.DropDownSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.cbx_statut.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_statut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_statut.FocusBorderColor = System.Drawing.Color.Silver;
            this.cbx_statut.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_statut.Location = new System.Drawing.Point(159, 441);
            this.cbx_statut.Name = "cbx_statut";
            this.cbx_statut.SelectedItem = null;
            this.cbx_statut.SelectedValue = null;
            this.cbx_statut.Size = new System.Drawing.Size(285, 28);
            this.cbx_statut.TabIndex = 3;
            // 
            // cbx_mois
            // 
            this.cbx_mois.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_mois.ArrowColor = System.Drawing.SystemColors.ActiveCaption;
            this.cbx_mois.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_mois.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_mois.BorderColor = System.Drawing.Color.Silver;
            this.cbx_mois.BorderRadius = 6;
            this.cbx_mois.BorderSize = 1;
            this.cbx_mois.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_mois.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_mois.DropDownSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.cbx_mois.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_mois.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_mois.FocusBorderColor = System.Drawing.Color.Silver;
            this.cbx_mois.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_mois.Location = new System.Drawing.Point(159, 228);
            this.cbx_mois.Name = "cbx_mois";
            this.cbx_mois.SelectedItem = null;
            this.cbx_mois.SelectedValue = null;
            this.cbx_mois.Size = new System.Drawing.Size(285, 28);
            this.cbx_mois.TabIndex = 3;
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.DarkBlue;
            this.bunifuRoundedPanel1.BorderRadius = 8;
            this.bunifuRoundedPanel1.BorderSize = 0;
            this.bunifuRoundedPanel1.Controls.Add(this.lb_age);
            this.bunifuRoundedPanel1.Controls.Add(this.lb_postnom);
            this.bunifuRoundedPanel1.Controls.Add(this.label3);
            this.bunifuRoundedPanel1.Controls.Add(this.lb_fonction);
            this.bunifuRoundedPanel1.Controls.Add(this.lb_nom);
            this.bunifuRoundedPanel1.Controls.Add(this.label5);
            this.bunifuRoundedPanel1.Controls.Add(this.label2);
            this.bunifuRoundedPanel1.Controls.Add(this.label4);
            this.bunifuRoundedPanel1.Controls.Add(this.pictureBox1);
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(5, 7);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 15;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(533, 144);
            this.bunifuRoundedPanel1.TabIndex = 0;
            // 
            // lb_age
            // 
            this.lb_age.AutoSize = true;
            this.lb_age.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lb_age.Location = new System.Drawing.Point(215, 105);
            this.lb_age.Name = "lb_age";
            this.lb_age.Size = new System.Drawing.Size(112, 17);
            this.lb_age.TabIndex = 3;
            this.lb_age.Text = "45 ans - Homme";
            // 
            // lb_postnom
            // 
            this.lb_postnom.AutoSize = true;
            this.lb_postnom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lb_postnom.Location = new System.Drawing.Point(215, 62);
            this.lb_postnom.Name = "lb_postnom";
            this.lb_postnom.Size = new System.Drawing.Size(36, 17);
            this.lb_postnom.TabIndex = 4;
            this.lb_postnom.Text = "Paul";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(120, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Age - Sexe : ";
            // 
            // lb_fonction
            // 
            this.lb_fonction.AutoSize = true;
            this.lb_fonction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lb_fonction.Location = new System.Drawing.Point(438, 62);
            this.lb_fonction.Name = "lb_fonction";
            this.lb_fonction.Size = new System.Drawing.Size(56, 17);
            this.lb_fonction.TabIndex = 6;
            this.lb_fonction.Text = "Aucune";
            // 
            // lb_nom
            // 
            this.lb_nom.AutoSize = true;
            this.lb_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lb_nom.Location = new System.Drawing.Point(215, 22);
            this.lb_nom.Name = "lb_nom";
            this.lb_nom.Size = new System.Drawing.Size(39, 17);
            this.lb_nom.TabIndex = 6;
            this.lb_nom.Text = "Jean";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(365, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fonction : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(120, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Post_Nom : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(120, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nom  : ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(13, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bt_start
            // 
            this.bt_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_start.BackColor = System.Drawing.Color.Transparent;
            this.bt_start.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_start.BorderRadius = 8;
            this.bt_start.ButtonText = "Enregistrer  le salaire";
            this.bt_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_start.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_start.FlatAppearance.BorderSize = 0;
            this.bt_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_start.ForeColor = System.Drawing.Color.White;
            this.bt_start.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_start.Image = global::Cepima.Properties.Resources.save_30px;
            this.bt_start.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_start.Location = new System.Drawing.Point(154, 511);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(255, 40);
            this.bt_start.TabIndex = 37;
            this.bt_start.Text = "Enregistrer  le salaire";
            this.bt_start.TextColor = System.Drawing.Color.White;
            this.bt_start.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_start.UseVisualStyleBackColor = false;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // Add_salaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(544, 563);
            this.Controls.Add(this.bt_start);
            this.Controls.Add(this.dtp_date_paiement);
            this.Controls.Add(this.tb_salaire);
            this.Controls.Add(this.cbx_statut);
            this.Controls.Add(this.cbx_mois);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Name = "Add_salaire";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter un salaire";
            this.Load += new System.EventHandler(this.Add_salaire_Load);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.bunifuRoundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_age;
        private System.Windows.Forms.Label lb_postnom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_nom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_fonction;
        private System.Windows.Forms.Label label5;
        private MyRoundedComboBox cbx_mois;
        private System.Windows.Forms.Label label6;
        private MyRoundedTextBox tb_salaire;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtp_date_paiement;
        private System.Windows.Forms.Label label8;
        private RoundedButton bt_start;
        private System.Windows.Forms.Label label9;
        private MyRoundedComboBox cbx_statut;
    }
}