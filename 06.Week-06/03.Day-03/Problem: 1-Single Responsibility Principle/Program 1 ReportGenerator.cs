using ConsoleApp1;
using System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class ReportGenerator
    {
        public void GenerateReport(List<Student> students)
        {
            Console.WriteLine("\n--- Student Report ---");

            foreach (var s in students)
            {
                Console.WriteLine($"ID: {s.StudentId}");
                Console.WriteLine($"Name: {s.StudentName}");
                Console.WriteLine($"Marks: {s.Marks}");

                // Simple grade logic
                string grade = s.Marks >= 50 ? "Pass" : "Fail";

                Console.WriteLine($"Result: {grade}");
                Console.WriteLine("---------------------");
            }
        }
    }
}
