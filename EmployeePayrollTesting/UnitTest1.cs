using NUnit.Framework;
using EmployeePayrollService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace EmployeePayrollTesting
{
    public class Tests
    {
        EmployeePayroll employeePayroll;
        Employee employee;
        [SetUp]
        public void Setup()
        {
            employeePayroll = new EmployeePayroll();
            employee = new Employee();
        }
        //UC-3 && 4  update salary testing
        [Test]
        public void UpdateSalary_Testing()
        {    
            Employee employee = new Employee();
            employee.Emp_Id = 6;
            employee.Emp_Name = "Terissa";
            employee.Salary = 300000;
            var res = EmployeePayroll.Updata_Salary(employee);
            Assert.AreEqual(employee.Emp_Name,res.Emp_Name);
        }
        //UC-5 get data feom partular date testing
        [Test]
        public void EmployeeDataFromDateRangeTesting()
        {
            Employee emp = new Employee();
            var From_Date = Convert.ToDateTime("2022-04-01");
            var toDate = Convert.ToDateTime("2022-04-25");
            var res = EmployeePayroll.GetEmployeeData_FromDateRange(From_Date, toDate);
            Assert.AreEqual(7, res.Count);
        }
    }
}