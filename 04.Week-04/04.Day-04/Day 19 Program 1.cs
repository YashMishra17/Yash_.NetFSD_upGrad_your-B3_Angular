using System;

// Calculator class
// Contains methods for performing arithmetic operations
public class Calculator
{
    // Method to add two numbers
    // Takes two integers as parameters and returns their sum
    public int Add(int a, int b)
    {
        return a + b;
    }

    // Method to subtract two numbers
    // Takes two integers and returns the difference
    public int Subtract(int a, int b)
    {
        return a - b;
    }
}

// Main program class
class Program
{
    static void Main()
    {
        // Create an object of Calculator class
        Calculator calc = new Calculator();

        // Sample input numbers
        int num1 = 10;
        int num2 = 5;

        // Call Add method
        int additionResult = calc.Add(num1, num2);

        // Call Subtract method
        int subtractionResult = calc.Subtract(num1, num2);

        // Display results
        Console.WriteLine("Addition = " + additionResult);
        Console.WriteLine("Subtraction = " + subtractionResult);
    }
}