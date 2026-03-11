/*Week - 4 / DAY-1 Hands On

Level-2 Problem 1: Stored Procedures and User-Defined Functions
Scenario
The company requires reusable database logic to generate reports such as total sales per store and discounted order totals.

📌 Requirements 
- Create a stored procedure to generate total sales amount per store.
- Create a stored procedure to retrieve orders by date range.
- Create a scalar function to calculate total price after discount.
- Create a table-valued function to return top 5 selling products.

🛠️ Technical Constraints 
- Use input parameters in stored procedures.
- Handle NULL values properly.
- Ensure optimized queries inside procedures.
- Follow proper naming conventions.

Expectations
- Reusable and modular SQL code.
- Accurate calculations using functions.
- Efficient report generation using procedures.

🎯 Learning Outcome 
- Understand encapsulation using stored procedures.
- Learn how to create and use user-defined functions.
- Develop reusable database logic.        */

-------------------------------------------------------------------------------

--Create Tables
--Stores Table

CREATE TABLE stores
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100),
    city VARCHAR(50)
);

--Insert Sample Data

INSERT INTO stores VALUES
(1,'Central Store','Delhi'),
(2,'Metro Store','Mumbai'),
(3,'City Store','Pune'),
(4,'Auto Hub','Bangalore'),
(5,'Prime Motors','Hyderabad');

--Customers Table

CREATE TABLE customers
(
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(100)
);

--Insert Sample Data

INSERT INTO customers VALUES
(1,'Rahul','Sharma','rahul@email.com'),
(2,'Priya','Singh','priya@email.com'),
(3,'Amit','Verma','amit@email.com'),
(4,'Neha','Gupta','neha@email.com'),
(5,'Rohit','Patel','rohit@email.com');

--Products Table

CREATE TABLE products
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    list_price DECIMAL(10,2)
);

--Insert Sample Data

INSERT INTO products VALUES
(1,'Laptop',50000),
(2,'Mobile',20000),
(3,'Headphones',3000),
(4,'Smart Watch',7000),
(5,'Tablet',25000);

--Orders Table

CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    order_status INT,
    store_id INT,

    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

--Insert Sample Data

INSERT INTO orders VALUES
(101,1,'2024-01-10',4,1),
(102,2,'2024-02-05',4,2),
(103,3,'2024-03-15',2,1),
(104,4,'2024-04-20',4,3),
(105,5,'2024-05-25',1,2);

--Order Items Table

CREATE TABLE order_items
(
    order_id INT,
    item_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(5,2),

    PRIMARY KEY(order_id,item_id),

    FOREIGN KEY(order_id) REFERENCES orders(order_id),
    FOREIGN KEY(product_id) REFERENCES products(product_id)
);

--Insert Sample Data

INSERT INTO order_items VALUES
(101,1,1,1,50000,0.10),
(101,2,3,2,3000,0.05),
(102,1,2,1,20000,0.05),
(103,1,4,1,7000,0.00),
(104,1,5,1,25000,0.10),
(105,1,2,2,20000,0.15);

--Stored Procedure – Total Sales Per Store

CREATE PROCEDURE sp_TotalSalesPerStore
AS
BEGIN

SELECT 
s.store_name,

SUM(oi.quantity * oi.list_price * (1 - ISNULL(oi.discount,0))) AS total_sales

FROM orders o
JOIN order_items oi
ON o.order_id = oi.order_id

JOIN stores s
ON o.store_id = s.store_id

GROUP BY s.store_name;

END;

EXEC sp_TotalSalesPerStore;

--Stored Procedure – Orders By Date Range

CREATE PROCEDURE sp_GetOrdersByDateRange
@StartDate DATE,
@EndDate DATE
AS
BEGIN

SELECT
order_id,
customer_id,
order_date,
order_status

FROM orders

WHERE order_date BETWEEN @StartDate AND @EndDate;

END;

EXEC sp_GetOrdersByDateRange '2024-01-01','2024-12-31';

--Scalar Function – Calculate Discounted Price

