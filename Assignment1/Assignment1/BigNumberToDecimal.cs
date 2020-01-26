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
        public static string ConvertBigNumToBinary(string num)
        {
            string result = "";
            EMode sortedNumType = (EMode)SortNumber.SortNumbers(num);
            List<char> numCharList = new List<char>();
            

            if (sortedNumType == EMode.Decimal)
            {
                ulong sortedNum;

                if (num[0] == '-')
                {
                    num = num.Remove(0, 1);
                    num = ConvertBigNumToBinary(num);
                    
                    result = BigNumberCalculator.GetTwosComplementOrNull("0b" + num);
                    if (result[3] == '1' && result[2] == '1')
                    {
                        result = result.Remove(2, 1);
                    }
                    result = result.Split('b')[1];
                }
                else if (num[0] != '-')
                {
                    sortedNum = Convert.ToUInt64(num);
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
                    result = new string(numCharList.ToArray());
                    if (result[0] == '1')
                    {
                        result = "0" + result;
                    }
                }
            }
            return result;
        }

        public static string ConvertBigNum(string num)
        {
            List<char> charList = new List<char>();
            char[] charArray = num.ToCharArray();
            int[] intArray = new int[charArray.Length + 1];
            intArray[0] = 0;
            for (int i = 1; i < charArray.Length; i++)
            {
                intArray[i] = Convert.ToInt32(charArray[i]);
            }

            for (int i = 1; i < intArray.Length; i++)
            {
                if (intArray[i - 1] % 2 != 0)
                {
                    intArray[i] += 10;
                }
                intArray[i] /= 2;
                if (intArray[intArray.Length - 1] % 2 == 1)
                {
                    charList.Insert(0, '1');
                }
                else
                {
                    charList.Insert(0, '0');
                }
            }

            return null;
        }
        public static string ConvertBigNum(string num, int divisor, out char remainder)
        {
            string result = "";
            int index = 0;
            int temp = (num[index] - '0');

            while (temp < divisor)
            {
                temp = temp * 10 + (num[index + 1] - '0');
                index++;
            }
            ++index;

            while (num.Length > index)
            {

                result += (char)(temp / divisor + '0');

                
                temp = (temp % divisor) * 10 + (num[index] - '0');
                index++;
            }
            result += (char)(temp / divisor + '0');

            if(Convert.ToInt32(num[num.Length - 1]) % 2 == 1)
            {
                remainder = '1';
            }
            else
            {
                remainder = '0';
            }
            if (result.Length == 0)
            {
                return "0";
            }
               
            return result;
        }

        public static string ConvertBigNumToBin(string num)
        {
            string outPut;
            List<char> charList = new List<char>();
            if (num[0] == '-')
            {
                num = num.Remove(0, 1);
                outPut = ConvertBigNumToBin(num);

                outPut = BigNumberCalculator.GetTwosComplementOrNull(outPut);
            }
            else
            {
                while (true)
                {
                    num = ConvertBigNum(num, 2, out char remainder);
                    charList.Insert(0, remainder);
                    if (num == "1" || num == "0")
                    {
                        if (num == "1")
                        {
                            charList.Insert(0, '1');
                        }
                        else
                        {
                            charList.Insert(0, '0');
                        }
                        break;
                    }
                }
                outPut = new string(charList.ToArray());
                if (outPut[0] != '0')
                {
                    outPut = outPut.Insert(0, "0");
                }
                outPut = "0b" + outPut;

            }

            return outPut;
        }
    }
}
