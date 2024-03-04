using System;
using System.Collections.Generic;

namespace DesignPatterns.StructuralDesignPatterns.Mediator;

public class MediatorProgram
{
    public static void Client(string[] args)
    {
        IFacebookGroupMediator facebookGrupMediator = new ConcreteFacebookGroupMediator();

        User Emir = new ConcreteUser("Emir");
        User Timur = new ConcreteUser("Timur");
        User Napolyon = new ConcreteUser("Napolyon");
        User Cleopatra = new ConcreteUser("Cleopatra");
        User Den = new ConcreteUser("Den");
        User Eme = new ConcreteUser("Eme");
        User Tutan = new ConcreteUser("Tutan");
        User Gamon = new ConcreteUser("Gamon");

        facebookGrupMediator.RegisterUser(Emir);
        facebookGrupMediator.RegisterUser(Timur);
        facebookGrupMediator.RegisterUser(Napolyon);
        facebookGrupMediator.RegisterUser(Cleopatra);
        facebookGrupMediator.RegisterUser(Den);
        facebookGrupMediator.RegisterUser(Eme);
        facebookGrupMediator.RegisterUser(Tutan);
        facebookGrupMediator.RegisterUser(Gamon);

        Timur.Send("What are the Design Patterns");
        Console.WriteLine();
        Cleopatra.Send("Well, actually...");
    }
}

public interface IFacebookGroupMediator
{
    void SendMessage(string msg, User user);
    void RegisterUser(User user);
}

public class ConcreteFacebookGroupMediator : IFacebookGroupMediator
{
    List<User> _users = new();

    public void RegisterUser(User user)
    {
        _users.Add(user);
        user.Mediator = this;
    }

    public void SendMessage(string message, User user)
    {
        foreach (User u in _users)
        {
            if (u != user) u.Receive(message);
        }
    }
}

public abstract class User
{
    protected string Name;
    public IFacebookGroupMediator Mediator { get; set; }

    public User(string name)
    {
        Name = name;
    }

    public abstract void Send(string message);
    public abstract void Receive(string message);
}

public class ConcreteUser : User
{
    public ConcreteUser(string name) : base(name) { }

    public override void Receive(string message)
    {
        Console.WriteLine($"{Name}: Received Message: {message}");
    }

    public override void Send(string message)
    {
        Console.WriteLine($"{Name}: Sending Message: {message}\n");
        Mediator.SendMessage(message, this);
    }
}