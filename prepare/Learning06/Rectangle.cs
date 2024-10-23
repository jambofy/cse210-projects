
public class Rectangle : Shape
{
    // Private member variables for the sides of the rectangle
    private double _length;
    private double _width;

    // Constructor to set color, length, and width
    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }

    // Override the GetArea method to calculate the area of a rectangle
    public override double GetArea()
    {
        return _length * _width;
    }
}
