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
                    Console.WriteLine($"Decrypted data: {decrypted}"); 
                }
            }
            catch (Exception exp) 
            { 
                Console.WriteLine(exp.Message); 
            }

            Console.WriteLine("Enter number that needs to be encrypted");
            int number = int.Parse(Console.ReadLine());

            NumberConverter numberConverter = new NumberConverter();
            Console.Write("Binary= "); 
            for (int i = numberConverter.DecimaltoBinary(number).Length-1; i >= 0; i--)
            {
                Console.Write(numberConverter.DecimaltoBinary(number)[i]); 
            }
            Console.WriteLine();

            Console.Write("Octal= ");
            for (int i = numberConverter.DecimalToOctal(number).Length-1; i >= 0; i--)
            {
                Console.Write(numberConverter.DecimalToOctal(number)[i]);
            }
            Console.WriteLine();

            Console.WriteLine($"Hexadecimal= { numberConverter.DecimalToHexadecimal(number)}");

            Console.WriteLine("Enter text that needs to be encrypted");
            Base64Converter base64Converter = new Base64Converter();
            string text = Console.ReadLine();
            Console.WriteLine($"Base64= {base64Converter.Base64(text)}");

            Console.ReadLine();
        }

    }
}
