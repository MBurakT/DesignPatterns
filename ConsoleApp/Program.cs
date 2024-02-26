// dotnet run --project ConsoleApp/ConsoleApp.csproj
using System;
using Classes;
using Interfaces;

namespace ConsoleApp;

class Program
{
    static void Run(string[] args)
    {
        Account account = new();

        account.Deposit(10);
        account.Withdraw(5);

        Console.WriteLine($"Balance: {account.GetBalance().ToString("f2")}");
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