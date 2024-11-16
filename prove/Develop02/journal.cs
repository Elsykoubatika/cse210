using System;
using System.IO.Enumeration;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Journal 
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
        Console.WriteLine("Entrée ajoutée avec succès.");
    }

    public void SaveToFile(string fileName)
    {   
        try
        {
            File.WriteAllText(fileName, string.Join(",", _entries));
            Console.WriteLine($"Enter Save to cvs File '{fileName}'");
        }

        catch (Exception e)
        {
            Console.WriteLine($"Errer save CSV : {e.Message}");
        }

    }

    public void LoadFromFile(String fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine($"File '{fileName}' not found");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);
        _entries = new List<Entry>();

        foreach (string line in lines)
        {
            try
            {
                _entries.Add(Entry.Parse(line));
            }

            catch (FormatException ex)
            {
                Console.WriteLine($"Skipping invalid entry: {line}");
                Console.WriteLine($"Error: {ex.Message}");
            }
            
        }
        Console.WriteLine($"Journal loaded From  '{fileName}' With {_entries.Count} entries.");
    }

    public void DisplayAll()
    {
        Console.WriteLine("Liste des Entrer :");

        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_entries[i]}");
        }
    }
}