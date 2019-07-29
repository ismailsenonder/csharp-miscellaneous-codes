using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_array_reverser
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] myarray = { "HellO", "WoRLd", "iSmAiL", "SENonder" };

            string[] output = ReverseArray(myarray, true);
            //Console.WriteLine("NOW UPPER-LOWER REVERSED");
            //string[] output = ReverseArray(myarray, true);
            foreach (string s in output)
            {
                Console.WriteLine(s);
            }
            Console.Read();
        }

        public static string[] ReverseArray(string[] inputArray, bool convertUpperLower = false)
        {
            string tempStr = "";


            for (int i = 0; i < inputArray.Length / 2; i++)
            {
                tempStr = inputArray[i];
                inputArray[i] = ReverseString(inputArray[inputArray.Length - 1 - i], convertUpperLower);
                inputArray[inputArray.Length - 1 - i] = ReverseString(tempStr, convertUpperLower);
            }

            return inputArray;
        }

        private static string ReverseString(string strToReverse, bool convertUpperLower = false)
        {
            char[] chars = strToReverse.ToCharArray();
            char tempChar = ' ';

            for (int i = 0; i < chars.Length / 2; i++)
            {
                tempChar = chars[i];


                chars[i] = chars[chars.Length - 1 - i];

                if (convertUpperLower)
                {
                    if (Char.IsUpper(chars[i]))
                        chars[i] = Char.ToLower(chars[i]);
                    else
                        chars[i] = Char.ToUpper(chars[i]);

                    if (Char.IsUpper(tempChar))
                        tempChar = Char.ToLower(tempChar);
                    else
                        tempChar = Char.ToUpper(tempChar);
                }
                chars[chars.Length - 1 - i] = tempChar;



            }

            if (convertUpperLower & chars.Length % 2 != 0)
            {
                int j = (int)((chars.Length - 1) / 2);
                if (Char.IsUpper(chars[j]))
                    chars[j] = Char.ToLower(chars[j]);
                else
                    chars[j] = Char.ToUpper(chars[j]);
            }

            return new string(chars);
        }

        //public static string[] ReverseMultidimensionalArray(string[,] inputArray, bool convertUpperLower = false)
        //{
        //    string tempStr = "";

        //    int dimension = inputArray.GetLength();

        //    for (int i = 0, ; i < dimension; i++)
        //    {
        //        string[] subArray = inputArray[i, k];
        //        for (int j = 0; j < subArray.Length / 2; j++)
        //        {
        //            tempStr = subArray[j];
        //            subArray[j] = ReverseString(subArray[subArray.Length - 1 - j], convertUpperLower);
        //            subArray[subArray.Length - 1 - j] = ReverseString(tempStr, convertUpperLower);
        //        }
        //    }


        //    return inputArray;
        //}
    }
}
