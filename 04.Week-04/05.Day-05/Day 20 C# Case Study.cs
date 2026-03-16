using System;

public class Employee
{
    // ===============================
    // PRIVATE FIELDS (Data Hiding)
    // ===============================

    // Internal storage for full name
    private string _fullName;

    // Internal storage for age
    private int _age;

    // Internal storage for salary (sensitive data)
    private decimal _salary;

    // Readonly employee ID (never changes after creation)
    private readonly string _employeeId;


    // ===============================
    // PROPERTIES (Controlled Access)
    // ===============================

    // Public property for FullName
    // Validation prevents empty names
    public string FullName
    {
        get => _fullName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Full name cannot be empty or whitespace.");

            _fullName = value.Trim(); // remove extra spaces
        }
    }

    // Public property for Age
    public int Age
    {
        get => _age;
        set
        {
            if (value < 18 || value > 80)
                throw new ArgumentException("Age must be between 18 and 80.");

            _age = value;
        }
    }

    // Salary property
    // Public read, but private write
    public decimal Salary
    {
        get => _salary;
        private set
        {
            if (value < 1000)
                throw new ArgumentException("Salary cannot be less than 1000.");

            _salary = value;
        }
    }

    // Read-only EmployeeId property
    public string EmployeeId => _employeeId;


    // ===============================
    // CONSTRUCTORS (Safe Creation)
    // ===============================

    // Constructor with automatic ID generation
    public Employee(string fullName, decimal startingSalary, int age)
    {
        // Generate simple employee ID
        _employeeId = "E" + Guid.NewGuid().ToString().Substring(0, 6);

        // Use properties so validation logic is reused
        FullName = fullName;
        Age = age;
        Salary = startingSalary;
    }

    // Constructor with custom ID
    public Employee(string employeeId, string fullName, decimal startingSalary, int age)
    {
        if (string.IsNullOrWhiteSpace(employeeId))
            throw new ArgumentException("Employee ID cannot be empty.");

        _employeeId = employeeId;

        FullName = fullName;
        Age = age;
        Salary = startingSalary;
    }


    // ===============================
    // BUSINESS METHODS
    // ===============================

    // Method to increase salary
    public void GiveRaise(decimal percentage)
    {
        // Company rule: raise must be between 0 and 30%
        if (percentage <= 0 || percentage > 30)
            throw new ArgumentException("Raise must be between 0 and 30 percent.");

        decimal increase = Salary * (percentage / 100);

        Salary += increase;

        Console.WriteLine($"Raise applied ({percentage}%). New salary: {Salary}");
    }

    // Method to deduct penalty
    public bool DeductPenalty(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Penalty amount must be positive.");

        // Salary must never drop below 1000
        if (Salary - amount < 1000)
        {
            Console.WriteLine("Penalty rejected: salary cannot fall below 1000.");
            return false;
        }

        Salary -= amount;

        Console.WriteLine($"Penalty deducted: {amount}. New salary: {Salary}");
        return true;
    }
}


// ======================================
// MAIN PROGRAM (Testing the Employee class)
// ======================================
class Program
{
    static void Main()
    {
        try
        {
            // Create employee
            var emp = new Employee("Marko Horvat", 4500m, 35);

            Console.WriteLine("Employee Created");
            Console.WriteLine($"ID: {emp.EmployeeId}");
            Console.WriteLine($"Name: {emp.FullName}");
            Console.WriteLine($"Age: {emp.Age}");
            Console.WriteLine($"Salary: {emp.Salary}");

            Console.WriteLine();

            // Give raise
            emp.GiveRaise(15);

            Console.WriteLine();

            // Deduct penalty
            emp.DeductPenalty(200);

            Console.WriteLine();

            // Update name
            emp.FullName = "Marko Horvat Jr.";

            Console.WriteLine($"Updated Name: {emp.FullName}");

            Console.WriteLine();

            // Show final salary
            Console.WriteLine($"Final Salary: {emp.Salary}");

            // Examples of forbidden operations (won't compile or will throw exception)

            // emp.Salary = 800;      //  impossible (private setter)
            // emp._salary = -500;    //  private field
            // emp.Age = 12;          //  exception
            // emp.FullName = "";     //  exception
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}