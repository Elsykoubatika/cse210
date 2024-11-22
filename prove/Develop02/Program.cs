using System;

class Program
{
    static void Main(string[] args)
    {  
        Console.WriteLine("Enter your choice\n1-Add\n2-load\n3-Save\n4-Display\n5-Quit");

        DateTime theCurrentTime = DateTime.Now;

        string answer = "";

        PromptGenerator Promp = new PromptGenerator();
        Journal journal = new Journal();
        Entry Answer = new Entry();

        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 5 )
            {
                Console.WriteLine("Please enter a number between 1 and 5.");
                continue;
            }

            if (choice == 1) // add the text
            {
                Promp.GetRandomPrompt();
                Console.WriteLine(Promp.GetRandomPrompt());

                answer = Console.ReadLine();

                Answer._date = theCurrentTime.ToShortDateString();
                Answer._entryText = answer;
                Answer._promptText = Promp.GetRandomPrompt();

                Console.WriteLine("Enter added seccessfully");
            }
        
            else if (choice == 4) // display
            {   
                Answer.Displaid();
            }

            else if (choice == 3) // Save the file
            {   
                Console.WriteLine("Enter file's name to save: ");
                string fileName = Console.ReadLine();
                journal.SaveToFile(fileName);
            }

            else if (choice == 2)// Load the file
            {
                Console.WriteLine("Enter file's name to lad: ");
                string fileName = Console.ReadLine();
                journal.LoadFromFile(fileName);
            }
            
            else if (choice == 5) // Break the wool
            {
                Console.WriteLine("Goodbye!");
                break;
            }
        }
    }
}