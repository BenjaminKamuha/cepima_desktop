namespace Cepima.MesForms
{
    partial class Form_Fiche_suivie
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
            this.flowSections = new System.Windows.Forms.FlowLayoutPanel();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.sectionAdministratif = new Cepima.MesForms.Fiches.SectionRepliable();
            this.sectionPsychiatrique = new Cepima.MesForms.Fiches.SectionRepliable();
            this.sectionConsultation = new Cepima.MesForms.Fiches.SectionRepliable();
            this.sectionEEG = new Cepima.MesForms.Fiches.SectionRepliable();
            this.sectionPrescription = new Cepima.MesForms.Fiches.SectionRepliable();
            this.sectionNoteClinique = new Cepima.MesForms.Fiches.SectionRepliable();
            this.sectionDocument = new Cepima.MesForms.Fiches.SectionRepliable();
            this.flowSections.SuspendLayout();
            this.panelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowSections
            // 
            this.flowSections.AutoScroll = true;
            this.flowSections.Controls.Add(this.sectionAdministratif);
            this.flowSections.Controls.Add(this.sectionPsychiatrique);
            this.flowSections.Controls.Add(this.sectionConsultation);
            this.flowSections.Controls.Add(this.sectionEEG);
            this.flowSections.Controls.Add(this.sectionPrescription);
            this.flowSections.Controls.Add(this.sectionNoteClinique);
            this.flowSections.Controls.Add(this.sectionDocument);
            this.flowSections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowSections.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowSections.Location = new System.Drawing.Point(0, 0);
            this.flowSections.Name = "flowSections";
            this.flowSections.Size = new System.Drawing.Size(825, 739);
            this.flowSections.TabIndex = 1;
            this.flowSections.WrapContents = false;
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.AutoScroll = true;
            this.panelPrincipal.Controls.Add(this.flowSections);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(825, 739);
            this.panelPrincipal.TabIndex = 0;
            // 
            // sectionAdministratif
            // 
            this.sectionAdministratif.BackColor = System.Drawing.Color.White;
            this.sectionAdministratif.Location = new System.Drawing.Point(5, 5);
            this.sectionAdministratif.Margin = new System.Windows.Forms.Padding(5);
            this.sectionAdministratif.Name = "sectionAdministratif";
            this.sectionAdministratif.Size = new System.Drawing.Size(796, 215);
            this.sectionAdministratif.TabIndex = 0;
            this.sectionAdministratif.Titre = "Informations administratives";
            // 
            // sectionPsychiatrique
            // 
            this.sectionPsychiatrique.BackColor = System.Drawing.Color.White;
            this.sectionPsychiatrique.Location = new System.Drawing.Point(5, 230);
            this.sectionPsychiatrique.Margin = new System.Windows.Forms.Padding(5);
            this.sectionPsychiatrique.Name = "sectionPsychiatrique";
            this.sectionPsychiatrique.Size = new System.Drawing.Size(796, 215);
            this.sectionPsychiatrique.TabIndex = 1;
            this.sectionPsychiatrique.Titre = "Dossier Psychiatrique";
            // 
            // sectionConsultation
            // 
            this.sectionConsultation.BackColor = System.Drawing.Color.White;
            this.sectionConsultation.Location = new System.Drawing.Point(3, 453);
            this.sectionConsultation.Name = "sectionConsultation";
            this.sectionConsultation.Size = new System.Drawing.Size(796, 215);
            this.sectionConsultation.TabIndex = 2;
            this.sectionConsultation.Titre = "Consultation";
            // 
            // sectionEEG
            // 
            this.sectionEEG.BackColor = System.Drawing.Color.White;
            this.sectionEEG.Location = new System.Drawing.Point(3, 674);
            this.sectionEEG.Name = "sectionEEG";
            this.sectionEEG.Size = new System.Drawing.Size(796, 215);
            this.sectionEEG.TabIndex = 3;
            this.sectionEEG.Titre = "EEG";
            // 
            // sectionPrescription
            // 
            this.sectionPrescription.BackColor = System.Drawing.Color.White;
            this.sectionPrescription.Location = new System.Drawing.Point(3, 895);
            this.sectionPrescription.Name = "sectionPrescription";
            this.sectionPrescription.Size = new System.Drawing.Size(796, 215);
            this.sectionPrescription.TabIndex = 4;
            this.sectionPrescription.Titre = "Préscription";
            // 
            // sectionNoteClinique
            // 
            this.sectionNoteClinique.BackColor = System.Drawing.Color.White;
            this.sectionNoteClinique.Location = new System.Drawing.Point(3, 1116);
            this.sectionNoteClinique.Name = "sectionNoteClinique";
            this.sectionNoteClinique.Size = new System.Drawing.Size(796, 215);
            this.sectionNoteClinique.TabIndex = 1;
            this.sectionNoteClinique.Titre = "Notes Cliniques";
            // 
            // sectionDocument
            // 
            this.sectionDocument.BackColor = System.Drawing.Color.White;
            this.sectionDocument.Location = new System.Drawing.Point(3, 1337);
            this.sectionDocument.Name = "sectionDocument";
            this.sectionDocument.Size = new System.Drawing.Size(796, 215);
            this.sectionDocument.TabIndex = 5;
            this.sectionDocument.Titre = "Documents";
            // 
            // Form_Fiche_suivie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(825, 739);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "Form_Fiche_suivie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiche de suivie du patient";
            //this.Load += new System.EventHandler(this.Form_Fiche_suivie_Load);
            this.flowSections.ResumeLayout(false);
            this.panelPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowSections;
        private System.Windows.Forms.Panel panelPrincipal;
        private Fiches.SectionRepliable sectionAdministratif;
        private Fiches.SectionRepliable sectionPsychiatrique;
        private Fiches.SectionRepliable sectionConsultation;
        private Fiches.SectionRepliable sectionEEG;
        private Fiches.SectionRepliable sectionPrescription;
        private Fiches.SectionRepliable sectionNoteClinique;
        private Fiches.SectionRepliable sectionDocument;


    }
}