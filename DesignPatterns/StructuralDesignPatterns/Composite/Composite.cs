using System;
using System.Collections.Generic;

namespace DesignPatterns.StructuralDesignPatterns.Composite;

public class CompositeProgram
{
    public static void Client(string[] args)
    {
        IComponent hardDisk = new Leaf("Hard Disk", 2000);
        IComponent ram = new Leaf("RAM", 3000);
        IComponent cpu = new Leaf("CPU", 2000);
        IComponent mouse = new Leaf("Mouse", 2000);
        IComponent keyboard = new Leaf("Keyboard", 2000);

        Composite motherBoard = new Composite("MotherBoard");
        Composite cabinet = new Composite("Cabinet");
        Composite peripherals = new Composite("Peripherals");
        Composite computer = new Composite("Computer");

        motherBoard.AddComponent(cpu);
        motherBoard.AddComponent(ram);
        cabinet.AddComponent(motherBoard);
        cabinet.AddComponent(hardDisk);
        peripherals.AddComponent(mouse);
        peripherals.AddComponent(keyboard);
        computer.AddComponent(cabinet);
        computer.AddComponent(peripherals);

        computer.DisplayPrice();
        Console.WriteLine("\t---------");
        keyboard.DisplayPrice();
        Console.WriteLine("\t---------");
        cabinet.DisplayPrice();
    }
}

public interface IComponent
{
    void DisplayPrice();
}

public class Leaf : IComponent
{
    public string Name { get; set; }
    public int Price { get; set; }

    public Leaf(string name, int price)
    {
        Price = price;
        Name = name;
    }

    public void DisplayPrice()
    {
        Console.WriteLine($"\tComponent Name: {Name}, Component Price: {Price}");
    }
}

public class Composite : IComponent
{
    List<IComponent> _components = new();
    
    public string Name { get; set; }

    public Composite(string name)
    {
        Name = name;
    }

    public void AddComponent(IComponent component)
    {
        _components.Add(component);
    }

    public void DisplayPrice()
    {
        _components.ForEach(x => x.DisplayPrice());
    }
}