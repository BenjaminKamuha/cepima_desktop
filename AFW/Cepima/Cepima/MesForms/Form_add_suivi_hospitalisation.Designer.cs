namespace Cepima.MesForms
{
    partial class Form_add_suivi_hospitalisation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_add_suivi_hospitalisation));
            this.tb_temperature = new MyRoundedTextBox();
            this.tb_tension = new MyRoundedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_rythme = new MyRoundedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rich_text = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_etat_mental = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bt_save_suivi = new test_arrondissement2012.PerfectRoundedButton();
            this.SuspendLayout();
            // 
            // tb_temperature
            // 
            this.tb_temperature.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_temperature.BorderRadius = 4;
            this.tb_temperature.BorderSize = 0;
            this.tb_temperature.FocusBorderColor = System.Drawing.Color.Orange;
            this.tb_temperature.Location = new System.Drawing.Point(185, 39);
            this.tb_temperature.Name = "tb_temperature";
            this.tb_temperature.PasswordChar = '\0';
            this.tb_temperature.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_temperature.PlaceholderText = "";
            this.tb_temperature.Size = new System.Drawing.Size(213, 28);
            this.tb_temperature.TabIndex = 17;
            this.tb_temperature.UseSystemPasswordChar = false;
            // 
            // tb_tension
            // 
            this.tb_tension.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_tension.BorderRadius = 4;
            this.tb_tension.BorderSize = 0;
            this.tb_tension.FocusBorderColor = System.Drawing.Color.Orange;
            this.tb_tension.Location = new System.Drawing.Point(185, 97);
            this.tb_tension.Name = "tb_tension";
            this.tb_tension.PasswordChar = '\0';
            this.tb_tension.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_tension.PlaceholderText = "";
            this.tb_tension.Size = new System.Drawing.Size(213, 28);
            this.tb_tension.TabIndex = 17;
            this.tb_tension.UseSystemPasswordChar = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 14);
            this.label3.TabIndex = 18;
            this.label3.Text = "Température : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 14);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tension arterielle : ";
            // 
            // tb_rythme
            // 
            this.tb_rythme.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_rythme.BorderRadius = 4;
            this.tb_rythme.BorderSize = 0;
            this.tb_rythme.FocusBorderColor = System.Drawing.Color.Orange;
            this.tb_rythme.Location = new System.Drawing.Point(185, 151);
            this.tb_rythme.Name = "tb_rythme";
            this.tb_rythme.PasswordChar = '\0';
            this.tb_rythme.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_rythme.PlaceholderText = "";
            this.tb_rythme.Size = new System.Drawing.Size(213, 28);
            this.tb_rythme.TabIndex = 17;
            this.tb_rythme.UseSystemPasswordChar = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 14);
            this.label4.TabIndex = 18;
            this.label4.Text = "Rythme cardiaque : ";
            // 
            // rich_text
            // 
            this.rich_text.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rich_text.Location = new System.Drawing.Point(185, 212);
            this.rich_text.Name = "rich_text";
            this.rich_text.Size = new System.Drawing.Size(213, 53);
            this.rich_text.TabIndex = 19;
            this.rich_text.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(69, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 14);
            this.label5.TabIndex = 18;
            this.label5.Text = "Observation : ";
            // 
            // cbx_etat_mental
            // 
            this.cbx_etat_mental.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_etat_mental.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_etat_mental.FormattingEnabled = true;
            this.cbx_etat_mental.Location = new System.Drawing.Point(185, 295);
            this.cbx_etat_mental.Name = "cbx_etat_mental";
            this.cbx_etat_mental.Size = new System.Drawing.Size(213, 22);
            this.cbx_etat_mental.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(69, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 14);
            this.label6.TabIndex = 18;
            this.label6.Text = "Etat mental : ";
            // 
            // bt_save_suivi
            // 
            this.bt_save_suivi.BackColor = System.Drawing.Color.Transparent;
            this.bt_save_suivi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bt_save_suivi.BorderColor = System.Drawing.Color.Transparent;
            this.bt_save_suivi.BorderRadius = 5;
            this.bt_save_suivi.BorderSize = 0;
            this.bt_save_suivi.ButtonText = "Enregistrer suivi hospitalisation";
            this.bt_save_suivi.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.bt_save_suivi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save_suivi.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_save_suivi.Location = new System.Drawing.Point(185, 344);
            this.bt_save_suivi.Name = "bt_save_suivi";
            this.bt_save_suivi.Size = new System.Drawing.Size(193, 28);
            this.bt_save_suivi.TabIndex = 21;
            this.bt_save_suivi.Click += new System.EventHandler(this.bt_save_suivi_Click);
            // 
            // Form_add_suivi_hospitalisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(527, 394);
            this.Controls.Add(this.bt_save_suivi);
            this.Controls.Add(this.cbx_etat_mental);
            this.Controls.Add(this.rich_text);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_rythme);
            this.Controls.Add(this.tb_tension);
            this.Controls.Add(this.tb_temperature);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_add_suivi_hospitalisation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Passer un suivi d\'hospitalisation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyRoundedTextBox tb_temperature;
        private MyRoundedTextBox tb_tension;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private MyRoundedTextBox tb_rythme;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rich_text;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbx_etat_mental;
        private System.Windows.Forms.Label label6;
        private test_arrondissement2012.PerfectRoundedButton bt_save_suivi;
    }
}