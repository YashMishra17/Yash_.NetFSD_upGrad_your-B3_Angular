using System;
using System.Collections.Generic;

// Record (structure) to store student details
struct Student
{
    public int RollNumber;
    public string Name;
    public string Course;
    public int Marks;
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();
        int choice;

        do
        {
            Console.WriteLine("\n--- Student Record Management System ---");
            Console.WriteLine("1. Add Student Records");
            Console.WriteLine("2. Display All Records");
            Console.WriteLine("3. Search by Roll Number");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    AddStudents(students);
                    break;

                case 2:
                    DisplayStudents(students);
                    break;

                case 3:
                    SearchStudent(students);
                    break;

                case 4:
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 4);
    }

    // Method to add students
    static void AddStudents(List<Student> students)
    {
        Console.Write("Enter number of students: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Invalid number.");
            return;
        }

        for (int i = 0; i < n; i++)
        {
            Student s = new Student();

            // Roll Number validation
            while (true)
            {
                Console.Write("Enter Roll Number: ");
                if (int.TryParse(Console.ReadLine(), out int roll) && roll > 0)
                {
                    s.RollNumber = roll;
                    break;
                }
                Console.WriteLine("Invalid Roll Number. Try again.");
            }

            Console.Write("Enter Name: ");
            s.Name = Console.ReadLine();

            Console.Write("Enter Course: ");
            s.Course = Console.ReadLine();

            // Marks validation
            while (true)
            {
                Console.Write("Enter Marks (0-100): ");
                if (int.TryParse(Console.ReadLine(), out int marks) && marks >= 0 && marks <= 100)
                {
                    s.Marks = marks;
                    break;
                }
                Console.WriteLine("Invalid Marks. Enter between 0 and 100.");
            }

            students.Add(s);
        }

        Console.WriteLine("Student records added successfully.");
    }

    // Method to display students
    static void DisplayStudents(List<Student> students)
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No records found.");
            return;
        }

        Console.WriteLine("\nStudent Records:");
        foreach (Student s in students)
        {
            Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
        }
    }

    // Method to search student
    static void SearchStudent(List<Student> students)
    {
        Console.Write("Enter Roll Number to search: ");

        if (!int.TryParse(Console.ReadLine(), out int roll))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        foreach (Student s in students)
        {
            if (s.RollNumber == roll)
            {
                Console.WriteLine("\nSearch Result:");
                Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
                return;
            }
        }

        Console.WriteLine("Student record not found.");
    }
}