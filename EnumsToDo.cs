using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    enum weekdays
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }
    class EnumsToDo
    {
        static void Main(string[] args)
        {
            Array weekdaylenght = Enum.GetValues(typeof(weekdays));
            for (int i = 0; i < weekdaylenght.Length; i++)
            {
                Console.WriteLine(weekdaylenght.GetValue(i));
            }
            weekdays select = (weekdays)Enum.Parse(typeof(weekdays), Console.ReadLine(), true);
            Console.WriteLine(select);

        }
    }
}
