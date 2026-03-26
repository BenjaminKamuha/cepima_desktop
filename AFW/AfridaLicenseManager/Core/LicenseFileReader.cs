using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using AfridaLicenseManager.Models;
using AfridaLicenseManager.Utils;
using AfridaLicenseManager.Security;

namespace AfridaLicenseManager.Core
{
    public class LicenseFileReader
    {
        public License Read(string path)
        {
            byte[] encryptedAesKey;
            byte[] aesIv;
            byte[] encryptedData;

            using (FileStream fs = File.OpenRead(path))
            {
                encryptedAesKey = ReadBlock(fs);
                aesIv = ReadBlock(fs);
                encryptedData = ReadBlock(fs);
            }

            byte[] aesKey;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.FromXmlString(RsaKeyStore.PrivateKey);
                aesKey = rsa.Decrypt(encryptedAesKey, false);
            }

            byte[] plainBytes;
            using (Aes aes = Aes.Create())
            {
                aes.Key = aesKey;
                aes.IV = aesIv;

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(encryptedData, 0, encryptedData.Length);
                    cs.FlushFinalBlock();
                    plainBytes = ms.ToArray();
                }
            }

            string json = Encoding.UTF8.GetString(plainBytes);
            return JsonSerializerHelper.Deserialize<License>(json);
        }

        private byte[] ReadBlock(Stream s)
        {
            byte[] lenBytes = new byte[4];
            if (s.Read(lenBytes, 0, 4) != 4)
                throw new Exception("Fichier licence corrompu.");

            int size = BitConverter.ToInt32(lenBytes, 0);
            if (size <= 0 || size > 10000000)
                throw new Exception("Bloc licence corrompu.");

            byte[] data = new byte[size];
            int read = s.Read(data, 0, size);
            if (read != size)
                throw new Exception("Bloc licence incomplet.");

            return data;
        }
    }
}
