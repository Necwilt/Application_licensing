using PluginInterfaces;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Soft_Dev_Kursach
{
    public static class LicenseKeyGenerator
    {
        private static readonly RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

        public static string GenerateLicenseKey(string hardwareId, string pluginName, Dictionary<string, IPlugin<int, string>> plugins, string additionalData)
        {
            if (!plugins.ContainsKey(pluginName))
                throw new ArgumentException($"Плагин '{pluginName}' не найден.");

            IPlugin<int, string> plugin = plugins[pluginName];
            int hash = plugin.Execute(hardwareId);

            string key = hash.ToString("X");

            if (key.Length < 16)
                key = AddRandomHexCharacters(key);
            if (key.Length > 16)
            {
                key = key.Substring(0, 16);
            }

            string encryptedKeyWithAdditionalData = EncryptAdditionalData(additionalData, "wC/fKlFJwX2hp53+ezuwOw==");
            string encryptedKey = key;
            encryptedKey += encryptedKeyWithAdditionalData;

            encryptedKey = SubstituteAlphabet(encryptedKey);

            return encryptedKey;
        }

        public static void LoadPlugins(ListBox FileListBox, ListBox functionNameListBox, Dictionary<string, IPlugin<int, string>> plugins, Dictionary<string, string> pluginDescriptions)
        {
            string pluginsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");
            string[] pluginFiles = Directory.GetFiles(pluginsDirectory, "*.dll");

            foreach (string pluginFile in pluginFiles)
            {
                Assembly pluginAssembly = Assembly.LoadFrom(pluginFile);

                foreach (Type pluginType in pluginAssembly.GetTypes())
                {
                    if (typeof(IPlugin<int, string>).IsAssignableFrom(pluginType))
                    {
                        IPlugin<int, string> plugin = Activator.CreateInstance(pluginType) as IPlugin<int, string>;
                        if (plugin != null)
                        {
                            string pluginDescription = plugin.GetDescription();
                            string pluginName = plugin.GetName();

                            plugins.Add(pluginName, plugin);
                            pluginDescriptions.Add(pluginName, pluginDescription);

                            FileListBox.Items.Add(Path.GetFileNameWithoutExtension(pluginFile));
                            functionNameListBox.Items.Add(plugin.GetName());
                        }
                    }
                }
            }
        }

        public static string EncryptAdditionalData(string additionalData, string key)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
            string keyID = Convert.ToBase64String(hash);

            byte[] textBytes = Encoding.UTF8.GetBytes(additionalData);
            byte[] keyBytes = Encoding.UTF8.GetBytes(keyID);

            byte[] encryptedBytes = new byte[textBytes.Length];
            for (int i = 0; i < textBytes.Length; i++)
            {
                encryptedBytes[i] = (byte)((textBytes[i] + keyBytes[i % keyBytes.Length]) % 256);
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        private static string AddRandomHexCharacters(string hash)
        {
            int missingCharacters = 16 - hash.Length;
            missingCharacters = (int)Math.Ceiling((double)missingCharacters / 2) * 2;

            StringBuilder stringBuilder = new StringBuilder(hash);

            byte[] randomBytes = new byte[missingCharacters / 2];
            rngCsp.GetBytes(randomBytes);

            for (int i = 0; i < randomBytes.Length; i++)
            {
                string hexValue = randomBytes[i].ToString("X2");
                stringBuilder.Append(hexValue);
            }

            return stringBuilder.ToString();
        }

        public static string AddRandomHexCharactersForTest(string hash)
        {
            return AddRandomHexCharacters(hash);
        }


        private static string SubstituteAlphabet(string key)
        {
            Dictionary<char, char> substitutionMap = new Dictionary<char, char>()
            {
                {'0', 'B'},
                {'1', '5'},
                {'2', '1'},
                {'3', 'C'},
                {'4', '7'},
                {'5', 'D'},
                {'6', '9'},
                {'7', 'A'},
                {'8', '3'},
                {'9', 'E'},
                {'A', 'F'},
                {'B', '2'},
                {'C', '4'},
                {'D', '6'},
                {'E', '8'},
                {'F', '0'}
            };

            StringBuilder encryptedKey = new StringBuilder();

            foreach (char c in key)
            {
                if (substitutionMap.ContainsKey(c))
                {
                    encryptedKey.Append(substitutionMap[c]);
                }
                else
                {
                    encryptedKey.Append(c);
                }
            }

            return encryptedKey.ToString();
        }

        public static string SubstituteAlphabetForTest(string key)
        {
            return SubstituteAlphabet(key);
        }
    }
}

