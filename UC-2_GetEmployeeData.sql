USE [Payroll_services]
Go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter PROCEDURE [GetEmployeeData]
AS
BEGIN   
	select Employee_Payroll.Emp_Id,Emp_Name,Salary,Joining_Date,Gender,
	Department,Address,Pnone_number,Deductions,Taxable_Pay,Income_Tax,Net_Pay from Employee_Payroll
	
END
GO
