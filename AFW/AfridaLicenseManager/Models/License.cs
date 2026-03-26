using System;
using System.Collections.Generic;

namespace AfridaLicenseManager.Models
{
    public class License
    {
        public string LicenseId { get; set; }
        public string ClientName { get; set; }
        public string ProductModel { get; set; }

        public string MachineFingerprint { get; set; }

        public LicenseType Type { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public decimal PaidAmount { get; set; }
        public decimal TotalPrice { get; set; }

        public DateTime LastRunDate { get; set; }

        public DateTime ActivationDeadlineUtc { get; set; }
        public bool Activated { get; set; }

        //public Dictionary<string, string> Features { get; set; }
    }
}