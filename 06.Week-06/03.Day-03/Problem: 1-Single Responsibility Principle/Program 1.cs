using ConsoleApp1;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            StudentRepository repo = new StudentRepository();
            ReportGenerator report = new ReportGenerator();

            while (true)
            {
                Console.WriteLine("\n1. Add Student");
                Console.WriteLine("2. View Report");
                Console.WriteLine("3. Exit");
                Console.Write("Enter choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Student s = new Student();

                    Console.Write("Enter ID: ");
                    s.StudentId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    s.StudentName = Console.ReadLine();

                    Console.Write("Enter Marks: ");
                    s.Marks = Convert.ToInt32(Console.ReadLine());

                    repo.AddStudent(s);
                    Console.WriteLine("Student added successfully!");
                }
                else if (choice == 2)
                {
                    var students = repo.GetStudents();

                    if (students.Count == 0)
                    {
                        Console.WriteLine("No data available.");
                    }
                    else
                    {
                        report.GenerateReport(students);
                    }
                }
                else if (choice == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                }
            }
        }
    }
}