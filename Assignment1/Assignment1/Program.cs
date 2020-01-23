using System;
using System.Text;
using System.Diagnostics;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BigNumberCalculator.ToDecimalOrNull("0"));
            Console.WriteLine(BigNumberCalculator.ToDecimalOrNull("1"));
            Console.WriteLine(BigNumberCalculator.ToDecimalOrNull("2"));
            Console.WriteLine(BigNumberCalculator.ToDecimalOrNull("-1"));
            Console.WriteLine(BigNumberCalculator.ToDecimalOrNull("-2"));
            Console.WriteLine(BigNumberCalculator.ToDecimalOrNull("4"));
            Console.WriteLine(BigNumberCalculator.ToDecimalOrNull("5"));
            Console.WriteLine(BigNumberCalculator.ToDecimalOrNull("100"));
            Console.WriteLine(BigNumberCalculator.ToDecimalOrNull("6"));
            Console.WriteLine(BigNumberCalculator.ToDecimalOrNull("7"));
            Console.WriteLine(BigNumberCalculator.ToDecimalOrNull("100000"));
            Console.WriteLine(BigNumberCalculator.ToDecimalOrNull("4"));
            Console.WriteLine(BigNumberCalculator.ToDecimalOrNull("8"));
            Console.WriteLine(BigNumberCalculator.ToDecimalOrNull("-2"));
            Console.WriteLine(BigNumberCalculator.ToDecimalOrNull("-5"));
            Console.WriteLine(BigNumberCalculator.ToDecimalOrNull("-10"));

        }
    }
}
