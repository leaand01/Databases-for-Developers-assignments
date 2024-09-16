/*
Task 4: User-Defined Function: Scaler
Develop a scalar user-defined function named CalculateTotalAmount that calculates the total amount spent by a specific customer. The function should take a CustomerID as a parameter
and return the total amount spent by that customer.
*/

--drop function if EXISTS CalculateTotalAmount;
--go

create function CalculateTotalAmount
	(@customerid int)
returns int
as
begin
	declare @totalAmountSpend int;

	select @totalAmountSpend = sum(amount)
	from Orders
	where CustomerID = @customerid
	return isnull(@totalAmountSpend, 0);  -- bemærk returnerer kun værdien ikke navnet på variablen. Deklarer derfor selv navnet når kalder funktionen.
end;



/*
Task 5: User-defined Function: Scalar
Implement a scalar user-defined function named GetCustomerStatus that returns the status of a customer based on the total amount spent. The function should take a CustomerID as a parameter
and return the status as a string (e.g., 'Bronze', 'Silver', 'Gold').


Task 6: Trigger
Create a trigger that changes the status of a customer whenever a new order is placed. The trigger should update the status of the customer based on the total amount spent.


Task 7: Trigger
Create a trigger that prevents the deletion of a customer if the customer has placed orders. The trigger should raise an error if an attempt is made to delete a customer with associated orders.

*/