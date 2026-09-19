namespace Cepima.MesForms.Pharmacie
{
    partial class Form_reception_stock
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
            this.cbx_medicament = new MyRoundedComboBox();
            this.ud_quantite = new RoundedNumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_cancel = new RoundedButton();
            this.bt_save_stock = new RoundedButton();
            this.tb_numero_lot = new MyRoundedTextBox();
            this.dtp_expiration_date = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbx_medicament
            // 
            this.cbx_medicament.ArrowColor = System.Drawing.Color.DimGray;
            this.cbx_medicament.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbx_medicament.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbx_medicament.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbx_medicament.BorderRadius = 8;
            this.cbx_medicament.DropDownBackColor = System.Drawing.Color.White;
            this.cbx_medicament.DropDownForeColor = System.Drawing.Color.Black;
            this.cbx_medicament.DropDownSelectedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.cbx_medicament.DropDownSelectedForeColor = System.Drawing.Color.White;
            this.cbx_medicament.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_medicament.DropDownWidth = 250;
            this.cbx_medicament.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.cbx_medicament.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_medicament.Location = new System.Drawing.Point(211, 124);
            this.cbx_medicament.MinimumSize = new System.Drawing.Size(80, 36);
            this.cbx_medicament.Name = "cbx_medicament";
            this.cbx_medicament.SelectedItem = null;
            this.cbx_medicament.SelectedValue = null;
            this.cbx_medicament.Size = new System.Drawing.Size(270, 42);
            this.cbx_medicament.TabIndex = 34;
            // 
            // ud_quantite
            // 
            this.ud_quantite.BackColor = System.Drawing.Color.White;
            this.ud_quantite.BorderColor = System.Drawing.Color.LightGray;
            this.ud_quantite.BorderRadius = 8;
            this.ud_quantite.BorderSize = 2;
            this.ud_quantite.ButtonBackColor = System.Drawing.Color.White;
            this.ud_quantite.ButtonFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ud_quantite.ButtonForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ud_quantite.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ud_quantite.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.ud_quantite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_quantite.ForeColor = System.Drawing.Color.Black;
            this.ud_quantite.Location = new System.Drawing.Point(211, 216);
            this.ud_quantite.MinimumSize = new System.Drawing.Size(74, 36);
            this.ud_quantite.Name = "ud_quantite";
            this.ud_quantite.Size = new System.Drawing.Size(270, 37);
            this.ud_quantite.TabIndex = 33;
            this.ud_quantite.TextPadding = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Quantité:";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(135, 42);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(237, 24);
            this.title.TabIndex = 29;
            this.title.Text = "RECEPTION DE STOCK";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(86, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Numéro de lot : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Médicament: ";
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
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_cancel.Image = global::Cepima.Properties.Resources.cancel_30px;
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancel.Location = new System.Drawing.Point(116, 481);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(150, 45);
            this.btn_cancel.TabIndex = 32;
            this.btn_cancel.Text = "Annuler";
            this.btn_cancel.TextColor = System.Drawing.Color.White;
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // bt_save_stock
            // 
            this.bt_save_stock.BackColor = System.Drawing.Color.Transparent;
            this.bt_save_stock.BorderColor = System.Drawing.Color.White;
            this.bt_save_stock.BorderRadius = 10;
            this.bt_save_stock.BorderSize = 0;
            this.bt_save_stock.ButtonText = "Enregistrer";
            this.bt_save_stock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_save_stock.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_save_stock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_save_stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save_stock.ForeColor = System.Drawing.Color.White;
            this.bt_save_stock.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_save_stock.Image = global::Cepima.Properties.Resources.save_30px;
            this.bt_save_stock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_save_stock.Location = new System.Drawing.Point(299, 481);
            this.bt_save_stock.Name = "bt_save_stock";
            this.bt_save_stock.Size = new System.Drawing.Size(164, 45);
            this.bt_save_stock.TabIndex = 31;
            this.bt_save_stock.Text = "Enregistrer";
            this.bt_save_stock.TextColor = System.Drawing.Color.White;
            this.bt_save_stock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_save_stock.UseVisualStyleBackColor = false;
            this.bt_save_stock.Click += new System.EventHandler(this.bt_save_stock_Click);
            // 
            // tb_numero_lot
            // 
            this.tb_numero_lot.BackColor = System.Drawing.Color.White;
            this.tb_numero_lot.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_numero_lot.BorderRadius = 8;
            this.tb_numero_lot.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_numero_lot.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_numero_lot.ForeColor = System.Drawing.Color.Black;
            this.tb_numero_lot.Image = null;
            this.tb_numero_lot.Location = new System.Drawing.Point(211, 303);
            this.tb_numero_lot.MaxLength = 32767;
            this.tb_numero_lot.Name = "tb_numero_lot";
            this.tb_numero_lot.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_numero_lot.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_numero_lot.PlaceholderText = "";
            this.tb_numero_lot.Size = new System.Drawing.Size(270, 37);
            this.tb_numero_lot.TabIndex = 36;
            // 
            // dtp_expiration_date
            // 
            this.dtp_expiration_date.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_expiration_date.Location = new System.Drawing.Point(220, 390);
            this.dtp_expiration_date.Name = "dtp_expiration_date";
            this.dtp_expiration_date.Size = new System.Drawing.Size(250, 20);
            this.dtp_expiration_date.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 393);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "Date d\'expiration: ";
            // 
            // Form_reception_stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(565, 558);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtp_expiration_date);
            this.Controls.Add(this.tb_numero_lot);
            this.Controls.Add(this.cbx_medicament);
            this.Controls.Add(this.ud_quantite);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.bt_save_stock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "Form_reception_stock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "m ";
            this.Load += new System.EventHandler(this.Form_reception_stock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyRoundedComboBox cbx_medicament;
        private RoundedNumericUpDown ud_quantite;
        private RoundedButton btn_cancel;
        private RoundedButton bt_save_stock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private MyRoundedTextBox tb_numero_lot;
        private System.Windows.Forms.DateTimePicker dtp_expiration_date;
        private System.Windows.Forms.Label label3;
    }
}