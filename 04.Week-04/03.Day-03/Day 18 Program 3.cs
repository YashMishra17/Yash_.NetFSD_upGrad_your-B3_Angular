/*Week - 04 
 * Day - 03 / 18
 Level-2 Problem 3: Employee Bonus Calculator
Scenario
Develop a console application that calculates employee bonus based on salary and years of experience.
Requirements
• Accept employee name, salary and years of experience.
• Use if-else and conditional operator.
• Bonus rules:
   - Experience < 2 years: 5% bonus
   - 2-5 years: 10% bonus
   - >5 years: 15% bonus
• Display final salary after bonus.
Technical Constraints
• Use double for salary.
• Use if-else and ternary operator.
• Use proper formatting for currency output.
Sample Input
Enter Name: Aisha
Enter Salary: 50000
Enter Experience: 4
Sample Output
Employee: Aisha
Bonus: 5000
Final Salary: 55000
Expectations
Accurate bonus calculation and correct usage of control statements.
Learning Outcome
Apply conditional logic and arithmetic operations in real-world scenarios.*/

/////////////////////////////////////////////////////////////////////////////////////

using System;

// Ask user to enter employee name
Console.WriteLine("Enter Name:");
string name = Console.ReadLine();

// Ask user to enter salary
Console.WriteLine("Enter Salary:");
double salary = double.Parse(Console.ReadLine());

// Ask user to enter years of experience
Console.WriteLine("Enter Experience:");
int experience = int.Parse(Console.ReadLine());

// Variable to store bonus percentage
double bonusPercent;

// Determine bonus percentage using if-else
if (experience < 2)
{
    bonusPercent = 0.05;   // 5% bonus
}
else if (experience <= 5)
{
    bonusPercent = 0.10;   // 10% bonus
}
else
{
    bonusPercent = 0.15;   // 15% bonus
}

// Calculate bonus amount
double bonus = salary * bonusPercent;

// Calculate final salary after adding bonus
double finalSalary = salary + bonus;

// Display employee name
Console.WriteLine("Employee: " + name);

// Display calculated bonus
Console.WriteLine("Bonus: " + bonus);

// Display final salary after bonus
Console.WriteLine("Final Salary: " + finalSalary);