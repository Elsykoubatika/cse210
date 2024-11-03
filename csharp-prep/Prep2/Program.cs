using System;
using System.Reflection.Metadata;

class Program
{ 
        static int getLastNumber(int percent)
    {
        return Math.Abs(percent) % 10;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        string answer = Console.ReadLine();

        int percent = int.Parse(answer);
        string letter = "";
        string sign = "";
        int lastNumber = getLastNumber(percent);
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (lastNumber < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }
        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (percent >= 70)
        {
            Console.WriteLine("Congratilations, You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}