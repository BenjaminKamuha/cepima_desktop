namespace Cepima.MesForms
{
    partial class Form_add_patient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_add_patient));
            this.lb_titre = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.cbx_etat = new MyRoundedComboBox();
            this.cbx_genre = new MyRoundedComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dt_naissance = new System.Windows.Forms.DateTimePicker();
            this.tb_confession = new MyRoundedTextBox();
            this.tb_num_fiche = new MyRoundedTextBox();
            this.tb_niveau = new MyRoundedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_profession = new MyRoundedTextBox();
            this.tb_adresse = new MyRoundedTextBox();
            this.tb_phone_number = new MyRoundedTextBox();
            this.tb_prenom = new MyRoundedTextBox();
            this.tb_post_nom = new MyRoundedTextBox();
            this.tb_name_patient = new MyRoundedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_phone = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.tb_autres_membres_famille = new System.Windows.Forms.RichTextBox();
            this.tb_profession_mere = new MyRoundedTextBox();
            this.tb_nom_mere = new MyRoundedTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tb_profession_pere = new MyRoundedTextBox();
            this.tb_nom_pere = new MyRoundedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.customRoundedPanel3 = new CustomRoundedPanel();
            this.bt_cancel = new RoundedButton();
            this.bt_save_patient = new RoundedButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.tb_engagement_tuteur = new System.Windows.Forms.RichTextBox();
            this.tb_adresse_accompagnant = new System.Windows.Forms.RichTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tb_contact_garde = new MyRoundedTextBox();
            this.tb_garde_name = new MyRoundedTextBox();
            this.tb_telephone_accompagnant = new MyRoundedTextBox();
            this.tb_personne_accompagnante = new MyRoundedTextBox();
            this.label = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.customRoundedPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.customRoundedPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.customRoundedPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_titre
            // 
            this.lb_titre.AutoSize = true;
            this.lb_titre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titre.Location = new System.Drawing.Point(12, 9);
            this.lb_titre.Name = "lb_titre";
            this.lb_titre.Size = new System.Drawing.Size(175, 24);
            this.lb_titre.TabIndex = 0;
            this.lb_titre.Text = "Ajouter un patient";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.68222F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.31778F));
            this.tableLayoutPanel1.Controls.Add(this.customRoundedPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.customRoundedPanel2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1243, 351);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.Gray;
            this.customRoundedPanel1.BorderRadius = 8;
            this.customRoundedPanel1.BorderSize = 1;
            this.customRoundedPanel1.Controls.Add(this.cbx_etat);
            this.customRoundedPanel1.Controls.Add(this.cbx_genre);
            this.customRoundedPanel1.Controls.Add(this.panel1);
            this.customRoundedPanel1.Controls.Add(this.dt_naissance);
            this.customRoundedPanel1.Controls.Add(this.tb_confession);
            this.customRoundedPanel1.Controls.Add(this.tb_num_fiche);
            this.customRoundedPanel1.Controls.Add(this.tb_niveau);
            this.customRoundedPanel1.Controls.Add(this.label8);
            this.customRoundedPanel1.Controls.Add(this.tb_profession);
            this.customRoundedPanel1.Controls.Add(this.tb_adresse);
            this.customRoundedPanel1.Controls.Add(this.tb_phone_number);
            this.customRoundedPanel1.Controls.Add(this.tb_prenom);
            this.customRoundedPanel1.Controls.Add(this.tb_post_nom);
            this.customRoundedPanel1.Controls.Add(this.tb_name_patient);
            this.customRoundedPanel1.Controls.Add(this.label7);
            this.customRoundedPanel1.Controls.Add(this.label12);
            this.customRoundedPanel1.Controls.Add(this.label6);
            this.customRoundedPanel1.Controls.Add(this.label11);
            this.customRoundedPanel1.Controls.Add(this.label5);
            this.customRoundedPanel1.Controls.Add(this.tb_phone);
            this.customRoundedPanel1.Controls.Add(this.label10);
            this.customRoundedPanel1.Controls.Add(this.label21);
            this.customRoundedPanel1.Controls.Add(this.label4);
            this.customRoundedPanel1.Controls.Add(this.label9);
            this.customRoundedPanel1.Controls.Add(this.label3);
            this.customRoundedPanel1.Controls.Add(this.label2);
            this.customRoundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(3, 3);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.ShadowBlur = 10;
            this.customRoundedPanel1.ShadowBorderRadius = -1;
            this.customRoundedPanel1.ShadowColor = System.Drawing.Color.Black;
            this.customRoundedPanel1.ShadowEnabled = false;
            this.customRoundedPanel1.ShadowOffsetX = 0;
            this.customRoundedPanel1.ShadowOffsetY = 4;
            this.customRoundedPanel1.ShadowOpacity = 60;
            this.customRoundedPanel1.ShadowSpread = 0;
            this.customRoundedPanel1.Size = new System.Drawing.Size(798, 345);
            this.customRoundedPanel1.TabIndex = 0;
            // 
            // cbx_etat
            // 
            this.cbx_etat.ArrowColor = System.Drawing.Color.DimGray;
            this.cbx_etat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_etat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_etat.BorderColor = System.Drawing.Color.Silver;
            this.cbx_etat.BorderRadius = 8;
            this.cbx_etat.BorderSize = 1;
            this.cbx_etat.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_etat.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_etat.DropDownSelectedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.cbx_etat.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_etat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_etat.FocusBorderColor = System.Drawing.Color.Silver;
            this.cbx_etat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_etat.Location = new System.Drawing.Point(554, 208);
            this.cbx_etat.Name = "cbx_etat";
            this.cbx_etat.SelectedItem = null;
            this.cbx_etat.SelectedValue = null;
            this.cbx_etat.Size = new System.Drawing.Size(236, 34);
            this.cbx_etat.TabIndex = 46;
            // 
            // cbx_genre
            // 
            this.cbx_genre.ArrowColor = System.Drawing.Color.DimGray;
            this.cbx_genre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_genre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_genre.BorderColor = System.Drawing.Color.Silver;
            this.cbx_genre.BorderRadius = 8;
            this.cbx_genre.BorderSize = 1;
            this.cbx_genre.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_genre.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_genre.DropDownSelectedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.cbx_genre.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_genre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_genre.FocusBorderColor = System.Drawing.Color.Silver;
            this.cbx_genre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_genre.Location = new System.Drawing.Point(111, 206);
            this.cbx_genre.Name = "cbx_genre";
            this.cbx_genre.SelectedItem = null;
            this.cbx_genre.SelectedValue = null;
            this.cbx_genre.Size = new System.Drawing.Size(251, 34);
            this.cbx_genre.TabIndex = 45;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(226)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 35);
            this.panel1.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Informations personnelles";
            // 
            // dt_naissance
            // 
            this.dt_naissance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_naissance.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_naissance.Location = new System.Drawing.Point(111, 259);
            this.dt_naissance.Name = "dt_naissance";
            this.dt_naissance.Size = new System.Drawing.Size(251, 24);
            this.dt_naissance.TabIndex = 2;
            // 
            // tb_confession
            // 
            this.tb_confession.BackColor = System.Drawing.Color.White;
            this.tb_confession.BorderColor = System.Drawing.Color.Silver;
            this.tb_confession.BorderRadius = 8;
            this.tb_confession.BorderSize = 1;
            this.tb_confession.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_confession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_confession.ForeColor = System.Drawing.Color.Black;
            this.tb_confession.Image = null;
            this.tb_confession.Location = new System.Drawing.Point(554, 303);
            this.tb_confession.MaxLength = 32767;
            this.tb_confession.Multiline = true;
            this.tb_confession.Name = "tb_confession";
            this.tb_confession.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_confession.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_confession.PlaceholderText = "";
            this.tb_confession.Size = new System.Drawing.Size(236, 34);
            this.tb_confession.TabIndex = 43;
            // 
            // tb_num_fiche
            // 
            this.tb_num_fiche.BackColor = System.Drawing.Color.White;
            this.tb_num_fiche.BorderColor = System.Drawing.Color.Silver;
            this.tb_num_fiche.BorderRadius = 8;
            this.tb_num_fiche.BorderSize = 1;
            this.tb_num_fiche.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_num_fiche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_num_fiche.ForeColor = System.Drawing.Color.Black;
            this.tb_num_fiche.Image = null;
            this.tb_num_fiche.Location = new System.Drawing.Point(554, 55);
            this.tb_num_fiche.MaxLength = 32767;
            this.tb_num_fiche.Multiline = true;
            this.tb_num_fiche.Name = "tb_num_fiche";
            this.tb_num_fiche.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_num_fiche.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_num_fiche.PlaceholderText = "";
            this.tb_num_fiche.ReadOnly = true;
            this.tb_num_fiche.Size = new System.Drawing.Size(236, 34);
            this.tb_num_fiche.TabIndex = 43;
            // 
            // tb_niveau
            // 
            this.tb_niveau.BackColor = System.Drawing.Color.White;
            this.tb_niveau.BorderColor = System.Drawing.Color.Silver;
            this.tb_niveau.BorderRadius = 8;
            this.tb_niveau.BorderSize = 1;
            this.tb_niveau.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_niveau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_niveau.ForeColor = System.Drawing.Color.Black;
            this.tb_niveau.Image = null;
            this.tb_niveau.Location = new System.Drawing.Point(554, 252);
            this.tb_niveau.MaxLength = 32767;
            this.tb_niveau.Multiline = true;
            this.tb_niveau.Name = "tb_niveau";
            this.tb_niveau.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_niveau.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_niveau.PlaceholderText = "";
            this.tb_niveau.Size = new System.Drawing.Size(236, 34);
            this.tb_niveau.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(400, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 18);
            this.label8.TabIndex = 1;
            this.label8.Text = "Numéro fiche : ";
            // 
            // tb_profession
            // 
            this.tb_profession.BackColor = System.Drawing.Color.White;
            this.tb_profession.BorderColor = System.Drawing.Color.Silver;
            this.tb_profession.BorderRadius = 8;
            this.tb_profession.BorderSize = 1;
            this.tb_profession.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_profession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_profession.ForeColor = System.Drawing.Color.Black;
            this.tb_profession.Image = null;
            this.tb_profession.Location = new System.Drawing.Point(554, 157);
            this.tb_profession.MaxLength = 32767;
            this.tb_profession.Multiline = true;
            this.tb_profession.Name = "tb_profession";
            this.tb_profession.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_profession.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_profession.PlaceholderText = "";
            this.tb_profession.Size = new System.Drawing.Size(236, 34);
            this.tb_profession.TabIndex = 43;
            // 
            // tb_adresse
            // 
            this.tb_adresse.BackColor = System.Drawing.Color.White;
            this.tb_adresse.BorderColor = System.Drawing.Color.Silver;
            this.tb_adresse.BorderRadius = 8;
            this.tb_adresse.BorderSize = 1;
            this.tb_adresse.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_adresse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_adresse.ForeColor = System.Drawing.Color.Black;
            this.tb_adresse.Image = null;
            this.tb_adresse.Location = new System.Drawing.Point(554, 103);
            this.tb_adresse.MaxLength = 32767;
            this.tb_adresse.Multiline = true;
            this.tb_adresse.Name = "tb_adresse";
            this.tb_adresse.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_adresse.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_adresse.PlaceholderText = "";
            this.tb_adresse.Size = new System.Drawing.Size(236, 34);
            this.tb_adresse.TabIndex = 43;
            // 
            // tb_phone_number
            // 
            this.tb_phone_number.BackColor = System.Drawing.Color.White;
            this.tb_phone_number.BorderColor = System.Drawing.Color.Silver;
            this.tb_phone_number.BorderRadius = 8;
            this.tb_phone_number.BorderSize = 1;
            this.tb_phone_number.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_phone_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_phone_number.ForeColor = System.Drawing.Color.Black;
            this.tb_phone_number.Image = null;
            this.tb_phone_number.Location = new System.Drawing.Point(111, 303);
            this.tb_phone_number.MaxLength = 32767;
            this.tb_phone_number.Multiline = true;
            this.tb_phone_number.Name = "tb_phone_number";
            this.tb_phone_number.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_phone_number.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_phone_number.PlaceholderText = "";
            this.tb_phone_number.Size = new System.Drawing.Size(251, 34);
            this.tb_phone_number.TabIndex = 43;
            // 
            // tb_prenom
            // 
            this.tb_prenom.BackColor = System.Drawing.Color.White;
            this.tb_prenom.BorderColor = System.Drawing.Color.Silver;
            this.tb_prenom.BorderRadius = 8;
            this.tb_prenom.BorderSize = 1;
            this.tb_prenom.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_prenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_prenom.ForeColor = System.Drawing.Color.Black;
            this.tb_prenom.Image = null;
            this.tb_prenom.Location = new System.Drawing.Point(111, 157);
            this.tb_prenom.MaxLength = 32767;
            this.tb_prenom.Multiline = true;
            this.tb_prenom.Name = "tb_prenom";
            this.tb_prenom.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_prenom.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_prenom.PlaceholderText = "";
            this.tb_prenom.Size = new System.Drawing.Size(251, 34);
            this.tb_prenom.TabIndex = 43;
            // 
            // tb_post_nom
            // 
            this.tb_post_nom.BackColor = System.Drawing.Color.White;
            this.tb_post_nom.BorderColor = System.Drawing.Color.Silver;
            this.tb_post_nom.BorderRadius = 8;
            this.tb_post_nom.BorderSize = 1;
            this.tb_post_nom.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_post_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_post_nom.ForeColor = System.Drawing.Color.Black;
            this.tb_post_nom.Image = null;
            this.tb_post_nom.Location = new System.Drawing.Point(111, 108);
            this.tb_post_nom.MaxLength = 32767;
            this.tb_post_nom.Multiline = true;
            this.tb_post_nom.Name = "tb_post_nom";
            this.tb_post_nom.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_post_nom.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_post_nom.PlaceholderText = "";
            this.tb_post_nom.Size = new System.Drawing.Size(251, 34);
            this.tb_post_nom.TabIndex = 43;
            // 
            // tb_name_patient
            // 
            this.tb_name_patient.BackColor = System.Drawing.Color.White;
            this.tb_name_patient.BorderColor = System.Drawing.Color.Silver;
            this.tb_name_patient.BorderRadius = 8;
            this.tb_name_patient.BorderSize = 1;
            this.tb_name_patient.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_name_patient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_name_patient.ForeColor = System.Drawing.Color.Black;
            this.tb_name_patient.Image = null;
            this.tb_name_patient.Location = new System.Drawing.Point(111, 55);
            this.tb_name_patient.MaxLength = 32767;
            this.tb_name_patient.Multiline = true;
            this.tb_name_patient.Name = "tb_name_patient";
            this.tb_name_patient.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_name_patient.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_name_patient.PlaceholderText = "";
            this.tb_name_patient.Size = new System.Drawing.Size(251, 34);
            this.tb_name_patient.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(400, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "Adresse : ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(414, 303);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 18);
            this.label12.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 18);
            this.label6.TabIndex = 1;
            this.label6.Text = "Naissance : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(384, 315);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(162, 18);
            this.label11.TabIndex = 1;
            this.label11.Text = "Confession réligieuse : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Sexe : ";
            // 
            // tb_phone
            // 
            this.tb_phone.AutoSize = true;
            this.tb_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_phone.Location = new System.Drawing.Point(13, 315);
            this.tb_phone.Name = "tb_phone";
            this.tb_phone.Size = new System.Drawing.Size(89, 18);
            this.tb_phone.TabIndex = 1;
            this.tb_phone.Text = "Téléphone : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(400, 263);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 18);
            this.label10.TabIndex = 1;
            this.label10.Text = "Niveau d\'étude : ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(400, 220);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(74, 18);
            this.label21.TabIndex = 1;
            this.label21.Text = "Etat civil : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Prenom : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(400, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 18);
            this.label9.TabIndex = 1;
            this.label9.Text = "Profession : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Post_nom : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nom : ";
            // 
            // customRoundedPanel2
            // 
            this.customRoundedPanel2.BorderColor = System.Drawing.Color.Gray;
            this.customRoundedPanel2.BorderRadius = 8;
            this.customRoundedPanel2.BorderSize = 1;
            this.customRoundedPanel2.Controls.Add(this.panel2);
            this.customRoundedPanel2.Controls.Add(this.tb_autres_membres_famille);
            this.customRoundedPanel2.Controls.Add(this.tb_profession_mere);
            this.customRoundedPanel2.Controls.Add(this.tb_nom_mere);
            this.customRoundedPanel2.Controls.Add(this.label18);
            this.customRoundedPanel2.Controls.Add(this.tb_profession_pere);
            this.customRoundedPanel2.Controls.Add(this.tb_nom_pere);
            this.customRoundedPanel2.Controls.Add(this.label14);
            this.customRoundedPanel2.Controls.Add(this.label15);
            this.customRoundedPanel2.Controls.Add(this.label16);
            this.customRoundedPanel2.Controls.Add(this.label17);
            this.customRoundedPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customRoundedPanel2.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel2.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel2.Location = new System.Drawing.Point(807, 3);
            this.customRoundedPanel2.Name = "customRoundedPanel2";
            this.customRoundedPanel2.ShadowBlur = 10;
            this.customRoundedPanel2.ShadowBorderRadius = -1;
            this.customRoundedPanel2.ShadowColor = System.Drawing.Color.Black;
            this.customRoundedPanel2.ShadowEnabled = false;
            this.customRoundedPanel2.ShadowOffsetX = 0;
            this.customRoundedPanel2.ShadowOffsetY = 4;
            this.customRoundedPanel2.ShadowOpacity = 60;
            this.customRoundedPanel2.ShadowSpread = 0;
            this.customRoundedPanel2.Size = new System.Drawing.Size(433, 345);
            this.customRoundedPanel2.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(178)))));
            this.panel2.Controls.Add(this.label13);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(433, 35);
            this.panel2.TabIndex = 44;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Green;
            this.label13.Location = new System.Drawing.Point(21, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(178, 18);
            this.label13.TabIndex = 0;
            this.label13.Text = "Informations familiales";
            // 
            // tb_autres_membres_famille
            // 
            this.tb_autres_membres_famille.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_autres_membres_famille.Location = new System.Drawing.Point(14, 266);
            this.tb_autres_membres_famille.Name = "tb_autres_membres_famille";
            this.tb_autres_membres_famille.Size = new System.Drawing.Size(402, 67);
            this.tb_autres_membres_famille.TabIndex = 44;
            this.tb_autres_membres_famille.Text = "";
            // 
            // tb_profession_mere
            // 
            this.tb_profession_mere.BackColor = System.Drawing.Color.White;
            this.tb_profession_mere.BorderColor = System.Drawing.Color.Silver;
            this.tb_profession_mere.BorderRadius = 8;
            this.tb_profession_mere.BorderSize = 1;
            this.tb_profession_mere.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_profession_mere.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_profession_mere.ForeColor = System.Drawing.Color.Black;
            this.tb_profession_mere.Image = null;
            this.tb_profession_mere.Location = new System.Drawing.Point(174, 199);
            this.tb_profession_mere.MaxLength = 32767;
            this.tb_profession_mere.Multiline = true;
            this.tb_profession_mere.Name = "tb_profession_mere";
            this.tb_profession_mere.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_profession_mere.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_profession_mere.PlaceholderText = "";
            this.tb_profession_mere.Size = new System.Drawing.Size(242, 34);
            this.tb_profession_mere.TabIndex = 43;
            // 
            // tb_nom_mere
            // 
            this.tb_nom_mere.BackColor = System.Drawing.Color.White;
            this.tb_nom_mere.BorderColor = System.Drawing.Color.Silver;
            this.tb_nom_mere.BorderRadius = 8;
            this.tb_nom_mere.BorderSize = 1;
            this.tb_nom_mere.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_nom_mere.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nom_mere.ForeColor = System.Drawing.Color.Black;
            this.tb_nom_mere.Image = null;
            this.tb_nom_mere.Location = new System.Drawing.Point(174, 145);
            this.tb_nom_mere.MaxLength = 32767;
            this.tb_nom_mere.Multiline = true;
            this.tb_nom_mere.Name = "tb_nom_mere";
            this.tb_nom_mere.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_nom_mere.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_nom_mere.PlaceholderText = "";
            this.tb_nom_mere.Size = new System.Drawing.Size(242, 34);
            this.tb_nom_mere.TabIndex = 43;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(21, 245);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(331, 18);
            this.label18.TabIndex = 1;
            this.label18.Text = "Autres membres de la famille qui aident le malade";
            // 
            // tb_profession_pere
            // 
            this.tb_profession_pere.BackColor = System.Drawing.Color.White;
            this.tb_profession_pere.BorderColor = System.Drawing.Color.Silver;
            this.tb_profession_pere.BorderRadius = 8;
            this.tb_profession_pere.BorderSize = 1;
            this.tb_profession_pere.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_profession_pere.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_profession_pere.ForeColor = System.Drawing.Color.Black;
            this.tb_profession_pere.Image = null;
            this.tb_profession_pere.Location = new System.Drawing.Point(174, 92);
            this.tb_profession_pere.MaxLength = 32767;
            this.tb_profession_pere.Multiline = true;
            this.tb_profession_pere.Name = "tb_profession_pere";
            this.tb_profession_pere.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_profession_pere.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_profession_pere.PlaceholderText = "";
            this.tb_profession_pere.Size = new System.Drawing.Size(242, 34);
            this.tb_profession_pere.TabIndex = 43;
            // 
            // tb_nom_pere
            // 
            this.tb_nom_pere.BackColor = System.Drawing.Color.White;
            this.tb_nom_pere.BorderColor = System.Drawing.Color.Silver;
            this.tb_nom_pere.BorderRadius = 8;
            this.tb_nom_pere.BorderSize = 1;
            this.tb_nom_pere.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_nom_pere.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nom_pere.ForeColor = System.Drawing.Color.Black;
            this.tb_nom_pere.Image = null;
            this.tb_nom_pere.Location = new System.Drawing.Point(174, 43);
            this.tb_nom_pere.MaxLength = 32767;
            this.tb_nom_pere.Multiline = true;
            this.tb_nom_pere.Name = "tb_nom_pere";
            this.tb_nom_pere.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_nom_pere.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_nom_pere.PlaceholderText = "";
            this.tb_nom_pere.Size = new System.Drawing.Size(242, 34);
            this.tb_nom_pere.TabIndex = 43;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 18);
            this.label14.TabIndex = 1;
            this.label14.Text = "Nom du père : ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(3, 104);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(145, 18);
            this.label15.TabIndex = 1;
            this.label15.Text = "Profession du père : ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(3, 157);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(126, 18);
            this.label16.TabIndex = 1;
            this.label16.Text = "Nom de la mère : ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(3, 208);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(165, 18);
            this.label17.TabIndex = 1;
            this.label17.Text = "Profession de la mère : ";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.customRoundedPanel3, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 393);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1243, 238);
            this.tableLayoutPanel2.TabIndex = 44;
            // 
            // customRoundedPanel3
            // 
            this.customRoundedPanel3.BorderColor = System.Drawing.Color.Gray;
            this.customRoundedPanel3.BorderRadius = 8;
            this.customRoundedPanel3.BorderSize = 1;
            this.customRoundedPanel3.Controls.Add(this.bt_cancel);
            this.customRoundedPanel3.Controls.Add(this.bt_save_patient);
            this.customRoundedPanel3.Controls.Add(this.panel3);
            this.customRoundedPanel3.Controls.Add(this.tb_engagement_tuteur);
            this.customRoundedPanel3.Controls.Add(this.tb_adresse_accompagnant);
            this.customRoundedPanel3.Controls.Add(this.label22);
            this.customRoundedPanel3.Controls.Add(this.label25);
            this.customRoundedPanel3.Controls.Add(this.label24);
            this.customRoundedPanel3.Controls.Add(this.label20);
            this.customRoundedPanel3.Controls.Add(this.label23);
            this.customRoundedPanel3.Controls.Add(this.label);
            this.customRoundedPanel3.Controls.Add(this.tb_contact_garde);
            this.customRoundedPanel3.Controls.Add(this.tb_garde_name);
            this.customRoundedPanel3.Controls.Add(this.tb_telephone_accompagnant);
            this.customRoundedPanel3.Controls.Add(this.tb_personne_accompagnante);
            this.customRoundedPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customRoundedPanel3.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel3.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel3.Location = new System.Drawing.Point(3, 3);
            this.customRoundedPanel3.Name = "customRoundedPanel3";
            this.customRoundedPanel3.ShadowBlur = 10;
            this.customRoundedPanel3.ShadowBorderRadius = -1;
            this.customRoundedPanel3.ShadowColor = System.Drawing.Color.Black;
            this.customRoundedPanel3.ShadowEnabled = false;
            this.customRoundedPanel3.ShadowOffsetX = 0;
            this.customRoundedPanel3.ShadowOffsetY = 4;
            this.customRoundedPanel3.ShadowOpacity = 60;
            this.customRoundedPanel3.ShadowSpread = 0;
            this.customRoundedPanel3.Size = new System.Drawing.Size(1237, 232);
            this.customRoundedPanel3.TabIndex = 0;
            // 
            // bt_cancel
            // 
            this.bt_cancel.BackColor = System.Drawing.Color.Transparent;
            this.bt_cancel.BorderColor = System.Drawing.Color.DodgerBlue;
            this.bt_cancel.BorderRadius = 10;
            this.bt_cancel.ButtonText = "Annuler";
            this.bt_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_cancel.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_cancel.FlatAppearance.BorderSize = 0;
            this.bt_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_cancel.ForeColor = System.Drawing.Color.White;
            this.bt_cancel.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_cancel.Image = global::Cepima.Properties.Resources.cancel_30px;
            this.bt_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_cancel.Location = new System.Drawing.Point(898, 165);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(148, 39);
            this.bt_cancel.TabIndex = 48;
            this.bt_cancel.Text = "Annuler";
            this.bt_cancel.TextColor = System.Drawing.Color.White;
            this.bt_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_cancel.UseVisualStyleBackColor = false;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // bt_save_patient
            // 
            this.bt_save_patient.BackColor = System.Drawing.Color.Transparent;
            this.bt_save_patient.BorderColor = System.Drawing.Color.DodgerBlue;
            this.bt_save_patient.BorderRadius = 10;
            this.bt_save_patient.ButtonText = "Enregistrer";
            this.bt_save_patient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_save_patient.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_save_patient.FlatAppearance.BorderSize = 0;
            this.bt_save_patient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_save_patient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save_patient.ForeColor = System.Drawing.Color.White;
            this.bt_save_patient.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_save_patient.Image = global::Cepima.Properties.Resources.save_30px;
            this.bt_save_patient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_save_patient.Location = new System.Drawing.Point(1086, 166);
            this.bt_save_patient.Name = "bt_save_patient";
            this.bt_save_patient.Size = new System.Drawing.Size(148, 39);
            this.bt_save_patient.TabIndex = 48;
            this.bt_save_patient.Text = "Enregistrer";
            this.bt_save_patient.TextColor = System.Drawing.Color.White;
            this.bt_save_patient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_save_patient.UseVisualStyleBackColor = false;
            this.bt_save_patient.Click += new System.EventHandler(this.bt_save_patient_Click_1);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(190)))), ((int)(((byte)(231)))));
            this.panel3.Controls.Add(this.label19);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1237, 33);
            this.panel3.TabIndex = 47;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(20)))), ((int)(((byte)(90)))));
            this.label19.Location = new System.Drawing.Point(19, 8);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(285, 18);
            this.label19.TabIndex = 0;
            this.label19.Text = "Personnes accompagnantes / Tuteur";
            // 
            // tb_engagement_tuteur
            // 
            this.tb_engagement_tuteur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_engagement_tuteur.Location = new System.Drawing.Point(952, 65);
            this.tb_engagement_tuteur.Name = "tb_engagement_tuteur";
            this.tb_engagement_tuteur.Size = new System.Drawing.Size(268, 63);
            this.tb_engagement_tuteur.TabIndex = 46;
            this.tb_engagement_tuteur.Text = "";
            // 
            // tb_adresse_accompagnant
            // 
            this.tb_adresse_accompagnant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tb_adresse_accompagnant.Location = new System.Drawing.Point(224, 154);
            this.tb_adresse_accompagnant.Name = "tb_adresse_accompagnant";
            this.tb_adresse_accompagnant.Size = new System.Drawing.Size(668, 50);
            this.tb_adresse_accompagnant.TabIndex = 45;
            this.tb_adresse_accompagnant.Text = "";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(14, 166);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(180, 18);
            this.label22.TabIndex = 1;
            this.label22.Text = "Adresse  accompagnant : ";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(949, 40);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(164, 18);
            this.label25.TabIndex = 1;
            this.label25.Text = "Engagement du tuteur : ";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(511, 62);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(114, 18);
            this.label24.TabIndex = 1;
            this.label24.Text = "Nom du garde : ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(14, 74);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(194, 18);
            this.label20.TabIndex = 1;
            this.label20.Text = "Personne accompagnante : ";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(511, 108);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(113, 18);
            this.label23.TabIndex = 1;
            this.label23.Text = "Contact garde : ";
            // 
            // tb_contact_garde
            // 
            this.tb_contact_garde.BackColor = System.Drawing.Color.White;
            this.tb_contact_garde.BorderColor = System.Drawing.Color.Silver;
            this.tb_contact_garde.BorderRadius = 8;
            this.tb_contact_garde.BorderSize = 1;
            this.tb_contact_garde.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_contact_garde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_contact_garde.ForeColor = System.Drawing.Color.Black;
            this.tb_contact_garde.Image = null;
            this.tb_contact_garde.Location = new System.Drawing.Point(644, 96);
            this.tb_contact_garde.MaxLength = 32767;
            this.tb_contact_garde.Multiline = true;
            this.tb_contact_garde.Name = "tb_contact_garde";
            this.tb_contact_garde.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_contact_garde.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_contact_garde.PlaceholderText = "";
            this.tb_contact_garde.Size = new System.Drawing.Size(269, 34);
            this.tb_contact_garde.TabIndex = 43;
            // 
            // tb_garde_name
            // 
            this.tb_garde_name.BackColor = System.Drawing.Color.White;
            this.tb_garde_name.BorderColor = System.Drawing.Color.Silver;
            this.tb_garde_name.BorderRadius = 8;
            this.tb_garde_name.BorderSize = 1;
            this.tb_garde_name.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_garde_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_garde_name.ForeColor = System.Drawing.Color.Black;
            this.tb_garde_name.Image = null;
            this.tb_garde_name.Location = new System.Drawing.Point(644, 50);
            this.tb_garde_name.MaxLength = 32767;
            this.tb_garde_name.Multiline = true;
            this.tb_garde_name.Name = "tb_garde_name";
            this.tb_garde_name.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_garde_name.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_garde_name.PlaceholderText = "";
            this.tb_garde_name.Size = new System.Drawing.Size(269, 34);
            this.tb_garde_name.TabIndex = 43;
            // 
            // tb_telephone_accompagnant
            // 
            this.tb_telephone_accompagnant.BackColor = System.Drawing.Color.White;
            this.tb_telephone_accompagnant.BorderColor = System.Drawing.Color.Silver;
            this.tb_telephone_accompagnant.BorderRadius = 8;
            this.tb_telephone_accompagnant.BorderSize = 1;
            this.tb_telephone_accompagnant.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_telephone_accompagnant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_telephone_accompagnant.ForeColor = System.Drawing.Color.Black;
            this.tb_telephone_accompagnant.Image = null;
            this.tb_telephone_accompagnant.Location = new System.Drawing.Point(223, 108);
            this.tb_telephone_accompagnant.MaxLength = 32767;
            this.tb_telephone_accompagnant.Multiline = true;
            this.tb_telephone_accompagnant.Name = "tb_telephone_accompagnant";
            this.tb_telephone_accompagnant.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_telephone_accompagnant.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_telephone_accompagnant.PlaceholderText = "";
            this.tb_telephone_accompagnant.Size = new System.Drawing.Size(269, 34);
            this.tb_telephone_accompagnant.TabIndex = 43;
            // 
            // tb_personne_accompagnante
            // 
            this.tb_personne_accompagnante.BackColor = System.Drawing.Color.White;
            this.tb_personne_accompagnante.BorderColor = System.Drawing.Color.Silver;
            this.tb_personne_accompagnante.BorderRadius = 8;
            this.tb_personne_accompagnante.BorderSize = 1;
            this.tb_personne_accompagnante.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_personne_accompagnante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_personne_accompagnante.ForeColor = System.Drawing.Color.Black;
            this.tb_personne_accompagnante.Image = null;
            this.tb_personne_accompagnante.Location = new System.Drawing.Point(223, 62);
            this.tb_personne_accompagnante.MaxLength = 32767;
            this.tb_personne_accompagnante.Multiline = true;
            this.tb_personne_accompagnante.Name = "tb_personne_accompagnante";
            this.tb_personne_accompagnante.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_personne_accompagnante.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_personne_accompagnante.PlaceholderText = "";
            this.tb_personne_accompagnante.Size = new System.Drawing.Size(269, 34);
            this.tb_personne_accompagnante.TabIndex = 43;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(14, 120);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(191, 18);
            this.label.TabIndex = 1;
            this.label.Text = "Téléphone accompagnant : ";
            // 
            // Form_add_patient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1267, 635);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lb_titre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_add_patient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form_add_patient_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.customRoundedPanel2.ResumeLayout(false);
            this.customRoundedPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.customRoundedPanel3.ResumeLayout(false);
            this.customRoundedPanel3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_titre;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dt_naissance;
        private MyRoundedTextBox tb_confession;
        private MyRoundedTextBox tb_niveau;
        private MyRoundedTextBox tb_profession;
        private MyRoundedTextBox tb_adresse;
        private MyRoundedTextBox tb_prenom;
        private MyRoundedTextBox tb_post_nom;
        private MyRoundedTextBox tb_name_patient;
        private MyRoundedTextBox tb_num_fiche;
        private CustomRoundedPanel customRoundedPanel2;
        private System.Windows.Forms.RichTextBox tb_autres_membres_famille;
        private System.Windows.Forms.Label label13;
        private MyRoundedTextBox tb_profession_mere;
        private MyRoundedTextBox tb_nom_mere;
        private MyRoundedTextBox tb_profession_pere;
        private MyRoundedTextBox tb_nom_pere;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CustomRoundedPanel customRoundedPanel3;
        private System.Windows.Forms.RichTextBox tb_engagement_tuteur;
        private System.Windows.Forms.RichTextBox tb_adresse_accompagnant;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private MyRoundedTextBox tb_contact_garde;
        private MyRoundedTextBox tb_garde_name;
        private MyRoundedTextBox tb_telephone_accompagnant;
        private MyRoundedTextBox tb_personne_accompagnante;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private MyRoundedComboBox cbx_genre;
        private MyRoundedTextBox tb_phone_number;
        private System.Windows.Forms.Label tb_phone;
        private RoundedButton bt_save_patient;
        private RoundedButton bt_cancel;
        private MyRoundedComboBox cbx_etat;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label;
    }
}