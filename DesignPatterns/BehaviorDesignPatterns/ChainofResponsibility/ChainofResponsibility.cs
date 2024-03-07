using System;

namespace DesignPatterns.StructuralDesignPatterns.ChainofResponsibility;

public class ChainofResponsibilityProgram
{
    public static void Client(string[] args)
    {
        ATM atm = new();

        Console.WriteLine("Requested Amount 4600");
        atm.Withdraw(4600);
        Console.WriteLine("Requested Amount 1900");
        atm.Withdraw(1900);
        Console.WriteLine("Requested Amount 600");
        atm.Withdraw(600);
        Console.WriteLine("Requested Amount 750");
        atm.Withdraw(750);
    }
}

public abstract class Handler
{
    public Handler NextHandler;

    public void SetNextHandler(Handler nextHandler)
    {
        NextHandler = nextHandler;
    }

    public abstract void DispatchNote(long requestedAmount);
}

public class TwoThousandHandler : Handler
{
    public override void DispatchNote(long requestedAmount)
    {
        long numberofNotesToBeDispatched = requestedAmount / 2000;

        if (numberofNotesToBeDispatched > 0)
        {
            if (numberofNotesToBeDispatched > 1)
            {
                Console.WriteLine($"{numberofNotesToBeDispatched} Two Thousand notes are dispatched by TwoThousandHandler");
            }
            else
            {
                Console.WriteLine($"{numberofNotesToBeDispatched} Two Thousand note is dispatched by TwoThousandHandler");
            }
        }

        long pendingAmountToBeProcessed = requestedAmount % 2000;

        if (pendingAmountToBeProcessed > 0)
        {
            NextHandler.DispatchNote(pendingAmountToBeProcessed);
        }
    }
}

public class FiveHundredHandler : Handler
{
    public override void DispatchNote(long requestedAmount)
    {
        long numberofNotesToBeDispatched = requestedAmount / 500;

        if (numberofNotesToBeDispatched > 0)
        {
            if (numberofNotesToBeDispatched > 1)
            {
                Console.WriteLine($"{numberofNotesToBeDispatched} Five Hundred notes are dispatched by FiveHundredHandler");
            }
            else
            {
                Console.WriteLine($"{numberofNotesToBeDispatched} Five Hundred note is dispatched by FiveHundredHandler");
            }
        }

        long pendingAmountToBeProcessed = requestedAmount % 500;

        if (pendingAmountToBeProcessed > 0)
        {
            NextHandler.DispatchNote(pendingAmountToBeProcessed);
        }
    }
}

public class TwoHundredHandler : Handler
{
    public override void DispatchNote(long requestedAmount)
    {
        long numberofNotesToBeDispatched = requestedAmount / 200;

        if (numberofNotesToBeDispatched > 0)
        {
            if (numberofNotesToBeDispatched > 1)
            {
                Console.WriteLine($"{numberofNotesToBeDispatched} Two Hundred notes are dispatched by TwoHundredHandler");
            }
            else
            {
                Console.WriteLine($"{numberofNotesToBeDispatched} Two Hundred note is dispatched by TwoHundredHandler");
            }
        }

        long pendingAmountToBeProcessed = requestedAmount % 200;

        if (pendingAmountToBeProcessed > 0)
        {
            NextHandler.DispatchNote(pendingAmountToBeProcessed);
        }
    }
}

public class HundredHandler : Handler
{
    public override void DispatchNote(long requestedAmount)
    {
        long numberofNotesToBeDispatched = requestedAmount / 100;

        if (numberofNotesToBeDispatched > 0)
        {
            if (numberofNotesToBeDispatched > 1)
            {
                Console.WriteLine($"{numberofNotesToBeDispatched} Hundred notes are dispatched by HundredHandler");
            }
            else
            {
                Console.WriteLine($"{numberofNotesToBeDispatched} Hundred note is dispatched by HundredHandler");
            }
        }

        long pendingAmountToBeProcessed = requestedAmount % 100;

        if (pendingAmountToBeProcessed > 0)
        {
            NextHandler.DispatchNote(pendingAmountToBeProcessed);
        }
    }
}

public class ATM
{
    TwoThousandHandler _twoThousandHandler = new();
    FiveHundredHandler _fiveHundredHandler = new();
    TwoHundredHandler _twoHundredHandler = new();
    HundredHandler _hundredHandler = new();

    public ATM()
    {
        _twoThousandHandler.SetNextHandler(_fiveHundredHandler);
        _fiveHundredHandler.SetNextHandler(_twoHundredHandler);
        _twoHundredHandler.SetNextHandler(_hundredHandler);
    }

    public void Withdraw(long requestedAmount)
    {
        if (requestedAmount % 100 == 0)
        {
            _twoThousandHandler.DispatchNote(requestedAmount);
        }
        else
        {
            Console.WriteLine($"Invalid Amount: {requestedAmount}");
        }
    }
}