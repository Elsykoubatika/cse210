using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private List<Reference> _reference;
    private List<Word> _words;
    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
        _reference = new List<Reference>();

    }

    //Methode pour charger des écritures depuis un fichier
    public void LoadFromFile(string filepath)
    {
        if (!File.Exists(filepath))
        {
            Console.WriteLine("File not found");
            return;
        }

        String[] lines = File.ReadAllLines(filepath);

        foreach (string line in lines)
        {
            // diviser chaque ligne en parties: book, chapter, verse et text
            string[] parts = line.Split('|');
            if (parts.Length == 4)
            {
                string book = parts[0];
                int chapter = int.Parse(parts[1]);
                int verse = int.Parse(parts[2]);
                string text = parts[3];

                
                //decoupe le texte en mots et crée un objet word pour chaque mot
                _words = new List<Word>();

                string[] wordsArray = text.Split(' ');
                foreach (string word in wordsArray)
                {
                    _words.Add(new Word (word));
                }
            
                // Crée une nouvelle réference et une nouvelle Scripture
                Reference reference = new Reference(book, chapter, verse);
                Scripture scripture = new Scripture(reference);

                //Ajoute à la bibliothéque
                _scriptures.Add(scripture);
                _reference.Add(reference);

            }
        }
    }

    //Méthode pour choisir une écriture au hasard
    public Scripture GetRandomSripture()
    {
        if (_scriptures.Count == 0)
        {
            Console.WriteLine("Nothing");
            return null;
        }

        Random random = new Random();
        int randomIndex = random.Next(_scriptures.Count);

        return _scriptures[randomIndex];
    }

    //Méthode pour afficher toutes les écritures chargées(utile pour vérifier)
    public void DisplayAllScripture()
    {
        foreach (Scripture scripture in _scriptures)
        {
            Console.WriteLine($"{scripture.GetReference().GetDisplayText()} \n'{scripture.GetDisplayText()}'");
        }
    }

}