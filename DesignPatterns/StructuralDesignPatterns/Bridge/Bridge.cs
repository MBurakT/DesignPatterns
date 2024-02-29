using System;

namespace DesignPatterns.StructuralDesignPatterns.Bridge;

public class BridgeProgram
{
    public static void Client(string[] args)
    {
        LongMessage longMessage = new(new EmailMessageSender());
        ShortMessage shortMessage = new(new SmsMessageSender());

        longMessage.SendMessage("Long Message");
        shortMessage.SendMessage("Short");
    }
}

public interface IMessageSender
{
    void SendMessage(string message);
}

public class SmsMessageSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"'{message}' This message has been sent by using SMS");
    }
}

public class EmailMessageSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"'{message}' This message has been sent by using Email");
    }
}

public abstract class Message
{
    protected IMessageSender messageSender;
    public abstract void SendMessage(string message);
}

public class LongMessage : Message
{
    public LongMessage(IMessageSender messageSender)
    {
        this.messageSender = messageSender;
    }

    public override void SendMessage(string message)
    {
        messageSender.SendMessage(message);
    }
}

public class ShortMessage : Message
{
    public ShortMessage(IMessageSender messageSender)
    {
        this.messageSender = messageSender;
    }

    public override void SendMessage(string message)
    {
        messageSender.SendMessage(message);
    }
}