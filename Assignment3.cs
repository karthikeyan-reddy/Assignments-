using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignments
{

    class Assignment3
    {
        static bool calculate(int choice)
        {
            switch (choice)
            {
                case 1:
                    Add();
                    return true;
                case 2:
                    sub();
                    return true;

                case 3:
                    Multiply();
                    return true;

                case 4:
                    division();
                    return true;

                case 5:
                    square();
                    return true;

                case 6:
                    squareroot();
                    return true;

                default:
                    Console.WriteLine("Sorry!! Selected Operation Unavailabe .. /n Press Any key to exit");
                    return false;


            }

        }

        private static void squareroot()
        {
            Console.WriteLine("Enter The Number !!!");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("The Squareroot of the entered Function is {0}",Math.Sqrt(number));
        }

        private static void square()
        {
            Console.WriteLine("Enter The Number !!!");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("The Square of the entered Function is {0}", Math.Pow(number,2));
        }

        private static void division()
        {
            Console.WriteLine("Enter The First Number !!!");

            int number1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter The Second Number !!!");

            int number2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"The Result After Performing Division is {number1/number2}");
        }

        private static void Multiply()
        {
            Console.WriteLine("Enter The First Number !!!");

            int number1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter The Second Number !!!");

            int number2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"The Result After Performing Multiplication is {number1* number2}");
        }

        private static void sub()
        {
            Console.WriteLine("Enter The First Number !!!");

            int number1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter The Second Number !!!");

            int number2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"The Result After Performing Subtraction is {number1 - number2}");
        }

        private static void Add()
        {
            Console.WriteLine("Enter The First Number !!!");

            int number1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter The Second Number !!!");

            int number2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"The Result After Performing Addition is {number1 + number2}");
        }

        static void Main(string[] args)
        {
            const string menu = @"C:\MyTraining\Assignments\Assignments\menu.txt";
            bool enter = true;
            do
            {
                Console.WriteLine(File.ReadAllText(menu));
                int Entry = int.Parse(Console.ReadLine());
                enter = calculate(Entry);
               
                Console.ReadKey();
                Console.Clear();
            } while (enter);

        }
    }
}
