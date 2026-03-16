/*SQL Server Case Study

Assignment Case Study: Stored Procedures & Transactions in SQL Server 
 Business Scenario – “BookMart Online Bookstore” (Simplified)
BookMart needs a reliable way to place customer orders without overselling books. When a customer orders a book:
Check if enough stock is available.
If yes → reduce stock and record the order.
If no → do not change anything (no partial updates).
Your task is to implement this safely using one stored procedure with transaction control and basic error handling.
Database Schema (Use this – create if needed)
SQL
CREATE TABLE Books (
    BookID  INT IDENTITY(1,1) PRIMARY KEY,
    Title   NVARCHAR(150) NOT NULL,
    Stock   INT NOT NULL CHECK (Stock >= 0),
    Price   DECIMAL(10,2) NOT NULL
);

CREATE TABLE Orders (
    OrderID    INT IDENTITY(1,1) PRIMARY KEY,
    BookID     INT NOT NULL,
    Quantity   INT NOT NULL CHECK (Quantity > 0),
    OrderDate  DATETIME2 DEFAULT SYSDATETIME(),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);
Assignment Tasks  
Task 1: Stored Procedure to Add a Book  
Create a stored procedure named sp_AddNewBook that takes: @Title NVARCHAR(150), @Stock INT, @Price DECIMAL(10,2)
Insert the new book into the Books table.
Use TRY…CATCH to handle errors (e.g., invalid stock or price).
Print a success message or error message.
Task 2: Main Stored Procedure – Place Order with Transaction  
Create a stored procedure named sp_PlaceOrder with parameters: @BookID INT, @Quantity INT
Must include all of the following:
1.SET XACT_ABORT ON; at the beginning.
2.BEGIN TRY
oBEGIN TRANSACTION
oCheck if book exists and Stock >= @Quantity
If not → RAISERROR('Not enough stock or book not found.', 16, 1);
oUPDATE Books SET Stock = Stock - @Quantity WHERE BookID = @BookID;
oINSERT INTO Orders (BookID, Quantity) VALUES (@BookID, @Quantity);
oCOMMIT TRANSACTION;
oPrint success message: 'Order placed successfully.'
3.END TRY
4.BEGIN CATCH
oIf @@TRANCOUNT > 0 then ROLLBACK TRANSACTION;
oPrint error details: number + message (use ERROR_NUMBER(), ERROR_MESSAGE())
oExample: 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR) + ': ' + ERROR_MESSAGE()
5.END CATCH
Task 3: Testing & Output  
Insert 3–5 sample books (you can do this manually or using sp_AddNewBook).
Run and show results (screenshots or text output) for at least these three cases:
1.Successful order → stock decreases, order is inserted.
2.Insufficient stock → error message, no change in stock or orders table.
3.Invalid BookID (book does not exist) → error, rollback happens.*/

------------------------------------------------------------------------------------------

--Create Tables

--Books Table

CREATE TABLE Books (
    BookID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(150) NOT NULL,
    Stock INT NOT NULL CHECK (Stock >= 0),
    Price DECIMAL(10,2) NOT NULL
)
GO

--Orders Table

CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    BookID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    OrderDate DATETIME2 DEFAULT SYSDATETIME(),

    FOREIGN KEY (BookID) REFERENCES Books(BookID)
)
GO

--Stored Procedure — Add New Book

CREATE PROCEDURE sp_AddNewBook
    @Title NVARCHAR(150),
    @Stock INT,
    @Price DECIMAL(10,2)
AS
BEGIN

BEGIN TRY

INSERT INTO Books (Title, Stock, Price)
VALUES (@Title, @Stock, @Price)

PRINT 'Book added successfully'

END TRY

BEGIN CATCH

PRINT 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR) 
      + ': ' + ERROR_MESSAGE()

END CATCH

END
GO

--Main Stored Procedure — Place Order with Transaction

CREATE PROCEDURE sp_PlaceOrder
    @BookID INT,
    @Quantity INT
AS
BEGIN

SET XACT_ABORT ON

BEGIN TRY

BEGIN TRANSACTION

-- Check if book exists and stock is enough
IF NOT EXISTS (
    SELECT 1
    FROM Books
    WHERE BookID = @BookID
    AND Stock >= @Quantity
)
BEGIN
    RAISERROR ('Not enough stock or book not found.',16,1)
END

-- Reduce stock
UPDATE Books
SET Stock = Stock - @Quantity
WHERE BookID = @BookID

-- Insert order
INSERT INTO Orders (BookID, Quantity)
VALUES (@BookID, @Quantity)

COMMIT TRANSACTION

PRINT 'Order placed successfully.'

END TRY

BEGIN CATCH

IF @@TRANCOUNT > 0
ROLLBACK TRANSACTION

PRINT 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR) 
      + ': ' + ERROR_MESSAGE()

END CATCH

END
GO

--Insert Sample Books

EXEC sp_AddNewBook 'SQL Basics',10,450
EXEC sp_AddNewBook 'Advanced SQL Server',5,700
EXEC sp_AddNewBook 'Database Design',8,520
EXEC sp_AddNewBook 'T-SQL Programming',6,600
EXEC sp_AddNewBook 'SQL Performance Tuning',4,750

SELECT * FROM Books

--Test Case 1 — Successful Order

EXEC sp_PlaceOrder 1,2

SELECT * FROM Books
SELECT * FROM Orders

--Test Case 2 — Insufficient Stock

EXEC sp_PlaceOrder 2,50

--Test Case 3 — Invalid BookID

EXEC sp_PlaceOrder 100,1

--Verify Final Data

SELECT * FROM Books
SELECT * FROM Orders