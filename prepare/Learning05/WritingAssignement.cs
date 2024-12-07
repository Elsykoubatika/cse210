using System;

public class WritingAssignement : Assignement
{
    private string _title;

    public WritingAssignement(string title) : base("Mary Waters", "European History")
    {
        _title = title;
    }

    public string GetTitle()
    {
        return _title;
    }
    public string GetWritingInformation()
    {
        return $"{_title}";
    }
}