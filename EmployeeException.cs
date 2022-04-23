using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollService
{
    public class EmployeeException : Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            No_Data_Found,
            Invertion_Error,
            No_Sql_Procedure,
            Connection_Failed
        }
        public EmployeeException(ExceptionType type, string message) : base(message)
        {
           this.type = type;
        }
    }
}
