use Company;

alter table Works_on
add constraint ForeignKey_WorksOn_Employee
foreign key (Essn) references Employee(SSN)
on delete cascade
on update cascade;