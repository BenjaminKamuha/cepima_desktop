namespace Cepima.MesForms
{
    partial class Paiement
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
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.nud_reste = new RoundedNumericUpDown();
            this.nud_montant = new RoundedNumericUpDown();
            this.dtpPaiement = new Cepima.Controls.MyDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_confirmer = new RoundedButton();
            this.tb_description = new MyRoundedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.customRoundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.BackColor = System.Drawing.Color.White;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 4;
            this.customRoundedPanel1.BorderSize = 1;
            this.customRoundedPanel1.Controls.Add(this.nud_reste);
            this.customRoundedPanel1.Controls.Add(this.nud_montant);
            this.customRoundedPanel1.Controls.Add(this.dtpPaiement);
            this.customRoundedPanel1.Controls.Add(this.label1);
            this.customRoundedPanel1.Controls.Add(this.bt_confirmer);
            this.customRoundedPanel1.Controls.Add(this.tb_description);
            this.customRoundedPanel1.Controls.Add(this.label4);
            this.customRoundedPanel1.Controls.Add(this.label2);
            this.customRoundedPanel1.Controls.Add(this.label3);
            this.customRoundedPanel1.Controls.Add(this.label);
            this.customRoundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(0, 0);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.ShadowBlur = 10;
            this.customRoundedPanel1.ShadowBorderRadius = -1;
            this.customRoundedPanel1.ShadowColor = System.Drawing.Color.Black;
            this.customRoundedPanel1.ShadowEnabled = false;
            this.customRoundedPanel1.ShadowOffsetX = 0;
            this.customRoundedPanel1.ShadowOffsetY = 4;
            this.customRoundedPanel1.ShadowOpacity = 60;
            this.customRoundedPanel1.ShadowSpread = 0;
            this.customRoundedPanel1.Size = new System.Drawing.Size(394, 462);
            this.customRoundedPanel1.TabIndex = 1;
            // 
            // nud_reste
            // 
            this.nud_reste.BackColor = System.Drawing.Color.White;
            this.nud_reste.BorderColor = System.Drawing.Color.Silver;
            this.nud_reste.BorderRadius = 8;
            this.nud_reste.ButtonBackColor = System.Drawing.Color.White;
            this.nud_reste.ButtonFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.nud_reste.ButtonForeColor = System.Drawing.Color.DimGray;
            this.nud_reste.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.nud_reste.DecimalPlaces = 1;
            this.nud_reste.FocusBorderColor = System.Drawing.Color.Silver;
            this.nud_reste.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nud_reste.ForeColor = System.Drawing.Color.Black;
            this.nud_reste.Location = new System.Drawing.Point(70, 257);
            this.nud_reste.MinimumSize = new System.Drawing.Size(77, 32);
            this.nud_reste.Name = "nud_reste";
            this.nud_reste.Size = new System.Drawing.Size(257, 40);
            this.nud_reste.TabIndex = 44;
            this.nud_reste.ThousandsSeparator = true;
            // 
            // nud_montant
            // 
            this.nud_montant.BackColor = System.Drawing.Color.White;
            this.nud_montant.BorderColor = System.Drawing.Color.Silver;
            this.nud_montant.BorderRadius = 8;
            this.nud_montant.ButtonBackColor = System.Drawing.Color.White;
            this.nud_montant.ButtonFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.nud_montant.ButtonForeColor = System.Drawing.Color.DimGray;
            this.nud_montant.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.nud_montant.DecimalPlaces = 1;
            this.nud_montant.FocusBorderColor = System.Drawing.Color.Silver;
            this.nud_montant.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nud_montant.ForeColor = System.Drawing.Color.Black;
            this.nud_montant.Location = new System.Drawing.Point(70, 172);
            this.nud_montant.MinimumSize = new System.Drawing.Size(77, 32);
            this.nud_montant.Name = "nud_montant";
            this.nud_montant.Size = new System.Drawing.Size(257, 40);
            this.nud_montant.TabIndex = 44;
            this.nud_montant.ThousandsSeparator = true;
            // 
            // dtpPaiement
            // 
            this.dtpPaiement.BackColor = System.Drawing.Color.White;
            this.dtpPaiement.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.dtpPaiement.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.dtpPaiement.BorderRadius = 8;
            this.dtpPaiement.BorderSize = 1;
            this.dtpPaiement.CalendarBackColor = System.Drawing.Color.White;
            this.dtpPaiement.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPaiement.CalendarHeight = 280;
            this.dtpPaiement.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.dtpPaiement.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpPaiement.Checked = true;
            this.dtpPaiement.CustomFormat = "dd/MM/yyyy";
            this.dtpPaiement.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpPaiement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.dtpPaiement.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpPaiement.Location = new System.Drawing.Point(70, 88);
            this.dtpPaiement.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpPaiement.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpPaiement.MinimumSize = new System.Drawing.Size(180, 28);
            this.dtpPaiement.Name = "dtpPaiement";
            this.dtpPaiement.SelectedDayColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.dtpPaiement.ShowCheckBox = false;
            this.dtpPaiement.ShowUpDown = false;
            this.dtpPaiement.Size = new System.Drawing.Size(257, 40);
            this.dtpPaiement.TabIndex = 43;
            this.dtpPaiement.Value = new System.DateTime(2026, 10, 30, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 42;
            this.label1.Text = "Date: ";
            // 
            // bt_confirmer
            // 
            this.bt_confirmer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_confirmer.BackColor = System.Drawing.Color.Transparent;
            this.bt_confirmer.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_confirmer.BorderRadius = 8;
            this.bt_confirmer.ButtonText = "Enregistrer";
            this.bt_confirmer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_confirmer.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_confirmer.FlatAppearance.BorderSize = 0;
            this.bt_confirmer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_confirmer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_confirmer.ForeColor = System.Drawing.Color.White;
            this.bt_confirmer.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_confirmer.Image = global::Cepima.Properties.Resources.ok_30px1;
            this.bt_confirmer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_confirmer.Location = new System.Drawing.Point(119, 413);
            this.bt_confirmer.Name = "bt_confirmer";
            this.bt_confirmer.Size = new System.Drawing.Size(157, 35);
            this.bt_confirmer.TabIndex = 40;
            this.bt_confirmer.Text = "Enregistrer";
            this.bt_confirmer.TextColor = System.Drawing.Color.White;
            this.bt_confirmer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_confirmer.UseVisualStyleBackColor = false;
            this.bt_confirmer.Click += new System.EventHandler(this.bt_confirmer_Click);
            // 
            // tb_description
            // 
            this.tb_description.BackColor = System.Drawing.Color.White;
            this.tb_description.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_description.BorderRadius = 8;
            this.tb_description.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_description.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_description.ForeColor = System.Drawing.Color.Black;
            this.tb_description.Image = null;
            this.tb_description.Location = new System.Drawing.Point(70, 332);
            this.tb_description.MaxLength = 32767;
            this.tb_description.Multiline = true;
            this.tb_description.Name = "tb_description";
            this.tb_description.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_description.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_description.PlaceholderText = "";
            this.tb_description.Size = new System.Drawing.Size(257, 70);
            this.tb_description.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(67, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 38;
            this.label4.Text = "Reste:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 38;
            this.label2.Text = "Montant: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(88, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 23);
            this.label3.TabIndex = 38;
            this.label3.Text = "Enregistrer un paiement";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(67, 144);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(67, 17);
            this.label.TabIndex = 38;
            this.label.Text = "Montant: ";
            // 
            // Paiement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 462);
            this.Controls.Add(this.customRoundedPanel1);
            this.Name = "Paiement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paiement";
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.Label label1;
        private RoundedButton bt_confirmer;
        private MyRoundedTextBox tb_description;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label;
        private Controls.MyDateTimePicker dtpPaiement;
        private RoundedNumericUpDown nud_montant;
        private System.Windows.Forms.Label label3;
        private RoundedNumericUpDown nud_reste;
        private System.Windows.Forms.Label label4;
    }
}