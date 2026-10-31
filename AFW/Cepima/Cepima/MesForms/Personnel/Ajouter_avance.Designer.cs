namespace Cepima.MesForms.Personnel
{
    partial class Ajouter_Avance
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
            this.dtpDateAvance = new Cepima.Controls.MyDateTimePicker();
            this.txtPersonnel = new MyRoundedTextBox();
            this.btEnregistrer = new RoundedButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSalaire = new MyRoundedComboBox();
            this.txtReste = new MyRoundedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.customRoundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(58)))), ((int)(((byte)(199)))));
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
            this.customRoundedPanel1.TabIndex = 16;
            // 
            // lbSousTitre
            // 
            this.lbSousTitre.AutoSize = true;
            this.lbSousTitre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSousTitre.ForeColor = System.Drawing.Color.White;
            this.lbSousTitre.Location = new System.Drawing.Point(112, 72);
            this.lbSousTitre.Name = "lbSousTitre";
            this.lbSousTitre.Size = new System.Drawing.Size(253, 21);
            this.lbSousTitre.TabIndex = 2;
            this.lbSousTitre.Text = "Enregistrer ou modifier une avance";
            // 
            // lbTitre
            // 
            this.lbTitre.AutoSize = true;
            this.lbTitre.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitre.ForeColor = System.Drawing.Color.White;
            this.lbTitre.Location = new System.Drawing.Point(111, 26);
            this.lbTitre.Name = "lbTitre";
            this.lbTitre.Size = new System.Drawing.Size(97, 32);
            this.lbTitre.TabIndex = 2;
            this.lbTitre.Text = "Avance";
            // 
            // avatarControl1
            // 
            this.avatarControl1.Avatar = global::Cepima.Properties.Resources.avance1;
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
            this.label6.Location = new System.Drawing.Point(31, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 21);
            this.label6.TabIndex = 21;
            this.label6.Text = "Montant de la prime";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 21);
            this.label5.TabIndex = 22;
            this.label5.Text = "Date de l\'avance";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 21);
            this.label3.TabIndex = 24;
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
            this.nudMontant.Location = new System.Drawing.Point(251, 295);
            this.nudMontant.MinimumSize = new System.Drawing.Size(77, 32);
            this.nudMontant.Name = "nudMontant";
            this.nudMontant.Size = new System.Drawing.Size(380, 40);
            this.nudMontant.TabIndex = 20;
            this.nudMontant.ThousandsSeparator = true;
            this.nudMontant.ValueChanged += new System.EventHandler(this.nudMontant_ValueChanged);
            // 
            // dtpDateAvance
            // 
            this.dtpDateAvance.BackColor = System.Drawing.Color.White;
            this.dtpDateAvance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.dtpDateAvance.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.dtpDateAvance.BorderRadius = 8;
            this.dtpDateAvance.BorderSize = 1;
            this.dtpDateAvance.CalendarBackColor = System.Drawing.Color.White;
            this.dtpDateAvance.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateAvance.CalendarHeight = 280;
            this.dtpDateAvance.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.dtpDateAvance.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpDateAvance.Checked = true;
            this.dtpDateAvance.CustomFormat = "dd/MM/yyyy";
            this.dtpDateAvance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDateAvance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.dtpDateAvance.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDateAvance.Location = new System.Drawing.Point(251, 230);
            this.dtpDateAvance.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDateAvance.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDateAvance.MinimumSize = new System.Drawing.Size(180, 28);
            this.dtpDateAvance.Name = "dtpDateAvance";
            this.dtpDateAvance.SelectedDayColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.dtpDateAvance.ShowCheckBox = false;
            this.dtpDateAvance.ShowUpDown = false;
            this.dtpDateAvance.Size = new System.Drawing.Size(380, 40);
            this.dtpDateAvance.TabIndex = 19;
            this.dtpDateAvance.Value = new System.DateTime(2026, 10, 30, 0, 0, 0, 0);
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
            this.txtPersonnel.Location = new System.Drawing.Point(251, 122);
            this.txtPersonnel.MaxLength = 32767;
            this.txtPersonnel.Name = "txtPersonnel";
            this.txtPersonnel.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPersonnel.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtPersonnel.PlaceholderText = "";
            this.txtPersonnel.ReadOnly = true;
            this.txtPersonnel.Size = new System.Drawing.Size(380, 40);
            this.txtPersonnel.TabIndex = 18;
            // 
            // btEnregistrer
            // 
            this.btEnregistrer.BackColor = System.Drawing.Color.Transparent;
            this.btEnregistrer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(58)))), ((int)(((byte)(199)))));
            this.btEnregistrer.BorderRadius = 8;
            this.btEnregistrer.ButtonText = "Enregistrer";
            this.btEnregistrer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEnregistrer.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(58)))), ((int)(((byte)(199)))));
            this.btEnregistrer.FlatAppearance.BorderSize = 0;
            this.btEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEnregistrer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEnregistrer.ForeColor = System.Drawing.Color.White;
            this.btEnregistrer.HoverBackColor = System.Drawing.Color.MediumPurple;
            this.btEnregistrer.Image = global::Cepima.Properties.Resources.save_30px;
            this.btEnregistrer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEnregistrer.Location = new System.Drawing.Point(251, 427);
            this.btEnregistrer.Name = "btEnregistrer";
            this.btEnregistrer.Size = new System.Drawing.Size(380, 45);
            this.btEnregistrer.TabIndex = 25;
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
            this.label7.Location = new System.Drawing.Point(31, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 21);
            this.label7.TabIndex = 27;
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
            this.cbSalaire.Location = new System.Drawing.Point(251, 176);
            this.cbSalaire.Name = "cbSalaire";
            this.cbSalaire.SelectedItem = null;
            this.cbSalaire.SelectedValue = null;
            this.cbSalaire.Size = new System.Drawing.Size(380, 40);
            this.cbSalaire.TabIndex = 26;
            this.cbSalaire.SelectedIndexChanged += new System.EventHandler(this.cbSalaire_SelectedIndexChanged);
            // 
            // txtReste
            // 
            this.txtReste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(239)))), ((int)(((byte)(245)))));
            this.txtReste.BorderColor = System.Drawing.Color.Silver;
            this.txtReste.BorderRadius = 8;
            this.txtReste.BorderSize = 1;
            this.txtReste.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(239)))), ((int)(((byte)(245)))));
            this.txtReste.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReste.ForeColor = System.Drawing.Color.Black;
            this.txtReste.Image = null;
            this.txtReste.Location = new System.Drawing.Point(251, 358);
            this.txtReste.MaxLength = 32767;
            this.txtReste.Name = "txtReste";
            this.txtReste.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtReste.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtReste.PlaceholderText = "";
            this.txtReste.ReadOnly = true;
            this.txtReste.Size = new System.Drawing.Size(380, 41);
            this.txtReste.TabIndex = 17;
            this.txtReste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "Reste";
            // 
            // Ajouter_Avance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(651, 489);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbSalaire);
            this.Controls.Add(this.customRoundedPanel1);
            this.Controls.Add(this.btEnregistrer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudMontant);
            this.Controls.Add(this.dtpDateAvance);
            this.Controls.Add(this.txtReste);
            this.Controls.Add(this.txtPersonnel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Ajouter_Avance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter_Avance";
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
        private RoundedButton btEnregistrer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private RoundedNumericUpDown nudMontant;
        private Controls.MyDateTimePicker dtpDateAvance;
        private MyRoundedTextBox txtPersonnel;
        private System.Windows.Forms.Label label7;
        private MyRoundedComboBox cbSalaire;
        private MyRoundedTextBox txtReste;
        private System.Windows.Forms.Label label2;
    }
}