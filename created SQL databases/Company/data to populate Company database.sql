-- load table Department

INSERT INTO Department(DName, DNumber, MgrSSN, MgrStartDate) VALUES (N'Headquarters', 1, 888665555, N'1971-06-19')
INSERT INTO Department(DName, DNumber, MgrSSN, MgrStartDate) VALUES (N'Administration', 4, 123456789, N'1986-01-01')
INSERT INTO Department(DName, DNumber, MgrSSN, MgrStartDate) VALUES (N'Research', 5, 987654321, N'1978-05-22')

-- load table Dependent

INSERT INTO  [Dependent] (Essn, Dependent_Name, Sex, BDate, Relationship) VALUES (123456789, N'Alice', N'F', N'1978-12-31', N'Daughter')
INSERT INTO  [Dependent] (Essn, Dependent_Name, Sex, BDate, Relationship) VALUES (123456789, N'Elizabeth', N'F', N'1957-05-05', N'Spouse')
INSERT INTO  [Dependent] (Essn, Dependent_Name, Sex, BDate, Relationship) VALUES (123456789, N'Michael', N'M', N'1978-01-01', N'Son')
INSERT INTO  [Dependent] (Essn, Dependent_Name, Sex, BDate, Relationship) VALUES (333445555, N'Alice', N'F', N'1976-04-05', N'Daughter')
INSERT INTO  [Dependent] (Essn, Dependent_Name, Sex, BDate, Relationship) VALUES (333445555, N'Joy', N'F', N'1948-05-03', N'Spouse')
INSERT INTO  [Dependent] (Essn, Dependent_Name, Sex, BDate, Relationship) VALUES (333445555, N'Theodore', N'M', N'1973-10-25', N'Son')
INSERT INTO  [Dependent] (Essn, Dependent_Name, Sex, BDate, Relationship) VALUES (987654321, N'Abner', N'M', N'1932-02-29', N'Spouse')

-- load table Dept_Locations

INSERT INTO Dept_Locations (DNUmber, DLocation) VALUES (1, N'Houston')
INSERT INTO Dept_Locations (DNUmber, DLocation) VALUES (4, N'Stafford')
INSERT INTO Dept_Locations (DNUmber, DLocation) VALUES (5, N'Bellaire')
INSERT INTO Dept_Locations (DNUmber, DLocation) VALUES (5, N'Houston')
INSERT INTO Dept_Locations (DNUmber, DLocation) VALUES (5, N'Sugarland')

-- load table Employee

INSERT INTO Employee (FName, Minit, LName, SSN, BDate, Address, Sex, Salary, SuperSSN, Dno) VALUES (N'John', N'B', N'Smith', 123456789, N'1955-01-09', N'731 Fondren, Houston, TX', N'M', 30000.00, 987654321, 5)
INSERT INTO Employee (FName, Minit, LName, SSN, BDate, Address, Sex, Salary, SuperSSN, Dno) VALUES (N'Franklin', N'T', N'Wong', 333445555, N'1945-12-08', N'638 Voss, Houston, TX', N'M', 40000.00, 987654321, 5)
INSERT INTO Employee (FName, Minit, LName, SSN, BDate, Address, Sex, Salary, SuperSSN, Dno) VALUES (N'Joyce', N'A', N'English', 453453453, N'1962-07-31', N'5631 Rice, Houston, TX', N'F', 25000.00, 987654321, 5)
INSERT INTO Employee (FName, Minit, LName, SSN, BDate, Address, Sex, Salary, SuperSSN, Dno) VALUES (N'Ramesh', N'K', N'Narayan',666884444, N'1952-09-15', N'974 Fire Oak, Humble, TX', N'M', 38000.00, 987654321, 5)
INSERT INTO Employee (FName, Minit, LName, SSN, BDate, Address, Sex, Salary, SuperSSN, Dno) VALUES (N'James', N'E', N'Borg', 888665555, N'1927-11-10', N'450 Stone, Houston, TX', N'M', 55000.00, NULL, 1)
INSERT INTO Employee (FName, Minit, LName, SSN, BDate, Address, Sex, Salary, SuperSSN, Dno) VALUES (N'Jennifer', N'S', N'Wallace', 987654321, N'1931-06-20', N'291 Berry, Bellaire, TX', N'F', 36000.00, 123456789, 4)
INSERT INTO Employee (FName, Minit, LName, SSN, BDate, Address, Sex, Salary, SuperSSN, Dno) VALUES (N'Ahmad', N'V', N'Jabbar', 987987987, N'1959-03-29', N'980 Dallas, Houston, TX', N'M', 25000.00, 123456789, 4)
INSERT INTO Employee (FName, Minit, LName, SSN, BDate, Address, Sex, Salary, SuperSSN, Dno) VALUES (N'Alicia', N'J', N'Zelaya', 999887777, N'1958-07-19', N'3321 Castle, Spring, TX', N'F', 25000.00, 123456789, 4)

