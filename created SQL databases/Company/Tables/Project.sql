use Company;

create table Project (
	PName nvarchar(50) null,
	PNumber int not null primary key,
	PLocation nvarchar(50) null,
	DNum int null
);