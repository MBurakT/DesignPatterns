// dotnet run --project ConsoleApp/ConsoleApp.csproj
using System;
using DesignPatterns.CreationalDesignPatterns.Singleton.NoThreadSafeSingleton;
using DesignPatterns.CreationalDesignPatterns.Singleton.ThreadSafeSingleton;
using DesignPatterns.BehaviorDesignPatterns.Memento;

namespace ConsoleApp;

class Program
{
    static void Run(string[] args)
    {
        Console.WriteLine("Design Patterns\n");

        Console.WriteLine("Creational Design Patterns\n");

        Console.WriteLine("Singleton (No Thread-Safe)");
        NoThreadSafeSingletonProgram.Main(args);
        Console.WriteLine("\nSingleton (Thread-Safe)");
        ThreadSafeSingletonProgram.Main(args);

        // Console.WriteLine("Memento");
        // MementoProgram.Main(args);
    }

    static void Main(string[] args)
    {
        try
        {
            Run(args);
            if (Console.ReadLine() == "clear") Console.Clear();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}