SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 alter PROCEDURE [DeleteEmp_Details]
@Emp_Name varchar(50)
AS
BEGIN	
	SET NOCOUNT ON;
	Delete Employee_Payroll where Emp_Name=@Emp_Name;
   	select Employee_Payroll.Emp_Id,Emp_Name,Salary,Joining_Date,Gender,Department,Address,Pnone_number,Deductions,Taxable_Pay,Income_Tax,Net_Pay from Employee_Payroll;	
END
GO
