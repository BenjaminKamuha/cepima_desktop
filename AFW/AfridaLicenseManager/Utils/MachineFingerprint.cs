using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace AfridaLicenseManager.Utils
{
    public static class MachineFingerprint
    {
        public static string Generate()
        {
            string cpu = GetCpuId();
            string disk = GetDiskSerial();
            string raw = cpu + disk;

            using (SHA256 sha = SHA256.Create())
            {
                byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(raw));
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

        private static string GetCpuId()
        {
            try
            {
                var m = new ManagementObjectSearcher("select ProcessorId from Win32_Processor");
                foreach (ManagementObject mo in m.Get())
                    return mo["ProcessorId"].ToString();
            }
            catch { }
            return "CPU_UNKNOWN";
        }

        private static string GetDiskSerial()
        {
            try
            {
                var m = new ManagementObjectSearcher("select SerialNumber from Win32_DiskDrive");
                foreach (ManagementObject mo in m.Get())
                    return mo["SerialNumber"].ToString();
            }
            catch { }
            return "DISK_UNKNOWN";
        }
    }
}
