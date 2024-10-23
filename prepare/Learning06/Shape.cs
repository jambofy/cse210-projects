
public abstract class Shape
{
    // Protected member variable for color
    protected string _color;

    // Constructor to set the color
    public Shape(string color)
    {
        _color = color;
    }

    // Getter for color
    public string GetColor()
    {
        return _color;
    }

    // Abstract method for getting the area (to be overridden)
    public abstract double GetArea();
}
