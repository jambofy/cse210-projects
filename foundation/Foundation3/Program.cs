using System;
using System.Collections.Generic;

// Base class
public abstract class Activity
{
    private DateTime _date;
    private int _length; // length in minutes

    public Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }

    public DateTime Date => _date;

    public int Length => _length;

    // Abstract methods to be overridden in derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {GetType().Name} ({Length} min) - Distance: {GetDistance():F1}, Speed: {GetSpeed():F1}, Pace: {GetPace():F1} min per {GetPaceUnit()}";
    }

    protected virtual string GetPaceUnit()
    {
        return "mile";
    }
}

// Derived class for Running
public class Running : Activity
{
    private double _distance; // distance in miles

    public Running(DateTime date, int length, double distance) : base(date, length)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => (GetDistance() / Length) * 60; // Speed in mph

    public override double GetPace() => Length / GetDistance(); // Pace in min per mile
}

// Derived class for Cycling
public class Cycling : Activity
{
    private double _speed; // speed in mph

    public Cycling(DateTime date, int length, double speed) : base(date, length)
    {
        _speed = speed;
    }

    public override double GetDistance() => (GetSpeed() * Length) / 60; // Distance in miles

    public override double GetSpeed() => _speed; // Speed in mph

    public override double GetPace() => 60 / GetSpeed(); // Pace in min per mile
}

// Derived class for Swimming
public class Swimming : Activity
{
    private int _laps; // number of laps

    public Swimming(DateTime date, int length, int laps) : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50 / 1000.0 * 0.62; // Distance in miles

    public override double GetSpeed() => (GetDistance() / Length) * 60; // Speed in mph

    public override double GetPace() => Length / GetDistance(); // Pace in min per mile

    protected override string GetPaceUnit()
    {
        return "mile"; // For swimming, it's still calculated per mile
    }
}

// Program to demonstrate functionality
class Program
{
    static void Main(string[] args)
    {
        // Create a list of activities
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 4), 45, 12.0),
            new Swimming(new DateTime(2022, 11, 5), 30, 20)
        };

        // Display summaries for each activity
        foreach (Activity activity in activities)
        {   
            Console.WriteLine();
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
          
        }
    }
}
