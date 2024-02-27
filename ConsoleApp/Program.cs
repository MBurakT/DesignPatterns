// dotnet run --project ConsoleApp/ConsoleApp.csproj
using System;
using DesignPatterns.BehaviorDesignPatterns.Memento;

namespace ConsoleApp;

class Program
{
    static void Run(string[] args)
    {
        Console.WriteLine("Design Patterns");

        MementoProgram.Main(args);
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