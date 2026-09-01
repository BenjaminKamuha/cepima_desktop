namespace Cepima.MesForms
{
    partial class Form_detail_produit
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
            this.bunifuRoundedPanel1 = new BunifuRoundedPanel();
            this.main_pan = new System.Windows.Forms.Panel();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.btn_refresh = new RoundedButton();
            this.btn_history = new RoundedButton();
            this.btn_delete = new RoundedButton();
            this.btn_edit = new RoundedButton();
            this.btn_stock_plus = new RoundedButton();
            this.item_medoc = new ModernListItem();
            this.bunifuRoundedPanel1.SuspendLayout();
            this.pnl_header.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.DarkBlue;
            this.bunifuRoundedPanel1.BorderRadius = 8;
            this.bunifuRoundedPanel1.BorderSize = 0;
            this.bunifuRoundedPanel1.Controls.Add(this.main_pan);
            this.bunifuRoundedPanel1.Controls.Add(this.pnl_header);
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(8, 7);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 10;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(980, 539);
            this.bunifuRoundedPanel1.TabIndex = 0;
            // 
            // main_pan
            // 
            this.main_pan.Location = new System.Drawing.Point(4, 81);
            this.main_pan.Name = "main_pan";
            this.main_pan.Size = new System.Drawing.Size(973, 455);
            this.main_pan.TabIndex = 1;
            // 
            // pnl_header
            // 
            this.pnl_header.Controls.Add(this.item_medoc);
            this.pnl_header.Controls.Add(this.btn_refresh);
            this.pnl_header.Controls.Add(this.btn_history);
            this.pnl_header.Controls.Add(this.btn_delete);
            this.pnl_header.Controls.Add(this.btn_edit);
            this.pnl_header.Controls.Add(this.btn_stock_plus);
            this.pnl_header.Location = new System.Drawing.Point(4, 5);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(973, 73);
            this.pnl_header.TabIndex = 0;
            // 
            // btn_refresh
            // 
            this.btn_refresh.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_refresh.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_refresh.BorderRadius = 8;
            this.btn_refresh.BorderSize = 0;
            this.btn_refresh.ButtonText = "";
            this.btn_refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_refresh.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_refresh.FlatAppearance.BorderSize = 0;
            this.btn_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refresh.ForeColor = System.Drawing.Color.White;
            this.btn_refresh.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_refresh.Image = global::Cepima.Properties.Resources.refresh_25px1;
            this.btn_refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_refresh.Location = new System.Drawing.Point(191, 22);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(58, 34);
            this.btn_refresh.TabIndex = 8;
            this.btn_refresh.TextColor = System.Drawing.Color.White;
            this.btn_refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_refresh.UseVisualStyleBackColor = false;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_history
            // 
            this.btn_history.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_history.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_history.BorderRadius = 8;
            this.btn_history.BorderSize = 0;
            this.btn_history.ButtonText = "Historique";
            this.btn_history.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_history.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_history.FlatAppearance.BorderSize = 0;
            this.btn_history.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_history.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_history.ForeColor = System.Drawing.Color.White;
            this.btn_history.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_history.Image = global::Cepima.Properties.Resources.Clock_25px;
            this.btn_history.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_history.Location = new System.Drawing.Point(478, 22);
            this.btn_history.Name = "btn_history";
            this.btn_history.Size = new System.Drawing.Size(151, 34);
            this.btn_history.TabIndex = 6;
            this.btn_history.Text = "Historique";
            this.btn_history.TextColor = System.Drawing.Color.White;
            this.btn_history.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_history.UseVisualStyleBackColor = false;
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_delete.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_delete.BorderRadius = 8;
            this.btn_delete.BorderSize = 0;
            this.btn_delete.ButtonText = "Supprimer";
            this.btn_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delete.DefaultBackColor = System.Drawing.Color.Crimson;
            this.btn_delete.FlatAppearance.BorderSize = 0;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.White;
            this.btn_delete.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_delete.Image = global::Cepima.Properties.Resources.trash_25px;
            this.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_delete.Location = new System.Drawing.Point(824, 22);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(140, 34);
            this.btn_delete.TabIndex = 5;
            this.btn_delete.Text = "Supprimer";
            this.btn_delete.TextColor = System.Drawing.Color.White;
            this.btn_delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_delete.UseVisualStyleBackColor = false;
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_edit.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_edit.BorderRadius = 8;
            this.btn_edit.BorderSize = 0;
            this.btn_edit.ButtonText = "Modifier";
            this.btn_edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_edit.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_edit.FlatAppearance.BorderSize = 0;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.ForeColor = System.Drawing.Color.White;
            this.btn_edit.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_edit.Image = global::Cepima.Properties.Resources.edit_property_25px;
            this.btn_edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_edit.Location = new System.Drawing.Point(654, 22);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(145, 34);
            this.btn_edit.TabIndex = 4;
            this.btn_edit.Text = "Modifier";
            this.btn_edit.TextColor = System.Drawing.Color.White;
            this.btn_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_edit.UseVisualStyleBackColor = false;
            // 
            // btn_stock_plus
            // 
            this.btn_stock_plus.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_stock_plus.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_stock_plus.BorderRadius = 8;
            this.btn_stock_plus.BorderSize = 0;
            this.btn_stock_plus.ButtonText = "Réception stock";
            this.btn_stock_plus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_stock_plus.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_stock_plus.FlatAppearance.BorderSize = 0;
            this.btn_stock_plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stock_plus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stock_plus.ForeColor = System.Drawing.Color.White;
            this.btn_stock_plus.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_stock_plus.Image = global::Cepima.Properties.Resources.add_25px1;
            this.btn_stock_plus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_stock_plus.Location = new System.Drawing.Point(274, 22);
            this.btn_stock_plus.Name = "btn_stock_plus";
            this.btn_stock_plus.Size = new System.Drawing.Size(179, 34);
            this.btn_stock_plus.TabIndex = 3;
            this.btn_stock_plus.Text = "Réception stock";
            this.btn_stock_plus.TextColor = System.Drawing.Color.White;
            this.btn_stock_plus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_stock_plus.UseVisualStyleBackColor = false;
            this.btn_stock_plus.Click += new System.EventHandler(this.btn_stock_plus_Click);
            // 
            // item_medoc
            // 
            this.item_medoc.BackColor = System.Drawing.Color.Transparent;
            this.item_medoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.item_medoc.IndicatorColor = System.Drawing.Color.LightBlue;
            this.item_medoc.IndicatorShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.item_medoc.Location = new System.Drawing.Point(3, 6);
            this.item_medoc.Name = "item_medoc";
            this.item_medoc.Size = new System.Drawing.Size(160, 60);
            this.item_medoc.SubtitleColor = System.Drawing.Color.Gray;
            this.item_medoc.SubtitleFont = new System.Drawing.Font("Segoe UI", 7F);
            this.item_medoc.TabIndex = 9;
            this.item_medoc.TitleColor = System.Drawing.Color.Black;
            this.item_medoc.TitleFont = new System.Drawing.Font("Segoe UI", 9F);
            // 
            // Form_detail_produit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 558);
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Name = "Form_detail_produit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_detail_produit";
            this.Load += new System.EventHandler(this.Form_detail_produit_Load);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.pnl_header.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.Panel pnl_header;
        private RoundedButton btn_delete;
        private RoundedButton btn_edit;
        private RoundedButton btn_stock_plus;
        private System.Windows.Forms.Panel main_pan;
        private RoundedButton btn_history;
        private RoundedButton btn_refresh;
        private ModernListItem item_medoc;

    }
}