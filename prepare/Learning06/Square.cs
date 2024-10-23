
public class Square : Shape
{
    // Private member variable for the side of the square
    private double _side;

    // Constructor to set color and side
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Override the GetArea method to calculate the area of a square
    public override double GetArea()
    {
        return _side * _side;
    }
}
