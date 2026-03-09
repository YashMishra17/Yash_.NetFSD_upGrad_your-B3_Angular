/*Week - 3 / DAY-14/4 Hands On
Pre-Requisites: Before starting with problem solving, please make sure that you have created a database and restored data  
AutoDb – SQL Problem Definitions Based on Advanced Querying and Data Manipulation

Level-1: Problem 1 – Product Analysis Using Nested Queries

Scenario:
You are working as a database developer for an automobile retail company. Management wants to identify products that are priced higher than the average price of products in their respective categories.

📌 Requirements
1. Retrieve product details (product_name, model_year, list_price).
2. Compare each product’s price with the average price of products in the same category using a nested query.
3. Display only those products whose price is greater than the category average.
4. Show calculated difference between product price and category average.
5. Concatenate product name and model year as a single column (e.g., 'ProductName (2017)').

🛠️ Technical Constraints
• Use subquery in WHERE clause.
• Use aggregate function (AVG).
• Use string manipulation functions.
• Use arithmetic expressions for price difference calculation.


Expectations:
• Proper use of nested query.
• Correct calculation of average and difference.
• Clean and readable SQL query.

🎯 Learning Outcome
• Understand nested queries with aggregate functions.
• Perform calculations inside SELECT statement.
• Apply string concatenation in SQL. */

---------------------------------------------------------------------------------------------

--Create Tables

--Categories Table

CREATE TABLE categories
(
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100) NOT NULL
);

--Products Table

CREATE TABLE products
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100) NOT NULL,
    category_id INT NOT NULL,
    model_year INT NOT NULL,
    list_price DECIMAL(10,2) NOT NULL,

    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

--Insert Sample Data

--Insert Categories

INSERT INTO categories VALUES
(4,'Hybrid Bikes'),
(5,'Kids Bikes'),
(6,'BMX Bikes');

--Insert Products

INSERT INTO products
(product_id, product_name, category_id, model_year, list_price)
VALUES
(1,'Trek Marlin 5',1,2019,550),
(2,'Trek Marlin 7',1,2020,850),
(3,'Giant Talon 3',1,2019,500),
(4,'Trek Domane AL',2,2021,1200),
(5,'Giant Contend 3',2,2020,900),
(6,'Specialized Turbo Vado',3,2022,3500),
(7,'Giant Explore E+',3,2021,3000);

--Final Query Nested Query Solution

SELECT 
    CONCAT(p.product_name,' (',p.model_year,')') AS product_info,
    p.product_name,
    p.model_year,
    p.list_price,
    
    p.list_price -
    (
        SELECT AVG(p2.list_price)
        FROM products p2
        WHERE p2.category_id = p.category_id
    ) AS price_difference

FROM products p

WHERE p.list_price >
(
    SELECT AVG(p3.list_price)
    FROM products p3
    WHERE p3.category_id = p.category_id
);

-------------------------------------------------------------------------------------------------

/*Level-1: Problem 2 – Customer Activity Classification

Scenario:
The company wants to classify customers based on their total order value and identify customers who have placed orders versus those who have not.

📌 Requirements
1. Use nested query to calculate total order value per customer.
2. Classify customers using conditional logic:
   - 'Premium' if total order value > 10000
   - 'Regular' if total order value between 5000 and 10000
   - 'Basic' if total order value < 5000
3. Use UNION to display customers with orders and customers without orders.
4. Display full name using string concatenation.
5. Handle NULL cases appropriately.


🛠️ Technical Constraints
• Use CASE statement for classification.
• Use UNION operator.
• Use subquery for total calculation.
• Use JOIN between customers and orders tables.

Expectations:
• Proper implementation of UNION.
• Correct usage of CASE expression.
• Accurate total value calculation.

🎯 Learning Outcome 
• Apply conditional logic in SQL.
• Combine results using set operators.
• Work with nested aggregation queries. */

----------------------------------------------------------------------------
--Create Tables

--Customers Table

CREATE TABLE customers
(
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);

--Orders Table

CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,

    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);

--Order Items Table

CREATE TABLE order_items
(
    item_id INT PRIMARY KEY,
    order_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),

    FOREIGN KEY (order_id) REFERENCES orders(order_id)
);

--Insert Sample Data

--Customers

INSERT INTO customers VALUES
(1,'John','Smith'),
(2,'Maria','Garcia'),
(3,'David','Lee'),
(4,'Emily','Davis');

--Order Items

INSERT INTO order_items VALUES
(1,101,2,3000,0.10),
(2,101,1,2000,0.05),
(3,102,1,5000,0.00),
(4,103,3,1500,0.05),
(5,104,1,2500,0.00);

