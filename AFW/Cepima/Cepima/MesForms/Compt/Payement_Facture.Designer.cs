namespace Cepima.MesForms.Compt
{
    partial class Payement_Facture
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
            this.label2 = new System.Windows.Forms.Label();
            this.bt_valider = new RoundedButton();
            this.tb_montant = new MyRoundedTextBox();
            this.bunifuRoundedPanel1 = new BunifuRoundedPanel();
            this.lb_age = new System.Windows.Forms.Label();
            this.lb_nom = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuRoundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Montant payé : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(336, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "$";
            // 
            // bt_valider
            // 
            this.bt_valider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_valider.BackColor = System.Drawing.Color.Transparent;
            this.bt_valider.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_valider.BorderRadius = 8;
            this.bt_valider.ButtonText = "Enregistrer le paiement";
            this.bt_valider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_valider.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_valider.FlatAppearance.BorderSize = 0;
            this.bt_valider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_valider.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_valider.ForeColor = System.Drawing.Color.White;
            this.bt_valider.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_valider.Image = global::Cepima.Properties.Resources.save_30px;
            this.bt_valider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_valider.Location = new System.Drawing.Point(97, 264);
            this.bt_valider.Name = "bt_valider";
            this.bt_valider.Size = new System.Drawing.Size(211, 43);
            this.bt_valider.TabIndex = 46;
            this.bt_valider.Text = "Enregistrer le paiement";
            this.bt_valider.TextColor = System.Drawing.Color.White;
            this.bt_valider.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_valider.UseVisualStyleBackColor = false;
            this.bt_valider.Click += new System.EventHandler(this.bt_valider_Click);
            // 
            // tb_montant
            // 
            this.tb_montant.BackColor = System.Drawing.Color.White;
            this.tb_montant.BorderColor = System.Drawing.Color.Silver;
            this.tb_montant.BorderRadius = 8;
            this.tb_montant.BorderSize = 1;
            this.tb_montant.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_montant.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.tb_montant.ForeColor = System.Drawing.Color.Black;
            this.tb_montant.Image = null;
            this.tb_montant.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_montant.ImagePadding = 4;
            this.tb_montant.Location = new System.Drawing.Point(57, 189);
            this.tb_montant.MaxLength = 32767;
            this.tb_montant.Name = "tb_montant";
            this.tb_montant.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_montant.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_montant.PlaceholderText = "Entrer lemontant...";
            this.tb_montant.Size = new System.Drawing.Size(273, 34);
            this.tb_montant.TabIndex = 45;
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.Empty;
            this.bunifuRoundedPanel1.BorderRadius = 10;
            this.bunifuRoundedPanel1.BorderSize = 1;
            this.bunifuRoundedPanel1.Controls.Add(this.lb_age);
            this.bunifuRoundedPanel1.Controls.Add(this.lb_nom);
            this.bunifuRoundedPanel1.Controls.Add(this.pictureBox1);
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(2, 3);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 10;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(382, 100);
            this.bunifuRoundedPanel1.TabIndex = 1;
            // 
            // lb_age
            // 
            this.lb_age.AutoSize = true;
            this.lb_age.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_age.Location = new System.Drawing.Point(150, 58);
            this.lb_age.Name = "lb_age";
            this.lb_age.Size = new System.Drawing.Size(126, 20);
            this.lb_age.TabIndex = 2;
            this.lb_age.Text = "32 ans - Homme";
            // 
            // lb_nom
            // 
            this.lb_nom.AutoSize = true;
            this.lb_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nom.Location = new System.Drawing.Point(150, 23);
            this.lb_nom.Name = "lb_nom";
            this.lb_nom.Size = new System.Drawing.Size(110, 20);
            this.lb_nom.TabIndex = 2;
            this.lb_nom.Text = "Kambale Jean";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(18, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Payement_Facture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(386, 326);
            this.Controls.Add(this.bt_valider);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_montant);
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Name = "Payement_Facture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payement_Facture";
            this.Load += new System.EventHandler(this.Payement_Facture_Load);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.bunifuRoundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.Label lb_age;
        private System.Windows.Forms.Label lb_nom;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MyRoundedTextBox tb_montant;
        private System.Windows.Forms.Label label1;
        private RoundedButton bt_valider;
        private System.Windows.Forms.Label label2;
    }
}