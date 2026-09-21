namespace Cepima.MesUserCases.Services
{
    partial class User_services
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.dgv_prestation = new System.Windows.Forms.DataGridView();
            this.dgv_services = new System.Windows.Forms.DataGridView();
            this.btn_add_prestation = new RoundedButton();
            this.tb_search_prestation = new MyRoundedTextBox();
            this.btn_add_service = new RoundedButton();
            this.tb_search_service = new MyRoundedTextBox();
            this.customRoundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_prestation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_services)).BeginInit();
            this.SuspendLayout();
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customRoundedPanel1.BackColor = System.Drawing.Color.White;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 5;
            this.customRoundedPanel1.BorderSize = 2;
            this.customRoundedPanel1.Controls.Add(this.dgv_prestation);
            this.customRoundedPanel1.Controls.Add(this.dgv_services);
            this.customRoundedPanel1.Controls.Add(this.btn_add_prestation);
            this.customRoundedPanel1.Controls.Add(this.tb_search_prestation);
            this.customRoundedPanel1.Controls.Add(this.btn_add_service);
            this.customRoundedPanel1.Controls.Add(this.tb_search_service);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel1.Location = new System.Drawing.Point(12, 16);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 14);
            this.customRoundedPanel1.ShadowBlur = 10;
            this.customRoundedPanel1.ShadowBorderRadius = -1;
            this.customRoundedPanel1.ShadowColor = System.Drawing.Color.Black;
            this.customRoundedPanel1.ShadowEnabled = true;
            this.customRoundedPanel1.ShadowOffsetX = 0;
            this.customRoundedPanel1.ShadowOffsetY = 4;
            this.customRoundedPanel1.ShadowOpacity = 60;
            this.customRoundedPanel1.ShadowSpread = 0;
            this.customRoundedPanel1.Size = new System.Drawing.Size(1008, 495);
            this.customRoundedPanel1.TabIndex = 9;
            // 
            // dgv_prestation
            // 
            this.dgv_prestation.AllowUserToAddRows = false;
            this.dgv_prestation.AllowUserToDeleteRows = false;
            this.dgv_prestation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_prestation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_prestation.BackgroundColor = System.Drawing.Color.White;
            this.dgv_prestation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_prestation.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_prestation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_prestation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_prestation.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_prestation.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_prestation.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_prestation.EnableHeadersVisualStyles = false;
            this.dgv_prestation.Location = new System.Drawing.Point(7, 333);
            this.dgv_prestation.Name = "dgv_prestation";
            this.dgv_prestation.ReadOnly = true;
            this.dgv_prestation.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_prestation.RowHeadersVisible = false;
            this.dgv_prestation.RowTemplate.Height = 30;
            this.dgv_prestation.Size = new System.Drawing.Size(995, 156);
            this.dgv_prestation.TabIndex = 9;
            // 
            // dgv_services
            // 
            this.dgv_services.AllowUserToAddRows = false;
            this.dgv_services.AllowUserToDeleteRows = false;
            this.dgv_services.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_services.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_services.BackgroundColor = System.Drawing.Color.White;
            this.dgv_services.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_services.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_services.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_services.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_services.ColumnHeadersHeight = 30;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_services.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_services.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_services.EnableHeadersVisualStyles = false;
            this.dgv_services.Location = new System.Drawing.Point(7, 55);
            this.dgv_services.Name = "dgv_services";
            this.dgv_services.ReadOnly = true;
            this.dgv_services.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_services.RowHeadersVisible = false;
            this.dgv_services.RowTemplate.Height = 30;
            this.dgv_services.Size = new System.Drawing.Size(995, 191);
            this.dgv_services.TabIndex = 1;
            // 
            // btn_add_prestation
            // 
            this.btn_add_prestation.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_add_prestation.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_add_prestation.BorderRadius = 8;
            this.btn_add_prestation.BorderSize = 0;
            this.btn_add_prestation.ButtonText = "Nouvelle prestation";
            this.btn_add_prestation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add_prestation.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_add_prestation.FlatAppearance.BorderSize = 0;
            this.btn_add_prestation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_prestation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_prestation.ForeColor = System.Drawing.Color.White;
            this.btn_add_prestation.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_add_prestation.Image = global::Cepima.Properties.Resources.add_25px1;
            this.btn_add_prestation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_add_prestation.Location = new System.Drawing.Point(805, 277);
            this.btn_add_prestation.Name = "btn_add_prestation";
            this.btn_add_prestation.Size = new System.Drawing.Size(200, 34);
            this.btn_add_prestation.TabIndex = 8;
            this.btn_add_prestation.Text = "Nouvelle prestation";
            this.btn_add_prestation.TextColor = System.Drawing.Color.White;
            this.btn_add_prestation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_add_prestation.UseVisualStyleBackColor = false;
            // 
            // tb_search_prestation
            // 
            this.tb_search_prestation.BackColor = System.Drawing.Color.White;
            this.tb_search_prestation.BorderColor = System.Drawing.Color.Silver;
            this.tb_search_prestation.BorderRadius = 8;
            this.tb_search_prestation.BorderSize = 1;
            this.tb_search_prestation.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_search_prestation.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search_prestation.ForeColor = System.Drawing.Color.Black;
            this.tb_search_prestation.Image = global::Cepima.Properties.Resources.search_25px;
            this.tb_search_prestation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_search_prestation.ImagePadding = 4;
            this.tb_search_prestation.Location = new System.Drawing.Point(2, 279);
            this.tb_search_prestation.MaxLength = 32767;
            this.tb_search_prestation.Name = "tb_search_prestation";
            this.tb_search_prestation.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_search_prestation.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_search_prestation.PlaceholderText = "Rechercher un service";
            this.tb_search_prestation.Size = new System.Drawing.Size(273, 34);
            this.tb_search_prestation.TabIndex = 7;
            // 
            // btn_add_service
            // 
            this.btn_add_service.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_add_service.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_add_service.BorderRadius = 8;
            this.btn_add_service.BorderSize = 0;
            this.btn_add_service.ButtonText = "Nouveau service";
            this.btn_add_service.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add_service.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_add_service.FlatAppearance.BorderSize = 0;
            this.btn_add_service.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_service.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_service.ForeColor = System.Drawing.Color.White;
            this.btn_add_service.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_add_service.Image = global::Cepima.Properties.Resources.add_25px1;
            this.btn_add_service.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_add_service.Location = new System.Drawing.Point(810, 3);
            this.btn_add_service.Name = "btn_add_service";
            this.btn_add_service.Size = new System.Drawing.Size(193, 34);
            this.btn_add_service.TabIndex = 8;
            this.btn_add_service.Text = "Nouveau service";
            this.btn_add_service.TextColor = System.Drawing.Color.White;
            this.btn_add_service.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_add_service.UseVisualStyleBackColor = false;
            // 
            // tb_search_service
            // 
            this.tb_search_service.BackColor = System.Drawing.Color.White;
            this.tb_search_service.BorderColor = System.Drawing.Color.Silver;
            this.tb_search_service.BorderRadius = 8;
            this.tb_search_service.BorderSize = 1;
            this.tb_search_service.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.tb_search_service.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search_service.ForeColor = System.Drawing.Color.Black;
            this.tb_search_service.Image = global::Cepima.Properties.Resources.search_25px;
            this.tb_search_service.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_search_service.ImagePadding = 4;
            this.tb_search_service.Location = new System.Drawing.Point(3, 5);
            this.tb_search_service.MaxLength = 32767;
            this.tb_search_service.Name = "tb_search_service";
            this.tb_search_service.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_search_service.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_search_service.PlaceholderText = "Rechercher un service";
            this.tb_search_service.Size = new System.Drawing.Size(273, 34);
            this.tb_search_service.TabIndex = 7;
            // 
            // User_services
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.customRoundedPanel1);
            this.Name = "User_services";
            this.Size = new System.Drawing.Size(1031, 526);
            this.customRoundedPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_prestation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_services)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel1;
        private RoundedButton btn_add_service;
        private MyRoundedTextBox tb_search_service;
        private System.Windows.Forms.DataGridView dgv_prestation;
        private System.Windows.Forms.DataGridView dgv_services;
        private RoundedButton btn_add_prestation;
        private MyRoundedTextBox tb_search_prestation;
    }
}
