using System;

namespace DesignPatterns.StructuralDesignPatterns.TemplateMethod;

public class TemplateMethodProgram
{
    public static void Client(string[] args)
    {
        Console.WriteLine("Build a Concrete House\n");
        HouseTemplate houseTemplate = new ConcreteHouse();
        houseTemplate.BuildHouse();

        Console.WriteLine("\nBuild a Wooden House\n");
        houseTemplate = new WoodenHouse();
        houseTemplate.BuildHouse();
    }
}

public abstract class HouseTemplate
{
    public void BuildHouse()
    {
        BuildFoundation();
        BuildPillars();
        BuildWalls();
        BuildWindows();
        Console.WriteLine("House is Built");
    }

    protected abstract void BuildFoundation();
    protected abstract void BuildPillars();
    protected abstract void BuildWalls();
    protected abstract void BuildWindows();
}

public class ConcreteHouse : HouseTemplate
{
    protected override void BuildFoundation()
    {
        Console.WriteLine("Building foundation with cement, iron rods and sand");
    }
    protected override void BuildPillars()
    {
        Console.WriteLine("Building Concrete Pillars with Cement and Sand");
    }
    protected override void BuildWalls()
    {
        Console.WriteLine("Building Concrete Walls");
    }
    protected override void BuildWindows()
    {
        Console.WriteLine("Building Concrete Windows");
    }
}

public class WoodenHouse : HouseTemplate
{
    protected override void BuildFoundation()
    {
        Console.WriteLine("Building foundation with cement, iron rods, wood and sand");
    }
    protected override void BuildPillars()
    {
        Console.WriteLine("Building wood Pillars with wood coating");
    }
    protected override void BuildWalls()
    {
        Console.WriteLine("Building Wood Walls");
    }
    protected override void BuildWindows()
    {
        Console.WriteLine("Building Wood Windows");
    }
}