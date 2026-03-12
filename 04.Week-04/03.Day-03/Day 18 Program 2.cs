/*Week - 04 
 * Day - 03 / 18
 Level-1 Problem 2: Simple Calculator Using Switch
Scenario
Create a simple calculator application that performs basic arithmetic operations.
Requirements
• Accept two numbers from user.
• Accept operator (+, -, *, /).
• Use switch statement to perform operation.
• Display result.
Technical Constraints
• Use int or double data types.
• Use switch-case statement.
• Handle division by zero.
Sample Input
Enter First Number: 10
Enter Second Number: 5
Enter Operator: *
Sample Output
Result: 50
Expectations
Correct operator selection and proper validation of inputs.
Learning Outcome
Understand switch statements, arithmetic operators and control flow in C#.*/

/////////////////////////////////////////////////////////////////////////////////////

using System;

Console.WriteLine("Enter First Number:");
int num1 = int.Parse(Console.ReadLine());

Console.WriteLine("Enter Second Number:");
int num2 = int.Parse(Console.ReadLine());

Console.WriteLine("Enter Operator (+, -, *, /):");
string op = Console.ReadLine();

switch (op)
{
    case "+":
        Console.WriteLine("Result: " + (num1 + num2));
        break;

    case "-":
        Console.WriteLine("Result: " + (num1 - num2));
        break;

    case "*":
        Console.WriteLine("Result: " + (num1 * num2));
        break;

    case "/":
        if (num2 == 0)
        {
            Console.WriteLine("Division by zero not allowed");
        }
        else
        {
            Console.WriteLine("Result: " + (num1 / num2));
        }
        break;

    default:
        Console.WriteLine("Invalid operator");
        break;
}