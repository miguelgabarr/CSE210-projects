using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class ScriptureReference
{
    public string Reference { get; set; }

    public ScriptureReference(string reference)
    {
        Reference = reference;
    }
}

class ScriptureVerse
{
    public ScriptureReference Reference { get; set; }
    public List<string> Words { get; set; }

    public ScriptureVerse(ScriptureReference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').ToList();
    }

    public bool IsHidden()
    {
        return Words.All(word => word == "---");
    }

    public void HideRandomWord()
    {
        if (Words.Count > 0)
        {
            Random random = new Random();
            int randomIndex = random.Next(0, Words.Count);
            Words[randomIndex] = "---";
        }
    }

    public void Display()
    {
        Console.WriteLine($"{Reference.Reference}: {string.Join(" ", Words)}");
    }
}

class ScriptureMemorizer
{
    private ScriptureVerse verse;

    public ScriptureMemorizer(ScriptureReference reference, string text)
    {
        verse = new ScriptureVerse(reference, text);
    }

    public void Run()
    {
        Console.Clear();
        verse.Display();

        while (!verse.IsHidden())
        {
            Console.WriteLine("Press Enter to continue or type 'quit' to exit: ");
            string userInput = Console.ReadLine().ToLower();

            if (userInput == "quit")
                break;

            verse.HideRandomWord();
            Console.Clear();
            verse.Display();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ScriptureReference reference = new ScriptureReference("John 3:16");
        string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";

        ScriptureMemorizer memorizer = new ScriptureMemorizer(reference, text);
        memorizer.Run();
    }
}
