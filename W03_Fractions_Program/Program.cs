using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Core Requirements ===");
        Fraction f1 = new Fraction();        // 1/1
        Fraction f2 = new Fraction(5);       // 5/1
        Fraction f3 = new Fraction(3, 4);    // 3/4
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Console.WriteLine();        
        Console.WriteLine("=== Encapsulation Check (getters/setters) ===");
        f3.SetTop(6);
        f3.SetBottom(7);
        Console.WriteLine(f3.GetFractionString());   // 6/7
        Console.WriteLine(f3.GetDecimalValue());     // 0.8571428571428571

        Console.WriteLine();
        Console.WriteLine("=== Exceeds: Reduction, Sign Normalization, Mixed Number ===");
        Fraction fNeg = new Fraction(8, -12); // should normalize to -2/3
        Console.WriteLine($"8/-12 reduced => {fNeg.GetFractionString()}");
        Console.WriteLine($"As decimal: {fNeg.GetDecimalValue()}");
        Fraction fMixed = new Fraction(7, 3); // 2 1/3
        Console.WriteLine($"7/3 mixed => {fMixed.GetMixedNumberString()}");

        Console.WriteLine();
        Console.WriteLine("=== Exceeds: Add & Multiply ===");
        Fraction a = new Fraction(1, 6);
        Fraction b = new Fraction(1, 4);
        Fraction sum = a.Add(b);            // 1/6 + 1/4 = 5/12
        Fraction prod = a.Multiply(b);      // 1/24
        Console.WriteLine($"1/6 + 1/4 = {sum.GetFractionString()} (decimal {sum.GetDecimalValue()})");
        Console.WriteLine($"1/6 * 1/4 = {prod.GetFractionString()} (decimal {prod.GetDecimalValue()})");

        Console.WriteLine();
        Console.WriteLine("=== Guard: Zero denominator becomes /1 and reduces ===");
        Fraction z = new Fraction(5, 0); // guarded to 5/1
        Console.WriteLine($"5/0 guarded => {z.GetFractionString()}");
    }
}
