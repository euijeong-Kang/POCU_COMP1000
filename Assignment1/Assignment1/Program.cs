using System;
using System.Text;
using System.Diagnostics;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-135799753113579"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-135799753113579") == "0b100001000111110110100111111101001000000000010101");
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-9223372036854775808")); // long.minvalue
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-9223372036854775808") == "0b1000000000000000000000000000000000000000000000000000000000000000");
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-9223372036854775809"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-9223372036854775809") == "0b10111111111111111111111111111111111111111111111111111111111111111");
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-9223372036854775810"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-9223372036854775810") == "0b10111111111111111111111111111111111111111111111111111111111111110");
            Console.WriteLine($"{BigNumberCalculator.ToBinaryOrNull(int.MaxValue.ToString())}");
            Console.WriteLine($"{BigNumberCalculator.ToBinaryOrNull((int.MinValue + 1).ToString())}");
            Console.WriteLine($"{BigNumberCalculator.ToBinaryOrNull(int.MinValue.ToString())}");
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            for (long i = -1; i < 1; ++i)
            {
                Console.WriteLine(i);
                string binary = Convert.ToString(i, 2);
                binary = binary.Insert(0, "0b");
                Console.WriteLine($"std : {binary}");
                Console.WriteLine($"{i} : {BigNumberCalculator.ToBinaryOrNull(i.ToString())}");
                long number = i - i - i;
                Console.WriteLine($"{number} : {BigNumberCalculator.ToBinaryOrNull(number.ToString())}");
                Console.WriteLine();
            }


        }
    }
}
