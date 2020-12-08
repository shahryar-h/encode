
using System;
using System.Text;

namespace encode
{
    class Program
    {
        static void Main(string[] args)
        {


            byte[] source = { 0x6A, 0x77, 0xC4 };

            var encodedText = Encode(source);

            //Console.WriteLine(encodedText);
     



        }

        private static readonly string alphabetTable = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789/+";
        
        public static string Encode(byte[] source)
        {
            // used stirng builder for result variable becasue the performance
                // of append function is better than string concatenation
            StringBuilder result = new StringBuilder();
            int index = 0;
            int indexOfAllFullSegments;

            // this determines how many group of 3 bytes(segments) exists in source array
            // in our test we don't need to worry about possible not complete three
                // byte segments because the input assumed to be divisble to 3

            // if the source is not divisible by 3, we can use this value to add padding 
            indexOfAllFullSegments = (int)(source.Length / 3) * 3;

            // we compute the number of possible characters based on source array

            // using obtained index, we increment the for loop's index by three
                // until we reach the last index
            // this way we can use index as the starting point of three bit segments
            // then using the bellow bitwise operations, we can obtain the index for
                // each six-bit parts and using the table we can find the
                // corresponding character
            for (index = 0; index < indexOfAllFullSegments; index += 3)
            {

                result.Append(alphabetTable[source[index] >> 2]);
                result.Append(alphabetTable[((source[index] & 0x03) << 4) | ((source[index + 1] & 0xF0) >> 4)]);
                result.Append(alphabetTable[((source[index + 1] & 0x0F) << 2) | ((source[index + 2] & 0xC0) >> 6)]);
                result.Append(alphabetTable[source[index + 2] & 0x3F]);
            }


            return result.ToString();


        }
    }
}





