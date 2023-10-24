using System;

class Student
{
    private string studentName;
    private int studentID;
    private double[] grades;

    public void SetName(string name)
    {
        // Validation logic, if necessary
        studentName = name;
    }

    public string GetName()
    {
        return studentName;
    }

    public void SetID(int id)
    {
        // Validation logic, if necessary
        studentID = id;
    }

    public int GetID()
    {
        return studentID;
    }

    public void SetGrades(double[] studentGrades)
    {
        // Validation logic, if necessary
        grades = studentGrades;
    }

    public double[] GetGrades()
    {
        return grades;
    }
}

class Program
{
    static void Main()
    {
        // Create an instance of the Student class
        Student student = new Student();

        // Get user input for student details
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();
        student.SetName(name);

        Console.Write("Enter student ID: ");
        int id = int.Parse(Console.ReadLine());
        student.SetID(id);

        Console.Write("Enter the number of grades: ");
        int numGrades = int.Parse(Console.ReadLine());

        double[] grades = new double[numGrades];
        for (int i = 0; i < numGrades; i++)
        {
            Console.Write($"Enter grade {i + 1}: ");
            grades[i] = double.Parse(Console.ReadLine());
        }
        student.SetGrades(grades);

        // Display student information
        Console.WriteLine("\nStudent Information:");
        Console.WriteLine($"Name: {student.GetName()}");
        Console.WriteLine($"ID: {student.GetID()}");
        Console.WriteLine("Grades:");

        foreach (var grade in student.GetGrades())
        {
            Console.WriteLine($"- {grade}");
        }
    }
}