-- load table Project

INSERT INTO Project (PName, PNumber, PLocation, DNum) VALUES (N'ProductX', 1, N'Bellaire', 5)
INSERT INTO Project (PName, PNumber, PLocation, DNum) VALUES (N'ProductY', 2, N'Sugarland', 5)
INSERT INTO Project (PName, PNumber, PLocation, DNum) VALUES (N'ProductZ', 3, N'Houston', 5)
INSERT INTO Project (PName, PNumber, PLocation, DNum) VALUES (N'Computerization', 10, N'Stafford', 4)
INSERT INTO Project (PName, PNumber, PLocation, DNum) VALUES (N'Reorganization', 20, N'Houston', 1)
INSERT INTO Project (PName, PNumber, PLocation, DNum) VALUES (N'Newbenefits', 30, N'Stafford', 4)

-- load table Works_on
INSERT INTO Works_on (Essn, Pno, [Hours]) VALUES (123456789, 1, 32)
INSERT INTO Works_on (Essn, Pno, [Hours]) VALUES (123456789, 2, 8)
INSERT INTO Works_on (Essn, Pno, [Hours]) VALUES (333445555, 2, 10)
INSERT INTO Works_on (Essn, Pno, [Hours]) VALUES (333445555, 3, 10)
INSERT INTO Works_on (Essn, Pno, [Hours]) VALUES (333445555, 10, 10)
INSERT INTO Works_on (Essn, Pno, [Hours]) VALUES (333445555, 20, 10)
INSERT INTO Works_on (Essn, Pno, [Hours]) VALUES (453453453, 1, 20)
INSERT INTO Works_on (Essn, Pno, [Hours]) VALUES (453453453, 2, 20)
INSERT INTO Works_on (Essn, Pno, [Hours]) VALUES (666884444, 3, 40)
INSERT INTO Works_on (Essn, Pno, [Hours]) VALUES (888665555, 20, NULL)
INSERT INTO Works_on (Essn, Pno, [Hours]) VALUES (987654321, 20, 15)
INSERT INTO Works_on (Essn, Pno, [Hours]) VALUES (987654321, 30, 20)
INSERT INTO Works_on (Essn, Pno, [Hours]) VALUES (987987987, 10, 35)
INSERT INTO Works_on (Essn, Pno, [Hours]) VALUES (987987987, 30, 5)
INSERT INTO Works_on (Essn, Pno, [Hours]) VALUES (999887777, 10, 10)
INSERT INTO Works_on (Essn, Pno, [Hours]) VALUES (999887777, 30, 30)

-- Setup referential integrity constraints

ALTER TABLE Department ADD CONSTRAINT FK_Department_Employee FOREIGN KEY(MgrSSN)	-- tilføjer her 3 referential keys som jeg selv har overset
REFERENCES Employee(SSN)
GO

-- selv lavet nedenstående foreign keys her C:\easv\Databases for Developers\Opgaver\Databases-for-Developers-assignments\created SQL databases\Company\added constraints_ForeignKey_ReferentialKey
/*
ALTER TABLE Dependent ADD CONSTRAINT FK_Dependent_Employee FOREIGN KEY(Essn)  
REFERENCES Employee(SSN)
GO


ALTER TABLE Dept_Locations ADD CONSTRAINT FK_Dept_Locations_Department FOREIGN KEY(DNUmber)
REFERENCES Department(DNumber)
GO

ALTER TABLE Employee ADD CONSTRAINT FK_Employee_Department FOREIGN KEY(Dno)
REFERENCES Department(DNumber)
GO
*/

ALTER TABLE Employee ADD CONSTRAINT FK_Employee_Employee FOREIGN KEY(SuperSSN)
REFERENCES Employee(SSN)
GO

ALTER TABLE Project ADD CONSTRAINT FK_Project_Department FOREIGN KEY(DNum)
REFERENCES Department(DNumber)
GO

-- selv lavet nedenstående foreign keys her C:\easv\Databases for Developers\Opgaver\Databases-for-Developers-assignments\created SQL databases\Company\added constraints_ForeignKey_ReferentialKey
/*
ALTER TABLE Works_on ADD CONSTRAINT FK_Works_on_Employee FOREIGN KEY(Essn)
REFERENCES Employee(SSN)
GO

ALTER TABLE Works_on ADD CONSTRAINT FK_Works_on_Project FOREIGN KEY(Pno)
REFERENCES Project(PNumber)
GO
*/