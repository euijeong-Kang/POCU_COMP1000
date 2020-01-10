using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class SortNumber
    {
        public static Enum sortNumber(string num)
        {
            int enumNumber = 0; // 0: Decimal 1: Binary 2: Hex 3: Null, 4: Zero
            List<char> decimalNum = new List<char> { '-', '1', '2', '3', '4', '5', '7', '8', '9', '0' };
            List<char> hexNum = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'A', 'B', 'C', 'D', 'E', 'F' };
            List<char> binaryNum = new List<char> { '1', '0' };

            char[] numCharArray = num.ToCharArray();

            if (numCharArray[1] == 'b' || numCharArray[1] == 'x')
            {
                for (int i = 2; i < numCharArray.Length; i++)
                {
                    if (numCharArray[0] == '0' && numCharArray[i] == '0')
                    {
                        enumNumber = 4;
                    }
                    else if (numCharArray[0] == '0' && binaryNum.Contains(numCharArray[i]))
                    {
                        enumNumber = 1;
                    }
                    else if (numCharArray[0] == '0' && hexNum.Contains(numCharArray[i]))
                    {
                        enumNumber = 2;
                    }
                    else
                    {
                        enumNumber = 3;
                    }
                }
            }
            else if (numCharArray[0] != '0')
            {
                for (int i = 0; i < numCharArray.Length; i++)
                {
                    if (decimalNum.Contains(numCharArray[i]))
                    {
                        enumNumber = 0;
                    }
                }
            }
            else
            {
                enumNumber = 3;
            }
            return (EMode)enumNumber;
        }
    }
}
