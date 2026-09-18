using System;
using System.Windows.Forms;

namespace Cepima.Updater
{
    public partial class UpdaterForm : Form
    {
        private string[] _args;

        public UpdaterForm(string[] args)
        {
            InitializeComponent();

            _args = args ?? new string[0];

            Text = "Mise à jour de CEPIMA";
            Width = 450;
            Height = 180;
            StartPosition = FormStartPosition.CenterScreen;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            UpdateInstaller installer = new UpdateInstaller();

            try
            {
                installer.Run(_args);
                MessageBox.Show(
                    "Mise à jour terminée.",
                    "CEPIMA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur pendant la mise à jour :\r\n\r\n" + ex.Message,
                    "CEPIMA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Close();
            }
        }
    }
}