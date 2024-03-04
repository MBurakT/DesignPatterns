using System;

namespace DesignPatterns.StructuralDesignPatterns.State;

public class StateProgram
{
    public static void Client(string[] args)
    {
        ATMMachine atmMachine = new ATMMachine();

        Console.WriteLine($"ATM Machine Current state: {atmMachine.AtmMachineState.GetType().Name}\n");
        atmMachine.EnterPin();
        atmMachine.WithdrawMoney();
        atmMachine.EjectDebitCard();
        atmMachine.InsertDebitCard();

        Console.WriteLine();

        Console.WriteLine($"ATM Machine Current state: {atmMachine.AtmMachineState.GetType().Name}\n");
        atmMachine.EnterPin();
        atmMachine.WithdrawMoney();
        atmMachine.InsertDebitCard();
        atmMachine.EjectDebitCard();

        Console.WriteLine($"\nATM Machine Current state: {atmMachine.AtmMachineState.GetType().Name}");
    }
}

public interface IATMState
{
    void InsertDebitCard();
    void EjectDebitCard();
    void EnterPin();
    void WithdrawMoney();
}

public class DebitCardNotInsertedState : IATMState
{
    public void InsertDebitCard()
    {
        Console.WriteLine("DebitCard Inserted");
    }
    public void EjectDebitCard()
    {
        Console.WriteLine("You cannot eject the Debit CardNo, as no Debit Card in ATM Machine slot");
    }
    public void EnterPin()
    {
        Console.WriteLine("you cannot enter the pin, as No Debit Card in ATM Machine slot");
    }
    public void WithdrawMoney()
    {
        Console.WriteLine("you cannot withdraw money, as No Debit Card in ATM Machine slot");
    }
}

public class DebitCardInsertedState : IATMState
{
    public void InsertDebitCard()
    {
        Console.WriteLine("You cannot insert the Debit Card, as the Debit card is already there ");
    }
    public void EjectDebitCard()
    {
        Console.WriteLine("Debit Card is ejected");
    }
    public void EnterPin()
    {
        Console.WriteLine("Pin number has been entered correctly");
    }
    public void WithdrawMoney()
    {
        Console.WriteLine("Money has been withdrawn");
    }
}

public class ATMMachine : IATMState
{
    public IATMState AtmMachineState;

    public ATMMachine()
    {
        AtmMachineState = new DebitCardNotInsertedState();
    }

    public void InsertDebitCard()
    {
        AtmMachineState.InsertDebitCard();

        if (AtmMachineState is DebitCardNotInsertedState)
        {
            AtmMachineState = new DebitCardInsertedState();
            Console.WriteLine($"ATM Machine internal state has been changed to : {AtmMachineState.GetType().Name}");
        }
    }

    public void EjectDebitCard()
    {
        AtmMachineState.EjectDebitCard();

        if (AtmMachineState is DebitCardInsertedState)
        {
            AtmMachineState = new DebitCardNotInsertedState();
            Console.WriteLine($"ATM Machine internal state has been Changed to : {AtmMachineState.GetType().Name}");
        }
    }

    public void EnterPin()
    {
        AtmMachineState.EnterPin();
    }

    public void WithdrawMoney()
    {
        AtmMachineState.WithdrawMoney();
    }
}