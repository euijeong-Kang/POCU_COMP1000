using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class MyConvertor
    {
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
            string result = new string(numCharList.ToArray());
            if (result[0] == '1')
            {
                result = "0" + result;
            }
            return result;
        }
        public static string ConvertToHex(string num)
        {
            StringBuilder result = new StringBuilder(((num.Length - 2) / 8) + 1);

            string[] splitedNum = num.Split('b');
            string binary = splitedNum[1];

            if (binary.Length % 8 != 0)
            {
                if (binary[0] == '1')
                {
                    binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '1');
                }
                else if (binary[0] == '0')
                {
                    binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
                }
            }
            for (int i = 0; i < binary.Length; i += 8)
            {
                string eightBit = binary.Substring(i, 8);
                result.AppendFormat("{0:X2}", Convert.ToByte(eightBit, 2));
            }
            if (result.Length - splitedNum.Length > 3)
            {
                result.Remove(0, 1);
            }
            return result.ToString();
        }
        public static string ConvertToDeciaml(string num)
        {
            string result;
            if (num[0] == '1')
            {
                num = "0b" + num;
                num = BigNumberCalculator.GetTwosComplementOrNull(num);
                string splitedNum = num.Split('b')[1];
                int convertedNum = Convert.ToInt32(splitedNum, 2);
                result = "-" + convertedNum.ToString();
            }
            else
            {
                int convertedNum = Convert.ToInt32(num, 2);
                result = convertedNum.ToString();
            }
            return result;
        }
        public static string GetBigNumCal(string num)
        {
            EMode numberType = (EMode)SortNumber.SortNumbers(num);
            if (numberType == EMode.Hex)
            {
                num = BigNumberToDecimal.ConvertBigNumToDecimal(num);
            }
            
            string result;
            string splitedNum = num.Split('b')[1];
            splitedNum = splitedNum.Insert(64, "a");
            string[] numPart = splitedNum.Split('a');
            
            ulong numPartA = Convert.ToUInt64(numPart[0], 2);
            string numPartB = Convert.ToUInt64(numPart[1], 2).ToString();

            result = numPartA.ToString();
            for (int i = 0; i < 20; i++)
            {
                result = BigNumberToDecimal.CalculatStringBigNumber(result);
            }
            int numPartAInt = int.Parse(result.Substring((result.Length - numPartB.Length) - 2, numPartB.Length + 2));
            string tailResult = (numPartAInt + int.Parse(numPartB)).ToString();
            string hadresult = result.Substring(0, result.Length - tailResult.Length);

            result = "-" + hadresult + tailResult;

            return result;
        }
    }
}
