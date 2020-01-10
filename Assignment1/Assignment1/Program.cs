using System;
using System.Text;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BigNumberCalculator.ToHexOrNull("-155555551")); // 0xF6BA6921
            Console.WriteLine(BigNumberCalculator.ToHexOrNull("5258")); // 0x148A
            Console.WriteLine(BigNumberCalculator.ToHexOrNull("0x53ABC")); // 0x53ABC
            Console.WriteLine(BigNumberCalculator.ToHexOrNull("0b000000110001001"));
        }
    }
}
