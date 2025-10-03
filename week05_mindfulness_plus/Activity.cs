namespace Mindfulness;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _durationSeconds;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    /// <summary>Extra credit notes:
    /// - Shared base with Start/End, spinner, countdown, random helper.
    /// - Session logging via Log() into logs.csv.
    /// </summary>

    public void SetDuration(int seconds) => _durationSeconds = seconds;
    public int GetDuration() => _durationSeconds;

    public void Start()
    {
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine(_description);
        Console.Write("\nEnter duration in seconds: ");
        if (int.TryParse(Console.ReadLine(), out var s) && s > 0) SetDuration(s);
        else SetDuration(30);

        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);
    }

    public void End()
    {
        Console.WriteLine($"\nWell done! You completed the {_name} Activity for {GetDuration()} seconds.");
        ShowSpinner(3);
        Log($"{_name},{GetDuration()},{DateTime.Now:o}");
    }

    protected void ShowSpinner(int seconds)
    {
        var end = DateTime.Now.AddSeconds(seconds);
        var glyphs = new[] { "|", "/", "-", "\\" };
        var i = 0;
        while (DateTime.Now < end)
        {
            Console.Write($"\r{glyphs[i++ % glyphs.Length]}");
            Thread.Sleep(100);
        }
        Console.Write("\r \r");
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected static readonly Random _rand = new Random();
    protected T GetRandom<T>(List<T> items) => items[_rand.Next(items.Count)];

    protected void Log(string csvLine)
    {
        try
        {
            var path = Path.Combine(AppContext.BaseDirectory, "logs.csv");
            var headerNeeded = !File.Exists(path);
            using var sw = new StreamWriter(path, append: true);
            if (headerNeeded) sw.WriteLine("activity,duration_seconds,timestamp_iso");
            sw.WriteLine(csvLine);
        }
        catch { /* ignore logging errors */ }
    }

    public abstract void Run();
}
