using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    public class BigNumberCalculator
    {
        public BigNumberCalculator(int bitCount, EMode mode)
        {
        }

        public static string GetOnesComplementOrNull(string num)
        {
            string answer;
            List<char> listComplement = new List<char>();
            EMode numberType = (EMode)SortNumber.sortNumber(num);
            if (numberType == EMode.Binary)
            {
                for (int i = 2; i < num.Length; i++)
                {
                    if (num[i] == '0')
                    {
                        listComplement.Add('1');
                    }
                    else if (num[i] == '1')
                    {
                        listComplement.Add('0');
                    }
                }
                answer = new string(listComplement.ToArray());
            }
            else
            {
                answer = null;
            }
            return "0b" + answer;

        }

        public static string GetTwosComplementOrNull(string num)
        {
            string answer;
            List<char> listComplement = new List<char>();

            EMode numberType = (EMode)SortNumber.sortNumber(num);
            if (numberType == EMode.Binary)
            {
                string[] splitedNum = GetOnesComplementOrNull(num).Split('b');
                char[] onesComplement = splitedNum[1].ToCharArray();
                Array.Reverse(onesComplement);
                if (onesComplement[0] == '1')
                {
                    int Count = 0;
                    while(true)
                    {
                        if (onesComplement[Count + 1] == '0')
                        {
                            break;
                        }
                        onesComplement[Count] = '0';
                        Count++;
                    }
                    onesComplement[Count] = '0';
                    onesComplement[Count + 1] = '1';
                }
                else
                {
                    onesComplement[0] = '1';
                }
                Array.Reverse(onesComplement);
                answer = new string(onesComplement);
            }
            else if (numberType == EMode.Zero)
            {
                if (num[1] == 'b')
                {
                    answer = num.Split('b')[1];
                }
                else
                {
                    answer = null;
                }
            }
            else
            {
                answer = null;
            }
            return "0b" + answer;
        }

        public static string ToBinaryOrNull(string num)
        {
            string result = "";
            string outPut;
            EMode numberType = (EMode)SortNumber.sortNumber(num);
            if (numberType == EMode.Binary)
            {
                result = num;
            }
            else if (numberType == EMode.Decimal)
            {
                if (num[0] == '-')
                {
                    outPut = "0b1" + MyConvertor.convertToBinary(num.Remove(0, 1));
                    outPut = GetTwosComplementOrNull(outPut);
                }
                else
                {
                    outPut = "0b0" + MyConvertor.convertToBinary(num);
                }
                result = outPut;
            }
            else if (numberType == EMode.Hex)
            {
                string[] splitedNum = num.Split('x');

                outPut = MyConvertor.convertToBinary(splitedNum[1]);
                
                result = "0b" + outPut;

            }
            else if (numberType == EMode.Null)
            {
                result = null;
            }
            return result;
        }

        public static string ToHexOrNull(string num)
        {
            string result = "";
            string outPut;
            EMode numberType = (EMode)SortNumber.sortNumber(num);
            if (numberType == EMode.Hex)
            {
                result = num;
            }
            else if (numberType == EMode.Decimal)
            {
                
                outPut = ToBinaryOrNull(num);
                outPut = MyConvertor.convertToHex(outPut);
                
                if (num[0] == '-' && outPut[0] == '0')
                {
                    int count = 0;
                    while (true)
                    {
                        outPut = outPut.Remove(0, 1);
                        outPut = outPut.Insert(0, "F");
                        if (outPut[count + 1] != '0')
                        { 
                            break;
                        }
                    }
                }
                result = "0x" + outPut;
            }
            else if (numberType == EMode.Binary)
            {
                outPut = MyConvertor.convertToHex(num);
                result = "0x" + outPut;

            }
            else if (numberType == EMode.Null)
            {
                result = null;
            }
            return result;
        }

        public static string ToDecimalOrNull(string num)
        {
            string result = "";
            string outPut;
            EMode numberType = (EMode)SortNumber.sortNumber(num);
            if (numberType == EMode.Decimal)
            {
                result = num;
            }
            else if (numberType == EMode.Binary)
            {
                string splitedNum = num.Split('b')[1];
                outPut = MyConvertor.convertToDeciaml(splitedNum);
                
                result = outPut;
            }
            else if (numberType == EMode.Hex)
            {
                string[] splitedNum = num.Split('x');

                outPut = MyConvertor.convertToBinary(splitedNum[1]);

                result = "0b" + outPut;

            }
            else if (numberType == EMode.Null)
            {
                result = null;
            }
            return result;
        }

        public string AddOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;
            return null;
        }

        public string SubtractOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;
            return null;
        }
    }
}
