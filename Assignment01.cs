using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    class Assignment01
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Displaying the range of floating and integral types");
            // Numerical Data Types
            Console.WriteLine("Integral Signed Data Type range .....\n");
            Console.WriteLine($"The Range of Byte dataType is {Byte.MinValue} and {Byte.MaxValue}");
            Console.WriteLine($"The Range of int  dataType is {int.MinValue} and {int.MaxValue}");
            Console.WriteLine($"The Range of Short dataType is {short.MinValue} and {short.MaxValue}");
            Console.WriteLine($"The Range of Long dataType is {long.MinValue} and {long.MaxValue}\n");
            /// Floating DataTypes
            Console.WriteLine("Floating Signed Data Types Range.......\n");
            Console.WriteLine($"The Range of Float dataType is {float.MinValue} and {float.MaxValue}");
            Console.WriteLine($"The Range of Double dataType is {Double.MinValue} and {Double.MaxValue}\n");
            /// Unsigned Data Types
            Console.WriteLine("Integral UnSigned Data Type range .....\n");
            Console.WriteLine($"The Range of Byte dataType is 0 and {Byte.MaxValue}");
            Console.WriteLine($"The Range of int  dataType is 0 and {int.MaxValue}");
            Console.WriteLine($"The Range of Short dataType is 0  and {short.MaxValue}");
            Console.WriteLine($"The Range of Long dataType is 0 and {long.MaxValue}\n");
            /// Unsigned Data Types 
            Console.WriteLine("Floating UnSigned Data Types Range.......\n");
            Console.WriteLine($"The Range of Float dataType is 0 and {float.MaxValue}");
            Console.WriteLine($"The Range of Double dataType is 0 and {Double.MaxValue}");
        }
    }
}
