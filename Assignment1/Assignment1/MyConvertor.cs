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
            List<char> numCharList = new List<char>();
            int sortedNum = Convert.ToInt32(num, 16);



            return null;
        }
    }
}
