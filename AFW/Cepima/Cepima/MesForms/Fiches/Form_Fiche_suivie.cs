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
            //  (Information administratives)
            MesForms.Fiches.User_AdminInfo info = new Fiches.User_AdminInfo(PatientID);
            info.Dock = DockStyle.Fill;
            sectionAdministratif.Contenu.Controls.Add(info);

            // section consultation
            MesForms.Fiches.User_consultation cons = new Fiches.User_consultation();
            cons.Dock = DockStyle.Fill;
            sectionConsultation.Contenu.Controls.Add(cons);

            // section préscription
            MesForms.Fiches.User_prescription presc = new Fiches.User_prescription();
            presc.Dock = DockStyle.Fill;
            sectionPrescription.Contenu.Controls.Add(presc);

            // section EEG
            MesForms.Fiches.User_EEG_fiche eeg = new Fiches.User_EEG_fiche();
            eeg.Dock = DockStyle.Fill;
            sectionEEG.Contenu.Controls.Add(eeg);

            // section note clinique
            MesForms.Fiches.User_note_clinique note = new Fiches.User_note_clinique();
            note.Dock = DockStyle.Fill;
            sectionNoteClinique.Contenu.Controls.Add(note);

        }
      
    }
}
