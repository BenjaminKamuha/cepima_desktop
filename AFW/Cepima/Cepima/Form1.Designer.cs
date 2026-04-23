namespace Cepima
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.bt_close = new System.Windows.Forms.Button();
            this.bt_minus = new System.Windows.Forms.Button();
            this.picture_statut = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_role = new System.Windows.Forms.Label();
            this.lb_username = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lb_version = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel_center_main = new System.Windows.Forms.Panel();
            this.pan = new System.Windows.Forms.Panel();
            this.panel_sous_menu = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lb_sous_menu = new System.Windows.Forms.Label();
            this.picture_image_menu = new System.Windows.Forms.PictureBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.bt_hospitalisation = new System.Windows.Forms.Button();
            this.bt_setting = new System.Windows.Forms.Button();
            this.bt_personnel = new System.Windows.Forms.Button();
            this.bt_comptability = new System.Windows.Forms.Button();
            this.bt_EEG = new System.Windows.Forms.Button();
            this.bt_soin = new System.Windows.Forms.Button();
            this.bt_pharmacie = new System.Windows.Forms.Button();
            this.bt_reception = new System.Windows.Forms.Button();
            this.bt_acceuil = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_statut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.pan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_image_menu)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1091, 73);
            this.panel1.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.Controls.Add(this.bt_close);
            this.panel9.Controls.Add(this.bt_minus);
            this.panel9.Controls.Add(this.picture_statut);
            this.panel9.Controls.Add(this.label2);
            this.panel9.Controls.Add(this.lb_role);
            this.panel9.Controls.Add(this.lb_username);
            this.panel9.Controls.Add(this.pictureBox2);
            this.panel9.Location = new System.Drawing.Point(832, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(252, 64);
            this.panel9.TabIndex = 3;
            // 
            // bt_close
            // 
            this.bt_close.FlatAppearance.BorderSize = 0;
            this.bt_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_close.Image = global::Cepima.Properties.Resources.close_rounded;
            this.bt_close.Location = new System.Drawing.Point(206, 33);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(41, 29);
            this.bt_close.TabIndex = 3;
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // bt_minus
            // 
            this.bt_minus.FlatAppearance.BorderSize = 0;
            this.bt_minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_minus.Image = global::Cepima.Properties.Resources.minus_30px;
            this.bt_minus.Location = new System.Drawing.Point(145, 33);
            this.bt_minus.Name = "bt_minus";
            this.bt_minus.Size = new System.Drawing.Size(41, 29);
            this.bt_minus.TabIndex = 3;
            this.bt_minus.UseVisualStyleBackColor = true;
            this.bt_minus.Click += new System.EventHandler(this.bt_minus_Click);
            // 
            // picture_statut
            // 
            this.picture_statut.Image = global::Cepima.Properties.Resources.dot_point;
            this.picture_statut.Location = new System.Drawing.Point(213, 6);
            this.picture_statut.Name = "picture_statut";
            this.picture_statut.Size = new System.Drawing.Size(19, 21);
            this.picture_statut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_statut.TabIndex = 3;
            this.picture_statut.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F);
            this.label2.Location = new System.Drawing.Point(168, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Statut";
            // 
            // lb_role
            // 
            this.lb_role.AutoSize = true;
            this.lb_role.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_role.Location = new System.Drawing.Point(76, 33);
            this.lb_role.Name = "lb_role";
            this.lb_role.Size = new System.Drawing.Size(43, 15);
            this.lb_role.TabIndex = 3;
            this.lb_role.Text = "Admin";
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_username.Location = new System.Drawing.Point(76, 5);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(76, 19);
            this.lb_username.TabIndex = 3;
            this.lb_username.Text = "username";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Cepima.Properties.Resources.contacts_40px;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(67, 56);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(426, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "CEPIMA - Centre Ukandilama";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.cepima_logo;
            this.pictureBox1.Location = new System.Drawing.Point(5, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1086, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 68);
            this.panel4.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1086, 5);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 73);
            this.panel3.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lb_version);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.pictureBox3);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(89, 559);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1002, 41);
            this.panel5.TabIndex = 3;
            // 
            // lb_version
            // 
            this.lb_version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_version.AutoSize = true;
            this.lb_version.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_version.Location = new System.Drawing.Point(953, 16);
            this.lb_version.Name = "lb_version";
            this.lb_version.Size = new System.Drawing.Size(31, 14);
            this.lb_version.TabIndex = 4;
            this.lb_version.Text = "1.0.0";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(536, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 14);
            this.label6.TabIndex = 4;
            this.label6.Text = "14 : 25";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Cepima.Properties.Resources.wi_fi_off_20px;
            this.pictureBox3.Location = new System.Drawing.Point(109, 11);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(894, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Version : ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(427, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Synchronisation : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Serveur local : ";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(997, 5);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(5, 36);
            this.panel7.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1002, 5);
            this.panel6.TabIndex = 4;
            // 
            // panel_center_main
            // 
            this.panel_center_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_center_main.BackColor = System.Drawing.Color.Transparent;
            this.panel_center_main.Location = new System.Drawing.Point(262, 79);
            this.panel_center_main.Name = "panel_center_main";
            this.panel_center_main.Size = new System.Drawing.Size(822, 474);
            this.panel_center_main.TabIndex = 4;
            // 
            // pan
            // 
            this.pan.Controls.Add(this.panel_sous_menu);
            this.pan.Controls.Add(this.panel11);
            this.pan.Controls.Add(this.lb_sous_menu);
            this.pan.Controls.Add(this.picture_image_menu);
            this.pan.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan.Location = new System.Drawing.Point(89, 73);
            this.pan.Name = "pan";
            this.pan.Size = new System.Drawing.Size(161, 486);
            this.pan.TabIndex = 5;
            // 
            // panel_sous_menu
            // 
            this.panel_sous_menu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_sous_menu.AutoScroll = true;
            this.panel_sous_menu.Location = new System.Drawing.Point(6, 155);
            this.panel_sous_menu.Name = "panel_sous_menu";
            this.panel_sous_menu.Size = new System.Drawing.Size(152, 328);
            this.panel_sous_menu.TabIndex = 0;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.panel11.Location = new System.Drawing.Point(4, 144);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(151, 5);
            this.panel11.TabIndex = 0;
            this.panel11.Visible = false;
            // 
            // lb_sous_menu
            // 
            this.lb_sous_menu.AutoSize = true;
            this.lb_sous_menu.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sous_menu.Location = new System.Drawing.Point(24, 115);
            this.lb_sous_menu.Name = "lb_sous_menu";
            this.lb_sous_menu.Size = new System.Drawing.Size(83, 23);
            this.lb_sous_menu.TabIndex = 1;
            this.lb_sous_menu.Text = "Contexte";
            this.lb_sous_menu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_sous_menu.Visible = false;
            // 
            // picture_image_menu
            // 
            this.picture_image_menu.Location = new System.Drawing.Point(11, 6);
            this.picture_image_menu.Name = "picture_image_menu";
            this.picture_image_menu.Size = new System.Drawing.Size(139, 106);
            this.picture_image_menu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_image_menu.TabIndex = 0;
            this.picture_image_menu.TabStop = false;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(250, 73);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(4, 486);
            this.panel10.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.panel8.Controls.Add(this.bt_hospitalisation);
            this.panel8.Controls.Add(this.bt_setting);
            this.panel8.Controls.Add(this.bt_personnel);
            this.panel8.Controls.Add(this.bt_comptability);
            this.panel8.Controls.Add(this.bt_EEG);
            this.panel8.Controls.Add(this.bt_soin);
            this.panel8.Controls.Add(this.bt_pharmacie);
            this.panel8.Controls.Add(this.bt_reception);
            this.panel8.Controls.Add(this.bt_acceuil);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 73);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(89, 527);
            this.panel8.TabIndex = 2;
            // 
            // bt_hospitalisation
            // 
            this.bt_hospitalisation.FlatAppearance.BorderSize = 0;
            this.bt_hospitalisation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_hospitalisation.Image = global::Cepima.Properties.Resources.hospital_bed_40px;
            this.bt_hospitalisation.Location = new System.Drawing.Point(4, 419);
            this.bt_hospitalisation.Name = "bt_hospitalisation";
            this.bt_hospitalisation.Size = new System.Drawing.Size(83, 47);
            this.bt_hospitalisation.TabIndex = 0;
            this.bt_hospitalisation.UseVisualStyleBackColor = true;
            this.bt_hospitalisation.Click += new System.EventHandler(this.bt_hospitalisation_Click);
            // 
            // bt_setting
            // 
            this.bt_setting.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bt_setting.FlatAppearance.BorderSize = 0;
            this.bt_setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_setting.Image = global::Cepima.Properties.Resources.settings_40px;
            this.bt_setting.Location = new System.Drawing.Point(6, 477);
            this.bt_setting.Name = "bt_setting";
            this.bt_setting.Size = new System.Drawing.Size(77, 47);
            this.bt_setting.TabIndex = 0;
            this.bt_setting.UseVisualStyleBackColor = true;
            this.bt_setting.Click += new System.EventHandler(this.bt_setting_Click);
            // 
            // bt_personnel
            // 
            this.bt_personnel.FlatAppearance.BorderSize = 0;
            this.bt_personnel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_personnel.Image = global::Cepima.Properties.Resources.staff_40px;
            this.bt_personnel.Location = new System.Drawing.Point(5, 487);
            this.bt_personnel.Name = "bt_personnel";
            this.bt_personnel.Size = new System.Drawing.Size(79, 47);
            this.bt_personnel.TabIndex = 0;
            this.bt_personnel.UseVisualStyleBackColor = true;
            // 
            // bt_comptability
            // 
            this.bt_comptability.FlatAppearance.BorderSize = 0;
            this.bt_comptability.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_comptability.Image = global::Cepima.Properties.Resources.paycheque_40px;
            this.bt_comptability.Location = new System.Drawing.Point(3, 351);
            this.bt_comptability.Name = "bt_comptability";
            this.bt_comptability.Size = new System.Drawing.Size(83, 47);
            this.bt_comptability.TabIndex = 0;
            this.bt_comptability.UseVisualStyleBackColor = true;
            this.bt_comptability.Click += new System.EventHandler(this.bt_comptability_Click);
            // 
            // bt_EEG
            // 
            this.bt_EEG.FlatAppearance.BorderSize = 0;
            this.bt_EEG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_EEG.Image = global::Cepima.Properties.Resources.brain_40px;
            this.bt_EEG.Location = new System.Drawing.Point(3, 215);
            this.bt_EEG.Name = "bt_EEG";
            this.bt_EEG.Size = new System.Drawing.Size(83, 47);
            this.bt_EEG.TabIndex = 0;
            this.bt_EEG.UseVisualStyleBackColor = true;
            this.bt_EEG.Click += new System.EventHandler(this.bt_EEG_Click);
            // 
            // bt_soin
            // 
            this.bt_soin.FlatAppearance.BorderSize = 0;
            this.bt_soin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_soin.Image = global::Cepima.Properties.Resources.health_checkup_40px;
            this.bt_soin.Location = new System.Drawing.Point(3, 283);
            this.bt_soin.Name = "bt_soin";
            this.bt_soin.Size = new System.Drawing.Size(83, 47);
            this.bt_soin.TabIndex = 0;
            this.bt_soin.UseVisualStyleBackColor = true;
            this.bt_soin.Click += new System.EventHandler(this.bt_soin_Click);
            // 
            // bt_pharmacie
            // 
            this.bt_pharmacie.FlatAppearance.BorderSize = 0;
            this.bt_pharmacie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_pharmacie.Image = global::Cepima.Properties.Resources.doctors_bag_40px;
            this.bt_pharmacie.Location = new System.Drawing.Point(3, 147);
            this.bt_pharmacie.Name = "bt_pharmacie";
            this.bt_pharmacie.Size = new System.Drawing.Size(83, 47);
            this.bt_pharmacie.TabIndex = 0;
            this.bt_pharmacie.UseVisualStyleBackColor = true;
            this.bt_pharmacie.Click += new System.EventHandler(this.bt_pharmacie_Click);
            // 
            // bt_reception
            // 
            this.bt_reception.FlatAppearance.BorderSize = 0;
            this.bt_reception.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_reception.Image = global::Cepima.Properties.Resources.reception_40px;
            this.bt_reception.Location = new System.Drawing.Point(3, 79);
            this.bt_reception.Name = "bt_reception";
            this.bt_reception.Size = new System.Drawing.Size(83, 47);
            this.bt_reception.TabIndex = 0;
            this.bt_reception.UseVisualStyleBackColor = true;
            this.bt_reception.Click += new System.EventHandler(this.bt_reception_Click);
            // 
            // bt_acceuil
            // 
            this.bt_acceuil.FlatAppearance.BorderSize = 0;
            this.bt_acceuil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_acceuil.Image = global::Cepima.Properties.Resources.homework_40px;
            this.bt_acceuil.Location = new System.Drawing.Point(3, 11);
            this.bt_acceuil.Name = "bt_acceuil";
            this.bt_acceuil.Size = new System.Drawing.Size(83, 47);
            this.bt_acceuil.TabIndex = 0;
            this.bt_acceuil.UseVisualStyleBackColor = true;
            this.bt_acceuil.Click += new System.EventHandler(this.bt_acceuil_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1091, 600);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.pan);
            this.Controls.Add(this.panel_center_main);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Connexion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_statut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.pan.ResumeLayout(false);
            this.pan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_image_menu)).EndInit();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lb_role;
        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.PictureBox picture_statut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.Button bt_minus;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lb_version;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel_center_main;
        private System.Windows.Forms.Label lb_sous_menu;
        private System.Windows.Forms.PictureBox picture_image_menu;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel pan;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel_sous_menu;
        private System.Windows.Forms.Button bt_setting;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button bt_personnel;
        private System.Windows.Forms.Button bt_comptability;
        private System.Windows.Forms.Button bt_EEG;
        private System.Windows.Forms.Button bt_soin;
        private System.Windows.Forms.Button bt_pharmacie;
        private System.Windows.Forms.Button bt_reception;
        private System.Windows.Forms.Button bt_acceuil;
        private System.Windows.Forms.Button bt_hospitalisation;

    }
}

