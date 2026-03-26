using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace AfridaLicenseManager.Utils
{
    public static class JsonSerializerHelper
    {
        public static string Serialize<T>(T obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(ms, obj);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public static T Deserialize<T>(string json)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(ms);
            }
        }
    }
}
