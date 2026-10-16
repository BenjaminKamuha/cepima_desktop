namespace Cepima.MesUserCases.Users
{
    partial class Utilisateurs_user
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuRoundedPanel1 = new BunifuRoundedPanel();
            this.bt_add_role = new RoundedButton();
            this.bt_add_user = new RoundedButton();
            this.tb_search_user = new MyRoundedTextBox();
            this.dgv_utilisateurs = new ModernDataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bunifuRoundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_utilisateurs)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.Empty;
            this.bunifuRoundedPanel1.BorderRadius = 8;
            this.bunifuRoundedPanel1.BorderSize = 0;
            this.bunifuRoundedPanel1.Controls.Add(this.bt_add_role);
            this.bunifuRoundedPanel1.Controls.Add(this.bt_add_user);
            this.bunifuRoundedPanel1.Controls.Add(this.tb_search_user);
            this.bunifuRoundedPanel1.Controls.Add(this.dgv_utilisateurs);
            this.bunifuRoundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 8;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(1001, 506);
            this.bunifuRoundedPanel1.TabIndex = 0;
            // 
            // bt_add_role
            // 
            this.bt_add_role.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_add_role.BackColor = System.Drawing.Color.Transparent;
            this.bt_add_role.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_add_role.BorderRadius = 10;
            this.bt_add_role.ButtonText = "Ajouter un rôle";
            this.bt_add_role.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_add_role.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_add_role.FlatAppearance.BorderSize = 0;
            this.bt_add_role.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_add_role.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_add_role.ForeColor = System.Drawing.Color.White;
            this.bt_add_role.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_add_role.Image = global::Cepima.Properties.Resources.add_25px1;
            this.bt_add_role.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_add_role.Location = new System.Drawing.Point(547, 9);
            this.bt_add_role.Name = "bt_add_role";
            this.bt_add_role.Size = new System.Drawing.Size(185, 42);
            this.bt_add_role.TabIndex = 2;
            this.bt_add_role.Text = "Ajouter un rôle";
            this.bt_add_role.TextColor = System.Drawing.Color.White;
            this.bt_add_role.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_add_role.UseVisualStyleBackColor = false;
            this.bt_add_role.Click += new System.EventHandler(this.bt_add_role_Click);
            // 
            // bt_add_user
            // 
            this.bt_add_user.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_add_user.BackColor = System.Drawing.Color.Transparent;
            this.bt_add_user.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_add_user.BorderRadius = 10;
            this.bt_add_user.ButtonText = "Ajouter compte";
            this.bt_add_user.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_add_user.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.bt_add_user.FlatAppearance.BorderSize = 0;
            this.bt_add_user.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_add_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_add_user.ForeColor = System.Drawing.Color.White;
            this.bt_add_user.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.bt_add_user.Image = global::Cepima.Properties.Resources.add_25px1;
            this.bt_add_user.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_add_user.Location = new System.Drawing.Point(815, 9);
            this.bt_add_user.Name = "bt_add_user";
            this.bt_add_user.Size = new System.Drawing.Size(170, 42);
            this.bt_add_user.TabIndex = 2;
            this.bt_add_user.Text = "Ajouter compte";
            this.bt_add_user.TextColor = System.Drawing.Color.White;
            this.bt_add_user.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_add_user.UseVisualStyleBackColor = false;
            this.bt_add_user.Click += new System.EventHandler(this.bt_add_user_Click);
            // 
            // tb_search_user
            // 
            this.tb_search_user.BackColor = System.Drawing.Color.White;
            this.tb_search_user.BorderColor = System.Drawing.Color.Silver;
            this.tb_search_user.BorderRadius = 10;
            this.tb_search_user.BorderSize = 1;
            this.tb_search_user.FocusBorderColor = System.Drawing.Color.Silver;
            this.tb_search_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search_user.ForeColor = System.Drawing.Color.Black;
            this.tb_search_user.Image = global::Cepima.Properties.Resources.search;
            this.tb_search_user.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tb_search_user.Location = new System.Drawing.Point(19, 14);
            this.tb_search_user.MaxLength = 32767;
            this.tb_search_user.Name = "tb_search_user";
            this.tb_search_user.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tb_search_user.PlaceholderColor = System.Drawing.Color.Gray;
            this.tb_search_user.PlaceholderText = "Search user";
            this.tb_search_user.Size = new System.Drawing.Size(250, 35);
            this.tb_search_user.TabIndex = 1;
            this.tb_search_user.TextChanged += new System.EventHandler(this.tb_search_user_TextChanged);
            // 
            // dgv_utilisateurs
            // 
            this.dgv_utilisateurs.AllowUserToAddRows = false;
            this.dgv_utilisateurs.AllowUserToDeleteRows = false;
            this.dgv_utilisateurs.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dgv_utilisateurs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_utilisateurs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_utilisateurs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_utilisateurs.BackgroundColor = System.Drawing.Color.White;
            this.dgv_utilisateurs.BorderRadius = 1;
            this.dgv_utilisateurs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_utilisateurs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_utilisateurs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_utilisateurs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_utilisateurs.ColumnHeadersHeight = 35;
            this.dgv_utilisateurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_utilisateurs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colUser,
            this.colRole,
            this.colDate,
            this.colUpdate});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_utilisateurs.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_utilisateurs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgv_utilisateurs.EnableHeadersVisualStyles = false;
            this.dgv_utilisateurs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.dgv_utilisateurs.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dgv_utilisateurs.HeaderForeColor = System.Drawing.Color.White;
            this.dgv_utilisateurs.HeaderHeight = 35;
            this.dgv_utilisateurs.Location = new System.Drawing.Point(19, 57);
            this.dgv_utilisateurs.MultiSelect = false;
            this.dgv_utilisateurs.Name = "dgv_utilisateurs";
            this.dgv_utilisateurs.OuterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.dgv_utilisateurs.ReadOnly = true;
            this.dgv_utilisateurs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_utilisateurs.RowHeadersVisible = false;
            this.dgv_utilisateurs.RowHeadersWidth = 35;
            this.dgv_utilisateurs.RowHeight = 35;
            this.dgv_utilisateurs.RowTemplate.Height = 35;
            this.dgv_utilisateurs.RowTemplate.ReadOnly = true;
            this.dgv_utilisateurs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_utilisateurs.Size = new System.Drawing.Size(966, 433);
            this.dgv_utilisateurs.TabIndex = 0;
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colID.HeaderText = "N°";
            this.colID.MinimumWidth = 50;
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // colUser
            // 
            this.colUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUser.HeaderText = "Utilisateur";
            this.colUser.MinimumWidth = 50;
            this.colUser.Name = "colUser";
            this.colUser.ReadOnly = true;
            // 
            // colRole
            // 
            this.colRole.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRole.HeaderText = "Rôle utilisateur";
            this.colRole.MinimumWidth = 50;
            this.colRole.Name = "colRole";
            this.colRole.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDate.HeaderText = "Date";
            this.colDate.MinimumWidth = 50;
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colUpdate
            // 
            this.colUpdate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.colUpdate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colUpdate.HeaderText = "";
            this.colUpdate.MinimumWidth = 50;
            this.colUpdate.Name = "colUpdate";
            this.colUpdate.ReadOnly = true;
            this.colUpdate.Text = "Modifier";
            // 
            // Utilisateurs_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Name = "Utilisateurs_user";
            this.Size = new System.Drawing.Size(1001, 506);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_utilisateurs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BunifuRoundedPanel bunifuRoundedPanel1;
        private ModernDataGridView dgv_utilisateurs;
        private MyRoundedTextBox tb_search_user;
        private RoundedButton bt_add_role;
        private RoundedButton bt_add_user;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewButtonColumn colUpdate;

    }
}
