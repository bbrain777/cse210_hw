
using System;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var manager = new GoalManager();
        manager.Start();
    }
}
