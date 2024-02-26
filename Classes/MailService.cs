using System;

namespace Classes;

public class MailService
{
    public void SendEmail()
    {
        Connect();
        Disconnect();
        // Send Email
        Authenticate();
    }

    private void Connect()
    {
        Console.WriteLine("Connect");
    }

    private void Disconnect()
    {
        Console.WriteLine("Disconnect");
    }

    private void Authenticate()
    {
        Console.WriteLine("Authenticate");
    }
}