using System;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalDesignPatterns.Singleton.ThreadSafeSingleton;

public class ThreadSafeSingletonProgram
{
    public static void Client(string[] args)
    {
        Parallel.Invoke(
            () => PrintTeacherDetails(),
            () => PrintStudentDetails()
        );
    }
    private static void PrintTeacherDetails()
    {
        Singleton fromTeacher = Singleton.GetInstance();
        fromTeacher.PrintDetails("One");
    }
    private static void PrintStudentDetails()
    {
        Singleton fromStudent = Singleton.GetInstance();
        fromStudent.PrintDetails("Two");
    }
}

public sealed class Singleton
{
    static int _counter = 0;
    static Singleton? _instance = null;
    static readonly object _instancelock = new object();

    public static Singleton GetInstance()
    {
        if (_instance == null)
        {
            lock (_instancelock)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
            }
        }

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