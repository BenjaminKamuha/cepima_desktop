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
namespace Cepima
{
    public partial class Form1 : Form
    {
        public static Panel GlobalPanel_main { get; set; }
        public Form1()
        {
            InitializeComponent();
            GlobalPanel_main = panel_center_main;
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bt_minus_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bt_add_patient_Click(object sender, EventArgs e)
        {
            MesUserCases.User_patient patient = new MesUserCases.User_patient();
            patient.Dock = DockStyle.Fill;
            panel_center_main.Controls.Clear();
            panel_center_main.Controls.Add(patient);
            GlobalPanel_main = panel_center_main;
        }

        private void bt_signe_vitaux_Click(object sender, EventArgs e)
        {
            GlobalPanel_main = panel_center_main;
            MesUserCases.User_signes_vitaux signes = new MesUserCases.User_signes_vitaux();
            signes.Dock = DockStyle.Fill;
            panel_center_main.Controls.Clear();
            panel_center_main.Controls.Add(signes);
        }

        private void bt_consultation_Click(object sender, EventArgs e)
        {
            GlobalPanel_main = panel_center_main;
            MesUserCases.User_consultation consultation = new MesUserCases.User_consultation();
            consultation.Dock = new DockStyle();
            panel_center_main.Controls.Clear();
            panel_center_main.Controls.Add(consultation);
        }

    }
}
