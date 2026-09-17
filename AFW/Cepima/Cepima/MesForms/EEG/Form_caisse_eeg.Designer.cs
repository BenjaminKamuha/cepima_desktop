namespace Cepima.MesForms.EEG
{
    partial class Form_caisse_eeg
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
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_confirmer = new RoundedButton();
            this.tb_montant = new MyRoundedTextBox();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(40, 126);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(67, 17);
            this.label.TabIndex = 29;
            this.label.Text = "Montant: ";
            // 
            // dtp_date
            // 
            this.dtp_date.Location = new System.Drawing.Point(113, 78);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(187, 20);
            this.dtp_date.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "Date: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // bt_confirmer
            // 
            this.bt_confirmer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_confirmer.BackColor = System.Drawing.Color.Transparent;
            this.bt_confirmer.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_confirmer.BorderRadius = 8;
            this.bt_confirmer.ButtonText = "Confirmer";
            this.bt_confirmer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_confirmer.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_confirmer.FlatAppearance.BorderSize = 0;
            this.bt_confirmer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_confirmer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_confirmer.ForeColor = System.Drawing.Color.White;
            this.bt_confirmer.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_confirmer.Image = global::Cepima.Properties.Resources.ok_30px1;
            this.bt_confirmer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_confirmer.Location = new System.Drawing.Point(92, 246);
            this.bt_confirmer.Name = "bt_confirmer";
            this.bt_confirmer.Size = new System.Drawing.Size(157, 35);
            this.bt_confirmer.TabIndex = 35;
            this.bt_confirmer.Text = "Confirmer";
            this.bt_confirmer.TextColor = System.Drawing.Color.White;
            this.bt_confirmer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_confirmer.UseVisualStyleBackColor = false;
            this.bt_confirmer.Click += new System.EventHandler(this.bt_confirmer_Click);
            // 
            // tb_montant
            // 
            this.tb_montant.BackColor = System.Drawing.Color.White;
            this.tb_montant.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_montant.BorderRadius = 8;
            this.tb_montant.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_montant.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_montant.ForeColor = System.Drawing.Color.Black;
            this.tb_montant.Image = null;
            this.tb_montant.Location = new System.Drawing.Point(113, 119);
            this.tb_montant.MaxLength = 32767;
            this.tb_montant.Name = "tb_montant";
            this.tb_montant.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_montant.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_montant.PlaceholderText = "";
            this.tb_montant.Size = new System.Drawing.Size(187, 37);
            this.tb_montant.TabIndex = 30;
            // 
            // Form_caisse_eeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(347, 331);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_date);
            this.Controls.Add(this.bt_confirmer);
            this.Controls.Add(this.tb_montant);
            this.Controls.Add(this.label);
            this.Name = "Form_caisse_eeg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_caisse_eeg";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyRoundedTextBox tb_montant;
        private System.Windows.Forms.Label label;
        private RoundedButton bt_confirmer;
        private System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.Label label1;
    }
}