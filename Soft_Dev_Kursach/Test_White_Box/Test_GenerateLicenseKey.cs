using PluginInterfaces;
using Soft_Dev_Kursach;
using BitwiseShiftsHashPlug;
using HardDiskIdPlug;
using LicenseKeyValidator;
using MotherboardIdPlug;
using MultiplyAddHashPlug;
using ProcessorIdPlugin;
using SumOfSquaresHashPlug;
using System.Text.RegularExpressions;
using System.Security.Cryptography.Xml;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;

namespace Test_White_Box
{
    [TestClass]
    public class LicenseKeyGeneratorTests
    {
        WindowsDriver<WindowsElement> driver;
        string ExePath =
            @"C:\Users\nikit\source\repos\Soft_Dev_Kursach\Soft_Dev_Kursach\bin\x86\Release\net6.0-windows\Soft_Dev_Kursach.exe";
        [TestInitialize]
        public void Setup()
        {
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", ExePath);
            driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
        }
        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
        }

        [TestMethod]
        public void GenerateLicenseKey_GeneratesValidLicenseKey()
        {
            var form = driver.FindElementByAccessibilityId("KeyGenerator");

            string hardwareId = "HardwareId";
            string pluginName = "Побитовые сдвиги";
            var plugins = new Dictionary<string, IPlugin<int, string>>();
            string additionalData = "AdditionalData";

            var bitwiseShiftsHashPlug = new BitwiseShiftsHashPlugin();
            plugins.Add(bitwiseShiftsHashPlug.GetName(), bitwiseShiftsHashPlug);

            var multiplyAddHashPlug = new MultiplyAddHashPlugin();
            plugins.Add(multiplyAddHashPlug.GetName(), multiplyAddHashPlug);

            var sumOfSquaresHashPlug = new SumOfSquaresHashPlugin();
            plugins.Add(sumOfSquaresHashPlug.GetName(), sumOfSquaresHashPlug);

            // Act
            string licenseKey = LicenseKeyGenerator.GenerateLicenseKey(hardwareId, pluginName, plugins, additionalData);

            // Assert
            Assert.IsNotNull(licenseKey);
            Assert.IsTrue(licenseKey.Length > 0);

            Console.WriteLine($"Длина лицензионного ключа: {licenseKey.Length}");

            var IDflag = form.FindElementByAccessibilityId("radioButtonProcessor");
            IDflag.Click();

            var Hashflag = form.FindElementByAccessibilityId("BitwiseShifts");
            Hashflag.Click();

            var GenerateKey = form.FindElementByAccessibilityId("buttonGenerateKey");
            GenerateKey.Click();
        }

        [TestMethod]
        public void GenerateLicenseKey_GeneratesValidLicenseKeyTrueKey()
        {
            var form = driver.FindElementByAccessibilityId("KeyGenerator");

            string hardwareId = "HardwareId";
            string pluginName = "Побитовые сдвиги";
            var plugins = new Dictionary<string, IPlugin<int, string>>();
            string additionalData = "AdditionalData";

            var bitwiseShiftsHashPlug = new BitwiseShiftsHashPlugin();
            plugins.Add(bitwiseShiftsHashPlug.GetName(), bitwiseShiftsHashPlug);

            var multiplyAddHashPlug = new MultiplyAddHashPlugin();
            plugins.Add(multiplyAddHashPlug.GetName(), multiplyAddHashPlug);

            var sumOfSquaresHashPlug = new SumOfSquaresHashPlugin();
            plugins.Add(sumOfSquaresHashPlug.GetName(), sumOfSquaresHashPlug);

            // Act
            string licenseKey = LicenseKeyGenerator.GenerateLicenseKey(hardwareId, pluginName, plugins, additionalData);

            var textBox1 = form.FindElementByAccessibilityId("textBox1");
            var textBox2 = form.FindElementByAccessibilityId("textBox2");

            var IDflag = form.FindElementByAccessibilityId("radioButtonProcessor");
            IDflag.Click();

            var Hashflag = form.FindElementByAccessibilityId("BitwiseShifts");
            Hashflag.Click();

            var GenerateKey = form.FindElementByAccessibilityId("buttonGenerateKey");
            GenerateKey.Click();



            textBox2.Click();
            textBox2.Click();
            textBox2.SendKeys(textBox1.Text);


            var CheckKey = form.FindElementByAccessibilityId("CheckKey");
            CheckKey.Click();

            Assert.AreEqual(textBox1.Text, textBox2.Text);
        }

