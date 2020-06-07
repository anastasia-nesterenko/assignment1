using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Converter.Models
{
    public class Base64Converter
    {
        public string Base64(string str)
        {
            var bits = string.Empty;
            foreach (var character in str)
            {
                bits += Convert.ToString(character, 2).PadLeft(8, '0');
            }

            string base64 = string.Empty;

            const byte threeOctets = 24;
            var octetsTaken = 0;
            while (octetsTaken < bits.Length)
            {
                var octets = bits.Skip(octetsTaken).Take(threeOctets).ToList();

                const byte sixBits = 6;
                int hextetsTaken = 0;
                while (hextetsTaken < octets.Count())
                {
                    var chunk = octets.Skip(hextetsTaken).Take(sixBits);
                    hextetsTaken += sixBits;

                    var bitString = chunk.Aggregate(string.Empty, (current, currentBit) => current + currentBit);

                    if (bitString.Length < 6)
                    {
                        bitString = bitString.PadRight(6, '0');
                    }
                    var singleInt = Convert.ToInt32(bitString, 2);

                    base64 += Base64Letters[singleInt];
                }

                octetsTaken += threeOctets;
            }

            //  When we lack 1 or 2 octects out of our 24 bit string, we need to pad the end of the base64 string with =
            for (var i = 0; i < (bits.Length % 3); i++)
            {
                base64 += "=";
            }

            return base64;
        }
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
    }
}
