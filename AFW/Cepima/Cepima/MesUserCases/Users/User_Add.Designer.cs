namespace Cepima.MesUserCases.Users
{
    partial class User_Add
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
            this.bt_save_user = new RoundedButton();
            this.check_list_role = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_password = new MyRoundedTextBox();
            this.tb_username = new MyRoundedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuRoundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.Empty;
            this.bunifuRoundedPanel1.BorderRadius = 10;
            this.bunifuRoundedPanel1.BorderSize = 1;
            this.bunifuRoundedPanel1.Controls.Add(this.bt_save_user);
            this.bunifuRoundedPanel1.Controls.Add(this.check_list_role);
            this.bunifuRoundedPanel1.Controls.Add(this.label4);
            this.bunifuRoundedPanel1.Controls.Add(this.label3);
            this.bunifuRoundedPanel1.Controls.Add(this.label2);
            this.bunifuRoundedPanel1.Controls.Add(this.tb_password);
            this.bunifuRoundedPanel1.Controls.Add(this.tb_username);
            this.bunifuRoundedPanel1.Controls.Add(this.label1);
            this.bunifuRoundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 10;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(457, 472);
            this.bunifuRoundedPanel1.TabIndex = 0;
            // 
            // bt_save_user
            // 
            this.bt_save_user.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_save_user.BackColor = System.Drawing.Color.Transparent;
            this.bt_save_user.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_save_user.BorderRadius = 10;
            this.bt_save_user.ButtonText = "Enregistrer";
            this.bt_save_user.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_save_user.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_save_user.FlatAppearance.BorderSize = 0;
            this.bt_save_user.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_save_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save_user.ForeColor = System.Drawing.Color.White;
            this.bt_save_user.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_save_user.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_save_user.Location = new System.Drawing.Point(136, 406);
            this.bt_save_user.Name = "bt_save_user";
            this.bt_save_user.Size = new System.Drawing.Size(185, 42);
            this.bt_save_user.TabIndex = 5;
            this.bt_save_user.Text = "Enregistrer";
            this.bt_save_user.TextColor = System.Drawing.Color.White;
            this.bt_save_user.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_save_user.UseVisualStyleBackColor = false;
            this.bt_save_user.Click += new System.EventHandler(this.bt_save_user_Click);
            // 
            // check_list_role
            // 
            this.check_list_role.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_list_role.FormattingEnabled = true;
            this.check_list_role.Location = new System.Drawing.Point(65, 273);
            this.check_list_role.Name = "check_list_role";
            this.check_list_role.Size = new System.Drawing.Size(314, 89);
            this.check_list_role.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(85, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rôle  utilisateur : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mot de passe : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nom d\'utilisateur : ";
            // 
            // tb_password
            // 
            this.tb_password.BackColor = System.Drawing.Color.White;
            this.tb_password.BorderColor = System.Drawing.Color.Silver;
            this.tb_password.BorderRadius = 10;
            this.tb_password.BorderSize = 1;
            this.tb_password.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_password.ForeColor = System.Drawing.Color.Black;
            this.tb_password.Image = null;
            this.tb_password.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_password.Location = new System.Drawing.Point(65, 198);
            this.tb_password.MaxLength = 32767;
            this.tb_password.Name = "tb_password";
            this.tb_password.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_password.PasswordChar = '*';
            this.tb_password.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_password.PlaceholderText = "";
            this.tb_password.Size = new System.Drawing.Size(314, 35);
            this.tb_password.TabIndex = 2;
            // 
            // tb_username
            // 
            this.tb_username.BackColor = System.Drawing.Color.White;
            this.tb_username.BorderColor = System.Drawing.Color.Silver;
            this.tb_username.BorderRadius = 10;
            this.tb_username.BorderSize = 1;
            this.tb_username.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_username.ForeColor = System.Drawing.Color.Black;
            this.tb_username.Image = null;
            this.tb_username.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_username.Location = new System.Drawing.Point(65, 121);
            this.tb_username.MaxLength = 32767;
            this.tb_username.Name = "tb_username";
            this.tb_username.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_username.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_username.PlaceholderText = "";
            this.tb_username.Size = new System.Drawing.Size(314, 35);
            this.tb_username.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(127, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ajouter un utilisateur";
            // 
            // User_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(457, 472);
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Name = "User_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter un utilisateur";
            this.Load += new System.EventHandler(this.User_Add_Load);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.bunifuRoundedPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox check_list_role;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private MyRoundedTextBox tb_password;
        private MyRoundedTextBox tb_username;
        private RoundedButton bt_save_user;
    }
}