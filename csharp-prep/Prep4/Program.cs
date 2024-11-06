using System;
using System.Collections.Generic;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        List<int> number = new List<int>();

        int userNumber = -1;

        number.Sort();
        
        while (userNumber != 0)
        {
            Console.WriteLine("Enter a list of numbers, type 0 when finished.");

            string userAnswers = Console.ReadLine();
            userNumber = int.Parse(userAnswers);

            number.Add(userNumber);

            foreach (int numbers in number)
            {
                int sum = 0;
                int largestNumber = number[0];

                float average = ((float) sum) / number.Count;

                if (userNumber != 0)
                {
                    sum += numbers;
                    Console.WriteLine($"The sum is: {sum}");
                    Console.WriteLine($"The average is: {average}");
                }

                if (numbers > largestNumber)
                {
                    largestNumber = numbers;
                    Console.WriteLine($"The largest Number is: {largestNumber}");
                }
            
            }
            
        }
        Console.WriteLine("The sorted list is: " + string.Join(", ", number));
    }
}   