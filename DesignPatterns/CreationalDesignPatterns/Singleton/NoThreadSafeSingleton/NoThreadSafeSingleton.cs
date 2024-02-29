using System;

namespace DesignPatterns.CreationalDesignPatterns.Singleton.NoThreadSafeSingleton;

public class NoThreadSafeSingletonProgram
{
    public static void Client(string[] args)
    {
        Singleton one = Singleton.GetInstance();
        one.PrintDetails("One");

        Singleton two = Singleton.GetInstance();
        two.PrintDetails("Two");
    }
}

public sealed class Singleton
{
    private static int Counter = 0;
    private static Singleton? Instance = null;

    public static Singleton GetInstance()
    {
        if (Instance is null) Instance = new Singleton();

        return Instance;
    }

    private Singleton()
    {
        Counter++;
        Console.WriteLine($"Counter: {Counter}");
    }

    public void PrintDetails(string message)
    {
        Console.WriteLine(message);
    }
}