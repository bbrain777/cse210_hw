namespace Mindfulness;

public class ListingActivity : Activity
{
    private readonly PromptDeck _prompts = new(new []
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    });

    public ListingActivity()
        : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {}

    public override void Run()
    {
        Start();

        Console.WriteLine("\nList as many responses as you can to this prompt:");
        Console.WriteLine($"> {_prompts.Next()}");

        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        var items = new List<string>();
        var end = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            // ReadLine blocks, so we do a timed window per input
            // We'll use a 250ms polling to allow time check
            var line = TimedReadLine(250, ref end);
            if (!string.IsNullOrWhiteSpace(line))
                items.Add(line.Trim());
        }

        Console.WriteLine($"\nYou listed {items.Count} item(s).");
        End();
    }

    private static string? TimedReadLine(int pollMs, ref DateTime end)
    {
        var buffer = new System.Text.StringBuilder();
        while (DateTime.Now < end)
        {
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return buffer.ToString();
                }
                else if (key.Key == ConsoleKey.Backspace && buffer.Length > 0)
                {
                    buffer.Length--;
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    buffer.Append(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
            }
            Thread.Sleep(pollMs);
        }
        Console.WriteLine();
        return buffer.Length > 0 ? buffer.ToString() : null;
    }
}
