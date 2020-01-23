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
           

            

            BigNumberCalculator calc2 = new BigNumberCalculator(8, EMode.Binary);

          

            Debug.Assert(calc2.SubtractOrNull("25", "52", out bOverflow) == "0b11100101");
            Debug.Assert(!bOverflow);

            Debug.Assert(calc2.SubtractOrNull("0b100110", "-12", out bOverflow) == "0b11110010");
            Debug.Assert(!bOverflow);

            Debug.Assert(calc2.SubtractOrNull("0b0001101", "10", out bOverflow) == "0b00000011");
            Debug.Assert(!bOverflow);

            Debug.Assert(calc2.SubtractOrNull("-125", "100", out bOverflow) == "0b00011111");
            Debug.Assert(bOverflow);

            BigNumberCalculator calc3 = new BigNumberCalculator(100, EMode.Decimal);

            Debug.Assert(calc3.AddOrNull("126585123123216548452353151521", "5646862135432184515421587", out bOverflow) == "126590769985351980636868573108");
            Debug.Assert(!bOverflow);

            Debug.Assert(calc3.SubtractOrNull("-889874837998729348827376462", "577257635827634627837676734", out bOverflow) == "-1467132473826363976665053196");
            Debug.Assert(!bOverflow);


        }
    }
}
