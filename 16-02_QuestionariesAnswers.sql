--Max Salary Designation Wise With Employee Name
select Designation,EmpName,Salary as EmployeeWithMaxSalaryInDesgn From Employee where 
                      salary in (SELECT MAX(Salary) FROM Employee Group By Designation);
-------------------------------------------------------------------------------------------------


-------------Create Strored Proc (SP) that will return Max Salary per DeptName

--select salary,DeptName From Employee inner join Department On Department.DeptNo=Employee.DeptNo;

create Procedure sp_GetAllEmployeesWithMaxSalByDeptName
As
Begin
      select max(Salary) as MaxSalaryInDepartment,DeptName from Employee Inner Join Department on Department.DeptNo = Employee.DeptNo Group By DeptName;
End

--drop procedure sp_GetAllEmployeesWithMaxSalByDeptName;

exec sp_GetAllEmployeesWithMaxSalByDeptName;
----------------------------------------------------------------


-----Select Second Max Salary Per Designation
select Designation,EmpName,Salary as EmployeeWithSecondMaxSalaryInDesg from Employee where 
             Designation in(select Designation from Employee group by Designation having COUNT(Designation)=1)
			 --if there is only one record exists for any Designation
union
SELECT Designation, EmpName, Salary as EmployeeWithSecondMaxSalaryInDesg FROM Employee WHERE 
             Salary IN (SELECT MAX(Salary) FROM Employee  where salary 
			            not in(SELECT MAX(Salary) FROM Employee GROUP BY Designation) GROUP BY Designation);
-------------------------------------------------------------------------------

--Second Max Salary Department Wise With Employee Name

select DeptNo, EmpName, Salary as EmployeeWithSecondMaxSalaryInDept from Employee where 
             DeptNo in(select DeptNo from Employee group by DeptNo having COUNT(DeptNo)=1)
			 ----if there is only one record exists for any Department
union
SELECT DeptNo, EmpName, Salary as EmployeeWithSecondMaxSalaryInDept FROM Employee WHERE 
             Salary IN (SELECT MAX(Salary) FROM Employee  where salary 
			            not in(SELECT MAX(Salary) FROM Employee GROUP BY DeptNo) GROUP BY DeptNo);
-----------------------------------------------------------------------------------------------


--------Create a SP that will insert row in Employee Table

create procedure sp_InsertIntoEmployee
@EmpNo int,@EmpName varchar(50),@Salary int,@Designation varchar(50),@DeptNo int,@Email varchar(50)
As
Begin
      Begin Try
            Insert Into Employee values(@EmpNo,@EmpName,@Salary,@Designation,@DeptNo,@Email);
	  End Try
	  Begin Catch
		Select ERROR_NUMBER() as Error_number,
		ERROR_SEVERITY() as Error_Severity,
		ERROR_MESSAGE() as Error_Meessage
	   End Catch
End;

--drop procedure sp_InsertIntoEmployee	

Declare @EmpNoActualParam int,@EmpNameActualParam varchar(50),@SalaryActualParam int,@DesignationActualParam varchar(50),
               @DeptNoActualParam int,@EmailActualParam varchar(50)

Set @EmpNoActualParam=125
Set @EmpNameActualParam='Narendra'

exec sp_InsertIntoEmployee @EmpNo=@EmpNoActualParam,@EmpName=@EmpNameActualParam,@Salary=987654,@Designation='Lead',
                    @DeptNo=20,@Email='Narendra@msit.com'

--select *from Employee

--drop function dbo.ValiDateData;
