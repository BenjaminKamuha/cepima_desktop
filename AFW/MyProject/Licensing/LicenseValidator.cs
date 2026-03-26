using System;
using AfridaLicenseManager.Models;
using AfridaLicenseManager.Utils;

namespace MyProject.Licensing
{
    public static class LicenseValidator
    {
        public static void Validate(License license)
        {
            string currentMachine = MachineFingerprint.Generate();

            // 1 Fingeprint
            if (license.MachineFingerprint != currentMachine)
                throw new Exception("Licence invalide pour cette machine.");


            // 2. Rollback protection
            DateTime now = DateTime.UtcNow;

            if (license.Type != LicenseType.Perpetual)
                if (license.LastRunDate != DateTime.MinValue && now < license.LastRunDate)
                {
                    throw new Exception("Tentative de fraude détectée (rollback date).");
                }

            // 3. Expiration
            if (license.Type == LicenseType.Temporary &&
                license.ExpiryDate.HasValue &&
                DateTime.UtcNow > license.ExpiryDate.Value)
            {
                throw new Exception("Licence expirée.");
            }

            // 4. Mise à jour LastRunDate
            license.LastRunDate = now;
            license.Activated = true;
            license.LastRunDate = now;
            // 5. Sauvegarder la license mise à jour
            LicenseStorage.Save(license);
        }

        public static void checkLicenseDeadLine(License license) 
        {
            DateTime now = DateTime.UtcNow;
            // Deadline d'activation
            if (!(now > license.ActivationDeadlineUtc.AddDays(-3) && now < license.ActivationDeadlineUtc))
               
                throw new Exception("Deadline: License expirée");

            // Déjà activé
            if (license.Activated)
                throw new Exception("Cette licence a déjà été utilisée.");


           Validate(license);
        }

        public static int GetRemainingDays(License license)
        {
            if (license.Type == LicenseType.Perpetual)
                return int.MaxValue;

            if (!license.ExpiryDate.HasValue)
                return 0;

            return (license.ExpiryDate.Value.Date - DateTime.UtcNow.Date).Days;
        }


    }
}
