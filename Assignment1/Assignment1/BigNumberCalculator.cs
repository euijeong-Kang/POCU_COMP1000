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

        public static string GetOnesComplement(string num)
        {
            string answer = "";
            List<char> listComplement = new List<char>();
            bool a = false;

            for (int i = 2; i < num.Length; i++)
            {
                if (num[i] == '1' || num[i] == '0')
                {
                    a = true;
                }
            }
            if (num[0] == '0' && num[1] == 'b' && a == true)
            {
                listComplement.Add('0');
                listComplement.Add('b');
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
            return answer;
        }

        public static string GetTwosComplement(string num)
        {
            string answer = "";
            List<char> listComplement = new List<char>();
            bool a = false;

            for (int i = 2; i < num.Length; i++)
            {
                if (num[i] == '1' || num[i] == '0')
                {
                    a = true;
                }
            }
            if (num[0] == '0' && num[1] == 'b' && a == true)
            {
                listComplement.Add('0');
                listComplement.Add('b');
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
                char[] complementArray = listComplement.ToArray();
                Array.Reverse(complementArray);
                if (complementArray[0] == '1')
                {
                    int endCount = 0;
                    for (int i = 0; a; i++)
                    {
                        if (complementArray[i + 1] == '0')
                        {
                            a = false;
                        }
                        complementArray[i] = '0';
                        endCount++;
                    }
                    complementArray[endCount] = '1';
                }
                Array.Reverse(complementArray);
                answer = new string(complementArray);
            }
            else
            {
                answer = null;
            }
            return answer;
        }

        public static string ToBinary(string num)
        {
            return null;
        }

        public static string ToHex(string num)
        {
            
            return null;
        }

        public static string ToDecimal(string num)
        {
            return null;
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
