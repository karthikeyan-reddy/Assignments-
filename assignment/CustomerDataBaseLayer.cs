using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proj2_dlls.assignment
{
    public interface ICustomerDataBaseLayer
    {
        void AddNewCustomer(Customers customers);
        void UpdateCustomerDetails(Customers customers);
        void deleteCustomer(int CustomerId);
        List<Customers> FindCustomerByPhoneNumber(long PhoneNumber);
        List<Customers> FindCustomerByCity(string City);
        List<Customers> FindCustomerByPartialName(string CustomerName);
    }
    class DataAccessLayer : ICustomerDataBaseLayer
    {
        private static readonly string STRConnection = @"Data Source=W-674PY03-1;Initial Catalog=karthik;Persist Security Info=True;User ID=sa;Password=Password@12345";
        const string Insert = "insert into Customers values(@CustomerName,@CustomerAddress,@MobileNumber,@BillAmount,@BillDate)";
        const string update = "update Customers set CustomerName = @CustomerName , CustomerAddress = @CustomerAddress,MobileNumber = @MobileNumber,BillAmount=@BillAmount,BillDate=@BillDate where Customerid = @Customerid";
        const string delete = "delete from Customers where Customerid = @Customerid";
        const string findbyphone = "select * from Customers where Customers.MobileNumber = @MobileNumber";
        const string findbyCity = "select * from Customers where Customers.CustomerAddress = @CustomerAddress";
        const string findbyname = "select * from Customers where Customers.CustomerName like '%@CustomerName%' ";
        
        public void AddNewCustomer(Customers customers)
        {
            SqlConnection Con = new SqlConnection(STRConnection);
            SqlCommand Cmd = new SqlCommand(Insert, Con);
            Cmd.Parameters.AddWithValue("@CustomerName", customers.CustomerName);
            Cmd.Parameters.AddWithValue("@CustomerAddress", customers.CustomerAddress);
            Cmd.Parameters.AddWithValue("@MobileNumber", customers.MobileNumber);
            Cmd.Parameters.AddWithValue("@BillDate", customers.BillDate);
            Cmd.Parameters.AddWithValue("@BillAmount", customers.BillAmount);

            try
            {
                Con.Open();
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        public void deleteCustomer(int CustomerId)
        {
            SqlConnection Con = new SqlConnection(STRConnection);
            SqlCommand Cmd = new SqlCommand(delete, Con);
            Cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
            try
            {
                Con.Open();
                Cmd.ExecuteNonQuery();
                UIConsole.PrintMessage("Succesfully Removed The Book From DataBase");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Con.Close();
            }
        }

        public List<Customers> FindCustomerByCity(string City)
        {
            Customers customerinfo = new Customers();
            SqlConnection Con = new SqlConnection(STRConnection);
            SqlCommand Cmd = new SqlCommand(findbyCity, Con);
            Cmd.Parameters.AddWithValue("@CustomerAddress", City);
            List<Customers> customerslist = new List<Customers>();
            try
            {
                Con.Open();
                var read = Cmd.ExecuteReader();
                if (read == null)
                {
                    customerslist = null;
                }
                else
                {
                    while (read.Read())
                    {
                        var row = new Customers
                        {
                            CustomerId = Convert.ToInt32(read[0]),
                            CustomerName = read[1].ToString(),
                            CustomerAddress =read[2].ToString(),
                            MobileNumber = Convert.ToInt64(read[3]),
                            BillAmount = Convert.ToDouble(read[4]),
                            BillDate = Convert.ToDateTime(read[5])

                        };
                        customerslist.Add(row);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Con.Close();
            }
            return customerslist;
        }

        public List<Customers> FindCustomerByPartialName(string CustomerName)
        {
            Customers customerinfo = new Customers();
            SqlConnection Con = new SqlConnection(STRConnection);
            SqlCommand Cmd = new SqlCommand(findbyname, Con);
            Cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
            List<Customers> customerslist = new List<Customers>();
            try
            {
                Con.Open();
                var read = Cmd.ExecuteReader();
                if (read == null)
                {
                    customerslist = null;
                }
                else
                {
                    while (read.Read())
                    {
                        var row = new Customers
                        {
                            CustomerId = Convert.ToInt32(read[0]),
                            CustomerName = read[1].ToString(),
                            CustomerAddress = read[2].ToString(),
                            MobileNumber = Convert.ToInt64(read[3]),
                            BillAmount = Convert.ToDouble(read[4]),
                            BillDate = Convert.ToDateTime(read[5])

                        };
                        customerslist.Add(row);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Con.Close();
            }
            return customerslist;
        }

        public List<Customers> FindCustomerByPhoneNumber(long PhoneNumber)
        {
            Customers customerinfo = new Customers();
            SqlConnection Con = new SqlConnection(STRConnection);
            SqlCommand Cmd = new SqlCommand(findbyphone, Con);
            Cmd.Parameters.AddWithValue("@MobileNumber", PhoneNumber);
            List<Customers> customerslist = new List<Customers>();
            try
            {
                Con.Open();
                var read = Cmd.ExecuteReader();
                if (read == null)
                {
                    customerslist = null;
                }
                else
                {
                    while (read.Read())
                    {
                        var row = new Customers
                        {
                            CustomerId = Convert.ToInt32(read[0]),
                            CustomerName = read[1].ToString(),
                            CustomerAddress = read[2].ToString(),
                            MobileNumber = Convert.ToInt64(read[3]),
                            BillAmount = Convert.ToDouble(read[4]),
                            BillDate = Convert.ToDateTime(read[5])

                        };
                        customerslist.Add(row);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Con.Close();
            }
            return customerslist;
        }

        public void UpdateCustomerDetails(Customers customers)
        {
            SqlConnection Con = new SqlConnection(STRConnection);
            SqlCommand Cmd = new SqlCommand(update, Con);
            Cmd.Parameters.AddWithValue("@CustomerId", customers.CustomerId);
            Cmd.Parameters.AddWithValue("@CustomerName", customers.CustomerName);
            Cmd.Parameters.AddWithValue("@CustomerAddress", customers.CustomerAddress);
            Cmd.Parameters.AddWithValue("@MobileNumber", customers.MobileNumber);
            Cmd.Parameters.AddWithValue("@BillDate", customers.BillDate);
            Cmd.Parameters.AddWithValue("@BillAmount", customers.BillAmount);
            try
            {
                Con.Open();
                int rowsAffected = Cmd.ExecuteNonQuery();
                if (rowsAffected != 1)
                    throw new Exception("No Record found to update");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Con.Close();
            }
        }
    }
}
