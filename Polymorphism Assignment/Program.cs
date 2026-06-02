using System;

namespace EmployeeApplication
{
    // Define an interface named IQuittable.
    // Interfaces contain method signatures that implementing classes must define.
    public interface IQuittable
    {
        // Declare the Quit method.
        void Quit();
    }

    // Employee class implements the IQuittable interface.
    public class Employee : IQuittable
    {
        // Employee ID property.
        public int Id { get; set; }

        // Employee first name property.
        public string FirstName { get; set; }

        // Employee last name property.
        public string LastName { get; set; }

        // Implementation of the Quit method required by IQuittable.
        public void Quit()
        {
            // Display a message indicating the employee has quit.
            Console.WriteLine($"{FirstName} {LastName} has resigned from the company.");
        }
    }

    // Main program class.
    class Program
    {
        // Application entry point.
        static void Main(string[] args)
        {
            // Create an Employee object and assign values to its properties.
            Employee employee = new Employee()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe"
            };

            // Demonstrate polymorphism by creating an object of interface type
            // and assigning it an Employee instance.
            IQuittable quittableEmployee = employee;

            // Call the Quit method through the interface reference.
            quittableEmployee.Quit();

            // Pause the console window so the output can be viewed.
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}