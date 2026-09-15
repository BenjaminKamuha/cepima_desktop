using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Cepima.Updater
{
    public class UpdateInstaller
    {
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

            // Attendre que CEPIMA soit complètement fermé
            Thread.Sleep(1500);

            CopyDirectory(
                updatePath,
                applicationDirectory);

            // Redémarrer CEPIMA
            Process.Start(applicationPath);
        }

        private void CopyDirectory(
            string sourceDirectory,
            string destinationDirectory)
        {
            if (!Directory.Exists(destinationDirectory))
                Directory.CreateDirectory(destinationDirectory);

            string[] files =
                Directory.GetFiles(sourceDirectory);

            foreach (string file in files)
            {
                string fileName =
                    Path.GetFileName(file);

                string destination =
                    Path.Combine(
                        destinationDirectory,
                        fileName);

                File.Copy(file, destination, true);
            }

            string[] directories =
                Directory.GetDirectories(sourceDirectory);

            foreach (string directory in directories)
            {
                string directoryName =
                    Path.GetFileName(directory);

                string destination =
                    Path.Combine(
                        destinationDirectory,
                        directoryName);

                CopyDirectory(
                    directory,
                    destination);
            }
        }
    }
}