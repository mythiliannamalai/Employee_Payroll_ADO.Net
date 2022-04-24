using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
namespace EmployeePayrollService
{   
    public class EmployeePayroll
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Payroll_services; Integrated Security=SSPI;";
        static SqlConnection connection=new SqlConnection(connectionString);
        //UC-1 Check connection
        public static void EstablishConnection()
        {
            if (connection != null && connection.State.Equals(ConnectionState.Closed))
                {
                try
                {
                    connection.Open();                    
                }
                catch (Exception)
                {
                    throw new EmployeeException(EmployeeException.ExceptionType.Connection_Failed, "Connection failed..");
                }
            }           
                if (connection != null && connection.State.Equals(ConnectionState.Open))
                {
                    try
                    {
                        connection.Close();                        
                    }
                    catch (Exception)
                    {
                        throw new EmployeeException(EmployeeException.ExceptionType.Connection_Failed, "Connection failed..");
                    }
                }            
        }
        public static List<Employee> GetEmployeeData()
        {
            List<Employee> employees = new List<Employee>();
            Employee emp=new Employee();
            SqlConnection connection = new SqlConnection(connectionString);
            string spname = "dbo.GetEmployeeData";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(spname, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader=sqlCommand.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        emp.Emp_Id = reader.GetInt32(0);
                        emp.Emp_Name = reader.GetString(1);
                        emp.Salary= reader.GetInt32(2);
                        emp.Joining_Date=reader.GetDateTime(3);
                        emp.Gender=reader.GetString(4);
                        emp.Department=reader.GetString(5);
                        emp.Address = reader.GetString(6);
                        emp.Phone_number = reader.GetInt32(7);
                        emp.Deductions=reader.GetInt32(8);
                        emp.Taxable_Pay = reader.GetInt32(9);
                        emp.Income_Tax=reader.GetInt32(10);
                        emp.Net_Pay=reader.GetInt32(11);
                        employees.Add(emp);
                        Console.WriteLine(emp.Emp_Id +","+ emp.Emp_Name+","+ emp.Salary+","+ emp.Joining_Date+","+ emp.Gender+","+ emp.Department);
                    }
                    connection.Close();
                }
                return employees;
            }
        }

        static void Main(string[]args)
        {             
            EmployeePayroll.EstablishConnection();
           EmployeePayroll.GetEmployeeData();
        }
    }


}