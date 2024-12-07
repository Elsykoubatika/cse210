using System;

public class Assignement
{
    private string _studentName;
    private string _topic;

    public Assignement(string name, string topic)
    {
        _studentName = name;
        _topic = topic;
    }
    public string GetstudentName()
    {
        return _studentName;
    }
    public string GetTopic()
    {
        return _topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}