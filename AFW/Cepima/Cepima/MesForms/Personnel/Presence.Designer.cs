namespace Cepima.MesForms.Personnel
{
    partial class Presence
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
            this.components = new System.ComponentModel.Container();
            this.lb_nom_personnel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_date = new System.Windows.Forms.Label();
            this.lb_heure_arrive = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_nom_personnel
            // 
            this.lb_nom_personnel.AutoSize = true;
            this.lb_nom_personnel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lb_nom_personnel.Location = new System.Drawing.Point(226, 91);
            this.lb_nom_personnel.Name = "lb_nom_personnel";
            this.lb_nom_personnel.Size = new System.Drawing.Size(154, 24);
            this.lb_nom_personnel.TabIndex = 7;
            this.lb_nom_personnel.Text = "Nom personnel";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cepima.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(105, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(227, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Date: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(227, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Heure d\'arrivé: ";
            // 
            // lb_date
            // 
            this.lb_date.AutoSize = true;
            this.lb_date.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_date.Location = new System.Drawing.Point(294, 163);
            this.lb_date.Name = "lb_date";
            this.lb_date.Size = new System.Drawing.Size(49, 21);
            this.lb_date.TabIndex = 8;
            this.lb_date.Text = "Date: ";
            // 
            // lb_heure_arrive
            // 
            this.lb_heure_arrive.AutoSize = true;
            this.lb_heure_arrive.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_heure_arrive.Location = new System.Drawing.Point(349, 193);
            this.lb_heure_arrive.Name = "lb_heure_arrive";
            this.lb_heure_arrive.Size = new System.Drawing.Size(116, 21);
            this.lb_heure_arrive.TabIndex = 8;
            this.lb_heure_arrive.Text = "Heure d\'arrivé: ";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            // 
            // Presence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(587, 333);
            this.Controls.Add(this.lb_heure_arrive);
            this.Controls.Add(this.lb_date);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_nom_personnel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Presence";
            this.Text = "Presence";
            this.Load += new System.EventHandler(this.Presence_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_nom_personnel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_date;
        private System.Windows.Forms.Label lb_heure_arrive;
        private System.Windows.Forms.Timer timer;
    }
}