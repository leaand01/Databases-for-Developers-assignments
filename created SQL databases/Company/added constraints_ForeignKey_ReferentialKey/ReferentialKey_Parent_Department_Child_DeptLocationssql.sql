use Company;

alter table Dept_Locations
add constraint ForeignKey_DeptLocations_Department
foreign key (DNumber) references Department(DNumber)
on delete cascade
on update cascade;