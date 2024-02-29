// dotnet run --project ConsoleApp/ConsoleApp.csproj
using System;
using DesignPatterns.CreationalDesignPatterns.Singleton.NoThreadSafeSingleton;
using DesignPatterns.CreationalDesignPatterns.Singleton.ThreadSafeSingleton;
using DesignPatterns.CreationalDesignPatterns.FactoryMethod;
using DesignPatterns.CreationalDesignPatterns.AbstractFactory;
using DesignPatterns.CreationalDesignPatterns.Prototype;
using DesignPatterns.CreationalDesignPatterns.Builder;
using DesignPatterns.StructuralDesignPatterns.Adapter.ObjectAdapter;
using DesignPatterns.StructuralDesignPatterns.Adapter.ClassAdapter;
using DesignPatterns.BehaviorDesignPatterns.Memento;

namespace ConsoleApp;

class Program
{
    static void Run(string[] args)
    {
        Console.WriteLine("Design Patterns");

        // Console.WriteLine("Creational Design Patterns");
        // Console.WriteLine("Singleton (No Thread-Safe)");
        // NoThreadSafeSingletonProgram.Client(args);
        // Console.WriteLine("\nSingleton (Thread-Safe)");
        // ThreadSafeSingletonProgram.Client(args);
        // Console.WriteLine("\nFactory Method");
        // FactoryMethodProgram.Client(args);
        // Console.WriteLine("\nAbstract Factory");
        // AbstractFactoryProgram.Client(args);
        // Console.WriteLine("\nPrototype");
        // PrototypeProgram.Client(args);
        // Console.WriteLine("\nBuilder");
        // BuilderProgram.Client(args);

        Console.WriteLine("Structural Design Patterns");
        Console.WriteLine("Object Adapter");
        ObjectAdapterProgram.Client(args);
        Console.WriteLine("\nClass Adapter");
        ClassAdapterProgram.Client(args);

        // Console.WriteLine("Memento");
        // MementoProgram.Client(args);
    }

    static void Main(string[] args)
    {
        try
        {
            Run(args);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n{ex}\n");
        }
        if (Console.ReadLine() == "clear") Console.Clear();
    }
}