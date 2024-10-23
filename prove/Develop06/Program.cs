using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    protected string _goalName;
    protected int _points;
    protected bool _isCompleted;

    public Goal(string goalName, int points)
    {
        _goalName = goalName;
        _points = points;
        _isCompleted = false;
    }

    public abstract void DisplayGoal();
    public abstract int MarkAsComplete();

    public string GetGoalName() => _goalName;
    public int GetPoints() => _points;

    public virtual void Save(StreamWriter writer)
    {
        writer.WriteLine($"{GetType().Name}|{_goalName}|{_points}|{_isCompleted}");
    }

    public virtual void Load(string[] data)
    {
        _goalName = data[1];
        _points = int.Parse(data[2]);
        _isCompleted = bool.Parse(data[3]);
    }
}

class SimpleGoal : Goal
{
    public SimpleGoal(string goalName, int points) : base(goalName, points) { }

    public override void DisplayGoal()
    {
        Console.WriteLine($"{_goalName} [Simple] - {(_isCompleted ? "Completed" : "Incomplete")} ({_points} points)");
    }

    public override int MarkAsComplete()
    {
        if (!_isCompleted)
        {
            _isCompleted = true;
            return _points;
        }
        return 0; // No points if already completed
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string goalName, int points) : base(goalName, points) { }

    public override void DisplayGoal()
    {
        Console.WriteLine($"{_goalName} [Eternal] - Never completed, earn {_points} points each time");
    }

    public override int MarkAsComplete()
    {
        // Eternal goals never get "completed"
        return _points;
    }
}

class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _requiredTimes;
    private int _bonus;

    public ChecklistGoal(string goalName, int points, int requiredTimes, int bonus) : base(goalName, points)
    {
        _timesCompleted = 0;
        _requiredTimes = requiredTimes;
        _bonus = bonus;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"{_goalName} [Checklist] - Completed {_timesCompleted}/{_requiredTimes} times");
    }

    public override int MarkAsComplete()
    {
        if (_timesCompleted < _requiredTimes)
        {
            _timesCompleted++;
            if (_timesCompleted == _requiredTimes)
            {
                _isCompleted = true;
                return _points + _bonus; // Bonus when fully completed
            }
            return _points;
        }
        return 0; // No points if already fully completed
    }

    public override void Save(StreamWriter writer)
    {
        base.Save(writer);
        writer.WriteLine($"{_timesCompleted}|{_requiredTimes}|{_bonus}");
    }

    public override void Load(string[] data)
    {
        base.Load(data);
        _timesCompleted = int.Parse(data[4]);
        _requiredTimes = int.Parse(data[5]);
        _bonus = int.Parse(data[6]);
    }
}

class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int totalPoints = 0;

    static void Main(string[] args)
    {
        LoadGoals();

        bool quit = false;
        while (!quit)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Complete a goal");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Quit");

            Console.Write("\nChoose an option: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoals();
                    break;
                case 3:
                    CompleteGoal();
                    break;
                case 4:
                    SaveGoals();
                    break;
                case 5:
                    LoadGoals();
                    break;
                case 6:
                    quit = true;
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("\nChoose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter points for the goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                goals.Add(new SimpleGoal(name, points));
                break;
            case 2:
                goals.Add(new EternalGoal(name, points));
                break;
            case 3:
                Console.Write("Enter number of times required to complete: ");
                int requiredTimes = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus for completing the goal: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, points, requiredTimes, bonus));
                break;
        }
    }

    static void ListGoals()
    {
        Console.WriteLine("\nYour goals:");
        foreach (var goal in goals)
        {
            goal.DisplayGoal();
        }
    }

    static void CompleteGoal()
    {
        Console.WriteLine("\nEnter goal number to mark as completed: ");
        int goalNumber = int.Parse(Console.ReadLine());

        if (goalNumber >= 1 && goalNumber <= goals.Count)
        {
            totalPoints += goals[goalNumber - 1].MarkAsComplete();
            Console.WriteLine($"Total points: {totalPoints}");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(totalPoints); // Save total points first
            foreach (var goal in goals)
            {
                goal.Save(writer);
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                totalPoints = int.Parse(reader.ReadLine());
                goals.Clear(); // Clear existing goals before loading

                while (!reader.EndOfStream)
                {
                    string[] goalData = reader.ReadLine().Split('|');
                    string goalType = goalData[0];

                    if (goalType == nameof(SimpleGoal))
                    {
                        var goal = new SimpleGoal("", 0);
                        goal.Load(goalData);
                        goals.Add(goal);
                    }
                    else if (goalType == nameof(EternalGoal))
                    {
                        var goal = new EternalGoal("", 0);
                        goal.Load(goalData);
                        goals.Add(goal);
                    }
                    else if (goalType == nameof(ChecklistGoal))
                    {
                        var goal = new ChecklistGoal("", 0, 0, 0);
                        goal.Load(goalData);
                        goals.Add(goal);
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }
}
