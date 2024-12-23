using System;
using System.IO;

public class GoalManager
{
    private List<Goal> _goal;
    private int _score;

    public GoalManager()
    {
        _goal = new List<Goal>();
        _score = 0;
    }

    public void star()
    {
        Console.WriteLine("1. Create a Goal\n2. List Goals\n3. Record Event\n Display Player Info\n5. Save Goals\n6. Load Goals\n7. Exit\nYour choice: ");
        string choice = Console.ReadLine();
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nPlayer Score: {_score}");
    }

    public void ListeGoalName()
    {
        foreach(Goal goal in _goal)
        {
            Console.WriteLine(goal.GetName());
        }
    }
    public void ListGoalDetail()
    {
        Console.WriteLine("\n--- Goals ---");
        foreach (Goal goal in _goal)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
        
    }
    public void CreateGoal()
    {
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose goal type: ");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goal.Add(new SimpleGoal(description, points));
        }
        else if (type == "2")
        {
            _goal.Add(new EternalGoal(description, points));
        }
        else if (type == "3")
        {
            Console.Write("Target count: ");
            int targetCount = int.Parse(Console.ReadLine());

            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            _goal.Add(new ChecklistGoal(name, description, points, targetCount, bonus));
        }
    }
    public void RecordEvent()
    {
        Console.WriteLine("\nSelect a goal to record an event:");
        for (int i = 0; i < _goal.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goal[i].GetDetailsString()}");
        }

        Console.Write("Your choice: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goal.Count)
        {
            _goal[index].RecordEvent();
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }
    public void SaveGoal()
    {
        using (StreamWriter writer = new StreamWriter("goal.txt"))
        {
            writer.WriteLine($"Player Score: {_score}");

            foreach (Goal goal in _goal)
            {
                string line = goal.GetstringRepresentation();
                writer.WriteLine(line); 
            }
        }
        Console.WriteLine("Les objectifs ont été sauvegardés avec succès.");

    }
    public void LoadGoal()
    {
        _goal.Clear();
        using (StreamReader reader = new StreamReader("goals.txt"))
        {
            // Lire le score total
            _score = int.Parse(reader.ReadLine());
            string[] lines = System.IO.File.ReadAllLines("goals.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts[0] == "SimpleGoal")
                {
                    _goal.Add(new SimpleGoal( parts[2], int.Parse(parts[3])));
                }
                else if (parts[0] == "EternalGoal")
                {
                    _goal.Add(new EternalGoal( parts[2], int.Parse(parts[3])));
                }

                else if (parts[0] == "ChecklistGoal")
                {
                    _goal.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                        int.Parse(parts[4]), int.Parse(parts[6])));
                }
            }
            Console.WriteLine("Les objectifs ont été chargés avec succès.");
        }       
    }
}

