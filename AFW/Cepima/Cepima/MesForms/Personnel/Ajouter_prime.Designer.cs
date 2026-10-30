namespace Cepima.MesForms.Personnel
{
    partial class Ajouter_prime
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
            this.lbSousTitre = new System.Windows.Forms.Label();
            this.lbTitre = new System.Windows.Forms.Label();
            this.avatarControl1 = new AvatarControl();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudMontant = new RoundedNumericUpDown();
            this.dtpDatePrime = new Cepima.Controls.MyDateTimePicker();
            this.txtPersonnel = new MyRoundedTextBox();
            this.txtMotif = new MyRoundedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btEnregistrer = new RoundedButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSalaire = new MyRoundedComboBox();
            this.customRoundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(131)))), ((int)(((byte)(78)))));
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.customRoundedPanel1.BorderRadius = 8;
            this.customRoundedPanel1.BorderSize = 0;
            this.customRoundedPanel1.Controls.Add(this.lbSousTitre);
            this.customRoundedPanel1.Controls.Add(this.lbTitre);
            this.customRoundedPanel1.Controls.Add(this.avatarControl1);
            this.customRoundedPanel1.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.customRoundedPanel1.Size = new System.Drawing.Size(651, 99);
            this.customRoundedPanel1.TabIndex = 1;
            // 
            // lbSousTitre
            // 
            this.lbSousTitre.AutoSize = true;
            this.lbSousTitre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSousTitre.ForeColor = System.Drawing.Color.White;
            this.lbSousTitre.Location = new System.Drawing.Point(112, 72);
            this.lbSousTitre.Name = "lbSousTitre";
            this.lbSousTitre.Size = new System.Drawing.Size(246, 21);
            this.lbSousTitre.TabIndex = 2;
            this.lbSousTitre.Text = "Enregistrer ou modifier une prime";
            // 
            // lbTitre
            // 
            this.lbTitre.AutoSize = true;
            this.lbTitre.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitre.ForeColor = System.Drawing.Color.White;
            this.lbTitre.Location = new System.Drawing.Point(111, 26);
            this.lbTitre.Name = "lbTitre";
            this.lbTitre.Size = new System.Drawing.Size(82, 32);
            this.lbTitre.TabIndex = 2;
            this.lbTitre.Text = "Prime";
            // 
            // avatarControl1
            // 
            this.avatarControl1.Avatar = global::Cepima.Properties.Resources.prime;
            this.avatarControl1.BackColor = System.Drawing.Color.Transparent;
            this.avatarControl1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.avatarControl1.BorderSize = 2;
            this.avatarControl1.Location = new System.Drawing.Point(12, 12);
            this.avatarControl1.Name = "avatarControl1";
            this.avatarControl1.Size = new System.Drawing.Size(80, 80);
            this.avatarControl1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 370);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Montant de la prime";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 21);
            this.label5.TabIndex = 12;
            this.label5.Text = "Date de la prime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "Personnel ";
            // 
            // nudMontant
            // 
            this.nudMontant.BackColor = System.Drawing.Color.White;
            this.nudMontant.BorderColor = System.Drawing.Color.Silver;
            this.nudMontant.BorderRadius = 8;
            this.nudMontant.ButtonBackColor = System.Drawing.Color.White;
            this.nudMontant.ButtonFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.nudMontant.ButtonForeColor = System.Drawing.Color.DimGray;
            this.nudMontant.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.nudMontant.DecimalPlaces = 1;
            this.nudMontant.FocusBorderColor = System.Drawing.Color.Silver;
            this.nudMontant.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudMontant.ForeColor = System.Drawing.Color.Black;
            this.nudMontant.Location = new System.Drawing.Point(251, 351);
            this.nudMontant.MinimumSize = new System.Drawing.Size(77, 32);
            this.nudMontant.Name = "nudMontant";
            this.nudMontant.Size = new System.Drawing.Size(380, 40);
            this.nudMontant.TabIndex = 10;
            this.nudMontant.ThousandsSeparator = true;
            // 
            // dtpDatePrime
            // 
            this.dtpDatePrime.BackColor = System.Drawing.Color.White;
            this.dtpDatePrime.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.dtpDatePrime.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.dtpDatePrime.BorderRadius = 8;
            this.dtpDatePrime.BorderSize = 1;
            this.dtpDatePrime.CalendarBackColor = System.Drawing.Color.White;
            this.dtpDatePrime.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatePrime.CalendarHeight = 280;
            this.dtpDatePrime.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.dtpDatePrime.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpDatePrime.Checked = true;
            this.dtpDatePrime.CustomFormat = "dd/MM/yyyy";
            this.dtpDatePrime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDatePrime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.dtpDatePrime.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDatePrime.Location = new System.Drawing.Point(251, 241);
            this.dtpDatePrime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDatePrime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDatePrime.MinimumSize = new System.Drawing.Size(180, 28);
            this.dtpDatePrime.Name = "dtpDatePrime";
            this.dtpDatePrime.SelectedDayColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.dtpDatePrime.ShowCheckBox = false;
            this.dtpDatePrime.ShowUpDown = false;
            this.dtpDatePrime.Size = new System.Drawing.Size(380, 40);
            this.dtpDatePrime.TabIndex = 9;
            this.dtpDatePrime.Value = new System.DateTime(2026, 10, 30, 0, 0, 0, 0);
            // 
            // txtPersonnel
            // 
            this.txtPersonnel.BackColor = System.Drawing.Color.White;
            this.txtPersonnel.BorderColor = System.Drawing.Color.Silver;
            this.txtPersonnel.BorderRadius = 8;
            this.txtPersonnel.BorderSize = 1;
            this.txtPersonnel.FocusBorderColor = System.Drawing.Color.Orange;
            this.txtPersonnel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonnel.ForeColor = System.Drawing.Color.Black;
            this.txtPersonnel.Image = null;
            this.txtPersonnel.Location = new System.Drawing.Point(251, 131);
            this.txtPersonnel.MaxLength = 32767;
            this.txtPersonnel.Name = "txtPersonnel";
            this.txtPersonnel.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPersonnel.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtPersonnel.PlaceholderText = "";
            this.txtPersonnel.ReadOnly = true;
            this.txtPersonnel.Size = new System.Drawing.Size(380, 40);
            this.txtPersonnel.TabIndex = 7;
            // 
            // txtMotif
            // 
            this.txtMotif.BackColor = System.Drawing.Color.White;
            this.txtMotif.BorderColor = System.Drawing.Color.Silver;
            this.txtMotif.BorderRadius = 8;
            this.txtMotif.BorderSize = 1;
            this.txtMotif.FocusBorderColor = System.Drawing.Color.Silver;
            this.txtMotif.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotif.ForeColor = System.Drawing.Color.Black;
            this.txtMotif.Image = null;
            this.txtMotif.Location = new System.Drawing.Point(251, 296);
            this.txtMotif.MaxLength = 32767;
            this.txtMotif.Name = "txtMotif";
            this.txtMotif.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtMotif.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtMotif.PlaceholderText = "";
            this.txtMotif.Size = new System.Drawing.Size(380, 40);
            this.txtMotif.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 21);
            this.label1.TabIndex = 14;
            this.label1.Text = "Motif ";
            // 
            // btEnregistrer
            // 
            this.btEnregistrer.BackColor = System.Drawing.Color.Transparent;
            this.btEnregistrer.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btEnregistrer.BorderRadius = 8;
            this.btEnregistrer.ButtonText = "Enregistrer";
            this.btEnregistrer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEnregistrer.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(131)))), ((int)(((byte)(78)))));
            this.btEnregistrer.FlatAppearance.BorderSize = 0;
            this.btEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEnregistrer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEnregistrer.ForeColor = System.Drawing.Color.White;
            this.btEnregistrer.HoverBackColor = System.Drawing.Color.Green;
            this.btEnregistrer.Image = global::Cepima.Properties.Resources.save_30px;
            this.btEnregistrer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEnregistrer.Location = new System.Drawing.Point(251, 409);
            this.btEnregistrer.Name = "btEnregistrer";
            this.btEnregistrer.Size = new System.Drawing.Size(380, 50);
            this.btEnregistrer.TabIndex = 15;
            this.btEnregistrer.Text = "Enregistrer";
            this.btEnregistrer.TextColor = System.Drawing.Color.White;
            this.btEnregistrer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEnregistrer.UseVisualStyleBackColor = false;
            this.btEnregistrer.Click += new System.EventHandler(this.btEnregistrer_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 21);
            this.label7.TabIndex = 17;
            this.label7.Text = "Salaire concerné";
            // 
            // cbSalaire
            // 
            this.cbSalaire.ArrowColor = System.Drawing.Color.DimGray;
            this.cbSalaire.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbSalaire.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbSalaire.BackColor = System.Drawing.Color.White;
            this.cbSalaire.BorderColor = System.Drawing.Color.Silver;
            this.cbSalaire.BorderRadius = 8;
            this.cbSalaire.BorderSize = 1;
            this.cbSalaire.DropDownBackColor = System.Drawing.Color.White;
            this.cbSalaire.DropDownForeColor = System.Drawing.Color.Black;
            this.cbSalaire.DropDownSelectedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.cbSalaire.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbSalaire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSalaire.FocusBorderColor = System.Drawing.Color.Orange;
            this.cbSalaire.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSalaire.Location = new System.Drawing.Point(251, 186);
            this.cbSalaire.Name = "cbSalaire";
            this.cbSalaire.SelectedItem = null;
            this.cbSalaire.SelectedValue = null;
            this.cbSalaire.Size = new System.Drawing.Size(380, 40);
            this.cbSalaire.TabIndex = 16;
            // 
            // Ajouter_prime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(651, 471);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbSalaire);
            this.Controls.Add(this.btEnregistrer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudMontant);
            this.Controls.Add(this.dtpDatePrime);
            this.Controls.Add(this.txtMotif);
            this.Controls.Add(this.txtPersonnel);
            this.Controls.Add(this.customRoundedPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Ajouter_prime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter_prime";
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.Label lbSousTitre;
        private System.Windows.Forms.Label lbTitre;
        private AvatarControl avatarControl1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private RoundedNumericUpDown nudMontant;
        private Controls.MyDateTimePicker dtpDatePrime;
        private MyRoundedTextBox txtPersonnel;
        private MyRoundedTextBox txtMotif;
        private System.Windows.Forms.Label label1;
        private RoundedButton btEnregistrer;
        private System.Windows.Forms.Label label7;
        private MyRoundedComboBox cbSalaire;
    }
}