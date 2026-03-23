/*Week-6 (DAY-1) / Day - 25
 * Hands-On
Level-1 Problem 2: Debugging Incorrect Discount Calculation
Scenario
A retail application calculates the final price of products after applying a discount. Recently, users reported that the final price shown by the application is incorrect. The development team needs to debug the application to identify where the incorrect calculation is happening.
Requirements
Create a console application that calculates the final product price.
The program should accept:
oProduct Name
oProduct Price
oDiscount Percentage
The final price should be calculated using the formula:
FinalPrice = Price − (Price × Discount / 100)
Use debugging tools to verify that the calculation is correct.
Place breakpoints and inspect variable values during execution.
Technical Constraints
Use Visual Studio Debugging Tools.
Use breakpoints, step over, step into, and watch window.
Implement the solution using a .NET console application.
Expectations
Students should run the program in debug mode.
They should track variable values and confirm that the discount calculation is correct.
If incorrect results appear, students should identify the faulty logic.
Learning Outcome
Students will learn how to:
Use breakpoints effectively.
Inspect variable values during program execution.
Identify logical errors using debugging techniques.*/

///////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace ConsoleApp8
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Input
                Console.Write("Enter Product Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Product Price: ");
                double price = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Discount (%): ");
                double discount = Convert.ToDouble(Console.ReadLine());

                // Correct Formula
                double finalPrice = price - (price * discount / 100);

                // Output
                Console.WriteLine("\nProduct Name : " + name);
                Console.WriteLine("Original Price : " + price);
                Console.WriteLine("Discount (%) : " + discount);
                Console.WriteLine("Final Price : " + finalPrice);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}