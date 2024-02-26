// dotnet run --project ConsoleApp/ConsoleApp.csproj
using System;
using Classes;

namespace ConsoleApp;

class Program
{
    static void Run(string[] args)
    {
        TextBox textBox = new();

        textBox.Enable();
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