using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cepima
{
    public partial class Test_simple : Form
    {
        public Test_simple()
        {
            InitializeComponent();
        }

        private void Test_simple_Load(object sender, EventArgs e)
        {
            TestGraphique();
        }

        private void TestGraphique()
        {
            List<string> mois = new List<string>
{
    "Janvier",
    "Février",
    "Mars",
    "Avril",
    "Mai",
    "Juin"
};

            List<double> montants = new List<double>
{
    150000,
    230000,
    180000,
    310000,
    270000,
    350000
};

            //MonGraphique graphique = new MonGraphique();

            //graphique.Size = new Size(850, 450);

            monGraphique1.CouleurFond = Color.White;
            monGraphique1.AfficherLegende = true;
            monGraphique1.AfficherGrille = true;

            monGraphique1.AjouterHistogramme(
                "Recettes",
                mois,
                montants
            );

        }
    }
}
