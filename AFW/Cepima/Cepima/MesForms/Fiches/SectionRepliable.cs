using System;
using System.Windows.Forms;

namespace Cepima.MesForms.Fiches
{
    public partial class SectionRepliable : UserControl
    {
        private int hauteurOuverte;

        public string Titre
        {
            get
            {
                return lblTitre.Text;
            }
            set
            {
                lblTitre.Text = value;
            }
        }

        public Panel Contenu
        {
            get
            {
                return panelContent;
            }
        }

        public SectionRepliable()
        {
            InitializeComponent();
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            if (panelContent.Visible)
            {
                // On mémorise la hauteur actuelle
                hauteurOuverte = this.Height;

                // Fermer
                panelContent.Visible = false;

                this.Height = panelHeader.Height;

                btnToggle.Text = "+";
            }
            else
            {
                // Ouvrir
                panelContent.Visible = true;

                // Restaurer la hauteur mémorisée
                this.Height = hauteurOuverte;

                btnToggle.Text = "−";
            }
        }
    }
}