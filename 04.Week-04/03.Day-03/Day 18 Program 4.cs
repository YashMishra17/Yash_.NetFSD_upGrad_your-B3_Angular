/*Week - 04 
 * Day - 03 / 18
 Level-2 Problem 4: Number Analysis Using Loops
Scenario
Create a .NET 8 console application that analyzes numbers between 1 and N.
Requirements
• Accept a number N from user.
• Use loops to:
   - Count even numbers
   - Count odd numbers
   - Calculate sum of all numbers
• Display results.
Technical Constraints
• Use for or while loop.
• Use int data type.
• Avoid using arrays or collections.
Sample Input
Enter Number: 10
Sample Output
Even Count: 5
Odd Count: 5
Sum: 55
Expectations
Proper loop usage and correct counting logic.
Learning Outcome
Strengthen understanding of loops, counters and accumulators in C#.*/

/////////////////////////////////////////////////////////////////////////////////////

using System;

// Ask user to enter a number
Console.WriteLine("Enter Number:");
int n = int.Parse(Console.ReadLine());

// Counters and accumulator
int evenCount = 0;
int oddCount = 0;
int sum = 0;

// Loop from 1 to N
for (int i = 1; i <= n; i++)
{
    // Add current number to sum
    sum = sum + i;

    // Check if number is even
    if (i % 2 == 0)
    {
        evenCount++;   // increase even counter
    }
    else
    {
        oddCount++;    // increase odd counter
    }
}

// Display results
Console.WriteLine("Even Count: " + evenCount);
Console.WriteLine("Odd Count: " + oddCount);
Console.WriteLine("Sum: " + sum);