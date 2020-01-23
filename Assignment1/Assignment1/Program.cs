using System;
using System.Text;
using System.Diagnostics;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bOverflow = false;
            BigNumberCalculator calc1 = new BigNumberCalculator(8, EMode.Decimal);

            // AddOrNull test

            
            
            

            Debug.Assert(calc1.AddOrNull("-128", "0", out bOverflow) == "-128");
            Debug.Assert(!bOverflow);
            Debug.Assert(calc1.AddOrNull("0b1", "0b11111111", out bOverflow) == "-2");
            Debug.Assert(!bOverflow);



        }
    }
}
