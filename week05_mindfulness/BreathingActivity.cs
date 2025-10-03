namespace Mindfulness;

public class BreathingActivity : Activity
{
    private int _inhaleSeconds = 4;
    private int _exhaleSeconds = 6;

    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by guiding you through slow breathing.")
    {}

    public override void Run()
    {
        Start();

        var end = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < end)
        {
            Console.Write("\nBreathe in... ");
            ShowCountDown(_inhaleSeconds);
            Console.Write("  Breathe out... ");
            ShowCountDown(_exhaleSeconds);
        }

        End();
    }
}
