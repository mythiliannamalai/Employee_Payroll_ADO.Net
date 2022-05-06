USE [Payroll_services]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GetEmployeeData_FromDateRange]
	@From_Date Date,
	@toDate Date
AS
BEGIN	
	SET NOCOUNT ON;
select Employee_Payroll.Emp_Id,Emp_Name,Salary,Joining_Date,Gender,Department,Address,Pnone_number,Deductions,Taxable_Pay,Income_Tax,Net_Pay from Employee_Payroll
left join Depatment_Id on Employee_Payroll.Emp_Id=Depatment_Id.Emp_Id where Joining_Date between @From_Date and @toDate;   
END
GO
