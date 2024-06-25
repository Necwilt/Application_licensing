using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;


public static class ByteUtils
{
    public static byte[] StringToBytes(string str)
        {
            return Encoding.Unicode.GetBytes(str);
        }

    public static string BytesToString(byte[] bytes)
        {
            return Encoding.Unicode.GetString(bytes);
        }

    public static void SaveByteArrayToFile(string filePath, byte[] byteArray)
    {
        if (!File.Exists(filePath))
        {
            System.IO.Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }
        try
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                fileStream.Write(byteArray, 0, byteArray.Length);
            }
        }
        catch { }
    }

    public static byte[] ReadByteArrayFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException();
            //return null;
        }
        using (var fileStream = new FileStream(filePath, FileMode.Open))
        {
            var buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, buffer.Length);
            return buffer;
        }
    }

    public static string Encrypt(string plainText, string Key)
    {
        byte[] iv = new byte[16];
        byte[] array;

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                    {
                        streamWriter.Write(plainText);
                    }

                    array = memoryStream.ToArray();
                }
            }
        }

        return Convert.ToBase64String(array);
    }

    public static string Decrypt(string cipherText, string Key)
    {
        byte[] iv = new byte[16];
        byte[] buffer = Convert.FromBase64String(cipherText);

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }

    public static void ForceGarbageCollector() {
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    public static int MoveElementBackward<T>(List<T> list, int index)
    {
        if (list == null || index < 1 || index > list.Count - 1)
        {
            return index;
        }

        if (index > 0)
        {
            var element = list[index];
            list.RemoveAt(index);
            list.Insert(index - 1, element);
            return index - 1;
        }
        return index;
    }

    public static int MoveElementForward<T>(List<T> list, int index)
    {
        if (list == null || index < 0 || index > list.Count - 2)
        {
            return index;
        }

        if (index < list.Count - 1)
        {
            var element = list[index];
            list.RemoveAt(index);
            list.Insert(index + 1, element);
            return index + 1;
        }
        return index;
    }

}

