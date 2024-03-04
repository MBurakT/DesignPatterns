using System;
using System.Collections.Generic;

namespace DesignPatterns.StructuralDesignPatterns.Interpreter;

public class InterpreterProgram
{
    public static void Client(string[] args)
    {
        List<IExpression> expressions = new();

        Context context = new(DateTime.Now);

        context.Expression = "YYYY MM DD";

        string[] exps = context.Expression.Split(' ');

        foreach (string exp in exps)
        {
            if (exp.Equals("DD"))
            {
                expressions.Add(new DayExpression());
            }
            else if (exp.Equals("MM"))
            {
                expressions.Add(new MonthExpression());
            }
            else if (exp.Equals("YYYY"))
            {
                expressions.Add(new YearExpression());
            }
        }

        foreach (var expression in expressions)
        {
            expression.Evaluate(context);
        }

        Console.WriteLine(context.Expression);
    }
}

public class Context
{
    public string Expression { get; set; }
    public DateTime Date { get; set; }

    public Context(DateTime date)
    {
        Date = date;
    }
}

public interface IExpression
{
    void Evaluate(Context context);
}

public class DayExpression : IExpression
{
    public void Evaluate(Context context)
    {
        string expression = context.Expression;
        context.Expression = expression.Replace("DD", context.Date.Day.ToString());
    }
}

public class MonthExpression : IExpression
{
    public void Evaluate(Context context)
    {
        string expression = context.Expression;
        context.Expression = expression.Replace("MM", context.Date.Month.ToString());
    }
}

public class YearExpression : IExpression
{
    public void Evaluate(Context context)
    {
        string expression = context.Expression;
        context.Expression = expression.Replace("YYYY", context.Date.Year.ToString());
    }
}

public class SeparatorExpression : IExpression
{
    public void Evaluate(Context context)
    {
        string expression = context.Expression;
        context.Expression = expression.Replace(" ", "-");
    }
}