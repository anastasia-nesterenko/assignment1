using System;
using System.Collections.Generic;
using System.Text;

namespace Converter.Models
{
    public class NumberConverter
    {
        public int[] DecimaltoBinary(int n) {
            int[] a = new int[10];
            int i;
            for ( i = 0; n > 0; i++) 
            { 
                a[i] = n % 2; n = n / 2; 
            }
            
            return a;
        }

        public string DecimalToHexadecimal(int dec)
        {
            if (dec < 1) return "0";
            int hex = dec; string hexStr = string.Empty;
            while (dec > 0)
            {
                hex = dec % 16;
                if (hex < 10) 
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex + 48).ToString());
                else hexStr = hexStr.Insert(0, Convert.ToChar(hex + 55).ToString());
                dec /= 16;
            }
            return hexStr;
        }

        public int[] DecimalToOctal(int n)
        {
            int[] a = new int[10];
            int i;
            for (i = 0; n > 0; i++) 
            { 
                a[i] = n % 8; n = n / 8; 
            }
            
            return a;
        }

    }
}
