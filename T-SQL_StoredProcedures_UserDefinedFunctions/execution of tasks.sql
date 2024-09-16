use ShopDB;
go

exec all_orders_of_customer_with_id 1;
go

exec all_orders_within_dates @startdate='2025-03-03', @enddate='2025-06-16';
go

exec CreateCustomer @name='ny bruger', @email='ny_bruger@email.com', @status='regular';
go

-- vis alle nye brugere
select * from Customers
where CustomerID >= 20;
go


-- slet ny bruger
declare @customerid int;  -- variabel til at gemme customer id 

select @customerid = CustomerID
from Customers
where name = 'ny bruger'  -- find det specifikke customer id

if @customerid is not null  -- slet bruger hvis findes
begin
exec DeleteCustomer @customerid
end
go

-- vis alle nye brugere hvor slettet 'slet mig'
select * from Customers
where CustomerID >= 20;
go


select dbo.CalculateTotalAmount(20) as totalAmountSpend;
go