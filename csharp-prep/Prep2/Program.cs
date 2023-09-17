using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        int gradePercentage = int.Parse (Console.ReadLine());

        string letter;

        if (gradePercentage >=90)
        {
            letter = "A";
        }
        
        else if (gradePercentage >=80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }

        else if (gradePercentage >= 60)

        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }

        Console.WriteLine ($"Your letter grade is: {letter}");

        if (gradePercentage >=70)
        {
            Console.WriteLine ("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine ("You did not pass the course.  Keep working hard for next time!");

        }

    }   
}