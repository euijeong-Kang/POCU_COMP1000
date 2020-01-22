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
            string prefix = "0b";
            List<char> listComplement = new List<char>();
            EMode numberType = (EMode)SortNumber.SortNumbers(num);
            if (numberType == EMode.Binary || numberType == EMode.Zero)
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
                answer = prefix + answer;
            }
            else
            {
                answer = null;
            }
            return answer;

        }

        public static string GetTwosComplementOrNull(string num)
        {
            string answer;
            string prefix = "0b";

            EMode numberType = (EMode)SortNumber.SortNumbers(num);
            if (numberType == EMode.Binary || numberType == EMode.Zero)
            {
                string[] splitedNum = GetOnesComplementOrNull(num).Split('b');
                char[] onesComplement = splitedNum[1].ToCharArray();
                Array.Reverse(onesComplement);
                if (numberType == EMode.Zero && num.Length != 1)
                {
                    return num;
                }
                else if (numberType == EMode.Zero && num.Length == 1)
                {
                    return null;
                }
                else if (onesComplement[0] == '1')
                {
                    int count = 0;
                    while (true)
                    {
                        if (onesComplement[count + 1] == '0')
                        {
                            break;
                        }
                        onesComplement[count] = '0';
                        count++;
                    }
                    onesComplement[count] = '0';
                    onesComplement[count + 1] = '1';
                }
                else
                {
                    onesComplement[0] = '1';
                }
                Array.Reverse(onesComplement);
                answer = prefix + new string(onesComplement);
            }
            else
            {
                answer = null;
            }
            return answer;
        }

        public static string ToBinaryOrNull(string num)
        {
            string result = "";
            string outPut;
            EMode numberType = (EMode)SortNumber.SortNumbers(num);
            if (numberType == EMode.Binary)
            {
                result = num;
            }
            else if (numberType == EMode.Decimal)
            {
                if (num.Length > 9)
                {
                    outPut = BigNumberToDecimal.ConvertBigNumToBinary(num);
                }
                else if (num[0] == '-' && num.Length < 9)
                {
                    outPut = "0b" + MyConvertor.ConvertToBinary(" " + num.Remove(0, 1));
                    outPut = GetTwosComplementOrNull(outPut);
                }
                else
                {
                    outPut = "0b" + MyConvertor.ConvertToBinary(" " + num);
                }
                result = outPut;
            }
            else if (numberType == EMode.Hex)
            {   
                outPut = MyConvertor.ConvertToBinary(num);
                if (outPut.Length % 4 != 0)
                {
                    outPut = outPut.PadLeft((num.Length - 2) * 4, '0');
                }
                result = "0b" + outPut;

            }
            else if (numberType == EMode.Zero)
            {
                result = "0b" + num;
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
            EMode numberType = (EMode)SortNumber.SortNumbers(num);
            if (numberType == EMode.Hex)
            {
                result = num;
            }
            else if (numberType == EMode.Decimal)
            {
                if (num[0] == '-')
                {
                    outPut = ToBinaryOrNull(num);
                    outPut = ToHexOrNull(outPut);
                }
                else
                {
                    outPut = ToBinaryOrNull(num);
                    outPut = "0x" + MyConvertor.ConvertToHex(outPut);
                }
                result = outPut;
            }
            else if (numberType == EMode.Binary)
            {
                if (num[2] == '1')
                {
                    num = num.Remove(2, 1);
                    outPut = "F" + MyConvertor.ConvertToHex(num);
                }
                else
                {
                    outPut = MyConvertor.ConvertToHex(num);
                }
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
            EMode numberType = (EMode)SortNumber.SortNumbers(num);
            if (numberType == EMode.Decimal)
            {
                result = num;
            }
            else if (numberType == EMode.Binary)
            {
                string splitedNum = num.Split('b')[1];
                outPut = MyConvertor.ConvertToDeciaml(splitedNum);
                
                result = outPut;
            }
            else if (numberType == EMode.Hex)
            {
                if (num.Length > 16)
                {
                    outPut = MyConvertor.GetBigNumCal(num);
                }
                else if (num[2] == 'F')
                {
                    num.Remove(2, 1);
                    outPut = MyConvertor.ConvertToBinary(num);
                    if (outPut[0] == '0')
                    {
                        outPut.Insert(0, "1");
                    }
                    outPut = MyConvertor.ConvertToDeciaml(outPut);
                }
                else
                {
                    outPut = MyConvertor.ConvertToBinary(num);
                    if (outPut.Length != ((num.Length - 2) * 4))
                    {
                        while (true)
                        {

                            outPut = outPut.Remove(0, 1);
                            if (outPut.Length == (num.Length - 2) * 4)
                            {
                                break;
                            }
                        }
                    }
                    outPut = MyConvertor.ConvertToDeciaml(outPut);
                }
                result = outPut;

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
