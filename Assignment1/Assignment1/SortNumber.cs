﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class SortNumber
    {
        public static Enum sortNumber(string num)
        {
            string result = "";
            List<char> decimalNum = new List<char> { '-', '1', '2', '3', '4', '5', '7', '8', '9', '0' };
            List<char> hexNum = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'A', 'B', 'C', 'D', 'E', 'F' };
            List<char> binaryNum = new List<char> { '1', '0' };
            char[] numCharArray = num.ToCharArray();
            
            

            if (numCharArray[0] == '0')
            {
                for (int i = 2; i < numCharArray.Length; i++)
                {
                    if (numCharArray[1] == 'b' && binaryNum.Contains(numCharArray[i]))
                    {
                        result = num;
                    }
                    if (numCharArray[1] == 'x' && hexNum.Contains(numCharArray[i]))
                    {
                        return EMode.Hex;
                    }
                    else
                    {
                        result = null;
                    }
                }
            }
            else if ()
            for (int i = 0; i < numCharArray.Length; i++)
            {
                if (decimalNum.Contains(numCharArray[i]))
                {
                    return EMode.Decimal;
                }
            }
            
            

            retur;
        }
    }
}