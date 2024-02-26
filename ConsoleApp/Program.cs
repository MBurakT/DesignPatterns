// dotnet run --project ConsoleApp/ConsoleApp.csproj
using System;

namespace ConsoleApp;

class Program
{
    static void Run(string[] args)
    {
        Console.WriteLine("Design Patterns");
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