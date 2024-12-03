using System;

public class Scripture
{   
    private Reference _reference;
    private List<Word> _words;
    
    public Scripture(Reference reference)
    {
        _reference = reference;
        _words = new List<Word>();
    }

    public void HideRandomWords(int numberToHide)
    
    {
        Random random = new Random();

        // créé une liste de mots visible
        List<Word> availablewords = new List<Word>();

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                availablewords.Add(word);
            }
        }

        //cache les mots aleatoire
        for (int i = 0; i < numberToHide && availablewords.Count > 0; i++)
        {
            //choisit un mot aleatoire dans la liste des mots visibles
            int randomIndex = random.Next(availablewords.Count);
            Word selectedWord = availablewords[randomIndex];

            //Masque le mot et retire de la liste
            selectedWord.Hide();
            availablewords.RemoveAt(randomIndex);
        }   
        
    }
    public string GetDisplayText()
    {
        // Crée une chaîne de texte avec les mots affichés ou masqués
        string result = " ";
        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }
        return result.TrimEnd(); // Supprime l'espace final inutil
    }

    public bool IsCompletelyHidden()
    {
        // Vérifie si tous les mots sont masqués
        foreach (Word word in _words)
        {
            if (!word.IsHidden()) // Si au moins un mot est visible, retourne false
            {
                return false;
            }
        }
        return true; // Tous les mots sont masqués
    }

    public Reference GetReference()
    {
        return _reference;
    }
}