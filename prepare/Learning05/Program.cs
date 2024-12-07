using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignement math = new MathAssignement("Problems 8-19", "Section 7.3");
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeWorkList());

        WritingAssignement Write = new WritingAssignement("The Causes of World War II by Mary Waters");
        Console.WriteLine(Write.GetSummary());
        Console.WriteLine(Write.GetWritingInformation());
    }
}