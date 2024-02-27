using System;

namespace DesignPatterns.CreationalDesignPatterns.Singleton.FactoryMethod;

public class FactoryMethodProgram
{
    public static void Main(string[] args)
    {
        ICreditCard creditCard = new PlatinumFactory().CreateProduct();

        if (creditCard != null)
        {
            Console.WriteLine("Card Type : " + creditCard.GetCardType());
            Console.WriteLine("Credit Limit : " + creditCard.GetCreditLimit());
            Console.WriteLine("Annual Charge :" + creditCard.GetAnnualCharge());
        }
        else
        {
            Console.Write("Invalid Card Type");
        }

        Console.WriteLine("--------------");
        
        creditCard = new MoneyBackFactory().CreateProduct();
        if (creditCard != null)
        {
            Console.WriteLine("Card Type : " + creditCard.GetCardType());
            Console.WriteLine("Credit Limit : " + creditCard.GetCreditLimit());
            Console.WriteLine("Annual Charge :" + creditCard.GetAnnualCharge());
        }
        else
        {
            Console.Write("Invalid Card Type");
        }
    }
}

public interface ICreditCard
{
    string GetCardType();
    int GetCreditLimit();
    int GetAnnualCharge();
}

public class MoneyBack : ICreditCard
{
    public string GetCardType()
    {
        return "MoneyBack";
    }

    public int GetCreditLimit()
    {
        return 15000;
    }

    public int GetAnnualCharge()
    {
        return 500;
    }
}

public class Platinum : ICreditCard
{
    public string GetCardType()
    {
        return "Platinum";
    }

    public int GetCreditLimit()
    {
        return 35000;
    }

    public int GetAnnualCharge()
    {
        return 2000;
    }
}

public class Titanium : ICreditCard
{
    public string GetCardType()
    {
        return "Titanium";
    }

    public int GetCreditLimit()
    {
        return 25000;
    }

    public int GetAnnualCharge()
    {
        return 1500;
    }
}

public abstract class CreditCardFactory
{
    protected abstract ICreditCard MakeProduct();

    public ICreditCard CreateProduct()
    {
        ICreditCard creditCard = MakeProduct();
        return creditCard;
    }
}

public class PlatinumFactory : CreditCardFactory
{
    protected override ICreditCard MakeProduct()
    {
        ICreditCard product = new Platinum();
        return product;
    }
}

public class TitaniumFactory : CreditCardFactory
{
    protected override ICreditCard MakeProduct()
    {
        ICreditCard product = new Titanium();
        return product;
    }
}

public class MoneyBackFactory : CreditCardFactory
{
    protected override ICreditCard MakeProduct()
    {
        ICreditCard product = new MoneyBack();
        return product;
    }
}