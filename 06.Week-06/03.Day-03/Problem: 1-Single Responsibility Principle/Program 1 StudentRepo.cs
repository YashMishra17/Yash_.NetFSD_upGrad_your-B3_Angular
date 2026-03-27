using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class StudentRepository
    {
        private List<Student> students = new List<Student>();

        // Add student
        public void AddStudent(Student s)
        {
            students.Add(s);
        }

        // Get all students
        public List<Student> GetStudents()
        {
            return students;
        }
    }
}
