using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Converter.Models
{
    public class Base64Converter
    {
        private static readonly char[] Base64Letters = new[]
                                        {
                                              'A'
                                            , 'B'
                                            , 'C'
                                            , 'D'
                                            , 'E'
                                            , 'F'
                                            , 'G'
                                            , 'H'
                                            , 'I'
                                            , 'J'
                                            , 'K'
                                            , 'L'
                                            , 'M'
                                            , 'N'
                                            , 'O'
                                            , 'P'
                                            , 'Q'
                                            , 'R'
                                            , 'S'
                                            , 'T'
                                            , 'U'
                                            , 'V'
                                            , 'W'
                                            , 'X'
                                            , 'Y'
                                            , 'Z'
                                            , 'a'
                                            , 'b'
                                            , 'c'
                                            , 'd'
                                            , 'e'
                                            , 'f'
                                            , 'g'
                                            , 'h'
                                            , 'i'
                                            , 'j'
                                            , 'k'
                                            , 'l'
                                            , 'm'
                                            , 'n'
                                            , 'o'
                                            , 'p'
                                            , 'q'
                                            , 'r'
                                            , 's'
                                            , 't'
                                            , 'u'
                                            , 'v'
                                            , 'w'
                                            , 'x'
                                            , 'y'
                                            , 'z'
                                            , '0'
                                            , '1'
                                            , '2'
                                            , '3'
                                            , '4'
                                            , '5'
                                            , '6'
                                            , '7'
                                            , '8'
                                            , '9'
                                            , '+'
                                            , '/'
                                        };

        public string Base64(string str) {
            StringToBinary stringToBinary = new StringToBinary();
            string binary = stringToBinary.StrToBinary(str);
            
            //count number of paddings 
            List<string> test = new List<string>();
            int paddings = binary.Length % 6;
            if (paddings > 0) {
                paddings = (6 - paddings) / 2;
            }
             
            //splitting to 6-bits 
            while (binary!="") {
                if (binary.Length > 5)
                    test.Add(binary.Substring(0, 6));
                else
                {
                    string padding = binary.Substring(0, binary.Length).PadRight(6, '0');
                    test.Add(padding);
                    break;
                }
                binary = binary.Substring(6);
            }
            
            //getting decimal from 6-bits
            List<int> decimals = new List<int>();
            foreach (string tt in test)
            {
                int num = int.Parse(tt);
                int binVal, decVal = 0, baseVal = 1, rem;
                while (num > 0)
                {
                    rem = num % 10;
                    decVal = decVal + rem * baseVal;
                    num = num / 10;
                    baseVal = baseVal * 2;
                }
                decimals.Add(decVal);

            }

            //getting base64
            List<char> chars = new List<char>();
            foreach (int item in decimals)
            {
                chars.Add(Base64Letters[item]);
            }
            string result = new string(chars.ToArray());

            //adding '=' if required
            for (var i = 0; i < paddings; i++)
            {
                result += "=";
            }

            return result;
        }
    }
}
