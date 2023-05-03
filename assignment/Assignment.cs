using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proj2_dlls.assignment;

namespace DataBaseConnection
{
    class Assignment
    {
        static ICustomerDataBaseLayer instance = Factoryassignment.GetInstance();
        static Customers customers = new Customers();
        static void Main(string[] args)
        {
            const string menu = @"C:\MyTraining\BasicTraining\proj2_dlls\Menu.txt";
                bool process = true;
                do
                {
                    string entry = UIConsole.GetString(File.ReadAllText(menu));
                    process = display(entry);
                    UIConsole.clearScreen();

                } while (process);

        }

        private static bool display(string entry)
        {
            switch (entry.ToUpper())
            {
                case "I":
                    AddCustomer();
                    return true;
                case "U":
                    updateCustomer();
                    return true;
                case "Z":
                    FindCustomerByName();
                    return true;
                case "D":
                    deleteCustomer();
                    return true;
                case "N":
                    FindCustomerByNumber();
                    return true;
                case "C":
                    FindCustomerByCity();
                    return true;
                default:
                    return false;
            }
        }

        private static void FindCustomerByCity()
        {
            try
            {
                string city = customers.CustomerAddress = UIConsole.GetString("Enter The City Name to get data");
                var data = instance.FindCustomerByCity(city);
                foreach (var item in data)
                {
                    Console.WriteLine(item.CustomerId);
                    Console.WriteLine(item.CustomerName);
                    Console.WriteLine(item.MobileNumber);
                    Console.WriteLine(item.BillAmount);
                    Console.WriteLine(item.BillDate);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void FindCustomerByNumber()
        {
            try
            {
                long Number = customers.MobileNumber = UIConsole.GetLong("Enter The  Number to get data");
                var data = instance.FindCustomerByPhoneNumber(Number);
                foreach (var item in data)
                {
                    Console.WriteLine(item.CustomerId);
                    Console.WriteLine(item.CustomerName);
                    Console.WriteLine(item.MobileNumber);
                    Console.WriteLine(item.BillAmount);
                    Console.WriteLine(item.BillDate);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void deleteCustomer()
        {
            try
            {
                int deleteNumber = customers.CustomerId = UIConsole.GetNumber("Enter The Customer Id");
                instance.deleteCustomer(deleteNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void FindCustomerByName()
        {
            try
            {
                string Name = customers.CustomerName = UIConsole.GetString("Enter The  Name to get data");
                var data = instance.FindCustomerByPartialName(Name);
                foreach (var item in data)
                {
                    Console.WriteLine(item.CustomerId);
                    Console.WriteLine(item.CustomerName);
                    Console.WriteLine(item.MobileNumber);
                    Console.WriteLine(item.BillAmount);
                    Console.WriteLine(item.BillDate);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void updateCustomer()
        {
            try
            {
                customers.CustomerId = UIConsole.GetNumber("Enter The Customer Id to Update");
                customers.CustomerName = UIConsole.GetString("Enter Customer Name");
                customers.CustomerAddress = UIConsole.GetString("Enter The Address // City");
                customers.MobileNumber = UIConsole.GetLong("Enter The Mobile Number");
                customers.BillAmount = UIConsole.GetDouble("Enter The Bill Amount");
                customers.BillDate = UIConsole.GetDate("Enter The Bill Date");
                instance.UpdateCustomerDetails(customers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddCustomer()
        {
            try
            {
                customers.CustomerName = UIConsole.GetString("Enter Customer Name");
                customers.CustomerAddress = UIConsole.GetString("Enter The Address // City");
                customers.MobileNumber = UIConsole.GetLong("Enter The Mobile Number");
                customers.BillAmount = UIConsole.GetDouble("Enter The Bill Amount");
                customers.BillDate = UIConsole.GetDate("Enter The Bill Date");
                instance.AddNewCustomer(customers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}

