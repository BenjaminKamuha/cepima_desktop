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
using Cepima.Data;

namespace Cepima.MesUserCases.Personnels
{
    public partial class AgentNonReconnu : UserControl
    {
        Database db = new Database();

        public AgentNonReconnu()
        {
            InitializeComponent();
        }



        private void ShowError(
    string message)
        {
            Action action =
                delegate
                {
                    MessageBox.Show(
                        message,
                        "CEPIMA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                };

            try
            {
                if (
                    Application.OpenForms.Count >
                    0)
                {
                    Form form =
                        Application.OpenForms[0];

                    if (form.InvokeRequired)
                    {
                        form.BeginInvoke(action);
                    }
                    else
                    {
                        action();
                    }
                }
            }
            catch
            {
            }
        }


        private int GetNextFingerprintId()
        {
            using (
                MySqlConnection con =
                db.GetConnection())
            {
                con.Open();

                string sql =
                    "SELECT COALESCE(" +
                    "MAX(fingerprint_id),0) + 1 " +
                    "FROM personnels";

                using (
                    MySqlCommand cmd =
                    new MySqlCommand(
                        sql,
                        con))
                {
                    return Convert.ToInt32(
                        cmd.ExecuteScalar());
                }
            }
        }


        private void OpenAddPersonnelForm()
        {
            try
            {
                int fingerprintId =
                    GetNextFingerprintId();

                Action action =
                    delegate
                    {
                        using (
                            MesForms.Personnel.Ajout_personnel form =
                            new MesForms.Personnel.Ajout_personnel())
                        {
                            form.FingerprintId =
                                fingerprintId;

                            form.ShowDialog();
                        }
                    };

                if (
                    Application.OpenForms.Count == 0)
                    return;

                Form mainForm =
                    Application.OpenForms[0];

                if (mainForm.InvokeRequired)
                {
                    mainForm.BeginInvoke(action);
                }
                else
                {
                    action();
                }
            }
            catch (Exception ex)
            {
                ShowError(
                    "Erreur ouverture formulaire :\n\n" +
                    ex.Message);
            }
        }

        private void btn_add_agent_Click(object sender, EventArgs e)
        {
            OpenAddPersonnelForm();
        }
    }
}
