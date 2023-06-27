using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();        // Initializes fraction to 1/1
        Fraction fraction2 = new Fraction(5);       // Initializes fraction to 5/1
        Fraction fraction3 = new Fraction(3, 4);    // Initializes fraction to 3/4
        Fraction fraction4 = new Fraction(3, 4);
        
        Console.WriteLine("Fraction 1: " + fraction1.GetFractionString());
        Console.WriteLine("Fraction 2: " + fraction2.GetFractionString());
        Console.WriteLine("Fraction 3: " + fraction3.GetFractionString());
        
        int numerator = fraction3.Top;      
        int denominator = fraction3.Bottom; 

        Console.WriteLine("Numerator of Fraction 3: " + numerator);
        Console.WriteLine("Denominator of Fraction 3: " + denominator);

        
        Fraction fraction5 = new Fraction(3, 4);
        string fractionString = fraction5.GetFractionString();
        double decimalValue = fraction5.GetDecimalValue();

        Console.WriteLine("Fraction: " + fractionString);
        Console.WriteLine("Decimal Value: " + decimalValue);

    }
}