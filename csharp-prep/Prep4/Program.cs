using System;
using System.Collections.Generic;
using System.Linq; // Needed for sorting and easier list operations

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store the numbers
        List<int> numbers = new List<int>();

        // Ask the user for a series of numbers
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number;
        do
        {
            // Ask the user to enter a number
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            // Append the number to the list if it's not 0
            if (number != 0)
            {
                numbers.Add(number);
            }

        } while (number != 0);

        // Core Requirements:
        
        // Compute the sum of the numbers in the list
        int sum = numbers.Sum();
        Console.WriteLine($"The sum is: {sum}");

        // Compute the average of the numbers in the list
        double average = numbers.Average();
        Console.WriteLine($"The average is: {average}");

        // Find the maximum number in the list
        int max = numbers.Max();
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenge:

        // Find the smallest positive number (closest to zero)
        int smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty().Min();
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        // Sort the numbers in the list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
