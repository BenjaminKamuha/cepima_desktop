using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cepima.Services
{
    public partial class UpdateProgressForm : Form
    {
        private Label lblTitle;
        private Label lblStatus;
        private Label lblSize;
        private ProgressBar progressBar;

        public UpdateProgressForm()
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            this.Text = "Mise à jour de CEPIMA";
            this.Width = 500;
            this.Height = 190;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.ShowInTaskbar = false;

            lblTitle = new Label();

            lblTitle.Text = "Mise à jour de CEPIMA";
            lblTitle.Font = new Font(
                "Segoe UI",
                12,
                FontStyle.Bold);

            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(25, 20);

            this.Controls.Add(lblTitle);


            lblStatus = new Label();

            lblStatus.Text =
                "Téléchargement de la mise à jour...";

            lblStatus.AutoSize = true;
            lblStatus.Location =
                new Point(25, 55);

            this.Controls.Add(lblStatus);


            progressBar = new ProgressBar();

            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;

            progressBar.Width = 440;
            progressBar.Height = 25;

            progressBar.Location =
                new Point(25, 80);

            this.Controls.Add(progressBar);


            lblSize = new Label();

            lblSize.Text = "0 %";

            lblSize.AutoSize = true;
            lblSize.Location =
                new Point(25, 120);

            this.Controls.Add(lblSize);
        }


        public void SetProgress(
            int percentage,
            long downloadedBytes,
            long totalBytes)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    new Action<int, long, long>(
                        SetProgress),
                    percentage,
                    downloadedBytes,
                    totalBytes);

                return;
            }

            if (percentage < 0)
                percentage = 0;

            if (percentage > 100)
                percentage = 100;

            progressBar.Value = percentage;

            string downloaded =
                FormatBytes(downloadedBytes);

            string total =
                FormatBytes(totalBytes);

            if (totalBytes > 0)
            {
                lblSize.Text =
                    percentage + "%   " +
                    downloaded + " / " +
                    total;
            }
            else
            {
                lblSize.Text =
                    percentage + "%   " +
                    downloaded;
            }
        }


        public void SetStatus(string status)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    new Action<string>(
                        SetStatus),
                    status);

                return;
            }

            lblStatus.Text = status;
        }


        private string FormatBytes(long bytes)
        {
            if (bytes < 1024)
                return bytes + " B";

            if (bytes < 1024 * 1024)
                return
                    (bytes / 1024.0)
                    .ToString("0.0") +
                    " KB";

            if (bytes < 1024 * 1024 * 1024)
                return
                    (bytes / (1024.0 * 1024.0))
                    .ToString("0.0") +
                    " MB";

            return
                (bytes / (1024.0 * 1024.0 * 1024.0))
                .ToString("0.0") +
                " GB";
        }
    }
}