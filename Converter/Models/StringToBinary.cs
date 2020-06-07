using System;
using System.Collections.Generic;
using System.Text;

namespace Converter.Models
{
    public class StringToBinary
    {
        public string StrToBinary(String data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in data.ToCharArray()) 
            { 
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0')); 
            }
            return(sb.ToString());
        }

        public string BinaryToStr(String data)
        {
            List<Byte> byteList = new List<Byte>();
            for (int i = 0; i < data.Length; i += 8) 
            { 
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2)); 
            }

            return Encoding.ASCII.GetString(byteList.ToArray());
        }

    }
}
