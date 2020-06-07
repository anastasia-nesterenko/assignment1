using Converter.Models;
using System;
using System.Security.Cryptography;

namespace Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text that needs to be converted");
            string data = Console.ReadLine();

            StringToBinary sb = new StringToBinary();
            string binary = sb.StrToBinary(data);
            string original = sb.BinaryToStr(binary);

            Console.WriteLine($"Binary of {data} = {binary}");
            
            Console.WriteLine($"Binary {binary} to String : = {original}");

            Console.WriteLine("Enter text that needs to be encrypted");
            string data2 = Console.ReadLine();

            try
            {
                // Create Aes that generates a new key and initialization vector (IV).   
                using (AesManaged aes = new AesManaged()) 
                {
                    EncryptDecrypt encryptDecrypt = new EncryptDecrypt();
                    // Encrypt string    
                    byte[] encrypted = encryptDecrypt.Encrypt(data2, aes.Key, aes.IV); 
                    // Print encrypted string   
                    Console.WriteLine($"Encrypted data: {System.Text.Encoding.UTF8.GetString(encrypted)}"); 
                    // Decrypt the bytes to a string
                    string decrypted = encryptDecrypt.Decrypt(encrypted, aes.Key, aes.IV); 
                    // Print decrypted string
                    Console.WriteLine($"Decrypted data: {decrypted}"); }
            }
            catch (Exception exp) { Console.WriteLine(exp.Message); }
            Console.ReadLine();



        }

    }
}
