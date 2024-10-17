using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    class Program
    {
        // Dictionary to log the counts of each activity
        private static Dictionary<string, int> activityLog = new Dictionary<string, int>
        {
            { "Breathing Activity", 0 },
            { "Reflection Activity", 0 },
            { "Listing Activity", 0 }
        };

        static void Main(string[] args)
        {
            MindfulnessActivity activity;
            int choice = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Mindfulness Program!");
                Console.WriteLine("Select an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. View Activity Log");
                Console.WriteLine("0. Exit");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        activity = new BreathingActivity();
                        activityLog["Breathing Activity"]++; // Increment count
                        break;
                    case 2:
                        activity = new ReflectionActivity();
                        activityLog["Reflection Activity"]++; // Increment count
                        break;
                    case 3:
                        activity = new ListingActivity();
                        activityLog["Listing Activity"]++; // Increment count
                        break;
                    case 4:
                        ViewActivityLog(); // View log option
                        continue;
                    default:
                        continue;
                }
                activity.Start();
            } while (choice != 0);
        }

        static void ViewActivityLog()
        {
            Console.Clear();
            Console.WriteLine("Activity Log:");
            foreach (var activity in activityLog)
            {
                Console.WriteLine($"{activity.Key}: {activity.Value} times");
            }
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }

    abstract class MindfulnessActivity
    {
        protected int duration;

        public void Start()
        {
            Console.Clear();
            Console.WriteLine($"Starting {GetActivityName()}...");
            Console.WriteLine(GetDescription());
            Console.Write("Enter duration in seconds: ");
            duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Prepare to begin...");
            Pause(3);

            PerformActivity();
            End();
        }

        protected abstract void PerformActivity();
        protected abstract string GetActivityName();
        protected abstract string GetDescription();

        protected void End()
        {
            Console.WriteLine("Good job! You have completed the activity.");
            Console.WriteLine($"Duration: {duration} seconds.");
            Pause(3);
        }

        protected void Pause(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"\rPausing for {i} seconds... ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        protected void Spinner(int duration)
        {
            Console.Write("Loading");
            for (int i = 0; i < duration; i++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
            Console.WriteLine();
        }
    }

    class BreathingActivity : MindfulnessActivity
    {
        protected override string GetActivityName() => "Breathing Activity";

        protected override string GetDescription() =>
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";

        protected override void PerformActivity()
        {
            for (int i = 0; i < duration; i += 5) // Assuming each breath cycle takes 5 seconds
            {
                Console.WriteLine("Breathe in...");
                Spinner(5);
                Console.WriteLine("Breathe out...");
                Spinner(5);
            }
        }
    }

    class ReflectionActivity : MindfulnessActivity
    {
        private List<string> prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> questions = new List<string>
        {
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

        protected override string GetActivityName() => "Reflection Activity";

        protected override string GetDescription() =>
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        protected override void PerformActivity()
        {
            Random random = new Random();
            Console.WriteLine(prompts[random.Next(prompts.Count)]);
            Spinner(3); // Time to think

            for (int i = 0; i < duration; i += 5) // Assuming each question display takes 5 seconds
            {
                Console.WriteLine(questions[random.Next(questions.Count)]);
                Spinner(5);
            }
        }
    }

    class ListingActivity : MindfulnessActivity
    {
        private List<string> prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        protected override string GetActivityName() => "Listing Activity";

        protected override string GetDescription() =>
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        protected override void PerformActivity()
        {
            Random random = new Random();
            Console.WriteLine(prompts[random.Next(prompts.Count)]);
            Pause(5); // Time to think before listing

            List<string> items = new List<string>();
            Console.WriteLine("Start listing (type 'done' to finish):");

            DateTime startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < duration)
            {
                string item = Console.ReadLine();
                if (item.ToLower() == "done") break;
                items.Add(item);
            }

            Console.WriteLine($"You listed {items.Count} items.");
        }
    }
}
