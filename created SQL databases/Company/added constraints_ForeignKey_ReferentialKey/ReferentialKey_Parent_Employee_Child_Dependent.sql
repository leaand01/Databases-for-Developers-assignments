use Company;

alter table Dependent
add constraint ForeignKey_Dependent_Employee
foreign key (Essn) references Employee(SSN)
on delete cascade
on update cascade;