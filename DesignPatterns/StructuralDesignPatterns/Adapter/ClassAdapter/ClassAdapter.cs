using System;
using System.Collections.Generic;

namespace DesignPatterns.StructuralDesignPatterns.Adapter.ClassAdapter;

public class ClassAdapterProgram
{
    public static void Client(string[] args)
    {
        string[,] employees = new string[5, 4]
        {
            {"101","John","SE","10000"},
            {"102","Smith","SE","20000"},
            {"103","Dev","SSE","30000"},
            {"104","Pam","SE","40000"},
            {"105","Sara","SSE","50000"}
        };

        ITarget target = new EmployeeAdapter();

        target.ProcessCompanySalary(employees);
    }
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Designation { get; set; }
    public decimal Salary { get; set; }

    public Employee(int id, string name, string designation, decimal salary)
    {
        Id = id;
        Name = name;
        Designation = designation;
        Salary = salary;
    }
}

public class ThirdPartyBillingSystem
{
    public void ProcessSalary(List<Employee> employees)
    {
        employees.ForEach(x => Console.WriteLine($"Rs.{x.Salary} Salary Credited to {x.Name} Account"));
    }
}

public interface ITarget
{
    void ProcessCompanySalary(string[,] employes);
}

public class EmployeeAdapter : ThirdPartyBillingSystem, ITarget
{
    public void ProcessCompanySalary(string[,] employees)
    {
        string? id = null;
        string? name = null;
        string? designation = null;
        string? salary = null;

        List<Employee> employeeList = new();

        for (int i = 0; i < employees.GetLength(0); i++)
        {
            for (int j = 0; j < employees.GetLength(1); j++)
            {
                if (j == 0)
                {
                    id = employees[i, j];
                }
                else if (j == 1)
                {
                    name = employees[i, j];
                }
                else if (j == 2)
                {
                    designation = employees[i, j];
                }
                else
                {
                    salary = employees[i, j];
                }
            }

            employeeList.Add(new Employee(Convert.ToInt32(id), name, designation, Convert.ToDecimal(salary)));
        }

        ProcessSalary(employeeList);
    }
}