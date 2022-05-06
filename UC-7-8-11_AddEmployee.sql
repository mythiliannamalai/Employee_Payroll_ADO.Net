USE [Payroll_services]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [Add_Empoloyee]
@Emp_Id int,
@Emp_Name varchar(50),
@Salary int,
@Joining_Date datetime,
@Gender varchar(1),
@Department varchar(20),
@Address varchar(20),
@Pnone_number int,
@Deductions int,
@Taxable_Pay int,
@Income_Tax int,
@Net_Pay int
AS
BEGIN
insert into Employee_Payroll(Emp_Id,Emp_Name,Salary,Joining_Date,Gender,Department,Address,Pnone_number,Deductions,Taxable_Pay,Income_Tax,Net_Pay)
	values (@Emp_Id,@Emp_Name,@Salary,@Joining_Date,@Gender,@Department,@Address,@Pnone_number,@Deductions,@Taxable_Pay,@Income_Tax,@Net_Pay);  
	
END
GO

exec Add_Empoloyee 8,Sumathi,75000,'2022-05-03',F,Sales,Tamilnadu,9600474622,10000,1000,200,35000