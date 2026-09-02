namespace Cepima.MesForms
{
    partial class Form_add_category_med
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_add_category_med));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_save_category = new RoundedButton();
            this.tb_cat_color = new ColorPickerTextBox();
            this.tb_cat_name = new MyRoundedTextBox();
            this.myRoundedTextBox1 = new MyRoundedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOUVELLE CATEGORIE MEDICAMENT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nom catégorie:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Couleur:";
            // 
            // btn_save_category
            // 
            this.btn_save_category.BackColor = System.Drawing.Color.Transparent;
            this.btn_save_category.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_save_category.BorderRadius = 10;
            this.btn_save_category.ButtonText = "Enregistrer";
            this.btn_save_category.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save_category.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_save_category.FlatAppearance.BorderSize = 0;
            this.btn_save_category.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_category.ForeColor = System.Drawing.Color.White;
            this.btn_save_category.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_save_category.Image = global::Cepima.Properties.Resources.save_30px;
            this.btn_save_category.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save_category.Location = new System.Drawing.Point(179, 289);
            this.btn_save_category.Name = "btn_save_category";
            this.btn_save_category.Size = new System.Drawing.Size(169, 38);
            this.btn_save_category.TabIndex = 5;
            this.btn_save_category.Text = "Enregistrer";
            this.btn_save_category.TextColor = System.Drawing.Color.White;
            this.btn_save_category.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save_category.UseVisualStyleBackColor = false;
            this.btn_save_category.Click += new System.EventHandler(this.btn_save_category_Click);
            // 
            // tb_cat_color
            // 
            this.tb_cat_color.BackColor = System.Drawing.Color.White;
            this.tb_cat_color.BorderColor = System.Drawing.Color.LightGray;
            this.tb_cat_color.BorderSize = 2;
            this.tb_cat_color.ColorButtonMargin = 12;
            this.tb_cat_color.ColorButtonRadius = 10;
            this.tb_cat_color.ColorButtonSize = 30;
            this.tb_cat_color.FocusBorderColor = System.Drawing.Color.DeepSkyBlue;
            this.tb_cat_color.Location = new System.Drawing.Point(227, 179);
            this.tb_cat_color.Name = "tb_cat_color";
            this.tb_cat_color.SelectedColor = System.Drawing.Color.DodgerBlue;
            this.tb_cat_color.Size = new System.Drawing.Size(250, 43);
            this.tb_cat_color.TabIndex = 4;
            // 
            // tb_cat_name
            // 
            this.tb_cat_name.BackColor = System.Drawing.Color.White;
            this.tb_cat_name.BorderColor = System.Drawing.Color.LightGray;
            this.tb_cat_name.FocusBorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.tb_cat_name.ForeColor = System.Drawing.Color.Black;
            this.tb_cat_name.Image = null;
            this.tb_cat_name.Location = new System.Drawing.Point(227, 89);
            this.tb_cat_name.MaxLength = 32767;
            this.tb_cat_name.Name = "tb_cat_name";
            this.tb_cat_name.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_cat_name.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_cat_name.PlaceholderText = "";
            this.tb_cat_name.Size = new System.Drawing.Size(250, 40);
            this.tb_cat_name.TabIndex = 1;
            // 
            // myRoundedTextBox1
            // 
            this.myRoundedTextBox1.BackColor = System.Drawing.Color.White;
            this.myRoundedTextBox1.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.myRoundedTextBox1.BorderSize = 3;
            this.myRoundedTextBox1.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myRoundedTextBox1.ForeColor = System.Drawing.Color.Black;
            this.myRoundedTextBox1.Image = null;
            this.myRoundedTextBox1.Location = new System.Drawing.Point(147, 153);
            this.myRoundedTextBox1.MaxLength = 32767;
            this.myRoundedTextBox1.Name = "myRoundedTextBox1";
            this.myRoundedTextBox1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.myRoundedTextBox1.PlaceholderColor = System.Drawing.SystemColors.ControlDark;
            this.myRoundedTextBox1.PlaceholderText = "Enter text...";
            this.myRoundedTextBox1.Size = new System.Drawing.Size(250, 40);
            this.myRoundedTextBox1.TabIndex = 1;
            this.myRoundedTextBox1.Text = "myRoundedTextBox1";
            // 
            // Form_add_category_med
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(536, 363);
            this.Controls.Add(this.btn_save_category);
            this.Controls.Add(this.tb_cat_color);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_cat_name);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_add_category_med";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter une catégorie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private MyRoundedTextBox myRoundedTextBox1;
        private MyRoundedTextBox tb_cat_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ColorPickerTextBox tb_cat_color;
        private RoundedButton btn_save_category;
    }
}