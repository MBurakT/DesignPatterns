using System;

namespace DesignPatterns.CreationalDesignPatterns.Prototype;

public class PrototypeProgram
{
    public static void Main(string[] args)
    {
        Employee perEmp = new PermanentEmployee()
        {
            Name = "Den",
            Department = "Eme",
            Type = "Permanent",
            Salary = 100000
        };

        Employee perEmpCopy = perEmp.GetClone();

        perEmpCopy.Name = "Timur";
        perEmpCopy.Department = "Emir";

        perEmp.GetDetails();
        perEmpCopy.GetDetails();

        Employee tempEmp = new TemporaryEmployee()
        {
            Name = "Cleopatra",
            Department = "Sales",
            Type = "Temporary",
            FixedAmount = 10000
        };

        Employee tempEmpCopy = tempEmp.GetClone();

        tempEmpCopy.Name = "Tutan";
        tempEmpCopy.Department = "Management";

        tempEmp.GetDetails();
        tempEmpCopy.GetDetails();
    }
}

public abstract class Employee
{
    public string? Name { get; set; }
    public string? Department { get; set; }
    public string? Type { get; set; }

    public abstract Employee GetClone();
    public abstract void GetDetails();
}

public class PermanentEmployee : Employee
{
    public int? Salary { get; set; }

    public override Employee GetClone()
    {
        return (PermanentEmployee)MemberwiseClone();
    }

    public override void GetDetails()
    {
        Console.WriteLine($"{nameof(PermanentEmployee)} {Name} {Department} {Type} {Salary}");
    }
}

public class TemporaryEmployee : Employee
{
    public int? FixedAmount { get; set; }

    public override Employee GetClone()
    {
        return (TemporaryEmployee)MemberwiseClone();
    }

    public override void GetDetails()
    {
        Console.WriteLine($"{nameof(TemporaryEmployee)} {Name} {Department} {Type} {FixedAmount}");
    }
}