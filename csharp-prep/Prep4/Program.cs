using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a list to store numbers.
        List<double> numbers = new List<double>();

        // Ask the user to enter numbers.
        while (true)
        {
            Console.Write("Enter a number (or type '0' to finish): ");
            string input = Console.ReadLine();

            // "0" to exit the loop.
            if (input == "0")
                break;

            try
            {
                // Convert the user's input to a decimal number and add it to the list.
                double num = double.Parse(input);
                numbers.Add(num);
            }
            
            // Error message If the user doesn't enter a valid number.
            catch (FormatException)
            {
                Console.WriteLine("Invalid input, please enter a number.");
            }
        }

        // If the user entered at least one number, calculate statistics.
        if (numbers.Count > 0)
        {
            // Sum of the numbers.
            double total = 0;
            foreach (double num in numbers)
            {
                total += num;
            }

            // Average of the numbers.
            double average = total / numbers.Count;

            // Largest number.
            double maximum = numbers[0];
            foreach (double num in numbers)
            {
                if (num > maximum)
                {
                    maximum = num;
                }
            }

            // List of positive numbers.
            List<double> positiveNumbers = new List<double>();
            foreach (double num in numbers)
            {
                if (num > 0)
                {
                    positiveNumbers.Add(num);
                }
            }

            // If there are positive numbers, find the smallest one.
            if (positiveNumbers.Count > 0)
            {
                double smallestPositive = positiveNumbers[0];
                foreach (double num in positiveNumbers)
                {
                    if (num < smallestPositive)
                    {
                        smallestPositive = num;
                    }
                }
                Console.WriteLine("The smallest positive number is: " + smallestPositive);
            }
            else
            {
                Console.WriteLine("There are no positive numbers in the list.");
            }

            // Sort the list of numbers.
            numbers.Sort();

            // Display the results.
            Console.WriteLine("The sum is: " + total);
            Console.WriteLine("The average is: " + average);
            Console.WriteLine("The largest number is: " + maximum);
            Console.WriteLine("The sorted list is:");
            foreach (double num in numbers)
            {
                Console.WriteLine(num);
            }
        }
        else
        {
            // No numbers were entered, message.
            Console.WriteLine("No numbers were entered.");
        }
    }
}
