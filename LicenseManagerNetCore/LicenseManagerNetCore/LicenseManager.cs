using LicenseKeyValidator;
using Microsoft.Win32;
using System.Reflection;
using System.Runtime.InteropServices;

namespace LicManager
{
    public interface IFunctionalityManager
    {
        void EnableFunctionality();
        void DisableFunctionality();
    }

    public class MyLicenseManager : IFunctionalityManager
    {
        private string keyPath = GetKeyPath();
        private const string valueName = "LicenseKey";
        public const string KEY = "wC/fKlFJwX2hp53+ezuwOw==";

        public string LicenseKey { get; private set; }
        public bool IsLicenseValid { get; private set; }
        public bool IsAdditionalFunctionalityEnabled { get; private set; }
        public string EncryptedData { get; }

        private IFunctionalityManager functionalityManager;

        public MyLicenseManager(IFunctionalityManager manager)
        {
            functionalityManager = manager;
            LicenseKey = ReadLicenseKeyFromRegistry() ?? string.Empty;
            IsLicenseValid = ValidateLicenseKey(LicenseKey, KEY);
            EnableDisableFunctionality();
        }

        private static string GetKeyPath()
        {
            string keyPath = string.Empty;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                string appName = Assembly.GetEntryAssembly()?.GetName().Name;
                if (string.IsNullOrEmpty(appName))
                {
                    keyPath = "Ошибка получения имени файла";
                }
                else
                {
                    keyPath = $"SOFTWARE\\{appName}";
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string appName = Assembly.GetEntryAssembly()?.GetName().Name;

                if (string.IsNullOrEmpty(appName))
                {
                    keyPath = "Ошибка получения имени файла";
                }
                else
                {
                    keyPath = Path.Combine(homeDirectory, $".{appName}_config");
                }
            }

            return keyPath;
        }

        public void SetLicenseKey(string licenseKey, string key)
        {
            LicenseKey = licenseKey;
            IsLicenseValid = ValidateLicenseKey(licenseKey, KEY);
            WriteLicenseKeyToRegistry(LicenseKey);
            EnableDisableFunctionality();
        }

        public string GetEncryptedDataFromKey(string licenseKey, string key)
        {
            string encryptedData = licenseKey.Substring(16);
            string decryptedData = LicenseKeyValid.DecryptAdditionalData(encryptedData, KEY);

            return decryptedData;
        }

        public void RemoveLicenseKey()
        {
            LicenseKey = null;
            IsLicenseValid = false;
            DeleteLicenseKeyFromRegistry();
            EnableDisableFunctionality();
        }

        private string ReadLicenseKeyFromRegistry()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                try
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
                    {
                        return key?.GetValue(valueName)?.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при чтении ключа из реестра: " + ex.Message);
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                try
                {
                    string filePath = Path.Combine(keyPath, "license.key");

                    if (File.Exists(filePath))
                    {
                        return File.ReadAllText(filePath);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при чтении лицензионного ключа: " + ex.Message);
                }

            }
            return null;
        }

        private void WriteLicenseKeyToRegistry(string licenseKey)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                try
                {
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                    {
                        key.SetValue(valueName, licenseKey);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при записи ключа в реестр: " + ex.Message);
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                try
                {
                    if (!Directory.Exists(keyPath))
                    {
                        Directory.CreateDirectory(keyPath);
                    }

                    string filePath = Path.Combine(keyPath, "license.key");
                    File.WriteAllText(filePath, licenseKey);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при записи лицензионного ключа: " + ex.Message);
                }
            }
        }

        private bool ValidateLicenseKey(string licenseKey, string key)
        {
            bool isValid = LicenseKeyValid.ValidateLicenseKey(licenseKey);

            if (isValid)
            {
                string encryptedDateStr = GetEncryptedDataFromKey(licenseKey, key).ToString();
                DateTime encryptedDate = DateTime.Parse(encryptedDateStr);
                isValid = encryptedDate >= DateTime.Now;
            }

            return isValid;
        }

        private void DeleteLicenseKeyFromRegistry()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                try
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath, true))
                    {
                        key?.DeleteValue(valueName, false);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при удалении ключа из реестра: " + ex.Message);
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                try
                {
                    string filePath = Path.Combine(keyPath, "license.key");

                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при удалении лицензионного ключа: " + ex.Message);
                }
            }
        }

        private void EnableDisableFunctionality()
        {
            if (IsLicenseValid)
            {
                functionalityManager.EnableFunctionality();
            }
            else
            {
                functionalityManager.DisableFunctionality();
            }
        }

        public void EnableFunctionality()
        {
            IsAdditionalFunctionalityEnabled = true;
        }

        public void DisableFunctionality()
        {
            IsAdditionalFunctionalityEnabled = false;
        }

    }
}
