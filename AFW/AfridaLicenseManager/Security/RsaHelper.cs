using System.Security.Cryptography;

namespace AfridaLicenseManager.Security
{
    public class RsaHelper
    {
        private RSACryptoServiceProvider rsa;

        public RsaHelper(int keySize = 2048)
        {
            rsa = new RSACryptoServiceProvider(keySize);
        }

        public void FromXml(string xml)
        {
            rsa.FromXmlString(xml);
        }

        public string ToXml()
        {
            return rsa.ToXmlString(true);
        }

        public byte[] Encrypt(byte[] data)
        {
            return rsa.Encrypt(data, false);
        }

        public byte[] Decrypt(byte[] data)
        {
            return rsa.Decrypt(data, false);
        }
    }
}
