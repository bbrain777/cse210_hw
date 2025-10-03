namespace Mindfulness;

public class ReflectingActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Think of a time you stood up for someone else.",
        "Recall a moment you overcame a challenge.",
        "Remember a time you helped another person."
    };

    private readonly List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "What did you learn about yourself?",
        "How can you apply this in the future?",
        "What was the hardest part?"
    };

    public ReflectingActivity()
        : base("Reflecting", "This activity helps you reflect on times when you have shown strength and resilience.")
    {}

    public override void Run()
    {
        Start();

        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"> {GetRandom(_prompts)}");
        Console.WriteLine("\nWhen you have something in mind, press ENTER to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on these questions...");
        Console.WriteLine("(You’ll have a few seconds between each.)\n");

        var end = DateTime.Now.AddSeconds(GetDuration());
        int i = 0;
        while (DateTime.Now < end)
        {
            var q = _questions[i++ % _questions.Count];
            Console.WriteLine($"- {q}");
            ShowSpinner(6);
        }

        End();
    }
}
