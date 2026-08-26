namespace Cepima.MesForms
{
    partial class FormDetailPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetailPatient));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_numero = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_mod_genre = new System.Windows.Forms.Button();
            this.bt_mod_prenom = new System.Windows.Forms.Button();
            this.bt_mod_postnom = new System.Windows.Forms.Button();
            this.bt_mod_adresse = new System.Windows.Forms.Button();
            this.bt_mod_phone = new System.Windows.Forms.Button();
            this.bt_mod_nom = new System.Windows.Forms.Button();
            this.tb_mod_postnom = new System.Windows.Forms.TextBox();
            this.tb_mod_adresse = new System.Windows.Forms.TextBox();
            this.tb_mod_phone = new System.Windows.Forms.TextBox();
            this.tb_mod_genre = new System.Windows.Forms.TextBox();
            this.tb_mod_prenom = new System.Windows.Forms.TextBox();
            this.tb_mod_nom = new System.Windows.Forms.TextBox();
            this.lb_genre = new System.Windows.Forms.Label();
            this.lb_adresse = new System.Windows.Forms.Label();
            this.lb_phone = new System.Windows.Forms.Label();
            this.lb_prenom = new System.Windows.Forms.Label();
            this.lb_centre = new System.Windows.Forms.Label();
            this.lb_date = new System.Windows.Forms.Label();
            this.lb_postnom = new System.Windows.Forms.Label();
            this.lb_nom = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_save_update = new RoundedButton();
            this.bt_cancel = new RoundedButton();
            this.bt_delete_patient = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lb_numero);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 50);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.more_details_40px;
            this.pictureBox1.Location = new System.Drawing.Point(4, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(60, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Détail du Patient du numero de la fiche :  ";
            // 
            // lb_numero
            // 
            this.lb_numero.AutoSize = true;
            this.lb_numero.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lb_numero.ForeColor = System.Drawing.Color.White;
            this.lb_numero.Location = new System.Drawing.Point(399, 20);
            this.lb_numero.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_numero.Name = "lb_numero";
            this.lb_numero.Size = new System.Drawing.Size(72, 23);
            this.lb_numero.TabIndex = 0;
            this.lb_numero.Text = "numero";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bt_mod_genre);
            this.panel2.Controls.Add(this.bt_mod_prenom);
            this.panel2.Controls.Add(this.bt_mod_postnom);
            this.panel2.Controls.Add(this.bt_mod_adresse);
            this.panel2.Controls.Add(this.bt_mod_phone);
            this.panel2.Controls.Add(this.bt_mod_nom);
            this.panel2.Controls.Add(this.tb_mod_postnom);
            this.panel2.Controls.Add(this.tb_mod_adresse);
            this.panel2.Controls.Add(this.tb_mod_phone);
            this.panel2.Controls.Add(this.tb_mod_genre);
            this.panel2.Controls.Add(this.tb_mod_prenom);
            this.panel2.Controls.Add(this.tb_mod_nom);
            this.panel2.Controls.Add(this.lb_genre);
            this.panel2.Controls.Add(this.lb_adresse);
            this.panel2.Controls.Add(this.lb_phone);
            this.panel2.Controls.Add(this.lb_prenom);
            this.panel2.Controls.Add(this.lb_centre);
            this.panel2.Controls.Add(this.lb_date);
            this.panel2.Controls.Add(this.lb_postnom);
            this.panel2.Controls.Add(this.lb_nom);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(62, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(712, 267);
            this.panel2.TabIndex = 4;
            // 
            // bt_mod_genre
            // 
            this.bt_mod_genre.FlatAppearance.BorderSize = 0;
            this.bt_mod_genre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_mod_genre.Image = ((System.Drawing.Image)(resources.GetObject("bt_mod_genre.Image")));
            this.bt_mod_genre.Location = new System.Drawing.Point(284, 179);
            this.bt_mod_genre.Name = "bt_mod_genre";
            this.bt_mod_genre.Size = new System.Drawing.Size(25, 25);
            this.bt_mod_genre.TabIndex = 12;
            this.bt_mod_genre.UseVisualStyleBackColor = true;
            this.bt_mod_genre.Click += new System.EventHandler(this.bt_mod_genre_Click);
            // 
            // bt_mod_prenom
            // 
            this.bt_mod_prenom.FlatAppearance.BorderSize = 0;
            this.bt_mod_prenom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_mod_prenom.Image = ((System.Drawing.Image)(resources.GetObject("bt_mod_prenom.Image")));
            this.bt_mod_prenom.Location = new System.Drawing.Point(284, 128);
            this.bt_mod_prenom.Name = "bt_mod_prenom";
            this.bt_mod_prenom.Size = new System.Drawing.Size(25, 25);
            this.bt_mod_prenom.TabIndex = 12;
            this.bt_mod_prenom.UseVisualStyleBackColor = true;
            this.bt_mod_prenom.Click += new System.EventHandler(this.bt_mod_prenom_Click);
            // 
            // bt_mod_postnom
            // 
            this.bt_mod_postnom.FlatAppearance.BorderSize = 0;
            this.bt_mod_postnom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_mod_postnom.Image = ((System.Drawing.Image)(resources.GetObject("bt_mod_postnom.Image")));
            this.bt_mod_postnom.Location = new System.Drawing.Point(284, 74);
            this.bt_mod_postnom.Name = "bt_mod_postnom";
            this.bt_mod_postnom.Size = new System.Drawing.Size(25, 25);
            this.bt_mod_postnom.TabIndex = 12;
            this.bt_mod_postnom.UseVisualStyleBackColor = true;
            this.bt_mod_postnom.Click += new System.EventHandler(this.bt_mod_postnom_Click);
            // 
            // bt_mod_adresse
            // 
            this.bt_mod_adresse.FlatAppearance.BorderSize = 0;
            this.bt_mod_adresse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_mod_adresse.Image = ((System.Drawing.Image)(resources.GetObject("bt_mod_adresse.Image")));
            this.bt_mod_adresse.Location = new System.Drawing.Point(659, 126);
            this.bt_mod_adresse.Name = "bt_mod_adresse";
            this.bt_mod_adresse.Size = new System.Drawing.Size(25, 25);
            this.bt_mod_adresse.TabIndex = 12;
            this.bt_mod_adresse.UseVisualStyleBackColor = true;
            this.bt_mod_adresse.Click += new System.EventHandler(this.bt_mod_adresse_Click);
            // 
            // bt_mod_phone
            // 
            this.bt_mod_phone.FlatAppearance.BorderSize = 0;
            this.bt_mod_phone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_mod_phone.Image = ((System.Drawing.Image)(resources.GetObject("bt_mod_phone.Image")));
            this.bt_mod_phone.Location = new System.Drawing.Point(659, 74);
            this.bt_mod_phone.Name = "bt_mod_phone";
            this.bt_mod_phone.Size = new System.Drawing.Size(25, 25);
            this.bt_mod_phone.TabIndex = 12;
            this.bt_mod_phone.UseVisualStyleBackColor = true;
            this.bt_mod_phone.Click += new System.EventHandler(this.bt_mod_phone_Click);
            // 
            // bt_mod_nom
            // 
            this.bt_mod_nom.FlatAppearance.BorderSize = 0;
            this.bt_mod_nom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_mod_nom.Image = ((System.Drawing.Image)(resources.GetObject("bt_mod_nom.Image")));
            this.bt_mod_nom.Location = new System.Drawing.Point(284, 23);
            this.bt_mod_nom.Name = "bt_mod_nom";
            this.bt_mod_nom.Size = new System.Drawing.Size(25, 25);
            this.bt_mod_nom.TabIndex = 12;
            this.bt_mod_nom.UseVisualStyleBackColor = true;
            this.bt_mod_nom.Click += new System.EventHandler(this.bt_mod_nom_Click);
            // 
            // tb_mod_postnom
            // 
            this.tb_mod_postnom.Location = new System.Drawing.Point(106, 77);
            this.tb_mod_postnom.Name = "tb_mod_postnom";
            this.tb_mod_postnom.Size = new System.Drawing.Size(172, 20);
            this.tb_mod_postnom.TabIndex = 7;
            // 
            // tb_mod_adresse
            // 
            this.tb_mod_adresse.Location = new System.Drawing.Point(509, 129);
            this.tb_mod_adresse.Name = "tb_mod_adresse";
            this.tb_mod_adresse.Size = new System.Drawing.Size(144, 20);
            this.tb_mod_adresse.TabIndex = 6;
            // 
            // tb_mod_phone
            // 
            this.tb_mod_phone.Location = new System.Drawing.Point(509, 77);
            this.tb_mod_phone.Name = "tb_mod_phone";
            this.tb_mod_phone.Size = new System.Drawing.Size(144, 20);
            this.tb_mod_phone.TabIndex = 5;
            // 
            // tb_mod_genre
            // 
            this.tb_mod_genre.Location = new System.Drawing.Point(106, 182);
            this.tb_mod_genre.Name = "tb_mod_genre";
            this.tb_mod_genre.Size = new System.Drawing.Size(172, 20);
            this.tb_mod_genre.TabIndex = 4;
            // 
            // tb_mod_prenom
            // 
            this.tb_mod_prenom.Location = new System.Drawing.Point(106, 130);
            this.tb_mod_prenom.Name = "tb_mod_prenom";
            this.tb_mod_prenom.Size = new System.Drawing.Size(172, 20);
            this.tb_mod_prenom.TabIndex = 3;
            // 
            // tb_mod_nom
            // 
            this.tb_mod_nom.Location = new System.Drawing.Point(106, 25);
            this.tb_mod_nom.Name = "tb_mod_nom";
            this.tb_mod_nom.Size = new System.Drawing.Size(172, 20);
            this.tb_mod_nom.TabIndex = 2;
            // 
            // lb_genre
            // 
            this.lb_genre.AutoSize = true;
            this.lb_genre.Font = new System.Drawing.Font("Calibri", 9F);
            this.lb_genre.Location = new System.Drawing.Point(103, 188);
            this.lb_genre.Name = "lb_genre";
            this.lb_genre.Size = new System.Drawing.Size(38, 14);
            this.lb_genre.TabIndex = 1;
            this.lb_genre.Text = "genre";
            // 
            // lb_adresse
            // 
            this.lb_adresse.AutoSize = true;
            this.lb_adresse.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_adresse.Location = new System.Drawing.Point(506, 133);
            this.lb_adresse.Name = "lb_adresse";
            this.lb_adresse.Size = new System.Drawing.Size(51, 14);
            this.lb_adresse.TabIndex = 1;
            this.lb_adresse.Text = "adresse";
            // 
            // lb_phone
            // 
            this.lb_phone.AutoSize = true;
            this.lb_phone.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_phone.Location = new System.Drawing.Point(506, 82);
            this.lb_phone.Name = "lb_phone";
            this.lb_phone.Size = new System.Drawing.Size(42, 14);
            this.lb_phone.TabIndex = 1;
            this.lb_phone.Text = "phone";
            // 
            // lb_prenom
            // 
            this.lb_prenom.AutoSize = true;
            this.lb_prenom.Font = new System.Drawing.Font("Calibri", 9F);
            this.lb_prenom.Location = new System.Drawing.Point(103, 136);
            this.lb_prenom.Name = "lb_prenom";
            this.lb_prenom.Size = new System.Drawing.Size(49, 14);
            this.lb_prenom.TabIndex = 1;
            this.lb_prenom.Text = "prenom";
            // 
            // lb_centre
            // 
            this.lb_centre.AutoSize = true;
            this.lb_centre.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_centre.Location = new System.Drawing.Point(506, 187);
            this.lb_centre.Name = "lb_centre";
            this.lb_centre.Size = new System.Drawing.Size(63, 14);
            this.lb_centre.TabIndex = 1;
            this.lb_centre.Text = "naissance";
            // 
            // lb_date
            // 
            this.lb_date.AutoSize = true;
            this.lb_date.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_date.Location = new System.Drawing.Point(506, 32);
            this.lb_date.Name = "lb_date";
            this.lb_date.Size = new System.Drawing.Size(63, 14);
            this.lb_date.TabIndex = 1;
            this.lb_date.Text = "naissance";
            // 
            // lb_postnom
            // 
            this.lb_postnom.AutoSize = true;
            this.lb_postnom.Font = new System.Drawing.Font("Calibri", 9F);
            this.lb_postnom.Location = new System.Drawing.Point(103, 83);
            this.lb_postnom.Name = "lb_postnom";
            this.lb_postnom.Size = new System.Drawing.Size(55, 14);
            this.lb_postnom.TabIndex = 1;
            this.lb_postnom.Text = "postnom";
            // 
            // lb_nom
            // 
            this.lb_nom.AutoSize = true;
            this.lb_nom.Font = new System.Drawing.Font("Calibri", 9F);
            this.lb_nom.Location = new System.Drawing.Point(103, 31);
            this.lb_nom.Name = "lb_nom";
            this.lb_nom.Size = new System.Drawing.Size(31, 14);
            this.lb_nom.TabIndex = 1;
            this.lb_nom.Text = "nom";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Genre : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(381, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Centre  : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(381, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Adresse  : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(381, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Téléphone  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Prénom : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(381, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Date de naisance : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Post-Nom :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nom : ";
            // 
            // bt_save_update
            // 
            this.bt_save_update.BackColor = System.Drawing.Color.Transparent;
            this.bt_save_update.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_save_update.BorderRadius = 4;
            this.bt_save_update.BorderSize = 0;
            this.bt_save_update.ButtonText = "Enregister ";
            this.bt_save_update.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.bt_save_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.bt_save_update.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_save_update.Location = new System.Drawing.Point(504, 368);
            this.bt_save_update.Name = "bt_save_update";
            this.bt_save_update.Size = new System.Drawing.Size(127, 29);
            this.bt_save_update.TabIndex = 14;
            this.bt_save_update.Click += new System.EventHandler(this.bt_save_update_Click);
            // 
            // bt_cancel
            // 
            this.bt_cancel.BackColor = System.Drawing.Color.Transparent;
            this.bt_cancel.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_cancel.BorderRadius = 4;
            this.bt_cancel.BorderSize = 0;
            this.bt_cancel.ButtonText = "Annuler";
            this.bt_cancel.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.bt_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_cancel.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_cancel.Location = new System.Drawing.Point(64, 368);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(132, 29);
            this.bt_cancel.TabIndex = 13;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // bt_delete_patient
            // 
            this.bt_delete_patient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_delete_patient.FlatAppearance.BorderSize = 0;
            this.bt_delete_patient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_delete_patient.Image = global::Cepima.Properties.Resources.trasch_blue;
            this.bt_delete_patient.Location = new System.Drawing.Point(792, 363);
            this.bt_delete_patient.Name = "bt_delete_patient";
            this.bt_delete_patient.Size = new System.Drawing.Size(33, 34);
            this.bt_delete_patient.TabIndex = 12;
            this.bt_delete_patient.UseVisualStyleBackColor = true;
            this.bt_delete_patient.Click += new System.EventHandler(this.bt_delete_patient_Click);
            // 
            // FormDetailPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(837, 405);
            this.Controls.Add(this.bt_save_update);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_delete_patient);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormDetailPatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormDetailPatient_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_numero;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bt_mod_genre;
        private System.Windows.Forms.Button bt_mod_prenom;
        private System.Windows.Forms.Button bt_mod_postnom;
        private System.Windows.Forms.Button bt_mod_adresse;
        private System.Windows.Forms.Button bt_mod_phone;
        private System.Windows.Forms.Button bt_mod_nom;
        private System.Windows.Forms.TextBox tb_mod_postnom;
        private System.Windows.Forms.TextBox tb_mod_adresse;
        private System.Windows.Forms.TextBox tb_mod_phone;
        private System.Windows.Forms.TextBox tb_mod_genre;
        private System.Windows.Forms.TextBox tb_mod_prenom;
        private System.Windows.Forms.TextBox tb_mod_nom;
        private System.Windows.Forms.Label lb_genre;
        private System.Windows.Forms.Label lb_adresse;
        private System.Windows.Forms.Label lb_phone;
        private System.Windows.Forms.Label lb_prenom;
        private System.Windows.Forms.Label lb_centre;
        private System.Windows.Forms.Label lb_date;
        private System.Windows.Forms.Label lb_postnom;
        private System.Windows.Forms.Label lb_nom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private RoundedButton bt_save_update;
        private RoundedButton bt_cancel;
        private System.Windows.Forms.Button bt_delete_patient;

    }
}