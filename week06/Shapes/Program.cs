using System;

class Program
{
    static void Main(string[] args)
    {

        List<Shape> shapes = new List<Shape>();

        Square square = new Square(5);
        square.SetColor("Red");
        shapes.Add(square);

        Retangle retangle = new Retangle(5, 20);
        retangle.SetColor("Pink");
        shapes.Add(retangle);

        Circle circle = new Circle(10);
        circle.SetColor("Green");
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The {shape.GetColor()} shape has an area of {shape.GetArea()}");
        }
    }
}