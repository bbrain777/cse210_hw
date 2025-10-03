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
    }

    protected void ShowSpinner(int seconds)
    {
        var end = DateTime.Now.AddSeconds(seconds);
        var glyphs = new[] { "|", "/", "-", "\\" };
        var i = 0;
        while (DateTime.Now < end)
        {
            Console.Write($"\r{glyphs[i++ % glyphs.Length]}");
            Thread.Sleep(150);
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

    protected T GetRandom<T>(List<T> items)
    {
        var rand = new Random();
        return items[rand.Next(items.Count)];
    }

    public abstract void Run();
}
