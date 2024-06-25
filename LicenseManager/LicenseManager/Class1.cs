using LicenseKeyValidator;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Reflection;

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

        public string LicenseKey { get; private set; }
        public bool IsLicenseValid { get; private set; }
        public bool IsAdditionalFunctionalityEnabled { get; private set; }
        public string EncryptedData { get; }

        private IFunctionalityManager functionalityManager;


        public MyLicenseManager(IFunctionalityManager manager)
        {
            functionalityManager = manager;
            LicenseKey = ReadLicenseKeyFromRegistry();
            IsLicenseValid = LicenseKeyValid.ValidateLicenseKey(LicenseKey);
            EnableDisableFunctionality();
        }

        private static string GetKeyPath()
        {
            // Получаем имя исполняемого файла приложения без расширения
            string appName = Assembly.GetEntryAssembly()?.GetName().Name;
            if (string.IsNullOrEmpty(appName))
            {
                return "Ошибка получения имени файла";
            }

            // Формируем путь на основе имени приложения
            return $"SOFTWARE\\{appName}";
        }

        public void SetLicenseKey(string licenseKey)
        {
            LicenseKey = licenseKey;
            IsLicenseValid = ValidateLicenseKey(licenseKey);
            WriteLicenseKeyToRegistry(LicenseKey);
            KeyActivation(licenseKey);
            EnableDisableFunctionality();
        }

        public void RemoveLicenseKey()
        {
            LicenseKey = null;
            IsLicenseValid = false;
            DeleteLicenseKeyFromRegistry();
            EnableDisableFunctionality();
        }

        
        private void KeyActivation(string licenseKey)
        {

            string connectionString = "Server= localhost; Database=licensekeys; port = 3306; UserId=root; Charset=utf8mb4;";
            int duration = 0;
            bool isActive = true;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT IsActive FROM LicKeys WHERE LicenseKey = @LicenseKey";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseKey", licenseKey);
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        isActive = Convert.ToBoolean(result);
                    }
                }
            }

            if (isActive == false)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Duration FROM LicKeys WHERE LicenseKey = @LicenseKey";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseKey", licenseKey);
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            duration = Convert.ToInt32(result);
                        }
                    }
                }


                DateTime activationDate = DateTime.Now;
                DateTime expirationDate = activationDate.AddDays(duration);

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query2 = "UPDATE LicKeys SET ActivationDate = @ActivationDate, ExpirationDate = @ExpirationDate, IsActive = true WHERE LicenseKey = @LicenseKey";
                    using (MySqlCommand command = new MySqlCommand(query2, connection))
                    {
                        command.Parameters.AddWithValue("@ActivationDate", activationDate);
                        command.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                        command.Parameters.AddWithValue("@LicenseKey", licenseKey);
                        command.Parameters.AddWithValue("@IsActive", isActive);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private string ReadLicenseKeyFromRegistry()
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
                return null;
            }
        }

        private int WriteLicenseKeyToRegistry(string licenseKey)
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
            return 1;
        }

        private bool ValidateLicenseKey(string licenseKey)
        {
            bool isValid = LicenseKeyValid.ValidateLicenseKey(licenseKey);

            return isValid;
        }

        private void DeleteLicenseKeyFromRegistry()
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
