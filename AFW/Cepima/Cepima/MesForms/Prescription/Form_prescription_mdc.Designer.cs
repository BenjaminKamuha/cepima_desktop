namespace Cepima.MesForms.Prescription
{
    partial class Form_prescription_mdc
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
            this.fl_prescription_ligne = new System.Windows.Forms.FlowLayoutPanel();
            this.cbx_filter_category = new MyRoundedComboBox();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.fl_medoc = new System.Windows.Forms.FlowLayoutPanel();
            this.tb_search = new MyRoundedTextBox();
            this.btn_save_prescription = new RoundedButton();
            this.bunifuRoundedPanel1 = new BunifuRoundedPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_nom_patient = new System.Windows.Forms.Label();
            this.lb_num_fiche = new System.Windows.Forms.Label();
            this.lb_sexe_age = new System.Windows.Forms.Label();
            this.customRoundedPanel1.SuspendLayout();
            this.bunifuRoundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // fl_prescription_ligne
            // 
            this.fl_prescription_ligne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fl_prescription_ligne.AutoScroll = true;
            this.fl_prescription_ligne.BackColor = System.Drawing.Color.White;
            this.fl_prescription_ligne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fl_prescription_ligne.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fl_prescription_ligne.Location = new System.Drawing.Point(12, 123);
            this.fl_prescription_ligne.Name = "fl_prescription_ligne";
            this.fl_prescription_ligne.Size = new System.Drawing.Size(950, 115);
            this.fl_prescription_ligne.TabIndex = 10;
            // 
            // cbx_filter_category
            // 
            this.cbx_filter_category.ArrowColor = System.Drawing.Color.DodgerBlue;
            this.cbx_filter_category.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_filter_category.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_filter_category.BorderColor = System.Drawing.Color.Silver;
            this.cbx_filter_category.BorderRadius = 8;
            this.cbx_filter_category.BorderSize = 1;
            this.cbx_filter_category.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_filter_category.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_filter_category.DropDownSelectedBackColor = System.Drawing.Color.Silver;
            this.cbx_filter_category.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_filter_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_filter_category.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.cbx_filter_category.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_filter_category.Location = new System.Drawing.Point(10, 250);
            this.cbx_filter_category.MinimumSize = new System.Drawing.Size(80, 30);
            this.cbx_filter_category.Name = "cbx_filter_category";
            this.cbx_filter_category.SelectedItem = null;
            this.cbx_filter_category.SelectedValue = null;
            this.cbx_filter_category.Size = new System.Drawing.Size(188, 34);
            this.cbx_filter_category.TabIndex = 6;
            this.cbx_filter_category.SelectedIndexChanged += new System.EventHandler(this.cbx_filter_category_SelectedIndexChanged);
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customRoundedPanel1.BackColor = System.Drawing.Color.White;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 5;
            this.customRoundedPanel1.BorderSize = 2;
            this.customRoundedPanel1.Controls.Add(this.fl_medoc);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(12, 290);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 14);
            this.customRoundedPanel1.ShadowBlur = 10;
            this.customRoundedPanel1.ShadowBorderRadius = -1;
            this.customRoundedPanel1.ShadowColor = System.Drawing.Color.Black;
            this.customRoundedPanel1.ShadowEnabled = true;
            this.customRoundedPanel1.ShadowOffsetX = 0;
            this.customRoundedPanel1.ShadowOffsetY = 4;
            this.customRoundedPanel1.ShadowOpacity = 60;
            this.customRoundedPanel1.ShadowSpread = 0;
            this.customRoundedPanel1.Size = new System.Drawing.Size(1067, 258);
            this.customRoundedPanel1.TabIndex = 9;
            // 
            // fl_medoc
            // 
            this.fl_medoc.AutoScroll = true;
            this.fl_medoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fl_medoc.Location = new System.Drawing.Point(10, 10);
            this.fl_medoc.Name = "fl_medoc";
            this.fl_medoc.Size = new System.Drawing.Size(1047, 234);
            this.fl_medoc.TabIndex = 3;
            // 
            // tb_search
            // 
            this.tb_search.BackColor = System.Drawing.Color.White;
            this.tb_search.BorderColor = System.Drawing.Color.Silver;
            this.tb_search.BorderRadius = 8;
            this.tb_search.BorderSize = 1;
            this.tb_search.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_search.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search.ForeColor = System.Drawing.Color.Black;
            this.tb_search.Image = global::Cepima.Properties.Resources.search_25px;
            this.tb_search.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_search.ImagePadding = 4;
            this.tb_search.Location = new System.Drawing.Point(204, 250);
            this.tb_search.MaxLength = 32767;
            this.tb_search.Name = "tb_search";
            this.tb_search.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_search.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_search.PlaceholderText = "Rechercher un produit";
            this.tb_search.Size = new System.Drawing.Size(273, 34);
            this.tb_search.TabIndex = 7;
            this.tb_search.TextChanged += new System.EventHandler(this.tb_search_TextChanged_1);
            // 
            // btn_save_prescription
            // 
            this.btn_save_prescription.BackColor = System.Drawing.Color.Transparent;
            this.btn_save_prescription.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_save_prescription.BorderRadius = 10;
            this.btn_save_prescription.ButtonText = "Valider";
            this.btn_save_prescription.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save_prescription.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_save_prescription.FlatAppearance.BorderSize = 0;
            this.btn_save_prescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save_prescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_prescription.ForeColor = System.Drawing.Color.White;
            this.btn_save_prescription.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_save_prescription.Image = global::Cepima.Properties.Resources.ok_30px1;
            this.btn_save_prescription.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save_prescription.Location = new System.Drawing.Point(968, 165);
            this.btn_save_prescription.Name = "btn_save_prescription";
            this.btn_save_prescription.Size = new System.Drawing.Size(101, 34);
            this.btn_save_prescription.TabIndex = 6;
            this.btn_save_prescription.Text = "Valider";
            this.btn_save_prescription.TextColor = System.Drawing.Color.White;
            this.btn_save_prescription.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save_prescription.UseVisualStyleBackColor = false;
            this.btn_save_prescription.Click += new System.EventHandler(this.btn_save_prescription_Click);
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.DarkBlue;
            this.bunifuRoundedPanel1.BorderRadius = 2;
            this.bunifuRoundedPanel1.BorderSize = 0;
            this.bunifuRoundedPanel1.Controls.Add(this.pictureBox1);
            this.bunifuRoundedPanel1.Controls.Add(this.lb_nom_patient);
            this.bunifuRoundedPanel1.Controls.Add(this.lb_num_fiche);
            this.bunifuRoundedPanel1.Controls.Add(this.lb_sexe_age);
            this.bunifuRoundedPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 5;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(1105, 80);
            this.bunifuRoundedPanel1.TabIndex = 39;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // lb_nom_patient
            // 
            this.lb_nom_patient.AutoSize = true;
            this.lb_nom_patient.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nom_patient.Location = new System.Drawing.Point(119, 17);
            this.lb_nom_patient.Name = "lb_nom_patient";
            this.lb_nom_patient.Size = new System.Drawing.Size(105, 18);
            this.lb_nom_patient.TabIndex = 29;
            this.lb_nom_patient.Text = "Kambale Jean ";
            // 
            // lb_num_fiche
            // 
            this.lb_num_fiche.AutoSize = true;
            this.lb_num_fiche.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_num_fiche.Location = new System.Drawing.Point(999, 34);
            this.lb_num_fiche.Name = "lb_num_fiche";
            this.lb_num_fiche.Size = new System.Drawing.Size(70, 18);
            this.lb_num_fiche.TabIndex = 23;
            this.lb_num_fiche.Text = "CEP-0023";
            // 
            // lb_sexe_age
            // 
            this.lb_sexe_age.AutoSize = true;
            this.lb_sexe_age.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sexe_age.Location = new System.Drawing.Point(119, 49);
            this.lb_sexe_age.Name = "lb_sexe_age";
            this.lb_sexe_age.Size = new System.Drawing.Size(117, 18);
            this.lb_sexe_age.TabIndex = 23;
            this.lb_sexe_age.Text = "HOMME - 32 ans";
            // 
            // Form_prescription_mdc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1105, 590);
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Controls.Add(this.btn_save_prescription);
            this.Controls.Add(this.fl_prescription_ligne);
            this.Controls.Add(this.cbx_filter_category);
            this.Controls.Add(this.customRoundedPanel1);
            this.Controls.Add(this.tb_search);
            this.Name = "Form_prescription_mdc";
            this.Text = "Form_prescription_mdc";
            this.customRoundedPanel1.ResumeLayout(false);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.bunifuRoundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fl_prescription_ligne;
        private MyRoundedComboBox cbx_filter_category;
        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.FlowLayoutPanel fl_medoc;
        private MyRoundedTextBox tb_search;
        private RoundedButton btn_save_prescription;
        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_nom_patient;
        private System.Windows.Forms.Label lb_num_fiche;
        private System.Windows.Forms.Label lb_sexe_age;
    }
}