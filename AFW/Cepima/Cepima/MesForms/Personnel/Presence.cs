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
        string nom_personnel;
        DateTime date;
        string hour;

        public Presence(string nom, DateTime date, string hour)
        {
            InitializeComponent();


            timer.Interval = 5000;
            timer.Start();

            nom_personnel = nom;
            date = date;
            hour = hour;

            lb_nom_personnel.Text = nom;
            lb_date.Text = Convert.ToString(date);
            lb_heure_arrive.Text = Convert.ToString(hour);


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
