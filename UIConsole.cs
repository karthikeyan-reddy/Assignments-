using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    class UIConsole
    {
        internal static String GetString(String question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        internal static int GetNumber(String question)
        {
            return int.Parse(GetString(question));
        }
        internal static Double GetDouble(String question)
        {
            return double.Parse(GetString(question));
        }

        internal static long GetLong(string question)
        {
            return long.Parse(GetString(question));
        }

        internal static DateTime GetDate(string v)
        {
            Console.WriteLine(v);
            return DateTime.Parse(Console.ReadLine());
        }

        internal static void PrintMessage(string v)
        {
            var Oldbg = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(v);
            Console.BackgroundColor = Oldbg;
        }

        internal static void NegativeMessage(string v)
        {
            var Oldbg = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(v);
            Console.BackgroundColor = Oldbg;
        }
    }
}
