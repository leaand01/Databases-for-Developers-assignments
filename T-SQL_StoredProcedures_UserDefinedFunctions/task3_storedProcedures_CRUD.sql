/*
Task 3: Stored Procedure: CRUD
Create stored procedures for the following CRUD operations on the Customers table:

CreateCustomer: Inserts a new customer into the Customers table.				-- KUN LAVET DENNE
UpdateCustomer: Updates the information of an existing customer.
DeleteCustomer: Deletes a customer from the Customers table.					-- OG LAVET DENNE
*/

use ShopDB;
go


-- Definer CreateCustomer

--drop procedure if EXISTS CreateCustomer;
--go

-- har IKKE implementeret tjek så hvis navn og email er det samme som eksisterende bruger så opret ikke.
create procedure CreateCustomer
--	@customerid int,  -- opret automatisk      RETTELSE skal ikke selv oprette denne da er en primary key og laves automatisk ved oprettelse af ny bruger
	@name nvarchar(100),
	@email nvarchar(100),
--	@registrationdate datetime,  -- opret automatisk
	@status nvarchar(50)
as
begin
--	declare @HighestExistingCustomerID int;
	
--	select @HighestExistingCustomerID = max(CustomerID) 
--    from Customers;

	declare @creationdate datetime;
	
	set @creationdate = cast(convert(date, getdate()) as datetime); -- definer til dags dato men med tidsstempel 00:00:00.000


	--insert into Customers (CustomerID, Name, Email, RegistrationDate, Status)
	insert into Customers (Name, Email, RegistrationDate, Status)
	values (
--		ISNULL(@HighestExistingCustomerID, 0) + 1,
		@name,
		@email,
		@creationdate,
		@status
		)
end;
go



-- Definer DeleteCustomer

--drop procedure if EXISTS DeleteCustomer;
--go

create procedure DeleteCustomer
	@customerid int
as
begin
	if exists (select 1 from Customers where customerid = @customerid) -- if statement, hvis true så gå ind i begin
	begin
		delete from Customers
		where CustomerID = @customerid

		print 'customer with id ' +  cast(@customerid as nvarchar) + ' is deleted';
	end
	else
	begin
		print 'customerid ' + cast(@customerid as nvarchar) + ' not found';
	end
end;
go
