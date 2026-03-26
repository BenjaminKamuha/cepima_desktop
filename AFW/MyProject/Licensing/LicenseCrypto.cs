using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using AfridaLicenseManager.Models;
using AfridaLicenseManager.Utils;
using AfridaLicenseManager.Security;

namespace MyProject.Licensing
{
    public static class LicenseCrypto
    {
        public static byte[] Encrypt(License license)
        {
            string json = JsonSerializerHelper.Serialize(license);
            byte[] plainBytes = Encoding.UTF8.GetBytes(json);

            byte[] encryptedData;
            byte[] aesKey;
            byte[] aesIv;

            using (Aes aes = Aes.Create())
            {
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

            byte[] encryptedAesKey;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(RsaKeyStore.PublicKey);
                encryptedAesKey = rsa.Encrypt(aesKey, false);
            }

            using (MemoryStream fs = new MemoryStream())
            {
                WriteBlock(fs, encryptedAesKey);
                WriteBlock(fs, aesIv);
                WriteBlock(fs, encryptedData);
                return fs.ToArray();
            }
        }

        private static void WriteBlock(Stream s, byte[] data)
        {
            s.Write(BitConverter.GetBytes(data.Length), 0, 4);
            s.Write(data, 0, data.Length);
        }

        public static License Decrypt(byte[] fileBytes)
        {
            using (var ms = new MemoryStream(fileBytes))
            {
                byte[] encryptedAesKey = ReadBlock(ms);
                byte[] aesIv = ReadBlock(ms);
                byte[] encryptedData = ReadBlock(ms);

                // Déchiffre la clé AES avec RSA
                byte[] aesKey;
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(RsaKeyStore.PrivateKey); // clé privée en dur
                    aesKey = rsa.Decrypt(encryptedAesKey, false);
                }

                // Déchiffre les données AES
                byte[] plainBytes;
                using (Aes aes = Aes.Create())
                {
                    aes.Key = aesKey;
                    aes.IV = aesIv;

                    using (MemoryStream decryptMs = new MemoryStream())
                    using (CryptoStream cs = new CryptoStream(decryptMs, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedData, 0, encryptedData.Length);
                        cs.FlushFinalBlock();
                        plainBytes = decryptMs.ToArray();
                    }
                }

                // JSON -> License
                string json = Encoding.UTF8.GetString(plainBytes);
                return JsonSerializerHelper.Deserialize<License>(json);
            }
        }

        // Méthode privée pour lire un bloc
        private static byte[] ReadBlock(Stream s)
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
