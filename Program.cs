using System;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Welcome to the Calculator!");
        
            while (true)
            {
                Console.Write("Enter operation (+, -, *, /) or 'exit' to quit: ");
                string? operation = Console.ReadLine();

                // Check if the 'operation' string is null or empty
                if (string.IsNullOrEmpty(operation)) 
                {
                    Console.WriteLine("Error: Please enter a valid operation that are not 0.");
                    continue;
                }

                // Check if the user wants to exit the program
                if (operation.ToLower() == "exit") break;

                // Check if the entered operation is valid (+, -, *, /)
                if (operation != "+" && operation != "-" && operation != "*" && operation != "/")
                {
                    Console.WriteLine("Error: Invalid operation. Please use +, -, *, or /.");
                    continue;
                }

                Console.Write("Enter two numbers separated by a comma: ");
                string? input = Console.ReadLine();

                // Check if the input string is null or empty
                if (string.IsNullOrEmpty(input)) 
                {
                    Console.WriteLine("Error: Please enter a valid numbers that are not 0.");
                    continue;
                }

                // Split the input into an array using the comma as a separator
                string[] parts = input.Split(',');

                // Check if the user has entered exactly two numbers
                if (parts.Length != 2)
                {
                    Console.WriteLine("Please enter exactly two numbers.");
                    continue;
                }

                 // Try to parse both numbers from the input strings to doubles
                if (!double.TryParse(parts[0], out double num1) || !double.TryParse(parts[1], out double num2))
                {
                    Console.WriteLine("Error: Both inputs must be valid numbers.");
                    continue;
                }

                // Call the Calculate method to perform the operation on the two numbers
                double result = Calculate(num1, num2, operation);
                Console.WriteLine($"Result: {result}\n");
            }
        }

         // Method to perform the calculation based on the operation
        static double Calculate(double a, double b, string op)
        {
            // Switch statement to handle different operations
            switch (op)
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/": 
                    
                    if (b == 0)  // Check for division by zero
                    {
                        Console.WriteLine("Error: Cannot divide by zero.");
                        return 0;
                    }
                    return a / b;
                default:
                    Console.WriteLine("Invalid operation.");
                    return 0;
            }
        }
    }
}