using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    class Assignment6
    {
        ///Direct Method .........
        static bool isValidDate(int year, int month, int day)
        {
            bool validate;
            String givenDate= month.ToString() +"/"+ day.ToString()+"/"+year.ToString();
            try
            {
                DateTime validdate = DateTime.Parse(givenDate);
                validate = true;
            }
            catch (Exception)
            {
                validate = false;
            }

            return validate;
        }
        static void Main(string[] args)
        {
            getentries();
        }

        private static void getentries()
        {
            try
            {
                RETRY:
                int year = UIConsole.GetNumber("Enter The Year in YYYY Format");
                int month = UIConsole.GetNumber("Enter The Month in mm Format");
                int day = UIConsole.GetNumber("Enter the day in dd Format");
                //bool check = isValidDate(year, month, day);
                bool check = Regularmethod(year, month, day);
                if (check == true)
                {
                    UIConsole.PrintMessage("Valid Date Thanks!");
                    Console.WriteLine("Press Any Key to Clear Screen");
                    Console.ReadKey();
                    Console.Clear();
                    goto RETRY;
                }
                else
                {
                    UIConsole.NegativeMessage("Invalid Date please check and enter again!");
                    Console.WriteLine("Press Any Key to Clear Screen");
                    Console.ReadKey();
                    Console.Clear();
                    goto RETRY;
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Please Provide Numerical input only!!!!!!!");
            }
        }
        ////Regular Method
        static bool Regularmethod(int year, int month, int day)
        {
            bool validate =true;
            if(month>12 || month<0)
            {
                validate = false;
            }
            else if (month == 02 || month == 2)
            {
                if (year%4==0)
                {
                    if (day>29 || day<0)
                    {
                        validate= false;
                    }
                }
                else
                {
                    if (day>28 || day < 0)
                    {
                        validate = false;
                    }
                }
            }
            else if (month == 01 || month == 03 || month == 05 || month ==07 || month==08 || month==10|| month == 12 )
            {
                if(day>31 || day<0)
                {
                    validate = false;
                }
            }
            else if (month == 04 || month == 06 || month == 09 || month == 11)
            {
                if (day > 30 || day < 0)
                {
                    validate = false;
                }
            }
            else
            {
                validate = true;
            }

            return validate ;
        }
    }
}
