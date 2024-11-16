using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    internal static Entry Parse(string entryText)
    {
        throw new NotImplementedException();
    }

    public void Displaid()
    {
        Console.WriteLine($"{_promptText}\n{_entryText}\n{_date}");
    }
}