using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            hauteurOuverte = this.Height;
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            if (panelContent.Visible)
            {
                // Fermer la section
                panelContent.Visible = false;

                this.Height = panelHeader.Height;

                btnToggle.Text = "+";
            }
            else
            {
                // Ouvrir la section
                panelContent.Visible = true;

                this.Height = hauteurOuverte;

                btnToggle.Text = "−";
            }
        }
    }
}

