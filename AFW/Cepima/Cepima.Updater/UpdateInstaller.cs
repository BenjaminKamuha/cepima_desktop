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
                throw new Exception(
                    "Paramètres de mise à jour manquants.");

            string applicationPath = args[0];
            string updatePath = args[1];

            if (!File.Exists(applicationPath))
                throw new FileNotFoundException(
                    "Application CEPIMA introuvable.",
                    applicationPath);

            if (!Directory.Exists(updatePath))
                throw new DirectoryNotFoundException(
                    "Dossier de mise à jour introuvable : " +
                    updatePath);

            string applicationDirectory =
                Path.GetDirectoryName(applicationPath);

            // =====================================================
            // 1. ATTENDRE LA FERMETURE DE CEPIMA
            // =====================================================

            WaitForCepimaToClose(applicationPath);

            // =====================================================
            // 2. DOSSIER DE SAUVEGARDE
            // =====================================================

            string backupDirectory = Path.Combine(
                Path.GetTempPath(),
                "CEPIMA_Update_Backup");

            if (Directory.Exists(backupDirectory))
                Directory.Delete(backupDirectory, true);

            Directory.CreateDirectory(backupDirectory);

            List<string> copiedFiles =
                new List<string>();

            List<string> newFiles =
                new List<string>();

            try
            {
                // =================================================
                // 3. INSTALLER LA NOUVELLE VERSION
                // =================================================

                UpdateDirectory(
                    updatePath,
                    applicationDirectory,
                    backupDirectory,
                    copiedFiles,
                    newFiles);

                // =================================================
                // 4. SUPPRIMER LA SAUVEGARDE
                // =================================================

                if (Directory.Exists(backupDirectory))
                    Directory.Delete(
                        backupDirectory,
                        true);

                // =================================================
                // 5. RELANCER CEPIMA
                // =================================================

                Process.Start(applicationPath);
            }
            catch (Exception ex)
            {
                // =================================================
                // ROLLBACK
                // =================================================

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
                        "La mise à jour a échoué et la " +
                        "restauration a également échoué.\r\n\r\n" +
                        "Erreur mise à jour :\r\n" +
                        ex.Message +
                        "\r\n\r\n" +
                        "Erreur restauration :\r\n" +
                        rollbackException.Message);
                }

                throw new Exception(
                    "La mise à jour a échoué. " +
                    "L'ancienne version a été restaurée.\r\n\r\n" +
                    ex.Message);
            }
        }


        // =========================================================
        // ATTENDRE QUE CEPIMA SOIT FERMÉ
        // =========================================================

        private void WaitForCepimaToClose(
            string applicationPath)
        {
            string processName =
                Path.GetFileNameWithoutExtension(
                    applicationPath);

            const int maxAttempts = 60;

            for (int i = 0; i < maxAttempts; i++)
            {
                Process[] processes;

                try
                {
                    processes =
                        Process.GetProcessesByName(
                            processName);
                }
                catch
                {
                    processes = new Process[0];
                }

                bool cepimaRunning = false;

                foreach (Process process in processes)
                {
                    try
                    {
                        if (!process.HasExited)
                        {
                            cepimaRunning = true;
                            process.Dispose();
                            break;
                        }
                    }
                    catch
                    {
                        // Le processus vient peut-être
                        // de se fermer.
                    }

                    process.Dispose();
                }

                if (!cepimaRunning)
                {
                    // Petite pause de sécurité
                    Thread.Sleep(500);

                    return;
                }

                Thread.Sleep(500);
            }

            throw new IOException(
                "CEPIMA est toujours en cours d'exécution. " +
                "La mise à jour ne peut pas continuer.");
        }


        // =========================================================
        // MISE À JOUR D'UN DOSSIER
        // =========================================================

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

                // Ne jamais remplacer l'Updater
                if (string.Equals(
                    fileName,
                    UpdaterFileName,
                    StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // Ne jamais remplacer la configuration locale
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

                // =================================================
                // SAUVEGARDER L'ANCIEN FICHIER
                // =================================================

                if (File.Exists(destinationFile))
                {
                    string backupFile =
                        GetBackupPath(
                            destinationFile,
                            destinationDirectory,
                            backupDirectory);

                    string backupFolder =
                        Path.GetDirectoryName(
                            backupFile);

                    if (!Directory.Exists(backupFolder))
                        Directory.CreateDirectory(
                            backupFolder);

                    File.Copy(
                        destinationFile,
                        backupFile,
                        true);
                }
                else
                {
                    newFiles.Add(destinationFile);
                }

                // =================================================
                // COPIER AVEC RETRIES
                // =================================================

                CopyFileWithRetry(
                    sourceFile,
                    destinationFile);

                copiedFiles.Add(destinationFile);
            }

            // =====================================================
            // SOUS-DOSSIERS
            // =====================================================

            string[] directories =
                Directory.GetDirectories(
                    sourceDirectory);

            foreach (string sourceSubDirectory in directories)
            {
                string directoryName =
                    Path.GetFileName(
                        sourceSubDirectory);

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


        // =========================================================
        // COPIE AVEC RETRIES
        // =========================================================

        private void CopyFileWithRetry(
            string sourceFile,
            string destinationFile)
        {
            const int maxAttempts = 10;

            for (int i = 0; i < maxAttempts; i++)
            {
                try
                {
                    File.Copy(
                        sourceFile,
                        destinationFile,
                        true);

                    return;
                }
                catch
                {
                    if (i == maxAttempts - 1)
                        throw;

                    Thread.Sleep(500);
                }
            }
        }


        // =========================================================
        // CHEMIN BACKUP
        // =========================================================

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


        // =========================================================
        // ROLLBACK
        // =========================================================

        private void Rollback(
            string applicationDirectory,
            string backupDirectory,
            List<string> copiedFiles,
            List<string> newFiles)
        {
            // Supprimer les nouveaux fichiers
            foreach (string file in newFiles)
            {
                try
                {
                    if (File.Exists(file))
                        File.Delete(file);
                }
                catch
                {
                    // Continuer le rollback
                }
            }

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
                    Path.GetDirectoryName(
                        destinationFile);

                if (!Directory.Exists(destinationDirectory))
                    Directory.CreateDirectory(
                        destinationDirectory);

                File.Copy(
                    backupFile,
                    destinationFile,
                    true);
            }
        }
    }
}