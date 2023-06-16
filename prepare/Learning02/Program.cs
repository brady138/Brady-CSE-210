using System;

public class Job
{
    public string _jobTitle;
    public string _company;
    public int _start;
    public int _end;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_start}-{_end}");
    }
}
public class Resume
{
    public string _name;

    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}
public class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Senior Software Engineer";
        job1._company = "Microsoft";
        job1._start = 2003;
        job1._end = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Software Engineer";
        job2._company = "Apple";
        job2._start = 2001;
        job2._end = 2003;

        Resume myResume = new Resume();
        myResume._name = "Allison Rose";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}