CREATE FUNCTION fn_CalculateDiscountPrice
(
@Quantity INT,
@Price DECIMAL(10,2),
@Discount DECIMAL(5,2)
)

RETURNS DECIMAL(10,2)

AS
BEGIN

DECLARE @Total DECIMAL(10,2)

SET @Total = @Quantity * @Price * (1 - ISNULL(@Discount,0))

RETURN @Total

END;

SELECT dbo.fn_CalculateDiscountPrice(2,20000,0.10) AS FinalPrice;

--Table Valued Function – Top 5 Selling Products

CREATE FUNCTION fn_Top5SellingProducts()
RETURNS TABLE
AS
RETURN
(
SELECT TOP 5
p.product_name,
SUM(oi.quantity) AS total_sold

FROM order_items oi
JOIN products p
ON oi.product_id = p.product_id

GROUP BY p.product_name

ORDER BY total_sold DESC
);

SELECT * FROM dbo.fn_Top5SellingProducts();

--------------------------------------------------------------------------------------

/*Level-2 Problem 2: Stock Auto-Update Trigger
Scenario
Whenever a new record is inserted into order_items, the stock quantity in the stocks table must automatically decrease based on the ordered quantity.

📌 Requirements 
- Create an AFTER INSERT trigger on order_items.
- Reduce the corresponding quantity in stocks table.
- Prevent stock from becoming negative.
- If stock is insufficient, rollback the transaction with a custom error message.

🛠️ Technical Constraints 
- Use AFTER trigger.
- Use TRY…CATCH block inside the trigger.
- Use RAISERROR or THROW for custom error messages.
- Use ROLLBACK if stock is insufficient.
Expectations
- Correct trigger implementation.
- Proper transaction handling.
- Accurate stock update.
- Meaningful error handling.


🎯 Learning Outcome 
- Understand AFTER triggers.
- Implement transaction control using COMMIT/ROLLBACK.
- Apply error handling using TRY…CATCH.
- Maintain data integrity automatically.*/

--Create Stocks Table

CREATE TABLE stocks
(
    store_id INT,
    product_id INT,
    quantity INT,

    PRIMARY KEY(store_id, product_id)
);

--Insert Sample Data

INSERT INTO stocks VALUES
(1,1,50),
(1,2,40),
(1,3,60),
(2,1,30),
(2,2,25);

--AFTER INSERT Trigger on order_items

CREATE TRIGGER trg_UpdateStockAfterOrder
ON order_items
AFTER INSERT
AS
BEGIN

BEGIN TRY

    -- Check if stock is sufficient
    IF EXISTS (
        SELECT 1
        FROM stocks s
        JOIN orders o ON s.store_id = o.store_id
        JOIN inserted i ON i.product_id = s.product_id
        WHERE s.quantity < i.quantity
    )
    BEGIN
        THROW 50001, 'Stock is insufficient for this product.', 1;
    END

    -- Update stock quantity
    UPDATE s
    SET s.quantity = s.quantity - i.quantity
    FROM stocks s
    JOIN orders o ON s.store_id = o.store_id
    JOIN inserted i ON s.product_id = i.product_id
    WHERE o.order_id = i.order_id;

END TRY

BEGIN CATCH

    PRINT 'Error occurred while updating stock';
    ROLLBACK TRANSACTION;

END CATCH

END;

--Test the Trigger

INSERT INTO order_items VALUES
(101,3,2,2,20000,0.05);

--Test Insufficient Stock
INSERT INTO order_items VALUES
(101,4,1,500,50000,0);

SELECT * FROM stocks;

--------------------------------------------------------------------------------

/*Level-2 Problem 3: Order Status Validation Trigger
Scenario
Before updating order_status in orders table, ensure that shipped_date is not NULL when status is set to Completed (4).
📌 Requirements 
- Create an AFTER UPDATE trigger on orders.
- Validate that shipped_date is NOT NULL when order_status = 4.
- Prevent update if condition fails.

🛠️ Technical Constraints 
- Use AFTER UPDATE trigger.
- Use inserted logical table for validation.
- Use TRY…CATCH with custom error message.
- Rollback transaction if validation fails.

Expectations
- Accurate validation logic.
- Proper rollback handling.
- Clean and readable SQL implementation.



🎯 Learning Outcome 
- Understand validation using triggers.
- Work with inserted table.
- Enforce business rules at database level.*/

