namespace Cepima.MesForms.Personnel
{
    partial class Liste_presence
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Ds_Liste = new Cepima.MesForms.Personnel.Ds_Liste();
            this.Dt_ListeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Ds_Liste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dt_ListeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Ds_Liste";
            reportDataSource1.Value = this.Dt_ListeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Cepima.MesForms.Personnel.Liste_presence.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(902, 644);
            this.reportViewer1.TabIndex = 0;
            // 
            // Ds_Liste
            // 
            this.Ds_Liste.DataSetName = "Ds_Liste";
            this.Ds_Liste.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Dt_ListeBindingSource
            // 
            this.Dt_ListeBindingSource.DataMember = "Dt_Liste";
            this.Dt_ListeBindingSource.DataSource = this.Ds_Liste;
            // 
            // Liste_presence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(902, 644);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Liste_presence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liste_presence";
            this.Load += new System.EventHandler(this.Liste_presence_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Ds_Liste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dt_ListeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Dt_ListeBindingSource;
        private Ds_Liste Ds_Liste;
    }
}