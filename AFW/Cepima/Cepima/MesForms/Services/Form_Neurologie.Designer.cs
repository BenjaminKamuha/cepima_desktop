namespace Cepima.MesForms.Services
{
    partial class Form_Neurologie
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
            this.lb_nom_patient = new System.Windows.Forms.Label();
            this.lb_num_fiche = new System.Windows.Forms.Label();
            this.lb_sexe_age = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.tb_memoire = new MyRoundedTextBox();
            this.tb_nerf = new MyRoundedTextBox();
            this.tb_force = new MyRoundedTextBox();
            this.tb_tonus = new MyRoundedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_reflexe = new MyRoundedTextBox();
            this.tb_sensibilite = new MyRoundedTextBox();
            this.tb_coordination = new MyRoundedTextBox();
            this.tb_marche = new MyRoundedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_save_examen = new RoundedButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbx_conscience = new MyRoundedComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_orientation = new MyRoundedComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_langage = new MyRoundedComboBox();
            this.bunifuRoundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.DarkBlue;
            this.bunifuRoundedPanel1.BorderRadius = 8;
            this.bunifuRoundedPanel1.BorderSize = 0;
            this.bunifuRoundedPanel1.Controls.Add(this.lb_nom_patient);
            this.bunifuRoundedPanel1.Controls.Add(this.lb_num_fiche);
            this.bunifuRoundedPanel1.Controls.Add(this.lb_sexe_age);
            this.bunifuRoundedPanel1.Controls.Add(this.pictureBox1);
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(4, 3);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 10;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(532, 93);
            this.bunifuRoundedPanel1.TabIndex = 0;
            // 
            // lb_nom_patient
            // 
            this.lb_nom_patient.AutoSize = true;
            this.lb_nom_patient.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nom_patient.Location = new System.Drawing.Point(119, 28);
            this.lb_nom_patient.Name = "lb_nom_patient";
            this.lb_nom_patient.Size = new System.Drawing.Size(105, 18);
            this.lb_nom_patient.TabIndex = 32;
            this.lb_nom_patient.Text = "Kambale Jean ";
            // 
            // lb_num_fiche
            // 
            this.lb_num_fiche.AutoSize = true;
            this.lb_num_fiche.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_num_fiche.Location = new System.Drawing.Point(396, 48);
            this.lb_num_fiche.Name = "lb_num_fiche";
            this.lb_num_fiche.Size = new System.Drawing.Size(70, 18);
            this.lb_num_fiche.TabIndex = 30;
            this.lb_num_fiche.Text = "CEP-0023";
            // 
            // lb_sexe_age
            // 
            this.lb_sexe_age.AutoSize = true;
            this.lb_sexe_age.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sexe_age.Location = new System.Drawing.Point(119, 60);
            this.lb_sexe_age.Name = "lb_sexe_age";
            this.lb_sexe_age.Size = new System.Drawing.Size(117, 18);
            this.lb_sexe_age.TabIndex = 31;
            this.lb_sexe_age.Text = "HOMME - 32 ans";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(145, 105);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(177, 18);
            this.title.TabIndex = 30;
            this.title.Text = "EXAMEN NEUROLOGIQUE";
            // 
            // tb_memoire
            // 
            this.tb_memoire.BackColor = System.Drawing.Color.White;
            this.tb_memoire.BorderColor = System.Drawing.Color.Silver;
            this.tb_memoire.BorderRadius = 8;
            this.tb_memoire.BorderSize = 1;
            this.tb_memoire.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_memoire.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.tb_memoire.ForeColor = System.Drawing.Color.Black;
            this.tb_memoire.Image = null;
            this.tb_memoire.Location = new System.Drawing.Point(4, 323);
            this.tb_memoire.MaxLength = 32767;
            this.tb_memoire.Multiline = true;
            this.tb_memoire.Name = "tb_memoire";
            this.tb_memoire.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_memoire.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_memoire.PlaceholderText = "";
            this.tb_memoire.Size = new System.Drawing.Size(255, 36);
            this.tb_memoire.TabIndex = 43;
            // 
            // tb_nerf
            // 
            this.tb_nerf.BackColor = System.Drawing.Color.White;
            this.tb_nerf.BorderColor = System.Drawing.Color.Silver;
            this.tb_nerf.BorderRadius = 8;
            this.tb_nerf.BorderSize = 1;
            this.tb_nerf.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_nerf.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.tb_nerf.ForeColor = System.Drawing.Color.Black;
            this.tb_nerf.Image = null;
            this.tb_nerf.Location = new System.Drawing.Point(4, 395);
            this.tb_nerf.MaxLength = 32767;
            this.tb_nerf.Multiline = true;
            this.tb_nerf.Name = "tb_nerf";
            this.tb_nerf.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_nerf.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_nerf.PlaceholderText = "";
            this.tb_nerf.Size = new System.Drawing.Size(255, 36);
            this.tb_nerf.TabIndex = 43;
            // 
            // tb_force
            // 
            this.tb_force.BackColor = System.Drawing.Color.White;
            this.tb_force.BorderColor = System.Drawing.Color.Silver;
            this.tb_force.BorderRadius = 8;
            this.tb_force.BorderSize = 1;
            this.tb_force.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_force.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.tb_force.ForeColor = System.Drawing.Color.Black;
            this.tb_force.Image = null;
            this.tb_force.Location = new System.Drawing.Point(4, 466);
            this.tb_force.MaxLength = 32767;
            this.tb_force.Multiline = true;
            this.tb_force.Name = "tb_force";
            this.tb_force.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_force.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_force.PlaceholderText = "";
            this.tb_force.Size = new System.Drawing.Size(255, 36);
            this.tb_force.TabIndex = 43;
            // 
            // tb_tonus
            // 
            this.tb_tonus.BackColor = System.Drawing.Color.White;
            this.tb_tonus.BorderColor = System.Drawing.Color.Silver;
            this.tb_tonus.BorderRadius = 8;
            this.tb_tonus.BorderSize = 1;
            this.tb_tonus.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_tonus.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.tb_tonus.ForeColor = System.Drawing.Color.Black;
            this.tb_tonus.Image = null;
            this.tb_tonus.Location = new System.Drawing.Point(4, 533);
            this.tb_tonus.MaxLength = 32767;
            this.tb_tonus.Multiline = true;
            this.tb_tonus.Name = "tb_tonus";
            this.tb_tonus.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_tonus.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_tonus.PlaceholderText = "";
            this.tb_tonus.Size = new System.Drawing.Size(255, 36);
            this.tb_tonus.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 18);
            this.label4.TabIndex = 32;
            this.label4.Text = "Mémoire ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 374);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 18);
            this.label5.TabIndex = 32;
            this.label5.Text = "Nerfs craniens ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 445);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 18);
            this.label6.TabIndex = 32;
            this.label6.Text = "Force musculaire";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 512);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 18);
            this.label7.TabIndex = 32;
            this.label7.Text = "Tonus";
            // 
            // tb_reflexe
            // 
            this.tb_reflexe.BackColor = System.Drawing.Color.White;
            this.tb_reflexe.BorderColor = System.Drawing.Color.Silver;
            this.tb_reflexe.BorderRadius = 8;
            this.tb_reflexe.BorderSize = 1;
            this.tb_reflexe.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_reflexe.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.tb_reflexe.ForeColor = System.Drawing.Color.Black;
            this.tb_reflexe.Image = null;
            this.tb_reflexe.Location = new System.Drawing.Point(272, 323);
            this.tb_reflexe.MaxLength = 32767;
            this.tb_reflexe.Multiline = true;
            this.tb_reflexe.Name = "tb_reflexe";
            this.tb_reflexe.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_reflexe.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_reflexe.PlaceholderText = "";
            this.tb_reflexe.Size = new System.Drawing.Size(255, 36);
            this.tb_reflexe.TabIndex = 43;
            // 
            // tb_sensibilite
            // 
            this.tb_sensibilite.BackColor = System.Drawing.Color.White;
            this.tb_sensibilite.BorderColor = System.Drawing.Color.Silver;
            this.tb_sensibilite.BorderRadius = 8;
            this.tb_sensibilite.BorderSize = 1;
            this.tb_sensibilite.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_sensibilite.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.tb_sensibilite.ForeColor = System.Drawing.Color.Black;
            this.tb_sensibilite.Image = null;
            this.tb_sensibilite.Location = new System.Drawing.Point(272, 395);
            this.tb_sensibilite.MaxLength = 32767;
            this.tb_sensibilite.Multiline = true;
            this.tb_sensibilite.Name = "tb_sensibilite";
            this.tb_sensibilite.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_sensibilite.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_sensibilite.PlaceholderText = "";
            this.tb_sensibilite.Size = new System.Drawing.Size(255, 36);
            this.tb_sensibilite.TabIndex = 43;
            // 
            // tb_coordination
            // 
            this.tb_coordination.BackColor = System.Drawing.Color.White;
            this.tb_coordination.BorderColor = System.Drawing.Color.Silver;
            this.tb_coordination.BorderRadius = 8;
            this.tb_coordination.BorderSize = 1;
            this.tb_coordination.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_coordination.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.tb_coordination.ForeColor = System.Drawing.Color.Black;
            this.tb_coordination.Image = null;
            this.tb_coordination.Location = new System.Drawing.Point(272, 466);
            this.tb_coordination.MaxLength = 32767;
            this.tb_coordination.Multiline = true;
            this.tb_coordination.Name = "tb_coordination";
            this.tb_coordination.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_coordination.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_coordination.PlaceholderText = "";
            this.tb_coordination.Size = new System.Drawing.Size(255, 36);
            this.tb_coordination.TabIndex = 43;
            // 
            // tb_marche
            // 
            this.tb_marche.BackColor = System.Drawing.Color.White;
            this.tb_marche.BorderColor = System.Drawing.Color.Silver;
            this.tb_marche.BorderRadius = 8;
            this.tb_marche.BorderSize = 1;
            this.tb_marche.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_marche.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.tb_marche.ForeColor = System.Drawing.Color.Black;
            this.tb_marche.Image = null;
            this.tb_marche.Location = new System.Drawing.Point(272, 533);
            this.tb_marche.MaxLength = 32767;
            this.tb_marche.Multiline = true;
            this.tb_marche.Name = "tb_marche";
            this.tb_marche.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_marche.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_marche.PlaceholderText = "";
            this.tb_marche.Size = new System.Drawing.Size(255, 36);
            this.tb_marche.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(286, 302);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 18);
            this.label8.TabIndex = 32;
            this.label8.Text = "Reflèxes";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(283, 374);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 18);
            this.label9.TabIndex = 32;
            this.label9.Text = "Sensibilité";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(274, 445);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 18);
            this.label10.TabIndex = 32;
            this.label10.Text = "Coordination";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(274, 512);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 18);
            this.label11.TabIndex = 32;
            this.label11.Text = "Marche";
            // 
            // btn_save_examen
            // 
            this.btn_save_examen.BackColor = System.Drawing.Color.Transparent;
            this.btn_save_examen.BorderColor = System.Drawing.Color.White;
            this.btn_save_examen.BorderRadius = 10;
            this.btn_save_examen.BorderSize = 0;
            this.btn_save_examen.ButtonText = "Enregistrer l\'examen neurologique";
            this.btn_save_examen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save_examen.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_save_examen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save_examen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_examen.ForeColor = System.Drawing.Color.White;
            this.btn_save_examen.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_save_examen.Image = global::Cepima.Properties.Resources.save_30px;
            this.btn_save_examen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save_examen.Location = new System.Drawing.Point(109, 590);
            this.btn_save_examen.Name = "btn_save_examen";
            this.btn_save_examen.Size = new System.Drawing.Size(320, 45);
            this.btn_save_examen.TabIndex = 44;
            this.btn_save_examen.Text = "Enregistrer l\'examen neurologique";
            this.btn_save_examen.TextColor = System.Drawing.Color.White;
            this.btn_save_examen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save_examen.UseVisualStyleBackColor = false;
            this.btn_save_examen.Click += new System.EventHandler(this.btn_save_examen_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(14, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cbx_conscience
            // 
            this.cbx_conscience.ArrowColor = System.Drawing.Color.DimGray;
            this.cbx_conscience.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_conscience.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_conscience.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbx_conscience.BorderRadius = 8;
            this.cbx_conscience.BorderSize = 1;
            this.cbx_conscience.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_conscience.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_conscience.DropDownSelectedBackColor = System.Drawing.Color.Silver;
            this.cbx_conscience.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_conscience.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_conscience.DropDownWidth = 250;
            this.cbx_conscience.FocusBorderColor = System.Drawing.Color.Silver;
            this.cbx_conscience.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_conscience.Location = new System.Drawing.Point(12, 149);
            this.cbx_conscience.MinimumSize = new System.Drawing.Size(80, 36);
            this.cbx_conscience.Name = "cbx_conscience";
            this.cbx_conscience.SelectedItem = null;
            this.cbx_conscience.SelectedValue = null;
            this.cbx_conscience.Size = new System.Drawing.Size(515, 36);
            this.cbx_conscience.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 45;
            this.label1.Text = "Conscience : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 17);
            this.label2.TabIndex = 45;
            this.label2.Text = "Orientation Temporo spatiale ";
            // 
            // cbx_orientation
            // 
            this.cbx_orientation.ArrowColor = System.Drawing.Color.DimGray;
            this.cbx_orientation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_orientation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_orientation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbx_orientation.BorderRadius = 8;
            this.cbx_orientation.BorderSize = 1;
            this.cbx_orientation.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_orientation.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_orientation.DropDownSelectedBackColor = System.Drawing.Color.Silver;
            this.cbx_orientation.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_orientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_orientation.DropDownWidth = 250;
            this.cbx_orientation.FocusBorderColor = System.Drawing.Color.Silver;
            this.cbx_orientation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_orientation.Location = new System.Drawing.Point(12, 207);
            this.cbx_orientation.MinimumSize = new System.Drawing.Size(80, 36);
            this.cbx_orientation.Name = "cbx_orientation";
            this.cbx_orientation.SelectedItem = null;
            this.cbx_orientation.SelectedValue = null;
            this.cbx_orientation.Size = new System.Drawing.Size(515, 36);
            this.cbx_orientation.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 45;
            this.label3.Text = "Langage";
            // 
            // cbx_langage
            // 
            this.cbx_langage.ArrowColor = System.Drawing.Color.DimGray;
            this.cbx_langage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_langage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_langage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbx_langage.BorderRadius = 8;
            this.cbx_langage.BorderSize = 1;
            this.cbx_langage.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_langage.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_langage.DropDownSelectedBackColor = System.Drawing.Color.Silver;
            this.cbx_langage.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_langage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_langage.DropDownWidth = 250;
            this.cbx_langage.FocusBorderColor = System.Drawing.Color.Silver;
            this.cbx_langage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_langage.Location = new System.Drawing.Point(12, 263);
            this.cbx_langage.MinimumSize = new System.Drawing.Size(80, 36);
            this.cbx_langage.Name = "cbx_langage";
            this.cbx_langage.SelectedItem = null;
            this.cbx_langage.SelectedValue = null;
            this.cbx_langage.Size = new System.Drawing.Size(515, 36);
            this.cbx_langage.TabIndex = 46;
            // 
            // Form_Neurologie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(539, 647);
            this.Controls.Add(this.cbx_langage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbx_orientation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbx_conscience);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_save_examen);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_marche);
            this.Controls.Add(this.tb_coordination);
            this.Controls.Add(this.tb_tonus);
            this.Controls.Add(this.tb_sensibilite);
            this.Controls.Add(this.tb_force);
            this.Controls.Add(this.tb_reflexe);
            this.Controls.Add(this.tb_nerf);
            this.Controls.Add(this.tb_memoire);
            this.Controls.Add(this.title);
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Name = "Form_Neurologie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Neurologie";
            this.Load += new System.EventHandler(this.Form_Neurologie_Load);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.bunifuRoundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_nom_patient;
        private System.Windows.Forms.Label lb_num_fiche;
        private System.Windows.Forms.Label lb_sexe_age;
        private System.Windows.Forms.Label title;
        private MyRoundedTextBox tb_memoire;
        private MyRoundedTextBox tb_nerf;
        private MyRoundedTextBox tb_force;
        private MyRoundedTextBox tb_tonus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private MyRoundedTextBox tb_reflexe;
        private MyRoundedTextBox tb_sensibilite;
        private MyRoundedTextBox tb_coordination;
        private MyRoundedTextBox tb_marche;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private RoundedButton btn_save_examen;
        private MyRoundedComboBox cbx_conscience;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MyRoundedComboBox cbx_orientation;
        private System.Windows.Forms.Label label3;
        private MyRoundedComboBox cbx_langage;
    }
}