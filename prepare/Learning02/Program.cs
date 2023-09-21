using System;

class Program
{
    static void Main(string[] args)
    {
        // Create the first job instance (job1)
        Job job1 = new Job("Microsoft", "Software Engineer", 2019, 2022);

        // Create the second job instance (job2)
        Job job2 = new Job("Apple", "Manager", 2022, 2023);

        // Create a Resume instance
        Resume myResume = new Resume("Allison Rose");

        // Add the two job instances to the list of jobs in the resume
        myResume.AddJob(job1);
        myResume.AddJob(job2);

        // Display the resume details
        myResume.Display();
    }
}
