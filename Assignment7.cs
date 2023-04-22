using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    class Assignment7
    {
        static bool isPrimeNumber(int num)
        {
            if (num<=0)
            {
                return false;
            }
             else
            {
                if (num > 2)
                {
                    for (int i = 2; i < num / 2; i++)
                    {
                        if (num % i == 0)
                        {
                            return false;
                        }
                    }
                }
               else if(num == 2 || num == 3)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("1 is niether Prime nor Composite !! ");
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
        RETRY:
            try
            {
                int number = UIConsole.GetNumber("Enter The Number to check whether it is Prime or not");
                bool check = isPrimeNumber(number);
                if(check==true)
                {
                    Console.WriteLine($"{number} is a Prime Number");
                }
                else
                {
                    Console.WriteLine($"{number} is Not a Prime Number");
                }
                goto RETRY;
            }
            catch(Exception)
            {
                Console.WriteLine("Provide a Valid Number in Numerical Format");
                goto RETRY;
            }

        }
    }
}
