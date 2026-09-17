using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace Cepima.Services
{
    public class UpdateManager
    {
        // =========================================================
        // CONFIGURATION GITHUB
        // =========================================================

        private const string GitHubApiUrl =
            "https://api.github.com/repos/BenjaminKamuha/cepima_desktop/releases/latest";

        // =========================================================
        // FICHIERS
        // =========================================================

        private readonly string _updaterPath;

        // =========================================================
        // CONSTRUCTEUR
        // =========================================================

        public UpdateManager()
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            _updaterPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Cepima.Updater.exe");
        }

        // =========================================================
        // VERSION ACTUELLE
        // =========================================================

        public string GetCurrentVersion()
        {
            Version version =
                Assembly.GetExecutingAssembly().GetName().Version;

            return version.ToString(3);
        }

        // =========================================================
        // VERIFIER LA MISE A JOUR
        // =========================================================

        public async Task CheckForUpdateAsync()
        {
            try
            {
                // -------------------------------------------------
                // VERSION ACTUELLE
                // -------------------------------------------------

                string currentVersionString =
                    GetCurrentVersion();

                Version currentVersion =
                    new Version(currentVersionString);

                // -------------------------------------------------
                // CONTACTER GITHUB
                // -------------------------------------------------

                string json;

                using (WebClient client = new WebClient())
                {
                    // GitHub exige un User-Agent
                    client.Headers.Add(
                        "User-Agent",
                        "CEPIMA-Desktop");

                    client.Headers.Add(
                        "Accept",
                        "application/vnd.github+json");

                    json =
                        await client.DownloadStringTaskAsync(
                            GitHubApiUrl);
                }

                // -------------------------------------------------
                // LIRE LA REPONSE JSON
                // -------------------------------------------------

                JavaScriptSerializer serializer =
                    new JavaScriptSerializer();

                GitHubRelease release =
                    serializer.Deserialize<GitHubRelease>(json);

                if (release == null)
                    return;

                if (string.IsNullOrEmpty(release.tag_name))
                    return;

                // -------------------------------------------------
                // VERSION GITHUB
                // Exemple : v1.0.1
                // -------------------------------------------------

                string latestVersionString =
                    release.tag_name
                    .Trim()
                    .TrimStart('v', 'V');

                Version latestVersion;

                if (!Version.TryParse(
                    latestVersionString,
                    out latestVersion))
                {
                    MessageBox.Show(
                        "La version GitHub est invalide : " +
                        release.tag_name,
                        "Mise à jour de CEPIMA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // -------------------------------------------------
                // COMPARAISON
                // -------------------------------------------------

                if (latestVersion <= currentVersion)
                {
                    MessageBox.Show(
                        "Aucune mise à jour.\r\n\r\n" +
                        "Version actuelle : " +
                        currentVersionString +
                        "\r\n" +
                        "Dernière version : " +
                        latestVersionString,
                        "CEPIMA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                // -------------------------------------------------
                // CHERCHER LE ZIP
                // -------------------------------------------------

                GitHubAsset updateAsset = null;

                if (release.assets != null)
                {
                    foreach (GitHubAsset asset in release.assets)
                    {
                        if (asset == null)
                            continue;

                        if (string.IsNullOrEmpty(asset.name))
                            continue;

                        if (asset.name.EndsWith(
                            ".zip",
                            StringComparison.OrdinalIgnoreCase))
                        {
                            updateAsset = asset;
                            break;
                        }
                    }
                }

                if (updateAsset == null)
                {
                    MessageBox.Show(
                        "La version " +
                        latestVersionString +
                        " est disponible, mais aucun fichier ZIP " +
                        "de mise à jour n'a été trouvé dans la Release.",
                        "Mise à jour de CEPIMA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // -------------------------------------------------
                // CONFIRMATION UTILISATEUR
                // -------------------------------------------------

                DialogResult confirmation =
                    MessageBox.Show(
                        "Une nouvelle version de CEPIMA est disponible.\r\n\r\n" +

                        "Version actuelle : " +
                        currentVersionString +
                        "\r\n" +

                        "Nouvelle version : " +
                        latestVersionString +
                        "\r\n\r\n" +

                        "Voulez-vous mettre à jour maintenant ?",

                        "Mise à jour de CEPIMA",

                        MessageBoxButtons.YesNo,

                        MessageBoxIcon.Information);

                if (confirmation != DialogResult.Yes)
                    return;

                // -------------------------------------------------
                // VERIFIER L'UPDATER
                // -------------------------------------------------

                if (!File.Exists(_updaterPath))
                {
                    MessageBox.Show(
                        "Cepima.Updater.exe est introuvable.\r\n\r\n" +
                        _updaterPath,
                        "Mise à jour de CEPIMA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                // -------------------------------------------------
                // DOSSIER TEMPORAIRE
                // -------------------------------------------------

                string updateRoot =
                    Path.Combine(
                        Path.GetTempPath(),
                        "CEPIMA_Update");

                if (Directory.Exists(updateRoot))
                {
                    try
                    {
                        Directory.Delete(
                            updateRoot,
                            true);
                    }
                    catch
                    {
                        // On continue.
                    }
                }

                Directory.CreateDirectory(updateRoot);

                // -------------------------------------------------
                // ZIP
                // -------------------------------------------------

                string zipPath =
                    Path.Combine(
                        updateRoot,
                        "CEPIMA_Update.zip");

                // -------------------------------------------------
                // TELECHARGEMENT
                // -------------------------------------------------

                using (WebClient client = new WebClient())
                {
                    client.Headers.Add(
                        "User-Agent",
                        "CEPIMA-Desktop");

                    await client.DownloadFileTaskAsync(
                        updateAsset.browser_download_url,
                        zipPath);
                }

                // -------------------------------------------------
                // EXTRACTION
                // -------------------------------------------------

                string extractDirectory =
                    Path.Combine(
                        updateRoot,
                        "NewVersion");

                Directory.CreateDirectory(
                    extractDirectory);

                System.IO.Compression.ZipFile
                    .ExtractToDirectory(
                        zipPath,
                        extractDirectory);

                // -------------------------------------------------
                // CHEMIN DE CEPIMA
                // -------------------------------------------------

                string applicationPath =
                    Process.GetCurrentProcess()
                        .MainModule
                        .FileName;

                // -------------------------------------------------
                // LANCER L'UPDATER
                // -------------------------------------------------

                ProcessStartInfo startInfo =
                    new ProcessStartInfo();

                startInfo.FileName =
                    _updaterPath;

                startInfo.Arguments =
                    "\"" +
                    applicationPath +
                    "\" \"" +
                    extractDirectory +
                    "\"";

                startInfo.UseShellExecute = true;

                // Demander les droits administrateur
                startInfo.Verb = "runas";

                Process.Start(startInfo);

                // -------------------------------------------------
                // FERMER CEPIMA
                // -------------------------------------------------

                Environment.Exit(0);
            }
            catch (WebException ex)
            {
                MessageBox.Show(
                    "Impossible de contacter GitHub.\r\n\r\n" +
                    ex.Message,
                    "Mise à jour de CEPIMA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur pendant la mise à jour :\r\n\r\n" +
                    ex.Message,
                    "Mise à jour de CEPIMA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }

    // =============================================================
    // MODELE GITHUB RELEASE
    // =============================================================

    public class GitHubRelease
    {
        public string tag_name { get; set; }

        public string name { get; set; }

        public GitHubAsset[] assets { get; set; }
    }

    // =============================================================
    // MODELE GITHUB ASSET
    // =============================================================

    public class GitHubAsset
    {
        public string name { get; set; }

        public string browser_download_url { get; set; }
    }
}