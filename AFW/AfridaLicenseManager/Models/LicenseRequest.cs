using System;
using System.Collections.Generic;

namespace AfridaLicenseManager.Models
{
    public class LicenseRequest
    {
        public string ClientName { get; set; }
        public string ProductCode { get; set; }
        public string MachineFingerprint { get; set; }
        public double PaidAmount { get; set; }
        public double TotalAmount { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Dictionary<string, string> Features { get; set; }
    }
}
