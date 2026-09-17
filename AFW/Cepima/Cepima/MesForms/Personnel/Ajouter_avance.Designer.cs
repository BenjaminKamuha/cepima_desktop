namespace Cepima.MesForms.Personnel
{
    partial class Ajouter_avance
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
            this.tb_reste = new MyRoundedTextBox();
            this.tb_montantAvance = new MyRoundedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp_date_paiement = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuRoundedPanel1 = new BunifuRoundedPanel();
            this.lblSalaire = new System.Windows.Forms.Label();
            this.lblMois = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPersonnel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bt_start = new RoundedButton();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_avancesDejaRecues = new MyRoundedTextBox();
            this.bunifuRoundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_reste
            // 
            this.tb_reste.BackColor = System.Drawing.Color.White;
            this.tb_reste.BorderColor = System.Drawing.Color.Silver;
            this.tb_reste.BorderRadius = 6;
            this.tb_reste.BorderSize = 1;
            this.tb_reste.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_reste.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_reste.ForeColor = System.Drawing.Color.Black;
            this.tb_reste.Image = null;
            this.tb_reste.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_reste.ImagePadding = 2;
            this.tb_reste.Location = new System.Drawing.Point(40, 442);
            this.tb_reste.MaxLength = 32767;
            this.tb_reste.Name = "tb_reste";
            this.tb_reste.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_reste.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_reste.PlaceholderText = "";
            this.tb_reste.ReadOnly = true;
            this.tb_reste.Size = new System.Drawing.Size(321, 35);
            this.tb_reste.TabIndex = 53;
            // 
            // tb_montantAvance
            // 
            this.tb_montantAvance.BackColor = System.Drawing.Color.White;
            this.tb_montantAvance.BorderColor = System.Drawing.Color.Silver;
            this.tb_montantAvance.BorderRadius = 6;
            this.tb_montantAvance.BorderSize = 1;
            this.tb_montantAvance.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_montantAvance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_montantAvance.ForeColor = System.Drawing.Color.Black;
            this.tb_montantAvance.Image = null;
            this.tb_montantAvance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_montantAvance.ImagePadding = 2;
            this.tb_montantAvance.Location = new System.Drawing.Point(40, 368);
            this.tb_montantAvance.MaxLength = 32767;
            this.tb_montantAvance.Name = "tb_montantAvance";
            this.tb_montantAvance.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_montantAvance.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_montantAvance.PlaceholderText = "";
            this.tb_montantAvance.Size = new System.Drawing.Size(321, 35);
            this.tb_montantAvance.TabIndex = 54;
            this.tb_montantAvance.TextChanged += new System.EventHandler(this.tb_montantAvance_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(48, 422);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 17);
            this.label6.TabIndex = 49;
            this.label6.Text = "Reste disponible : ";
            // 
            // dtp_date_paiement
            // 
            this.dtp_date_paiement.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_date_paiement.Location = new System.Drawing.Point(40, 223);
            this.dtp_date_paiement.Name = "dtp_date_paiement";
            this.dtp_date_paiement.Size = new System.Drawing.Size(320, 27);
            this.dtp_date_paiement.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(48, 348);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 17);
            this.label5.TabIndex = 50;
            this.label5.Text = "Montant  de l\'avance : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(51, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 17);
            this.label8.TabIndex = 51;
            this.label8.Text = "Date de l\'avance : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 23);
            this.label1.TabIndex = 48;
            this.label1.Text = "Ajouter une avance sur salaire";
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.DarkBlue;
            this.bunifuRoundedPanel1.BorderRadius = 8;
            this.bunifuRoundedPanel1.BorderSize = 0;
            this.bunifuRoundedPanel1.Controls.Add(this.lblSalaire);
            this.bunifuRoundedPanel1.Controls.Add(this.lblMois);
            this.bunifuRoundedPanel1.Controls.Add(this.label3);
            this.bunifuRoundedPanel1.Controls.Add(this.lblPersonnel);
            this.bunifuRoundedPanel1.Controls.Add(this.label2);
            this.bunifuRoundedPanel1.Controls.Add(this.label4);
            this.bunifuRoundedPanel1.Controls.Add(this.pictureBox1);
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(4, 1);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 15;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(428, 144);
            this.bunifuRoundedPanel1.TabIndex = 47;
            // 
            // lblSalaire
            // 
            this.lblSalaire.AutoSize = true;
            this.lblSalaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblSalaire.Location = new System.Drawing.Point(197, 105);
            this.lblSalaire.Name = "lblSalaire";
            this.lblSalaire.Size = new System.Drawing.Size(50, 17);
            this.lblSalaire.TabIndex = 3;
            this.lblSalaire.Text = "salaire";
            // 
            // lblMois
            // 
            this.lblMois.AutoSize = true;
            this.lblMois.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblMois.Location = new System.Drawing.Point(197, 62);
            this.lblMois.Name = "lblMois";
            this.lblMois.Size = new System.Drawing.Size(36, 17);
            this.lblMois.TabIndex = 4;
            this.lblMois.Text = "Paul";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(120, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Salaire  : ";
            // 
            // lblPersonnel
            // 
            this.lblPersonnel.AutoSize = true;
            this.lblPersonnel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPersonnel.Location = new System.Drawing.Point(197, 22);
            this.lblPersonnel.Name = "lblPersonnel";
            this.lblPersonnel.Size = new System.Drawing.Size(39, 17);
            this.lblPersonnel.TabIndex = 6;
            this.lblPersonnel.Text = "Jean";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(120, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mois : ";
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
            this.bt_start.ButtonText = "Enregistrer  une avance";
            this.bt_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_start.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_start.FlatAppearance.BorderSize = 0;
            this.bt_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_start.ForeColor = System.Drawing.Color.White;
            this.bt_start.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_start.Image = global::Cepima.Properties.Resources.save_30px;
            this.bt_start.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_start.Location = new System.Drawing.Point(75, 515);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(255, 40);
            this.bt_start.TabIndex = 55;
            this.bt_start.Text = "Enregistrer  une avance";
            this.bt_start.TextColor = System.Drawing.Color.White;
            this.bt_start.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_start.UseVisualStyleBackColor = false;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(48, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 17);
            this.label7.TabIndex = 49;
            this.label7.Text = "Avances déjà réçues: ";
            // 
            // tb_avancesDejaRecues
            // 
            this.tb_avancesDejaRecues.BackColor = System.Drawing.Color.White;
            this.tb_avancesDejaRecues.BorderColor = System.Drawing.Color.Silver;
            this.tb_avancesDejaRecues.BorderRadius = 6;
            this.tb_avancesDejaRecues.BorderSize = 1;
            this.tb_avancesDejaRecues.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_avancesDejaRecues.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_avancesDejaRecues.ForeColor = System.Drawing.Color.Black;
            this.tb_avancesDejaRecues.Image = null;
            this.tb_avancesDejaRecues.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_avancesDejaRecues.ImagePadding = 2;
            this.tb_avancesDejaRecues.Location = new System.Drawing.Point(40, 293);
            this.tb_avancesDejaRecues.MaxLength = 32767;
            this.tb_avancesDejaRecues.Name = "tb_avancesDejaRecues";
            this.tb_avancesDejaRecues.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_avancesDejaRecues.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_avancesDejaRecues.PlaceholderText = "";
            this.tb_avancesDejaRecues.ReadOnly = true;
            this.tb_avancesDejaRecues.Size = new System.Drawing.Size(320, 35);
            this.tb_avancesDejaRecues.TabIndex = 53;
            // 
            // Ajouter_avance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(436, 574);
            this.Controls.Add(this.bt_start);
            this.Controls.Add(this.tb_avancesDejaRecues);
            this.Controls.Add(this.tb_reste);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_montantAvance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtp_date_paiement);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Name = "Ajouter_avance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter une avance";
            this.Load += new System.EventHandler(this.Ajouter_avance_Load);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.bunifuRoundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedButton bt_start;
        private MyRoundedTextBox tb_reste;
        private MyRoundedTextBox tb_montantAvance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_date_paiement;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.Label lblSalaire;
        private System.Windows.Forms.Label lblMois;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPersonnel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private MyRoundedTextBox tb_avancesDejaRecues;
    }
}