using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//using LiveCharts;
//using LiveCharts.WinForms;
using UIFramework;
namespace Cepima.MesUserCases
{
    public partial class User_Stock_hospitalisation : UserControl
    {
        public User_Stock_hospitalisation()
        {
            InitializeComponent();
            SelectedLabel(lb_stock);
            DisplayItems(cbx_afficher);
        }

        private void DisplayItems(ComboBox cbx)
        {
            cbx.Items.Clear();
            cbx.Items.Add("Tous");
            cbx.Items.Add("Valeur");
            cbx.Items.Add("Cette semaine");
           
        }

        private void TestGraphique()
        {
          
            
        }
        // mettre en mouvement le panel en dessous des label
        private void LovePanel(Label lbl)
        {
            pan_move.Width = lbl.Width;
            pan_move.Left = lbl.Left;
            pan_move.Top = lbl.Top + 17;
        }

        private void SelectedLabel(Label actif)
        {
            lb_stock.ForeColor = Color.Black;
            lb_appro.ForeColor = Color.Black;
            lb_history.ForeColor = Color.Black;
            actif.ForeColor = Color.FromArgb(33, 99, 219);
            LovePanel(actif);
        }

        private void lb_stock_Click(object sender, EventArgs e)
        {
            SelectedLabel(lb_stock);
        }

        private void lb_appro_Click(object sender, EventArgs e)
        {
            SelectedLabel(lb_appro);
        }

        private void lb_history_Click(object sender, EventArgs e)
        {
            SelectedLabel(lb_history);
        }
    }
}
