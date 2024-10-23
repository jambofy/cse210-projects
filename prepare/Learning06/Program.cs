
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of Shape objects
        List<Shape> shapes = new List<Shape>();

        
        shapes.Add(new Square("Red", 4));
        shapes.Add(new Rectangle("Blue", 5, 6));
        shapes.Add(new Circle("Green", 3));

        // Iterating through the list and display the color and area of each shape
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}");
            Console.WriteLine($"Shape Area: {shape.GetArea():F2}");
            Console.WriteLine();
        }
    }
}
