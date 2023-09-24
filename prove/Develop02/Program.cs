using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        return $"{Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(string prompt, string response)
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        entries.Add(new Entry(prompt, response, date));
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"Date: {entry.Date}");
                writer.WriteLine($"Prompt: {entry.Prompt}");
                writer.WriteLine($"Response: {entry.Response}");
                writer.WriteLine();
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            entries.Clear();

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                string currentPrompt = null;
                string currentDate = null;
                string currentResponse = "";

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Date: "))
                    {
                        currentDate = line.Substring("Date: ".Length);
                    }
                    else if (line.StartsWith("Prompt: "))
                    {
                        currentPrompt = line.Substring("Prompt: ".Length);
                    }
                    else if (line.StartsWith("Response: "))
                    {
                        currentResponse = line.Substring("Response: ".Length);
                    }
                    else if (line.Trim() == "")
                    {
                        if (currentPrompt != null && currentDate != null)
                        {
                            entries.Add(new Entry(currentPrompt, currentResponse, currentDate));
                            currentPrompt = null;
                            currentDate = null;
                            currentResponse = "";
                        }
                    }
                }
            }

            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Console.WriteLine("Welcome to the Journal program!");

        while (true)
        {
            Console.WriteLine("Please select one of the following choices.");
            Console.WriteLine("1. Write\t2. Display\t3. Load\t4. Save\t5. Quit");
            Console.Write("What would you like to do? ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Select a prompt:");
                        for (int i = 0; i < prompts.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {prompts[i]}");
                        }
                        Console.Write("Enter the number of the prompt: ");
                        int promptNumber;
                        if (int.TryParse(Console.ReadLine(), out promptNumber) && promptNumber >= 1 && promptNumber <= prompts.Count)
                        {
                            Console.Write("Enter your response: ");
                            string response = Console.ReadLine();
                            journal.AddEntry(prompts[promptNumber - 1], response);
                            Console.WriteLine("Entry added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid prompt number.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Journal Entries:");
                        journal.DisplayEntries();
                        break;

                    case 3:
                        Console.Write("Enter the filename to load from: ");
                        string loadFileName = Console.ReadLine();
                        journal.LoadFromFile(loadFileName);
                        break;

                    case 4:
                        Console.Write("Enter the filename to save to: ");
                        string saveFileName = Console.ReadLine();
                        journal.SaveToFile(saveFileName);
                        Console.WriteLine("Journal saved successfully.");
                        break;

                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
