using System;
using System.Collections.Generic;

namespace DesignPatterns.StructuralDesignPatterns.Observer;

public class ObserverProgram
{
    public static void Client(string[] args)
    {
        Subject redMi = new("Red MI Mobile", "Out Of Stock", 10000);

        Observer fObserver = new("EmirTimur");
        Observer sObserver = new("OğuzKağan");
        Observer tObserver = new("Napolyon");

        fObserver.AddSubscriber(redMi);
        sObserver.AddSubscriber(redMi);
        tObserver.AddSubscriber(redMi);

        Console.WriteLine($"Red MI Mobile current state: {redMi.GetAvailability()}");

        tObserver.RemoveObserver(redMi);

        redMi.SetAvailability("Available");
    }
}

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObserver();
}

public class Subject : ISubject
{
    List<IObserver> observers = new();
    string _productName;
    string _availability;
    int _productPrice;

    public Subject(string productName, string availability, int productPrice)
    {
        _productName = productName;
        _availability = availability;
        _productPrice = productPrice;
    }

    public string GetAvailability()
    {
        return _availability;
    }

    public void SetAvailability(string availability)
    {
        _availability = availability;
        NotifyObserver();
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObserver()
    {
        System.Console.WriteLine($"Product Name: {_productName}, Product Price: {_productPrice} is Now available. So, notifying all Registered users\n");
        foreach (IObserver observer in observers)
        {
            //By Calling the Update method, we are sending notifications to observers
            observer.Update(_availability);
        }
    }
}

public interface IObserver
{
    void Update(string availability);
}

public class Observer : IObserver
{
    public string Username { get; set; }

    public Observer(string username)
    {
        Username = username;
    }

    public void AddSubscriber(ISubject subject)
    {
        subject.RegisterObserver(this);
    }

    public void RemoveObserver(ISubject subject)
    {
        subject.RemoveObserver(this);
    }

    public void Update(string availability)
    {
        Console.WriteLine($"Hello {Username}, Product is now {availability} on Amazon.");
    }
}