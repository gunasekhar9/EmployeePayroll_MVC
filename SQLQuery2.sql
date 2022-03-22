alter procedure addEmployee

(@emp_name varchar(50),
@profile_img varchar(200),
@gender varchar(50),
@department varchar(50),
@salary varchar(50),
@startDate varchar(50),
@notes varchar(50)
)

as
begin try
     insert into employeePayrollDetails values ( @emp_name, @profile_img, @gender, @department, @salary, @startDate, @notes)	 
end try
begin catch
  select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
end catch


alter procedure deleteEmployee
 
(
@emp_id int
)

as
begin try
     delete from employeePayrollDetails where  emp_id=@emp_id	 
end try
begin catch
  select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
end catch


alter procedure updateEmployee

(@emp_id int,
@emp_name varchar(50),
@profile_img varchar(200),
@gender varchar(50),
@department varchar(50),
@salary varchar(50),
@startDate varchar(50),
@notes varchar(50)
)

as
begin try
     update employeePayrollDetails set emp_name=@emp_name, profile_img=@profile_img, gender=@gender, department=@department, salary=@salary, startDate=@startDate, notes=@notes where emp_id = @emp_id
end try
begin catch
  select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
end catch



create procedure getEmployee


as
begin try
select * from employeePayrollDetails

end try
begin catch
  select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
end catch


exec addEmployee 'Gunasekhar','ghkj','Male', 'Depart','Salary','6-12-2012','notes'




