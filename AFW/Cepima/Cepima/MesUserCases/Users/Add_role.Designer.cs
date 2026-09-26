namespace Cepima.MesUserCases.Users
{
    partial class Add_role
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
            this.bt_add_role = new RoundedButton();
            this.tb_role = new MyRoundedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuRoundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.Empty;
            this.bunifuRoundedPanel1.BorderRadius = 10;
            this.bunifuRoundedPanel1.BorderSize = 1;
            this.bunifuRoundedPanel1.Controls.Add(this.bt_add_role);
            this.bunifuRoundedPanel1.Controls.Add(this.tb_role);
            this.bunifuRoundedPanel1.Controls.Add(this.label2);
            this.bunifuRoundedPanel1.Controls.Add(this.label1);
            this.bunifuRoundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 10;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(361, 286);
            this.bunifuRoundedPanel1.TabIndex = 0;
            // 
            // bt_add_role
            // 
            this.bt_add_role.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_add_role.BackColor = System.Drawing.Color.Transparent;
            this.bt_add_role.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_add_role.BorderRadius = 10;
            this.bt_add_role.ButtonText = "Enregistrer";
            this.bt_add_role.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_add_role.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_add_role.FlatAppearance.BorderSize = 0;
            this.bt_add_role.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_add_role.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_add_role.ForeColor = System.Drawing.Color.White;
            this.bt_add_role.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_add_role.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_add_role.Location = new System.Drawing.Point(88, 210);
            this.bt_add_role.Name = "bt_add_role";
            this.bt_add_role.Size = new System.Drawing.Size(185, 42);
            this.bt_add_role.TabIndex = 3;
            this.bt_add_role.Text = "Enregistrer";
            this.bt_add_role.TextColor = System.Drawing.Color.White;
            this.bt_add_role.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_add_role.UseVisualStyleBackColor = false;
            this.bt_add_role.Click += new System.EventHandler(this.bt_add_role_Click);
            // 
            // tb_role
            // 
            this.tb_role.BackColor = System.Drawing.Color.White;
            this.tb_role.BorderColor = System.Drawing.Color.Silver;
            this.tb_role.BorderRadius = 10;
            this.tb_role.BorderSize = 1;
            this.tb_role.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_role.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_role.ForeColor = System.Drawing.Color.Black;
            this.tb_role.Image = null;
            this.tb_role.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_role.Location = new System.Drawing.Point(55, 125);
            this.tb_role.MaxLength = 32767;
            this.tb_role.Name = "tb_role";
            this.tb_role.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_role.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_role.PlaceholderText = "";
            this.tb_role.Size = new System.Drawing.Size(250, 35);
            this.tb_role.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nom rôle : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ajouter un role";
            // 
            // Add_role
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(361, 286);
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Name = "Add_role";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_role";
            this.Load += new System.EventHandler(this.Add_role_Load);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.bunifuRoundedPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.Label label1;
        private MyRoundedTextBox tb_role;
        private System.Windows.Forms.Label label2;
        private RoundedButton bt_add_role;
    }
}