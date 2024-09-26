using System;

public class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "Who am I most grateful for today?",
            "What new skill or knowledge did I gain today?",
            "What is one thing I could improve upon tomorrow?",
            "Who made a positive impact on my day, and why?",
            "What was the most challenging part of my day?",
            "How did I take care of myself today?",
            "What moment brought me the most joy today?",
            "What is one memory I want to keep from today?",
            "What act of kindness did I perform today?",
            "If I could change one decision I made today, what would it be?",
            "If I had one thing I could do over today, what would it be?"
        };

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Random rnd = new Random();
                string prompt = prompts[rnd.Next(prompts.Length)];
                Console.WriteLine(prompt);
                string response = Console.ReadLine();
                string date = DateTime.Now.ToString("MM/dd/yyyy");
                journal.AddEntry(new Entry(date, prompt, response));
            }
            else if (choice == "2")
            {
                journal.DisplayJournal();
            }
            else if (choice == "3")
            {
                Console.WriteLine("Enter the filename to save:");
                string filename = Console.ReadLine();
                journal.SaveJournal(filename);
            }
            else if (choice == "4")
            {
                Console.WriteLine("Enter the filename to load:");
                string filename = Console.ReadLine();

                if (File.Exists(filename))
                {
                    journal.LoadJournal(filename);
                }
                else
                {
                    Console.WriteLine("File not found. Here are the available files:");
                    DisplayExistingFiles();
                }
            }
            else if (choice == "5")
            {
                break;
            }
        }
    }

    static void DisplayExistingFiles()
    {
        string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());

        if (files.Length > 0)
        {
            Console.WriteLine("Existing files:");
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }
        else
        {
            Console.WriteLine("No files available in the current directory.");
        }
    }
}