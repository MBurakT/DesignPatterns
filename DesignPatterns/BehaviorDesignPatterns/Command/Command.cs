using System;

namespace DesignPatterns.StructuralDesignPatterns.Command;

public class CommandProgram
{
    public static void Client(string[] args)
    {
        Document document = new();

        ICommand openCommand = new OpenCommand(document);
        ICommand saveCommand = new SaveCommand(document);
        ICommand closeCommand = new CloseCommand(document);

        MenuOptions menuOpts = new(openCommand, saveCommand, closeCommand);

        menuOpts.ClickOpen();
        menuOpts.ClickSave();
        menuOpts.ClickClose();
    }
}

public class Document // Receiver
{
    public void Open()
    {
        Console.WriteLine("Document Opened.");
    }

    public void Close()
    {
        Console.WriteLine("Document Closed.");
    }

    public void Save()
    {
        Console.WriteLine("Document Saved.");
    }
}

public interface ICommand
{
    void Execute();
}

public class OpenCommand : ICommand
{
    Document _document;

    public OpenCommand(Document document)
    {
        _document = document;
    }

    public void Execute()
    {
        _document.Open();
    }
}

public class SaveCommand : ICommand
{
    Document _document;

    public SaveCommand(Document document)
    {
        _document = document;
    }

    public void Execute()
    {
        _document.Save();
    }
}

public class CloseCommand : ICommand
{
    Document _document;

    public CloseCommand(Document document)
    {
        _document = document;
    }

    public void Execute()
    {
        _document.Close();
    }
}

public class MenuOptions // Invoker
{
    ICommand _openCommand;
    ICommand _saveCommand;
    ICommand _closeCommand;

    public MenuOptions(ICommand openCommand, ICommand saveCommand, ICommand closeCommand)
    {
        _openCommand = openCommand;
        _saveCommand = saveCommand;
        _closeCommand = closeCommand;
    }

    public void ClickOpen()
    {
        _openCommand.Execute();
    }

    public void ClickSave()
    {
        _saveCommand.Execute();
    }

    public void ClickClose()
    {
        _closeCommand.Execute();
    }
}