using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Cepima.Updater
{
    public class UpdateInstaller
    {
        private const string UpdaterFileName = "Cepima.Updater.exe";
        private const string ConfigFileName = "Cepima.exe.config";

        public void Run(string[] args)
        {
            if (args == null || args.Length < 2)
                throw new Exception("Paramètres de mise à jour manquants.");

            string applicationPath = args[0];
            string updatePath = args[1];

            if (!File.Exists(applicationPath))
                throw new FileNotFoundException(
                    "Application CEPIMA introuvable.",
                    applicationPath);

            if (!Directory.Exists(updatePath))
                throw new DirectoryNotFoundException(
                    "Dossier de mise à jour introuvable : " + updatePath);

            string applicationDirectory =
                Path.GetDirectoryName(applicationPath);

            // -------------------------------------------------
            // 1. Attendre que CEPIMA soit complètement fermé
            // -------------------------------------------------

            WaitForApplicationToClose(applicationPath);

            // -------------------------------------------------
            // 2. Créer un dossier de sauvegarde
            // -------------------------------------------------

            string backupDirectory = Path.Combine(
                Path.GetTempPath(),
                "CEPIMA_Update_Backup");

            if (Directory.Exists(backupDirectory))
                Directory.Delete(backupDirectory, true);

            Directory.CreateDirectory(backupDirectory);

            // -------------------------------------------------
            // 3. Copier les fichiers avec sauvegarde
            // -------------------------------------------------

            List<string> copiedFiles =
                new List<string>();

            List<string> newFiles =
                new List<string>();

            try
            {
                UpdateDirectory(
                    updatePath,
                    applicationDirectory,
                    backupDirectory,
                    copiedFiles,
                    newFiles);

                // -------------------------------------------------
                // 4. Nettoyer la sauvegarde après succès
                // -------------------------------------------------

                if (Directory.Exists(backupDirectory))
                    Directory.Delete(backupDirectory, true);

                // -------------------------------------------------
                // 5. Relancer CEPIMA
                // -------------------------------------------------

                Process.Start(applicationPath);
            }
            catch (Exception ex)
            {
                // -------------------------------------------------
                // ÉCHEC → ROLLBACK
                // -------------------------------------------------

                try
                {
                    Rollback(
                        applicationDirectory,
                        backupDirectory,
                        copiedFiles,
                        newFiles);
                }
                catch (Exception rollbackException)
                {
                    throw new Exception(
                        "La mise à jour a échoué et la restauration " +
                        "automatique a également échoué.\r\n\r\n" +
                        "Erreur mise à jour :\r\n" +
                        ex.Message +
                        "\r\n\r\nErreur restauration :\r\n" +
                        rollbackException.Message);
                }

                throw new Exception(
                    "La mise à jour a échoué. " +
                    "L'ancienne version a été restaurée.\r\n\r\n" +
                    ex.Message);
            }
        }

        // =====================================================
        // MISE À JOUR D'UN DOSSIER
        // =====================================================

        private void UpdateDirectory(
            string sourceDirectory,
            string destinationDirectory,
            string backupDirectory,
            List<string> copiedFiles,
            List<string> newFiles)
        {
            if (!Directory.Exists(destinationDirectory))
                Directory.CreateDirectory(destinationDirectory);

            string[] files =
                Directory.GetFiles(sourceDirectory);

            foreach (string sourceFile in files)
            {
                string fileName =
                    Path.GetFileName(sourceFile);

                // ---------------------------------------------
                // Ne jamais remplacer l'Updater actuellement
                // en cours d'exécution.
                // ---------------------------------------------

                if (string.Equals(
                    fileName,
                    UpdaterFileName,
                    StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // ---------------------------------------------
                // Ne jamais remplacer la configuration locale.
                // ---------------------------------------------

                if (string.Equals(
                    fileName,
                    ConfigFileName,
                    StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string destinationFile =
                    Path.Combine(
                        destinationDirectory,
                        fileName);

                // ---------------------------------------------
                // Sauvegarder l'ancien fichier
                // ---------------------------------------------

                if (File.Exists(destinationFile))
                {
                    string backupFile =
                        GetBackupPath(
                            destinationFile,
                            destinationDirectory,
                            backupDirectory);

                    string backupFolder =
                        Path.GetDirectoryName(backupFile);

                    if (!Directory.Exists(backupFolder))
                        Directory.CreateDirectory(backupFolder);

                    File.Copy(
                        destinationFile,
                        backupFile,
                        true);
                }
                else
                {
                    // Nouveau fichier
                    newFiles.Add(destinationFile);
                }

                // ---------------------------------------------
                // Copier la nouvelle version
                // ---------------------------------------------

                File.Copy(
                    sourceFile,
                    destinationFile,
                    true);

                copiedFiles.Add(destinationFile);
            }

            // ---------------------------------------------
            // Sous-dossiers
            // ---------------------------------------------

            string[] directories =
                Directory.GetDirectories(sourceDirectory);

            foreach (string sourceSubDirectory in directories)
            {
                string directoryName =
                    Path.GetFileName(sourceSubDirectory);

                string destinationSubDirectory =
                    Path.Combine(
                        destinationDirectory,
                        directoryName);

                UpdateDirectory(
                    sourceSubDirectory,
                    destinationSubDirectory,
                    backupDirectory,
                    copiedFiles,
                    newFiles);
            }
        }

        // =====================================================
        // CHEMIN DE SAUVEGARDE
        // =====================================================

        private string GetBackupPath(
            string filePath,
            string applicationDirectory,
            string backupDirectory)
        {
            string relativePath =
                filePath.Substring(
                    applicationDirectory.Length)
                .TrimStart(
                    Path.DirectorySeparatorChar,
                    Path.AltDirectorySeparatorChar);

            return Path.Combine(
                backupDirectory,
                relativePath);
        }

        // =====================================================
        // ROLLBACK
        // =====================================================

        private void Rollback(
            string applicationDirectory,
            string backupDirectory,
            List<string> copiedFiles,
            List<string> newFiles)
        {
            // Supprimer les fichiers nouvellement créés
            foreach (string file in newFiles)
            {
                if (File.Exists(file))
                    File.Delete(file);
            }

            // Restaurer les anciens fichiers
            if (!Directory.Exists(backupDirectory))
                return;

            string[] backupFiles =
                Directory.GetFiles(
                    backupDirectory,
                    "*",
                    SearchOption.AllDirectories);

            foreach (string backupFile in backupFiles)
            {
                string relativePath =
                    backupFile.Substring(
                        backupDirectory.Length)
                    .TrimStart(
                        Path.DirectorySeparatorChar,
                        Path.AltDirectorySeparatorChar);

                string destinationFile =
                    Path.Combine(
                        applicationDirectory,
                        relativePath);

                string destinationDirectory =
                    Path.GetDirectoryName(destinationFile);

                if (!Directory.Exists(destinationDirectory))
                    Directory.CreateDirectory(destinationDirectory);

                File.Copy(
                    backupFile,
                    destinationFile,
                    true);
            }
        }

        // =====================================================
        // ATTENDRE LA FERMETURE DE CEPIMA
        // =====================================================

        private void WaitForApplicationToClose(
            string applicationPath)
        {
            const int maxAttempts = 30;

            for (int i = 0; i < maxAttempts; i++)
            {
                if (CanAccessFile(applicationPath))
                    return;

                Thread.Sleep(500);
            }

            throw new IOException(
                "CEPIMA est toujours en cours d'utilisation. " +
                "Impossible de continuer la mise à jour.");
        }

        // =====================================================
        // TEST D'ACCÈS AU FICHIER
        // =====================================================

        private bool CanAccessFile(
            string filePath)
        {
            try
            {
                using (FileStream stream =
                    new FileStream(
                        filePath,
                        FileMode.Open,
                        FileAccess.Read,
                        FileShare.None))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}