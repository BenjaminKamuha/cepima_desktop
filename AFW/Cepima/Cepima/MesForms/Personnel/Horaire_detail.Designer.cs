namespace Cepima.MesForms.Personnel
{
    partial class Horaire_detail
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
            this.dgv_horaires = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeureEntree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeureSortie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIDHoraire = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModifier = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colSupprimer = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_horaires)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_horaires
            // 
            this.dgv_horaires.AllowUserToAddRows = false;
            this.dgv_horaires.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_horaires.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_horaires.BackgroundColor = System.Drawing.Color.White;
            this.dgv_horaires.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_horaires.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_horaires.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_horaires.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_horaires.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colJour,
            this.colHeureEntree,
            this.colHeureSortie,
            this.colIDHoraire,
            this.colModifier,
            this.colSupprimer});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_horaires.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_horaires.EnableHeadersVisualStyles = false;
            this.dgv_horaires.Location = new System.Drawing.Point(2, 3);
            this.dgv_horaires.Name = "dgv_horaires";
            this.dgv_horaires.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_horaires.RowHeadersVisible = false;
            this.dgv_horaires.Size = new System.Drawing.Size(699, 315);
            this.dgv_horaires.TabIndex = 8;
            this.dgv_horaires.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_horaires_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Jours";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 139;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Heure d\'entré";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 140;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Heure de sortié";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 139;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // colJour
            // 
            this.colJour.HeaderText = "Jours";
            this.colJour.Name = "colJour";
            // 
            // colHeureEntree
            // 
            this.colHeureEntree.HeaderText = "Heure d\'entré";
            this.colHeureEntree.Name = "colHeureEntree";
            // 
            // colHeureSortie
            // 
            this.colHeureSortie.HeaderText = "Heure de sortié";
            this.colHeureSortie.Name = "colHeureSortie";
            // 
            // colIDHoraire
            // 
            this.colIDHoraire.HeaderText = "";
            this.colIDHoraire.Name = "colIDHoraire";
            this.colIDHoraire.Visible = false;
            // 
            // colModifier
            // 
            this.colModifier.HeaderText = "";
            this.colModifier.Name = "colModifier";
            this.colModifier.Text = "Modifier";
            this.colModifier.UseColumnTextForButtonValue = true;
            // 
            // colSupprimer
            // 
            this.colSupprimer.HeaderText = "";
            this.colSupprimer.Name = "colSupprimer";
            this.colSupprimer.Text = "Supprimer";
            this.colSupprimer.UseColumnTextForButtonValue = true;
            // 
            // Horaire_detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(706, 322);
            this.Controls.Add(this.dgv_horaires);
            this.Name = "Horaire_detail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Horaire_detail";
            this.Load += new System.EventHandler(this.Horaire_detail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_horaires)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_horaires;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJour;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeureEntree;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeureSortie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIDHoraire;
        private System.Windows.Forms.DataGridViewButtonColumn colModifier;
        private System.Windows.Forms.DataGridViewButtonColumn colSupprimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

    }
}