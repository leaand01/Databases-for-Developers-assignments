-- Create the Customers table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name NVARCHAR(100),
    Email NVARCHAR(100)
);

-- Create the Accounts table
CREATE TABLE Accounts (
    AccountID INT PRIMARY KEY,
    CustomerID INT,
    Balance DECIMAL(10, 2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

-- Create the Employees table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    Name NVARCHAR(100),
    Position NVARCHAR(100)
);

-- Create the Transactions table
CREATE TABLE Transactions (
    TransactionID INT PRIMARY KEY,
    AccountID INT,
    Amount DECIMAL(10, 2),
    Type NVARCHAR(20),
    Timestamp DATETIME2 DEFAULT SYSDATETIME(),
    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);

-- Create the EmployeeActions table
CREATE TABLE EmployeeActions (
    ActionID INT PRIMARY KEY,
    EmployeeID INT,
    ActionType NVARCHAR(50),
    Timestamp DATETIME2 DEFAULT SYSDATETIME(),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

-- Insert sample data into Customers
INSERT INTO Customers (CustomerID, Name, Email) VALUES
(1, N'John Doe', N'john.doe@email.com'),
(2, N'Jane Smith', N'jane.smith@email.com'),
(3, N'Bob Johnson', N'bob.johnson@email.com');

-- Insert sample data into Accounts
INSERT INTO Accounts (AccountID, CustomerID, Balance) VALUES
(101, 1, 50000.00),
(102, 2, 75000.00),
(103, 3, 100000.00);

-- Insert sample data into Employees
INSERT INTO Employees (EmployeeID, Name, Position) VALUES
(1, N'Alice Williams', N'Teller'),
(2, N'Charlie Brown', N'Account Manager'),
(3, N'David Lee', N'IT Specialist');

-- Insert sample data into Transactions
INSERT INTO Transactions (TransactionID, AccountID, Amount, Type, Timestamp) VALUES
(1001, 101, 500.00, N'Deposit', '2024-03-15 09:30:00'),
(1002, 102, 1000.00, N'Withdrawal', '2024-03-15 10:15:00'),
(1003, 103, 750.00, N'Transfer', '2024-03-15 11:00:00'),
(1004, 102, 50000.00, N'Withdrawal', '2024-03-15 14:30:00'), -- Suspicious transaction
(1005, 101, 200.00, N'Deposit', '2024-03-15 15:45:00');

-- Insert sample data into EmployeeActions
INSERT INTO EmployeeActions (ActionID, EmployeeID, ActionType, Timestamp) VALUES
(2001, 1, N'Login', '2024-03-15 09:00:00'),
(2002, 1, N'View Account', '2024-03-15 09:25:00'),
(2003, 1, N'Process Deposit', '2024-03-15 09:30:00'),
(2004, 2, N'Login', '2024-03-15 10:00:00'),
(2005, 2, N'View Account', '2024-03-15 10:10:00'),
(2006, 2, N'Process Withdrawal', '2024-03-15 10:15:00'),
(2007, 1, N'Process Transfer', '2024-03-15 11:00:00'),
(2008, 3, N'Login', '2024-03-15 14:15:00'),
(2009, 3, N'Database Access', '2024-03-15 14:20:00'),
(2010, 3, N'Process Withdrawal', '2024-03-15 14:30:00'), -- Suspicious action
(2011, 3, N'Logout', '2024-03-15 14:35:00'),
(2012, 1, N'Process Deposit', '2024-03-15 15:45:00');