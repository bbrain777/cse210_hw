namespace Mindfulness;

/// <summary>
/// Extra activity (for creativity points): a guided visualization with timed steps.
/// </summary>
public class VisualizationActivity : Activity
{
    private readonly List<string> _steps = new()
    {
        "Close your eyes and notice the weight of your body on the chair or ground.",
        "Visualize a calm place—perhaps a quiet beach or a forest path.",
        "Hear the ambient sounds in this place. Let them wash over you.",
        "Notice gentle details: the temperature of the air, a soft breeze, the scent around you.",
        "Imagine a warm light expanding from your chest with each inhale, relaxing your muscles.",
        "On each exhale, let go of tension in your face, shoulders, and hands."
    };

    public VisualizationActivity()
        : base("Visualization", "Guides you through a calm mental scene using short, paced prompts.")
    {}

    public override void Run()
    {
        Start();

        var end = DateTime.Now.AddSeconds(GetDuration());
        int i = 0;
        while (DateTime.Now < end)
        {
            var step = _steps[i++ % _steps.Count];
            Console.WriteLine($"• {step}");
            ShowSpinner(5);
        }

        End();
    }
}
