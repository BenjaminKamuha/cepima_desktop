namespace Cepima.MesForms.Fiches
{
    partial class RaportFiche
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource17 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource18 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource19 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource20 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource21 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource22 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource23 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource24 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dtPatientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Ds_Fiche = new Cepima.MesForms.Fiches.Ds_Fiche();
            this.dtAntecedentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtSignesVitauxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtExamenNeuroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtConsultationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtExamenPsyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtEEGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtTraitementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dtPatientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ds_Fiche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtAntecedentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSignesVitauxBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtExamenNeuroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtConsultationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtExamenPsyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEEGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTraitementBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dtPatientBindingSource
            // 
            this.dtPatientBindingSource.DataMember = "dtPatient";
            this.dtPatientBindingSource.DataSource = this.Ds_Fiche;
            // 
            // Ds_Fiche
            // 
            this.Ds_Fiche.DataSetName = "Ds_Fiche";
            this.Ds_Fiche.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtAntecedentsBindingSource
            // 
            this.dtAntecedentsBindingSource.DataMember = "dtAntecedents";
            this.dtAntecedentsBindingSource.DataSource = this.Ds_Fiche;
            // 
            // dtSignesVitauxBindingSource
            // 
            this.dtSignesVitauxBindingSource.DataMember = "dtSignesVitaux";
            this.dtSignesVitauxBindingSource.DataSource = this.Ds_Fiche;
            // 
            // dtExamenNeuroBindingSource
            // 
            this.dtExamenNeuroBindingSource.DataMember = "dtExamenNeuro";
            this.dtExamenNeuroBindingSource.DataSource = this.Ds_Fiche;
            // 
            // dtConsultationBindingSource
            // 
            this.dtConsultationBindingSource.DataMember = "dtConsultation";
            this.dtConsultationBindingSource.DataSource = this.Ds_Fiche;
            // 
            // dtExamenPsyBindingSource
            // 
            this.dtExamenPsyBindingSource.DataMember = "dtExamenPsy";
            this.dtExamenPsyBindingSource.DataSource = this.Ds_Fiche;
            // 
            // dtEEGBindingSource
            // 
            this.dtEEGBindingSource.DataMember = "dtEEG";
            this.dtEEGBindingSource.DataSource = this.Ds_Fiche;
            // 
            // dtTraitementBindingSource
            // 
            this.dtTraitementBindingSource.DataMember = "dtTraitement";
            this.dtTraitementBindingSource.DataSource = this.Ds_Fiche;
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoScroll = true;
            this.reportViewer1.AutoSize = true;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource17.Name = "dsPatient";
            reportDataSource17.Value = this.dtPatientBindingSource;
            reportDataSource18.Name = "dsAntecedents";
            reportDataSource18.Value = this.dtAntecedentsBindingSource;
            reportDataSource19.Name = "dsSignes";
            reportDataSource19.Value = this.dtSignesVitauxBindingSource;
            reportDataSource20.Name = "dsExamen_neurologique";
            reportDataSource20.Value = this.dtExamenNeuroBindingSource;
            reportDataSource21.Name = "dsConsultation";
            reportDataSource21.Value = this.dtConsultationBindingSource;
            reportDataSource22.Name = "dsPsychiatrique";
            reportDataSource22.Value = this.dtExamenPsyBindingSource;
            reportDataSource23.Name = "dsEEG";
            reportDataSource23.Value = this.dtEEGBindingSource;
            reportDataSource24.Name = "dsTraitement";
            reportDataSource24.Value = this.dtTraitementBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource17);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource18);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource19);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource20);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource21);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource22);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource23);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource24);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Cepima.MesForms.Fiches.Fiche.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(890, 881);
            this.reportViewer1.TabIndex = 0;
            // 
            // RaportFiche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(890, 881);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RaportFiche";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RaportFiche";
            this.Load += new System.EventHandler(this.RaportFiche_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtPatientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ds_Fiche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtAntecedentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSignesVitauxBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtExamenNeuroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtConsultationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtExamenPsyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEEGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTraitementBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dtPatientBindingSource;
        private Ds_Fiche Ds_Fiche;
        private System.Windows.Forms.BindingSource dtAntecedentsBindingSource;
        private System.Windows.Forms.BindingSource dtSignesVitauxBindingSource;
        private System.Windows.Forms.BindingSource dtExamenNeuroBindingSource;
        private System.Windows.Forms.BindingSource dtConsultationBindingSource;
        private System.Windows.Forms.BindingSource dtExamenPsyBindingSource;
        private System.Windows.Forms.BindingSource dtEEGBindingSource;
        private System.Windows.Forms.BindingSource dtTraitementBindingSource;
    }
}