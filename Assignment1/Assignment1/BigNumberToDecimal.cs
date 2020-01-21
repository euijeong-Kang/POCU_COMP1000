using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class BigNumberToDecimal
    {
        public static string ConvertBigNumToDecimal(string num)
        {
            string result = "";
            string[] splitedNum = num.Split('x');
            string hex = splitedNum[1];

            if (hex.Length % 4 != 0)
            {
                hex = hex.PadLeft(((hex.Length / 4) + 1) * 4, '0');
            }
            for (int i = 0; i < hex.Length; i += 4)
            {
                string outPut = ConvertToBinary("0x" + hex.Substring(i, 4));
                result += outPut;
            }
            if (result[0] == '0')
            {
                result = result.Remove(0, 1);
            }
            result = BigNumberCalculator.GetTwosComplementOrNull("0b" + result);

            return result;
        }
        public static string CalculatStringBigNumber(string num)
        {
            string result = "";
            int numLength = num.Length;
            List<int> intList = new List<int>();
            for (int i = 0; i < numLength; i++)
            {
                intList.Add(int.Parse(num[i].ToString()));
            }
            if (intList[0] > 4)
            {
                intList.Insert(0, 0);
                numLength += 1;
            }
            intList[0] *= 2;
            for (int i = 1; i < numLength; i++)
            {
                if (intList[i] > 4)
                {
                    intList[i - 1] += 1;
                    intList[i] = intList[i] * 2 - 10;
                }
                else
                {
                    intList[i] *= 2;
                }
            }
            int count = intList.ToArray().Length;
            for (int k = 0; k < count; k++)
            {
                result += intList[k].ToString();
            }
            return result;
        }
        public static string ConvertToBinary(string num)
        {
            List<char> numCharList = new List<char>();
            int sortedNum;

            if (num[1] == 'x')
            {
                string[] splitedNum = num.Split('x');
                sortedNum = Convert.ToInt32(splitedNum[1], 16);
            }
            else
            {
                sortedNum = Convert.ToInt32(num);
            }
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

                if (sortedNum == 0 || sortedNum == 1)
                {
                    if (sortedNum == 1)
                    {
                        numCharList.Insert(0, '1');
                    }
                    else if (sortedNum == 0)
                    {
                        numCharList.Insert(0, '0');
                    }
                    break;
                }
                
            }
            string snum = num.Split('x')[1];
            List<char> hexNum = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8' };
            string result = new string(numCharList.ToArray());
            if (hexNum.Contains(snum[0]))
            {
                result = "0" + result;
            }
            return result;
        }
    }
}
