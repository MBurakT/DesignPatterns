// dotnet run --project ConsoleApp/ConsoleApp.csproj
using System;
using DesignPatterns.CreationalDesignPatterns.Singleton.NoThreadSafeSingleton;
using DesignPatterns.CreationalDesignPatterns.Singleton.ThreadSafeSingleton;
using DesignPatterns.CreationalDesignPatterns.FactoryMethod;
using DesignPatterns.CreationalDesignPatterns.AbstractFactory;
using DesignPatterns.CreationalDesignPatterns.Prototype;
using DesignPatterns.CreationalDesignPatterns.Builder;
using DesignPatterns.StructuralDesignPatterns.Adapter.ObjectAdapter;
using DesignPatterns.StructuralDesignPatterns.Adapter.ClassAdapter;
using DesignPatterns.StructuralDesignPatterns.Facade;
using DesignPatterns.StructuralDesignPatterns.Decorator;
using DesignPatterns.StructuralDesignPatterns.Bridge;
using DesignPatterns.StructuralDesignPatterns.Composite;
using DesignPatterns.StructuralDesignPatterns.Proxy;
using DesignPatterns.StructuralDesignPatterns.Flyweight;
using DesignPatterns.StructuralDesignPatterns.Iterator;
using DesignPatterns.StructuralDesignPatterns.Observer;
using DesignPatterns.StructuralDesignPatterns.ChainofResponsibility;
using DesignPatterns.StructuralDesignPatterns.Interpreter;
using DesignPatterns.StructuralDesignPatterns.Command;
using DesignPatterns.BehaviorDesignPatterns.Memento;
using DesignPatterns.StructuralDesignPatterns.Mediator;
using DesignPatterns.StructuralDesignPatterns.State;
using DesignPatterns.StructuralDesignPatterns.TemplateMethod;
using DesignPatterns.StructuralDesignPatterns.Strategy;

namespace ConsoleApp;

class Program
{
    static void Run(string[] args)
    {
        Console.WriteLine("Design Patterns");

        // Console.WriteLine("Creational Design Patterns");
        // Console.WriteLine("Singleton (No Thread-Safe) Design Pattern");
        // NoThreadSafeSingletonProgram.Client(args);
        // Console.WriteLine("\nSingleton (Thread-Safe) Design Pattern");
        // ThreadSafeSingletonProgram.Client(args);
        // Console.WriteLine("\nFactory Method Design Pattern"); Design Pattern
        // FactoryMethodProgram.Client(args);
        // Console.WriteLine("\nAbstract Factory Design Pattern");
        // AbstractFactoryProgram.Client(args);
        // Console.WriteLine("\nPrototype Design Pattern");
        // PrototypeProgram.Client(args);
        // Console.WriteLine("\nBuilder Design Pattern");
        // BuilderProgram.Client(args);

        // Console.WriteLine("Structural Design Patterns");
        // Console.WriteLine("Object Adapter Design Pattern");
        // ObjectAdapterProgram.Client(args);
        // Console.WriteLine("\nClass Adapter Design Pattern");
        // ClassAdapterProgram.Client(args);
        // Console.WriteLine("\nFacade Design Pattern");
        // FacadeProgram.Client(args);
        // Console.WriteLine("\nDecorator Design Pattern");
        // DecoratorProgram.Client(args);
        // Console.WriteLine("\nBridge Design Pattern");
        // BridgeProgram.Client(args);
        // Console.WriteLine("\nComposite Design Pattern");
        // CompositeProgram.Client(args);
        // Console.WriteLine("\nProxy Design Pattern");
        // ProxyProgram.Client(args);
        // Console.WriteLine("\nFlyweight Design Pattern");
        // FlyweightProgram.Client(args);

        Console.WriteLine("Behavior Design Patterns");
        // Console.WriteLine("Iterator Design Pattern");
        // IteratorProgram.Client(args);
        // Console.WriteLine("\nObserver Design Pattern");
        // ObserverProgram.Client(args);
        // Console.WriteLine("\nChainofResponsibility Design Pattern");
        // ChainofResponsibilityProgram.Client(args);
        // Console.WriteLine("\nInterpreter Design Pattern");
        // InterpreterProgram.Client(args);
        // Console.WriteLine("\nCommand Design Pattern");
        // CommandProgram.Client(args);
        // Console.WriteLine("\nMemento Design Pattern");
        // MementoProgram.Client(args);
        // Console.WriteLine("\nMediator Design Pattern");
        // MediatorProgram.Client(args);
        // Console.WriteLine("\nState Design Pattern");
        // StateProgram.Client(args);
        // Console.WriteLine("\nTemplateMethod Design Pattern");
        // TemplateMethodProgram.Client(args);
        Console.WriteLine("\nStrategy Design Pattern");
        StrategyProgram.Client(args);
    }

    static void Main(string[] args)
    {
        try
        {
            Run(args);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n{ex}\n");
        }
        if (Console.ReadLine() == "clear") Console.Clear();
    }
}