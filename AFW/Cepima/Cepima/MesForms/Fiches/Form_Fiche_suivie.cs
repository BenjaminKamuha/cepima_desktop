using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cepima.MesForms
{
    public partial class Form_Fiche_suivie : Form
    {
        string PatientID;
        public Form_Fiche_suivie(string id_patient)
        {
            InitializeComponent();
            PatientID = id_patient;
            // nous ajoutons notre control sur notre sectionAdministration
            ChargerSection();
        }

        private void ChargerSection()
        {
            // Informations administratives
            MesForms.Fiches.User_AdminInfo info = new MesForms.Fiches.User_AdminInfo(PatientID.ToString());
            info.Dock = DockStyle.Fill;
            // Vider uniquement la zone de contenu
            section_info_patient.Contenu.Controls.Clear();
            section_info_patient.Contenu.Controls.Add(info);

            // Historique et motif de consultation
            MesForms.Fiches.User_consultation cons = new Fiches.User_consultation(PatientID);
            cons.Dock = DockStyle.Fill;
            section_motif.Contenu.Controls.Clear();
            section_motif.Contenu.Controls.Add(cons);

            // Tous les examens possibles
            MesForms.Fiches.User_examens ex = new Fiches.User_examens(PatientID);
            ex.Dock = DockStyle.Fill;
            section_examens.Contenu.Controls.Clear();
            section_examens.Contenu.Controls.Add(ex);

            // antécedents
            MesForms.Fiches.User_antecedant ante = new Fiches.User_antecedant(PatientID);
            ante.Dock = DockStyle.Fill;
            section_antecedents.Contenu.Controls.Clear();
            section_antecedents.Contenu.Controls.Add(ante);

            // Autres sections
            MesForms.Fiches.User_Other autre = new Fiches.User_Other(PatientID);
            autre.Dock = DockStyle.Fill;
            section_autre.Contenu.Controls.Clear();
            section_autre.Contenu.Controls.Add(autre);
        }

        private void Form_Fiche_suivie_Load(object sender, EventArgs e)
        {

        }
      
    }
}
