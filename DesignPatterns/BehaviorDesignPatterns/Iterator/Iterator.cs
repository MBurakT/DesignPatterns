using System;
using System.Collections.Generic;

namespace DesignPatterns.StructuralDesignPatterns.Iterator;

public class IteratorProgram
{
    public static void Client(string[] args)
    {
        ConcreteCollection collection = new();

        collection.AddEmployee(new Employee(100, "Deneme"));
        collection.AddEmployee(new Employee(101, "Timur"));
        collection.AddEmployee(new Employee(102, "Atilla"));
        collection.AddEmployee(new Employee(103, "Cleopatra"));
        collection.AddEmployee(new Employee(104, "Cengizhan"));
        collection.AddEmployee(new Employee(105, "Oğuz"));

        ConcreteIterator iterator = collection.CreateIterator();

        for (Employee emp = iterator.First(); !iterator.IsCompleted; emp = iterator.Next())
        {
            Console.WriteLine($"Id: {emp.Id}, Name: {emp.Name}");
        }
    }
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

interface IAbstractCollection
{
    ConcreteIterator CreateIterator();
}

class ConcreteCollection : IAbstractCollection
{
    List<Employee> employees = new();

    public int Count { get { return employees.Count; } }

    public ConcreteIterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    public Employee GetEmployee(int index)
    {
        return employees[index];
    }
}

interface IAbstractIterator
{
    bool IsCompleted { get; }

    Employee? First();
    Employee? Next();
}

class ConcreteIterator : IAbstractIterator
{
    ConcreteCollection collection;
    int current = 0;
    readonly int step = 1;

    public bool IsCompleted { get { return current >= collection.Count; } }

    public ConcreteIterator(ConcreteCollection collection)
    {
        this.collection = collection;
    }

    public Employee? First()
    {
        current = 0;
        return collection.GetEmployee(current);
    }

    public Employee? Next()
    {
        current += step;

        if (!IsCompleted)
        {
            return collection.GetEmployee(current);
        }
        else
        {
            return null;
        }
    }
}