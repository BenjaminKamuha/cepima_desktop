using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AfridaLicenseManager.Models;


namespace MyProject.Licensing
{
    class LicenseStorage
    {
        private static string Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Afrida\license.lic";

        public static void Save(License license)
        {
            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(Path));

            byte[] data = LicenseCrypto.Encrypt(license);
            File.WriteAllBytes(Path, data);
        }

        public static License Load()
        {
            if (!File.Exists(Path))
                throw new Exception("License non activée.");

            byte[] data = File.ReadAllBytes(Path);
            return LicenseCrypto.Decrypt(data);
        }
    }
}
