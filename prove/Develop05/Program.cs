using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

class Program
{
    [Serializable]
    class Goal
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public string ShortDescription { get; set; }
        public int Points { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }

        public Goal(string description, DateTime dueDate, string type, string shortDescription, int points)
        {
            Description = description;
            Type = type;
            ShortDescription = shortDescription;
            Points = points;
            IsCompleted = false;
            DueDate = dueDate;
        }
    }

    static List<Goal> goalList = new List<Goal>();
    static string dataFilePath = "goals.dat";
    static int totalPoints = 0;

    static void Main()
    {
        LoadGoals();

        int choice;
        do
        {
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateNewGoal();
                        break;
                    case 2:
                        ListGoals();
                        break;
                    case 3:
                        SaveGoals();
                        break;
                    case 4:
                        LoadGoals();
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        Console.WriteLine("Exiting program.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

        } while (choice != 6);
    }

    static void CreateNewGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        if (int.TryParse(Console.ReadLine(), out int goalType) && goalType >= 1 && goalType <= 3)
        {
            Console.Write("What is the name of your Goal? ");
            string description = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string shortDescription = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            if (int.TryParse(Console.ReadLine(), out int points))
            {
                Console.Write("Enter due date (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
                {
                    Goal newGoal = new Goal(description, dueDate, GetGoalTypeName(goalType), shortDescription, points);
                    goalList.Add(newGoal);
                    Console.WriteLine("Goal added successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid date format. Goal not added.");
                }
            }
            else
            {
                Console.WriteLine("Invalid points format. Goal not added.");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal type. Please choose a number between 1 and 3.");
        }
    }

    static string GetGoalTypeName(int goalType)
    {
        switch (goalType)
        {
            case 1:
                return "Simple Goal";
            case 2:
                return "Eternal Goal";
            case 3:
                return "Checklist Goal";
            default:
                return "Unknown";
        }
    }

    static void ListGoals()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < goalList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. [{(goalList[i].IsCompleted ? "X" : " ")}] {goalList[i].Description} (Type: {goalList[i].Type}, Due: {goalList[i].DueDate.ToShortDateString()}, Points: {goalList[i].Points})");
        }

        if (goalList.Count == 0)
        {
            Console.WriteLine("No goals available.");
        }

        Console.WriteLine($"Total Points: {totalPoints}");
    }

    static void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        if (fileName.EndsWith(".txt"))
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (Goal goal in goalList)
                    {
                        writer.WriteLine($"[{(goal.IsCompleted ? "X" : " ")}] {goal.Description} (Type: {goal.Type}, Due: {goal.DueDate.ToShortDateString()}, Points: {goal.Points})");
                    }
                }

                Console.WriteLine("Goals saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving goals: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid file extension. File must have '.txt' extension.");
        }
    }

    static void LoadGoals()
    {
        if (File.Exists(dataFilePath))
        {
            try
            {
                using (FileStream fileStream = new FileStream(dataFilePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    goalList = (List<Goal>)formatter.Deserialize(fileStream);
                }

                Console.WriteLine("Goals loaded successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading goals: {ex.Message}");
            }
        }
    }

    static void RecordEvent()
    {
        Console.WriteLine("Goals to mark as completed:");
        ListGoals();

        Console.Write("Enter the number of the goal to mark as completed: ");
        if (int.TryParse(Console.ReadLine(), out int goalNumber) && goalNumber > 0 && goalNumber <= goalList.Count)
        {
            Goal completedGoal = goalList[goalNumber - 1];

            if (!completedGoal.IsCompleted)
            {
                totalPoints += completedGoal.Points;
                Console.WriteLine($"Congratulations! You have earned {completedGoal.Points} points.");

                // Mensaje de motivación con la puntuación ganada
                Console.WriteLine($"Great job! Keep up the good work! You now have a total of {totalPoints} points.");

                completedGoal.IsCompleted = true;
            }
            else
            {
                Console.WriteLine($"You have already completed the goal \"{completedGoal.Description}\". No additional points awarded.");
            }

            Console.WriteLine("Goal marked as completed!");
        }
        else
        {
            Console.WriteLine("Invalid goal number. No changes made.");
        }
    }
}
