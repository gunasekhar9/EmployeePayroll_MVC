create database employeeMvc
use employeeMvc

create table employeePayrollDetails
( emp_id int not null identity(1,1) primary key,
  emp_name varchar(50), profile_img varchar(200),
  gender varchar(50), department varchar(50),
  salary varchar(50), startDate  varchar(50),
  notes varchar(50)
)
 select * from employeePayrollDetails