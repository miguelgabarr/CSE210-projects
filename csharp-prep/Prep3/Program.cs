using System;
using System.Threading;

class Program
{
    static void Main()
    {
        string keepPlaying = "yes";

        // As long as they say 'yes' we will keep playing
        while (keepPlaying.ToLower() == "yes")
        {
            Random random = new Random();
            int magicNumber = random.Next(1, 101);
            int guess = 0;
            int guessCount = 0;

            while (guess != magicNumber)
            {
                Console.Write("\nWhat is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("The Magic number is higher than your answer.\nTry again.");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("The Magic number is lower than your answer.\nTry again.");
                }
                else
                {
                    Console.WriteLine($@"
            
            W0W
            0 0
            ---

      That is correct!

            \n You guessed the magic number");
                    Thread.Sleep(1000);
                    Console.WriteLine($"\nIt took you {guessCount} guesses");
                }
            }

            Thread.Sleep(1000);
            Console.Write("\nDo you want to keep playing? ");
            keepPlaying = Console.ReadLine();

            if (keepPlaying.ToLower() != "yes")
            {
                Thread.Sleep(500);
                Console.WriteLine(@"
            ----  Game Over  ---- 
         
             Thanks for playing
            ");
            }
        }
    }
}
