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

    public void SaveToFile(string file)
    {   
        File.WriteAllText(file, string.Join(",", _entries));
        Console.WriteLine($"Enter Save to CVS File '{file}'");
    }

    public void LoadFromFile(String file)
    {

        string contenu = File.ReadAllText(file);
        var entriesText = contenu.Split(',');
        _entries = new List<Entry>();

        foreach (var entryText in entriesText)
        {
            _entries.Add(Entry.Parse(entryText));
        }
        Console.WriteLine($"Load From file '{file}'");
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