namespace Cepima.MesUserCases.Hospitalisation
{
    partial class User_Termine_hospi
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
            this.bunifuRoundedPanel1 = new BunifuRoundedPanel();
            this.flow_demande = new System.Windows.Forms.FlowLayoutPanel();
            this.lb_not_found = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_nombres = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rb_annulees = new System.Windows.Forms.RadioButton();
            this.rb_terminees = new System.Windows.Forms.RadioButton();
            this.rb_demandees = new System.Windows.Forms.RadioButton();
            this.rb_tous = new System.Windows.Forms.RadioButton();
            this.textBox_reseach = new MyRoundedTextBox();
            this.bunifuRoundedPanel1.SuspendLayout();
            this.flow_demande.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuRoundedPanel1
            // 
            this.bunifuRoundedPanel1.BorderColor = System.Drawing.Color.DarkBlue;
            this.bunifuRoundedPanel1.BorderRadius = 8;
            this.bunifuRoundedPanel1.BorderSize = 0;
            this.bunifuRoundedPanel1.Controls.Add(this.flow_demande);
            this.bunifuRoundedPanel1.Controls.Add(this.panel1);
            this.bunifuRoundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuRoundedPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuRoundedPanel1.Name = "bunifuRoundedPanel1";
            this.bunifuRoundedPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.bunifuRoundedPanel1.ShadowDepth = 10;
            this.bunifuRoundedPanel1.Size = new System.Drawing.Size(1057, 573);
            this.bunifuRoundedPanel1.TabIndex = 1;
            // 
            // flow_demande
            // 
            this.flow_demande.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flow_demande.AutoScroll = true;
            this.flow_demande.Controls.Add(this.lb_not_found);
            this.flow_demande.Location = new System.Drawing.Point(13, 79);
            this.flow_demande.Name = "flow_demande";
            this.flow_demande.Size = new System.Drawing.Size(1030, 486);
            this.flow_demande.TabIndex = 1;
            // 
            // lb_not_found
            // 
            this.lb_not_found.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_not_found.AutoSize = true;
            this.lb_not_found.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_not_found.Location = new System.Drawing.Point(3, 0);
            this.lb_not_found.Name = "lb_not_found";
            this.lb_not_found.Padding = new System.Windows.Forms.Padding(400, 250, 0, 0);
            this.lb_not_found.Size = new System.Drawing.Size(400, 270);
            this.lb_not_found.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lb_nombres);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.rb_annulees);
            this.panel1.Controls.Add(this.rb_terminees);
            this.panel1.Controls.Add(this.rb_demandees);
            this.panel1.Controls.Add(this.rb_tous);
            this.panel1.Controls.Add(this.textBox_reseach);
            this.panel1.Location = new System.Drawing.Point(13, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 62);
            this.panel1.TabIndex = 0;
            // 
            // lb_nombres
            // 
            this.lb_nombres.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_nombres.AutoSize = true;
            this.lb_nombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nombres.Location = new System.Drawing.Point(963, 31);
            this.lb_nombres.Name = "lb_nombres";
            this.lb_nombres.Size = new System.Drawing.Size(24, 16);
            this.lb_nombres.TabIndex = 39;
            this.lb_nombres.Text = "34";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1030, 4);
            this.panel2.TabIndex = 13;
            // 
            // rb_annulees
            // 
            this.rb_annulees.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rb_annulees.AutoSize = true;
            this.rb_annulees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_annulees.Location = new System.Drawing.Point(819, 29);
            this.rb_annulees.Name = "rb_annulees";
            this.rb_annulees.Size = new System.Drawing.Size(90, 20);
            this.rb_annulees.TabIndex = 12;
            this.rb_annulees.TabStop = true;
            this.rb_annulees.Text = "Annulées";
            this.rb_annulees.UseVisualStyleBackColor = true;
            this.rb_annulees.CheckedChanged += new System.EventHandler(this.rb_annulees_CheckedChanged);
            // 
            // rb_terminees
            // 
            this.rb_terminees.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rb_terminees.AutoSize = true;
            this.rb_terminees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_terminees.Location = new System.Drawing.Point(642, 29);
            this.rb_terminees.Name = "rb_terminees";
            this.rb_terminees.Size = new System.Drawing.Size(100, 20);
            this.rb_terminees.TabIndex = 12;
            this.rb_terminees.TabStop = true;
            this.rb_terminees.Text = "Terminées";
            this.rb_terminees.UseVisualStyleBackColor = true;
            this.rb_terminees.CheckedChanged += new System.EventHandler(this.rb_terminees_CheckedChanged);
            // 
            // rb_demandees
            // 
            this.rb_demandees.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rb_demandees.AutoSize = true;
            this.rb_demandees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_demandees.Location = new System.Drawing.Point(455, 29);
            this.rb_demandees.Name = "rb_demandees";
            this.rb_demandees.Size = new System.Drawing.Size(110, 20);
            this.rb_demandees.TabIndex = 12;
            this.rb_demandees.TabStop = true;
            this.rb_demandees.Text = "Demandées";
            this.rb_demandees.UseVisualStyleBackColor = true;
            this.rb_demandees.CheckedChanged += new System.EventHandler(this.rb_demandees_CheckedChanged);
            // 
            // rb_tous
            // 
            this.rb_tous.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rb_tous.AutoSize = true;
            this.rb_tous.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_tous.Location = new System.Drawing.Point(317, 29);
            this.rb_tous.Name = "rb_tous";
            this.rb_tous.Size = new System.Drawing.Size(61, 20);
            this.rb_tous.TabIndex = 12;
            this.rb_tous.TabStop = true;
            this.rb_tous.Text = "Tous";
            this.rb_tous.UseVisualStyleBackColor = true;
            this.rb_tous.CheckedChanged += new System.EventHandler(this.rb_tous_CheckedChanged);
            // 
            // textBox_reseach
            // 
            this.textBox_reseach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_reseach.BackColor = System.Drawing.Color.White;
            this.textBox_reseach.BorderColor = System.Drawing.Color.Silver;
            this.textBox_reseach.BorderRadius = 8;
            this.textBox_reseach.BorderSize = 1;
            this.textBox_reseach.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.textBox_reseach.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.textBox_reseach.ForeColor = System.Drawing.Color.Black;
            this.textBox_reseach.Image = global::Cepima.Properties.Resources.search_25px;
            this.textBox_reseach.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.textBox_reseach.ImagePadding = 4;
            this.textBox_reseach.Location = new System.Drawing.Point(3, 15);
            this.textBox_reseach.MaxLength = 32767;
            this.textBox_reseach.Name = "textBox_reseach";
            this.textBox_reseach.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.textBox_reseach.PlaceholderColor = System.Drawing.Color.Gray;
            this.textBox_reseach.PlaceholderText = "";
            this.textBox_reseach.Size = new System.Drawing.Size(273, 34);
            this.textBox_reseach.TabIndex = 11;
            this.textBox_reseach.TextChanged += new System.EventHandler(this.textBox_reseach_TextChanged);
            // 
            // User_Termine_hospi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bunifuRoundedPanel1);
            this.Name = "User_Termine_hospi";
            this.Size = new System.Drawing.Size(1057, 573);
            this.bunifuRoundedPanel1.ResumeLayout(false);
            this.flow_demande.ResumeLayout(false);
            this.flow_demande.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rb_annulees;
        private System.Windows.Forms.RadioButton rb_terminees;
        private System.Windows.Forms.RadioButton rb_demandees;
        private System.Windows.Forms.RadioButton rb_tous;
        private MyRoundedTextBox textBox_reseach;
        private BunifuRoundedPanel bunifuRoundedPanel1;
        private System.Windows.Forms.FlowLayoutPanel flow_demande;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb_not_found;
        private System.Windows.Forms.Label lb_nombres;
    }
}
