namespace Mindfulness;

public class BreathingActivity : Activity
{
    private int _inhaleSeconds = 4;
    private int _exhaleSeconds = 6;

    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breathing.")
    {}

    public override void Run()
    {
        Start();

        var end = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < end)
        {
            Console.Write("\nBreathe in... ");
            ShowProgressBar(_inhaleSeconds);
            Console.Write("  Breathe out... ");
            ShowProgressBar(_exhaleSeconds);
        }

        End();
    }

    private void ShowProgressBar(int seconds)
    {
        int steps = 20;
        for (int i = 0; i <= steps; i++)
        {
            double pct = i / (double)steps;
            int filled = i;
            Console.Write($"[{new string('#', filled)}{new string('-', steps - filled)}]");
            Thread.Sleep((int)(seconds * 1000.0 / steps));
            Console.Write(new string('\b', steps + 2)); // clear brackets + chars
        }
        // Clear the last progress bar completely
        Console.Write(new string(' ',  steps + 2));
        Console.Write(new string('\b', steps + 2));
    }
}
