namespace Cepima.MesForms.Personnel
{
    partial class Ajouter_salaire
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btEnregistrer = new RoundedButton();
            this.nudSalaireBase = new RoundedNumericUpDown();
            this.dtpDatePaiement = new Cepima.Controls.MyDateTimePicker();
            this.cbMois = new MyRoundedComboBox();
            this.txtPersonnel = new MyRoundedTextBox();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.lbSousTitre = new System.Windows.Forms.Label();
            this.lbTitre = new System.Windows.Forms.Label();
            this.avatarControl1 = new AvatarControl();
            this.customRoundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Personnel ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(63, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mois";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(63, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "Date de paiement";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(63, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "Salaire de base";
            // 
            // btEnregistrer
            // 
            this.btEnregistrer.BackColor = System.Drawing.Color.Transparent;
            this.btEnregistrer.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btEnregistrer.BorderRadius = 8;
            this.btEnregistrer.ButtonText = "Enregistrer";
            this.btEnregistrer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEnregistrer.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(198)))));
            this.btEnregistrer.FlatAppearance.BorderSize = 0;
            this.btEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEnregistrer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEnregistrer.ForeColor = System.Drawing.Color.White;
            this.btEnregistrer.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btEnregistrer.Image = global::Cepima.Properties.Resources.save_30px;
            this.btEnregistrer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEnregistrer.Location = new System.Drawing.Point(259, 409);
            this.btEnregistrer.Name = "btEnregistrer";
            this.btEnregistrer.Size = new System.Drawing.Size(380, 50);
            this.btEnregistrer.TabIndex = 5;
            this.btEnregistrer.Text = "Enregistrer";
            this.btEnregistrer.TextColor = System.Drawing.Color.White;
            this.btEnregistrer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEnregistrer.UseVisualStyleBackColor = false;
            this.btEnregistrer.Click += new System.EventHandler(this.btEnregistrer_Click);
            // 
            // nudSalaireBase
            // 
            this.nudSalaireBase.BackColor = System.Drawing.Color.White;
            this.nudSalaireBase.BorderColor = System.Drawing.Color.Silver;
            this.nudSalaireBase.BorderRadius = 8;
            this.nudSalaireBase.ButtonBackColor = System.Drawing.Color.White;
            this.nudSalaireBase.ButtonFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.nudSalaireBase.ButtonForeColor = System.Drawing.Color.DimGray;
            this.nudSalaireBase.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.nudSalaireBase.DecimalPlaces = 1;
            this.nudSalaireBase.FocusBorderColor = System.Drawing.Color.Silver;
            this.nudSalaireBase.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.nudSalaireBase.ForeColor = System.Drawing.Color.Black;
            this.nudSalaireBase.Location = new System.Drawing.Point(259, 310);
            this.nudSalaireBase.MinimumSize = new System.Drawing.Size(77, 32);
            this.nudSalaireBase.Name = "nudSalaireBase";
            this.nudSalaireBase.Size = new System.Drawing.Size(380, 40);
            this.nudSalaireBase.TabIndex = 4;
            this.nudSalaireBase.ThousandsSeparator = true;
            // 
            // dtpDatePaiement
            // 
            this.dtpDatePaiement.BackColor = System.Drawing.Color.White;
            this.dtpDatePaiement.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.dtpDatePaiement.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.dtpDatePaiement.BorderRadius = 8;
            this.dtpDatePaiement.BorderSize = 1;
            this.dtpDatePaiement.CalendarBackColor = System.Drawing.Color.White;
            this.dtpDatePaiement.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatePaiement.CalendarHeight = 280;
            this.dtpDatePaiement.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.dtpDatePaiement.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpDatePaiement.Checked = true;
            this.dtpDatePaiement.CustomFormat = "dd/MM/yyyy";
            this.dtpDatePaiement.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDatePaiement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.dtpDatePaiement.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDatePaiement.Location = new System.Drawing.Point(259, 254);
            this.dtpDatePaiement.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDatePaiement.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDatePaiement.MinimumSize = new System.Drawing.Size(180, 28);
            this.dtpDatePaiement.Name = "dtpDatePaiement";
            this.dtpDatePaiement.SelectedDayColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.dtpDatePaiement.ShowCheckBox = false;
            this.dtpDatePaiement.ShowUpDown = false;
            this.dtpDatePaiement.Size = new System.Drawing.Size(380, 40);
            this.dtpDatePaiement.TabIndex = 3;
            this.dtpDatePaiement.Value = new System.DateTime(2026, 10, 30, 0, 0, 0, 0);
            // 
            // cbMois
            // 
            this.cbMois.ArrowColor = System.Drawing.Color.DimGray;
            this.cbMois.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbMois.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbMois.BackColor = System.Drawing.Color.White;
            this.cbMois.BorderColor = System.Drawing.Color.Silver;
            this.cbMois.BorderRadius = 8;
            this.cbMois.BorderSize = 1;
            this.cbMois.DropDownBackColor = System.Drawing.Color.White;
            this.cbMois.DropDownForeColor = System.Drawing.Color.Black;
            this.cbMois.DropDownSelectedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.cbMois.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbMois.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMois.FocusBorderColor = System.Drawing.Color.Silver;
            this.cbMois.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMois.Location = new System.Drawing.Point(259, 198);
            this.cbMois.Name = "cbMois";
            this.cbMois.SelectedItem = null;
            this.cbMois.SelectedValue = null;
            this.cbMois.Size = new System.Drawing.Size(380, 40);
            this.cbMois.TabIndex = 2;
            // 
            // txtPersonnel
            // 
            this.txtPersonnel.BackColor = System.Drawing.Color.White;
            this.txtPersonnel.BorderColor = System.Drawing.Color.Silver;
            this.txtPersonnel.BorderRadius = 8;
            this.txtPersonnel.BorderSize = 1;
            this.txtPersonnel.FocusBorderColor = System.Drawing.Color.Silver;
            this.txtPersonnel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonnel.ForeColor = System.Drawing.Color.Black;
            this.txtPersonnel.Image = null;
            this.txtPersonnel.Location = new System.Drawing.Point(259, 142);
            this.txtPersonnel.MaxLength = 32767;
            this.txtPersonnel.Name = "txtPersonnel";
            this.txtPersonnel.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPersonnel.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtPersonnel.PlaceholderText = "";
            this.txtPersonnel.ReadOnly = true;
            this.txtPersonnel.Size = new System.Drawing.Size(380, 40);
            this.txtPersonnel.TabIndex = 1;
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(198)))));
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
            this.customRoundedPanel1.TabIndex = 0;
            // 
            // lbSousTitre
            // 
            this.lbSousTitre.AutoSize = true;
            this.lbSousTitre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSousTitre.ForeColor = System.Drawing.Color.White;
            this.lbSousTitre.Location = new System.Drawing.Point(112, 72);
            this.lbSousTitre.Name = "lbSousTitre";
            this.lbSousTitre.Size = new System.Drawing.Size(236, 21);
            this.lbSousTitre.TabIndex = 2;
            this.lbSousTitre.Text = "Enregistrer ou modifier le salaire";
            // 
            // lbTitre
            // 
            this.lbTitre.AutoSize = true;
            this.lbTitre.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lbTitre.ForeColor = System.Drawing.Color.White;
            this.lbTitre.Location = new System.Drawing.Point(111, 26);
            this.lbTitre.Name = "lbTitre";
            this.lbTitre.Size = new System.Drawing.Size(91, 32);
            this.lbTitre.TabIndex = 2;
            this.lbTitre.Text = "Salaire";
            // 
            // avatarControl1
            // 
            this.avatarControl1.Avatar = global::Cepima.Properties.Resources.Salaire2;
            this.avatarControl1.BackColor = System.Drawing.Color.Transparent;
            this.avatarControl1.BorderColor = System.Drawing.Color.White;
            this.avatarControl1.BorderSize = 2;
            this.avatarControl1.Location = new System.Drawing.Point(12, 12);
            this.avatarControl1.Name = "avatarControl1";
            this.avatarControl1.Size = new System.Drawing.Size(80, 80);
            this.avatarControl1.TabIndex = 1;
            // 
            // Ajouter_salaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(651, 471);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btEnregistrer);
            this.Controls.Add(this.nudSalaireBase);
            this.Controls.Add(this.dtpDatePaiement);
            this.Controls.Add(this.cbMois);
            this.Controls.Add(this.txtPersonnel);
            this.Controls.Add(this.customRoundedPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Ajouter_salaire";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajout/ Modification du salaire";
            this.Load += new System.EventHandler(this.Ajouter_salaire_Load);
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel1;
        private AvatarControl avatarControl1;
        private System.Windows.Forms.Label lbSousTitre;
        private System.Windows.Forms.Label lbTitre;
        private MyRoundedTextBox txtPersonnel;
        private MyRoundedComboBox cbMois;
        private Controls.MyDateTimePicker dtpDatePaiement;
        private RoundedNumericUpDown nudSalaireBase;
        private RoundedButton btEnregistrer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}