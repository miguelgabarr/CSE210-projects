using System.Collections.Generic;

public class Resume
{
    private string _name;
    private List<Job> _jobs;

    // Constructor to initialize the resume with a person's name
    public Resume(string name)
    {
        _name = name;
        _jobs = new List<Job>(); // Initialize the list of jobs
    }

    // Getter and setter property for the person's name
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    // Getter property for the list of jobs
    public List<Job> Jobs
    {
        get { return _jobs; }
    }

    // Method to add a job to the resume
    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }
}
