using System;

public class Job
{
    public string _company = "";
    public string _jobTitle = "";
    public int _StartYear = 0;
    public int _endYear = 0;

    public void DisplayJobDetails()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_StartYear}-{_endYear}");
    }
}