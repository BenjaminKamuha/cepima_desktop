namespace Cepima.MesUserCases
{
    partial class User_horaires
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
            this.customRoundedPanel1 = new CustomRoundedPanel();
            this.dt_heure_sortie = new System.Windows.Forms.DateTimePicker();
            this.dt_heure_arrivee = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_save_horaire = new test_arrondissement2012.PerfectRoundedButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.combo_day = new System.Windows.Forms.ComboBox();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.list_box_personnel = new System.Windows.Forms.CheckedListBox();
            this.customRoundedPanel3 = new CustomRoundedPanel();
            this.dgv_horaire = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.customRoundedPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.customRoundedPanel2.SuspendLayout();
            this.customRoundedPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_horaire)).BeginInit();
            this.SuspendLayout();
            // 
            // customRoundedPanel1
            // 
            this.customRoundedPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customRoundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel1.BorderRadius = 10;
            this.customRoundedPanel1.BorderSize = 2;
            this.customRoundedPanel1.Controls.Add(this.dt_heure_sortie);
            this.customRoundedPanel1.Controls.Add(this.dt_heure_arrivee);
            this.customRoundedPanel1.Controls.Add(this.panel1);
            this.customRoundedPanel1.Controls.Add(this.bt_save_horaire);
            this.customRoundedPanel1.Controls.Add(this.label3);
            this.customRoundedPanel1.Controls.Add(this.label2);
            this.customRoundedPanel1.Controls.Add(this.label6);
            this.customRoundedPanel1.Controls.Add(this.label1);
            this.customRoundedPanel1.Controls.Add(this.combo_day);
            this.customRoundedPanel1.Controls.Add(this.customRoundedPanel2);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel1.Location = new System.Drawing.Point(3, 3);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Size = new System.Drawing.Size(770, 217);
            this.customRoundedPanel1.TabIndex = 2;
            // 
            // dt_heure_sortie
            // 
            this.dt_heure_sortie.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_heure_sortie.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dt_heure_sortie.Location = new System.Drawing.Point(330, 67);
            this.dt_heure_sortie.Name = "dt_heure_sortie";
            this.dt_heure_sortie.Size = new System.Drawing.Size(174, 22);
            this.dt_heure_sortie.TabIndex = 6;
            // 
            // dt_heure_arrivee
            // 
            this.dt_heure_arrivee.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_heure_arrivee.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dt_heure_arrivee.Location = new System.Drawing.Point(330, 14);
            this.dt_heure_arrivee.Name = "dt_heure_arrivee";
            this.dt_heure_arrivee.Size = new System.Drawing.Size(174, 22);
            this.dt_heure_arrivee.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(3, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 188);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.calendar_minus_90px;
            this.pictureBox1.Location = new System.Drawing.Point(19, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 126);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(60, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ajouter un horaire";
            // 
            // bt_save_horaire
            // 
            this.bt_save_horaire.BackColor = System.Drawing.Color.Transparent;
            this.bt_save_horaire.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_save_horaire.BorderRadius = 5;
            this.bt_save_horaire.BorderSize = 0;
            this.bt_save_horaire.ButtonText = "Enregistrer un horaire";
            this.bt_save_horaire.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.bt_save_horaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save_horaire.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_save_horaire.Location = new System.Drawing.Point(319, 159);
            this.bt_save_horaire.Name = "bt_save_horaire";
            this.bt_save_horaire.Size = new System.Drawing.Size(185, 30);
            this.bt_save_horaire.TabIndex = 4;
            this.bt_save_horaire.Click += new System.EventHandler(this.bt_save_horaire_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(233, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Heure Finale : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(233, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Jours  : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(538, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Liste du personnel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(233, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Heure Début :  ";
            // 
            // combo_day
            // 
            this.combo_day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_day.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_day.FormattingEnabled = true;
            this.combo_day.Location = new System.Drawing.Point(330, 115);
            this.combo_day.Name = "combo_day";
            this.combo_day.Size = new System.Drawing.Size(174, 22);
            this.combo_day.TabIndex = 1;
            // 
            // customRoundedPanel2
            // 
            this.customRoundedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customRoundedPanel2.BorderRadius = 8;
            this.customRoundedPanel2.BorderSize = 0;
            this.customRoundedPanel2.Controls.Add(this.list_box_personnel);
            this.customRoundedPanel2.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel2.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel2.Location = new System.Drawing.Point(531, 23);
            this.customRoundedPanel2.Name = "customRoundedPanel2";
            this.customRoundedPanel2.Size = new System.Drawing.Size(233, 174);
            this.customRoundedPanel2.TabIndex = 0;
            // 
            // list_box_personnel
            // 
            this.list_box_personnel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.list_box_personnel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_box_personnel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_box_personnel.FormattingEnabled = true;
            this.list_box_personnel.Location = new System.Drawing.Point(3, 4);
            this.list_box_personnel.Name = "list_box_personnel";
            this.list_box_personnel.Size = new System.Drawing.Size(227, 162);
            this.list_box_personnel.TabIndex = 1;
            // 
            // customRoundedPanel3
            // 
            this.customRoundedPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.customRoundedPanel3.BorderRadius = 10;
            this.customRoundedPanel3.BorderSize = 2;
            this.customRoundedPanel3.Controls.Add(this.dgv_horaire);
            this.customRoundedPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.customRoundedPanel3.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel3.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel3.Location = new System.Drawing.Point(0, 250);
            this.customRoundedPanel3.Name = "customRoundedPanel3";
            this.customRoundedPanel3.Size = new System.Drawing.Size(786, 174);
            this.customRoundedPanel3.TabIndex = 3;
            // 
            // dgv_horaire
            // 
            this.dgv_horaire.AllowUserToAddRows = false;
            this.dgv_horaire.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_horaire.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_horaire.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.dgv_horaire.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_horaire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_horaire.Location = new System.Drawing.Point(6, 12);
            this.dgv_horaire.Name = "dgv_horaire";
            this.dgv_horaire.RowHeadersVisible = false;
            this.dgv_horaire.Size = new System.Drawing.Size(777, 159);
            this.dgv_horaire.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(15, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Horaire";
            // 
            // User_horaires
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.label5);
            this.Controls.Add(this.customRoundedPanel3);
            this.Controls.Add(this.customRoundedPanel1);
            this.Name = "User_horaires";
            this.Size = new System.Drawing.Size(786, 424);
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.customRoundedPanel2.ResumeLayout(false);
            this.customRoundedPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_horaire)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomRoundedPanel customRoundedPanel1;
        private System.Windows.Forms.DateTimePicker dt_heure_sortie;
        private System.Windows.Forms.DateTimePicker dt_heure_arrivee;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private test_arrondissement2012.PerfectRoundedButton bt_save_horaire;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_day;
        private CustomRoundedPanel customRoundedPanel2;
        private System.Windows.Forms.CheckedListBox list_box_personnel;
        private CustomRoundedPanel customRoundedPanel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_horaire;
    }
}
