using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cepima.MesUserCases
{
    public partial class User_DashBoard_consultation : UserControl
    {
        int idPatient = 0;
        public User_DashBoard_consultation()
        {
            InitializeComponent();
        }

        private void dgv_consult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_consult.CurrentRow != null)
            {
               bt_start.Visible = true;
               idPatient = Convert.ToInt32(dgv_consult.CurrentRow.Cells["ID_Patient"].Value);
            }
            else
            {
                bt_start.Visible = false;
                return;
            }
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            // appel du User_consultation
            MesUserCases.User_consultation cons = new User_consultation(idPatient);
            Form1.GlobalPanel_main.Controls.Clear();
            Form1.GlobalPanel_main.Controls.Add(cons);
        }

    }
}
