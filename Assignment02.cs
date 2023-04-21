using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    class Assignment02
    {
        static Array ArrayCreation(int n)
        {
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            EvenNumber(array);
            return array;
            
        }
        static void EvenNumber(Array array)
        {
            Console.WriteLine("Even Numbers Entered : ");
            foreach (int item in array)
            {
                if (item % 2 == 0)
                {
                    Console.Write(item + " ");
                }
            }
            Console.WriteLine();
            OddNumber(array);
        }

        private static void OddNumber(Array array)
        {
            Console.WriteLine("Odd Numbers Entered : s");
            foreach (int i in array)
            {
                if (i % 2 != 0)
                {
                    Console.Write(i + " ");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter The Number Of Elements to Want to enter");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Number of Integers you are willing to enter");
            ArrayCreation(n);
        }
    }
}
