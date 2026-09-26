namespace Cepima.MesForms
{
    partial class FormConnexion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.link_create_compte = new System.Windows.Forms.LinkLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb_notice = new System.Windows.Forms.Label();
            this.bt_add_compte = new RoundedButton();
            this.panel_con = new CustomRoundedPanel();
            this.link_forgot = new System.Windows.Forms.LinkLabel();
            this.bt_connexion = new test_arrondissement2012.PerfectRoundedButton();
            this.cb_remember = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_password = new MyRoundedTextBox();
            this.tb_username = new MyRoundedTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel_con.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1159, 79);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(466, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Connectez-vous ";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Cepima.Properties.Resources.close_black;
            this.button1.Location = new System.Drawing.Point(1111, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 31);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.cepima_logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1159, 4);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 625);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1159, 6);
            this.panel4.TabIndex = 1;
            // 
            // link_create_compte
            // 
            this.link_create_compte.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.link_create_compte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.link_create_compte.AutoSize = true;
            this.link_create_compte.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_create_compte.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.link_create_compte.Location = new System.Drawing.Point(958, 600);
            this.link_create_compte.Name = "link_create_compte";
            this.link_create_compte.Size = new System.Drawing.Size(189, 19);
            this.link_create_compte.TabIndex = 17;
            this.link_create_compte.TabStop = true;
            this.link_create_compte.Text = " Créer un compte utilisateur";
            this.link_create_compte.Visible = false;
            this.link_create_compte.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_create_compte_LinkClicked);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lb_notice);
            this.panel3.Location = new System.Drawing.Point(12, 93);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(332, 307);
            this.panel3.TabIndex = 18;
            // 
            // lb_notice
            // 
            this.lb_notice.AutoSize = true;
            this.lb_notice.Location = new System.Drawing.Point(20, 44);
            this.lb_notice.Name = "lb_notice";
            this.lb_notice.Size = new System.Drawing.Size(35, 13);
            this.lb_notice.TabIndex = 0;
            this.lb_notice.Text = "label5";
            // 
            // bt_add_compte
            // 
            this.bt_add_compte.BackColor = System.Drawing.Color.Transparent;
            this.bt_add_compte.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_add_compte.BorderRadius = 10;
            this.bt_add_compte.ButtonText = "Ajouter un compte";
            this.bt_add_compte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_add_compte.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_add_compte.FlatAppearance.BorderSize = 0;
            this.bt_add_compte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_add_compte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_add_compte.ForeColor = System.Drawing.Color.White;
            this.bt_add_compte.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_add_compte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_add_compte.Location = new System.Drawing.Point(54, 422);
            this.bt_add_compte.Name = "bt_add_compte";
            this.bt_add_compte.Size = new System.Drawing.Size(217, 35);
            this.bt_add_compte.TabIndex = 19;
            this.bt_add_compte.Text = "Ajouter un compte";
            this.bt_add_compte.TextColor = System.Drawing.Color.White;
            this.bt_add_compte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_add_compte.UseVisualStyleBackColor = false;
            this.bt_add_compte.Click += new System.EventHandler(this.bt_add_compte_Click);
            // 
            // panel_con
            // 
            this.panel_con.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_con.BackColor = System.Drawing.Color.White;
            this.panel_con.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_con.BorderRadius = 10;
            this.panel_con.BorderSize = 2;
            this.panel_con.Controls.Add(this.link_forgot);
            this.panel_con.Controls.Add(this.bt_connexion);
            this.panel_con.Controls.Add(this.cb_remember);
            this.panel_con.Controls.Add(this.label3);
            this.panel_con.Controls.Add(this.label2);
            this.panel_con.Controls.Add(this.tb_password);
            this.panel_con.Controls.Add(this.tb_username);
            this.panel_con.Controls.Add(this.pictureBox2);
            this.panel_con.HoverBackColor = System.Drawing.Color.Empty;
            this.panel_con.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.panel_con.Location = new System.Drawing.Point(406, 104);
            this.panel_con.Name = "panel_con";
            this.panel_con.ShadowBlur = 10;
            this.panel_con.ShadowBorderRadius = -1;
            this.panel_con.ShadowColor = System.Drawing.Color.Black;
            this.panel_con.ShadowEnabled = false;
            this.panel_con.ShadowOffsetX = 0;
            this.panel_con.ShadowOffsetY = 4;
            this.panel_con.ShadowOpacity = 60;
            this.panel_con.ShadowSpread = 0;
            this.panel_con.Size = new System.Drawing.Size(340, 471);
            this.panel_con.TabIndex = 2;
            // 
            // link_forgot
            // 
            this.link_forgot.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.link_forgot.AutoSize = true;
            this.link_forgot.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_forgot.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.link_forgot.Location = new System.Drawing.Point(105, 318);
            this.link_forgot.Name = "link_forgot";
            this.link_forgot.Size = new System.Drawing.Size(106, 14);
            this.link_forgot.TabIndex = 16;
            this.link_forgot.TabStop = true;
            this.link_forgot.Text = "Mot de passe oublié";
            this.link_forgot.Visible = false;
            this.link_forgot.Click += new System.EventHandler(this.link_forgot_Click);
            // 
            // bt_connexion
            // 
            this.bt_connexion.BackColor = System.Drawing.Color.Transparent;
            this.bt_connexion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_connexion.BorderRadius = 5;
            this.bt_connexion.BorderSize = 0;
            this.bt_connexion.ButtonText = "Se connecter";
            this.bt_connexion.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_connexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_connexion.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bt_connexion.Location = new System.Drawing.Point(106, 388);
            this.bt_connexion.Name = "bt_connexion";
            this.bt_connexion.Size = new System.Drawing.Size(124, 30);
            this.bt_connexion.TabIndex = 2;
            this.bt_connexion.Load += new System.EventHandler(this.bt_connexion_Load);
            this.bt_connexion.Click += new System.EventHandler(this.bt_connexion_Click);
            // 
            // cb_remember
            // 
            this.cb_remember.AutoSize = true;
            this.cb_remember.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_remember.Location = new System.Drawing.Point(97, 348);
            this.cb_remember.Name = "cb_remember";
            this.cb_remember.Size = new System.Drawing.Size(142, 20);
            this.cb_remember.TabIndex = 2;
            this.cb_remember.Text = "Se souvenir de moi";
            this.cb_remember.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(61, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Mot de passe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nom d\'utilisateur";
            // 
            // tb_password
            // 
            this.tb_password.BackColor = System.Drawing.Color.White;
            this.tb_password.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_password.BorderRadius = 8;
            this.tb_password.BorderSize = 1;
            this.tb_password.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_password.ForeColor = System.Drawing.Color.Black;
            this.tb_password.Image = null;
            this.tb_password.Location = new System.Drawing.Point(47, 265);
            this.tb_password.MaxLength = 32767;
            this.tb_password.Name = "tb_password";
            this.tb_password.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_password.PasswordChar = '●';
            this.tb_password.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_password.PlaceholderText = "";
            this.tb_password.Size = new System.Drawing.Size(241, 30);
            this.tb_password.TabIndex = 1;
            // 
            // tb_username
            // 
            this.tb_username.BackColor = System.Drawing.Color.White;
            this.tb_username.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_username.BorderRadius = 8;
            this.tb_username.BorderSize = 1;
            this.tb_username.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_username.ForeColor = System.Drawing.Color.Black;
            this.tb_username.Image = null;
            this.tb_username.Location = new System.Drawing.Point(47, 198);
            this.tb_username.MaxLength = 32767;
            this.tb_username.Name = "tb_username";
            this.tb_username.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_username.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_username.PlaceholderText = "";
            this.tb_username.Size = new System.Drawing.Size(241, 28);
            this.tb_username.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Cepima.Properties.Resources.user;
            this.pictureBox2.Location = new System.Drawing.Point(93, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(154, 135);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // FormConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1159, 631);
            this.Controls.Add(this.bt_add_compte);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.link_create_compte);
            this.Controls.Add(this.panel_con);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormConnexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormConnexion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormConnexion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel_con.ResumeLayout(false);
            this.panel_con.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private CustomRoundedPanel panel_con;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MyRoundedTextBox tb_password;
        private MyRoundedTextBox tb_username;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_remember;
        private test_arrondissement2012.PerfectRoundedButton bt_connexion;
        private System.Windows.Forms.LinkLabel link_forgot;
        private System.Windows.Forms.LinkLabel link_create_compte;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lb_notice;
        private RoundedButton bt_add_compte;
    }
}