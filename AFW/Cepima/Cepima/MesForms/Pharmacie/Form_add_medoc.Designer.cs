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
            this.label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_medoc_name = new MyRoundedTextBox();
            this.ud_seuil = new RoundedNumericUpDown();
            this.cbx_category = new MyRoundedComboBox();
            this.cbx_unity = new MyRoundedComboBox();
            this.btn_add_unity = new System.Windows.Forms.Button();
            this.btn_add_category = new System.Windows.Forms.Button();
            this.btn_cancel = new RoundedButton();
            this.bt_save_medoc = new RoundedButton();
            this.label5 = new System.Windows.Forms.Label();
            this.ud_prix_achat = new RoundedNumericUpDown();
            this.ud_prix_vente = new RoundedNumericUpDown();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(81, 113);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(96, 17);
            this.label.TabIndex = 1;
            this.label.Text = "Médicament : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Categorie:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(86, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Seuil minimum:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(86, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Prix d\'achat : ";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(135, 35);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(295, 24);
            this.title.TabIndex = 7;
            this.title.Text = "INFORMATIONS DU PRODUIT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Unité : ";
            // 
            // tb_medoc_name
            // 
            this.tb_medoc_name.BackColor = System.Drawing.Color.White;
            this.tb_medoc_name.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_medoc_name.BorderRadius = 8;
            this.tb_medoc_name.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_medoc_name.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_medoc_name.ForeColor = System.Drawing.Color.Black;
            this.tb_medoc_name.Image = null;
            this.tb_medoc_name.Location = new System.Drawing.Point(211, 102);
            this.tb_medoc_name.MaxLength = 32767;
            this.tb_medoc_name.Name = "tb_medoc_name";
            this.tb_medoc_name.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_medoc_name.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_medoc_name.PlaceholderText = "";
            this.tb_medoc_name.Size = new System.Drawing.Size(270, 37);
            this.tb_medoc_name.TabIndex = 5;
            // 
            // ud_seuil
            // 
            this.ud_seuil.BackColor = System.Drawing.Color.White;
            this.ud_seuil.BorderColor = System.Drawing.Color.LightGray;
            this.ud_seuil.BorderRadius = 8;
            this.ud_seuil.BorderSize = 2;
            this.ud_seuil.ButtonBackColor = System.Drawing.Color.White;
            this.ud_seuil.ButtonFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ud_seuil.ButtonForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ud_seuil.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ud_seuil.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.ud_seuil.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_seuil.ForeColor = System.Drawing.Color.Black;
            this.ud_seuil.Location = new System.Drawing.Point(211, 306);
            this.ud_seuil.MinimumSize = new System.Drawing.Size(74, 36);
            this.ud_seuil.Name = "ud_seuil";
            this.ud_seuil.Size = new System.Drawing.Size(270, 37);
            this.ud_seuil.TabIndex = 16;
            this.ud_seuil.TextPadding = 5;
            // 
            // cbx_category
            // 
            this.cbx_category.ArrowColor = System.Drawing.Color.DimGray;
            this.cbx_category.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_category.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_category.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbx_category.BorderRadius = 8;
            this.cbx_category.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_category.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_category.DropDownSelectedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.cbx_category.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_category.DropDownWidth = 250;
            this.cbx_category.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.cbx_category.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_category.Location = new System.Drawing.Point(211, 165);
            this.cbx_category.MinimumSize = new System.Drawing.Size(80, 36);
            this.cbx_category.Name = "cbx_category";
            this.cbx_category.SelectedItem = null;
            this.cbx_category.SelectedValue = null;
            this.cbx_category.Size = new System.Drawing.Size(238, 42);
            this.cbx_category.TabIndex = 17;
            // 
            // cbx_unity
            // 
            this.cbx_unity.ArrowColor = System.Drawing.Color.DimGray;
            this.cbx_unity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_unity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_unity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbx_unity.BorderRadius = 8;
            this.cbx_unity.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_unity.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_unity.DropDownSelectedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.cbx_unity.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_unity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_unity.DropDownWidth = 250;
            this.cbx_unity.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.cbx_unity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_unity.Location = new System.Drawing.Point(211, 233);
            this.cbx_unity.MinimumSize = new System.Drawing.Size(80, 36);
            this.cbx_unity.Name = "cbx_unity";
            this.cbx_unity.SelectedItem = null;
            this.cbx_unity.SelectedValue = null;
            this.cbx_unity.Size = new System.Drawing.Size(238, 42);
            this.cbx_unity.TabIndex = 18;
            // 
            // btn_add_unity
            // 
            this.btn_add_unity.FlatAppearance.BorderSize = 0;
            this.btn_add_unity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_unity.Image = global::Cepima.Properties.Resources.plus___35px;
            this.btn_add_unity.Location = new System.Drawing.Point(452, 241);
            this.btn_add_unity.Name = "btn_add_unity";
            this.btn_add_unity.Size = new System.Drawing.Size(32, 31);
            this.btn_add_unity.TabIndex = 20;
            this.btn_add_unity.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_add_unity.UseVisualStyleBackColor = true;
            this.btn_add_unity.Click += new System.EventHandler(this.btn_add_unity_Click);
            // 
            // btn_add_category
            // 
            this.btn_add_category.FlatAppearance.BorderSize = 0;
            this.btn_add_category.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_category.Image = global::Cepima.Properties.Resources.plus___35px;
            this.btn_add_category.Location = new System.Drawing.Point(452, 173);
            this.btn_add_category.Name = "btn_add_category";
            this.btn_add_category.Size = new System.Drawing.Size(32, 31);
            this.btn_add_category.TabIndex = 19;
            this.btn_add_category.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_add_category.UseVisualStyleBackColor = true;
            this.btn_add_category.Click += new System.EventHandler(this.btn_add_category_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancel.BorderColor = System.Drawing.Color.White;
            this.btn_cancel.BorderRadius = 10;
            this.btn_cancel.BorderSize = 0;
            this.btn_cancel.ButtonText = "Annuler";
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel.DefaultBackColor = System.Drawing.Color.Crimson;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_cancel.Image = global::Cepima.Properties.Resources.cancel_30px;
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancel.Location = new System.Drawing.Point(116, 526);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(150, 45);
            this.btn_cancel.TabIndex = 15;
            this.btn_cancel.Text = "Annuler";
            this.btn_cancel.TextColor = System.Drawing.Color.White;
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // bt_save_medoc
            // 
            this.bt_save_medoc.BackColor = System.Drawing.Color.Transparent;
            this.bt_save_medoc.BorderColor = System.Drawing.Color.White;
            this.bt_save_medoc.BorderRadius = 10;
            this.bt_save_medoc.BorderSize = 0;
            this.bt_save_medoc.ButtonText = "Enregistrer";
            this.bt_save_medoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_save_medoc.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_save_medoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_save_medoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save_medoc.ForeColor = System.Drawing.Color.White;
            this.bt_save_medoc.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_save_medoc.Image = global::Cepima.Properties.Resources.save_30px;
            this.bt_save_medoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_save_medoc.Location = new System.Drawing.Point(299, 526);
            this.bt_save_medoc.Name = "bt_save_medoc";
            this.bt_save_medoc.Size = new System.Drawing.Size(164, 45);
            this.bt_save_medoc.TabIndex = 14;
            this.bt_save_medoc.Text = "Enregistrer";
            this.bt_save_medoc.TextColor = System.Drawing.Color.White;
            this.bt_save_medoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_save_medoc.UseVisualStyleBackColor = false;
            this.bt_save_medoc.Click += new System.EventHandler(this.bt_save_medoc_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(86, 453);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Prix de vente : ";
            // 
            // ud_prix_achat
            // 
            this.ud_prix_achat.BackColor = System.Drawing.Color.White;
            this.ud_prix_achat.BorderColor = System.Drawing.Color.LightGray;
            this.ud_prix_achat.BorderRadius = 8;
            this.ud_prix_achat.BorderSize = 2;
            this.ud_prix_achat.ButtonBackColor = System.Drawing.Color.White;
            this.ud_prix_achat.ButtonFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ud_prix_achat.ButtonForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ud_prix_achat.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ud_prix_achat.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.ud_prix_achat.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_prix_achat.ForeColor = System.Drawing.Color.Black;
            this.ud_prix_achat.Location = new System.Drawing.Point(211, 376);
            this.ud_prix_achat.MinimumSize = new System.Drawing.Size(74, 36);
            this.ud_prix_achat.Name = "ud_prix_achat";
            this.ud_prix_achat.Size = new System.Drawing.Size(270, 37);
            this.ud_prix_achat.TabIndex = 21;
            this.ud_prix_achat.TextPadding = 5;
            // 
            // ud_prix_vente
            // 
            this.ud_prix_vente.BackColor = System.Drawing.Color.White;
            this.ud_prix_vente.BorderColor = System.Drawing.Color.LightGray;
            this.ud_prix_vente.BorderRadius = 8;
            this.ud_prix_vente.BorderSize = 2;
            this.ud_prix_vente.ButtonBackColor = System.Drawing.Color.White;
            this.ud_prix_vente.ButtonFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ud_prix_vente.ButtonForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ud_prix_vente.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ud_prix_vente.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.ud_prix_vente.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_prix_vente.ForeColor = System.Drawing.Color.Black;
            this.ud_prix_vente.Location = new System.Drawing.Point(211, 443);
            this.ud_prix_vente.MinimumSize = new System.Drawing.Size(74, 36);
            this.ud_prix_vente.Name = "ud_prix_vente";
            this.ud_prix_vente.Size = new System.Drawing.Size(270, 37);
            this.ud_prix_vente.TabIndex = 22;
            this.ud_prix_vente.TextPadding = 5;
            // 
            // Form_add_medoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(565, 621);
            this.Controls.Add(this.ud_prix_vente);
            this.Controls.Add(this.ud_prix_achat);
            this.Controls.Add(this.btn_add_unity);
            this.Controls.Add(this.btn_add_category);
            this.Controls.Add(this.cbx_unity);
            this.Controls.Add(this.cbx_category);
            this.Controls.Add(this.ud_seuil);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.bt_save_medoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.tb_medoc_name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label);
            this.Name = "Form_add_medoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_add_medoc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label1;
        private RoundedButton bt_save_medoc;
        private RoundedButton btn_cancel;
        private MyRoundedTextBox tb_medoc_name;
        private RoundedNumericUpDown ud_seuil;
        private MyRoundedComboBox cbx_category;
        private MyRoundedComboBox cbx_unity;
        private System.Windows.Forms.Button btn_add_category;
        private System.Windows.Forms.Button btn_add_unity;
        private System.Windows.Forms.Label label5;
        private RoundedNumericUpDown ud_prix_achat;
        private RoundedNumericUpDown ud_prix_vente;
    }
}