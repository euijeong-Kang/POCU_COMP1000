using System;
using System.Text;
using System.Diagnostics;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        { 
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b") == null);
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b11000") == "0b01000");
            
        }
    }
}
