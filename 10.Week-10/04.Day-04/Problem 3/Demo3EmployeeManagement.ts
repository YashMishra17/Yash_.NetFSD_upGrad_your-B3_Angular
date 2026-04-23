/*Problem -3: Design a Basic Employee Management Module using TypeScript Classes
Problem
Learners need to implement object-oriented programming concepts in TypeScript such as constructors, access modifiers, inheritance, method overriding, and getters/setters by building a simple Employee Management system.
Scenario
You are developing a small module for an organization where different types of employees exist.
The system should support:
A base Employee class 
A derived Manager class 
Controlled access to properties 
Customized behavior using method overriding

Requirements
1. Create a Base Class: Employee
Properties: 
oid (number) 
oname (string) 
osalary (number) 
Use access modifiers: 
oid → public 
oname → protected 
osalary → private 
Constructor to initialize all properties

2. Implement Getters and Setters
Create: 
ogetSalary() → return salary 
osetSalary(value: number) → update salary with validation (salary > 0)

3. Create a Method
displayDetails() → print employee details 

4. Create a Derived Class: Manager
Inherit from Employee 
Add property: 
oteamSize (number) 
Constructor: 
oCall base class constructor using super
5. Method Overriding
Override displayDetails() in Manager 
Include: 
oEmployee details 
oTeam size
6. Object Creation
Create: 
oOne Employee object 
oOne Manager object 
Call methods and display output 

Technical Constraints
Use TypeScript only (no Angular components required yet) 
Use ES6 class syntax 
Must use: 
opublic, private, protected 
oextends, super 
Follow proper naming conventions 
No external libraries



Expectations
Correct use of: 
oConstructors 
oAccess modifiers 
oInheritance 
oMethod overriding 
oEncapsulation using getters/setters 
Clean and readable code 
Proper console output
Learning Outcomes
By completing this hands-on, learners will:
Understand how TypeScript supports OOP 
Learn data hiding using access modifiers 
Implement inheritance and code reuse 
Apply method overriding (polymorphism) 
Use getters and setters for controlled access 
Prepare for Angular service/component class design*/



// 1. Base Class: Employee
class Employee {
  public id: number;
  protected name: string;
  private salary: number;

  constructor(id: number, name: string, salary: number) {
    this.id = id;
    this.name = name;
    this.salary = salary;
  }

  // 2. Getter
  public getSalary(): number {
    return this.salary;
  }

  // 2. Setter with validation
  public setSalary(value: number): void {
    if (value > 0) {
      this.salary = value;
    } else {
      console.log("Invalid salary. Must be greater than 0.");
    }
  }

  // 3. Method
  public displayDetails(): void {
    console.log(`ID: ${this.id}, Name: ${this.name}, Salary: ${this.salary}`);
  }
}

// 4. Derived Class: Manager
class Manager extends Employee {
  public teamSize: number;

  constructor(id: number, name: string, salary: number, teamSize: number) {
    super(id, name, salary); // call base constructor
    this.teamSize = teamSize;
  }

  // 5. Method Overriding
  public displayDetails(): void {
    console.log(
      `ID: ${this.id}, Name: ${this.name}, Salary: ${this.getSalary()}, Team Size: ${this.teamSize}`
    );
  }
}

// 6. Object Creation

// Employee object
const emp1 = new Employee(1, "Yash", 300000);
emp1.displayDetails();

emp1.setSalary(350000);
console.log("Updated Salary:", emp1.getSalary());

// Manager object
const mgr1 = new Manager(2, "Nishi", 50000, 5);
mgr1.displayDetails();