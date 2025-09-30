using System;
using Homework;

class Program
{
    static void Main()
    {
        var a1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(a1.GetSummary());

        Console.WriteLine();

        var m1 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(m1.GetSummary());
        Console.WriteLine(m1.GetHomeworkList());

        Console.WriteLine();

        var w1 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(w1.GetSummary());
        Console.WriteLine(w1.GetWritingInformation());
    }
}
