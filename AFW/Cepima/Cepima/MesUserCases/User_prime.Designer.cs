namespace Cepima.MesUserCases
{
    partial class User_prime
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
            this.customRoundedPanel3 = new CustomRoundedPanel();
            this.dgv_primes = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.bt_save_prime = new test_arrondissement2012.PerfectRoundedButton();
            this.customRoundedPanel4 = new CustomRoundedPanel();
            this.rich_description = new System.Windows.Forms.RichTextBox();
            this.tb_montant = new System.Windows.Forms.TextBox();
            this.myRoundedTextBox2 = new MyRoundedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_salaire_primes = new System.Windows.Forms.ComboBox();
            this.customRoundedPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_primes)).BeginInit();
            this.customRoundedPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.customRoundedPanel2.SuspendLayout();
            this.customRoundedPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // customRoundedPanel3
            // 
            this.customRoundedPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.customRoundedPanel3.BorderRadius = 10;
            this.customRoundedPanel3.BorderSize = 2;
            this.customRoundedPanel3.Controls.Add(this.dgv_primes);
            this.customRoundedPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.customRoundedPanel3.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel3.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel3.Location = new System.Drawing.Point(0, 268);
            this.customRoundedPanel3.Name = "customRoundedPanel3";
            this.customRoundedPanel3.Size = new System.Drawing.Size(786, 156);
            this.customRoundedPanel3.TabIndex = 2;
            // 
            // dgv_primes
            // 
            this.dgv_primes.AllowUserToAddRows = false;
            this.dgv_primes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_primes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_primes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.dgv_primes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_primes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_primes.Location = new System.Drawing.Point(3, 8);
            this.dgv_primes.Name = "dgv_primes";
            this.dgv_primes.RowHeadersVisible = false;
            this.dgv_primes.Size = new System.Drawing.Size(780, 145);
            this.dgv_primes.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(12, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Liste de primes ";
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.customRoundedPanel1.BorderRadius = 20;
            this.customRoundedPanel1.BorderSize = 0;
            this.customRoundedPanel1.Controls.Add(this.panel1);
            this.customRoundedPanel1.Controls.Add(this.customRoundedPanel2);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(3, 3);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Size = new System.Drawing.Size(780, 241);
            this.customRoundedPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 235);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::Cepima.Properties.Resources.refund_90px;
            this.pictureBox1.Location = new System.Drawing.Point(21, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 153);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(39, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ajouter une prime";
            // 
            // customRoundedPanel2
            // 
            this.customRoundedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel2.BorderRadius = 10;
            this.customRoundedPanel2.BorderSize = 2;
            this.customRoundedPanel2.Controls.Add(this.bt_save_prime);
            this.customRoundedPanel2.Controls.Add(this.customRoundedPanel4);
            this.customRoundedPanel2.Controls.Add(this.tb_montant);
            this.customRoundedPanel2.Controls.Add(this.myRoundedTextBox2);
            this.customRoundedPanel2.Controls.Add(this.label3);
            this.customRoundedPanel2.Controls.Add(this.label2);
            this.customRoundedPanel2.Controls.Add(this.label1);
            this.customRoundedPanel2.Controls.Add(this.cbx_salaire_primes);
            this.customRoundedPanel2.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel2.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel2.Location = new System.Drawing.Point(221, 3);
            this.customRoundedPanel2.Name = "customRoundedPanel2";
            this.customRoundedPanel2.Size = new System.Drawing.Size(559, 235);
            this.customRoundedPanel2.TabIndex = 2;
            // 
            // bt_save_prime
            // 
            this.bt_save_prime.BackColor = System.Drawing.Color.Transparent;
            this.bt_save_prime.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_save_prime.BorderRadius = 5;
            this.bt_save_prime.BorderSize = 0;
            this.bt_save_prime.ButtonText = "Ajouter une prime";
            this.bt_save_prime.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.bt_save_prime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save_prime.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_save_prime.Location = new System.Drawing.Point(228, 194);
            this.bt_save_prime.Name = "bt_save_prime";
            this.bt_save_prime.Size = new System.Drawing.Size(132, 28);
            this.bt_save_prime.TabIndex = 12;
            this.bt_save_prime.Click += new System.EventHandler(this.bt_save_prime_Click);
            // 
            // customRoundedPanel4
            // 
            this.customRoundedPanel4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel4.BorderRadius = 10;
            this.customRoundedPanel4.BorderSize = 2;
            this.customRoundedPanel4.Controls.Add(this.rich_description);
            this.customRoundedPanel4.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel4.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel4.Location = new System.Drawing.Point(193, 121);
            this.customRoundedPanel4.Name = "customRoundedPanel4";
            this.customRoundedPanel4.Size = new System.Drawing.Size(251, 63);
            this.customRoundedPanel4.TabIndex = 11;
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
            this.rich_description.Size = new System.Drawing.Size(242, 57);
            this.rich_description.TabIndex = 8;
            this.rich_description.Text = "";
            // 
            // tb_montant
            // 
            this.tb_montant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.tb_montant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_montant.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_montant.Location = new System.Drawing.Point(203, 65);
            this.tb_montant.Multiline = true;
            this.tb_montant.Name = "tb_montant";
            this.tb_montant.Size = new System.Drawing.Size(234, 23);
            this.tb_montant.TabIndex = 10;
            // 
            // myRoundedTextBox2
            // 
            this.myRoundedTextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myRoundedTextBox2.BorderRadius = 4;
            this.myRoundedTextBox2.BorderSize = 0;
            this.myRoundedTextBox2.Enabled = false;
            this.myRoundedTextBox2.FocusBorderColor = System.Drawing.Color.Orange;
            this.myRoundedTextBox2.Location = new System.Drawing.Point(193, 63);
            this.myRoundedTextBox2.Name = "myRoundedTextBox2";
            this.myRoundedTextBox2.PasswordChar = '\0';
            this.myRoundedTextBox2.PlaceholderColor = System.Drawing.Color.Gray;
            this.myRoundedTextBox2.PlaceholderText = "";
            this.myRoundedTextBox2.Size = new System.Drawing.Size(251, 28);
            this.myRoundedTextBox2.TabIndex = 9;
            this.myRoundedTextBox2.UseSystemPasswordChar = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(88, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "description : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(89, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Montant  : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Salaire : ";
            // 
            // cbx_salaire_primes
            // 
            this.cbx_salaire_primes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_salaire_primes.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_salaire_primes.FormattingEnabled = true;
            this.cbx_salaire_primes.Location = new System.Drawing.Point(193, 11);
            this.cbx_salaire_primes.Name = "cbx_salaire_primes";
            this.cbx_salaire_primes.Size = new System.Drawing.Size(248, 22);
            this.cbx_salaire_primes.TabIndex = 3;
            // 
            // User_prime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.customRoundedPanel1);
            this.Controls.Add(this.customRoundedPanel3);
            this.Controls.Add(this.label5);
            this.Name = "User_prime";
            this.Size = new System.Drawing.Size(786, 424);
            this.customRoundedPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_primes)).EndInit();
            this.customRoundedPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.customRoundedPanel2.ResumeLayout(false);
            this.customRoundedPanel2.PerformLayout();
            this.customRoundedPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel3;
        private System.Windows.Forms.DataGridView dgv_primes;
        private System.Windows.Forms.Label label5;
        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private CustomRoundedPanel customRoundedPanel2;
        private test_arrondissement2012.PerfectRoundedButton bt_save_prime;
        private CustomRoundedPanel customRoundedPanel4;
        private System.Windows.Forms.RichTextBox rich_description;
        private System.Windows.Forms.TextBox tb_montant;
        private MyRoundedTextBox myRoundedTextBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_salaire_primes;
    }
}
