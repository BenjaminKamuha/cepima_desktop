using System;
using AfridaLicenseManager.Models;
using AfridaLicenseManager.Utils;
using AfridaLicenseManager.Security;

namespace AfridaLicenseManager.Services
{
    public static class LicensePaymentManager
    {
        public static void ApplyPayment(License license, decimal paymentAmount)
        {
            if (license == null)
                throw new ArgumentNullException("license");

            if (paymentAmount <= 0)
                throw new Exception("Montant de paiement invalide.");

            // 1. Ajouter au total payé
            license.PaidAmount += paymentAmount;

            // 2. Si déjà perpétuelle, on ne touche plus aux dates
            if (license.Type == LicenseType.Perpetual)
                return;

            // 3. Calcul des jours ajoutés
            int addedDays = CalculateAddedDays(paymentAmount);

            // 4. Extension de la date d’expiration
            if (!license.ExpiryDate.HasValue || license.ExpiryDate.Value < DateTime.UtcNow)
                license.ExpiryDate = DateTime.UtcNow.AddDays(addedDays);
            else
                license.ExpiryDate = license.ExpiryDate.Value.AddDays(addedDays);

            // 5. Passage automatique en perpétuel
            if (license.PaidAmount >= license.TotalPrice)
            {
                license.Type = LicenseType.Perpetual;
                license.ExpiryDate = null;
            }
        }

        public static int GetRemainingDays(License license)
        {
            if (license.Type == LicenseType.Perpetual)
                return int.MaxValue;

            if (!license.ExpiryDate.HasValue)
                return 0;

            return (license.ExpiryDate.Value.Date - DateTime.UtcNow.Date).Days;
        }

        public static int CalculateAddedDays(decimal amount)
        {
            // 20$ = 30 jours
            const decimal PRICE_PER_30_DAYS = 20m;
            const int DAYS_PER_30 = 30;

            decimal ratio = amount / PRICE_PER_30_DAYS;
            return (int)Math.Floor(ratio * DAYS_PER_30);
        }
    }
}