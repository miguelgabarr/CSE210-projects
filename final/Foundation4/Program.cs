using System;

// Base class
class Shape
{
    public virtual void Draw()
    {
        Console.WriteLine("Drawing a generic shape");
    }
}

// Derived class 1
class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a circle");
    }
}

// Derived class 2
class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a rectangle");
    }
}

class Program
{
    static void Main()
    {
        // Create instances of the base class and derived classes
        Shape genericShape = new Shape();
        Shape circle = new Circle();
        Shape rectangle = new Rectangle();

        // Call the Draw method on each instance
        Console.WriteLine("Drawing a generic shape:");
        genericShape.Draw();

        Console.WriteLine("\nDrawing a circle:");
        circle.Draw();

        Console.WriteLine("\nDrawing a rectangle:");
        rectangle.Draw();
    }
}
