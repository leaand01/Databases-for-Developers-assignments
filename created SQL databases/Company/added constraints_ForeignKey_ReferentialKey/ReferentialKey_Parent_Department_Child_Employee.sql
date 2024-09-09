use Company;

-- Tilf�j en fremmedn�gleconstraint til Employee-tabellen
alter table Employee									-- �ndre i employee tabellen
add constraint ForeignKey_Employee_Department			-- opret en constraint med navnet ForeignKey_Employee_Department
foreign key (Dno) references Department(DNumber)        -- angiv at kolonnen Dno i Employee refererer til  DNumber i Department-tabellen. Dvs kan ikke inserte en employee med Dno som ikke findes i Department.DNumber.
on delete cascade										-- Dvs hvis sletter et DNumber i Department (som her er parent tabellen) vil r�kker i Employee (child-tabellen) med samme DNumber blive slettet
on update cascade;										-- hvis �ndrer DNumber i parent-tabellen Department vil den blive �ndret tilsvarende i child-tabellen Employee