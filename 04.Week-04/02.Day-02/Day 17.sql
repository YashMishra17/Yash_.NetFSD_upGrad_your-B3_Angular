/*Day 17 / DAY-2 Hands On


Pre-Requisites: Before starting with problem solving, please make sure that you have created a database and restored data  

Level-2 Problem 1: Transactions and Trigger Implementation
Scenario
Auto retail company wants to ensure stock consistency while placing orders. Whenever an order is placed, stock should reduce automatically and transaction should rollback if stock is insufficient.

📌 Requirements 
- Write a transaction to insert data into orders and order_items tables.
- Check stock availability before confirming order.
- Create a trigger to reduce stock quantity after order insertion.
- Rollback transaction if stock quantity is insufficient.

🛠️ Technical Constraints 
- Use explicit transactions (BEGIN TRANSACTION, COMMIT, ROLLBACK).
- Trigger must handle multiple rows.
- Do not allow negative stock values.
- Maintain referential integrity.
Expectations
- Successful implementation of ACID properties.
- Automatic stock update using trigger.
- Proper rollback mechanism in failure scenarios.

🎯 Learning Outcome 
- Understand transaction management.
- Learn trigger-based automation.
- Implement real-world stock control logic.*/

---------------------------------------------------------------------------------------------------

SELECT * FROM customers;


--Stores Tables

CREATE TABLE stores
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
);

--Insert Sample Data

INSERT INTO stores VALUES
(1,'Central Store'),
(2,'Metro Store');

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
(3,'Headphones',3000);

--Orders Table

CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_status INT,
    order_date DATE,
    store_id INT,

    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

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

--Stocks Table

CREATE TABLE stocks
(
    store_id INT,
    product_id INT,
    quantity INT,

    PRIMARY KEY(store_id,product_id),

    FOREIGN KEY(store_id) REFERENCES stores(store_id),
    FOREIGN KEY(product_id) REFERENCES products(product_id)
);

--Insert Sample Data

INSERT INTO stocks VALUES
(1,1,50),
(1,2,40),
(1,3,60),
(2,1,30),
(2,2,25);

---------------------------------------------------------------------------------------------------

--Create Trigger to Reduce Stock

GO

CREATE TRIGGER trg_reduce_stock
ON order_items
AFTER INSERT
AS
BEGIN

-- check stock availability
IF EXISTS
(
    SELECT 1
    FROM inserted i
    JOIN orders o ON i.order_id = o.order_id
    JOIN stocks s 
      ON s.product_id = i.product_id 
     AND s.store_id = o.store_id
    WHERE s.quantity < i.quantity
)
BEGIN
    RAISERROR('Stock is insufficient.',16,1)
    ROLLBACK TRANSACTION
    RETURN
END

-- reduce stock
UPDATE s
SET s.quantity = s.quantity - i.quantity
FROM stocks s
JOIN inserted i 
  ON s.product_id = i.product_id
JOIN orders o 
  ON o.order_id = i.order_id
 AND s.store_id = o.store_id

END;

--Transaction to Place Order

BEGIN TRY

BEGIN TRANSACTION

INSERT INTO orders
(order_id,customer_id,order_status,order_date,store_id)
VALUES
(101,1,1,'2024-06-01',1);


INSERT INTO order_items
(order_id,item_id,product_id,quantity,list_price,discount)
VALUES
(101,1,1,5,50000,0.10);

COMMIT TRANSACTION

PRINT 'Order successful'

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION

PRINT 'Order failed due to stock issue'

END CATCH

SELECT * FROM stocks;

--------------------------------------------------------------------------------------------

/*Level-2 Problem 2: Atomic Order Cancellation with SAVEPOINT
Scenario
When cancelling an order, system must restore stock quantities and update order_status to Rejected (3). All actions must be atomic.
📌 Requirements 
- Begin a transaction when cancelling an order.
- Restore stock quantities based on order_items.
- Update order_status to 3.
- Use SAVEPOINT before stock restoration.
- If stock restoration fails, rollback to SAVEPOINT.
- Commit transaction only if all operations succeed.

🛠️ Technical Constraints 
- Use BEGIN TRANSACTION.
- Use SAVE TRANSACTION (SAVEPOINT).
- Use TRY…CATCH with custom error handling.
- Use COMMIT and ROLLBACK appropriately.

Expectations
- Proper use of SAVEPOINT.
- Atomic and consistent transaction handling.
- Accurate stock restoration.
- Robust error management.
🎯 Learning Outcome 
- Understand atomic transactions.
- Use SAVEPOINT effectively.
- Maintain data consistency.
- Implement advanced transaction control.*/

------------------------------------------------------------------------------------------------

--Start Transaction and Create SAVEPOINT

BEGIN TRY

BEGIN TRANSACTION

SAVE TRANSACTION Cancel_Order_Savepoint

-- Restore stock
UPDATE s
SET s.quantity = s.quantity + oi.quantity
FROM stocks s
INNER JOIN order_items oi
ON s.product_id = oi.product_id
WHERE oi.order_id = 101

-- Update order status
UPDATE orders
SET order_status = 3
WHERE order_id = 101

COMMIT TRANSACTION

PRINT 'Order cancelled successfully'

END TRY

BEGIN CATCH

PRINT 'Error occurred while cancelling order'

ROLLBACK TRANSACTION Cancel_Order_Savepoint

END CATCH
