using System;

namespace DesignPatterns.StructuralDesignPatterns.Proxy;

public class ProxyProgram
{
    public static void Client(string[] args)
    {
        Employee firstEmp = new Employee("Den Eme", "deneme123", "Developer");
        Employee secondEmp = new Employee("Emir Timur", "emirtimur123", "Manager");

        SharedFolderProxy firstSharedFolderProxy = new(firstEmp);
        SharedFolderProxy secondSharedFolderProxy = new(secondEmp);

        firstSharedFolderProxy.PerformReadWriteOperations();
        Console.WriteLine("----------");
        secondSharedFolderProxy.PerformReadWriteOperations();
    }
}

public class Employee
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }

    public Employee(string username, string password, string role)
    {
        Username = username;
        Password = password;
        Role = role;
    }
}

public interface ISharedFolder
{
    void PerformReadWriteOperations();
}

public class SharedFolder : ISharedFolder
{
    public void PerformReadWriteOperations()
    {
        Console.WriteLine("Performing Read Write operation on the Shared Folder");
    }
}

class SharedFolderProxy : ISharedFolder
{
    ISharedFolder sharedFolder;
    Employee employee;

    public SharedFolderProxy(Employee employee)
    {
        this.employee = employee;
    }

    public void PerformReadWriteOperations()
    {
        if (employee.Role.ToUpper().Equals("CEO") || employee.Role.ToUpper().Equals("MANAGER"))
        {
            sharedFolder = new SharedFolder();
            sharedFolder.PerformReadWriteOperations();
        }
        else
        {
            Console.WriteLine("You don't have permission to access this folder!");
        }
    }
}