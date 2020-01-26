using System;
using System.Text;
using System.Diagnostics;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1024; i++)
            {
                string a = BigNumberCalculator.ToBinaryOrNull($"{i}");
                Console.WriteLine(BigNumberCalculator.ToHexOrNull(a));
            }
            
            

        }
    }
}
