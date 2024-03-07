using System;
using System.Collections.Generic;

namespace DesignPatterns.StructuralDesignPatterns.Flyweight;

public class FlyweightProgram
{
    public static void Client(string[] args)
    {
        for (int i = 0; i < 3; i++)
        {
            Circle circle = (Circle)ShapeFactory.GetShape("circle");
            circle.Draw();
            circle.SetColor("Red");
            circle.Draw();
        }

        Console.WriteLine("\nGreen color Circles ");
        for (int i = 0; i < 3; i++)
        {
            Circle circle = (Circle)ShapeFactory.GetShape("circle");
            circle.Draw();
            circle.SetColor("Green");
            circle.Draw();
        }

        Console.WriteLine("\nBlue color Circles");
        for (int i = 0; i < 3; ++i)
        {
            Circle circle = (Circle)ShapeFactory.GetShape("circle");
            circle.Draw();
            circle.SetColor("Green");
            circle.Draw();
        }

        Console.WriteLine("\nOrange color Circles");
        for (int i = 0; i < 3; ++i)
        {
            Circle circle = (Circle)ShapeFactory.GetShape("circle");
            circle.Draw();
            circle.SetColor("Orange");
            circle.Draw();
        }

        Console.WriteLine("\nBlack color Circles");
        for (int i = 0; i < 3; ++i)
        {
            Circle circle = (Circle)ShapeFactory.GetShape("circle");
            circle.Draw();
            circle.SetColor("Black");
            circle.Draw();
        }
    }
}

public interface IShape // Flyweight
{
    void Draw();
}

public class Circle : IShape
{
    readonly int _xCor;
    readonly int _yCor;
    readonly int _radius;

    public string? Color { get; set; }

    public void SetColor(string color)
    {
        Color = color;
    }

    public void Draw()
    {
        Console.WriteLine($"Circle [Color: {Color}, XCor: {_xCor}, XCor: {_yCor}, Radius: {_radius}]");
    }
}

public class ShapeFactory
{
    static Dictionary<string, IShape> _shapeMap = new();

    public static IShape GetShape(string shapeType)
    {
        IShape? shape = null;

        if (shapeType.Equals("circle", StringComparison.InvariantCultureIgnoreCase))
        {
            if (_shapeMap.TryGetValue("circle", out shape))
            {
            }
            else
            {
                shape = new Circle();
                _shapeMap.Add("circle", shape);
            }
        }

        return shape;
    }
}