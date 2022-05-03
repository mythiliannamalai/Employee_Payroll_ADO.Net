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
        //UC-7 && 8 Add Contact testing
        [Test]
        public void Add_ContactTesting()
        {
            Employee emp = new Employee();
            EmployeePayroll employeePayroll = new EmployeePayroll();
            emp.Emp_Name = "Sumathi";
            emp.Salary = 70000;
            string JD = "2022-04-26";
            DateTime Joindate = Convert.ToDateTime(JD);
            emp.Joining_Date = Joindate;
            emp.Gender = "F";
            emp.Department = "Sales";
            emp.Address = "tamilnadu";
            emp.Deductions = 10000;
            emp.Taxable_Pay = 1000;
            emp.Income_Tax = 2000;
            emp.Net_Pay = 50000;
            var res = employeePayroll.Add_Contact(emp);
            Assert.AreEqual(emp.Emp_Name, res.Emp_Name);
        }
        //UC-11 Add emp details
        public void Add_EmpDetails()
        {
            Employee emp = new Employee();
            EmployeePayroll employeePayroll = new EmployeePayroll();
            emp.Emp_Name = "Saravanan";
            emp.Salary = 75000;
            string JD = "2022-04-26";
            DateTime Joindate = Convert.ToDateTime(JD);
            emp.Joining_Date = Joindate;
            emp.Gender = "F";
            emp.Department = "Sales";
            emp.Address = "tamilnadu";
            emp.Deductions = 10000;
            emp.Taxable_Pay = 1000;
            emp.Income_Tax = 2000;
            emp.Net_Pay = 50000;
            var res = employeePayroll.Add_Contact(emp);
            Assert.AreEqual(emp.Emp_Name, res.Emp_Name);
        }
    }
}