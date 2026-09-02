namespace Cepima.MesUserCases.Pharmacie
{
    partial class UC_detail_produit
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
            this.pnl_detail_prod = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_provider = new System.Windows.Forms.Label();
            this.lb_provide_phone = new System.Windows.Forms.Label();
            this.lb_last_purchase = new System.Windows.Forms.Label();
            this.lb_price = new System.Windows.Forms.Label();
            this.lb_prod_category = new System.Windows.Forms.Label();
            this.lb_prod_form = new System.Windows.Forms.Label();
            this.lb_prod_dose = new System.Windows.Forms.Label();
            this.lb_prod_name = new System.Windows.Forms.Label();
            this.c_pnl_taux = new CustomRoundedPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.lb_taux_distribution = new System.Windows.Forms.Label();
            this.c_pnl_seuil_min = new CustomRoundedPanel();
            this.lb_seuil = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.c_pnl_stock_now = new CustomRoundedPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_stock_now = new System.Windows.Forms.Label();
            this.pnl_detail_prod.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.c_pnl_taux.SuspendLayout();
            this.c_pnl_seuil_min.SuspendLayout();
            this.c_pnl_stock_now.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_detail_prod
            // 
            this.pnl_detail_prod.Controls.Add(this.panel3);
            this.pnl_detail_prod.Controls.Add(this.panel2);
            this.pnl_detail_prod.Controls.Add(this.c_pnl_taux);
            this.pnl_detail_prod.Controls.Add(this.c_pnl_seuil_min);
            this.pnl_detail_prod.Controls.Add(this.c_pnl_stock_now);
            this.pnl_detail_prod.Controls.Add(this.label5);
            this.pnl_detail_prod.Controls.Add(this.panel1);
            this.pnl_detail_prod.Location = new System.Drawing.Point(3, 3);
            this.pnl_detail_prod.Name = "pnl_detail_prod";
            this.pnl_detail_prod.Size = new System.Drawing.Size(967, 449);
            this.pnl_detail_prod.TabIndex = 9;
            this.pnl_detail_prod.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_detail_prod_Paint);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(286, 18);
            this.label15.TabIndex = 17;
            this.label15.Text = "INFORMATIONS FOURNISSEUR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "STOCK";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Location = new System.Drawing.Point(0, 202);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(967, 5);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lb_price);
            this.panel2.Controls.Add(this.lb_last_purchase);
            this.panel2.Controls.Add(this.lb_provide_phone);
            this.panel2.Controls.Add(this.lb_provider);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Location = new System.Drawing.Point(483, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(481, 183);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lb_prod_category);
            this.panel3.Controls.Add(this.lb_prod_form);
            this.panel3.Controls.Add(this.lb_prod_dose);
            this.panel3.Controls.Add(this.lb_prod_name);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(3, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(453, 183);
            this.panel3.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "INFORMATIONS PRODUIT";
            // 
            // lb_provider
            // 
            this.lb_provider.AutoSize = true;
            this.lb_provider.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_provider.Location = new System.Drawing.Point(3, 43);
            this.lb_provider.Name = "lb_provider";
            this.lb_provider.Size = new System.Drawing.Size(91, 17);
            this.lb_provider.TabIndex = 18;
            this.lb_provider.Text = "Fournisseur: ";
            // 
            // lb_provide_phone
            // 
            this.lb_provide_phone.AutoSize = true;
            this.lb_provide_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_provide_phone.Location = new System.Drawing.Point(3, 79);
            this.lb_provide_phone.Name = "lb_provide_phone";
            this.lb_provide_phone.Size = new System.Drawing.Size(84, 17);
            this.lb_provide_phone.TabIndex = 19;
            this.lb_provide_phone.Text = "Téléphone: ";
            // 
            // lb_last_purchase
            // 
            this.lb_last_purchase.AutoSize = true;
            this.lb_last_purchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_last_purchase.Location = new System.Drawing.Point(3, 115);
            this.lb_last_purchase.Name = "lb_last_purchase";
            this.lb_last_purchase.Size = new System.Drawing.Size(102, 17);
            this.lb_last_purchase.TabIndex = 20;
            this.lb_last_purchase.Text = "Dernier achat: ";
            // 
            // lb_price
            // 
            this.lb_price.AutoSize = true;
            this.lb_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_price.Location = new System.Drawing.Point(3, 153);
            this.lb_price.Name = "lb_price";
            this.lb_price.Size = new System.Drawing.Size(39, 17);
            this.lb_price.TabIndex = 21;
            this.lb_price.Text = "Prix: ";
            // 
            // lb_prod_category
            // 
            this.lb_prod_category.AutoSize = true;
            this.lb_prod_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_prod_category.Location = new System.Drawing.Point(3, 153);
            this.lb_prod_category.Name = "lb_prod_category";
            this.lb_prod_category.Size = new System.Drawing.Size(77, 17);
            this.lb_prod_category.TabIndex = 25;
            this.lb_prod_category.Text = "Catégorie: ";
            // 
            // lb_prod_form
            // 
            this.lb_prod_form.AutoSize = true;
            this.lb_prod_form.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_prod_form.Location = new System.Drawing.Point(3, 115);
            this.lb_prod_form.Name = "lb_prod_form";
            this.lb_prod_form.Size = new System.Drawing.Size(56, 17);
            this.lb_prod_form.TabIndex = 24;
            this.lb_prod_form.Text = "Forme: ";
            // 
            // lb_prod_dose
            // 
            this.lb_prod_dose.AutoSize = true;
            this.lb_prod_dose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_prod_dose.Location = new System.Drawing.Point(3, 79);
            this.lb_prod_dose.Name = "lb_prod_dose";
            this.lb_prod_dose.Size = new System.Drawing.Size(69, 17);
            this.lb_prod_dose.TabIndex = 23;
            this.lb_prod_dose.Text = "Dosage:  ";
            // 
            // lb_prod_name
            // 
            this.lb_prod_name.AutoSize = true;
            this.lb_prod_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_prod_name.Location = new System.Drawing.Point(3, 43);
            this.lb_prod_name.Name = "lb_prod_name";
            this.lb_prod_name.Size = new System.Drawing.Size(45, 17);
            this.lb_prod_name.TabIndex = 22;
            this.lb_prod_name.Text = "Nom: ";
            // 
            // c_pnl_taux
            // 
            this.c_pnl_taux.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.c_pnl_taux.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.c_pnl_taux.BorderRadius = 15;
            this.c_pnl_taux.BorderSize = 0;
            this.c_pnl_taux.Controls.Add(this.label11);
            this.c_pnl_taux.Controls.Add(this.lb_taux_distribution);
            this.c_pnl_taux.HoverBackColor = System.Drawing.Color.Empty;
            this.c_pnl_taux.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.c_pnl_taux.Location = new System.Drawing.Point(689, 284);
            this.c_pnl_taux.Name = "c_pnl_taux";
            this.c_pnl_taux.Padding = new System.Windows.Forms.Padding(10, 10, 14, 14);
            this.c_pnl_taux.ShadowBlur = 10;
            this.c_pnl_taux.ShadowBorderRadius = -1;
            this.c_pnl_taux.ShadowColor = System.Drawing.Color.Black;
            this.c_pnl_taux.ShadowEnabled = true;
            this.c_pnl_taux.ShadowOffsetX = 4;
            this.c_pnl_taux.ShadowOffsetY = 4;
            this.c_pnl_taux.ShadowOpacity = 30;
            this.c_pnl_taux.ShadowSpread = 0;
            this.c_pnl_taux.Size = new System.Drawing.Size(212, 100);
            this.c_pnl_taux.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(22, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(168, 17);
            this.label11.TabIndex = 13;
            this.label11.Text = "TAUX DE DISTRIBUTION";
            // 
            // lb_taux_distribution
            // 
            this.lb_taux_distribution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_taux_distribution.AutoSize = true;
            this.lb_taux_distribution.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_taux_distribution.Location = new System.Drawing.Point(56, 57);
            this.lb_taux_distribution.Name = "lb_taux_distribution";
            this.lb_taux_distribution.Size = new System.Drawing.Size(101, 26);
            this.lb_taux_distribution.TabIndex = 14;
            this.lb_taux_distribution.Text = "lb_value";
            this.lb_taux_distribution.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // c_pnl_seuil_min
            // 
            this.c_pnl_seuil_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.c_pnl_seuil_min.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.c_pnl_seuil_min.BorderRadius = 10;
            this.c_pnl_seuil_min.BorderSize = 0;
            this.c_pnl_seuil_min.Controls.Add(this.lb_seuil);
            this.c_pnl_seuil_min.Controls.Add(this.label7);
            this.c_pnl_seuil_min.HoverBackColor = System.Drawing.Color.Empty;
            this.c_pnl_seuil_min.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.c_pnl_seuil_min.Location = new System.Drawing.Point(353, 284);
            this.c_pnl_seuil_min.Name = "c_pnl_seuil_min";
            this.c_pnl_seuil_min.Padding = new System.Windows.Forms.Padding(10, 10, 14, 14);
            this.c_pnl_seuil_min.ShadowBlur = 10;
            this.c_pnl_seuil_min.ShadowBorderRadius = -1;
            this.c_pnl_seuil_min.ShadowColor = System.Drawing.Color.Black;
            this.c_pnl_seuil_min.ShadowEnabled = true;
            this.c_pnl_seuil_min.ShadowOffsetX = 4;
            this.c_pnl_seuil_min.ShadowOffsetY = 4;
            this.c_pnl_seuil_min.ShadowOpacity = 30;
            this.c_pnl_seuil_min.ShadowSpread = 0;
            this.c_pnl_seuil_min.Size = new System.Drawing.Size(212, 100);
            this.c_pnl_seuil_min.TabIndex = 15;
            // 
            // lb_seuil
            // 
            this.lb_seuil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_seuil.AutoSize = true;
            this.lb_seuil.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_seuil.Location = new System.Drawing.Point(56, 57);
            this.lb_seuil.Name = "lb_seuil";
            this.lb_seuil.Size = new System.Drawing.Size(101, 26);
            this.lb_seuil.TabIndex = 13;
            this.lb_seuil.Text = "lb_value";
            this.lb_seuil.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(50, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "SEUIL MINIMAL";
            // 
            // c_pnl_stock_now
            // 
            this.c_pnl_stock_now.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.c_pnl_stock_now.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.c_pnl_stock_now.BorderRadius = 15;
            this.c_pnl_stock_now.BorderSize = 0;
            this.c_pnl_stock_now.Controls.Add(this.label6);
            this.c_pnl_stock_now.Controls.Add(this.lb_stock_now);
            this.c_pnl_stock_now.HoverBackColor = System.Drawing.Color.Empty;
            this.c_pnl_stock_now.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.c_pnl_stock_now.Location = new System.Drawing.Point(49, 284);
            this.c_pnl_stock_now.Name = "c_pnl_stock_now";
            this.c_pnl_stock_now.Padding = new System.Windows.Forms.Padding(10, 10, 14, 14);
            this.c_pnl_stock_now.ShadowBlur = 10;
            this.c_pnl_stock_now.ShadowBorderRadius = -1;
            this.c_pnl_stock_now.ShadowColor = System.Drawing.Color.Black;
            this.c_pnl_stock_now.ShadowEnabled = true;
            this.c_pnl_stock_now.ShadowOffsetX = 4;
            this.c_pnl_stock_now.ShadowOffsetY = 4;
            this.c_pnl_stock_now.ShadowOpacity = 30;
            this.c_pnl_stock_now.ShadowSpread = 0;
            this.c_pnl_stock_now.Size = new System.Drawing.Size(212, 100);
            this.c_pnl_stock_now.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(49, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "STOCK ACTUEL";
            // 
            // lb_stock_now
            // 
            this.lb_stock_now.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_stock_now.AutoSize = true;
            this.lb_stock_now.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_stock_now.Location = new System.Drawing.Point(56, 51);
            this.lb_stock_now.Name = "lb_stock_now";
            this.lb_stock_now.Size = new System.Drawing.Size(101, 26);
            this.lb_stock_now.TabIndex = 12;
            this.lb_stock_now.Text = "lb_value";
            this.lb_stock_now.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_detail_produit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnl_detail_prod);
            this.Name = "UC_detail_produit";
            this.Size = new System.Drawing.Size(973, 455);
            this.Load += new System.EventHandler(this.UC_detail_produit_Load);
            this.pnl_detail_prod.ResumeLayout(false);
            this.pnl_detail_prod.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.c_pnl_taux.ResumeLayout(false);
            this.c_pnl_taux.PerformLayout();
            this.c_pnl_seuil_min.ResumeLayout(false);
            this.c_pnl_seuil_min.PerformLayout();
            this.c_pnl_stock_now.ResumeLayout(false);
            this.c_pnl_stock_now.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_detail_prod;
        private System.Windows.Forms.Label lb_stock_now;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private CustomRoundedPanel c_pnl_taux;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lb_taux_distribution;
        private CustomRoundedPanel c_pnl_seuil_min;
        private System.Windows.Forms.Label lb_seuil;
        private System.Windows.Forms.Label label7;
        private CustomRoundedPanel c_pnl_stock_now;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lb_prod_category;
        private System.Windows.Forms.Label lb_prod_form;
        private System.Windows.Forms.Label lb_prod_dose;
        private System.Windows.Forms.Label lb_prod_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb_price;
        private System.Windows.Forms.Label lb_last_purchase;
        private System.Windows.Forms.Label lb_provide_phone;
        private System.Windows.Forms.Label lb_provider;

    }
}
