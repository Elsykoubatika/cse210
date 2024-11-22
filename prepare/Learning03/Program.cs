using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction = new Fraction(3, 4);
        fraction.SetBottom(4);
        fraction.SetTop(3);

        //string fract =   $"{fraction.GetBottom()}/{fraction.GetTop()}";

        //Console.WriteLine(fract);

        Console.WriteLine(fraction.GetBottom());
        Console.WriteLine(fraction.GetTop());

        Console.WriteLine(fraction.GetDecimelValue());
        Console.WriteLine(fraction.GetFractionString());
    }
}