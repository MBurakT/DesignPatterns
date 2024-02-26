// dotnet run --project ConsoleApp/ConsoleApp.csproj
using System;
using Classes;
using Interfaces;

namespace ConsoleApp;

class Program
{
    static void Run(string[] args)
    {
        ITaxCalculator taxCalculator = GetCalculator();

        taxCalculator.CalculateTax();
    }

    static ITaxCalculator GetCalculator()
    {
        return new TaxCalculator2024();
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