namespace Cepima.MesForms.Rapport
{
    partial class BonRapport
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
            this.Ds_BonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Ds_Bon = new Cepima.MesForms.Rapport.Ds_Bon();
            ((System.ComponentModel.ISupportInitialize)(this.Ds_BonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ds_Bon)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Ds_Bon";
            reportDataSource1.Value = this.Ds_BonBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Cepima.MesForms.Rapport.Bon.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(389, 457);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // Ds_BonBindingSource
            // 
            this.Ds_BonBindingSource.DataMember = "Ds_Bon";
            this.Ds_BonBindingSource.DataSource = this.Ds_Bon;
            // 
            // Ds_Bon
            // 
            this.Ds_Bon.DataSetName = "Ds_Bon";
            this.Ds_Bon.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BonRapport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(389, 457);
            this.Controls.Add(this.reportViewer1);
            this.Name = "BonRapport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BonRapport";
            this.Load += new System.EventHandler(this.BonRapport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Ds_BonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ds_Bon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Ds_BonBindingSource;
        private Ds_Bon Ds_Bon;
    }
}