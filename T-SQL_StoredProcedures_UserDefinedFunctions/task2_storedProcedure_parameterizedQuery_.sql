/*
Task 2: Stored Procedure: Parameterized Query
Create a stored procedure that retrieves all orders placed within a specific date range. The stored procedure should take two parameters, StartDate and EndDate, and return all orders placed between those dates.
*/

--drop procedure if EXISTS all_orders_within_dates;
--go

use ShopDB;
go

create procedure all_orders_within_dates
	@startdate date,
	@enddate date
as
begin
	select
		*
	from ShopDB.dbo.Orders
	where
		@startdate <= OrderDate
		and OrderDate <= @enddate
end;