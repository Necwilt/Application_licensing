using BitwiseShiftsHashPlug;
using GetID;
using MultiplyAddHashPlug;
using SumOfSquaresHashPlug;
using System.Security.Cryptography;
using System.Text;

namespace LicenseKeyValidator
{
    public class LicenseKeyValid
    {
        private static string SubstituteAlphabet(string key)
        {
            Dictionary<char, char> substitutionMap = new Dictionary<char, char>()
            {
                {'B', '0'},
                {'5', '1'},
                {'1', '2'},
                {'C', '3'},
                {'7', '4'},
                {'D', '5'},
                {'9', '6'},
                {'A', '7'},
                {'3', '8'},
                {'E', '9'},
                {'F', 'A'},
                {'2', 'B'},
                {'4', 'C'},
                {'6', 'D'},
                {'8', 'E'},
                {'0', 'F'}
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

        public static string DecryptAdditionalData(string encryptedText, string key)
        {
            string _encryptedText = SubstituteAlphabet(encryptedText);
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
            string keyID = Convert.ToBase64String(hash);

            byte[] encryptedBytes = Convert.FromBase64String(_encryptedText);
            byte[] keyBytes = Encoding.UTF8.GetBytes(keyID);

            byte[] decryptedBytes = new byte[encryptedBytes.Length];
            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                decryptedBytes[i] = (byte)((encryptedBytes[i] - keyBytes[i % keyBytes.Length]));
            }

            return Encoding.UTF8.GetString(decryptedBytes);
        }

        public static bool ValidateLicenseKey(string licenseKey)
        {
            string processorId = IdGetter.GetProcessorID();
            string hardDiskId = IdGetter.GetDiskID();
            string motherboardId = IdGetter.GetMotherBoardID();

            SumOfSquaresHashPlugin sumOfSquaresHashPlug = new SumOfSquaresHashPlugin();
            BitwiseShiftsHashPlugin bitwiseShiftsHashPlug = new BitwiseShiftsHashPlugin();
            MultiplyAddHashPlugin multiplyAddHashPlug = new MultiplyAddHashPlugin();

            // Вычисление хешей
            int hashProcessor1 = BitwiseShiftsHashPlugin.BitwiseShiftsHash(processorId);
            int hashProcessor2 = MultiplyAddHashPlugin.MultiplyAddHash(processorId);
            int hashProcessor3 = SumOfSquaresHashPlugin.SumOfSquaresHash(processorId);

            int hashHardDisk1 = BitwiseShiftsHashPlugin.BitwiseShiftsHash(hardDiskId);
            int hashHardDisk2 = MultiplyAddHashPlugin.MultiplyAddHash(hardDiskId);
            int hashHardDisk3 = SumOfSquaresHashPlugin.SumOfSquaresHash(hardDiskId);

            int hashMotherboard1 = BitwiseShiftsHashPlugin.BitwiseShiftsHash(motherboardId);
            int hashMotherboard2 = MultiplyAddHashPlugin.MultiplyAddHash(motherboardId);
            int hashMotherboard3 = SumOfSquaresHashPlugin.SumOfSquaresHash(motherboardId);

            string decryptedKey = SubstituteAlphabet(licenseKey);

            return decryptedKey.StartsWith(hashProcessor1.ToString("X"))
                || decryptedKey.StartsWith(hashProcessor2.ToString("X"))
                || decryptedKey.StartsWith(hashProcessor3.ToString("X"))
                || decryptedKey.StartsWith(hashHardDisk1.ToString("X"))
                || decryptedKey.StartsWith(hashHardDisk2.ToString("X"))
                || decryptedKey.StartsWith(hashHardDisk3.ToString("X"))
                || decryptedKey.StartsWith(hashMotherboard1.ToString("X"))
                || decryptedKey.StartsWith(hashMotherboard2.ToString("X"))
                || decryptedKey.StartsWith(hashMotherboard3.ToString("X"));

        }
    }
}
