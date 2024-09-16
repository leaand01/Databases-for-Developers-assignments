/*
Task 1: Stored Procedure: Parameterized Query
Create a stored procedure that retrieves all orders for a specific customer. The stored procedure should take a CustomerID as a parameter and return all orders for that customer.
*/

--drop procedure if EXISTS all_orders_of_customer_with_id;
--go

create procedure all_orders_of_customer_with_id
	@customerid int
as
begin
	select
		orderid
	from ShopDB.dbo.Orders
	where CustomerID = @customerid
end;
go

--EXEC all_orders_of_customer_with_id 1;
--go