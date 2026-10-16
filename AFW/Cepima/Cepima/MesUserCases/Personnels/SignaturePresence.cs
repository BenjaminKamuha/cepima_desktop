using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cepima
{
    public partial class SignaturePresence : UserControl
    {
        public SignaturePresence(string nom, string date, string hour)
        {
            InitializeComponent();

            lb_nom_personnel.Text = nom;
            lb_date.Text = date;
            lb_heure_arrive.Text = hour;
        }
    }
}
