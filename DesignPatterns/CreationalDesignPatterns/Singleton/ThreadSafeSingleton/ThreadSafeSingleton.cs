using System;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalDesignPatterns.Singleton.ThreadSafeSingleton;

public class ThreadSafeSingletonProgram
{
    public static void Main(string[] args)
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
    private static int Counter = 0;
    private static Singleton? Instance = null;
    private static readonly object Instancelock = new object();

    public static Singleton GetInstance()
    {
        if (Instance == null)
        {
            lock (Instancelock)
            {
                if (Instance == null)
                {
                    Instance = new Singleton();
                }
            }
        }

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