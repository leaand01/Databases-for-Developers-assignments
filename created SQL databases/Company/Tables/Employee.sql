use Company;

create table Employee (
	FName nvarchar(50) null,	-- First name, allows Null
	Minit char(1) null,			-- Middle initial of employee
	LName nvarchar(50) null,
	SSN numeric(9,0) not null primary key,
	BDate datetime null,
	Address nvarchar(50) null,
	Sex char(1) null,
	Salary numeric(10,2) null,
	SuperSSN numeric(9,0) null, -- Social Security Number of employees supervisor
	Dno int null
);