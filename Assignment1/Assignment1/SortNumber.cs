using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class SortNumber
    {
        public static Enum SortNumbers(string num)
        {
            int enumNumber = 0; // 0: Decimal 1: Binary 2: Hex 3: Null, 4: Zero
            List<char> decimalNum = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            List<char> hexNum = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'A', 'B', 'C', 'D', 'E', 'F' };
            List<char> binaryNum = new List<char> { '1', '0' };

            if (num != null && num.Length > 0)
            {
                char[] numCharArray = num.ToCharArray();
                if (numCharArray[0] == '0' && num.Length > 2)
                {
                    int count = 0;
                    for (int i = 2; i < numCharArray.Length; i++)
                    {
                        if (numCharArray[i] != '0')
                        {
                            count++;
                        }
                        if (numCharArray[1] == 'b' && binaryNum.Contains(numCharArray[i]))
                        {
                            enumNumber = 1;
                        }
                        else if (numCharArray[1] == 'x' && hexNum.Contains(numCharArray[i]))
                        {
                            enumNumber = 2;
                        }
                        else
                        {
                            enumNumber = 3;
                        }
                    }
                    if (count == 0)
                    {
                        if ((numCharArray[1] == 'b' || numCharArray[1] == 'x'))
                        {
                            enumNumber = 4;
                        }
                    }
                }
                else if (numCharArray[0] == '0' && num.Length == 1)
                {
                    enumNumber = 4;
                }
                else if (numCharArray[0] != '0' && numCharArray.Length < 19)
                {
                    long number;
                    bool bSuccess = long.TryParse(num, out number);
                    if (numCharArray[0] == '+')
                    {
                        enumNumber = 3;
                    }
                    else if (numCharArray[0] == '-' && numCharArray.Length == 1)
                    {
                        enumNumber = 3;
                    }
                    else if (numCharArray[0] == '-' && numCharArray[1] == '0')
                    {
                        enumNumber = 3;
                    }
                    else if (bSuccess)
                    {
                        enumNumber = 0;
                    }
                    else
                    {
                        enumNumber = 3;
                    }
                }
                else if (num == null)
                {
                    enumNumber = 3;
                }
                else if (numCharArray.Length > 9 && decimalNum.Contains(numCharArray[1]))
                {
                    for (int i = 1; i < numCharArray.Length; i++)
                    {
                        if (numCharArray[0] == '-' && decimalNum.Contains(numCharArray[i]))
                        {
                            enumNumber = 0;
                        }
                        else if (decimalNum.Contains(numCharArray[0]) && decimalNum.Contains(numCharArray[i]))
                        {
                            enumNumber = 0;
                        }
                        else
                        {
                            enumNumber = 3;
                        }
                    }
                }
                else
                {
                    enumNumber = 3;
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
