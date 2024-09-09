use Company;

create table Department (
	DName nvarchar(50) null,
	DNumber int not null primary key,
	MgrSSN numeric(9,0) null,			-- Manager Social Security Number
	MgrStartDate datetime null
);