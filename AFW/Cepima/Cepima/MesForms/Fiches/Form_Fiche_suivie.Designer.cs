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
            this.section_info_patient = new Cepima.MesForms.Fiches.SectionRepliable();
            this.section_motif = new Cepima.MesForms.Fiches.SectionRepliable();
            this.section_antecedents = new Cepima.MesForms.Fiches.SectionRepliable();
            this.section_examens = new Cepima.MesForms.Fiches.SectionRepliable();
            this.section_autre = new Cepima.MesForms.Fiches.SectionRepliable();
            this.flowSections.SuspendLayout();
            this.panelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowSections
            // 
            this.flowSections.AutoScroll = true;
            this.flowSections.Controls.Add(this.section_info_patient);
            this.flowSections.Controls.Add(this.section_motif);
            this.flowSections.Controls.Add(this.section_antecedents);
            this.flowSections.Controls.Add(this.section_examens);
            this.flowSections.Controls.Add(this.section_autre);
            this.flowSections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowSections.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowSections.Location = new System.Drawing.Point(0, 0);
            this.flowSections.Name = "flowSections";
            this.flowSections.Size = new System.Drawing.Size(1039, 881);
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
            this.panelPrincipal.Size = new System.Drawing.Size(1039, 881);
            this.panelPrincipal.TabIndex = 0;
            // 
            // section_info_patient
            // 
            this.section_info_patient.BackColor = System.Drawing.Color.White;
            this.section_info_patient.Location = new System.Drawing.Point(3, 3);
            this.section_info_patient.Name = "section_info_patient";
            this.section_info_patient.Size = new System.Drawing.Size(1014, 671);
            this.section_info_patient.TabIndex = 0;
            this.section_info_patient.Titre = "I.Informations  du patient";
            // 
            // section_motif
            // 
            this.section_motif.BackColor = System.Drawing.Color.White;
            this.section_motif.Location = new System.Drawing.Point(3, 680);
            this.section_motif.Name = "section_motif";
            this.section_motif.Size = new System.Drawing.Size(1014, 345);
            this.section_motif.TabIndex = 1;
            this.section_motif.Titre = " Motif et historique de la maladie";
            // 
            // section_antecedents
            // 
            this.section_antecedents.BackColor = System.Drawing.Color.White;
            this.section_antecedents.Location = new System.Drawing.Point(3, 1031);
            this.section_antecedents.Name = "section_antecedents";
            this.section_antecedents.Size = new System.Drawing.Size(1014, 420);
            this.section_antecedents.TabIndex = 4;
            this.section_antecedents.Titre = "IV. Antecédents";
            // 
            // section_examens
            // 
            this.section_examens.BackColor = System.Drawing.Color.White;
            this.section_examens.Location = new System.Drawing.Point(3, 1457);
            this.section_examens.Name = "section_examens";
            this.section_examens.Size = new System.Drawing.Size(1014, 1171);
            this.section_examens.TabIndex = 3;
            this.section_examens.Titre = "Tous les examens";
            // 
            // section_autre
            // 
            this.section_autre.BackColor = System.Drawing.Color.White;
            this.section_autre.Location = new System.Drawing.Point(3, 2634);
            this.section_autre.Name = "section_autre";
            this.section_autre.Size = new System.Drawing.Size(1012, 616);
            this.section_autre.TabIndex = 2;
            this.section_autre.Titre = "Autres";
            // 
            // Form_Fiche_suivie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1039, 881);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "Form_Fiche_suivie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiche de suivie du patient";
            this.Load += new System.EventHandler(this.Form_Fiche_suivie_Load);
            this.flowSections.ResumeLayout(false);
            this.panelPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowSections;
        private System.Windows.Forms.Panel panelPrincipal;
        private Fiches.SectionRepliable section_info_patient;
        private Fiches.SectionRepliable section_motif;
        private Fiches.SectionRepliable section_autre;
        private Fiches.SectionRepliable section_antecedents;
        private Fiches.SectionRepliable section_examens;


    }
}