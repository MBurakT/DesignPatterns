// dotnet run --project DesignPatterns/DesignPatterns.csproj
using System;
using Classes;

namespace DesignPatterns;

class Program
{
    static void Run(string[] args)
    {
        User user = new("Denem");
        user.SayHello();
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
