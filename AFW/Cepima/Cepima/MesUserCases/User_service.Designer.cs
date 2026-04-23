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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.customRoundedPanel3 = new CustomRoundedPanel();
            this.dgv_services = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_save_service = new test_arrondissement2012.PerfectRoundedButton();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.rich_description = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_name_service = new MyRoundedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.customRoundedPanel1.SuspendLayout();
            this.customRoundedPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_services)).BeginInit();
            this.panel2.SuspendLayout();
            this.customRoundedPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(18, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 202);
            this.panel1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ajouter un service";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.unit_90px;
            this.pictureBox1.Location = new System.Drawing.Point(22, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(159, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 10;
            this.customRoundedPanel1.BorderSize = 2;
            this.customRoundedPanel1.Controls.Add(this.customRoundedPanel3);
            this.customRoundedPanel1.Controls.Add(this.panel2);
            this.customRoundedPanel1.Controls.Add(this.label2);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(237, 23);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Size = new System.Drawing.Size(639, 408);
            this.customRoundedPanel1.TabIndex = 2;
            // 
            // customRoundedPanel3
            // 
            this.customRoundedPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.customRoundedPanel3.BorderRadius = 10;
            this.customRoundedPanel3.BorderSize = 2;
            this.customRoundedPanel3.Controls.Add(this.dgv_services);
            this.customRoundedPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.customRoundedPanel3.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel3.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel3.Location = new System.Drawing.Point(0, 277);
            this.customRoundedPanel3.Name = "customRoundedPanel3";
            this.customRoundedPanel3.Size = new System.Drawing.Size(639, 131);
            this.customRoundedPanel3.TabIndex = 4;
            // 
            // dgv_services
            // 
            this.dgv_services.AllowUserToAddRows = false;
            this.dgv_services.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_services.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_services.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.dgv_services.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_services.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_services.Location = new System.Drawing.Point(3, 3);
            this.dgv_services.Name = "dgv_services";
            this.dgv_services.RowHeadersVisible = false;
            this.dgv_services.Size = new System.Drawing.Size(633, 125);
            this.dgv_services.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bt_save_service);
            this.panel2.Controls.Add(this.customRoundedPanel2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.tb_name_service);
            this.panel2.Location = new System.Drawing.Point(88, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(498, 213);
            this.panel2.TabIndex = 3;
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
            this.bt_save_service.Location = new System.Drawing.Point(206, 173);
            this.bt_save_service.Name = "bt_save_service";
            this.bt_save_service.Size = new System.Drawing.Size(132, 30);
            this.bt_save_service.TabIndex = 10;
            this.bt_save_service.Click += new System.EventHandler(this.bt_save_service_Click);
            // 
            // customRoundedPanel2
            // 
            this.customRoundedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel2.BorderRadius = 10;
            this.customRoundedPanel2.BorderSize = 2;
            this.customRoundedPanel2.Controls.Add(this.rich_description);
            this.customRoundedPanel2.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel2.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel2.Location = new System.Drawing.Point(138, 75);
            this.customRoundedPanel2.Name = "customRoundedPanel2";
            this.customRoundedPanel2.Size = new System.Drawing.Size(280, 87);
            this.customRoundedPanel2.TabIndex = 9;
            // 
            // rich_description
            // 
            this.rich_description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rich_description.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.rich_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rich_description.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rich_description.Location = new System.Drawing.Point(6, 3);
            this.rich_description.Name = "rich_description";
            this.rich_description.Size = new System.Drawing.Size(271, 81);
            this.rich_description.TabIndex = 8;
            this.rich_description.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nom du service : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "Description  : ";
            // 
            // tb_name_service
            // 
            this.tb_name_service.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_name_service.BorderRadius = 4;
            this.tb_name_service.BorderSize = 0;
            this.tb_name_service.FocusBorderColor = System.Drawing.Color.Orange;
            this.tb_name_service.Location = new System.Drawing.Point(138, 21);
            this.tb_name_service.Name = "tb_name_service";
            this.tb_name_service.PasswordChar = '\0';
            this.tb_name_service.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_name_service.PlaceholderText = "";
            this.tb_name_service.Size = new System.Drawing.Size(277, 28);
            this.tb_name_service.TabIndex = 2;
            this.tb_name_service.UseSystemPasswordChar = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(23, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Liste de services";
            // 
            // User_service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.customRoundedPanel1);
            this.Name = "User_service";
            this.Size = new System.Drawing.Size(905, 462);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel1.PerformLayout();
            this.customRoundedPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_services)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.customRoundedPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private MyRoundedTextBox tb_name_service;
        private CustomRoundedPanel customRoundedPanel2;
        private System.Windows.Forms.RichTextBox rich_description;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private test_arrondissement2012.PerfectRoundedButton bt_save_service;
        private CustomRoundedPanel customRoundedPanel3;
        private System.Windows.Forms.DataGridView dgv_services;
        private System.Windows.Forms.Label label2;
    }
}
