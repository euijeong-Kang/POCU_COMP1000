using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class MyConvertor
    {
        public static string convertToBinary(string num)
        {
            List<char> numCharList = new List<char>();
            int sortedNum = Convert.ToInt32(num);
            while (true)
            {
                if (sortedNum % 2 == 1)
                {
                    numCharList.Insert(0, '1');
                }
                else if (sortedNum % 2 == 0)
                {
                    numCharList.Insert(0, '0');
                }
                sortedNum /= 2;

                if (sortedNum == 0)
                {
                    break;
                }
            }
            string result = new string(numCharList.ToArray());
            return result;
        }
        public static string convertToHex(string num)
        {
            StringBuilder result = new StringBuilder(((num.Length - 2) / 8) + 1);

            string[] splitedNum = num.Split('b');
            string binary = splitedNum[1];

            if (binary.Length % 8 != 0)
            {
                binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
            }
            for (int i = 0; i < binary.Length; i += 8)
            {
                string eightBit = binary.Substring(i, 8);
                result.AppendFormat("{0:X2}", Convert.ToByte(eightBit, 2));
            }
            return result.ToString();
        }
        public static string convertToDeciaml(string num)
        {
            string result;
            int convertedNum = Convert.ToInt32(num);
            result = convertedNum.ToString();
            return result;
        }
    }
}
