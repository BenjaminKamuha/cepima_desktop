namespace Cepima.MesForms.Hospitalisation
{
    partial class update
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
            this.lb_chambre = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numeric_mod = new RoundedNumericUpDown();
            this.tb_mod_tarif = new MyRoundedTextBox();
            this.tb_mod_chambre = new MyRoundedTextBox();
            this.bt_save = new RoundedButton();
            this.SuspendLayout();
            // 
            // lb_chambre
            // 
            this.lb_chambre.AutoSize = true;
            this.lb_chambre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_chambre.Location = new System.Drawing.Point(103, 26);
            this.lb_chambre.Name = "lb_chambre";
            this.lb_chambre.Size = new System.Drawing.Size(166, 20);
            this.lb_chambre.TabIndex = 41;
            this.lb_chambre.Text = "Modifier la chambre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(67, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 49;
            this.label4.Text = "Tarif journalier : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 50;
            this.label3.Text = "Nombre de lit : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 51;
            this.label2.Text = "Nom chambre : ";
            // 
            // numeric_mod
            // 
            this.numeric_mod.BackColor = System.Drawing.Color.White;
            this.numeric_mod.BorderColor = System.Drawing.Color.LightGray;
            this.numeric_mod.BorderRadius = 8;
            this.numeric_mod.ButtonBackColor = System.Drawing.Color.White;
            this.numeric_mod.ButtonFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.numeric_mod.ButtonForeColor = System.Drawing.Color.DimGray;
            this.numeric_mod.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.numeric_mod.FocusBorderColor = System.Drawing.Color.DeepSkyBlue;
            this.numeric_mod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeric_mod.ForeColor = System.Drawing.Color.Black;
            this.numeric_mod.Location = new System.Drawing.Point(57, 211);
            this.numeric_mod.MinimumSize = new System.Drawing.Size(77, 32);
            this.numeric_mod.Name = "numeric_mod";
            this.numeric_mod.Size = new System.Drawing.Size(285, 35);
            this.numeric_mod.TabIndex = 48;
            // 
            // tb_mod_tarif
            // 
            this.tb_mod_tarif.BackColor = System.Drawing.Color.White;
            this.tb_mod_tarif.BorderColor = System.Drawing.Color.Silver;
            this.tb_mod_tarif.BorderRadius = 6;
            this.tb_mod_tarif.BorderSize = 1;
            this.tb_mod_tarif.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_mod_tarif.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_mod_tarif.ForeColor = System.Drawing.Color.Black;
            this.tb_mod_tarif.Image = null;
            this.tb_mod_tarif.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_mod_tarif.ImagePadding = 2;
            this.tb_mod_tarif.Location = new System.Drawing.Point(61, 293);
            this.tb_mod_tarif.MaxLength = 32767;
            this.tb_mod_tarif.Name = "tb_mod_tarif";
            this.tb_mod_tarif.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_mod_tarif.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_mod_tarif.PlaceholderText = "";
            this.tb_mod_tarif.Size = new System.Drawing.Size(285, 35);
            this.tb_mod_tarif.TabIndex = 46;
            // 
            // tb_mod_chambre
            // 
            this.tb_mod_chambre.BackColor = System.Drawing.Color.White;
            this.tb_mod_chambre.BorderColor = System.Drawing.Color.Silver;
            this.tb_mod_chambre.BorderRadius = 6;
            this.tb_mod_chambre.BorderSize = 1;
            this.tb_mod_chambre.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_mod_chambre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_mod_chambre.ForeColor = System.Drawing.Color.Black;
            this.tb_mod_chambre.Image = null;
            this.tb_mod_chambre.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_mod_chambre.ImagePadding = 2;
            this.tb_mod_chambre.Location = new System.Drawing.Point(57, 129);
            this.tb_mod_chambre.MaxLength = 32767;
            this.tb_mod_chambre.Name = "tb_mod_chambre";
            this.tb_mod_chambre.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_mod_chambre.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_mod_chambre.PlaceholderText = "";
            this.tb_mod_chambre.Size = new System.Drawing.Size(285, 35);
            this.tb_mod_chambre.TabIndex = 47;
            // 
            // bt_save
            // 
            this.bt_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_save.BackColor = System.Drawing.Color.Transparent;
            this.bt_save.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_save.BorderRadius = 8;
            this.bt_save.ButtonText = "Enregistrer ";
            this.bt_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_save.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_save.FlatAppearance.BorderSize = 0;
            this.bt_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save.ForeColor = System.Drawing.Color.White;
            this.bt_save.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_save.Image = global::Cepima.Properties.Resources.save_30px;
            this.bt_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_save.Location = new System.Drawing.Point(71, 366);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(261, 40);
            this.bt_save.TabIndex = 52;
            this.bt_save.Text = "Enregistrer ";
            this.bt_save.TextColor = System.Drawing.Color.White;
            this.bt_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_save.UseVisualStyleBackColor = false;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(402, 434);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numeric_mod);
            this.Controls.Add(this.tb_mod_tarif);
            this.Controls.Add(this.tb_mod_chambre);
            this.Controls.Add(this.lb_chambre);
            this.Name = "update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update_chambre";
            this.Load += new System.EventHandler(this.update_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_chambre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private RoundedNumericUpDown numeric_mod;
        private MyRoundedTextBox tb_mod_tarif;
        private MyRoundedTextBox tb_mod_chambre;
        private RoundedButton bt_save;
    }
}