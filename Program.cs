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
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Payroll; Integrated Security=SSPI;";
        static SqlConnection connection=new SqlConnection(connectionString);
        //UC-1 Check connection
        public void EstablishConnection()
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

        static void Main(string[]args)
        {
            EmployeePayroll employeePayroll= new EmployeePayroll();
            employeePayroll.EstablishConnection();
        }
    }


}