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
    public partial class User_consultation : UserControl
    {
        string  PatientID;
        public User_consultation(string Patient)
        {
            InitializeComponent();
            PatientID = Patient;
        }

        private void bunifuRoundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_new_consualor_Click(object sender, EventArgs e)
        {
            MesUserCases.User_consultation cons = new MesUserCases.User_consultation(Convert.ToInt32(PatientID));
            cons.Dock = DockStyle.Fill;
            Form1.GlobalPanel_main.Controls.Clear();
            Form1.GlobalPanel_main.Controls.Add(cons);
        }
    }
}