--Final Query

SELECT 
    CONCAT(c.first_name,' ',c.last_name) AS full_name,
    t.total_value,
    CASE
        WHEN t.total_value > 10000 THEN 'Premium'
        WHEN t.total_value BETWEEN 5000 AND 10000 THEN 'Regular'
        ELSE 'Basic'
    END AS customer_category
FROM customers c
INNER JOIN
(
    SELECT 
        o.customer_id,
        SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_value
    FROM orders o
    INNER JOIN order_items oi
        ON o.order_id = oi.order_id
    GROUP BY o.customer_id
) t
ON c.customer_id = t.customer_id

UNION

SELECT
    CONCAT(c.first_name,' ',c.last_name) AS full_name,
    0 AS total_value,
    'No Orders' AS customer_category
FROM customers c
WHERE c.customer_id NOT IN
(
    SELECT customer_id FROM orders
);

----------------------------------------------------------------------------------

/*Level-1: Problem 2 – Customer Activity Classification

Scenario:
The company wants to classify customers based on their total order value and identify customers who have placed orders versus those who have not.

📌 Requirements
1. Use nested query to calculate total order value per customer.
2. Classify customers using conditional logic:
   - 'Premium' if total order value > 10000
   - 'Regular' if total order value between 5000 and 10000
   - 'Basic' if total order value < 5000
3. Use UNION to display customers with orders and customers without orders.
4. Display full name using string concatenation.
5. Handle NULL cases appropriately.


🛠️ Technical Constraints
• Use CASE statement for classification.
• Use UNION operator.
• Use subquery for total calculation.
• Use JOIN between customers and orders tables.

Expectations:
• Proper implementation of UNION.
• Correct usage of CASE expression.
• Accurate total value calculation.

🎯 Learning Outcome 
• Apply conditional logic in SQL.
• Combine results using set operators.
• Work with nested aggregation queries.*/

-- Customers who have placed orders

SELECT 
    CONCAT(c.first_name,' ',c.last_name) AS full_name,
    t.total_order_value,
    
    CASE 
        WHEN t.total_order_value > 10000 THEN 'Premium'
        WHEN t.total_order_value BETWEEN 5000 AND 10000 THEN 'Regular'
        ELSE 'Basic'
    END AS customer_category

FROM customers c

INNER JOIN
(
    -- Subquery to calculate total order value per customer
    SELECT 
        o.customer_id,
        SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_order_value
    FROM orders o
    INNER JOIN order_items oi
        ON o.order_id = oi.order_id
    GROUP BY o.customer_id
) t

ON c.customer_id = t.customer_id


UNION


-- Customers who have not placed any orders

SELECT 
    CONCAT(c.first_name,' ',c.last_name) AS full_name,
    0 AS total_order_value,
    'No Orders' AS customer_category

FROM customers c

WHERE c.customer_id NOT IN
(
    SELECT customer_id
    FROM orders
);

------------------------------------------------------------------------------

/*Level-2: Problem 3 – Store Performance and Stock Validation

Scenario:
Management wants to evaluate store performance by identifying stores that have sold products but currently have zero stock for those products.

📌 Requirements
1. Identify products sold in each store using nested queries.
2. Compare sold products with current stock using INTERSECT and EXCEPT operators.
3. Display store_name, product_name, total quantity sold.
4. Calculate total revenue per product (quantity × list_price – discount).
5. Update stock quantity to 0 for discontinued products (simulation).

🛠️ Technical Constraints
• Use INTERSECT and EXCEPT operators.
• Use subqueries in FROM clause.
• Use arithmetic expressions for revenue calculation.
• Use UPDATE statement for stock modification.

Expectations:
• Correct application of set operators.
• Accurate revenue calculations.
• Proper JOIN between order_items, orders, stores, and stocks tables.

🎯 Learning Outcome
• Master set operators (INTERSECT, EXCEPT).
• Perform advanced nested queries.
• Apply UPDATE statements with conditions.*/

---------------------------------------------------------------------------

SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS total_quantity_sold,
    SUM((oi.quantity * oi.list_price) - oi.discount) AS total_revenue
FROM orders o

INNER JOIN order_items oi
ON o.order_id = oi.order_id

INNER JOIN stores s
ON o.store_id = s.store_id

INNER JOIN products p
ON oi.product_id = p.product_id

WHERE oi.product_id IN
(
    SELECT oi.product_id
    FROM orders o
    JOIN order_items oi
    ON o.order_id = oi.order_id

    EXCEPT

    SELECT product_id
    FROM stocks
)

