using System;

namespace OperatorOverloadingAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the first Employee object.
            Employee employee1 = new Employee()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith"
            };

            // Create the second Employee object.
            Employee employee2 = new Employee()
            {
                Id = 1,
                FirstName = "Jane",
                LastName = "Doe"
            };

            // Compare the two employees using the overloaded == operator.
            bool areEqual = employee1 == employee2;

            // Display employee information.
            Console.WriteLine("Employee Comparison Results");
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Employee 1: {employee1.FirstName} {employee1.LastName} (ID: {employee1.Id})");
            Console.WriteLine($"Employee 2: {employee2.FirstName} {employee2.LastName} (ID: {employee2.Id})");
            Console.WriteLine();

            // Display comparison result.
            Console.WriteLine($"Are the employees equal? {areEqual}");

            // Keep the console window open.
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}