using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    class Assignment04
    {
        
        static void Entries()
        {
            Console.WriteLine("Enter the size ");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the datatype");
            string datatype = Console.ReadLine();
            typeconversion(datatype,size);
        }
        static void typeconversion(string datatype, int size)
        {
            Type getdataType = Type.GetType(datatype, false, true);
            if (getdataType == null)
            {
                Console.WriteLine("Invalid Entry....");
            }
            
            arraycreation(getdataType, size);
        }
        static void arraycreation(Type datatype,int size)
        {
            Console.WriteLine("Enter the Values to the Array");
            Array instance = Array.CreateInstance(datatype, size);
            for (int i = 0; i < size; i++)
            {
                instance.SetValue(Convert.ChangeType(Console.ReadLine(),datatype),i);
            }
            arrayDisplay(instance);
        }

        private static void arrayDisplay(Array instance)
        {
            Console.WriteLine("Entries Provided are .......");
            foreach (var item in instance)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            Entries();   
        }
    }
}
