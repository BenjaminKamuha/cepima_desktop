using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cepima.MesForms.Personnel
{
    public partial class Presence : Form
    {
        bool success;
        public Presence(bool success, Control user_control)
        {
            InitializeComponent();

            success = success;

            if (success)
            {
                timer.Interval = 10000;
            }

            else
            {
                timer.Interval = 15000;
            }

            pan_presence_check.Controls.Clear();
            user_control.Dock = DockStyle.Fill;
            pan_presence_check.Controls.Add(user_control);
            
            timer.Start();
            timer.Tick += timer_Tick;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
        }

        private void Presence_Load(object sender, EventArgs e)
        {

        }
    }
}