        [TestMethod]
        public void GenerateLicenseKey_GeneratesValidLicenseKeyNoFlag1()
        {
            var form = driver.FindElementByAccessibilityId("KeyGenerator");

            string hardwareId = "HardwareId";
            string pluginName = "Побитовые сдвиги";
            var plugins = new Dictionary<string, IPlugin<int, string>>();
            string additionalData = "AdditionalData";

            var bitwiseShiftsHashPlug = new BitwiseShiftsHashPlugin();
            plugins.Add(bitwiseShiftsHashPlug.GetName(), bitwiseShiftsHashPlug);

            var multiplyAddHashPlug = new MultiplyAddHashPlugin();
            plugins.Add(multiplyAddHashPlug.GetName(), multiplyAddHashPlug);

            var sumOfSquaresHashPlug = new SumOfSquaresHashPlugin();
            plugins.Add(sumOfSquaresHashPlug.GetName(), sumOfSquaresHashPlug);

            // Act
            string licenseKey = LicenseKeyGenerator.GenerateLicenseKey(hardwareId, pluginName, plugins, additionalData);

            // Assert
            //Assert.IsNotNull(licenseKey);
            //Assert.IsTrue(licenseKey.Length > 0);

            var IDflag = form.FindElementByAccessibilityId("radioButtonProcessor");
            IDflag.Click();

            var GenerateKey = form.FindElementByAccessibilityId("buttonGenerateKey");
            GenerateKey.Click();

            var textBox1 = form.FindElementByAccessibilityId("textBox1");

            Assert.IsTrue(textBox1.Text.Length > 0);
        }

        [TestMethod]
        public void GenerateLicenseKey_GeneratesValidLicenseKeyNoFlag2()
        {
            var form = driver.FindElementByAccessibilityId("KeyGenerator");

            string hardwareId = "HardwareId";
            string pluginName = "Побитовые сдвиги";
            var plugins = new Dictionary<string, IPlugin<int, string>>();
            string additionalData = "AdditionalData";

            var bitwiseShiftsHashPlug = new BitwiseShiftsHashPlugin();
            plugins.Add(bitwiseShiftsHashPlug.GetName(), bitwiseShiftsHashPlug);

            var multiplyAddHashPlug = new MultiplyAddHashPlugin();
            plugins.Add(multiplyAddHashPlug.GetName(), multiplyAddHashPlug);

            var sumOfSquaresHashPlug = new SumOfSquaresHashPlugin();
            plugins.Add(sumOfSquaresHashPlug.GetName(), sumOfSquaresHashPlug);

            // Act
            string licenseKey = LicenseKeyGenerator.GenerateLicenseKey(hardwareId, pluginName, plugins, additionalData);

            // Assert
            //Assert.IsNotNull(licenseKey);
            //Assert.IsTrue(licenseKey.Length > 0);

            var Hashflag = form.FindElementByAccessibilityId("BitwiseShifts");
            Hashflag.Click();

            var GenerateKey = form.FindElementByAccessibilityId("buttonGenerateKey");
            GenerateKey.Click();

            var textBox1 = form.FindElementByAccessibilityId("textBox1");

            Assert.IsTrue(textBox1.Text.Length > 0);
        }

        [TestMethod]
        public void GenerateLicenseKey_GeneratesValidLicenseKeyFileSpawned()
        {
            var form = driver.FindElementByAccessibilityId("KeyGenerator");

            string hardwareId = "HardwareId";
            string pluginName = "Побитовые сдвиги";
            var plugins = new Dictionary<string, IPlugin<int, string>>();
            string additionalData = "AdditionalData";

            var bitwiseShiftsHashPlug = new BitwiseShiftsHashPlugin();
            plugins.Add(bitwiseShiftsHashPlug.GetName(), bitwiseShiftsHashPlug);

            var multiplyAddHashPlug = new MultiplyAddHashPlugin();
            plugins.Add(multiplyAddHashPlug.GetName(), multiplyAddHashPlug);

            var sumOfSquaresHashPlug = new SumOfSquaresHashPlugin();
            plugins.Add(sumOfSquaresHashPlug.GetName(), sumOfSquaresHashPlug);

            // Act
            string licenseKey = LicenseKeyGenerator.GenerateLicenseKey(hardwareId, pluginName, plugins, additionalData);

            var textBoxFilePath = form.FindElementByAccessibilityId("textBoxFilePath");
            textBoxFilePath.SendKeys("D:\\test\\my.txt");

            var IDflag = form.FindElementByAccessibilityId("radioButtonProcessor");
            IDflag.Click();

            var Hashflag = form.FindElementByAccessibilityId("BitwiseShifts");
            Hashflag.Click();

            var GenerateKey = form.FindElementByAccessibilityId("buttonGenerateKey");
            GenerateKey.Click();

            Assert.IsTrue(File.Exists(textBoxFilePath.Text), $"Файл не найден по пути: {textBoxFilePath.Text}");
        }

