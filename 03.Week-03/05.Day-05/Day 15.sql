/*Pre-Requisites: Before starting with problem solving, please make sure that you have created a database and restored data  
Level-1 Problem 1: Basic Setup and Data Retrieval in EcommDb

Scenario
You are assigned as a database developer to set up the EcommDb database for an automobile retail company. The company wants to verify basic operations such as inserting data and retrieving product and customer information.

📌 Requirements 
- Create EcommDb and all tables using the provided schema.
- Insert at least 5 records in categories, brands, products, customers, and stores.
- Write SELECT queries to retrieve all products with their brand and category names.
- Retrieve all customers from a specific city.
- Display total number of products available in each category.

🛠️ Technical Constraints 
- Use SQL Server.
- Use ANSI SQL queries wherever applicable.
- Do not modify the existing table structure.
- Ensure foreign key constraints are satisfied while inserting data.

Expectations
- Successful creation of database and tables.
- Accurate data insertion without constraint violations.
- Correct JOIN queries to retrieve relational data.

🎯 Learning Outcome 
- Understand database setup process.
- Learn basic SELECT, INSERT and JOIN operations.
- Gain understanding of relational data retrieval. */


--Create Tables
--Categories Table

CREATE TABLE categories
(
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100) NOT NULL
);

--insert

INSERT INTO categories VALUES
(1,'Cars'),
(2,'Motorcycles'),
(3,'Trucks'),
(4,'SUV'),
(5,'Electric Vehicles');

SELECT * FROM categories;

--Brands Table

CREATE TABLE brands
(
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(100) NOT NULL
);

--insert

INSERT INTO brands VALUES
(1,'Toyota'),
(2,'Honda'),
(3,'Ford'),
(4,'BMW'),
(5,'Tesla');

--Products Table

CREATE TABLE products
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),

    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

--insert

INSERT INTO products VALUES
(1,'Toyota Camry',1,1,2023,30000),
(2,'Honda Civic',2,1,2023,25000),
(3,'Ford F150',3,3,2022,40000),
(4,'BMW X5',4,4,2024,60000),
(5,'Tesla Model 3',5,5,2024,45000);

--Customers Tables

CREATE TABLE customers
(
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    phone VARCHAR(20),
    email VARCHAR(100),
    city VARCHAR(50)
);

--insert

INSERT INTO customers VALUES
(1,'Rahul','Sharma','9876543210','rahul@email.com','Delhi'),
(2,'Priya','Verma','9876543211','priya@email.com','Mumbai'),
(3,'Amit','Singh','9876543212','amit@email.com','Delhi'),
(4,'Neha','Gupta','9876543213','neha@email.com','Pune'),
(5,'Rohit','Patel','9876543214','rohit@email.com','Mumbai');

--Stores Tables

CREATE TABLE stores
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100),
    city VARCHAR(50)
);

--insert 

INSERT INTO stores VALUES
(1,'Central Auto Store','Delhi'),
(2,'Metro Auto Store','Mumbai'),
(3,'City Wheels','Pune'),
(4,'Auto Hub','Bangalore'),
(5,'Prime Motors','Hyderabad');

--Final Query

SELECT 
p.product_id,
p.product_name,
b.brand_name,
c.category_name,
p.list_price
FROM products p
JOIN brands b
ON p.brand_id = b.brand_id
JOIN categories c
ON p.category_id = c.category_id;

--

SELECT * FROM customers WHERE city = 'Delhi';

--

SELECT c.category_name, COUNT(p.product_id) AS total_products FROM categories c LEFT JOIN products p ON c.category_id = p.category_id GROUP BY c.category_name; 

------------------------------------------------------------------------------------------------
/*Level-1 Problem 2: Creating Views and Indexes for Performance

Scenario
The management team frequently accesses product and order summary reports. To simplify access and improve performance, they require database views and indexing.

📌 Requirements 
- Create a view that shows product name, brand name, category name, model year and list price.
- Create a view that shows order details with customer name, store name and staff name.
- Create appropriate indexes on foreign key columns.
- Test performance improvement using execution plan.

🛠️ Technical Constraints 
- Views must not duplicate data.
- Indexes should be created only on frequently searched columns.
- Do not change table definitions.
- Follow proper naming conventions.


Expectations
- Working views returning accurate data.
- Indexes improving query execution time.
- Proper documentation of execution plan comparison.

🎯 Learning Outcome 
- Understand purpose of views.
- Learn how indexing improves performance.
- Gain hands-on knowledge of query optimization. */



CREATE VIEW vw_product_details
AS
SELECT 
    p.product_id,
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
JOIN brands b
ON p.brand_id = b.brand_id
JOIN categories c
ON p.category_id = c.category_id;

SELECT * FROM vw_product_details;