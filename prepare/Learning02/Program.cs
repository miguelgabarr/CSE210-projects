using System;

class Program
{
    static void Main(string[] args)
    {
        // Create the first job instance (job1)
        Job job1 = new Job ("Microsoft", "Software Engineer", 2019, 2022);

        // Set the member variables for job1

        job1.Company = "Microsoft";
        job1.JobTitle = "Software Engineer";
        job1.StartYear = 2019;
        job1.EndYear = 2022;

        //Display job1 company
        Console.WriteLine (job1.Company);

        //Create the second job instance (job2)
        Job job2 = new Job ("Apple", "iOS Developer", 2020, 2023)

         // Set the member variables for job2

        job2.Company = "Apple";
        job2.JobTitle = "iOS Developer";
        job2.StartYear = 2020;
        job2.EndYear = 2023;

        // Display job2 company
        Console.WriteLine (job2.Company);
    }
}