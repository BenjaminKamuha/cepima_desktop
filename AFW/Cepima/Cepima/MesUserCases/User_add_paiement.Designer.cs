namespace Cepima.MesUserCases
{
    partial class User_add_paiement
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
            this.bt_add_paiement = new test_arrondissement2012.PerfectRoundedButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_montant_paye = new System.Windows.Forms.TextBox();
            this.tb_mode_paiement = new System.Windows.Forms.TextBox();
            this.tb_reste = new System.Windows.Forms.TextBox();
            this.tb_total = new System.Windows.Forms.TextBox();
            this.tb_numero_fiche = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.customRoundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 4;
            this.customRoundedPanel1.BorderSize = 1;
            this.customRoundedPanel1.Controls.Add(this.bt_add_paiement);
            this.customRoundedPanel1.Controls.Add(this.label5);
            this.customRoundedPanel1.Controls.Add(this.label4);
            this.customRoundedPanel1.Controls.Add(this.label3);
            this.customRoundedPanel1.Controls.Add(this.label6);
            this.customRoundedPanel1.Controls.Add(this.label2);
            this.customRoundedPanel1.Controls.Add(this.tb_montant_paye);
            this.customRoundedPanel1.Controls.Add(this.tb_mode_paiement);
            this.customRoundedPanel1.Controls.Add(this.tb_reste);
            this.customRoundedPanel1.Controls.Add(this.tb_total);
            this.customRoundedPanel1.Controls.Add(this.tb_numero_fiche);
            this.customRoundedPanel1.Controls.Add(this.label1);
            this.customRoundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(0, 0);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Size = new System.Drawing.Size(357, 183);
            this.customRoundedPanel1.TabIndex = 0;
            // 
            // bt_add_paiement
            // 
            this.bt_add_paiement.BackColor = System.Drawing.Color.Transparent;
            this.bt_add_paiement.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_add_paiement.BorderRadius = 5;
            this.bt_add_paiement.BorderSize = 0;
            this.bt_add_paiement.ButtonText = "Valider paiement";
            this.bt_add_paiement.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.bt_add_paiement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_add_paiement.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_add_paiement.Location = new System.Drawing.Point(112, 155);
            this.bt_add_paiement.Name = "bt_add_paiement";
            this.bt_add_paiement.Size = new System.Drawing.Size(125, 25);
            this.bt_add_paiement.TabIndex = 12;
            this.bt_add_paiement.Click += new System.EventHandler(this.bt_add_paiement_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(195, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Montant payé";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mode de paiement";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Montant restant";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Total facture : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero fiche";
            // 
            // tb_montant_paye
            // 
            this.tb_montant_paye.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_montant_paye.Location = new System.Drawing.Point(198, 74);
            this.tb_montant_paye.Name = "tb_montant_paye";
            this.tb_montant_paye.Size = new System.Drawing.Size(135, 23);
            this.tb_montant_paye.TabIndex = 1;
            // 
            // tb_mode_paiement
            // 
            this.tb_mode_paiement.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_mode_paiement.Location = new System.Drawing.Point(198, 125);
            this.tb_mode_paiement.Name = "tb_mode_paiement";
            this.tb_mode_paiement.Size = new System.Drawing.Size(135, 23);
            this.tb_mode_paiement.TabIndex = 1;
            // 
            // tb_reste
            // 
            this.tb_reste.Enabled = false;
            this.tb_reste.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_reste.Location = new System.Drawing.Point(38, 125);
            this.tb_reste.Name = "tb_reste";
            this.tb_reste.Size = new System.Drawing.Size(99, 23);
            this.tb_reste.TabIndex = 1;
            // 
            // tb_total
            // 
            this.tb_total.Enabled = false;
            this.tb_total.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_total.Location = new System.Drawing.Point(255, 29);
            this.tb_total.Name = "tb_total";
            this.tb_total.Size = new System.Drawing.Size(99, 23);
            this.tb_total.TabIndex = 1;
            // 
            // tb_numero_fiche
            // 
            this.tb_numero_fiche.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_numero_fiche.Location = new System.Drawing.Point(38, 74);
            this.tb_numero_fiche.Name = "tb_numero_fiche";
            this.tb_numero_fiche.Size = new System.Drawing.Size(99, 23);
            this.tb_numero_fiche.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Paiement de la facture";
            // 
            // User_add_paiement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.customRoundedPanel1);
            this.Name = "User_add_paiement";
            this.Size = new System.Drawing.Size(357, 183);
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_montant_paye;
        private System.Windows.Forms.TextBox tb_mode_paiement;
        private System.Windows.Forms.TextBox tb_reste;
        private System.Windows.Forms.TextBox tb_numero_fiche;
        private test_arrondissement2012.PerfectRoundedButton bt_add_paiement;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_total;
    }
}