        [TestMethod]
        public void GenerateLicenseKey_GeneratesValidLicenseKeyFileNotSpawned()
        {
            var form = driver.FindElementByAccessibilityId("KeyGenerator");

            string hardwareId = "HardwareId";
            string pluginName = "Побитовые сдвиги";
            var plugins = new Dictionary<string, IPlugin<int, string>>();
            string additionalData = "AdditionalData";

            var bitwiseShiftsHashPlug = new BitwiseShiftsHashPlugin();
            plugins.Add(bitwiseShiftsHashPlug.GetName(), bitwiseShiftsHashPlug);

            var multiplyAddHashPlug = new MultiplyAddHashPlugin();
            plugins.Add(multiplyAddHashPlug.GetName(), multiplyAddHashPlug);

            var sumOfSquaresHashPlug = new SumOfSquaresHashPlugin();
            plugins.Add(sumOfSquaresHashPlug.GetName(), sumOfSquaresHashPlug);

            // Act
            string licenseKey = LicenseKeyGenerator.GenerateLicenseKey(hardwareId, pluginName, plugins, additionalData);

            var textBoxFilePath = form.FindElementByAccessibilityId("textBoxFilePath");
            textBoxFilePath.SendKeys("F:\\test\\my.txt");

            var IDflag = form.FindElementByAccessibilityId("radioButtonProcessor");
            IDflag.Click();

            var Hashflag = form.FindElementByAccessibilityId("BitwiseShifts");
            Hashflag.Click();

            var GenerateKey = form.FindElementByAccessibilityId("buttonGenerateKey");
            GenerateKey.Click();

            Assert.IsTrue(File.Exists(textBoxFilePath.Text), $"Файл не найден по пути: {textBoxFilePath.Text}");
        }

        [TestMethod]
        public void EncryptAdditionalData()
        {
            string additionalData = "AdditionalData";
            string key = "wC/fKlFJwX2hp53+ezuwOw==";
            string expectedEncryptedData = "bLC9nMzVvL3TnJ64wrs=";

            // Act
            string encryptedData = LicenseKeyGenerator.EncryptAdditionalData(additionalData, key);

            // Assert
            Assert.AreEqual(expectedEncryptedData, encryptedData);

            Console.WriteLine($"Шифрованные данные: {encryptedData}");
        }

        [TestMethod]
        public void SubstituteAlphabet_ReplacesCharacters()
        {
            // Arrange
            string input = "EA3F";

            // Act
            string result = LicenseKeyGenerator.AddRandomHexCharactersForTest(input);

            // Assert
            Assert.IsTrue(result.Length == 16);

            Console.WriteLine($"Длина ключа: {result.Length}");
        }

        [TestMethod]
        public void DecryptAdditionalData_DecryptsCorrectly()
        {
            // Arrange
            string encryptedText = "bL4EnMzVvLCTnJ97wrs=";
            string key = "wC/fKlFJwX2hp53+ezuwOw==";

            // Act
            string decryptedText = LicenseKeyValid.DecryptAdditionalData(encryptedText, key);

            // Assert
            string expectedDecryptedText = "AdditionalData";
            Assert.AreEqual(expectedDecryptedText, decryptedText);

            Console.WriteLine($"Расшифрованный текст: {decryptedText}");
        }

        [TestMethod]
        public void SubstituteAlphabet_SuccessfulSubstitution()
        {
            // Arrange
            string inputKey = "0123456789ABCDEF";
            string expectedOutput = "B51C7D9A3EF24680";

            // Act
            string result = LicenseKeyGenerator.SubstituteAlphabetForTest(inputKey);

            // Assert
            Assert.AreEqual(expectedOutput, result);

            Console.WriteLine($"Полученная строка: {result}");
        }

        [TestMethod]
        public void SubstituteAlphabet_NoChange()
        {
            // Arrange
            string inputKey = "XYZ";
            string expectedOutput = "XYZ";

            // Act
            string result = LicenseKeyGenerator.SubstituteAlphabetForTest(inputKey);

            // Assert
            Assert.AreEqual(expectedOutput, result);

            Console.WriteLine($"Полученная строка: {result}");
        }

        [TestMethod]
        public void SubstituteAlphabet_ReturnsEmptyString()
        {
            // Arrange
            string inputKey = string.Empty;

            // Act
            string result = LicenseKeyGenerator.SubstituteAlphabetForTest(inputKey);

            // Assert
            Assert.AreEqual(string.Empty, result);

            Console.WriteLine($"Полученная строка: {result}");
        }

        [TestMethod]
        public void BitwiseShiftsHash()
        {
            // Arrange
            string input = "InputString";
            int expectedHash = 1583258125, actualHash;

            // Act
            var bitwiseShiftsHashPlug = new BitwiseShiftsHashPlugin();
            actualHash = bitwiseShiftsHashPlug.Execute(input);

            // Assert
            Assert.AreEqual(expectedHash, actualHash);

            Console.WriteLine($"Полученное хеш-значение: {actualHash}");
        }

        [TestMethod]
        public void multiplyAddHashPlug()
        {
            // Arrange
            string input = "InputString";
            int expectedHash = -118844513, actualHash;

            // Act
            var multiplyAddHashPlug = new MultiplyAddHashPlugin();
            actualHash = multiplyAddHashPlug.Execute(input);

            // Assert
            Assert.AreEqual(expectedHash, actualHash);

            Console.WriteLine($"Полученное хеш-значение: {actualHash}");
        }

        [TestMethod]
        public void sumOfSquaresHashPlug()
        {
            // Arrange
            string input = "InputString";
            int expectedHash = 124193, actualHash;

            // Act
            var sumOfSquaresHashPlug = new SumOfSquaresHashPlugin();
            actualHash = sumOfSquaresHashPlug.Execute(input);

            // Assert
            Assert.AreEqual(expectedHash, actualHash);

            Console.WriteLine($"Полученное хеш-значение: {actualHash}");
        }
    }
}