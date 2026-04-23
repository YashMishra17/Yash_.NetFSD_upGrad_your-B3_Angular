"use strict";
// 1. Base Class: Employee
class Employee {
    id;
    name;
    salary;
    constructor(id, name, salary) {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }
    // 2. Getter
    getSalary() {
        return this.salary;
    }
    // 2. Setter with validation
    setSalary(value) {
        if (value > 0) {
            this.salary = value;
        }
        else {
            console.log("Invalid salary. Must be greater than 0.");
        }
    }
    // 3. Method
    displayDetails() {
        console.log(`ID: ${this.id}, Name: ${this.name}, Salary: ${this.salary}`);
    }
}
// 4. Derived Class: Manager
class Manager extends Employee {
    teamSize;
    constructor(id, name, salary, teamSize) {
        super(id, name, salary); // call base constructor
        this.teamSize = teamSize;
    }
    // 5. Method Overriding
    displayDetails() {
        console.log(`ID: ${this.id}, Name: ${this.name}, Salary: ${this.getSalary()}, Team Size: ${this.teamSize}`);
    }
}
// 6. Object Creation
// Employee object
const emp1 = new Employee(1, "Yash", 300000);
emp1.displayDetails();
emp1.setSalary(35000);
console.log("Updated Salary:", emp1.getSalary());
// Manager object
const mgr1 = new Manager(2, "Nishi", 50000, 5);
mgr1.displayDetails();
