namespace Cepima.MesForms.Personnel
{
    partial class Detail_presence
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label6 = new System.Windows.Forms.Label();
            this.bunifuRoundedPanel1 = new BunifuRoundedPanel();
            this.dgv_presences = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSortie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuRoundedPanel2 = new BunifuRoundedPanel();
            this.lb_age = new System.Windows.Forms.Label();
            this.lb_post_nom = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_nom = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuRoundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_presences)).BeginInit();
            this.bunifuRoundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(225, 23);
            this.label6.TabIndex = 43;
            this.label6.Text = "HISTORIQUE DE PRESENCES";
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.DarkBlue;
            this.bunifuRoundedPanel1.BorderRadius = 8;
            this.bunifuRoundedPanel1.BorderSize = 0;
            this.bunifuRoundedPanel1.Controls.Add(this.dgv_presences);
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(0, 162);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 10;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(874, 358);
            this.bunifuRoundedPanel1.TabIndex = 41;
            // 
            // dgv_presences
            // 
            this.dgv_presences.AllowUserToAddRows = false;
            this.dgv_presences.AllowUserToDeleteRows = false;
            this.dgv_presences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_presences.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_presences.BackgroundColor = System.Drawing.Color.White;
            this.dgv_presences.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_presences.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_presences.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgv_presences.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_presences.ColumnHeadersHeight = 30;
            this.dgv_presences.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colEntree,
            this.colSortie,
            this.colStatut});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_presences.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_presences.EnableHeadersVisualStyles = false;
            this.dgv_presences.Location = new System.Drawing.Point(7, 11);
            this.dgv_presences.Name = "dgv_presences";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_presences.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_presences.RowHeadersVisible = false;
            this.dgv_presences.RowTemplate.Height = 35;
            this.dgv_presences.Size = new System.Drawing.Size(859, 335);
            this.dgv_presences.TabIndex = 0;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            // 
            // colEntree
            // 
            this.colEntree.HeaderText = "Heure d\'entrée";
            this.colEntree.Name = "colEntree";
            // 
            // colSortie
            // 
            this.colSortie.HeaderText = "Heure de sortie";
            this.colSortie.Name = "colSortie";
            // 
            // colStatut
            // 
            this.colStatut.HeaderText = "Statut";
            this.colStatut.Name = "colStatut";
            // 
            // bunifuRoundedPanel2
            // 
            this.bunifuRoundedPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuRoundedPanel2.BorderColor = System.Drawing.Color.DarkBlue;
            this.bunifuRoundedPanel2.BorderRadius = 8;
            this.bunifuRoundedPanel2.BorderSize = 0;
            this.bunifuRoundedPanel2.Controls.Add(this.lb_age);
            this.bunifuRoundedPanel2.Controls.Add(this.lb_post_nom);
            this.bunifuRoundedPanel2.Controls.Add(this.label3);
            this.bunifuRoundedPanel2.Controls.Add(this.lb_nom);
            this.bunifuRoundedPanel2.Controls.Add(this.label2);
            this.bunifuRoundedPanel2.Controls.Add(this.label1);
            this.bunifuRoundedPanel2.Controls.Add(this.pictureBox1);
            this.bunifuRoundedPanel2.Location = new System.Drawing.Point(0, 6);
            this.bunifuRoundedPanel2.Name = "bunifuRoundedPanel2";
            this.bunifuRoundedPanel2.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel2.ShadowDepth = 10;
            this.bunifuRoundedPanel2.Size = new System.Drawing.Size(874, 127);
            this.bunifuRoundedPanel2.TabIndex = 42;
            // 
            // lb_age
            // 
            this.lb_age.AutoSize = true;
            this.lb_age.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_age.Location = new System.Drawing.Point(275, 87);
            this.lb_age.Name = "lb_age";
            this.lb_age.Size = new System.Drawing.Size(121, 23);
            this.lb_age.TabIndex = 1;
            this.lb_age.Text = "34 ans - Home";
            // 
            // lb_post_nom
            // 
            this.lb_post_nom.AutoSize = true;
            this.lb_post_nom.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_post_nom.Location = new System.Drawing.Point(275, 55);
            this.lb_post_nom.Name = "lb_post_nom";
            this.lb_post_nom.Size = new System.Drawing.Size(48, 23);
            this.lb_post_nom.TabIndex = 1;
            this.lb_post_nom.Text = "Jean ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(156, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Age  : ";
            // 
            // lb_nom
            // 
            this.lb_nom.AutoSize = true;
            this.lb_nom.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nom.Location = new System.Drawing.Point(275, 20);
            this.lb_nom.Name = "lb_nom";
            this.lb_nom.Size = new System.Drawing.Size(43, 23);
            this.lb_nom.TabIndex = 1;
            this.lb_nom.Text = "Paul";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(156, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "PostNom : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(156, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nom : ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(17, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Detail_presence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(874, 523);
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Controls.Add(this.bunifuRoundedPanel2);
            this.Controls.Add(this.label6);
            this.Name = "Detail_presence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detail_presence";
            this.Load += new System.EventHandler(this.Detail_presence_Load);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_presences)).EndInit();
            this.bunifuRoundedPanel2.ResumeLayout(false);
            this.bunifuRoundedPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_age;
        private System.Windows.Forms.Label lb_post_nom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_nom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_presences;
        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BunifuRoundedPanel bunifuRoundedPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntree;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSortie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatut;
    }
}