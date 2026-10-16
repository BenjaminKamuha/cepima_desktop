namespace Cepima.MesForms.Prescription
{
    partial class Form_add_ligne
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
            this.pnl_header = new System.Windows.Forms.Panel();
            this.item_medoc = new ModernListItem();
            this.tb_frequence = new MyRoundedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.tb_dosage = new MyRoundedTextBox();
            this.upd_quantite = new RoundedNumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_save_medoc = new RoundedButton();
            this.tb_duree = new MyRoundedTextBox();
            this.pnl_header.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_header
            // 
            this.pnl_header.Controls.Add(this.item_medoc);
            this.pnl_header.Location = new System.Drawing.Point(3, 12);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(470, 71);
            this.pnl_header.TabIndex = 1;
            // 
            // item_medoc
            // 
            this.item_medoc.BackColor = System.Drawing.Color.Transparent;
            this.item_medoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.item_medoc.IndicatorColor = System.Drawing.Color.LightBlue;
            this.item_medoc.IndicatorShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.item_medoc.Location = new System.Drawing.Point(3, 6);
            this.item_medoc.Name = "item_medoc";
            this.item_medoc.Size = new System.Drawing.Size(160, 60);
            this.item_medoc.SubtitleColor = System.Drawing.Color.Gray;
            this.item_medoc.SubtitleFont = new System.Drawing.Font("Segoe UI", 7F);
            this.item_medoc.TabIndex = 9;
            this.item_medoc.TitleColor = System.Drawing.Color.Black;
            this.item_medoc.TitleFont = new System.Drawing.Font("Segoe UI", 9F);
            // 
            // tb_frequence
            // 
            this.tb_frequence.BackColor = System.Drawing.Color.White;
            this.tb_frequence.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_frequence.BorderRadius = 8;
            this.tb_frequence.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_frequence.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_frequence.ForeColor = System.Drawing.Color.Black;
            this.tb_frequence.Image = null;
            this.tb_frequence.Location = new System.Drawing.Point(182, 184);
            this.tb_frequence.MaxLength = 32767;
            this.tb_frequence.Name = "tb_frequence";
            this.tb_frequence.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_frequence.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_frequence.PlaceholderText = "ex: 2 fois / jours";
            this.tb_frequence.Size = new System.Drawing.Size(238, 37);
            this.tb_frequence.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Durée:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Frequence:";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(52, 126);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(45, 17);
            this.label.TabIndex = 25;
            this.label.Text = "Dose:";
            // 
            // tb_dosage
            // 
            this.tb_dosage.BackColor = System.Drawing.Color.White;
            this.tb_dosage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_dosage.BorderRadius = 8;
            this.tb_dosage.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_dosage.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_dosage.ForeColor = System.Drawing.Color.Black;
            this.tb_dosage.Image = null;
            this.tb_dosage.Location = new System.Drawing.Point(182, 116);
            this.tb_dosage.MaxLength = 32767;
            this.tb_dosage.Name = "tb_dosage";
            this.tb_dosage.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_dosage.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_dosage.PlaceholderText = "2 mg";
            this.tb_dosage.Size = new System.Drawing.Size(238, 37);
            this.tb_dosage.TabIndex = 26;
            // 
            // upd_quantite
            // 
            this.upd_quantite.BackColor = System.Drawing.Color.White;
            this.upd_quantite.BorderColor = System.Drawing.Color.LightGray;
            this.upd_quantite.BorderRadius = 8;
            this.upd_quantite.BorderSize = 2;
            this.upd_quantite.ButtonBackColor = System.Drawing.Color.White;
            this.upd_quantite.ButtonFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.upd_quantite.ButtonForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.upd_quantite.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.upd_quantite.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.upd_quantite.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upd_quantite.ForeColor = System.Drawing.Color.Black;
            this.upd_quantite.Location = new System.Drawing.Point(182, 318);
            this.upd_quantite.MinimumSize = new System.Drawing.Size(74, 36);
            this.upd_quantite.Name = "upd_quantite";
            this.upd_quantite.Size = new System.Drawing.Size(238, 37);
            this.upd_quantite.TabIndex = 31;
            this.upd_quantite.TextPadding = 5;
            this.upd_quantite.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Quantitée:";
            this.label1.Click += new System.EventHandler(this.label4_Click);
            // 
            // bt_save_medoc
            // 
            this.bt_save_medoc.BackColor = System.Drawing.Color.Transparent;
            this.bt_save_medoc.BorderColor = System.Drawing.Color.White;
            this.bt_save_medoc.BorderRadius = 10;
            this.bt_save_medoc.BorderSize = 0;
            this.bt_save_medoc.ButtonText = "Ajouter";
            this.bt_save_medoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_save_medoc.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_save_medoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_save_medoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save_medoc.ForeColor = System.Drawing.Color.White;
            this.bt_save_medoc.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_save_medoc.Image = global::Cepima.Properties.Resources.add_25px1;
            this.bt_save_medoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_save_medoc.Location = new System.Drawing.Point(182, 411);
            this.bt_save_medoc.Name = "bt_save_medoc";
            this.bt_save_medoc.Size = new System.Drawing.Size(121, 34);
            this.bt_save_medoc.TabIndex = 32;
            this.bt_save_medoc.Text = "Ajouter";
            this.bt_save_medoc.TextColor = System.Drawing.Color.White;
            this.bt_save_medoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_save_medoc.UseVisualStyleBackColor = false;
            this.bt_save_medoc.Click += new System.EventHandler(this.bt_save_medoc_Click);
            // 
            // tb_duree
            // 
            this.tb_duree.BackColor = System.Drawing.Color.White;
            this.tb_duree.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_duree.BorderRadius = 8;
            this.tb_duree.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_duree.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_duree.ForeColor = System.Drawing.Color.Black;
            this.tb_duree.Image = null;
            this.tb_duree.Location = new System.Drawing.Point(182, 251);
            this.tb_duree.MaxLength = 32767;
            this.tb_duree.Name = "tb_duree";
            this.tb_duree.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_duree.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_duree.PlaceholderText = "ex: 7 jours";
            this.tb_duree.Size = new System.Drawing.Size(238, 37);
            this.tb_duree.TabIndex = 26;
            // 
            // Form_add_ligne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(477, 478);
            this.Controls.Add(this.bt_save_medoc);
            this.Controls.Add(this.upd_quantite);
            this.Controls.Add(this.tb_dosage);
            this.Controls.Add(this.tb_duree);
            this.Controls.Add(this.tb_frequence);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label);
            this.Controls.Add(this.pnl_header);
            this.Name = "Form_add_ligne";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_add_ligne";
            this.pnl_header.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_header;
        private ModernListItem item_medoc;
        private MyRoundedTextBox tb_frequence;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label;
        private MyRoundedTextBox tb_dosage;
        private RoundedNumericUpDown upd_quantite;
        private System.Windows.Forms.Label label1;
        private RoundedButton bt_save_medoc;
        private MyRoundedTextBox tb_duree;
    }
}