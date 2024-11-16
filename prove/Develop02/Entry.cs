using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    internal static Entry Parse(string entryText)
    {
        string[] parts = entryText.Split(new[] {" - ", ": "}, StringSplitOptions.None);
        

        if (parts.Length == 3)
        {
            return new Entry
            {
                _date = parts[0],
                _promptText = parts[1],
                _entryText = parts[2],
            };
        }

        throw new NotImplementedException("Entry text is not in the correct format. ");
    }

    public void Displaid()
    {
        Console.WriteLine($"{_promptText}\n{_entryText}\n{_date}");
    }
}