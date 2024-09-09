use Company;

create table Dependent (
	Essn numeric(9,0) not null primary key,				-- Employee Social Security Number
	Dependent_Name nvarchar(50) not null,
	Sex nchar(1) null,
	BDate datetime null,
	Relationship nvarchar(50) null
);