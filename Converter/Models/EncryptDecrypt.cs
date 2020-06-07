using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Converter.Models
{
    public class EncryptDecrypt
    {

        public byte[] Encrypt(string data, byte[] Key, byte[] IV) {
            byte[] encrypted; 
            // Create a new AesManaged.    
            using (AesManaged aes = new AesManaged()) 
            { 
                // Create encryptor 
                ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV); 
                // Create MemoryStream 
                using (MemoryStream ms = new MemoryStream()) 
                { 
                    // Create crypto stream using the CryptoStream class. This class is the key to encryption    
                    // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
                    // to encrypt    
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    { 
                        // Create StreamWriter and write data to a stream   
                        using (StreamWriter sw = new StreamWriter(cs)) sw.Write(data); 
                        encrypted = ms.ToArray(); } 
                } 
            } 
            // Return encrypted data   
            return encrypted;

        }

        public string Decrypt(byte[] data, byte[] Key, byte[] IV)
        {
            string plaintext = null; 
            // Create AesManaged 
            using (AesManaged aes = new AesManaged()) 
            { 
                // Create a decryptor
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                // Create the streams used for decryption.    
                using (MemoryStream ms = new MemoryStream(data)) 
                { 
                    // Create crypto stream    
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    { 
                        // Read crypto stream    
                        using (StreamReader reader = new StreamReader(cs)) 
                            plaintext = reader.ReadToEnd(); 
                    }
                }
            }
            return plaintext;

        }
    }
}
