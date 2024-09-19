using System;

class Program
{
    static void Main(string[] args)
    {
        
        bool playAgain = true;
        Random random = new Random();

        while (playAgain)
        {
            int magicNumber = random.Next(1, 101);
            int guesses = 0;

            Console.WriteLine("Welcome to Guess My Number game!");

            while (true)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();
                int guess;

                {
                    guesses++;
                    if (guess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (guess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine("You guessed it!");
                        Console.WriteLine($"It took you {guesses} guesses.");
                        break;
                    }
                }
               
            }

            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();

            playAgain = response == "yes";
        }
    }
}