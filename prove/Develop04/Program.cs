using System;
using System.Threading;

class ReflectionActivity : Activity
{
    private readonly string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly string[] reflectionQuestions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base(duration) { }

    public override void Start()
    {
        base.Start();

        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        Console.WriteLine("This will help you recognize the power you have and how you can use it in other aspects of your life.");

        // Ask the user for the duration
        Console.Write("How long, in seconds, would you like for your session? ");
        duration = int.Parse(Console.ReadLine());

        Random random = new Random();

        for (int i = 0; i < duration / 10; i++)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(prompt);
            ShowSpinner(3);

            Console.WriteLine("Waiting for your response (10 seconds)...");
            string userResponse = WaitForUserResponse(10);
            Console.WriteLine($"Your response: {userResponse}");
        }

        base.End();
    }

    private string WaitForUserResponse(int seconds)
    {
        Console.Write("Type your response here: ");
        string response = string.Empty;
        Thread inputThread = new Thread(() => { response = Console.ReadLine(); });
        inputThread.Start();
        inputThread.Join(seconds * 1000);
        inputThread.Abort(); // If user hasn't finished typing in the specified time, abort the thread
        return response;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Self-Care Program!");

        while (true)
        {
            // Display menu
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            // Get user choice
            Console.Write("Enter the number of your choice: ");
            int choice = int.Parse(Console.ReadLine());

            Activity selectedActivity;

            switch (choice)
            {
                case 1:
                    selectedActivity = new BreathingActivity(0); // Duration not used for BreathingActivity
                    break;
                case 2:
                    selectedActivity = new ReflectionActivity(0); // Duration not used initially
                    break;
                case 3:
                    // Add cases for other activities if needed
                    break;
                case 4:
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    continue;
            }

            // Start and end the selected activity
            selectedActivity.Start();
            selectedActivity.End();
        }
    }
}
