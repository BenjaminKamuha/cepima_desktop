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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pan_presence_check = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            // 
            // pan_presence_check
            // 
            this.pan_presence_check.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_presence_check.Location = new System.Drawing.Point(0, 0);
            this.pan_presence_check.Name = "pan_presence_check";
            this.pan_presence_check.Size = new System.Drawing.Size(469, 275);
            this.pan_presence_check.TabIndex = 0;
            // 
            // Presence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(469, 275);
            this.Controls.Add(this.pan_presence_check);
            this.Name = "Presence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Presence";
            this.Load += new System.EventHandler(this.Presence_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel pan_presence_check;
    }
}