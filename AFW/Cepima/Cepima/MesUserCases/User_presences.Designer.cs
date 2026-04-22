namespace Cepima.MesUserCases
{
    partial class User_presences
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
            this.bt_save_presence = new test_arrondissement2012.PerfectRoundedButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.combo_statut = new System.Windows.Forms.ComboBox();
            this.customRoundedPanel2 = new CustomRoundedPanel();
            this.list_box_personnel = new System.Windows.Forms.CheckedListBox();
            this.customRoundedPanel3 = new CustomRoundedPanel();
            this.dgv_presence = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.customRoundedPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.customRoundedPanel2.SuspendLayout();
            this.customRoundedPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_presence)).BeginInit();
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
            this.customRoundedPanel1.Controls.Add(this.bt_save_presence);
            this.customRoundedPanel1.Controls.Add(this.label3);
            this.customRoundedPanel1.Controls.Add(this.label2);
            this.customRoundedPanel1.Controls.Add(this.label6);
            this.customRoundedPanel1.Controls.Add(this.label1);
            this.customRoundedPanel1.Controls.Add(this.combo_statut);
            this.customRoundedPanel1.Controls.Add(this.customRoundedPanel2);
            this.customRoundedPanel1.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel1.HoverCursor = System.Windows.Forms.Cursors.Default;
            this.customRoundedPanel1.Location = new System.Drawing.Point(6, 3);
            this.customRoundedPanel1.Name = "customRoundedPanel1";
            this.customRoundedPanel1.Size = new System.Drawing.Size(770, 211);
            this.customRoundedPanel1.TabIndex = 1;
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
            this.pictureBox1.Image = global::Cepima.Properties.Resources.clock_90px;
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
            this.label4.Size = new System.Drawing.Size(136, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ajouter une présence";
            // 
            // bt_save_presence
            // 
            this.bt_save_presence.BackColor = System.Drawing.Color.Transparent;
            this.bt_save_presence.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_save_presence.BorderRadius = 5;
            this.bt_save_presence.BorderSize = 0;
            this.bt_save_presence.ButtonText = "Enregistrer une présence";
            this.bt_save_presence.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(51)))), ((int)(((byte)(131)))));
            this.bt_save_presence.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save_presence.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.bt_save_presence.Location = new System.Drawing.Point(344, 167);
            this.bt_save_presence.Name = "bt_save_presence";
            this.bt_save_presence.Size = new System.Drawing.Size(151, 25);
            this.bt_save_presence.TabIndex = 4;
            this.bt_save_presence.Click += new System.EventHandler(this.bt_save_presence_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(233, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Heure sortie : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(233, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Statut : ";
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
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Heure arrivée: ";
            // 
            // combo_statut
            // 
            this.combo_statut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_statut.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_statut.FormattingEnabled = true;
            this.combo_statut.Location = new System.Drawing.Point(330, 115);
            this.combo_statut.Name = "combo_statut";
            this.combo_statut.Size = new System.Drawing.Size(174, 22);
            this.combo_statut.TabIndex = 1;
            // 
            // customRoundedPanel2
            // 
            this.customRoundedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.customRoundedPanel2.BorderRadius = 8;
            this.customRoundedPanel2.BorderSize = 2;
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
            this.list_box_personnel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_box_personnel.FormattingEnabled = true;
            this.list_box_personnel.Location = new System.Drawing.Point(3, 4);
            this.list_box_personnel.Name = "list_box_personnel";
            this.list_box_personnel.Size = new System.Drawing.Size(227, 153);
            this.list_box_personnel.TabIndex = 1;
            // 
            // customRoundedPanel3
            // 
            this.customRoundedPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(229)))));
            this.customRoundedPanel3.BorderRadius = 10;
            this.customRoundedPanel3.BorderSize = 2;
            this.customRoundedPanel3.Controls.Add(this.dgv_presence);
            this.customRoundedPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.customRoundedPanel3.HoverBackColor = System.Drawing.Color.Empty;
            this.customRoundedPanel3.HoverCursor = System.Windows.Forms.Cursors.Hand;
            this.customRoundedPanel3.Location = new System.Drawing.Point(0, 258);
            this.customRoundedPanel3.Name = "customRoundedPanel3";
            this.customRoundedPanel3.Size = new System.Drawing.Size(786, 166);
            this.customRoundedPanel3.TabIndex = 2;
            // 
            // dgv_presence
            // 
            this.dgv_presence.AllowUserToAddRows = false;
            this.dgv_presence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_presence.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_presence.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.dgv_presence.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_presence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_presence.EnableHeadersVisualStyles = false;
            this.dgv_presence.Location = new System.Drawing.Point(6, 9);
            this.dgv_presence.Name = "dgv_presence";
            this.dgv_presence.RowHeadersVisible = false;
            this.dgv_presence.Size = new System.Drawing.Size(777, 150);
            this.dgv_presence.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(16, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Liste de présences";
            // 
            // User_presences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.customRoundedPanel3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.customRoundedPanel1);
            this.Name = "User_presences";
            this.Size = new System.Drawing.Size(786, 424);
            this.customRoundedPanel1.ResumeLayout(false);
            this.customRoundedPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.customRoundedPanel2.ResumeLayout(false);
            this.customRoundedPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_presence)).EndInit();
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
        private test_arrondissement2012.PerfectRoundedButton bt_save_presence;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_statut;
        private CustomRoundedPanel customRoundedPanel2;
        private System.Windows.Forms.CheckedListBox list_box_personnel;
        private CustomRoundedPanel customRoundedPanel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_presence;
    }
}
