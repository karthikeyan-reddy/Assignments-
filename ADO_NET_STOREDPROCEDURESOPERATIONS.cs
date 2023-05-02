using System;
using System.Data.SqlClient;
using System.Data;
namespace DataBaseConnection
{
    class Ex01_SingleTierOperation
    {
        const string STRCONNECTION = @"Data Source=W-674PY03-1;Initial Catalog=karthik;Persist Security Info=True;User ID=sa;Password=Password@12345";
        const string selectall = "select * from tblemployee";
        static void Main(string[] args)
        {
            //readrecords();//for DQL Operations
            //insertrecordes(UIConsole.GetString("Enter The Name"),UIConsole.GetLong("Enter Mobile Number"),UIConsole.GetNumber("Enter The salary"),UIConsole.GetNumber("Enter The Dept Id"),UIConsole.GetNumber("Enter The city id"));//For Dml Operations

            //insertintousingprocedures(UIConsole.GetString("Enter The Name"), UIConsole.GetLong("Enter Mobile Number"), UIConsole.GetNumber("Enter The salary"), UIConsole.GetNumber("Enter The Dept Id"), UIConsole.GetNumber("Enter The city id"));
            // DeletedusingProc(UIConsole.GetNumber("Enter The Id to Delete The Record"));
            updatingusingproc(UIConsole.GetString("Enter The Name"), UIConsole.GetLong("Enter Mobile Number"), UIConsole.GetNumber("Enter The salary"), UIConsole.GetNumber("Enter The Dept Id"), UIConsole.GetNumber("Enter The city id"),UIConsole.GetNumber("Enter The id to Update "));
        }

        private static void updatingusingproc(string name, long phone, int salary, int dept, int city,int id)
        {
            string updatedata = "UpdateEmployees";
            var Con = new SqlConnection(STRCONNECTION);
            var cmd = new SqlCommand(updatedata, Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empName", name);
            cmd.Parameters.AddWithValue("@empSalary",salary);
            cmd.Parameters.AddWithValue("@empPhone", phone);
            cmd.Parameters.AddWithValue("@deptId", dept);
            cmd.Parameters.AddWithValue("@cityId", city);
            cmd.Parameters.AddWithValue("@empId", id);
            try
            {
                Con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DeletedusingProc(int empid)
        {
            string deletion = "deleteemployee";
            var con = new SqlConnection(STRCONNECTION);
            var cmd = new SqlCommand(deletion, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", empid);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private static void insertintousingprocedures(string name, long phone, int salary, int deptid, int cityid)
        {
            int igenerated = 0;
            string inserttbl = "InsertEmployees";
            var con = new SqlConnection(STRCONNECTION);
            var cmd = new SqlCommand(inserttbl,con);
            cmd.CommandType =CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empName", name);
            cmd.Parameters.AddWithValue("@empsalary", salary);
            cmd.Parameters.AddWithValue("@empphone", phone);
            cmd.Parameters.AddWithValue("@deptId", deptid);
            cmd.Parameters.AddWithValue("@cityid", cityid);
            cmd.Parameters.AddWithValue("@empid", igenerated);
            cmd.Parameters[5].Direction = ParameterDirection.Output;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("The Generated value is : "+ cmd.Parameters[5].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private static void insertrecordes(string name, long phone, int salary, int dept, int city)
        {
            string pass = $"insert into tblemployee values ('{name}',{phone},{salary},{dept},{city})";
           var con = new SqlConnection(STRCONNECTION);
            var cmd = new SqlCommand(pass, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private static void readrecords()
        {
            //Establish The Connection with SQL Server
            SqlConnection sqlcmd = new SqlConnection();
            sqlcmd.ConnectionString = STRCONNECTION;
            try
            {
                sqlcmd.Open();
                //Create Command to access data
                SqlCommand command = new SqlCommand();
                command.Connection = sqlcmd;
                //create a Reader to read The data retrieved from server
                command.CommandText = selectall;
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Console.WriteLine("{0},{1}",reader["empsalary"],reader["empname"]);
                }
            }
            catch (SqlException ex)
            {
                UIConsole.PrintNegativeMessage(ex.Message);
            }
            finally
            {
                if (sqlcmd.State == System.Data.ConnectionState.Open)
                    sqlcmd.Close();
            }
           
        }
    }
}
