namespace Cepima.MesForms
{
    partial class Form_add_medoc
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
            this.tb_medoc = new System.Windows.Forms.TextBox();
            this.tb_categorie = new System.Windows.Forms.TextBox();
            this.tb_unity = new System.Windows.Forms.TextBox();
            this.tb_prix_achat = new System.Windows.Forms.TextBox();
            this.tb_prix_vente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bt_save_medoc = new System.Windows.Forms.Button();
            this.picture_image = new System.Windows.Forms.PictureBox();
            this.bt_add_image = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picture_image)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_medoc
            // 
            this.tb_medoc.Location = new System.Drawing.Point(172, 100);
            this.tb_medoc.Name = "tb_medoc";
            this.tb_medoc.Size = new System.Drawing.Size(203, 20);
            this.tb_medoc.TabIndex = 0;
            // 
            // tb_categorie
            // 
            this.tb_categorie.Location = new System.Drawing.Point(172, 145);
            this.tb_categorie.Name = "tb_categorie";
            this.tb_categorie.Size = new System.Drawing.Size(203, 20);
            this.tb_categorie.TabIndex = 0;
            // 
            // tb_unity
            // 
            this.tb_unity.Location = new System.Drawing.Point(172, 196);
            this.tb_unity.Name = "tb_unity";
            this.tb_unity.Size = new System.Drawing.Size(203, 20);
            this.tb_unity.TabIndex = 0;
            // 
            // tb_prix_achat
            // 
            this.tb_prix_achat.Location = new System.Drawing.Point(172, 248);
            this.tb_prix_achat.Name = "tb_prix_achat";
            this.tb_prix_achat.Size = new System.Drawing.Size(203, 20);
            this.tb_prix_achat.TabIndex = 0;
            // 
            // tb_prix_vente
            // 
            this.tb_prix_vente.Location = new System.Drawing.Point(172, 298);
            this.tb_prix_vente.Name = "tb_prix_vente";
            this.tb_prix_vente.Size = new System.Drawing.Size(203, 20);
            this.tb_prix_vente.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Médicament : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Categorie";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Unité : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Prix d\'achat : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Prix de vente : ";
            // 
            // bt_save_medoc
            // 
            this.bt_save_medoc.Location = new System.Drawing.Point(209, 356);
            this.bt_save_medoc.Name = "bt_save_medoc";
            this.bt_save_medoc.Size = new System.Drawing.Size(132, 23);
            this.bt_save_medoc.TabIndex = 2;
            this.bt_save_medoc.Text = "Ajouter medicament";
            this.bt_save_medoc.UseVisualStyleBackColor = true;
            this.bt_save_medoc.Click += new System.EventHandler(this.bt_save_medoc_Click);
            // 
            // picture_image
            // 
            this.picture_image.Location = new System.Drawing.Point(402, 227);
            this.picture_image.Name = "picture_image";
            this.picture_image.Size = new System.Drawing.Size(114, 91);
            this.picture_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_image.TabIndex = 3;
            this.picture_image.TabStop = false;
            // 
            // bt_add_image
            // 
            this.bt_add_image.Location = new System.Drawing.Point(402, 194);
            this.bt_add_image.Name = "bt_add_image";
            this.bt_add_image.Size = new System.Drawing.Size(114, 23);
            this.bt_add_image.TabIndex = 4;
            this.bt_add_image.Text = "choisir image";
            this.bt_add_image.UseVisualStyleBackColor = true;
            this.bt_add_image.Click += new System.EventHandler(this.bt_add_image_Click);
            // 
            // Form_add_medoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 419);
            this.Controls.Add(this.bt_add_image);
            this.Controls.Add(this.picture_image);
            this.Controls.Add(this.bt_save_medoc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_prix_vente);
            this.Controls.Add(this.tb_prix_achat);
            this.Controls.Add(this.tb_unity);
            this.Controls.Add(this.tb_categorie);
            this.Controls.Add(this.tb_medoc);
            this.Name = "Form_add_medoc";
            this.Text = "Form_add_medoc";
            ((System.ComponentModel.ISupportInitialize)(this.picture_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_medoc;
        private System.Windows.Forms.TextBox tb_categorie;
        private System.Windows.Forms.TextBox tb_unity;
        private System.Windows.Forms.TextBox tb_prix_achat;
        private System.Windows.Forms.TextBox tb_prix_vente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bt_save_medoc;
        private System.Windows.Forms.PictureBox picture_image;
        private System.Windows.Forms.Button bt_add_image;
    }
}