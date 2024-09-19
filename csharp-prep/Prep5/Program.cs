using System;

class Program
{

    static void Main(string[] args)
    {
         {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);
        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        while (true)
        {
            Console.Write("What is your favorite number? ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                return number;
            }
            Console.WriteLine("Invalid input. Please enter a whole number.");
        }
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"Hello, {userName}! The square of your favorite number is {squaredNumber}.");
    }
       
    }
}