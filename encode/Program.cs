﻿using System;
using System.Collections.Generic;
using System.Text;

namespace encode
{
    class Program
    {
        static void Main(string[] args)
        {

            ///public static string Encode(byte[] source)

            var input = new byte[] { 0x6A, 0x77, 0xC4, 0x6A, 0x77, 0xC4, 0x6A, 0x77, 0xC4, 0x6A, 0x77, 0xC4, 0x6A, 0x77, 0xC4, 0x6A, 0x77, 0xC4, 0x6A, 0x77, 0xC4, 0x6A, 0x77, 0xC4, 0x6A, 0x77, 0xC4, 0x6A, 0x77, 0xC4, };
            Console.WriteLine(Encode(input));
            
        }

        public static string Encode(byte[] source)
        {
            
            // variable initialization
            string eightBitString = "";
            string result = "";
            

            foreach (var b in source)
            {

                eightBitString = eightBitString + convertToBinary(b);
                
            }
            string temp;

            while (eightBitString != "")

            {
                temp = eightBitString.Substring(0, 6);
                temp = convertToDecimal(temp);
                result += referenceTable[temp];
                eightBitString = eightBitString.Substring(6, eightBitString.Length - 6);

            }

            //result = result + referenceTable[convertToDecimal(eightBitString)];

            return result.ToString();
        }




        // this method uses the by hand method of converting decimal to Binary
        private static string convertToBinary(int num)
        {
            
            string result = "";
            while (num > 1)
            {
                int remainder = num % 2;
                result = Convert.ToString(remainder) + result;
                num /= 2;
            }
            result = Convert.ToString(num) + result;
            return result.PadLeft(8, '0').ToString();
        }


        // this method uses the by hand method of converting binary to decimal
        // by adding the 2 to the power of index
        // this can be done recursively but this method is better as it uses
        // less memory with a for loop
        private static string convertToDecimal(string input)
        {
            char[] array = input.ToCharArray();
            Array.Reverse(array);
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {
                    if (i == 0)
                    {
                        sum += 1;
                    }
                    else
                    {
                        sum += (int)Math.Pow(2, i);
                    }
                }

            }

            return sum.ToString();
        }


        // this is a dictionary to keep the encoding table. this way we can access the values instantly or O(1)
        private static readonly Dictionary<string, string> referenceTable = new Dictionary<string, string> {
            
            ["0"] = "A",
            ["1"] = "B",
            ["2"] = "C",
            ["3"] = "D",
            ["4"] = "E",
            ["5"] = "F",
            ["6"] = "G",
            ["7"] = "H",
            ["8"] = "I",
            ["9"] = "J",
            ["10"] = "K",
            ["11"] = "L",
            ["12"] = "M",
            ["13"] = "N",
            ["14"] = "O",
            ["15"] = "P",
            ["16"] = "Q",
            ["17"] = "R",
            ["18"] = "S",
            ["19"] = "T",
            ["20"] = "U",
            ["21"] = "V",
            ["22"] = "W",
            ["23"] = "X",
            ["24"] = "Y",
            ["25"] = "Z",
            ["26"] = "a",
            ["27"] = "b",
            ["28"] = "c",
            ["29"] = "d",
            ["30"] = "e",
            ["31"] = "f",
            ["32"] = "g",
            ["33"] = "h",
            ["34"] = "i",
            ["35"] = "j",
            ["36"] = "k",
            ["37"] = "l",
            ["38"] = "m",
            ["39"] = "n",
            ["40"] = "o",
            ["41"] = "p",
            ["42"] = "q",
            ["43"] = "r",
            ["44"] = "s",
            ["45"] = "t",
            ["46"] = "u",
            ["47"] = "v",
            ["48"] = "w",
            ["49"] = "x",
            ["50"] = "y",
            ["51"] = "z",
            ["52"] = "0",
            ["53"] = "1",
            ["54"] = "2",
            ["55"] = "3",
            ["56"] = "4",
            ["57"] = "5",
            ["58"] = "6",
            ["59"] = "7",
            ["60"] = "8",
            ["61"] = "9",
            ["62"] = "/",
            ["63"] = "+",


        };

    }
}





