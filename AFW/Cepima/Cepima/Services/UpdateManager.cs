using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Cepima.Services
{
    public class UpdateManager
    {
        private readonly string _currentVersion;
        private readonly string _updaterPath;

        public UpdateManager()
        {
            _currentVersion = System.Reflection.Assembly
                .GetExecutingAssembly()
                .GetName()
                .Version
                .ToString(3);

            _updaterPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Cepima.Updater.exe");
        }

        public string CurrentVersion
        {
            get { return _currentVersion; }
        }

        public bool IsUpdaterAvailable()
        {
            return File.Exists(_updaterPath);
        }

        public async Task<bool> CheckLocalUpdateAsync(
            string versionFileUrl,
            string updateZipUrl)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string latestVersion =
                        await client.DownloadStringTaskAsync(
                            versionFileUrl);

                    latestVersion =
                        latestVersion.Trim();

                    Version current =
                        new Version(_currentVersion);

                    Version latest =
                        new Version(latestVersion);

                    if (latest <= current)
                        return false;

                    string tempDirectory =
                        Path.Combine(
                            Path.GetTempPath(),
                            "CEPIMA_Update");

                    if (Directory.Exists(tempDirectory))
                        Directory.Delete(
                            tempDirectory,
                            true);

                    Directory.CreateDirectory(
                        tempDirectory);

                    string zipPath =
                        Path.Combine(
                            tempDirectory,
                            "CEPIMA_Update.zip");

                    await client.DownloadFileTaskAsync(
                        updateZipUrl,
                        zipPath);

                    string extractDirectory =
                        Path.Combine(
                            tempDirectory,
                            "Extracted");

                    System.IO.Compression.ZipFile
                        .ExtractToDirectory(
                            zipPath,
                            extractDirectory);

                    StartUpdater(
                        extractDirectory);

                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    ex.ToString(),
                    "Erreur UpdateManager",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);

                return false;
            }
        }

        private void StartUpdater(
            string updateDirectory)
        {
            if (!IsUpdaterAvailable())
                throw new FileNotFoundException(
                    "Cepima.Updater.exe est introuvable.",
                    _updaterPath);

            string applicationPath =
                Process.GetCurrentProcess()
                .MainModule.FileName;

            ProcessStartInfo info =
                new ProcessStartInfo();

            info.FileName = _updaterPath;

            info.Arguments =
                "\"" + applicationPath + "\" " +
                "\"" + updateDirectory + "\"";

            info.UseShellExecute = true;

            Process.Start(info);

            Environment.Exit(0);
        }
    }
}