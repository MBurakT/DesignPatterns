using System;
using System.Collections.Generic;

namespace DesignPatterns.StructuralDesignPatterns.Visitor;

public class VisitorProgram
{
    public static void Client(string[] args)
    {
        School school = new();

        IVisitor fVisitor = new Doctor("Den");
        IVisitor sVisitor = new Salesman("Eme");

        school.PerformOperation(fVisitor);
        Console.WriteLine();
        school.PerformOperation(sVisitor);
    }
}

public interface IElement
{
    void Accept(IVisitor visitor);
}

public class Kid : IElement
{
    public string Name { get; set; }

    public Kid(string name)
    {
        Name = name;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public interface IVisitor
{
    void Visit(IElement element);
}

public class Doctor : IVisitor
{
    public string Name { get; set; }

    public Doctor(string name)
    {
        Name = name;
    }

    public void Visit(IElement element)
    {
        Kid kid = (Kid)element;
        Console.WriteLine($"Doctor: {Name} did the health checkup of the child: {kid.Name}");
    }
}

class Salesman : IVisitor
{

    public string Name { get; set; }

    public Salesman(string name)
    {
        Name = name;
    }

    public void Visit(IElement element)
    {
        Kid kid = (Kid)element;
        Console.WriteLine($"Salesman: {Name} give a school bag to the child: {kid.Name}");
    }
}

public class School
{
    static readonly List<IElement> Elements = new();
    static School()
    {
        Elements = new List<IElement>
        {
            new Kid("Data"),
            new Kid("Lore"),
            new Kid("Picard")
        };
    }

    public void PerformOperation(IVisitor visitor)
    {
        foreach (var kid in Elements)
        {
            kid.Accept(visitor);
        }
    }
}