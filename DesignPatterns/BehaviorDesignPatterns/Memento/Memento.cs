using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.BehaviorDesignPatterns.Memento;

public class MementoProgram
{
    public static void Client(string[] args)
    {
        Article article = new();
        ArticleHistory history = new();

        article.Title = "Memento Pattern in C#";
        article.Content = "The Memento Pattern is...";
        history.Save(article);

        article.Content = "It's useful for implementing undo functionality.";
        history.Save(article);

        article.Content = "However, care must be taken about memory usage.";

        history.PrintHistory();

        article.Restore(history.GetLatestVersion());
    }
}

public class Article //Originator
{
    public string? Title { get; set; }
    public string? Content { get; set; }

    public ArticleMemento Save()
    {
        return new ArticleMemento(Title, Content, DateTime.Now);
    }

    public void Restore(ArticleMemento memento)
    {
        Title = memento.Title;
        Content = memento.Content;
    }
}

public class ArticleMemento //Memento
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime Timestamp { get; set; }

    public ArticleMemento(string? title, string? content, DateTime timestamp)
    {
        Title = title;
        Content = content;
        Timestamp = timestamp;
    }
}

public class ArticleHistory // Caretaker
{
    private Stack<ArticleMemento> _history = new Stack<ArticleMemento>();

    public void Save(Article article)
    {
        _history.Push(article.Save());
    }

    public ArticleMemento GetLatestVersion()
    {
        return _history.Pop();
    }

    public void PrintHistory()
    {
        _history.ToList().ForEach(x => Console.WriteLine($"Title: {x.Title} Content: {x.Content} Time: {x.Timestamp}"));
    }
}