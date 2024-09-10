use BlehmannBrothersBank

-- identificer max withdrawal
select *
from Transactions
where amount = (select max(amount) from Transactions where type = 'withdrawal')
and type = 'withdrawal'; -- f�r accountID p� kunde som har mistet pengene. Sl� nu op hvem kunden er. Har ogs� tidspunkt for hvorn�r pengene er h�vet fra kontoen

go  -- separer queries s� de k�rer uafh�ngigt af hinanden

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

-- se hvilke handlinger ansatte har lavet p� tidspunkt hvor kundens h�vning er fundet sted
select *
from EmployeeActions
where Timestamp = '2024-03-15 14:30:00.0000000'; -- giver employee ID s� kan se alle vedkommendes handlinger

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



-- Kombiner ovenst�ende i en query som giver/opsummerer resultatet:

/*
set statistics time on;  -- m�l hvor hurtigt query er
with
	-- lav tabel som indeholder den ber�vede kundes oplysninger (best�r af et join mellem 3 tabeller)
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
-- lav query baseret p� ovenst�ende 2 tabeller
select
    rc.Amount as stolenAmount,
    --rc.AccountID as customerAccount,
    --rc.CustomerID,
    c.Name as customerName,
    ge.Timestamp as timeOfTheft,
	--ge.ActionID,
    --ge.EmployeeID as idOfGuiltyEmployee,
    e.Name as guiltyEmployeeName,
	e.Position as guiltyEmployeePosition
from robbedCustomer rc
inner join Customers c ON rc.CustomerID = c.CustomerID
left join guiltyEmployee ge ON rc.Timestamp = ge.Timestamp
left join Employees e ON ge.EmployeeID = e.EmployeeID;
set statistics time off;
*/


-- fors�gt optimeret ovenst�ende i sidste select statement og tilf�je variable i konstruerede tabeller

set statistics time on;
with
	-- lav tabel som indeholder den ber�vede kundes oplysninger (best�r af et join mellem 3 tabeller)
	robbedCustomer as
		(select
			t.amount,
			t.accountID,
			t.type,
			t.timestamp,
			c.customerid,
			c.Name			-- tilf�jet
		from Transactions t
		inner join Accounts a on t.AccountID = a.AccountID
		inner join Customers c on a.CustomerID = c.CustomerID
		where t.amount = (select max(amount) from Transactions where type = 'withdrawal')
		),
	-- lav tabel som indeholder oplysninger om den skyldige medarbejder (join af 3 tabeller)
	guiltyEmployee as 
		(
		select
			ea.actionID,
			ea.timestamp,
			ea.employeeID,
			ea.actiontype,
			e.Name,			-- tilf�jet
			e.Position		-- tilf�jet
		from EmployeeActions ea
		inner join robbedCustomer rc on ea.timestamp = rc.timestamp
		inner join Employees e on ea.EmployeeID = e.EmployeeID			-- tilf�jet
		)
-- lav query baseret p� ovenst�ende 2 tabeller
select
    rc.Amount as stolenAmount,
    --rc.AccountID as customerAccount,
    --rc.CustomerID,
	rc.Name as customerName,
    --ge.ActionID,
    ge.Timestamp as timeOfTheft,
	ge.Name as guiltyEmployeeName,
	ge.Position as guiltyEmployeePosition
    --ge.EmployeeID as idOfGuiltyEmployee
from robbedCustomer rc
left join guiltyEmployee ge ON rc.Timestamp = ge.Timestamp		-- ved ovenst�ende tilf�jelser beh�ver jeg ikke joine med table Customers og Employees her
set statistics time off;										-- hmm kan ikke m�le hvilken en query der er hurtigst?


/*
Vigtigt ift ovenst�ende og Query Trees.

Afh�ngig af hvilke variable vil have ud i nederste query kan jeg lave om i nederste query.
Hvis vil have udkommenteret ovenst�ende variable burde jeg optimere mit query tree, s�ledes at min query er mest effektiv og hurtig,
ved ikke at inkludere un�dvendige variable i mit select statement i de konstruerede queryies defineret under with-statementet.

*/