--------------------------------------------------------------------------------------

--Add New Coloumn In Orders Table

ALTER TABLE orders
ADD shipped_date DATE;

SELECT * FROM orders

--Create AFTER UPDATE Trigger

CREATE TRIGGER trg_OrderStatusValidation
ON orders
AFTER UPDATE
AS
BEGIN

BEGIN TRY

    -- Check if any order is marked completed without shipped_date
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE order_status = 4
        AND shipped_date IS NULL
    )
    BEGIN
        THROW 50002, 'Order cannot be marked as Completed without shipped_date.', 1;
    END

END TRY

BEGIN CATCH

    PRINT 'Order status validation failed.';
    ROLLBACK TRANSACTION;

END CATCH

END;

--Test the Trigger (Invalid Update)

UPDATE orders
SET order_status = 4
WHERE order_id = 103;

--Correct Update

UPDATE orders
SET shipped_date = '2024-03-20',
order_status = 4
WHERE order_id = 103;

--Verify Result

SELECT order_id, order_status, shipped_date
FROM orders;

-------------------------------------------------------------------------------------------

/*Level-2 Problem 4: Cursor-Based Revenue Calculation
Scenario
Management wants a detailed revenue calculation per store by iterating through completed orders and calculating total revenue including discounts.
📌 Requirements 
- Use a cursor to iterate through completed orders (order_status = 4).
- Calculate total revenue per order using order_items.
- Store computed revenue in a temporary table.
- Display store-wise revenue summary.

🛠️ Technical Constraints 
- Use CURSOR for row-by-row processing.
- Use TRY…CATCH for error handling.
- Use explicit BEGIN TRANSACTION and COMMIT.
- Use ROLLBACK in case of failure.

Expectations
- Correct cursor implementation.
- Accurate revenue computation.
- Proper transaction and error handling.
- Efficient and clean SQL logic.

🎯 Learning Outcome 
- Understand cursor usage.
- Implement row-by-row processing.
- Combine transactions with cursors.
- Handle runtime errors effectively.*/

--------------------------------------------------------------------------------

--Create Temporary Table for Revenue (This table will store order revenue calculated by the cursor.)

CREATE TABLE #OrderRevenue
(
    order_id INT,
    store_id INT,
    revenue DECIMAL(12,2)
);

--Cursor-Based Revenue Calculation

BEGIN TRY

BEGIN TRANSACTION;

DECLARE @order_id INT
DECLARE @store_id INT
DECLARE @revenue DECIMAL(12,2)

DECLARE order_cursor CURSOR FOR

SELECT order_id, store_id
FROM orders
WHERE order_status = 4;

OPEN order_cursor

FETCH NEXT FROM order_cursor INTO @order_id, @store_id

WHILE @@FETCH_STATUS = 0
BEGIN

    -- Calculate revenue for the order
    SELECT @revenue =
    SUM(quantity * list_price * (1 - ISNULL(discount,0)))
    FROM order_items
    WHERE order_id = @order_id;

    -- Insert result into temporary table
    INSERT INTO #OrderRevenue
    VALUES (@order_id, @store_id, @revenue);

    FETCH NEXT FROM order_cursor INTO @order_id, @store_id

END

CLOSE order_cursor
DEALLOCATE order_cursor

COMMIT TRANSACTION;

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION;

PRINT 'Error occurred during revenue calculation';

END CATCH;


-- Alter Table
ALTER TABLE orders
ADD order_status INT;

ALTER TABLE orders
ADD store_id INT;

ALTER TABLE orders
ADD shipped_date DATE;

ALTER TABLE orders
ADD required_date DATE;

SELECT * FROM orders;

SELECT
s.store_name,
SUM(r.revenue) AS total_store_revenue

FROM #OrderRevenue r
JOIN stores s
ON r.store_id = s.store_id

GROUP BY s.store_name

ORDER BY total_store_revenue DESC;