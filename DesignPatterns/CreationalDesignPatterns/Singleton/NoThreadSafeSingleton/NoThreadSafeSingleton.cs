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
    static int _counter = 0;
    static Singleton? _instance = null;

    public static Singleton GetInstance()
    {
        if (_instance is null) _instance = new Singleton();

        return _instance;
    }

    private Singleton()
    {
        _counter++;
        Console.WriteLine($"Counter: {_counter}");
    }

    public void PrintDetails(string message)
    {
        Console.WriteLine(message);
    }
}