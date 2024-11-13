using System;

class Program
{
    static void Main(string[] args)
    {
        Resume myResume = new Resume();
        List<Job> _jobs = new List<Job>();
        myResume._name = "Koubatika ELsy F";
        myResume.Displaid();

        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._StartYear = 2019;
        job1._endYear = 2022;
        job1.DisplayJobDetails();


    }
}