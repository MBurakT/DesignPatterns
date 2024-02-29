using System;

namespace DesignPatterns.StructuralDesignPatterns.Facade;

public class FacadeProgram
{
    public static void Client(string[] args)
    {
        Order order = new();
        order.PlaceOrder();
    }
}

public class Product // Subsystem
{
    public void GetProductDetails()
    {
        Console.WriteLine("Fetching the Product Details");
    }
}

public class Payment // Subsytem
{
    public void MakePayment()
    {
        Console.WriteLine("Payment Done Successfully");
    }
}

public class Invoice // Subsytem
{
    public void SendInvoice()
    {
        Console.WriteLine("Invoice Send Succcesfully");
    }
}

public class Order // Facade
{
    public void PlaceOrder()
    {
        Product product = new();
        product.GetProductDetails();

        Payment payment = new();
        payment.MakePayment();

        Invoice invoice = new();
        invoice.SendInvoice();
    }
}