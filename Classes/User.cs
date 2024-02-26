using System;

namespace Classes;

public class User
{
    public string name;

    public User(string name)
    {
        this.name = name;
    }

    public void SayHello()
    {
        Console.WriteLine($"Hello, my name is {name}");
    }
}