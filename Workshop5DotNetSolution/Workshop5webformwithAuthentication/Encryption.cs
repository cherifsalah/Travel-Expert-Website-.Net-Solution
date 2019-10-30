using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Workshop5webformwithAuthentication
{
    internal static class Encryption
    {
        //get encrypted value of text 
        internal static string GetEncyptedValue(string text, string hash)
        {
            string encryptedvalue;
            byte[] data = UTF8Encoding.UTF8.GetBytes(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDES =
                            new TripleDESCryptoServiceProvider()
                            {
                                Key = key,
                                Mode = CipherMode.ECB,
                                Padding = PaddingMode.PKCS7
                            }
                      )
                {
                    ICryptoTransform transform = tripleDES.CreateEncryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                    encryptedvalue = Convert.ToBase64String(result, 0, result.Length);
                }

            }
            return encryptedvalue;

        }
        //get decrypted value of text
        internal static string GetDecryptedValue(string textencrypted, string hash)
        {
            string textDecrypted;
            byte[] data = Convert.FromBase64String(textencrypted);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDES =
                            new TripleDESCryptoServiceProvider()
                            {
                                Key = key,
                                Mode = CipherMode.ECB,
                                Padding = PaddingMode.PKCS7
                            }
                      )
                {
                    ICryptoTransform transform = tripleDES.CreateDecryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                    textDecrypted = UTF8Encoding.UTF8.GetString(result);

                }
            }
            return textDecrypted;

        }

    }
}