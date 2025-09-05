using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int value))
            {
                Console.WriteLine("Please enter a valid integer.");
                continue;
            }

            if (value == 0)
                break;

            numbers.Add(value);
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        int sum = 0;
        foreach (int n in numbers)
            sum += n;

        Console.WriteLine($"The sum is: {sum}");

        double average = sum / (double)numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int largest = numbers[0];
        foreach (int n in numbers)
            if (n > largest) largest = n;

        Console.WriteLine($"The largest number is: {largest}");

        int? smallestPositive = null;
        foreach (int n in numbers)
        {
            if (n > 0 && (smallestPositive == null || n < smallestPositive))
                smallestPositive = n;
        }

        if (smallestPositive != null)
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        else
            Console.WriteLine("There are no positive numbers.");

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int n in numbers)
            Console.WriteLine(n);
    }
}