namespace Cepima.MesForms.Hospitalisation
{
    partial class Add_chambre
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
            this.bt_save = new RoundedButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numeric_lit = new RoundedNumericUpDown();
            this.tb_tarif = new MyRoundedTextBox();
            this.tb_numero_chambre = new MyRoundedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuRoundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.DarkBlue;
            this.bunifuRoundedPanel1.BorderRadius = 8;
            this.bunifuRoundedPanel1.BorderSize = 0;
            this.bunifuRoundedPanel1.Controls.Add(this.bt_save);
            this.bunifuRoundedPanel1.Controls.Add(this.label4);
            this.bunifuRoundedPanel1.Controls.Add(this.label3);
            this.bunifuRoundedPanel1.Controls.Add(this.label2);
            this.bunifuRoundedPanel1.Controls.Add(this.numeric_lit);
            this.bunifuRoundedPanel1.Controls.Add(this.tb_tarif);
            this.bunifuRoundedPanel1.Controls.Add(this.tb_numero_chambre);
            this.bunifuRoundedPanel1.Controls.Add(this.label1);
            this.bunifuRoundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 10;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(489, 426);
            this.bunifuRoundedPanel1.TabIndex = 0;
            // 
            // bt_save
            // 
            this.bt_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_save.BackColor = System.Drawing.Color.Transparent;
            this.bt_save.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_save.BorderRadius = 8;
            this.bt_save.ButtonText = "Enregistrer une chambre";
            this.bt_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_save.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_save.FlatAppearance.BorderSize = 0;
            this.bt_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save.ForeColor = System.Drawing.Color.White;
            this.bt_save.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_save.Image = global::Cepima.Properties.Resources.save_30px;
            this.bt_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_save.Location = new System.Drawing.Point(100, 357);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(261, 40);
            this.bt_save.TabIndex = 46;
            this.bt_save.Text = "Enregistrer une chambre";
            this.bt_save.TextColor = System.Drawing.Color.White;
            this.bt_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_save.UseVisualStyleBackColor = false;
            this.bt_save.Click += new System.EventHandler(this.bt_modifier_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(96, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 43;
            this.label4.Text = "Tarif journalier : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(96, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 44;
            this.label3.Text = "Nombre de lit : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(96, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 45;
            this.label2.Text = "Nom chambre : ";
            // 
            // numeric_lit
            // 
            this.numeric_lit.BackColor = System.Drawing.Color.White;
            this.numeric_lit.BorderColor = System.Drawing.Color.LightGray;
            this.numeric_lit.BorderRadius = 8;
            this.numeric_lit.ButtonBackColor = System.Drawing.Color.White;
            this.numeric_lit.ButtonFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.numeric_lit.ButtonForeColor = System.Drawing.Color.DimGray;
            this.numeric_lit.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.numeric_lit.FocusBorderColor = System.Drawing.Color.DeepSkyBlue;
            this.numeric_lit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeric_lit.ForeColor = System.Drawing.Color.Black;
            this.numeric_lit.Location = new System.Drawing.Point(86, 186);
            this.numeric_lit.MinimumSize = new System.Drawing.Size(77, 32);
            this.numeric_lit.Name = "numeric_lit";
            this.numeric_lit.Size = new System.Drawing.Size(285, 35);
            this.numeric_lit.TabIndex = 42;
            // 
            // tb_tarif
            // 
            this.tb_tarif.BackColor = System.Drawing.Color.White;
            this.tb_tarif.BorderColor = System.Drawing.Color.Silver;
            this.tb_tarif.BorderRadius = 6;
            this.tb_tarif.BorderSize = 1;
            this.tb_tarif.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_tarif.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_tarif.ForeColor = System.Drawing.Color.Black;
            this.tb_tarif.Image = null;
            this.tb_tarif.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_tarif.ImagePadding = 2;
            this.tb_tarif.Location = new System.Drawing.Point(90, 268);
            this.tb_tarif.MaxLength = 32767;
            this.tb_tarif.Name = "tb_tarif";
            this.tb_tarif.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_tarif.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_tarif.PlaceholderText = "";
            this.tb_tarif.Size = new System.Drawing.Size(285, 35);
            this.tb_tarif.TabIndex = 40;
            // 
            // tb_numero_chambre
            // 
            this.tb_numero_chambre.BackColor = System.Drawing.Color.White;
            this.tb_numero_chambre.BorderColor = System.Drawing.Color.Silver;
            this.tb_numero_chambre.BorderRadius = 6;
            this.tb_numero_chambre.BorderSize = 1;
            this.tb_numero_chambre.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_numero_chambre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_numero_chambre.ForeColor = System.Drawing.Color.Black;
            this.tb_numero_chambre.Image = null;
            this.tb_numero_chambre.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_numero_chambre.ImagePadding = 2;
            this.tb_numero_chambre.Location = new System.Drawing.Point(86, 104);
            this.tb_numero_chambre.MaxLength = 32767;
            this.tb_numero_chambre.Name = "tb_numero_chambre";
            this.tb_numero_chambre.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_numero_chambre.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_numero_chambre.PlaceholderText = "";
            this.tb_numero_chambre.Size = new System.Drawing.Size(285, 35);
            this.tb_numero_chambre.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(141, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 24);
            this.label1.TabIndex = 39;
            this.label1.Text = "Ajouter une chambre";
            // 
            // Add_chambre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(489, 426);
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Name = "Add_chambre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter une chambre";
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.bunifuRoundedPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BunifuRoundedPanel bunifuRoundedPanel1;
        private RoundedButton bt_save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private RoundedNumericUpDown numeric_lit;
        private MyRoundedTextBox tb_tarif;
        private MyRoundedTextBox tb_numero_chambre;
        private System.Windows.Forms.Label label1;

    }
}