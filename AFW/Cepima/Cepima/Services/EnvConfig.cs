using System;
using System.Collections.Generic;
using System.IO;

namespace Cepima.Services
{
    public static class EnvConfig
    {
        private static readonly Dictionary<string, string> Values =
            new Dictionary<string, string>(
                StringComparer.OrdinalIgnoreCase);

        private static bool loaded = false;

        private static void Load()
        {
            if (loaded)
                return;

            loaded = true;

            string envPath =
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    ".env");

            if (!File.Exists(envPath))
                return;

            foreach (string line in File.ReadAllLines(envPath))
            {
                string value = line.Trim();

                if (value.Length == 0)
                    continue;

                if (value.StartsWith("#"))
                    continue;

                int separator =
                    value.IndexOf('=');

                if (separator <= 0)
                    continue;

                string key =
                    value.Substring(
                        0,
                        separator).Trim();

                string val =
                    value.Substring(
                        separator + 1).Trim();

                // Retirer éventuellement les guillemets
                if (val.Length >= 2 &&
                    ((val.StartsWith("\"") &&
                      val.EndsWith("\"")) ||
                     (val.StartsWith("'") &&
                      val.EndsWith("'"))))
                {
                    val =
                        val.Substring(
                            1,
                            val.Length - 2);
                }

                Values[key] = val;
            }
        }

        public static string Get(
            string key,
            string defaultValue = "")
        {
            Load();

            string value;

            if (Values.TryGetValue(
                key,
                out value))
            {
                return value;
            }

            return defaultValue;
        }

        public static int GetInt(
            string key,
            int defaultValue)
        {
            string value =
                Get(key, null);

            int result;

            if (int.TryParse(
                value,
                out result))
            {
                return result;
            }

            return defaultValue;
        }
    }
}