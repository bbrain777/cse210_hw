namespace Mindfulness;

public class ListingActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "List people you appreciate.",
        "List your personal strengths.",
        "List acts of kindness you’ve seen recently."
    };

    public ListingActivity()
        : base("Listing", "This activity will help you reflect on the good things by listing as many as you can.")
    {}

    public override void Run()
    {
        Start();

        Console.WriteLine("\nList as many responses as you can to this prompt:");
        Console.WriteLine($"> {GetRandom(_prompts)}");

        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        var items = new List<string>();
        var end = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            if (Console.KeyAvailable == false)
            {
                Thread.Sleep(50);
                continue;
            }
            var line = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(line))
                items.Add(line.Trim());
        }

        Console.WriteLine($"\nYou listed {items.Count} item(s).");
        End();
    }
}
