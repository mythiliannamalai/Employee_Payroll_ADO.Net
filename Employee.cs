using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EmployeePayrollService
{
    public class Employee
    {
        public int Emp_Id { get; set; }
        public string Emp_Name { get; set; }
        public int Salary { get; set; }
        public DateTime Joining_Date { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public Int64 Phone_number { get; set; }
        public int Deductions { get; set; }
        public int Taxable_Pay { get; set; }
        public int Income_Tax { get; set; }
        public int Net_Pay { get; set; }
    }
}
