// Exceeds core requirements:
// - Added a Summary Report (menu option 6) showing completion percentage for completable goals (Simple & Checklist).
// - Automatic summary display after each recorded event.
// - Robust save/load with input validation remains present.

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
