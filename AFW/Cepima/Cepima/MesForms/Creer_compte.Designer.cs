namespace Cepima.MesForms
{
    partial class Creer_compte
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
            this.bt_compte = new RoundedButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_password = new MyRoundedTextBox();
            this.tb_username = new MyRoundedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bunifuRoundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.Empty;
            this.bunifuRoundedPanel1.BorderRadius = 10;
            this.bunifuRoundedPanel1.BorderSize = 0;
            this.bunifuRoundedPanel1.Controls.Add(this.bt_compte);
            this.bunifuRoundedPanel1.Controls.Add(this.label3);
            this.bunifuRoundedPanel1.Controls.Add(this.label2);
            this.bunifuRoundedPanel1.Controls.Add(this.tb_password);
            this.bunifuRoundedPanel1.Controls.Add(this.tb_username);
            this.bunifuRoundedPanel1.Controls.Add(this.label1);
            this.bunifuRoundedPanel1.Controls.Add(this.pictureBox2);
            this.bunifuRoundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 10;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(434, 540);
            this.bunifuRoundedPanel1.TabIndex = 0;
            // 
            // bt_compte
            // 
            this.bt_compte.BackColor = System.Drawing.Color.Transparent;
            this.bt_compte.BorderColor = System.Drawing.Color.White;
            this.bt_compte.BorderRadius = 10;
            this.bt_compte.BorderSize = 0;
            this.bt_compte.ButtonText = "Créer un compte";
            this.bt_compte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_compte.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_compte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_compte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_compte.ForeColor = System.Drawing.Color.White;
            this.bt_compte.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_compte.Image = global::Cepima.Properties.Resources.add_user_male_30px1;
            this.bt_compte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_compte.Location = new System.Drawing.Point(78, 472);
            this.bt_compte.Name = "bt_compte";
            this.bt_compte.Size = new System.Drawing.Size(275, 42);
            this.bt_compte.TabIndex = 40;
            this.bt_compte.Text = "Créer un compte";
            this.bt_compte.TextColor = System.Drawing.Color.White;
            this.bt_compte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_compte.UseVisualStyleBackColor = false;
            this.bt_compte.Click += new System.EventHandler(this.bt_compte_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(95, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 38;
            this.label3.Text = "Mot de passe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(95, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 39;
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
            this.tb_password.Location = new System.Drawing.Point(81, 370);
            this.tb_password.MaxLength = 32767;
            this.tb_password.Name = "tb_password";
            this.tb_password.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_password.PasswordChar = '●';
            this.tb_password.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_password.PlaceholderText = "";
            this.tb_password.Size = new System.Drawing.Size(275, 35);
            this.tb_password.TabIndex = 37;
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
            this.tb_username.Location = new System.Drawing.Point(81, 283);
            this.tb_username.MaxLength = 32767;
            this.tb_username.Name = "tb_username";
            this.tb_username.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_username.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_username.PlaceholderText = "";
            this.tb_username.Size = new System.Drawing.Size(275, 35);
            this.tb_username.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(102, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "Créer un compte utilisateur";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Cepima.Properties.Resources.user;
            this.pictureBox2.Location = new System.Drawing.Point(137, 60);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(154, 135);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // Creer_compte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(434, 540);
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Name = "Creer_compte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Créer un compte utilisateur";
            this.Load += new System.EventHandler(this.Creer_compte_Load);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.bunifuRoundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BunifuRoundedPanel bunifuRoundedPanel1;
        private RoundedButton bt_compte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private MyRoundedTextBox tb_password;
        private MyRoundedTextBox tb_username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;

    }
}