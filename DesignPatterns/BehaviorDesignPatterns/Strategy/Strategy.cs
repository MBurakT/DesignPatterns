using System;

namespace DesignPatterns.StructuralDesignPatterns.Strategy;

public class StrategyProgram
{
    public static void Client(string[] args)
    {
        ICompression strategy = new ZipCompression();

        CompressionContext ctx = new CompressionContext(strategy);

        ctx.CreateArchive("DotNetDesignPattern");

        ctx.SetStrategy(new RarCompression());
        ctx.CreateArchive("DotNetDesignPattern");
    }
}

public interface ICompression
{
    void CompressFolder(string compressedArchiveFileName);
}

public class RarCompression : ICompression
{
    public void CompressFolder(string compressedArchiveFileName)
    {
        Console.WriteLine($"Folder is compressed using Rar approach: '{compressedArchiveFileName}.rar' file is created");
    }
}

public class ZipCompression : ICompression
{
    public void CompressFolder(string compressedArchiveFileName)
    {
        Console.WriteLine($"Folder is compressed using Zip approach: '{compressedArchiveFileName}.zip' file is created");
    }
}

public class CompressionContext
{
    ICompression _compression;

    public CompressionContext(ICompression compression)
    {
        _compression = compression;
    }

    public void SetStrategy(ICompression Compression)
    {
        _compression = Compression;
    }

    public void CreateArchive(string compressedArchiveFileName)
    {
        //The CompressFolder method is going to be invoked based on the strategy object
        _compression.CompressFolder(compressedArchiveFileName);
    }
}