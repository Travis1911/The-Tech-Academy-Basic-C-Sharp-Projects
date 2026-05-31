using System;

namespace Method_Class
{
    // This class contains a method that accepts two integer parameters.
    class MathOperations
    {
        // This method performs a math operation on the first integer
        // and displays the second integer.
        public void PerformOperation(int firstNumber, int secondNumber)
        {
            // Multiply the first number by 2.
            int result = firstNumber * 2;

            // Display the result.
            Console.WriteLine("Result of first number * 2: " + result);

            // Display the second integer.
            Console.WriteLine("Second number: " + secondNumber);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an object of the MathOperations class.
            MathOperations mathOps = new MathOperations();

            // Call the method using positional arguments.
            mathOps.PerformOperation(10, 20);

            Console.WriteLine();

            // Call the method using named parameters.
            mathOps.PerformOperation(firstNumber: 15, secondNumber: 30);

            // Keep the console window open.
            Console.ReadKey();
        }
    }
}