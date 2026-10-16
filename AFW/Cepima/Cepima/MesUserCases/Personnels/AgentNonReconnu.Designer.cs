namespace Cepima.MesUserCases.Personnels
{
    partial class AgentNonReconnu
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lb_nom_personnel = new System.Windows.Forms.Label();
            this.btn_add_agent = new RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Cepima.Properties.Resources.no_100px;
            this.pictureBox2.Location = new System.Drawing.Point(182, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(120, 72);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // lb_nom_personnel
            // 
            this.lb_nom_personnel.AutoSize = true;
            this.lb_nom_personnel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lb_nom_personnel.Location = new System.Drawing.Point(157, 124);
            this.lb_nom_personnel.Name = "lb_nom_personnel";
            this.lb_nom_personnel.Size = new System.Drawing.Size(171, 24);
            this.lb_nom_personnel.TabIndex = 11;
            this.lb_nom_personnel.Text = "Agent non trouvé";
            // 
            // btn_add_agent
            // 
            this.btn_add_agent.BackColor = System.Drawing.Color.Transparent;
            this.btn_add_agent.BorderColor = System.Drawing.Color.White;
            this.btn_add_agent.BorderRadius = 10;
            this.btn_add_agent.BorderSize = 0;
            this.btn_add_agent.ButtonText = "Ajouter l\'agent";
            this.btn_add_agent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add_agent.DefaultBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_add_agent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_agent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_agent.ForeColor = System.Drawing.Color.White;
            this.btn_add_agent.HoverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_add_agent.Image = global::Cepima.Properties.Resources.add_30px;
            this.btn_add_agent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_add_agent.Location = new System.Drawing.Point(159, 211);
            this.btn_add_agent.Name = "btn_add_agent";
            this.btn_add_agent.Size = new System.Drawing.Size(167, 35);
            this.btn_add_agent.TabIndex = 39;
            this.btn_add_agent.Text = "Ajouter l\'agent";
            this.btn_add_agent.TextColor = System.Drawing.Color.White;
            this.btn_add_agent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_add_agent.UseVisualStyleBackColor = false;
            this.btn_add_agent.Click += new System.EventHandler(this.btn_add_agent_Click);
            // 
            // AgentNonReconnu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_add_agent);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lb_nom_personnel);
            this.Name = "AgentNonReconnu";
            this.Size = new System.Drawing.Size(485, 273);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lb_nom_personnel;
        private RoundedButton btn_add_agent;

    }
}
