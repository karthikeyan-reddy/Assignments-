using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    class Assignment11
    {
        static void Main(string[] args)
        {
            Requirements();
        }

        private static void Requirements()
        {
        RETRY:
            Console.Clear();
            try
            {
                double Principle = UIConsole.GetDouble("Enter the Principle Amount");
                if(Principle<0)
                {
                    Console.WriteLine("Non Negative Numbers are Invalid!!!");
                    Console.WriteLine("Press Any Key to Clear Screen.....");
                    Console.ReadKey();
                    goto RETRY;
                }
                double RateOfInterest = UIConsole.GetDouble("Enter the Rate Of Interest");
                if (RateOfInterest < 0)
                {
                    Console.WriteLine("Non Negative Numbers are Invalid!!!");
                    Console.WriteLine("Press Any Key to Clear Screen.....");
                    Console.ReadKey();
                    goto RETRY;
                }
                double term = UIConsole.GetDouble("Enter The term of Loan");
                if (term < 0)
                {
                    Console.WriteLine("Non Negative Numbers are Invalid!!!");
                    Console.WriteLine("Press Any Key to Clear Screen.....");
                    Console.ReadKey();
                    goto RETRY;
                }
                InterestCalculator(Principle, RateOfInterest, term);
                Console.WriteLine("Press Any Key to Clear Screen.....");
                Console.ReadKey();
                goto RETRY;
            }
            catch(Exception)
            {
                Console.WriteLine("Enter Valid Inputs!! inputs Should be Numeric and Non-negative.....");
                goto RETRY;
            }
        }

        private static void InterestCalculator(double principle, double rateOfInterest, double term)
        {
            double interest = (principle * term * rateOfInterest) / 100;
            Console.WriteLine($"Interest Acquired For The {principle} with {rateOfInterest} Rate of interest for the Ter Period of {term} is {interest}");
        }
    }
}