GROUP BY 
    s.store_name,
    p.product_name;

----------------------------------------------------------------------------

/*Level-2: Problem 4 – Order Cleanup and Data Maintenance

Scenario:
The database contains outdated and rejected orders. Management wants to clean up and archive data while maintaining consistency.

📌 Requirements 
1. Insert archived records into a new table (archived_orders) using INSERT INTO SELECT.
2. Delete orders where order_status = 3 (Rejected) and older than 1 year.
3. Use nested query to identify customers whose all orders are completed.
4. Display order processing delay (DATEDIFF between shipped_date and order_date).
5. Mark orders as 'Delayed' or 'On Time' using CASE expression based on required_date.

🛠️ Technical Constraints 
• Use INSERT statement with SELECT.
• Use DELETE with nested query.
• Use DATE functions and conditional logic.
• Maintain referential integrity constraints.

Expectations:
• Proper handling of DELETE and INSERT operations.
• Correct usage of subqueries for validation.
• Accurate date calculations and CASE logic.


🎯 Learning Outcome
• Perform data modification operations safely.
• Implement business logic using SQL expressions.
• Understand real-world database maintenance scenarios. */

---------------------------------------------------------------------------

--Customers Table

CREATE TABLE Customers1
(
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(100)
);

--Insert sample data

INSERT INTO customers1 VALUES
(1,'Rahul','Sharma','rahul@gmail.com'),
(2,'Priya','Singh','priya@gmail.com'),
(3,'Amit','Verma','amit@gmail.com'),
(4,'Neha','Gupta','neha@gmail.com'),
(5,'Rohit','Patel','rohit@gmail.com');

--Stores Table

CREATE TABLE stores1
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100),
    city VARCHAR(50)
);

--Insert sample data

INSERT INTO stores1 VALUES
(1,'Central Store','Delhi'),
(2,'City Mall Store','Mumbai'),
(3,'Metro Store','Bangalore');

--Categories Table

CREATE TABLE categories1
(
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100)
);

--Insert sample data

INSERT INTO categories1 VALUES
(1,'Electronics'),
(2,'Clothing'),
(3,'Accessories');

--Products Table

CREATE TABLE products1
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    category_id INT,
    list_price DECIMAL(10,2),

    FOREIGN KEY (category_id)
    REFERENCES categories(category_id)
);

--Insert sample data

INSERT INTO products1 VALUES
(1,'Laptop',1,50000),
(2,'Mobile',1,20000),
(3,'T-Shirt',2,800),
(4,'Headphones',3,1500),
(5,'Smart Watch',1,7000);

/*--Stocks Table

CREATE TABLE stocks1
(
    store_id INT,
    product_id INT,
    quantity INT,

    PRIMARY KEY(store_id,product_id),

    FOREIGN KEY(store_id) REFERENCES stores(store_id),
    FOREIGN KEY(product_id) REFERENCES products(product_id)
);

--Insert sample data

INSERT INTO stocks1 VALUES
(1,1,10),
(1,2,15),
(1,3,30),
(2,1,5),
(2,4,20),
(3,5,0);*/

----------------------------------------------------------------------------

--Orders Table

CREATE TABLE orders1
(
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_status INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    store_id INT,

    FOREIGN KEY(customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY(store_id) REFERENCES stores(store_id)
);

--insert into value

INSERT INTO orders1 VALUES
(1,1,4,'2024-01-10','2024-01-15','2024-01-14',1),
(2,2,4,'2024-02-05','2024-02-10','2024-02-12',2),
(3,3,3,'2023-01-01','2023-01-05',NULL,1),
(4,1,4,'2024-03-10','2024-03-15','2024-03-14',2),
(5,4,2,'2024-04-01','2024-04-06',NULL,3);

--Order Items Table

CREATE TABLE order_items1
(
    order_id INT,
    item_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(10,2),

    PRIMARY KEY(order_id,item_id),

    FOREIGN KEY(order_id) REFERENCES orders(order_id),
    FOREIGN KEY(product_id) REFERENCES products(product_id)
);

--Insert

INSERT INTO order_items1 VALUES
(1,1,1,1,50000,1000),
(1,2,4,2,1500,100),
(2,1,2,1,20000,500),
(3,1,3,3,800,50),
(4,1,5,1,7000,200),
(5,1,2,2,20000,1000);

--Archived Orders Table

CREATE TABLE archived_orders
(
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_status INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    store_id INT
);

SELECT * FROM customers1
SELECT * FROM stores1
SELECT * FROM products1
SELECT * FROM orders1
SELECT * FROM order_items1
SELECT * FROM stocks1