namespace Cepima.MesForms.Compt
{
    partial class Bon_de_sortie
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
            this.bunifuRoundedPanel1 = new BunifuRoundedPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dt_date = new System.Windows.Forms.DateTimePicker();
            this.tb_montant = new MyRoundedTextBox();
            this.tb_donneur = new MyRoundedTextBox();
            this.tb_responsable = new MyRoundedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_add_bon = new RoundedButton();
            this.bunifuRoundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.Empty;
            this.bunifuRoundedPanel1.BorderRadius = 10;
            this.bunifuRoundedPanel1.BorderSize = 0;
            this.bunifuRoundedPanel1.Controls.Add(this.label5);
            this.bunifuRoundedPanel1.Controls.Add(this.label4);
            this.bunifuRoundedPanel1.Controls.Add(this.label3);
            this.bunifuRoundedPanel1.Controls.Add(this.label2);
            this.bunifuRoundedPanel1.Controls.Add(this.bt_add_bon);
            this.bunifuRoundedPanel1.Controls.Add(this.dt_date);
            this.bunifuRoundedPanel1.Controls.Add(this.tb_montant);
            this.bunifuRoundedPanel1.Controls.Add(this.tb_donneur);
            this.bunifuRoundedPanel1.Controls.Add(this.tb_responsable);
            this.bunifuRoundedPanel1.Controls.Add(this.label1);
            this.bunifuRoundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 10;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(481, 518);
            this.bunifuRoundedPanel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14F);
            this.label5.Location = new System.Drawing.Point(12, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 23);
            this.label5.TabIndex = 54;
            this.label5.Text = "Date : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14F);
            this.label4.Location = new System.Drawing.Point(12, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 23);
            this.label4.TabIndex = 54;
            this.label4.Text = "Montant : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14F);
            this.label3.Location = new System.Drawing.Point(9, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 23);
            this.label3.TabIndex = 54;
            this.label3.Text = "Resp Donneur : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14F);
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 23);
            this.label2.TabIndex = 54;
            this.label2.Text = "Responsable : ";
            // 
            // dt_date
            // 
            this.dt_date.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_date.Location = new System.Drawing.Point(147, 355);
            this.dt_date.Name = "dt_date";
            this.dt_date.Size = new System.Drawing.Size(273, 27);
            this.dt_date.TabIndex = 47;
            // 
            // tb_montant
            // 
            this.tb_montant.BackColor = System.Drawing.Color.White;
            this.tb_montant.BorderColor = System.Drawing.Color.Silver;
            this.tb_montant.BorderRadius = 8;
            this.tb_montant.BorderSize = 1;
            this.tb_montant.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_montant.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_montant.ForeColor = System.Drawing.Color.Black;
            this.tb_montant.Image = null;
            this.tb_montant.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_montant.ImagePadding = 4;
            this.tb_montant.Location = new System.Drawing.Point(147, 270);
            this.tb_montant.MaxLength = 32767;
            this.tb_montant.Name = "tb_montant";
            this.tb_montant.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_montant.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_montant.PlaceholderText = "";
            this.tb_montant.Size = new System.Drawing.Size(273, 34);
            this.tb_montant.TabIndex = 46;
            // 
            // tb_donneur
            // 
            this.tb_donneur.BackColor = System.Drawing.Color.White;
            this.tb_donneur.BorderColor = System.Drawing.Color.Silver;
            this.tb_donneur.BorderRadius = 8;
            this.tb_donneur.BorderSize = 1;
            this.tb_donneur.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_donneur.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_donneur.ForeColor = System.Drawing.Color.Black;
            this.tb_donneur.Image = null;
            this.tb_donneur.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_donneur.ImagePadding = 4;
            this.tb_donneur.Location = new System.Drawing.Point(147, 189);
            this.tb_donneur.MaxLength = 32767;
            this.tb_donneur.Name = "tb_donneur";
            this.tb_donneur.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_donneur.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_donneur.PlaceholderText = "";
            this.tb_donneur.Size = new System.Drawing.Size(273, 34);
            this.tb_donneur.TabIndex = 46;
            // 
            // tb_responsable
            // 
            this.tb_responsable.BackColor = System.Drawing.Color.White;
            this.tb_responsable.BorderColor = System.Drawing.Color.Silver;
            this.tb_responsable.BorderRadius = 8;
            this.tb_responsable.BorderSize = 1;
            this.tb_responsable.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_responsable.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_responsable.ForeColor = System.Drawing.Color.Black;
            this.tb_responsable.Image = null;
            this.tb_responsable.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_responsable.ImagePadding = 4;
            this.tb_responsable.Location = new System.Drawing.Point(147, 107);
            this.tb_responsable.MaxLength = 32767;
            this.tb_responsable.Name = "tb_responsable";
            this.tb_responsable.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_responsable.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_responsable.PlaceholderText = "";
            this.tb_responsable.Size = new System.Drawing.Size(273, 34);
            this.tb_responsable.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ajouter un bon de sortie";
            // 
            // bt_add_bon
            // 
            this.bt_add_bon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_add_bon.BackColor = System.Drawing.Color.Transparent;
            this.bt_add_bon.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_add_bon.BorderRadius = 10;
            this.bt_add_bon.ButtonText = "Enregistrer";
            this.bt_add_bon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_add_bon.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_add_bon.FlatAppearance.BorderSize = 0;
            this.bt_add_bon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_add_bon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_add_bon.ForeColor = System.Drawing.Color.White;
            this.bt_add_bon.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_add_bon.Image = global::Cepima.Properties.Resources.save_30px;
            this.bt_add_bon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_add_bon.Location = new System.Drawing.Point(159, 430);
            this.bt_add_bon.Name = "bt_add_bon";
            this.bt_add_bon.Size = new System.Drawing.Size(166, 38);
            this.bt_add_bon.TabIndex = 53;
            this.bt_add_bon.Text = "Enregistrer";
            this.bt_add_bon.TextColor = System.Drawing.Color.White;
            this.bt_add_bon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_add_bon.UseVisualStyleBackColor = false;
            this.bt_add_bon.Click += new System.EventHandler(this.bt_add_bon_Click);
            // 
            // Bon_de_sortie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(481, 518);
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Name = "Bon_de_sortie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bon_de_sortie";
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.bunifuRoundedPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dt_date;
        private MyRoundedTextBox tb_montant;
        private MyRoundedTextBox tb_donneur;
        private MyRoundedTextBox tb_responsable;
        private RoundedButton bt_add_bon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}