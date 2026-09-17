using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cepima.Data;

namespace Cepima.MesUserCases
{
    public partial class User_DashBord_pharmacie : UserControl
    {
        Database db = new Database();

        public User_DashBord_pharmacie()
        {
            InitializeComponent();
        }

        private void User_DashBord_pharmacie_Load(object sender, EventArgs e)
        {
            // Chargement médicament dispensé 
            //string query_disp_ambulatoire = "SELECT 
        }
    }
}
