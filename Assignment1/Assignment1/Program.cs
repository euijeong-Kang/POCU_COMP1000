using System;
using System.Text;
using System.Diagnostics;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BigNumberToDecimal.ConvertBigNumToBin("18"));
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("18"));
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("0x12"));

        }
    }
}
