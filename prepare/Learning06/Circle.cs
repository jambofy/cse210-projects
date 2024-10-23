
using System;

public class Circle : Shape
{
    // Private member variable for the radius of the circle
    private double _radius;

    // Constructor to set color and radius
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Override the GetArea method to calculate the area of a circle
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}
