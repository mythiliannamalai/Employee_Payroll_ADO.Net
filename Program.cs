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
        //UC-2 retrive data from database
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
        //UC-3 && UC-4 Update salary
        public static Employee Updata_Salary(Employee employee)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string spname = "dbo.Updata_Salary";
                    SqlCommand Command = new SqlCommand(spname, connection);
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@Emp_Id", employee.Emp_Id);
                    Command.Parameters.AddWithValue("@Emp_Name", employee.Emp_Name);
                    Command.Parameters.AddWithValue("@Salary", employee.Salary);
                    employee = new Employee();
                    connection.Open();
                    SqlDataReader reader = Command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employee.Emp_Id = (int)reader["Emp_Id"];
                            employee.Emp_Name = (string)reader["Emp_Name"];
                            employee.Salary = (int)reader["Salary"];
                            employee.Joining_Date = (DateTime)reader["Joining_Date"];
                            employee.Gender = (String)reader["Gender"];
                            employee.Department = (String)reader["Department"];
                            employee.Address = (string)reader["Address"];                            
                            employee.Deductions = (int)reader["Deductions"];
                            employee.Taxable_Pay = (int)reader["Taxable_Pay"];
                            employee.Income_Tax = (int)reader["Income_Tax"];
                            employee.Net_Pay = (int)reader["Net_Pay"];
                        }
                        connection.Close();
                        return employee;
                    }
                }
            }
            catch (EmployeeException)
            {
                throw new EmployeeException(EmployeeException.ExceptionType.No_Data_Found, "Data not found...");
            }
            return null;
        }
        
        static void Main(string[]args)
        {
            EmployeePayroll.EstablishConnection();
            EmployeePayroll.GetEmployeeData();


        }
    }
}