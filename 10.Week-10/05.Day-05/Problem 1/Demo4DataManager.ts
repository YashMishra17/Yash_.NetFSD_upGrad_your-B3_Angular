/*Week-10 (DAY-5) Hands-On
Problem-1: Build a Reusable Data Manager using Generics in TypeScript
Problem:
Develop a reusable and type-safe data handling module using generic functions, interfaces, and classes to manage different types of data (e.g., Users, Products) without duplicating code.
Scenario:
You are building an Angular application where multiple modules (User Management, Product Management) require similar operations like add, retrieve, and display data. Instead of writing separate logic for each data type, you decide to use TypeScript Generics to create reusable and scalable components.
Requirements:
1. Generic Function
Create a function:
function getFirstElement<T>(items: T[]): T
It should return the first element from any type of array.
2. Generic Interface
Create an interface:
	interface Repository<T>
Include methods: 
oadd(item: T): void 
ogetAll(): T[] 
3. Generic Class
Create a class:
	class DataManager<T> implements Repository<T>
Implement: 
oStore items in an internal array 
oImplement add() and getAll() methods 




4. Use Case Implementation
Create two models:
interface User {
  id: number;
  name: string;
}
interface Product {
  id: number;
  title: string;
}

Use DataManager<T> to: 
oStore Users 
oStore Products 
5. Testing
Add sample data for Users and Products 
Display results using console.log()

Technical Constraints:
Use TypeScript only (no Angular components yet) 
Must use: 
oAt least 1 generic function 
oAt least 1 generic interface 
oAt least 1 generic class 
Avoid using any type 
Follow proper naming conventions
Expectations:
Code should be: 
oClean and readable 
oProperly structured 
oType-safe using generics 
Demonstrate reusability 
Show how one generic structure works for multiple data types 

Learning Outcomes:
By completing this task, learners will be able to:
Understand why generics are used in TypeScript 
Implement generic functions for reusable logic 
Design generic interfaces for flexible contracts 
Build generic classes for scalable architecture 
Apply generics in real-world Angular-like scenarios 
Avoid code duplication and improve maintainability*/

//////////////////////////////////////////////////////////////////

// 1. Generic Function
function getFirstElement<T>(items: T[]): T {
  if (items.length === 0) {
    throw new Error("Array is empty");
  }
  return items[0];
}

// 2. Generic Interface
interface Repository<T> {
  add(item: T): void;
  getAll(): T[];
}

// 3. Generic Class
class DataManager<T> implements Repository<T> {
  private items: T[] = [];

  add(item: T): void {
    this.items.push(item);
  }

  getAll(): T[] {
    return this.items;
  }
}

// 4. Models
interface User {
  id: number;
  name: string;
}

interface Product {
  id: number;
  title: string;
}

// 5. Use Case Implementation

// User Data Manager
const userManager = new DataManager<User>();
userManager.add({ id: 1, name: "Yash" });
userManager.add({ id: 2, name: "Nishi" });

// Product Data Manager
const productManager = new DataManager<Product>();
productManager.add({ id: 101, title: "Laptop" });
productManager.add({ id: 102, title: "Phone" });

// Testing Outputs
console.log("All Users:", userManager.getAll());
console.log("All Products:", productManager.getAll());

// Generic Function Usage
console.log("First User:", getFirstElement(userManager.getAll()));
console.log("First Product:", getFirstElement(productManager.getAll()));