using System;

class Program
{
    static void Main(string[] args)
    {
        bool replay = true;
        while (replay)
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);
            
            int number = 0;

            bool hope = false;

            while (!hope)
            { 
                Console.WriteLine("What is the magic number? ");
                string guess = Console.ReadLine();
                int guessNumber = int.Parse(guess);

                number++;

                if (guessNumber == magicNumber)
                {
                    Console.WriteLine($"Well done! You've guessed the number in {number} trials!");
                    hope = true;
                } 
                else if (guessNumber > magicNumber)
                {
                    Console.WriteLine(" The magic number is Lower");
                }
                else
                {
                    Console.WriteLine("The magic number is Higher");
                }
            
            } 
        Console.WriteLine("Do you want to play again? (yes to continue, something else to quit");
        string answer = Console.ReadLine().ToLower();    
        replay = (answer == "yes");  
        }
        
        
    }   
}