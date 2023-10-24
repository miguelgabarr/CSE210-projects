using System;

class Shape
{
    // Common attributes
    protected double width;
    protected double height;

    // Common behavior for setting dimensions
    public virtual void SetDimensions(double w, double h)
    {
        width = w;
        height = h;
    }

    // Common behavior for calculating area
    public virtual double Area()
    {
        return 0;
    }
}

class Circle : Shape
{
    public double Radius { get; set; }

    // Override SetDimensions to set radius for a circle
    public override void SetDimensions(double r)
    {
        Radius = r;
    }

    // Override Area to calculate area for a circle
    public override double Area()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}

class Rectangle : Shape
{
    // Override SetDimensions to set width and height for a rectangle
    public override void SetDimensions(double w, double h)
    {
        Width = w;
        Height = h;
    }

    // Override Area to calculate area for a rectangle
    public override double Area()
    {
        return Width * Height;
    }

    // Additional property specific to Rectangle
    public double Width { get; set; }
    public double Height { get; set; }
}

class Program
{
    static void Main()
    {
        // Create instances of Circle and Rectangle
        Circle circle = new Circle();
        Rectangle rectangle = new Rectangle();

        // Set dimensions for Circle
        circle.SetDimensions(5.0);

        // Set dimensions for Rectangle
        rectangle.SetDimensions(4.0, 6.0);

        // Display areas
        Console.WriteLine($"Area of Circle: {circle.Area()}");
        Console.WriteLine($"Area of Rectangle: {rectangle.Area()}");
    }
}
