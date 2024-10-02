using System;

class Program
{
    static void Main(string[] args)
    {
        // Create fractions using different constructors
        Fraction fraction1 = new Fraction();        
        Fraction fraction2 = new Fraction(5);        
        Fraction fraction3 = new Fraction(3, 4);     
        Fraction fraction4 = new Fraction(1, 3);     

        // Display the fraction string and decimal value
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue()); 

        Console.WriteLine(fraction2.GetFractionString()); 
        Console.WriteLine(fraction2.GetDecimalValue());  

        Console.WriteLine(fraction3.GetFractionString()); 
        Console.WriteLine(fraction3.GetDecimalValue()); 

        Console.WriteLine(fraction4.GetFractionString()); 
        Console.WriteLine(fraction4.GetDecimalValue());   

        // Using setters to change fraction values
        fraction1.SetNumerator(7);
        fraction1.SetDenominator(8);
        Console.WriteLine(fraction1.GetFractionString()); 
        Console.WriteLine(fraction1.GetDecimalValue());   
    }
}
