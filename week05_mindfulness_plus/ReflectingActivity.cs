namespace Mindfulness;

public class ReflectingActivity : Activity
{
    private readonly PromptDeck _prompts = new(new []
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    });

    private readonly PromptDeck _questions = new(new []
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    });

    public ReflectingActivity()
        : base("Reflecting", "This activity helps you reflect on times in your life when you have shown strength and resilience.")
    {}

    public override void Run()
    {
        Start();

        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"> {_prompts.Next()}");
        Console.WriteLine("\nWhen you have something in mind, press ENTER to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on these questions...");
        Console.WriteLine("(You’ll have a few seconds between each.)\n");

        var end = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < end)
        {
            Console.WriteLine($"- {_questions.Next()}");
            // 6-second spinner between questions
            ShowSpinner(6);
        }

        End();
    }
}
