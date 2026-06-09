using StudentDatabase.Data;
using StudentDatabase.Models;
using System;

namespace StudentDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentContext())
            {
                var student = new Student
                {
                    StudentName = "John Smith"
                };

                db.Students.Add(student);
                db.SaveChanges();

                Console.WriteLine("Student added successfully!");
            }

            Console.ReadLine();
        }
    }
}