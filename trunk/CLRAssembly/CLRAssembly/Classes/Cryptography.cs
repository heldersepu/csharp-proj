using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace CLRAssembly
{
    public sealed class Cryptography
    {
        public static string Encrypt(string input, string dKey)
        {
            try
            {
                return Convert.ToBase64String(EncryptStringToBytes(input, Encoding.Default.GetBytes(dKey)));
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string Decrypt(string input, string dKey)
        {
            try
            {
                return DecryptStringFromBytes(Convert.FromBase64String(input), Encoding.Default.GetBytes(dKey));
            }
            catch (Exception)
            {
                return "";
            }
        }

        #region "    Private Functions    "
        private static byte[] EncryptStringToBytes(string plainText, byte[] Key)
        {
            // Check arguments.
            if ((plainText == null) || (plainText.Length <= 0))
            {
                throw (new ArgumentNullException("plainText"));
            }
            if ((Key == null) || (Key.Length <= 0))
            {
                throw (new ArgumentNullException("Key"));
            }
            // Create an RijndaelManaged object
            // with the specified key and IV.
            RijndaelManaged rijAlg = new RijndaelManaged();
            rijAlg.Key = Key;
            rijAlg.Mode = CipherMode.ECB;
            byte[] encrypted = null;
            // Create a decrytor to perform the stream transform.
            ICryptoTransform encryptor = rijAlg.CreateEncryptor();
            // Create the streams used for encryption.
            encrypted = encryptor.TransformFinalBlock(Encoding.Default.GetBytes(plainText), 0, plainText.Length); //msEncrypt.ToArray
            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }       

        private static string DecryptStringFromBytes(byte[] cipherText, byte[] Key)
        {
            // Check arguments.
            if ((cipherText == null) || (cipherText.Length <= 0))
            {
                throw (new ArgumentNullException("cipherText"));
            }
            if ((Key == null) || (Key.Length <= 0))
            {
                throw (new ArgumentNullException("Key"));
            }
            // Create an RijndaelManaged object
            // with the specified key and IV.
            RijndaelManaged rijAlg = new RijndaelManaged();
            rijAlg.Key = Key;
            rijAlg.Mode = CipherMode.ECB;
            string plaintext = null;
            // Create a decrytor to perform the stream transform.
            ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

            // Create the streams used for decryption.
            MemoryStream msDecrypt = new MemoryStream(cipherText);
            CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            StreamReader srDecrypt = new StreamReader(csDecrypt);
            // Read the decrypted bytes from the decrypting stream
            // and place them in a string.
            plaintext = srDecrypt.ReadToEnd();
            return plaintext;
        }
        #endregion
    }

}
