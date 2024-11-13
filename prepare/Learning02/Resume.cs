using System;

public class Resume
{
    public string _name = "";
    public string _jobs = "";

    public void Displaid ()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Jobs: {_jobs}");
    }
}