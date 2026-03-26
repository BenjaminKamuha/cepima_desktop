using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using AfridaLicenseManager.Models;
using AfridaLicenseManager.Utils;
using AfridaLicenseManager.Security;

namespace AfridaLicenseManager.Services
{
    public class LicenseGenerator
    {
        public void GenerateAndSave(License license, string path)
        {
            // Deadline activation 
            license.ActivationDeadlineUtc = DateTime.UtcNow.AddDays(3); // Delai court

            string json = JsonSerializerHelper.Serialize(license);
            byte[] plainBytes = Encoding.UTF8.GetBytes(json);
            
            byte[] encryptedData;
            byte[] aesKey;
            byte[] aesIv;

            // AES
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.GenerateKey();
                aes.GenerateIV();

                aesKey = aes.Key;
                aesIv = aes.IV;

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(plainBytes, 0, plainBytes.Length);
                    cs.FlushFinalBlock();
                    encryptedData = ms.ToArray();
                }
            }

            // RSA protège la clé AES
            byte[] encryptedAesKey;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.FromXmlString(RsaKeyStore.PublicKey);
                encryptedAesKey = rsa.Encrypt(aesKey, false);
            }

            // Écriture du fichier licence (FORMAT BLOCS)
            using (FileStream fs = File.Create(path))
            {
                WriteBlock(fs, encryptedAesKey);
                WriteBlock(fs, aesIv);
                WriteBlock(fs, encryptedData);
            }
        }

        private void WriteBlock(Stream s, byte[] data)
        {
            byte[] len = BitConverter.GetBytes(data.Length);
            s.Write(len, 0, 4);
            s.Write(data, 0, data.Length);
        }
    }
}
