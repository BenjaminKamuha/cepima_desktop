namespace Cepima.MesUserCases
{
    partial class UC_add_medoc
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
            this.panel_medoc = new CustomRoundedPanel();
            this.bt_add_image = new System.Windows.Forms.Button();
            this.picture_image = new System.Windows.Forms.PictureBox();
            this.tb_prix_vente = new System.Windows.Forms.TextBox();
            this.myRoundedTextBox5 = new MyRoundedTextBox();
            this.tb_prix_achat = new System.Windows.Forms.TextBox();
            this.tb_categorie = new System.Windows.Forms.TextBox();
            this.tb_medoc = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bt_save = new test_arrondissement2012.PerfectRoundedButton();
            this.myRoundedTextBox4 = new MyRoundedTextBox();
            this.label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.myRoundedTextBox2 = new MyRoundedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.myRoundedTextBox1 = new MyRoundedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rb_carton = new System.Windows.Forms.RadioButton();
            this.rd_plaquettte = new System.Windows.Forms.RadioButton();
            this.rd_comprime = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rd_autre = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.num_qty = new System.Windows.Forms.NumericUpDown();
            this.num_stock_min = new System.Windows.Forms.NumericUpDown();
            this.panel_unity = new System.Windows.Forms.Panel();
            this.panel_medoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_image)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_qty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_stock_min)).BeginInit();
            this.panel_unity.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_medoc
            // 
            this.panel_medoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_medoc.BackColor = System.Drawing.Color.White;
            this.panel_medoc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_medoc.BorderRadius = 10;
            this.panel_medoc.BorderSize = 2;
            this.panel_medoc.Controls.Add(this.panel_unity);
            this.panel_medoc.Controls.Add(this.num_stock_min);
            this.panel_medoc.Controls.Add(this.num_qty);
            this.panel_medoc.Controls.Add(this.label3);
            this.panel_medoc.Controls.Add(this.label2);
            this.panel_medoc.Controls.Add(this.label1);
            this.panel_medoc.Controls.Add(this.bt_add_image);
            this.panel_medoc.Controls.Add(this.picture_image);
            this.panel_medoc.Controls.Add(this.tb_prix_vente);
            this.panel_medoc.Controls.Add(this.myRoundedTextBox5);
            this.panel_medoc.Controls.Add(this.tb_prix_achat);
            this.panel_medoc.Controls.Add(this.tb_categorie);
            this.panel_medoc.Controls.Add(this.tb_medoc);
            this.panel_medoc.Controls.Add(this.textBox1);
            this.panel_medoc.Controls.Add(this.bt_save);
            this.panel_medoc.Controls.Add(this.myRoundedTextBox4);
            this.panel_medoc.Controls.Add(this.label);
            this.panel_medoc.Controls.Add(this.label8);
            this.panel_medoc.Controls.Add(this.myRoundedTextBox2);
            this.panel_medoc.Controls.Add(this.label10);
            this.panel_medoc.Controls.Add(this.myRoundedTextBox1);
            this.panel_medoc.Controls.Add(this.label11);
            this.panel_medoc.HoverBackColor = System.Drawing.Color.Empty;
            this.panel_medoc.HoverCursor = System.Windows.Forms.Cursors.Arrow;
            this.panel_medoc.Location = new System.Drawing.Point(290, 40);
            this.panel_medoc.Name = "panel_medoc";
            this.panel_medoc.Size = new System.Drawing.Size(612, 391);
            this.panel_medoc.TabIndex = 32;
            this.panel_medoc.Paint += new System.Windows.Forms.PaintEventHandler(this.customRoundedPanel1_Paint);
            // 
            // bt_add_image
            // 
            this.bt_add_image.Location = new System.Drawing.Point(468, 86);
            this.bt_add_image.Name = "bt_add_image";
            this.bt_add_image.Size = new System.Drawing.Size(114, 23);
            this.bt_add_image.TabIndex = 32;
            this.bt_add_image.Text = "choisir image";
            this.bt_add_image.UseVisualStyleBackColor = true;
            this.bt_add_image.Click += new System.EventHandler(this.bt_add_image_Click);
            // 
            // picture_image
            // 
            this.picture_image.Image = global::Cepima.Properties.Resources.capsules_100px;
            this.picture_image.Location = new System.Drawing.Point(477, 38);
            this.picture_image.Name = "picture_image";
            this.picture_image.Size = new System.Drawing.Size(87, 48);
            this.picture_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_image.TabIndex = 31;
            this.picture_image.TabStop = false;
            // 
            // tb_prix_vente
            // 
            this.tb_prix_vente.BackColor = System.Drawing.Color.White;
            this.tb_prix_vente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_prix_vente.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_prix_vente.Location = new System.Drawing.Point(174, 267);
            this.tb_prix_vente.Multiline = true;
            this.tb_prix_vente.Name = "tb_prix_vente";
            this.tb_prix_vente.Size = new System.Drawing.Size(280, 23);
            this.tb_prix_vente.TabIndex = 7;
            // 
            // myRoundedTextBox5
            // 
            this.myRoundedTextBox5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myRoundedTextBox5.BorderRadius = 4;
            this.myRoundedTextBox5.BorderSize = 1;
            this.myRoundedTextBox5.Enabled = false;
            this.myRoundedTextBox5.FocusBorderColor = System.Drawing.Color.Orange;
            this.myRoundedTextBox5.Location = new System.Drawing.Point(170, 266);
            this.myRoundedTextBox5.Name = "myRoundedTextBox5";
            this.myRoundedTextBox5.PasswordChar = '\0';
            this.myRoundedTextBox5.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myRoundedTextBox5.PlaceholderText = "";
            this.myRoundedTextBox5.Size = new System.Drawing.Size(288, 27);
            this.myRoundedTextBox5.TabIndex = 8;
            this.myRoundedTextBox5.UseSystemPasswordChar = false;
            // 
            // tb_prix_achat
            // 
            this.tb_prix_achat.BackColor = System.Drawing.Color.White;
            this.tb_prix_achat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_prix_achat.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_prix_achat.Location = new System.Drawing.Point(174, 219);
            this.tb_prix_achat.Multiline = true;
            this.tb_prix_achat.Name = "tb_prix_achat";
            this.tb_prix_achat.Size = new System.Drawing.Size(280, 23);
            this.tb_prix_achat.TabIndex = 6;
            // 
            // tb_categorie
            // 
            this.tb_categorie.BackColor = System.Drawing.Color.White;
            this.tb_categorie.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_categorie.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_categorie.Location = new System.Drawing.Point(176, 85);
            this.tb_categorie.Multiline = true;
            this.tb_categorie.Name = "tb_categorie";
            this.tb_categorie.Size = new System.Drawing.Size(280, 23);
            this.tb_categorie.TabIndex = 2;
            // 
            // tb_medoc
            // 
            this.tb_medoc.BackColor = System.Drawing.Color.White;
            this.tb_medoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_medoc.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_medoc.Location = new System.Drawing.Point(174, 40);
            this.tb_medoc.Multiline = true;
            this.tb_medoc.Name = "tb_medoc";
            this.tb_medoc.Size = new System.Drawing.Size(280, 23);
            this.tb_medoc.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(174, 40);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(280, 23);
            this.textBox1.TabIndex = 2;
            // 
            // bt_save
            // 
            this.bt_save.BackColor = System.Drawing.Color.Transparent;
            this.bt_save.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_save.BorderRadius = 5;
            this.bt_save.BorderSize = 0;
            this.bt_save.ButtonText = "Enregistrer";
            this.bt_save.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.bt_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_save.Location = new System.Drawing.Point(262, 344);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(124, 30);
            this.bt_save.TabIndex = 2;
            this.bt_save.Click += new System.EventHandler(this.bt_save_medoc_Click);
            // 
            // myRoundedTextBox4
            // 
            this.myRoundedTextBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myRoundedTextBox4.BorderRadius = 4;
            this.myRoundedTextBox4.BorderSize = 1;
            this.myRoundedTextBox4.Enabled = false;
            this.myRoundedTextBox4.FocusBorderColor = System.Drawing.Color.Orange;
            this.myRoundedTextBox4.Location = new System.Drawing.Point(170, 218);
            this.myRoundedTextBox4.Name = "myRoundedTextBox4";
            this.myRoundedTextBox4.PasswordChar = '\0';
            this.myRoundedTextBox4.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myRoundedTextBox4.PlaceholderText = "";
            this.myRoundedTextBox4.Size = new System.Drawing.Size(288, 27);
            this.myRoundedTextBox4.TabIndex = 6;
            this.myRoundedTextBox4.UseSystemPasswordChar = false;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(32, 273);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(81, 14);
            this.label.TabIndex = 0;
            this.label.Text = "Prix de vente : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(32, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "Prix d\'achat : ";
            // 
            // myRoundedTextBox2
            // 
            this.myRoundedTextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myRoundedTextBox2.BorderRadius = 4;
            this.myRoundedTextBox2.BorderSize = 1;
            this.myRoundedTextBox2.Enabled = false;
            this.myRoundedTextBox2.FocusBorderColor = System.Drawing.Color.Orange;
            this.myRoundedTextBox2.Location = new System.Drawing.Point(171, 84);
            this.myRoundedTextBox2.Name = "myRoundedTextBox2";
            this.myRoundedTextBox2.PasswordChar = '\0';
            this.myRoundedTextBox2.PlaceholderColor = System.Drawing.Color.Gray;
            this.myRoundedTextBox2.PlaceholderText = "";
            this.myRoundedTextBox2.Size = new System.Drawing.Size(288, 27);
            this.myRoundedTextBox2.TabIndex = 2;
            this.myRoundedTextBox2.UseSystemPasswordChar = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(32, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "Categorie :";
            // 
            // myRoundedTextBox1
            // 
            this.myRoundedTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myRoundedTextBox1.BorderRadius = 4;
            this.myRoundedTextBox1.BorderSize = 1;
            this.myRoundedTextBox1.Enabled = false;
            this.myRoundedTextBox1.FocusBorderColor = System.Drawing.Color.Orange;
            this.myRoundedTextBox1.Location = new System.Drawing.Point(170, 38);
            this.myRoundedTextBox1.Name = "myRoundedTextBox1";
            this.myRoundedTextBox1.PasswordChar = '\0';
            this.myRoundedTextBox1.PlaceholderColor = System.Drawing.Color.Beige;
            this.myRoundedTextBox1.PlaceholderText = "";
            this.myRoundedTextBox1.Size = new System.Drawing.Size(288, 27);
            this.myRoundedTextBox1.TabIndex = 1;
            this.myRoundedTextBox1.UseSystemPasswordChar = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(32, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 14);
            this.label11.TabIndex = 0;
            this.label11.Text = "Médicament  : ";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(21, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 231);
            this.panel1.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(29, 187);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(139, 19);
            this.label12.TabIndex = 1;
            this.label12.Text = "Ajouter un produit";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.capsules_100px;
            this.pictureBox1.Location = new System.Drawing.Point(20, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(159, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 33;
            this.label1.Text = "Quantité : ";
            // 
            // rb_carton
            // 
            this.rb_carton.AutoSize = true;
            this.rb_carton.Location = new System.Drawing.Point(4, 2);
            this.rb_carton.Name = "rb_carton";
            this.rb_carton.Size = new System.Drawing.Size(56, 17);
            this.rb_carton.TabIndex = 38;
            this.rb_carton.TabStop = true;
            this.rb_carton.Text = "Carton";
            this.rb_carton.UseVisualStyleBackColor = true;
            // 
            // rd_plaquettte
            // 
            this.rd_plaquettte.AutoSize = true;
            this.rd_plaquettte.Location = new System.Drawing.Point(73, 3);
            this.rd_plaquettte.Name = "rd_plaquettte";
            this.rd_plaquettte.Size = new System.Drawing.Size(70, 17);
            this.rd_plaquettte.TabIndex = 40;
            this.rd_plaquettte.TabStop = true;
            this.rd_plaquettte.Text = "Plaquette";
            this.rd_plaquettte.UseVisualStyleBackColor = true;
            this.rd_plaquettte.CheckedChanged += new System.EventHandler(this.rd_plaquettte_CheckedChanged);
            // 
            // rd_comprime
            // 
            this.rd_comprime.AutoSize = true;
            this.rd_comprime.Location = new System.Drawing.Point(4, 34);
            this.rd_comprime.Name = "rd_comprime";
            this.rd_comprime.Size = new System.Drawing.Size(71, 17);
            this.rd_comprime.TabIndex = 41;
            this.rd_comprime.TabStop = true;
            this.rd_comprime.Text = "Comprimé";
            this.rd_comprime.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 14);
            this.label2.TabIndex = 42;
            this.label2.Text = "Stock minimum : ";
            // 
            // rd_autre
            // 
            this.rd_autre.AutoSize = true;
            this.rd_autre.Location = new System.Drawing.Point(87, 34);
            this.rd_autre.Name = "rd_autre";
            this.rd_autre.Size = new System.Drawing.Size(50, 17);
            this.rd_autre.TabIndex = 45;
            this.rd_autre.TabStop = true;
            this.rd_autre.Text = "Autre";
            this.rd_autre.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(267, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 46;
            this.label3.Text = "Unité : ";
            // 
            // num_qty
            // 
            this.num_qty.Location = new System.Drawing.Point(173, 127);
            this.num_qty.Name = "num_qty";
            this.num_qty.Size = new System.Drawing.Size(76, 20);
            this.num_qty.TabIndex = 47;
            this.num_qty.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // num_stock_min
            // 
            this.num_stock_min.Location = new System.Drawing.Point(173, 174);
            this.num_stock_min.Name = "num_stock_min";
            this.num_stock_min.Size = new System.Drawing.Size(76, 20);
            this.num_stock_min.TabIndex = 48;
            // 
            // panel_unity
            // 
            this.panel_unity.Controls.Add(this.rd_plaquettte);
            this.panel_unity.Controls.Add(this.rb_carton);
            this.panel_unity.Controls.Add(this.rd_comprime);
            this.panel_unity.Controls.Add(this.rd_autre);
            this.panel_unity.Location = new System.Drawing.Point(316, 127);
            this.panel_unity.Name = "panel_unity";
            this.panel_unity.Size = new System.Drawing.Size(143, 57);
            this.panel_unity.TabIndex = 49;
            // 
            // UC_add_medoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_medoc);
            this.Controls.Add(this.panel1);
            this.Name = "UC_add_medoc";
            this.Size = new System.Drawing.Size(940, 479);
            this.Load += new System.EventHandler(this.UC_add_medoc_Load);
            this.panel_medoc.ResumeLayout(false);
            this.panel_medoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_image)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_qty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_stock_min)).EndInit();
            this.panel_unity.ResumeLayout(false);
            this.panel_unity.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomRoundedPanel panel_medoc;
        private System.Windows.Forms.TextBox tb_prix_achat;
        private System.Windows.Forms.TextBox tb_categorie;
        private System.Windows.Forms.TextBox tb_medoc;
        private System.Windows.Forms.TextBox textBox1;
        private test_arrondissement2012.PerfectRoundedButton bt_save;
        private MyRoundedTextBox myRoundedTextBox4;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label8;
        private MyRoundedTextBox myRoundedTextBox2;
        private System.Windows.Forms.Label label10;
        private MyRoundedTextBox myRoundedTextBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bt_add_image;
        private System.Windows.Forms.PictureBox picture_image;
        private System.Windows.Forms.TextBox tb_prix_vente;
        private MyRoundedTextBox myRoundedTextBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rd_autre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rd_comprime;
        private System.Windows.Forms.RadioButton rd_plaquettte;
        private System.Windows.Forms.RadioButton rb_carton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown num_stock_min;
        private System.Windows.Forms.NumericUpDown num_qty;
        private System.Windows.Forms.Panel panel_unity;
    }
}
