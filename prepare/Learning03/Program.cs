using System;

class Program
{
    static void Main(string[] args)
    {
        // Create fractions using different constructors
        Fraction fraction1 = new Fraction();         // 1/1
        Fraction fraction2 = new Fraction(5);        // 5/1
        Fraction fraction3 = new Fraction(3, 4);     // 3/4
        Fraction fraction4 = new Fraction(1, 3);     // 1/3

        // Display the fraction string and decimal value
        Console.WriteLine(fraction1.GetFractionString()); // Output: 1/1
        Console.WriteLine(fraction1.GetDecimalValue());   // Output: 1

        Console.WriteLine(fraction2.GetFractionString()); // Output: 5/1
        Console.WriteLine(fraction2.GetDecimalValue());   // Output: 5

        Console.WriteLine(fraction3.GetFractionString()); // Output: 3/4
        Console.WriteLine(fraction3.GetDecimalValue());   // Output: 0.75

        Console.WriteLine(fraction4.GetFractionString()); // Output: 1/3
        Console.WriteLine(fraction4.GetDecimalValue());   // Output: 0.3333333...

        // Using setters to change fraction values
        fraction1.SetNumerator(7);
        fraction1.SetDenominator(8);
        Console.WriteLine(fraction1.GetFractionString()); // Output: 7/8
        Console.WriteLine(fraction1.GetDecimalValue());   // Output: 0.875
    }
}
