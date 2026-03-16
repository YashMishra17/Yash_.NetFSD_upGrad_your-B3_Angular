/*DAY-1 Hands-On
 * Week - 05 / Day - 21
Level-1 Problem 2: Employee Salary Calculator
Scenario:
A company wants to calculate employee salaries using inheritance. All employees have a base salary, but different roles calculate bonuses differently.
Requirements:
1. Create a base class Employee with Name and BaseSalary properties.
2. Create derived classes Manager and Developer.
3. Override a virtual method CalculateSalary().
4. Manager gets 20% bonus, Developer gets 10% bonus.
Technical Constraints:
• Use inheritance and method overriding.
• Apply polymorphism using base class reference.
• Use properties for salary details.
Expectations:
• Demonstrate runtime polymorphism.
• Avoid code duplication.
• Display final calculated salary.
Learning Outcome:
• Understand inheritance hierarchy.
• Implement polymorphism using virtual and override.
• Write reusable and extensible code.
Sample Input: 
BaseSalary = 50000
Sample Output: 
Manager Salary = 60000, Developer Salary = 55000*/


using System;

// Base class
class Employee
{
    // Properties
    public string Name { get; set; }
    public double BaseSalary { get; set; }

    // Virtual method for salary calculation
    public virtual double CalculateSalary()
    {
        return BaseSalary;
    }
}

// Derived class: Manager
class Manager : Employee
{
    // Override method
    public override double CalculateSalary()
    {
        // Manager gets 20% bonus
        return BaseSalary + (BaseSalary * 0.20);
    }
}

// Derived class: Developer
class Developer : Employee
{
    // Override method
    public override double CalculateSalary()
    {
        // Developer gets 10% bonus
        return BaseSalary + (BaseSalary * 0.10);
    }
}

class Program
{
    static void Main()
    {
        double baseSalary = 50000;

        // Polymorphism using base class reference
        Employee manager = new Manager();
        manager.Name = "Alice";
        manager.BaseSalary = baseSalary;

        Employee developer = new Developer();
        developer.Name = "Bob";
        developer.BaseSalary = baseSalary;

        // Display calculated salaries
        Console.WriteLine("Manager Salary = " + manager.CalculateSalary());
        Console.WriteLine("Developer Salary = " + developer.CalculateSalary());
    }
}