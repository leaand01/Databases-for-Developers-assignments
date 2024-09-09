use Company;

alter table Works_on
add constraint ForeignKey_WorksOn_Project
foreign key (Pno) references Project(PNumber)
on delete cascade
on update cascade;