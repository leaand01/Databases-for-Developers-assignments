CREATE DATABASE ShopDB;
GO

USE ShopDB;
GO

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Email NVARCHAR(100),
    RegistrationDate DATETIME,
    [Status] NVARCHAR(50) DEFAULT 'Regular'
);
GO

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
    OrderDate DATETIME,
    Amount DECIMAL(10, 2)
);
GO

-- Populate the tables with some initial data
INSERT INTO Customers (Name, Email, RegistrationDate, Status)
VALUES 
('John Doe', 'john.doe@email.com', '2021-01-01', 'Regular'),
('Jane Smith', 'jane.smith@email.com', '2021-02-01', 'Regular'),
('Alice Johnson', 'alice.johnson@email.com', '2021-03-01', 'Regular'),
('Bob Brown', 'bob.brown@email.com', '2021-04-01', 'Regular'),
('Charlie Davis', 'charlie.davis@email.com', '2021-05-01', 'Regular'),
('Diana Evans', 'diana.evans@email.com', '2021-06-01', 'Regular'),
('Ethan Fox', 'ethan.fox@email.com', '2021-07-01', 'Regular'),
('Grace Green', 'grace.green@email.com', '2021-08-01', 'Regular'),
('Harry Hill', 'harry.hill@email.com', '2021-09-01', 'Regular'),
('Ivy Irvine', 'ivy.irvine@email.com', '2021-10-01', 'Regular'),
('Jack Johnson', 'jack.johnson@email.com', '2021-11-01', 'Regular'),
('Karen King', 'karen.king@email.com', '2021-12-01', 'Regular'),
('Liam Lee', 'liam.lee@email.com', '2022-01-01', 'Regular'),
('Mia Martin', 'mia.martin@email.com', '2022-02-01', 'Regular'),
('Noah Nelson', 'noah.nelson@email.com', '2022-03-01', 'Regular'),
('Olivia Owens', 'olivia.owens@email.com', '2022-04-01', 'Regular'),
('Peter Parker', 'peter.parker@email.com', '2022-05-01', 'Regular'),
('Quinn Quinn', 'quinn.quinn@email.com', '2022-06-01', 'Regular'),
('Ryan Reed', 'ryan.reed@email.com', '2022-07-01', 'Regular'),
('Sophia Scott', 'sophia.scott@email.com', '2022-08-01', 'Regular');

INSERT INTO Orders (CustomerID, OrderDate, Amount)
VALUES 
(1, '2022-01-10', 100.00),
(1, '2022-02-15', 200.00),
(2, '2022-01-20', 150.00),
(2, '2022-02-25', 300.00),
(3, '2022-03-05', 250.00),
(3, '2022-04-10', 50.00),
(4, '2022-05-15', 350.00),
(4, '2022-06-20', 450.00),
(5, '2022-07-25', 550.00),
(5, '2022-08-30', 150.00),
(6, '2022-09-04', 250.00),
(6, '2022-10-09', 350.00),
(7, '2022-11-14', 450.00),
(7, '2022-12-19', 550.00),
(8, '2023-01-23', 650.00),
(8, '2023-02-27', 750.00),
(9, '2023-04-03', 850.00),
(9, '2023-05-08', 950.00),
(10, '2023-06-12', 1050.00),
(10, '2023-07-17', 1150.00),
(11, '2023-08-21', 1250.00),
(11, '2023-09-25', 1350.00),
(12, '2023-10-30', 1450.00),
(12, '2023-12-04', 1550.00),
(13, '2024-01-08', 1650.00),
(13, '2024-02-12', 1750.00),
(14, '2024-03-18', 1850.00),
(14, '2024-04-22', 1950.00),
(15, '2024-05-27', 2050.00),
(15, '2024-07-01', 2150.00),
(16, '2024-08-05', 2250.00),
(16, '2024-09-09', 2350.00),
(17, '2024-10-14', 2450.00),
(17, '2024-11-18', 2550.00),
(18, '2024-12-23', 2650.00),
(18, '2025-01-27', 2750.00),
(19, '2025-03-03', 2850.00),
(19, '2025-04-07', 2950.00),
(20, '2025-05-12', 3050.00),
(20, '2025-06-16', 3150.00);
GO