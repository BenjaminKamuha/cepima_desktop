namespace GenerateLicenceAfrida
{
    partial class Form1
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.SubPan = new System.Windows.Forms.Panel();
            this.rd_temporary = new System.Windows.Forms.RadioButton();
            this.rd_perpetual = new System.Windows.Forms.RadioButton();
            this.tb_gen_license = new ButtonEx();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.paid_amount = new System.Windows.Forms.TextBox();
            this.machine_fingerprint = new System.Windows.Forms.TextBox();
            this.client_name = new System.Windows.Forms.TextBox();
            this.product_model = new System.Windows.Forms.TextBox();
            this.bt_regen_liencese = new ButtonEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_new_payment = new System.Windows.Forms.TextBox();
            this.MainPanel.SuspendLayout();
            this.SubPan.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.panel1);
            this.MainPanel.Controls.Add(this.SubPan);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1075, 436);
            this.MainPanel.TabIndex = 0;
            // 
            // SubPan
            // 
            this.SubPan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SubPan.Controls.Add(this.rd_temporary);
            this.SubPan.Controls.Add(this.rd_perpetual);
            this.SubPan.Controls.Add(this.tb_gen_license);
            this.SubPan.Controls.Add(this.label7);
            this.SubPan.Controls.Add(this.label4);
            this.SubPan.Controls.Add(this.label3);
            this.SubPan.Controls.Add(this.label2);
            this.SubPan.Controls.Add(this.label1);
            this.SubPan.Controls.Add(this.paid_amount);
            this.SubPan.Controls.Add(this.machine_fingerprint);
            this.SubPan.Controls.Add(this.client_name);
            this.SubPan.Controls.Add(this.product_model);
            this.SubPan.Location = new System.Drawing.Point(21, 25);
            this.SubPan.Name = "SubPan";
            this.SubPan.Size = new System.Drawing.Size(502, 390);
            this.SubPan.TabIndex = 0;
            this.SubPan.Paint += new System.Windows.Forms.PaintEventHandler(this.SubPan_Paint);
            // 
            // rd_temporary
            // 
            this.rd_temporary.AutoSize = true;
            this.rd_temporary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_temporary.Location = new System.Drawing.Point(370, 156);
            this.rd_temporary.Name = "rd_temporary";
            this.rd_temporary.Size = new System.Drawing.Size(84, 19);
            this.rd_temporary.TabIndex = 3;
            this.rd_temporary.TabStop = true;
            this.rd_temporary.Text = "Temporary";
            this.rd_temporary.UseVisualStyleBackColor = true;
            // 
            // rd_perpetual
            // 
            this.rd_perpetual.AutoSize = true;
            this.rd_perpetual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_perpetual.Location = new System.Drawing.Point(269, 156);
            this.rd_perpetual.Name = "rd_perpetual";
            this.rd_perpetual.Size = new System.Drawing.Size(78, 19);
            this.rd_perpetual.TabIndex = 3;
            this.rd_perpetual.TabStop = true;
            this.rd_perpetual.Text = "Perpetual";
            this.rd_perpetual.UseVisualStyleBackColor = true;
            // 
            // tb_gen_license
            // 
            this.tb_gen_license.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_gen_license.BackColor = System.Drawing.Color.Transparent;
            this.tb_gen_license.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_gen_license.HoverColor = System.Drawing.Color.LightBlue;
            this.tb_gen_license.Location = new System.Drawing.Point(148, 342);
            this.tb_gen_license.Name = "tb_gen_license";
            this.tb_gen_license.NormalColor = System.Drawing.Color.Blue;
            this.tb_gen_license.Size = new System.Drawing.Size(150, 33);
            this.tb_gen_license.TabIndex = 5;
            this.tb_gen_license.TextValue = "Generate License";
            this.tb_gen_license.Click += new System.EventHandler(this.tb_gen_license_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(49, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Paid Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Machine Fingerprint:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product Model:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client Name:";
            // 
            // paid_amount
            // 
            this.paid_amount.Location = new System.Drawing.Point(269, 191);
            this.paid_amount.Name = "paid_amount";
            this.paid_amount.Size = new System.Drawing.Size(186, 20);
            this.paid_amount.TabIndex = 4;
            // 
            // machine_fingerprint
            // 
            this.machine_fingerprint.Location = new System.Drawing.Point(269, 117);
            this.machine_fingerprint.Name = "machine_fingerprint";
            this.machine_fingerprint.Size = new System.Drawing.Size(186, 20);
            this.machine_fingerprint.TabIndex = 2;
            // 
            // client_name
            // 
            this.client_name.Location = new System.Drawing.Point(269, 40);
            this.client_name.Name = "client_name";
            this.client_name.Size = new System.Drawing.Size(186, 20);
            this.client_name.TabIndex = 0;
            // 
            // product_model
            // 
            this.product_model.Location = new System.Drawing.Point(269, 78);
            this.product_model.Name = "product_model";
            this.product_model.Size = new System.Drawing.Size(186, 20);
            this.product_model.TabIndex = 1;
            // 
            // bt_regen_liencese
            // 
            this.bt_regen_liencese.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_regen_liencese.BackColor = System.Drawing.Color.Transparent;
            this.bt_regen_liencese.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_regen_liencese.HoverColor = System.Drawing.Color.DodgerBlue;
            this.bt_regen_liencese.Location = new System.Drawing.Point(190, 220);
            this.bt_regen_liencese.Name = "bt_regen_liencese";
            this.bt_regen_liencese.NormalColor = System.Drawing.Color.Navy;
            this.bt_regen_liencese.Size = new System.Drawing.Size(150, 33);
            this.bt_regen_liencese.TabIndex = 5;
            this.bt_regen_liencese.TextValue = "Regenerate License";
            this.bt_regen_liencese.Click += new System.EventHandler(this.bt_regen_liencese_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.tb_new_payment);
            this.panel1.Controls.Add(this.bt_regen_liencese);
            this.panel1.Location = new System.Drawing.Point(547, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 390);
            this.panel1.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(49, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Client Name:";
            // 
            // tb_new_payment
            // 
            this.tb_new_payment.Location = new System.Drawing.Point(269, 40);
            this.tb_new_payment.Name = "tb_new_payment";
            this.tb_new_payment.Size = new System.Drawing.Size(186, 20);
            this.tb_new_payment.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 436);
            this.Controls.Add(this.MainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MainPanel.ResumeLayout(false);
            this.SubPan.ResumeLayout(false);
            this.SubPan.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel SubPan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox machine_fingerprint;
        private System.Windows.Forms.TextBox client_name;
        private System.Windows.Forms.TextBox product_model;
        private System.Windows.Forms.TextBox paid_amount;
        private System.Windows.Forms.Label label7;
        private ButtonEx tb_gen_license;
        private System.Windows.Forms.RadioButton rd_temporary;
        private System.Windows.Forms.RadioButton rd_perpetual;
        private ButtonEx bt_regen_liencese;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_new_payment;
    }
}

