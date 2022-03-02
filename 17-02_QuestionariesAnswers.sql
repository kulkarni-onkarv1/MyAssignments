--17-02-2002

--Create a Stored Provcedure that will perform an Insert Operation on Employee Table. 
--But before Performing the insert operation, this SP Must call the ValidateData() function which will accept the Employee Row parameters 
--and vbalidate it based on following conditions
--              EmpNo Must be +ve integer
--              EmpName Must containing Characters
--              Salary Must be +Ve integer
--              DeptNo Muset be present into Department table (Optional) 
--			          The alidateData() function will return 0 is any of the record-value is invalid else will return 1. 
					  
--The SP will perform insert operation accordingly

create Function ValiDationChecksForInsertionInEmployee(@EmpNo int,@EmpName varchar(50),@Salary int,@DeptNo int)
returns int
As
Begin 
      Declare @DeptNoPresence int
      --Exec @DeptNoPresence= sp_DeptNoValidation @DeptNo=@DeptNo;  
	  select @DeptNoPresence=DeptNo From Department where DeptNo=@DeptNo;
      Declare @ResultingFlag int;
	  if(@EmpNo<0 or @Salary<=0 or @EmpName like '%[^A-Z]%')
	       set @ResultingFlag=0;
	  else 
	      if(@DeptNoPresence=@DeptNo)
	       set @ResultingFlag=1;
		  else 
		    set @ResultingFlag=0;
 	  return @ResultingFlag;
End;

--drop function dbo.ValiDationChecksForInsertionInEmployee;

Declare @EmpNoActualParam int,@EmpNameActualParam varchar(50),@SalaryActualParam int,@DesignationActualParam varchar(50),
               @DeptNoActualParam int,@EmailActualParam varchar(50);

         Set @EmpNoActualParam=127;
         Set @EmpNameActualParam='Pawan';
		 set @SalaryActualParam=977654;
		 set @DesignationActualParam='Manager'
		 set @DeptNoActualParam=20;
		 set @EmailActualParam='Pawan@msit.com'

if(dbo.ValiDationChecksForInsertionInEmployee(@EmpNoActualParam,@EmpNameActualParam,@SalaryActualParam,@DeptNoActualParam)=1)
    Begin
	 Begin Try
        exec sp_InsertIntoEmployee @EmpNo=@EmpNoActualParam,@EmpName=@EmpNameActualParam,@Salary=@SalaryActualParam,@Designation=@DesignationActualParam,
                    @DeptNo=@DeptNoActualParam,@Email=@EmailActualParam;
	 End Try
	 Begin Catch
		Select ERROR_NUMBER() as Error_number,
		ERROR_SEVERITY() as Error_Severity,
		ERROR_MESSAGE() as Error_Meessage
	   End Catch
	 End
else 
     select 'Invalid Input Parameters' as Error



select *from Employee;

--delete from Employee where EmpNo=127;