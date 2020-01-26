using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    public class BigNumberCalculator
    {
        public int BitCount;
        public EMode Mode;
        public BigNumberCalculator(int bitCount, EMode mode)
        {
            BitCount = bitCount;
            Mode = mode;
        }

        public static string GetOnesComplementOrNull(string num)
        {
            string answer;
            string prefix = "0b";
            List<char> listComplement = new List<char>();
            EMode numberType = (EMode)SortNumber.SortNumbers(num);
            if (numberType == EMode.Zero && num.Length == 1)
            {
                return null;
            }
            if (numberType == EMode.Zero && num[1] == 'x')
            {
                return null;
            }
            else if (numberType == EMode.Binary || numberType == EMode.Zero)
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
            if (numberType == EMode.Zero && num.Length == 1)
            {
                return null;
            }
            else if (numberType == EMode.Binary || numberType == EMode.Zero)
            {
                string[] splitedNum = GetOnesComplementOrNull(num).Split('b');
                char[] onesComplement = splitedNum[1].ToCharArray();
                Array.Reverse(onesComplement);
                if (numberType == EMode.Zero && num.Length != 1)
                {
                    return num;
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
                    outPut = "0b" + BigNumberToDecimal.ConvertBigNumToBinary(num);
                }
                else if (num[0] == '-' && num.Length < 9)
                {
                    if (num == "-1")
                    {
                        outPut = "0b" + num.Remove(0, 1);
                    }
                    else
                    {
                        outPut = "0b" + MyConvertor.ConvertToBinary(" " + num.Remove(0, 1));
                        outPut = GetTwosComplementOrNull(outPut);
                    }
                }
                else
                {
                    outPut = "0b" + MyConvertor.ConvertToBinary(" " + num);
                }
                result = outPut;
                for (int i = 4; i < result.Length; i++)
                {
                    if (result[2] == '1' && result[3] == '1' && result[i] == '0')
                    {
                        result = result.Remove(2, 1);
                    }
                }
            }
            else if (numberType == EMode.Hex)
            {   
                outPut = MyConvertor.ConvertToBinary(num);
                if (outPut.Length < (num.Length - 2) * 4)
                {
                    outPut = outPut.PadLeft((num.Length - 2) * 4, '0');
                }
                else if (outPut.Length > (num.Length - 2) * 4)
                {
                    outPut = outPut.Remove(0, outPut.Length - (num.Length - 2) * 4);
                }
                
                result = "0b" + outPut;
                for (int i = 4; i < result.Length; i++)
                {
                    if (result[2] == '1' && result[3] == '1' && result[i] == '0')
                    {
                        result = result.Remove(2, 1);
                    }
                }

            }
            else if (numberType == EMode.Zero)
            {
                if (num.Length > 1)
                {
                    if (num[1] == 'x')
                    {
                        result = "0b" + result.PadLeft((num.Length - 2) * 4, '0');
                    }
                    else if (num[1] == 'b')
                    {
                        result = num;
                    }
                }
                else
                {
                    result = "0b" + num;
                }
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
                if (outPut[2] == '0')
                {
                    while (true)
                    {
                        outPut = outPut.Remove(2, 1);
                        if (outPut[2] != '0')
                        {
                            break;
                        }
                    }
                }
                result = outPut;
            }
            else if (numberType == EMode.Binary)
            {
                if (num[2] == '1' && num.Length - 2 > 3) 
                {
                    if ((num.Length - 2) % 4 != 0 && num[3] != '0')
                    {
                        num = num.Remove(2, 1);
                    }
                    outPut = "F" + MyConvertor.ConvertToHex(num);
                    if (outPut[0] == 'F' && outPut.Length > 1)
                    {
                        if (outPut[1] == 'F')
                        {
                            while (true)
                            {
                                outPut = outPut.Remove(0, 1);
                                if (outPut[1] != 'F')
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    outPut = MyConvertor.ConvertToHex(num);
                }
                result = "0x" + outPut;

            }
            else if (numberType == EMode.Zero)
            {
                if (num.Length > 1)
                {
                    if (num[1] == 'b')
                    {
                        result = "0x0";
                    }
                    else if (num[1] == 'x')
                    {
                        result = num;
                    }
                }
                else
                {
                    result = "0x" + num;
                }
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
                if (num.Length > 34)
                {
                    outPut = MyConvertor.GetBigNumCal(num);
                }
                else
                {
                    string splitedNum = num.Split('b')[1];
                    outPut = MyConvertor.ConvertToDeciaml(splitedNum);
                }
                
                
                result = outPut;
            }
            else if (numberType == EMode.Hex)
            {
                if (num.Length > 16)
                {
                    outPut = MyConvertor.GetBigNumCal(num);
                }
                else if (num[2] == 'F' && num.Length > 3)
                {
                    num.Remove(2, 1);
                    outPut = ToBinaryOrNull(num);
                    outPut = ToDecimalOrNull(outPut);
                }
                else
                {
                    outPut = ToBinaryOrNull(num);
                    
                    outPut = ToDecimalOrNull(outPut);
                }
                result = outPut;
            }
            else if (numberType == EMode.Zero)
            {
                result = "0";
            }
            else if (numberType == EMode.Null)
            {
                result = null;
            }
            return result;
        }

        public string AddOrNull(string num1, string num2, out bool bOverflow)
        {
            string result = "";
            string maxValue = "";
            maxValue = "0b0" + maxValue.PadRight(BitCount - 1, '1');
            maxValue = ToDecimalOrNull(maxValue);
            string minValue = "";
            minValue = "0b1" + minValue.PadRight(BitCount - 1, '0');
            minValue = ToDecimalOrNull(minValue);

            bOverflow = false;
            EMode number1Type = (EMode)SortNumber.SortNumbers(num1);
            EMode number2Type = (EMode)SortNumber.SortNumbers(num2);
            if (number1Type == EMode.Zero || number2Type == EMode.Zero)
            {
                if (number1Type != EMode.Zero)
                {
                    result = num1;
                }
                else if (number2Type != EMode.Zero)
                {
                    result = num2;
                }
            }
            else
            {
                string binaryNum1 = ToBinaryOrNull(num1);
                string binaryNum2 = ToBinaryOrNull(num2);
                if (binaryNum1.Length - 2 > BitCount || binaryNum2.Length - 2 > BitCount)
                {
                    result = null;
                }
                else if (binaryNum2.Length - 2 <= BitCount && binaryNum2.Length - 2 <= BitCount)
                {
                    result = (long.Parse(ToDecimalOrNull(binaryNum1)) + long.Parse(ToDecimalOrNull(binaryNum2))).ToString();
                    string resultBInary = ToBinaryOrNull(result);
                    string resultDecimal = ToDecimalOrNull(resultBInary);
                    if (long.Parse(resultDecimal) > long.Parse(maxValue))
                    {
                        result = (long.Parse(minValue) + (long.Parse(resultDecimal) - long.Parse(maxValue) - 1)).ToString();
                        bOverflow = true;
                    }
                    else if (long.Parse(resultDecimal) < long.Parse(minValue))
                    {
                        result = (long.Parse(maxValue) - (long.Parse(resultDecimal) - long.Parse(minValue) + 1)).ToString();
                        bOverflow = true;
                    }

                }

            }
            if (Mode == EMode.Binary)
            {

                result = ToBinaryOrNull(result);
                if (result.Length - 2 < BitCount)
                {
                    if (result[2] == '1')
                    {
                        result = result.Split('b')[1];
                        result = result.PadLeft(BitCount, '1');
                        result = "0b" + result;
                    }
                    else
                    {
                        result = result.Split('b')[1];
                        result = result.PadLeft(BitCount, '0');
                        result = "0b" + result;
                    }
                }
            }
            else if (Mode == EMode.Decimal)
            {
                result = ToDecimalOrNull(result);
            }
            else if (Mode == EMode.Hex)
            {
                result = ToHexOrNull(result);
            }
            return result;
        }

        public string SubtractOrNull(string num1, string num2, out bool bOverflow)
        {
            string result = "";
            string maxValue = "";
            maxValue = "0b0" + maxValue.PadRight(BitCount - 1, '1');
            maxValue = ToDecimalOrNull(maxValue);
            string minValue = "";
            minValue = "0b1" + minValue.PadRight(BitCount - 1, '0');
            minValue = ToDecimalOrNull(minValue);

            bOverflow = false;

            string binaryNum1 = ToBinaryOrNull(num1);
            string binaryNum2 = ToBinaryOrNull(num2);

            if (binaryNum1.Length - 2 > BitCount || binaryNum2.Length - 2 > BitCount)
            {
                result = null;
            }
            else if (binaryNum2.Length - 2 <= BitCount && binaryNum2.Length - 2 <= BitCount)
            {
                result = (long.Parse(ToDecimalOrNull(binaryNum1)) - long.Parse(ToDecimalOrNull(binaryNum2))).ToString();
                string resultBInary = ToBinaryOrNull(result);
                string resultDecimal = ToDecimalOrNull(resultBInary);
                if (long.Parse(resultDecimal) > long.Parse(maxValue))
                {
                    result = (long.Parse(minValue) + (long.Parse(resultDecimal) - long.Parse(maxValue) - 1)).ToString();
                    bOverflow = true;
                }
                else if (long.Parse(resultDecimal) < long.Parse(minValue))
                {
                    result = (long.Parse(maxValue) + (long.Parse(resultDecimal) - long.Parse(minValue) + 1)).ToString();
                    bOverflow = true;
                }

            }
            if (binaryNum1 == binaryNum2)
            {
                bOverflow = true;
            }
            if (Mode == EMode.Binary)
            {
                if (result[0] == '-')
                {
                    result = ToBinaryOrNull(result);
                    if (result.Length - 2 < BitCount)
                    {
                        result = result.Split('b')[1];
                        result = result.PadLeft(BitCount, '1');
                        result = "0b" + result;
                    }
                }

                else
                {
                    result = ToBinaryOrNull(result);
                    if (result.Length - 2 < BitCount)
                    {
                        result = result.Split('b')[1];
                        result = result.PadLeft(BitCount, '0');
                        result = "0b" + result;
                    }
                }

            }
            else if (Mode == EMode.Decimal)
            {
                result = ToDecimalOrNull(result);
            }
            else if (Mode == EMode.Hex)
            {
                result = ToHexOrNull(result);
            }
            return result;
        }
    }
}
