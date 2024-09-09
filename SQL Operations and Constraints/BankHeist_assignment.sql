use BlehmannBrothersBank

-- identificer max withdrawal
select *
from Transactions
where amount = (select max(amount) from Transactions where type = 'withdrawal')
and type = 'withdrawal'; -- får accountID på kunde som har mistet pengene. Slå nu op hvem kunden er. Har også tidspunkt for hvornår pengene er hævet fra kontoen

go  -- separer queries så de kører uafhængigt af hinanden

-- find kundens id
select *
from Accounts
where accountid = 102;  -- giver customer id

go

-- find kundens navn
select *
from Customers
where CustomerID = 2;

go

-- se hvilke handlinger ansatte har lavet på tidspunkt hvor kundens hævning er fundet sted
select *
from EmployeeActions
where Timestamp = '2024-03-15 14:30:00.0000000'; -- giver employee ID så kan se alle vedkommendes handlinger

go

-- se alle den ansattes handlinger
select *, convert(date, timestamp) as date
from EmployeeActions
where convert(date, timestamp) = '2024-03-15'
and employeeID = 3;  -- giver employeeID, kan nu se hvem har gjort det

go

-- se hvem den skyldige ansatte er
select *
from Employees
where employeeid = 3;

go



-- Kombiner ovenstående i en query som giver/opsummerer resultatet:


with
	-- lav tabel som indeholder den berøvede kundes oplysninger (består af et join mellem 3 tabeller)
	robbedCustomer as
		(select
			t.amount,
			t.accountID,
			t.type,
			t.timestamp,
			c.customerid
		from Transactions t
		inner join Accounts a on t.AccountID = a.AccountID
		inner join Customers c on a.CustomerID = c.CustomerID
		where t.amount = (select max(amount) from Transactions where type = 'withdrawal')
		),
	-- lav tabel som indeholder oplysninger om den skyldige medarbejder (join af 2 tabeller)
	guiltyEmployee as 
		(
		select
			ea.actionID,
			ea.timestamp,
			ea.employeeID,
			ea.actiontype
		from EmployeeActions ea
		inner join robbedCustomer rc on ea.timestamp = rc.timestamp
		)
-- lav query baseret på ovenstående 2 tabeller
SELECT
    rc.Amount as stolenAmount,
    --rc.AccountID as customerAccount,
    --rc.CustomerID,
    c.Name as customerName,
	--ge.ActionID,
    ge.Timestamp as timeOfTheft,
    --ge.EmployeeID as idOfGuiltyEmployee,
    e.Name as guiltyEmployeeName,
	e.Position as guiltyEmployeePosition
FROM robbedCustomer rc
INNER JOIN Customers c ON rc.CustomerID = c.CustomerID
LEFT JOIN guiltyEmployee ge ON rc.Timestamp = ge.Timestamp
LEFT JOIN Employees e ON ge.EmployeeID = e.EmployeeID;
