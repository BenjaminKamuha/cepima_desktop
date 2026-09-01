namespace Cepima.MesForms
{
    partial class Form_add_unity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_add_unity));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_unity_name = new MyRoundedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_save_unity = new RoundedButton();
            this.tb_unity_abr = new MyRoundedTextBox();
            this.tb_unity_desc = new MyRoundedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Abréviation:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.No;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nom de l\'unité:";
            // 
            // tb_unity_name
            // 
            this.tb_unity_name.BackColor = System.Drawing.Color.White;
            this.tb_unity_name.BorderColor = System.Drawing.Color.LightGray;
            this.tb_unity_name.FocusBorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.tb_unity_name.ForeColor = System.Drawing.Color.Black;
            this.tb_unity_name.Image = null;
            this.tb_unity_name.Location = new System.Drawing.Point(227, 107);
            this.tb_unity_name.MaxLength = 32767;
            this.tb_unity_name.Name = "tb_unity_name";
            this.tb_unity_name.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_unity_name.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_unity_name.PlaceholderText = "";
            this.tb_unity_name.Size = new System.Drawing.Size(250, 40);
            this.tb_unity_name.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(97, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "NOUVELLE UNITE DE GESTION";
            // 
            // btn_save_unity
            // 
            this.btn_save_unity.BackColor = System.Drawing.Color.Transparent;
            this.btn_save_unity.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_save_unity.BorderRadius = 10;
            this.btn_save_unity.ButtonText = "Enregistrer";
            this.btn_save_unity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save_unity.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_save_unity.FlatAppearance.BorderSize = 0;
            this.btn_save_unity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save_unity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_unity.ForeColor = System.Drawing.Color.White;
            this.btn_save_unity.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_save_unity.Image = global::Cepima.Properties.Resources.save_30px;
            this.btn_save_unity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save_unity.Location = new System.Drawing.Point(179, 329);
            this.btn_save_unity.Name = "btn_save_unity";
            this.btn_save_unity.Size = new System.Drawing.Size(169, 38);
            this.btn_save_unity.TabIndex = 12;
            this.btn_save_unity.Text = "Enregistrer";
            this.btn_save_unity.TextColor = System.Drawing.Color.White;
            this.btn_save_unity.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save_unity.UseVisualStyleBackColor = false;
            this.btn_save_unity.Click += new System.EventHandler(this.btn_save_unity_Click);
            // 
            // tb_unity_abr
            // 
            this.tb_unity_abr.BackColor = System.Drawing.Color.White;
            this.tb_unity_abr.BorderColor = System.Drawing.Color.LightGray;
            this.tb_unity_abr.FocusBorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.tb_unity_abr.ForeColor = System.Drawing.Color.Black;
            this.tb_unity_abr.Image = null;
            this.tb_unity_abr.Location = new System.Drawing.Point(227, 173);
            this.tb_unity_abr.MaxLength = 32767;
            this.tb_unity_abr.Name = "tb_unity_abr";
            this.tb_unity_abr.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_unity_abr.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_unity_abr.PlaceholderText = "";
            this.tb_unity_abr.Size = new System.Drawing.Size(250, 40);
            this.tb_unity_abr.TabIndex = 13;
            // 
            // tb_unity_desc
            // 
            this.tb_unity_desc.BackColor = System.Drawing.Color.White;
            this.tb_unity_desc.BorderColor = System.Drawing.Color.LightGray;
            this.tb_unity_desc.FocusBorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.tb_unity_desc.ForeColor = System.Drawing.Color.Black;
            this.tb_unity_desc.Image = null;
            this.tb_unity_desc.Location = new System.Drawing.Point(227, 243);
            this.tb_unity_desc.MaxLength = 32767;
            this.tb_unity_desc.Name = "tb_unity_desc";
            this.tb_unity_desc.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_unity_desc.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_unity_desc.PlaceholderText = "";
            this.tb_unity_desc.Size = new System.Drawing.Size(250, 40);
            this.tb_unity_desc.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(78, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Description:";
            // 
            // Form_add_unity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(536, 393);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_unity_desc);
            this.Controls.Add(this.tb_unity_abr);
            this.Controls.Add(this.btn_save_unity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_unity_name);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_add_unity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter l\'unité";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedButton btn_save_unity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private MyRoundedTextBox tb_unity_name;
        private System.Windows.Forms.Label label1;
        private MyRoundedTextBox tb_unity_abr;
        private MyRoundedTextBox tb_unity_desc;
        private System.Windows.Forms.Label label4;
    }
}