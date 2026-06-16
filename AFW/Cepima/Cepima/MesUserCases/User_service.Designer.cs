namespace Cepima.MesUserCases
{
    partial class User_service
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.pan_display_service = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.bt_update_service = new test_arrondissement2012.PerfectRoundedButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_update_name_service = new MyRoundedTextBox();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.bt_save_service = new test_arrondissement2012.PerfectRoundedButton();
            this.customRoundedPanel3 = new CustomRoundedPanel();
            this.rich_description = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textbox = new MyRoundedTextBox();
            this.pan_update_service = new CustomRoundedPanel();
            this.tb_mod_name_service = new System.Windows.Forms.TextBox();
            this.lb_nombre = new System.Windows.Forms.Label();
            this.customRoundedPanel1.SuspendLayout();
            this.customRoundedPanel2.SuspendLayout();
            this.customRoundedPanel3.SuspendLayout();
            this.pan_update_service.SuspendLayout();
            this.SuspendLayout();
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 10;
            this.customRoundedPanel1.BorderSize = 1;
            this.customRoundedPanel1.Controls.Add(this.pan_display_service);
            this.customRoundedPanel1.Controls.Add(this.label5);
            this.customRoundedPanel1.Controls.Add(this.lb_nombre);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(362, 19);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Size = new System.Drawing.Size(689, 513);
            this.customRoundedPanel1.TabIndex = 2;
            // 
            // pan_display_service
            // 
            this.pan_display_service.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pan_display_service.AutoScroll = true;
            this.pan_display_service.Location = new System.Drawing.Point(3, 34);
            this.pan_display_service.Name = "pan_display_service";
            this.pan_display_service.Size = new System.Drawing.Size(683, 472);
            this.pan_display_service.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Liste de service";
            // 
            // bt_update_service
            // 
            this.bt_update_service.BackColor = System.Drawing.Color.Transparent;
            this.bt_update_service.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_update_service.BorderRadius = 5;
            this.bt_update_service.BorderSize = 0;
            this.bt_update_service.ButtonText = "Valider";
            this.bt_update_service.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.bt_update_service.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_update_service.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_update_service.Location = new System.Drawing.Point(108, 107);
            this.bt_update_service.Name = "bt_update_service";
            this.bt_update_service.Size = new System.Drawing.Size(113, 27);
            this.bt_update_service.TabIndex = 10;
            this.bt_update_service.Click += new System.EventHandler(this.bt_update_service_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Modifier le service";
            // 
            // tb_update_name_service
            // 
            this.tb_update_name_service.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_update_name_service.BorderRadius = 4;
            this.tb_update_name_service.BorderSize = 0;
            this.tb_update_name_service.Enabled = false;
            this.tb_update_name_service.FocusBorderColor = System.Drawing.Color.Orange;
            this.tb_update_name_service.Location = new System.Drawing.Point(34, 66);
            this.tb_update_name_service.Name = "tb_update_name_service";
            this.tb_update_name_service.PasswordChar = '\0';
            this.tb_update_name_service.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_update_name_service.PlaceholderText = "";
            this.tb_update_name_service.Size = new System.Drawing.Size(221, 28);
            this.tb_update_name_service.TabIndex = 2;
            this.tb_update_name_service.UseSystemPasswordChar = false;
            // 
            // customRoundedPanel2
            // 
            this.customRoundedPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customRoundedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel2.BorderRadius = 10;
            this.customRoundedPanel2.BorderSize = 1;
            this.customRoundedPanel2.Controls.Add(this.bt_save_service);
            this.customRoundedPanel2.Controls.Add(this.customRoundedPanel3);
            this.customRoundedPanel2.Controls.Add(this.label4);
            this.customRoundedPanel2.Controls.Add(this.label1);
            this.customRoundedPanel2.Controls.Add(this.label6);
            this.customRoundedPanel2.Controls.Add(this.textbox);
            this.customRoundedPanel2.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel2.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel2.Location = new System.Drawing.Point(6, 20);
            this.customRoundedPanel2.Name = "customRoundedPanel2";
            this.customRoundedPanel2.Size = new System.Drawing.Size(350, 319);
            this.customRoundedPanel2.TabIndex = 0;
            // 
            // bt_save_service
            // 
            this.bt_save_service.BackColor = System.Drawing.Color.Transparent;
            this.bt_save_service.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_save_service.BorderRadius = 5;
            this.bt_save_service.BorderSize = 0;
            this.bt_save_service.ButtonText = "Enregistrer";
            this.bt_save_service.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.bt_save_service.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save_service.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_save_service.Location = new System.Drawing.Point(108, 263);
            this.bt_save_service.Name = "bt_save_service";
            this.bt_save_service.Size = new System.Drawing.Size(132, 30);
            this.bt_save_service.TabIndex = 16;
            // 
            // customRoundedPanel3
            // 
            this.customRoundedPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel3.BorderRadius = 10;
            this.customRoundedPanel3.BorderSize = 2;
            this.customRoundedPanel3.Controls.Add(this.rich_description);
            this.customRoundedPanel3.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel3.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel3.Location = new System.Drawing.Point(50, 141);
            this.customRoundedPanel3.Name = "customRoundedPanel3";
            this.customRoundedPanel3.Size = new System.Drawing.Size(268, 87);
            this.customRoundedPanel3.TabIndex = 15;
            // 
            // rich_description
            // 
            this.rich_description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rich_description.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.rich_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rich_description.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rich_description.Location = new System.Drawing.Point(4, 3);
            this.rich_description.Name = "rich_description";
            this.rich_description.Size = new System.Drawing.Size(259, 81);
            this.rich_description.TabIndex = 8;
            this.rich_description.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "Ajouter un service";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nom du service";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(58, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "Description ";
            // 
            // textbox
            // 
            this.textbox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textbox.BorderRadius = 4;
            this.textbox.BorderSize = 0;
            this.textbox.FocusBorderColor = System.Drawing.Color.Orange;
            this.textbox.Location = new System.Drawing.Point(50, 87);
            this.textbox.Name = "textbox";
            this.textbox.PasswordChar = '\0';
            this.textbox.PlaceholderColor = System.Drawing.Color.Gray;
            this.textbox.PlaceholderText = "";
            this.textbox.Size = new System.Drawing.Size(268, 28);
            this.textbox.TabIndex = 11;
            this.textbox.UseSystemPasswordChar = false;
            // 
            // pan_update_service
            // 
            this.pan_update_service.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pan_update_service.BorderRadius = 10;
            this.pan_update_service.BorderSize = 1;
            this.pan_update_service.Controls.Add(this.tb_mod_name_service);
            this.pan_update_service.Controls.Add(this.bt_update_service);
            this.pan_update_service.Controls.Add(this.tb_update_name_service);
            this.pan_update_service.Controls.Add(this.label2);
            this.pan_update_service.HoverBackColor = System.Drawing.Color.Empty;
            this.pan_update_service.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.pan_update_service.Location = new System.Drawing.Point(6, 371);
            this.pan_update_service.Name = "pan_update_service";
            this.pan_update_service.Size = new System.Drawing.Size(350, 154);
            this.pan_update_service.TabIndex = 4;
            this.pan_update_service.Visible = false;
            // 
            // tb_mod_name_service
            // 
            this.tb_mod_name_service.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_mod_name_service.Font = new System.Drawing.Font("Calibri", 10F);
            this.tb_mod_name_service.Location = new System.Drawing.Point(37, 69);
            this.tb_mod_name_service.Multiline = true;
            this.tb_mod_name_service.Name = "tb_mod_name_service";
            this.tb_mod_name_service.Size = new System.Drawing.Size(214, 22);
            this.tb_mod_name_service.TabIndex = 0;
            // 
            // lb_nombre
            // 
            this.lb_nombre.AutoSize = true;
            this.lb_nombre.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nombre.Location = new System.Drawing.Point(582, 11);
            this.lb_nombre.Name = "lb_nombre";
            this.lb_nombre.Size = new System.Drawing.Size(0, 15);
            this.lb_nombre.TabIndex = 13;
            // 
            // User_service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.pan_update_service);
            this.Controls.Add(this.customRoundedPanel2);
            this.Controls.Add(this.customRoundedPanel1);
            this.Name = "User_service";
            this.Size = new System.Drawing.Size(1054, 535);
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel1.PerformLayout();
            this.customRoundedPanel2.ResumeLayout(false);
            this.customRoundedPanel2.PerformLayout();
            this.customRoundedPanel3.ResumeLayout(false);
            this.pan_update_service.ResumeLayout(false);
            this.pan_update_service.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.Panel pan_display_service;
        private System.Windows.Forms.Label label5;
        private test_arrondissement2012.PerfectRoundedButton bt_update_service;
        private System.Windows.Forms.Label label2;
        private MyRoundedTextBox tb_update_name_service;
        private CustomRoundedPanel customRoundedPanel2;
        private test_arrondissement2012.PerfectRoundedButton bt_save_service;
        private CustomRoundedPanel customRoundedPanel3;
        private System.Windows.Forms.RichTextBox rich_description;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private MyRoundedTextBox textbox;
        private CustomRoundedPanel pan_update_service;
        private System.Windows.Forms.TextBox tb_mod_name_service;
        private System.Windows.Forms.Label lb_nombre;
    }
}
