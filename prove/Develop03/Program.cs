using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("john", 3, 10);
        string text = "For God so loved the world that He gave His only Son";

        Scripture scripture = new Scripture(reference, text);
        Console.WriteLine($"{reference.GetDisplayText()}\n{text}");
        bool boucle = true;

        while (boucle == true)
        {
            string choice = Console.ReadLine();
            if (choice == "quit")
            {
                boucle = false;
                break;
            }
            else
            {
                scripture.HideRandomWords(3);
                Console.WriteLine($"{reference.GetDisplayText()}\n{scripture.GetDisplayText()}");
                Console.WriteLine(scripture.IsCompletelyHidden());

                Console.Clear();
                Console.WriteLine($"{reference.GetDisplayText()}\n{scripture.GetDisplayText()}");
            }
        
        }
    }
}
