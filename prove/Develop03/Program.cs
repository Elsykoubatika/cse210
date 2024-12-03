using System;
using System.Reflection;

class Program
{
        static void Main(string[] args)
        {
                Reference reference = new Reference();       
                ScriptureLibrary text1 = new ScriptureLibrary();

                string filepath = "D:/Cproject/cse210/prove/Develop03/scriptures.txt";
                text1.LoadFromFile(filepath);

                Scripture randomScripture = text1.GetRandomSripture();

                Console.WriteLine($"{randomScripture.GetReference().GetDisplayText()}: {randomScripture.GetDisplayText()}");
                text1.DisplayAllScripture();

                
                Scripture scripture = new Scripture(reference);

                bool boucle = true;
                
                string choice = Console.ReadLine();
                
                while (boucle == true)
                {
                        string choices = Console.ReadLine();
                        if (choices == "quit")
                        {
                                boucle = false;
                                break;
                        }      
                        else
                        {
                                scripture.HideRandomWords(7);
                                Console.WriteLine($"{randomScripture.GetReference().GetDisplayText()}: {scripture.GetDisplayText()}");
                                Console.WriteLine(scripture.IsCompletelyHidden());      
                                Console.Clear();
                                Console.WriteLine($"{randomScripture.GetReference().GetDisplayText()}: {scripture.GetDisplayText()}");
                        }        
                        
                }
        }
}