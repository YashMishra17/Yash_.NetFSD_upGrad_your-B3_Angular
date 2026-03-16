/*DAY-4 
 * week - 04 / day 19
 * Hands-On
 * Level-1 Problem 2: Student Grade Calculator
Scenario:
A school wants to calculate the average marks of a student using a class-based approach.
Requirements:
1. Create a class Student.
2. Create method CalculateAverage(int m1, int m2, int m3).
3. Return the average marks.
4. Display grade based on average.
Technical Constraints:
1. Use return type double for average.
2. Avoid hard-coded values.
Expectations:
Clear separation of logic inside methods.
Learning Outcome:
Learn method creation, return values, and basic OOP concepts.
Sample Input: 
80 70 90
Sample Output: 
Average = 80, Grade = A*/


using System;

// Student class containing logic for average and grade
public class Student
{
    // Method to calculate average marks
    // Takes 3 marks as parameters and returns the average as double
    public double CalculateAverage(int m1, int m2, int m3)
    {
        return (m1 + m2 + m3) / 3.0;
    }

    // Method to determine grade based on average
    public string GetGrade(double average)
    {
        if (average >= 90)
            return "A+";
        else if (average >= 80)
            return "A";
        else if (average >= 70)
            return "B";
        else if (average >= 60)
            return "C";
        else if (average >= 50)
            return "D";
        else
            return "F";
    }
}

// Main program
class Program
{
    static void Main()
    {
        // Create Student object
        Student student = new Student();

        // Sample input marks
        int m1 = 80;
        int m2 = 70;
        int m3 = 90;

        // Call method to calculate average
        double avg = student.CalculateAverage(m1, m2, m3);

        // Call method to determine grade
        string grade = student.GetGrade(avg);

        // Display results
        Console.WriteLine("Average = " + avg);
        Console.WriteLine("Grade = " + grade);
    }
}