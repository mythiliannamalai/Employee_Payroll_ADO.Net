USE [Payroll_services]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Updata_Salary]
@Emp_Id int,
@Emp_Name varchar(50),
@Salary int
AS
BEGIN	
SET NOCOUNT ON;
	update Employee_Payroll set Salary=@Salary  where Emp_Id =@Emp_Id;	
	select Employee_Payroll.Emp_Id,Emp_Name,Salary,Joining_Date,Gender,Department,Address,Pnone_number,Deductions,Taxable_Pay,Income_Tax,Net_Pay from Employee_Payroll
	left join Depatment_Id on Employee_Payroll.Emp_Id=Depatment_Id.Emp_Id;
END
GO
exec Updata_Salary 1,Mythili,300000